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

## Phase 1 — Tageskontext gelöst (21.09.2026, ohne Cross-Instrument-API)
`ICrossTradingIndicatorContext` (Service nicht registriert, Laufzeitfehler bestätigt per ATAS-Logs-Panel) und `ICandlesDataProvider` (Typ existiert nicht in dieser ATAS-Version 8.0.14.399, per Objektkatalog bestätigt) funktionieren beide nicht — die öffentliche ATAS-Doku beschreibt eine andere SDK-Version. Nebenfund: ATAS' eigenes "Cross Trading"-Feature ist vermutlich etwas anderes (Handelsvorlagen-Synchronisierung zwischen korrelierten Rohstoff-Gruppen wie S&P 500/Crude Oil/Bitcoin/Ether, nicht Kerzendaten eines zweiten Instruments lesen).

**Lösung:** Da ATAS als ein Prozess läuft, wenn ES- und NQ-Chart gleichzeitig offen sind, reicht ein statisches Feld als "Briefkasten" zwischen zwei separaten Indikatoren — kein Cross-Instrument-API nötig. Drei Dateien:
- `code/TageskontextState.cs` — gemeinsamer statischer Speicher (`TagesRichtung`-Enum: Neutral/Long/Short)
- `code/EsTageskontext.cs` — läuft auf dem ES-Chart, erkennt Vortageshoch/-tief-Ablehnung/Akzeptanz (Checkliste Regel 1, höchste Priorität), schreibt Richtung in den State
- `code/NqTestStrategy.cs` — liest die Richtung, handelt jetzt **bidirektional** (Long UND Short), aber nur wenn Demand-Index-Signal UND Tageskontext-Richtung übereinstimmen

**Voraussetzung:** ES-Chart und NQ-Chart müssen gleichzeitig offen sein, "RG Tageskontext (ES)" muss zusätzlich zum NQ-Chart auf einem ES-Chart aktiv laufen.

## Phase 1 — Location gelöst (21.09.2026, VAH/VAL/POC auf ES Range-US Chart)
Mike korrigierte eine Annahme: Location (Checkliste Punkt 3) wird **nicht** auf einem NQ- oder zeitbasierten ES-Chart berechnet, sondern auf seinem echten ES-Chart-Typ, per Screenshot bestätigt: Range-Chart mit Einstellung **"0/2/3R US"** (Chart-Tab "ES 0/2/3R US Chart", siehe [[RangeUS Chart (Kontext für Setups)]]).

**Neue Datei `code/EsLocation.cs`**, läuft auf genau diesem Chart:
- Baut aus den Kerzen-Cluster-Daten ein Session-Volume-Profil auf: Preis → kumuliertes Volumen. API dafür per Objektkatalog bestätigt (21.09.2026, nach einem ersten falschen Build-Versuch): `candle.GetAllPriceLevels()` gibt direkt eine Liste von `ATAS.Indicators.PriceVolumeInfo`-Objekten zurück (Member: `Ask`, `Between`, `Bid`, `Price`, `Ticks`, `Time`, `Volume`) — Preis und Volumen stecken schon in jedem Element, ein zusätzlicher `candle.GetPriceVolumeInfo(price)`-Aufruf ist unnötig (erste Fassung hatte das noch falsch angenommen, Build-Fehler CS1503 — korrigiert)
- Daraus POC (meistes Volumen) und VAH/VAL nach der Standard-Value-Area-Methode (vom POC aus abwechselnd die Seite mit mehr Volumen dazunehmen, bis 70% des Gesamtvolumens erreicht sind). **70% ist der Branchenstandard, von mir angenommen, nicht einzeln von Mike bestätigt** — bei Bedarf leicht änderbar (`ValueAreaPercent`-Konstante)
- Erkennt Ablehnung an VAH/VAL (High/Low toucht die Linie, Kerze schließt wieder auf der anderen Seite — gleiches Muster wie die Vortageshoch/-tief-Regel in `EsTageskontext.cs`), schreibt Ergebnis in `LocationState.Richtung`. Anders als `TageskontextState.Richtung` (gilt den ganzen Tag) ist das ein kurzer Impuls, der bei jeder abgeschlossenen Kerze neu gesetzt wird
- POC selbst wird bewusst NICHT als Ablehnungs-Level behandelt (wirkt eher wie ein Pivot/Magnet als wie Support/Resistance) — der POC-Rücktest aus Checkliste Punkt 4 (NQ-Footprint-Setup) bleibt ein eigener, separater Baustein, siehe `NqFootprintDelta.cs`
- **Wichtig zum Instrument:** POC/VAH/VAL sind ES-Preise, kein direkter Vergleich mit NQ-Kursen — Checkliste Punkt 3 (Location) prüft ES-Reaktion an der eigenen Location, Punkt 4 (Setup) prüft separat NQ-Bestätigung im selben Moment; erst beide zusammen ergeben den Einstieg

