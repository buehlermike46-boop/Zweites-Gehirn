---
tags: [bereich, youtube, content, queue]
date: 2026-09-20
status: aktiv
---

# Video-Warteschlange (YouTube Kinder-Kanäle DE & EN)

## Freigabe-Phase

**Aktueller Status: Phase 1, Freigabe nötig.** Neues Content-Format mit echten rechtlichen Fallstricken (COPPA/"Made for Kids", IP-Abgrenzung zu Cocomelon & Co., siehe [[YouTube Kinder-Kanäle (DE & EN)]]) — deshalb wie beim Start von Instagram (nicht wie Telegram) erstmal mit Einzelfreigabe, bis Mike den Stil/die Qualität für gut befunden hat. `youtube-executor` produziert Videos und trägt sie hier mit Status `bereit (wartet auf Freigabe)` ein, veröffentlicht aber nichts ohne `freigegeben`. Umschalten auf "automatisch" ist jederzeit Mikes Entscheidung, analog zu `Posting-Warteschlange.md`.

**Hinweis:** Solange kein YouTube-Upload-Werkzeug existiert (siehe Kanal-Setup-Status unten), ist diese Phase ohnehin nur für die Vorbereitung relevant — es kann noch nichts live gehen, egal welcher Status hier steht.

## Kanal-Setup-Status — in Arbeit

**Fortschritt (20.09.2026):** DE-Kanal **"Fenno & Freunde"** ist angelegt (Google hat den längeren Namen mit Zusatz "– Kinderlieder" beim Erst-Anlegen abgelehnt, "Fenno Test" als Testname ging durch, danach umbenannt zu "Fenno & Freunde" — Name/Handle jetzt für 14 Tage gesperrt, siehe Google-Regel). EN-Kanal **"Fenno & Friends"** noch anzulegen, gleiches Namensmuster ohne Zusatz verwenden. Es gibt noch keinen Upload-Connector. Geprüft: Make.com hat ein natives YouTube-Modul (`Upload a Video`, `Set a Video Thumbnail`, `Update a Video Details`, `Update a Channel Details`, u.a.) — technisch also machbar, aber die Verbindung braucht einen echten Google-Login mit Klick-Freigabe im Browser. Das kann keine Session/kein Agent automatisiert für Mike erledigen (Google verlangt den Login/die Zustimmung von einer echten Person).

**Was Mike noch tun muss:**
1. ~~DE-Kanal "Fenno & Freunde" anlegen~~ erledigt (20.09.2026)
2. EN-Kanal "Fenno & Friends" anlegen (gleicher Weg: youtube.com → Konto-Symbol → "Kanal erstellen", Namen ohne Zusatz verwenden, Alias z.B. `@fennoandfriends`)
3. Branding (Profilbild/Banner, siehe unten) und "Für Kinder"-Kennzeichnung für beide Kanäle in YouTube Studio setzen
4. In Make.com (eu1.make.com, Team "My Team"): irgendein Szenario öffnen (oder ein neues anlegen), ein YouTube-Modul hinzufügen, **"Create a connection"** klicken, den Google-Login durchklicken und alle angefragten Rechte bestätigen (deckt beide Kanäle ab, wenn sie am selben Google-Konto hängen)
5. Kurz Bescheid geben, sobald die Verbindung steht — dann baue ich daraus ein Szenario "YouTube: Video-Upload", analog zum bestehenden Telegram-Szenario (Make-Szenario-ID 7391673), und der `youtube-executor` kann ab dann automatisch hochladen.

**Bis dahin:** `youtube-executor` produziert fertige Videos (Charakter, Song, Animation, Untertitel) über Jarvis und legt sie hier mit fertiger Video-URL ab, Status `fertig, wartet auf Kanal/Upload`. Nichts geht verloren, sobald der Connector steht, müssen die bereits fertigen Videos nicht neu erzeugt werden.

## Charakter-Referenz (nicht neu generieren, wiederverwenden)

