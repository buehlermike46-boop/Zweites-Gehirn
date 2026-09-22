// Gemeinsamer Speicher zwischen NqTestStrategy.cs (ChartStrategy, laeuft auf dem NQ-Chart) und
// NqDiagnostics.cs (reiner Indicator, ebenfalls auf dem NQ-Chart) - noetig weil DataSeries auf
// einer ChartStrategy in dieser ATAS-Version NICHT im Chart angezeigt wird (bestaetigt
// 22.09.2026 an Mikes echter Installation: Build fehlerfrei, Strategie komplett neu zum Chart
// hinzugefuegt, trotzdem keiner der drei Plots sichtbar - weder auf dem Chart noch in der
// Indikatorenliste). Gleiches "Briefkasten"-Muster wie TageskontextState.cs/LocationState.cs,
// nur fuer Diagnose-Werte statt Handelssignale, und in die andere Richtung: die Strategie
// schreibt bei jedem Tick, der separate Indicator liest und zeichnet.

namespace RgTrading.Indicators
{
    public static class NqDiagnosticsState
    {
        public static decimal? HaSmoothedLine;
        public static decimal DemandIndexLive;
        public static int SetupStage;
    }
}
