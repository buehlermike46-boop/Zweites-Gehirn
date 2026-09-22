// Phase 3 — Order-Platzierung mit ATR-basiertem Stop/Ziel, Tageskontext-Richtung, Location UND
// Heiken-Ashi-Smoothed-Rücksetzer. Siehe Projekt-Notiz im übergeordneten Ordner. Läuft nur auf
// dem Demo-Konto (DEMO331DE, bestätigt 20.09.2026).
//
// EINSTIEGSLOGIK NEU 22.09.2026 (Mikes Klarstellung per Sprachnachricht, nachdem am 22.09. trotz
// aktiver Strategie kein einziger Trade ausgelöst hatte). Vorher: alle vier Bedingungen mussten
// auf DERSELBEN NQ-Kerze gleichzeitig zutreffen — strukturell fast unmöglich, weil
// LocationState.Richtung (ES-Chart) nur eine Kerze lang galt, während der NQ-Rücksetzer auf
// einem komplett unabhängigen Takt läuft. Jetzt eine echte SEQUENZ, keine Gleichzeitigkeits-
// Prüfung mehr:
//
// 1. Tageskontext (siehe EsTageskontext.cs) gibt die Richtung vor — gilt für den ganzen Tag,
//    hat laut Mike praktisch immer einen Wert (Long oder Short, kein "dazwischen").
// 2. Location (siehe EsLocation.cs) ist eine Preis-ZONE. Verlässt der Preis diese Zone in
//    Kontext-Richtung (z.B. Kontext Long, Preis kommt von oben in die Zone, verlässt sie wieder
//    nach oben), wird LocationState.Richtung "scharf" (armed) — und bleibt das jetzt, bis sie
//    verbraucht/überschrieben/per Sessionwechsel zurückgesetzt wird (siehe LocationState.cs).
//    Das ersetzt die alte "nur eine Kerze gültig"-Regel, die der eigentliche Grund für die
//    ausbleibenden Trades war.
// 3. Erst WÄHREND Location scharf ist: NQ wird auf einen Rücksetzer zum Heiken-Ashi-Smoothed
//    geprüft (CheckHaProximity) — muss die Linie laut Mike nicht exakt berühren, leichtes
//    Überschießen ist auch ok (ATR-basierte Toleranz, siehe HaProximityAtrFraction).
// 4. Danach WARTEN wir 1-2 weitere NQ-Kerzen auf eine Bestätigungskerze, die in Kontext-Richtung
//    schließt (Mike: "damit der Einstieg möglichst gut ist"). Kommt keine innerhalb des Fensters,
//    verfällt das Setup wieder (_pendingDeadlineBar).
// 5. Erst AN der Bestätigungskerze zählt der Demand Index — NIE als eigener Auslöser (Mikes
//    Worte: "nie der Auslöser für ein Trade"), sondern als reines Vorzeichen-Filter: er muss zu
//    diesem Zeitpunkt auf der Kontext-Seite der Nulllinie stehen (deckt beide von Mike
//    beschriebenen Fälle ab: frisch aus einem Extrem durch die Nulllinie gekreuzt, ODER die
//    ganze Zeit schon auf der richtigen Seite gewesen und nur kurz zur Nulllinie zurückgekommen).
//    "Große Order-Interesse" als Stärke-/Magnitude-Kriterium wurde bewusst NICHT versucht zu
//    formalisieren (bräuchte einen kalibrierten Schwellenwert, den Mike nicht genannt hat) —
//    reines Vorzeichen ist die konservative, unkalibrierte Vereinfachung, bei Bedarf später
//    verschärfen.
// Stimmen alle fünf Schritte, erst dann Order. Genau wie vorher: lieber kein Trade als einer
// ohne vollständige Bestätigung — nur ist die Zeitfenster-Logik jetzt realistisch statt
// strukturell fast unerreichbar.
//
// Heiken-Ashi-Smoothed-Formel (Sylvain Vervoort, öffentlich bekannt, KEINE ATAS-eigene API,
// deshalb selbst nachgerechnet statt den bereits geladenen "Heiken Ashi Smoothed"-Indikator
// auszulesen):
//   1. Rohe OHLC erst mit EMA(Länge1) glätten
//   2. Aus den geglätteten Werten normale Heiken-Ashi-Kerzen berechnen
//   3. Deren Open/Close nochmal mit EMA(Länge2) glätten -> Ergebnis ist die geplottete Linie
// Länge1 = Länge2 = 10, wie bei Mikes geladenem Indikator ("Heiken Ashi Smoothed (Bars, 10, 10,
// True)"). Seit 22.09.2026 über NqDiagnosticsState/NqDiagnostics.cs als eigener Plot sichtbar
// (siehe unten) für den optischen Abgleich mit der geladenen Indikator-Linie.
//
// WICHTIG: EsTageskontext.cs UND EsLocation.cs müssen laufen (auf zwei separaten ES-Charts),
// sonst bleiben TageskontextState.Richtung/LocationState.Richtung dauerhaft "Neutral" und diese
// Strategie handelt nie.
//
// Seit 21.09.2026 (Mikes Wunsch): kein "nur einmal für immer" mehr, sondern erneuter Einstieg
// erlaubt sobald CurrentPosition wieder 0 ist (keine offene Position mehr) — Mike kann die
// Strategie außerdem jederzeit selbst über "IsActivated" stoppen.
//
// Stop-Loss (1,5x ATR) und Take-Profit (3x ATR, CRV 1:2) werden nach dem tatsächlichen Fill
// automatisch nachgeschickt, verknüpft über OCOGroup. ATR-Formel nach
// [[RG-Trading Indikator - ATR (Average True Range)]]. OnNewMyTrade unterscheidet
// Eröffnungs- von Schluss-Trades (per CurrentPosition), damit beim Schließen einer Position
// (Stop/Ziel gegriffen) nicht versehentlich ein neues Bracket gesetzt wird.
//
// Order-Klasse (ATAS.DataFeedsCore.Order), Enums (OrderDirections, OrderTypes) und
// MyTrade.Price per Objektkatalog/Testbuild gegen die echte ATAS-Installation bestätigt,
// 19.-21.09.2026.
//
// ZWEI BUGS BEHOBEN 22.09.2026 (Grund, warum der Strategie-Zustand vor der obigen Neufassung
// ohnehin schon von der echten Marktlage abgedriftet war — Mikes Meldung samt Screenshot:
// Strategie "Aktiv", aber Position/Preis/Offene/Geschlossen alle 0):
//   a) Der Demand-Index-Kumulativwert (_cumulative) wurde erst berechnet, NACHDEM die
//      "nur aktuelle Kerze"-Bremse (`if (bar < CurrentBar - 1) return;`) schon gegriffen hatte —
//      anders als in NqDemandIndex.cs (dem Original-Indikator, der bewusst die volle Historie ab
//      bar 0 verarbeitet) startete der Kumulativwert hier also nicht aus der echten Historie,
//      sondern bei jedem Neustart der Strategie künstlich bei 0.
//   b) Weil OnCalculate pro Tick feuert (nicht nur pro abgeschlossener Kerze) und die
//      Kumulativ-Berechnung KEINE "nur einmal pro Kerze"-Bremse hatte, wurde bei jedem Preis-Tick
//      der noch laufenden Kerze ihr Volumen-Anteil ERNEUT aufaddiert statt einmalig. Gleicher
//      Fehler steckte in UpdateAtr (jetzt AdvanceAtr) und hat den ATR (damit Stop/Ziel-Abstand)
//      auf dieselbe Art verfälscht.
//   Fix: ATR und Demand-Index-Kumulativ laufen jetzt über denselben "nur einmal pro
//   abgeschlossener Kerze"-Mechanismus wie UpdateHeikenAshiSmoothed (_lastConfirmedBar),
//   verarbeiten dabei bewusst die volle Historie beim Laden (wie NqDemandIndex.cs). Die
//   Live-Auswertung (Rücksetzer-/Bestätigungs-/Vorzeichen-Prüfung) bleibt bewusst tick-reaktiv —
//   dafür wird der Live-Wert der aktuell laufenden Kerze pro Tick frisch aus dem bestätigten
//   Vorwert plus dem aktuellen Tick-Stand neu berechnet statt draufaddiert.
//
// Vier Diagnose-Werte (22.09.2026, erweitert um den ATR-Wert selbst nach einer langen erfolglosen
// Fehlersuche), damit sich "warum kein Trade" am Chart ablesen statt raten lässt: HA-Smoothed-
// Linie, interner Demand-Index-Kumulativwert (Abgleich mit der echten "RG Demand Index"-Linie),
// die aktuelle Setup-Stufe (0 = kein Setup, 1 = Rücksetzer erkannt/wartet auf Bestätigungskerze,
// 2 = Bestätigungskerze da, Vorzeichen wird geprüft) und der ATR-Wert selbst.
//
// BESTÄTIGT 22.09.2026 (Mikes Test): DataSeries auf einer ChartStrategy wird in dieser
// ATAS-Version NICHT im Chart angezeigt — Build fehlerfrei, Strategie frisch neu hinzugefügt,
// trotzdem kein einziger Plot sichtbar. Deshalb schreibt diese Strategie die Werte jetzt in
// den Briefkasten `NqDiagnosticsState` (gleiches Muster wie TageskontextState/LocationState),
// und SEPARATE reine Indicator-Klassen (`NqDiagnostics.cs`) lesen ihn und zeichnen die Plots —
// müssen zusätzlich zur Strategie auf dem NQ-Chart hinzugefügt werden, siehe Kommentar dort.
//
// ERWEITERT 22.09.2026 (nach stundenlanger Fehlersuche ohne Ergebnis: Demand Index/Setup-Stufe
// blieben trotz Strategie "Aktiv", frisch hinzugefügt, komplettem Rechner-Neustart und leerem
// Positions-/Order-Buch bei 0 - selbst als die ES-seitigen Briefkästen TageskontextState/
// LocationState nachweislich funktionierten): Demand Index + ATR-Status werden jetzt UNBEDINGT
// geschrieben, bevor überhaupt geprüft wird ob eine Position offen ist oder der ATR fertig ist -
// vorher blieben beide Werte bei diesen (nicht von außen unterscheidbaren) Fällen einfach auf
// ihrem letzten Stand stehen. `NqDiagnosticsState.AtrValue` (neuer vierter Plot, "RG ATR-Wert
// (Strategie)") zeigt jetzt direkt, ob/wann die Strategie überhaupt genug Kerzen für einen
// fertigen ATR (14 Perioden) verarbeitet hat - unabhängig vom Rest der Logik.

