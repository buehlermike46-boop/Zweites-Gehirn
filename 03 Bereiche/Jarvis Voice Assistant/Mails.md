---
tags: [mail, cockpit]
---

# Mails

Datenquelle für die Cockpit-Kachel "Mails" im Jarvis-Interface (`/cockpit/status`).
Anders als Telegram/WhatsApp läuft hier (noch) keine automatische 10-Minuten-Bridge —
`task_agent.py` hat keinen Mail-Zugriff (siehe [[Jarvis Hand - Agenten Ausbau]]). Diese
Notiz wird bislang von der großen Claude-Session auf Zuruf aktualisiert (gleiches Prinzip
wie [[Termine]]), zeigt also den Stand vom letzten Abruf, nicht Echtzeit.

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

Für "Mails checken" als echten HAND-Baustein (automatische Entwürfe, wie bei Telegram)
bräuchte `task_agent.py` eine eigene Google-API-Anbindung (eigenes Google-Cloud-Projekt +
OAuth). Bisher ungeklärt, ob/wann das gebaut wird — siehe [[Jarvis Hand - Agenten Ausbau]].
Bis dahin bleibt Mail auf "Wissen"-Ebene: Jarvis kennt den Stand (diese Notiz), beantwortet
aber nichts automatisch.

Verwandt: [[Kunden]], [[Einnahmen]], [[Termine]], [[Jarvis Hand - Agenten Ausbau]]
