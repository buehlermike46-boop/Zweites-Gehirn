---
tags: [bereich, marketing, einnahmequellen, akquise]
status: aktiv
date: 2026-09-24
---

# Handwerker-Chatbot Akquise

Vorbereitung für die Ansprache von Elektro-Handwerksbetrieben zum [[Einnahmequellen-Recherche|Handwerker-Chatbot]] (Make-Szenario 7597709, "Handwerker-Chatbot Demo (FAQ + Terminanfrage)"). Entstanden aus Mikes direktem Auftrag im Chat vom 24.09.2026: "Bereite alles vor und suche 30 potentielle Kunden für mich heraus und schreib ihnen ein Angebot das sie auch wirklich kaufen wollen."

**Status: reine Vorbereitung.** Nichts wurde verschickt, kein Betrieb wurde kontaktiert. Liste und Texte warten auf Mikes Durchsicht und Freigabe, siehe Eintrag unter `## Freigabe nötig: Einnahmequellen` in [[Tagesplan]].

**Zielgruppen-Begründung:** bewusst Elektro-Handwerksbetriebe statt Handwerk allgemein, weil Mike selbst gelernter Elektroniker für Betriebstechnik und Elektromeister ist (siehe [[Über mich]]) — das ist ein echter Vertrauensvorsprung ("ich bin selbst vom Fach"), kein anonymer Kaltakquise-Pitch.

**Wichtiger Zusammenhang mit dem Chatbot selbst:** Die Demo lief seit 24./25.09.2026 technisch fertig und getestet, aber inhaltlich mit einem Pflegedienst-Platzhalter (Seniorendienst Klein, der ursprüngliche technische Testfall). Am 25.09.2026, abends, auf Mikes Wunsch ("echter Inhalt statt Platzhalter-Firmenprofil") durch ein echtes Elektrobetrieb-Musterprofil ersetzt (Leistungen: Elektroinstallation, PV, Wallbox, Smart Home, E-Check, Notdienst; Einsatzgebiet Kreis Viersen — passend zu den tatsächlich recherchierten Zielkunden), Szenario umbenannt in "Chatbot TEST: Handwerker-Demo (Elektrobetrieb)", live gegen den Webhook getestet (beide Routen: FAQ-Antwort und Terminanfrage). Die Demo ist damit inhaltlich jetzt tatsächlich passend zur Zielgruppe, nicht nur technisch funktionsfähig. Details siehe [[Tagesplan]] Log-Eintrag vom 25.09.2026.

**Strategische Neubewertung (25.09.2026, Mikes Entscheidung im Chat):** Mike hält den Chatbot für das stärkere, schwerer kopierbare Angebot im Vergleich zum GMB-Bewertungspaket (siehe [[GMB-Angebot Akquise]]) — eine echte funktionierende Automatisierung statt einer Text-/Design-Vorlage. Die parallel laufende GMB-Mailkampagne wurde deshalb pausiert (Stand: 11 von 30 raus, siehe [[GMB-Angebot Akquise]]), der Fokus liegt jetzt auf dem Chatbot als Hauptangebot.

## Live-Demo-Seite (25.09.2026, abends)

**https://handwerker-chatbot.higgsfield.app** — echte, live erreichbare Landingpage für die Chatbot-Demo, gebaut über den Jarvis/Higgsfield-Website-Builder (eigenes Cloudflare-Worker-Projekt, kein Vault-Code). Löst das ursprüngliche Problem ("nichts live vorführbares", siehe Log 24.09.) und den akuten Bug vom selben Abend: das erste lokale Embed-Widget (`Chatbot-Widget (Embed-Baustein).html`) funktionierte beim lokalen Öffnen per Doppelklick nicht (`file://`-Ursprung, Browser blockt Netzwerk-Anfragen von lokalen Dateien an externe Server — nicht der Server/CORS, das war schon korrekt konfiguriert).

**Aufbau:** Hero, "So funktioniert's" (3 Schritte), eingebettete echte Live-Chat-Demo (ruft denselben Make-Webhook wie das lokale Widget auf), Verfügbarkeits-Abschnitt, Kontakt-CTA. Eigenes generiertes Bildkonzept (Kobalt-Blau auf warmem Off-White, Elektro-Handwerk-Motiv), keine Higgsfield-Marke sichtbar. Demo-Firmenname "Musterbetrieb Elektrotechnik" ist als Platzhalter im Text auf der Seite selbst gekennzeichnet, um keine Verwechslung mit einer echten Firma zu erzeugen.

