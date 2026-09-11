---
tags: [bereich, agenten, qualitaetsmanagement]
status: aktiv
date: 2026-09-10
---

# Qualitätsbericht

Laufender Bericht des `professor`-Agenten (siehe `.claude/agents/professor.md`) über Mikes gesamte Agenten-/Arbeitsstruktur. Neue Runden kommen als eigener Abschnitt dazu, nichts wird überschrieben.

## Bericht vom 10.09.2026 (Eröffnung, von Mike/Claude, nicht vom Professor selbst)

Der `professor` wurde heute Abend gebaut, **bewusst als Ausnahme** von der eigenen MasterPlan-Regel (Abschnitt 8: max. 1-2 aktive Baustellen, Abschnitt "Was KI-Agenten realistisch bringen": erst einen Agenten zuverlässig laufen lassen, dann den nächsten). Zum Zeitpunkt des Baus lief der `content-manager`/`content-executor` (heute ebenfalls neu gebaut) noch kein einziges Mal live, unter anderem weil den zugehörigen Scheduled Routines noch die Connectoren fehlen. Mike hat sich dafür entschieden, trotzdem jetzt zu bauen.

**Damit ist die erste ehrliche Aufgabe für den `professor` in seiner ersten echten Runde vorgezeichnet:** genau diesen Zustand bewerten. Aktuelle Baustellen-Lage bei Eröffnung:

1. `aufgaben-manager`/`aufgaben-executor` – läuft, mit Beleg (Log in [[Tagesplan]])
2. `content-manager`/`content-executor` – gebaut, aber noch nicht live (Connectoren fehlen)
3. `professor` – gerade erst gebaut, noch kein einziger Lauf

Drei parallele Agenten-Baustellen bei einem Zeitbudget von 10-15h/Woche ist mehr, als der Plan vorsieht. Der `professor` sollte das in seiner ersten Runde nicht schönreden.

## Bericht vom 11.09.2026

Erster echter Live-Lauf des `professor`, kein Trockentest. Quellen gelesen: `MasterPlan`, `CLAUDE.md` (Session-Routinen), alle fünf Dateien unter `.claude/agents/`, `Tagesplan.md`, `Posting-Warteschlange.md`, `Performance-Log.md`, `Marketing & Kundenakquise.md`, `Aufgaben-Triage (Sofort, Aufwendig, Komplex).md`, die sechs vorhandenen Daily Notes (04., 06.–10.09.2026 – für den 11.09. existiert noch keine), und dieser Bericht selbst.

### 1. Bestandsaufnahme

Fünf Agenten-Dateien, drei funktionale Einheiten:

- `aufgaben-manager` (`.claude/agents/aufgaben-manager.md`) – plant/kontrolliert Mikes 24h-Aufgabenliste gegen den MasterPlan, schreibt Vorschläge in `Tagesplan.md`. Laut CLAUDE.md als Scheduled Cloud Routine um 06:00 Uhr geplant.
- `aufgaben-executor` (`.claude/agents/aufgaben-executor.md`) – arbeitet den bestätigten Tagesplan ab, führt nichts nach außen aus. Scheduled um 06:30 Uhr.
- `content-manager` (`.claude/agents/content-manager.md`) – plant wöchentlich Instagram-Content, wertet Performance aus, schreibt Vorschläge in `Posting-Warteschlange.md`. Scheduled sonntags 17:00 UTC (laut Daily Note 10.09.).
- `content-executor` (`.claude/agents/content-executor.md`) – erstellt Assets über Jarvis/Higgsfield, postet über Windsor.ai, pflegt das Performance-Log. Scheduled täglich 16:35 UTC (laut Daily Note 10.09.).
- `professor` (`.claude/agents/professor.md`) – dieser Agent. Ob und wie oft er als eigene Scheduled Routine läuft, ist im Vault nicht dokumentiert (CLAUDE.md nennt nur `/professor-check` als manuellen Trigger); dieser Lauf wurde von der aufrufenden Session ausgelöst.

**Wie viele laufen tatsächlich zuverlässig, nicht nur als Datei: null.** Das ist der zentrale Befund dieser Runde, siehe Abschnitt 2.

### 2. Qualitätsprüfung je Agent, mit Beleg

