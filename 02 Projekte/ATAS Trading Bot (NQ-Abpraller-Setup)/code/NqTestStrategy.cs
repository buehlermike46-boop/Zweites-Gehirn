// Phase 3 — Order-Platzierung mit ATR-basiertem Stop/Ziel, Tageskontext-Richtung UND Location.
// Siehe Projekt-Notiz im übergeordneten Ordner. Läuft nur auf dem Demo-Konto
// (DEMO331DE, bestätigt 20.09.2026).
//
// Einstieg: Demand-Index-Nulllinien-Kreuzung (Signal), aber NUR wenn ZWEI ES-seitige Gates
// zustimmen — [[NQ Abpraller-Setup Checkliste]] Punkt 1 (Tageskontext) UND Punkt 3 (Location):
// 1. Tageskontext (siehe EsTageskontext.cs, läuft auf ES M15 o.ä.): Vortageshoch/-tief
//    abgelehnt/akzeptiert, ergibt eine Richtung die für den ganzen Tag gilt.
// 2. Location (siehe EsLocation.cs, läuft auf Mikes ES "0/2/3R US" Range-Chart, seit 21.09.2026):
//    gerade jetzt eine Ablehnung an VAH/VAL erkannt, gilt nur für die zuletzt abgeschlossene
//    ES-Kerze, kein Tages-Flag.
// Kreuzung nach oben nur wenn BEIDE Gates "Long" sagen, Kreuzung nach unten nur wenn BEIDE
// "Short" sagen. Stimmen Tageskontext und Location nicht überein (oder eines ist Neutral): kein
// Trade — bewusst so, lieber kein Trade als einer ohne vollständige Richtungsbestätigung.
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

        private decimal _cumulative;
        private decimal _previousCumulative;
        private OrderDirections _entryDirection;

        private decimal _atrSum;
        private decimal? _atr;

        public NqTestStrategy() : base(true)
        {
        }

        protected override void OnCalculate(int bar, decimal value)
        {
            UpdateAtr(bar);

            // Nicht auf historische Kerzen beim Laden reagieren, nur auf die aktuell laufende
            if (bar < CurrentBar - 1)
                return;

            // Schon eine offene Position -> kein neuer Einstieg, wartet bis sie flach ist
            if (CurrentPosition != 0)
                return;

            if (bar == 0)
            {
                _cumulative = 0;
                _previousCumulative = 0;
                return;
            }

            var candle = GetCandle(bar);
            var openPrice = candle.Open == 0 ? 1 : candle.Open;
            var relativeChange = (candle.Close - candle.Open) / openPrice;
            var volumeComponent = candle.Volume * relativeChange;

            _previousCumulative = _cumulative;
            _cumulative += volumeComponent;

            var crossedUp = _previousCumulative <= 0 && _cumulative > 0;
            var crossedDown = _previousCumulative >= 0 && _cumulative < 0;

            // Ohne ATR-Wert (noch nicht genug Kerzen für 14 Perioden) kein Einstieg,
            // sonst könnten wir hinterher keinen Stop/Ziel berechnen
            if (!_atr.HasValue)
                return;

            if (!LocationState.HasProfile)
                return;

            if (crossedUp && TageskontextState.Richtung == TagesRichtung.Long
                && LocationState.Richtung == TagesRichtung.Long)
            {
                _entryDirection = OrderDirections.Buy;
                PlaceEntryOrder();
            }
            else if (crossedDown && TageskontextState.Richtung == TagesRichtung.Short
                && LocationState.Richtung == TagesRichtung.Short)
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

        private void UpdateAtr(int bar)
        {
            if (bar == 0)
            {
                _atrSum = 0;
                _atr = null;
                return;
            }

            var candle = GetCandle(bar);
            var previousCandle = GetCandle(bar - 1);

            var trueRange = Math.Max(candle.High - candle.Low,
                Math.Max(Math.Abs(candle.High - previousCandle.Close), Math.Abs(candle.Low - previousCandle.Close)));

            if (!_atr.HasValue)
            {
                // Erste 14 Kerzen: einfacher Durchschnitt aufbauen
                _atrSum += trueRange;

                if (bar >= AtrPeriod)
                    _atr = _atrSum / AtrPeriod;

                return;
            }

            // Danach: gleitender ATR nach der Standard-Formel
            _atr = (_atr.Value * (AtrPeriod - 1) + trueRange) / AtrPeriod;
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
