---
tags: [bereich]
---

# Marketing & Kundenakquise

## Beschreibung
Laufender Betrieb der Kundengewinnung: Facebook- und Instagram-Werbung sowie Telegram-Kanäle mit automatisierten Bots. Läuft dauerhaft, sobald das automatisierte System (siehe 02 Projekte/KI-Automatisierung IB-Business.md) aufgebaut ist.

## Aktive Themen
- Affiliate-Strategie & Content-Aufbau für Instagram (persönlicher Account + Limitless-Account) — siehe [[VT Markets Affiliate-Strategie & Content-Plan]]
- Content-Produktion mit KI-Tools (CapCut, InVideo AI, HeyGen, Canva) — siehe [[Content-Workflow Tools (KI & Reels)]]
- Content-Erstellung zusätzlich über Higgsfield (Bilder/Videos on-demand, `generate_image`/`generate_video`, plus `virality_predictor` als Vorab-Qualitätscheck) — ergänzt die bestehenden Tools, ersetzt sie nicht. Skills liegen unter `.agents/skills/` (Brandkit, Video-Explainer, Soul-ID, etc.)
- Instagram-Publishing läuft über den bestehenden Windsor.ai-Connector (Account `mike_bueh`, id `17841459820754777`), volle Schreibrechte (Bild/Video/Carousel/Story)

