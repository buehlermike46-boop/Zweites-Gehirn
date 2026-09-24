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
- **Status:** bereit zur Produktion (Song-Prompts fertig vorbereitet und maschinell validiert, 24.09.2026 — eigentliche Bild-/Video-Generierung noch nicht gestartet, siehe Executor-Log 24.09.2026: Credits reichen nicht für die volle Episode)
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

#### Vorbereitung (24.09.2026, für den nächsten Lauf mit ausreichend Credits)
Damit die bereits investierte Recherche-/Prompt-Arbeit nicht verloren geht, bevor an den eigentlichen Credits-Engpass gestoßen wurde (siehe Executor-Log unten):

- **Stil:** Kids-Katalog-Stil "Studio 3D" (`faceless-video`-Workflow) — passt zum bestehenden Fenno-Look ("3D-stylized/Pixar-artig"), siehe Charakter-Referenz oben. Kein neuer Style-Key nötig, das bestehende Fenno-Charakterbild direkt als `image_references` in jedem Block wiederverwenden (spart Credits, entspricht der Konsistenz-Vorgabe).
- **Locations (neu zu generieren, je 1× `seedream_v5_pro`, ~2,5 Credits/Stück):** (1) bunte Wiesen-Szene, (2) buntes, einfaches Wohnzimmer — beide leer/ohne Figur, Studio-3D-Formel, für Intro/Verse-Wechsel.
- **Block-Plan:** 2 Minuten = 12 Blöcke à 10s (`minimax_h3`, 2K, 16:9, 4-Cut-Kids-Pattern WIDE→CU-Reaktion→ECU-Körperteil→MEDIUM, Kamera bewusst frontal/mittig-lastig statt vieler Close-ups, damit Kleinkinder die Bewegung mitmachen können). Block-Zuordnung zum Song folgt dem SONG-MODE-Template aus `references/kids-song.md`: B1 Intro+Vers1 · B2 Vers1 · B3–B4 Chorus 1 · B5–B6 Vers2 · B7–B8 Chorus 2 · B9–B10 Vers3 · B11–B12 Final-Chorus (voller).
- **Song-Prompts (DE + EN), bereits mit `validate_song_prompt.py` geprüft — beide `valid: true`:**
  - Stil: DANCE-ALONG, 112 BPM, G-Dur, traditioneller Refrain wortgleich zur seit Jahrzehnten gebräuchlichen Fassung ("Kopf und Schultern, Knie und Zeh" / "Head and shoulders, knees and toes").
  - **EN-Prompt (1938 Zeichen):** Verse 1: "Hello, hello, it's Fenno fox / Come and play and move your body / Touch your head then touch your shoulders / Let's get moving, everybody" · Chorus: "Head and shoulders, knees and toes / Knees and toes, knees and toes / Head and shoulders, knees and toes / Eyes and ears and mouth and nose" · Verse 2: "Touch your knees now touch your toes too / Clap your hands and feel the beat / Eyes and ears and mouth and nose too / Fenno dances, come and meet" · Verse 3: "Now we go a little faster / Head and shoulders, spin around / Knees and toes, we clap together / Dance with Fenno, hear the sound" (vollständiger Prompt inkl. Meter-/Tempo-Klauseln liegt im Sandbox-Skript vor, muss beim nächsten Lauf nur neu zusammengesetzt werden — Struktur siehe `references/kids-song.md` Skeleton).
  - **DE-Prompt (2005 Zeichen):** Verse 1: "Hallo, hallo, ich bin Fenno / Komm und spiel und tanz mit mir / Kopf und Schultern fest berühren / Alle machen mit, komm her" · Chorus: "Kopf und Schultern, Knie und Zeh / Knie und Zeh, Knie und Zeh / Kopf und Schultern, Knie und Zeh / Augen, Ohren, Mund und Nase" · Verse 2: "Knie berühren, dann die Zehen / Klatsch die Hände, spür den Beat / Augen, Ohren, Mund und Nase / Fenno tanzt und alle gehen mit" · Verse 3: "Jetzt wird es ein bisschen schneller / Kopf und Schultern, dreh dich um / Knie und Zeh, wir klatschen zusammen / Tanz mit Fenno, hab Spaß mit uns".
  - Beide Prompts sind reine Neukompositionen (KI-generierte Melodie) mit dem traditionellen, gemeinfreien Refraintext — keine Übernahme einer bestehenden Aufnahme/Melodie eines fremden Kanals.