**Neue Datei `code/LocationState.cs`** — gleicher "Briefkasten"-Mechanismus wie `TageskontextState.cs`.

**`NqTestStrategy.cs` erweitert:** Einstieg jetzt an drei Bedingungen gebunden statt zwei — Demand-Index-Kreuzung (NQ) UND Tageskontext-Richtung (ES M15) UND Location-Richtung (ES Range-US), alle drei müssen in dieselbe Richtung zeigen. Damit ist Checkliste Punkt 1 UND Punkt 3 jetzt umgesetzt (Punkt 4 Setup/Footprint/Orderflow und Punkt 5 Trade-Management bleiben offen, siehe unten).

**Nebenbei behoben:** `EsTageskontext.cs` hatte noch die "nur letzte Kerze"-Bremse aus der Order-Strategie kopiert (`if (bar < CurrentBar - 1) return;`). Für einen reinen Zustands-Indikator ohne Order-Wirkung ist das falsch — dadurch hätte der Indikator beim Laden/Neustart von ATAS das Vortageshoch/-tief NICHT aus der Historie übernommen, sondern erst nach dem nächsten LIVEN Sessionwechsel, bis dahin wäre `TageskontextState.Richtung` immer Neutral geblieben (kein Trade möglich, obwohl sonst alles gepasst hätte). Entfernt — verarbeitet jetzt bewusst die volle Historie beim Laden, reagiert danach unverändert live weiter. Gleiches Muster (volle Historie verarbeiten) direkt so in `EsLocation.cs` übernommen.

## Erster Live-Test des Dreifach-Gates: zu restriktiv (21.09.2026)
Alle drei Charts liefen (Screenshots bestätigt: NQ-Strategie `[Started]`, ES-Tageskontext aktiv, ES-Location aktiv), aber Mikes Einschätzung nach kurzer Beobachtung: die Location-Prüfung nur gegen VAH/VAL ist "zu wenig" — auf seinem Chart reagiert der Preis erkennbar an ganz anderen Leveln (siehe sein Screenshot mit mehreren violetten Linien unterhalb des VAH). Sein Einwand: so bekommt der Bot praktisch nie einen vollständig bestätigten Trade rein.

## Location UND Setup deutlich erweitert (21.09.2026)
Zwei Erweiterungen auf Mikes konkretes Feedback:

**1. `EsLocation.cs` prüft jetzt gegen eine ganze Liste von Checkliste-Punkt-3-Leveln statt nur VAH/VAL:**
- VAH, VAL, POC (POC vorher bewusst ausgeschlossen als "Magnet statt Support/Resistance" — eigene Vorsicht, kein Mike-Wunsch; Checkliste listet POC aber explizit, jetzt mit drin)
- Vortageshoch/-tief, Tageshoch/-tief (eigenständig in `EsLocation.cs` nachgebaut, nicht von `EsTageskontext.cs` gelesen, damit beide Dateien unabhängig und im selben "nur abgeschlossene Kerzen"-Takt bleiben)
- **Neu: Ober-/Unterkante Volumenberg** (`FindVolumeClusterEdges()`) — findet zusammenhängende Preisbereiche mit Volumen ≥ 40% des POC-Volumens (eigene Heuristik, **noch nicht an echten Setups kalibriert**, Schwellenwert `VolumeClusterThreshold` bei Bedarf anpassen). Ein Tag kann mehrere solcher "Berge" haben, nicht nur den einen um den POC (den deckt VAH/VAL schon ab)
- Bewusst NICHT umgesetzt, mangels belastbarer Definition statt geraten: Single Prints (bräuchte TPO-/Zeitdaten, haben wir nicht), Range High/Low (Begriff mehrdeutig, noch mit Mike zu klären)
- Reagiert jetzt IRGENDEIN Level in die passende Richtung (Ablehnungsmuster wie bisher), wird das als Long/Short gewertet; widersprechen sich mehrere Level gleichzeitig, bleibt es sicherheitshalber Neutral

