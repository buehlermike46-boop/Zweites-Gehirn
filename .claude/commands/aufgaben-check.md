---
description: Vollständige Aufgaben-Kontrolle gegen den MasterPlan – lesen, kontrollieren, neu verteilen
---

Ruf den `aufgaben-manager`-Subagenten auf (Agent-Tool, subagent_type: aufgaben-manager) und lass ihn den vollständigen Zyklus durchlaufen: letzte Zuweisung kontrollieren, Aufgaben-Triage und Daily Note aktualisieren, neue Tages-/Wochenaufgaben gegen den MasterPlan vorschlagen.

Fass sein Ergebnis danach für Mike zusammen:
- was als erledigt bestätigt wurde (mit Beleg)
- was offen/unklar geblieben ist und wo du eine Antwort von ihm brauchst
- die konkrete Empfehlung für heute/diese Woche (steht jetzt als "Vorschlag" in `03 Bereiche/Aufgaben-Management/Tagesplan.md`)
- was zurückgestellt wurde, weil es zu keiner aktiven MasterPlan-Stufe passt
- was aktuell im Freigabe-Stau liegt und auf sein Ja/Nein wartet

Wenn Mike den Vorschlag bestätigt: verschieb die Punkte in `Tagesplan.md` von "Vorschlag" nach "Bestätigt für [Datum]" – erst dann darf der `aufgaben-executor` sie abarbeiten.

Frag explizit nach, bevor du etwas löschst oder komplett überschreibst, das der Agent als Unsicherheit markiert hat.
