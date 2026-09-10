---
tags: [projekt]
status: aktiv
erstellt: 2026-09-04
---

# KI-Automatisierung IB-Business

## Ziel
Ein vollautomatisches System für die Kundenakquise im IB-Business bauen: Kunden werden automatisiert akquiriert, bekommen alle Links per Klick zur Verfügung gestellt (z.B. über einen Telegram-Bot) und erhalten automatisch Nachrichten in Gruppen. Ziel ist, dass der IB-Bereich möglichst ohne manuelle Arbeit von alleine läuft.

## Status
In Bearbeitung

## Nächste Schritte
- [ ] Telegram-Gruppe erstellen
- [ ] Telegram-Bot für vollautomatische Nachrichten erstellen
- [ ] Nachrichten-Texte für den Bot erstellen
- [ ] Website bauen
- [ ] Klären ob Limitless eine API/Webhook für den Prospect Tracker anbietet (bei Limitless-Support erfragen), sonst Alternative planen (z.B. eigene Datenbank/Airtable, die der Telegram-Bot befüllt, plus regelmäßiger CSV-Export/Abgleich mit dem Prospect Tracker)

## Telegram-Bot Setup — Ablauf & Fortschritt

Ziel: Neues Mitglied kommt in die Telegram-Gruppe → Bot postet eine Nachricht mit "Start Now"-Button → Klick öffnet den privaten Chat mit dem Bot → Bot schickt automatisch die Onboarding-Nachricht (Platzhaltertext fürs Erste, wird später durch den finalen Text ersetzt).

**Setup-Schritte:**
- [x] Bot bei @BotFather erstellt, Token vorhanden (04.09.2026)
- [x] Make.com-Account erstellt (04.09.2026)
- [x] Telegram-Gruppe erstellt, Bot als Admin hinzugefügt (04.09.2026)
- [x] Make.com-Szenario gebaut: Telegram-Trigger (Watch Updates), Bot-Verbindung per Token in Make eingetragen (04.09.2026)
- [x] Router/Filter: neues Gruppenmitglied vs. "/start"-Nachricht im Privatchat (04.09.2026) — Filter korrekt auf "New Chat Members" bzw. Text startet mit "/start" eingestellt, damit nur echte Beitritte/Start-Befehle durchgehen
- [x] Aktion 1: Bei neuem Mitglied → Nachricht in der Gruppe mit Inline-Button "🚀 Start Now" (Link: t.me/<BotUsername>?start=go) — getestet, funktioniert (04.09.2026)
- [x] Aktion 2: Bei "/start" im Privatchat → Onboarding-Nachricht (erstmal Platzhaltertext) an den Nutzer senden — eingerichtet, noch nicht live durchgeklickt
- [x] Zusatz: Alte "Start Now"-Nachricht wird automatisch gelöscht, bevor die neue gepostet wird, damit der Gruppenchat nicht mit Willkommensnachrichten vollläuft (Data Store speichert die letzte Message-ID pro Gruppe) — getestet, funktioniert (04.09.2026)
- [ ] Szenario testen: kompletten Ablauf einmal durchklicken (Start Now → privater Chat → Onboarding-Nachricht kommt an)
- [ ] Platzhaltertexte durch finale Nachrichten-Texte ersetzen
- [ ] Szenario dauerhaft aktivieren ("Immediately as data arrives" ist aktuell zu Testzwecken an)

**Die bestehende Telegram-Gruppe "Limitless" bleibt erhalten** (Entscheidung 04.09.2026): Neue Mitglieder sehen dort keine ältere Chat-Historie, was für reine Content-Distribution ungünstig ist — die Gruppe ist aber für späteren Live-Austausch/Community-Chat weiterhin nützlich und wird nicht abgeschaltet. Die Automatisierung (Willkommensnachricht mit Start-Button beim Beitritt) läuft dort unverändert weiter.

## Telegram-Kanal "Inner Circle" — Content & Onboarding

**Hintergrund:** Neue Gruppenmitglieder sehen keine vorherige Chat-Historie — für den geplanten Anwendungsfall (Leute kommen rein, sehen bisherige Posts/Content, klicken auf Start) ungeeignet. Als Vorbild diente Mikes eigenes Beispiel "Freedom Circle" von Moritz Schulz: ein Kanal mit voller Sichtbarkeit der Historie für alle Abonnenten plus einer angepinnten Nachricht mit Start-Link zum privaten Bot-Chat.

**Umsetzung (04.09.2026):**
- [x] Neuer öffentlicher Telegram-Kanal erstellt: **"Inner Circle - Mike Bühler"** (eigene Marke, angelehnt an "Freedom Circle", bewusst ohne Bezug zu "Limitless" im Namen, um markenrechtlich unabhängig zu bleiben)
- [x] Öffentlicher Link: **t.me/JointoInnerCircle**
- [x] Beschreibung gesetzt: "Kostenloses Trading-Ökosystem: Signale, Automatisierung & Live-Sessions. Klick auf Start für den Einstieg."
- [x] Bot (@LimitlessPuBot) als Administrator hinzugefügt (von Mike selbst erledigt, da die Admin-Suche im Telegram-Web-Client Bots nicht zuverlässig fand)
- [x] Willkommensnachricht gepostet und angepinnt: "🚀 Willkommen im Inner Circle! Klick auf den Link und starte den Bot für alle Infos: https://t.me/LimitlessPuBot?start=go" — fungiert wie der "Start"-Button bei Freedom Circle (Telegram verlinkt t.me-Links automatisch klickbar)
- [ ] Prüfen, ob sich der Link stattdessen als echter Inline-Button (wie bei Freedom Circle) über die Bot-API/Make.com posten lässt, statt als reiner Textlink
- [ ] Regelmäßig Content im Kanal posten (Signale, Updates, Live-Sessions-Ankündigungen etc.), damit neue Abonnenten beim Beitritt direkt Substanz sehen
- [ ] Platzhaltertexte (Kanal-Willkommensnachricht + Bot-Onboarding-Nachricht) durch finale Texte ersetzen