using System;
using ATAS.DataFeedsCore;
using ATAS.Strategies.Chart;
using OFT.Attributes;

namespace RgTrading.Indicators
{
    [DisplayName("RG Test-Strategie (Demand Index)")]
    public class NqTestStrategy : ChartStrategy
    {
        // ATR-Parameter, siehe [[RG-Trading Indikator - ATR (Average True Range)]]
        private const int AtrPeriod = 14;
        private const decimal StopMultiplier = 1.5m;   // Stop = 1,5x ATR vom Einstieg
        private const decimal TargetMultiplier = 3m;    // Ziel = 3x ATR (CRV 1:2 zum Stop)
        private const decimal OrderQuantity = 1m;

        // Heiken-Ashi-Smoothed-Parameter, wie bei Mikes geladenem Indikator
        private const int HaSmoothPeriod1 = 10;
        private const int HaSmoothPeriod2 = 10;

        // Toleranz für "Rücksetzer zum Smoothed-Indikator, muss ihn nicht komplett berühren,
        // kann sich mal leicht drüber gehen" (Mike, 22.09.2026) — als Bruchteil des aktuellen
        // ATR, noch NICHT an echten Setups kalibriert (gleiches Prinzip wie
        // VolumeClusterThreshold in EsLocation.cs), Konstante bei Bedarf anpassen.
        private const decimal HaProximityAtrFraction = 0.25m;