**Wichtige Nebenentscheidung während des Baus:** Higgsfield-Websites sind ohne "Publish" nicht öffentlich erreichbar (401 "unauthenticated" beim ersten Deploy) — Publish listet die Seite aber zusätzlich in der öffentlichen Higgsfield-Community-Galerie, was ursprünglich explizit abgelehnt war (reines Geschäfts-Tool, kein Showcase). Mike hat im Chat nachträglich zugestimmt, das in Kauf zu nehmen, damit der Link überhaupt funktioniert — Marketplace-Listing ist ihm nicht wichtig. Marketplace-Link (nicht weiter genutzt): https://higgsfield.ai/supercomputer/apps/8d9774f2-4a30-434f-90c7-13ca3bec32d9/view

**Für spätere Sessions:** Änderungen an der Seite laufen über die Jarvis-Website-Tools (`website_repo_access`, `deploy_website`), nicht über dieses Git-Repo — der Seiten-Code liegt in einem eigenen, von Higgsfield verwalteten Repo (website_id `01f874f1-05bb-46f4-bc50-f470e4154701`). Nach jeder Änderung erneut `deploy_website` nötig, sonst bleibt die alte Version live.

**Update 25.09.2026, Mikes Auftrag ("Websites bauen, als Synergie zu meinem Bot und Google-Optimierung"):** dieselbe Website zu einer vollwertigen Mehrseiten-Website ausgebaut (Start, Leistungen, Bewertungen, Kontakt), nicht mehr nur eine Chatbot-Landingpage. Dient jetzt als Live-Beispiel für das neue **Website-Komplettpaket** (eigene Website + Chatbot + Google-Optimierung, Empfehlung 1.490-2.490 EUR), siehe [[Einnahmequellen-Recherche]], Abschnitt "Idee 2: Website-Komplettpaket". Der Chatbot bleibt unverändert auf der Startseite eingebettet.

## Update 25.09.2026, spät abends: zu Gesamtpaket zusammengelegt

Mike hat entschieden, den Chatbot nicht mehr als eigenständiges Angebot zu führen, sondern zusammen mit dem GMB-Paket (siehe [[GMB-Angebot Akquise]]) als **ein Gesamtpaket für 299 EUR**. Details, Preis-Begründung und der neue, gemeinsame Angebotstext (E-Mail + Telefon) stehen in [[Einnahmequellen-Recherche]], Abschnitt "Idee 1 + 3 zusammengelegt". Die 30 hier recherchierten Betriebe bleiben die Zielkundenliste für beide Bausteine zusammen — keine neue Recherche nötig.

## Teil 1: 30 Elektro-Handwerksbetriebe

**Quellen:** ausschließlich öffentlich zugängliche Daten — hauptsächlich `dashandwerk.de`, das offizielle Verzeichnis "E-Handwerke Niederrhein-Kreis Viersen" (Innungsbetriebe), ergänzt um die jeweilige eigene Firmenwebsite, Gelbe Seiten und Das Örtliche. Keine privaten oder nicht-öffentlichen Daten gesammelt — nur was auf der eigenen Firmenwebsite oder in öffentlichen Branchenverzeichnissen sowieso steht. Regionaler Schwerpunkt Kreis Viersen (Mikes eigener Wohnraum Süchteln/Viersen), erweitert auf Willich, Tönisvorst, Nettetal, Kempen, Grefrath und Mönchengladbach, um auf 30 zu kommen.

**Hinweis zur Kontaktdaten-Spalte:** Wo eine eigene Firmenwebsite existiert, ist die primär genannt (Kontaktformular/Impressum dort). Wo keine eigene Website auffindbar war, steht die öffentlich gelistete Telefonnummer (Gelbe Seiten/Das Örtliche). Vor tatsächlicher Kontaktaufnahme lohnt sich ein kurzer Blick auf die jeweils aktuelle Website — Handwerksbetriebe wechseln gelegentlich Adresse/Ansprechpartner, die Suche datiert vom 24.09.2026.

