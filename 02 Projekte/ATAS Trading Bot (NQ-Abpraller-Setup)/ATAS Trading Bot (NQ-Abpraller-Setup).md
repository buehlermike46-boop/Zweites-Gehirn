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

## Wichtige Rahmenbedingung: ATAS läuft lokal, nicht in der Cloud
ATAS ist eine Desktop-Anwendung, kein Server-/Cloud-Dienst. Eine gestartete Strategie läuft im ATAS-Prozess auf Mikes Rechner — schließt er ATAS oder geht der Rechner in Standby, stoppt der Bot mit. Kurze Internet-Aussetzer bei laufendem ATAS übersteht die Strategie (ATAS-eigene Meldung "bleibt aktiv"), ein Schließen der App nicht. Für echten Dauerbetrieb (Phase 4, vollautomatisch) muss der Rechner mit laufendem ATAS durchgehend an sein, solange gehandelt werden soll.

## Technischer Rahmen (ATAS)
- Sprache: C#, .NET Standard Class Library
- Referenzen aus dem lokalen ATAS-Installationsverzeichnis: `ATAS.Indicators.dll` (Analyse/Anzeige), `ATAS Strategies.dll` (zusätzlich Order-Ausführung), `Utils.Common.dll` (Logging)
- Basisklassen: `Indicator` (Analyse) → `ChartStrategy` (erbt von `Indicator`, zusätzlich `OpenOrder`/`ModifyOrder`/`CancelOrder`, `Security`/`Portfolio`/`Connector`/`CurrentPosition`/`State`)
- Lifecycle: `OnInitialize`, `OnCalculate(bar)` für jede Kerze/jeden Tick; bei Strategien zusätzlich `OnStarted`/`OnStopped`/`OnSuspended`/`CanProcess`
- Deployment: Projekt bauen → erzeugte `.dll` nach `C:\Users\<User>\AppData\Roaming\ATAS\Indicators` kopieren (**nicht** `Dokumente\ATAS\Indicators` — das war eine veraltete öffentliche Anleitung, am 19.09.2026 live widerlegt: kein Log-Eintrag, ATAS scannt den Ordner gar nicht. Der echte Ordner liegt unter AppData\Roaming, bestätigt weil dort auch der fertige "RG-Trading Academy Super Trend"-Indikator lag) → ATAS komplett neu starten (Task-Manager prüfen, alle "Platform"-Hintergrundprozesse beenden, sonst wird der Ordner nicht neu gescannt) → im Indikator-Manager unter "All" suchen

## Offene technische Fragen — brauchen Verifikation an deiner echten Installation
1. **ATAS-Lizenzstufe:** Custom-Indikatoren laufen meist auf jeder Stufe, automatisierte Order-Ausführung (`ChartStrategy`) braucht vermutlich eine höhere Stufe. Handelsverbindung ist geklärt (19.09.2026, Mike): **Rithmic** — Apex läuft über Rithmic.

### Order-Klasse bestätigt (19.09.2026, per Objektkatalog gegen Mikes Installation)
Die von der ATAS-Doku beschriebene `Order`-Klasse (Parameter von `ChartStrategy.OpenOrder`) ist **nicht** in `ATAS.Indicators.dll` oder `ATAS.Strategies.dll` enthalten, sondern in einer bis dahin nicht referenzierten dritten DLL: **`ATAS.DataFeedsCore.dll`** (liegt im selben ATAS-Platform-Ordner, jetzt als Referenz hinzugefügt). Vollständiger Klasse: `ATAS.DataFeedsCore.Order`, `public class`.

Bestätigte Felder (per Objektkatalog): `Direction`, `Price`, `QuantityToFill`, `Security`, `SecurityId`, `Portfolio`, `State`, `Comment`, `OCOGroup` (vermutlich Mechanismus für verknüpfte Stop/Target-Orders), `Id`, `ExtId`, `AccountID`, `AutoCancel`, `Canceled`, `ExpiryDate`, `ExtendedOptions`, `IsAttached`, `IsInPosition`, `Latency`, `Parent`, `Route`, `RoutedAccountId`, `Time`, `TimeInForce`, plus `Clone()`/`ToString()`. Zugehörige Enums `ATAS.DataFeedsCore.OrderDirections` und `ATAS.DataFeedsCore.OrderTypes` existieren, genaue Werte werden gerade geprüft.
2. **Exakte Footprint-/Cluster-API** (Delta, MaxDelta, MinDelta, POC, Bid/Ask je Preisstufe je Kerze) — in der öffentlichen Doku nicht im Detail einsehbar. Sobald du Visual Studio mit den ATAS-Referenzen offen hast: IntelliSense auf `GetCandle(bar).` zeigt dir die verfügbaren Properties — schick mir die Liste (Screenshot oder Abschrift reicht), dann baue ich Phase 2 exakt darauf.
3. **Cross-Instrument-Zugriff:** Die Tageskontext-Regeln laufen auf ES M15, während der Trade-Chart NQ ist. ATAS hat laut Doku "zusätzliche Datenquellen" für Indikatoren — genaue API muss ich noch verifizieren, sobald Punkt 2 geklärt ist.
4. **Journal-Integration (später):** Läuft dieser Vault-Ordner auf demselben Windows-Rechner wie ATAS? Relevant, falls der Bot später automatisch in [[Trading-Ergebnisse]] schreiben soll — nicht Teil der ersten Phasen.