        // Nach einem erkannten Rücksetzer: wie viele weitere Kerzen wir auf die Bestätigungskerze
        // warten ("auch gerne 2 Kerzen", Mike 22.09.2026).
        private const int ConfirmationWindowBars = 2;

        // Demand-Index-Kumulativ, Stand nach der letzten ABGESCHLOSSENEN Kerze (siehe Bugfix-
        // Kommentar oben). Gleiche Formel wie NqDemandIndex.cs.
        private decimal _cumulative;
        private OrderDirections _entryDirection;

        private decimal _atrSum;
        private decimal? _atr;

        // Bar-Index bis zu dem ATR + Demand-Index-Kumulativ bereits verarbeitet sind — gleiches
        // Muster wie _lastHaProcessedBar, verhindert Mehrfachverarbeitung derselben Kerze bei
        // mehreren Ticks.
        private int _lastConfirmedBar = -1;

        private int _lastHaProcessedBar = -1;
        private decimal? _emaOpen1;
        private decimal? _emaHigh1;
        private decimal? _emaLow1;
        private decimal? _emaClose1;
        private decimal? _haOpen;
        private decimal? _haClose;
        private decimal? _haSmoothedLine;

        // Pending-Setup-Zustand für die neue Sequenz (siehe Kommentar oben): Neutral = kein
        // Setup unterwegs. Long/Short = Rücksetzer erkannt, wartet bis _pendingDeadlineBar auf
        // eine Bestätigungskerze NACH der Rücksetzer-Kerze (_pendingStartBar) — wichtig, weil
        // OnCalculate pro Tick feuert: ohne die Start-Bar-Prüfung könnte die Rücksetzer-Kerze
        // selbst auf einem späteren Tick noch als ihre eigene Bestätigungskerze durchgehen.
        private TagesRichtung _pendingDirection = TagesRichtung.Neutral;
        private int _pendingStartBar = -1;
        private int _pendingDeadlineBar = -1;

