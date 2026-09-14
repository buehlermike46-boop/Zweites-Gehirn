---
tags: [bereich, marketing, content, posting]
date: 2026-09-08
status: aktiv
---

# Posting-Warteschlange (Limitless-Account, automatisierbar)

## Freigabe-Phase

**Klarstellung 10.09.2026:** Die beiden Notizen von 08.09. und 09.09. weiter unten haben sich
widersprochen (einmal "nichts ohne Freigabe", einmal "volle Automatisierung"). Beim Aufbau
des `content-manager`/`content-executor`-Agentenpaars mit Mike geklärt: **zweiphasig, aktuell
Phase 1.**

**Aktueller Status: Phase 1, Freigabe nötig.** Jeder Post bekommt vom `content-executor` den
Status `bereit (wartet auf Freigabe)`. Nichts geht live, bevor der Status hier auf
`freigegeben` wechselt (Mike setzt ihn selbst um, oder sagt es Claude, dann wird es
eingetragen).

**Umschalten auf Phase 2 (automatisch, keine Einzelfreigabe mehr):** Sobald Mike den Content-
Stil/die Qualität für gut befunden hat, trägt er hier ein: `Freigabe-Phase: automatisch (seit
[Datum])`. Ab dann postet der `content-executor` neue Posts ohne auf `freigegeben` zu warten,
trackt aber weiterhin jeden Post im [[Performance-Log]]. Zurückschalten auf Phase 1 geht
jederzeit, einfach den Status hier wieder auf "Freigabe nötig" setzen.

**Update 13.09.2026 (Mike per Chat):** Content-Stil/Qualität für gut befunden, Umschalten auf Phase 2 wie oben beschrieben.

**Freigabe-Phase: automatisch (Phase 2, seit 13.09.2026)**

Ab jetzt postet der `content-executor` neue, fällige Posts mit Status `bereit (wartet auf Freigabe)` ohne dass Mike jeden einzeln freigibt, trackt aber weiterhin jeden Post im [[Performance-Log]]. Zurückschalten auf Phase 1 geht jederzeit, siehe oben.

Operative Liste für die Auto-Posting-Automatisierung (siehe
[[Content-Plan - Woche 07.09.-13.09.2026]] für den Gesamt-Wochenplan inkl. Personal-Account).

## Facebook Cross-Posting (Auftrag 14.09.2026, Mike per Chat)

**Auftrag:** "Poste ab sofort alles auch auf Facebook, das du auf Instagram postet, zusammen." Gilt für alle künftigen Posts dieser Warteschlange (Limitless-Account), nicht rückwirkend.

**Technischer Stand, geprüft 14.09.2026 (`mcp__Windsor-ai__get_connectors`/`list_actions`):**
- Der Meta-Ads-Connector "facebook" ist zwar verbunden (Account "Mike Bühler"), deckt aber nur Kampagnen/Anzeigen/Boosting ab — keine organischen Page-Posts. Für die CFD/Forex-Inhalte hier ist bezahlte Werbung ohnehin strikt tabu (Meta-Regel, Account-Risiko), dieser Connector kommt für Cross-Posting also nicht infrage.
- Der richtige Connector wäre "facebook_organic" (organische Page-Posts) — **ist aktuell nicht verbunden**, kein Account hinterlegt. Braucht einen neuen OAuth-Connect, den nur Mike selbst herstellen kann (gleiches Prinzip wie bei jeder neuen Plattform, siehe `aufgaben-executor.md`).
- **Zusätzliche Einschränkung, auch nach dem Connect:** "facebook_organic" unterstützt laut `list_actions` nur `create_photo_post` (einzelnes Bild + Caption) und `create_post` (Text/Link). Keine Aktion für Video/Reel, Carousel oder Story. Echtes 1:1-Cross-Posting ist also nur für Bild-Posts möglich — Reels und Carousels (der Großteil der aktuellen Warteschlange) können nicht in gleicher Form auf Facebook gepostet werden, bestenfalls als vereinfachter Text-Post mit Caption oder als Einzelbild (z. B. Slide 1 eines Carousels).

**Status: technisch blockiert, an Mike.** Sobald die Facebook-Seite über Windsor.ai verbunden ist (neuer OAuth-Connect durch Mike), übernimmt `content-executor` ab dann automatisch: Bild-Posts/Carousels 1:1 (erstes Slide als Foto) auf Facebook mitposten, für Reels einen Text-Post mit Caption + Hinweis "Video im Instagram-Kanal" als Behelfslösung, bis ggf. ein Video-fähiger Connector dazukommt. `professor` bekommt diesen Punkt zur Kenntnis für seine nächste Runde (Connector-Lücke, Plattform neu).

