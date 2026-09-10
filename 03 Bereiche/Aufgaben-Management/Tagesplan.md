---
tags: [bereich, aufgaben, automatisierung]
status: aktiv
date: 2026-09-10
---

# Tagesplan

Gemeinsame Zustandsdatei zwischen dem [[aufgaben-manager]] (plant, kontrolliert) und dem `aufgaben-executor` (arbeitet ab). Wird von den Scheduled Cloud Routines gelesen und beschrieben. Format bewusst simpel, damit beide Agenten zuverlässig damit arbeiten können.

**Status:** Erster Planungslauf am 10.09.2026 (Scheduled Cloud Routine). Noch kein Executor-Zyklus gelaufen, deshalb keine Kontrolle gegen ein vorheriges "Bestätigt"/Log nötig – die Häkchen in [[Aufgaben-Triage (Sofort, Aufwendig, Komplex)]] und im [[2026-09-10]]-Daily-Note stammen aus einer direkten interaktiven Session mit Mike, nicht aus einem Executor-Lauf. Beide Dateien sind bereits aktuell (Zahlen im Kopf der Triage stimmen: 47 offene Punkte, 21/14/12, 14 davon inzwischen erledigt), daher keine Änderung dort nötig in dieser Runde.

## Vorschlag für 2026-09-10
*(Vom aufgaben-manager erzeugt, wartet auf Mikes Bestätigung per Push-Nachricht)*

Aktive Stufe: **Stufe 0, Fundament** (Ziel 0-500 EUR). Weiter-wenn-Bedingung: 10 geworbene Accounts, davon 5 aktiv handelnd, 100-Lot-Schwelle einmal geknackt. Nach der Regel "max. 1-2 aktive Baustellen" bleiben zwei Fronten aktiv: **Kanal/Bot fertigstellen** und **Lot-Tracking aufsetzen** (beides explizit Teil von Stufe 0). Alles andere bleibt bewusst liegen.

### Für Mike selbst (App-/Login-gebundene Aktionen, der Executor kann das nicht übernehmen)
- [ ] Sofort · Stufe 0: Kanalbild in Telegram setzen (Datei liegt fertig unter `Lim/Content/Assets/ic-kanalbild-limitless.png`)
- [ ] Sofort · Stufe 0: Die vier Kanalbilder aus `Lim/Content/Telegram/` gegenchecken und freigeben
- [ ] Sofort · Stufe 0: Make.com-Szenario dauerhaft aktivieren (Scheduling-Schalter auf ON)
- [ ] Sofort · Stufe 0: Google-Drive-Ordner `Rechnungen/Eingang` anlegen, Drive für Desktop prüfen
- [ ] Aufwendig · Stufe 0: WhatsApp end-to-end testen (braucht eine echte Nachricht von jemand anderem)

### Für den Executor vorzubereiten (Recherche/Text/Entwurf/Vault-Pflege, sobald bestätigt)
- [ ] Aufwendig · Stufe 0 (Kernanforderung "Lot-Tracking läuft"): Tracking-Struktur im Vault aufsetzen – Tabelle/Notiz für Gesamt-Lots pro Monat, Lots je Kunde, erreichte Staffelstufe, passend zur Staffel-Logik aus dem MasterPlan (nicht rückwirkend)
- [ ] Aufwendig · Stufe 0: Terminplan-Entwurf für Posts 1-6 (Woche 1) vorbereiten – welcher Post an welchem Tag/zu welcher Zeit laut [[Zwei-Wochen-Takt]], damit Mike es nur noch in Telegram einträgt
- [ ] Aufwendig · Stufe 0: Bot-Willkommensnachricht + die drei Follow-ups (24h/3 Tage/7 Tage) aus [[Inner Circle Kanal-Content]] auf finalen Wortlaut prüfen und einsatzbereit zum Einfügen ins Make.com-Szenario zusammenstellen

### Zurückgestellt, passt aktuell zu keiner aktiven Handlung
- Liste mit 20 Namen + persönliches Anschreiben – reine Mike-Aufgabe (eigenes Netzwerk), nicht planbar für den Executor
- Alle Komplex-Punkte aus der Triage (Website, laufender Content, Zugangs-Gate, Referenzprojekt Pflegedienst, Sprachauswahl Bot) – laut Triage bewusst zurückgestellt, bis Kanal/Bot und Lot-Tracking stehen
- Gmail-OAuth, GMX-IMAP, Dashboard-Auto-Update, Meta Graph API – technische Themen im `jarvis-voice-assistant`-Code, außerhalb dessen was der Executor (Vault-Pflege) leisten kann, brauchen eine interaktive Coding-Session

## Bestätigt für [Datum]
*(Erst befüllt, nachdem Mike den Vorschlag oben bestätigt hat – der Executor darf NUR aus diesem Abschnitt arbeiten)*

## Freigabe-Stau
*(Fertig vorbereitete, aber freigabepflichtige Punkte – Senden, Posten, neue Logins, Käufe, Formulare mit persönlichen Daten, Löschen. Mike gibt hier beim täglichen Check-in gesammelt frei oder ab.)*

Aktuell leer, erster Lauf.

## Log
*(Append-only Protokoll jedes Executor-Laufs, mit Zeitstempel)*

Aktuell leer, erster Lauf.