| # | Firmenname | Ort | Kontaktweg | Notiz (Größe/Passung) |
|---|---|---|---|---|
| 1 | Edmund Rohde Elektromeister | Viersen-Süchteln | Tel. 02162 4 53 13 (Gelbe Seiten, keine eigene Website gefunden) | Kleiner Einzel-Meisterbetrieb, direkt in Mikes eigenem Stadtteil Süchteln |
| 2 | Elektro Birker GmbH | Viersen-Süchteln | www.elektro-birker.com | GmbH mit Elektrogroßhandel + Installation + Antennenanlagen, 2 Geschäftsführer, mittelständisch |
| 3 | Elektroanlagen Jan-Dieter Brüggemann GmbH | Viersen | www.elektro-brueggemann.de (Tel. 02162 29743) | GmbH, Industrie/Gewerbe/Privat, zusätzlich Kälte-/Klimatechnik |
| 4 | Elektro Herentrey GmbH | Viersen-Dülken | www.elektroherentrey.de | GmbH seit 2000, bildet aus, Elektro + Hausgeräteservice |
| 5 | Elektrotechnik Heiner Hermans GmbH | Viersen | www.elektro-hermans.de | GmbH, Spektrum von privater Standardinstallation bis Industrie |
| 6 | KKR Louwen GmbH | Viersen-Süchteln | www.kkrgmbh.de (service@kkrgmbh.de) | 10-19 Mitarbeiter, Klima/Kälte/Elektro/PV, ebenfalls Mikes eigener Stadtteil |
| 7 | Elektro Lenzen GmbH & Co. KG | Viersen-Dülken | www.elektrolenzen.de (info@elektrolenzen.de) | Industrie- und Privatkunden, seit 1996 |
| 8 | Georg Lerchner Elektro-Installationen GmbH & Co. KG | Viersen | www.elektro-lerchner.de | Seit 1962, breites Spektrum von Klingelanlage bis Starkstrom |
| 9 | Frank Mihm Elektroinstallateurmeister | Viersen | www.elektro-mihm.de | Familienbetrieb 2. Generation, seit 1964, PV/Wärmepumpe |
| 10 | Torsten Jütte Elektrotechnik (Elektro Jütte) | Viersen | Tel. 02162 914787 / juetteelektro@aol.com | Kleiner Einzelbetrieb, gut bewertet, PV/Smart Home |
| 11 | Elektro Bogisch GmbH & Co. KG | Willich | www.elektrobogisch.de (info@elektrobogisch.de) | Familienbetrieb seit 1994, Elektro + Großküchentechnik |
| 12 | Heuser & Wankum Elektrotechnik GmbH | Willich | https://heuser-wankum.de/ | Smart Home/PV/E-Mobilität/Sicherheitstechnik, bildet seit 2007 aus |
| 13 | Elektro Lücke GmbH | Willich | www.elektro-luecke.de | 49 Mitarbeiter, über 40 Jahre am Markt, größerer Betrieb |
| 14 | Mainka Elektroanlagen GmbH | Willich | www.elektro-mainka.de (Tel. 02154/412750) | Industrie/Gewerbe/Privat, Innungsfachbetrieb |
| 15 | Franz Tillmanns (Tillmanns Haustechnik) | Willich | Adresse/Tel. laut Stadt-Willich-Wirtschaftsverzeichnis | Kleiner Familienbetrieb, Elektro + Sanitär/Heizung + Kaminstudio |
| 16 | Fabian Gietmann (FG Energie- und Gebäudetechnik) | Willich | Tel. 02161 3040982 | Einzelbetrieb, Energie- und Gebäudetechnik |
| 17 | Elektro Baumanns Installations GmbH | Tönisvorst | www.elektro-baumanns.de (info@elektro-baumanns.de) | Ausbildungsbetrieb, E-Check/Gebäudesystemtechnik |
| 18 | Elektro Richter e.K. | Tönisvorst | www.elektro-richter.nrw | Wallbox/Smart Home/PV/Sicherheitstechnik, HomePilot-zertifiziert |
| 19 | Wolfram Hahn Elektrotechnikerbetrieb & Handel | Tönisvorst | Tel. 02151 368902 | Kleiner Betrieb, wirbt mit individuellem Kundenservice |
| 20 | Elektrotechnik Bergmann GmbH | Nettetal | Tel. 02153-1277675 | GmbH, privat und gewerblich |
| 21 | Elektrotechnik Kempkes GmbH | Nettetal-Lobberich | www.elektro-kempkes.de (info@elektro-kempkes.de) | Wallbox/PV/Sicherheitstechnik/Kommunikationstechnik |
| 22 | Elektro Becker e.K. (Inh. Wilfried Becker) | Nettetal-Kaldenkirchen | elektrobecker-nettetal.de (Tel. 02157-811900) | E-Check, Beleuchtung, PV |
| 23 | Elektro Klinkertz GmbH | Nettetal | Tel. 02157-6096 | E-Check, etablierter Betrieb |
| 24 | Elektroanlagen Göbel GmbH | Kempen | www.elektroanlagen-goebel.de | Ca. 60 Mitarbeiter, seit 1976, bedient trotz Größe auch Privatkunden |
| 25 | Elektro Kranen GmbH | Kempen-St. Hubert | www.elektro-kranen.de | 35 Mitarbeiter, seit 1953, Privat- und Gewerbekunden |
| 26 | ElektroTechnik Leber GmbH | Kempen-St. Hubert | www.etlg-mbh.de (Tel. 02152 96 22 60) | Gewerbe/Privat, Smart Home, Straßenbeleuchtung |
| 27 | EKA Elektroanlagen GmbH & Co. KG | Grefrath | kontakt@eka-tebyl.de (Tel. 02158/951957) | Elektroinstallation + Solaranlagen |
| 28 | Göbel Manfred & Kompagnon Elektrotechnik GmbH | Grefrath | www.goebelgmbh.de (info@goebelgmbh.de) | VdS-zertifiziert, Schwerpunkt Sicherheitstechnik |
| 29 | Elektro Kamper GmbH | Mönchengladbach | www.elektro-kamper.de | Seit 1961, größerer regionaler Betrieb (ca. 50 km Einzugsgebiet) |
| 30 | Elektro Bremges (Starkstrom Bremges) | Mönchengladbach | www.starkstrom-bremges.de | Seit 1934, Meisterfachbetrieb, Stiebel-Eltron-Vertragspartner |

