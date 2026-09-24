---
tags: [bereich, aufgaben, einnahmequellen]
status: aktiv
date: 2026-09-24
---

# Einnahmequellen-Recherche

Laufende Recherche des `aufgaben-manager`/`aufgaben-executor`-Paars zu zusätzlichen digitalen Einnahmequellen, die auf den [[MasterPlan - Teilziele und Zeitplan bis 50.000 EUR]] einzahlen. Ziel: nicht nur abwarten, sondern aktiv prüfen, was aktuell sinnvoll und mit Mikes Zeitbudget (10-15h/Woche) schnell machbar ist, bewerten und ihm konkrete, vorbereitete Vorschläge vorlegen statt nur Ideen zu sammeln.

**Entstanden aus Mikes Auftrag vom 24.09.2026 (Chat):** "im Digitalen bereich geld verdienen... verschiedenen einnahm möglichkeiten... Websiten für andere machen und vertreiben oder sonst was... nach dingen suchen die aktuell sin machen und die dann mir vorschlagen."

## Rahmen (nicht verhandelbar, aus dem MasterPlan)

- Bewegt sich innerhalb des bestehenden Ziel-Mix (siehe MasterPlan Abschnitt 2), nicht daneben: **Digitale Dienstleistungen** (Webseiten, Chatbots, Automatisierung, 25 %/12.500 EUR) und **Digitale Produkte** (Membership, Templates, 15 %/7.500 EUR). Nicht IB-Business/Content (läuft über `content-manager`/`-executor`), nicht Trading (0 % Einkommensanteil, MasterPlan Abschnitt 2, RG Trading bleibt strikt privat).
- Erstes konkretes Ziel steht bereits im MasterPlan: Stufe 1 fordert "Erstes Dienstleistungsprojekt verkauft (Webseite oder Chatbot, 1.500 bis 3.000 EUR)". In der [[Aufgaben-Triage (Sofort, Aufwendig, Komplex)]] liegt dazu seit 10.09.2026 unangefasst: "Referenzprojekt bauen: Webseite oder Chatbot für den [[Pflegedienst]], kostenlos, dafür mit Ergebnis-Nachweis als Portfolio-Stück" — naheliegender erster Schritt, bevor neue Ideen gesucht werden.
- MasterPlan Punkt 8 gilt weiter: max. 1-2 aktive Baustellen bei 12h/Woche. Diese Recherche ist kein neues, drittes/viertes Standbein neben IB/Content/YouTube, sondern arbeitet dem bestehenden "Digitale Dienstleistungen"-Anteil des IB-Plans zu.

## Freigabe-Modell (Mikes Entscheidung, 24.09.2026)

Zweistufig, wie beim Content-Agent, aber anders aufgeteilt:
- **Automatisch, ohne Einzelbestätigung:** Ideen suchen (Recherche), Machbarkeit/Passung bewerten, Angebots-/Website-Texte entwerfen, Vorarbeit fürs Referenzprojekt (z.B. Struktur, Text, Entwurf für den Pflegedienst).
- **Bleibt freigabepflichtig:** alles was nach außen geht – einen Kunden kontaktieren, ein Angebot tatsächlich verschicken, eine Domain/ein Tool/Abo kaufen, sich irgendwo neu registrieren. Diese Punkte laufen über `## Freigabe nötig: Einnahmequellen` in [[Tagesplan]], siehe dort.

Details siehe `.claude/agents/aufgaben-manager.md` (Abschnitt "Einnahmequellen-Explorer") und `.claude/agents/aufgaben-executor.md` (Abschnitt "Ausnahme: Einnahmequellen-Recherche").

## Ideen-Pool

*(wird vom `aufgaben-manager`/`aufgaben-executor` laufend gepflegt – gefundene Ideen, kurze Bewertung, Status.)*

