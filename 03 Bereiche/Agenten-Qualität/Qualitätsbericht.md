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

## Bericht vom 12.09.2026

**Kontext dieser Runde, anders als sonst:** Kein regulärer `/professor-check`, sondern ein von Mike im Chat bestätigter Sonderauftrag: langfristige Content-Automatisierung über mehrere Plattformen (Instagram+Facebook zusammenlegen, Telegram jetzt, später LinkedIn und YouTube). Die aufrufende Session hatte den aktuellen Windsor.ai-Connector-Stand bereits selbst recherchiert (ich habe kein Windsor.ai-Write-Tool) und mir direkt mitgegeben – das übernehme ich unten ungeprüft als Faktenbasis, weil es aus einer echten `get_connectors`/`list_actions`-Abfrage stammt, nicht aus meiner eigenen Vermutung. Mein eigener Beitrag: Skill-/Plugin-Recherche für die Lücken, Einordnung gegen den MasterPlan, phasierter Vorschlag. **Technische Einschränkung dieser Runde:** `SearchMcpRegistry`, `SuggestConnectors`, `SuggestSkills` und `SuggestPluginInstall` waren in diesem Lauf alle deaktiviert (Tool-Fehler "disabled for this session"), obwohl sie laut meiner eigenen `tools:`-Zeile vorhanden sein sollten. Ich konnte deshalb nur `SearchSkills`/`SearchPlugins` nutzen und keine bestätigbare Karte für Mike erzeugen – das unten gefundene Ergebnis ist deshalb nur als Text vermerkt, nicht als Suggest-Karte ausgespielt. Das sollte in einem künftigen Lauf (oder direkt in der Hauptsession) nachgeholt werden, sobald die Tools wieder verfügbar sind.

### 1. Kurz-Update Bestandsaufnahme/Qualität seit dem 11.09.2026

Kein vollständiger Neu-Durchlauf aller fünf Phasen diese Runde (der Auftrag war bewusst eng gefasst, siehe oben), aber beim Lesen von `Tagesplan.md` und `Posting-Warteschlange.md` als Nebenbefund mitgenommen:

- **`aufgaben-manager`/`aufgaben-executor`:** sehr aktiv seit dem letzten Bericht, mit Beleg – mehrere Vorschlag/Bestätigt/Log-Zyklen am 12.09., inklusive der Chat-Entscheidungen "volle Ausführungs-Autonomie", "Werkzeug-Selbstbeschaffung" und "Leerlauf-Verkettung". Kein neuer Fehlbefund. Auffällig: an einem einzigen Tag (12.09.) sind dem Executor drei grundlegend neue Befugnisse gegeben worden (voll autonom nach außen wirken, sich selbst Tools eintragen, den Manager selbst nachziehen lassen) – das ist für sich genommen schon viel Veränderung auf einmal, nicht falsch, aber ein Punkt, den ich im nächsten regulären `/professor-check` explizit nachhalten sollte (lief das seitdem sauber, oder wurden Grenzen überdehnt).
- **`content-manager`/`content-executor`:** läuft, mit Beleg – erster echter Post live (Media-ID 17901731430581191, 11.09.), sieben weitere Queue-Einträge für die kommende Woche freigegeben, Executor-Log wird gepflegt. Kein Routing-Fehler gefunden: die Telegram-Kanal-Punkte in `Tagesplan.md` sind explizit als "nicht Instagram/content-manager-Gebiet" markiert (Log-Eintrag 12.09., Domain-Check durchgeführt) – korrekt, weil der `content-executor` gar keinen Telegram-Connector hat. Keine Verschiebung nötig diese Runde.
- **Kleine Korrekturen an Agenten-Dateien:** keine. Der Auftrag dieser Runde war ausdrücklich Recherche + Bericht, keine Tool-Listen von `content-manager`/`content-executor` ändern – daran halte ich mich, auch wenn unten ein technischer Bezug zu ihrer künftigen Tool-Liste steht.
- **Offen, unverändert seit dem 11.09.:** Punkt 5 aus `Tagesplan.md` `## Technisch blockiert` (Google-Drive-Ordner) bleibt ungelöst – auch in dieser Session standen nur die vier MCP-Server github/Gmail/Jarvis/Windsor-ai zur Verfügung, kein Google-Drive-Server, also weiterhin kein verifizierbarer Tool-Name. Nicht geraten, wie beim letzten Mal auch.

### 2. Mikes Auftrag: Content-Automatisierung über mehrere Plattformen

