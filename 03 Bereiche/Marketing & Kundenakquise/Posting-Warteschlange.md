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

## Tägliche Trade-Story (Limitless-Signalgruppe, seit 24.09.2026)

**Auftrag (Mike per Chat, 24.09.2026):** Mike schickt täglich eine Übersicht der Trades aus der Limitless-Signalgruppe ("Limitless Signals ATM"), daraus entsteht ein täglicher Instagram-**Story**-Post (verschwindet nach 24h). **Freigabe-Phase: automatisch** (Mikes ausdrückliche Entscheidung, analog zu Phase 2 der normalen Queue) — kein Warten auf `freigegeben`.

**Wichtige technische Grenze:** Es gibt keinen Signalgruppen-Connector/keine API. Diese Automatisierung läuft NICHT von selbst über die tägliche Scheduled Cloud Routine — sie ist reaktiv: erst wenn Mike an dem Tag tatsächlich die Trades schickt (im Chat, egal welche Session), entsteht ein Post. Kommt an einem Tag keine Nachricht von Mike, gibt es an dem Tag auch keine Trade-Story, das ist kein Fehler.

**Ablauf, sobald Mike die Trades schickt:**
1. Daten 1:1 übernehmen, nichts erfinden/schönen/aufrunden. Bei Unklarheit (z.B. unleserlicher Screenshot-Ausschnitt) lieber nachfragen als raten.
2. Saubere, gebrandete Story-Grafik über Jarvis erstellen (bestehender Limitless-Look), mit den echten Zahlen — **kein 1:1-Repost des rohen Screenshots** (siehe [[Bilder-Datenspeicher]], Screenshots sind keine Content-Bilder).
3. **Pflicht-Disclaimer** muss auf jeder Trade-Story sichtbar sein (Text im Bild oder in der Caption, mindestens sinngemäß): *"Bildungsinhalt, keine Anlageberatung. Trading ist mit Risiko verbunden, vergangene Ergebnisse sind kein Indikator für zukünftige Ergebnisse, keine Gewinngarantie."*
4. **Korrekte Attribution:** Es sind Trades/Signale aus der Limitless-Signalgruppe (die Trader dort zum Kopieren einstellen, siehe [[Angebot]]), nicht automatisch Mikes eigene persönlich ausgeführten Trades — nie als "meine Trades" formulieren, außer Mike sagt ausdrücklich, dass er sie selbst mitgehandelt hat.
5. **Keine Rosinenpickerei-Illusion:** Es wird gepostet was Mike an dem Tag schickt (i.d.R. der komplette Tagesüberblick der Gruppe inkl. eventueller Verluste, wie im Screenshot-Format "Today We Win .../Loss ..."), nicht nur ausgewählte Gewinner-Trades einzeln herausgepickt.
6. Text-Check wie bei jedem anderen Asset (Pflicht seit 20.09.2026, siehe `content-executor.md`) vor dem Posten.
7. Posten über `mcp__Windsor_ai__execute_action` (`create_story`) auf `mike_bueh`, wie die restliche Queue. Nie bezahlt/geboostet.
8. Queue-Eintrag hier unten anlegen (Datum, Rohdaten, Media-ID) + Zeile im [[Performance-Log]] + Executor-Log-Eintrag wie gewohnt.

### Einträge

#### Mittwoch, 24.09.2026 (Wednesday's Results, von Mike per Chat geschickt)
- **Quelle:** Screenshot "Limitless Signals ATM", Wednesday's Results
- **Rohdaten:** GOLD BUY 270+PIPS (R,T) ✅ · GOLD BUY 120+PIPS ✅ · GOLD BUY 110+PIPS ✅ · GOLD BUY 240+PIPS ✅ · GOLD BUY 200+PIPS ✅ — Today We Win 940+PIPS, Loss -00PIPS, Overall +940 PIPS
- **Status:** an `content-executor` übergeben zur Erstellung + automatischem Posten (siehe Agent-Aufruf)

## Facebook Cross-Posting (Auftrag 14.09.2026, Mike per Chat)

**Auftrag:** "Poste ab sofort alles auch auf Facebook, das du auf Instagram postet, zusammen." Gilt für alle künftigen Posts dieser Warteschlange (Limitless-Account), nicht rückwirkend.

**Technischer Stand, geprüft 14.09.2026 (`mcp__Windsor-ai__get_connectors`/`list_actions`):**
- Der Meta-Ads-Connector "facebook" ist zwar verbunden (Account "Mike Bühler"), deckt aber nur Kampagnen/Anzeigen/Boosting ab — keine organischen Page-Posts. Für die CFD/Forex-Inhalte hier ist bezahlte Werbung ohnehin strikt tabu (Meta-Regel, Account-Risiko), dieser Connector kommt für Cross-Posting also nicht infrage.
- Der richtige Connector wäre "facebook_organic" (organische Page-Posts) — **ist aktuell nicht verbunden**, kein Account hinterlegt. Braucht einen neuen OAuth-Connect, den nur Mike selbst herstellen kann (gleiches Prinzip wie bei jeder neuen Plattform, siehe `aufgaben-executor.md`).
- **Zusätzliche Einschränkung, auch nach dem Connect:** "facebook_organic" unterstützt laut `list_actions` nur `create_photo_post` (einzelnes Bild + Caption) und `create_post` (Text/Link). Keine Aktion für Video/Reel, Carousel oder Story. Echtes 1:1-Cross-Posting ist also nur für Bild-Posts möglich — Reels und Carousels (der Großteil der aktuellen Warteschlange) können nicht in gleicher Form auf Facebook gepostet werden, bestenfalls als vereinfachter Text-Post mit Caption oder als Einzelbild (z. B. Slide 1 eines Carousels).