        public NqTestStrategy() : base(true)
        {
        }

        protected override void OnCalculate(int bar, decimal value)
        {
            UpdateHeikenAshiSmoothed(bar);

            // ATR + Demand-Index-Kumulativ nur EINMAL pro abgeschlossener Kerze fortschreiben,
            // nicht bei jedem Preis-Tick (Bugfix 22.09.2026, siehe Kommentar oben) — verarbeitet
            // dabei bewusst die volle Historie beim Laden, exakt wie NqDemandIndex.cs.
            while (_lastConfirmedBar < bar - 1)
            {
                _lastConfirmedBar++;
                AdvanceAtr(_lastConfirmedBar);
                AdvanceDemandIndex(_lastConfirmedBar);
            }

            if (_haSmoothedLine.HasValue)
                NqDiagnosticsState.HaSmoothedLine = _haSmoothedLine.Value;

            // Diagnose (22.09.2026): ATR-Status und Live-Demand-Index werden jetzt IMMER
            // geschrieben, auch bevor/falls die Handelslogik unten wegen offener Position oder
            // fehlendem ATR gar nicht erst startet. Vorher blieben Demand Index/Setup-Stufe in
            // dem Fall auf ihrem letzten (oder nie gesetzten) Wert stehen - von aussen nicht von
            // "legitim 0, kein Setup" zu unterscheiden. NqDiagnosticsState.AtrValue zeigt jetzt
            // explizit, ob der ATR ueberhaupt schon bereit ist (null = noch nicht genug Kerzen).
            // Live-Wert der laufenden Kerze wird pro Tick frisch aus dem bestätigten Kumulativ
            // (Stand vorherige Kerze) plus dem aktuellen Tick-Stand berechnet, nicht draufaddiert
            // (das war Bug b) oben).
            var candle = GetCandle(bar);
            var openPrice = candle.Open == 0 ? 1 : candle.Open;
            var relativeChange = (candle.Close - candle.Open) / openPrice;
            var volumeComponent = candle.Volume * relativeChange;
            var liveCumulative = _cumulative + volumeComponent;
            NqDiagnosticsState.AtrValue = _atr;
            NqDiagnosticsState.DemandIndexLive = liveCumulative;

            // Nicht auf historische Kerzen beim Laden reagieren, nur auf die aktuell laufende
            if (bar < CurrentBar - 1)
                return;

            // Schon eine offene Position -> kein neues Setup aufbauen, wartet bis sie flach ist
            if (CurrentPosition != 0)
            {
                _pendingDirection = TagesRichtung.Neutral;
                NqDiagnosticsState.SetupStage = 0;
                return;
            }

            // Ohne ATR-Wert (noch nicht genug Kerzen für 14 Perioden) kein Einstieg,
            // sonst könnten wir hinterher keinen Stop/Ziel berechnen, und die Rücksetzer-Toleranz
            // (ATR-basiert) wäre auch nicht berechenbar
            if (!_atr.HasValue)
            {
                NqDiagnosticsState.SetupStage = 0;
                return;
            }

            var stage = 0;

            // Schritt 4+5: bereits ein Rücksetzer-Setup unterwegs -> auf Bestätigungskerze +
            // Demand-Index-Vorzeichen prüfen (siehe Kommentar oben)
            if (_pendingDirection != TagesRichtung.Neutral)
            {
                var stillValid = bar <= _pendingDeadlineBar
                    && TageskontextState.Richtung == _pendingDirection
                    && LocationState.Richtung == _pendingDirection;

                if (!stillValid)
                {
                    _pendingDirection = TagesRichtung.Neutral;
                }
                else
                {
                    stage = 1;

                    // Bestätigungskerze muss NACH der Rücksetzer-Kerze kommen, nicht dieselbe
                    // sein (siehe Kommentar bei _pendingStartBar oben)
                    if (bar > _pendingStartBar)
                    {
                        var confirms = _pendingDirection == TagesRichtung.Long
                            ? candle.Close > candle.Open
                            : candle.Close < candle.Open;

                        if (confirms)
                        {
                            stage = 2;

                            var demandIndexAgrees = _pendingDirection == TagesRichtung.Long
                                ? liveCumulative > 0
                                : liveCumulative < 0;

                            if (demandIndexAgrees)
                            {
                                _entryDirection = _pendingDirection == TagesRichtung.Long ? OrderDirections.Buy : OrderDirections.Sell;
                                PlaceEntryOrder();
                            }

                            _pendingDirection = TagesRichtung.Neutral;
                        }
                    }
                }
            }

            // Schritt 2+3: kein Setup unterwegs -> prüfen ob Location gerade scharf ist UND NQ
            // jetzt einen Rücksetzer zum HA-Smoothed zeigt -> startet ein neues Bestätigungsfenster
            if (_pendingDirection == TagesRichtung.Neutral)
            {
                var haProximity = CheckHaProximity(bar);

                if (haProximity != TagesRichtung.Neutral
                    && haProximity == TageskontextState.Richtung
                    && haProximity == LocationState.Richtung)
                {
                    _pendingDirection = haProximity;
                    _pendingStartBar = bar;
                    _pendingDeadlineBar = bar + ConfirmationWindowBars;
                    stage = 1;
                }
            }

            NqDiagnosticsState.SetupStage = stage;
        }