**Fenno**, origineller kleiner Fuchs, 3D-stylized/Pixar-artiger Look, von Mike freigegeben am 20.09.2026.
- Charakterbild (Jarvis `soul_cast`, Split-Screen-Sheet): https://d8j0ntlcm91z4.cloudfront.net/user_3IxIbY4gft5U53G8n41lsTQUh7a/hf_20260920_164107_b3e1e5bb-b883-40e1-bec7-463d31e5547b.png
- Für jede neue Generierung (Bild/Video) exakt dieses Aussehen referenzieren/beschreiben, damit der Charakter über alle Videos und beide Sprachversionen konsistent bleibt: kleiner Fuchs, oranges-rotes Fell mit weißem Bauch-/Brustfleck, weiße Schwanzspitze, große amber-braune Augen, himmelblaue Latzhose mit gelbem Sternchen-Patch, senffarbenes Halstuch, barfuß.
- Kanalname/Branding: siehe [[YouTube Kinder-Kanäle]] Bereichs-Übersicht.
- **Profilbild (für beide Kanäle, 20.09.2026 erstellt):** https://d8j0ntlcm91z4.cloudfront.net/user_3IxIbY4gft5U53G8n41lsTQUh7a/hf_20260920_171757_686bc402-7e8b-4afb-a962-27c1a249ffef.png
- **Kanal-Banner (für beide Kanäle, 20.09.2026 erstellt, 1344×576, textfrei):** https://d8j0ntlcm91z4.cloudfront.net/user_3IxIbY4gft5U53G8n41lsTQUh7a/hf_20260920_171800_6927d5b3-3ed3-4706-b5f3-ef7a2b547e79.png

## Queue

### Episode 1: "Kopf, Schulter, Knie und Zeh" / "Head, Shoulders, Knees and Toes"
- **Status:** bereit zur Produktion
- **Typ:** Kids-Song-Video (Jarvis `faceless-video`-Workflow, Typ Kids, Song-Modus)
- **Warum dieses Lied als Erstes:** klassisches, gemeinfreies Bewegungslied, in DE und EN gleichermaßen etabliert (nicht neu übersetzt, sondern die jeweils seit Jahrzehnten gebräuchliche Fassung) — dadurch ist "1:1 identisches Video, nur andere Sprachspur" hier besonders sauber umsetzbar, ohne die "Format klonen, nicht Marke kopieren"-Frage überhaupt zu berühren (kein bestehender Kinder-Kanal hat daran ein Markenrecht). Einfache, robuste Wahl für den allerersten Produktionstest der neuen Pipeline.
- **Zielalter:** 1-4 Jahre
- **Länge:** ca. 2 Minuten (Lied 2x durchlaufen: einmal normal, einmal etwas schneller, wie im Original üblich)
- **Ablauf/Szenen:**
  1. Intro: Fenno winkt fröhlich in die Kamera in einer bunten, einfachen Wiesen-/Wohnzimmer-Szene, kurze Begrüßung ("Hallo, ich bin Fenno! Lass uns singen und tanzen!" / "Hi, I'm Fenno! Let's sing and dance!")
  2. Hauptteil: Fenno führt die Bewegungen des Liedes vor (Kopf, Schultern, Knie, Zehen berühren, dann Augen, Ohren, Mund, Nase in der Zusatzstrophe), Kamera bleibt einfach frontal/mittig, damit Kleinkinder mitmachen können
  3. Wiederholung schneller, wie im Original
  4. Kurzer Abspann: Fenno winkt zum Abschied, freundliche Verabschiedung
- **Charakter:** ausschließlich Fenno (siehe Charakter-Referenz oben), keine weiteren Figuren nötig für den ersten Test
- **Guardrails-Check:** kein Bezug zu bestehenden Kanälen/Charakteren, ruhiges Tempo, keine Flacker-Effekte, keine Werbe-CTAs im Video
- **Nächster Schritt:** `youtube-executor` produziert über den `faceless-video`-Workflow (Typ Kids, Song-Modus) je eine DE- und eine EN-Fassung, trägt Ergebnis hier ein

## Executor-Log
*(Append-only Protokoll jedes `youtube-executor`-Laufs, mit Zeitstempel. Wird beim ersten Lauf angelegt.)*
