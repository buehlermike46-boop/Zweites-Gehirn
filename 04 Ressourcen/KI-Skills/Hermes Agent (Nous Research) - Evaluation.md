---
tags: [ressource, ki-tool, evaluation]
date: 2026-09-07
status: abgeschlossen
---

# Hermes Agent (Nous Research) - Evaluation

Am 07.09.2026 isoliert getestet als möglicher Baustein für [[Jarvis Hand - Agenten Ausbau]]. Ergebnis: **nicht für Telegram/Nachrichten-Automatisierung geeignet**, siehe unten. Repo: https://github.com/NousResearch/hermes-agent

## Was es ist
Open-Source, selbstlernender KI-Agent-Framework von Nous Research. MIT-Lizenz. Stand 07.09.2026: 243.000 Sterne, 50.000 Forks, aber auch 40.500 offene Issues (Zahlen per direktem GitHub-API-Call verifiziert, nicht nur Repo-Beschreibung geglaubt).

- CLI-basiert (`hermes`), plus optional Desktop-App
- Multi-Plattform-Messaging: Telegram, Discord, Slack, WhatsApp, Signal, u.v.m.
- Freie Modellwahl (Anthropic, OpenAI, OpenRouter, Nous Portal, eigener Endpoint, 40+ Provider)
- Große Skill-Bibliothek (54 Skills bei Installation): Recherche, PDF/Office, Code-Review, Notion/Airtable, Preis-Monitoring, u.a. — auch ein **"obsidian"-Skill**
- Terminal-Backend konfigurierbar: Local, Docker (isoliert), Modal, SSH, Daytona, Vercel Sandbox

## Installations-Vorsicht (falls das nochmal jemand macht)
Der offizielle Installer (`irm .../install.ps1 | iex`) wurde vor Ausführung komplett gelesen (5000+ Zeilen), nicht blind ausgeführt. Fund: **standardmäßig lädt er zusätzlich einen Computer-Use-Treiber von einem DRITTEN GitHub-Projekt (`trycua/cua`, nicht Nous Research selbst) und führt den per `Invoke-Expression` aus** — gibt dem Agent Maus/Tastatur/Bildschirm-Kontrolle. Mit `-SkipComputerUse` umgangen. Sonst wirkte der Installer sauber (nur bekannte Quellen: astral.sh/uv, git-scm.com, nodejs.org, GitHub selbst).

## Das "obsidian"-Skill — keine echte Integration
Rein informativ per `skill_view` geprüft, nichts ausgeführt. Ergebnis: **kein Obsidian-API/Plugin-Zugriff**, nur ein Best-Practice-Regelwerk (SKILL.md) wie man mit den generischen Datei-Tools (read_file/write_file/patch/search_files) sauber auf einen Vault-Ordner zugreift (Wikilinks beachten, nie blind überschreiben, Pfad über `OBSIDIAN_VAULT_PATH` auflösen). Im Kern dieselbe Idee wie unser eigener `task_agent.py` in [[Jarvis Voice Assistant]], nur als wiederverwendbares Skill verpackt — kein Mehrwert gegenüber dem was schon existiert.

## Kritischer Befund: Kein Freigabe-Mechanismus für ausgehende Nachrichten
Das war der Ausschlussgrund. Geprüft direkt in der offiziellen Doku (nicht nur im Repo-README):
- `approvals.mode` (smart/manual/off) bezieht sich NUR auf potenziell gefährliche Shell-Befehle (`rm -rf`, `git reset --hard` etc.), NICHT auf Chat-/Gateway-Nachrichten.
- Laut https://hermes-agent.nousresearch.com/docs/user-guide/messaging: *"Each platform adapter receives messages ... and dispatches them to the AIAgent for processing"* — der Agent antwortet automatisch auf eingehende Nachrichten. Keine Entwurf-/Freigabe-Schleife dokumentiert.
- Allowlists (wer den Bot nutzen darf) sind reine Zugriffskontrolle, keine Inhalts-Freigabe.

**Konsequenz:** Würde man Hermes ans Telegram-Gateway anbinden, antwortet es echten eingehenden Nachrichten sofort und automatisch — das widerspricht dem bewusst gewählten "Entwurf-statt-Auto-Antwort"-Prinzip von [[Telegram Nachrichten]] / [[Telegram Persönlich]].

## Entscheidung (07.09.2026)
- Hermes NICHT an Telegram/Vault/Account anbinden.
- Eigenes System (`telegram_bridge.py` / `telegram_userbot_bridge.py`, mit bestätigt funktionierender Freigabe-Pflicht) bleibt der Weg für Nachrichten-Automatisierung.
- Hermes könnte trotzdem nützlich sein als **separates, manuell aufgerufenes Werkzeug** für Aufgaben ohne Nachrichten-Bezug (Recherche, PDF/Office-Arbeit, Code-Review) — unabhängig von Jarvis/der Bridge, kein Zugriff auf echte Daten/Accounts. Noch nicht weiter verfolgt, offen für später falls Bedarf.
- Installiert unter `C:\Users\buehl\AppData\Local\hermes\` (eigener Anthropic-Test-Key, Docker-Sandbox, Blank-Slate-Konfiguration — nichts an echten Vault/Account angebunden).