**Uhrzeiten bewusst leicht gestreut (08.09.2026 angepasst):** nicht mehr exakt 19:30 auf die
Minute für jeden Post — wirkt sonst nach Bot und widerspricht der "authentische Journey"-
Positionierung. Stattdessen Fenster 18:45–20:00 Uhr, pro Post leicht verschoben. Die
Grundlogik "abends, nach Feierabend/Trading-Fenster" bleibt (dafür gibt's einen echten
Grund), nur die exakte Minute variiert. Nach ein paar Wochen Tracking-Daten (siehe
Wochenplan) kann das Fenster gezielter eingegrenzt werden, statt es weiter zu raten.

Nur der **Limitless-Account** ist hier gelistet — die Personal-Account-Slots aus dem
Wochenplan (Mi/Do/Sa/So) brauchen Mikes echtes Gesicht/Stimme und sind bewusst NICHT Teil
dieser automatisierten Warteschlange, siehe "Wartet auf dich" unten.

## Queue

### 1. Freitag, 11.09.2026, 19:20 Uhr
- **Status:** gepostet (11.09.2026, nach Freischaltung der Windsor-Write-Actions durch Mike). Media-ID 17901731430581191
- **Format:** Reel
- **Asset (alt, unerreichbar):** `Lim/Content/Videos/11-ein-oekosystem-vier-werkzeuge-0-kosten.mp4`
- **Asset (neu, über Jarvis erstellt, fertig zum Posten):** https://d8j0ntlcm91z4.cloudfront.net/user_3IxIbY4gft5U53G8n41lsTQUh7a/hf_20260911_083137_cfa0dc68-0cf1-448c-8052-497e223fc589.mp4 (9:16, 15s, ~97,5 Credits)
- **Caption:** "Ein Ökosystem, vier Werkzeuge, 0€ Kosten. Signalgruppen, Academy, Hands-Free Trading, PrimeVerse-Tools, alles kostenlos. Schreib mir 'START', ich zeig dir wie's geht."
- **Hashtags:** #trading #forex #tradingeducation #limitless #finanziellefreiheit

### 2. Montag, 14.09.2026, 18:50 Uhr
- **Status:** gepostet (14.09.2026, 16:37 UTC, Phase 2 automatisch). Media-ID 17886630126617086
- **Format:** Carousel (4 Bilder)
- **Assets (alt, unerreichbar):** ~~`Lim/Content/Bilder/26-drei-saeulenein-oekosystem.png`, `27-mehr-als-tradingtraverse.png`, `28-nicht-nur-chartsauch-du-selbst.png`, `30-warum-limitlessund-primeversezusammenarb.png`~~ lokal bei Mike, für Cloud-Executor unerreichbar.
- **Assets (neu, über Jarvis `nano_banana_2` erstellt, gepostet):** 4 Slides "Drei Säulen"/"Technologie"/"Bildung"/"Lifestyle", 4:5, als PNG direkt akzeptiert (kein JPEG-Problem trotz Windsor-Doku).
- **Caption:** "PrimeVerse ist mehr als Trading-Tools. Drei Säulen: Technologie, Bildung, Lifestyle, inklusive Reise-Vorteilen und einem Ansatz, der auch Mindset und Fitness einschließt. Alles Teil des kostenlosen Limitless-Zugangs. Schreib mir 'START' für mehr Infos."
- **Hashtags:** #trading #primeverse #limitless #tradingcommunity

### 3. Dienstag, 15.09.2026, 19:45 Uhr
- **Status:** freigegeben (11.09.2026, Mike per Chat)
- **Format:** Reel
- **Asset (alt, unerreichbar — Korrektur `content-manager` 13.09.2026):** ~~`Lim/Content/Videos/08-24-bis-zur-pruefung.mp4`~~ liegt lokal bei Mike außerhalb des Git-Vaults, für den `content-executor` nicht erreichbar.
- **Ersatz-Generation-Brief (frisch über Jarvis zu erstellen):** 15s faceless Reel, Text-Overlay/Timeline-Optik, zeigt die drei Schritte "Bewerbung → Prüfung (laut Anbieter ca. 24h) → Freischaltung" als einfache Kette/Fortschrittsbalken. Kein Gesicht, keine Kontostände, keine Gewinn-Darstellung.
- **Caption:** "Von der Bewerbung bis zur Freischaltung: laut Limitless im Schnitt 24 Stunden. Kein wochenlanges Warten. Schreib mir 'START', ich schick dir den Link."
- **Hashtags:** #trading #limitless #forextrading #tradingtipps