| Idee | Kategorie (Dienstleistung/Produkt) | Passt zu Stufe | Aufwand grob | Bewertung | Status |
|---|---|---|---|---|---|
| **KI-Terminbuchungs-/FAQ-Chatbot für Handwerksbetriebe** (per Make.com + Jarvis, als Website-Widget oder WhatsApp-Bot) | Dienstleistung | Stufe 1, guter Kandidat fürs Erstprojekt (1.500-3.000 EUR) | Aufwendig — einmaliges Template bauen (ca. 1-2 Tage), danach pro Kunde wenige Stunden Anpassung | Mike kennt Make.com bereits aus dem eigenen Telegram-Bot, kein neues Werkzeug nötig. Marktpreise laut Recherche 3.000-5.000 EUR je Projekt (Prozessmeister) bzw. ab 1.490 EUR/Monat im Abo — deckt sich mit dem Stufe-1-Zielkorridor. Elektro-Handwerk als Zielgruppe passt zu seinem Vertrauensvorsprung im eigenen Netzwerk (siehe [[Kontaktliste - 20 Namen aus dem Umfeld]], [[Pflegedienst]]-Umfeld). **Update 24.09.2026:** Demo-Version gebaut (Webhook + KI-Intent-Erkennung + FAQ-Antwort per Make-AI-Tools + Terminanfrage-Meldung per Telegram-DM), technisch fertig aber nicht aktivierbar — Make-Konto erlaubt nur eine begrenzte Zahl aktiver Szenarien, beide Plätze belegt. Siehe [[Tagesplan]], "Technisch blockiert". | technisch fertig, Aktivierung blockiert (Make-Plan-Limit) |
| **Website-Baukasten-Service für kleine Handwerks-/Dienstleistungsbetriebe** (No-Code, über Jarvis' `website-builder-flow`-Workflow) | Dienstleistung | Stufe 1 — direkter Treffer auf die im MasterPlan genannte Erstprojekt-Bedingung ("Webseite oder Chatbot, 1.500-3.000 EUR") | Komplex — Standard-Template einmal bauen, dann mehrere Tage Anpassung pro Kunde | Jarvis bietet laut eigener Tool-Dokumentation einen dedizierten Workflow für Websites, den Mike ohne Entwickler-Kenntnisse bedienen kann. **Update 24.09.2026:** Der Pflegedienst-Fall ist konkreter geworden als reines Portfolio-Stück — die bestehende Seite läuft aktuell über IONOS für ca. 50 EUR/Monat, Mike will das selbst günstiger ersetzen (siehe [[Pflegedienst]]). Erste Text-/Strukturentwürfe stehen und sind von Mike inhaltlich freigegeben, das Thema ist aber bewusst **pausiert bis Sonntag, 27.09.2026** (gemeinsame Besprechung mit seiner Mutter) — kein Agenten-Schritt bis dahin. | pausiert bis 27.09.2026, Entwürfe fertig und freigegeben, aber noch nichts verschickt |
| **Google-Unternehmensprofil-Optimierung als Einstiegspaket für lokale Betriebe** (Ersteinrichtung, Fotos, Beschreibung, Bewertungsmanagement) | Dienstleistung | Kein eigenständiges Stufe-1-Projekt (Preis zu niedrig für 1.500-3.000 EUR), aber guter Türöffner vor größeren Aufträgen | Sofort bis Aufwendig — wenige Stunden pro Kunde | Sehr niedrige Einstiegshürde: das Profil selbst ist für den Kunden kostenlos, Agenturen verlangen laut Recherche ab ca. 299 EUR für die Optimierung. Technisch schon ein Werkzeug vorhanden — der bestehende Windsor.ai-Connector unterstützt laut eigener Doku bereits Schreibzugriff auf Google Business Profile (Posts/Reviews/Listing-Änderungen), sobald ein Kundenaccount verbunden ist. Guter Kombi-/Upsell-Baustein zu den beiden Ideen oben. | offen |
| **KI-Automatisierungspakete für Admin-Prozesse kleiner Betriebe** (Rechnungserfassung, Lead-Erfassung/-Routing, Terminerinnerungen via Make.com) | Dienstleistung | Stufe 1, mit Potenzial für ein wiederkehrendes Abo-Modell | Komplex — pro Kunde eigene Prozessanalyse nötig, mehrere Tage bis Wochen | Baut auf Mikes eigenem, bereits geplantem Rechnungs-Automatik-Vorhaben auf (siehe [[Aufgaben-Triage (Sofort, Aufwendig, Komplex)]], "Komplex", Stufe 2/3 im eigenen IB-Business) — dieselbe Technik ließe sich als Dienstleistung verkaufen. Marktpreise laut Recherche ab 1.490 EUR/Monat (Abo) oder ab 2.500 EUR (Einmalprojekt), für den Kunden teils über BAFA/"go-digital" bis zu 50 % förderfähig (Verkaufsargument). Höherer Aufwand pro Kunde als der Chatbot oben, deshalb eher zweiter Schritt nach dem ersten Projekt. | offen |
| **Digitale Lern-/Prüfungsvorbereitungs-Templates für angehende Elektroniker** (PDF-Checklisten, Übungsblätter, kleines Bundle für die Gesellenprüfung) | Produkt | Kein Stufe-1-Ersatz (zu kleinteilig für 1.500-3.000 EUR), aber risikoarmer erster Test für die "Digitale Produkte"-Kategorie | Sofort bis Aufwendig — Content selbst erstellen, kein technisches Setup außer einfacher Verkaufsseite/Marktplatz-Listing | Nutzt zwei echte Vorerfahrungen: Elektromeister-Fachwissen plus frühere Tätigkeit als Dozent für technische/mathematische Fächer (siehe [[Über mich]]). Templates/Checklisten verkaufen sich laut Recherche aktuell gut (Einstiegspreise 9-29 EUR, Bundles bis ca. 197 EUR), spezifisch fürs Elektrohandwerk aber eine Nische ohne direkt gefundene Vergleichsangebote — Chance auf wenig Konkurrenz, aber auch unklare Nachfrage, deshalb eher kleiner Test als große Wette. Passiv nach Ersterstellung. | offen |

## Entschieden / verworfen

*(Ideen, die bewertet und abgeschlossen wurden, mit Begründung – nichts wird stillschweigend gelöscht, siehe Vault-Regel additiv arbeiten)*

## Log

*(jeder Recherche-Lauf mit Datum: was wurde geprüft, was kam neu dazu, was wurde verworfen und warum)*

### 2026-09-24, Abend (Chat mit Mike, kein Subagent)
Pflegedienst-Text-Entwürfe von Mike inhaltlich freigegeben ("Passt so"), aber explizit gestoppt: seine Mutter zahlt aktuell ~50 EUR/Monat bei IONOS für die bestehende Website, Ziel ist eine selbst gebaute, günstigere Lösung statt nur ein Portfolio-Stück. Thema **pausiert bis Sonntag, 27.09.2026** — wird dann gemeinsam mit seiner Mutter weiterbesprochen. Idee 2 oben entsprechend aktualisiert, kein weiterer Agenten-Schritt zu diesem Punkt bis dahin.

### 2026-09-24, aufgaben-executor-Lauf (Recherche-Auftrag aus `## Bestätigt für 2026-09-24 (Einnahmequellen-Recherche, Standing-Freigabe)`)
Auftrag aus [[Tagesplan]] abgearbeitet: 5 aktuell realistische digitale Einnahmequellen-Ideen recherchiert (WebSearch, vier Suchen zu Preisen/Trends 2026: KI-Automatisierung für Handwerksbetriebe, No-Code-Chatbots für kleine Unternehmen, Google-Unternehmensprofil-Optimierung, digitale Templates/Checklisten) und oben im Ideen-Pool eingetragen, Beispielzeile ersetzt. Drei Dienstleistungs-Ideen (Chatbot, Website-Baukasten, Admin-Automatisierung) und eine vierte (GMB-Optimierung) plus ein Produkt (Lern-Templates für Azubis). Alle fünf bewusst innerhalb des MasterPlan-Ziel-Mix (Abschnitt 2) gehalten — nichts mit Trading/IB-Bezug geprüft oder vorgeschlagen, das wäre außerhalb des Rahmens dieser Recherche gewesen (RG Trading Academy bleibt ohnehin strikt privat, siehe MasterPlan-Trennregel).

Konkrete, nach außen wirkende Schritte (Kundenkontakt, Angebot verschicken, Domain/Tool kaufen, Registrierung) waren in keiner der fünf Ideen in dieser Recherche-Runde nötig — reine Web-Recherche und Bewertung, deshalb kein neuer Eintrag unter `## Freigabe nötig: Einnahmequellen` in [[Tagesplan]]. Zwei Ideen (Website-Baukasten fürs Pflegedienst-Referenzprojekt, Chatbot) sind direkte Stufe-1-Kandidaten und bereits mit Preis-Richtwerten hinterlegt; noch keine Priorisierung zwischen den fünf Ideen vorgenommen — das ist Mikes Entscheidung bzw. der nächste Schritt des `aufgaben-manager`.

Nicht weiter vertieft, weil laut vorherigem Log-Eintrag bereits an fehlenden Fakten hängend: konkrete Vorarbeit (Texte/Struktur) für das [[Pflegedienst]]-Referenzprojekt selbst — Name und URL der bestehenden Website stehen laut [[Pflegedienst]] weiterhin nicht im Vault, das wäre sonst Erfinden von Fakten über eine reale, existierende Website. Bleibt offene Frage an Mike (siehe [[Tagesplan]]).

Geänderte Datei: `03 Bereiche/Aufgaben-Management/Einnahmequellen-Recherche.md` (dieser Log-Eintrag, Ideen-Pool-Tabelle befüllt).

### 2026-09-24 (aufgaben-manager, erster Lauf nach Mikes Auftrag)
Ideen-Pool war noch komplett leer (nur die Gerüst-Beispielzeile) — kein bereits bewerteter, unentschiedener Punkt zum Priorisieren vorhanden. Deshalb direkt per Standing-Freigabe einen Recherche-Auftrag in [[Tagesplan]] unter `## Bestätigt für 2026-09-24 (Einnahmequellen-Recherche, Standing-Freigabe)` eingetragen: 3-5 aktuell realistische digitale Einnahmequellen-Ideen (Dienstleistung/Produkt, passend zu Mikes Elektromeister-Profil und KI-Agenten-Zugriff) recherchieren und hier im Ideen-Pool eintragen. Noch keine eigene Recherche durchgeführt (dieser Agent hat kein WebSearch/WebFetch-Werkzeug in dieser Runde) — das übernimmt der `aufgaben-executor` im nächsten Lauf.

Zusätzlich das bereits bekannte [[Pflegedienst]]-Referenzprojekt gegengeprüft: laut dortiger Notiz hat Mike am 14.09.2026 entschieden, das Thema als drittes Standbein anzugehen, mit einem für 16.09.2026 geplanten Termin bei seiner Mutter (freie Kapazität, Google-Unternehmensprofil, bestehende Website sichten). Ob dieser Termin stattgefunden hat, ist im Vault nicht dokumentiert, und Name/URL der bestehenden Website fehlen weiterhin — als offene Frage an Mike in [[Tagesplan]] übernommen, keine Vorarbeit mit erfundenen Fakten gestartet.

---

Verknüpft: [[MasterPlan - Teilziele und Zeitplan bis 50.000 EUR]] · [[Aufgaben-Triage (Sofort, Aufwendig, Komplex)]] · [[Tagesplan]] · [[Pflegedienst]]
