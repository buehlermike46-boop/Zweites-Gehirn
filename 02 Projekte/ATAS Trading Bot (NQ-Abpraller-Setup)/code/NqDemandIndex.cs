// Phase 0/1 — erster Baustein des ATAS Trading Bots, siehe Projekt-Notiz im übergeordneten Ordner.
//
// Stand 19.09.2026: gegen Mikes echte ATAS-Installation gebaut und korrigiert (erster Build-Versuch).
// Zwei Korrekturen gegenüber der ersten Fassung:
//   - using OFT.Attributes braucht eine eigene Referenz auf OFT.Attributes.dll (im ATAS-Platform-
//     Ordner, nicht in ATAS.Indicators.dll enthalten)
//   - candle.Volume ist decimal, nicht double — komplette Rechnung läuft jetzt in decimal, keine
//     Casts mehr nötig
//
// Formel: [[RG-Trading Indikator - Demand Index]] (Sibbet), referenziert in
// [[NQ Abpraller-Setup Checkliste]] Punkt 4 als letzter Bestätigungsfilter.

using ATAS.Indicators;
using OFT.Attributes;

namespace RgTrading.Indicators
{
    [DisplayName("RG Demand Index")]
    public class NqDemandIndex : Indicator
    {
        private readonly ValueDataSeries _demandIndex = new ValueDataSeries("Demand Index");
        private readonly ValueDataSeries _zeroLine = new ValueDataSeries("Nulllinie");
        private decimal _cumulative;

        public NqDemandIndex() : base(true)
        {
            DataSeries[0] = _demandIndex;
            DataSeries.Add(_zeroLine);
        }

        protected override void OnCalculate(int bar, decimal value)
        {
            if (bar == 0)
            {
                _cumulative = 0;
                _demandIndex[bar] = 0;
                _zeroLine[bar] = 0;
                return;
            }

            var candle = GetCandle(bar);

            // Schritt 1+2: relative Preisänderung = (Close - Open) / Open
            var openPrice = candle.Open == 0 ? 1 : candle.Open; // Division durch 0 vermeiden
            var relativeChange = (candle.Close - candle.Open) / openPrice;

            // Schritt 3+4: Volumenkomponente kumulieren
            var volumeComponent = candle.Volume * relativeChange;
            _cumulative += volumeComponent;

            _demandIndex[bar] = _cumulative;
            _zeroLine[bar] = 0;
        }
    }
}
