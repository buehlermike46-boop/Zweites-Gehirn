---
tags: [projekt, uebersicht, steuerung]
status: aktiv
date: 2026-09-12
---

# Aufgaben-Triage (Sofort, Aufwendig, Komplex)

Alle offenen Aufgaben aus dem Vault, gesammelt am 10.09.2026 und nach Aufwand sortiert. Grundlage sind alle offenen Checkboxen in [[Brain Dump]], [[Jarvis Hand - Agenten Ausbau]], [[Inner Circle Kanal-Content]], [[KI-Automatisierung IB-Business]], [[IB-Projekt (Limitless & PU Prime)]], [[MasterPlan - Teilziele und Zeitplan bis 50.000 EUR]], [[Ausgaben und Rechnungen Tracking]] und [[2026-09-09]]. Doppelte Einträge sind zusammengefasst.

**Einteilung**
- **Sofort**: unter 30 Minuten, in einem Rutsch erledigbar
- **Aufwendig**: mehrere Stunden bis ein ganzer Tag
- **Komplex**: mehrere Tage bis Wochen, braucht eigene Planung

**Zahlen:** 21 sofort, 14 aufwendig, 12 komplex. Gesamt 47 offene Punkte (Stand bei Anlage 10.09.2026, unten laufend abgehakt statt neu gezählt).

**Tagesprotokoll dazu:** [[2026-09-10]]

> [!success] Vault-Sync 13.09.2026: mehrere liegengebliebene Session-Branches gemerged
> Mehrere interaktive Sessions hatten am 12./13.09. echte Fortschritte gemacht, aber auf eigenen Branches, die nie nach `master` gemerged wurden (siehe `CLAUDE.md`, neuer Abschnitt "Git-Workflow für interaktive Sessions"). Bei der Sync-Runde zusammengeführt. **Echter Mike-only-Zähler nach dem Zusammenführen: 5**, nicht 13, 9 oder 7 wie in älteren Einzel-Einträgen unten:
> 1. WhatsApp end-to-end testen
> 2. Die 20 Leute persönlich anschreiben (Liste selbst ist komplett, 20/20)
> 3. Telegram-Warnungen am Account prüfen
> 4. Kanal-Profilbild in Telegram setzen (13.09. generiert)
> 5. Bot-Profilbild bei @BotFather setzen (13.09. generiert)
>
> Erledigt und aus dem Zähler raus: Kanalbild setzen, Instagram-Bio-Feld, Make.com aktivieren (inkl. Willkommensnachricht + 3 Follow-ups), 4 Kanalbilder freigeben, Google-Drive-Ordner, 20-Namen-Liste, Limitless-Support-Anfrage. "Posts 1-6 terminieren" ist obsolet: der Telegram-Kanal-Versand läuft seit 13.09.2026 automatisch über `content-executor` (siehe [[Inner Circle Kanal-Content]] Abschnitt 9), kein manuelles Terminieren mehr nötig — Post 1 ist bereits live.

**Stand 10.09.2026, unterwegs abgearbeitet:** Staffelsatz geklärt (nicht rückwirkend, Rechnung im MasterPlan korrigiert), Kanalbeschreibung gesetzt, Reaktionen und Diskussionschat geprüft, Instagram-Bio ergänzt. Schichtplan und Tagesstruktur aus dem Kalender als [[Zwei-Wochen-Takt]] dokumentiert, Halbmarathon-Termin auf den 21.11.2026 korrigiert (Vault und Kalender). Kanalbild wartet auf Mike in der App, Bildfreigabe wartet auf ihn zuhause.

**Kontrolle 11.09.2026 ([[aufgaben-manager]], erster Planungslauf über [[Tagesplan]]):** Kein Beleg zu prüfen, weil noch keine Executor-Runde gelaufen ist ("Bestätigt"-Abschnitt und Log in [[Tagesplan]] waren leer). Diese Liste war bereits aktuell und deckt alle offenen Punkte aus dem MasterPlan ("Nächste 30 Tage") und der Inbox ab, deshalb keine inhaltliche Änderung — nur der neue Vorschlag in [[Tagesplan]] ergänzt.

