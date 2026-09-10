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
- **Status:** bereit (wartet auf Freigabe)
- **Format:** Reel
- **Asset:** `Lim/Content/Videos/11-ein-oekosystem-vier-werkzeuge-0-kosten.mp4`
- **Caption:** "Ein Ökosystem, vier Werkzeuge, 0€ Kosten. Signalgruppen, Academy, Hands-Free Trading, PrimeVerse-Tools, alles kostenlos. Schreib mir 'START', ich zeig dir wie's geht."
- **Hashtags:** #trading #forex #tradingeducation #limitless #finanziellefreiheit

### 2. Montag, 14.09.2026, 18:50 Uhr
- **Status:** bereit (wartet auf Freigabe)
- **Format:** Carousel (4 Bilder)
- **Assets:** `Lim/Content/Bilder/26-drei-saeulenein-oekosystem.png`, `27-mehr-als-tradingtraverse.png`, `28-nicht-nur-chartsauch-du-selbst.png`, `30-warum-limitlessund-primeversezusammenarb.png`
- **Caption:** "PrimeVerse ist mehr als Trading-Tools. Drei Säulen: Technologie, Bildung, Lifestyle, inklusive Reise-Vorteilen und einem Ansatz, der auch Mindset und Fitness einschließt. Alles Teil des kostenlosen Limitless-Zugangs. Schreib mir 'START' für mehr Infos."
- **Hashtags:** #trading #primeverse #limitless #tradingcommunity

### 3. Dienstag, 15.09.2026, 19:45 Uhr
- **Status:** bereit (wartet auf Freigabe)
- **Format:** Reel
- **Asset:** `Lim/Content/Videos/08-24-bis-zur-pruefung.mp4`
- **Caption:** "Von der Bewerbung bis zur Freischaltung: laut Limitless im Schnitt 24 Stunden. Kein wochenlanges Warten. Schreib mir 'START', ich schick dir den Link."
- **Hashtags:** #trading #limitless #forextrading #tradingtipps

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
