// Location-Indikator, laeuft auf Mikes ES "0/2/3R US" Range-Chart (bestaetigt 21.09.2026 per
// Screenshot - NICHT auf einem zeitbasierten ES-Chart, siehe [[NQ Abpraller-Setup Checkliste]]
// Punkt 3 "Location").
//
// Baut ein Session-Volume-Profil aus den Cluster-/Footprint-Daten jeder Kerze auf (Preis ->
// Volumen), daraus POC (Preis mit dem meisten Volumen) und VAH/VAL (Value Area, Standard-Methode:
// vom POC aus abwechselnd die Reihe mit mehr Volumen dazunehmen, bis 70% des Gesamtvolumens der
// Session erreicht sind). 70% ist der Branchenstandard fuer Value Area - Mike hat das nicht
// einzeln bestaetigt, bei Bedarf leicht als Konstante anpassbar (siehe ValueAreaPercent unten).
//
// API bestaetigt am 21.09.2026 per Objektkatalog gegen Mikes Installation: candle.GetAllPriceLevels()
// gibt direkt eine Liste von ATAS.Indicators.PriceVolumeInfo-Objekten zurueck (Member: Ask, Between,
// Bid, Price, Ticks, Time, Volume) - Preis UND Volumen stecken also schon in jedem Element, ein
// zusaetzlicher candle.GetPriceVolumeInfo(price)-Aufruf ist unnoetig.
//
// WICHTIG zum Instrument: alle Levels hier sind ES-Preise, NICHT NQ-Preise (siehe Projekt-Notiz).
// Checkliste Punkt 3 (Location) prueft, ob ES gerade an seiner eigenen Location reagiert, Punkt 4
// (Setup) prueft separat, ob NQ im selben Moment eine eigene Bestaetigung zeigt - beides zusammen
// ergibt den Einstieg, nicht ein Preisvergleich zwischen den Instrumenten.
//
// ERWEITERT 21.09.2026 (Mikes Feedback nach dem ersten Live-Test: "nur VAH/VAL ist zu wenig, so
// kriegen wir keinen Trade rein"): LocationState.Richtung wird nicht mehr nur gegen VAH/VAL
// geprueft, sondern gegen eine ganze Liste an Checklisten-Punkt-3-Leveln:
// - VAH, VAL, POC (POC vorher bewusst ausgeschlossen als "Magnet statt Support/Resistance" -
//   das war meine eigene Vorsicht, nicht Mikes Wunsch; die Checkliste listet POC aber explizit als
//   Location-Typ, deshalb jetzt mit drin. Der NQ-seitige POC-Ruecktest aus Checkliste Punkt 4
//   (Footprint) bleibt trotzdem ein eigener, separater Baustein, siehe NqFootprintDelta.cs)
// - Vortageshoch/-tief, Tageshoch/-tief (gleiche Ablehnungs-/Akzeptanz-Logik wie in
//   EsTageskontext.cs, hier aber eigenstaendig nachgebaut statt von dort gelesen, damit
//   EsLocation.cs unabhaengig bleibt und mit dem "nur abgeschlossene Kerzen"-Takt dieser Datei
//   konsistent ist)
// - Ober-/Unterkante Volumenberg ("Volumenbergkante"): siehe FindVolumeClusterEdges() unten -
//   eigene, klar markierte Heuristik (kein Standardalgorithmus wie bei VAH/VAL), noch NICHT an
//   echten Setups kalibriert, Schwellenwert VolumeClusterThreshold bei Bedarf anpassen
// NICHT umgesetzt (bewusst, mangels belastbarer Definition statt geraten): Single Prints (braucht
// TPO-/Zeit-Daten, die wir hier nicht haben) und Range High/Low (Begriff mehrdeutig - koennte
// Globex-Range oder Session-Opening-Range meinen, noch mit Mike zu klaeren)
//
// Reaktion = Ablehnung/Akzeptanz-Muster wie in EsTageskontext.cs Regel 1: Kerze testet ein Level
// von einer Seite an, schliesst aber wieder auf derselben Seite -> Ablehnung in die Gegenrichtung.
// Zeigen mehrere Level gleichzeitig widerspruechliche Richtungen (sehr selten), bleibt es
// sicherheitshalber Neutral statt zu raten.
//
// Verarbeitet bewusst ALLE Kerzen beim Laden aus der Historie (kein "nur letzte Kerze"-Bremse,
// siehe Kommentar dazu in EsTageskontext.cs). Um Live-Ticks der noch laufenden Kerze nicht
// mehrfach ins Profil zu zaehlen, wird eine Kerze erst dann einmalig verarbeitet, wenn die
// naechste Kerze zu laufen beginnt (also garantiert abgeschlossen ist) - das gilt jetzt auch fuer
// Tageshoch/-tief und die Reaktionspruefung, damit alles im selben Takt bleibt.
//
// NEU 22.09.2026: LocationState.Richtung wird zusaetzlich als Plot sichtbar gemacht (-1 Short/
// 0 Neutral/1 Long), gleicher Grund und gleiches Muster wie in EsTageskontext.cs - war bisher
// komplett unsichtbar am Chart.
//
// UEBERARBEITET 22.09.2026 (Mikes Klarstellung per Sprachnachricht, siehe Projekt-Notiz
// "Einstiegslogik neu..." und LocationState.cs): eine Location ist inhaltlich eine Preis-ZONE
// (z.B. "3000-3010"), nicht ein einzelner Punkt - strukturell deckt das die bestehende
// Zwei-Seiten-Pruefung pro Level (von oben getestet -> Ablehnung nach unten ODER von unten
// getestet -> Ablehnung nach oben) schon ab: VAH und VAL wirken dadurch zusammen bereits wie
// die zwei Kanten EINER Zone, ein Volumenberg-Paar (FindVolumeClusterEdges) ist ohnehin schon
// eine Zone, und ein Einzel-Level (POC/Vortag/Tag) ist einfach eine Zone der Breite 0 - keine
// Strukturaenderung noetig. Was sich aendert: "Preis verlaesst die Zone in Kontext-Richtung"
// setzt LocationState.Richtung jetzt auf "scharf" (armed) statt nur fuer eine Kerze zu gelten -
// bleibt bestehen bis verbraucht/ueberschrieben/Sessionwechsel (siehe CheckReaction unten und
// LocationState.cs).