**Kontrolle 12.09.2026 ([[aufgaben-manager]]):** Mike hat den Vorschlag vom 11.09. bestätigt, aber laut [[Tagesplan]] und der Daily Note [[2026-09-11]] ist der Tag komplett in Agenten-Infrastruktur-Arbeit gegangen (Content-Agent live, Professor, Jarvis-Voice-Assistant-Reparatur) — die sieben bestätigten Tagesaufgaben (Kanalbild, Insta-Bio, Make.com, Kanalbilder freigeben, Drive-Ordner, WhatsApp-Test, Posts terminieren) blieben laut eigenem Vermerk in der Daily Note unangetastet liegen, kein Häkchen gesetzt. Diese Liste bleibt daher inhaltlich unverändert (weiterhin 47 offene Punkte), keine neuen Inbox-Punkte seit dem 10.09. gefunden. Die sieben Punkte wandern unverändert in den neuen Vorschlag für 2026-09-12 in [[Tagesplan]].

**Kontrolle 12.09.2026, zweiter Lauf ([[aufgaben-manager]], ausgelöst durch Leerlauf-Signal des Executors):** Der `aufgaben-executor` hat die sieben bestätigten Punkte durchgearbeitet und alle sieben mit nachvollziehbarem technischem Grund als blockiert dokumentiert (siehe [[Tagesplan]], Abschnitt "Technisch blockiert" und Log-Eintrag "2026-09-12, Executor-Lauf, nachmittags") — kein Beleg für "erledigt", deshalb hier weiterhin keine Häkchen gesetzt, Punkte bleiben offen. Automatisch nachgezogen und wirklich erledigt: **Lot-Tracking** (siehe Häkchen unten, [[Lot-Tracking]] angelegt). Dabei aufgefallen: Die Aufwendig-Punkte "Neue Willkommensnachricht im Bot eintragen" und "Drei Follow-ups im Bot einrichten" sind inhaltlich bereits komplett vorbereitet — fertige Texte stehen in [[Inner Circle Kanal-Content]] Abschnitt 7. Es fehlt nur noch der reine Eintrage-Schritt in Make.com, der am selben Login-Problem hängt wie "Make.com-Szenario dauerhaft aktivieren" weiter unten — sinnvollerweise alle drei Make.com-Schritte in einem Rutsch erledigen, sobald Mike eingeloggt ist. Keine neuen Inbox-Punkte gefunden. Auffällig: nahezu alle verbleibenden Sofort- und Aufwendig-Punkte hängen entweder an einem App-/Browser-Login (Telegram, Instagram, Make.com), an Mikes persönlichem Wissen/Kontakten (20-Namen-Liste, Fixkosten-Zahlen) oder an einem Repo, auf das der Executor keinen Zugriff hat (`jarvis-voice-assistant` für GMX/Gmail/Dashboard) — der Executor hat damit faktisch keinen weiteren eigenständig ausführbaren Stufe-0-Punkt mehr offen, bis Mike selbst etwas davon abräumt oder neue Fakten liefert. Siehe [[Tagesplan]], neuer Vorschlag, für die Einordnung.

**Kontrolle 12.09.2026, dritter Lauf ([[aufgaben-manager]], nach Mikes Bestätigung "Der Manager soll es bitte umsetzen" zum zweiten Vorschlag vom selben Tag):** Zwei Umsetzungen. (1) Mike hat 16 der 20 Namen für die Kontaktliste geliefert (Marina, Atin, Julia, Yilmaz, Mika, Jerome, Max, Eno, Jens, Tahsin, Sven, Lars, Dome, Manuel, Ronja, Maltesa Westerwald) — neue Tracking-Notiz [[Kontaktliste - 20 Namen aus dem Umfeld]] angelegt, keine Beziehungsdetails erfunden, die Zeilen unten in der Liste entsprechend verlinkt. Noch 4 Namen offen. (2) App-/Browser-Login-Punkte (Kanalbild setzen, Instagram-Bio-Feld, Make.com aktivieren, Kanalbilder freigeben, WhatsApp-Test, Posts terminieren) laufen ab jetzt nicht mehr über den Tagesplan-Bestätigt-Kreislauf — Mike hakt sie direkt hier ab, sobald erledigt (Vermerk bei jeder betroffenen Zeile ergänzt). Kein neuer Bestätigt-Abschnitt für den Executor nötig, da aktuell kein Punkt existiert, den er eigenständig bis zum Ende ausführen kann (das persönliche Anschreiben ist explizit Mikes eigene Aufgabe, siehe [[Kontaktliste - 20 Namen aus dem Umfeld]]).