**2. `NqTestStrategy.cs` bekommt eine vierte Bedingung: Abpraller am Heiken-Ashi-Smoothed.** Mike hat an echten NQ-Rücksetzern gezeigt (Screenshot mit mehreren violetten Markierungen), dass der beste Bestätigungspunkt ist, wenn die Kerze am bereits geladenen "Heiken Ashi Smoothed"-Indikator abprallt (Low/High testet die geglättete Linie an, Schluss bleibt auf der Trendseite). Formel (Sylvain Vervoort, öffentlich bekannt, Parameter 10/10 wie Mikes geladener Indikator) intern selbst nachgerechnet statt den Fremd-Indikator auszulesen — gleiches Prinzip wie beim Demand Index/ATR, hat sich als robuster erwiesen. **Wichtig:** das ist reine Mathematik, keine über den Objektkatalog verifizierbare API — einmal visuell gegenprüfen, ob unsere berechnete Linie zur sichtbaren Indikator-Linie passt.

**Einstieg braucht jetzt VIER übereinstimmende Bedingungen:** Demand-Index-Kreuzung (Trigger) + Tageskontext-Richtung + Location-Richtung (erweitert) + Heiken-Ashi-Smoothed-Abpraller, alle in dieselbe Richtung. Damit ist Checkliste Punkt 1, 3 und ein zusätzliches, von Mike beobachtetes NQ-Bestätigungsmuster umgesetzt (Punkt 4 Setup/Footprint/Orderflow aus der ursprünglichen Checkliste bleibt trotzdem noch offen, siehe unten — der HA-Smoothed-Abpraller ergänzt das, ersetzt es nicht).

## Kein Trade am 22.09.2026 — zwei echte Bugs gefunden und behoben
Mike meldete (Screenshot des "Handelsstrategien"-Panels): Strategie steht auf "Aktiv", aber Position/Preis/Offene/Geschlossen stehen alle bei 0 — am ersten vollen Handelstag mit allen vier Bedingungen hat noch kein einziger Order-Versuch stattgefunden.

**Zwei echte Code-Bugs in `NqTestStrategy.cs` gefunden (Codelesung, noch nicht an Mikes Installation verifiziert):**
1. Der Demand-Index-Kumulativwert (`_cumulative`) wurde erst berechnet, NACHDEM die "nur aktuelle Kerze"-Bremse (`if (bar < CurrentBar - 1) return;`) schon gegriffen hatte — anders als im Original-Indikator `NqDemandIndex.cs` (der bewusst die volle Historie ab Kerze 0 verarbeitet) startete der Kumulativwert hier bei jedem Neustart der Strategie künstlich bei 0 statt aus der echten Historie. Jede erste "Kreuzung" danach war ein Artefakt des Start-Zeitpunkts, keine echte Nulllinien-Kreuzung.
2. Weil `OnCalculate` pro Tick feuert (nicht nur pro abgeschlossener Kerze) und die Kumulativ-Berechnung keine "nur einmal pro Kerze"-Bremse hatte (anders als `UpdateHeikenAshiSmoothed`/`EsLocation.cs` mit ihrem `_lastHaProcessedBar`/`_lastAddedBar`-Muster), wurde bei jedem Preis-Tick der noch laufenden Kerze ihr Volumen-Anteil ERNEUT aufaddiert statt einmalig — der interne Kumulativwert lief mit jedem Tick weiter von der tatsächlich im Chart sichtbaren Demand-Index-Linie weg. Derselbe Fehler steckte in `UpdateAtr` (jetzt `AdvanceAtr`) und hat den ATR (damit Stop/Ziel-Abstand) auf dieselbe Art verfälscht.

