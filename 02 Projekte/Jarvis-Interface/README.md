# Jarvis-Interface (v0.1 Prototyp)

Erster Entwurf für dein Jarvis-Interface, auf Basis von Punkt 3 (Model), 5 (Skills), 6 (Tools) und 7 (Gerätezugriff/Sprache) aus dem 8-Schritte-Blueprint.

## Starten

Einfach `index.html` im Browser öffnen (Chrome empfohlen, da die Spracherkennung dort am zuverlässigsten läuft). Mikrofon-Zugriff erlauben, wenn danach gefragt wird.

## Architektur (Gehirn / Hand / Stimme)

Angelehnt an dein Jarvis-Setup-Vorbild:

- **Gehirn** = dein Obsidian-Vault ("Zweites Gehirn"). Jarvis kann darin suchen (`vault.js`).
- **Hand** = einzelne spezialisierte Agenten, die Aufgaben erledigen (E-Mail, Kalender, Dashboard, …). Noch nicht gebaut — kommt Stück für Stück.
- **Stimme** = dieses Interface hier (Wake-Word, Sprachein-/ausgabe, Chat-Verlauf).

## Was schon funktioniert

- Dunkles HUD-Interface mit animiertem "Kern" (Standby/Hört zu/Denkt nach/Antwortet)
- Wake-Word-Erkennung ("Jarvis", änderbar im Einstellungsfeld) über die Web Speech API des Browsers
- Nach dem Wake-Word: Begrüßung per Sprachausgabe ("Hallo Mike, was kann ich für dich tun?"), danach Befehl per Sprache
- Verlaufs-Log (wie ein Chat-Protokoll)
- Text-Eingabefeld als Fallback, falls Sprache mal nicht will
- Stimmen-Auswahl (je nachdem, welche Systemstimmen dein Windows/Chrome anbietet)
- **Neu — Gehirn/Vault-Anbindung:** Button "📁 Vault verbinden" oben im Interface. Du wählst deinen "Zweites Gehirn"-Ordner aus, Jarvis liest alle `.md`-Notizen ein und kann danach Fragen dazu per Stichwortsuche beantworten (Titel + passende Textstelle wird vorgelesen).

### Warum musst du den Vault-Ordner jedes Mal neu auswählen?

Weil die Seite einfach per Doppelklick geöffnet wird (`file://`), blockiert Chrome aus Sicherheitsgründen die modernere API, die sich den Ordner dauerhaft merken könnte. Sobald wir später einen kleinen lokalen Server dafür laufen lassen, fällt das weg — für den ersten Test reicht das so.

## Was noch Platzhalter ist

- **Sprach-Engine:** Läuft aktuell komplett über die Browser-eigene Web Speech API (SpeechRecognition + SpeechSynthesis). Sobald klar ist, wie sich **Hermes** technisch anbinden lässt, wird nur der Block "SPRACH-ENGINE" in `app.js` ausgetauscht — der Rest der App bleibt unverändert, weil alles über `startListening()` und `speak()` läuft.
- **Hand-Agenten:** E-Mails checken, Instagram posten, Dashboards abfragen etc. — noch nicht gebaut.
- **Vault-Suche:** Aktuell eine einfache Stichwortsuche (kein "echtes" Sprachverständnis). Reicht für den ersten Test, kann später durch eine smartere Suche ersetzt werden.

## Offene Punkte / für dich

- Vault-Ordner testen: Button klicken, "Zweites Gehirn"-Ordner auswählen, dann eine Frage stellen (z. B. "Was weißt du über Apex Trader Funding?").
- Schick mir das Foto/Video, wie das Interface aussehen soll — Farben, Layout, Elemente können wir danach anpassen.
- Sobald wir wissen, was Hermes technisch ist (API? SDK? eigenständige App?), bauen wir die echte Sprachanbindung.
- Danach: den ersten "Hand"-Agenten festlegen und bauen (E-Mail? Kalender? Trading-/IB-Dashboard?).
