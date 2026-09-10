---
tags: [projekt, vision]
status: aktiv
erstellt: 2026-09-06
---

# Vision: Vault-Wachstum → Jarvis-Assistent → Monitoring

Von Mike am 06.09.2026 als nächste große Ziele genannt (per WhatsApp-Video gezeigt: eine Obsidian Graph-Ansicht mit hunderten/tausenden vernetzten Notizen als Vorbild für die Vault-Größe).

## Phase 1: Vault wächst wie im Referenzvideo
Ziel: "Zweites Gehirn" wird so groß und dicht vernetzt wie die gezeigte Graph-Ansicht — also nicht nur viele Notizen, sondern viele **Verknüpfungen** zwischen ihnen.

Ideen zur Umsetzung:
- Regelmäßig weiter Inhalte einpflegen: ChatGPT-Verlauf (wie am 06.09. begonnen), Trading-Learnings, Business-Entscheidungen, Daily Notes.
- Konsequent [[Wikilinks]] zwischen verwandten Notizen setzen, nicht nur neue Notizen anlegen — das ist es, was die Graph-Ansicht dicht macht, nicht die reine Anzahl.
- Bestehende "leere" Übersichtsdateien (z.B. in 03 Bereiche/04 Ressourcen) nach und nach mit echten Inhalten und Verlinkungen füllen.
- Ggf. eine feste Routine etablieren (z.B. wöchentlicher Vault-Review: neue Notizen verlinken, Inbox leeren).

## Phase 2: Claude als "Jarvis"-Setup
Ziel: Dieser Assistent soll sich stärker wie ein persönlicher, proaktiver Assistent á la "Jarvis" anfühlen.

Realistische Bausteine (kein leeres Versprechen, sondern was tatsächlich umsetzbar ist):
- Fester, konsistenter Charakter/Ansprache (Name, Ton) — als eigene Notiz/Vorgabe hier im Vault oder als Schreibstil-Regel festlegen.
- Proaktive Briefings: Kalender-Zusammenfassung ist schon eingerichtet (06:30 täglich) — könnte erweitert werden um Vault-/Business-Kontext (z.B. offene Punkte aus der Inbox, Trading-Ziele).
- Tiefere Integration mit dem Vault: bei Session-Start automatisch Inbox + aktive Projekte checken (steht schon so in CLAUDE.md).
- Ggf. Sprachsteuerung/Sprachausgabe, falls über die genutzte Claude-App verfügbar.
- Ein Dashboard (z.B. als Artifact) mit den wichtigsten Kennzahlen (Trading-Status, IB-Business-Funnel, Ziele) als "Jarvis-Oberfläche".

## Phase 3: Autonomer Business-Agent (Kundenakquise, Betreuung, Analyse) — konkretisiert 08.09.2026

Von Mike ausführlich erklärt am 08.09.2026, beantwortet die bisher offene Frage oben
("was genau ist mit Monitoring gemeint"): **Business-Dashboards, kein Kamera-/Smart-Home-Monitoring.**

**Hauptziel, das nie aus den Augen verloren werden darf:** 50.000 €/Monat aus dem IB-Business
(Limitless & PU Prime) — das entspricht bei aktueller Lot-Provision (15 €/Lot) grob Mikes eigener
Faustregel nach **~100 aktiven, handelnden Kunden**. Jede Baustein-Entscheidung sollte sich daran
messen lassen, ob sie diesem Ziel dient — Details/Ziel-Ladder in
[[IB-Projekt (Limitless & PU Prime)]].

**Das Gesamtsystem, das gebaut wird — vier Säulen:**

1. **Kundenakquise (Werbung):** Ein Agent erstellt Content für Limitless/PU Prime und postet ihn
   automatisch nach einem festgelegten Plan. Konkretes Abnahmekriterium (Mikes eigenes Beispiel):
   sagt er "erstelle neuen Content für Limitless und plane die Woche", muss am Ende eine Woche
   Content wirklich in der Meta Business Suite hochgeladen/geplant sein — nicht nur eine
   Text-Idee im Vault.
