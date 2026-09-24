---
tags: [marketing, tracking]
status: aktiv
date: 2026-09-24
---

# Link-Klick-Tracking

Konzept-Recherche zur Lücke aus [[MasterPlan - Teilziele und Zeitplan bis 50.000 EUR]] Abschnitt 7: Link-Klicks auf Bio-/Kanal-Link stehen seit 24.09.2026 als eigene Kennzahl drin, aktuell aber bei 0 Sichtbarkeit ("wir brauchen auch mehr Link Klicks - aktuell noch keine, Auswertung und Verbesserung ist wichtig", Mike im Chat). Auftrag aus [[Tagesplan]], `## Bestätigt für 2026-09-24 (Stufe 1 Auftakt: Pflegedienst-Vorarbeit & Link-Klick-Tracking)`.

## Ausgangslage (24.09.2026)
- Die Instagram-Bio verlinkt aktuell als Text direkt auf den öffentlichen Kanal `t.me/JointoInnerCircle` (siehe [[Inner Circle Kanal-Content]]), nicht auf den Bot. Kein Tracking-Mechanismus aktiv.
- Der Bot `@LimitlessPuBot` trägt in seiner `/start`-Route bereits den Referral-Link `worldoflimitless.com/apply?ref=2A5CC2B8` (siehe [[Aufgaben-Triage (Sofort, Aufwendig, Komplex)]]). Auch hier bislang keine Quellen-Unterscheidung.
- Der Windsor.ai-Connector für Instagram ist verbunden, wird aber bisher nur manuell von interaktiven Sessions abgerufen (siehe [[Instagram-Reichweite]]) — der `aufgaben-executor` hat dieses Werkzeug nicht in seiner eigenen Tool-Liste (in diesem Lauf standen nur Read/Glob/Grep/Edit/Write/WebSearch/WebFetch zur Verfügung).

## Ergebnis der Recherche

### 1. Sofort umsetzbar, ohne neuen Login/neues Tool (nutzt bereits vorhandene Zugänge)

**a) Telegrams eigenes Mehrfach-Einladungslink-Tracking für den Kanal — empfohlener erster Schritt**
Telegram-Kanäle unterstützen nativ mehrere, unterscheidbare Einladungslinks pro Kanal. Für jeden Link zeigt Telegram direkt in der App (Kanal-Info → Einladungslinks verwalten) die Anzahl der darüber beigetretenen Mitglieder an — ohne Zusatz-Tool, Mike ist als Kanal-Admin dafür bereits berechtigt.
Vorschlag: mindestens 3 benannte Links anlegen, z.B. "Instagram-Bio", "Kanal-Post-CTA", "Direkt/Sonstige", und den in der Instagram-Bio hinterlegten Link auf den "Instagram-Bio"-Link umstellen statt wie bisher den generischen `t.me/JointoInnerCircle`.
Vorteil gegenüber reinem Klick-Zählen: misst tatsächliche Beitritte (Conversion), nicht nur Klicks — für Mikes eigentliches Anliegen ("Auswertung und Verbesserung") die aussagekräftigere Zahl.

**b) Windsor.ai-Feld `website_clicks_1d` (Instagram Insights)**
Laut Windsor.ai-Datenfeld-Dokumentation für Instagram existiert das Feld `website_clicks_1d` ("Total number of taps on the website link in the Instagram user's profile") — genau die Bio-Link-Klickzahl, die aktuell nirgends erfasst wird. Instagram Insights liefert dabei nur eine aggregierte Tageszahl, keine Aufschlüsselung nach Quelle/Post und keine Nutzeridentität (Plattform-Limit, kein Windsor.ai-Limit).
Der Connector ist bereits verbunden (siehe [[Instagram-Reichweite]]), wird bisher aber nur manuell durch eine interaktive Session mit Windsor.ai-Zugriff abgerufen. Empfehlung: `website_clicks_1d` beim nächsten manuellen Pull als neue Spalte in [[Instagram-Reichweite]] mit aufnehmen. Kein neuer Login nötig, nur eine Erweiterung des bereits bestehenden Abrufs.

### 2. Braucht Mikes eigenen Login/Setup