### 4. Mittwoch, 16.09.2026, 19:00 Uhr
- **Status:** freigegeben (11.09.2026, Mike per Chat)
- **Format:** Reel (faceless, Text-Overlay/Screen-Recording-Stil, kein KI-Avatar als Mike)
- **Thema/Hook:** Copy Trading ehrlich erklärt. Kontrast-Hook: "Copy Trading heißt nicht Knopf drücken und fertig. Was in den Signalgruppen wirklich passiert, in 30 Sekunden."
- **Fakt/Nutzwert (Angebot.md):** Premium-Signalgruppen, in denen professionelle Trader ihre Trades zum Kopieren einstellen, komplett kostenfrei Teil vom Limitless-Ökosystem.
- **Asset:** kein bestehendes Asset, über Jarvis frisch zu erstellen. Generation-Brief: kurzes Erklär-Reel mit Text-Overlays, das den Ablauf "Signal kommt rein → Trade wird sichtbar → du entscheidest, ob du mitgehst" zeigt. Keine Gesichter, keine Gewinn-Screenshots mit konkreten Euro-Beträgen, neutrale Chart-/App-Optik im bestehenden Limitless-Look.
- **Caption:** "Copy Trading heißt nicht: Knopf drücken, Geld kommt von allein. In den Signalgruppen von Limitless stellen erfahrene Trader ihre eigenen Trades zum Nachvollziehen ein, du siehst Einstieg, Stop und Ziel und entscheidest selbst, ob und wie du mitgehst. Kostenfrei, ohne Abo. Mehr dazu und wie du reinkommst, zeig ich dir in meinem Kanal: t.me/JointoInnerCircle. Hinweis: Bildungsinhalt, keine Anlageberatung, Trading ist mit Risiko verbunden."
- **Hashtags:** #copytrading #trading #tradingsignale #limitless #tradingeducation

### 5. Donnerstag, 17.09.2026, 19:15 Uhr
- **Status:** freigegeben (11.09.2026, Mike per Chat)
- **Format:** Carousel (4-5 Bilder)
- **Thema/Hook:** Myth-Busting "vollautomatisiert = Geld im Schlaf?". Hook: "Vollautomatisiert heißt nicht: kein Risiko. Was Hands-Free Trading wirklich bedeutet."
- **Fakt/Nutzwert (Angebot.md):** vollautomatisierte Trading-Bot-Systeme, laut Anbieter 24/5 von Vollzeit-Tradern verwaltet, Teil des kostenfreien Limitless-Zugangs.
- **Asset:** kein bestehendes Asset, über Jarvis frisch zu erstellen. Generation-Brief: 4-5 Info-Grafik-Slides im bestehenden Limitless-Look (wie die Grafik vom 09.09.). Slide 1 Hook/Mythos, Slide 2 was Hands-Free wirklich ist, Slide 3 was es NICHT ist (keine Gewinngarantie, Risiko bleibt beim Nutzer), Slide 4 für wen es Sinn ergibt, Slide 5 CTA zum Kanal.
- **Caption:** "Vollautomatisiert heißt nicht automatisch sicher. Die Hands-Free-Bots bei Limitless werden laut Anbieter rund um die Uhr von Vollzeit-Tradern verwaltet, das Risiko liegt aber trotzdem bei dir und deinem Konto. Kein System garantiert Gewinne. Was so ein Bot wirklich macht und für wen sich das eignet, zeig ich dir Schritt für Schritt in meinem Kanal: t.me/JointoInnerCircle. Hinweis: Bildungsinhalt, keine Anlageberatung, keine Gewinngarantie."
- **Hashtags:** #tradingbot #automatisiertestrading #limitless #tradingeducation #finanziellefreiheit

