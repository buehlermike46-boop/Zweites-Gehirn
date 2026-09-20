---
tags: [bereich, youtube, content, queue]
date: 2026-09-20
status: aktiv
---

# Video-Warteschlange (YouTube Kinder-Kanäle DE & EN)

## Freigabe-Phase

**Aktueller Status: Phase 1, Freigabe nötig.** Neues Content-Format mit echten rechtlichen Fallstricken (COPPA/"Made for Kids", IP-Abgrenzung zu Cocomelon & Co., siehe [[YouTube Kinder-Kanäle (DE & EN)]]) — deshalb wie beim Start von Instagram (nicht wie Telegram) erstmal mit Einzelfreigabe, bis Mike den Stil/die Qualität für gut befunden hat. `youtube-executor` produziert Videos und trägt sie hier mit Status `bereit (wartet auf Freigabe)` ein, veröffentlicht aber nichts ohne `freigegeben`. Umschalten auf "automatisch" ist jederzeit Mikes Entscheidung, analog zu `Posting-Warteschlange.md`.

**Hinweis:** Solange kein YouTube-Upload-Werkzeug existiert (siehe Kanal-Setup-Status unten), ist diese Phase ohnehin nur für die Vorbereitung relevant — es kann noch nichts live gehen, egal welcher Status hier steht.

## Kanal-Setup-Status — technisch blockiert, braucht Mike

**Was fehlt (Stand 20.09.2026):** Es gibt weder die beiden YouTube-Kanäle selbst noch einen Upload-Connector. Geprüft: Make.com hat ein natives YouTube-Modul (`Upload a Video`, `Set a Video Thumbnail`, `Update a Video Details`, `Update a Channel Details`, u.a.) — technisch also machbar, aber die Verbindung braucht einen echten Google-Login mit Klick-Freigabe im Browser. Das kann keine Session/kein Agent automatisiert für Mike erledigen (Google verlangt den Login/die Zustimmung von einer echten Person).

**Was Mike konkret tun muss (einmalig, ca. 15-20 Minuten):**
1. Zwei YouTube-Kanäle anlegen (über ein Google-Konto, z. B. auf youtube.com → Konto-Symbol → "Kanal erstellen"): einen für "Fenno & Freunde – Kinderlieder" (DE), einen für "Fenno & Friends – Kids Songs" (EN). Können am selben Google-Konto hängen (Kanalwechsel in YouTube Studio) oder an zwei getrennten Konten.
2. In Make.com (eu1.make.com, Team "My Team"): irgendein Szenario öffnen (oder ein neues anlegen), ein YouTube-Modul hinzufügen, **"Create a connection"** klicken, den Google-Login für Kanal 1 durchklicken und alle angefragten Rechte bestätigen. Gleiches nochmal für Kanal 2 (zweite Connection, falls zwei getrennte Google-Konten).
3. Kurz Bescheid geben, sobald die Verbindung(en) stehen — dann baue ich (oder eine Session mit Make-Zugriff) daraus ein Szenario "YouTube: Video-Upload", analog zum bestehenden Telegram-Szenario (Make-Szenario-ID 7391673), und der `youtube-executor` kann ab dann automatisch hochladen.

**Bis dahin:** `youtube-executor` produziert fertige Videos (Charakter, Song, Animation, Untertitel) über Jarvis und legt sie hier mit fertiger Video-URL ab, Status `fertig, wartet auf Kanal/Upload`. Nichts geht verloren, sobald der Connector steht, müssen die bereits fertigen Videos nicht neu erzeugt werden.

## Charakter-Referenz (nicht neu generieren, wiederverwenden)

**Fenno**, origineller kleiner Fuchs, 3D-stylized/Pixar-artiger Look, von Mike freigegeben am 20.09.2026.
- Charakterbild (Jarvis `soul_cast`, Split-Screen-Sheet): https://d8j0ntlcm91z4.cloudfront.net/user_3IxIbY4gft5U53G8n41lsTQUh7a/hf_20260920_164107_b3e1e5bb-b883-40e1-bec7-463d31e5547b.png
- Für jede neue Generierung (Bild/Video) exakt dieses Aussehen referenzieren/beschreiben, damit der Charakter über alle Videos und beide Sprachversionen konsistent bleibt: kleiner Fuchs, oranges-rotes Fell mit weißem Bauch-/Brustfleck, weiße Schwanzspitze, große amber-braune Augen, himmelblaue Latzhose mit gelbem Sternchen-Patch, senffarbenes Halstuch, barfuß.
- Kanalname/Branding: siehe [[YouTube Kinder-Kanäle]] Bereichs-Übersicht.

## Queue

*(Noch leer — erster Eintrag folgt vom `youtube-manager` in der nächsten Planungsrunde: erstes Lied/Thema auswählen, siehe "Nächste Schritte" in [[YouTube Kinder-Kanäle (DE & EN)]].)*

## Executor-Log
*(Append-only Protokoll jedes `youtube-executor`-Laufs, mit Zeitstempel. Wird beim ersten Lauf angelegt.)*