**Mikes Vision, wörtlich:** "Ich brauche für immer mehr Anbieter nachher eine Automatisierung was das Thema angeht, Instagram und Facebook können wir zusammenlegen, Telegram brauch ich jetzt auch schon, später soll noch LinkedIn und auch YouTube dazu kommen."

**Technischer Ist-Stand (Windsor.ai, von der aufrufenden Session heute per `get_connectors`/`list_actions` geprüft):**

| Plattform | Windsor.ai-Status | Organisches Posten möglich? |
|---|---|---|
| Instagram | verbunden (`mike_bueh`) | **Ja** – einzige Plattform mit echtem Write-Support (Bild-Post, Kommentar) |
| Facebook | verbunden, aber als **Meta-Ads-Connector** (Account "Mike Bühler") | Nein – nur Kampagnen/Ad-Sets/Budget, "Post boosten" (=bezahlt). `facebook_organic` existiert als eigener Connector-Typ, ist nicht verbunden, und hätte laut Windsor-Doku selbst nach Verbindung keine Write-Actions (nur Analytics) |
| LinkedIn | `linkedin` (Ads) und `linkedin_organic` existieren, beide nicht verbunden | Nein – `linkedin` (Ads) hat nur Kampagnen-Write-Actions, `linkedin_organic` laut Doku ohnehin ohne Write-Actions |
| YouTube | Connector existiert, nicht verbunden | Nein – laut Doku kein Write-Connector, nur potenziell lesend |
| Telegram | **existiert überhaupt nicht** in Windsor.ais Connector-Liste | Nein, kein Weg über Windsor.ai |

**Kurzfassung:** Windsor.ai kann heute ausschließlich Instagram organisch bespielen. Für alles, was Mike zusätzlich will (Facebook organisch, Telegram, später LinkedIn/YouTube), ist Windsor.ai der falsche Baustein – das ist keine Konfigurationsfrage, sondern eine echte Werkzeug-Lücke.

**Recherche-Ergebnis (`SearchPlugins`, da `SearchMcpRegistry` in diesem Lauf deaktiviert war):**

