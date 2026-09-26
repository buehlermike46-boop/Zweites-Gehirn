---
tags: [projekt, jarvis]
status: aktiv
date: 2026-09-07
---

# Jarvis "Hand" – Agenten-Ausbau

Briefing-Datei für eine neue Chat-Session. Enthält Ziel, aktuellen Stand und was zu klären ist, damit die neue Session nicht bei null anfängt.

**Gesamtziel nie vergessen (von Mike am 08.09.2026 präzisiert):** Alles hier sind Bausteine auf dem Weg zu einem Agenten-System, das Kundenakquise (Content + Auto-Posting) und Kundenbetreuung komplett übernimmt, dazu eine Live-Kundenanalyse (Funnel-Stufe/Wert/Risiko) liefert, Termine im Blick behält, und langfristig ganz ohne Mikes einzelne Freigabe auf das Ziel 50.000 €/Monat hinarbeitet. Volles Konzept: [[Vision - Vault-Wachstum, Jarvis-Assistent & Monitoring]], Geschäftsziel: [[IB-Projekt (Limitless & PU Prime)]].

## Ziel

Jarvis (der Sprachassistent, siehe [[Jarvis Voice Assistant]]) soll eigenständig Aufgaben erledigen können, nicht nur Auskunft geben:
1. **Mails checken** — E-Mails lesen, ggf. sortieren/zusammenfassen
2. **Instagram-Nachrichten** lesen, einsortieren, Antworten formulieren
3. **Telegram-Nachrichten** lesen, einsortieren, Antworten formulieren
4. **WhatsApp-Nachrichten** lesen, einsortieren, Antworten formulieren (dazugekommen 08.09.2026)
5. **Facebook-Nachrichten** lesen, einsortieren, Antworten formulieren (dazugekommen 08.09.2026, noch nicht gebaut)
6. **Content selbst erstellen** — Bilder und Videos
7. **Automatisch posten** nach einem festgelegten Plan

Im neuen Webinterface (Wissensgraph) ist das der **"HAND"**-Ast. Die Punkte oben sind dort als Knoten eingezeichnet (`mail-agent`, `instagram`, `facebook`, `telegram`, `whatsapp`, `content`, `autopost`), bewusst gedimmt/gestrichelt = geplant, noch nicht angebunden, bis ein Baustein wirklich funktioniert (dann in `jarvis-voice-assistant/frontend/main.js` `plannedNode` → `liveNode` umstellen). **`telegram` ist seit 07.09.2026 als "live" umgestellt.** `whatsapp` ist seit 08.09.2026 fertig gebaut, aber noch als geplant (gedimmt) markiert, bis Mike den einmaligen QR-Login gemacht hat (siehe unten).

**Grundsatzentscheidung 08.09.2026 (gilt fuer alle neuen Nachrichten-Bausteine):** Mike hat bestaetigt, dass ALLE neuen Kanaele (WhatsApp, spaeter Instagram/Facebook) nach dem gleichen Entwurf-statt-Auto-Antwort-Prinzip laufen wie Telegram — Jarvis liest/sortiert automatisch und schreibt Entwuerfe, aber nichts geht ohne Mikes Freigabe raus. Ausserdem: Bausteine werden NACHEINANDER gebaut, nicht alle parallel (WhatsApp zuerst, siehe Reihenfolge unten), jeweils mit kurzer Bestaetigung bevor der naechste losgeht.

## Aktueller Stand (07.09.2026)

- **Ort:** `Zweites Gehirn/jarvis-voice-assistant/` — eigenes Git-Repo, eigene `CLAUDE.md` dort (lesen!).
- **Läuft:** Sprachassistent (`server.py`, FastAPI + Claude Haiku + ElevenLabs TTS), startet automatisch per Klatschen (Windows Scheduled Task "Jarvis Clap Trigger").
- **Die Bridge:** Jarvis kann Aufgaben, die er selbst nicht kann, per `[ACTION:TASK]` an `01 Inbox/Jarvis Aufgaben.md` übergeben. Ein Scheduled Task ("Jarvis Task Watcher", alle 10 Minuten) ruft `scripts/task_agent.py` auf — ein eigener kleiner Tool-Use-Agent (Claude Sonnet über die rohe Anthropic-API, **nicht** über Claude Code/MCP), der offene Aufgaben abarbeitet. Er hat nur Vault-Lese-/Schreibzugriff und lesenden Web-Zugriff (Playwright headless), sonst nichts.
- **Interface:** interaktiver Wissensgraph (vis-network, lokal vendored in `frontend/vendor/`), JARVIS → GEHIRN/HAND → Einzelknoten. `/context/status` und `/tasks/status` Endpoints in `server.py` liefern die Live-Daten dafür.
- Details, Architektur, alle bisherigen Bugfixes: [[Jarvis Voice Assistant]].

## Wichtige technische Erkenntnis — zuerst lesen

Es gibt **zwei unterschiedliche "Claude"-Umgebungen**, die leicht verwechselt werden:

1. **Diese interaktive Session** (Claude Desktop / Claude Code, wie die die gerade dieses Briefing schreibt) hat Zugriff auf MCP-Connectoren, die bereits eingerichtet sind — u.a.:
   - Ein **Gmail-Connector** (Mails lesen, Labels, Entwürfe, Antworten, Weiterleiten — volle Mail-Funktionalität)
   - Ein **Google-Calendar-Connector**
   - Eine **Content-/Media-Suite** (Bild-/Video-/Audio-Generierung, u.a. auch TikTok-Publishing-Tools) — Details beim nächsten Start mit `ToolSearch` oder in der Tool-Liste der neuen Session nachsehen, Name/Umfang kann sich ändern.
   - Kein sichtbarer Instagram- oder Telegram-API-Connector (Instagram lief bisher nur über eine eingeloggte Browser-Session im Claude-Browser-Tool, siehe unten).

2. **`task_agent.py`** (der unbeaufsichtigt im Hintergrund laufende Bridge-Agent) läuft über die **rohe Anthropic-API**, nicht über Claude Code/MCP. Er hat **keinen** Zugriff auf die Connectoren aus Punkt 1 — nur auf die Tools, die explizit in `task_agent.py` selbst definiert sind (aktuell: Vault lesen/schreiben, Web-Suche/-Abruf).

