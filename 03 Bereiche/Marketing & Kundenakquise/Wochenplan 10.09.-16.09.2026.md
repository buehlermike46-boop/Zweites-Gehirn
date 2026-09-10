---
tags: [bereich, marketing, content, posting]
status: aktiv
date: 2026-09-09
---

# Wochenplan Content: 10.09.–16.09.2026

Einmalige Freigabe für die ganze Woche (neuer Workflow ab 09.09.2026, siehe [[Marketing & Kundenakquise]]). Nach Freigabe postet das System die 5 Beiträge unten automatisch zu den angegebenen Zeiten auf Instagram (`mike_bueh`). Facebook folgt sobald die Konto-Frage geklärt ist.

**Version 4:** Mike hat den Bilder-Ordner selbst neu strukturiert (09.09.2026 nachmittags): `Lim/Content/Bilder/Fertig/` = freigegeben, darf gepostet werden. `Lim/Content/Bilder/Idee/` = Rohmaterial/Input für neuen Content, noch nicht postbar. `Lim/Content/Bilder/` (direkt) = fertiger Content der noch auf Freigabe wartet. Alle 5 Bilder unten liegen jetzt in `Fertig/` und sind bestätigt freigegeben. Zeiten leicht gestreut (18:50–19:15).

## Queue

### 1. Donnerstag, 10.09.2026, 19:00 Uhr
- **Asset:** `Lim/Content/Bilder/Fertig/01-warum-tradest-dueigentlich-noch-alleine.png`
- **Caption:** "Warum tradest du eigentlich noch alleine?\n\nBei mir bekommst du das komplette Trading-Ökosystem, komplett kostenlos: Signalgruppen, Live-Sessions, Academy, Hands-Free Trading.\n\nSchreib mir 'START' für den kostenlosen Zugang."
- **Status:** freigegeben

### 2. Freitag, 11.09.2026, 18:50 Uhr
- **Asset:** `Lim/Content/Bilder/Fertig/49-missverstaendnisseueber-signalgruppen.png`
- **Caption:** "Ein paar Missverständnisse über Signalgruppen, die ich oft höre:\n\n'Signale = garantierter Gewinn' — falsch, Trading bleibt Risiko.\n'Ich muss nichts mehr lernen' — falsch, Academy bleibt wichtig.\n'Mehr Signale = mehr Gewinn' — falsch, Qualität schlägt Menge.\n\nEhrlich statt geschönt, das war schon immer mein Ansatz. Mehr dazu im Kanal: t.me/JointoInnerCircle"
- **Status:** freigegeben

### 3. Sonntag, 13.09.2026, 19:15 Uhr
- **Asset:** `Lim/Content/Bilder/Fertig/42-was-hands-freewirklich-bedeutet.png`
- **Caption:** "Was 'Hands-Free' beim Trading wirklich bedeutet:\n\nKein Bot ohne Aufsicht. Feste Regeln statt Bauchgefühl. Du behältst jederzeit den Überblick.\n\nAutomatisiert heißt nicht unkontrolliert. Mehr im Kanal: t.me/JointoInnerCircle"
- **Status:** freigegeben

### 4. Montag, 14.09.2026, 18:55 Uhr
- **Asset:** `Lim/Content/Bilder/Fertig/45-ich-verspreche-dirkeine-gewinne.png`
- **Caption:** "Ich verspreche dir keine Gewinne.\n\nTrading ist Risiko, das sag ich dir immer ehrlich vorher. Ich zeig dir die Tools, was du daraus machst, entscheidest du.\n\nKeine leeren Versprechen, nur ehrliche Erwartungen. Mehr dazu: t.me/JointoInnerCircle"
- **Status:** freigegeben

### 5. Mittwoch, 16.09.2026, 19:05 Uhr
- **Asset:** `Lim/Content/Bilder/Fertig/44-bildung-zuerstsignale-danach.png`
- **Caption:** "Bildung zuerst. Signale danach.\n\nMein langfristiges Ziel: du verstehst den Markt selbst, statt nur Signale zu kopieren. Signale sind der Einstieg, nicht das Endziel.\n\nMehr im Kanal: t.me/JointoInnerCircle"
- **Status:** freigegeben

## Reserve für später
Alles konsolidiert in einem Ordner: `Lim/Content/Bilder/` (65 Bilder, Nummern 01-65), siehe [[Bilder-Datenspeicher]] für die vollständige Übersicht.
- 01-50: professionelle Bilder, je eigenes Thema/Motiv
- 51-60: Higgsfield-KI-Bilder (Gold/Navy-Stil, Myth-Busting-Winkel)
- 61-65: Canva-Varianten (Limitless-Branding, gleiche Basisvorlage — Achtung: alle mit identischem Hintergrundbild, siehe [[content-bild-muss-zum-thema-passen]])
- ⚠️ Vor Verwendung jedes weiteren bestehenden Bildes kurz prüfen: enthält es schon eine CTA (z.B. "Schreib mir START"), dann Caption darauf abstimmen statt einen zweiten, widersprüchlichen CTA (Telegram-Link) reinzupacken

## Wichtige Erkenntnis: Links in Captions sind nicht klickbar
Instagram-Captions unterstützen keine anklickbaren Links. Für echte Klicks eignet sich zusätzlich eine **Story mit Link-Sticker** am selben Tag (Feed-Post für Reichweite, Story für den Klick). Technisch aufwändiger zu automatisieren (Windsor-API unterstützt keine Link-Sticker) — **nächster Ausbauschritt, nicht Teil dieser ersten Woche.**

## Posting-Methode
Läuft über Browser-Automatisierung (Datei-Upload direkt in Instagram, wie beim ersten Post), NICHT über die Windsor-API — deshalb auch kein Hosting/JPEG-Problem mehr, PNG-Dateien funktionieren direkt.

## Positionierung beachtet (siehe [[00 Kontext/Branding]], Update 09.09.2026)
Captions rücken bewusst Mike als Person in den Vordergrund.

## Automatisierung
Scheduled Task `limitless-weekly-posting` läuft täglich um 18:30 Uhr, prüft diese Datei auf einen für heute freigegebenen Eintrag und postet ihn automatisch (siehe Details in [[Marketing & Kundenakquise]]). Voraussetzung: Status hier auf "freigegeben" setzen.