**`aufgaben-manager`/`aufgaben-executor` – kein Beleg für einen einzigen gelaufenen Zyklus, trotz gegenteiliger Annahme im Eröffnungsbericht vom 10.09.2026.**
- `Tagesplan.md` steht exakt auf dem Gerüst-Zustand vom 10.09.: `## Vorschlag für [Datum wird beim ersten Lauf eingetragen]` ist unverändert der Platzhalter, `## Bestätigt für [Datum]` ist leer, `## Log` hat **keinen einzigen Eintrag** – auch keinen "kein bestätigter Plan, nichts unternommen"-Eintrag, den der `aufgaben-executor` laut eigenem Prompt selbst dann schreiben müsste, wenn nichts zu tun war.
- `Aufgaben-Triage (Sofort, Aufwendig, Komplex).md` ist seit dem 10.09. nicht weitergeführt worden (Kopf-Datum unverändert, keine neuen Abhakungen).
- Für den 11.09.2026 existiert noch keine Daily Note.
- **Das widerspricht der Aussage im Eröffnungsbericht** ("`aufgaben-manager`/`aufgaben-executor` – läuft, mit Beleg (Log in [[Tagesplan]])") **und der Notiz in der Daily Note vom 10.09.** ("Aufgaben-Manager (06:00) und Aufgaben-Executor (06:30) … sind also durchgehend normal gelaufen"). Beide Aussagen bezogen sich offenbar darauf, dass die Routinen über die claude.ai-Oberfläche angelegt und nicht pausierbar waren – nicht auf einen tatsächlichen, im Vault sichtbaren Lauf. Im Vault selbst fehlt der Beleg vollständig, sowohl für den 10.09. als auch für den 11.09. (Stand jetzt).
- **Einordnung, ehrlich:** Ich kann von hier aus nicht unterscheiden, ob (a) die Scheduled Routines technisch nie aktiv wurden, (b) sie liefen, aber nicht committen/pushen konnten, oder (c) der 06:00/06:30-Trigger heute schlicht noch nicht erreicht war, als dieser Lauf startete. Das ist trotzdem ein Problem: Ohne verlässlichen Log-Eintrag bei jedem Lauf (siehe Korrektur unten) ist diese Frage von niemandem – auch nicht von Mike selbst – ohne Blick in die claude.ai-Routines-Oberfläche zu beantworten.
- **Konkrete Empfehlung an Mike (keine Aufgabe, die ich selbst anstoße):** in der claude.ai-Oberfläche prüfen, ob die beiden Routinen wirklich aktiv/scheduled sind und schon mindestens einmal gelaufen sind.

> [!error] Korrektur (aufrufende Session, 11.09.2026, kurz nach diesem Bericht): Fehlalarm
> Dieser ganze Befund ist **falsch**, und zwar nicht wegen der beiden Agenten, sondern wegen eines Bugs in meinem eigenen Vorgehen. Der `professor` hat kein Bash/Git-Tool und konnte deshalb nur den lokal ausgecheckten Branch lesen (den Arbeits-Branch für Content-Agent/Professor, nicht `master`). `aufgaben-manager` und `aufgaben-executor` pushen aber direkt nach `master` – und dort standen zum Zeitpunkt dieses Berichts längst drei neue Commits, die der Professor nie gesehen hat: ein echter Vorschlag vom Manager (11.09., 06:05 UTC), ein korrekter "kein bestätigter Plan"-Log-Eintrag vom Executor (11.09., 06:36 UTC), und eine Bestätigung des Vorschlags durch Mike selbst. Beide Routinen laufen also, wie geplant. Die tatsächliche Lehre daraus: die aufrufende Session muss vor jedem `/aufgaben-check`, `/content-check` oder `/professor-check` erst `git fetch origin master && git merge origin/master` machen, bevor sie einen der Subagenten startet – sonst arbeiten sie auf einem veralteten Stand. Diese Regel jetzt in CLAUDE.md ergänzt. Der Rest dieses Berichts (Abschnitt 2 zum `content`-Paar, Abschnitt 3 Baustellen-Zahl "drei", Abschnitte 4-6) bleibt unverändert gültig, nur die Aussage zu `aufgaben-manager`/`aufgaben-executor` in diesem Abschnitt ist zurückzuziehen.

**`content-manager`/`content-executor` – bestätigt noch nicht live, wie im Eröffnungsbericht angekündigt, aber jetzt mit einer neuen, konkreten Konsequenz.**
- `Posting-Warteschlange.md` enthält weiterhin exakt die drei Einträge, die am 08./10.09. von Hand/im Setup angelegt wurden, keine neuen Vorschläge vom `content-manager` (der laut Plan sonntags läuft – der 10.09. war ein Donnerstag, insofern noch kein fälliger Lauf, das ist kein Fehlbefund).
- `Performance-Log.md` hat weiterhin genau die eine Zeile vom 09.09.2026 (vor Bau der Agenten, von Hand gepostet). Kein neuer Eintrag, keine Nachtragung von Reichweiten-Zahlen für diesen Post, obwohl er inzwischen weit über 24–48h alt ist – das wäre laut `content-executor`-Prompt (Schritt 4) fällig gewesen, sobald der Executor einmal liefe.
- **Neuer Befund dieser Runde:** Eintrag 1 der Queue ("Freitag, 11.09.2026, 19:20 Uhr") ist **heute fällig**, Status weiterhin `bereit (wartet auf Freigabe)`, und referenziert einen lokalen Pfad (`Lim/Content/Videos/…`), den der `content-executor` als Cloud-Routine laut der Datei selbst nicht erreichen kann. Selbst wenn Mike ihn jetzt auf `freigegeben` setzt, kann der Executor ihn so nicht posten – die Datei sagt selbst, dass der `content-manager` das "bei der nächsten Planungsrunde" beheben sollte, das war aber bisher nirgends als expliziter Arbeitsschritt im `content-manager`-Prompt verankert (siehe Korrektur unten).
- Ursache weiterhin wie im Eröffnungsbericht: die Scheduled Routines wurden am 10.09. abends angelegt, aber ohne Connector-Rechte (Jarvis, Windsor.ai, Canva) – das lässt sich laut Daily Note nur über die claude.ai-Oberfläche selbst nachtragen, nicht aus dieser Session heraus. Dieser offene Punkt aus dem 10.09. ist unverändert offen.

