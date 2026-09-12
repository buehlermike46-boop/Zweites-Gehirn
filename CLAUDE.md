# Vault Context

Dieses Vault ist das Zweite Gehirn von Mike Bühler.

## Über mich

Mike Bühler, 28 Jahre alt, gelernter Elektroniker für Betriebstechnik und Elektromeister. Baut aktuell neben seiner Anstellung als Elektroniker ein zweites Standbein im Finanzbereich auf: Trading und ein IB-Business (Introducing Broker) über Limitless & PU Prime. Ausführliches Profil in 00 Kontext/Über mich.md.

## Vault-Struktur

- 00 Kontext/: Persönliches Kontext-Profil (Über mich.md, ICP.md, Angebot.md, Schreibstil.md, Branding.md). Zentrale Referenz für alle inhaltlichen Aufgaben. Lies diese Dateien wenn du Content erstellst, Mails schreibst oder Angebote formulierst.
- 01 Inbox/: Schnelle Gedanken, Brain Dumps, unverarbeitete Notizen. Alles was noch keinen festen Platz hat landet hier.
- 02 Projekte/: Aktive Projekte mit konkretem Ziel und Enddatum. Projekte starten als einzelne .md Datei. Nur bei komplexen Projekten mit mehreren Dateien wird ein Unterordner erstellt.
- 03 Bereiche/: Laufende Verantwortungsbereiche ohne Enddatum. Jeder Bereich ist ein eigener Ordner, weil Bereiche über die Zeit wachsen und mehrere Dateien sammeln.
- 04 Ressourcen/: Referenzmaterial, Wissen, gesammelte Informationen. Jedes Thema ist ein eigener Ordner.
- 05 Daily Notes/: Tägliches Logbuch. Was an einem Tag passiert ist, welche Entscheidungen getroffen wurden, was offen ist. Gibt Claude die Kontinuität zwischen Sessions.
- 06 Archiv/: Abgeschlossene Projekte und inaktive Bereiche. Aus dem aktiven Blickfeld, aber durchsuchbar.
- 07 Anhänge/: Bilder, PDFs, Medien. Obsidian legt hier automatisch alle eingefügten Dateien ab.

## Regeln für dieses Vault

- Nutze [[Wikilinks]] für Verknüpfungen zwischen Notizen
- Neue Notizen ohne klaren Platz kommen in 01 Inbox/
- Halte Notizen atomar: eine Idee pro Notiz wo möglich. Ausnahme: Daily Notes fassen einen ganzen Tag zusammen.
- Daily Notes benennen im Format: YYYY-MM-DD.md (z.B. 2026-09-04.md). So sortieren sie automatisch chronologisch.
- Nutze YAML Frontmatter: tags, status (aktiv/abgeschlossen/pausiert), date
- Dateinamen in normaler Schreibweise mit Leerzeichen und Großbuchstaben: Beschreibender Name.md
- Neue Projekte bekommen eine einzelne .md Datei direkt unter 02 Projekte/. Einen Unterordner nur anlegen wenn das Projekt mehrere Dateien braucht.
- Bereiche und Ressourcen sind immer Ordner, weil sie über die Zeit wachsen
- Abgeschlossene Projekte nach 06 Archiv/ verschieben. Nur auf Anweisung des Nutzers, nicht eigenständig.
- Der [[MasterPlan - Teilziele und Zeitplan bis 50.000 EUR]] ist die Grundlage für alle Planung. Wöchentliche und tägliche Planung (Wochenpläne, Daily Notes, neue Aufgaben) muss auf die Teilziele und Stufen aus diesem Plan einzahlen. Bei neuen Aufgaben/Ideen kurz gegenprüfen, ob sie einer aktiven Stufe dienen, siehe auch Punkt 8 im Plan (nicht zu viele Baustellen gleichzeitig, max. 1-2 aktive Sachen bei 12h/Woche).
- Wenn du Dateien erstellst oder verschiebst, erkläre kurz warum
- Bevor du Dateien löschst oder überschreibst, frag nach
- Wenn der Nutzer sagt "merk dir das" oder "speicher das", speichere es dort wo es thematisch hingehört. Schreibregeln nach 00 Kontext/Schreibstil.md, Projekt-Infos in die jeweilige Projekt-Datei, technische Erkenntnisse in 04 Ressourcen/, Vault-Regeln in diese CLAUDE.md. Im Zweifel kurz fragen wo es hin soll.
- Schreibstil in generierten Texten: Mike duzt, locker aber professionell wo es um Kunden/Business geht, keine Gedankenstriche, Emojis nur passend zum Kontext, nie "nach KI klingen".

