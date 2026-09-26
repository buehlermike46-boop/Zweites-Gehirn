// Minimal-Test 22.09.2026: komplett unabhaengig von NqTestStrategy.cs, um zu klaeren ob
// UEBERHAUPT irgendeine ChartStrategy auf Mikes Installation noch OnCalculate aufgerufen
// bekommt, nachdem NqTestStrategy.OnCalculate laut "RG OnCalculate-Zaehler (Strategie)" (0 nach
// stundenlangem Live-Betrieb) nachweislich nie laeuft - waehrend JEDE reine Indicator-Klasse in
// derselben DLL (EsTageskontext, EsLocation, alle NqDiagnostics*) nachweislich funktioniert.
//
// Diese Datei tut NICHTS ausser einen Zaehler hochzaehlen, sobald OnCalculate aufgerufen wird -
// keine Order-Logik, kein Bezug zu NqTestStrategy.cs oder irgendeiner anderen Datei dieses
// Projekts. Eigener Briefkasten (NqHelloWorldState), eigener Anzeige-Indicator
// (NqHelloWorldDisplay). Bleibt der Zaehler bei 0: ChartStrategy-OnCalculate laeuft auf dieser
// ATAS-Installation generell nicht (mehr) - ein Plattform-Problem, kein Fehler in
// NqTestStrategy.cs. Steigt er: dann ist etwas sehr Spezifisches an NqTestStrategy.cs kaputt,
// trotz des bereits als allererste Zeile eingebauten Zaehlers dort - noch unwahrscheinlicher,
// aber dann naechster Schritt waere ein Vergleich beider Dateien Zeile fuer Zeile.
//
// WICHTIG (Deployment): "RG HelloWorld-Test-Strategie" muss GENAUSO wie "RG Test-Strategie
// (Demand Index)" ueber die Handelsstrategien-Funktion aktiviert werden (nicht ueber den
// normalen Indikatoren-Button - es ist eine ChartStrategy, keine Indicator). "RG HelloWorld
// Zaehler (Anzeige)" separat ueber den Indikatoren-Button hinzufuegen, wie bei den anderen
// Diagnose-Plots.

using ATAS.Indicators;
using ATAS.Strategies.Chart;
using OFT.Attributes;

namespace RgTrading.Indicators
{
    public static class NqHelloWorldState
    {
        public static long HitCount;
    }

    [DisplayName("RG HelloWorld-Test-Strategie")]
    public class NqHelloWorldStrategy : ChartStrategy
    {
        public NqHelloWorldStrategy() : base(true)
        {
        }

        protected override void OnCalculate(int bar, decimal value)
        {
            NqHelloWorldState.HitCount++;
        }
    }

    [DisplayName("RG HelloWorld Zaehler (Anzeige)")]
    public class NqHelloWorldDisplay : Indicator
    {
        private readonly ValueDataSeries _plot = new ValueDataSeries("HelloWorld-Zaehler");

        public NqHelloWorldDisplay() : base(true)
        {
            DataSeries[0] = _plot;
        }

        protected override void OnCalculate(int bar, decimal value)
        {
            _plot[bar] = NqHelloWorldState.HitCount;
        }
    }
}