### 6. Freitag, 18.09.2026, 19:30 Uhr
- **Status:** freigegeben (11.09.2026, Mike per Chat)
- **Format:** Reel
- **Thema/Hook:** PrimeVerse Market-Scanner (Syphon AI & Zonar). Hook mit konkreter Zahl: "40+ Währungspaare, ein KI-Scanner. Was ein Market-Scanner-Tool wirklich zeigt."
- **Fakt/Nutzwert (Angebot.md):** KI-Marktscanner für institutionelle Orderflow-Muster über 40+ Währungspaare, laut Anbieter Teil von PrimeVerse, kostenfrei über den Limitless-Zugang.
- **Asset:** kein bestehendes Asset, über Jarvis frisch zu erstellen. Generation-Brief: Screen-Recording-artiges Reel mit neutral gestalteter, eigener Dashboard-Optik (kein echtes proprietäres UI kopieren), Text-Overlays erklären in 3 Schritten, was ein Market-Scanner macht.
- **Caption:** "Ein Market-Scanner beobachtet laut Anbieter über 40 Währungspaare gleichzeitig und sucht nach Mustern, für die ein Mensch den ganzen Tag vorm Chart sitzen müsste. Genau das ist eines der Tools, die im PrimeVerse-Teil von Limitless kostenlos mit dabei sind, sobald dein Zugang steht. Ersetzt kein eigenes Marktverständnis, spart dir aber Zeit beim Beobachten. Wie du rankommst, zeig ich dir in meinem Kanal: t.me/JointoInnerCircle. Hinweis: Bildungsinhalt, keine Anlageberatung."
- **Hashtags:** #trading #marketscanner #ki #limitless #primeverse #tradingtools

### 7. Samstag, 19.09.2026, 19:00 Uhr
- **Status:** freigegeben (11.09.2026, Mike per Chat)
- **Format:** Story (Umfrage/Interaktion)
- **Thema/Hook:** Story-Umfrage zur Zielgruppen-Klärung, analog zum Q&A-Format aus der Recherche. Frage: "Was ist für dich am Trading-Ökosystem am unklarsten?" mit Antwortoptionen "Signale", "Bots", "Wie ich starte", "Kosten".
- **Fakt/Nutzwert:** direkte Verbindung zu den Themen aus `Angebot.md` (Signalgruppen, Bots, Live-Sessions, kostenfrei), sammelt Feedback statt neue Behauptung aufzustellen.
- **Asset:** kein bestehendes Asset, über Jarvis frisch zu erstellen. Generation-Brief: einfache Story-Grafik mit Platzhalter für Umfrage-Sticker (Frage + vier Antwortoptionen), im bestehenden Look.
- **Caption/Text:** "Bevor's nächste Woche weitergeht: was ist für dich am unklarsten? 👇" plus Umfrage-Sticker mit den vier Optionen. Kein CTA zum Konto, optional Link-Sticker "Mehr Infos: t.me/JointoInnerCircle".
- **Hashtags:** #trading #limitless

### 8. Sonntag, 20.09.2026, 18:50 Uhr
- **Status:** freigegeben (11.09.2026, Mike per Chat)
- **Format:** Reel
- **Thema/Hook:** Live-Sessions & Academy, Lernen statt nur Kopieren, Mike als Person in den Vordergrund (siehe Branding-Update 09.09.2026). Geständnis-Hook: "Ich hab am Anfang nur Signale kopiert, ohne zu verstehen warum. Das war mein größter Anfängerfehler."
- **Fakt/Nutzwert (ICP.md/Angebot.md):** Live-Sessions zum eigenständigen Lernen, langfristiges Ziel ist, den Finanzmarkt selbst zu verstehen statt dauerhaft nur zu kopieren.
- **Asset:** kein bestehendes Asset, über Jarvis frisch zu erstellen. Generation-Brief: Reel im Geständnis-/Text-Overlay-Stil (kein KI-Avatar als Mike, siehe Guardrail in `content-executor.md`), reines Text-Overlay-Reel statt Talking-Head.
- **Caption:** "Mike zeigt dir, warum er anfangs nur Signale kopiert hat, ohne zu verstehen, warum die eigentlich funktionieren. Genau deshalb gibt's bei Limitless neben den Signalgruppen auch Live-Sessions und die Academy, kostenfrei mit dabei. Ziel ist nicht, dass du für immer kopierst, sondern dass du den Markt irgendwann selbst einschätzen kannst. Mehr dazu in meinem Kanal: t.me/JointoInnerCircle. Hinweis: Bildungsinhalt, keine Anlageberatung."
- **Hashtags:** #trading #tradingacademy #limitless #tradinglernen #finanziellefreiheit