**Update 14.09.2026 abends:** Mike hat den Connect-Link probiert, das Konto ließ sich bei ihm nicht anbinden (Fehler/Grund noch nicht bekannt, war spät, nicht weiter nachgehakt). Bleibt offen, nächstes Mal genauer schauen woran es hängt (falscher Login, fehlende Berechtigung auf der Facebook-Seite selbst, o.ä.).

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
- **Status:** gepostet (17.09.2026, ca. 16:52 UTC, Nachhol-Lauf — Original-Termin 15.09. verpasst, siehe Executor-Log). Media-ID 18137862454715385
- **Format:** Reel
- **Asset (alt, unerreichbar — Korrektur `content-manager` 13.09.2026):** ~~`Lim/Content/Videos/08-24-bis-zur-pruefung.mp4`~~ liegt lokal bei Mike außerhalb des Git-Vaults, für den `content-executor` nicht erreichbar.
- **Asset (neu, über Jarvis `seedance_2_5` erstellt, gepostet):** faceless Timeline-Animation der drei Schritte "Bewerbung → Prüfung → Freischaltung".
- **Caption:** "Von der Bewerbung bis zur Freischaltung: laut Limitless im Schnitt 24 Stunden. Kein wochenlanges Warten. Schreib mir 'START', ich schick dir den Link."
- **Hashtags:** #trading #limitless #forextrading #tradingtipps

### 4. Mittwoch, 16.09.2026, 19:00 Uhr
- **Status:** gepostet (17.09.2026, ca. 16:51 UTC, Nachhol-Lauf — Original-Termin 16.09. verpasst, siehe Executor-Log). Media-ID 18153905323512731
- **Format:** Reel (faceless, Text-Overlay/Screen-Recording-Stil, kein KI-Avatar als Mike)
- **Thema/Hook:** Copy Trading ehrlich erklärt. Kontrast-Hook: "Copy Trading heißt nicht Knopf drücken und fertig. Was in den Signalgruppen wirklich passiert, in 30 Sekunden."
- **Fakt/Nutzwert (Angebot.md):** Premium-Signalgruppen, in denen professionelle Trader ihre Trades zum Kopieren einstellen, komplett kostenfrei Teil vom Limitless-Ökosystem.
- **Asset:** über Jarvis `seedance_2_5` erstellt und gepostet: Erklär-Reel mit dem Ablauf "Signal kommt rein → Trade wird sichtbar → du entscheidest, ob du mitgehst".
- **Caption:** "Copy Trading heißt nicht: Knopf drücken, Geld kommt von allein. In den Signalgruppen von Limitless stellen erfahrene Trader ihre eigenen Trades zum Nachvollziehen ein, du siehst Einstieg, Stop und Ziel und entscheidest selbst, ob und wie du mitgehst. Kostenfrei, ohne Abo. Mehr dazu und wie du reinkommst, zeig ich dir in meinem Kanal: t.me/JointoInnerCircle. Hinweis: Bildungsinhalt, keine Anlageberatung, Trading ist mit Risiko verbunden."
- **Hashtags:** #copytrading #trading #tradingsignale #limitless #tradingeducation

### 5. Donnerstag, 17.09.2026, 19:15 Uhr
- **Status:** gepostet (17.09.2026, ca. 16:53 UTC, im Rahmen des Nachhol-Laufs vorgezogen — planmäßiger Termin war 19:15 Uhr, siehe Executor-Log). Media-ID 18088200095689277
- **Format:** Carousel (5 Bilder)
- **Thema/Hook:** Myth-Busting "vollautomatisiert = Geld im Schlaf?". Hook: "Vollautomatisiert heißt nicht: kein Risiko. Was Hands-Free Trading wirklich bedeutet."
- **Fakt/Nutzwert (Angebot.md):** vollautomatisierte Trading-Bot-Systeme, laut Anbieter 24/5 von Vollzeit-Tradern verwaltet, Teil des kostenfreien Limitless-Zugangs.
- **Asset:** über Jarvis `nano_banana_2` erstellt und gepostet: 5 Info-Grafik-Slides (Hook, was Hands-Free ist, was es nicht ist, für wen, CTA).
- **Caption:** "Vollautomatisiert heißt nicht automatisch sicher. Die Hands-Free-Bots bei Limitless werden laut Anbieter rund um die Uhr von Vollzeit-Tradern verwaltet, das Risiko liegt aber trotzdem bei dir und deinem Konto. Kein System garantiert Gewinne. Was so ein Bot wirklich macht und für wen sich das eignet, zeig ich dir Schritt für Schritt in meinem Kanal: t.me/JointoInnerCircle. Hinweis: Bildungsinhalt, keine Anlageberatung, keine Gewinngarantie."
- **Hashtags:** #tradingbot #automatisiertestrading #limitless #tradingeducation #finanziellefreiheit

