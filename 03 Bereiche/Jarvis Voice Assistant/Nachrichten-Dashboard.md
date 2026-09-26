---
tags: [bereich, jarvis, dashboard, monitoring]
status: aktiv
date: 2026-09-09
---

# Nachrichten-Dashboard

Zentrale Übersicht über alle Nachrichtenkanäle, die Jarvis kennt. Fasst zusammen, was in den einzelnen Kanal-Notizen steht: [[Telegram Nachrichten]] (Business-Bot), [[Telegram Persönlich]], WhatsApp Nachrichten (noch keine Datei, siehe unten), [[Mails]], [[Termine]].

**Wichtig zur Ehrlichkeit dieser Notiz:** Ich (die Bridge-Instanz, die diese Notiz schreibt) habe nur Lese-/Schreibzugriff auf den Vault und lesenden Web-Zugriff — **keinen** direkten Zugriff auf Gmail, GMX, WhatsApp oder Telegram-APIs selbst. Diese Übersicht ist ein manueller Snapshot aus dem, was die jeweiligen Kanal-Notizen aktuell zeigen, kein Live-Datenabruf. Details zur technischen Grenze unten unter "Was noch fehlt".

## Übersicht (Snapshot, Stand siehe "Letzter Abruf" pro Kanal)

| Kanal | Automatisierung | Neue/offene Nachrichten | Letzter Abruf laut Quelle |
|---|---|---|---|
| Telegram Business-Bot (@Mikebubot) | ✅ läuft alle 10 Min ([[Jarvis Voice Assistant]] „Die Bridge") | 0 offen (2 Einträge total, alle beantwortet/ignoriert) | 07.09.2026, siehe [[Telegram Nachrichten]] |
| Telegram Persönlich (Userbot) | ✅ läuft alle 10 Min | 0 offen (4 Einträge total, alle beantwortet/ignoriert) | 08.09.2026, siehe [[Telegram Persönlich]] |
| WhatsApp (eigene Bridge) | 🔵 gebaut + eingeloggt (`whatsapp_bridge.py`, eigenes Profil, laeuft alle 10 Min mit), wartet auf den ersten echten Entwurf zur Bestaetigung | 0 (noch kein Entwurf durchgekommen) | läuft, aber noch ohne Treffer |
| WhatsApp (via Claude in Chrome) | 🔵 erreichbar, solange eine interaktive Session offen ist — geprüft 09.09.2026, eingeloggt, Chats laden | nicht ausgezählt | 09.09.2026 |
| Gmail (buehlermike46@gmail.com) | 🟡 seit 26.09.2026 gebaut (`mail_bridge.py`, IMAP, alle 10 Min), wartet auf App-Passwort von Mike in `config.json` — siehe [[Jarvis Hand - Agenten Ausbau]] | 201 ungelesen (Stand 09.09.2026, vor dem Umbau) | 09.09.2026, wird nach dem Setup wieder live |
| GMX E-Mail | 🟡 seit 26.09.2026 gebaut (`mail_bridge.py`, IMAP statt Browser-Login — der alte SSO-Block betraf nur den Browser-Weg), wartet auf App-Passwort von Mike in `config.json` | unbekannt | nie |
| ChatGPT | 🔵 erreichbar über Claude in Chrome, eingeloggt als Mike Buehler — geprüft 09.09.2026 | n/a | 09.09.2026 |
| Instagram | 🔵 erreichbar über Claude in Chrome, eingeloggt — noch kein automatisierter Check der Nachrichten | unbekannt | nicht geprüft |
| Facebook | 🔵 erreichbar über Claude in Chrome, eingeloggt — noch kein automatisierter Check der Nachrichten | unbekannt | nicht geprüft |
| PU Prime — Kunden (IB) | 🔵 erreichbar über Claude in Chrome — geprüft 09.09.2026 | 0 echte Kunden (1 Eintrag = Mikes Test-Account) | 09.09.2026, siehe [[Kunden]] |
| PU Prime — persönliches Handelskonto (Kontostand) | ❌ Session abgelaufen (`myaccount.puprime.com` leitet auf Login um, zusätzlich Cloudflare-Sicherheitscheck) | unbekannt | zuletzt 08.09.2026 (~1,48 €) |
| Limitless — Kunden/Referrals | 🔵 erreichbar über Claude in Chrome — geprüft 09.09.2026 | 0 echte Leads/Kunden | 09.09.2026, siehe [[Kunden]] |

🔵 = erreichbar über eine interaktive Session (Claude in Chrome / Connector), aber nicht Teil
der automatischen 10-Min-Bridge (`task_agent.py`) — läuft nur, wenn jemand wie diese Session
offen ist, nicht rund um die Uhr.

## Was noch fehlt, um das wirklich alle 10 Minuten automatisch zu machen

Ein echtes 10-Minuten-Monitoring über **alle** genannten Kanäle bräuchte für jeden Kanal, der noch nicht angebunden ist, eine eigene technische Anbindung in `task_agent.py` (dem Bridge-Agenten, der alle 10 Minuten läuft):

1. **Gmail — gelöst 26.09.2026:** Die Annahme "braucht eigenes Google-Cloud-Projekt + OAuth" war zu pessimistisch. `scripts/mail_bridge.py` nutzt IMAP mit einem App-Passwort (2FA im Google-Konto vorausgesetzt) und läuft damit alle 10 Min mit `task_agent.py` mit, ganz ohne OAuth. Fehlt nur noch: Mike trägt `gmail_address`/`gmail_app_password` in `config.json` ein.
2. **GMX — gelöst 26.09.2026:** Gleicher IMAP-Weg wie Gmail, umgeht den früheren SSO-Redirect-Block komplett (der betraf nur die Browser-Variante in `broker_bridge.py`, die deshalb entfernt wurde). Fehlt nur noch: Mike aktiviert POP3/IMAP in den GMX-Einstellungen, erzeugt ein App-Passwort, trägt `gmx_address`/`gmx_app_password` in `config.json` ein. Details: `jarvis-voice-assistant/CLAUDE.md`, Abschnitt "Mail-Bruecke: Gmail + GMX per IMAP".
3. **WhatsApp:** Login ist bereits erledigt, die eigene Bridge (`whatsapp_bridge.py`) läuft seit 08.09.2026 alle 10 Min mit, wartet aber weiterhin auf ihren ersten echten Entwurf zur Bestätigung. Zusätzlich seit 09.09.2026 bekannt: auch über Claude in Chrome erreichbar (separater Pfad, nicht automatisiert).
4. **Instagram/Facebook:** seit 09.09.2026 ueber Claude in Chrome erreichbar (Mike ist eingeloggt), aber noch keine automatisierte Pruefung der Nachrichten gebaut, plus weiterhin offene ToS-Risiko-Abwägung fuer eine echte Bridge (Browser-Automatisierung wie bei WhatsApp vs. offizielle Meta-API).
5. **PU Prime (Kunden-Dashboard) / Limitless (Referrals):** seit 09.09.2026 ueber Claude in Chrome erreichbar und geprueft (siehe [[Kunden]]), aber ebenfalls keine automatisierte 10-Min-Bridge — die Dashboards sind moderne React-Seiten ohne stabile, einfach zu scrapende Struktur, eine eigene Bridge (eigenes Profil + einmaliger Login durch Mike, aehnlich wie bei WhatsApp) waere noetig und noch nicht gebaut.
6. **PU Prime perssönliches Handelskonto (Kontostand):** Login-Session ist abgelaufen, zusaetzlich schuetzt die Seite sich mit einem Cloudflare-Sicherheitscheck — Mike muesste sich selbst neu einloggen, bevor der Kontostand wieder gecheckt werden kann.

Das ist alles **Code-Arbeit** (neue Python-Module, Zugangsdaten in `config.json`, ggf. neuer Windows Scheduled Task, jeweils ein einmaliger Login durch Mike selbst) — das kann nicht über Vault-Bearbeitung allein entstehen, sondern nur in einer interaktiven Session mit Zugriff auf den `jarvis-voice-assistant`-Code. Ich kann diese Dashboard-Notiz gerne bei jedem Bridge-Lauf oder auf Zuruf mit dem aktuellen Stand aus den Kanal-Notizen aktualisieren, aber das ersetzt keinen echten Live-Abruf.

## Verwandt

[[Jarvis Voice Assistant]], [[Jarvis Hand - Agenten Ausbau]], [[Telegram Nachrichten]], [[Telegram Persönlich]], [[Mails]], [[Mail-Löschungen]], [[Termine]]