using System.Collections.Generic;
using ATAS.Indicators;
using OFT.Attributes;

namespace RgTrading.Indicators
{
    [DisplayName("RG Location (ES Range US)")]
    public class EsLocation : Indicator
    {
        private const decimal ValueAreaPercent = 0.70m;

        // Ein Preis-Level zaehlt zu einem "Volumenberg", wenn sein Volumen mindestens diesen
        // Anteil des staerksten Levels (POC-Volumen) der Session erreicht. Eigene Heuristik, noch
        // nicht an echten Setups kalibriert - bei zu vielen/zu wenigen Kanten anpassen.
        private const decimal VolumeClusterThreshold = 0.40m;

        private readonly ValueDataSeries _richtungPlot = new ValueDataSeries("Location-Richtung");

        private readonly Dictionary<decimal, decimal> _volumeByPrice = new Dictionary<decimal, decimal>();
        private int _lastAddedBar = -1;

        private decimal _previousDayHigh;
        private decimal _previousDayLow;
        private decimal _currentDayHigh;
        private decimal _currentDayLow;
        private bool _hasPreviousDay;

        public EsLocation() : base(true)
        {
            DataSeries[0] = _richtungPlot;
        }

        protected override void OnCalculate(int bar, decimal value)
        {
            if (bar == 0)
            {
                _volumeByPrice.Clear();
                _lastAddedBar = -1;
                _currentDayHigh = 0;
                _currentDayLow = 0;
                _hasPreviousDay = false;
            }

            if (IsNewSession(bar))
            {
                _volumeByPrice.Clear();
                _lastAddedBar = bar - 1;
                LocationState.HasProfile = false;
                LocationState.Richtung = TagesRichtung.Neutral;

                if (_currentDayHigh != 0)
                {
                    _previousDayHigh = _currentDayHigh;
                    _previousDayLow = _currentDayLow;
                    _hasPreviousDay = true;
                }

                var newSessionCandle = GetCandle(bar);
                _currentDayHigh = newSessionCandle.High;
                _currentDayLow = newSessionCandle.Low;
            }

            // Nur abgeschlossene Kerzen einrechnen, sonst wird die noch laufende Kerze bei jedem
            // Tick mehrfach gezaehlt
            while (_lastAddedBar < bar - 1)
            {
                _lastAddedBar++;
                AddCandleToProfile(_lastAddedBar);
                UpdateDayHighLow(_lastAddedBar);
                CheckReaction(_lastAddedBar);
            }

            RecalculateProfile();
        }

        private void AddCandleToProfile(int completedBar)
        {
            var candle = GetCandle(completedBar);

            foreach (var level in candle.GetAllPriceLevels())
            {
                if (_volumeByPrice.TryGetValue(level.Price, out var existingVolume))
                    _volumeByPrice[level.Price] = existingVolume + level.Volume;
                else
                    _volumeByPrice[level.Price] = level.Volume;
            }
        }

        private void UpdateDayHighLow(int completedBar)
        {
            var candle = GetCandle(completedBar);

            if (candle.High > _currentDayHigh)
                _currentDayHigh = candle.High;
            if (candle.Low < _currentDayLow)
                _currentDayLow = candle.Low;
        }

