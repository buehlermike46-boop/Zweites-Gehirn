// Phase 3 — Order-Platzierung mit ATR-basiertem Stop/Ziel, Tageskontext-Richtung, Location UND
// Heiken-Ashi-Smoothed-Abpraller. Siehe Projekt-Notiz im übergeordneten Ordner. Läuft nur auf dem
// Demo-Konto (DEMO331DE, bestätigt 20.09.2026).
//
// Einstieg braucht jetzt VIER übereinstimmende Bedingungen:
// 1. Demand-Index-Nulllinien-Kreuzung (Signal/Trigger, wie bisher)
// 2. Tageskontext-Richtung (siehe EsTageskontext.cs, läuft auf ES M15 o.ä.) — Checkliste Punkt 1
// 3. Location-Richtung (siehe EsLocation.cs, läuft auf Mikes ES "0/2/3R US" Range-Chart) —
//    Checkliste Punkt 3, seit 21.09.2026 erweitert um POC/Vortageshoch-tief/Tageshoch-tief/
//    Volumenbergkanten, nicht mehr nur VAH/VAL
// 4. NEU seit 21.09.2026 (Mikes Beobachtung an echten NQ-Abprallern): Kerze prallt am
//    Heiken-Ashi-Smoothed ab — Low/High testet die geglättete Linie an, Schluss bleibt auf der
//    Trendseite. Gleiches Ablehnungs-Muster wie bei Location, nur auf NQ statt ES angewendet.
//
// Kreuzung nach oben nur wenn ALLE VIER "Long" sagen, nach unten nur wenn ALLE VIER "Short"
// sagen. Fehlt eine Bestätigung: kein Trade — bewusst so, lieber kein Trade als einer ohne
// vollständige Bestätigung.
//
// Heiken-Ashi-Smoothed-Formel (Sylvain Vervoort, öffentlich bekannt, KEINE ATAS-eigene API,
// deshalb selbst nachgerechnet statt den bereits geladenen "Heiken Ashi Smoothed"-Indikator
// auszulesen — gleiches Prinzip wie beim Demand Index/ATR, hat sich als robuster erwiesen als
// Cross-Indikator-Zugriff):
//   1. Rohe OHLC erst mit EMA(Länge1) glätten
//   2. Aus den geglätteten Werten normale Heiken-Ashi-Kerzen berechnen
//   3. Deren Open/Close nochmal mit EMA(Länge2) glätten -> Ergebnis ist die geplottete Linie
// Länge1 = Länge2 = 10, wie bei Mikes geladenem Indikator ("Heiken Ashi Smoothed (Bars, 10, 10,
// True)"). WICHTIG: das ist eine öffentlich dokumentierte Formel, keine über den Objektkatalog
// verifizierbare API (es gibt hier keine "richtige" API zu prüfen, nur Mathematik) — einmal
// gegenprüfen, ob unsere berechnete Linie optisch zur geladenen Indikator-Linie auf dem Chart
// passt, dann passt die Umsetzung. Seit 22.09.2026 als eigener Plot sichtbar (siehe unten), damit
// dieser Abgleich jetzt tatsächlich am Chart gemacht werden kann statt nur geplant zu sein.
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
// [[RG-Trading Indikator - ATR (Average True Range)]]. OnNewMyTrade unterscheidet jetzt
// Eröffnungs- von Schluss-Trades (per CurrentPosition), damit beim Schließen einer Position
// (Stop/Ziel gegriffen) nicht versehentlich ein neues Bracket gesetzt wird.
//
// Order-Klasse (ATAS.DataFeedsCore.Order), Enums (OrderDirections, OrderTypes) und
// MyTrade.Price per Objektkatalog/Testbuild gegen die echte ATAS-Installation bestätigt,
// 19.-21.09.2026. ICrossTradingIndicatorContext/ICandlesDataProvider funktionieren in dieser
// ATAS-Version NICHT (Service nicht registriert bzw. Typ existiert nicht) — deshalb der Weg
// über TageskontextState.cs statt eines direkten Cross-Instrument-Zugriffs.
//
// ZWEI BUGS BEHOBEN 22.09.2026 (Grund für "kein Trade ausgelöst" am ersten vollen Handelstag mit
// allen vier Bedingungen, Mikes Meldung samt Screenshot: Strategie "Aktiv", aber Position/Preis/
// Offene/Geschlossen alle 0):
//   a) Der Demand-Index-Kumulativwert (_cumulative) wurde erst berechnet, NACHDEM die
//      "nur aktuelle Kerze"-Bremse (`if (bar < CurrentBar - 1) return;`) schon gegriffen hatte —
//      anders als in NqDemandIndex.cs (dem Original-Indikator, der bewusst die volle Historie ab
//      bar 0 verarbeitet) startete der Kumulativwert hier also nicht aus der echten Historie,
//      sondern bei jedem Neustart der Strategie künstlich bei 0. Jede erste "Kreuzung" danach war
//      dadurch ein Artefakt des Start-Zeitpunkts, kein echtes Kreuzen der Nulllinie.
//   b) Weil OnCalculate pro Tick feuert (nicht nur pro abgeschlossener Kerze, siehe Kommentar in
//      UpdateHeikenAshiSmoothed) und die Kumulativ-Berechnung KEINE "nur einmal pro Kerze"-Bremse
//      hatte (anders als UpdateHeikenAshiSmoothed/EsLocation.cs mit ihrem _lastHaProcessedBar/
//      _lastAddedBar-Muster), wurde bei jedem Preis-Tick der noch laufenden Kerze der
//      Volumen-Anteil dieser Kerze ERNEUT aufaddiert statt einmalig — der interne Kumulativwert
//      lief dadurch mit jedem Tick weiter weg von der tatsächlich im Chart sichtbaren
//      Demand-Index-Linie. Gleicher Fehler steckte in UpdateAtr (jetzt AdvanceAtr) und hat den
//      ATR (damit Stop/Ziel-Abstand) auf dieselbe Art verfälscht.
//   Fix: ATR und Demand-Index-Kumulativ laufen jetzt über denselben "nur einmal pro abgeschlossener
//   Kerze"-Mechanismus wie UpdateHeikenAshiSmoothed (_lastConfirmedBar), verarbeiten dabei bewusst
//   die volle Historie beim Laden (wie NqDemandIndex.cs). Die eigentliche Kreuzungsprüfung bleibt
//   bewusst tick-reaktiv (reagiert sofort, nicht erst beim Kerzenabschluss) — dafür wird der
//   Live-Wert der aktuell laufenden Kerze pro Tick frisch aus dem bestätigten Vorwert plus dem
//   aktuellen Tick-Stand neu berechnet statt draufaddiert.
//
// NEU 22.09.2026: zwei Diagnose-Plots (HA-Smoothed-Linie + "Bedingungen erfüllt 0-4"), damit sich
// "warum hat es nicht ausgelöst" ab jetzt am NQ-Chart ablesen statt raten lässt (ergänzt die neuen
// Richtungs-Plots in EsTageskontext.cs/EsLocation.cs vom selben Tag). DataSeries auf einer
// ChartStrategy (statt einem reinen Indicator wie NqDemandIndex.cs/NqFootprintDelta.cs, wo das
// Muster schon bestätigt lief) ist NOCH NICHT einzeln gegen die echte Installation
// verifiziert — sollte laut Projekt-Notiz funktionieren (ChartStrategy erbt von Indicator), beim
// nächsten Build einmal prüfen ob die Plots im Chart erscheinen.

