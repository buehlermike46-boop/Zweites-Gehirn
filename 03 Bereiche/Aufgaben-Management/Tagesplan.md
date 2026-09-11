---
tags: [bereich, aufgaben, automatisierung]
status: aktiv
date: 2026-09-10
---

# Tagesplan

Gemeinsame Zustandsdatei zwischen dem [[aufgaben-manager]] (plant, kontrolliert) und dem `aufgaben-executor` (arbeitet ab). Wird von den Scheduled Cloud Routines gelesen und beschrieben. Format bewusst simpel, damit beide Agenten zuverlässig damit arbeiten können.

**Status:** noch kein Zyklus gelaufen. Diese Datei ist das Gerüst, ab dem ersten Routinen-Lauf befüllt sie sich selbst.

## Vorschlag für [Datum wird beim ersten Lauf eingetragen]
*(Vom aufgaben-manager erzeugt, wartet auf Mikes Bestätigung per Push-Nachricht)*

- [ ] Beispiel: wird beim ersten Planungslauf ersetzt

## Bestätigt für [Datum]
*(Erst befüllt, nachdem Mike den Vorschlag oben bestätigt hat – der Executor darf NUR aus diesem Abschnitt arbeiten)*

## Bestätigt für 2026-09-11
*(Mike hat den Vorschlag vom 11.09.2026 per Chat bestätigt ("Bestätigt"). Der Executor arbeitet ab hier. Stufe 0, Fundament, siehe [[MasterPlan - Teilziele und Zeitplan bis 50.000 EUR]].)*

### Sofort
- [ ] Kanalbild in Telegram setzen — Datei liegt bereit unter `Lim/Content/Assets/ic-kanalbild-limitless.png`
- [ ] Instagram-Bio: Link zusätzlich ins Website-Feld eintragen, geht nur in der App
- [ ] Make.com-Szenario dauerhaft aktivieren, Scheduling-Schalter auf ON
- [ ] Die vier neuen Kanalbilder aus `Lim/Content/Telegram/` gegenchecken und freigeben
- [ ] Google-Drive-Ordner `Rechnungen/Eingang` anlegen
- [ ] WhatsApp end-to-end testen: jemanden bitten zu schreiben, danach Entwurf prüfen/freigeben, Versand kontrollieren

### Aufwendig
- [ ] Posts 1 bis 6 für Woche 1 im Kanal terminieren, ca. 60 Minuten

**Hinweis (aktualisiert 11.09.2026):** Einige dieser Punkte (Kanalbild setzen, Make.com aktivieren, Bilder freigeben, Instagram-Bio in der App) kann aktuell nur Mike selbst ausführen, nicht weil eine Freigabe fehlt, sondern weil es dafür schlicht kein Werkzeug/keinen Connector gibt bzw. eine Plattformgrenze besteht (siehe "Technisch blockiert" unten für die Details je Punkt, Stand der Session vom 11.09.2026). Der Executor bereitet an, was er kann, und trägt den Rest weiterhin unter "Technisch blockiert" ein statt ihn als erledigt zu markieren.

Die "Offene Frage an Mike" zum Start-Button-Weg im Kanal (siehe Vorschlag unten) ist mit "Bestätigt" noch nicht beantwortet — bleibt offen bis zur nächsten Rückmeldung.

## Technisch blockiert
*(Seit 11.09.2026 keine Freigabe-Warteschlange mehr – Mike hat entschieden, dass der Executor jede Aktion, für die er ein Werkzeug hat, direkt ausführt, auch Senden/Posten/Login/Kauf/Löschen. Hier landet nur noch, wofür schlicht kein Werkzeug existiert oder ein Connector fehlerhaft/unzureichend berechtigt ist. Mike richtet hier Zugriff/Connector ein, dann kann der Executor beim nächsten Lauf ranmüssen.)*