2. **Kundenbetreuung:** Ein Agent beantwortet Kundenfragen (Telegram/WhatsApp, später Mail,
   Instagram, Facebook) — aktuell Entwurf-Freigabe-Prinzip, siehe [[Jarvis Hand - Agenten Ausbau]].
3. **Live-Kunden-Analyse:** Nicht nur eine Liste, sondern pro Kunde: in welchem Prozess-Schritt
   er steht (Funnel-Stufe), was er bringt (Umsatz/Provision), ob es Warnsignale/Probleme gibt
   (Risiko/Abwanderungsgefahr o.ä.). Die [[Kunden]]-Kachel im Cockpit ist erst das Grundgerüst
   (Name/Status/Seit), noch keine Analyse-Tiefe.
4. **Content-Performance-Feedback:** Messen, welcher Content wirklich Kunden bringt und welcher
   nicht, damit sich das System iterativ verbessert statt nur stur zu produzieren.

Dazu weiterhin: Termine im Blick behalten (siehe [[Termine]], schon umgesetzt).

**Endstufe (bewusst spätere Ausbaustufe, nicht jetzt):** Ein übergeordneter Agent bekommt direkt
das Ziel "50k/Monat erreichen" und verteilt selbstständig Aufgaben an Sub-Agenten (Content,
Kundenservice, Analyse) — ohne dass Mike einzelne Befehle geben muss. Bis dahin bleibt das
aktuelle Entwurf-Freigabe-Prinzip bestehen (siehe Sicherheits-Grundsatzentscheidung in
[[Jarvis Hand - Agenten Ausbau]]) — volle Autonomie ist bewusst ein späterer Schritt, keine
sofortige Anforderung.

**Ehrlicher Stand gegen die vier Säulen (Stand 08.09.2026):**
- Kundenakquise/Content-Posting: **noch nicht gebaut**, keine Meta-Business-Suite-Anbindung
- Kundenbetreuung: **teilweise** (Telegram/WhatsApp Entwurf-Prinzip live, Mail/Instagram/Facebook offen)
- Live-Kunden-Analyse: **Grundgerüst da** (Cockpit-Kachel), Tiefe (Funnel-Stufe/Wert/Risiko) fehlt
- Termine: **umgesetzt**
- Content-Performance-Analyse: **noch nicht gebaut**
- Volle Multi-Agent-Autonomie: **noch nicht begonnen**, bewusst spätere Stufe

Technischer Ausbau weiterhin in [[Jarvis Hand - Agenten Ausbau]] getrackt.

## Status
Phase 1 läuft bereits (Vault-Ausbau seit 06.09.2026). Phase 3 ist konkretisiert (siehe oben), Umsetzung läuft schrittweise über [[Jarvis Hand - Agenten Ausbau]].

**Phase 2 — Update 06.09.2026:** Statt (nur) Claude selbst in diesem Vault "Jarvis-artiger" zu machen, wurde direkt ein eigenständiger Sprach-Assistent namens **Jarvis** aufgesetzt (separates Repo, lokal auf diesem Rechner, per Klatschen startbar) — siehe [[Jarvis Voice Assistant]]. Deckt einiges aus der ursprünglichen Idee ab: fester Charakter/Ansprache, Sprachein-/ausgabe, Wetter- und Aufgaben-Briefing beim Start, Browser-Steuerung, Bildschirm sehen. Die vault-interne Variante (Claude selbst proaktiver/Jarvis-artiger im Ton) bleibt trotzdem eine mögliche Ergänzung, ist aber durch den eigenständigen Assistenten weniger dringend geworden.

**Phase 2 — Update 07.09.2026:** Jarvis kann jetzt Aufgaben, die er selbst nicht kann, automatisch an eine größere Claude-Instanz weiterreichen und das Ergebnis kommt von selbst zurück in den Vault, ganz ohne dass du manuell eine Session öffnen musst (Details in [[Jarvis Voice Assistant]] unter "Die Bridge"). Damit ist Jarvis nicht mehr nur Sprachein-/ausgabe plus Browser, sondern kann echte mehrschrittige Arbeit für dich erledigen. Phase 2 ist damit im Kern fertig.