## Phasenplan

### Phase 0 — Toolchain verifizieren (jetzt)
- Visual Studio Community installieren (falls noch nicht vorhanden)
- Neues Projekt: "Class Library (.NET Standard)", Referenzen auf `ATAS.Indicators.dll` + `Utils.Common.dll` aus dem ATAS-Installationsordner setzen
- Beigelegten Demand-Index-Indikator (`code/NqDemandIndex.cs`) bauen, DLL nach `Dokumente\ATAS\Indicators` kopieren, im NQ-Chart laden. **Ziel dieser Phase ist nicht der perfekte Indikator, sondern einmal den kompletten Weg Code → Build → Chart lebend zu sehen** — Fehler beim ersten Build sind erwartbar, siehe Hinweis im Code.

### Phase 1 — Analyse-Ebene (überarbeitet, 19.09.2026)
**Großteils schon vorhanden.** Mike hat aus dem RG-Trading-Kurs bereits eine komplette Indikator-Ausstattung in ATAS installiert und auf den richtigen Charts (NQ/ES) eingeteilt: Demand Index, Super Trend ("RG-Trading Academy Super Trend"), Heiken Ashi, Heiken Ashi Smoothed, Account Info Display, Depth of Market, VWAP/TWAP. Der `NqDemandIndex.cs`-Testindikator aus Phase 0 war nur ein Toolchain-Test (Code → Visual Studio → ATAS laden), kein Ersatz dafür — nicht als eigenständiger Baustein weiterverfolgen.

**Damit verschiebt sich der Fokus von Phase 1 direkt auf:**
- Location-Level-Erkennung (VAH/VAL/POC/Tageshoch-tief) — noch zu bauen
- Tageskontext-Regeln (Vortageshoch/-tief Ablehnung/Annahme, Trendtag-Erkennung) — braucht Punkt 3 der offenen Fragen (Cross-Instrument), noch zu bauen
- Offene technische Frage für später: ob eine neue Checklisten-Strategie die Werte der bereits vorhandenen Kurs-Indikatoren live auslesen kann, oder ob Demand Index/Supertrend intern nochmal nach der dokumentierten Formel berechnet werden müssen (robuster, unabhängig von fremdem Indikator-Code) — klärt sich, sobald wir an diesem Baustein arbeiten

### Phase 0 — abgeschlossen und bestätigt (19.09.2026)
`RgTradingIndicators.dll` lag zunächst in `Dokumente\ATAS\Indicators` (falscher, veralteter Pfad) und tauchte deshalb nicht in ATAS' Indikatorenliste auf — kein Log-Eintrag, ATAS hat den Ordner nie gescannt. Echter Ordner ist `AppData\Roaming\ATAS\Indicators` (siehe oben). Nach Kopieren dorthin + vollständigem Neustart (Task-Manager: alle "Platform"-Prozesse beenden) taucht "RG Demand Index" jetzt im Indikator-Manager unter "All" auf. **Kompletter Weg Code → Build → Deploy → ATAS-Ladung damit erstmals nachgewiesen funktionsfähig.**

### Phase 2 — Footprint-/Orderflow-Bestätigung
- Cluster-API bestätigt (19.09.2026, per IntelliSense gegen Mikes Installation gegengecheckt): `candle.Delta`, `candle.MaxDelta`, `candle.MinDelta`, `candle.GetAllPriceLevels()`, `candle.GetPriceVolumeInfo(price)`, `candle.MaxVolumePriceInfo` — direkt auf `IndicatorCandle`, keine Zusatz-API nötig
- Erster Baustein `code/NqFootprintDelta.cs`: zeigt Delta/MaxDelta/MinDelta als Rohwerte an (noch kein Ja/Nein-Signal)
- Ablehnungskerze/Delta-Logik in konkrete Zahlen-Schwellen übersetzen — **das kalibrieren wir an echten vergangenen Setups aus deinem Trading-Journal, nicht geraten**
- POC-Rücktest noch offen: das ist der Session-POC aus dem bestehenden Volume-Profile-Indikator, nicht der POC einer einzelnen Kerze (`candle.MaxVolumePriceInfo` wäre nur die Kerze selbst) — eigener Baustein, noch zu klären ob Session-Profil selbst nachgebaut oder vom bestehenden Indikator mitgelesen wird

