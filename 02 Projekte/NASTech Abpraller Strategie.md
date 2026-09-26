---
tags: [projekt, trading, nq, abpraller, heikin-ashi]
status: aktiv
date: 2026-09-26
---

# NASTech Abpraller Strategie

## Ziel
Eigenständige, bewusst einfach gehaltene Rücksetzer-Strategie auf dem Nasdaq-Tech-Index (NQ/NAS100, Mikes Begriff "NASTech"), aufgebaut auf normalen Heikin-Ashi-Kerzen + Heikin Ashi Smoothed als Trendfilter. Schritt für Schritt bauen und an echten Marktbedingungen testen — erst wenn ein Baustein nachweislich funktioniert, kommt der nächste dazu. Ausdrücklicher Grund (Mike, 26.09.2026): genau das lange Stecken-in-einem-Baustein hat das [[ATAS Trading Bot (NQ-Abpraller-Setup)|ATAS-Bot-Projekt]] immer wieder ausgebremst, das soll hier von Anfang an vermieden werden.

## Abgrenzung zum ATAS-Bot-Projekt
- [[ATAS Trading Bot (NQ-Abpraller-Setup)]] bleibt exakt wie er ist stehen — nicht pausiert, nicht archiviert, nicht inhaltlich angefasst. Eigenes, deutlich komplexeres Vier-Bedingungen-System (Demand-Index-Kreuzung NQ + Tageskontext ES + Location ES + HA-Smoothed-Abpraller), automatisiert in C#.
- Dieses neue Projekt ist bewusst schlank: nur NQ/NAS100 selbst, kein ES-Tageskontext, keine Footprint-/Orderflow-Ebene, keine Automatisierung. Mike beobachtet/handelt manuell nach einem klaren, kleinen Regelwerk ("Watch"-Strategie).
- Ob sich beide Projekte später sinnvoll verbinden (z.B. dieses Regelwerk als vereinfachter Ersatz für die HA-Smoothed-Bedingung im Bot), ist eine spätere, eigene Entscheidung — hier nicht vorweggenommen.

## Einordnung gegen den MasterPlan
Läuft unter der bereits bestehenden Trading-Ausnahme (siehe [[MasterPlan - Teilziele und Zeitplan bis 50.000 EUR]], Abschnitt 8, Update 24.09.2026): privates Trading-Werkzeug ohne Kundenkontakt, zählt nicht als zusätzliche der 1-2 erlaubten Kern-Baustellen und konkurriert nicht um die 12h/Woche IB-Business-Zeit. Trading-Gewinne zählen seit 24.09.2026 trotzdem zum 50.000-€-Ziel dazu. Keine neue Baustelle im Sinne von Punkt 8, sondern Teil derselben bereits abgesegneten Ausnahme wie der ATAS-Bot.

## Kern-Regelwerk (Mikes Erklärung, 26.09.2026 — Phase 1, vollständig spezifiziert)

### 1. Chart-Setup
- Instrument: nur NQ/NAS100 ("NASTech") — kein anderes Instrument.
- Kerzen: normale Heikin-Ashi-Kerzen für die Kursbewegung, siehe [[Heikin-Ashi Kerzen (Grundlagen)]].
- Zusätzlich als Overlay/Trendindikator: **Heikin Ashi Smoothed** (in Mikes Diktat als "Haiki Move"/"Haikiis Move" transkribiert — gemeint ist der bereits dokumentierte, doppelt geglättete Indikator, siehe [[Heikin Ashi Smoothed Reversal-Breakout-Setup]]).
- Beide Indikatoren sind bei Mike bereits in ATAS auf dem NQ-Chart eingerichtet (siehe [[ATAS Trading Bot (NQ-Abpraller-Setup)]], Phase 1) — für reine Beobachtung/manuelles Testen ab Montag ist nichts Neues zu installieren.

### 2. Richtungsfilter (Regel Nummer eins, wichtigste Regel)
Farbe/Richtung des Heikin Ashi Smoothed bestimmt die einzig erlaubte Handelsrichtung: grün = nur Long, rot = nur Short. Gegen die aktuelle Indikator-Richtung wird nie gehandelt.

### 3. Einstieg: Rücksetzer-Entry
Beispiel Long-Setup (Short spiegelverkehrt):
1. Warten auf einen Rücksetzer = Gegenbewegungs-Kerzen (rot/Sell-farbig), die in Richtung des Smoothed-Indikators laufen. Müssen ihn nicht direkt berühren — leicht darüber oder darunter zählt auch.
2. Einstieg, sobald der Rücksetzer abgeschlossen ist und wieder **zwei** Kerzen in der eigentlichen Trendrichtung erscheinen (bei Long: zwei grüne Kerzen in Folge).

Das ist aktuell der einzige vollständig spezifizierte, startklare Teil des Regelwerks.

