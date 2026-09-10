---
tags: [ressource, trading, rg-trading, setup]
date: 2026-09-08
quelle: RG-Trading Academy Kurs, Kapitel "Nasdaq Scalping", Lektionen "Heikin Ashi Smoothed Reversal/Breakout Setup" und "Optimierung - Heikin Ashi Smoothed Reversal Setup", 08.09.2026
---

# Heikin Ashi Smoothed Reversal-/Breakout-Setup

Trendfolge- und Breakout-Setup mit dem **doppelt geglätteten** Heikin-Ashi-Indikator (Heikin-Ashi-Werte zusätzlich mit gleitendem Durchschnitt geglättet). Baut auf [[Heikin-Ashi Kerzen (Grundlagen)]] auf, Teil von [[Nasdaq-Scalping Setups (Katalog)]].

## Warum doppelt geglättet

Kleine Gegenbewegungen werden zusätzlich ausgeblendet, der Chart wirkt noch ruhiger als normales Heikin-Ashi. Grüne Kerzen = Aufwärtstrend, rote = Abwärtstrend, Farbwechsel = potenzieller Umkehrpunkt. Besonders nützlich im volatilen NQ (weniger Fehlsignale), im ruhigeren ES zeigt er stabile Trendbilder.

## Reversal-Variante (Trendfolge nach Pullback)

1. Starken Trend identifizieren (durchgehend gleiche Kerzenfarbe).
2. Anzeichen einer Abschwächung abwarten (kleiner werdende Kerzenkörper).
3. Pullback abwarten, der vom Indikator noch als Trend bestätigt wird (Farbe bleibt).
4. Steigt/fällt der Kurs nach dem Pullback wieder in Trendrichtung und die Kerzenfarbe bleibt bestätigt → Einstieg.

Stop-Loss unter dem letzten Swing-Tief (Long) bzw. über dem letzten Swing-Hoch (Short), Ziel mind. 2-3× Risiko.

## Breakout-Variante

Einstieg direkt beim **Farbwechsel** der geglätteten Kerzen nach einer Konsolidierungsphase (Trendwechsel-Signal), siehe Kursbeispiel "Entry BO" nach markierter Trendwechsel-Box.

## Kombination mit anderen Indikatoren

Wird meist mit [[RG-Trading Indikator - Supertrend|Supertrend]] und/oder [[RG-Trading Indikator - Demand Index|Demand Index]] kombiniert, um Fehlsignale zu reduzieren.

## Wichtige Einschränkungen

- Zeigt **nicht die exakten Preise** (geglättete Durchschnittswerte) — Stops immer nach echten Kurslevels setzen, nicht nach Indikator-Werten (z.B. via [[RG-Trading Indikator - ATR (Average True Range)|ATR]] oder Swing-Hoch/-Tief).
- Reagiert **verzögert** auf plötzliche Wendepunkte (hinkt dem echten Kurs hinterher).
- In Seitwärtsphasen anfällig für **häufige Farbwechsel/Fehlsignale** → auf zusätzliche Bestätigung warten (z.B. Range-Ausbruch).
- Einstellungen anpassbar (Standard oft 10/10, für Scalping kürzer z.B. 5/5, für Swing länger z.B. 20/20). NQ braucht wegen höherer Volatilität ggf. andere Einstellung als ES, per Backtesting ermitteln.

## Praxis-Tipp

Morgens den Haupttrend von ES und NQ auf höherem Zeitrahmen mit Heikin-Ashi Smoothed festlegen (Tages-Bias), danach nur Trades in diese Richtung suchen. Indikator am besten als Overlay über dem normalen Kerzenchart nutzen, um echte Kurse nicht aus den Augen zu verlieren.

## Offen

Die Lektion "Optimierung - Heikin Ashi Smoothed Reversal Setup" ist reine Video-Lektion ohne PDF, vermutlich eine Verfeinerung der Reversal-Variante. Noch nicht im Detail dokumentiert, siehe [[Nasdaq-Scalping Setups (Katalog)]].