        private void RecalculateProfile()
        {
            if (_volumeByPrice.Count == 0)
                return;

            decimal poc = 0;
            var maxVolume = -1m;
            var totalVolume = 0m;

            foreach (var level in _volumeByPrice)
            {
                totalVolume += level.Value;

                if (level.Value > maxVolume)
                {
                    maxVolume = level.Value;
                    poc = level.Key;
                }
            }

            var sortedPrices = new List<decimal>(_volumeByPrice.Keys);
            sortedPrices.Sort();

            var pocIndex = sortedPrices.IndexOf(poc);
            var lowIndex = pocIndex;
            var highIndex = pocIndex;
            var accumulated = _volumeByPrice[poc];
            var target = totalVolume * ValueAreaPercent;

            while (accumulated < target && (lowIndex > 0 || highIndex < sortedPrices.Count - 1))
            {
                var volumeBelow = lowIndex > 0 ? _volumeByPrice[sortedPrices[lowIndex - 1]] : -1m;
                var volumeAbove = highIndex < sortedPrices.Count - 1 ? _volumeByPrice[sortedPrices[highIndex + 1]] : -1m;

                if (volumeAbove >= volumeBelow)
                {
                    highIndex++;
                    accumulated += _volumeByPrice[sortedPrices[highIndex]];
                }
                else
                {
                    lowIndex--;
                    accumulated += _volumeByPrice[sortedPrices[lowIndex]];
                }
            }

            LocationState.Poc = poc;
            LocationState.Vah = sortedPrices[highIndex];
            LocationState.Val = sortedPrices[lowIndex];
            LocationState.HasProfile = true;
        }

        // Ober-/Unterkante Volumenberg: findet zusammenhaengende Preisbereiche, deren Volumen
        // ueber VolumeClusterThreshold des POC-Volumens liegt (ein "Volumenberg"), und gibt fuer
        // jeden gefundenen Bereich Unter- und Oberkante zurueck. Ein Tag kann mehrere solcher
        // Berge haben (z.B. zwei getrennte Balance-Bereiche) - VAH/VAL decken nur den einen
        // Hauptbereich um den POC ab, das hier findet auch die anderen.
        private List<decimal> FindVolumeClusterEdges()
        {
            var edges = new List<decimal>();

            if (_volumeByPrice.Count == 0)
                return edges;

            var maxVolume = 0m;
            foreach (var volume in _volumeByPrice.Values)
                if (volume > maxVolume)
                    maxVolume = volume;

            var threshold = maxVolume * VolumeClusterThreshold;

            var sortedPrices = new List<decimal>(_volumeByPrice.Keys);
            sortedPrices.Sort();

            var inCluster = false;
            var clusterLow = 0m;

            for (var i = 0; i < sortedPrices.Count; i++)
            {
                var isAboveThreshold = _volumeByPrice[sortedPrices[i]] >= threshold;

                if (isAboveThreshold && !inCluster)
                {
                    inCluster = true;
                    clusterLow = sortedPrices[i];
                }
                else if (!isAboveThreshold && inCluster)
                {
                    inCluster = false;
                    edges.Add(clusterLow);
                    edges.Add(sortedPrices[i - 1]);
                }
            }

            if (inCluster)
                edges.Add(clusterLow);

            return edges;
        }

        private List<decimal> CollectLocationLevels()
        {
            var levels = new List<decimal> { LocationState.Vah, LocationState.Val, LocationState.Poc };

            if (_hasPreviousDay)
            {
                levels.Add(_previousDayHigh);
                levels.Add(_previousDayLow);
            }

            if (_currentDayHigh != 0)
            {
                levels.Add(_currentDayHigh);
                levels.Add(_currentDayLow);
            }

            levels.AddRange(FindVolumeClusterEdges());

            return levels;
        }

        private void CheckReaction(int completedBar)
        {
            // Ohne Profil (z.B. allererste Kerze der Session) noch keine Level zum Pruefen
            if (!LocationState.HasProfile)
            {
                LocationState.Richtung = TagesRichtung.Neutral;
                _richtungPlot[completedBar] = 0;
                return;
            }

            var candle = GetCandle(completedBar);
            var levels = CollectLocationLevels();

            var longFound = false;
            var shortFound = false;

            foreach (var level in levels)
            {
                // Level von oben angetestet, aber Schluss wieder darunter -> Ablehnung -> bearish
                if (candle.High > level && candle.Close < level)
                    shortFound = true;
                // Level von unten angetestet, aber Schluss wieder darueber -> Ablehnung -> bullish
                else if (candle.Low < level && candle.Close > level)
                    longFound = true;
            }

            if (longFound && !shortFound)
                LocationState.Richtung = TagesRichtung.Long;
            else if (shortFound && !longFound)
                LocationState.Richtung = TagesRichtung.Short;
            // sonst: keine (eindeutige) Reaktion auf dieser Kerze -> vorherigen "scharfen"
            // Zustand NICHT zuruecksetzen (Redesign 22.09.2026, siehe Kommentar oben) - Location
            // bleibt armed bis eine neue Reaktion sie ueberschreibt oder die naechste Session sie
            // zuruecksetzt (siehe IsNewSession-Block oben).

            _richtungPlot[completedBar] = LocationState.Richtung == TagesRichtung.Long ? 1
                : LocationState.Richtung == TagesRichtung.Short ? -1
                : 0;
        }
    }
}