Gefunden: **Postiz** (Plugin-ID `plugin_019XQ3kYMHjpnY1RcxCZttGb`, im Katalog als "Social media automation CLI for scheduling posts, managing integrations, uploading media, and tracking analytics across 28+ platforms including X, LinkedIn, Reddit, YouTube, TikTok, Instagram, and more" gelistet, noch nicht aktiviert). Per Web-Recherche zur Einordnung nachgeprüft (Quelle: [github.com/gitroomhq/postiz-app](https://github.com/gitroomhq/postiz-app), das zugrundeliegende Open-Source-Projekt): Postiz deckt laut eigener Doku über 30 Netzwerke ab, **explizit inklusive Telegram, Facebook, LinkedIn (persönlich und Seiten) und YouTube**, zusätzlich zu Instagram. Das trifft Mikes komplette Wunschliste in einem einzigen Werkzeug, statt vier separate Connectoren zu suchen.

**Wichtige Einschränkungen, ehrlich benannt, nicht schöngeredet:**
- Ich konnte **keine** `SuggestPluginInstall`-Karte erzeugen (Tool deaktiviert in dieser Session, siehe oben) – Mike muss das Plugin selbst im Katalog finden/bestätigen, oder ein späterer Lauf mit funktionierenden Suggest-Tools holt das nach.
- Postiz ist kein reiner Ein-Klick-Connector wie Windsor.ai, sondern ein eigenständiges Scheduling-Tool (selbst gehostet oder über einen eigenen Cloud-Account), das für jede Plattform einzeln verbunden werden muss (Telegram-Bot-Token, Facebook-Seiten-OAuth, LinkedIn-OAuth, YouTube-OAuth). Das ist mehr Einrichtungsaufwand als ein bestehender Connector zu aktivieren, aber immer noch deutlich weniger, als für jede Plattform eine eigene Lösung zu bauen.
- Ob Postiz auch die Telegram-Spezialfunktion "Kanalbild setzen" (`setChatPhoto`) abdeckt, die aktuell unter `## Technisch blockiert` in `Tagesplan.md` steht, ist aus der Plugin-Beschreibung nicht ersichtlich (das Tool ist in erster Linie ein Scheduler für Beiträge/Nachrichten, keine volle Kanal-Verwaltung). Das müsste bei Interesse konkret geprüft werden – für das eigentliche Bedürfnis "Nachrichten/Content zeitversetzt posten" passt es aber.
- Ich habe **nichts installiert, aktiviert oder verbunden** – das bleibt technisch unmöglich für mich und ist ohnehin Mikes Entscheidung.

**Zusatzfrage von Mike beantwortet – gilt für LinkedIn dieselbe Werbe-Sperre wie bei Meta?** Nein, nicht identisch. Meta verbietet CFD/Forex-Werbung komplett (siehe `Marketing & Kundenakquise.md`). LinkedIn stuft Finanzprodukte laut eigener Ads Policy als "restricted", nicht als komplett verboten ein: erlaubt, aber mit Pflicht-Disclaimern, ohne Gewinnversprechen, teils mit Lizenz-/Regionalauflagen ([linkedin.com/legal/ads-policy](https://www.linkedin.com/legal/ads-policy)). Für den aktuellen Plan ändert das nichts (Mike macht ohnehin keine bezahlte Werbung, siehe MasterPlan Stufe 3: Werbung erst ab 15.000 EUR-Stufe) – relevant nur als Randnotiz für später.

### 3. Phasierter Vorschlag (Empfehlung, keine Umsetzung)

**Phase A, jetzt, keine neue Baustelle:** Instagram bleibt exakt wie es ist – über Windsor.ai/`content-executor`. Daran ändert dieser Vorschlag nichts.

**Phase B, sobald eine echte Verbindung steht (nicht vorher):** Content-Planung für Facebook/LinkedIn/YouTube schon vorbereiten (Themen/Formate in einer neuen Sektion denken), aber **nicht jetzt schon anfangen** – siehe Baustellen-Einschätzung unten. Sobald ein Connector/Skill wirklich verbunden ist, kann `content-manager` sofort in seine bestehende Struktur erweitert werden (neue Spalte/Abschnitt in `Posting-Warteschlange.md` je Plattform), das ist kein Architektur-Umbau, nur mehr Zeilen.

**Phase C, braucht zuerst einen technischen Baustein:** Telegram-Content-Posting (Postiz oder gleichwertig), Facebook organisch (selbes Tool), später LinkedIn, zuletzt YouTube (Video-Format am aufwendigsten, andere Seitenverhältnisse als die bestehenden 9:16-Reels).

**Explizite Prüfung gegen MasterPlan Abschnitt 8 ("max. 1-2 aktive Baustellen"), ehrlich, nicht wohlwollend:**

Aktueller Baustellen-Stand heute (siehe Abschnitt 1): `aufgaben-Paar` (gerade erst mit drei neuen, weitreichenden Befugnissen ausgestattet, noch keine Woche bewährt unter den neuen Regeln), `content-Paar` (Instagram-only, ein einziger echter Post alt, ebenfalls unter einer Woche produktiv), `professor` (ich selbst). Das sind bereits zwei bis drei laufende Baustellen, je nachdem wie man zählt – **eine vierte Baustelle "Multi-Plattform-Content-Ausbau" jetzt zusätzlich aktiv zu starten, würde die Regel klar reißen.**

**Meine ehrliche Einschätzung, auch wenn sie Mikes "brauch ich jetzt auch schon" bei Telegram widerspricht:** Jetzt ist nicht der richtige Zeitpunkt, alle vier neuen Plattformen gleichzeitig anzugehen – das wäre exakt der Fehler aus MasterPlan Abschnitt 6 ("ein Hauptagent, der drei kaputte Subagenten koordiniert, ist langsamer als du allein"), nur auf Connector-Ebene übertragen. Wenn Mike Telegram trotzdem vorziehen will, wäre mein Vorschlag: **es ersetzt etwas, statt obendrauf zu kommen** – z. B. erst die noch offenen Stufe-0-Punkte aus `Tagesplan.md` (Kanalbild, Make.com-Aktivierung, Posts terminieren) wirklich abschließen, dann Postiz/Telegram als die **eine** nächste aktive Baustelle nach dem `content-Paar` behandeln, nicht parallel zu allem anderen. Facebook/LinkedIn/YouTube bleiben in diesem Fall bewusst Notiz im Vault (wie MasterPlan Abschnitt 8 es vorsieht), nicht Aufgabe der nächsten Wochen – auch wenn die Vision alle vier nennt, die Reihenfolge entscheidet.

**Kein neuer Agenten-Entwurf:** Diese Erweiterung braucht keinen zusätzlichen Agenten, sondern (a) einen neuen Connector/ein neues Tool und (b) eine Erweiterung von `content-manager`/`content-executor` um weitere Plattform-Abschnitte – das ist eine spätere, überschaubare Prompt-Ergänzung an den bestehenden zwei Dateien, kein fünftes/sechstes Agentenpaar. Deshalb kein Entwurf angelegt.

### 4. Geänderte Dateien dieser Runde

- `03 Bereiche/Agenten-Qualität/Qualitätsbericht.md` – dieser Abschnitt

Nicht angefasst, bewusst: `.claude/agents/content-manager.md`, `.claude/agents/content-executor.md` (Auftrag war Recherche + Vorschlag, keine Tool-/Scope-Änderung), `Tagesplan.md`, `Posting-Warteschlange.md` (kein Fehlrouting gefunden, siehe Abschnitt 1).

## Bericht vom 20.09.2026 (Vorfall: Rechtschreibfehler in einem Instagram-Video, System überarbeitet – von Mike direkt im Chat ausgelöst, keine reguläre `professor`-Runde)

**Auslöser:** Mike hat sich ein bereits gepostetes Instagram-Video nochmal angeschaut und Rechtschreibfehler darin gefunden. Seine Frage: warum hat das System das nicht selbst entdeckt, und er will die gesamte Agenten-Struktur überdacht und überarbeitet haben, inklusive der Möglichkeit, aus jedem neuen Chat heraus automatisch weiterzuarbeiten (Beispiel YouTube-Projekt: Recherche, Planung, Produktion bis Upload, alles ohne dass er jeden Schritt einzeln anstoßen muss).

### 1. Root-Cause-Analyse

Beim Durchsehen von `Posting-Warteschlange.md` fand sich der eigentliche Beweis bereits im eigenen Executor-Log: **Eintrag vom 17.09.2026** dokumentiert einen Tippfehler auf Slide 5 eines geposteten Carousels ("STARTMhr" statt "START"/"Mehr dazu" im Bild-Prompt) – und schließt mit "das ist die Ursache, keine Handlungsnotwendigkeit von hier aus, aber zur Kenntnis". Der Fehler wurde also intern erkannt und **bewusst nicht korrigiert**, weder das konkrete Asset noch der Prozess dahinter.

**Strukturelle Ursache, nicht nur ein einzelnes Versehen:**
1. `content-executor.md` hatte (bis heute) keinen einzigen Schritt, der den tatsächlich von Jarvis erzeugten Bild-/Video-Text vor dem Posten gegenliest. Der Ablauf war: Asset generieren → direkt posten. Ob der Prompt so gerendert wurde wie gemeint, wurde nie geprüft.
2. Gleiches Muster, gleiches Risiko bei `youtube-executor.md` (eingebrannte Untertitel/Songtext, sogar in zwei Sprachfassungen gleichzeitig) – nur noch nicht in einem Vorfall sichtbar geworden, weil der Kanal-Upload technisch noch blockiert ist.
3. `professor.md` prüft bisher ausschließlich Prozess-Fragen (läuft ein Agent, gibt es Fehlrouting, fehlt ein Tool) – nie die inhaltliche Qualität des tatsächlich erzeugten Outputs. Ein erkannter, aber nicht behobener Content-Fehler wie der vom 17.09. wäre auch einer regulären Qualitätsrunde nicht aufgefallen, weil dafür schlicht kein Prüfschritt vorgesehen war.

**Damit ist die Antwort auf Mikes Frage eindeutig:** Das System hat den Fehler nicht "nicht entdeckt" – es hat ihn einmal entdeckt und dann bewusst folgenlos gelassen, weil kein verbindlicher Schritt existierte, der aus dieser Entdeckung eine Konsequenz macht.

**Update, geklärt per Rückfrage an Mike:** Es war ein weiterer, bisher nicht geloggter Fall, nicht der 17.09.-Carousel-Fehler. Betroffen war **Post Nr. 6 (Market-Scanner-Reel, Media-ID 18011708741973337)**, heute (20.09.2026) ca. 16:45 UTC automatisch gepostet, von Mike ca. 1h später selbst über die Instagram-App gelöscht, nachdem er den Rechtschreibfehler im Video-Text entdeckt hatte. Damit bestätigt sich der Befund oben nicht nur einmalig (17.09.) sondern ein zweites Mal in derselben Woche – der Text-Rendering-Fehler war also kein Einzelfall, sondern ein wiederkehrendes Muster ohne Gegenmaßnahme, genau das strukturelle Problem, das der Fix unten behebt. Details/Log-Eintrag in [[Posting-Warteschlange]], Queue-Eintrag #6 und Executor-Log-Abschnitt vom 20.09.2026 (20:40 Uhr). Kein automatischer Ersatz-Post erstellt, das ist bewusst Mikes Entscheidung, falls er das Thema nochmal bringen will.

### 2. Fix: Pflicht-Text-Check vor jedem Posten/Fertig-Markieren

- **`content-executor.md`:** neuer Abschnitt "Text-Check vor jedem Posten" – vor jedem Instagram-/Telegram-Post mit sichtbarem Text muss `show_generation_by_ids` das tatsächliche Ergebnis zeigen, jedes Wort wird gegen den Soll-Text geprüft, bei Abweichung wird neu erzeugt (max. 3 Versuche gesamt), nach 3 gescheiterten Versuchen wird NICHT gepostet. Ergebnis muss im Executor-Log stehen.
- **`youtube-executor.md`:** gleiches Prinzip für eingebrannte Untertitel/Songtext, für DE und EN einzeln geprüft, vor jedem `fertig`/Upload.
- **`professor.md`:** neuer Prüfpunkt "Content-Qualitäts-Check" – kontrolliert künftig, ob der Text-Check in den Executor-Logs tatsächlich dokumentiert ist, und behandelt einen erkannten-aber-nicht-behobenen Content-Fehler als Befund, der eine Prompt-Korrektur auslösen muss, nicht nur eine erneute Erwähnung.
- **`CLAUDE.md`:** kurze Verweise auf den neuen Text-Check in den Content- und YouTube-Agent-Abschnitten ergänzt.

### 3. Generalisierung: automatischer Anschub für alle Agentenpaare & neue Projekte

Zweiter Teil von Mikes Auftrag: das System soll aus jedem Chat heraus möglichst selbstständig weiterlaufen, nicht nur bei Aufgaben. Umgesetzt in `CLAUDE.md`, neuer Abschnitt "Automatischer Anschub für alle Agentenpaare & neue Projekte":

1. Die bisher nur bei `aufgaben-manager`/`aufgaben-executor` bestehende Leerlauf-Verkettung (Executor läuft leer → Manager legt sofort neu vor → Executor macht sofort weiter) gilt jetzt auch für Content und YouTube. Beide Executoren loggen jetzt ein `LEERLAUF:`-Signal, wenn ihre Warteschlange zur Neige geht (siehe Änderungen an `content-executor.md`/`youtube-executor.md` oben), jede aufrufende Session reagiert darauf im selben Lauf.
2. Neu: startet Mike in einem neuen Chat ein neues Projekt, prüft die Session direkt den Baustellen-Stand gegen MasterPlan Punkt 8, entscheidet dann ob eine dauerhafte Pipeline (neues Agentenpaar nach bestehendem Muster) oder ein Einzelprojekt (direktes, selbstständiges Weiterarbeiten ohne neues Agentenpaar) angemessen ist, und treibt es im selben Lauf voran, bis entweder fertig oder ein echter Blocker erreicht ist – genau wie es aktuell beim YouTube-Projekt gehandhabt wird.

**Bewusst nicht aufgehoben:** die bestehenden Freigabe-Grenzen (bezahlte Werbung, Credit-Käufe, endgültiges Löschen etc.) und der MasterPlan-Baustellen-Check selbst – der neue Automatismus macht Baustellen schneller sichtbar, überspringt die Prüfung aber nicht. Zukünftige `professor`-Runden sollten explizit mitprüfen, ob dieser neue Automatismus dazu führt, dass zu viele Pipelines gleichzeitig entstehen (Risiko: die 1-2-Baustellen-Regel wird durch die niedrigere Hürde zum Anlegen neuer Agentenpaare leichter gerissen als vorher).

### 4. Geänderte Dateien dieser Runde

- `.claude/agents/content-executor.md` – Text-Check-Pflicht (Instagram + Telegram), Leerlauf-Signal
- `.claude/agents/youtube-executor.md` – Text-Check-Pflicht (DE+EN), Leerlauf-Signal, Schritte neu nummeriert
- `.claude/agents/professor.md` – neuer Prüfpunkt "Content-Qualitäts-Check"
- `CLAUDE.md` – Session-Start erweitert, neue Sektion "Automatischer Anschub für alle Agentenpaare & neue Projekte", kurze Verweise bei Content-/YouTube-Agent
- `03 Bereiche/Agenten-Qualität/Qualitätsbericht.md` – dieser Abschnitt

Nicht angefasst, bewusst: `Posting-Warteschlange.md` (der 17.09.-Post bleibt live, Entscheidung über Repost/Löschen liegt bei Mike, siehe Abschnitt 1), `aufgaben-manager.md`/`aufgaben-executor.md` (deren Leerlauf-Verkettung war bereits korrekt, keine Änderung nötig), `content-manager.md`/`youtube-manager.md` (Planungsseite unverändert, der Fix betrifft die Ausführungsseite).
