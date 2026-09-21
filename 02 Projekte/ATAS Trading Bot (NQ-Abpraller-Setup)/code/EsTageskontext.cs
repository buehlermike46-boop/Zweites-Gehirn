// Tageskontext-Indikator, laeuft auf dem ES-Chart, siehe [[NQ Abpraller-Setup Checkliste]]
// Regel 1 (hoechste Prioritaet): "Vortageshoch/-tief abgelehnt oder akzeptiert? -> Nur in
// Richtung der Ablehnung bzw. Annahme handeln."
//
// Logik: sobald ein neuer Handelstag beginnt, wird das Hoch/Tief des ABGELAUFENEN Tages als
// "Vortageshoch/-tief" uebernommen. Waehrend des laufenden Tages wird geprueft, ob eine Kerze
// das Vortageshoch/-tief antestet und wieder zurueckfaellt (Ablehnung) oder ob der Schlusskurs
// darueber/darunter bleibt (Akzeptanz). Ergebnis landet in TageskontextState.Richtung, siehe
// TageskontextState.cs.
//
// IsNewSession(bar) stammt aus der oeffentlichen ATAS-Doku (Indicator-Basisklasse), noch nicht
// einzeln per Objektkatalog gegen diese Installation verifiziert - beim ersten Build pruefen.

using ATAS.Indicators;
using OFT.Attributes;

namespace RgTrading.Indicators
{
    [DisplayName("RG Tageskontext (ES)")]
    public class EsTageskontext : Indicator
    {
        private decimal _previousDayHigh;
        private decimal _previousDayLow;
        private decimal _currentDayHigh;
        private decimal _currentDayLow;
        private bool _hasPreviousDay;

        public EsTageskontext() : base(true)
        {
        }

        protected override void OnCalculate(int bar, decimal value)
        {
            if (bar < CurrentBar - 1)
                return;

            var candle = GetCandle(bar);

            if (IsNewSession(bar))
            {
                if (_currentDayHigh != 0)
                {
                    _previousDayHigh = _currentDayHigh;
                    _previousDayLow = _currentDayLow;
                    _hasPreviousDay = true;
                }

                _currentDayHigh = candle.High;
                _currentDayLow = candle.Low;
                TageskontextState.Richtung = TagesRichtung.Neutral;
                return;
            }

            if (candle.High > _currentDayHigh)
                _currentDayHigh = candle.High;
            if (candle.Low < _currentDayLow)
                _currentDayLow = candle.Low;

            if (!_hasPreviousDay)
                return;

            // Regel 1: Vortageshoch angetestet, aber Kerze schliesst wieder darunter -> Ablehnung -> bearish
            if (candle.High > _previousDayHigh && candle.Close < _previousDayHigh)
            {
                TageskontextState.Richtung = TagesRichtung.Short;
            }
            // Vortageshoch akzeptiert (Schluss darueber) -> bullish
            else if (candle.Close > _previousDayHigh)
            {
                TageskontextState.Richtung = TagesRichtung.Long;
            }
            // Vortagestief angetestet, aber Kerze schliesst wieder darueber -> Ablehnung -> bullish
            else if (candle.Low < _previousDayLow && candle.Close > _previousDayLow)
            {
                TageskontextState.Richtung = TagesRichtung.Long;
            }
            // Vortagestief akzeptiert (Schluss darunter) -> bearish
            else if (candle.Close < _previousDayLow)
            {
                TageskontextState.Richtung = TagesRichtung.Short;
            }
        }
    }
}