**Kontrolle 12.09.2026, vierter Lauf ([[aufgaben-manager]], "Deckel-Runde 1" — Mikes Stapel-Freigabe "Aufgaben-Nachschub bis Deckel 20"):** Komplette Liste noch einmal Punkt für Punkt gegen Stufe 0 geprüft (Sofort und Aufwendig zuerst). Keine inhaltliche Änderung an dieser Datei nötig (keine neuen erledigten Punkte mit Beleg, keine neuen Inbox-Punkte) — die Runde bestand darin, vier noch nicht markierte/blockierte, aber genuin offene Stufe-0-Punkte direkt in [[Tagesplan]], neuer Abschnitt "Bestätigt für 2026-09-12 (Deckel-Runde 1)", einzureihen: Limitless-Support-Anfrage (API/Webhook Prospect Tracker), Telegram-Warnungs-Check, Willkommensnachricht plus drei Follow-ups im Bot (letztere beide bisher nur in der Kommentierung erwähnt, nicht selbst als "läuft nicht mehr über den Bestätigt-Kreislauf" markiert). Ausdrücklich nicht mit übernommen: die restlichen 4 Namen der Kontaktliste und das persönliche Anschreiben (beide bereits an anderer Stelle als Mikes eigene Aufgabe benannt, zählen schon zum Mike-only-Bestand), Fixkosten-/Business-Kosten-Listen und die Buchhaltungs-Frage (keiner MasterPlan-Stufe zugeordnet), Gmail/GMX/Dashboard-Punkte und der `whatsapp`-Knoten in `frontend/main.js` (separates Repo `jarvis-voice-assistant`, kein Zugriff für diesen Agenten, per Glob in diesem Repo bestätigt: kein Treffer), die beiden "in ein paar Tagen"-Punkte zu WhatsApp-Warnungen (kein klarer Stufe-0-Bezug) und das Trade_Journal.xlsx-Herunterladen (kein Stufe-0-Bezug). Details siehe [[Tagesplan]].

**Genauer Mike-only-Zähler-Stand nach dieser Runde** (Technisch blockiert in [[Tagesplan]] plus Triage-Punkte, die nur Mike lösen kann, Überschneidungen zwischen beiden Listen einmal gezählt): **9** — Kanalbild setzen, Instagram-Bio-Feld, Make.com aktivieren, vier Kanalbilder freigeben, WhatsApp-Test, Posts 1-6 terminieren (6 App-Login-Punkte, jeweils sowohl hier als auch unter Technisch blockiert gelistet, hier nur einmal gezählt), Google-Drive-Ordner anlegen (1, Tool-Lücke, nur unter Technisch blockiert), 20-Namen-Liste vervollständigen (1, Mikes persönliches Umfeld), persönlich anschreiben (1, Mikes eigene Handlung). Deckt sich mit Mikes eigener Schätzung vom 12.09.2026. Die vier neu in "Deckel-Runde 1" eingereihten Punkte zählen erst dazu, sobald der nächste Executor-Lauf sie tatsächlich als technisch blockiert dokumentiert — aktuell, vor diesem Executor-Lauf, bleibt der Stand bei 9.

**Kontrolle 12.09.2026, fünfter Lauf ([[aufgaben-manager]], "Deckel-Runde 2" — Fortsetzung der Stapel-Freigabe, gründliche Nachprüfung vor dem Aufgeben):** Zwei Dinge geprüft. (1) [[Brain Dump]] und [[Jarvis Aufgaben]] komplett neu gelesen: keine neuen, noch nicht in dieser Triage erfassten Punkte gefunden — Brain Dump enthält nur bereits abgehakte oder bereits mit Verweis hierher versehene Zeilen, Jarvis Aufgaben ist ein Log mit ausschließlich `status: erledigt`/`status: fehler`-Einträgen, kein einziger offener Punkt. (2) Die sechs bisher bewusst ausgeschlossenen Punkte einzeln neu bewertet, nicht pauschal übernommen:
- **Fixkosten-Liste** und **Business-Kosten-Liste**: Stufe 0 nennt als Bedingungen nur Kanal/Bot, Content-Rhythmus und Lot-Tracking (siehe [[MasterPlan - Teilziele und Zeitplan bis 50.000 EUR]], Abschnitt 3). Eine Kostenübersicht ist an keiner Stelle Teil dieser Bedingungen oder der "Nächsten 30 Tage" — bleibt zurückgestellt, kein Stufe-0-Bezug.
- **Buchhaltungs-Frage** (womit läuft die Buchhaltung): gleiche Begründung, keine Stufe-0-Bedingung. Bleibt zurückgestellt.
- **WhatsApp-Warnungs-Check** ("in ein paar Tagen prüfen, ob WhatsApp Warnungen an der Geräteverknüpfung zeigt"): anders als der bereits in Deckel-Runde 1 aufgenommene Telegram-Warnungs-Check schützt dieser nicht die Infrastruktur, über die der Inner-Circle-Kanal läuft (das ist Telegram, nicht WhatsApp) — WhatsApp ist laut Stufe-0-Bedingungen kein Bestandteil der Kanal-/Bot-Strecke. Bleibt zurückgestellt, kein Stufe-0-Bezug.
- **Trade_Journal.xlsx herunterladen**: MasterPlan hält ausdrücklich fest, "Eigenes Trading ist bewusst kein Einkommensposten" (Abschnitt 2) — das Trading-Journal gehört zum privaten Trading, nicht zum IB-Business, das Stufe 0 tatsächlich meint. Zusätzlich technisch ohnehin nicht ausführbar (kein ChatGPT-Connector in der Executor-Tool-Liste). Bleibt zurückgestellt, kein Stufe-0-Bezug.

