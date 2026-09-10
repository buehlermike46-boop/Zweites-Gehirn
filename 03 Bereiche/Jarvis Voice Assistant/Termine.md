---
tags: [jarvis, termine, cockpit]
---

# Termine

Datenquelle für die Cockpit-Kachel "Termine" im Jarvis-Interface (`/cockpit/status`)
und für die Sprachansage bei "Jarvis activate".

**Format:** `- JJJJ-MM-TT HH:MM | Titel` — die Uhrzeit ist optional (ohne Uhrzeit =
ganztägig). Vergangene Termine blendet das Cockpit automatisch aus, du musst hier
nichts aufräumen.

- 2026-09-11 | Kinderwochenende (bis So 13.09.)
- 2026-09-25 | Kinderwochenende (bis So 27.09.)

## Woher die Einträge kommen

Stand heute aus deinem Google Kalender (buehlermike46@gmail.com), übertragen von der
großen Claude-Session. Der Jarvis-Server selbst hat keinen Kalender-Zugriff — er liest
nur diese Notiz. Wenn du willst, kann die tägliche Kalender-Zusammenfassung um 06:30
diese Liste künftig automatisch mit aktualisieren.