### 9. Montag, 21.09.2026, 18:50 Uhr
- **Status:** bereit (wartet auf Freigabe)
- **Format:** Carousel (4-5 Bilder)
- **Thema/Hook:** PrimeVerse Oracle Tracker (Analytics-Dashboard). Hook: "Die meisten wissen nicht, WARUM sie einen Trade verlieren. Ein Analytics-Dashboard schon."
- **Fakt/Nutzwert (Angebot.md):** Oracle Tracker, laut Anbieter Analytics-Dashboard im PrimeVerse-Teil von Limitless, erkennt psychologische Fehlermuster automatisch und verfolgt Equity-Kurve und Konsistenz. Kostenfrei Teil des Limitless-Zugangs.
- **Asset:** kein bestehendes Asset, über Jarvis frisch zu erstellen. Generation-Brief: 4-5 Info-Grafik-Slides im bestehenden Limitless-Look. Slide 1 Hook, Slide 2 was der Tracker zeigt (Equity-Kurve, abstrahierte Dashboard-Optik, kein echtes UI kopieren), Slide 3 erkennt Fehlermuster (z.B. nach Verlust größer nachlegen), Slide 4 wieso das hilft (sehen statt raten), Slide 5 CTA.
- **Caption:** "Die meisten Trader schauen nur auf den Kontostand, nicht darauf WARUM ein Trade schiefgeht. Der Oracle Tracker im PrimeVerse-Teil von Limitless verfolgt laut Anbieter deine Equity-Kurve und erkennt automatisch psychologische Fehlermuster, zum Beispiel wenn du nach einem Verlust größer nachlegst. Ersetzt keine eigene Reflexion, zeigt dir aber schwarz auf weiß, was du sonst übersiehst. Kostenfrei Teil vom Limitless-Zugang. Mehr dazu in meinem Kanal: t.me/JointoInnerCircle. Hinweis: Bildungsinhalt, keine Anlageberatung."
- **Hashtags:** #trading #tradingpsychologie #primeverse #limitless #tradingtools

### 10. Dienstag, 22.09.2026, 19:20 Uhr
- **Status:** bereit (wartet auf Freigabe)
- **Format:** Reel (faceless, Text-Overlay)
- **Thema/Hook:** Myth-Busting/Trust-Post. Hook: "Kostenlos klingt erstmal nach Haken. Der ehrliche Haken hier."
- **Fakt/Nutzwert (Angebot.md):** Limitless positioniert sich laut Anbieter als kostenloses Trading-Ökosystem ohne Abo-Gebühren/versteckte Kosten, finanziert über die Kooperation mit dem Broker statt über ein Produkt an den Nutzer.
- **Asset:** kein bestehendes Asset, über Jarvis frisch zu erstellen. Generation-Brief: kurzes Text-Overlay-Reel (kein Gesicht), das den Trust-Einwand "warum ist das kostenlos" direkt adressiert, neutrale Chart-/App-Optik im bestehenden Look.
- **Caption:** "Kostenlos klingt erstmal nach Haken. Der ehrliche Haken hier: das Ökosystem finanziert sich über die Zusammenarbeit mit dem Broker, nicht über ein Abo von dir. Kein Kurs zu kaufen, keine versteckten Gebühren für Signale, Bots oder Academy. Der eigentliche Haken ist ein anderer: du brauchst trotzdem Zeit und Geduld, kostenlos heißt nicht automatisch schnell. Wie das Ganze aufgebaut ist, zeig ich dir Schritt für Schritt in meinem Kanal: t.me/JointoInnerCircle. Hinweis: Bildungsinhalt, keine Anlageberatung."
- **Hashtags:** #trading #limitless #finanziellebildung #tradingeducation

### 11. Mittwoch, 23.09.2026, 19:00 Uhr
- **Status:** bereit (wartet auf Freigabe)
- **Format:** Reel (faceless, Chart-/Zahlen-Overlay)
- **Thema/Hook:** Risikomanagement-Rechnung. Hook: "Minus 50 % auf dem Konto heißt: du brauchst plus 100 %, um wieder bei null zu sein."
- **Fakt/Nutzwert (Angebot.md/ICP.md):** Allgemeine Risikomanagement-Mathematik, die genau die Zielgruppen-Unsicherheit adressiert ("wissen nicht, was sie sinnvoll mit Geld anfangen sollen"). Solche Grundlagen sind Teil der kostenfreien Limitless Academy, bevor überhaupt ein Trade läuft.
- **Asset:** kein bestehendes Asset, über Jarvis frisch zu erstellen. Generation-Brief: einfaches Zahlen-/Text-Overlay-Reel, das die Rechnung -50%/+100% vs. -20%/+25% visuell gegenüberstellt. Kein Gesicht, keine Kontostände mit konkreten Euro-Beträgen.
- **Caption:** "Minus 50 % auf dem Konto heißt nicht minus 50 % zum Ausgleich, sondern plus 100 %, um wieder bei null zu sein. Minus 20 % dagegen nur plus 25 %. Der Unterschied zwischen zwei Prozentpunkten Risiko pro Trade entscheidet oft darüber, ob ein Konto übersteht oder nicht. Genau solche Grundlagen sind Teil der kostenfreien Limitless Academy, bevor überhaupt ein Trade läuft. Mehr dazu in meinem Kanal: t.me/JointoInnerCircle. Hinweis: Bildungsinhalt, keine Anlageberatung, keine Gewinngarantie."
- **Hashtags:** #risikomanagement #trading #tradingeducation #limitless

