---
tags: [bereich, jarvis, tooling]
status: aktiv
date: 2026-09-07
---

# Jarvis Voice Assistant

Persönlicher Sprach-KI-Assistent (Template von Julian, [Skool Community](https://skool.com/ki-automatisierung)), am 06.09.2026 geklont und eingerichtet. Läuft lokal auf diesem Rechner, spricht Deutsch im sarkastisch-britischen Butler-Stil, hört per Mikrofon zu, antwortet per Stimme, kann Browser steuern und den Bildschirm sehen.

**Ort:** [[jarvis-voice-assistant]] direkt im Vault-Ordner (`Zweites Gehirn/jarvis-voice-assistant/`) — eigenes Git-Repo, eigenes `CLAUDE.md`, gilt nur dort.

## Starten

- **Manuell:** `python server.py` im Projektordner, dann `http://localhost:8340` in Chrome öffnen, einmal klicken (Autoplay-Policy), dann reden.
- **Automatisch:** einmal laut klatschen. Ein Windows-Task-Scheduler-Eintrag namens **"Jarvis Clap Trigger"** startet bei jeder Windows-Anmeldung `scripts/clap-trigger.py` unsichtbar im Hintergrund (`pythonw`), der bei einem Klatscher `scripts/launch-session.ps1` auslöst: startet Server, Spotify/Musik-Link, Obsidian, Claude Desktop, Chrome mit Jarvis + Limitless-Dashboard, snapped Fenster in Bildschirm-Viertel.
- Task manuell neu anstoßen (z.B. zum Testen): `Start-ScheduledTask -TaskName "Jarvis Clap Trigger"` (kein Admin nötig zum Starten, nur zum ursprünglichen Registrieren war Admin-PowerShell nötig).

## Konfiguration (`config.json`, lokal, nicht in Git)
- Name: Mike, Anrede: Sir
- Stadt (Wetter): Mönchengladbach
- Browser-Startseite: `worldoflimitless.com/affiliate` (aus dem Vault übernommen — ggf. nochmal auf die konkret gewünschte Limitless-Seite prüfen)
- "Spotify-Track"-Feld enthält aktuell einen **YouTube-Link** (2Pac), keinen echten Spotify-Track — funktioniert technisch (öffnet einfach im Browser), aber bei Bedarf durch einen echten Spotify-Link ersetzbar
- Aufgaben-Ansage bei "Jarvis activate" scannt automatisch offene Checkboxen (`- [ ]`) aus [[01 Inbox]] und [[02 Projekte]] und nennt die 2-3 wichtigsten konkret (nicht nur die Anzahl)

## Bugs gefixt (Stand 06.09.2026, falls mal wieder komisches Verhalten auftaucht)
- `config.json` wurde ohne `encoding="utf-8"` gelesen → Windows-Standard-Encoding (cp1252) hat Umlaute zerlegt. Fix in `server.py` und `clap-trigger.py`.
- Wetter-Request crashte bei Umlauten im Städtenamen (fehlendes URL-Encoding).
- `get_tasks_sync()` suchte nach einer nie existierenden `Tasks.md` — umgebaut auf Scan von Inbox + Projekte-Ordner, inkl. Bereinigung von rohen `[[Wikilinks]]` fürs Vorlesen.
- Klatsch-Erkennung: Default-Audiogerät (Intel Smart Sound Array, Kanal 0 roh) lieferte fast Stille. Fix: Gerät gezielt anhand des Namens wählen, lautesten Kanal nehmen, Schwelle von 0.15 auf 0.02 gesenkt. Ursprünglich Doppelklatsch, auf Wunsch am 06.09. auf **Einzelklatsch** umgestellt (höheres Fehlauslöser-Risiko bewusst in Kauf genommen).
- `launch-session.ps1` brach beim Server-Start ab, weil der Vault-Pfad ein Leerzeichen enthält ("Zweites Gehirn") und unquotiert in einen `cmd /k`-Aufruf eingebaut wurde. Fix: Server läuft jetzt direkt über `pythonw` (fensterlos), kein `cmd`/`wt.exe`-Umweg mehr.
- `pythonw.exe` setzt `sys.stdout`/`stderr` auf `None` (keine Konsole) → jedes `print()` crashte den Prozess sofort, bevor der Server überhaupt band. Fix: beide Skripte leiten stdout/stderr bei fehlender Konsole automatisch in `jarvis.log` (im Projektordner) um, statt zu crashen — dort nachschauen, falls der Autostart mal wieder nichts tut.
- VS-Code-Start (`code`-CLI) ist optional geworden — auf diesem Rechner ist VS Code nicht installiert, Skript überspringt das jetzt sauber statt zu hängen.

## Die Bridge: Jarvis delegiert Aufgaben an eine größere Instanz (07.09.2026)

Jarvis kann jetzt Aufgaben, die er selbst nicht kann (Recherche, Texte schreiben, Vault bearbeiten), per `[ACTION:TASK]` an [[Jarvis Aufgaben]] in der Inbox übergeben. Ein eigener kleiner Agent arbeitet das automatisch ab, ohne dass du selbst eine Claude-Session öffnen musst.

**Ablauf:**
1. Du sagst Jarvis etwas, das mehr braucht ("erstell mir einen Content-Plan...").
2. Jarvis bestätigt kurz und schreibt die Aufgabe wortwörtlich in `01 Inbox/Jarvis Aufgaben.md` (status: offen).
3. Ein Windows Scheduled Task ("Jarvis Task Watcher") prüft alle 10 Minuten diese Datei und ruft bei offenen Einträgen `scripts/task_agent.py` auf.
4. `task_agent.py` ist ein eigener kleiner Tool-Use-Agent (Claude Sonnet, plus Lese- und Schreibzugriff auf den Vault und Web-Suche, sandboxed auf den Vault-Ordner). Er bearbeitet die Aufgabe und schreibt das Ergebnis direkt in den Eintrag zurück (status: erledigt bzw. fehler).
5. Der aktuelle Stand ist live im Jarvis-Webinterface sichtbar, als Unterknoten des "Bridge"-Knotens im Wissensgraph (siehe unten), Endpoint `/tasks/status`.

**Sicherheitsdesign:** Der Task-Agent hat bewusst keinen Zugriff auf E-Mail, Kalender, Zahlungen oder Systemeinstellungen, nur lesenden und schreibenden Zugriff auf den Vault-Ordner selbst und lesenden Web-Zugriff. Kann also unbeaufsichtigt laufen, ohne dass er etwas Riskantes anrichten könnte.

**Einmaliges Setup nötig:** Der Scheduled Task muss einmal registriert werden:
```
powershell -ExecutionPolicy Bypass -File "jarvis-voice-assistant\scripts\register-task-watcher.ps1"
```
Falls "Zugriff verweigert" kommt: PowerShell als Administrator öffnen und nochmal ausführen.

**Bekannter Vorfall:** Beim Bauen dieser Funktion wurde die Datei einmal versehentlich komplett überschrieben statt ergänzt, dabei ist ein echter Auftrag von dir verloren gegangen (Content-Plan fürs IB-Business/Limitless für diese Woche, heute Vormittag per Sprache angefragt). Guardrail dagegen steht jetzt in [[jarvis-voice-assistant]]/CLAUDE.md (nur Append/Edit, nie Write auf diese Datei). Der Content-Plan-Auftrag muss neu gestellt werden, sobald du Zeit hast.

**Status 07.09.2026:** Scheduled Task ist registriert und getestet (läuft alle 10 Minuten). Spotify-Link (YouTube) und Browser-Startseite (`worldoflimitless.com/affiliate`) bleiben bewusst wie sie sind, kein Änderungsbedarf. Technisches Setup ist damit fertig.

## Interface: interaktiver Wissensgraph (07.09.2026)

Die Weboberfläche (`http://localhost:8340`) ist kein Chat-Fenster mit Orb mehr, sondern ausschließlich ein interaktiver Knoten-Graph (vis-network, lokal eingebunden, kein CDN nötig), nach Mikes eigener Referenz (Screenshot eines echten "Gehirn/Hand"-Wissensgraphen).

**Struktur:** JARVIS (Zentrum, Klick = Mikro an/aus) → **GEHIRN** (was Jarvis weiß: Vault, Wetter, Aufgaben, live) und **HAND** (was Jarvis tut: Nachrichten, Bildschirm sehen, Bridge, live). Reale Fähigkeiten sind hell/orange und anklickbar (macht dasselbe wie der entsprechende Sprachbefehl), geplante/noch nicht angebundene Fähigkeiten (Mails, E-Mail-Agent, Instagram, Telegram, Content-Erstellung, Auto-Posting) sind bewusst gedimmt und gestrichelt dargestellt, damit der Graph ehrlich zeigt was schon geht und was noch kommt. Die Bridge-Aufgaben aus [[Jarvis Aufgaben]] hängen live als eigene Unterknoten am "Bridge"-Knoten (Farbe = Status).

**Nächste Ausbaustufe ("Hand" mit echten Agenten):** Mike möchte, dass Jarvis eigenständig E-Mails checkt, Instagram- und Telegram-Nachrichten liest/einsortiert/beantwortet, selbst Content (Bilder & Videos) erstellt und automatisch nach Plan postet. Jedes davon braucht eigenen Zugriff (Mail-, Instagram-, Telegram-Anbindung, Bild-/Video-Erstellung) und ist ein eigenes Teilprojekt. Details, Reihenfolge und aktueller Stand pro Baustein: [[Jarvis Hand - Agenten Ausbau]].

**Telegram (Baustein 1) — zwei getrennte Systeme, beide live seit 07.09.2026:** Klärung im Chat ergab, dass "Telegram-Nachrichten lesen" zwei technisch unterschiedliche Dinge sein können. (a) **Business-Bot `@Mikebubot`** (`scripts/telegram_bridge.py`) — offizielle Bot API, ✅ fertig gebaut UND end-to-end getestet (Nachricht → Entwurf → Freigabe → Versand angekommen). Nur für Nachrichten, die direkt an den Bot gehen (Kunden/Leads), nicht Mikes private Chats. (b) **Persönlicher Userbot** (`scripts/telegram_userbot_bridge.py`) — für Mikes echte Nachrichten (Mama, Freunde). Kein offiziell unterstützter Weg, Mike hat das Risiko bewusst akzeptiert. Login durchgeführt (nach ein paar holprigen Versuchen, siehe [[Jarvis Hand - Agenten Ausbau]]), Baseline gesetzt, wartet jetzt auf die erste echte Testnachricht.

## Echtzeit-Vault-Zugriff (seit 07.09.2026)
Mike bemerkte, dass Jarvis kaum echten Zugriff auf den Vault hatte (z.B. konnte er einen Telegram-Entwurf nicht vorlesen). Neu: `[ACTION:VAULT]` in `server.py` — ein schneller, read-only Tool-Use-Loop (Claude Haiku, `read_vault_file`/`list_vault_dir`/`search_vault`), beantwortet Vault-Fragen in Sekunden statt über die 10-Minuten-Bridge. Bewusst nur lesend: Notizen bearbeiten/anlegen läuft weiterhin über `[ACTION:TASK]` und die Bridge, nicht direkt aus der Sprachschleife (Risiko von Verhören). Isoliert getestet: "Lies mir den offenen Telegram-Entwurf vor" hat funktioniert (fand die richtige Notiz per Volltextsuche, las den Entwurf korrekt vor).

## WhatsApp-Baustein (seit 08.09.2026, wartet auf Login)

Wie bei Telegram, aber für Mikes echten WhatsApp-Account: `jarvis-voice-assistant/scripts/whatsapp_bridge.py` (Playwright-Scraping von web.whatsapp.com, keine offizielle API für private Accounts vorhanden, daher fragiler als Telegram). Entwurf-statt-Auto-Antwort-Prinzip, bewusst nur 1:1-Chats. Code steht seit 08.09.2026, aktiv sobald Mike den einmaligen QR-Login gemacht hat (`python scripts/whatsapp_userbot_login.py`, braucht sein Handy). Details, Risiko-Hintergrund und offene Checkliste: [[Jarvis Hand - Agenten Ausbau]].

Am 08.09.2026 wurde außerdem bestätigt, dass Mike auch bei Instagram und Facebook über die Claude-in-Chrome-Erweiterung in seinem echten Chrome eingeloggt ist — beide noch nicht als eigene Bausteine gebaut, stehen laut Reihenfolge nach WhatsApp an.

## Cockpit: fünfte Kachel "Mails" (08.09.2026)

Auf Mikes Wunsch ("Interface und Überwachung fertigstellen — komplette Übersicht") kam
eine fünfte Cockpit-Kachel dazu: **Mails**, gespeist aus der neuen Notiz
[[Mails]] (`03 Bereiche/Jarvis Voice Assistant/Mails.md`), gleiches Muster wie
[[Termine]] — Snapshot, von der großen Claude-Session per Gmail-Connector aktualisiert,
keine automatische 10-Minuten-Bridge (dafür bräuchte `task_agent.py` eine eigene
Google-API-Anbindung). Erster Abruf: **201 ungelesene Mails**, größtenteils
Stepstone-Jobagent-Digests und Newsletter, siehe [[Mails]] für Details. Knoten `mails`
im Wissensgraph läuft jetzt live statt geplant, `build_system_prompt()` kennt die Zahl
bei "Jarvis activate" mit. Details/technische Umsetzung: `jarvis-voice-assistant/CLAUDE.md`.

**Nebenbei gefunden und gefixt:** Der laufende Server-Prozess war veraltet (Codestand
von vor dem WhatsApp-Endpoint), `/whatsapp/status` gab deshalb 404 zurück. Neu gestartet
— läuft jetzt mit aktuellem Code, WhatsApp-Endpoint antwortet normal.

## Offen
- Content-Plan fürs IB-Business/Limitless (diese Woche) neu beauftragen, ursprünglicher Auftrag ging beim Bridge-Bau verloren, siehe oben.
- Persönlichen Telegram-Userbot einmal end-to-end testen (echte Nachricht → Entwurf → Freigabe → Versand), siehe [[Jarvis Hand - Agenten Ausbau]].
- Echtzeit-Vault-Zugriff (`[ACTION:VAULT]`) einmal live per Sprache testen (bisher nur isoliert im Code getestet, nicht durch den echten Sprachassistenten durchgesprochen).
- WhatsApp-Baustein: QR-Login ist erledigt, Baseline-Lauf ist am 08.09.2026 10:03 gesetzt worden (keine alten Nachrichten als "neu" verarbeitet). Noch offen: eine echte eingehende Nachricht abwarten → prüfen ob ein Entwurf in [[WhatsApp Nachrichten]] erscheint → freigeben → Versand bestätigen. Erst danach den `whatsapp`-Knoten in `frontend/main.js` auf live umstellen.
- **Update 08.09.2026 (Nachmittag):** Live bei PU Prime (IB-Dashboard) und Limitless nachgesehen (siehe [[Kunden]], [[Einnahmen]], [[PU Prime]], [[Limitless]]) — die 0 in Kundenstamm/Verdienste ist bestätigt der echte aktuelle Stand, keine unausgefüllte Vorlage mehr. Offen bleibt nur Mikes separates persönliches Trading-Kontoguthaben (~1,48 €, andere Login-Session, aktuell abgelaufen).
- Mail als echter "Hand"-Baustein (automatische Entwürfe wie bei Telegram) — noch offen, braucht eigene Google-API-Anbindung in `task_agent.py`, siehe [[Jarvis Hand - Agenten Ausbau]].
- Übrige "Hand"-Agenten bauen: Instagram/Facebook lesen+beantworten (ToS-Risiko-Entscheidung mit Mike noch offen), Content-Erstellung (Bild/Video), Auto-Posting nach Plan — jeweils eigenes Teilprojekt, siehe [[Jarvis Hand - Agenten Ausbau]].
