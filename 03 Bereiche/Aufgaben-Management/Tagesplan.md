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

**Hinweis:** Einige dieser Punkte (Kanalbild setzen, Make.com aktivieren, Bilder freigeben, Instagram-Bio in der App) kann nur Mike selbst ausführen, weil sie App-/Browser-Login brauchen, die der Executor nicht hat. Der Executor bereitet an, was er kann (z.B. Post-Texte/Termine vorschlagen), und trägt den Rest in den Freigabe-Stau bzw. lässt ihn offen für Mike, statt ihn als erledigt zu markieren.

Die "Offene Frage an Mike" zum Start-Button-Weg im Kanal (siehe Vorschlag unten) ist mit "Bestätigt" noch nicht beantwortet — bleibt offen bis zur nächsten Rückmeldung.

## Freigabe-Stau
*(Fertig vorbereitete, aber freigabepflichtige Punkte – Senden, Posten, neue Logins, Käufe, Formulare mit persönlichen Daten, Löschen. Mike gibt hier beim täglichen Check-in gesammelt frei oder ab.)*

## Log
*(Append-only Protokoll jedes Executor-Laufs, mit Zeitstempel)*

### 2026-09-11, Executor-Lauf
Kein bestätigter Plan für heute, nichts unternommen. Der Abschnitt "## Bestätigt für [Datum]" ist noch das leere Template, und der "## Vorschlag für 2026-09-11" vom aufgaben-manager wartet noch auf Mikes Bestätigung per Push-Nachricht. Ohne Bestätigung wird laut Vorgabe keine eigene Freigabe erfunden — auch kein automatisches Nachziehen aus der Aufgaben-Triage, weil das erst greift, wenn die bestätigte Liste leer abgearbeitet ist, nicht wenn sie nie befüllt wurde.

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

## Vorschlag für 2026-09-12
*(Vom aufgaben-manager erzeugt, wartet auf Mikes Bestätigung per Push-Nachricht)*

**Kontrolle vorab:** Der "## Bestätigt für 2026-09-11"-Abschnitt oben wurde geprüft. Kein einziger der sieben Punkte hat einen Beleg — im Gegenteil, die Daily Note [[2026-09-11]] vermerkt explizit unter "Liegen geblieben, noch offen", dass der komplette Tag stattdessen in Agenten-Infrastruktur ging (Content-Agent live geschaltet, Professor gebaut, Jarvis-Voice-Assistant repariert und versioniert). Das Log oben hat dazu keinen zweiten Eintrag — es gab schlicht keinen Executor-Lauf gegen die bestätigte Liste, seit Mike um 07:44 UTC bestätigt hat. Nichts wird als erledigt abgehakt, alle sieben Punkte wandern unverändert in diesen Vorschlag. Die "Offene Frage an Mike" zum Start-Button-Test von gestern ist ebenfalls noch unbeantwortet, siehe oben.

**Aktive Baustelle (Stufe 0, Fundament, siehe [[MasterPlan - Teilziele und Zeitplan bis 50.000 EUR]]):** unverändert Telegram-Kanal Inner Circle und Bot-Strecke fertigstellen. Zahlt weiterhin direkt auf die "Weiter, wenn"-Bedingung von Stufe 0 ein (10 geworbene Accounts, davon 5 aktiv, 100-Lot-Schwelle einmal geknackt). Zusätzlich relevant: ab 14.09. beginnt laut [[Zwei-Wochen-Takt]] der Wechselschicht-Job, das Zeitfenster für diese Sofort-Punkte wird danach enger.

### Sofort (unter 30 Min, teils nur am Handy/in der App möglich) — 2. Tag unverändert offen
- [ ] Kanalbild in Telegram setzen — Datei liegt bereit unter `Lim/Content/Assets/ic-kanalbild-limitless.png` (Stufe 0, Kanal-Feinschliff)
- [ ] Instagram-Bio: Link zusätzlich ins Website-Feld eintragen, geht nur in der App (Stufe 0)
- [ ] Make.com-Szenario dauerhaft aktivieren, Scheduling-Schalter auf ON (Stufe 0 — ohne das läuft die Bot-Automatik nicht zuverlässig weiter)
- [ ] Die vier neuen Kanalbilder aus `Lim/Content/Telegram/` gegenchecken und freigeben (Stufe 0)
- [ ] Google-Drive-Ordner `Rechnungen/Eingang` anlegen (Stufe 0, Vorarbeit fürs spätere Rechnungs-Tracking)
- [ ] WhatsApp end-to-end testen: jemanden bitten zu schreiben, danach Entwurf prüfen/freigeben, Versand kontrollieren (Stufe-0-Tooling — du kannst nur anstoßen, hängt von einer eingehenden Nachricht ab)

### Aufwendig (das eine Thema, das diese Woche vorangeht) — 2. Tag unverändert offen
- [ ] Posts 1 bis 6 für Woche 1 im Kanal terminieren, ca. 60 Minuten (Stufe 0: "Content-Rhythmus etabliert: 3 Posts pro Woche". Sinnvoll direkt nach den Sofort-Punkten, weil die Instagram-Captions schon auf den noch leeren Kanal verweisen)

### Komplex — weiterhin bewusst zurückgestellt
Unverändert: Lot-Tracking, die 20-Namen-Liste, das Pflegedienst-Referenzprojekt und die übrigen Komplex-Punkte aus der Triage bleiben liegen, bis Kanal und Bot-Strecke wirklich stehen (MasterPlan Punkt 8: maximal 1-2 aktive Baustellen, Automatisieren vor Validieren). Nächster Kandidat danach weiterhin: Lot-Tracking.

### Passt zu keiner aktiven Stufe — zurückgestellt
Keine neuen Punkte. Unverändert in der Triage als Stufe-1-plus-Themen geparkt: Meta Graph API / Facebook-Bridge, Jarvis-Interface-Ausbau, eigenes Monitoring-System als App, Rechnungs-Automatik Stufe 2/3.

### Offene Fragen an Mike
- Dieselbe Liste steht jetzt den zweiten Tag in Folge unbestätigt/unausgeführt da, während parallel viel Zeit in die Agenten-Infrastruktur selbst floss (Content-Agent, Professor, Jarvis-Voice-Assistant). Das ist genau die Baustellen-Falle aus MasterPlan Punkt 8: die Agenten-Arbeit ist wichtig, ersetzt aber nicht die sieben kleinen Stufe-0-Punkte, die insgesamt unter zwei Stunden brauchen. Vorschlag: diese sieben Punkte heute oder morgen bewusst zuerst wegräumen, bevor eine weitere Agenten-Baustelle Zeit zieht — sag Bescheid, ob das so passt oder ob sich die Priorität aus deiner Sicht tatsächlich verschoben hat.
- Start-Button-Frage von gestern weiterhin offen (siehe Vorschlag 2026-09-11 oben).