Ergebnis: keine neuen Punkte für Stufe 0 gefunden, weder aus der Inbox noch aus der Neubewertung der sechs Ausschlüsse. Der Mike-only-Zähler stand damit zunächst unverändert bei 13 (9 aus dem vierten Lauf plus die vier aus Deckel-Runde 1: Limitless-Support-Anfrage, Telegram-Warnungscheck, Willkommensnachricht, drei Follow-ups). Details und Begründung auch in [[Tagesplan]], Log-Eintrag vom selben Datum.

**Kontrolle 12.09.2026, sechster Lauf (interaktive Chat-Session, kein Subagent):** Mike hat direkt in dieser Session nachgefragt, was von den 13 sich noch bearbeiten lässt. Diese Session hat, anders als `aufgaben-executor` und `aufgaben-manager`, eigene Connectoren für Google Drive, Gmail und Make.com (das ist genau das in `jarvis-voice-assistant` dokumentierte `reachableNode`-Prinzip, nur für den Vault-Agenten statt für Jarvis). Ergebnis nach Live-Check:
- Google-Drive-Ordner `Rechnungen/Eingang`: existierte schon (siehe oben). **Zähler −1.**
- Make.com-Szenario aktivieren: war laut API schon aktiv. **Zähler −1.**
- Neue Willkommensnachricht + Button "Konto eröffnen": mit Mikes Ja live umgesetzt (siehe oben). **Zähler −1.**
- Drei Follow-ups: nicht umgesetzt, echter Blocker (Make-Speicherquote + fehlender verifizierbarer Datastore-Auslese-Baustein), bleibt offen, jetzt mit anderer, genauerer Begründung.
- Limitless-Support-Anfrage: **erledigt 12.09.2026**, Mike hat selbst geschrieben (ohne Umweg über Gmail-Connector dieser Session). **Zähler −1.**
- Telegram-Warnungscheck, Kanalbild, Instagram-Bio-Feld, 4 Kanalbilder freigeben, WhatsApp-Test, Posts terminieren, restliche 4 Namen, persönlich anschreiben: unverändert, wirklich nur Mike möglich.

**Neuer Mike-only-Zähler-Stand: 10** (13 minus die drei oben erledigten Punkte). Der Deckel liegt weiterhin bei 20, davon sind wir also weiter entfernt als vorher, im positiven Sinn.

**Nachtrag, selber Tag:** Mike hat die Limitless-Support-Anfrage selbst geschrieben (ohne Mail-Entwurf dieser Session). **Zähler jetzt 9.**

**Nachtrag 2, selber Tag:** Instagram-Bio-Website-Feld erledigt, Mike hat den Link selbst in der App eingetragen. **Zähler jetzt 8.**

**Nachtrag 3, selber Tag:** Kontaktliste vervollständigt, Mike hat die letzten 4 Namen geliefert (Martin, Luisa, Lukas, Fabian), Liste steht bei 20/20. Das persönliche Anschreiben selbst bleibt ein eigener, weiterhin offener Punkt. **Zähler jetzt 7.**