**Fix:** ATR und Demand-Index-Kumulativ laufen jetzt über denselben "nur einmal pro abgeschlossener Kerze"-Mechanismus wie `UpdateHeikenAshiSmoothed` (`_lastConfirmedBar`), verarbeiten dabei bewusst die volle Historie beim Laden (wie `NqDemandIndex.cs`). Die Kreuzungsprüfung selbst bleibt bewusst tick-reaktiv (reagiert sofort, nicht erst beim Kerzenabschluss) — der Live-Wert der laufenden Kerze wird pro Tick frisch aus dem bestätigten Vorwert plus aktuellem Tick-Stand neu berechnet statt draufaddiert.

**Wahrscheinlichster Hauptgrund bleibt aber wohl eher struktureller Natur statt reiner Bug:** Alle vier Bedingungen müssen auf derselben NQ-Kerze zusammentreffen, aber `LocationState.Richtung` (aus `EsLocation.cs`, läuft auf dem ES Range-Chart) ist laut eigenem Design nur ein **kurzer Impuls** — gilt nur ab der Kerze, auf der die Reaktion erkannt wurde, bis zur nächsten abgeschlossenen ES-Range-Kerze, dann fällt sie zurück auf Neutral, falls die neue Kerze keine eigene Reaktion zeigt. Range-Kerzen schließen unregelmäßig (erst wenn ein bestimmter Preisbereich durchlaufen ist), NQ-Zeitkerzen dagegen regelmäßig — die Wahrscheinlichkeit, dass Demand-Index-Kreuzung, Tageskontext, Location-Impuls UND Heiken-Ashi-Abpraller exakt zur gleichen Zeit zusammentreffen, ist dadurch strukturell sehr klein. Das deckt sich mit Mikes eigener Beobachtung vom 21.09.2026 ("zu restriktiv, so kriegen wir keinen Trade rein") — danach wurde aber eine VIERTE Bedingung ergänzt statt die Zeitfenster zu lockern, was die Restriktivität weiter erhöht statt sie zu lösen. Das ist keine Vermutung, die ich einfach umgesetzt habe (bewusst nicht selbst gelockert, das ist Kalibrierung/Design, keine Bugfix-Entscheidung) — offene Frage an Mike, siehe unten.

**Zusätzlich: Diagnose-Plots ergänzt, damit sich "warum kein Trade" ab jetzt am Chart ablesen statt raten lässt.** `EsTageskontext.cs` und `EsLocation.cs` liefen bisher komplett unsichtbar im Hintergrund — kein Weg für Mike zu sehen, was `TageskontextState.Richtung`/`LocationState.Richtung` gerade sind. Beide zeigen jetzt einen Plot (-1 Short/0 Neutral/1 Long) auf ihrem jeweiligen Chart. `NqTestStrategy.cs` zeigt zusätzlich die intern berechnete Heiken-Ashi-Smoothed-Linie (deckt den seit 21.09.2026 offenen Verifikations-Punkt "optisch mit der geladenen Indikator-Linie vergleichen" ab) und einen Zähler "Bedingungen erfüllt (0-4)". **Nicht verifiziert:** ob `DataSeries` auf einer `ChartStrategy` (statt einem reinen `Indicator`) genauso funktioniert — bei den ES-Indikatoren und den beiden bestehenden Indikatoren (`NqDemandIndex.cs`/`NqFootprintDelta.cs`) ist das Muster bestätigt, bei `NqTestStrategy.cs` zum ersten Mal eingesetzt. Beim nächsten Build prüfen ob die zwei Plots im NQ-Chart erscheinen.