- **Geschätzte Kosten laut `get_cost`-Preflight (24.09.2026):** 12× Video-Block à 20 Credits (`minimax_h3`, 2K, 10s) = 240 Credits, + 2× Location-Bild à 2,5 Credits = 5 Credits, + 2× Song à 0,4 Credits = 0,8 Credits → **~245,8 Credits gesamt**, für die 12 Bild-/Video-Blöcke identisch für DE+EN nur einmal nötig (nur die 2 Songs sind sprachspezifisch). Bei nur 1 Minute/6 Blöcken (Notlösung, weicht vom Queue-Plan "ca. 2 Minuten, 2x durchlaufen" ab) wären es ~125,8 Credits.

## Executor-Log
*(Append-only Protokoll jedes `youtube-executor`-Laufs, mit Zeitstempel. Wird beim ersten Lauf angelegt.)*

### 24.09.2026 — Erster Produktionslauf: übersprungen, Credits nicht ausreichend

**Ablauf dieses Laufs:** Warteschlange gelesen (Kanal-Setup-Status: weiterhin technisch blockiert wie am 20.09.2026 dokumentiert, EN-Kanal + Make-Connector fehlen noch; Freigabe-Phase: weiterhin Phase 1). Nächster offener Queue-Eintrag ohne fertiges Video: Episode 1 ("Kopf, Schulter, Knie und Zeh" / "Head, Shoulders, Knees and Toes"). `faceless-video`-Workflow-Instruktionen geladen und das für Kids-Song-Modus relevante Referenzmaterial (`references/kids-song.md`, `references/kids-styles.md`, `references/prompts.md`) gelesen, DE- und EN-Songtext nach dem vorgegebenen Meter-Skelett geschrieben und mit dem mitgelieferten `validate_song_prompt.py`-Gate geprüft — **beide `valid: true`** (Details siehe "Vorbereitung" oben).

**Vor der eigentlichen Generierung** wie vorgeschrieben `balance` geprüft: **64,88 Credits** (Plus-Plan). Per `get_cost`-Preflight (keine echte Generierung, 0 Credits verbraucht) ermittelt: ein einzelner 10s-Video-Block im vorgeschriebenen Kids-Template (`minimax_h3`, 2K, 16:9) kostet **20 Credits**, ein Song (`seed_audio`) 0,4 Credits, ein Location-Bild (`seedream_v5_pro`) 2,5 Credits. Die Episode braucht laut Workflow-Vorgabe 12 Blöcke à 10s (2 Minuten, damit Video- und Songlänge zusammenpassen, ±3s-Toleranz im Assembler) → allein die Video-Blöcke kosten ~240 Credits, mit Locations/Songs zusammen **~245,8 Credits** — das ist rund das Vierfache der vorhandenen 64,88 Credits. Auch eine verkürzte 1-Minuten/6-Block-Notlösung (~125,8 Credits) würde das Budget noch fast verdoppeln, und würde ohnehin vom in der Queue festgelegten Ablauf ("ca. 2 Minuten, Lied 2x durchlaufen") abweichen, was ich nicht eigenmächtig entscheiden wollte.

**Entscheidung:** Keine Bild-/Video-Generierung gestartet (0 Credits für tatsächliche Generierung verbraucht, `balance` danach erneut geprüft: weiterhin 64,88). Kein Upgrade/Kauf ausgelöst (strikt freigabepflichtig laut Auftrag). Episode 1 bleibt Status "bereit zur Produktion", die fertig vorbereiteten und validierten Song-Prompts liegen jetzt direkt im Queue-Eintrag, damit der nächste Lauf ohne erneute Recherche sofort mit der Generierung starten kann, sobald genug Credits da sind.

**Text-Check:** entfällt für diesen Lauf — es wurde nichts generiert, es gibt also keine Bild-/Video-/Audio-Ausgabe zu prüfen. Die beiden Songtexte selbst wurden aber bereits vorab maschinell gegen das Meter-/Struktur-Gate geprüft (siehe oben), das ersetzt den Text-Check nicht, ergänzt ihn aber für den nächsten Lauf.

