// Gemeinsamer Speicher zwischen EsLocation.cs (laeuft auf dem ES "0/2/3R US" Range-Chart) und
// NqTestStrategy.cs (laeuft auf dem NQ-Chart). Gleiches Muster wie TageskontextState.cs - beide
// Indikatoren laufen im selben ATAS-Prozess, ein statisches Feld reicht als "Briefkasten", kein
// Cross-Instrument-API noetig.
//
// Anders als TageskontextState.Richtung (gilt fuer den ganzen Tag) ist LocationState.Richtung
// nur ein kurzer Impuls: wird bei jeder abgeschlossenen ES-Kerze neu gesetzt (Long/Short bei
// erkannter Reaktion an VAH/VAL, sonst Neutral) - "Handel nur an einer A-Location" heisst JETZT
// an der Location, nicht irgendwann heute.
//
// Voraussetzung: Der ES "0/2/3R US" Range-Chart muss gleichzeitig mit dem NQ-Chart offen sein.

namespace RgTrading.Indicators
{
    public static class LocationState
    {
        public static bool HasProfile;
        public static decimal Poc;
        public static decimal Vah;
        public static decimal Val;
        public static TagesRichtung Richtung = TagesRichtung.Neutral;
    }
}
