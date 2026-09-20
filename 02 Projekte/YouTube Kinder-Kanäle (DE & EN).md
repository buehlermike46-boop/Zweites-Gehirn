---
tags: [projekt, youtube, content]
status: pausiert
date: 2026-09-20
---

# YouTube Kinder-Kanäle (DE & EN)

## Ziel
Zwei inhaltsgleiche YouTube-Kanäle für Kleinkinder aufbauen, einen auf Deutsch und einen auf Englisch, nach dem Erfolgsformat der größten Kinder-Kanäle. Nicht die Kanäle selbst kopieren, sondern das Format übernehmen: eigene Charaktere, eigene Marke, eigener Content.

## Einordnung gegen den MasterPlan
**Offen ansprechen statt stillschweigend mit aufnehmen (CLAUDE.md-Regel):** Der [[MasterPlan - Teilziele und Zeitplan bis 50.000 EUR]] sieht bei 12 Stunden pro Woche maximal ein bis zwei aktive Baustellen vor (Punkt 8). Aktuell laufen bereits zwei: das IB-Business mit dem Content-System (Instagram/Telegram) und der `professor`. Ein YouTube-Kinder-Kanal-Projekt ist ein komplett neues, drittes Standbein ohne Bezug zum IB-Business. Deshalb Status hier bewusst `pausiert` statt `aktiv` — das Projekt steht recherchiert und geplant bereit, aber die Entscheidung ob und wann es losgeht (parallel, als Ersatz für etwas anderes, oder erst nach einer MasterPlan-Stufe) liegt bei Mike.

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

## Nächste Schritte (falls Mike grünes Licht gibt)

- [ ] Grundsatzentscheidung: dritte Baustelle parallel zulassen, etwas anderes dafür pausieren, oder Start auf nach einer MasterPlan-Stufe verschieben
- [ ] Nischen-Feinschnitt: welche gemeinfreien Reime/Themen zuerst, Zielalter (0-2, 2-4), Videolänge
- [ ] Eigenes Charakterdesign + Kanalbranding für DE und EN (identisch, nur Sprache unterschiedlich)
- [ ] Ein Testvideo produzieren und Produktionszeit/-kosten pro Video real messen
- [ ] Erst danach über eine eigene Produktions-Pipeline (Agent ähnlich `content-executor`) nachdenken

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
