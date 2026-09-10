---
tags: [finanzen, tracking, system]
status: aktiv
date: 2026-09-08
---

# Ausgaben und Rechnungen Tracking

Zielbild: Rechnung fotografieren, sie landet automatisch im Vault, Agenten lesen sie aus und verteilen die Daten dorthin, wo sie gebraucht werden. Damit gibt es jederzeit eine Antwort auf: Ist alles bezahlt? Was ist offen? Welche Frist läuft?

Verwandt: [[IB-Projekt (Limitless & PU Prime)]] · [[Vision - Vault-Wachstum, Jarvis-Assistent & Monitoring]]

## Stufe 1, manuell aber vollständig (jetzt)

Ohne saubere manuelle Erfassung kann keine Automatisierung entstehen. Ein Agent kann nur strukturieren, was strukturiert erfasst wurde.

### Datenstruktur pro Rechnung

Eine Notiz pro Rechnung, Dateiname `JJJJ-MM-TT Empfänger Betrag.md`:

```yaml
---
typ: rechnung
richtung: ausgabe        # ausgabe oder einnahme
empfaenger:
betrag:
waehrung: EUR
datum:
faellig_am:
zahlungsziel_tage:
status: offen            # offen, bezahlt, überfällig, strittig
kategorie:
wiederkehrend: false     # false, monatlich, quartal, jährlich
beleg: ![[scan.jpg]]
---
```

### Kategorien, fest, nicht ohne Grund erweitern

| Kategorie | Beispiele |
|---|---|
| `fix-privat` | Miete, Strom, Versicherungen, Handy |
| `fix-business` | Broker-Gebühren, ATAS, Hosting, KI-Tools, Telegram-Bot |
| `variabel-privat` | Einkauf, Kinder, Sprit |
| `weiterbildung` | Kurse für dich selbst |
| `invest-business` | Werbung, Software, Ausrüstung |
| `einnahme-job` | Gehalt |
| `einnahme-ib` | Provision Broker |
| `einnahme-dienstleistung` | Webseiten, Chatbots |

### Monatsroutine, 15 Minuten, immer am 1.

1. Alle Rechnungen des Vormonats erfasst? Belege fotografiert?
2. Alle wiederkehrenden Posten tatsächlich abgebucht, und in richtiger Höhe?
3. Offene Posten prüfen. Frist in weniger als 7 Tagen bedeutet sofort bezahlen.
4. Zusammenfassung schreiben: Summe Einnahmen, Summe Ausgaben je Kategorie, Differenz.
5. Business-Zahlen in die Einnahmen-Übersicht des IB-Bereichs übertragen.

## Stufe 2, halbautomatisch, ab ca. Monat 4

- **Foto in den Vault:** über Google Drive (`Rechnungen/Eingang`, Scan-Funktion der Drive-App), auf dem Laptop per Google Drive für Desktop gespiegelt
- **Auslese-Agent:** liest Betrag, Empfänger, Datum und Fälligkeit aus dem Bild und legt die Notiz nach obigem Schema an
- **Prüf-Agent:** wöchentlicher Lauf. Welche wiederkehrenden Posten fehlen diesen Monat, welche Frist läuft in weniger als 7 Tagen, welcher Betrag weicht mehr als 10 % vom Vormonat ab.
- **Meldung** kommt in denselben Kanal wie das Morgenbriefing

## Stufe 3, Dashboard

Teil des geplanten Monitoring-Systems: Einnahmen je Standbein, Fixkostenquote, offene Posten, Fortschritt Richtung Ziel, in einer Ansicht, automatisch aktualisiert.

## Was noch fehlt

- [ ] Liste der wiederkehrenden Fixkosten (Bezeichnung, Betrag, Abbuchungstag, monatlich oder jährlich)
- [ ] Liste der Business-Kosten (Broker, ATAS, Tools, Abos)
- [x] Entscheidung getroffen (10.09.2026): Rechnungsfotos laufen über **Google Drive**. Ordner `Rechnungen/Eingang`, befüllt per Scan-Funktion der Drive-App am Handy. Damit der spätere Auslese-Agent drankommt, muss der Ordner über Google Drive für Desktop auf dem Laptop gespiegelt sein
- [ ] Klären, womit die Buchhaltung läuft, falls schon etwas existiert
