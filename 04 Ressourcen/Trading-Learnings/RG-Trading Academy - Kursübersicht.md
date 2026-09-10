---
tags: [ressource, trading, rg-trading]
date: 2026-09-08
quelle: RG-Trading Academy Kurs "Trading und Scalping mit präzisen Orderflow-Strategien" (Reinhard Grünauer), Mitgliederbereich reinhard-gruenauer.systeme.io
status: teilweise dokumentiert
---

# RG-Trading Academy: Kursübersicht

Karte durch den Kurs, damit klar ist was schon als eigene Notiz dokumentiert ist und was noch offen ist. Achtung: Der Kurs hat eine Verschwiegenheitserklärung (keine Weitergabe an Dritte, keine Veröffentlichung von Setups/Chart-Configs) — diese Notizen sind nur für den persönlichen Gebrauch gedacht, nicht teilen/posten.

## Kursstruktur (Stand 08.09.2026, Kurs 74% durch)

1. Rechtliche Hinweise, Vorstellung
2. Fundamentales Börsenverständnis (Börse, Futures, Chartarten)
3. ATAS Tradingsoftware (Installation, Datenfeed, Workspace, TPO-Einstellungen)
4. **Volumenprofile** → [[Tageskontext & Location - Analyse-Guides]]
   - Regel 1: Ablehnung/Annahme des Vortagesbereichs, Regel 2: Trendtag, Regel 3: Valueverschiebung (bereits ausführlich in [[NQ Abpraller-Setup Checkliste]] dokumentiert)
   - Die besten Locations im Trading (VAH/VAL/POC/Volumenberg-Kanten)
5. **Market Profile** (Wie aufgebaut, 7 Situationstypen: Single Prints, Vortages Fake, Balanced Day, Trend Balanced, Inside Day, Inside Day Breakout, Inside Day Fake) — noch nicht einzeln dokumentiert, nur Struktur bekannt
6. **Footprint Charts** (Was sind sie, Typen in ATAS, richtig lesen) — Grundlagen, noch nicht einzeln dokumentiert
7. **Orderflow-Analyse mit Delta** (Einführung, Delta lesen, Delta-Zahlen) — Grundlagen für alle Setups unten
8. **Orderbuch (DOM)** (Einführung, Velocity, Absorption) → Grundlage für [[Orderflow 5-Phasen-Analysemodell]]
9. **Setups für den Einstieg – Footprint-Setups für Scalping und Daytrading** (RangeUS Chart, Delta-basiert) — vollständig dokumentiert:
   - [[RangeUS Chart (Kontext für Setups)]] — Chart-Grundlage
   - [[Delta Reversal-Setup (RangeUS Chart)]]
   - [[Continued Breakout-Setup (RangeUS Chart)]]
   - [[Sammelzonen-Volumenberg Breakout-Setup (RangeUS Chart)]]
   - [[M5 Footprint Ablehnungs-Setup]]
   - [[M5 Footprint Breakout-Setup]]
10. **Nasdaq Scalping** (ATR, Supertrend, Demand Index, Heikin Ashi, RangeUS 0/6/18) → [[Nasdaq-Scalping Setups (Katalog)]] — inzwischen großteils vollständig dokumentiert (Reversal-, Breakout-, Korrelations- und Heikin-Ashi-Setups), nur "Optimierung – Heikin Ashi Smoothed Reversal Setup" bleibt offen
11. Risikomanagement/Moneymanagement, Skalierung
12. Research/Backtesting (ATAS CST-File Converter)
13. Prop Trading & Fremdkapital (Apex Challenge, Notfallplan, 50K/250K PA Masterplan, Apex- und IQ-Capital Regel-Dashboards) → siehe [[Apex Trader Funding - 50k Auszahlungsregeln]]
14. RG-Trading BOT (GPT-BOT), RG-Trading Indikatoren (Demand Power Indicator, Super Trend Indikator)
15. **Videos/Sessions**: großes Archiv (~50+ Videos) an Live-Trading-Sessions, Community-Calls und Trade-Nachbesprechungen von März 2025 bis heute — bewusst nicht durchgegangen (angewandte Beispiele, keine neuen Setup-Definitionen, siehe Umfangsentscheidung unten)

## Warum nicht alles 1:1 transkribiert ist

Die Kursvideos sind selbst gehostet ohne Untertitel/Transkript-Spur — ich kann Chart-Folien, eingeblendete Regeln und PDFs auswerten, aber keine gesprochene Erklärung wortwörtlich mitschreiben. Setup-Lektionen mit PDF-Download sind vollständig dokumentiert. Lektionen ohne PDF (v.a. Nasdaq-Scalping, Market Profile Situationen im Detail) sind nur als Katalogeintrag mit Kontext erfasst.

## Cross-Referenzen zu bestehenden Notizen

Einiges aus dem Kurs war schon vorher über Gespräche mit dem RG-Trading Mentor GPT in diesem Vault gelandet, bevor ich die Original-Kursinhalte direkt durchgesehen habe:
- [[NQ Abpraller-Setup Checkliste]] = im Kern das [[M5 Footprint Ablehnungs-Setup]] aus dem Kurs, erweitert um ES/NQ-Korrelation und Demand Index
- [[Orderflow 5-Phasen-Analysemodell]] = eigenes Analyse-Framework, ergänzt die Kurs-Setups um eine Schritt-für-Schritt-Denkweise beim Chart-Lesen
