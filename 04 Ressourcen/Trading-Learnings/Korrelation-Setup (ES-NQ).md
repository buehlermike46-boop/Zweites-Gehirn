---
tags: [ressource, trading, rg-trading, setup]
date: 2026-09-08
quelle: RG-Trading Academy Kurs, Kapitel "Nasdaq Scalping", Lektion "Korrelation-Setup", 08.09.2026
---

# Korrelation-Setup (ES → NQ)

Setup aus [[Nasdaq-Scalping Setups (Katalog)]], nutzt die enge Korrelation zwischen ES (S&P 500 Future) und NQ (Nasdaq-100 Future). Ergänzt den "ES bestätigt?"-Filter aus [[NQ Abpraller-Setup Checkliste]] um eine eigene Setup-Logik.

## Grundidee

ES und NQ bewegen sich meist synchron. Man beobachtet ES an einer Location (VAH/vPOC/VAL) mit dem [[RG-Trading Indikator - Demand Index|Demand Index]] und prüft, ob NQ zeitgleich dieselbe Reaktion zeigt (gleiche Richtung, ähnliches Demand-Index-Verhalten). Bestätigt NQ die ES-Bewegung, ist das Setup gültig.

## Ablauf

1. ES-Chart und NQ-Chart parallel beobachten (je eigener Range-Chart, z.B. RangeUS 0/2/3 bzw. 0/5/12).
2. An einer Location im ES (VAH/vPOC/VAL) auf eine Reaktion warten, z.B. Ablehnung oder Reversal, mit passendem Demand-Index-Ausschlag.
3. Prüfen, ob NQ zeitgleich dieselbe Bewegung zeigt (synchrone Kerzen, ähnlicher Demand-Index-Verlauf).
4. Nur wenn beide Märkte übereinstimmen (Korrelation bestätigt) wird der Trade im NQ eingegangen.

## Praktischer Hinweis

Aus den Kursbeispielen: die Footprint-Delta-Werte (Range-Kerzen mit MIN/MAX-Delta) werden auf beiden Charts parallel mitgelesen, nicht nur der Demand Index. Ziel ist, dass ein Setup im NQ nicht isoliert gehandelt wird, sondern nur wenn ES die gleiche Marktrichtung stützt, das reduziert Fehlsignale bei Divergenzen zwischen den beiden Indizes.
