---
tags: [ressource, trading, rg-trading]
date: 2026-09-08
quelle: RG-Trading Academy Kurs, Lektionen "Heikin Ashi Reversal Setup" und "Heikin Ashi Smoothed Reversal/Breakout Setup", 08.09.2026
---

# Heikin-Ashi Kerzen (Grundlagen)

Grundlage für [[Heikin Ashi Reversal-Setup]] und [[Heikin Ashi Smoothed Reversal-Breakout-Setup]], Teil von [[Nasdaq-Scalping Setups (Katalog)]].

## Was ist Heikin-Ashi

Technik zur Darstellung von Kursdaten, die Trends glättet und Marktrauschen reduziert. Berechnet aus Open/High/Low/Close, aber auf besondere geglättete Weise. Erfunden vom japanischen Reishändler Munehisa Homma (ca. 1700), der als Vater der technischen Analyse gilt ("The Fountain Of Gold", 1755).

Gegenüber normalen Candlesticks: weniger Rauschen, klarere Trendanzeige (z.B. viele grüne Kerzen ohne unteren Docht im Aufwärtstrend), aber die Kerzen zeigen **nicht die echten Marktpreise**.

## Die 4 Formeln

- **HA-Close** = (Open + High + Low + Close) / 4 → geglätteter Schlusskurs.
- **HA-Open** = (voriger HA-Open + voriger HA-Close) / 2 → fließender Übergang zwischen Kerzen.
- **HA-High** = max(High, HA-Open, HA-Close) → geglättete Obergrenze.
- **HA-Low** = min(Low, HA-Open, HA-Close) → geglättete Untergrenze.

Nur die Kombination aller vier Formeln ergibt den typischen geglätteten Heikin-Ashi-Verlauf.

## Wichtige Einschränkung

Da Open/Close geglättete Durchschnittswerte sind, entsprechen sie **nicht** den echten Marktpreisen. Stops und Kursalarme deshalb immer nach den echten Kursen setzen, nicht nach den Heikin-Ashi-Werten (siehe Risikomanagement-Hinweis in [[Heikin Ashi Smoothed Reversal-Breakout-Setup]]).
