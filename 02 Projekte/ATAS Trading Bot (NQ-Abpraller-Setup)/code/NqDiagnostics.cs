// Reine Indicator-Klassen (bewusst NICHT ChartStrategy!) fuer die Diagnose-Werte aus
// NqTestStrategy.cs. Lesen nur den "Briefkasten" NqDiagnosticsState, den NqTestStrategy.cs bei
// jedem Tick befuellt - keine eigene Berechnung hier, rein Anzeige.
//
// UEBERARBEITET 22.09.2026 (Mikes Test): urspruenglich EIN Indicator mit allen drei Werten
// zusammen - dabei zeigte sich, dass sie sich EINE Skala teilen. HA-Smoothed (intern) liegt bei
// echten NQ-Preisen (~30.900), waehrend Demand Index (intern, ca. -100 bis 100) und Setup-Stufe
// (0-2) winzig dagegen sind - die grosse Zahl drueckt die beiden kleinen komplett an den unteren
// Rand, unsichtbar (bestaetigt per Screenshot: leeres Panel bis auf eine flache Linie oben).
// Deshalb jetzt DREI separate Indicator-Klassen, jede mit genau einem Wert und eigener Skala.
//
// WICHTIG (Deployment): alle drei muessen ZUSAETZLICH zur Strategie auf dem NQ-Chart hinzugefuegt
// werden - ueber den normalen Indikatoren-Button im Chart, NICHT ueber die Handelsstrategien-
// Liste. "RG Setup-Stufe (0/1/2)" ist die wichtigste der drei (zeigt direkt, wie weit die
// Einstiegs-Sequenz gerade kommt) - die anderen zwei sind optional zur Kontrolle/zum Abgleich.

using ATAS.Indicators;
using OFT.Attributes;

namespace RgTrading.Indicators
{
    // Wichtigste der drei: zeigt live, wie weit die Einstiegs-Sequenz in NqTestStrategy.cs
    // gerade kommt (0 = kein Setup, 1 = Ruecksetzer erkannt/wartet auf Bestaetigungskerze,
    // 2 = Bestaetigungskerze da, Demand-Index-Vorzeichen wird geprueft).
    [DisplayName("RG Setup-Stufe (0/1/2)")]
    public class NqDiagnosticsSetupStage : Indicator
    {
        private readonly ValueDataSeries _setupStage = new ValueDataSeries("Setup-Stufe (0/1/2)");

        public NqDiagnosticsSetupStage() : base(true)
        {
            DataSeries[0] = _setupStage;
        }

        protected override void OnCalculate(int bar, decimal value)
        {
            _setupStage[bar] = NqDiagnosticsState.SetupStage;
        }
    }

    // Interner Demand-Index-Kumulativwert der Strategie - zum Abgleich mit der echten,
    // bereits geladenen "RG Demand Index"-Linie (aehnliche Groessenordnung, ca. -100 bis 100).
    [DisplayName("RG Demand Index (intern)")]
    public class NqDiagnosticsDemandIndex : Indicator
    {
        private readonly ValueDataSeries _demandIndexPlot = new ValueDataSeries("Demand Index (intern)");

        public NqDiagnosticsDemandIndex() : base(true)
        {
            DataSeries[0] = _demandIndexPlot;
        }

        protected override void OnCalculate(int bar, decimal value)
        {
            _demandIndexPlot[bar] = NqDiagnosticsState.DemandIndexLive;
        }
    }

    // Intern berechnete Heiken-Ashi-Smoothed-Linie - zum optischen Abgleich mit Mikes bereits
    // geladenem "Heiken Ashi Smoothed"-Indikator. Echter Preiswert (~NQ-Kurs) - sinnvollerweise
    // auf "Chart" (ueber den Kerzen) statt in einem eigenen Panel anzeigen.
    [DisplayName("RG HA-Smoothed (intern)")]
    public class NqDiagnosticsHaSmoothed : Indicator
    {
        private readonly ValueDataSeries _haSmoothedPlot = new ValueDataSeries("HA-Smoothed (intern)");

        public NqDiagnosticsHaSmoothed() : base(true)
        {
            DataSeries[0] = _haSmoothedPlot;
        }

        protected override void OnCalculate(int bar, decimal value)
        {
            if (NqDiagnosticsState.HaSmoothedLine.HasValue)
                _haSmoothedPlot[bar] = NqDiagnosticsState.HaSmoothedLine.Value;
        }
    }

    // NEU 22.09.2026: zeigt den ATR-Wert der Strategie selbst - entscheidend fuer die Diagnose,
    // weil Demand Index/Setup-Stufe bisher erst NACH einem fertigen ATR ueberhaupt geschrieben
    // wurden. Bleibt dieser Plot leer, hat die Strategie noch nie genug Kerzen fuer einen
    // fertigen ATR verarbeitet (14 Perioden) - unabhaengig vom Rest der Logik.
    [DisplayName("RG ATR-Wert (Strategie)")]
    public class NqDiagnosticsAtr : Indicator
    {
        private readonly ValueDataSeries _atrPlot = new ValueDataSeries("ATR (Strategie)");

        public NqDiagnosticsAtr() : base(true)
        {
            DataSeries[0] = _atrPlot;
        }

        protected override void OnCalculate(int bar, decimal value)
        {
            if (NqDiagnosticsState.AtrValue.HasValue)
                _atrPlot[bar] = NqDiagnosticsState.AtrValue.Value;
        }
    }
}