**Kontrolle 13.09.2026 ([[aufgaben-manager]], turnusmäßiger Planungslauf, Scheduled Cloud Routine):** Kein neuer Beleg zu prüfen — die letzte Bestätigt-Liste (Deckel-Runde 1, vier Punkte) war bereits am 12.09. vom Executor als technisch blockiert dokumentiert und in dieser Kontrolle abgehandelt. [[Brain Dump]] und [[Jarvis Aufgaben]] erneut komplett gelesen: keine neuen offenen Punkte. [[Kontaktliste - 20 Namen aus dem Umfeld]] weiterhin bei 16/20, kein Name als angeschrieben markiert. Die sechs App-Login-Punkte hier unten weiterhin unmarkiert (kein Mike-Häkchen seit 12.09.). Keine inhaltliche Änderung an dieser Datei nötig, Zahlen im Kopf bleiben unverändert. Mike-only-Zähler unverändert bei **13/20**. Neuer Vorschlag für den 13.09. steht in [[Tagesplan]] — empfiehlt als größten Hebel die 4 fehlenden Kontaktnamen plus erste persönliche Anschreiben, weil laut MasterPlan Abschnitt 4 Kundengewinnung (aktuell 0 Accounts im [[Lot-Tracking]]) der eigentliche Engpass ist, nicht Technik.

**Kontrolle 13.09.2026, zweiter Lauf (Chat mit Mike, interaktive Session):** Mike hat im Chat bestätigt, dass die Telegram-Technik komplett steht: Kanalbild gesetzt, die vier Kanalbilder aus `Lim/Content/Telegram/` freigegeben, Make.com-Szenario dauerhaft aktiviert inklusive neuer Willkommensnachricht und der drei Follow-ups. Fünf der sechs App-Login-Punkte oben entsprechend abgehakt (Beleg: Mikes direkte Aussage im Chat, konsistent mit der Vault-Regel, Bestätigungen aus dem direkten Gespräch mit Mike als gültigen Beleg zu behandeln). Weiterhin offen und explizit NICHT von seiner Aussage gedeckt, weil er ausdrücklich nur "Telegram" meinte: Instagram-Bio-Feld (Instagram, nicht Telegram) und WhatsApp-Test (WhatsApp, nicht Telegram). Zusätzlich: Post 6 (Wochenausblick) in [[Inner Circle Kanal-Content]] war der letzte inhaltliche Platzhalter im gesamten 12-Post-Plan — heute mit recherchierten echten Terminen für die Woche 21.–27.09. fertiggestellt (FOMC-Sitzung 15.–16.09. liegt bereits in Woche 1 und war damit nicht mehr relevant für diesen Post). Damit ist der Content für alle 12 Posts jetzt vollständig copy-paste-fertig, keine Platzhalter mehr offen.

**Neuer Mike-only-Zähler-Stand: 8** (13 minus die 5 heute bestätigten: Kanalbild, vier Kanalbilder freigeben, Make.com aktivieren, Willkommensnachricht, Follow-ups — letztere drei zählten als ein gemeinsamer Login-Vorgang, siehe [[Tagesplan]]). Verbleibend: Instagram-Bio-Feld, WhatsApp-Test, Posts 1-6 terminieren, Limitless-Support-Anfrage, Telegram-Warnungscheck, Google-Drive-Ordner, 20-Namen-Liste vervollständigen, persönlich anschreiben. Einziger noch offener Punkt an der Kanal-Strecke selbst: Posts 1-6 im Kanal terminieren — rein die App-Aktion, inhaltlich nichts mehr zu tun. Details siehe [[Tagesplan]], neuer Log-Eintrag vom selben Datum.

**Kontrolle 13.09.2026, dritter Lauf (Chat mit Mike, gleiche Session):** Mike hat zusätzlich zwei neue Profilbilder angefragt (Kanal + Bot). Auf Nachfrage gewählt: gestaltetes Icon statt echtem Foto. Beide über Jarvis (`gpt_image_2_5`) generiert und Mike als Datei geschickt — Kanal: Ring-Emblem (drei goldene konzentrische Ringe, markenunabhängig), Bot: Chat-Bubble mit Spark, beide im bestehenden Gold/Navy-Look, 1:1, ohne Text. Zwei neue Sofort-Punkte oben ergänzt (Setzen ist wieder App-only: Telegram-App fürs Kanalbild, @BotFather `/setuserpic` fürs Bot-Bild). **Mike-only-Zähler damit auf 10** (8 + 2 neue App-Login-Punkte).

---

## 1. Sofort (21)

