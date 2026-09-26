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
//
// Verarbeitet bewusst ALLE Kerzen, auch beim Laden aus der Historie (Aenderung 21.09.2026,
// vorher stand hier eine "nur letzte Kerze"-Bremse wie in NqTestStrategy.cs - die gehoert aber
// nur in die Order-platzierende Strategie, nicht in einen reinen Zustands-Indikator ohne
// Order-Wirkung). Mit der Bremse haette dieser Indikator beim Laden/Neustart von ATAS das
// Vortageshoch/-tief NICHT aus der Historie uebernommen, sondern erst nach dem naechsten LIVEN
// Sessionwechsel - bis dahin waere TageskontextState.Richtung immer Neutral geblieben und der Bot
// haette trotz gueltiger Bedingungen nicht gehandelt. Ohne die Bremse baut sich der Zustand sofort
// beim Laden korrekt aus der Historie auf, danach reagiert er wie bisher live weiter. Setzen
// derselben statischen Werte mehrfach pro Kerze (bei jedem Tick) ist unschaedlich, da idempotent.
//
// NEU 22.09.2026: TageskontextState.Richtung wird zusaetzlich als Plot sichtbar gemacht (-1 Short/
// 0 Neutral/1 Long). Grund: dieser Indikator lief bisher komplett unsichtbar im Hintergrund - Mike
// hatte am Chart keine Moeglichkeit zu sehen, was der Bot gerade als Tageskontext-Richtung
// annimmt, als er sich fragte warum NqTestStrategy.cs nicht ausgeloest hat. Gleiches Plot-Muster
// wie in NqDemandIndex.cs/NqFootprintDelta.cs bereits bestaetigt funktionierend.

using ATAS.Indicators;
using OFT.Attributes;

namespace RgTrading.Indicators
{
    [DisplayName("RG Tageskontext (ES)")]
    public class EsTageskontext : Indicator
    {
        private readonly ValueDataSeries _richtungPlot = new ValueDataSeries("Tageskontext-Richtung");

        private decimal _previousDayHigh;
        private decimal _previousDayLow;
        private decimal _currentDayHigh;
        private decimal _currentDayLow;
        private bool _hasPreviousDay;

        public EsTageskontext() : base(true)
        {
            DataSeries[0] = _richtungPlot;
        }

        protected override void OnCalculate(int bar, decimal value)
        {
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
                _richtungPlot[bar] = 0;
                return;
            }

            if (candle.High > _currentDayHigh)
                _currentDayHigh = candle.High;
            if (candle.Low < _currentDayLow)
                _currentDayLow = candle.Low;

            if (!_hasPreviousDay)
            {
                _richtungPlot[bar] = 0;
                return;
            }

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

            _richtungPlot[bar] = TageskontextState.Richtung == TagesRichtung.Long ? 1
                : TageskontextState.Richtung == TagesRichtung.Short ? -1
                : 0;
        }
    }
}
