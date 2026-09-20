---
description: Vollständige Kontrolle der beiden Kinder-YouTube-Kanäle (DE & EN) – letzte Produktionsrunde auswerten, neue Episoden planen
---

Ruf den `youtube-manager`-Subagenten auf (Agent-Tool, subagent_type: youtube-manager) und lass ihn den vollständigen Zyklus durchlaufen: letzte Produktionsrunde gegen das Executor-Log kontrollieren, Kanal-Setup-Status prüfen, bei Bedarf Recherche ergänzen, neue Episoden in die Video-Warteschlange schreiben.

Fass sein Ergebnis danach für Mike zusammen:
- Kanal-Setup-Status (weiterhin blockiert oder hat sich was getan — das ist der wichtigste Punkt)
- was aus der letzten Produktionsrunde ausgewertet wurde
- welche neuen Episoden jetzt in der Queue stehen und warum
- die aktuelle Freigabe-Phase und was das für die neuen Episoden bedeutet

Wenn in Phase 1 Episoden auf Freigabe warten: frag Mike, ob er sie freigibt, und trag freigegebene Einträge entsprechend in der Warteschlange ein.

Ist die Queue danach nicht leer: ruf direkt im selben Lauf den `youtube-executor` auf (Agent-Tool), damit fällige Episoden produziert werden, statt auf die nächste geplante Routine zu warten.