**Konsequenz:** Damit "Mails checken" oder "Content posten" wirklich *automatisch/unbeaufsichtigt* passiert (Mikes Ziel), reicht es nicht, dass diese interaktive Session Zugriff hat — die Fähigkeit muss entweder (a) `task_agent.py` selbst beigebracht werden (eigene API-Anbindung, eigene Zugangsdaten in `config.json`), oder (b) es wird bewusst akzeptiert, dass dieser Teil nur läuft wenn jemand eine interaktive Session öffnet (weniger "vollautomatisch", aber schneller gebaut). Das sollte pro Baustein einzeln entschieden werden, nicht pauschal.

## Die Bausteine — Ausgangslage je Baustein

### 1. Mails — ✅ Code gebaut 26.09.2026, wartet auf Zugangsdaten

**Update 26.09.2026:** Mike wollte einen echten Wach-Agenten (Gmail + GMX überwachen, Werbung automatisch löschen, bei Wichtigem Bescheid geben) — nicht mehr nur "on demand" über die interaktive Session. Die ursprüngliche Annahme oben ("Gmail braucht eigenes Google-API-Projekt + OAuth") war zu pessimistisch: ein **IMAP-App-Passwort** (Google-Konto mit 2FA vorausgesetzt) reicht für automatischen, unbeaufsichtigten Zugriff völlig aus — kein OAuth-Flow nötig. Gleicher Weg funktioniert auch für GMX und ist dort sogar die Lösung für ein zweites, älteres Problem: die GMX-Browser-Automatisierung in `broker_bridge.py` (siehe Baustein 7 unten) scheiterte zuverlässig am SSO-Redirect im headless-Modus — IMAP umgeht das Problem komplett, weil kein Browser mehr im Spiel ist.

Neu: `jarvis-voice-assistant/scripts/mail_bridge.py`, eingehängt in `task_agent.py`, läuft alle 10 Minuten wie die anderen Bridges. Werbung (Newsletter, Rabattaktionen, Jobagent-Digests etc.) wird automatisch in den Papierkorb verschoben (reversibel, ~30 Tage, Protokoll in [[03 Bereiche/Jarvis Voice Assistant/Mail-Löschungen]]), Wichtiges landet zusätzlich in [[Mails]]/[[GMX Mails]] UND löst eine Telegram-Nachricht an Mike selbst aus (über den bestehenden Business-Bot `@Mikebubot`). Im Zweifel klassifiziert der Filter bewusst als "neutral" statt "werbung" — nichts wird gelöscht wenn nicht sicher. Details: `jarvis-voice-assistant/CLAUDE.md`, Abschnitt "Mail-Bruecke: Gmail + GMX per IMAP".

**Noch offen, bevor es live läuft (Mike selbst, kein Werkzeug kann das für ihn):**
- [ ] Google-Konto: 2-Faktor-Bestätigung aktivieren, App-Passwort unter myaccount.google.com/apppasswords erzeugen, `gmail_address`/`gmail_app_password` in `config.json` eintragen
- [ ] GMX: "POP3/IMAP-Abruf" in den GMX-Einstellungen aktivieren, App-/Programm-Passwort erzeugen, `gmx_address`/`gmx_app_password` in `config.json` eintragen
- [ ] Einmalig eine Nachricht an `@Mikebubot` schicken, eigene chat_id aus dem entstehenden Block in [[03 Bereiche/Jarvis Voice Assistant/Telegram Nachrichten]] ablesen, als `mike_telegram_chat_id` in `config.json` eintragen (danach den Test-Block auf `status: ignorieren` setzen)

Bis dahin bleibt der Baustein inaktiv (kein Fehler, gleiches Prinzip wie bei WhatsApp/Broker vor dem jeweiligen Login).

### 2. Instagram
Kein offizieller API-Connector vorhanden. Mike ist sowohl in einer Browser-Session im eigenen Claude-Browser-Tool als auch (bestätigt 08.09.2026) über die **Claude in Chrome**-Erweiterung in seinem echten Chrome bei Instagram eingeloggt (Account "Mike Bühler") — darüber liest/schreibt man technisch per Browser-Automatisierung, was aber gegen Instagrams Nutzungsbedingungen verstößt und das Konto gefährden kann. **Vor dem Bauen mit Mike klären**, ob Browser-Automatisierung das gewünschte Risiko ist, oder ob z.B. die offizielle Instagram-Graph-API (Meta Business, deutlich eingeschränkter aber ToS-konform) der bessere Weg ist. Noch nicht gebaut — laut Reihenfolge unten nach WhatsApp dran.

### 2b. Facebook (neu, 08.09.2026)
Gleiche Ausgangslage wie Instagram: kein offizieller API-Connector, aber Mike ist über Claude in Chrome in seinem echten Chrome eingeloggt (Account "Mike Bühler", bestätigt 08.09.2026). Noch nicht gebaut, gleiche ToS-Risiko-Abwägung wie bei Instagram nötig bevor losgelegt wird (Meta erkennt automatisiertes Verhalten erfahrungsgemäß aggressiver als Telegram).

### 3. Telegram — zwei getrennte Bausteine (Stand 07.09.2026)

**Wichtige Korrektur ggü. der ursprünglichen Annahme oben:** Die Telegram Bot API (offiziell, "kein ToS-Risiko") sieht NUR Nachrichten, die direkt an einen separaten Bot-Account geschrieben werden — sie hat keinerlei Zugriff auf Mikes echte persönliche Chats (Mama, Freunde etc.). Für "meine echten Nachrichten lesen" braucht es einen anderen, riskanteren Weg (Userbot/Client-API). Deshalb zwei getrennte Systeme:

**3a. Business-Bot `@Mikebubot` (Bot API) — ✅ fertig gebaut & getestet.**
`jarvis-voice-assistant/scripts/telegram_bridge.py`, eingehängt in `task_agent.py`. Offiziell unterstützt, kein ToS-Risiko. Für Kundenanfragen/Leads die den Bot direkt anschreiben (z.B. über einen Link/QR in Content/Bio) — NICHT für Mikes private Nachrichten. Entwurf-statt-Auto-Antwort-Prinzip (Basis: `00 Kontext/Schreibstil.md`, `ICP.md`, `Angebot.md`), Entwürfe landen in [[03 Bereiche/Jarvis Voice Assistant/Telegram Nachrichten]]. End-to-end getestet am 07.09.2026: Nachricht an Bot → Entwurf erschien → Freigabe gesetzt → Antwort kam wirklich in Telegram an.

