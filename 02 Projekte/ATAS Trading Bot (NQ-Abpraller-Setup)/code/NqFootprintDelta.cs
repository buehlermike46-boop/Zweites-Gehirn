// Phase 2 — erster Footprint-Baustein, siehe Projekt-Notiz im übergeordneten Ordner.
//
// Bewusst noch kein Ja/Nein-Signal, nur Rohwerte (Delta, MaxDelta, MinDelta) als Anzeige.
// Die Schwellenwerte für "MAX Delta nahe 0" / "MIN Delta hoch" aus der Ablehnungskerzen-Regel
// (siehe [[NQ Abpraller-Setup Checkliste]] Punkt 4) werden an echten, von Mike bestätigten
// Setups aus dem Trading-Journal kalibriert, nicht geraten.
//
// POC-Rücktest aus derselben Regel ist hier bewusst nicht enthalten — das ist der Session-POC
// aus dem bestehenden Volume-Profile-Indikator, nicht der POC einer einzelnen Kerze. Eigener
// Baustein, noch offen.
//
// API bestätigt am 19.09.2026 per IntelliSense gegen Mikes echte ATAS-Installation
// (candle.Delta, candle.MaxDelta, candle.MinDelta direkt auf IndicatorCandle).

using ATAS.Indicators;
using OFT.Attributes;

namespace RgTrading.Indicators
{
    [DisplayName("RG Footprint Delta")]
    public class NqFootprintDelta : Indicator
    {
        private readonly ValueDataSeries _delta = new ValueDataSeries("Delta");
        private readonly ValueDataSeries _maxDelta = new ValueDataSeries("Max Delta");
        private readonly ValueDataSeries _minDelta = new ValueDataSeries("Min Delta");
        private readonly ValueDataSeries _zeroLine = new ValueDataSeries("Nulllinie");

        public NqFootprintDelta() : base(true)
        {
            DataSeries[0] = _delta;
            DataSeries.Add(_maxDelta);
            DataSeries.Add(_minDelta);
            DataSeries.Add(_zeroLine);
        }

        protected override void OnCalculate(int bar, decimal value)
        {
            var candle = GetCandle(bar);

            _delta[bar] = candle.Delta;
            _maxDelta[bar] = candle.MaxDelta;
            _minDelta[bar] = candle.MinDelta;
            _zeroLine[bar] = 0;
        }
    }
}
