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
// WICHTIG zum Instrument: POC/VAH/VAL werden in ES-Preisen berechnet, NICHT in NQ-Preisen (beide
// Instrumente haben komplett unterschiedliche Preisniveaus, ein direkter Preisvergleich zwischen
// ES-Level und NQ-Kurs waere sinnlos). Die Checkliste sieht das auch so vor: Punkt 3 (Location)
// prueft, ob ES gerade an seiner eigenen Location reagiert, Punkt 4 (Setup) prueft separat, ob NQ
// im selben Moment eine eigene Bestaetigung zeigt (Demand Index, Footprint) - beides zusammen
// ergibt den Einstieg, nicht ein Preisvergleich zwischen den Instrumenten.
//
// Reaktion/Richtung (LocationState.Richtung): High toucht/ueberschreitet VAH, Kerze schliesst
// aber wieder darunter -> Ablehnung an VAH -> bearish (Short). Spiegelbildlich fuer VAL -> bullish
// (Long). Gleiche Ablehnungs-/Akzeptanz-Logik wie in EsTageskontext.cs (Regel 1), nur auf VAH/VAL
// statt Vortageshoch/-tief angewendet. POC bewusst NICHT als Ablehnungs-Level behandelt - POC
// wirkt eher wie ein Magnet/Pivot als wie Support/Resistance, und der POC-Ruecktest aus Checkliste
// Punkt 4 (NQ-Footprint) ist ohnehin ein eigener, separater Baustein (siehe NqFootprintDelta.cs).
// LocationState.Richtung wird bei JEDER abgeschlossenen Kerze neu gesetzt (auch auf Neutral
// zurueckgesetzt, falls keine Reaktion vorliegt) - kein Tages-Flag wie TageskontextState.Richtung.
//
// Verarbeitet bewusst ALLE Kerzen (keine "nur letzte Kerze"-Bremse wie in NqTestStrategy.cs) -
// dieser Indikator platziert keine Orders, sondern baut nur das Profil auf. Damit steht das
// Session-Profil sofort beim Laden aus der Historie zur Verfuegung, statt erst nach einem neuen
// Live-Sessionwechsel "warmzulaufen". Aus demselben Grund wurde derselbe historische
// Verarbeitungs-Bremse (bar < CurrentBar - 1) heute auch aus EsTageskontext.cs entfernt, siehe
// Kommentar dort und Projekt-Notiz.
//
// Um Live-Ticks der noch laufenden Kerze nicht mehrfach ins Profil zu zaehlen (OnCalculate feuert
// pro Tick, nicht nur beim Kerzenabschluss), wird eine Kerze erst dann einmalig ins Profil
// aufgenommen, wenn die naechste Kerze zu laufen beginnt (also garantiert abgeschlossen ist).
//
// API bestaetigt am 21.09.2026 per Objektkatalog gegen Mikes Installation: candle.GetAllPriceLevels()
// gibt direkt eine Liste von ATAS.Indicators.PriceVolumeInfo-Objekten zurueck (Member: Ask, Between,
// Bid, Price, Ticks, Time, Volume) - Preis UND Volumen stecken also schon in jedem Element, ein
// zusaetzlicher candle.GetPriceVolumeInfo(price)-Aufruf ist unnoetig (erste Fassung hat das noch
// falsch angenommen und dabei ein PriceVolumeInfo-Objekt als "price"-Argument uebergeben, daher der
// Build-Fehler CS1503).

using System.Collections.Generic;
using ATAS.Indicators;
using OFT.Attributes;

namespace RgTrading.Indicators
{
    [DisplayName("RG Location (ES Range US)")]
    public class EsLocation : Indicator
    {
        private const decimal ValueAreaPercent = 0.70m;

        private readonly Dictionary<decimal, decimal> _volumeByPrice = new Dictionary<decimal, decimal>();
        private int _lastAddedBar = -1;

        public EsLocation() : base(true)
        {
        }

        protected override void OnCalculate(int bar, decimal value)
        {
            if (bar == 0)
            {
                _volumeByPrice.Clear();
                _lastAddedBar = -1;
            }

            if (IsNewSession(bar))
            {
                _volumeByPrice.Clear();
                _lastAddedBar = bar - 1;
                LocationState.HasProfile = false;
                LocationState.Richtung = TagesRichtung.Neutral;
            }

            // Nur abgeschlossene Kerzen einrechnen, sonst wird die noch laufende Kerze bei jedem
            // Tick mehrfach gezaehlt
            while (_lastAddedBar < bar - 1)
            {
                _lastAddedBar++;
                AddCandleToProfile(_lastAddedBar);
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

        private void CheckReaction(int completedBar)
        {
            // Ohne Profil (z.B. allererste Kerze der Session) noch keine VAH/VAL zum Pruefen
            if (!LocationState.HasProfile)
            {
                LocationState.Richtung = TagesRichtung.Neutral;
                return;
            }

            var candle = GetCandle(completedBar);

            // VAH angetestet, aber Schluss wieder darunter -> Ablehnung an VAH -> bearish
            if (candle.High > LocationState.Vah && candle.Close < LocationState.Vah)
            {
                LocationState.Richtung = TagesRichtung.Short;
            }
            // VAL angetestet, aber Schluss wieder darueber -> Ablehnung an VAL -> bullish
            else if (candle.Low < LocationState.Val && candle.Close > LocationState.Val)
            {
                LocationState.Richtung = TagesRichtung.Long;
            }
            else
            {
                LocationState.Richtung = TagesRichtung.Neutral;
            }
        }
    }
}