**Kurze Einordnung nach Recherche:** bewusst mit Fokus auf Betriebe, die erkennbar auch Privat-/Gewerbekunden mit häufigen Anrufen bedienen (Installation, Smart Home, PV, Wallbox, E-Check) statt reiner Industrie-/B2B-Zulieferer (z.B. Elektromotoren-Reparatur, Schaltanlagenbau) — die Terminanfrage-/FAQ-Logik des Chatbots passt auf den ersten Typ deutlich besser. Mehrere Betriebe wurden aus genau diesem Grund aus der ursprünglichen Auswahl wieder rausgenommen (Elektromotoren-/Hebezeug-/Maschinenbau-Spezialisten) und durch klassische Elektroinstallations-Meisterbetriebe ersetzt.

## Teil 2: Angebotstext

Basierend auf `00 Kontext/Schreibstil.md`, `00 Kontext/Angebot.md`, `00 Kontext/ICP.md` und `00 Kontext/Über mich.md`. Duzen, locker aber professionell, keine Gedankenstriche, kein Hard-Sell, nichts behauptet was nicht stimmt (kein fertiges Produkt, keine Referenzkunden, keine erfundenen Erfolge).

### Langversion (E-Mail / Kontaktformular)

> **Betreff: Kurze Frage von einem Kollegen vom Fach an [Firmenname]**
>
> Hallo [Ansprechpartner / Team von [Firmenname]],
>
> mein Name ist Mike Bühler, ich bin selbst gelernter Elektroniker für Betriebstechnik und Elektromeister, aktuell noch fest angestellt und baue nebenbei etwas im Digitalen auf. Deshalb schreibe ich euch nicht als anonyme Agentur, sondern als jemand der weiß wie das im Handwerksalltag läuft. Ständig klingelt das Telefon, viele Anrufer fragen dasselbe (Preise, ob ihr Notdienst macht, ob ihr auch Wallboxen installiert), und parallel will jemand einen Termin, während du eigentlich auf der Baustelle stehst.
>
> Genau dafür habe ich einen kleinen Chatbot gebaut, der auf der Website die häufigsten Kundenfragen sofort beantwortet und Terminanfragen direkt aufnimmt, inklusive Kontaktdaten, damit ihr nur noch zurückrufen müsst statt jeden Anruf selbst anzunehmen.
>
> Ganz ehrlich: das Ganze ist aktuell eine funktionierende Demo, kein fertiges Produkt von der Stange, und ich habe noch keine Referenzkunden vorzuweisen, das kommt gerade erst. Genau deshalb würde ich es dir gern unverbindlich in 15 Minuten zeigen, live am Beispiel, ohne Verpflichtung und ohne Verkaufsgespräch. Wenn es nichts für euch ist, sag einfach Bescheid, dann war's das.
>
> Hättest du diese oder nächste Woche kurz Zeit? Meld dich gern hier zurück oder ruf mich an unter [Telefonnummer].
>
> Viele Grüße
> Mike Bühler
> [Telefonnummer] · [E-Mail-Adresse]