**3b. Persönlicher Userbot (Client-API/MTProto via Telethon) — ✅ live seit 07.09.2026.**
`jarvis-voice-assistant/scripts/telegram_userbot_bridge.py` + `scripts/telegram_userbot_login.py`. Läuft mit Mikes echtem Account (Telefonnummer), sieht dadurch wirklich alle 1:1-Chats. **Kein offiziell unterstützter Automatisierungsweg** — Telegram kann automatisiertes Verhalten auf einem echten Nutzer-Account als Missbrauch werten und den Account einschränken. Mike hat dieses Risiko am 07.09.2026 im Chat explizit akzeptiert (siehe Chat-Verlauf). Risikomindernd: gleiches Entwurf-Freigabe-Prinzip (nichts geht automatisch raus), bewusst nur 1:1-Chats mit echten Personen (keine Gruppen/Kanäle/Bots). Entwürfe landen in [[03 Bereiche/Jarvis Voice Assistant/Telegram Persönlich]].

**Login-Erfahrung (für später, falls nochmal ein Login-Reset nötig wird):** Der erste Login-Versuch ist mehrfach an einem Verbindungsaussetzer ("Server closed the connection") mitten in der Code-Eingabe gescheitert. Danach mehrfach neu gestartet — Telegram hat dabei über eine ganze Weile **keinen neuen Code verschickt** (dieselbe Nachricht blieb stehen), vermutlich ein Anti-Missbrauch-Bremser wegen mehrerer Versuche kurz hintereinander. Hat sich nach einer Pause von selbst gelöst. **Lehre:** bei Login-Problemen nicht in schneller Folge neu versuchen (macht es eher schlimmer, siehe Risiko oben), sondern ein paar Minuten bis Stunden Pause lassen.

**Wichtiger Code-Fix direkt nach dem ersten Login:** Der allererste Lauf hätte sonst die jeweils letzte Nachricht aus JEDEM 1:1-Chat (auch tagealte) als "neu" behandelt und auf einen Schlag Dutzende Entwürfe erzeugt. Gefixt: der erste Lauf setzt nur einen Zeitstempel als Basis, ohne etwas zu verarbeiten — erst Nachrichten danach zählen als neu.

### 4. WhatsApp — ✅ Code gebaut 08.09.2026, wartet auf Login

Mike ist über Claude in Chrome in seinem echten Chrome bei WhatsApp Web eingeloggt (bestätigt 08.09.2026) — das ist aber nur diese interaktive Session, nicht der unbeaufsichtigte `task_agent.py`. Für den echten HAND-Baustein (automatisches Lesen/Entwürfe alle 10 Minuten, ohne dass eine Chat-Session offen sein muss) gibt es **keine offizielle API für private WhatsApp-Accounts** — anders als bei Telegram (MTProto) musste hier auf Browser-Automatisierung per Playwright zurückgegriffen werden (DOM-Scraping von web.whatsapp.com: `#pane-side`, `data-pre-plain-text`, `message-in`/`message-out`-Klassen, JID aus `data-id`).

`jarvis-voice-assistant/scripts/whatsapp_bridge.py` + `scripts/whatsapp_userbot_login.py`, eingehängt in `task_agent.py`. Gleiches Entwurf-statt-Auto-Antwort-Prinzip wie Telegram 3a/3b (Grundsatzentscheidung siehe oben), gleiche Risikoeinordnung wie der Telegram-Userbot: kein offiziell unterstützter Automatisierungsweg, WhatsApp könnte automatisiertes Verhalten als Missbrauch werten und die Geräteverknüpfung/den Account einschränken. Mike hat dieses Risiko am 08.09.2026 im Chat bewusst akzeptiert. Bewusst nur 1:1-Chats (JIDs auf `@c.us`), keine Gruppen (`@g.us`). Entwürfe landen in [[03 Bereiche/Jarvis Voice Assistant/WhatsApp Nachrichten]].

**Bewusst fragiler als Telegram:** DOM-Scraping statt einer stabilen API — ändert WhatsApp sein Web-UI, findet die Brücke stumm nichts mehr (kein Fehler, einfach keine neuen Entwürfe). Bei Verdacht auf Stillstand zuerst dort ansetzen (Selektoren in `whatsapp_bridge.py` prüfen).

**Noch offen, bevor der Baustein wirklich läuft:**
- [x] Mike führt `python scripts/whatsapp_userbot_login.py` selbst aus (braucht sein Handy zum QR-Scannen) — erledigt (Marker-Datei `whatsapp_login_done` vorhanden)
- [x] Baseline-Lauf abwarten (erster Zyklus verarbeitet keine alten Nachrichten, setzt nur Zeitstempel je Chat) — 08.09.2026 10:03 gesetzt, danach läuft der 10-Minuten-Poll fehlerfrei
**Update 10.09.2026, Bridge repariert:** Die WhatsApp-Bruecke lag seit dem 09.09. abends still. Zwei Ursachen, beide im Log belegt:
1. Am 09.09. mittags war das Profil noch eingeloggt, aber jeder Chat-Klick lief in `Locator.click: Timeout 30000ms exceeded` (14 von 14 Chats uebersprungen).
2. Ab 09.09. 19:59 dann durchgehend `#pane-side nicht gefunden`, das Profil war aus WhatsApp Web ausgeloggt.

Nach einem neuen QR-Login (`python scripts/whatsapp_userbot_login.py`, 10.09.2026) laeuft der Poll wieder fehlerfrei: keine Timeouts, keine Fehlerzeilen, die Chatliste wird sauber abgearbeitet.

**Wichtig fuer den Test:** Eine Nachricht an sich selbst taugt nicht als Test. `poll_incoming()` ueberspringt alle `message-out`-Bubbles, im Chat "Nachricht an mich selbst" ist ausnahmslos alles message-out. Der Test braucht eine echte eingehende Nachricht von einer anderen Person in einem 1:1-Chat.

