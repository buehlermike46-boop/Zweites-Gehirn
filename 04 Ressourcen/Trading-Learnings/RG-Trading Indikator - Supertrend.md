---
tags: [ressource, trading, rg-trading, indikator]
date: 2026-09-08
quelle: RG-Trading Academy Kurs, Lektion "Supertrend Indikator", 08.09.2026
---

# Supertrend Indikator

Trendfolge-Indikator, in praktisch allen Nasdaq-Scalping-Setups als Bestätigungsfilter verwendet (siehe [[Nasdaq-Scalping Setups (Katalog)]]). Baut auf [[RG-Trading Indikator - ATR (Average True Range)|ATR]] auf. Eigene RG-Trading-Variante existiert zusätzlich als "RG-Trading Super Trend Indikator".

## Grundprinzip

Wie eine Ampel: **Grün = Go** (Aufwärtstrend, sicherer zu kaufen), **Rot = Stop** (Abwärtstrend, sicherer zu verkaufen/nicht zu kaufen). Die Linie bleibt im Aufwärtstrend unter dem Preis (grün), im Abwärtstrend über dem Preis (rot).

## Berechnung

1. **Mittlerer Preis:** `(High + Low) / 2`
2. **Obere Bande:** `Mittlerer Preis + (Multiplier × ATR)`
3. **Untere Bande:** `Mittlerer Preis − (Multiplier × ATR)`
4. **Regeln:** Preis schließt über oberer Bande → Linie wird grün (Kaufsignal). Preis schließt unter unterer Bande → Linie wird rot (Verkaufssignal).

Beispiel: ATR=10, Multiplier=3, High=150, Low=145 → Mittlerer Preis=147,5 → Obere Bande=177,5, Untere Bande=117,5.

Der Multiplier bestimmt die Sensitivität: kleiner Multiplier (z.B. 2) = empfindlicher, größerer Multiplier (z.B. 5) = glatter, weniger Fehlsignale.

## Verwendung in den Setups

Ein Bruch der Supertrend-Linie signalisiert einen potenziellen Trendwechsel bzw. -start und dient in den Nasdaq-Setups meist als zweite Bestätigung neben dem [[RG-Trading Indikator - Demand Index|Demand Index]].