### Aus der Session vom 11.09.2026 (Kontrolle der offenen Tagesplan-Punkte)
- **Kanalbild in Telegram setzen** — kein Telegram-Connector vorhanden (Registry durchsucht, nichts gefunden). Bleibt Handarbeit, bis es einen Weg nach Telegram gibt.
- **Instagram-Bio: Link ins Website-Feld** — laut `mcp__Windsor_ai__list_actions` deckt der Instagram-Connector nur "Bild-Post erstellen" und "Kommentieren" ab, keine Profil-/Bio-Felder. Das ist eine Plattformgrenze (Meta erlaubt das generell nur in der App), kein Connector wird das lösen.
- **Make.com-Szenario aktivieren** — noch nicht möglich, aber es gibt einen passenden Connector in der MCP-Registry ("Make", u.a. mit `scenarios_activate`/`scenarios_deactivate`/`scenarios_run`), der noch nicht verbunden ist. Sobald Mike ihn unter claude.ai → Einstellungen → Connectors verbindet und der aufgaben-executor-Routine unter "Zugang" freigibt, kann das automatisiert werden — dann trägt eine Session die konkreten Tool-Namen in `aufgaben-executor.md` nach.
- **Die 4 neuen Kanalbilder aus `Lim/Content/Telegram/` gegenchecken** — liegen lokal auf Mikes Desktop, außerhalb des Git-Vaults, für Cloud-Sessions nicht erreichbar. Laut [[Inner Circle Kanal-Content]] ohnehin als "Mike schaut sich das zuhause an" vorgemerkt.
- **Google-Drive-Ordner `Rechnungen/Eingang` anlegen** — Connector ist verbunden, scheitert aber bei jedem Aufruf (Suche und Ordner-Erstellung getestet) mit "insufficient scope". Mike muss Google Drive unter claude.ai → Einstellungen → Connectors trennen und neu verbinden, dabei die volle Berechtigungsanfrage bestätigen (nicht nur eingeschränkten Zugriff), und danach der aufgaben-executor-Routine unter "Zugang" Google Drive geben (analog zum Vorgehen bei Jarvis/Windsor.ai/Canva für den Content-Executor).
- **WhatsApp end-to-end testen** — kein WhatsApp-Business-Connector in der Registry gefunden. Setzt außerdem eine echte eingehende Nachricht von einer dritten Person voraus, kein reines Zugriffsproblem.
- **Posts 1-6 für Woche 1 im Kanal terminieren** — Texte sind längst copy-paste-fertig in [[Inner Circle Kanal-Content]], das reine Terminieren ("Sendebutton halten → Zeitplan") ist eine Telegram-App-Funktion, nicht Teil der Bot-API, damit auch mit einem künftigen Telegram-Connector nicht 1:1 nachbildbar (ein Bot könnte höchstens selbst zur richtigen Zeit senden).

## Log
*(Append-only Protokoll jedes Executor-Laufs, mit Zeitstempel)*

### 2026-09-11, Executor-Lauf
Kein bestätigter Plan für heute, nichts unternommen. Der Abschnitt "## Bestätigt für [Datum]" ist noch das leere Template, und der "## Vorschlag für 2026-09-11" vom aufgaben-manager wartet noch auf Mikes Bestätigung per Push-Nachricht. Ohne Bestätigung wird laut Vorgabe keine eigene Freigabe erfunden — auch kein automatisches Nachziehen aus der Aufgaben-Triage, weil das erst greift, wenn die bestätigte Liste leer abgearbeitet ist, nicht wenn sie nie befüllt wurde.

### 2026-09-11, Nachmittag, Hauptsession (kein Executor-Lauf, aber protokollrelevant)
Mike wollte die 7 offenen "Bestätigt für 2026-09-11"-Punkte abschließen. Kontrolle ergab: keiner der 7 Punkte war mit den damaligen Werkzeugen ausführbar (Telegram/Make.com/WhatsApp: kein Connector; Instagram-Bio: Plattformgrenze; Google Drive: verbunden, aber "insufficient scope"). Mike hat daraufhin entschieden: **volle Autonomie für den `aufgaben-executor` ab sofort** – keine Freigabepflicht mehr für Senden/Posten/Login/Kauf/Löschen, nur noch Log-Pflicht. Umgesetzt: `CLAUDE.md`, `aufgaben-executor.md`, `aufgaben-manager.md`, `aufgaben-check.md` und dieser Abschnitt (vormals "Freigabe-Stau", jetzt "Technisch blockiert") entsprechend angepasst. Executor hat jetzt zusätzlich Google Drive/Gmail/Google Calendar im Werkzeugkasten (Tool-Namen in `aufgaben-executor.md`) – **Mike muss dafür noch die Routine "aufgaben-executor" unter claude.ai/code/routines → Zugang für diese drei Connectoren freischalten, sonst laufen die Tools bei einem Cloud-Lauf ins Leere.** Google Drive zusätzlich neu verbinden nötig (Scope-Fehler), Make.com-Connector existiert in der Registry, ist aber noch nicht verbunden. Details siehe "Technisch blockiert" oben. Nichts von den 7 ursprünglichen Punkten wurde dadurch bereits erledigt, nur die Blockade-Ursache jeweils sauber dokumentiert.