**Offene Frage beantwortet — Einstiegslogik komplett neu (22.09.2026, Mikes Klarstellung per Sprachnachricht):** Statt "alle vier Bedingungen gleichzeitig auf derselben Kerze" jetzt eine echte SEQUENZ, siehe großer Kommentarblock oben in `NqTestStrategy.cs`:

1. **Tageskontext** gibt die Richtung vor (unverändert) — hat laut Mike praktisch immer einen Wert, kein "dazwischen".
2. **Location ist eine Preis-ZONE, kein Punkt.** Verlässt der Preis die Zone in Kontext-Richtung (Mikes Beispiel: Kontext Long, Location 3000-3010, Preis kommt von oben rein und verlässt die Zone wieder über 3010), wird `LocationState.Richtung` **"scharf" (armed)** — und bleibt das jetzt bestehen (nicht mehr nur eine Kerze lang), bis sie von einem Trade verbraucht, von einer neuen Reaktion überschrieben, oder von der nächsten ES-Session zurückgesetzt wird. Das war der eigentliche Grund für "kein Trade": mit nur einer Kerze Gültigkeit traf das praktisch nie mit dem unabhängig getakteten NQ-Rücksetzer zusammen.
3. Erst während Location scharf ist: NQ wird auf einen **Rücksetzer zum Heiken-Ashi-Smoothed** geprüft — muss die Linie laut Mike nicht exakt berühren, leichtes Überschießen ist ok (ATR-basierte Toleranz, `HaProximityAtrFraction`, noch nicht kalibriert).
4. Danach **1-2 weitere NQ-Kerzen** auf eine Bestätigungskerze warten, die in Kontext-Richtung schließt ("damit der Einstieg möglichst gut ist"). Kommt keine, verfällt das Setup.
5. **Erst an der Bestätigungskerze zählt der Demand Index** — laut Mike explizit NIE der Auslöser selbst, sondern reines Vorzeichen-Filter: muss zu dem Zeitpunkt auf der Kontext-Seite der Nulllinie stehen. Deckt beide von Mike beschriebenen Fälle ab (frisch aus einem Extrem durch die Nulllinie gekreuzt, ODER die ganze Zeit schon richtig gestanden und nur kurz zur Nulllinie zurückgekommen). "Große Order-Interesse" als Stärke-Kriterium bewusst NICHT formalisiert (kein Schwellenwert von Mike genannt) — reines Vorzeichen ist die unkalibrierte Vereinfachung.

Umgesetzt in `NqTestStrategy.cs` (neuer `_pendingDirection`/`_pendingDeadlineBar`-Zustand, `CheckHaProximity` statt `CheckHaSmoothedBounce`) und `EsLocation.cs`/`LocationState.cs` (Richtung wird bei "keine Reaktion" nicht mehr auf Neutral zurückgesetzt, siehe `CheckReaction`). Drei Diagnose-Plots ergänzt: HA-Smoothed-Linie, interner Demand-Index-Kumulativwert (Abgleich mit der echten Chart-Linie) und Setup-Stufe (0/1/2).

**Alle drei Codebugs vom Vormittag (Kumulativwert nicht aus Historie geseedet, Tick-Compounding bei Demand Index/ATR) bleiben unabhängig davon behoben** — die Sequenz-Logik baut direkt darauf auf.

## Diagnose-Plots doch nicht sichtbar — DataSeries auf ChartStrategy rendert nicht (22.09.2026)
Mike hat gebaut und getestet: Build fehlerfrei, Strategie komplett vom NQ-Chart entfernt und frisch neu hinzugefügt (nicht nur ATAS neu gestartet) — trotzdem keiner der drei Plots sichtbar, weder auf dem Chart noch in der Indikatorenliste. Das bestätigt den bereits vorher markierten unverifizierten Punkt: `DataSeries` auf einer `ChartStrategy` wird in dieser ATAS-Version offenbar grundsätzlich nicht gezeichnet, anders als bei einem reinen `Indicator` (wo es bei `NqDemandIndex.cs`, `NqFootprintDelta.cs`, `EsTageskontext.cs`, `EsLocation.cs` bestätigt funktioniert).

