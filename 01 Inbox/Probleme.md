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
| 2026-09-11 | Jarvis Voice Assistant | Frontend (localhost:8340) zeigte "Verbindung verloren...". Ursache gefunden: kein Server-Absturz, sondern das separate Anthropic-API-Konto (console.anthropic.com, genutzt von server.py/task_agent.py für Claude Haiku/Sonnet) hat kein Guthaben mehr ("credit balance too low"). Fix: dort Guthaben aufladen. | offen (wartet auf Aufladen) |
