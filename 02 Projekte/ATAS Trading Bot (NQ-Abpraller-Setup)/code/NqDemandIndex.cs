// Phase 0/1 — erster Baustein des ATAS Trading Bots, siehe Projekt-Notiz im übergeordneten Ordner.
//
// WICHTIG: Diese Datei ist gegen die öffentliche ATAS-Doku geschrieben, nicht gegen eine echte
// SDK-Installation getestet (dieser Cloud-Session steht kein Windows/ATAS zur Verfügung). Beim
// ersten Build sind Fehler an folgenden Stellen am wahrscheinlichsten:
//   - Namespace/Attribute für [DisplayName]/[Parameter] können in deiner SDK-Version anders heißen
//   - Der genaue Konstruktor/die Indexer-API von ValueDataSeries kann leicht abweichen
//   - candle.Volume könnte decimal statt double sein (Cast unten ggf. anpassen)
// Schick mir bei einem Build-Fehler einfach die genaue Fehlermeldung, dann korrigiere ich gezielt
// statt hier weiter zu raten.
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
        private double _cumulative;

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
            var relativeChange = (double)((candle.Close - candle.Open) / openPrice);

            // Schritt 3+4: Volumenkomponente kumulieren
            var volumeComponent = (double)candle.Volume * relativeChange;
            _cumulative += volumeComponent;

            _demandIndex[bar] = _cumulative;
            _zeroLine[bar] = 0;
        }
    }
}