### Phase 3 — Order-Ausführung mit Risikomanagement
- Umschalter Halbautomatisch (nur Alarm) / Vollautomatisch (Order direkt)
- Risikoregeln fest im Code, nicht optional: ATR-basierter Stop, CRV min. 1:2, 1R = 200 € Lotgrößen-Berechnung (siehe [[Trading-Journal Struktur (1R = 200€)]]), Tagesverlust-Limit 500 $ als Kill-Switch (siehe [[Trading-Psychologie - Disziplin-Regelwerk]])
- Erst im Halbautomatik-Modus scharf testen (Alarm, du bestätigst manuell), bevor Vollautomatik überhaupt in Betracht kommt

### Phase 4 — Vollautomatik scharf schalten
- Voraussetzung: Phase 1–3 im Replay/Demo stabil UND Apex-Bot-Regel offiziell geklärt (siehe Blocker oben)
- Erst Demo-/Evaluation-Konto, das Funded-Konto erst nach echter Bewährung

## Phase 3 — Status (21.09.2026, erster Live-Test erfolgreich)
Erster echter Order-Test (`code/NqTestStrategy.cs`) hat ausgelöst: Demand-Index-Nulllinien-Kreuzung erkannt, Market-Buy-Order über 1 Kontrakt platziert und gefüllt, Konto **DEMO331DE**. Komplette Kette Signal → Order → Fill damit erstmals nachgewiesen funktionsfähig.

**Wichtiger Fund:** Obwohl der Code selbst kein Stop-Loss/Take-Profit setzt, hat ATAS automatisch SL (-50 Ticks) und TP (+100 Ticks) an die Order gehängt — über Mikes eigene **"SL/TP Standardvorlage"** im Trading-Panel, die offenbar auf jede Order des Kontos greift, auch von der Strategie platzierte. 50:100 Ticks entspricht CRV 1:2, dem Minimum aus der Checkliste. Position wird dadurch vermutlich automatisch per Bracket-Order geschlossen, kein manuelles Eingreifen nötig. **Offene Frage:** ob wir uns dauerhaft auf diese feste Ticks-Vorlage verlassen oder wie geplant einen eigenen ATR-basierten, dynamischen Stop im Code bauen (siehe Phase 3 unten) — Mikes Entscheidung, sobald die Checkliste weiter steht.

**Zwischenfall während der Einrichtung (19./20.09.2026):** Nach vielen ATAS-Neustarts während der Entwicklung wurden alle Chart-Fenster grau/unbedienbar, während gleichzeitig die Rithmic-Verbindungen (APEX und ein zweites Konto) mit "Repository Connection Login Failed" fehlschlugen. Ursache nicht abschließend geklärt (DLL testweise entfernt UND Rechner neu gestartet, beides zusammen hat es behoben) — die eigene DLL kann als Auslöser nicht sicher ausgeschlossen werden, auch wenn die Rithmic-Login-Fehler eher wie ein separates, brokerseitiges Problem aussehen. Falls sich Chart-Probleme nach künftigen DLL-Updates wiederholen: DLL zuerst testweise aus beiden Ordnern entfernen, um es einzugrenzen.

## Nächster Schritt
Sobald der Markt wieder offen ist: prüfen ob die Test-Order tatsächlich auslöst. Danach: Stop-Loss/Take-Profit ergänzen (OCOGroup/TriggerPrice, siehe Order-Felder oben) und den Halb-/Vollautomatik-Umschalter als echten UI-Parameter einbauen.

## Referenzen
- [[NQ Abpraller-Setup Checkliste]]
- [[RG-Trading Indikator - Demand Index]]
- [[RG-Trading Indikator - Supertrend]]
- [[RG-Trading Indikator - ATR (Average True Range)]]
- [[Trading-Psychologie - Disziplin-Regelwerk]]
- [[Trading-Journal Struktur (1R = 200€)]]
- [[Apex Trader Funding - 50k Auszahlungsregeln]]
- [[Trading]]
