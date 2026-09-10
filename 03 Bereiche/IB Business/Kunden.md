---
tags: [ib, kunden, cockpit]
---

# Kundenstamm

Datenquelle für die Cockpit-Kachel "Kunden" im Jarvis-Interface (`/cockpit/status`).
Jarvis liest diese Tabelle nur — geändert wird sie hier in Obsidian (oder über die Bridge).

**Format:** eine Zeile pro Person. `Status` ist eines von `lead`, `aktiv`, `inaktiv`.
`Seit` im Format JJJJ-MM-TT (danach wird sortiert, neueste zuerst).

| Name | Status | Seit | Broker | Notiz |
|---|---|---|---|---|
| <Beispiel Max Mustermann> | lead | 2026-09-08 | PU Prime | Zeile löschen, sobald echte Kunden drinstehen |

## Legende

- **lead** — hat Interesse gezeigt, noch kein Konto über deinen Link
- **aktiv** — Konto läuft über deinen Link, handelt
- **inaktiv** — Konto vorhanden, aber kein Volumen mehr

## Live-Check 08.09.2026 (Nachmittag)

Auf Wunsch direkt bei PU Prime (IB-Dashboard, `hub.primeverse.ca`) und Limitless
(`worldoflimitless.com/affiliate`) nachgesehen, per Claude in Chrome über Mikes
eingeloggte Sessions, kein Passwort eingegeben. Ergebnis: **0 echte externe Leads/Kunden**
in beiden Systemen (PU Prime: 1 gelisteter "Kunde" ist Mikes eigener Test-Account, nicht
extern; Limitless-Prospect-Tracker und My-Referrals: beide leer). Die 0 oben ist also der
tatsächliche aktuelle Stand, keine unausgefüllte Vorlage mehr. Details:
[[PU Prime]], [[Limitless]] (`04 Ressourcen/Persönliches Datenarchiv/Trading-Konten/`).

## Live-Check 09.09.2026 (Abend)

Erneut direkt nachgesehen, auf Mikes Wunsch ("Kunden bei Limitless und/oder PU Prime pruefen"),
per Claude in Chrome, Mikes eingeloggte Sessions, kein Passwort eingegeben.

- **PU Prime** (`hub.primeverse.ca` → "Meine Kunden"): 1 Kunde total, 0 aktive Haendler,
  0,01 Lose gehandelt — der eine Eintrag ist weiterhin Mikes eigener Test-Account
  (Konto 26873235, Status "ruhend", 1 USD Einlage). **0 echte externe Kunden.**
- **Limitless** (`worldoflimitless.com/affiliate` → "My Referrals" + "Prospect Tracker"):
  Total Referred 0, Approved 0, Pending 0, This Month 0, Prospect Tracker ebenfalls
  ueberall 0. **0 echte Leads/Kunden.**

Damit unveraendert zum Stand 08.09.2026 — die 0 oben ist weiterhin der tatsaechliche Stand,
keine veraltete Zahl. Achtung: die "Command Center"-Startseite bei PU Prime zeigt einen
"Member Growth"-Chart mit grossen Zahlen (z.B. 2.840) — der ist explizit mit "Demo" markiert
und NICHT real, bewusst nicht hier eingetragen.

Verwandt: [[IB-Projekt (Limitless & PU Prime)]], [[Einnahmen]], [[ICP]]
