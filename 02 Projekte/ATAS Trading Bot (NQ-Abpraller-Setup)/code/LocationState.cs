// Gemeinsamer Speicher zwischen EsLocation.cs (laeuft auf dem ES "0/2/3R US" Range-Chart) und
// NqTestStrategy.cs (laeuft auf dem NQ-Chart). Gleiches Muster wie TageskontextState.cs - beide
// Indikatoren laufen im selben ATAS-Prozess, ein statisches Feld reicht als "Briefkasten", kein
// Cross-Instrument-API noetig.
//
// UEBERARBEITET 22.09.2026 (Mikes Klarstellung, siehe Projekt-Notiz "Einstiegslogik neu..."):
// LocationState.Richtung ist KEIN kurzer Impuls mehr, sondern ein "scharf"/"armed"-Zustand -
// wird gesetzt, sobald der Preis eine Location-Zone in Kontext-Richtung verlaesst (siehe
// EsLocation.cs CheckReaction), und bleibt dann bestehen (nicht schon auf der naechsten Kerze
// zurueck auf Neutral), bis entweder ein NQ-Trade ihn verbraucht, eine neue (evtl.
// gegenteilige) Reaktion ihn ueberschreibt, oder eine neue ES-Session ihn zuruecksetzt. Grund:
// mit nur einer Kerze Gueltigkeit war das Zusammentreffen mit dem unabhaengig getakteten
// NQ-Ruecksetzer praktisch nie gegeben (Mikes Beobachtung "kein Trade ausgeloest" am 22.09.).
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