### Telegram-Kanal Inner Circle
- [x] Kanalbeschreibung gesetzt (10.09.2026)
- [x] Kanalbild gesetzt — laut Mike im Chat am 13.09.2026 erledigt
- [x] Reaktionen: standen bereits auf "Alle" (geprüft 10.09.2026)
- [x] Kein Diskussionschat verknüpft (geprüft 10.09.2026)
- [x] Instagram-Bio um den Kanal-Link ergänzt (10.09.2026). Website-Feld (klickbarer Link) **erledigt 12.09.2026**, Mike hat es selbst in der App eingetragen
- [x] Bilder aus `Lim/Content/Telegram/` gegengecheckt und freigegeben — **erledigt 13.09.2026**, laut Mike im Chat (12.09. noch vertagt, da er nicht am PC war)
- [x] Referral-Link steht in der /start-Nachricht (geprüft 10.09.2026, worldoflimitless.com/?ref=2A5CC2B8)
- [x] Make.com-Szenario dauerhaft aktivieren inklusive neuer Willkommensnachricht und der drei Follow-ups — **korrigiert 12.09.2026:** war die ganze Zeit schon aktiv, per Make.com-Connector einer interaktiven Session verifiziert (`isActive: true`, Scheduling "immediately"); Willkommensnachricht direkt im selben Lauf mit eingetragen. Die drei Follow-ups hingen zunächst an einem Data-Store-Speicherlimit (siehe [[Tagesplan]]) — **erledigt 13.09.2026**, Mike hat die Datenstruktur-Erweiterung selbst am PC gemacht, laut Mike im Chat bestätigt
- [x] Bot-Strecke faktisch bestätigt: /start am 08. und 09.09.2026 ausgelöst, Onboarding-Nachricht inklusive Link kam an. Ungetestet bleibt nur der Weg über den Start-Button im Kanal
- [ ] Neues Kanal-Profilbild setzen (13.09.2026 generiert, Ring-Emblem-Icon, Gold/Navy) — Datei an Mike geschickt, Upload in der Telegram-App nur von ihm möglich (App-only, kein Connector)
- [ ] Profilbild für den Bot @LimitlessPuBot setzen (13.09.2026 generiert, Chat-Bubble-Icon, Gold/Navy) — via @BotFather → `/setuserpic`, Datei an Mike geschickt, nur er kann sich bei BotFather einloggen

### Jarvis Technik
- [x] `broker_login.py` ausgeführt (10.09.2026), jetzt nur noch Limitless und GMX. PU Prime ist aus der Brücke raus
- [x] Bridge-Lauf geprüft: PU Prime wird sauber übersprungen, Limitless liefert Werte. GMX scheitert weiter am SSO-Redirect und ist zurückgestellt
- [ ] WhatsApp end-to-end testen: Bridge ist nach neuem QR-Login (10.09.2026) wieder funktionsfähig, es fehlt eine echte eingehende Nachricht von einer anderen Person. Eigene Nachrichten überspringt die Bridge per Design — **läuft seit 12.09.2026 nicht mehr über den Tagesplan-Bestätigt-Kreislauf, Mike hakt selbst ab, sobald erledigt** (kein Messaging-Tool, um das anzustoßen, siehe [[Tagesplan]])
- [ ] `whatsapp`-Knoten in `frontend/main.js` von `plannedNode` auf `liveNode` umstellen, direkt nach dem Test
- [x] Entschieden (10.09.2026): Instagram und Facebook bleiben erstmal auf Zuruf, keine automatische Bridge, Meta Graph API zurückgestellt
- [ ] In ein paar Tagen: prüfen, ob WhatsApp Warnungen an der Geräteverknüpfung zeigt
- [ ] In ein paar Tagen: prüfen, ob Telegram Warnungen am persönlichen Account zeigt

### Anfragen, die nur du stellen kannst
- [x] Staffelsatz geklärt (10.09.2026): gilt nur oberhalb der Schwelle, nichts rückwirkend. MasterPlan und IB-Projekt neu gerechnet
- [x] Limitless-Support fragen, ob es eine API oder einen Webhook für den Prospect Tracker gibt — **erledigt 12.09.2026, Mike hat selbst geschrieben**
- [x] Pflegedienst-Kennzahlen von Mike geliefert (10.09.2026): 6 Kunden, ca. 1.500 EUR Umsatz, kein Überschuss, keine Mitarbeiter, Süchteln/Viersen, Kunden aus dem Bekanntenkreis. Eingetragen in [[Pflegedienst]]. Offen bleibt die freie Kapazität