## Session-Routinen

**Wichtig vor jedem manuellen Subagenten-Aufruf (`/aufgaben-check`, `/content-check`, `/professor-check`):** Die Scheduled Cloud Routines pushen direkt nach `master`. Diese Subagenten selbst haben kein Bash/Git-Tool und lesen nur den lokal ausgecheckten Branch der aufrufenden Session – der kann hinter `master` zurückliegen (z.B. wenn diese Session auf einem eigenen Arbeits-/PR-Branch läuft). Deshalb: aufrufende Session macht IMMER erst `git fetch origin master && git merge origin/master`, bevor einer der drei Subagenten gestartet wird, sonst arbeitet er auf veraltetem Stand (siehe [[Qualitätsbericht]], Fehlalarm vom 11.09.2026).

### Bei Session-Start
1. Prüfe 01 Inbox/ auf neue Notizen, zeige was drin liegt, und biete an die Einträge in die passenden Ordner einzusortieren

### Kontext bei Bedarf
Wenn der Nutzer fragt "Was ist gerade aktuell?", "Wo war ich stehen geblieben?" oder ähnliches: Lies die letzten 2-3 Daily Notes in 05 Daily Notes/ und die aktiven Projekt-Dateien in 02 Projekte/ um ein Briefing zu geben.

### Bei Wochen-/Tagesplanung
Wenn ein Wochenplan oder eine Daily Note mit Aufgaben erstellt wird: kurz gegen den [[MasterPlan - Teilziele und Zeitplan bis 50.000 EUR]] prüfen, in welche Stufe das fällt und ob es der aktuellen Stufe dient. Aufgaben, die zu keiner Stufe passen, offen ansprechen statt stillschweigend mit aufzunehmen. Offene Punkte aus dem Plan (z.B. "Nächste 30 Tage"), die noch nirgends als Aufgabe stehen, immer direkt als Todo in 01 Inbox/Brain Dump.md eintragen, nicht nur verbal erwähnen.

### Aufgaben-Kontrolle & autonome Ausführung
Zwei Subagenten arbeiten zusammen, abgestimmt über `03 Bereiche/Aufgaben-Management/Tagesplan.md`:
- `aufgaben-manager` (`.claude/agents/aufgaben-manager.md`) – plant und kontrolliert. Liest MasterPlan, Aufgaben-Triage, Daily Notes, Inbox, kontrolliert die letzte 24h-Runde (nur mit Beleg abhaken, sonst nachfragen) und schreibt einen neuen `## Vorschlag für [Datum]` in `Tagesplan.md`.
- `aufgaben-executor` (`.claude/agents/aufgaben-executor.md`) – arbeitet ausschließlich den `## Bestätigt für [Datum]`-Abschnitt ab (Recherche, Texte, Entwürfe, Vault-Pflege). Läuft auch unbeaufsichtigt per Scheduled Cloud Routine. **Seit 12.09.2026 volle Ausführungs-Autonomie** (Mikes Bestätigung im Chat, siehe Log in `Tagesplan.md`): führt bestätigte Punkte auch nach außen wirkend zu Ende aus (Senden, Posten, neue Logins, Käufe, Formulare mit persönlichen Daten, endgültiges Löschen), sofern ein Werkzeug/Connector dafür vorhanden ist. Mikes Bestätigung des Tagesplans selbst ist die einzige nötige Freigabe, keine zusätzliche Einzelfreigabe pro Aktion mehr. Fehlt ein Werkzeug/Connector: Punkt landet unter `## Technisch blockiert` in `Tagesplan.md`, nicht im (seit 12.09.2026 retired) `## Freigabe-Stau`. Diese Autonomie gilt ausschließlich für den aufgaben-executor, nicht für content-executor oder die Jarvis-Nachrichten-Bridges (siehe unten, dort bleibt das Entwurf-Freigabe-Prinzip aus `[[Jarvis Hand - Agenten Ausbau]]` unverändert bestehen).

