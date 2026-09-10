---
tags: [ib, finanzen, cockpit]
---

# Verdienste & Kontostand

Datenquelle für die Cockpit-Kachel "Verdienste" im Jarvis-Interface (`/cockpit/status`).
Jarvis liest diese Notiz nur.

**Kopfwerte** (eine Zeile je Wert, genau diese Schlüssel):

kontostand: 0
ziel_monat: 50000
waehrung: EUR

**Monatswerte:** eine Zeile pro Einnahme, `Monat` im Format JJJJ-MM. Mehrere Zeilen
pro Monat werden addiert, so kannst du nach Quelle trennen.

| Monat | Einnahmen | Quelle |
|---|---|---|
| 2026-09 | 0 | IB-Kommission Limitless / PU Prime |

## Hinweis

Solange die Broker-Auswertung nicht angebunden ist, trägst du die Zahlen hier von Hand
ein (oder sagst es Jarvis, dann macht es die Bridge). Sobald PU Prime / Limitless eine
Auswertung liefert, kann derselbe Cockpit-Endpoint stattdessen von dort lesen — das
Format hier bleibt gleich.

## Live-Check 08.09.2026 (Nachmittag)

Auf Wunsch direkt im PU-Prime-IB-Dashboard (`hub.primeverse.ca`) und bei Limitless
(`worldoflimitless.com/affiliate`) nach echten Zahlen gesucht (Claude in Chrome, Mikes
eingeloggte Sessions, kein Passwort eingegeben). **Ergebnis: 0 € Provision, 0 Referrals,
0 Lots externes Handelsvolumen** — kein Kunde außer Mikes eigenem Test-Account (0,01 Lose,
1 USD Einlage), keinen Earnings-Bereich mit Euro-/Dollar-Betrag im Affiliate-Dashboard
gefunden. `kontostand` bleibt daher bewusst auf 0 (echte IB-Provision, nicht das separate
persönliche Trading-Konto). Details: [[PU Prime]], [[Limitless]]
(`04 Ressourcen/Persönliches Datenarchiv/Trading-Konten/`).

**Separat davon:** Mikes persönliches PU-Prime-Handelskonto (`myaccount.puprime.com`,
MT5/MT4) zeigte bei einem früheren Abruf heute ca. 1,48 € Saldo — das ist sein eigenes
Trading-Guthaben, nicht IB-Provision, deshalb bewusst nicht hier eingetragen. Die
Login-Session dort ist inzwischen abgelaufen; sag Bescheid, wenn du dich dort neu einloggst,
dann hol ich den aktuellen Kontostand nach.

Verwandt: [[Kunden]], [[IB-Projekt (Limitless & PU Prime)]]