### 6. Freitag, 18.09.2026, 19:30 Uhr
- **Status:** von Mike gelöscht (20.09.2026, ca. 1h nach Veröffentlichung) — Rechtschreibfehler im Video entdeckt. War zuvor gepostet (20.09.2026, ca. 16:45 UTC, zweiter Versuch nach der Ablehnung vom 19.09.). Media-ID 18011708741973337, jetzt ungültig/gelöscht — für den nächsten `content-executor`-Lauf: **nicht mehr über `mcp__Windsor_ai__get_data` abfragen**, die Media-ID existiert nicht mehr.
- **Root Cause & Fix:** siehe [[Qualitätsbericht]], Bericht vom 20.09.2026 — der `content-executor` prüfte den tatsächlich gerenderten Video-Text vor dem Posten nie gegen den Prompt/die Caption, seit 20.09.2026 ist ein Pflicht-Text-Check vor jedem Posten eingebaut (siehe `content-executor.md`). Dieser konkrete Post ist bewusst nicht neu erstellt/erneut gepostet — falls Mike den Market-Scanner-Post trotzdem nochmal will, braucht es einen neuen, sauber geprüften Post, kein automatischer Ersatz.
- **Format:** Reel
- **Thema/Hook:** PrimeVerse Market-Scanner (Syphon AI & Zonar). Hook mit konkreter Zahl: "40+ Währungspaare, ein KI-Scanner. Was ein Market-Scanner-Tool wirklich zeigt."
- **Fakt/Nutzwert (Angebot.md):** KI-Marktscanner für institutionelle Orderflow-Muster über 40+ Währungspaare, Teil von PrimeVerse, kostenfrei über den Limitless-Zugang.
- **Asset (über Jarvis `seedance_2_5` erstellt, bereit zum Posten, noch nicht live):** https://d8j0ntlcm91z4.cloudfront.net/user_3IxIbY4gft5U53G8n41lsTQUh7a/hf_20260919_164841_32315f5c-95e8-4f46-adca-c21bef8ab270.mp4 (erste Generierung des Vortages schlug mit Status `ip_detected` fehl — vermutlich Fehlalarm eines IP-/Marken-Ähnlichkeitsfilters auf den ursprünglichen "Dashboard-UI"-Prompt, zweite Generierung mit angepasstem, abstrakterem Prompt ohne Dashboard-Optik erfolgreich).
- **Caption (überarbeitet 20.09.2026, "laut Anbieter" entfernt — siehe neue Regel unten "Content-Regel: nie 'laut Anbieter'"):** "Ein Market-Scanner beobachtet über 40 Währungspaare gleichzeitig und sucht nach Mustern, für die ein Mensch den ganzen Tag vorm Chart sitzen müsste. Genau das ist eines der Tools, die im PrimeVerse-Teil von Limitless kostenlos mit dabei sind, sobald dein Zugang steht. Ersetzt kein eigenes Marktverständnis, spart dir aber Zeit beim Beobachten. Wie du rankommst, zeig ich dir in meinem Kanal: t.me/JointoInnerCircle. Hinweis: Bildungsinhalt, keine Anlageberatung."
- **Hashtags:** #trading #marketscanner #ki #limitless #primeverse #tradingtools

### 7. Samstag, 19.09.2026, 19:00 Uhr
- **Status:** gepostet (19.09.2026, ca. 16:50 UTC). Media-ID 18486595840110988
- **Format:** Story
- **Thema/Hook:** Story-Umfrage zur Zielgruppen-Klärung, analog zum Q&A-Format aus der Recherche. Frage: "Was ist für dich am Trading-Ökosystem am unklarsten?" mit Antwortoptionen "Signale", "Bots", "Wie ich starte", "Kosten".
- **Fakt/Nutzwert:** direkte Verbindung zu den Themen aus `Angebot.md` (Signalgruppen, Bots, Live-Sessions, kostenfrei), sammelt Feedback statt neue Behauptung aufzustellen.
- **Umsetzung, abweichend vom ursprünglichen Plan:** Windsor.ai unterstützt für `create_story` keinen echten Umfrage-Sticker (nur `image_url`/`video_url`, keine Caption, kein interaktives Element). Frage + vier Antwortoptionen deshalb direkt als Text ins Bild gerendert (über Jarvis `nano_banana_2`) statt als klickbarer Sticker — sammelt damit kein strukturiertes Umfrage-Ergebnis, nur optische Wirkung. Für Mike/`professor` vermerkt.
- **Hashtags:** #trading #limitless