**Bestätigungs-Schleife (wichtig für jede Session):** Prüfe bei Session-Start zusätzlich `Tagesplan.md` auf einen unbestätigten `## Vorschlag`-Abschnitt und auf offene Punkte im `## Technisch blockiert`. Zeig beides Mike proaktiv, ohne dass er danach fragen muss. Bestätigt er den Vorschlag, verschiebst du die Punkte von "Vorschlag" nach "Bestätigt für [Datum]" (Edit, nicht neu schreiben) – ab da arbeitet der Executor sie selbstständig bis zum Ende ab, ohne dass du sie noch einzeln freigeben musst. **Ruf danach direkt den `aufgaben-executor` auf (Agent-Tool)**, statt auf die nächste geplante Routine zu warten – so geht's ohne Verzögerung weiter, genau wie Mike es sich seit 12.09.2026 wünscht. Technisch-blockiert-Punkte einzeln oder gesammelt mit ihm durchgehen (der `professor` schließt einen Teil davon schon selbst, wenn die Plattform bereits verbunden ist – siehe unten; was übrig bleibt braucht meist eine neue Verbindung/OAuth, die nur Mike selbst herstellen kann), und danach als erledigt/nicht relevant markieren statt löschen.

**Leerlauf-Verkettung (seit 12.09.2026, Mikes Wunsch):** Immer wenn eine Session den `aufgaben-executor` aufruft (egal ob Scheduled Cloud Routine oder manuell über `/aufgaben-check`) und dessen Bericht/Log-Eintrag die Zeile `LEERLAUF: aufgaben-manager sollte einen neuen Vorschlag erstellen` enthält: **ruf direkt im selben Lauf den `aufgaben-manager` auf** (Agent-Tool), damit ein neuer `## Vorschlag` in `Tagesplan.md` entsteht. Ergibt sich daraus ein neuer Vorschlag, schick Mike danach eine **Push-Nachricht** (PushNotification-Tool) mit einer kurzen Zusammenfassung (Stufe, wichtigste Punkte, Link/Verweis auf `Tagesplan.md`) und der Bitte um Bestätigung – das war schon immer so im Tagesplan-Template vorgesehen ("wartet auf Mikes Bestätigung per Push-Nachricht"), lief bisher aber nicht zuverlässig. So bleibt der Kreislauf am Laufen, ohne dass Mike selbst dran denken muss nachzufragen: Executor arbeitet ab → läuft leer → Manager legt neuen Vorschlag vor → Push an Mike → Mike bestätigt → Executor arbeitet sofort weiter (siehe oben) → usw. Bricht nur ab, wenn Mike nicht bestätigt – das ist gewollt, keine Aktion ohne seine Bestätigung des Plans.

Manuell auslösbar über `/aufgaben-check`.

### Content-Agent (Instagram, Limitless-Account)
Zwei Subagenten arbeiten zusammen, abgestimmt über `03 Bereiche/Marketing & Kundenakquise/Posting-Warteschlange.md`:
- `content-manager` (`.claude/agents/content-manager.md`) – plant wöchentlich. Liest Business-Kontext, Performance-Log, bestehende Recherche, kontrolliert die letzte Posting-Runde und schreibt neue Post-Vorschläge in die Queue. Recherchiert bei Bedarf öffentliche Ads/Trends nur zur Inspiration, schaltet nie selbst bezahlte Werbung (Meta verbietet das für CFD/Forex komplett, Account-Risiko).
- `content-executor` (`.claude/agents/content-executor.md`) – erstellt fällige Posts über den Jarvis/Higgsfield-Connector und postet sie über Windsor.ai auf Instagram (`mike_bueh`). Läuft auch unbeaufsichtigt per Scheduled Cloud Routine. Pflegt danach das Performance-Log.

