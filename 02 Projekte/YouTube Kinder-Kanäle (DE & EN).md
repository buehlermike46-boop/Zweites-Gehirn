---
tags: [projekt, youtube, content]
status: aktiv
date: 2026-09-20
---

# YouTube Kinder-Kanäle (DE & EN)

## Ziel
Zwei inhaltsgleiche YouTube-Kanäle für Kleinkinder aufbauen, einen auf Deutsch und einen auf Englisch, nach dem Erfolgsformat der größten Kinder-Kanäle. Nicht die Kanäle selbst kopieren, sondern das Format übernehmen: eigene Charaktere, eigene Marke, eigener Content. Ziel laut Mike (20.09.2026): fertigstellen und Reichweite/Klicks aufbauen.

## Einordnung gegen den MasterPlan
**Bewusste Ausnahme, 20.09.2026:** Der [[MasterPlan - Teilziele und Zeitplan bis 50.000 EUR]] sieht bei 12 Stunden pro Woche maximal ein bis zwei aktive Baustellen vor (Punkt 8). Aktuell liefen bereits zwei: das IB-Business mit dem Content-System (Instagram/Telegram) und der `professor`. Mike hat dieses Projekt trotzdem ausdrücklich auf `aktiv` gestellt ("Aktiv stellen, wir sollen das Beenden und Klicks sammeln") — bewusste Entscheidung, nicht übersehen, gleiches Muster wie die Ausnahme vom 10.09.2026 in Punkt 8 des MasterPlans. Damit sind es real drei aktive Baustellen. Der `professor` bewertet das in seiner nächsten Runde wie gewohnt mit.

## Recherche: Die größten Kinder-Kanäle

| Kanal | Abonnenten | Format |
|---|---|---|
| Cocomelon | ~199 Mio. | 3D-animierte Nursery Rhymes & Kinderlieder, eigene Charaktere (JJ & Familie) |
| Little Baby Bum | ~195 Mio. | 3D-animierte klassische + eigene Nursery Rhymes, eigene Charaktere (Mia & Familie) |
| Vlad and Niki | ~147 Mio. | Live-Action, echte Kinder als Protagonisten (Spielzeug, Alltag, Sketche) |
| Kids Diana Show | ~138 Mio. | Live-Action, echtes Kind als Protagonistin |
| Like Nastya | Top 10 | Live-Action, echtes Kind als Protagonistin |
| ChuChu TV | ~98 Mio. | 2D/3D-animierte Nursery Rhymes, mehrsprachig (Englisch, Hindi, Tamil, u.a.) |
| Baby Shark – Pinkfong | Top 10 | Animierte Kinderlieder, eigenes IP (Baby Shark) |
| Toys and Colors, El Reino Infantil, LooLoo Kids, Masha & the Bear | Top 20 | Mix aus Spielzeug-Content, Animation, Lizenz-Content |

## Zwei Formattypen, nur einer ist für dich realistisch

