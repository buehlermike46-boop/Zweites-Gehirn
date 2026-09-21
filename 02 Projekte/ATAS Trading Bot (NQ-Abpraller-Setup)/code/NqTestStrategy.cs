// Phase 3 — Order-Platzierung mit ATR-basiertem Stop/Ziel UND Tageskontext-Richtung.
// Siehe Projekt-Notiz im übergeordneten Ordner. Läuft nur auf dem Demo-Konto
// (DEMO331DE, bestätigt 20.09.2026).
//
// Einstieg: Demand-Index-Nulllinien-Kreuzung (Signal), aber NUR wenn der Tageskontext vom
// ES-Chart (siehe EsTageskontext.cs) zustimmt — Kreuzung nach oben nur bei Richtung "Long",
// Kreuzung nach unten nur bei "Short". Das setzt [[NQ Abpraller-Setup Checkliste]] Regel 1 um
// ("höchste Priorität: nur in Richtung der Ablehnung bzw. Annahme handeln").
//
// WICHTIG: EsTageskontext.cs muss auf einem ES-Chart laufen, damit TageskontextState.Richtung
// überhaupt etwas anderes als "Neutral" wird — sonst handelt diese Strategie nie (bewusst so,
// lieber kein Trade als einer ohne Richtungsbestätigung).
//
// Stop-Loss (1,5x ATR) und Take-Profit (3x ATR, CRV 1:2) werden nach dem tatsächlichen Fill
// automatisch nachgeschickt, verknüpft über OCOGroup. ATR-Formel nach
// [[RG-Trading Indikator - ATR (Average True Range)]].
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
        private bool _orderPlaced;
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

            if (_orderPlaced)
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

            if (crossedUp && TageskontextState.Richtung == TagesRichtung.Long)
            {
                _entryDirection = OrderDirections.Buy;
                PlaceEntryOrder();
            }
            else if (crossedDown && TageskontextState.Richtung == TagesRichtung.Short)
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
            _orderPlaced = true;
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
