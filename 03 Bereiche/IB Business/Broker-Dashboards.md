---
tags: [ib, broker, cockpit]
---

# Broker-Dashboards

Automatischer Snapshot aus dem offiziellen PU Prime IB-Portal und dem Limitless Affiliate-Dashboard, geschrieben von `scripts/broker_bridge.py` (Login einmalig per `scripts/broker_login.py`, danach alle 10 Minuten mit dem normalen Bridge-Lauf). Rein lesend. Bei einem Lesefehler bleibt der letzte bekannte Wert stehen und `status:` zeigt den Fehler, statt eine falsche Zahl einzutragen.

**Kopfwerte (automatisch geschrieben, nicht von Hand editieren):**

puprime_commission: 0.00
puprime_balance: 0.00
puprime_new_clients: 0
puprime_ftd_clients: 0
puprime_opened_accounts: 0
limitless_total_referred: 0
limitless_approved: 0
limitless_pending: 0
limitless_this_month: 0
letzter_abruf: 2026-09-10 17:30
status: teilweise: PU Prime nicht lesbar; GMX nicht lesbar
