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

        // NEU 22.09.2026: zeigt explizit, ob/wann der ATR in NqTestStrategy.cs ueberhaupt bereit
        // ist (null = noch nicht genug Kerzen verarbeitet). Vorher blieb SetupStage bei fehlendem
        // ATR einfach auf dem letzten Wert stehen - nicht von "legitim 0, kein Setup" zu
        // unterscheiden. Hilft eingrenzen, ob die Strategie ueberhaupt so weit kommt.
        public static decimal? AtrValue;
    }
}