**Freigabe-Phase steht oben in `Posting-Warteschlange.md`, zweistufig:** Phase 1 "Freigabe nötig" (aktuell aktiv, seit 10.09.2026) heißt: der Executor postet nur Einträge mit Status `freigegeben`, alles andere bereitet er nur vor. Phase 2 "automatisch" heißt: der Executor postet neue Einträge ohne Einzelfreigabe. Nur Mike schaltet zwischen den Phasen um, keiner der beiden Agenten tut das selbst.

Manuell auslösbar über `/content-check`. Bei Session-Start zusätzlich kurz prüfen, ob in Phase 1 Posts mit Status `bereit (wartet auf Freigabe)` auf Mikes Ja/Nein warten, und proaktiv zeigen.

### Professor (Qualitätsmanagement für die Agenten-Struktur)
`professor` (`.claude/agents/professor.md`) – prüft regelmäßig alle laufenden Agenten (aufgaben-manager/-executor, content-manager/-executor, sich selbst eingeschlossen) auf Reibung und Ineffizienz, sucht über die Skill-/Plugin-/Connector-Suche passende Bausteine für echte Lücken (installiert nichts selbst, kann er technisch nicht) und schreibt einen Bericht nach `03 Bereiche/Agenten-Qualität/Qualitätsbericht.md`. Legt neue Agenten-Entwürfe höchstens als Datei an, aktiviert/scheduled nie selbst eine Routine.

**Erweitert seit 12.09.2026 (Mikes Wunsch):** Der `professor` wacht darüber, dass sich Agenten nicht gegenseitig ins Gehege kommen – findet er in `Tagesplan.md` einen Punkt, der eigentlich Content-Gebiet ist (oder umgekehrt in `Posting-Warteschlange.md` einen, der eigentlich allgemeine Aufgabenplanung ist), verschiebt er ihn in die richtige Datei. Außerdem schließt er Werkzeug-Lücken des `aufgaben-executor` aus dessen `## Technisch blockiert`-Meldungen: ist die Plattform laut Vault bereits verbunden, trägt er das fehlende Tool direkt in dessen `tools:`-Liste ein, statt nur zu berichten. Ist die Plattform neu, bleibt es beim bisherigen Prinzip (Skill/Plugin/Connector vorschlagen, Mike bestätigt per Klick).

**Bewusste Ausnahme, seit 10.09.2026:** Der `professor` existiert, obwohl der [[MasterPlan - Teilziele und Zeitplan bis 50.000 EUR]] eigentlich max. 1-2 aktive Baustellen vorsieht und der `content-manager`/`content-executor` zu dem Zeitpunkt noch nicht einmal live lief. Mike hat sich dafür bewusst entschieden. Der `professor` bewertet diesen Zustand in seiner ersten Runde selbst, siehe `03 Bereiche/Agenten-Qualität/Qualitätsbericht.md`.

Manuell auslösbar über `/professor-check`.

### Bei Session-Ende
Wenn der Nutzer die Session beendet oder du merkst dass ein natürliches Ende erreicht ist, biete an:
1. Einen Daily Note Eintrag in 05 Daily Notes/ zu erstellen mit einer Zusammenfassung des Tages
2. Neue Erkenntnisse als Notizen zu speichern
3. Die Inbox aufzuräumen falls nötig

## Nach dem Setup

Falls der Nutzer sagt "Setup nochmal durchführen" oder "Vault neu einrichten", die ursprüngliche Setup-Anleitung wieder ausführen (Phasen 1-9 wie beim ersten Onboarding).
