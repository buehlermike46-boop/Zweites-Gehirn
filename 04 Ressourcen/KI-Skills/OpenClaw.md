---
tags: [ressource, ki-tool]
date: 2026-09-10
status: aktiv
---

# OpenClaw

Wird seit 10.09.2026 auf dem Windows-Rechner installiert. Repo: https://github.com/openclaw/openclaw

## Was es ist
Open-Source, lokal laufender KI-Assistent. State, Memory und Credentials bleiben auf der eigenen Maschine. Anbindung an 20+ Messaging-Kanäle (WhatsApp, Telegram, Discord, Slack, Teams, iMessage, u.a.), erweiterbar über Tools/Skills/Plugins, modellagnostisch (Claude, GPT, lokale Modelle über Ollama).

## Setup-Stand (10.09.2026)
- Windows-Installation über `install.ps1`, Node.js automatisch via winget nachinstalliert
- Onboarding-Wizard: Provider **Anthropic**, Auth-Methode **API-Key** (nicht Claude-CLI-Login, damit host-unabhängig)
- Gateway auf Loopback, Shared-Secret-Auth aktiv
- Noch offen: Kanäle, Skills, Daemon-Installation, Health-Check

## Ziel: Verknüpfung mit diesem Vault
Mike möchte OpenClaw an dieses Obsidian-Vault anbinden. Dafür gibt es einen offiziellen **Obsidian-Skill** (https://github.com/openclaw/openclaw/blob/main/skills/obsidian/SKILL.md): liest/sucht/erstellt/bearbeitet Notizen, Tasks, Links, Properties über die Obsidian-CLI, erhält Wikilinks.

Voraussetzungen dafür:
- Obsidian ≥ 1.12.7 installiert
- „Command line interface" in Obsidian-Settings → General aktiviert
- `obsidian` im PATH
- Obsidian-App muss laufen (CLI verbindet sich zur laufenden App)
- Installation über `/dashboard/skills` → „obsidian" suchen → installieren

Noch nicht umgesetzt, nur als Ziel vorgemerkt. Bevor das Skill scharf geschaltet wird: kurz klären, ob Lese-/Schreibzugriff auf sensible Bereiche (00 Kontext/, Finanzen) eingeschränkt werden soll oder ob der Agent das komplette Vault sehen darf.

## Offener Punkt vor jeder Anbindung an echte Kanäle/Accounts
Wie bei [[Hermes Agent (Nous Research) - Evaluation]] vorher prüfen: **gibt es einen Freigabe-Mechanismus für ausgehende Nachrichten**, oder antwortet der Agent eingehenden Chat-Nachrichten automatisch/sofort? Bisher nur gefunden: „Pairing" für neue Absender ist Zugriffskontrolle (wer darf schreiben), keine Inhalts-Freigabe für das, was der Agent selbst rausschickt. Solange das nicht geklärt ist, keine echten Messaging-Kanäle (WhatsApp/Telegram/etc.) mit echten Kontakten verbinden — passend zum Prinzip aus [[Telegram Nachrichten]] / [[Telegram Persönlich]] (Entwurf statt Auto-Antwort).

## Links
- Repo: https://github.com/openclaw/openclaw
- Docs: https://docs.openclaw.ai
- Anthropic-Provider-Setup: https://docs.openclaw.ai/providers/anthropic
- Onboarding-Wizard-Referenz: https://docs.openclaw.ai/reference/wizard