- Einmal end-to-end testen: echte Nachricht von einer anderen Person rein → Entwurf erscheint in [[03 Bereiche/Jarvis Voice Assistant/WhatsApp Nachrichten]] → freigeben → Versand kommt wirklich an. Aufgabe läuft über [[Aufgaben-Triage (Sofort, Aufwendig, Komplex)]], hier nicht doppelt tracken
- `whatsapp`-Knoten in `frontend/main.js` von `reachableNode` auf `liveNode` umstellen, sobald obiges bestätigt ist — Aufgabe läuft über [[Aufgaben-Triage (Sofort, Aufwendig, Komplex)]], hier nicht doppelt tracken
- Nach ein paar Tagen Betrieb prüfen, ob WhatsApp irgendwelche Warnungen/Einschränkungen an der Geräteverknüpfung zeigt — Aufgabe läuft über [[Aufgaben-Triage (Sofort, Aufwendig, Komplex)]], hier nicht doppelt tracken

**Update 08.09.2026 (Cockpit-Ausbau):** Beim Fertigstellen des Interfaces/Monitorings fiel
auf, dass der laufende Server-Prozess veraltet war (`/whatsapp/status` gab 404 zurück,
obwohl der Endpoint längst im Code stand) — neu gestartet, läuft jetzt aktuell. Außerdem
neu: eine fünfte Cockpit-Kachel **Mails** (Snapshot aus Gmail, von der großen Session auf
Zuruf aktualisiert, keine automatische Bridge) — Details in [[Jarvis Voice Assistant]] und
`jarvis-voice-assistant/CLAUDE.md`. Kunden.md/Einnahmen.md warten weiterhin auf echte
Zahlen von Mike, siehe dort.

### 5. Content-Erstellung (Bilder/Videos)

**Update 08.09.2026:** Erste Content-Pipeline steht. Wichtige Lektion dabei (siehe Memory
[[content-limitless-muss-informativ-sein]]): Content muss echten Informationswert zum
Limitless-Angebot haben (was ist drin, was kostet es, Ergebnisse laut Anbieter), nicht nur
hübsche Motiv-Grafik.

**Technischer Aufbau:** `Desktop/Lim/Content/` (bewusst außerhalb des Obsidian-Vaults, da
Bild-/Video-Dateien groß sind). `_template/render_posts.py` + `content_list.py` rendern
Posts lokal per Playwright aus HTML/CSS (1080×1350) statt komplett per KI-Bildgenerator —
dadurch immer korrektes Limitless-Logo (echtes Asset von `worldoflimitless.com`, aus
`Assets/limitless-logo.png`, nie KI-nachgezeichnet) und exakter, planbarer Text. `Assets/`
enthält 9 wiederverwendbare KI-generierte Hero-Illustrationen (Bulle, Roboter, Rakete,
Schachfigur, Gehirn, Meditation, Tür, Treppe, Globus), einmalig über Canva erzeugt.

