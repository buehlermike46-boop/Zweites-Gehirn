---
tags: [projekt, trading, atas, bot]
status: aktiv
date: 2026-09-19
---

# ATAS Trading Bot (NQ-Abpraller-Setup)

## Ziel
Bot auf der ATAS-Plattform, der das bestehende [[NQ Abpraller-Setup Checkliste]] erkennt. Zielmodus laut Mike (19.09.2026): **vollautomatisch bauen**, mit einem Umschalter auf **halbautomatisch** (Alarm statt Order).

## Einordnung gegen den MasterPlan
Der [[MasterPlan - Teilziele und Zeitplan bis 50.000 EUR]] führt eigenes Trading bewusst mit 0 % Einkommensanteil und warnt in Punkt 8 vor zu vielen parallelen Baustellen. Dieses Projekt läuft als **bewusste Ausnahme** (gleiches Prinzip wie `content-manager`/`professor`): Ziel ist Trading-Disziplin/Zeitersparnis am eigenen Konto, kein neues Umsatz-Standbein. Es konkurriert nicht um die 12h/Woche IB-Business-Zeit und läuft separat vom Aufgaben-Kreislauf (`aufgaben-manager`/`-executor`).

## Kritischer Blocker: Apex-Regeln zu Bots — noch offen
Recherche (19.09.2026) liefert widersprüchliche Quellen: ein Drittanbieter-Blog behauptet, Apex erlaube automatisierte Bots unter Auflagen (Stop/Target-Pflicht, Monitoring, Notfall-Stopp); eine andere Quelle sagt, volle Automatisierung sei auf Performance-Accounts verboten, nur "ATM-Strategien" und überwachte Webhook-Alerts seien erlaubt. **Mike klärt das direkt mit Apex' offiziellem Regelwerk, parallel zur Entwicklung.** Bis das geklärt ist: kein Order-Code geht auf ein echtes Konto (auch nicht Evaluation), nur Replay/Demo.

## Architektur-Entscheidungen (19.09.2026, mit Mike abgestimmt)
- **Automatisierungsgrad:** Vollautomatisch als Ziel, Umschalter Halbautomatisch (Property in den Strategie-Einstellungen)
- **Testreihenfolge:** erst Replay/Demo in ATAS, Apex-Freigabe klärt Mike parallel, Live erst danach
- **Code-Workflow:** Claude schreibt den C#-Code, Mike kompiliert/testet lokal in Visual Studio + ATAS, Feedback-Loop über diese Session

## Technischer Rahmen (ATAS)
- Sprache: C#, .NET Standard Class Library
- Referenzen aus dem lokalen ATAS-Installationsverzeichnis: `ATAS.Indicators.dll` (Analyse/Anzeige), `ATAS Strategies.dll` (zusätzlich Order-Ausführung), `Utils.Common.dll` (Logging)
- Basisklassen: `Indicator` (Analyse) → `ChartStrategy` (erbt von `Indicator`, zusätzlich `OpenOrder`/`ModifyOrder`/`CancelOrder`, `Security`/`Portfolio`/`Connector`/`CurrentPosition`/`State`)
- Lifecycle: `OnInitialize`, `OnCalculate(bar)` für jede Kerze/jeden Tick; bei Strategien zusätzlich `OnStarted`/`OnStopped`/`OnSuspended`/`CanProcess`
- Deployment: Projekt bauen → erzeugte `.dll` nach `Dokumente\ATAS\Indicators` (bzw. entsprechendem Strategies-Ordner) kopieren → in ATAS im Indikator-/Strategie-Manager hinzufügen

## Offene technische Fragen — brauchen Verifikation an deiner echten Installation
1. **ATAS-Lizenzstufe:** Custom-Indikatoren laufen meist auf jeder Stufe, automatisierte Order-Ausführung (`ChartStrategy`) braucht vermutlich eine höhere Stufe. Handelsverbindung ist geklärt (19.09.2026, Mike): **Rithmic** — Apex läuft über Rithmic.
2. **Exakte Footprint-/Cluster-API** (Delta, MaxDelta, MinDelta, POC, Bid/Ask je Preisstufe je Kerze) — in der öffentlichen Doku nicht im Detail einsehbar. Sobald du Visual Studio mit den ATAS-Referenzen offen hast: IntelliSense auf `GetCandle(bar).` zeigt dir die verfügbaren Properties — schick mir die Liste (Screenshot oder Abschrift reicht), dann baue ich Phase 2 exakt darauf.
3. **Cross-Instrument-Zugriff:** Die Tageskontext-Regeln laufen auf ES M15, während der Trade-Chart NQ ist. ATAS hat laut Doku "zusätzliche Datenquellen" für Indikatoren — genaue API muss ich noch verifizieren, sobald Punkt 2 geklärt ist.
4. **Journal-Integration (später):** Läuft dieser Vault-Ordner auf demselben Windows-Rechner wie ATAS? Relevant, falls der Bot später automatisch in [[Trading-Ergebnisse]] schreiben soll — nicht Teil der ersten Phasen.