**Fix:** Diagnose-Anzeige in eine separate Datei ausgelagert, gleiches "Briefkasten"-Prinzip wie bei `TageskontextState.cs`/`LocationState.cs`, nur in umgekehrter Richtung:
- **`NqDiagnosticsState.cs`** (neu) — statischer Speicher für die drei Werte (HA-Smoothed-Linie, interner Demand Index, Setup-Stufe)
- **`NqTestStrategy.cs`** schreibt jetzt in `NqDiagnosticsState` statt in eigene `ValueDataSeries` (die drei Felder + `DataSeries[0]`/`.Add()` im Konstruktor wieder entfernt)
- **`NqDiagnostics.cs`** (neu) — ein separater, reiner `Indicator` (kein `ChartStrategy`), der nur `NqDiagnosticsState` ausliest und zeichnet. **Muss zusätzlich zur Strategie auf dem NQ-Chart hinzugefügt werden** — über den normalen Indikatoren-Button, genau wie "RG Demand Index" oder "RG Footprint Delta", nicht über die Handelsstrategien-Liste.

## Diagnose-Panel doch nur teilweise sichtbar — eine gemeinsame Skala für alle drei Werte (22.09.2026)
`NqDiagnostics.cs` (ein Indicator, drei DataSeries) bekam zwar ein eigenes Panel, aber alle drei Werte teilten sich darin EINE Skala. `HA-Smoothed (intern)` liegt bei echten NQ-Preisen (~30.900), `Demand Index (intern)` bei ca. -100 bis 100, `Setup-Stufe` bei 0-2 — die große Zahl drückt die beiden kleinen komplett an den unteren Rand, praktisch unsichtbar (per Screenshot bestätigt: leeres Panel bis auf eine flache Linie).

**Fix:** `NqDiagnostics.cs` in drei separate Indicator-Klassen aufgeteilt, jede mit genau einem Wert und eigener Skala: `NqDiagnosticsSetupStage` ("RG Setup-Stufe (0/1/2)", die wichtigste), `NqDiagnosticsDemandIndex` ("RG Demand Index (intern)"), `NqDiagnosticsHaSmoothed` ("RG HA-Smoothed (intern)"). Alle drei lesen weiterhin denselben `NqDiagnosticsState`-Briefkasten, keine Änderung an `NqTestStrategy.cs` nötig. Müssen einzeln zum NQ-Chart hinzugefügt werden.

## Diagnose-Panels zeigten dann doch nichts mehr — Wiederholung des Assembly-Lade-Vorfalls vom 19./20.09. (22.09.2026)
Nach dem letzten Build zeigten "RG Demand Index (intern)" und "RG Setup-Stufe" eine flache 0-Linie, obwohl die Strategie als "Aktiv" gelistet war, und "RG HA-Smoothed (intern)" war laut Mike erst kurz sichtbar, dann verschwunden. ATAS-Logs-Panel (Mikes Screenshot, 22.09.2026 17:15:03) zeigte die Ursache: **`Could not load assembly 'RgTradingIndicators, Version=1.0.0.0...'`** für ALLE unsere Klassen gleichzeitig (`EsTageskontext`, `EsLocation`, alle drei `NqDiagnostics*`) — UND für Mikes komplett unabhängiges, altes Kurs-Indikator `RG-Trading Acedemy Super Trend`. Direkt daneben in den Logs, zur selben Sekunde: Rithmic-/dxFeed-/IQ-Verbindungen scheitern mit Login-/Auth-Fehlern.

**Das ist derselbe Vorfall wie am 19./20.09.2026** (siehe oben, Abschnitt "Zwischenfall während der Einrichtung"): nach vielen schnellen ATAS-Neustarts während intensiver Entwicklung brechen Assembly-Laden UND Broker-Verbindungen gleichzeitig zusammen. Kein Code-Bug — die Menge an DLL-Austauschen/Neustarts in kurzer Zeit heute (mindestens 6-7 Runden) hat vermutlich denselben Effekt ausgelöst. Ursache weiterhin nicht abschließend geklärt, aber die damalige Abhilfe (DLL testweise aus beiden Ordnern entfernen + kompletter Rechner-Neustart, nicht nur ATAS) hatte schon einmal geholfen — Mike wendet das jetzt erneut an.