**Update 08.09.2026 (Abend) — Batch 2 fertig, alle 50 Bilder stehen:** Die restlichen 26
Bilder gebaut (`content_list.py` von 24 auf 50 Items erweitert, gleiche Fakten-Regel wie
Batch 1, neue Aspekte: PrimeVerse-Säulen, Traverse/Lifestyle-Mitgliedschaft, ganzheitlicher
Ansatz (PrimeFit/Mindset Mastery/Financial Planning/Social Media Training), FAQ-Format
(Prüfdauer, Zeitaufwand, Geschäftsmodell, Kündigung), Copy-Trading- und Stop-Loss-Erklärung,
Mythen-Richtigstellung, ehrliche Grenzen ("ich verspreche dir keine Gewinne"). Alle 50 Bilder
mit `render_posts.py` gerendert, liegen in `Bilder/`.
**Nebenbei gefundener und gefixter Bug:** die 3 neuen Hero-Illustrationen (Tür, Treppe,
Globus) hatten einen sichtbaren schwarzen Kasten statt transparentem Hintergrund (Download-
Artefakt) — deshalb waren sie tags zuvor bewusst noch nicht verwendet worden. Per Chroma-Key-
Skript (Pillow, Luminanz-Schwellwert mit weicher Kante) behoben, neue `-fixed.png`-Varianten
in `Assets/` erzeugt (Originale bleiben erhalten), `render_posts.py` zeigt jetzt darauf.
**Ziel laut Mike weiterhin: 50 Bilder + 10 Videos als Vorrat, bevor irgendetwas gepostet
wird** (Freigabe-Prinzip wie bei den Nachrichten-Bausteinen) — die 50 Bilder sind damit
erreicht.

**Update 08.09.2026 (spät abends) — auch die 10 Videos fertig, Media-Suite-Plan-Frage
geklärt:** Balance-Check bestätigt: Mike ist auf dem "free"-Plan mit 10 Credits — Video-
Generierung über den KI-Connector (Higgsfield) ist noch teurer pro Generierung als
Bildgenerierung (grob ~24x mehr Credits/Generation laut Plan-Übersicht) und auf free
komplett gesperrt. Ein 3-Tage-Trial wäre verfügbar, verlangt aber eine hinterlegte
Kreditkarte und rechnet nach 3 Tagen automatisch auf 49€/Monat ab — das ist ein Kauf/Abo-
Entscheid, den nur Mike selbst treffen kann, daher nicht gestartet.

**Stattdessen dieselbe Masche wie bei den Bildern:** eigene Video-Produktion per HTML/CSS-
Animation + Playwright-Videoaufzeichnung, komplett kostenlos, exakter Text (kein KI-
Videogenerator nötig). Neue Dateien: `_template/video_list.py` (10 Items, gleiche Fakten-
Regel) und `_template/render_videos.py` (Playwright `record_video_dir` nimmt die Animation
als WebM auf, ffmpeg konvertiert nach MP4/H.264 für Instagram). Format 1080×1920 (Reels/
Stories, 9:16) statt dem 4:5-Bildformat — bewusst anders gewählt, da Videos meist für Reels
gedacht sind; bei Bedarf änderbar. Drei Animationsstile: `counter` (Zahl zählt hoch, z. B.
1.000+ Mitglieder), `hero_pulse` (Hero-Illustration pulsiert sanft + Text), `reveal` (Icons/
Schritte erscheinen nacheinander). Alle 10 MP4s (6-8s, je unter 1,3 MB) liegen in
`Lim/Content/Videos/`. **Damit ist auch das Video-Ziel (10) erreicht — gepostet wird
weiterhin bewusst nichts.**

**Wichtige Einschränkung gefunden:** Der eigentliche KI-Bildgenerierungs-Connector (Modelle
wie `nano_banana`) lehnt auf Mikes aktuellem kostenlosen Plan ab ("Requires basic plan or
higher") — nur 10 Credits vorhanden, die dafür gar nicht nutzbar waren. Ausweichlösung:
Canva (funktioniert, kein Plan-Limit getroffen) für die paar Hero-Illustrationen, der Rest
läuft über das eigene HTML-Templating. Für die 10 Videos ist noch offen, ob das gleiche
Plan-Limit greift — als Nächstes zu klären.

**Update 08.09.2026 (Abend) — Kundenergebnisse aus Chats:** Mike wollte wissen, ob Ergebnisse,
die Kunden im Chat schicken (z.B. eigene Trading-Screenshots), in Storys/Posts einfließen
können. `telegram_bridge.py` (nur der Business-Bot `@Mikebubot`, NICHT der persönliche
Userbot/WhatsApp — das sind private Kontakte, keine Kunden) erkennt jetzt Foto-Nachrichten
zusätzlich zu Text, lädt sie herunter und legt sie als neuen Eintrag in
[[03 Bereiche/Jarvis Voice Assistant/Kundenergebnisse]] ab (`status: neu`). Bilddatei selbst
liegt unter `Lim/Content/Kundenergebnisse/eingang/`. **Bewusst nicht automatisch verwendet**
— Persönlichkeitsrechte/Datenschutz: Mike muss pro Ergebnis freigeben, ob es `anonym` (Name/
Kontodetails verpixelt) oder `mit-name` (nur nach ausdrücklicher Zustimmung der Person)
verwendet werden darf, oder `abgelehnt`. Aktuell noch keine echten Kunden, also noch nichts
zum Testen — sobald der erste echte Screenshot reinkommt, einmal end-to-end durchtesten und
dann eine eigene "Testimonial"-Vorlage im Bilder-Renderer (`render_posts.py`) dafür bauen.

**Posten selbst ist schon vorbereitet, aber pausiert bis Mike den Content-Stil freigibt:**
Instagram (`@mike_bueh`) ist bereits über einen Windsor.ai-Connector live angebunden
(`create_image_post`/`create_carousel_post`/`create_video_post`/`create_story` funktionieren
direkt, kein Browser-Umweg nötig). Facebook ist bei Windsor nur für Ads verbunden, nicht für
normales Seiten-Posting — bräuchte eine zusätzliche einmalige Freigabe von Mike, falls
gewünscht. Ein einzelner Pilot-Post wurde vorbereitet (Canva-Design + Caption), aber auf
Mikes Wunsch NICHT gepostet — stattdessen wird jetzt erst Vorrat gesammelt.

### 6. Auto-Posting nach Plan
Braucht: (a) einen Redaktionsplan/Datenquelle (z.B. eine Vault-Notiz mit geplanten Posts, siehe die Content-Pläne in [[03 Bereiche/Marketing & Kundenakquise]]), (b) tatsächlichen Zugriff zum Posten je Plattform (Instagram/Facebook/Telegram, siehe Punkte 2+2b+3), (c) einen Scheduler der zur richtigen Zeit postet — könnte auf demselben Scheduled-Task-Muster wie "Jarvis Task Watcher" aufbauen.

### 7. Broker-Dashboards (PU Prime IB + Limitless) — ✅ Code gebaut 09.09.2026, wartet auf Login

Auf Mikes ausdrücklichen Wunsch ("wirklich automatisch alle 10 Min, das Dashboard soll sich selbst füttern, nicht erst nach Bestätigung") gebaut: `scripts/broker_bridge.py` + `scripts/broker_login.py`, gleiches Muster wie WhatsApp — eigenes Profil, einmaliger Login durch Mike, danach rein lesend alle 10 Min mit `task_agent.py` mitgelaufen. Schreibt nach [[Broker-Dashboards]], angezeigt im Kunden-Panel des Dashboards. Details/Fragilität siehe `jarvis-voice-assistant/CLAUDE.md`.

**Bewusst NICHT** angefasst: `myaccount.puprime.com` (persönliches Handelskonto) — Cloudflare-Bot-Check, "Bots umgehen" ist eine harte Grenze bei mir.

**Update 09.09.2026 (Abend):** GMX mit in `broker_login.py`/`broker_bridge.py` aufgenommen
(dritter Login-Schritt im selben Profil, schreibt [[GMX Mails]], im Cockpit an die
"Mails"-Kachel angehängt). Mike ist bei PU Prime, Limitless und GMX in seinem normalen
Chrome eingeloggt bestätigt — das dedizierte Bridge-Profil braucht aber weiterhin einen
EIGENEN, separaten Login (siehe Klarstellung unten).

**Update 10.09.2026: PU Prime aus der Brücke genommen.** Live geprüft: `ibportal.puprime.com` leitet auf `myaccount.puprime.com` um und zeigt dort einen Cloudflare-Bot-Check. Der läuft nur in Mikes normalem Chrome durch, im dedizierten Playwright-Profil nicht, und Bot-Erkennung wird bewusst nicht umgangen. Die Brücke hätte den Status damit dauerhaft auf "teilweise: PU Prime nicht lesbar" gehalten.

Umgesetzt:
- `broker_bridge.py`: neue Konstante `PUPRIME_ENABLED = False` ganz oben, der PU-Prime-Leseblock wird übersprungen und erzeugt keinen Fehlereintrag mehr. Auf `True` setzen, falls PU Prime den Check irgendwann fallen lässt
- `broker_bridge.py`: schreibt die Notiz nicht mehr komplett neu, sondern übernimmt alles ab der ersten `## `-Überschrift unverändert. Damit überlebt der manuelle PU-Prime-Abschnitt in [[Broker-Dashboards]] jeden Bridge-Lauf
- `broker_login.py`: nur noch 2 Schritte (Limitless, GMX), der PU-Prime-Schritt entfällt mit Erklärtext
- **Wichtig:** Beides greift erst, wenn der laufende `task_agent.py`-Prozess die Skripte neu einliest. Im Zweifel den Task Watcher einmal neu starten

PU-Prime-Zahlen kommen ab jetzt auf Zuruf über Claude in Chrome. Erster manueller Abruf am 10.09.2026: Total Commission 0,00 USD, Available Balance 0,00 USD, New/FTD Clients und Opened Accounts jeweils 0, in "Recently Opened Accounts" nur Mikes eigenes Konto. Limitless am selben Tag: 0 Referrals. Es gibt also bisher keinen einzigen geworbenen Kunden.

**Noch offen, bevor es wirklich live läuft:**
- [ ] Mike führt `python scripts/broker_login.py` einmal selbst aus (jetzt 3 Schritte: PU Prime IB-Dashboard, Limitless, GMX — alle in einem eigenen, separaten Browser-Fenster, NICHT dasselbe wie in Chrome eingeloggt zu sein)
- [x] Login am 10.09.2026 erneut durchgefuehrt (jetzt nur noch Limitless und GMX). Limitless liefert Werte, PU Prime ist deaktiviert.
**GMX war offen, jetzt gelöst (26.09.2026): per IMAP statt Browser.** Der SSO-Redirect-Block (`auth.gmx.net` erkennt die Session im headless-Profil nicht) betraf nur den Browser-Weg. GMX ist deshalb komplett aus `broker_bridge.py`/`broker_login.py` entfernt und läuft seit 26.09.2026 stattdessen über `scripts/mail_bridge.py` (IMAP + App-Passwort) — siehe Baustein 1 oben.

**Weiterhin offen, jeweils Mikes eigene Entscheidung, damit ALLE genannten Kanäle wirklich automatisch laufen:**
- ~~**Gmail für `task_agent.py` selbst:** bräuchte ein neues Google-Cloud-Projekt + OAuth-Zustimmung durch Mike~~ — **gelöst 26.09.2026:** ein IMAP-App-Passwort reicht, kein OAuth-Projekt nötig, siehe Baustein 1 oben (`scripts/mail_bridge.py`).

### 8. Instagram/Facebook — Content-Reichweite ✅ live, Nachrichten-Bridge ⛔ blockiert (09.09.2026)

Mike wollte "beides": Content-Reichweite/Views UND eine Nachrichten-Bridge wie bei
WhatsApp. Content-Reichweite ist live (echte Zahlen: 151 Follower, 2 Beiträge, siehe
[[Instagram-Reichweite]], über den bestehenden Windsor.ai-Connector, kein neuer Login
nötig) — davon unabhängig und unverändert nutzbar.

Für die Nachrichten-Bridge (`scripts/social_bridge.py` + `scripts/social_login.py`, gleiches
Muster wie WhatsApp) hat Mikes erster Login-Versuch am 09.09.2026 nicht funktioniert:
Instagram zeigt beim dedizierten Playwright-Profil dauerhaft eine leere reCAPTCHA-Seite
(nur Meta-Logo, lädt auch nach mehrfachem Neuladen nicht) — ein Bot-Erkennungs-Block noch
vor dem Passwort-Schritt. Wurde bewusst nicht umgangen (harte Grenze). `social_login_done`
ist NICHT gesetzt, die Bridge bleibt inaktiv. Details siehe `jarvis-voice-assistant/CLAUDE.md`.

**Status/nächste Schritte:**
- [x] ~~Mike führt `python scripts/social_login.py` einmal selbst aus~~ — versucht 09.09.2026, an Instagram-reCAPTCHA gescheitert
- [ ] Facebook-Schritt wurde dadurch noch gar nicht erreicht (Instagram kommt zuerst im Skript) — mit der Zuruf-Entscheidung vorerst gegenstandslos
- [x] **Entschieden am 10.09.2026 (Mike): erstmal auf Zuruf lassen.** Keine weiteren Login-Versuche mit dem dedizierten Profil, Instagram- und Facebook-Nachrichten holt die interaktive Session, wenn Mike danach fragt. Die Bridge-Dateien bleiben liegen, `social_login_done` bleibt ungesetzt
- [ ] Zurückgestellt (10.09.2026): Der einzig saubere Weg wäre die offizielle Meta Graph API (eigenes Projekt, App-Registrierung, Freigabeprozess). Wird erst wieder Thema, wenn das Nachrichtenvolumen es rechtfertigt

## Vorschlag Reihenfolge

**Update 08.09.2026:** Mike hat bestätigt nacheinander statt parallel zu bauen. Tatsächliche Reihenfolge: **Telegram** (07.09., fertig) → **WhatsApp** (08.09., Code fertig, wartet auf Login) → als Nächstes vermutlich **Mails** (Connector existiert schon, "nur" die Automatisierungs-Frage klären) oder direkt **Content-Erstellung**, dann gemeinsam mit Mike entscheiden wie mit **Instagram**/**Facebook** umgegangen wird (ToS-Risiko, siehe Punkte 2+2b), **Auto-Posting** zum Schluss (baut auf den anderen auf). Vor jedem neuen Baustein kurz mit Mike bestätigen, nicht automatisch weiterbauen.

## Sicherheits-Hinweis für die neue Session

Jede neue Anbindung (Mail-Zugriff automatisieren, Instagram/Telegram-Zugangsdaten, neue OAuth-Freigaben) fällt unter "explizite Erlaubnis nötig" — nicht eigenständig einrichten, sondern mit Mike im Chat kurz bestätigen lassen bevor Zugangsdaten/Tokens hinterlegt oder OAuth-Flows gestartet werden.

## Relevante Dateien/Orte
- [[Jarvis Voice Assistant]] — Gesamtüberblick, Architektur, bisherige Bugfixes
- `jarvis-voice-assistant/CLAUDE.md` — technische Doku direkt im Repo
- `jarvis-voice-assistant/scripts/task_agent.py` — der Bridge-Agent, hier kämen neue Tool-Anbindungen rein
- `jarvis-voice-assistant/scripts/telegram_bridge.py` — Business-Bot-Baustein (3a), von `task_agent.py` mit aufgerufen
- `jarvis-voice-assistant/scripts/telegram_userbot_bridge.py` + `scripts/telegram_userbot_login.py` — persönlicher Userbot-Baustein (3b)
- `jarvis-voice-assistant/scripts/whatsapp_bridge.py` + `scripts/whatsapp_userbot_login.py` — WhatsApp-Baustein (neu, 08.09.2026)
- `jarvis-voice-assistant/server.py` — Sprachassistent-Backend, `config.json` (lokal, nicht in Git) für Zugangsdaten
- `jarvis-voice-assistant/frontend/main.js` — Graph-Definition, hier `plannedNode` → `liveNode` umstellen sobald ein Baustein läuft (Telegram bereits umgestellt, WhatsApp wartet noch auf Login)
- [[01 Inbox/Jarvis Aufgaben]] — die Bridge-Aufgabenliste
- [[03 Bereiche/Jarvis Voice Assistant/Telegram Nachrichten]] — Entwürfe/Status Business-Bot (3a)
- [[03 Bereiche/Jarvis Voice Assistant/Telegram Persönlich]] — Entwürfe/Status persönlicher Userbot (3b)
- [[03 Bereiche/Jarvis Voice Assistant/WhatsApp Nachrichten]] — Entwürfe/Status WhatsApp (entsteht erst nach dem ersten echten Entwurf)

## Noch offen beim persönlichen Userbot (3b)
- [x] `telegram_api_id` + `telegram_api_hash` eingetragen
- [x] Login durchgeführt, Session steht (`telegram_userbot.session`)
- [x] Baseline gesetzt (erster Lauf ohne alte Nachrichten zu verarbeiten)
- [x] Test: echte Nachricht von Janina bekommen, Entwurf erschien in [[03 Bereiche/Jarvis Voice Assistant/Telegram Persönlich]] wie erwartet
- [x] Entwurf freigegeben, Antwort kam wirklich über den eigenen Account bei Janina an
- Nach ein paar Tagen Betrieb: prüfen ob Telegram irgendwelche Warnungen/Einschränkungen am Account zeigt — Aufgabe läuft über [[Aufgaben-Triage (Sofort, Aufwendig, Komplex)]], hier nicht doppelt tracken

## Telegram-Bridge: 07.-08.09.2026 pausiert, seit 08.09.2026 wieder aktiv

Am 07.09.2026 abends wurde `TELEGRAM_BRIDGE_PAUSED = True` in `task_agent.py` gesetzt, um einen Hermes-Agent-Test nicht mit unserem eigenen System kollidieren zu lassen (siehe unten). In dieser Zeit hat weder der Business-Bot `@Mikebubot` noch der persönliche Userbot geantwortet. Nach Abschluss des Hermes-Tests (verworfen, siehe unten) am 08.09.2026 mit Mike bestätigt und `TELEGRAM_BRIDGE_PAUSED` wieder auf `False` gesetzt — beide Bausteine laufen wieder normal im 10-Minuten-Bridge-Takt.

## Exkurs: Hermes Agent (Nous Research) getestet und wieder verworfen (07.09.2026)

Mike wollte prüfen ob das fertige Open-Source-Framework [[Hermes Agent (Nous Research) - Evaluation]] die Telegram-Automatisierung übernehmen könnte, idealerweise mit vollem Zugriff auf Vault/Account, gesteuert komplett über Jarvis. Isoliert getestet (Docker-Sandbox, eigener Test-API-Key, kein echter Vault-Zugriff), dabei unser eigenes Telegram-System pausiert um Konflikte zu vermeiden (siehe oben).

**Ergebnis: verworfen.** Offizielle Doku bestätigt: Hermes hat keinen Freigabe-Mechanismus für ausgehende Nachrichten — es antwortet automatisch auf eingehende Nachrichten, ohne Entwurf-/Bestätigungsschritt. Das widerspricht dem bewusst gewählten Entwurf-statt-Auto-Antwort-Prinzip von 3a/3b. Volle Details, inkl. was das Obsidian-Skill wirklich kann (kein API-Zugriff, nur Datei-Tools) und ein Sicherheitsfund im Installer (lädt standardmäßig einen Drittanbieter-Computer-Use-Treiber nach): [[Hermes Agent (Nous Research) - Evaluation]].

**Fazit:** Bei unserem eigenen System (3a/3b) bleiben, das hat die Freigabe-Pflicht bereits bestätigt eingebaut. Hermes bleibt installiert als mögliches separates Werkzeug für nachrichtenfreie Aufgaben (Recherche, PDF/Office, Code-Review) — noch nicht weiter genutzt.

## Exkurs: OpenClaw angefragt (10.09.2026)

Mike wollte OpenClaw (offenes, populäres Agenten-Framework, früher Clawdbot/Moltbot) einsetzen und ihm dafür pauschal alle Zugänge geben (Gmail, Kalender, Drive, GitHub, Jarvis, Windsor.ai), parallel unsere eigenen Routinen pausiert, siehe [[2026-09-10]].

Eingeordnet: OpenClaw läuft lokal bei Mike, nicht über die interaktive Claude-Code-Session, hat vollen Shell-/Browser-/Mail-Zugriff und einen offenen Community-Skill-Marktplatz (Drittanbieter-Code, ungeprüft). China hat es Behörden und Staatsbetrieben im März 2026 aus Sicherheitsgründen verboten. Die hier angebundenen Konten (Gmail, Kalender, Drive, GitHub, Jarvis, Windsor.ai) hängen am claude.ai-Konto und lassen sich nicht an ein separates externes Programm weiterreichen.

Gleiche Lehre wie beim Hermes-Test oben: einem fertigen externen Agenten fehlt meist der Freigabe-Mechanismus für ausgehende Aktionen, den unser eigenes System bewusst eingebaut hat. Bevor Zugänge freigegeben werden, sollte pro Kanal einzeln entschieden werden (erst lesend, keine Mail-/Kauf-/Finanzaktionen ungeprüft), nicht alles auf einmal.

**Nächste Session:** Thema mit Mike weiter, unter anderem ein Content-Agent als konkretes Beispiel für den nächsten Baustein (knüpft an Abschnitt 5/6 oben an). Prüfen was OpenClaw beim Setup an Berechtigungen abfragt, dann gezielt einzelne Zugänge freigeben statt pauschal.


### 9. Zweites-Gehirn Cloud-Agenten im Graph sichtbar machen ✅ fertig (11.09.2026)

**Update 11.09.2026 (abends):** Umgesetzt, exakt wie unten vorgeschlagen — eigener Ast
`AGENTEN` neben `GEHIRN`/`HAND`/`STIMME`, `/agenten/status`-Endpoint in `server.py` liest
`Tagesplan.md`/`Posting-Warteschlange.md`/`Qualitätsbericht.md`, `frontend/main.js` pollt
alle 30s, `professor` bewusst als `reachableNode` statt `liveNode` (real, aber nur manuell).
**Kleine Verzögerung dabei:** Die Umsetzung war technisch schon fertig, lag aber nur
unversioniert auf Mikes Rechner — `jarvis-voice-assistant` hatte bis dahin gar kein eigenes
GitHub-Repo, deshalb neues privates Repo `buehlermike46-boop/jarvis-voice-assistant`
angelegt (Fork-Basis: `Julian-Ivanov/jarvis-voice-assistant` als `upstream`-Remote erhalten)
und der komplette lokale Stand dorthin gesichert, inklusive aller bis dahin nur lokal
existierenden Bausteine (Telegram/WhatsApp/Broker-Bridges, Cockpit-Endpoints). Damit ist
`jarvis-voice-assistant` jetzt auch von einer Claude-Code-Session aus direkt bearbeitbar,
nicht mehr nur über eine lokale Session bei Mike.

**Auftrag von Mike:** Im Wissensgraph-Interface sollen die echten Cloud-Agenten aus dem
`Zweites-Gehirn`-Repo auftauchen, nicht nur die lokalen HAND-Bausteine (Mail, Instagram,
Telegram, WhatsApp etc.). Die fünf Agenten laufen als Scheduled Cloud Routines über
claude.ai/code direkt auf dem Vault, komplett unabhängig von `jarvis-voice-assistant`
selbst:

- **`aufgaben-manager`** (`.claude/agents/aufgaben-manager.md`) — plant/kontrolliert die
  24h-Aufgabenliste, schreibt Vorschläge in [[Tagesplan]]
- **`aufgaben-executor`** (`.claude/agents/aufgaben-executor.md`) — arbeitet den
  bestätigten Tagesplan ab, protokolliert im selben [[Tagesplan]]
- **`content-manager`** (`.claude/agents/content-manager.md`) — plant wöchentlich
  Instagram-Content, schreibt Vorschläge in [[Posting-Warteschlange]]
- **`content-executor`** (`.claude/agents/content-executor.md`) — erstellt/postet fällige
  Posts, protokolliert im "Executor-Log" derselben Datei
- **`professor`** (`.claude/agents/professor.md`) — Qualitätsrunde über alle Agenten,
  schreibt nach [[Qualitätsbericht]] (Mike hat sich am 10.09. bewusst für dieses fünfte,
  eigentlich überzählige Agenten-Paar entschieden, siehe `CLAUDE.md`; empfiehlt sich
  selbst bislang nur manuell laufen zu lassen)

**Status aller fünf:** live und bereits mindestens einmal echt durchgelaufen (Stand
11.09.2026), siehe [[2026-09-11]]. Sollten im Graph also nicht gedimmt/gestrichelt
("geplant") erscheinen wie die noch unfertigen HAND-Bausteine, sondern als aktiv, mit
Ausnahme des `professor` (der laut eigener Empfehlung aktuell nur manuell läuft, nicht
automatisiert).

**Technischer Vorschlag (von der lokalen Session zu prüfen/umzusetzen):**
- Eigener neuer Ast im Graph, z.B. `AGENTEN` oder `CLOUD` neben `GEHIRN`/`HAND`/`STIMME`
  (diese Agenten sind weder Jarvis' eigenes Wissen noch seine eigene Hand, sondern ein
  drittes, externes System das denselben Vault pflegt) — Layout-Entscheidung liegt bei
  Mike/der lokalen Session
- Je Agent ein Knoten, Status live aus den oben verlinkten Koordinationsdateien lesbar
  (`Tagesplan.md`/`Posting-Warteschlange.md`/`Qualitätsbericht.md` haben jeweils ein
  Log mit Zeitstempel des letzten Laufs) — `server.py` hat über `[ACTION:VAULT]` bereits
  Vault-Lesezugriff, dieselbe Mechanik sollte für einen neuen Status-Endpoint
  wiederverwendbar sein, ähnlich wie die bestehenden `/tasks/status`/`/cockpit/status`
- Klick auf einen Agenten-Knoten könnte z.B. den letzten Log-Eintrag aus der jeweiligen
  Datei vorlesen/anzeigen, analog zum bestehenden Bridge-Knoten-Muster

**Nicht Teil dieses Bausteins:** keine neue Fähigkeit, nur Sichtbarkeit/Monitoring im
Interface. Die Agenten selbst bleiben unverändert im `Zweites-Gehirn`-Repo.

## Offener Punkt (09.09.2026): Zentrales Nachrichten-Dashboard + GMX gewünscht — Mail-Teil gelöst 26.09.2026

Mike hat ein automatisiertes Monitoring-System für WhatsApp, Gmail, GMX, Telegram und
weitere Kanäle angefragt (alle 10 Min abrufen, zentrale Zusammenfassung im Vault:
Kanal, Anzahl neuer Nachrichten, wichtige Meldungen, Zeitstempel). Als erster Schritt
gibt es [[Nachrichten-Dashboard]] als manuellen Snapshot-Aggregator über die
bestehenden Kanal-Notizen (weiterhin manuell, siehe dort).

**Update 26.09.2026:** Der Mail-Teil (Gmail UND GMX per echtem Live-Polling, inkl. GMX-
IMAP-Anbindung) ist jetzt gelöst — siehe Baustein 1 oben (`scripts/mail_bridge.py`).
Zusätzlich zum reinen Abrufen wurde direkt Mikes weitergehender Wunsch mit umgesetzt:
Werbung wird automatisch aussortiert (Papierkorb, nicht nur gezählt) und bei Wichtigem
bekommt Mike aktiv eine Telegram-Nachricht, nicht nur einen passiven Zähler im Cockpit.
Ein zentrales Dashboard-Update in `task_agent.py`, das nach jedem Lauf automatisch
[[Nachrichten-Dashboard]] mitschreibt (statt nur Mail separat), bleibt für die anderen
Kanäle (WhatsApp/Telegram) weiterhin offen — eigene Entscheidung/Aufgabe, hier nur
Status-Notiz.