## Phasenplan

### Phase 0 — Toolchain verifizieren (jetzt)
- Visual Studio Community installieren (falls noch nicht vorhanden)
- Neues Projekt: "Class Library (.NET Standard)", Referenzen auf `ATAS.Indicators.dll` + `Utils.Common.dll` aus dem ATAS-Installationsordner setzen
- Beigelegten Demand-Index-Indikator (`code/NqDemandIndex.cs`) bauen, DLL nach `Dokumente\ATAS\Indicators` kopieren, im NQ-Chart laden. **Ziel dieser Phase ist nicht der perfekte Indikator, sondern einmal den kompletten Weg Code → Build → Chart lebend zu sehen** — Fehler beim ersten Build sind erwartbar, siehe Hinweis im Code.

### Phase 1 — Analyse-Indikator (read-only, kein Order-Code)
- Demand Index nach Sibbet-Formel — Code liegt bereit
- ATR/Supertrend: erst prüfen, ob deine bestehenden RG-Trading-Indikatoren schon in ATAS installiert sind — falls ja, nicht neu bauen, nur referenzieren
- Location-Level-Erkennung (VAH/VAL/POC/Tageshoch-tief) — nächster Baustein
- Tageskontext-Regeln (Vortageshoch/-tief Ablehnung/Annahme, Trendtag-Erkennung) — braucht Punkt 3 der offenen Fragen (Cross-Instrument)

### Phase 2 — Footprint-/Orderflow-Bestätigung
- Braucht Punkt 2 der offenen Fragen zuerst (Cluster-API)
- Ablehnungskerze/Delta-Logik in konkrete Zahlen-Schwellen übersetzen — **das kalibrieren wir an echten vergangenen Setups aus deinem Trading-Journal, nicht geraten**

### Phase 3 — Order-Ausführung mit Risikomanagement
- Umschalter Halbautomatisch (nur Alarm) / Vollautomatisch (Order direkt)
- Risikoregeln fest im Code, nicht optional: ATR-basierter Stop, CRV min. 1:2, 1R = 200 € Lotgrößen-Berechnung (siehe [[Trading-Journal Struktur (1R = 200€)]]), Tagesverlust-Limit 500 $ als Kill-Switch (siehe [[Trading-Psychologie - Disziplin-Regelwerk]])
- Erst im Halbautomatik-Modus scharf testen (Alarm, du bestätigst manuell), bevor Vollautomatik überhaupt in Betracht kommt

### Phase 4 — Vollautomatik scharf schalten
- Voraussetzung: Phase 1–3 im Replay/Demo stabil UND Apex-Bot-Regel offiziell geklärt (siehe Blocker oben)
- Erst Demo-/Evaluation-Konto, das Funded-Konto erst nach echter Bewährung

## Nächster Schritt
Code für Phase 0/1 (Demand-Index-Indikator) liegt in `code/NqDemandIndex.cs`. Du baust ihn lokal, meldest zurück was passiert (Build-Fehler, IntelliSense-Vorschläge für `GetCandle(bar).`) — daraus mache ich die nächsten Schritte konkret, statt weiter auf öffentlicher Doku zu raten.

## Referenzen
- [[NQ Abpraller-Setup Checkliste]]
- [[RG-Trading Indikator - Demand Index]]
- [[RG-Trading Indikator - Supertrend]]
- [[RG-Trading Indikator - ATR (Average True Range)]]
- [[Trading-Psychologie - Disziplin-Regelwerk]]
- [[Trading-Journal Struktur (1R = 200€)]]
- [[Apex Trader Funding - 50k Auszahlungsregeln]]
- [[Trading]]