        private void PlaceEntryOrder()
        {
            var order = new Order
            {
                Portfolio = Portfolio,
                Security = Security,
                Direction = _entryDirection,
                Type = OrderTypes.Market,
                QuantityToFill = OrderQuantity
            };

            OpenOrder(order);
        }

        // Demand-Index-Kumulativ, identische Formel wie NqDemandIndex.cs — Stand nach der letzten
        // abgeschlossenen Kerze. Bugfix 22.09.2026 (siehe Kommentar oben): verarbeitet jetzt
        // bewusst die volle Historie ab bar 0 und wird nur einmal pro Kerze aufgerufen (aus der
        // _lastConfirmedBar-Schleife), statt bei jedem Tick erneut draufzuaddieren.
        private void AdvanceDemandIndex(int completedBar)
        {
            if (completedBar == 0)
            {
                _cumulative = 0;
                return;
            }

            var candle = GetCandle(completedBar);
            var openPrice = candle.Open == 0 ? 1 : candle.Open;
            var relativeChange = (candle.Close - candle.Open) / openPrice;
            var volumeComponent = candle.Volume * relativeChange;

            _cumulative += volumeComponent;
        }

        // Bugfix 22.09.2026 (siehe Kommentar oben): wird jetzt nur noch einmal pro abgeschlossener
        // Kerze aufgerufen (aus der _lastConfirmedBar-Schleife), nicht mehr bei jedem Tick — sonst
        // wurde die EMA-Glättung bei jedem Tick der noch laufenden Kerze erneut auf sich selbst
        // angewendet und der ATR lief mit der Zeit von der echten 14er-Formel weg.
        private void AdvanceAtr(int completedBar)
        {
            if (completedBar == 0)
            {
                _atrSum = 0;
                _atr = null;
                return;
            }

            var candle = GetCandle(completedBar);
            var previousCandle = GetCandle(completedBar - 1);

            var trueRange = Math.Max(candle.High - candle.Low,
                Math.Max(Math.Abs(candle.High - previousCandle.Close), Math.Abs(candle.Low - previousCandle.Close)));

            if (!_atr.HasValue)
            {
                // Erste 14 Kerzen: einfacher Durchschnitt aufbauen
                _atrSum += trueRange;

                if (completedBar >= AtrPeriod)
                    _atr = _atrSum / AtrPeriod;

                return;
            }

            // Danach: gleitender ATR nach der Standard-Formel
            _atr = (_atr.Value * (AtrPeriod - 1) + trueRange) / AtrPeriod;
        }