## Noch zu bauen (Schritt für Schritt, in dieser Reihenfolge)

### Phase 2 — Seitwärtsphasen-Filter (Prinzip klar, Schwellenwert offen)
Ziel: keine Trades, wenn der Heikin Ashi Smoothed zu schnell die Richtung wechselt (kein verlässlicher Trend, sonst laufen ständig Trades, die dann doch nicht in die erwartete Richtung gehen). Umsetzung: Mindestanzahl an Kerzen, die der Indikator ununterbrochen dieselbe Richtung zeigen muss, bevor ein Setup überhaupt als gültig gilt. Exakte Kerzenzahl noch offen — wird kalibriert, sobald aus der Beobachtung von Phase 1 klar ist, wie oft/wo überhaupt brauchbare Rücksetzer auftreten (Mikes eigene Einschränkung dazu).

### Phase 3 — Demand Index als Zusatzfilter (wartet auf Mike, noch nicht spezifizieren)
Zwei von Mike explizit genannte Mechanismen, noch nicht in konkrete Regeln übersetzt:
1. **Schneller Wechsel zwischen Extremen** = starker Druck hinter der Bewegung. Bestätigt den Einstieg, wenn der Wechsel in unsere Trade-Richtung geht.
2. **Divergenz** — z.B. Preis macht ein neues Tief, der Demand Index macht aber ein neues Hoch → Kaufinteresse steigt trotz fallendem Preis → deutet auf einen möglichen Wechsel/Reversal hin.

Beides deckt sich inhaltlich mit den bereits dokumentierten Sibbet-Regeln in [[RG-Trading Indikator - Demand Index]] (v.a. Regel 1/3/6 zur Divergenz und der Abschnitt "Setup B: Trendfortsetzung" zu Rücksetzern im dominanten Segment) — **Mike hat aber ausdrücklich gesagt, dass er das nochmal exakt aus dem Kurs nachschlägt** und rund 20 markierte Chart-Beispiele nachreicht, bevor diese Phase konkret spezifiziert wird. Bis dahin bewusst nicht geraten oder vorweggenommen.

**Cross-Referenz:** [[Nasdaq-Scalping Setups (Katalog)]] Punkt 6 ("Optimierung – Heikin Ashi Smoothed Reversal Setup") ist eine bislang nicht im Detail dokumentierte Video-Lektion, laut Katalog-Notiz vermutlich genau eine Verfeinerung dieses Rücksetzer-Setups. Falls Mikes angekündigte Kurs-Nachschau dort ansetzt, lohnt sich beim nächsten Schritt ein Abgleich mit dieser Lektion.

## Offener Punkt: Trade-Management
Stop-Loss, Ziel und Positionsgröße für dieses konkrete Setup sind noch nicht besprochen. Der bestehende vault-weite Rahmen ([[Trading-Journal Struktur (1R = 200€)]], [[Trading-Psychologie - Disziplin-Regelwerk]]) gilt vermutlich auch hier, wurde von Mike aber nicht explizit für dieses Setup bestätigt — vor dem ersten Trade mit echtem Risiko (nicht nur Beobachtung) klären.

## Testplan
- **Ab Montag, 28.09.2026, sobald der Markt öffnet:** Phase 1 (Richtungsfilter + Rücksetzer-Entry) live am Chart beobachten/testen — bewusst als einzige Regel, ohne Phase 2 (Seitwärtsfilter) und Phase 3 (Demand Index), um sauber zu sehen, wann Phase 1 allein funktioniert und wann nicht mehr.
- Beobachtungen/Ergebnisse laufen in [[Trading-Ergebnisse]] bzw. als neuer Verlaufs-Eintrag hier im Projekt.

## Verlauf
**26.09.2026:** Projekt neu angelegt nach Mikes ausführlicher Sprachnotiz. Kern-Regelwerk (Richtungsfilter + Rücksetzer-Entry) vollständig für Phase 1, Seitwärtsfilter (Phase 2) und Demand-Index-Ebene (Phase 3) bewusst offen gelassen bis Mike Kurs-Details + Chart-Beispiele nachliefert. [[ATAS Trading Bot (NQ-Abpraller-Setup)]] dabei unverändert gelassen, wie ausdrücklich gewünscht.

## Referenzen
- [[ATAS Trading Bot (NQ-Abpraller-Setup)]] (getrenntes, bestehendes Projekt — unverändert)
- [[Heikin Ashi Smoothed Reversal-Breakout-Setup]]
- [[Heikin-Ashi Kerzen (Grundlagen)]]
- [[RG-Trading Indikator - Demand Index]]
- [[Nasdaq-Scalping Setups (Katalog)]]
- [[Trading]]
- [[Trading-Ergebnisse]]
- [[MasterPlan - Teilziele und Zeitplan bis 50.000 EUR]]