### Kurzversion (Telefon-Gesprächsleitfaden)

> Hallo, mein Name ist Mike Bühler, ich bin selbst gelernter Elektroniker und Elektromeister und melde mich kurz als Kollege vom Fach, nicht als Verkäufer. Ich habe in meiner Freizeit einen kleinen Chatbot für Elektrobetriebe gebaut, der auf der Website häufige Kundenfragen beantwortet und Terminanfragen direkt aufnimmt, damit nicht jeder Anruf bei euch landet.
>
> Das ist aktuell eine Demo, noch kein fertiges Produkt, deshalb zeige ich das gerade ein paar Betrieben aus der Region unverbindlich. Hättest du 15 Minuten, wo ich dir das kurz zeigen kann? Kein Verkaufsgespräch, wenn's nichts für dich ist, ist das auch völlig okay.

**Platzhalter-Hinweis:** `[Firmenname]`, `[Ansprechpartner]`, `[Telefonnummer]`, `[E-Mail-Adresse]` vor Verwendung pro Betrieb ausfüllen. Bewusst EIN wiederverwendbarer Text statt 30 Einzeltexte, wie im Auftrag verlangt.

## Rechtlicher Hinweis (keine Rechtsberatung, nur Einordnung)

E-Mail-Kaltakquise an Unternehmen ohne vorherige Geschäftsbeziehung fällt in Deutschland unter das UWG (§ 7, unzumutbare Belästigung) und ist auch im B2B-Bereich enger gefasst als oft angenommen — grundsätzlich wird eine ausdrückliche oder zumindest mutmaßliche Einwilligung des Empfängers vorausgesetzt. Telefonische Erstansprache von Unternehmen ist rechtlich etwas großzügiger geregelt als bei Privatpersonen (bei Verbrauchern verlangt § 7 Abs. 2 Nr. 2 UWG eine ausdrückliche Einwilligung, bei Unternehmen kann unter Umständen eine mutmaßliche Einwilligung ausreichen, z. B. bei erkennbarem sachlichem Bezug zur Branche), ist aber ebenfalls kein rechtsfreier Raum. Ein Kontaktformular auf der eigenen Firmenwebsite des Betriebs ist ein vom Betrieb selbst bereitgestellter Kanal für geschäftliche Anfragen und dürfte in der Praxis unkritischer sein als eine unaufgeforderte E-Mail an eine irgendwo gefundene Adresse — das ist aber ebenfalls keine Garantie und keine Rechtsauskunft.

**Diese Einschätzung ersetzt keine anwaltliche Beratung.** Bevor tatsächlich verschickt oder angerufen wird, wäre entweder eine kurze Rückfrage bei einem Anwalt/einer Anwältin oder zumindest eine bewusste eigene Risikoentscheidung sinnvoll. In der Praxis gilt der persönliche Telefonanruf (kein automatisiertes Anrufsystem) häufig als der unkompliziertere der beiden Wege — das ist eine allgemeine Einordnung, keine verbindliche Aussage für diesen konkreten Fall.

## Offene Entscheidungen für Mike

1. **Grundsätzliches Ja/Nein**, ob und wann diese 30 Betriebe angesprochen werden sollen.
2. **Telefon vs. E-Mail/Kontaktformular** als Kanal, unter Berücksichtigung des rechtlichen Hinweises oben.
3. **Timing gegenüber der Chatbot-Aktivierung:** Aktuell ist die Demo technisch fertig, aber nicht aktivierbar (Make-Plan-Limit, siehe [[Tagesplan]], "Technisch blockiert"). Ohne Aktivierung gibt es nichts live Vorführbares für die versprochenen "15 Minuten zeigen" — macht es mehr Sinn, erst die Aktivierungsfrage zu klären (Make-Plan upgraden oder ein bestehendes Szenario Platz machen lassen) und danach anzusprechen, oder soll trotzdem schon early angesprochen werden (z. B. mit Screenshots/Video statt Live-Demo)?
4. Falls Ja zur Ansprache: soll mit einer kleinen Testgruppe (z. B. 5 Betriebe) gestartet werden, um den Text/die Reaktion zu prüfen, bevor alle 30 angeschrieben/angerufen werden?

---

Verknüpft: [[Einnahmequellen-Recherche]] · [[Tagesplan]] · [[Über mich]] · [[MasterPlan - Teilziele und Zeitplan bis 50.000 EUR]]
