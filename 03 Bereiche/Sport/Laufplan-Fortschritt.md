---
tags: [sport, laufen, cockpit]
---

# Laufplan-Fortschritt

Datenquelle für die Panel-Kachel "Laufen" im Jarvis-Interface (`/panels/status`).
Basiert auf dem Aufbauplan [[Laufplan Halbmarathon November 2026]]. Jarvis liest diese Notiz nur — trage
hier ein, was du wirklich gelaufen bist, nicht was der Plan vorsieht.

**Kopfwerte** (eine Zeile je Wert, genau diese Schlüssel):

ziel_datum: 2026-11-21
ziel_distanz_km: 21.1

**Format:** eine Zeile pro Lauf. `Typ` ist eines von `tempo`, `locker`, `lang`. `Ist-KM`
und `Zeit` leer lassen, wenn der Lauf noch nicht stattgefunden hat.

| Datum | Woche | Typ | Soll-KM | Ist-KM | Zeit | Kommentar |
|---|---|---|---|---|---|---|
| <2026-09-16> | <W1> | <tempo> | <7> | | | Zeile löschen, sobald du wirklich läufst |

## Legende

- **tempo** — Dienstagslauf, Intervalle/Tempodauerlauf
- **locker** — Donnerstagslauf, ruhiges GA1
- **lang** — Samstagslauf, der wöchentliche lange Lauf

Verwandt: [[Sport]], [[Trainingsplan-Fortschritt]]