**Kanal-Setup-Status zur Kenntnis:** unverändert technisch blockiert (siehe Abschnitt oben) — EN-Kanal "Fenno & Friends" noch nicht angelegt, kein Make.com-YouTube-Connector. Nicht angefasst, ausschließlich Mikes Sache.

**Wichtiger Hinweis zur Werkzeug-Lage dieses Laufs (zur Ursachenklärung des ausgefallenen Laufs vom 21.09.2026):** Diese Session hatte keinerlei Bash-/Git-Werkzeug zur Verfügung (nur Read/Glob/Grep/Edit/Write plus die Jarvis-/Make-Tools) — `mcp__Jarvis__sandbox_exec` öffnet eine komplett separate, entfernte Higgsfield-Cloud-Sandbox ohne Zugriff auf dieses Vault-Repository, ist also für lokale Git-Kommandos ungeeignet (erster Versuch in diesem Lauf ist genau daran gescheitert: "No such file or directory"). Die eigentliche Vault-Datei-Änderung (dieser Log-Eintrag) läuft über `Edit`/`Write` und landet damit direkt im lokalen Arbeitsverzeichnis — aber **`git add/commit/push` konnte in dieser Session nicht ausgeführt werden**, weil kein entsprechendes Werkzeug bereitstand, obwohl Schritt 10 der Agenten-Definition genau das verlangt. Das ist ein sehr plausibler (Teil-)Erklärungsansatz für den spurlosen Lauf vom 21.09.2026: spürbarer Token-Verbrauch (Workflow-Doku lesen, Prompts entwickeln — beides sehr aufwändig, siehe unten) bei gleichzeitig fehlendem Mittel, das Ergebnis dauerhaft zu sichern. Offen für Mike/die Hauptsession: bitte diesen Log-Eintrag + die Episode-1-Vorbereitung committen und nach `master` pushen, und generell prüfen, ob der `youtube-executor` ein Bash/Git-Werkzeug in seiner `tools:`-Liste braucht, damit er künftig selbst committen kann (aktuell fehlt es dort komplett, siehe `.claude/agents/youtube-executor.md` Zeile 4).

**Zweiter Nebenbefund:** Das Laden der `faceless-video`-Workflow-Dokumentation (`get_workflow_instructions` bzw. große `get_workflow_bundle_file`-Dateien wie `SKILL.md`) liefert Ergebnisse von elfstelliger Zeichenzahl (>100.000 Zeichen) als eine einzige JSON-Zeile zurück, die weder mit dem normalen `Read`-Tool (Zeilen-basiert, bricht bei einer einzigen überlangen Zeile ab) noch vollständig mit `Grep` (bricht "lange Treffer" ab ~150–200 Zeichen ab) lesbar ist — nur einzelne kleinere Referenzdateien (`kids-song.md`, `kids-styles.md`, `prompts.md`) ließen sich direkt laden. Das kostet in jedem Lauf, der diesen Workflow zum ersten Mal in der Session lädt, spürbar Zeit/Tokens für Workarounds; könnte ebenfalls zum Token-Verbrauch des ausgefallenen Laufs vom 21.09.2026 beigetragen haben, falls dieser Lauf an genau dieser Stelle mit der riesigen `SKILL.md` gerungen hat.

**Offen für Mike:** (1) Diesen Lauf committen/pushen (siehe oben, kein Git-Zugriff in dieser Session). (2) Falls Episode 1 jetzt fertig produziert werden soll: Credits aufstocken (fehlen ca. 181 Credits für die volle 2-Minuten-Episode, siehe Rechnung oben) — Kauf/Upgrade macht ausschließlich Mike selbst, hier bewusst nicht ausgelöst. (3) Kanal-Setup weiterhin offen (EN-Kanal + Make-Connector, siehe Abschnitt oben, unverändert). Kein LEERLAUF-Signal — es gibt weiterhin einen offenen, aber nicht produzierbaren Queue-Eintrag, der `youtube-manager` muss hier nichts Neues planen.