**Live-Action mit echten Kindern** (Vlad and Niki, Kids Diana Show, Like Nastya, Ryan's World): Braucht echte Kinder vor der Kamera, laufende Filmproduktion, und bringt bei einem Kinder-Kanal erhebliche Privatsphäre-/Sicherheitsfragen mit sich. Für dich ohne eigenes Kind im passenden Alter und ohne Filmteam nicht praktikabel. **Nicht empfohlen.**

**Animierte Nursery Rhymes / Edutainment** (Cocomelon, Little Baby Bum, ChuChu TV, Pinkfong): Komplett ohne echte Kinder produzierbar, mit KI-Tools skalierbar, seit über zehn Jahren bewährtes Format mit konstanter Nachfrage (die Zielgruppe erneuert sich ständig, Kleinkinder schauen Inhalte zudem wieder und wieder). **Empfohlenes Format für dieses Projekt.**

## Die wichtigste Regel: Format klonen, nicht die Marke

Moonbug (Firma hinter Cocomelon) hat 2024 einen Prozess gegen den Anbieter Babybus gewonnen und 23 Millionen Dollar Schadenersatz zugesprochen bekommen, weil Babybus Charakternamen und Optik zu nah kopiert hat ("carbon copy"). Das ist die rote Linie.

**Was geht:** das Grundformat übernehmen, das seit Jahren funktioniert. Little Baby Bum und ChuChu TV machen das offen vor: klassische, gemeinfreie Nursery Rhymes (Incy Wincy Spider, Baa Baa Black Sheep, usw.) mit komplett eigenen Charakteren, eigenem Look und eigenem Kanalnamen neu vertonen und animieren.

**Was nicht geht:** Cocomelons Charaktere (JJ & Familie), Optik, Musik oder Kanalnamen nachbauen oder zu nah imitieren. Genau solche "Cocomelon-Ripoffs" sind aktuell ein bekanntes Problem auf YouTube und stehen in der Kritik (Stichwort "AI slop" für Kleinkinder) — davon klar abgrenzen ist auch Imagesache.

**Für dieses Projekt heißt das konkret:** eigene Original-Charaktere, eigener Kanalname/eigenes Branding für DE und EN, Inhalte auf Basis gemeinfreier Kinderlieder/Reime oder komplett eigener Songs. Format und Produktionsprinzip kopieren, nicht die Marke.

## Produktion mit Jarvis (gleiche Infrastruktur wie beim bestehenden Content-System)

Der `content-executor` nutzt für Instagram/Telegram bereits Jarvis für Bild-/Video-/Audio-Erstellung — dieselben Werkzeuge tragen ein Kinder-Kanal-Format:

- **Charakterdesign & Look:** `generate_image` / Character-Sheet-Workflow für konsistente, eigene Figuren
- **Animierte Clips:** `generate_video`
- **Gesang/Erzählung:** `generate_audio` bzw. eigene Stimme über `create_voice`
- **Zwei Kanäle, ein Produktionslauf:** gleiche Visuals für DE und EN wiederverwenden, nur Audiospur (Gesang/Text) pro Sprache neu erzeugen — genau die "identisch, nur zweisprachig"-Idee, die auch ChuChu TV so fährt

## Monetarisierung: Realistischer Zeit- und Ertragsrahmen

- Kinder-Content muss als "Made for Kids" gekennzeichnet werden (COPPA-Pflicht). Damit fallen personalisierte Werbung, Kommentare, Memberships und Endcards weg — nur kontextbezogene Werbung ist erlaubt.
- **RPM entsprechend niedriger:** ca. 0,50 bis 3 USD pro 1.000 Views bei Kinder-Content, gegenüber 3 bis 15 USD bei Erwachsenen-Content.
- **Monetarisierungs-Schwelle:** 1.000 Abonnenten plus 4.000 gültige Watch-Hours in 12 Monaten (oder 10 Mio. Shorts-Views in 90 Tagen). Ab Februar 2027 steigt die Watch-Hours-Schwelle für neue Kanäle auf 8.000 Stunden.
- **Realistische Dauer bis dahin:** bei 1 bis 2 Videos/Woche typischerweise 6 bis 18 Monate bis 1.000 Abonnenten, bei einem guten, konsequent bespielten Nischen-Format (Nursery Rhymes werden dauerhaft gesucht und wiederholt geschaut) eher am schnelleren Ende möglich.
- **Das eigentliche Geld** kommt in dieser Nische nicht aus Werbe-RPM, sondern erst bei großem Volumen, aus Lizenzierung (Streaming-Plattformen), Merchandising und Markenkooperationen (Spielzeug/Edtech) — das ist ein Marathon, kein schneller Cashflow-Kanal.

## Referenz-Beispiel von Mike (20.09.2026)
Mike hat als konkretes Beispiel für "sowas ist gut" verlinkt: ["Lerne schwimmen wie ein kleiner Fisch!" von HeyKids - Kinderlieder TV](https://www.youtube.com/watch?v=ZaD1RgBQBlc). HeyKids ist ein realer, aktiver deutscher Kinderlieder-Kanal (seit 2014, ~72 Mio. Views/Monat, +30.000 Abos/Monat zuletzt) mit klassischen und eigenen Kinderliedern/Bildungsliedern — bestätigt genau das oben empfohlene Format (animierte Nursery-Rhyme-/Bildungslieder statt Live-Action) und zeigt, dass der deutsche Markt für dieses Format aktuell noch wächst statt gesättigt zu sein. Szenen-Analyse des Beispielvideos läuft, wird bei Fertigstellung hier ergänzt.

## Produktionsstand

**Status 20.09.2026:** Auf Mikes Wunsch ("Aktiv stellen, wir sollen das Beenden und Klicks sammeln") direkt mit der Produktion gestartet, kein reines Recherche-Projekt mehr.

- [x] Erster Charakterentwurf über Jarvis (`soul_cast`, Character-Sheet-Workflow) fertig: kleiner origineller Fuchs-Charakter, 3D-stylized (Pixar-artiger Look). Von Mike freigegeben (20.09.2026: "Design gefällt mir")
- [x] Name final festgelegt: **Fenno** (statt des automatisch vergebenen "Pip" — zu stark belegt im Kinder-Content-Bereich, siehe oben). Kanalname: "Fenno & Freunde – Kinderlieder" (DE) / "Fenno & Friends – Kids Songs" (EN)
- [x] Eigenes Agentenpaar aufgesetzt (Mikes Wunsch 20.09.2026: "dafür hab ich doch meine Agenten"): `youtube-manager`/`youtube-executor` (siehe `CLAUDE.md` Abschnitt "YouTube-Agent"), koordiniert über `03 Bereiche/YouTube Kinder-Kanäle/Video-Warteschlange.md`. Übernehmen ab jetzt Planung und Produktion, nicht mehr die Hauptsession direkt
- [x] Produktions-Workflow identifiziert: Jarvis' `faceless-video`-Workflow (Typ "Kids", eigener Song-Modus) — liefert konsistenten Look, Gesangsstimme und eingebrannte Untertitel als fertiges Paket, genau das was für die Sing-along-Videos gebraucht wird
- [ ] Erstes Lied/erste Episode auswählen und produzieren (Aufgabe des `youtube-manager`/`youtube-executor`-Paars ab jetzt, siehe Video-Warteschlange)

## Kanal-Setup: YouTube-Upload technisch geprüft (20.09.2026)

**Ergebnis:** Make.com hat ein natives YouTube-Modul (`Upload a Video`, `Set a Video Thumbnail`, `Update a Video Details`, u.a.) — ein automatisierter Upload ist also technisch möglich, genau wie beim bestehenden Telegram-Kanal-Versand (Make-Szenario 7391673). **Aber:** Die Verbindung braucht einen echten Google-Login mit Klick-Bestätigung im Browser (Googles OAuth-Pflicht für YouTube-Uploads) — das kann kein Agent/keine Session automatisiert für Mike erledigen. Geprüft: aktuell existiert weder eine YouTube-Verbindung in Make.com noch einer der beiden Kanäle selbst.

**Einziger verbleibender manueller Schritt, den nur Mike machen kann (ca. 15-20 Minuten, einmalig):**
1. Zwei YouTube-Kanäle anlegen: "Fenno & Freunde – Kinderlieder" (DE), "Fenno & Friends – Kids Songs" (EN)
2. In Make.com ein YouTube-Modul hinzufügen, "Create a connection" klicken, Google-Login durchklicken (einmal je Kanal/Google-Konto)
3. Bescheid geben — danach wird daraus ein Upload-Szenario gebaut (analog zum Telegram-Szenario) und der `youtube-executor` kann ab dann selbstständig hochladen

**Bis dahin:** volle Produktion läuft bereits automatisiert über `youtube-executor`, fertige Videos werden in der Video-Warteschlange mit Status `fertig, wartet auf Kanal/Upload` gesammelt. Genaue Schritt-für-Schritt-Anleitung liegt in `03 Bereiche/YouTube Kinder-Kanäle/Video-Warteschlange.md`.

## Grundsatzentscheidung
Erledigt (20.09.2026): Mike hat das Projekt trotz der Drei-Baustellen-Warnung aktiv gestellt, siehe Log im [[MasterPlan - Teilziele und Zeitplan bis 50.000 EUR]] Punkt 8. Operative Planung (Nischen-Feinschnitt, Zielalter, Upload-Rhythmus) läuft ab jetzt über den `youtube-manager`, nicht mehr hier.

## Quellen
- [Most subscribed YouTube Kids channels – AIR Media-Tech](https://air.io/en/youtube-hacks/most-subscribed-youtube-kids-channels)
- [Cocomelon – Wikipedia](https://en.wikipedia.org/wiki/Cocomelon)
- [How CoComelon Became The Third Largest Channel on YouTube – RightMetric](https://rightmetric.co/outsight-library/how-cocomelon-became-the-third-largest-channel-on-youtube)
- [Little Baby Bum – Wikipedia](https://en.wikipedia.org/wiki/Little_Baby_Bum)
- [ChuChu TV – Wikipedia](https://en.wikipedia.org/wiki/ChuChu_TV)
- [Jury awards producers of YouTube's CoComelon $23M for copyright infringement – Daily Journal](https://www.dailyjournal.com/articles/374013-jury-awards-producers-of-youtube-s-cocomelon-23m-for-copyright-infringement)
- [Cocomelon Ripoffs Are Targeting Kids – But Is YouTube Doing Enough?](https://passionfru.it/youtube-ai-kids-videos-56389/)
- [Made for Kids YouTube: How to Make Money in 2026 – vidIQ](https://vidiq.com/blog/post/make-money-kids-youtube-channel/)
- [YouTube now requires creators to have twice as many watch hours to start earning money – TechCrunch](https://techcrunch.com/2026/08/10/youtube-now-requires-creators-to-have-twice-as-many-watch-hours-to-start-earning-money/)
- [How to monetize a YouTube kids channel in 2026 – Gyre](https://gyre.pro/blog/how-to-monetize-a-youtube-kids-channel)
