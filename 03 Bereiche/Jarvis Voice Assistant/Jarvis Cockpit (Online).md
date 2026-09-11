---
tags: [bereich, jarvis, dashboard, online]
status: aktiv
date: 2026-09-11
---

# Jarvis Cockpit (Online)

Online-Spiegel des lokalen Jarvis-Interface, damit Mike den Business-/Agenten-Stand von überall abrufen kann (Handy, Arbeit), nicht nur am PC.

**URL:** https://claude.ai/code/artifact/23553ef9-283c-42f0-ab0f-51994ce8f574

## Was es ist, was nicht

- Eine separate, statisch veröffentlichte Seite (Claude Artifact), **kein Live-Zugriff auf `localhost:8340`**. Die beiden sind technisch nicht verbunden.
- Liest dieselbe Grundlage wie das lokale Interface: den Vault selbst (hier über GitHub, nicht direkt lokal).
- Zeigt: aktuelle MasterPlan-Stufe (Stufe 0, Fundament) mit den drei "Weiter, wenn"-Bedingungen, Status aller fünf Cloud-Agenten (`aufgaben-manager`/`-executor`, `content-manager`/`-executor`, `professor`), Kennzahlen (Kunden, Verdienste, Instagram), Nachrichten-Kanal-Status, offene Probleme.
- Kein Mikrofon, keine Sprachsteuerung, keine Bridges — reine Anzeige.

## Automatische Aktualisierung

Scheduled Routine **"Jarvis Cockpit Update"** (`trig_01NLyJvgSTBTgz1zt824BUzq`), läuft täglich um 07:00 UTC (ca. 09:00 Uhr Mikes Zeit), startet jedes Mal eine frische Session in diesem Environment. Liest die relevanten Vault-Dateien (Tagesplan, Posting-Warteschlange, Qualitätsbericht, Einnahmen, Kunden, Instagram-Reichweite, Nachrichten-Dashboard, Probleme, MasterPlan), aktualisiert nur die Datenwerte im bestehenden Artifact-HTML (Layout/Design bleibt unverändert) und publiziert unter derselben URL neu. Läuft unbeaufsichtigt, meldet sich bei Mike nur, wenn eine der Quelldateien nicht lesbar ist (dann Eintrag in [[Probleme]]).

**Frequenz ändern oder Routine pausieren:** über `update_trigger`/`delete_trigger` in einer Claude-Code-Session, oder Mike direkt in der claude.ai-Routines-Oberfläche.

## Verwandt

[[Jarvis Voice Assistant]], [[Jarvis Hand - Agenten Ausbau]], [[Nachrichten-Dashboard]]
