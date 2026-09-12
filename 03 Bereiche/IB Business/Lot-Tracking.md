---
tags: [ib, finanzen, tracking]
status: aktiv
date: 2026-09-12
---

# Lot-Tracking

Die zentrale Steuergröße des IB-Projekts (siehe [[IB-Projekt (Limitless & PU Prime)]] und
[[MasterPlan - Teilziele und Zeitplan bis 50.000 EUR]], Stufe 0: "Lot-Tracking läuft:
Gesamt-Lots, Lots je Kunde, erreichte Staffelstufe"). Ohne diese Tabelle wird das
Gesamt-Handelsvolumen pro Monat nirgends gemessen — genau das ist laut "Nächste 30 Tage"
im MasterPlan eines der fünf Erfolgskriterien ("Gesamt-Lots zum ersten Mal überhaupt
gemessen").

## Staffel (PU Prime, Stand 08.09.2026, bestätigt — siehe [[IB-Projekt (Limitless & PU Prime)]])

Gehandelt wird Gold. Die Staffel gilt **nicht rückwirkend** (bestätigt 10.09.2026): jede
Stufe zahlt nur für die Lots *innerhalb* ihrer Spanne, nicht für den gesamten Monat.

| Lots im Monat | Provision je Lot in dieser Spanne |
|---|---|
| 1 – 49 | 15 € |
| 50 – 99 | 17 € |
| ab 100 | 19 € |

Beispiel: 120 Lots im Monat = 49×15 € + 50×17 € + 21×19 € = 735 € + 850 € + 399 € = 1.984 €.

## Gesamt-Lots pro Monat

**Kopfwerte (von Hand oder über die Bridge aktualisieren):**

aktueller_monat: 2026-09
gesamt_lots_monat: 0
staffelstufe_aktuell: 15 €/Lot (bis 49 Lots)
kommission_monat_geschaetzt: 0

| Monat | Gesamt-Lots | Kommission (geschätzt) | Quelle |
|---|---|---|---|
| 2026-09 | 0 | 0 € | [[Broker-Dashboards]] (Limitless: 0 Referrals; PU Prime deaktiviert, siehe unten) |

## Lots je Kunde

Noch keine echten Kunden (siehe [[Kunden]], Live-Checks 08./09.09.2026: 0 externe
Leads/Kunden bei PU Prime und Limitless). Tabelle ist vorbereitet, sobald der erste
Kunde ein Konto über den Link eröffnet:

| Name | Broker | Lots (dieser Monat) | Lots (gesamt seit Start) | Erreichte Staffelstufe | Notiz |
|---|---|---|---|---|---|
| <Beispiel Max Mustermann> | PU Prime | 0 | 0 | 15 €/Lot | Zeile löschen, sobald echte Kunden drinstehen |

## Woher die Zahlen kommen

- **PU Prime** ist seit 10.09.2026 aus der automatischen Broker-Bridge draußen
  (`PUPRIME_ENABLED = False` in `broker_bridge.py`, Cloudflare-Bot-Check verhindert
  Auslesen im dedizierten Profil, siehe [[Jarvis Hand - Agenten Ausbau]]). PU-Prime-Lots
  kommen bis auf Weiteres nur über einen manuellen Abruf durch Mike (Claude in Chrome,
  eingeloggte Session) oder eine eigene Zeile, die er selbst einträgt.
- **Limitless** liefert über dieselbe Bridge automatisch `limitless_total_referred` etc.
  in [[Broker-Dashboards]] — aktuell 0. Sobald dort Referrals auftauchen, in diese Tabelle
  übernehmen (Lots stehen bei Limitless selbst nicht direkt drin, nur Referral-Zahlen,
  die eigentlichen Lot-Zahlen kommen von PU Prime).
- Diese Notiz selbst wird nicht automatisch beschrieben (kein Cockpit-Endpoint dafür
  vorgesehen) — von Hand oder auf Zuruf aktualisieren, sobald neue Zahlen da sind.

## Offene Punkte

- Sobald der erste echte Kunde/Lot auftaucht: Kopfwerte und beide Tabellen mit echten
  Zahlen befüllen, Beispielzeilen löschen.
- Prüfen, ob sich `broker_bridge.py` so erweitern lässt, dass Lots direkt aus dem
  PU-Prime-Dashboard hierher geschrieben werden, sobald der Cloudflare-Block irgendwann
  fällt (siehe `PUPRIME_ENABLED`-Schalter in [[Jarvis Hand - Agenten Ausbau]]).

Verwandt: [[IB-Projekt (Limitless & PU Prime)]] · [[Kunden]] · [[Einnahmen]] ·
[[Broker-Dashboards]] · [[MasterPlan - Teilziele und Zeitplan bis 50.000 EUR]]