### 8. Sonntag, 20.09.2026, 18:50 Uhr
- **Status:** gepostet (20.09.2026, ca. 16:44 UTC, Auswertung nachgetragen 22.09.2026: 36 Reichweite/41 Views/**1 Save**, erste nicht-null Interaktion überhaupt). Media-ID 17987905185117145
- **Format:** Reel
- **Thema/Hook:** Live-Sessions & Academy, Lernen statt nur Kopieren, Mike als Person in den Vordergrund (siehe Branding-Update 09.09.2026). Geständnis-Hook: "Ich hab am Anfang nur Signale kopiert, ohne zu verstehen warum. Das war mein größter Anfängerfehler."
- **Fakt/Nutzwert (ICP.md/Angebot.md):** Live-Sessions zum eigenständigen Lernen, langfristiges Ziel ist, den Finanzmarkt selbst zu verstehen statt dauerhaft nur zu kopieren.
- **Asset:** kein bestehendes Asset, über Jarvis frisch zu erstellen. Generation-Brief: Reel im Geständnis-/Text-Overlay-Stil (kein KI-Avatar als Mike, siehe Guardrail in `content-executor.md`), reines Text-Overlay-Reel statt Talking-Head.
- **Caption:** "Mike zeigt dir, warum er anfangs nur Signale kopiert hat, ohne zu verstehen, warum die eigentlich funktionieren. Genau deshalb gibt's bei Limitless neben den Signalgruppen auch Live-Sessions und die Academy, kostenfrei mit dabei. Ziel ist nicht, dass du für immer kopierst, sondern dass du den Markt irgendwann selbst einschätzen kannst. Mehr dazu in meinem Kanal: t.me/JointoInnerCircle. Hinweis: Bildungsinhalt, keine Anlageberatung."
- **Hashtags:** #trading #tradingacademy #limitless #tradinglernen #finanziellefreiheit

### 9. Montag, 21.09.2026, 18:50 Uhr
- **Status:** gepostet (21.09.2026, ca. 16:45 UTC). Media-ID 18117162343809287
- **Format:** Carousel (5 Bilder)
- **Thema/Hook:** PrimeVerse Oracle Tracker (Analytics-Dashboard). Hook: "Die meisten wissen nicht, WARUM sie einen Trade verlieren. Ein Analytics-Dashboard schon."
- **Fakt/Nutzwert (Angebot.md):** Oracle Tracker, Analytics-Dashboard im PrimeVerse-Teil von Limitless, erkennt psychologische Fehlermuster automatisch und verfolgt Equity-Kurve und Konsistenz. Kostenfrei Teil des Limitless-Zugangs.
- **Asset:** kein bestehendes Asset, über Jarvis frisch zu erstellen. Generation-Brief: 4-5 Info-Grafik-Slides im bestehenden Limitless-Look. Slide 1 Hook, Slide 2 was der Tracker zeigt (Equity-Kurve, abstrahierte Dashboard-Optik, kein echtes UI kopieren), Slide 3 erkennt Fehlermuster (z.B. nach Verlust größer nachlegen), Slide 4 wieso das hilft (sehen statt raten), Slide 5 CTA.
- **Caption (überarbeitet 20.09.2026, "laut Anbieter" entfernt — siehe neue Regel unten "Content-Regel: nie 'laut Anbieter'"):** "Die meisten Trader schauen nur auf den Kontostand, nicht darauf WARUM ein Trade schiefgeht. Der Oracle Tracker im PrimeVerse-Teil von Limitless verfolgt deine Equity-Kurve und erkennt automatisch psychologische Fehlermuster, zum Beispiel wenn du nach einem Verlust größer nachlegst. Ersetzt keine eigene Reflexion, zeigt dir aber schwarz auf weiß, was du sonst übersiehst. Kostenfrei Teil vom Limitless-Zugang. Mehr dazu in meinem Kanal: t.me/JointoInnerCircle. Hinweis: Bildungsinhalt, keine Anlageberatung."
- **Hashtags:** #trading #tradingpsychologie #primeverse #limitless #tradingtools

### 10. Dienstag, 22.09.2026, 19:20 Uhr
- **Status:** gepostet (22.09.2026, ca. 16:38 UTC, im zweiten Anlauf — erster Versuch scheiterte am Text-Check, siehe Executor-Log). Media-ID 18114374552084019
- **Format:** Reel (faceless, Text-Overlay)
- **Thema/Hook:** Myth-Busting/Trust-Post. Hook: "Kostenlos klingt erstmal nach Haken. Der ehrliche Haken hier." — **Fakt/Nutzwert und Caption 20.09.2026 überarbeitet** (siehe neue Regel unten "Content-Regel: nie 'laut Anbieter'/nie Vergütung erwähnen"): die ursprüngliche Fassung erklärte explizit, dass sich das Ökosystem über die Zusammenarbeit mit dem Broker finanziert — genau das darf laut Mike nie erwähnt werden, klingt schlecht. Hook bleibt (echter Trust-Einwand), Auflösung jetzt ohne Vergütungs-/Finanzierungserklärung.
- **Fakt/Nutzwert (Angebot.md):** Limitless positioniert sich als kostenloses Trading-Ökosystem ohne Abo-Gebühren/versteckte Kosten für den Nutzer.
- **Asset:** kein bestehendes Asset, über Jarvis frisch zu erstellen. Generation-Brief: kurzes Text-Overlay-Reel (kein Gesicht), das den Trust-Einwand "warum ist das kostenlos" direkt adressiert, neutrale Chart-/App-Optik im bestehenden Look.
- **Caption:** "Kostenlos klingt erstmal nach Haken. Der ehrliche Haken hier: es gibt keinen Kurs zu kaufen und keine versteckten Gebühren für Signale, Bots oder Academy. Der eigentliche Haken ist ein anderer: du brauchst trotzdem Zeit und Geduld, kostenlos heißt nicht automatisch schnell. Wie das Ganze aufgebaut ist, zeig ich dir Schritt für Schritt in meinem Kanal: t.me/JointoInnerCircle. Hinweis: Bildungsinhalt, keine Anlageberatung."
- **Hashtags:** #trading #limitless #finanziellebildung #tradingeducation

### 11. Mittwoch, 23.09.2026, 19:00 Uhr
- **Status:** bereit (wartet auf Freigabe) — NICHT gepostet am 23./24.09.2026, Guthaben reichte nicht (Reel braucht laut Preflight 105 Credits, verfügbar waren 66,38/64,88). Siehe Executor-Log.
- **Format:** Reel (faceless, Chart-/Zahlen-Overlay)
- **Thema/Hook:** Risikomanagement-Rechnung. Hook: "Minus 50 % auf dem Konto heißt: du brauchst plus 100 %, um wieder bei null zu sein."
- **Fakt/Nutzwert (Angebot.md/ICP.md):** Allgemeine Risikomanagement-Mathematik, die genau die Zielgruppen-Unsicherheit adressiert ("wissen nicht, was sie sinnvoll mit Geld anfangen sollen"). Solche Grundlagen sind Teil der kostenfreien Limitless Academy, bevor überhaupt ein Trade läuft.
- **Asset:** kein bestehendes Asset, über Jarvis frisch zu erstellen. Generation-Brief: einfaches Zahlen-/Text-Overlay-Reel, das die Rechnung -50%/+100% vs. -20%/+25% visuell gegenüberstellt. Kein Gesicht, keine Kontostände mit konkreten Euro-Beträgen.
- **Caption:** "Minus 50 % auf dem Konto heißt nicht minus 50 % zum Ausgleich, sondern plus 100 %, um wieder bei null zu sein. Minus 20 % dagegen nur plus 25 %. Der Unterschied zwischen zwei Prozentpunkten Risiko pro Trade entscheidet oft darüber, ob ein Konto übersteht oder nicht. Genau solche Grundlagen sind Teil der kostenfreien Limitless Academy, bevor überhaupt ein Trade läuft. Mehr dazu in meinem Kanal: t.me/JointoInnerCircle. Hinweis: Bildungsinhalt, keine Anlageberatung, keine Gewinngarantie."
- **Hashtags:** #risikomanagement #trading #tradingeducation #limitless

### 12. Donnerstag, 24.09.2026, 19:10 Uhr
- **Status:** gepostet (24.09.2026, ca. 16:40 UTC). Media-ID 18090476540473806
- **Format:** Story
- **Thema/Hook:** Follow-up-Umfrage zur Themenwahl, analog zum Format vom 19.09. Frage: "Welches Thema soll ich als Nächstes genauer erklären?" mit Antwortoptionen "Signale", "Bots", "Market Scanner", "Risikomanagement".
- **Fakt/Nutzwert:** direkte Verbindung zu den Themen aus `Angebot.md`, sammelt Feedback statt neue Behauptung aufzustellen.
- **Asset:** kein bestehendes Asset, über Jarvis frisch zu erstellen. Generation-Brief: einfache Story-Grafik mit Platzhalter für Umfrage-Sticker (Frage + vier Antwortoptionen), im bestehenden Look.
- **Caption/Text:** "Welches Thema soll ich als Nächstes genauer erklären? 👇" plus Umfrage-Sticker mit den vier Optionen. Kein CTA zum Konto, optional Link-Sticker "Mehr Infos: t.me/JointoInnerCircle".
- **Hashtags:** #trading #limitless

### 13. Freitag, 25.09.2026, 19:35 Uhr
- **Status:** bereit (wartet auf Freigabe)
- **Format:** Carousel (4 Bilder)
- **Thema/Hook (20.09.2026 überarbeitet — ursprünglich komplett um "laut Anbieter" herum gebaut, siehe neue Regel unten "Content-Regel: nie 'laut Anbieter'"):** Community-Zahlen. Hook: "8.119 aktive Mitglieder in 40+ Ländern, was heißt das für dich als Einsteiger?"
- **Fakt/Nutzwert (Angebot.md):** PrimeVerse zählt aktuell 8.119 aktive Mitglieder in 40+ Ländern (Marketing-Angabe der Website, hier ohne Attributions-Hinweis im Text übernommen, siehe neue Content-Regel — bei Bedarf vor dem Posten nochmal auf Aktualität prüfen).
- **Asset:** kein bestehendes Asset, über Jarvis frisch zu erstellen. Generation-Brief: 4 Info-Grafik-Slides. Slide 1 Hook mit Zahl, Slide 2 was die Zahl für Einsteiger praktisch heißt (Austausch, nicht allein, Live-Coaching), Slide 3 vertieft das, Slide 4 CTA.
- **Caption:** "PrimeVerse zählt aktuell 8.119 aktive Mitglieder in über 40 Ländern. Für dich als Einsteiger heißt das vor allem: du bist nicht allein mit deinen Anfängerfragen, es gibt Austausch, Live-Coaching und Leute, die dieselben Anfängerfehler schon hinter sich haben. Mehr über das ganze Ökosystem in meinem Kanal: t.me/JointoInnerCircle. Hinweis: Bildungsinhalt, keine Anlageberatung."
- **Hashtags:** #trading #tradingcommunity #primeverse #limitless

### 14. Samstag, 26.09.2026, 19:20 Uhr
- **Status:** bereit (wartet auf Freigabe)
- **Format:** Carousel (4 Bilder), erster Post nach der neuen Recherche-Erkenntnis vom 20.09. — bewusst DM-share-optimiert (Tag-a-Friend-Format), siehe [[Recherche - Was funktioniert auf Instagram (Trading-Content)]]
- **Thema/Hook:** Anfängerfehler-Checkliste, explizit teilbar. Hook: "3 Anfängerfehler, die fast jeder am Anfang macht. Tag jemanden, der gerade erst anfängt."
- **Fakt/Nutzwert (ICP.md/Angebot.md):** Klassische Einsteigerfehler (kein Risikomanagement, kein Trading-Journal, nach Verlust größer nachlegen) — direkt verbunden mit dem, was die kostenfreie Limitless Academy vermittelt, bevor überhaupt ein Trade läuft.
- **Asset:** kein bestehendes Asset, über Jarvis frisch zu erstellen. Generation-Brief: 4 Info-Grafik-Slides im bestehenden Limitless-Look. Slide 1 Hook, Slide 2 Fehler 1 (kein Risikomanagement), Slide 3 Fehler 2 (kein Journal) + Fehler 3 (nach Verlust nachlegen), Slide 4 CTA.
- **Caption (mit explizitem Teilen-CTA, neu seit 20.09.):** "3 Anfängerfehler, die fast jeder am Anfang macht: kein Risikomanagement, kein Trading-Journal, nach einem Verlust größer nachlegen statt kleiner. Genau solche Grundlagen sind Teil der kostenfreien Limitless Academy, bevor überhaupt ein Trade läuft. Tag jemanden, der gerade erst mit Trading anfängt, das hier hätte ihm/ihr am Anfang geholfen. Mehr dazu in meinem Kanal: t.me/JointoInnerCircle. Hinweis: Bildungsinhalt, keine Anlageberatung."
- **Hashtags (spezifischer statt Standard-Set, siehe Recherche-Update 20.09.):** #tradingfehler #risikomanagement #tradingjournal #limitless

### 15. Sonntag, 27.09.2026, 18:50 Uhr
- **Format:** Reel (faceless, Text-Overlay)
- **Status:** bereit (wartet auf Freigabe)
- **Thema/Hook:** Signalgruppen im Detail (bisher nur am Rand im Copy-Trading-Post erwähnt, hier eigener Post). Hook: "Was du in einer Signalgruppe wirklich bekommst, in 20 Sekunden."
- **Fakt/Nutzwert (Angebot.md):** Premium-Signalgruppen mit Einstieg, Stop und Ziel pro Trade, kostenfrei Teil des Limitless-Zugangs, Nutzer entscheidet selbst ob und wie er mitgeht (keine automatische Ausführung).
- **Asset:** kein bestehendes Asset, über Jarvis frisch zu erstellen. Generation-Brief: kurzes Text-Overlay-Reel, zeigt eine Signal-Nachricht mit den drei Bestandteilen (Einstieg/Stop/Ziel) als abstrakte, neutrale Chat-Bubble-Grafik, keine echten Zahlen/Beträge.
- **Caption:** "Eine Signalgruppe schickt dir nicht einfach 'kaufen' oder 'verkaufen'. Du bekommst Einstieg, Stop und Ziel für einen Trade, und entscheidest selbst, ob und wie du mitgehst, nichts läuft automatisch. Genau das ist Teil der kostenfreien Signalgruppen im Limitless-Ökosystem. Mehr dazu in meinem Kanal: t.me/JointoInnerCircle. Hinweis: Bildungsinhalt, keine Anlageberatung, Trading ist mit Risiko verbunden."
- **Hashtags:** #tradingsignale #signalgruppe #limitless #tradingeducation

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

### 2026-09-23/24, Credit-Engpass bei Post #11, Story #12 planmäßig live

**23.09.2026:** Post Nr. 11 (Risikomanagement-Reel, planmäßig 19:00 Uhr) fällig. Preflight-Check (`get_cost: true`) ergab 105 Credits für die geplante 15s-Videogenerierung, verfügbares Guthaben aber nur 66,38 Credits. Wie in der Regel vorgesehen: **nichts generiert, nicht gepostet**, kein Upgrade/Kauf ausgelöst. Queue-Status bleibt `bereit`, wird beim nächsten Lauf mit ausreichend Guthaben erneut versucht.

**24.09.2026:** Guthaben weiterhin unverändert bei 64,88 (kein Verbrauch seit gestern, da nichts generiert wurde) — Post 11 bleibt aus Credit-Gründen offen. Post Nr. 12 (Story-Umfrage, planmäßig heute 19:10 Uhr) dagegen fällig und günstig (Bild ca. 1,5 Credits): über `nano_banana_2` erstellt, Text-Check bestanden (alle fünf Textelemente exakt wie vorgesehen), gepostet: **Media-ID 18090476540473806**.

**Telegram in diesem Lauf gestoppt:** Mike hat während dieses Laufs direkt im Chat angewiesen "auf telegram erstmal nichts mehr posten" — Freigabe-Phase in `Inner Circle Kanal-Content.md` entsprechend auf "gestoppt" geändert, siehe dortiges Executor-Log. Post 9 (Journal), der in diesem Lauf eigentlich nachgeholt werden sollte, bleibt offen, das bereits erstellte Bild-Asset ist nicht mehr verlinkt (URL: `https://d8j0ntlcm91z4.cloudfront.net/user_3IxIbY4gft5U53G8n41lsTQUh7a/hf_20260923_163610_9ccfd76a-143f-455a-8448-e6b46242acca.png`, für den Fall dass später doch noch gepostet wird). Zwei Posting-Versuche für Post 9 wurden zuvor unabhängig vom Sonn-Stopp bereits vom System abgelehnt ("Denied by user", 23. und 24.09.) — nicht abschließend geklärt, ob das mit dem später ausgesprochenen Stopp zusammenhängt.

### 2026-09-21/22, planmäßige Läufe — Oracle-Tracker-Post, Text-Check fängt ersten echten Fehler ab

**21.09.2026, ca. 16:42-16:45 UTC:** Post Nr. 9 (Oracle Tracker, planmäßig 18:50 Uhr) fällig. 5 Carousel-Slides über `nano_banana_2` erstellt, alle 5 einzeln heruntergeladen und Zeichen für Zeichen gegen den Generation-Brief geprüft (erster Lauf unter der neuen Text-Check-Pflicht) — keine Abweichung gefunden, gepostet: **Media-ID 18117162343809287**.

**22.09.2026, ca. 08:30-08:38 UTC (Nachlauf desselben Kontextes) und 16:35 UTC (planmäßiger Trigger):** Rohzahlen für Post Nr. 8 (20.09., Live-Sessions/Academy) nachgetragen: 36 Reichweite/41 Views/**1 Save** — erste nicht-null Interaktion seit Start des Systems, siehe [[Performance-Log]]. Für Post Nr. 6 (Market-Scanner, 18.09./20.09. gepostet) lieferte `mcp__Windsor_ai__get_data` keine Zeile zurück (leeres Ergebnis trotz spezifischem Media-ID-Filter) — nicht weiter untersucht in diesem Lauf, beim nächsten Versuch erneut prüfen, evtl. Indexierungsverzögerung bei Windsor.ai.

Post Nr. 10 (Trust-Post "kostenlos klingt nach Haken", planmäßig 19:20 Uhr) fällig. Video über `seedance_2_5` erstellt, Text-Check (Pflicht seit 20.09.) durchgeführt: **Erster Versuch gescheitert.** Da `show_generation_by_ids` bei Video nur die URL zurückgibt, kein Bild zum direkten Ansehen: `av`+`pillow` per `pip install` in der Sandbox nachinstalliert (kein `ffmpeg`/`ffprobe` vorhanden), Video heruntergeladen, 9 Frames über die Laufzeit extrahiert und einzeln angesehen. Ergebnis: alle drei Text-Overlays fehlerhaft gerendert — "HAGEN" statt "HAKEN", "KURZ" statt "KURS", "VERSCHEKTEN GEBÜKEN" statt "VERSTECKTEN GEBÜHREN". **Nicht gepostet**, wie in der Regel vorgesehen. Mike hat denselben Fehler zufällig zeitgleich im Chat gemeldet (Screenshot des exakt gleichen Frames) — konnte ihm bestätigen, dass der Post bereits gestoppt war, bevor er live ging.

Zweiter Versuch mit kürzerem, einfacherem Prompt (weniger komplexe Wörter: "KEIN KURS"/"KEINE GEBÜHR"/"NUR ZEIT" statt der ursprünglichen langen Sätze) generiert, gleiche Frame-Extraktion durchgeführt: alle drei Overlays diesmal korrekt. Gepostet: **Media-ID 18114374552084019**. Zusätzlicher Credit-Verbrauch durch den Fehlversuch (eine verworfene Video-Generierung), aber kein Post mit sichtbarem Rechtschreibfehler live gegangen — genau der Zweck der neuen Regel.

**Für professor/Vault-Pflege vermerkt:** Der Text-Check-Prozess für Video ist umständlicher als für Bilder (kein direkter Frame-Zugriff über die Jarvis-Tools, Workaround über lokale Paketinstallation nötig). Funktioniert, ist aber ein Stück brüchiger als der Bild-Check. Falls Jarvis künftig eine Thumbnail-/Frame-URL im `show_generation_by_ids`-Ergebnis für Videos mitliefert, würde das den Prozess deutlich robuster machen.

**Credit-Warnung für Mike:** Guthaben nach diesem Lauf nur noch 66,38 Credits (`plus`-Plan). Reicht für maximal ein bis zwei weitere Bild-Posts, aber nicht mehr für eine volle Video-Generierung (~97,5 Credits pro Reel, bei Fehlversuchen wie heute entsprechend mehr). Die kommenden Queue-Einträge #11-15 enthalten mehrere Reels — ohne Aufstocken wird der `content-executor` diese demnächst als "übersprungen, Credits nicht ausreichend" loggen müssen statt zu posten.

### 2026-09-20, ca. 16:42-16:46 UTC, planmäßiger täglicher Lauf — beide offenen Posts jetzt live

**Post Nr. 6 (Market-Scanner, aufgehobenes Asset vom 19.09.):** Zweiter Posting-Versuch mit dem bereits am 19.09. erstellten Video und der überarbeiteten (ohne "laut Anbieter") Caption. **Erfolgreich**, keine erneute Ablehnung — die "Denied by user" vom Vortag war offenbar ein einmaliges Ereignis (Ursache weiterhin nicht bekannt, evtl. ein Permission-Prompt, der in dem Moment nicht beantwortet wurde), kein dauerhafter Block. Media-ID 18011708741973337. Keine Credits erneut verbraucht.

**Post Nr. 8 (Live-Sessions & Academy, planmäßig heute 18:50 Uhr):** Reel über `seedance_2_5` neu erstellt (Geständnis-Hook, Text-Overlay statt Talking-Head) und gepostet. Media-ID 17987905185117145.

Guthaben-Stand: 393,88 Credits vor diesem Lauf (nach den Content-Regel-Korrekturen und der gestrigen Fehlgenerierung), nach der einen Video-Generierung für Post 8 entsprechend weniger.

Nächster fälliger Eintrag: Nr. 9 (Montag 21.09., Oracle Tracker Carousel), noch `bereit (wartet auf Freigabe)`, morgen relevant.

### 2026-09-18/19, Lauf über zwei Kalendertage — ein abgelehnter Posting-Versuch

**Ablauf, damit es nachvollziehbar bleibt:** Der Lauf begann als Reaktion auf die 18.09.-Benachrichtigung (Queue-Eintrag #6, Reel Market-Scanner, fällig 19:30 Uhr, bereits `freigegeben`). Die Session wurde mitten in der Bearbeitung unterbunden (Kontext-Kompression/Idle), bevor committet wurde — dadurch ging keine Arbeit verloren, aber der Lauf zog sich faktisch bis zum 19.09.-Trigger hin, wo er fortgesetzt wurde. Diese Notiz deckt beide Tage ab.

**Post Nr. 6 (Market-Scanner-Reel):** Erste Jarvis-Generierung (`seedance_2_5`, Dashboard-artiger Prompt) schlug fehl mit Status `ip_detected` — vermutlich ein Fehlalarm eines IP-/Marken-Ähnlichkeitsfilters, ausgelöst durch die Beschreibung einer generischen "Dashboard-UI". Zweite Generierung mit abstrakterem, UI-freiem Prompt (Radar-Sweep-Metapher statt Dashboard) erfolgreich. **Beim anschließenden Post-Versuch über `mcp__Windsor_ai__execute_action` (`create_video_post`) wurde der Tool-Call vom System mit "Denied by user" abgelehnt.** Das ist ungewöhnlich für einen unbeaufsichtigten Routine-Lauf — laut Systemregel wird ein abgelehnter Tool-Call nicht identisch wiederholt. **Post Nr. 6 ist daher weiterhin NICHT live**, Status bleibt `freigegeben`, das fertige Video-Asset ist im Queue-Eintrag hinterlegt, damit bei einem künftigen Versuch (nächster Lauf oder durch Mike/eine andere Session) nicht neu generiert werden muss. Für Mike wichtig zu wissen: falls das eine bewusste Ablehnung war (z.B. weil der Reel-Inhalt nochmal geprüft werden sollte), bitte kurz Bescheid geben, sonst versucht der nächste reguläre Lauf es automatisch erneut.

**Post Nr. 7 (Story-Umfrage, planmäßig 19.09.):** Erfolgreich gepostet, Media-ID 18486595840110988. Dabei eine technische Grenze entdeckt: `create_story` bei Windsor.ai/Instagram unterstützt keinen echten interaktiven Umfrage-Sticker, nur ein statisches Bild. Frage + vier Antwortoptionen deshalb direkt ins Bild gerendert statt als klickbares Element — sammelt kein strukturiertes Feedback wie ursprünglich in der Queue geplant, nur die optische Wirkung. An `professor` zur Kenntnis: falls Mike echte Story-Umfragen will, bräuchte es entweder eine andere Windsor-Aktion (aktuell laut `list_actions` nicht vorhanden) oder manuelles Posten durch Mike selbst für Story-Umfragen.

Performance-Zahlen für die drei 17.09.-Posts (#3, #4, #5, jetzt ~48h alt) nachgetragen, siehe [[Performance-Log]] — auffällig niedrigere Reichweite als bei früheren Posts, möglicherweise durch die Häufung von drei Posts in 15 Minuten am 17.09., aber nicht belastbar bei dieser Datenmenge.

Guthaben-Stand: 707,5 Credits vor diesem Lauf, 500,5 nach der fehlgeschlagenen+erfolgreichen Video-Generierung für Post 6 (zwei Video-Generierungen verbraucht, eine davon durch den `ip_detected`-Fehlschlag "verloren", ohne dass ein Post daraus wurde — an Mike/`professor` als Credit-Verlust durch den Filter-Fehlalarm vermerkt, kein Fehlverhalten dieser Session).

### 2026-09-17, 16:39-16:53 UTC, Nachhol-Lauf nach dreitägiger Lücke

**Ausgangslage:** Zwei Scheduled-Trigger-Benachrichtigungen lagen bei Session-Start an (gefeuert 16.09. 16:35 UTC und 17.09. 16:35 UTC), aber offenbar hatte auch schon der 15.09.-Lauf niemanden erreicht — Queue-Einträge #3 (15.09.), #4 (16.09.) und #5 (17.09., heute planmäßig) standen alle noch auf `freigegeben` bzw. unbearbeitet vor. **Ursache nicht abschließend geklärt:** entweder ist der 15.09.-Trigger gar nicht gefeuert, oder die Benachrichtigung ist keiner Session zugestellt/verarbeitet worden. Das ist ein Punkt für `professor`, nicht selbst reparierbar aus diesem Lauf heraus. Erst nach `git fetch origin master && git merge origin/master` (11 Commits von anderen Sessions seit dem letzten Stand dieser Session, u.a. Aufgaben-Management, Kontaktliste, Pflegedienst) war der lokale Stand wieder aktuell.

**Alle drei fälligen Posts nachgeholt statt nur den heutigen:** bewusste Entscheidung, weil alle drei bereits `freigegeben` waren (keine Freigabe-Grenze verletzt) und länger liegen zu lassen die Lücke nur vergrößert hätte. Guthaben vor der Runde: 707,5 Credits, `plus`-Plan.

- **Post Nr. 3** (ursprünglich Di 15.09., 19:45 Uhr): Ersatz-Generation-Brief umgesetzt, 15s faceless Reel "Bewerbung → Prüfung → Freischaltung" über `seedance_2_5`. Gepostet: **Media-ID 18137862454715385**.
- **Post Nr. 4** (ursprünglich Mi 16.09., 19:00 Uhr): Reel "Copy Trading ehrlich erklärt" über `seedance_2_5` erstellt und gepostet: **Media-ID 18153905323512731**.
- **Post Nr. 5** (planmäßig heute, 17.09., 19:15 Uhr, im Lauf vorgezogen): Carousel "Hands-Free Trading Myth-Busting", 5 Slides über `nano_banana_2` erstellt und gepostet: **Media-ID 18088200095689277**.

Alle drei Käptions/Hashtags 1:1 wie in der Queue hinterlegt übernommen, keine inhaltlichen Änderungen. Kein Credit-Problem (Guthaben reichte für alle drei Generierungen deutlich). Post Nr. 2 (14.09. Carousel) währenddessen ausgewertet, siehe [[Performance-Log]] — Rohzahlen erst nach ~3 statt der üblichen 1-2 Tage nachgetragen, gleicher Grund (Lücke).

**Kleiner Vorbehalt zu Slide 5 des heutigen Carousels:** Im Prompt für die letzte Carousel-Folie war ein Tippfehler ("STARTMhr" statt "START" mit separatem "Mehr dazu"), der Post ist bereits live (Media-ID 18088200095689277). Sollte Mike beim Ansehen einen Textfehler auf der letzten Folie bemerken: das ist die Ursache, keine Handlungsnotwendigkeit von hier aus, aber zur Kenntnis.

Alle drei Posts direkt nacheinander in einem ca. 15-minütigen Fenster gepostet statt über den Tag verteilt (anders als die sonst bewusst gestreuten Uhrzeiten) — Kompromiss, um die Backlog-Lücke nicht noch weiter zu verlängern. Für künftige Läufe kein verändertes Verhalten nötig, das war eine einmalige Nachhol-Situation.

### 2026-09-14, 16:36-16:38 UTC, planmäßiger täglicher Lauf — zweiter echter Post live
Post Nr. 2 (heute, 18:50 Uhr) war fällig, Status `freigegeben`. Hinterlegte Assets (4 lokale PNGs bei Mike) wie von `content-manager` am 13.09. vermerkt unerreichbar, daher den hinterlegten Ersatz-Generation-Brief umgesetzt: 4 Carousel-Slides ("Drei Säulen"/"Technologie"/"Bildung"/"Lifestyle") über Jarvis `nano_banana_2` erstellt, 4:5 (Guthaben vor der Generierung: 715,5 Credits, `plus`-Plan). Carousel über `mcp__Windsor_ai__execute_action` (instagram, `create_carousel_post`) gepostet: **Media-ID 17886630126617086**. Nebenbefund: die Windsor-Doku verlangt JPEG, die vier PNGs wurden trotzdem anstandslos akzeptiert — für künftige Läufe keine Konvertierung nötig, aber im Hinterkopf behalten falls doch mal ein Format abgelehnt wird. Ins [[Performance-Log]] eingetragen (frisch, Auswertung folgt). Phase 2 aktiv, keine Einzelfreigabe nötig gewesen (Status war ohnehin schon `freigegeben`). Nichts übersprungen, keine Credit-/Freigabeprobleme.

### 2026-09-20, ca. 20:40 Uhr lokal, kein Executor-Lauf — Mike hat Post Nr. 6 selbst gelöscht (Rechtschreibfehler)

Mike hat sich das Market-Scanner-Reel (Post Nr. 6, Media-ID 18011708741973337, heute ca. 16:45 UTC gepostet) angeschaut, einen Rechtschreibfehler im Video gefunden und den Post ca. 1h nach Veröffentlichung selbst gelöscht (über die Instagram-App, nicht über den `content-executor`). Auslöser für eine sofortige Überarbeitung des gesamten Text-Check-Prozesses, siehe [[Qualitätsbericht]], Bericht vom 20.09.2026: der `content-executor` prüfte bis dahin nie, ob der tatsächlich von Jarvis gerenderte Text im Bild/Video mit dem beabsichtigten Text übereinstimmt. Ein fast identischer Fehler war bereits am 17.09. im Log dieser Datei vermerkt worden ("STARTMhr"-Tippfehler auf einer Carousel-Folie), damals aber als "keine Handlungsnotwendigkeit" ohne Konsequenz belassen. Seit 20.09.2026 ist ein Pflicht-Text-Check vor jedem Posten in `content-executor.md` eingebaut (Details dort). Queue-Eintrag #6 oben entsprechend aktualisiert, kein automatischer Ersatz-Post erstellt.