## Meta-Compliance-Risiko (Recherche 09.09.2026)
CFD/Forex-Trading gehört bei Meta zu den **komplett verbotenen Kategorien für bezahlte Werbung** ("Prohibited Financial Products and Services"). 78% der Finance/Investment-Accounts bekommen laut Branchendaten irgendwann Restriktionen. Konsequenzen:
- **Nie Posts boosten oder als Ad schalten** (auch nicht über den `boost_post`-Action im Facebook-Connector) — würde wahrscheinlich abgelehnt und könnte den Account riskieren
- Nur organisches Posten, kein Paid-Media-Budget für diese Inhalte
- Risikoneutrale Sprache ist Pflicht, keine Gewinn-Garantien o.ä. (Disclaimer wie beim ersten Post beibehalten)
- Quelle: [Meta Transparency Center](https://transparency.meta.com/policies/ad-standards/deceptive-content/prohibited-financial-products-and-services/)

## Guardrails Content-Erstellung (09.09.2026)
- Content muss echte Angebots-Fakten enthalten, nicht nur hübsche Grafik — siehe `00 Kontext/Angebot.md`
- **Funnel-Staging wichtig:** Instagram-Posts bleiben rein informativ (Ökosystem/Themen erklären), OHNE die Kontoeröffnung als Voraussetzung zu erwähnen. Der Account-Eröffnungs-/Broker-CTA gehört erst in den Telegram-Funnel (Kanal **t.me/JointoInnerCircle**, "Inner Circle - Mike Bühler"). Instagram-Captions verlinken stattdessen auf den Kanal.
- Keine Inhalte aus der RG Trading Academy verwenden (Verschwiegenheitserklärung)
- Marketing-Zahlen (Winrate, Mitgliederzahlen etc.) immer als "laut Anbieter" kennzeichnen

## Automatisierungsgrad & Workflow (aktueller Stand, Update 10.09.2026)

**Klarstellung 10.09.2026:** Diese Datei und [[Posting-Warteschlange]] widersprachen sich bis eben beim Thema Freigabe (beide behaupteten am 09.09. die "finale Version" zu sein). Mit Mike geklärt beim Aufbau des `content-manager`/`content-executor`-Agentenpaars: **zweiphasig.**

- **Phase 1, jetzt aktiv:** Jeder Post läuft erst als Entwurf in [[Posting-Warteschlange]] mit Status `bereit (wartet auf Freigabe)`. Nichts geht live, bevor Mike den Status auf `freigegeben` setzt. So lernt er den Stil/die Qualität kennen, bevor er die Kontrolle abgibt.
- **Phase 2, nach Mikes ausdrücklichem Okay:** Sobald Mike sagt, der Stil sitzt, schaltet er in [[Posting-Warteschlange]] auf automatisch um (siehe dort, Abschnitt "Freigabe-Phase"). Ab dann postet der `content-executor` ohne Einzelfreigabe.

Der Prozess selbst bleibt wie hier beschrieben:

1. **Der `content-manager` plant wöchentlich genug Content** (Themen aus `00 Kontext/Angebot.md`, eigene Performance-Zahlen, öffentliche Trend-/Ads-Recherche nur zur Inspiration, siehe unten)
2. **Freigabe-Schritt** gemäß aktiver Phase (siehe oben)
3. **Posten auf Instagram** über den `content-executor` (Facebook-Ziel noch offen, siehe offene Punkte)
4. **Danach laufend tracken**: Beiträge, Storys, Reels (Performance-Daten über Windsor.ai, siehe [[Performance-Log]])
5. **Der `content-manager` entscheidet wöchentlich, was gut/schlecht läuft** — schlecht laufender Content wird entfernt/nicht wiederholt, gut laufender wird als Vorlage für Verbesserungen genutzt
6. **Ziel**: Reichweite und Klicks maximieren, um Kunden zu gewinnen — kontinuierliche Verbesserung, nicht nur einmalig posten und fertig

**Wichtig, geklärt 10.09.2026:** "Was läuft gerade gut" recherchieren heißt öffentliche Ads-Bibliotheken/Trendberichte für Inspiration ansehen (WebSearch), NICHT selbst bezahlte Kampagnen schalten. Siehe Meta-Compliance-Risiko unten, das gilt unverändert und uneingeschränkt.

Das ist die verbindliche Arbeitsweise ab jetzt, nicht nur für diese Session.

## Recherche: Was performt 2026 auf Meta (09.09.2026)
- **Info-Grafiken werden 3x häufiger gespeichert** als Talking-Head-Finance-Content — bestätigt unseren Ansatz (Higgsfield nano_banana_pro Grafiken)
- Quick-Explainer/Tutorial-Reels performen stark, Passive-Income-Content ist das meistgespeicherte Finance-Format, Myth-Busting mit Daten treibt Kommentare
- Algorithmus-Ranking-Signale 2026: **Watch-Time und "Sends" (per DM weiterschicken)** zählen mehr als Follower/Likes, besonders bei Reels
- Original/für-Instagram-gemachter Content bekommt 40-60% mehr Reichweite als erkennbar wiederverwerteter — 10+ Reposts/30 Tage fliegen aus der Empfehlung
- **Fürs eigene Modell (IB/Affiliate)**: Zielrhythmus 3-7 Reels/Woche, jedes mit CTA zum Telegram-Kanal. Der Kanal selbst sollte 4-8 Posts/Tag bekommen (Morning Briefing, Trade-Ideen, Mini-Education) um Vertrauen aufzubauen. Realistische Erwartung: ~2.000 Kanal-Mitglieder → 30-80 VIP-Conversions/Quartal (3-8%)
- ⚠️ Seit Januar 2026 strengere Telegram/WhatsApp-Regeln für häufiges Gruppen-Messaging & Bot-Verifizierung — relevant für das bestehende Make.com-Bot-Setup in [[KI-Automatisierung IB-Business]], sollte mal gegengecheckt werden ob es noch sauber läuft
- Quellen: [Contentworks](https://contentworks.agency/6-instagram-finance-reels-ideas-to-try-this-year/), [FlowShorts](https://flowshorts.app/instagram-reels-ideas/finance), [Hootsuite Instagram-Algorithmus 2026](https://blog.hootsuite.com/instagram-algorithm/), [Pay2.House Telegram-Funnels 2026](https://pay2.house/blogs/article/telegram-voronki-v-arbitrazhe-2026-kak-postroit-masshtabiruemuyu-sistemu-privlecheniya-i-ne-popast-pod-blokirovku?hl=en)

## Offene technische Punkte
- **GitHub-Repo `limitless-content` ist tot, Ursache gefunden (09.09.2026):** Der zugehörige Google-Account `buhlermike307@gmail.com` (Basis für den GitHub-Account `buhlermike307-del`) wurde von Google am 09.09.2026 deaktiviert — Begründung laut Google: "wurde offenbar mit mehreren anderen Konten erstellt... möglicherweise von einem Computerprogramm erstellt" (als Bot/Massen-Account geflaggt). Das erklärt die durchgängigen "Permission denied"-Fehler beim `git push`, unabhängig vom Token — der Account selbst ist gesperrt, kein Token-Scope-Problem. **Diesen Account/dieses Repo für künftige Automatisierung nicht mehr verwenden.** Für das JPEG-Hosting-Problem braucht es einen neuen Ansatz (z.B. Repo unter Mikes Hauptaccount, oder komplett andere Hosting-Lösung) — offener Punkt für später.
- Scheduled Task für den wiederkehrenden Content-Zyklus noch nicht aufgesetzt
- Erster Post läuft für heute manuell über die Instagram-App (09.09.2026), nicht über die API

## Referenzen
- [[Social Post Ideen (Batch 2)]]
- [[Content-Plan - Woche 07.09.-13.09.2026]]
- [[Recherche - Was funktioniert auf Instagram (Trading-Content)]]
- [[Posting-Warteschlange]] — konkrete Post-Queue mit Uhrzeiten für den Limitless-Account, siehe dort für den aktuellen Automatisierungs-Status
- [[Performance-Log]] — laufende Auswertung was auf Instagram performt (neu, 09.09.2026)