## Vorschlag für 2026-09-11
*(Vom aufgaben-manager erzeugt, wartet auf Mikes Bestätigung per Push-Nachricht)*

**Kontrolle vorab:** Erster echter Planungslauf über dieses System. "Bestätigt für [Datum]" und Log oben sind noch leer, es gibt also keine Executor-Runde zu kontrollieren und nichts abzuhaken. Grundlage ist stattdessen [[Aufgaben-Triage (Sofort, Aufwendig, Komplex)]] (Stand 10.09.2026, heute gegengeprüft und inhaltlich noch aktuell) sowie die Daily Note [[2026-09-10]].

**Aktive Baustelle (Stufe 0, Fundament, siehe [[MasterPlan - Teilziele und Zeitplan bis 50.000 EUR]]):** Telegram-Kanal Inner Circle und Bot-Strecke fertigstellen. Zahlt direkt auf die "Weiter, wenn"-Bedingung von Stufe 0 ein (10 geworbene Accounts, davon 5 aktiv, 100-Lot-Schwelle einmal geknackt).

### Sofort (unter 30 Min, teils nur am Handy/in der App möglich)
- [ ] Kanalbild in Telegram setzen — Datei liegt bereit unter `Lim/Content/Assets/ic-kanalbild-limitless.png` (Stufe 0, Kanal-Feinschliff)
- [ ] Instagram-Bio: Link zusätzlich ins Website-Feld eintragen, geht nur in der App (Stufe 0)
- [ ] Make.com-Szenario dauerhaft aktivieren, Scheduling-Schalter auf ON (Stufe 0 — ohne das läuft die Bot-Automatik nicht zuverlässig weiter)
- [ ] Die vier neuen Kanalbilder aus `Lim/Content/Telegram/` gegenchecken und freigeben (Stufe 0)
- [ ] Google-Drive-Ordner `Rechnungen/Eingang` anlegen (Stufe 0, Vorarbeit fürs spätere Rechnungs-Tracking)
- [ ] WhatsApp end-to-end testen: jemanden bitten zu schreiben, danach Entwurf prüfen/freigeben, Versand kontrollieren (Stufe-0-Tooling — du kannst nur anstoßen, hängt von einer eingehenden Nachricht ab)

### Aufwendig (das eine Thema, das diese Woche vorangeht)
- [ ] Posts 1 bis 6 für Woche 1 im Kanal terminieren, ca. 60 Minuten (Stufe 0: "Content-Rhythmus etabliert: 3 Posts pro Woche". Sinnvoll direkt nach den Sofort-Punkten, weil die Instagram-Captions schon auf den noch leeren Kanal verweisen)

### Komplex — bewusst zurückgestellt
Lot-Tracking, die 20-Namen-Liste, das Pflegedienst-Referenzprojekt und die übrigen Komplex-Punkte aus der Triage bleiben liegen, bis Kanal und Bot-Strecke wirklich stehen (MasterPlan Punkt 8: maximal 1-2 aktive Baustellen, Automatisieren vor Validieren). Nächster Kandidat danach: Lot-Tracking, weil die zentrale Steuergröße (Gesamt-Lots/Monat) sonst nirgends gemessen wird — passt am besten in eine Spätwoche laut [[Zwei-Wochen-Takt]] (Vormittagsblöcke vor der Schicht).

### Passt zu keiner aktiven Stufe — zurückgestellt
Keine neuen Punkte in diese Kategorie. Bereits in der Triage korrekt als Stufe-1-plus-Themen geparkt: Meta Graph API / Facebook-Bridge, Jarvis-Interface-Ausbau, eigenes Monitoring-System als App, Rechnungs-Automatik Stufe 2/3 (laut Plan erst ab Monat 4).

### Offene Fragen an Mike
- Die Triage markiert "Bot-Strecke faktisch bestätigt" bereits als erledigt, obwohl der Weg über den Start-Button direkt im Kanal (statt über /start im Bot-Chat) laut eigenem Text noch ungetestet ist. Nicht selbst korrigiert, da kein neuer Beleg vorliegt — kurz gegenchecken, ob das für dich als abgeschlossen gilt oder ob der Button-Weg noch ein offener Sofort-Punkt ist.
- Für heute existiert noch keine Daily Note. Vorschlag: bei Bedarf eine [[2026-09-11]] anlegen, sobald der Tag was zu berichten hat — nicht ungefragt vorab erstellt.
