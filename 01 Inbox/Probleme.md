---
tags: [inbox, probleme, cockpit]
---

# Probleme

Datenquelle für die Panel-Kachel "Probleme" im Jarvis-Interface (`/panels/status`). Kurzer
Sammelort für Blocker/offene Probleme, egal ob Business, Trading, Technik oder privat —
nicht jedes Problem braucht gleich ein eigenes Projekt. Jarvis liest diese Notiz nur, du
(oder die Bridge) pflegt sie.

**Format:** eine Zeile pro Problem. `Status` ist eines von `offen`, `gelöst`.

| Datum | Bereich | Problem | Status |
|---|---|---|---|
| <2026-09-09> | <Beispiel> | <Kurze Beschreibung> | offen |
| 2026-09-11 | Jarvis Voice Assistant | Frontend (localhost:8340, Wissensgraph) zeigt "Verbindung verloren...", Backend-Server vermutlich abgestürzt oder nicht erreichbar. Ursache noch unklar, jarvis.log prüfen. | offen |
