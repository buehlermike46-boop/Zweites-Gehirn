// Reiner Indicator (bewusst NICHT ChartStrategy!) fuer die drei Diagnose-Plots aus
// NqTestStrategy.cs - HA-Smoothed-Linie, interner Demand-Index-Kumulativwert, Setup-Stufe
// (0/1/2). Separat noetig, weil DataSeries auf einer ChartStrategy in dieser ATAS-Version nicht
// im Chart angezeigt wird (bestaetigt 22.09.2026 an Mikes echter Installation, siehe
// NqDiagnosticsState.cs und Projekt-Notiz). Liest nur den "Briefkasten" NqDiagnosticsState, den
// NqTestStrategy.cs bei jedem Tick befuellt - keine eigene Berechnung hier, rein Anzeige.
//
// WICHTIG (Deployment): muss ZUSAETZLICH zur Strategie auf dem NQ-Chart hinzugefuegt werden -
// ueber den normalen Indikatoren-Button im Chart (genau wie "RG Demand Index" oder
// "RG Footprint Delta"), NICHT ueber die Handelsstrategien-Liste. Ohne das gibt es nichts, das
// die Werte zeichnet, auch wenn die Strategie selbst laeuft.

using ATAS.Indicators;
using OFT.Attributes;

namespace RgTrading.Indicators
{
    [DisplayName("RG NQ-Diagnose (Setup-Stufe)")]
    public class NqDiagnostics : Indicator
    {
        private readonly ValueDataSeries _haSmoothedPlot = new ValueDataSeries("HA-Smoothed (intern)");
        private readonly ValueDataSeries _demandIndexPlot = new ValueDataSeries("Demand Index (intern)");
        private readonly ValueDataSeries _setupStage = new ValueDataSeries("Setup-Stufe (0/1/2)");

        public NqDiagnostics() : base(true)
        {
            DataSeries[0] = _haSmoothedPlot;
            DataSeries.Add(_demandIndexPlot);
            DataSeries.Add(_setupStage);
        }

        protected override void OnCalculate(int bar, decimal value)
        {
            if (NqDiagnosticsState.HaSmoothedLine.HasValue)
                _haSmoothedPlot[bar] = NqDiagnosticsState.HaSmoothedLine.Value;

            _demandIndexPlot[bar] = NqDiagnosticsState.DemandIndexLive;
            _setupStage[bar] = NqDiagnosticsState.SetupStage;
        }
    }
}
