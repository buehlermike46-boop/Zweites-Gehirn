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
| **KI-Terminbuchungs-/FAQ-Chatbot für Handwerksbetriebe** (per Make.com + Jarvis, als Website-Widget oder WhatsApp-Bot) | Dienstleistung | Stufe 1, guter Kandidat fürs Erstprojekt (1.500-3.000 EUR) | Aufwendig — einmaliges Template bauen (ca. 1-2 Tage), danach pro Kunde wenige Stunden Anpassung | Mike kennt Make.com bereits aus dem eigenen Telegram-Bot, kein neues Werkzeug nötig. Marktpreise laut Recherche 3.000-5.000 EUR je Projekt (Prozessmeister) bzw. ab 1.490 EUR/Monat im Abo — deckt sich mit dem Stufe-1-Zielkorridor. Elektro-Handwerk als Zielgruppe passt zu seinem Vertrauensvorsprung im eigenen Netzwerk (siehe [[Kontaktliste - 20 Namen aus dem Umfeld]], [[Pflegedienst]]-Umfeld). **Update 24.09.2026:** Demo-Version gebaut (Webhook + KI-Intent-Erkennung + FAQ-Antwort per Make-AI-Tools + Terminanfrage-Meldung per Telegram-DM), technisch fertig aber nicht aktivierbar — Make-Konto erlaubt nur eine begrenzte Zahl aktiver Szenarien, beide Plätze belegt. Siehe [[Tagesplan]], "Technisch blockiert". | **Update 25.09.2026:** technisch fertig, aktiviert, live getestet (Make-Plan-Limit gelöst), inhaltlich auf echtes Elektrobetrieb-Profil umgestellt, live-Demo-Website gebaut (https://handwerker-chatbot.higgsfield.app). Auf Mikes Entscheidung mit Idee 3 zu einem Gesamtpaket (299 EUR) zusammengelegt, siehe Abschnitt "Idee 1 + 3 zusammengelegt" unten. | mit Idee 3 zum Gesamtpaket zusammengelegt (299 EUR), siehe unten |
| **Website-Baukasten-Service für kleine Handwerks-/Dienstleistungsbetriebe** (No-Code, über Jarvis' `website-builder-flow`-Workflow) | Dienstleistung | Stufe 1 — direkter Treffer auf die im MasterPlan genannte Erstprojekt-Bedingung ("Webseite oder Chatbot, 1.500-3.000 EUR") | Komplex — Standard-Template einmal bauen, dann mehrere Tage Anpassung pro Kunde | Jarvis bietet laut eigener Tool-Dokumentation einen dedizierten Workflow für Websites, den Mike ohne Entwickler-Kenntnisse bedienen kann. **Update 24.09.2026:** Der Pflegedienst-Fall ist konkreter geworden als reines Portfolio-Stück — die bestehende Seite läuft aktuell über IONOS für ca. 50 EUR/Monat, Mike will das selbst günstiger ersetzen (siehe [[Pflegedienst]]). Erste Text-/Strukturentwürfe stehen und sind von Mike inhaltlich freigegeben, das Thema ist aber bewusst **pausiert bis Sonntag, 27.09.2026** (gemeinsame Besprechung mit seiner Mutter) — kein Agenten-Schritt bis dahin. | **Update 25.09.2026 (Mikes direkter Auftrag im Chat, "Websites bauen, als Synergie zu meinem Bot und Google-Optimierung"):** vom reinen Pflegedienst-Sonderfall gelöst und als eigenständiges, allgemeines Angebot ausgearbeitet — **"Website-Komplettpaket"**, siehe Abschnitt "Ausgearbeitete Angebote" unten. Der Pflegedienst-Teil (Sonntag-Pause) bleibt davon unberührt, ist nur noch ein möglicher Referenzfall unter vielen, kein Blocker mehr für das allgemeine Angebot. Live-Demo gebaut, siehe unten. |
| **Google-Unternehmensprofil-Optimierung als Einstiegspaket für lokale Betriebe** (Ersteinrichtung, Fotos, Beschreibung, Bewertungsmanagement) | Dienstleistung | Kein eigenständiges Stufe-1-Projekt (Preis zu niedrig für 1.500-3.000 EUR), aber guter Türöffner vor größeren Aufträgen | Sofort bis Aufwendig — wenige Stunden pro Kunde | Sehr niedrige Einstiegshürde: das Profil selbst ist für den Kunden kostenlos, Agenturen verlangen laut Recherche ab ca. 299 EUR für die Optimierung. Technisch schon ein Werkzeug vorhanden — der bestehende Windsor.ai-Connector unterstützt laut eigener Doku bereits Schreibzugriff auf Google Business Profile (Posts/Reviews/Listing-Änderungen), sobald ein Kundenaccount verbunden ist. Guter Kombi-/Upsell-Baustein zu den beiden Ideen oben. **Update 25.09.2026:** Angebotspaket komplett ausgearbeitet (Leistungsumfang, Preis-Rahmen, Angebotstext), siehe Abschnitt "Ausgearbeitete Angebote" unten. | **Update 25.09.2026:** mit Idee 1 zum Gesamtpaket zusammengelegt (299 EUR), siehe Abschnitt "Idee 1 + 3 zusammengelegt" unten. | mit Idee 1 zum Gesamtpaket zusammengelegt (299 EUR), siehe unten |
| **KI-Automatisierungspakete für Admin-Prozesse kleiner Betriebe** (Rechnungserfassung, Lead-Erfassung/-Routing, Terminerinnerungen via Make.com) | Dienstleistung | Stufe 1, mit Potenzial für ein wiederkehrendes Abo-Modell | Komplex — pro Kunde eigene Prozessanalyse nötig, mehrere Tage bis Wochen | Baut auf Mikes eigenem, bereits geplantem Rechnungs-Automatik-Vorhaben auf (siehe [[Aufgaben-Triage (Sofort, Aufwendig, Komplex)]], "Komplex", Stufe 2/3 im eigenen IB-Business) — dieselbe Technik ließe sich als Dienstleistung verkaufen. Marktpreise laut Recherche ab 1.490 EUR/Monat (Abo) oder ab 2.500 EUR (Einmalprojekt), für den Kunden teils über BAFA/"go-digital" bis zu 50 % förderfähig (Verkaufsargument). Höherer Aufwand pro Kunde als der Chatbot oben, deshalb eher zweiter Schritt nach dem ersten Projekt. | offen |
| **Digitale Lern-/Prüfungsvorbereitungs-Templates für angehende Elektroniker** (PDF-Checklisten, Übungsblätter, kleines Bundle für die Gesellenprüfung) | Produkt | Kein Stufe-1-Ersatz (zu kleinteilig für 1.500-3.000 EUR), aber risikoarmer erster Test für die "Digitale Produkte"-Kategorie | Sofort bis Aufwendig — Content selbst erstellen, kein technisches Setup außer einfacher Verkaufsseite/Marktplatz-Listing | Nutzt zwei echte Vorerfahrungen: Elektromeister-Fachwissen plus frühere Tätigkeit als Dozent für technische/mathematische Fächer (siehe [[Über mich]]). Templates/Checklisten verkaufen sich laut Recherche aktuell gut (Einstiegspreise 9-29 EUR, Bundles bis ca. 197 EUR), spezifisch fürs Elektrohandwerk aber eine Nische ohne direkt gefundene Vergleichsangebote — Chance auf wenig Konkurrenz, aber auch unklare Nachfrage, deshalb eher kleiner Test als große Wette. Passiv nach Ersterstellung. | offen |

## Ausgearbeitete Angebote

### Idee 3: Google-Unternehmensprofil-Optimierung — Angebotspaket (ausgearbeitet 25.09.2026)

Reiner Text-/Preisentwurf, gedeckt durch die Einnahmequellen-Standing-Freigabe. **Kein Kundenkontakt, kein Angebot verschickt, keine konkrete Zielkunden-Recherche** — das folgt erst nach einer bewussten Priorisierungs-Entscheidung, analog zur bereits vorbereiteten Handwerker-Chatbot-Kontaktliste (siehe [[Handwerker-Chatbot Akquise]]).

**Positionierung:** bewusst kein eigenständiges Stufe-1-Projekt, sondern ein günstiger, schnell umsetzbarer Türöffner vor größeren Aufträgen (Website, Chatbot) — passt zum selben Zielgruppen-Vertrauensvorsprung wie beim Chatbot (Mike als gelernter Elektroniker/Elektromeister, kein anonymer Agentur-Pitch), lässt sich aber auch branchenübergreifend an andere lokale Handwerks-/Dienstleistungsbetriebe im eigenen Umfeld anbieten, nicht nur an Elektrobetriebe.

#### Leistungsumfang (Einstiegspaket, einmalig)

- **Kategorie:** Hauptkategorie prüfen und ggf. korrigieren (so spezifisch wie möglich), sinnvolle Zusatzkategorien ergänzen — nur für Leistungen, die der Betrieb tatsächlich anbietet, um das Relevanzsignal nicht zu verwässern.
- **Beschreibung:** Unternehmensbeschreibung neu formuliert bzw. überarbeitet, mit den Suchbegriffen, nach denen echte Kunden lokal suchen (Leistung + Ort), statt reiner Werbefloskeln.
- **Öffnungszeiten:** reguläre Öffnungszeiten und Sonderöffnungszeiten (Feiertage, Betriebsurlaub) vollständig und korrekt gepflegt.
- **Fotos-Bereich:** bestehende Fotos sichten, nach Kategorien sortiert (Team, ausgeführte Arbeiten, Außenansicht/Standort, Logo) neu einordnen bzw. konkret benennen, welche Motive fehlen — Betriebe mit Fotos bekommen laut Recherche deutlich mehr Anfragen als ohne.
- **Rahmen für laufendes Bewertungsmanagement** (kein laufendes Abo, Teil des Einstiegspakets ist nur der Rahmen dafür): eine kurze Vorlage, mit der der Betrieb zufriedene Kunden aktiv um eine Bewertung bittet, plus zwei Antwortvorlagen (positive und negative Bewertung) — der Betrieb führt das danach selbst weiter, keine dauerhafte Betreuung durch Mike in diesem Paket.

Bewusst **kein** Bestandteil des Einstiegspakets: laufende monatliche Pflege/Reporting (das wäre ein separates, späteres Abo-Angebot, kein Teil dieses Türöffner-Pakets) und keine bezahlten Google-Ads-Kampagnen.

#### Preis-Rahmen

Markt-Check (WebSearch, 25.09.2026, zusätzlich zur bereits vorhandenen "ab 299 EUR"-Einschätzung vom 24.09.2026):
- Einmalige Ersteinrichtung/Neugestaltung bei einer Agentur: ca. 545 EUR (diedesigner.net)
- Einmalige Einrichtung bei einem laufenden Paket-Anbieter: 379 EUR (zzgl. eines danach folgenden Monatspakets ab 279 EUR/Monat, lokalbesucher.de) — für Mikes Einstiegspaket nicht relevant, weil ohne laufende Betreuung
- SEO/GEO-Optimierungspaket (Bewertungs-Setup, Leistungsseiten, Kategorien, Beschreibung, Fotos) einmalig: 399 EUR

Mikes Einstiegspaket deckt bewusst weniger ab als diese Vergleichsangebote (keine Leistungsseiten/kein SEO-Unterbau, keine laufende Betreuung), daher bewusst unter dem recherchierten Marktkorridor angesetzt, um als echter Türöffner zu funktionieren: **249 bis 349 EUR, einmalig**, je nach Ausgangszustand des Profils (komplett neu einrichten liegt eher am oberen Ende, ein bestehendes Profil nur optimieren eher am unteren Ende). Realistischer Zeitaufwand pro Kunde: wenige Stunden, keine mehrtägige Arbeit.

#### Angebotstext (kurz, wiederverwendbar)

Stil nach `00 Kontext/Schreibstil.md` (duzen, locker aber professionell, keine Gedankenstriche, keine erfundenen Referenzen/Erfolge) und `00 Kontext/Über mich.md`.

> Hallo [Ansprechpartner / Team von [Firmenname]],
>
> ich bin Mike, gelernter Elektroniker und Elektromeister, baue nebenbei etwas im Digitalen auf und schau mir dafür gerade öfter an, wie kleine Betriebe bei Google auffindbar sind. Bei euch ist mir aufgefallen [konkreter, individueller Punkt einsetzen, z. B. fehlende Fotos / unvollständige Öffnungszeiten / keine aktuelle Beschreibung — vor dem Versenden je Betrieb kurz das echte Profil prüfen, kein Textbaustein raten].
>
> Ich biete gerade ein kleines Einstiegspaket an, mit dem ich euer Google-Unternehmensprofil einmal komplett durchgehe: Kategorie, Beschreibung, Öffnungszeiten, Fotos sauber einsortiert, plus eine einfache Vorlage, mit der ihr künftig leichter an gute Bewertungen kommt. Kein Abo, keine laufenden Kosten, einmalig für [249 bis 349 EUR, je nach Ausgangslage].
>
> Wenn du magst, schau ich mir euer Profil kurz an und sag dir unverbindlich, was sich am meisten lohnen würde. Meld dich gern hier zurück oder ruf mich an unter [Telefonnummer].
>
> Viele Grüße
> Mike Bühler
> [Telefonnummer] · [E-Mail-Adresse]

**Platzhalter-Hinweis:** `[Firmenname]`, `[Ansprechpartner]`, der individuelle Aufhänger-Satz, `[Telefonnummer]`, `[E-Mail-Adresse]` vor Verwendung pro Betrieb ausfüllen — der individuelle Aufhänger-Satz braucht einen echten Blick auf das jeweilige Google-Profil, sonst wirkt der Text austauschbar/nach Massenmail.

**Ausdrücklich nicht Teil dieser Ausarbeitung:** keine Zielkunden-Liste (anders als beim Chatbot noch nicht recherchiert), kein Betrieb kontaktiert, kein Angebot verschickt. Wartet auf Mikes Priorisierungs-Entscheidung (siehe [[Tagesplan]]), ob und wann diese Idee vor oder nach den anderen vier verfolgt wird.

### Idee 1 + 3 zusammengelegt: Gesamtpaket Google-Profil + Chatbot (25.09.2026, Mikes Entscheidung im Chat)

Mike hat entschieden, Idee 1 (Handwerker-Chatbot) und Idee 3 (Google-Profil-Optimierung) nicht mehr getrennt anzubieten, sondern als **ein gemeinsames Einstiegspaket**: "Das alles müssen wir als gesamt Leistung anbieten." Auslöser: die live erreichbare Chatbot-Demo (siehe [[Handwerker-Chatbot Akquise]], Abschnitt "Live-Demo-Seite") war fertig und überzeugend genug, dass beide Bausteine inhaltlich zusammenpassen statt gestaffelt als Türöffner + Folgeangebot zu laufen.

**Pitch-Logik:** Sichtbarkeit UND Erreichbarkeit in einem Aufwasch — mehr Leute finden den Betrieb bei Google (Baustein 1), und keine Anfrage geht mehr verloren, wenn der Kunde gerade auf der Baustelle ist (Baustein 2). Beide Bausteine nutzen denselben Vertrauensvorsprung (Mike als gelernter Elektroniker/Elektromeister) und dieselbe Zielgruppe (kleine Handwerksbetriebe, primär Elektro).

**Leistungsumfang (unverändert aus den Einzelausarbeitungen oben, nur gebündelt):**
- Google-Unternehmensprofil komplett durchgehen (Kategorie, Beschreibung, Fotos) + System für echte Kundenbewertungen (Vorlage + zwei Antwortvorlagen)
- KI-Chatbot für die eigene Website: beantwortet Kundenfragen ehrlich, nimmt Terminwünsche auf, meldet sich per Telegram beim Team — Live-Demo unter https://handwerker-chatbot.higgsfield.app

**Preis: 299 EUR, einmalig, kein Abo.** Bewusst niedriger als die Summe der beiden Einzelpreise (GMB allein 249-349 EUR, Chatbot hatte noch keinen eigenen Preis) — Mikes ausdrückliche Begründung: "wir brauchen erstmal Kundenstamm und ein System das sich wirklich verkaufen lässt nachweislich, deswegen reichen erstmal 299 Euro." Bewusste Unterpreisung zum Markteintritt, kein langfristig gedachter Preis — spätere Preiserhöhung nach den ersten echten Kunden ist damit nicht ausgeschlossen, nur noch nicht entschieden.

**Übergang von der laufenden GMB-Einzelkampagne:** die bereits verschickten 11 GMB-only-Mails (siehe [[GMB-Angebot Akquise]]) bleiben unverändert stehen, kein Nachfass. Antwortet einer der 11 Betriebe, wird das Gesamtpaket im Gespräch als Erweiterung angeboten statt als separates Folgeangebot. Jede neue Ansprache ab jetzt (die restlichen 19 vorbereiteten Kontakte aus Runde 2, sowie neue) pitcht direkt das Gesamtpaket, nicht mehr GMB allein.

#### Angebotstext (kurz, wiederverwendbar)

Stil nach `00 Kontext/Schreibstil.md` (duzen, locker aber professionell, keine Gedankenstriche, keine erfundenen Referenzen/Erfolge).

> Hallo Team von [Firmenname],
>
> ich bin Mike, gelernter Elektroniker und Elektromeister, baue nebenbei etwas im Digitalen auf. Ich biete aktuell ein kleines Einstiegspaket für Handwerksbetriebe an, das an zwei Stellen ansetzt: dass mehr Leute euch bei Google finden, und dass keine Anfrage mehr verloren geht, wenn ihr gerade auf der Baustelle seid.
>
> Konkret enthalten: ich geh euer Google-Unternehmensprofil komplett durch (Kategorie, Beschreibung, Fotos) und richte ein System ein, mit dem ihr systematisch echte Kundenbewertungen sammelt. Dazu bekommt ihr einen KI-Chatbot für eure Website, der Kundenfragen beantwortet und Terminwünsche direkt an euer Handy weiterleitet. Kannst du dir hier live anschauen: https://handwerker-chatbot.higgsfield.app
>
> Beides zusammen, einmalig für 299 EUR, kein Abo.
>
> Magst du dir das unverbindlich anschauen? Meld dich gern zurück oder ruf mich an unter 0152 04553210.
>
> Viele Grüße
> Mike Bühler
> 0152 04553210 · buehlermike46@gmail.com

#### Telefon-Leitfaden (kurz)

> Hallo, mein Name ist Mike Bühler, ich bin selbst gelernter Elektroniker und Elektromeister und melde mich als Kollege vom Fach. Ich biete gerade ein kleines Einstiegspaket für Handwerksbetriebe an: ich optimiere euer Google-Profil, damit euch mehr Leute finden, und baue euch einen Chatbot für die Website, der Kundenfragen beantwortet und Terminwünsche direkt an euch weiterleitet, auch wenn ihr gerade auf der Baustelle seid. Den Chatbot kann ich dir sogar live zeigen, per Link. Beides zusammen einmalig 299 Euro, kein Abo. Hättest du kurz Zeit, dass ich dir das zeige?

**Ausdrücklich nicht Teil dieser Ausarbeitung:** keine neue Zielkunden-Recherche (die bestehenden Listen aus [[Handwerker-Chatbot Akquise]] und [[GMB-Angebot Akquise]] gelten weiter), kein Betrieb mit diesem Text kontaktiert, nichts verschickt.

### Idee 2: Website-Komplettpaket — Angebotspaket (ausgearbeitet 25.09.2026, Mikes direkter Auftrag im Chat)

Entstanden aus Mikes Auftrag im Chat vom 25.09.2026: "Lass uns Websites bauen, als Synergie zu meinem Bot und Google-Optimierung möchte ich auch eigene Websites anbieten, lass uns das ganz planen und umsetzen." Löst den Website-Baukasten-Punkt aus dem Ideen-Pool oben vom reinen Pflegedienst-Sonderfall (weiterhin pausiert bis 27.09.2026, siehe [[Pflegedienst]]) und macht daraus ein eigenständiges, allgemeines Angebot.

**Positionierung: das eigentliche Stufe-1-Projekt.** Das bestehende 299-EUR-Einstiegspaket (Idee 1+3, siehe oben) ist bewusst als günstiger Türöffner positioniert und trifft MasterPlan Stufe 1 damit nicht ("Erstes Dienstleistungsprojekt verkauft, Webseite oder Chatbot, 1.500 bis 3.000 EUR", siehe [[MasterPlan - Teilziele und Zeitplan bis 50.000 EUR]] Abschnitt 3). Das Website-Komplettpaket bündelt alle drei Bausteine, eigene Website, der bereits gebaute Chatbot, Google-Profil-Optimierung, zu einem höherpreisigen Angebot, das die Stufe-1-Bedingung tatsächlich erfüllen kann. Zielgruppe unverändert: kleine Handwerks-/Dienstleistungsbetriebe, primär Elektro-Handwerk wegen Mikes Vertrauensvorsprung, zusätzlich jetzt auch Betriebe ganz ohne eigene Website oder mit veralteter Website.

#### Leistungsumfang

- Eigene, mehrseitige Website (Startseite, Leistungen, Vertrauen/Bewertungen, Kontakt), mobil-optimiert, mit dem eigenen Branding des Betriebs, gebaut über Jarvis' `website-builder-flow`-Workflow
- Der bereits bestehende KI-Chatbot (siehe [[Handwerker-Chatbot Akquise]]) direkt in die neue Website integriert, beantwortet Fragen und nimmt Terminanfragen auf
- Google-Unternehmensprofil-Optimierung, identisch zum bereits ausgearbeiteten Baustein aus Idee 3 oben (Kategorie, Beschreibung, Öffnungszeiten, Fotos, Bewertungs-Vorlage)

**Offene technische Frage, bewusst nicht als fertiges Feature verkauft:** ob die ausgelieferte Website auf einer eigenen Domain des Kunden oder auf einer higgsfield.app-Subdomain läuft, ist noch nicht geklärt (möglich wäre eine Custom-Domain-Anbindung über Cloudflare, aber nicht verifiziert). Muss vor dem ersten echten Verkauf geprüft werden, bevor das Angebot dazu etwas verspricht.

#### Live-Beispiel gebaut (25.09.2026)

Die bestehende Chatbot-Demo (https://handwerker-chatbot.higgsfield.app) zu einer vollwertigen Mehrseiten-Website ausgebaut: **Start, Leistungen, Bewertungen, Kontakt.** Zeigt jetzt konkret, wie das fertige Produkt für einen echten Kunden aussehen könnte, statt nur den Chatbot isoliert zu zeigen:
- **Leistungen:** sechs Karten (Elektroinstallation, Photovoltaik, Wallbox-Installation, Smart Home, E-Check, Notdienst), passend zum bereits etablierten Musterbetrieb-Profil
- **Bewertungen:** erklärt den Google-Optimierung-Baustein ehrlich als Platzhalter ("Hier stehen bald echte Kundenstimmen") statt erfundener Sternebewertungen zu zeigen — bewusst keine fingierten Testimonials, gleiche Begründung wie in [[GMB-Angebot Akquise]] (§5-UWG-Risiko bei gefälschten Bewertungen)
- **Kontakt:** Telefon/E-Mail plus der eingebettete Chatbot direkt zum Ausprobieren
- Chatbot bleibt auf der Startseite eingebettet und live funktionsfähig (derselbe Make-Webhook wie zuvor)
- Gleiche Marke/Palette wie zuvor (Kobaltblau auf Bone, editorial, keine Higgsfield-Marke sichtbar), keine neuen Bild-Assets generiert, nur bestehende wiederverwendet
- Alle vier Seiten live verifiziert (HTTP 200)

**Technischer Nebenfund:** Die committete `routeTree.gen.ts` (TanStack Routers generierte Routentabelle) wurde beim ersten Deploy-Versuch nicht automatisch für die drei neuen Seiten aktualisiert (kein `bun`-Toolchain-Zugriff in der Build-Sandbox, um den Generator laufen zu lassen) und verursachte einen Typecheck-Fehler beim CI-Build. Manuell nach dem bestehenden generierten Muster ergänzt, danach baute der Deploy fehlerfrei durch.

#### Preis-Rahmen (Marktrecherche 25.09.2026, WebSearch)

- Freiberufler/Spezialisten: 500 bis 1.739 EUR, teils inklusive Texten und Google-Optimierung
- Spezialisierte Agenturen für Handwerksbetriebe, laut Recherche der "wirtschaftliche Sweet Spot" für ca. 90% aller Handwerksbetriebe: 759 bis 2.500 EUR Festpreis
- Große Agenturen für KMU: 1.500 bis 15.000 EUR
- Laufende Kosten bei klassischen Anbietern zusätzlich: Hosting 5 bis 10 EUR/Monat, Wartungsvertrag ab ca. 30 EUR/Monat

Empfehlung, angelehnt an den unteren bis mittleren Marktkorridor und bewusst innerhalb der MasterPlan-Stufe-1-Zielspanne: **1.490 bis 2.490 EUR, einmalig, je nach Umfang** (Standard-Website mit 4 Seiten am unteren Ende, mehr Individualisierung/Seiten am oberen Ende). Anders als beim 299-EUR-Einstiegspaket bewusst kein einheitlicher Festpreis, weil der Aufwand pro Website stärker variiert als bei der reinen GMB+Chatbot-Kombination. Kein Hosting-Abo für den Kunden nötig, solange die higgsfield.app-Infrastruktur genutzt wird (siehe offene technische Frage oben). Preis ist eine Empfehlung, keine Entscheidung, wartet auf Mikes Priorisierung.

#### Premium-Stufe mit Animation/3D-Optik (ausgearbeitet 26.09.2026, Mikes Auftrag im Chat)

Ausloeser: Mike zeigte zwei Instagram-Reels (ein KI-Website-Tool "Webild"/"Astra"
sowie ein Account, das per Claude Code + einer Prompt-Library aufwendig animierte
Three.js-Websites baut) und wollte diesen Animations-/3D-Stil fuer sein eigenes
Angebot. Nach kurzer Abstimmung im Chat eingeordnet als **Upgrade fuer das
bestehende Website-Komplettpaket** (nicht als neue Baustelle), und bewusst ohne
KI-Video-Rendering umgesetzt (Mikes Entscheidung angesichts des damaligen
Guthabenstands von 48,63 Credits) — stattdessen ein rein code-basierter
Tier-1-Effekt.

**Live-Beispiel gebaut:** zweite, eigenstaendige Demo-Website neben der
bestehenden Standard-Demo (handwerker-chatbot.higgsfield.app bleibt unveraendert),
damit beide Stufen im Kundenpitch nebeneinander gezeigt werden koennen:
**https://handwerker-premium.higgsfield.app** (oeffentlich im Higgsfield-Feed
gelistet, mit Mikes Zustimmung im Chat).

- Gleiches Demo-Firmenprofil (Musterbetrieb Elektrotechnik), aber bewusst
  andere Farbwelt als die Standard-Demo (Kobaltblau/Bone dort vs. Graphit/Chrome
  + gedaemptes Signalrot hier), damit der Unterschied sofort sichtbar ist.
- Tier-1-Effekt: der Hero setzt sich beim Laden aus tausenden Canvas-Partikeln
  zum Elektromeister-Foto zusammen und reagiert leicht auf die Maus. Reines
  2D-Canvas, kein Video, kein zusaetzlicher Credit-Verbrauch ueber die
  Bild-Generierung hinaus.
- Sechs Leistungen (Elektroinstallation, Photovoltaik, Wallbox, Smart Home,
  E-Check, Notdienst) als asymmetrisches Bento-Grid mit eigens generierten
  Icons, eigener Prozess-Ablauf, eigener Standard-vs-Premium-Vergleichsblock
  direkt auf der Seite (dient Mike als eingebautes Upsell-Argument im Pitch).
- Vier bewusst unterschiedliche CTA-Stile (Magnetic-Hover, Underline, Hover-
  Flood-Fill, Framed-Pill) statt einem Wiederholungs-Button, plus
  Scroll-Reveal per IntersectionObserver (dependency-frei gehalten, siehe
  Log-Eintrag unten zum GSAP-Fehlversuch).
- Eigenes Favicon-/Icon-Set als handgebautes SVG-Monogramm (kein KI-Rendering
  noetig), keine Higgsfield-Marke sichtbar (mechanischer Gate-Check
  durchlaufen: keine Platzhalter, kein Gedankenstrich, kein `h-screen`, kein
  Quanta-Branding in den eigenen Dateien).
- Credit-Verbrauch: rund 9,5 Credits fuer 5 Bildgenerierungen (Hero, Werkstatt,
  Icon-Sheet, 2x Cover-Kandidat) plus einen Hintergrund-Entfernen-Call fuer das
  Cover. Kein Video generiert. Guthaben danach: 39,14 Credits.

**Noch offen, kein nach aussen wirkender Schritt:** ob und wie dieser
Premium-Stil ins Preismodell einfliesst (eigener Aufpreis auf die 1.490-2.490
EUR-Spanne, oder als oberes Ende der bestehenden Spanne), ist noch nicht
entschieden, wartet auf Mikes Einschaetzung nach Ansicht der Demo. Kein Kunde
kontaktiert, kein Angebot verschickt, kein Preis final festgelegt.

#### Cross-Sell-Logik zum bestehenden Einstiegspaket

Kunden, die bereits das 299-EUR-Einstiegspaket (GMB + Chatbot) gekauft haben, bekommen die 299 EUR bei einem späteren Upgrade auf das Website-Komplettpaket angerechnet, echter Türöffner-Mechanismus statt zwei getrennter Verkäufe. Kunden ganz ohne bestehende Website können auch direkt mit dem Komplettpaket starten.

#### Angebotstext (kurz, wiederverwendbar)

Stil nach `00 Kontext/Schreibstil.md` (duzen, locker aber professionell, keine Gedankenstriche, keine erfundenen Referenzen/Erfolge).

> Hallo Team von [Firmenname],
>
> ich bin Mike, gelernter Elektroniker und Elektromeister, baue nebenbei etwas im Digitalen auf. Neben dem Chatbot und der Google-Optimierung baue ich jetzt auch komplette Websites für Handwerksbetriebe, alles aus einer Hand.
>
> Konkret heißt das: eine eigene, mehrseitige Website mit euren Leistungen, der KI-Chatbot direkt eingebaut, und euer Google-Profil optimiert, damit neue Kunden euch überhaupt erst finden. Wie das aussehen kann, zeig ich dir hier live an einem Beispiel: https://handwerker-chatbot.higgsfield.app
>
> Je nach Umfang liegt das bei 1.490 bis 2.490 EUR, einmalig, kein Abo. Wer schon das 299-EUR-Einstiegspaket hat, bekommt das beim Upgrade angerechnet.
>
> Magst du dir das unverbindlich anschauen? Meld dich gern zurück oder ruf mich an unter 0152 04553210.
>
> Viele Grüße
> Mike Bühler
> 0152 04553210 · buehlermike46@gmail.com

**Ausdrücklich nicht Teil dieser Ausarbeitung:** keine neue Zielkunden-Recherche für dieses spezifische Paket (die bestehenden Listen aus [[Handwerker-Chatbot Akquise]]/[[GMB-Angebot Akquise]] gelten weiter), kein Betrieb mit diesem Text kontaktiert, nichts verschickt, kein Preis final entschieden.

## Entschieden / verworfen

*(Ideen, die bewertet und abgeschlossen wurden, mit Begründung – nichts wird stillschweigend gelöscht, siehe Vault-Regel additiv arbeiten)*

## Log

*(jeder Recherche-Lauf mit Datum: was wurde geprüft, was kam neu dazu, was wurde verworfen und warum)*

### 2026-09-26, interaktive Chat-Session (kein Subagent — Premium-Design-Stufe geplant und Demo gebaut)

Direkter Auftrag von Mike im Chat, ausgeloest durch zwei geteilte Instagram-Reels
("guck dir diese 2 videos an, solche websiten möchte ich auch bauen"). Nach
Rueckfrage eingeordnet als Upgrade fuers bestehende Website-Komplettpaket (nicht
als neue Baustelle) und wegen des damaligen Guthabens von 48,63 Credits bewusst
ohne KI-Video-Rendering umgesetzt. Umgesetzt:

1. Jarvis-Workflow `website-builder-flow` gelesen (website-flow.md, design-recipe.md,
   wow-catalog.md, review-rubric.md, app-cover.md) und bewusst vom Standard-Pfad
   abgewichen: `Animation mode: non-animated` mit Tier-1-Technik **C2 Particle
   Dissolve** aus dem wow-catalog statt der Standard-Scroll-Scrub-Video-Variante,
   um Credits zu sparen (Mikes ausdrueckliche Wahl in der Rueckfrage).
2. Neue, eigenstaendige Demo-Website gebaut und live geschaltet:
   **https://handwerker-premium.higgsfield.app** (Jarvis website_id
   `27949520-5fcb-46f7-9bd1-2f3de8c93fa5`), oeffentlich im Higgsfield-Feed gelistet
   (Mikes Zustimmung im Chat). Bestehende Standard-Demo (handwerker-chatbot) blieb
   unangetastet, damit beide Stufen im Pitch nebeneinander stehen. Details zum
   Aufbau siehe neuer Abschnitt "Premium-Stufe mit Animation/3D-Optik" oben.
3. 5 Bildgenerierungen (Hero, Werkstatt-Flatlay, Icon-Sheet, 2x Cover-Kandidat)
   plus 1 Hintergrund-Entfernen-Call fuer den Cover-Cutout, zusammen rund 9,5
   Credits (Guthaben danach 39,14 von 48,63). Kein Video generiert.
4. Technischer Fehlversuch unterwegs: GSAP als Scroll-Animations-Bibliothek zu
   `package.json` hinzugefuegt, aber kein `bun` im Editier-Sandbox verfuegbar, um
   `bun.lock` passend zu aktualisieren — der erste Deploy scheiterte am
   CI-Schritt `bun install --frozen-lockfile` (Lockfile passte nicht mehr zu
   `package.json`). Korrigiert, indem GSAP wieder entfernt und der Scroll-Reveal
   stattdessen dependency-frei per `IntersectionObserver` + CSS-Transitions
   gebaut wurde (transform/blur, nie opacity-0, bleibt damit auch
   screenshot-sicher). Zweiter Deploy erfolgreich.
5. Mechanischen mechanical-gate-Check (review-rubric.md §A) selbst per grep
   durchlaufen: keine Platzhalter, keine Gedankenstriche in eigenem Code, keine
   gesperrte Standard-Palette, Eyebrow-Budget eingehalten (3 von max. 3), kein
   `h-screen` und kein Higgsfield/Quanta-Branding in den selbst geschriebenen
   Dateien (nur in ungenutzten, nicht importierten Scaffold-Altdateien, die
   deshalb nicht mitgebaut werden).

**Ausdruecklich kein nach aussen wirkender Schritt** ausser der oeffentlichen
Demo selbst (wie schon bei der Standard-Demo mit Mikes Zustimmung): kein Kunde
kontaktiert, kein Angebot verschickt, kein Preis fuer die Premium-Stufe final
entschieden.

**Domain-Check:** Einnahmequellen-Explorer-Track, kein Content-/YouTube-Bezug.

Geänderte Dateien:
- `03 Bereiche/Aufgaben-Management/Einnahmequellen-Recherche.md` (dieser
  Log-Eintrag, neuer Abschnitt "Premium-Stufe mit Animation/3D-Optik")
- Externes Jarvis/Higgsfield-Website-Projekt (website_id
  `27949520-5fcb-46f7-9bd1-2f3de8c93fa5`, Subdomain `handwerker-premium`) — kein
  Vault-Code, separat verwaltet.

### 2026-09-25, interaktive Chat-Session (kein Subagent — Website-Komplettpaket geplant und Demo gebaut)

Direkter Auftrag von Mike im Chat: "Lass uns Websites bauen, als Synergie zu meinem Bot und Google-Optimierung möchte ich auch eigene Websites anbieten, lass uns das ganz planen und umsetzen." Umgesetzt:

1. **Marktrecherche** (WebSearch): Preise für professionelle Websites für Handwerksbetriebe/kleine Firmen in Deutschland 2026 geprüft (Freiberufler 500-1.739 EUR, spezialisierte Agenturen 759-2.500 EUR "Sweet Spot" für Handwerksbetriebe, große Agenturen 1.500-15.000 EUR).
2. **Website-Baukasten-Idee (Ideen-Pool oben) vom Pflegedienst-Sonderfall gelöst** und als eigenständiges Angebot ausgearbeitet: neuer Abschnitt "Idee 2: Website-Komplettpaket" oben (Leistungsumfang, Preis-Empfehlung 1.490-2.490 EUR, Cross-Sell-Logik zum bestehenden 299-EUR-Paket, Angebotstext). Positionierung: das eigentliche Stufe-1-Projekt (1.500-3.000 EUR), im Unterschied zum bewusst günstigeren 299-EUR-Einstiegspaket.
3. **Live-Demo tatsächlich gebaut:** die bestehende Chatbot-Demo-Website (https://handwerker-chatbot.higgsfield.app, Jarvis website_id `01f874f1-05bb-46f4-bc50-f470e4154701`) von einer Einzelseite zu einer vollwertigen Mehrseiten-Website ausgebaut (Start, Leistungen, Bewertungen, Kontakt), gleiche Marke/Palette wiederverwendet, Chatbot bleibt eingebettet und live funktionsfähig. Bewertungen-Seite bewusst ohne erfundene Sternebewertungen (Platzhalter-Text statt fingierter Testimonials, gleiche Begründung wie beim §5-UWG-Hinweis in [[GMB-Angebot Akquise]]). Alle vier Seiten nach Deploy live verifiziert (HTTP 200). Ein Build-Fehler (generierte Routentabelle war nach dem Hinzufügen neuer Seiten veraltet) manuell behoben, danach baute der Deploy fehlerfrei durch.

**Ausdrücklich kein nach außen wirkender Schritt:** kein Betrieb kontaktiert, nichts verschickt, kein Preis final entschieden (Empfehlung, wartet auf Mikes Priorisierung). Die Demo-Website ist öffentlich erreichbar (wie schon zuvor beim reinen Chatbot, mit Mikes Zustimmung vom 25.09.2026 zum Higgsfield-Community-Listing), zeigt aber ausschließlich Platzhalter-Inhalte und ist als Projekt-Demo gekennzeichnet, keine reale Firma.

**Domain-Check:** Einnahmequellen-Explorer-Track, kein Content-/YouTube-Bezug.

Geänderte Dateien:
- `03 Bereiche/Aufgaben-Management/Einnahmequellen-Recherche.md` (dieser Log-Eintrag, neuer Abschnitt "Idee 2: Website-Komplettpaket", Ideen-Pool-Status aktualisiert)
- Externes Jarvis/Higgsfield-Website-Projekt (website_id `01f874f1-05bb-46f4-bc50-f470e4154701`) — kein Vault-Code, separat verwaltet, drei neue Seiten plus geteilte Nav-/Footer-Komponenten

### 2026-09-25, aufgaben-executor-Lauf (Scheduled Cloud Routine, `## Bestätigt für 2026-09-25 (Einnahmequellen-Explorer: GMB-Angebotspaket)`)
Auftrag aus [[Tagesplan]] abgearbeitet: Idee 3 (Google-Unternehmensprofil-Optimierung) vom bloßen Ideen-Pool-Eintrag zu einem konkreten Angebotspaket ausgearbeitet, siehe neuer Abschnitt "Ausgearbeitete Angebote" oben. Per WebSearch die bereits vorhandene "ab 299 EUR"-Einschätzung vom 24.09.2026 mit drei zusätzlichen, konkreten Vergleichsangeboten unterlegt (545 EUR Ersteinrichtung, 379 EUR + Monatspaket, 399 EUR SEO/GEO-Paket) und daraus einen eigenen, bewusst darunterliegenden Türöffner-Preis von 249-349 EUR einmalig abgeleitet, weil Mikes Einstiegspaket weniger Leistung enthält als diese Vergleichsangebote (kein SEO-Unterbau, keine laufende Betreuung). Leistungsumfang (Kategorie, Beschreibung, Öffnungszeiten, Fotos-Bereich, Rahmen für Bewertungsmanagement) und ein kurzer, wiederverwendbarer Angebotstext nach `00 Kontext/Schreibstil.md` stehen fertig. Status der Idee 3 in der Ideen-Pool-Tabelle von "offen" auf "Angebotspaket entworfen, wartet auf Priorisierung/Freigabe zur Ansprache" geändert.

**Ausdrücklich kein nach außen wirkender Schritt:** keine Zielkunden recherchiert, kein Betrieb kontaktiert, kein Angebot verschickt — Auftrag hat das auch explizit ausgeschlossen. Deshalb kein neuer Eintrag unter `## Freigabe nötig: Einnahmequellen` in [[Tagesplan]] nötig, die Standing-Freigabe für Recherche/Entwurf deckt diese Runde vollständig ab.

**Domain-Check:** kein Content-/Instagram-/Telegram-Bezug, kein YouTube-Bezug. Gehört ausschließlich zum Einnahmequellen-Explorer-Track.

Geänderte Datei: `03 Bereiche/Aufgaben-Management/Einnahmequellen-Recherche.md` (dieser Log-Eintrag, Ideen-Pool-Status, neuer Abschnitt "Ausgearbeitete Angebote").

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
