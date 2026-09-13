---
tags: [bereich, ib, telegram, automation]
status: aktiv
date: 2026-09-13
---

# Telegram Start-Bot (Cloudflare Worker)

Neubau des bestehenden `@LimitlessPuBot` auf Cloudflare Workers, nach einer fertigen Anleitung von Mikes Geschäftspartner Rob (@robdefi), der dasselbe Setup für sein eigenes Limitless/PU-Prime-Business bereits produktiv nutzt. Löst den bisherigen Make.com-Aufbau aus [[KI-Automatisierung IB-Business]] ab (Entscheidung von Mike, 13.09.2026: bestehenden Bot umstellen statt neuen Bot parallel zu bauen).

**Warum Cloudflare statt Make.com:** Kostenlos, läuft rund um die Uhr ohne eigenen Server, und die Anleitung bringt gegenüber dem bisherigen Make.com-Aufbau deutlich mehr mit: Sprachwahl DE/EN, sauberer Zweig für US/AU-Interessenten, eigener Zweig für Bestandskunden mit UID-Abfrage und fertiger Switch-Mail, dazu eine echte Lead-Datenbank (D1) mit Funnel-Stufe pro Kontakt statt nur Nachrichtenversand.

## Konfiguration (die sechs Angaben aus Robs Anleitung)

| Angabe | Wert | Quelle |
|---|---|---|
| Vorname | `Mike` | bestätigt 13.09.2026 |
| Telegram-Username | `mikebueh` | von Mike, 13.09.2026 |
| Bot-Username | `LimitlessPuBot` | bestehender Bot, bestätigt 13.09.2026 |
| Broker-Link | `https://puvip.co/la-partners/de/Y4GY2sPn` | von Mike, 13.09.2026 |
| Referral-Code | `2A5CC2B8` | aus [[KI-Automatisierung IB-Business]], bestätigt 13.09.2026 |
| IB-Nummer | `33772237` | aus dem Broker-Link herausgerechnet (Base64 in `affid`, löst auf zu `https://de.puprime.com/forex-trading-account/?affid=MzM3NzIyMzc=`), bestätigt 13.09.2026 |

Zusätzlich für Schritt 2 der Anleitung gebraucht, nicht Teil der sechs Angaben:
- **Numerische Telegram-ID (für `ROB_CHAT_ID`):** `6233075726` (für `mikebueh`, gefunden in [[Telegram Nachrichten]] aus einem früheren Test mit dem Jarvis-Bot, am 13.09.2026 von Mike bestätigt)

**Nicht im Vault gespeichert, gehören nur in den Passwortmanager:**
- `BOT_TOKEN` (von BotFather, wird nie in den Chat geholt, direkt in Cloudflare eingetragen)
- `HOOK_SECRET` und `ADMIN_TOKEN` (von Mike selbst frei erfunden, siehe Schritt 5 unten)

## Quelle

Vollständige Original-Anleitung von Rob, hochgeladen von Mike am 13.09.2026: "Limitless Start Bot — Anleitung zum Nachbauen". Fertiger Code mit allen sechs Werten bereits eingesetzt: [[limitless-start-bot-worker.js]] (im selben Ordner, direkt zum Einfügen in Cloudflare unter "Edit code").

## Setup-Fortschritt

- [x] Sechs Konfigurationswerte + Telegram-ID geklärt und bestätigt (13.09.2026)
- [x] Fertiger Code mit eingesetzten Werten erstellt: `limitless-start-bot-worker.js`
- [ ] Schritt 3: Cloudflare-Konto, D1-Datenbank `limitless-leads`, Worker `limitless-start-bot` anlegen — **Mikes Aufgabe**, braucht Cloudflare-Login
- [ ] Schritt 4: Code aus `limitless-start-bot-worker.js` einfügen und deployen — **Mikes Aufgabe**
- [ ] Schritt 5: D1-Binding `DB`, plus vier Variablen setzen (`BOT_TOKEN` = Token vom bestehenden `@LimitlessPuBot`, `ROB_CHAT_ID` = `6233075726`, `HOOK_SECRET` und `ADMIN_TOKEN` selbst frei erfinden, Muster Wort-Wort-Jahr-Wort, min. 20 Zeichen) — **Mikes Aufgabe**, Bot-Token verlässt Telegram/Cloudflare nie in Richtung Chat
- [ ] Schritt 6: `/setup?token=...` und `/sethook?token=...` einmal im Browser aufrufen — **Mikes Aufgabe**. Ab hier übernimmt der neue Worker den Webhook, das alte Make.com-Szenario bekommt keine Updates mehr (bewusste Ablösung, siehe oben)
- [ ] Schritt 7: Alle Zweige einmal durchklicken (Hauptstrecke, US/AU, Bestandskunde+UID, Freitext, Mail-Seite)
- [ ] Schritt 8: Neuen Kanal-Post mit Start-Button im Kanal "Inner Circle - Mike Bühler" absetzen und anpinnen, alten Post lösen

**Nächster Schritt sobald Mike in Cloudflare eingeloggt ist:** Schritt 3 bis 6 zusammen durchgehen.

## Stolperfallen (aus Robs Anleitung, gilt unverändert)

- Deploy nicht vergessen: Code einfügen allein ändert nichts, der Deploy-Button muss geklickt werden
- "Protect with Cloudflare Access" beim Worker ausgeschaltet lassen, sonst kommt Telegram nicht durch
- Absenderadresse bei der Bestandskunden-Switch-Mail muss exakt die beim Broker hinterlegte sein
- Kontoeröffnung außerhalb des eigenen Broker-Links lässt sich nicht nachträglich reparieren

## Was danach ohne neuen Deploy geht

- Kanal-Post ändern: `/post?token=...&chat=...&text=...&btn=...`
- Leads abrufen: `/export?token=...`