**Verhältnis Gruppe ↔ Kanal (Rollen final geklärt, 04.09.2026):**
- **Kanal "Inner Circle"** = Akquise/Top of Funnel. Öffentlich, für neue/kalte Kontakte. Zeigt Content wie "Gewinne"/Erfolge (ähnlich Moritz' "Freedom Circle") und Ausschnitte, damit Interessenten sehen, was sie erwartet, und dann über den Start-Link ein Konto erstellen.
- **Gruppe "Limitless"** = Community/Interaktion nach Anmeldung. Gedacht für Leute, die bereits ein Konto erstellt haben — dort werden regelmäßig Termine (Live-Sessions etc.) gepostet, Mitglieder tauschen Signale aus und schreiben miteinander.
- Offener Punkt: Der Gruppen-Beitritt soll idealerweise erst nach Konto-Erstellung erfolgen (Zugangs-Gate) — aktuell gibt es dafür noch keine technische Prüfung/Freigabe, die Gruppe ist weiterhin per Invite-Link frei beitretbar. Muss noch gelöst werden (z.B. manuelle Freigabe oder später Abgleich mit Kontodaten).

## Notizen

### 04.09.2026 — Limitless Affiliate-Dashboard angeschaut
Mike hat sich eingeloggt, ich habe mir mit seiner Erlaubnis den Affiliate-Bereich von Limitless angeschaut (kein Passwort wurde mir gegeben oder von mir eingegeben — Zugriff lief über die bestehende Browser-Session). Relevant für die Automatisierung:

- Es gibt bereits einen eingebauten **Prospect Tracker** (worldoflimitless.com/affiliate/prospect-tracker): ein Kanban-Board mit den Stufen Prospects → Contacted → Meeting Set → Closing → Signed Up, aktuell leer. Kontakte lassen sich manuell per "Add Contact" hinzufügen, es gibt einen CSV-Export.
- Auf den ersten Blick keine sichtbare Automatisierungs-Schnittstelle (API/Webhook), über die neue Kunden automatisch reinlaufen würden — nur manuelles Anlegen. Müsste beim Limitless-Support nachgefragt werden, ob es intern eine API gibt (z.B. für Affiliate-Tools).
- Es gibt ein Benachrichtigungssystem im Dashboard (Glocken-Icon), darüber laufen vermutlich Infos zu neuen Anmeldungen etc.
- Affiliate-Bereich hat außerdem: My Links (eigener Werbelink), Rewards Plan, 90 Day Run (aktuelle Incentive-Kampagne, Thailand-Reise), How to Start (6 Schritte), Affiliate Academy, IB Live Sessions, Trade.com (Automation-Onboarding-Guide), sowie einen offiziellen Affiliate-Telegram-Kanal.
- Für Mikes Wunsch (automatische Kundenliste + Benachrichtigung bei neuer Anmeldung) heißt das: entweder eine eigene Lösung bauen (Telegram-Bot → eigene Datenbank/Airtable → Benachrichtigung), die den Prospect Tracker per CSV ergänzt oder ersetzt, oder klären ob Limitless doch eine API anbietet.

### 04.09.2026 — PrimeVerse IB-Bereich angeschaut
Auch bei PrimeVerse (hub.primeverse.ca) eingeloggt und den IB-Bereich (Umschalter "Client/IB") angeschaut:

- **My Clients**: Tabelle der über PU Prime geworbenen Kunden (Konto, Markup-Stufe, Land, Status, Deposits, Volumen, Signed-up-Datum) plus Weltkarte nach Land. Wichtiger Fund: Die Daten stammen laut Seite aus dem "**latest activated IB import**" — es ist also ein periodischer Datenimport, kein Live-Webhook.
- **Command Center**: Übersichts-Dashboard (Total Clients, IB Downlines, Länder, "New Referrals **vs. last ingestion**"). Der Begriff "ingestion/import" bestätigt: neue Anmeldungen tauchen erst nach dem nächsten Datenabgleich auf, nicht sofort in Echtzeit.
- **Funnel** (in der Sidebar): eingebettetes "Funnel Hub"-Tool auf einer separaten Subdomain (go.primeverse.ca), sieht nach einem White-Label-Marketing/CRM-Tool aus (ähnlich GoHighLevel, u.a. Icons für Stats, Kampagnen, Konversationen, Kontakte). Bei Mike aktuell gesperrt: Fehler "403 primeverse_membership_required" — braucht eine aktive PrimeVerse-Mitgliedschaft, die er noch nicht hat.
- Weitere Menüpunkte im IB-Bereich: My Organization, Partner Pathway (gesperrt), Sub-IBs, IB Request, Affiliate Training (teils gesperrt).
- Fazit für die Automatisierung: Weder Limitless noch PrimeVerse bieten aktuell eine erkennbare Echtzeit-API/Webhook für neue Kunden — beide arbeiten mit periodischem Import/Ingestion. Für "sofortige" Benachrichtigungen bei neuer Anmeldung führt vermutlich kein Weg an einer eigenen Lösung vorbei (Telegram-Bot fängt die Anmeldung direkt beim Nutzer ab, bevor der überhaupt beim Broker landet). Das eingebettete Funnel-Hub-Tool bei PrimeVerse könnte relevant werden, sobald die Mitgliedschaft freigeschaltet ist — dort lohnt sich ein zweiter Blick.