### 12. Donnerstag, 24.09.2026, 19:10 Uhr
- **Status:** bereit (wartet auf Freigabe)
- **Format:** Story (Umfrage/Interaktion)
- **Thema/Hook:** Follow-up-Umfrage zur Themenwahl, analog zum Format vom 19.09. Frage: "Welches Thema soll ich als Nächstes genauer erklären?" mit Antwortoptionen "Signale", "Bots", "Market Scanner", "Risikomanagement".
- **Fakt/Nutzwert:** direkte Verbindung zu den Themen aus `Angebot.md`, sammelt Feedback statt neue Behauptung aufzustellen.
- **Asset:** kein bestehendes Asset, über Jarvis frisch zu erstellen. Generation-Brief: einfache Story-Grafik mit Platzhalter für Umfrage-Sticker (Frage + vier Antwortoptionen), im bestehenden Look.
- **Caption/Text:** "Welches Thema soll ich als Nächstes genauer erklären? 👇" plus Umfrage-Sticker mit den vier Optionen. Kein CTA zum Konto, optional Link-Sticker "Mehr Infos: t.me/JointoInnerCircle".
- **Hashtags:** #trading #limitless

### 13. Freitag, 25.09.2026, 19:35 Uhr
- **Status:** bereit (wartet auf Freigabe)
- **Format:** Carousel (4 Bilder)
- **Thema/Hook:** Community-Zahlen "laut Anbieter". Hook: "Laut Anbieter 8.119 aktive Mitglieder in 40+ Ländern, was heißt das für dich als Einsteiger?"
- **Fakt/Nutzwert (Angebot.md):** PrimeVerse laut Website aktuell 8.119 aktive Mitglieder in 40+ Ländern (Marketing-Angabe, nicht unabhängig geprüft, muss als "laut Anbieter" gekennzeichnet sein).
- **Asset:** kein bestehendes Asset, über Jarvis frisch zu erstellen. Generation-Brief: 4 Info-Grafik-Slides. Slide 1 Hook mit Zahl, Slide 2 Einordnung ("laut Anbieter", keine unabhängig geprüfte Zahl), Slide 3 was das für Einsteiger praktisch heißt (Austausch, nicht allein, Live-Coaching), Slide 4 CTA.
- **Caption:** "Laut Anbieter zählt PrimeVerse aktuell 8.119 aktive Mitglieder in über 40 Ländern (Marketingangabe, nicht unabhängig geprüft, aber ein Hinweis auf eine aktive Community). Für dich als Einsteiger heißt das vor allem: du bist nicht allein mit deinen Anfängerfragen, es gibt Austausch, Live-Coaching und Leute, die dieselben Anfängerfehler schon hinter sich haben. Mehr über das ganze Ökosystem in meinem Kanal: t.me/JointoInnerCircle. Hinweis: Bildungsinhalt, keine Anlageberatung."
- **Hashtags:** #trading #tradingcommunity #primeverse #limitless

## Wartet auf dich (Personal-Account, nicht Teil der Automatisierung)
- Mi 09.09. 19:30 — Reel "Meine erste Trading-Woche..." — Skript fertig in [[Content-Plan - Woche 07.09.-13.09.2026]]
- Do 10.09. — Story-Umfrage "Was würdest du einen Trading-Coach fragen?"
- Sa 12.09. 19:30 — Post "Tag X – von Gehalt zu finanzieller Freiheit" — braucht echte Zahlen
- So 13.09. 19:30 — Reel "Ich bin Elektromeister..." — Skript fertig

**Update 13.09.2026 (Mike per Chat):** Sobald Mike echte Fotos von sich zur Verfügung stellt, dürfen `content-manager`/`content-executor` diese für Personal-Account-Content mitverwenden — dann läuft auch dieser Teil über die Automatisierung statt komplett manuell. Bezahlte Werbung bleibt davon unberührt, weiterhin strikt tabu. Sobald Fotos da sind: an einen festen Ort legen (z.B. `07 Anhänge/Mike Fotos/`) und hier bzw. im [[Bilder-Datenspeicher]] eintragen, damit der Executor sie findet.

