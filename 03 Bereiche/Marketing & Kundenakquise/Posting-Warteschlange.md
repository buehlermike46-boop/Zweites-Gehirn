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

**Freigabe-Phase: Freigabe nötig (Phase 1, seit 10.09.2026)**

Operative Liste für die Auto-Posting-Automatisierung (siehe
[[Content-Plan - Woche 07.09.-13.09.2026]] für den Gesamt-Wochenplan inkl. Personal-Account).

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
- **Status:** Asset erstellt, Posten fehlgeschlagen (11.09.2026, 08:32 UTC) — siehe Executor-Log unten
- **Format:** Reel
- **Asset (alt, unerreichbar):** `Lim/Content/Videos/11-ein-oekosystem-vier-werkzeuge-0-kosten.mp4`
- **Asset (neu, über Jarvis erstellt, fertig zum Posten):** https://d8j0ntlcm91z4.cloudfront.net/user_3IxIbY4gft5U53G8n41lsTQUh7a/hf_20260911_083137_cfa0dc68-0cf1-448c-8052-497e223fc589.mp4 (9:16, 15s, ~97,5 Credits)
- **Caption:** "Ein Ökosystem, vier Werkzeuge, 0€ Kosten. Signalgruppen, Academy, Hands-Free Trading, PrimeVerse-Tools, alles kostenlos. Schreib mir 'START', ich zeig dir wie's geht."
- **Hashtags:** #trading #forex #tradingeducation #limitless #finanziellefreiheit

### 2. Montag, 14.09.2026, 18:50 Uhr
- **Status:** freigegeben (11.09.2026, Mike per Chat)
- **Format:** Carousel (4 Bilder)
- **Assets:** `Lim/Content/Bilder/26-drei-saeulenein-oekosystem.png`, `27-mehr-als-tradingtraverse.png`, `28-nicht-nur-chartsauch-du-selbst.png`, `30-warum-limitlessund-primeversezusammenarb.png`
- **Caption:** "PrimeVerse ist mehr als Trading-Tools. Drei Säulen: Technologie, Bildung, Lifestyle, inklusive Reise-Vorteilen und einem Ansatz, der auch Mindset und Fitness einschließt. Alles Teil des kostenlosen Limitless-Zugangs. Schreib mir 'START' für mehr Infos."
- **Hashtags:** #trading #primeverse #limitless #tradingcommunity

### 3. Dienstag, 15.09.2026, 19:45 Uhr
- **Status:** freigegeben (11.09.2026, Mike per Chat)
- **Format:** Reel
- **Asset:** `Lim/Content/Videos/08-24-bis-zur-pruefung.mp4`
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

## Wartet auf dich (Personal-Account, nicht Teil der Automatisierung)
- Mi 09.09. 19:30 — Reel "Meine erste Trading-Woche..." — Skript fertig in [[Content-Plan - Woche 07.09.-13.09.2026]]
- Do 10.09. — Story-Umfrage "Was würdest du einen Trading-Coach fragen?"
- Sa 12.09. 19:30 — Post "Tag X – von Gehalt zu finanzieller Freiheit" — braucht echte Zahlen
- So 13.09. 19:30 — Reel "Ich bin Elektromeister..." — Skript fertig

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