**`professor` (ich selbst) – erster Lauf, siehe Abschnitt 3.**

**Doppelarbeit/durchfallende Zuständigkeit zwischen zwei Agenten:** keine gefunden. Die Abgrenzungen (Manager plant/Executor führt aus, Aufgaben- vs. Content-Ebene, Freigabe-Phase nur Mike) sind in allen vier Prompts sauber und konsistent formuliert, das ist in Ordnung.

### 3. Baustellen-Check gegen die MasterPlan-Regel (max. 1–2 aktive Baustellen)

Aktiv "Aufmerksamkeit brauchend" gerade:
1. `aufgaben-manager`/`aufgaben-executor` – Verdacht auf nicht laufende Scheduled Routine, muss von Mike in der claude.ai-Oberfläche geprüft werden
2. `content-manager`/`content-executor` – bestätigt nicht live, Connector-Rechte fehlen, plus ein fälliger Post mit totem Asset-Pfad für heute Abend
3. `professor` – ich selbst, erster Lauf gerade erst abgeschlossen, Nutzen noch nicht über mehrere Runden bewiesen

**Das sind drei Baustellen, nicht eine bis zwei.** Das ist genau der Zustand, vor dem MasterPlan Abschnitt 8 warnt, und schlechter als im Eröffnungsbericht angenommen: damals galt die aufgaben-Ebene als solide laufend, jetzt zeigt sich, dass dafür im Vault schlicht der Beleg fehlt.

**Ehrliche Selbsteinschätzung:** Der wichtigste Beitrag dieser Runde war, den (falschen oder zumindest unbelegten) Eindruck "aufgaben-manager/-executor läuft" zu korrigieren, und drei konkrete, additive Prompt-Korrekturen zu machen, die künftig verlässlich sichtbar machen, ob ein Agent überhaupt läuft. Das ist echter Nutzen, kein Selbstzweck. Trotzdem: Ich bin gerade eine von drei parallelen Baustellen, nicht die Kontrollinstanz über zwei stabil laufende Systeme, wie es die Rollenbeschreibung eigentlich vorsieht ("Kontrollebene darüber, ob das System wie gedacht läuft"). Solange kein einziges der beiden operativen Agenten-Paare nachweislich zuverlässig läuft, hat ein wiederkehrender `professor`-Lauf wenig zu kontrollieren außer "läuft's schon" – das ist Overhead, kein Mehrwert, wenn es öfter als etwa wöchentlich passiert. **Konkrete Empfehlung an Mike:** `professor` bis auf Weiteres nur manuell per `/professor-check` laufen lassen (falls aktuell eine eigene Scheduled Routine für ihn existiert, sie pausieren oder auf sehr selten stellen), bis mindestens der `aufgaben-manager`/`aufgaben-executor`-Zyklus einmal nachweislich (mit Log-Eintrag) durchgelaufen ist. Das ist eine Empfehlung, keine Handlung – ich habe an den Routinen selbst nichts geändert und kann das auch nicht.

> [!error] Korrektur (aufrufende Session, 11.09.2026): Punkt 1 war ein Fehlalarm, siehe Korrektur bei Abschnitt 2
> `aufgaben-manager`/`aufgaben-executor` liefen am 11.09. tatsächlich beide erfolgreich (Vorschlag geschrieben, korrekter "nichts zu tun"-Log, danach von Mike bestätigt) – der Professor hat nur einen veralteten Branch gelesen, nicht `master`. Damit ist die genannte Vorbedingung für die Empfehlung ("bis der Zyklus einmal nachweislich durchgelaufen ist") bereits erfüllt. Real bleiben zwei Baustellen: `content`-Paar (noch nicht live) und `professor` selbst (Nutzen über mehrere Runden noch nicht bewiesen) – das liegt within der "max. 1-2"-Regel, nicht darüber.

### 4. Kleine Korrekturen, direkt per Edit gemacht

