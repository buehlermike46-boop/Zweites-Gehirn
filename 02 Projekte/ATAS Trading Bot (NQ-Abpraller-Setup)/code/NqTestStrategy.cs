// Phase 3 — erster echter Order-Platzierungs-Test, siehe Projekt-Notiz im übergeordneten Ordner.
//
// Bewusst minimal: kein Stop-Loss, kein Halb-/Vollautomatik-Umschalter, nur EIN Test-Trade
// (Demand-Index-Nulllinien-Kreuzung nach oben → Market-Buy 1 Kontrakt), um die reine
// Order-Mechanik zu prüfen, bevor Risikomanagement und die echte Checkliste dazukommen.
// Läuft nur auf dem Demo-Konto (DEMO331DE, bestätigt 20.09.2026).
//
// Order-Klasse (ATAS.DataFeedsCore.Order) und Enums (OrderDirections, OrderTypes) per
// Objektkatalog gegen die echte ATAS-Installation bestätigt, 19.09.2026.

using ATAS.DataFeedsCore;
using ATAS.Strategies.Chart;
using OFT.Attributes;

namespace RgTrading.Indicators
{
    [DisplayName("RG Test-Strategie (Demand Index)")]
    public class NqTestStrategy : ChartStrategy
    {
        private decimal _cumulative;
        private decimal _previousCumulative;
        private bool _orderPlaced;

        public NqTestStrategy() : base(true)
        {
        }

        protected override void OnCalculate(int bar, decimal value)
        {
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

            if (crossedUp)
            {
                var order = new Order
                {
                    Portfolio = Portfolio,
                    Security = Security,
                    Direction = OrderDirections.Buy,
                    Type = OrderTypes.Market,
                    QuantityToFill = 1
                };

                OpenOrder(order);
                _orderPlaced = true;
            }
        }
    }
}
