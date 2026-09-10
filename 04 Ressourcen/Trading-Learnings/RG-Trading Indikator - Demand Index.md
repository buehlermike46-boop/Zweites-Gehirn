---
tags: [ressource, trading, rg-trading, indikator, setup]
date: 2026-09-08
quelle: RG-Trading Academy Kurs, Lektionen "Demand Index" und "Schritt-für-Schritt-Anleitung für Setups", 08.09.2026
---

# Demand Index (DI)

Der wichtigste Bestätigungsindikator im Kurs, kommt in fast jedem Nasdaq-Scalping-Setup vor (siehe [[Nasdaq-Scalping Setups (Katalog)]]) und ist bereits knapper in [[NQ Abpraller-Setup Checkliste]] referenziert. Diese Notiz ist die vollständige Fassung.

## Was ist der Demand Index

Entwickelt von **James Sibbet**. Kombiniert Preis und Volumen zu einem **Frühindikator** (Vorlaufindikator) für Preisbewegungen, im Gegensatz zu nachlaufenden Indikatoren wie RSI. Positiver DI = Nachfrage/Käufer dominieren, negativer DI = Angebot/Verkäufer dominieren.

## Berechnung

1. Preisänderung = Schlusskurs − Eröffnungskurs (pro Kerze/Range)
2. Relativer Preisänderungsfaktor = Preisänderung / Eröffnungskurs
3. Volumenkomponente = Volumen × relativer Preisänderungsfaktor
4. Demand Index = kumulierte Summe der Volumenkomponenten

## Grafische Grundlagen

- **Nulllinie (Mittelpunktslinie):** immer in der Mitte des Indikators.
- **Oberes Segment:** Käufer dominieren. **Unteres Segment:** Verkäufer dominieren.
- **Extrempunkte:** ca. 20 Punkte von oben/unten entfernt, deuten auf überkaufte (oben) bzw. unterverkaufte (unten) Situation und potenziellen Trendwechsel hin.

## Die 6 Regeln nach James Sibbet

1. Eine **Divergenz** zwischen DI und Preis (Basistitel) deutet auf bevorstehende Kursschwäche hin (stärkstes Signal).
2. Ein eindeutiger **Hochpunkt** im DI läuft dem Preis oft voraus, gefolgt von neuen Preishochs.
3. Steigende Kurse mit **niedrigerem** DI-Hochpunkt (Hochpunkte werden nicht bestätigt) deuten einen wichtigen Wendepunkt an.
4. Ein **Kreuzen der Nulllinie** zeigt einen Trendwechsel an (Überbieten = neuer Aufwärtstrend, Unterbieten = Abwärtstrend). Hier ist der DI Trendfolger.
5. DI nahe der Nulllinie = Preisveränderungen sind unerheblich, kein neuer längerer Trend zu erwarten.
6. Eine **große, lang andauernde Divergenz** zwischen DI und Preis kündigt einen wesentlichen Umkehrpunkt an.

## Die besten Locations für DI-Signale

**Für Reversal-Setups:** VAH/VAL (Volumenbergkanten), Tageshochs/Höchstpreise (hoher Preis + DI nahe Null = starkes Umkehrsignal), rausgenommene Hochs (Divergenz an einem gerade genommenen High verstärkt das Signal).

**Für Trendfortsetzung (Rücksetzer):** dominantes Segment (DI muss dort konstant notieren, um Dominanz zu bestätigen), Nulllinie als temporäre Pullback-Zone innerhalb eines etablierten Trends.

## Setup A: Reversal Setup (Schritt für Schritt)

Am besten an kritischen VAH/VAL-Zonen.

1. **Location festlegen:** Preis erreicht eine kritische Zone (VAH, VAL, Tageshoch).
2. **Divergenz identifizieren:** Preis macht neue Hochs, aber DI zeigt fallende Hochs/schwächelt, oder Preis ist hoch bei DI nahe Null (Regel 1 & 6, stärkstes Signal).
3. **Extrempunkt/Schwäche bestätigen:** DI hat einen Extrempunkt erreicht (Regel 3).
4. **Einstiegssignal (Hauptbestätigung):** DI durchbricht die Nulllinie (Regel 4, endgültiger Trendwechsel).
5. **Zweite Bestätigung (optional):** Kurs schließt nach dem Nulllinien-Durchbruch über/unter dem [[RG-Trading Indikator - Supertrend|Supertrend]].

## Setup B: Trendfortsetzung Setup (Rücksetzer handeln)

Nur an starken Trendtagen, wenn der DI klare Dominanz zeigt.

1. **Dominanz feststellen:** Markt zeigt einen Trend, DI notiert konstant im dominanten Segment.
2. **Pullback erkennen:** Preis macht einen Rücksetzer, DI nähert sich der Nulllinie oder durchbricht sie kurzzeitig.
3. **Einstiegssignal:** DI kehrt sofort zurück ins dominante Segment → Einstieg für Trendfortsetzung.

## Cross-Referenz

Der [[NQ Abpraller-Setup Checkliste|NQ Abpraller-Setup]] nutzt eine vereinfachte Version von Setup A ("Nulllinie & Durchschnittslinie in Trade-Richtung durchbrochen, keine Divergenz") als einen von mehreren Filtern.