Alle additiv, nichts gelöscht:

1. **`.claude/agents/aufgaben-executor.md`** – ergänzt: auch im "kein bestätigter Plan"-Fall muss der Log-Eintrag geschrieben UND committet/gepusht werden. Grund: genau diese Lücke (kein Log-Eintrag trotz vermutlich gelaufener Routine) war die Ursache, warum sich der Zustand aus Abschnitt 2 nicht eindeutig einordnen ließ.
2. **`.claude/agents/content-executor.md`** – neuer, verpflichtender Abschnitt `## Executor-Log` in `Posting-Warteschlange.md` bei jedem Lauf, auch ohne postbaren Content. Vorher war der Log-Eintrag als "optional" formuliert und es gab keinen dedizierten Abschnitt dafür (anders als `## Log` in `Tagesplan.md`). Grund: gleiche Nachvollziehbarkeits-Lücke wie bei Punkt 1, hier sogar strukturell (kein Ziel-Abschnitt vorhanden).
3. **`.claude/agents/content-manager.md`** – Phase 1 ("Kontrollieren") um einen expliziten Arbeitsschritt ergänzt: offene Queue-Einträge mit lokalem, für den Cloud-Executor unerreichbarem Asset-Pfad erkennen und ersetzen. Grund: Diese Regel stand bisher nur als Kontext-Hinweis in `Posting-Warteschlange.md` selbst, nicht als Arbeitsschritt im `content-manager`-Prompt – dadurch hätte der `content-manager` sie bei seinem ersten echten Lauf leicht übersehen können, genau wie es aktuell beim heute fälligen Post Nr. 1 der Fall ist.

### 5. Skill-/Plugin-/Connector-Suche

`SearchSkills` und `SearchPlugins` mit mehreren Stichwort-Sets durchsucht (Rechnungen/Buchhaltung/Expense-Tracking, Social-Media-Posting/Content-Kalender, Aufgabenmanagement). Ergebnis: **keine passende Lücke gefunden, die einen Vorschlag rechtfertigt.**
- Der Skill-Katalog enthält aktuell nur generische Anthropic-Skills (xlsx, pptx, pdf, docx, learn, morning, setup-writing-style, skill-creator, import-memory), alle bereits aktiviert, keiner davon spezifisch für Mikes Automatisierungslücken.
- Zwei Plugins im Katalog gefunden (`product-tracking-skills` für SaaS-Produktanalytik, `valtown` für Web-App-Hosting) – beide fachfremd, keine Empfehlung.
- Kein Connector-Vorschlag: Die eigentlichen Lücken (Telegram/WhatsApp-Bridges, Broker-Dashboards, Instagram-Posting) sind bereits mit eigens gebauten Lösungen abgedeckt (siehe Jarvis-Bausteine), fachspezifisch genug (CFD/Forex-IB-Business), dass ein Standard-Plugin dafür unwahrscheinlich ist – und die eigentlichen Probleme dort sind laut Daily Notes ohnehin Bot-Erkennung (Cloudflare/reCAPTCHA), die laut Mikes eigener Regel nicht umgangen werden soll, kein Tooling-Mangel.
- Randnotiz, kein Vorschlag: Für das im MasterPlan offene "Lot-Tracking aufsetzen" (Abschnitt 9) ist der bereits aktivierte `xlsx`-Skill grundsätzlich passend – das ist aber eine Tagesgeschäft-Aufgabe für den `aufgaben-manager`, nicht meine Zuständigkeit, deshalb nur als Hinweis erwähnt.

### 6. Neuer Agenten-Entwurf

**Keiner.** Es gibt aktuell keine belegte, wiederkehrende Zeit-Lücke, die kein bestehender Agent abdeckt – im Gegenteil, die drei bestehenden Baustellen sind noch nicht einmal nachweislich stabil. Ein vierter oder fünfter Agent wäre exakt der Fehler, vor dem MasterPlan Abschnitt 6 warnt ("Ein Hauptagent, der drei kaputte Subagenten koordiniert, ist langsamer als du allein"). Diese Runde bewusst bei kleinen Korrekturen und einer ehrlichen Bestandsaufnahme belassen, nichts Neues vorgeschlagen.

### 7. Geänderte Dateien

- `.claude/agents/aufgaben-executor.md` – Korrektur 1 (siehe Abschnitt 4)
- `.claude/agents/content-executor.md` – Korrektur 2
- `.claude/agents/content-manager.md` – Korrektur 3
- `03 Bereiche/Agenten-Qualität/Qualitätsbericht.md` – dieser Abschnitt

Nicht angefasst, bewusst: `Tagesplan.md`, `Posting-Warteschlange.md`, `Performance-Log.md`, `Aufgaben-Triage.md` – operative Dateien der anderen Agenten, nicht mein Bereich.