using System;
using ATAS.DataFeedsCore;
using ATAS.Indicators;
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

        private readonly ValueDataSeries _haSmoothedPlot = new ValueDataSeries("HA-Smoothed (intern)");
        private readonly ValueDataSeries _bedingungenErfuellt = new ValueDataSeries("Bedingungen erfuellt (0-4)");

        public NqTestStrategy() : base(true)
        {
            DataSeries[0] = _haSmoothedPlot;
            DataSeries.Add(_bedingungenErfuellt);
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
                _haSmoothedPlot[bar] = _haSmoothedLine.Value;

            // Nicht auf historische Kerzen beim Laden reagieren, nur auf die aktuell laufende
            if (bar < CurrentBar - 1)
                return;

            // Schon eine offene Position -> kein neuer Einstieg, wartet bis sie flach ist
            if (CurrentPosition != 0)
                return;

            // Ohne ATR-Wert (noch nicht genug Kerzen für 14 Perioden) kein Einstieg,
            // sonst könnten wir hinterher keinen Stop/Ziel berechnen
            if (!_atr.HasValue)
                return;

            // Kreuzungsprüfung bleibt tick-reaktiv: Live-Wert der laufenden Kerze wird pro Tick
            // frisch aus dem bestätigten Kumulativ (Stand vorherige Kerze) plus dem aktuellen
            // Tick-Stand berechnet, nicht draufaddiert (das war Bug b) oben).
            var candle = GetCandle(bar);
            var openPrice = candle.Open == 0 ? 1 : candle.Open;
            var relativeChange = (candle.Close - candle.Open) / openPrice;
            var volumeComponent = candle.Volume * relativeChange;
            var liveCumulative = _cumulative + volumeComponent;

            var crossedUp = _cumulative <= 0 && liveCumulative > 0;
            var crossedDown = _cumulative >= 0 && liveCumulative < 0;

            var haBounce = CheckHaSmoothedBounce(bar);

            // Diagnose (22.09.2026): wie viele der vier Bedingungen sind gerade JE Richtung
            // erfüllt — getrennt gezählt, weil z.B. Kreuzung-nach-oben + Location-Short nicht als
            // "3 von 4" zählen darf. Zeigt am Chart auf einen Blick, welche Bedingung fehlt.
            var longConditions = (crossedUp ? 1 : 0) + (TageskontextState.Richtung == TagesRichtung.Long ? 1 : 0)
                + (LocationState.Richtung == TagesRichtung.Long ? 1 : 0) + (haBounce == TagesRichtung.Long ? 1 : 0);
            var shortConditions = (crossedDown ? 1 : 0) + (TageskontextState.Richtung == TagesRichtung.Short ? 1 : 0)
                + (LocationState.Richtung == TagesRichtung.Short ? 1 : 0) + (haBounce == TagesRichtung.Short ? 1 : 0);
            _bedingungenErfuellt[bar] = Math.Max(longConditions, shortConditions);

            if (!LocationState.HasProfile)
                return;

            if (crossedUp && TageskontextState.Richtung == TagesRichtung.Long
                && LocationState.Richtung == TagesRichtung.Long
                && haBounce == TagesRichtung.Long)
            {
                _entryDirection = OrderDirections.Buy;
                PlaceEntryOrder();
            }
            else if (crossedDown && TageskontextState.Richtung == TagesRichtung.Short
                && LocationState.Richtung == TagesRichtung.Short
                && haBounce == TagesRichtung.Short)
            {
                _entryDirection = OrderDirections.Sell;
                PlaceEntryOrder();
            }
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
        // CheckHaSmoothedBounce) - exakt das gleiche Prinzip wie VAH/VAL/POC in EsLocation.cs.
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

        // Abpraller am Heiken-Ashi-Smoothed: Low testet die Linie an, Schluss bleibt darüber ->
        // bullish. Spiegelbildlich für High/darunter -> bearish. Gleiches Ablehnungs-Muster wie
        // in EsTageskontext.cs/EsLocation.cs, hier auf die NQ-Trendlinie angewendet.
        private TagesRichtung CheckHaSmoothedBounce(int bar)
        {
            if (!_haSmoothedLine.HasValue)
                return TagesRichtung.Neutral;

            var candle = GetCandle(bar);
            var line = _haSmoothedLine.Value;

            if (candle.Low <= line && candle.Close > line)
                return TagesRichtung.Long;

            if (candle.High >= line && candle.Close < line)
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
