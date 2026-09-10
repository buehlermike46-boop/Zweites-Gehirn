---
tags: [bereich, marketing, content, posting]
date: 2026-09-08
status: aktiv
---

# Posting-Warteschlange (Limitless-Account, automatisierbar)

**Update 09.09.2026:** Mike hat sich nochmal ausdrücklich für **volle Automatisierung ohne
Freigabeschritt** entschieden (auch für neu über Higgsfield erstellten Content) — das
Freigabe-Prinzip unten (08.09.2026 beschlossen) ist damit überholt. Bleibt hier dokumentiert
für den Kontext/die Begründung, gilt aber nicht mehr als aktuelle Regel. Siehe
[[Marketing & Kundenakquise]] für den aktuellen Stand.

Operative Liste für die geplante Auto-Posting-Automatisierung (siehe
[[Content-Plan - Woche 07.09.-13.09.2026]] für den Gesamt-Wochenplan inkl. Personal-Account).
~~**Prinzip wie bei Telegram/WhatsApp:** nichts geht automatisch raus, bevor der Status hier
auf `freigegeben` steht. Freigeben = Mike setzt den Status unten selbst um (oder sagt es
Jarvis per Sprache/Telegram, dann trage ich es ein).~~ (überholt, siehe Update oben)

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
Status-Zeile hier von `bereit` auf `freigegeben` ändern (oder Jarvis sagen "Post Nummer X freigeben"), dann postet die Automatisierung (sobald eingerichtet) zur angegebenen Uhrzeit über den bestehenden Windsor.ai-Instagram-Connector. Ohne Freigabe passiert nichts.

## Noch NICHT eingerichtet — Stand 08.09.2026 spät abends

Die eigentliche Zeitsteuerung (täglicher Check um Postingzeit, Freigabe-Anfrage, tatsächliches
Posten) ist technisch noch nicht fertig — das ist eine neue dauerhafte Automatisierung und
brauchte Mikes ausdrückliches Go (gegeben, 08.09.2026), aber die technische Umsetzung ist an
einer konkreten Hürde stehengeblieben:

**Architektur-Fund:** Ein `/schedule`-Cloud-Agent (der Weg, den wir gewählt haben) läuft
isoliert und hat **keinen Zugriff auf den lokalen Vault oder lokale Dateien**. Windsor.ai
steht ihm zwar als Tool zur Verfügung, braucht aber zwingend eine **öffentliche URL** (kein
lokaler Upload) und bei Bildern **JPEG** (unsere Karten sind PNG).

**Lösung im Bau:** separates öffentliches GitHub-Repo nur für fertige Post-Assets:
`https://github.com/buhlermike307-del/limitless-content` — 4 Carousel-Bilder zu JPEG
konvertiert, mit den 2 Videos lokal committet, **aber `git push` hängt seit mehreren
Versuchen fest** (Git Credential Manager wartet nach erfolgreichem Browser-Login auf eine
Terminal-Bestätigung, die nie ankommt — Ursache per `GIT_TRACE` gefunden, siehe Daily Note
[[2026-09-08]]). Auf Mikes Wunsch für heute abgebrochen, morgen Priorität 1.

**Nächste Schritte sobald der Push durchläuft:**
1. Die 6 Datei-URLs (Format `https://raw.githubusercontent.com/buhlermike307-del/limitless-content/main/<dateiname>`) hier oben bei den 3 Posts eintragen (ersetzt die lokalen Pfade)
2. `/schedule`-Routine fertig einrichten — Prompt braucht Caption + URL direkt eingebettet, nicht auf die Vault-Datei verweisen
3. Einmal per "Run now" testen bevor ein wiederkehrender Zeitplan scharf geschaltet wird
4. Danach: restliche 47 Bilder + 8 Videos ebenfalls konvertieren/hochladen (aktuell nur die 6 für die 3 startklaren Posts)