### Kleinkram
- [x] Schichtplan eingepflegt (10.09.2026): steht komplett im Google Kalender ab 14.09., als Notiz [[Zwei-Wochen-Takt]] in den Vault übernommen
- [x] Rechnungsfotos: Google Drive, Ordner `Rechnungen/Eingang`, Scan per Drive-App (entschieden 10.09.2026). Ordner-Anlage **korrigiert 12.09.2026:** existiert bereits (angelegt 11.09.2026, per Google-Drive-Connector dieser Session verifiziert). Drive für Desktop prüfen steht noch aus

---

## 2. Aufwendig (14)

### Content und Akquise
- [ ] Posts 1 bis 6 für Woche 1 im Kanal terminieren (ca. 60 Minuten am Wochenende) — **läuft seit 12.09.2026 nicht mehr über den Tagesplan-Bestätigt-Kreislauf, Mike hakt selbst ab, sobald erledigt** (reine Telegram-App-UI-Funktion ohne Bot-API-Äquivalent, siehe [[Tagesplan]]). Inhaltlich seit 13.09.2026 nichts mehr offen: alle sechs Posts inkl. Post 6 fertig ausformuliert in [[Inner Circle Kanal-Content]], nur das Terminieren selbst steht noch aus
- [x] Neue Willkommensnachricht im Bot eintragen inklusive Button "Konto eröffnen" — **erledigt 12.09.2026** über den Make.com-Connector dieser interaktiven Session direkt im Blueprint der `/start`-Route eingetragen (neuer Text aus [[Inner Circle Kanal-Content]] Abschnitt 7, Link `?ref=2A5CC2B8` eingesetzt, Inline-Button "🏦 Konto eröffnen"), per erneutem Abruf verifiziert, am 13.09.2026 von Mike im Chat nochmal bestätigt
- [x] Drei Follow-ups im Bot einrichten (24 Stunden, 3 Tage, 7 Tage) — Texte fertig in [[Inner Circle Kanal-Content]] Abschnitt 7. Hing zunächst an einem Data-Store-Speicherlimit (Make-Team-Konto, siehe [[Tagesplan]] für Details) — **erledigt 13.09.2026**, Mike hat die Datenstruktur-Erweiterung und das Eintragen selbst am PC gemacht
- [x] Liste mit 20 Namen aus dem echten Umfeld zusammenstellen, die Trading interessiert — **erledigt 12.09.2026, 20/20 komplett** (letzte 4: Martin, Luisa, Lukas, Fabian), Tracking in [[Kontaktliste - 20 Namen aus dem Umfeld]]
- [ ] Diese 20 Leute persönlich anschreiben, keine Massentexte — Tracking und Status je Person in [[Kontaktliste - 20 Namen aus dem Umfeld]]. Ist Mikes eigene Aufgabe, kein Executor-Punkt: jede Nachricht persönlich, von Mike selbst verfasst oder freigegeben

### Zahlen und Struktur
- [x] Lot-Tracking aufsetzen: Gesamt-Lots pro Monat, Lots je Kunde, erreichte Staffelstufe. Die zentrale Steuergröße des IB-Projekts — Struktur am 12.09.2026 vom `aufgaben-executor` angelegt: [[Lot-Tracking]] (Staffel-Tabelle, Kopfwerte, Kunden-Tabelle, aktuell 0 Lots/0 Kunden). Automatisch aus [[Tagesplan]] nachgezogen, da alle Bestätigt-Punkte des Tages technisch blockiert waren und dies laut MasterPlan explizit zu Stufe 0 gehört
- [ ] Liste der wiederkehrenden Fixkosten anlegen (Bezeichnung, Betrag, Abbuchungstag, Rhythmus)
- [ ] Liste der Business-Kosten anlegen (Broker, ATAS, Tools, Abos)
- [ ] Klären, womit die Buchhaltung läuft, falls schon etwas existiert
- [x] Tagesstruktur steht bereits im Kalender und ist jetzt im Vault dokumentiert: [[Zwei-Wochen-Takt]]. Rund 12 Stunden Business pro Woche, in der Spätwoche vormittags, in der Frühwoche abends

### Technik
- [ ] Gmail-Zugang für `task_agent.py`: eigenes Google-Cloud-Projekt plus OAuth-Zustimmung
- [ ] GMX per IMAP anbinden, damit Mails wirklich alle 10 Minuten automatisch laufen
- [ ] Nachrichten-Dashboard automatisch nach jedem Bridge-Lauf aktualisieren statt nur auf Zuruf
- [ ] Trade_Journal.xlsx und die übrigen ChatGPT-Dokumente herunterladen und in 07 Anhänge ablegen, danach den restlichen ChatGPT-Verlauf sichten