## Wie freigeben
Solange Phase 1 aktiv ist: Status-Zeile hier von `bereit` auf `freigegeben` ändern (oder Mike sagt es Claude), dann postet der `content-executor` zur angegebenen Uhrzeit über den bestehenden Windsor.ai-Instagram-Connector. Ohne Freigabe passiert nichts.

## Architektur ab 10.09.2026: content-manager/content-executor statt /schedule-Agent

Der alte Ansatz (isolierter `/schedule`-Cloud-Agent ohne Vault-Zugriff, brauchte öffentliche JPEG-URLs, siehe Archiv-Abschnitt unten) ist ersetzt durch ein Agentenpaar nach dem Muster von `aufgaben-manager`/`aufgaben-executor` (siehe [[Jarvis Hand - Agenten Ausbau]] und `CLAUDE.md`):

- **`content-manager`** (wöchentlich): liest Performance-Log, Recherche, Business-Kontext, schreibt neue Posts hier in die Queue
- **`content-executor`** (täglich): erstellt fällige Posts frisch über den Jarvis/Higgsfield-Connector (`generate_image`/`generate_video`), prüft mit `virality_predictor` vor, postet freigegebene Posts über Windsor.ai, aktualisiert [[Performance-Log]]

**Wichtige Konsequenz für die alten 50 Bilder/10 Videos unter `Lim/Content/` auf Mikes Desktop:** Diese liegen außerhalb des Git-Vaults, eine Cloud-Routine kommt technisch nicht dran (gleiches Problem wie beim alten `/schedule`-Agent). Der `content-executor` generiert deshalb neue Assets direkt über Jarvis statt die alten lokalen Dateien zu verwenden. Falls Mike die vorhandenen 50/10 doch einsetzen will: entweder selbst posten, oder ausgewählte Dateien nach `07 Anhänge/` in diesem Repo kopieren, dann sind sie für den Executor erreichbar.

Die drei oben gelisteten Queue-Einträge referenzieren noch die alten lokalen Pfade und sind damit für den `content-executor` nicht postbar — bleiben als Referenz/Ideenquelle stehen, werden aber vom `content-manager` bei der nächsten Planungsrunde durch frisch erstellbare Posts ersetzt oder mit einer neu generierten URL versehen.

## Archiv: alter, verworfener Ansatz (Stand 08.09.2026, nicht mehr verfolgt)

Ein `/schedule`-Cloud-Agent lief isoliert ohne Zugriff auf Vault/lokale Dateien, brauchte öffentliche JPEG-URLs (unsere Karten waren PNG). Lösungsversuch war ein separates öffentliches GitHub-Repo (`buhlermike307-del/limitless-content`) für Post-Assets — der zugehörige Google-Account wurde von Google als Bot geflaggt und gesperrt (siehe [[Marketing & Kundenakquise]], "Offene technische Punkte"), das Repo ist tot. Nicht mehr weiterverfolgen, siehe Architektur oben stattdessen.

## Executor-Log
*(Append-only Protokoll jedes content-executor-Laufs, mit Zeitstempel. Angelegt beim ersten echten Lauf.)*

### 2026-09-11, 08:29-08:33 UTC, erster echter Lauf (von Mike manuell über "Jetzt ausführen" angestoßen)
Phase 1 aktiv. Post Nr. 1 (heute, 19:20 Uhr) war fällig und stand auf `freigegeben`. Der hinterlegte Asset-Pfad (`Lim/Content/Videos/...`) war wie erwartet unerreichbar (lokal bei Mike, nicht im Git-Vault) — daher neues Asset über Jarvis erstellt: 15s, 9:16-Reel, faceless/Info-Grafik-Stil passend zur Caption, 97,5 Credits (Guthaben danach: 720,5 von 818, `plus`-Plan). Video fertig unter der oben hinterlegten URL.

**Posten fehlgeschlagen:** `mcp__Windsor_ai__execute_action` (instagram, `create_video_post`, Account `mike_bueh`) lehnte ab mit: "Write actions are disabled for the Windsor user buehlermike46@gmail.com. The setting is per team member and that user can turn it on under Settings > API Access". Das ist ein eigener Schalter bei Windsor.ai, unabhängig von den Connector-Rechten der Routine — die waren richtig gesetzt, das Konto selbst blockt Schreibzugriffe pauschal. Nichts wurde gepostet, kein Fehlerzustand auf Instagram-Seite. Post-Status oben entsprechend gesetzt, Video-URL für den nächsten Versuch aufgehoben, damit die Credits nicht doppelt ausgegeben werden.