**Wichtige Erkenntnis für Diagnose-Runden mit vielen schnellen Iterationen:** Bei "zeigt nichts an"/"war da, dann weg"-Symptomen zuerst das ATAS-Logs-Panel auf `Could not load assembly` prüfen, bevor an der eigentlichen Code-Logik weitergesucht wird — spart potenziell mehrere Debugging-Runden.

## Reset half nicht — Demand Index/Setup-Stufe bleiben bei 0, systematisch ausgeschlossen (22.09.2026)
Kompletter Rechner-Neustart brachte keine Besserung. Systematisch durchgeprüft und ausgeschlossen: Assembly-Ladefehler im Logs-Panel sind irrelevant (Mikes unabhängiges Kurs-Indikator `RG-Trading Acedemy Super Trend` läuft trotz identischer Fehlermeldung einwandfrei, und `RgTrading.Indicators.EsTageskontext`/`EsLocation` aus derselben DLL liefern nachweislich echte Daten). Strategie steht auf "Aktiv", wurde laut Mike bereits mehrfach komplett entfernt und neu hinzugefügt. Kein offenes Position/Order-Buch (`CurrentPosition != 0`-Sperre damit ausgeschlossen).

**Verbleibender Verdacht:** `NqTestStrategy.OnCalculate` schrieb `DemandIndexLive`/`SetupStage` bisher erst NACH zwei Bedingungen (keine offene Position UND fertiger ATR, 14 Perioden) — blieb eine davon unerfüllt, wurde gar nichts geschrieben, von außen nicht unterscheidbar von "legitim 0". Da die offene-Position-Sperre ausgeschlossen ist, bleibt der ATR-Status als letzte unbestätigte Variable.

**Fix/Diagnose (22.09.2026):** `NqDiagnosticsState` um `AtrValue` (nullable decimal) erweitert, vierter Anzeige-Indikator `NqDiagnosticsAtr` ("RG ATR-Wert (Strategie)") ergänzt. `NqTestStrategy.cs` schreibt `DemandIndexLive` und `AtrValue` jetzt UNBEDINGT, bevor die Positions-/ATR-Prüfungen überhaupt greifen — bei den beiden Sperren wird `SetupStage` jetzt explizit auf 0 gesetzt statt implizit stehen zu bleiben.

## Nächster Schritt
Mike baut die drei geänderten Dateien (`NqDiagnosticsState.cs`, `NqDiagnostics.cs`, `NqTestStrategy.cs`), fügt "RG ATR-Wert (Strategie)" zusätzlich zum NQ-Chart hinzu. Entscheidender Test: zeigt "RG Demand Index (intern)" jetzt endlich Bewegung (jetzt unbedingt geschrieben)? Und zeigt "RG ATR-Wert (Strategie)" überhaupt eine Zahl, oder bleibt der leer (= ATR wird nie fertig, nächster Ansatzpunkt wäre dann `AdvanceAtr`/die `_lastConfirmedBar`-Schleife selbst)? Rest wie gehabt: Halb-/Vollautomatik-Umschalter als echten UI-Parameter einbauen, restliches Setup/Footprint/Orderflow (Checkliste Punkt 4) einbeziehen, Footprint- und Volumenbergkanten-Schwellen sowie `HaProximityAtrFraction`/`ConfirmationWindowBars` an echten Setups kalibrieren, Single Prints/Range High-Low klären.

## Referenzen
- [[NQ Abpraller-Setup Checkliste]]
- [[RG-Trading Indikator - Demand Index]]
- [[RG-Trading Indikator - Supertrend]]
- [[RG-Trading Indikator - ATR (Average True Range)]]
- [[Trading-Psychologie - Disziplin-Regelwerk]]
- [[Trading-Journal Struktur (1R = 200€)]]
- [[Apex Trader Funding - 50k Auszahlungsregeln]]
- [[Trading]]