---

## 3. Komplex (12)

### IB-Business
- [ ] Website bauen (aus [[KI-Automatisierung IB-Business]], seit Projektstart offen)
- [ ] Regelmäßig Content im Kanal posten, damit neue Abonnenten Substanz sehen. Läuft dauerhaft, braucht echtes Material von dir
- [ ] 12 Posts veröffentlichen, 3 pro Woche, Ziel aus den nächsten 30 Tagen des [[MasterPlan - Teilziele und Zeitplan bis 50.000 EUR]]
- [ ] Zugangs-Gate für die Gruppe: Beitritt erst nach Konto-Erstellung, technisch noch ungelöst
- [ ] Referenzprojekt bauen: Webseite oder Chatbot für den [[Pflegedienst]], kostenlos, dafür mit Ergebnis-Nachweis als Portfolio-Stück
- [ ] Sprachauswahl Deutsch und Englisch im Bot-Onboarding nachrüsten

### Jarvis
- [ ] Meta Graph API als sauberer Weg für Instagram- und Facebook-Nachrichten (eigenes Projekt, App-Registrierung, Freigabeprozess). Nur falls die Bridge wirklich gewollt ist
- [ ] Facebook-Anbindung, wurde bisher gar nicht erreicht, weil Instagram im Skript zuerst kommt
- [ ] Jarvis-Interface ausbauen: Sternenfeld-Optik, dritter Hauptast Stimme, Übersicht über Nachrichten, Kundenstamm, Verdienste und Termine
- [ ] Vault-Wachstum weitertreiben bis zur angepeilten Dichte, siehe [[Vision - Vault-Wachstum, Jarvis-Assistent & Monitoring]]
- [ ] Monitoring-System als eigene App: Umsatz täglich, wöchentlich, monatlich, Kundengewinnung, Trefferquote, CRV, Fortschritt Richtung 50.000 EUR
- [ ] Rechnungs-Automatik Stufe 2 und 3: Auslese-Agent, Prüf-Agent, Finanz-Dashboard, laut Plan ab Monat 4

---

## 4. Was ich dir empfehle

Du hast laut [[MasterPlan - Teilziele und Zeitplan bis 50.000 EUR]] rund 10 bis 15 Stunden pro Woche und die Regel maximal ein bis zwei aktive Baustellen. Die 21 Sofort-Aufgaben sind zusammen etwa drei bis vier Stunden. Wenn du die diese Woche wegräumst, verschwindet der größte Teil der Liste, ohne dass du an einem einzigen komplexen Thema arbeiten musst.

**Reihenfolge, die ich vorschlagen würde**
1. Kanal fertig machen (Beschreibung, Bild, Reaktionen, Bio-Link). Deine Instagram-Captions verweisen schon auf den Kanal, der Traffic läuft aktuell ins Leere.
2. Bot-Strecke einmal selbst durchklicken und Make.com dauerhaft aktivieren.
3. Die drei Anfragen rausschicken (Broker-Staffel, Limitless-API, Pflegedienst-Zahlen). Da wartest du danach nur noch auf Antwort.
4. `broker_login.py` ausführen, dann füttert sich das Dashboard selbst.
5. Erst danach an ein aufwendiges Thema, sinnvollerweise das Lot-Tracking, weil daran deine ganze Steuerung hängt.

Die komplexen Punkte bleiben bewusst liegen, bis der Schichtplan am 14.09. steht und die Tagesstruktur hängt.

## 5. Nebenbei aufgefallen

Erledigt am 10.09.2026: In [[Sport]], [[Laufplan-Fortschritt]] und [[Trainingsplan-Fortschritt]] zeigten sieben Wikilinks ins Leere. Sie zeigen jetzt auf [[Calisthenics Plan]] und [[Laufplan Halbmarathon November 2026]]. Die fehlende Notiz [[Zwei-Wochen-Takt]] wurde am selben Tag aus dem Kalender aufgebaut, die Links dorthin funktionieren wieder.

Verknüpft: [[MasterPlan - Teilziele und Zeitplan bis 50.000 EUR]] · [[Jarvis Hand - Agenten Ausbau]] · [[Inner Circle Kanal-Content]] · [[Brain Dump]]