**Für Mike offen:** Unter https://onboard.windsor.ai/app/settings/account → Settings → API Access → "Enable write actions for Claude, ChatGPT & API" aktivieren. Danach reicht ein erneuter `/content-check`-Lauf oder das nächste automatische Zeitfenster, das bereits fertige Video muss nicht neu erstellt werden.

### 2026-09-11, ca. 08:45 UTC, Nachtrag: erster echter Post ist live
Mike hat die Windsor-Write-Actions freigeschaltet. Gleiches Video erneut über `execute_action` gepostet, diesmal erfolgreich: **Media-ID 17901731430581191**, veröffentlicht als Reel auf `mike_bueh`. Keine erneute Jarvis-Generierung nötig, keine zusätzlichen Credits verbraucht. Post-Status oben aktualisiert, [[Performance-Log]] um den neuen Eintrag ergänzt. Das ist der erste vollautomatisch (Asset-Erstellung + Posting) über das neue Agentenpaar veröffentlichte Post.

### 2026-09-11, 16:35 UTC, planmäßiger täglicher Lauf
Nichts fällig. Nächster Queue-Eintrag ist Nr. 2 (Montag, 14.09., 18:50 Uhr), liegt außerhalb des Heute-plus-24h-Fensters. Post Nr. 1 von heute Vormittag (Media-ID 17901731430581191) ist erst ca. 8h alt, für eine Auswertung braucht es laut Vorgabe mindestens 24-48h — noch keine Zahlen nachgetragen. Nichts erstellt, nichts gepostet, keine Freigabe- oder Credit-Probleme.

### 2026-09-12, 16:35 UTC, planmäßiger täglicher Lauf
Nichts fällig zum Posten (nächster Queue-Eintrag weiterhin Nr. 2, Montag 14.09.). Post Nr. 1 (Media-ID 17901731430581191) ist jetzt ~32h alt, Rohzahlen über `mcp__Windsor_ai__get_data` nachgetragen: 19 Reichweite, 41 Views, 0 Likes/Kommentare/Saves/Shares. Ins [[Performance-Log]] eingetragen, keine Bewertung (macht `content-manager` sonntags). Nichts erstellt, nichts gepostet, keine Freigabe- oder Credit-Probleme.

### 2026-09-13, 16:36 UTC, planmäßiger täglicher Lauf
Zur Kenntnis genommen: Freigabe-Phase wurde heute von Mike auf **Phase 2 (automatisch)** umgestellt, siehe Abschnitt oben. Nichts fällig zum Posten in diesem Lauf (Eintrag Nr. 2, Montag 14.09. 18:50 Uhr, liegt mit ca. 26h noch knapp außerhalb des 24h-Fensters, ist bereits `freigegeben` und wird morgen fällig). Post Nr. 1 bereits ausgewertet (12.09.), noch keine neuen Rohzahlen fällig. Nichts erstellt, nichts gepostet, keine Freigabe- oder Credit-Probleme. Content-Manager läuft heute 17:00 UTC turnusmäßig selbst (Sonntag), keine Überschneidung mit diesem Lauf.

### 2026-09-14, 16:36-16:38 UTC, planmäßiger täglicher Lauf — zweiter echter Post live
Post Nr. 2 (heute, 18:50 Uhr) war fällig, Status `freigegeben`. Hinterlegte Assets (4 lokale PNGs bei Mike) wie von `content-manager` am 13.09. vermerkt unerreichbar, daher den hinterlegten Ersatz-Generation-Brief umgesetzt: 4 Carousel-Slides ("Drei Säulen"/"Technologie"/"Bildung"/"Lifestyle") über Jarvis `nano_banana_2` erstellt, 4:5 (Guthaben vor der Generierung: 715,5 Credits, `plus`-Plan). Carousel über `mcp__Windsor_ai__execute_action` (instagram, `create_carousel_post`) gepostet: **Media-ID 17886630126617086**. Nebenbefund: die Windsor-Doku verlangt JPEG, die vier PNGs wurden trotzdem anstandslos akzeptiert — für künftige Läufe keine Konvertierung nötig, aber im Hinterkopf behalten falls doch mal ein Format abgelehnt wird. Ins [[Performance-Log]] eingetragen (frisch, Auswertung folgt). Phase 2 aktiv, keine Einzelfreigabe nötig gewesen (Status war ohnehin schon `freigegeben`). Nichts übersprungen, keine Credit-/Freigabeprobleme.
