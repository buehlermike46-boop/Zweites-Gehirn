// Phase 3 — Order-Platzierung mit ATR-basiertem Stop/Ziel, siehe Projekt-Notiz im
// übergeordneten Ordner. Läuft nur auf dem Demo-Konto (DEMO331DE, bestätigt 20.09.2026).
//
// Einstieg unverändert: Demand-Index-Nulllinien-Kreuzung nach oben → Market-Buy, einmalig.
// Neu (21.09.2026): Stop-Loss (1,5x ATR) und Take-Profit (3x ATR, CRV 1:2) werden nach dem
// tatsächlichen Fill automatisch nachgeschickt, verknüpft über OCOGroup (eine schließt die
// andere automatisch). ATR-Formel nach [[RG-Trading Indikator - ATR (Average True Range)]].
//
// Order-Klasse (ATAS.DataFeedsCore.Order) und Enums (OrderDirections, OrderTypes) per
// Objektkatalog gegen die echte ATAS-Installation bestätigt, 19.09.2026. MyTrade-Eigenschaften
// und der Typ von OCOGroup sind hier noch NICHT verifiziert, nur aus Doku-Recherche angenommen —
// beim ersten Build IntelliSense/Objektkatalog prüfen, falls Fehler auftreten.

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

        private decimal _atrSum;
        private decimal? _atr;

        // Nur zum Testen: prueft einmalig, ob/wie "Cross Trading" (Zugriff auf ein zweites
        // Instrument, z.B. ES waehrend die Strategie auf NQ laeuft) in dieser ATAS-Installation
        // funktioniert. Schreibt das Ergebnis in die ATAS-Logdatei, kein Einfluss auf den Handel.
        private bool _crossTradingChecked;

        public NqTestStrategy() : base(true)
        {
        }

        protected override void OnCalculate(int bar, decimal value)
        {
            UpdateAtr(bar);

            if (!_crossTradingChecked)
            {
                _crossTradingChecked = true;
                var crossTradingContext = DataProvider.GetService<ICrossTradingIndicatorContext>();
                LogInfo($"CrossTrading aktiv: {crossTradingContext.IsCrossTradingActive}, Name: {crossTradingContext.CurrentCrossTradingDisplayName}");
            }

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

            // Ohne ATR-Wert (noch nicht genug Kerzen für 14 Perioden) kein Einstieg,
            // sonst könnten wir hinterher keinen Stop/Ziel berechnen
            if (crossedUp && _atr.HasValue)
            {
                var order = new Order
                {
                    Portfolio = Portfolio,
                    Security = Security,
                    Direction = OrderDirections.Buy,
                    Type = OrderTypes.Market,
                    QuantityToFill = OrderQuantity
                };

                OpenOrder(order);
                _orderPlaced = true;
            }
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
            var stopPrice = ShrinkPrice(entryPrice - _atr.Value * StopMultiplier);
            var targetPrice = ShrinkPrice(entryPrice + _atr.Value * TargetMultiplier);

            var ocoGroup = Guid.NewGuid().ToString();

            var stopLoss = new Order
            {
                Portfolio = Portfolio,
                Security = Security,
                Direction = OrderDirections.Sell,
                Type = OrderTypes.Stop,
                TriggerPrice = stopPrice,
                QuantityToFill = OrderQuantity,
                OCOGroup = ocoGroup
            };

            var takeProfit = new Order
            {
                Portfolio = Portfolio,
                Security = Security,
                Direction = OrderDirections.Sell,
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
