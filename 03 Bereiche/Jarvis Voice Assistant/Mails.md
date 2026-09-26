---
tags: [mail, cockpit]
---

# Mails

Datenquelle für die Cockpit-Kachel "Mails" im Jarvis-Interface (`/cockpit/status`).

**Update 26.09.2026:** Läuft jetzt genau wie Telegram/WhatsApp automatisch alle 10 Minuten
über `task_agent.py` — neu `scripts/mail_bridge.py`, per IMAP mit App-Passwort (kein
Browser, kein OAuth), siehe [[Jarvis Hand - Agenten Ausbau]] und
`jarvis-voice-assistant/CLAUDE.md`. Werbung wird automatisch in den Papierkorb verschoben
(Protokoll in [[Mail-Löschungen]]), bei Wichtigem schickt Jarvis zusätzlich eine
Telegram-Nachricht. **Setup durch Mike noch nicht erledigt** (Google-App-Passwort +
`gmail_address`/`gmail_app_password` in `config.json`) — bis dahin zeigt diese Notiz noch
den letzten manuellen Stand von unten, keine Echtzeit-Daten.

**Kopfwert:**

ungelesen: 201

**Format:** eine Zeile pro Mail, neueste zuerst. `Status` aktuell immer `ungelesen`
(Filterung nach Wichtigkeit kommt später, sobald klar ist wonach Mike sortieren will).

| Datum | Von | Betreff | Status |
|---|---|---|---|
| 2026-09-08 11:31 | Stepstone Jobagent | You have a great chance for an interview for this job | ungelesen |
| 2026-09-08 09:13 | Google | Google-Kontodaten mit windsorai geteilt | ungelesen |
| 2026-09-08 09:09 | Google | Google-Kontodaten mit Claude for Google Drive geteilt | ungelesen |
| 2026-09-08 07:58 | Outletcity Metzingen | ❗19V69-ltalia SALE | ungelesen |
| 2026-09-08 05:49 | Stepstone Jobagent | Enrichment Technology Company Ltd. und 11 weitere Firmen suchen | ungelesen |
| 2026-09-08 05:30 | Stepstone Jobagent | Systeex Brandschutzsysteme GmbH und 8 weitere Firmen suchen | ungelesen |
| 2026-09-07 21:00 | Google | Google-Kontodaten mit Claude geteilt | ungelesen |
| 2026-09-07 19:02 | Make.com | Your automation might just need one click | ungelesen |

## Auffällig beim ersten Abruf (08.09.2026)

201 ungelesene Mails im Posteingang laut Gmail (`is:unread in:inbox`) — größtenteils
Stepstone-Jobagent-Digests (automatische Jobvorschläge), Promo-Newsletter (Temu,
Outletcity, Lieferando, IQ Capital) und Google-Login-Benachrichtigungen (u.a. von den
heute neu verbundenen Connectoren: windsorai, Claude for Google Drive, Claude). Unter
den 15 neuesten war nichts erkennbar Dringendes von Kunden/Business dabei. Lohnt sich,
den Posteingang mal aufzuräumen bzw. Filter/Labels zu setzen, wenn Zeit ist — sag
Bescheid, dann übernehme ich das.

## Wie es weitergeht

Erledigt (26.09.2026, siehe Update oben) — die frühere Annahme, dass es ein eigenes
Google-Cloud-Projekt + OAuth bräuchte, war zu pessimistisch, ein IMAP-App-Passwort reicht.
Offen ist nur noch das einmalige Setup durch Mike selbst (siehe [[Jarvis Hand - Agenten Ausbau]],
Baustein 1). Mail bleibt bewusst bei "lesen + einordnen", kein automatisches Antworten wie
bei Telegram — dafür gibt es keinen Anwendungsfall (Kunden/Leads laufen über Telegram, nicht
Mail).

Verwandt: [[Kunden]], [[Einnahmen]], [[Termine]], [[Mail-Löschungen]], [[Jarvis Hand - Agenten Ausbau]]