        // Heiken-Ashi-Smoothed nach Vervoort: erst rohe OHLC glätten, daraus Heiken-Ashi bilden,
        // dann deren Open/Close nochmal glätten. Verarbeitet bewusst nur ABGESCHLOSSENE Kerzen
        // (wie EsLocation.cs) - OnCalculate feuert pro Tick, nicht nur beim Kerzenabschluss. Würde
        // die rekursive EMA-Kette bei jedem Tick der noch laufenden Kerze erneut verschoben, würde
        // die Linie nachträglich wandern statt stabil zu bleiben (mehrfache Anwendung derselben
        // Kerze auf sich selbst). Die Linie spiegelt also den Stand nach der letzten
        // abgeschlossenen Kerze, geprüft wird dagegen die aktuell laufende (siehe
        // CheckHaProximity) - exakt das gleiche Prinzip wie VAH/VAL/POC in EsLocation.cs.
        private void UpdateHeikenAshiSmoothed(int bar)
        {
            if (bar == 0)
            {
                _lastHaProcessedBar = -1;
                _emaOpen1 = null;
                _emaHigh1 = null;
                _emaLow1 = null;
                _emaClose1 = null;
                _haOpen = null;
                _haClose = null;
                _haSmoothedLine = null;
            }

            while (_lastHaProcessedBar < bar - 1)
            {
                _lastHaProcessedBar++;
                AdvanceHeikenAshiSmoothed(_lastHaProcessedBar);
            }
        }

        private void AdvanceHeikenAshiSmoothed(int completedBar)
        {
            var candle = GetCandle(completedBar);

            _emaOpen1 = Ema(_emaOpen1, candle.Open, HaSmoothPeriod1);
            _emaHigh1 = Ema(_emaHigh1, candle.High, HaSmoothPeriod1);
            _emaLow1 = Ema(_emaLow1, candle.Low, HaSmoothPeriod1);
            _emaClose1 = Ema(_emaClose1, candle.Close, HaSmoothPeriod1);

            var haCloseRaw = (_emaOpen1.Value + _emaHigh1.Value + _emaLow1.Value + _emaClose1.Value) / 4m;
            var haOpenRaw = _haOpen.HasValue && _haClose.HasValue
                ? (_haOpen.Value + _haClose.Value) / 2m
                : (_emaOpen1.Value + _emaClose1.Value) / 2m;

            _haOpen = haOpenRaw;
            _haClose = haCloseRaw;

            // Geplottete Linie = geglätteter HA-Close (zweite EMA-Stufe)
            _haSmoothedLine = Ema(_haSmoothedLine, _haClose.Value, HaSmoothPeriod2);
        }

