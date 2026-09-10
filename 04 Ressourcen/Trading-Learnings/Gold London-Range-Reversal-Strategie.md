---
tags: [ressource, trading, strategie]
date: 2026-09-06
quelle: ChatGPT, "Goldpreis 1 Jahr Chart", 19.11.2025
---

# Gold: London-Range-Reversal-Strategie (09–10 Uhr)

## Setup
1. Zeitfenster **09:00–10:00 Uhr deutscher Zeit** (Sommer-/Winterzeit beachten) auf Gold (XAUUSD) beobachten.
2. High und Low dieser Stunde markieren → Range High (R-High) und Range Low (R-Low).

## Entry-Regel: Fade des zweiten Extrempunkts
- Bewegt sich der Preis in der Stunde zuerst **hoch, dann runter** (High zuerst, Low danach) → **Buy am Low**, Ziel zurück zum High.
- Bewegt sich der Preis zuerst **runter, dann hoch** (Low zuerst, High danach) → **Sell am High**, Ziel zurück zum Low.
- Es wird also immer der zweite Extrempunkt gefadet, zurück zum ersten.

## Eigene Ausführungsregeln
- **Entry erst nach Bestätigung**, z.B. eine Engulfing-Kerze am Level — nicht blind am exakten High/Low.
- **Stop-Loss** über dem High bzw. unter dem Low.
- **Ziel-CRV: 1:1,5 bis 1:2.**

## Offen / nächste Schritte
ChatGPT konnte hierfür keinen echten automatisierten 1-Jahres-Intraday-Backtest fahren (kein Zugriff auf Rohdaten + Programmierumgebung in dem Chat). Für einen sauberen Backtest: Strategie 1:1 in TradingView, MT4/5 oder Python nachbauen und dort testen.
