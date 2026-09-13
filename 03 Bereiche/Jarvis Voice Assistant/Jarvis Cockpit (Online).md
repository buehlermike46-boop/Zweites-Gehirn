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

Scheduled Routine **"Jarvis Cockpit Update"** (`trig_01H9n2t5bVW7oBoggdQBmUEt`), läuft **stündlich** (zur :20-Minute). Liest die relevanten Vault-Dateien (Tagesplan, Posting-Warteschlange, Qualitätsbericht, Einnahmen, Kunden, Instagram-Reichweite, Nachrichten-Dashboard, Probleme, MasterPlan), aktualisiert nur die Datenwerte im bestehenden Artifact-HTML (Layout/Design bleibt unverändert) und publiziert unter derselben URL neu. Läuft unbeaufsichtigt, meldet sich bei Mike nur, wenn ein echter, neuer Fehler auftritt (dann Eintrag in [[Probleme]]). Push- und E-Mail-Benachrichtigungen für diese Routine sind bewusst aus.

**Architektur-Fix vom 13.09.2026:** Die ursprüngliche Version dieser Routine (`trig_01NLyJvgSTBTgz1zt824BUzq`) startete bei jedem Lauf eine komplett frische, sessionlose Session ohne fest hinterlegten Repo-Checkout — dadurch schlug sie unregelmäßig fehl ("kein Repo-Checkout vorhanden, `/home/user` leer"), weil das Anlege-Werkzeug für Routinen keinen Git-Quellpfad mitgeben kann. Fix: eigene dauerhafte Session `session_01L1ALSAq1Hyatcu4envD6bU` mit fest zugewiesenem Repo-Checkout angelegt (analog zum Muster von `content-manager`/`content-executor`/`professor`, aber bewusst eine eigene Session statt deren gemeinsamer, um die stündliche Kontext-Last nicht auf eine ohnehin schon fast volle Session zu packen), alte Trigger-Konfiguration gelöscht, neue mit identischem Namen/Rhythmus dagegen angelegt. Der Prompt holt sich vor jedem Lesen erst `git fetch origin master && git merge origin/master` (die Session bleibt bestehen, der Checkout kann sonst veralten), und pusht bei einem Fehlereintrag in [[Probleme]] direkt nach master.

**Bekannter Nachteil, im Blick behalten:** Diese Session läuft stündlich für immer weiter und sammelt Kontext an (deutlich schneller als die selteneren Content-/Aufgaben-Routinen). Muss vermutlich irgendwann zurückgesetzt werden (neue Session anlegen, Trigger per `update_trigger` nicht möglich, da `persistent_session_id` sich nicht nachträglich ändern lässt — wieder löschen + neu anlegen wie hier).

**Warum nicht alle 10 Minuten, wie die lokale Bridge:** von der Plattform technisch nicht erlaubt (Minimum für Scheduled Routines ist 1 Stunde, direkt als Fehlermeldung zurückbekommen, kein Ermessensspielraum). Stündlich ist damit das Maximum. Inhaltlich ohnehin ausreichend: anders als die lokale 10-Minuten-Bridge (die echte externe Kanäle wie Telegram/WhatsApp abfragt, die jederzeit neue Nachrichten haben können) liest diese Routine nur den Vault, und der ändert sich nur zu den festen Agenten-Laufzeiten (06:00/06:30 UTC, sonntags 17:00 UTC, täglich ~16:35 UTC) oder wenn Mike/Claude von Hand was ändern — die meisten stündlichen Läufe werden also ohnehin keine neuen Werte finden.

**Frequenz ändern oder Routine pausieren:** über `update_trigger`/`delete_trigger` in einer Claude-Code-Session, oder Mike direkt in der claude.ai-Routines-Oberfläche.

## Verwandt

[[Jarvis Voice Assistant]], [[Jarvis Hand - Agenten Ausbau]], [[Nachrichten-Dashboard]]