- Die unter 1a beschriebenen Telegram-Einladungslinks anlegen und den Bio-Link in der Instagram-App entsprechend umstellen (App-only, wie beim bereits bekannten offenen Punkt "Website-Feld").
- **Telegram-Start-Parameter über den Bot, als Alternative/Ergänzung zu 1a:** Wichtige Korrektur gegenüber der Annahme in der Aufgabenstellung: der `?start=`-Parameter-Mechanismus funktioniert laut Telegram-Doku nur bei Bot-Links (`t.me/<bot>?start=<payload>`), nicht bei Kanal-Links — die Instagram-Bio verlinkt aber aktuell auf den Kanal, nicht auf den Bot. Um das trotzdem zu nutzen, müsste die Bio künftig auf z.B. `t.me/LimitlessPuBot?start=ig` statt auf den Kanal verlinken, und der Bot müsste im `/start`-Handler je nach Payload reagieren (z.B. weiterhin die gewohnte Willkommensnachricht zeigen, aber den Payload mitloggen). Format hat harte Grenzen: nur ein einzelner Wert pro Link, maximal 64 Zeichen, nur Buchstaben/Ziffern/Unterstrich/Bindestrich — klassische Mehrfach-Parameter wie bei UTM (`utm_source=x&utm_medium=y`) passen da nicht rein, nötig wäre ein eigenes, kompaktes Kürzel-Schema, z.B. `ig_bio`, `tg_post_ep5`, `direkt`. Umsetzung liefe über dasselbe Make.com-Szenario ("Integration Telegram Bot", ID 7240246), das schon für Willkommensnachricht/Follow-ups genutzt wird — braucht also einen Make.com-Login wie die bereits bekannten offenen Bot-Punkte. Empfehlung: nur angehen, falls 1a (reine Beitritts-Zahl je Quelle) nicht granular genug ist, weil dieser Weg zusätzlich den bestehenden Bio-Linktext ändert und mehr Technik-Aufwand bedeutet.
- **UTM-Parameter am finalen Limitless-Apply-Link** (`worldoflimitless.com/apply?ref=2A5CC2B8`): technisch ließe sich ein zusätzlicher Parameter anhängen (z.B. `&utm_source=telegram`), aber es gibt im Vault keinen Beleg, dass worldoflimitless.com solche Parameter überhaupt auswertet oder in einem für Mike sichtbaren Dashboard anzeigt — es ist eine fremde, nicht selbst kontrollierte Website. Recherche bestätigt allgemein: UTM-Parameter funktionieren nur, wenn die Zielseite sie aktiv ausliest, sonst gehen sie ins Leere; manche Drittseiten behandeln unbekannte Parameter zudem nicht sauber (z.B. bei eigenen Weiterleitungen). Empfehlung: vor einer Änderung am produktiv genutzten Referral-Link entweder testen oder beim Limitless-Support nachfragen, ob und wie UTM-Daten ausgewertet werden — ähnlich der bereits dokumentierten früheren Support-Anfrage zum Prospect Tracker (siehe [[Tagesplan]], Abschnitt "Aus dem Lauf 2026-09-12"). In dieser Runde nicht selbst verändert, weil sonst ein produktiv genutzter Link ohne Rücksprache angefasst würde — echter, nach außen wirkender Schritt am bestehenden Funnel.

### 3. Bräuchte einen neuen Tool-Kauf (nur benannt, nicht umgesetzt)

- Ein eigener Kurzlink-/Redirect-Dienst (z.B. ein bezahltes Tool wie Bitly mit erweiterten Klick-Analysen, oder ein selbst gehosteter Redirect über eine eigene Domain) für eine durchgängige Klick-Kette Instagram → Zwischenseite → Telegram/Limitless mit klick-genauer Zuordnung inklusive Uhrzeit/Gerät. Aktuell nicht nötig: die beiden kostenlosen Bausteine oben (Telegram-Mehrfachlinks + Windsor.ai-Feld) schließen den Großteil der aktuellen "0 Sichtbarkeit"-Lücke, ohne dass Geld ausgegeben werden muss. Nur relevant, falls Mike später eine geräte-/zeitgenaue Analyse über mehrere Plattformen hinweg will.
- Ein Link-in-Bio-Tool (z.B. Linktree-artig) für mehrere gleichzeitige Links in der Instagram-Bio (Instagram erlaubt aktuell nur einen klickbaren Website-Link im Profil). Nur relevant, falls künftig mehr als ein Ziel-Link aus der Bio gebraucht wird — aktuell nicht der Fall, ein Ziel (Telegram-Kanal) reicht.

## Empfehlung / nächster Schritt
Kombination aus 1a (Telegram-Mehrfachlinks) und 1b (Windsor.ai-Feld mitloggen) deckt Mikes eigentliches Anliegen ("Auswertung und Verbesserung") am schnellsten und ohne neue Kosten ab. Beides sind aber Schritte, die nur Mike selbst ausführen kann (Telegram-App-Login bzw. der nächste manuelle Windsor.ai-Pull einer interaktiven Session) — der `aufgaben-executor` kann das Konzept nur vorbereiten, nicht selbst eintragen.

## Log

### 2026-09-24, aufgaben-executor-Lauf
Konzept aus dem Bestätigt-Auftrag in [[Tagesplan]] erarbeitet (WebSearch/WebFetch: Windsor.ai-Instagram-Datenfelder, Telegram-Deep-Link-/Start-Parameter-Mechanismus, Telegram-Kanal-Einladungslink-Tracking, allgemeine Funktionsweise von UTM-Parametern bei Drittseiten). Wichtigste eigene Erkenntnis gegenüber der ursprünglichen Annahme in der Aufgabenstellung: der `?start=`-Ansatz funktioniert nur für Bot-Links, die Instagram-Bio verlinkt aktuell aber auf den Kanal — deshalb zusätzlich Telegrams eigenes Mehrfach-Einladungslink-Tracking recherchiert und als einfacheren, kostenlosen ersten Schritt empfohlen. Kein nach außen wirkender Schritt ausgeführt (kein Link geändert, kein Tool gekauft, kein Make.com-Login genutzt) — reine Recherche/Konzeptarbeit, gedeckt durch die normale Executor-Autonomie für Konzeption/Doku (kein Einnahmequellen-Punkt, sondern reguläres technisches Setup laut "Kein Stillstand mehr"-Regel).

Verknüpft: [[MasterPlan - Teilziele und Zeitplan bis 50.000 EUR]] · [[Inner Circle Kanal-Content]] · [[Instagram-Reichweite]] · [[Aufgaben-Triage (Sofort, Aufwendig, Komplex)]] · [[Tagesplan]]