        private decimal Ema(decimal? previousEma, decimal price, int period)
        {
            if (!previousEma.HasValue)
                return price;

            var multiplier = 2m / (period + 1);
            return (price - previousEma.Value) * multiplier + previousEma.Value;
        }

        // Rücksetzer zum Heiken-Ashi-Smoothed (Schritt 3, siehe Kommentar oben): Kerze kommt aus
        // Kontext-Richtung nah an die Linie heran, muss sie laut Mike nicht komplett berühren,
        // leichtes Überschießen ist auch ok (ATR-basierte Toleranz). Liefert nur die Richtung des
        // Rücksetzers selbst - ob er tatsächlich zu einem Setup wird, entscheidet der Aufrufer
        // (muss zu Tageskontext + scharfer Location passen). Die eigentliche "Reaktion in die
        // Zielrichtung" prüft NICHT diese Kerze, sondern die Bestätigungskerze danach (Schritt 4).
        private TagesRichtung CheckHaProximity(int bar)
        {
            if (!_haSmoothedLine.HasValue || !_atr.HasValue)
                return TagesRichtung.Neutral;

            var candle = GetCandle(bar);
            var line = _haSmoothedLine.Value;
            var tolerance = _atr.Value * HaProximityAtrFraction;

            // Rücksetzer von oben (Long-Kontext): Low kommt nah an die Linie heran oder leicht
            // drunter durch
            if (candle.Low <= line + tolerance)
                return TagesRichtung.Long;

            // Rücksetzer von unten (Short-Kontext): High kommt nah an die Linie heran oder leicht
            // drüber durch
            if (candle.High >= line - tolerance)
                return TagesRichtung.Short;

            return TagesRichtung.Neutral;
        }

        protected override void OnNewMyTrade(MyTrade myTrade)
        {
            base.OnNewMyTrade(myTrade);

            if (!_atr.HasValue)
                return;

            // Dieser Trade hat die Position geschlossen (Stop/Ziel gegriffen oder manuell
            // geschlossen) -> kein neues Bracket setzen, nur bei Eroeffnung/Vergroesserung
            if (CurrentPosition == 0)
                return;

            var entryPrice = myTrade.Price;
            var isLong = _entryDirection == OrderDirections.Buy;

            var stopPrice = isLong
                ? ShrinkPrice(entryPrice - _atr.Value * StopMultiplier)
                : ShrinkPrice(entryPrice + _atr.Value * StopMultiplier);

            var targetPrice = isLong
                ? ShrinkPrice(entryPrice + _atr.Value * TargetMultiplier)
                : ShrinkPrice(entryPrice - _atr.Value * TargetMultiplier);

            var exitDirection = isLong ? OrderDirections.Sell : OrderDirections.Buy;
            var ocoGroup = Guid.NewGuid().ToString();

            var stopLoss = new Order
            {
                Portfolio = Portfolio,
                Security = Security,
                Direction = exitDirection,
                Type = OrderTypes.Stop,
                TriggerPrice = stopPrice,
                QuantityToFill = OrderQuantity,
                OCOGroup = ocoGroup
            };

            var takeProfit = new Order
            {
                Portfolio = Portfolio,
                Security = Security,
                Direction = exitDirection,
                Type = OrderTypes.Limit,
                Price = targetPrice,
                QuantityToFill = OrderQuantity,
                OCOGroup = ocoGroup
            };

            OpenOrder(stopLoss);
            OpenOrder(takeProfit);
        }
    }
}
