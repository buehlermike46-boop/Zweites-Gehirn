// Gemeinsamer Speicher zwischen EsTageskontext.cs (laeuft auf dem ES-Chart) und
// NqTestStrategy.cs (laeuft auf dem NQ-Chart). Beide laufen im selben ATAS-Prozess,
// deshalb reicht ein statisches Feld als "Briefkasten" zwischen den beiden Charts -
// kein Cross-Instrument-API noetig (ICrossTradingIndicatorContext/ICandlesDataProvider
// existieren in dieser ATAS-Version nicht bzw. sind nicht nutzbar, siehe Projekt-Notiz).
//
// Voraussetzung: ES-Chart und NQ-Chart muessen gleichzeitig in ATAS offen sein.

namespace RgTrading.Indicators
{
    public enum TagesRichtung
    {
        Neutral,
        Long,
        Short
    }

    public static class TageskontextState
    {
        public static TagesRichtung Richtung = TagesRichtung.Neutral;
    }
}
