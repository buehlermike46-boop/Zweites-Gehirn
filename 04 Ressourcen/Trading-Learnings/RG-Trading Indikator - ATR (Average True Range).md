---
tags: [ressource, trading, rg-trading, indikator]
date: 2026-09-08
quelle: RG-Trading Academy Kurs, Lektion "ATR (Average True Range)", 08.09.2026
---

# ATR (Average True Range)

Volatilitätsindikator, Baustein für [[RG-Trading Indikator - Supertrend]] und Basis für ATR-basierte Stop-Loss-Größen in den Nasdaq-Scalping-Setups (siehe [[Nasdaq-Scalping Setups (Katalog)]]).

## Was der ATR misst

Der ATR sagt **nichts über die Richtung** des Preises aus, nur über die **Volatilität**: hoher ATR = starke Schwankungen, niedriger ATR = ruhiger Markt.

## Berechnung

1. **True Range (TR)** pro Kerze: `TR = Max(High − Low, |High − Vortages-Close|, |Low − Vortages-Close|)`
2. **ATR** = gleitender Durchschnitt der TR-Werte über n Perioden (Standard: 14): `ATR = Summe der letzten 14 TR-Werte / 14`
3. Danach dynamisch angepasst: `Neuer ATR = (Vorheriger ATR × (n−1) + Aktueller TR) / n`

## Anwendung

- **Stop-Loss:** Stop z.B. auf 1,5 × ATR vom Einstiegspreis entfernt setzen. Hoher ATR → größere Stops, niedriger ATR → engere Stops.
- **Trendfolge-Indikatoren:** Der [[RG-Trading Indikator - Supertrend|Supertrend]] nutzt den ATR, um seine Bänder dynamisch an die Volatilität anzupassen.
