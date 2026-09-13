/**
 * Limitless Start Bot — Cloudflare Worker
 * Vorlage, aufgebaut von Rob (@robdefi), zur Übernahme durch Partner.
 *
 * Secrets (im Cloudflare-Dashboard unter Settings > Variables als "Encrypt" anlegen):
 *   BOT_TOKEN       Token von BotFather
 *   ROB_CHAT_ID     Deine numerische Telegram-ID (Meldungen gehen dorthin)
 *   HOOK_SECRET     frei gewaehltes Passwort, sichert den Webhook ab
 *   ADMIN_TOKEN     frei gewaehltes Passwort fuer /setup, /sethook und /export
 *
 * Binding:
 *   DB              D1-Datenbank
 */

/* ============================================================================
   NUR DIESEN BLOCK ANPASSEN. Alles darunter bleibt unverändert.
   ============================================================================ */

// Dein Vorname. Erscheint auf den Buttons und in den vorbereiteten Nachrichten.
const NAME = 'Mike';

// Dein Telegram-Username, ohne @.
const TG_USERNAME = 'mikebueh';

// Username deines Bots von BotFather, ohne @.
const BOT_USERNAME = 'LimitlessPuBot';

// Dein persönlicher Broker-Link von PU Prime, komplett mit deiner affid.
const LINK_BROKER = 'https://puvip.co/la-partners/de/Y4GY2sPn';

// Dein Limitless-Referral-Code.
const REF_CODE = '2A5CC2B8';

// Deine IB-Nummer bei PU Prime. Steht in der Switch-Mail für Bestandskunden.
const IB_NUMBER = '33772237';

/* ============================================================================
   Ab hier nichts mehr ändern.
   ============================================================================ */

const LINK_APPLY = 'https://www.worldoflimitless.com/apply?ref=' + REF_CODE;
const LINK_ROB = 'https://t.me/' + TG_USERNAME;
// Gemeinsame WhatsApp-Community. Bleibt für alle Partner gleich.
const LINK_WA = 'https://chat.whatsapp.com/EoffxgOS2nkKqXWYVcJXDV';
const robWithText = (t) => LINK_ROB + '?text=' + encodeURIComponent(t);

/* --------------------------------------------------- Kanal-Post mit Start-Button */

const CHANNEL_POST = `🚀 <b>Dein Start bei Limitless</b>

Ich habe den Einstieg komplett automatisiert. Ein Klick, und du bekommst Schritt für Schritt erklärt, wie du anfängst.

🔹 Was Limitless, PU Prime und PrimeVerse jeweils für dich machen
🔹 Wie du dein Konto eröffnest und deinen 100% Einzahlungs-Bonus sicherst
🔹 Wie du deinen vollen Plattformzugang bekommst

Kostet dich nichts und dauert keine zehn Minuten.

Bei Fragen erreichst du mich jederzeit direkt.`;

const CHANNEL_BUTTON = '🚀 JETZT STARTEN';
const MAIL_TO = 'andrew.santiago@puprime.com';
const MAIL_SUBJECT = 'Account Transfer';
const MAIL_BODY = (uid) => `I would like to transfer all my accounts to ${IB_NUMBER}.

My Details:
• Name: [Your Full Name]
• Email: [Your Email Address - must match the one used in the request]
• Account Number: ${uid || '[UID Number]'}`;

/* ------------------------------------------------------------------ Texte */

const T = {
  de: {
    welcome: (n) => `🚀 <b>Willkommen bei Limitless</b>

Schön, dass du da bist${n ? ', ' + n : ''}.

Bevor du loslegst, kurz zur Einordnung. Viele fragen sich am Anfang, warum es mehrere Plattformen gibt. Jede hat eine ganz eigene Aufgabe.

🏦 <b>PU Prime</b> ist dein Broker.
Dort eröffnest du dein Handelskonto, zahlst dein Kapital ein und handelst. Das Konto läuft komplett auf deinen Namen. Nur du hast Zugriff auf dein Geld, und nur du entscheidest über Ein- und Auszahlungen.

🌍 <b>Limitless</b> ist deine Ausbildung und die Community.
Trading Academy vom Anfänger bis Fortgeschritten, regelmäßige Live Sessions, Signalgruppen, Support und weitere Features.

⚙️ <b>PrimeVerse</b> ist das Add-on.
Weitere Tools, Live Trading Sessions, Trading Journal und die Automation, falls du die Signale nicht selbst umsetzen möchtest. Dazu eine eigene Reiseplattform und vieles mehr.

Limitless selbst kostet dich nichts. Dein Broker sponsert deinen Zugang.`,

    needs: `💰 <b>Was du zum Start brauchst</b>

🔹 Limitless ist kostenlos. Keine Gebühr, kein Abo.
🔹 Dein Kapital zahlst du auf dein eigenes Broker-Konto ein. Es geht nicht an Limitless.
🔹 Ab 300 $ kannst du starten. Ab 1.000 $ bekommst du den VIP-Zugang mit den zusätzlichen Signalgruppen und dem Smart Money Concept Kurs.
🔹 Deine erste Einzahlung wird verdoppelt. Aus 300 $ werden 600 $ Handelskapital, aus 1.000 $ werden 2.000 $. Das gilt einmalig auf die erste Einzahlung.

Kleiner Tipp von mir: mit 300 $ geht es, aber das Risikomanagement wird eng. Wer es sauber aufziehen möchte, startet eher bei 500 $ oder 1.000 $.

Erfahrung brauchst du keine. Die meisten hier haben vorher nie gehandelt.`,

    region: `🌍 <b>Eine Frage vorab</b>

Davon hängt ab, welchen Weg du gehst.

In welchem Land wohnst du?`,

    us: `🇺🇸 <b>Bei dir läuft es etwas anders</b>

In den USA und Australien geht die Kontoeröffnung nicht über PU Prime, sondern über Crucial Markets.

Das klären wir beide kurz persönlich um weiter fortzufahren.`,

    ask_existing: `🏦 <b>Noch eine kurze Frage</b>

Hast du schon ein Konto bei PU Prime?`,

    ask_uid: `🏦 <b>Kein Problem, das lässt sich lösen</b>

Dein bestehendes Konto kann nachträglich meiner Struktur zugeordnet werden. Danach hast du Zugang zu allem. Die Bearbeitung dauert in der Regel 24 Stunden.

Dafür brauche ich zuerst deine <b>UID</b>, das ist deine Kontonummer bei PU Prime.

📍 <b>Wo du sie findest</b>
Log dich auf puprime.com ein. Oben links steht dein Name, direkt darunter <b>UID</b> mit einer Zahl dahinter. Genau die brauche ich.

Schick mir die Nummer einfach hier als Nachricht.`,

    uid_invalid: `Das sieht noch nicht nach einer UID aus. Die besteht nur aus Ziffern.

Schau nochmal auf puprime.com oben links unter deinem Namen und schick mir nur die Zahl.`,

    uid_ok: (uid) => `✅ <b>Danke, deine UID ist ${uid}</b>

Jetzt fehlt nur noch eine kurze E-Mail an den Broker, damit dein Konto umgetragen wird.

⚠️ <b>Verschick die Mail von genau der Adresse, mit der du bei PU Prime angemeldet bist.</b> Von einer anderen Adresse wird der Antrag nicht bearbeitet.

Hinter dem Button findest du Empfänger, Betreff und den fertigen Text. Deine UID ist schon eingesetzt.`,

    dm_switch: (uid) => `Hi ${NAME}, ich habe gerade die E-Mail für die Kontoübertragung rausgeschickt.${uid ? ' Meine UID ist ' + uid + '.' : ''}`,
    dm_us: `Hi ${NAME}, ich komme aus den USA oder Australien und würde gern bei Limitless starten.`,
    dm_done: `Hi ${NAME}, ich bin durch. Konto ist eröffnet, eingezahlt und die Limitless-Bewerbung ist raus.`,
    dm_help: {
      default: `Hi ${NAME}, ich habe eine Frage zu Limitless.`,
      step1: `Hi ${NAME}, ich komme bei der Kontoeröffnung nicht weiter.`,
      step2: `Hi ${NAME}, ich komme bei der Einzahlung nicht weiter.`,
      step3: `Hi ${NAME}, ich komme bei der Limitless-Bewerbung nicht weiter.`,
    },

    mail_sent: `✅ <b>Stark, das war es schon</b>

Schreib mir jetzt bitte einmal kurz persönlich.

Das ist kein Formalismus. Ich sehe in meinem Dashboard, wann dein Wechsel durch ist, und gebe dir dann Bescheid. Ohne deine Nachricht weiß ich nicht, dass du wartest.`,

    step1: `1️⃣ <b>Schritt 1 von 3: Konto eröffnen</b>

Mit dem Button unten eröffnest du dein Konto direkt bei PU Prime. Dauert ein paar Minuten.

Zwei Dinge, die du dir jetzt schon merken solltest:

📧 Nutze überall dieselbe E-Mail-Adresse. Beim Broker und gleich bei Limitless. Wenn die auseinandergehen, lässt sich dein Zugang nicht zuordnen.

🔗 Nutze bitte nur den Button hier. Über einen anderen Weg kommt dein Konto nicht bei mir an und ich kann dich später nicht betreuen.

⚠️ Warte mit dem Einzahlen, bis du wieder hier bist. Beim 100% Einzahlungs-Bonus gibt es eine Kleinigkeit zu beachten, und sie gilt nur beim ersten Mal. Wer sie übersieht, verschenkt den Bonus. Dauert zwei Sätze, dann weißt du Bescheid.`,

    step2: `2️⃣ <b>Schritt 2 von 3: Verifizieren und einzahlen</b>

Stark, das war der wichtigste Klick.

🪪 <b>Zuerst die Identität bestätigen.</b> Einmal auf „ID Verification" gehen:
Ausweis hochladen, dauert meistens ein paar Minuten.

🎁 <b>Dann den Bonus aktivieren.</b> Unten rechts auf <b>Promotions</b> tippen, dort den „100% Deposit Bonus" öffnen und auf <b>Opt-in Now</b> gehen. Das ist die Kleinigkeit, von der ich gesprochen habe.

💵 <b>Erst danach einzahlen</b>, mindestens 300 $.

Zahlst du 300 $ ein, hast du 600 $ auf dem Konto.
Zahlst du 500 $ ein, hast du 1.000 $.
Zahlst du 1.000 $ ein, hast du 2.000 $.

Der Bonus wird deinem Trading-Konto als zusätzliche Margin gutgeschrieben, also als Handelskapital. Er steht dir ausschließlich zum Traden zur Verfügung.`,

    step3: (u) => `3️⃣ <b>Schritt 3 von 3: Limitless-Zugang beantragen</b>

⚠️ Der wichtigste Schritt, und genau der, den die meisten vergessen.
Dein Broker-Konto und dein Limitless-Zugang sind zwei getrennte Systeme. Ohne diesen Schritt hast du zwar ein Handelskonto, aber keine Academy, keine Signalgruppen, keine Live Sessions und keine Automation.

Ins Formular kommt:

📧 Dieselbe E-Mail wie beim Broker
${u
  ? '📱 Dein Telegram-Username: <b>@' + u + '</b>'
  : '📱 Dein Telegram-Username. Du hast noch keinen hinterlegt. Leg ihn kurz in den Telegram-Einstellungen an, ohne ihn kommst du nicht in die Signalgruppen.'}
🔑 Der Referral-Code: <b>${REF_CODE}</b>
✅ Die Bestätigung, dass dein Konto eröffnet und eingezahlt ist

Deine Bewerbung wird innerhalb von 24 Stunden geprüft und freigegeben. Wenn du nicht warten willst, schreib mir kurz persönlich, dann schalte ich dich direkt frei.`,

    done: `🎉 <b>Das war es, du bist durch</b>

Deine Bewerbung liegt jetzt zur Freigabe. Das dauert in der Regel keine 24 Stunden.

Was danach kommt:

📲 Nach der Freigabe hast du vollen Zugang zu World of Limitless. Kostenlos, und das für immer.

👉 Sobald du auf <a href="https://www.worldoflimitless.com/">www.worldoflimitless.com</a> eingeloggt bist, geht es für dich unter <b>How to Start</b> weiter. Dort wird Schritt für Schritt erklärt, wie du vorgehst und wie es ans Geldverdienen geht.

💬 Dazu haben wir eine WhatsApp-Community mit exklusivem Austausch unter den Mitgliedern. Klick unten auf den Button oder schreib mir einfach kurz.

Viel Erfolg. Schön, dass du dabei bist.`,

    help: `💬 <b>Kein Problem</b>

Schreib mir einfach direkt, dann klären wir das kurz zusammen.`,

    fallback: `Schreib mir gern direkt, ich lese hier mit. Am schnellsten geht es über die Buttons oben.`,

    b_go: '🚀 Zeig mir, wie ich starte',
    b_needs: '💰 Was brauche ich zum Start?',
    b_help: `💬 Frage an ${NAME}`,
    b_row: '🌍 Europa / Rest der Welt',
    b_us: '🇺🇸 USA oder Australien',
    b_new: '➕ Nein, ich fange neu an',
    b_has: '✅ Ja, ich habe schon eins',
    b_open: '🔗 Konto eröffnen',
    b_done_account: '✅ Mein Konto ist eröffnet',
    b_done_deposit: '✅ Ich habe eingezahlt',
    b_stuck: '💬 Ich komme nicht weiter',
    b_apply: '🔗 Zugang beantragen',
    b_done_apply: '✅ Bewerbung ist raus',
    b_rob: `💬 ${NAME} schreiben`,
    b_chat: `💬 Chat mit ${NAME} öffnen`,
    b_mail: '📧 E-Mail vorbereiten',
    b_mail_sent: '✅ Mail ist raus',
    b_wa: '🔗 WA Community beitreten',
  },

  en: {
    welcome: (n) => `🚀 <b>Welcome to Limitless</b>

Great to have you here${n ? ', ' + n : ''}.

Before you get started, a quick overview. Many people wonder at first why there are several platforms. Each one has a very specific job.

🏦 <b>PU Prime</b> is your broker.
This is where you open your trading account, deposit your capital and trade. The account runs entirely in your own name. Only you have access to your money, and only you decide about deposits and withdrawals.

🌍 <b>Limitless</b> is your education and the community.
Trading Academy from beginner to advanced, regular live sessions, signal groups, support and more features.

⚙️ <b>PrimeVerse</b> is the add-on.
More tools, live trading sessions, a trading journal and the automation, in case you would rather not place the signals yourself. Plus a travel platform of its own and plenty more.

Limitless itself is free. Your broker sponsors your access.`,

    needs: `💰 <b>What you need to begin</b>

🔹 Limitless is free. No fee, no subscription.
🔹 Your capital goes into your own broker account. It does not go to Limitless.
🔹 You can start from $300. From $1,000 you get VIP access with the additional signal groups and the Smart Money Concept course.
🔹 Your first deposit is doubled. $300 becomes $600 of trading capital, $1,000 becomes $2,000. This applies once, on your first deposit.

A small tip from me: $300 works, but risk management gets tight. If you want to do this properly, start at $500 or $1,000.

You do not need any experience. Most people here had never traded before.`,

    region: `🌍 <b>One question first</b>

Your path depends on this.

Which country do you live in?`,

    us: `🇺🇸 <b>Your setup works differently</b>

In the US and Australia the account is not opened with PU Prime but with Crucial Markets.

Let us sort this out between the two of us so you can carry on.`,

    ask_existing: `🏦 <b>One more quick question</b>

Do you already have an account with PU Prime?`,

    ask_uid: `🏦 <b>No problem, this can be sorted</b>

Your existing account can be moved to my structure afterwards. You then get access to everything. Processing usually takes 24 hours.

First I need your <b>UID</b>, which is your account number with PU Prime.

📍 <b>Where to find it</b>
Log in at puprime.com. Your name is at the top left, and directly below it you see <b>UID</b> with a number. That is the one.

Just send me the number here as a message.`,

    uid_invalid: `That does not look like a UID yet. It consists of digits only.

Have another look at puprime.com, top left below your name, and send me just the number.`,

    uid_ok: (uid) => `✅ <b>Thanks, your UID is ${uid}</b>

One short email to the broker is left, so your account gets moved over.

⚠️ <b>Send the email from exactly the address your PU Prime account is registered with.</b> From any other address the request will not be processed.

Behind the button you will find the recipient, the subject and the finished text. Your UID is already filled in.`,

    dm_switch: (uid) => `Hi ${NAME}, I have just sent the email for the account transfer.${uid ? ' My UID is ' + uid + '.' : ''}`,
    dm_us: `Hi ${NAME}, I am based in the US or Australia and would like to get started with Limitless.`,
    dm_done: `Hi ${NAME}, I am through. Account opened, funded, and the Limitless application is sent.`,
    dm_help: {
      default: `Hi ${NAME}, I have a question about Limitless.`,
      step1: `Hi ${NAME}, I am stuck opening my account.`,
      step2: `Hi ${NAME}, I am stuck on the deposit.`,
      step3: `Hi ${NAME}, I am stuck on the Limitless application.`,
    },

    mail_sent: `✅ <b>That is it already</b>

Now please send me a short personal message.

This is not a formality. I can see in my dashboard when your transfer goes through, and I will let you know. Without your message I do not know that you are waiting.`,

    step1: `1️⃣ <b>Step 1 of 3: Open your account</b>

The button below opens your account directly with PU Prime. It takes a few minutes.

Two things worth remembering right now:

📧 Use the same email address everywhere. With the broker and with Limitless in a moment. If they differ, your access cannot be matched.

🔗 Please only use the button here. Through any other route your account does not reach me and I cannot support you later on.

⚠️ Hold off on the deposit until you are back here. There is one small thing to get right with the 100% deposit bonus, and it only applies to your first deposit. Miss it and the bonus is gone. Two sentences and you will know.`,

    step2: `2️⃣ <b>Step 2 of 3: Verify and deposit</b>

Well done, that was the most important click.

🪪 <b>Verify your identity first.</b> Go to "ID Verification":
Upload your ID, it usually takes a few minutes.

🎁 <b>Then activate the bonus.</b> Tap <b>Promotions</b> at the bottom right, open the "100% Deposit Bonus" and tap <b>Opt-in Now</b>. That is the small thing I mentioned.

💵 <b>Only then deposit</b>, at least $300.

Deposit $300 and you have $600 in your account.
Deposit $500 and you have $1,000.
Deposit $1,000 and you have $2,000.

The bonus is credited to your trading account as additional margin, meaning trading capital. It is available for trading only.`,

    step3: (u) => `3️⃣ <b>Step 3 of 3: Apply for Limitless access</b>

⚠️ The most important step, and exactly the one most people forget.
Your broker account and your Limitless access are two separate systems. Without this step you have a trading account, but no Academy, no signal groups, no live sessions and no automation.

What goes into the form:

📧 The same email as with your broker
${u
  ? '📱 Your Telegram username: <b>@' + u + '</b>'
  : '📱 Your Telegram username. You do not have one yet. Set it up in your Telegram settings, without it you cannot join the signal groups.'}
🔑 The referral code: <b>${REF_CODE}</b>
✅ Confirmation that your account is open and funded

Your application is reviewed and approved within 24 hours. If you would rather not wait, just message me and I will approve you directly.`,

    done: `🎉 <b>That is it, you are through</b>

Your application is now waiting for approval. That usually takes less than 24 hours.

What comes next:

📲 Once approved you have full access to World of Limitless. Free, and that stays that way.

👉 As soon as you are logged in at <a href="https://www.worldoflimitless.com/">www.worldoflimitless.com</a>, carry on under <b>How to Start</b>. It walks you through every step and how the earning side works.

💬 We also have a WhatsApp community with exclusive exchange between members. Tap the button below or just message me.

All the best. Good to have you with us.`,

    help: `💬 <b>No problem</b>

Just message me directly and we will sort it out together.`,

    fallback: `Write to me here, I read along. The quickest way is the buttons above.`,

    b_go: '🚀 Show me how to start',
    b_needs: '💰 What do I need to begin?',
    b_help: `💬 Ask ${NAME}`,
    b_row: '🌍 Europe / Rest of the World',
    b_us: '🇺🇸 US or Australia',
    b_new: '➕ No, I am starting fresh',
    b_has: '✅ Yes, I already have one',
    b_open: '🔗 Open your account',
    b_done_account: '✅ My account is open',
    b_done_deposit: '✅ I have deposited',
    b_stuck: '💬 I am stuck',
    b_apply: '🔗 Apply now',
    b_done_apply: '✅ Application sent',
    b_rob: `💬 Message ${NAME}`,
    b_chat: `💬 Open chat with ${NAME}`,
    b_mail: '📧 Prepare the email',
    b_mail_sent: '✅ Email sent',
    b_wa: '🔗 Join the WA community',
  },
};

/* --------------------------------------------------------- Telegram-Helfer */

function esc(s) {
  return String(s == null ? '' : s)
    .replace(/&/g, '&amp;')
    .replace(/</g, '&lt;')
    .replace(/>/g, '&gt;');
}

async function tg(env, method, payload) {
  const res = await fetch(`https://api.telegram.org/bot${env.BOT_TOKEN}/${method}`, {
    method: 'POST',
    headers: { 'content-type': 'application/json' },
    body: JSON.stringify(payload),
  });
  return res.json();
}

function send(env, chatId, text, buttons) {
  return tg(env, 'sendMessage', {
    chat_id: chatId,
    text,
    parse_mode: 'HTML',
    disable_web_page_preview: true,
    reply_markup: buttons ? { inline_keyboard: buttons } : undefined,
  });
}

/* ------------------------------------------------------------- Datenbank */

const SCHEMA = [
  `CREATE TABLE IF NOT EXISTS leads (
     telegram_id INTEGER PRIMARY KEY,
     first_name TEXT, last_name TEXT, username TEXT,
     lang TEXT, source TEXT, region TEXT,
     stage TEXT, existing_account INTEGER DEFAULT 0,
     created_at TEXT, updated_at TEXT
   )`,
  `CREATE TABLE IF NOT EXISTS events (
     id INTEGER PRIMARY KEY AUTOINCREMENT,
     telegram_id INTEGER, stage TEXT, at TEXT
   )`,
  `CREATE INDEX IF NOT EXISTS idx_leads_updated ON leads(updated_at)`,
];

// Nachtraeglich hinzugekommene Spalten. Schlagen fehl wenn sie schon da sind, das ist ok.
const MIGRATIONS = [`ALTER TABLE leads ADD COLUMN uid TEXT`];

async function getLead(env, id) {
  return env.DB.prepare('SELECT * FROM leads WHERE telegram_id = ?').bind(id).first();
}

async function upsertLead(env, from, source) {
  const now = new Date().toISOString();
  await env.DB.prepare(
    `INSERT INTO leads (telegram_id, first_name, last_name, username, source, stage, created_at, updated_at)
     VALUES (?1, ?2, ?3, ?4, ?5, 'started', ?6, ?6)
     ON CONFLICT(telegram_id) DO UPDATE SET
       first_name = ?2, last_name = ?3, username = ?4, updated_at = ?6`
  ).bind(from.id, from.first_name || '', from.last_name || '', from.username || '', source || '', now).run();
}

async function setField(env, id, field, value) {
  const now = new Date().toISOString();
  await env.DB.prepare(`UPDATE leads SET ${field} = ?, updated_at = ? WHERE telegram_id = ?`)
    .bind(value, now, id).run();
}

async function logStage(env, id, stage) {
  const now = new Date().toISOString();
  await env.DB.prepare('UPDATE leads SET stage = ?, updated_at = ? WHERE telegram_id = ?')
    .bind(stage, now, id).run();
  await env.DB.prepare('INSERT INTO events (telegram_id, stage, at) VALUES (?, ?, ?)')
    .bind(id, stage, now).run();
}

/* ------------------------------------------------- Meldungen an dich */

const STAGE_LABEL = {
  started: '🚀 Neuer Lead hat gestartet',
  account_open: '✅ Konto eröffnet',
  deposited: '✅ Eingezahlt',
  applied: '✅ Limitless-Bewerbung ist raus',
  help: '💬 Möchte persönlich schreiben',
  region_us: '🇺🇸 Sonderfall US/AUS',
  account_existing: '🏦 Hat bereits ein PU-Prime-Konto',
  uid_given: '🔢 UID angegeben',
  switch_mail_sent: '📧 Switch-Mail an den Broker ist raus',
  free_text: '💬 Hat im Bot geschrieben',
};

function chatLink(from) {
  return from.username ? `https://t.me/${from.username}` : `tg://user?id=${from.id}`;
}

async function notify(env, from, stage, lead, extra) {
  if (!env.ROB_CHAT_ID) return;
  const label = STAGE_LABEL[stage];
  if (!label) return;

  const name = esc([from.first_name, from.last_name].filter(Boolean).join(' ') || 'Ohne Namen');
  const handle = from.username ? ' (@' + esc(from.username) + ')' : '';
  const time = new Date().toLocaleString('de-DE', { timeZone: 'Europe/Zurich' });

  let text;
  if (stage === 'started') {
    text = `🚀 <b>Neuer Lead im Kanal</b>

👤 ${name}${handle}
🆔 <code>${from.id}</code>
🌐 ${lead && lead.lang === 'en' ? 'Englisch' : 'Deutsch'}
🕐 ${time}

Die Willkommensstrecke wurde automatisch gestartet.

👉 Persönlich anschreiben: ${chatLink(from)}`;
  } else {
    text = `📈 <b>${name}${handle}</b>
${label}${extra ? '\n' + extra : ''}
🕐 ${time}

👉 ${chatLink(from)}`;
  }

  await send(env, env.ROB_CHAT_ID, text);
}

/* ------------------------------------------------------------- Strecke */

function dmHelp(t, stage) {
  if (stage === 'account_open') return t.dm_help.step2;
  if (stage === 'deposited') return t.dm_help.step3;
  if (stage === 'started' || stage === 'awaiting_uid') return t.dm_help.default;
  if (stage === 'region_us' || stage === 'account_existing') return t.dm_help.default;
  return t.dm_help.step1;
}

function kb(t) {
  return {
    lang: [[{ text: '🇩🇪 Deutsch', callback_data: 'lang:de' }, { text: '🇬🇧 English', callback_data: 'lang:en' }]],
    welcome: [
      [{ text: t.b_go, callback_data: 'go' }],
      [{ text: t.b_needs, callback_data: 'needs' }],
      [{ text: t.b_help, callback_data: 'help' }],
    ],
    needs: [
      [{ text: t.b_go, callback_data: 'go' }],
      [{ text: t.b_help, callback_data: 'help' }],
    ],
    region: [
      [{ text: t.b_row, callback_data: 'region:row' }],
      [{ text: t.b_us, callback_data: 'region:us' }],
    ],
    existing: [
      [{ text: t.b_new, callback_data: 'acct:new' }],
      [{ text: t.b_has, callback_data: 'acct:has' }],
    ],
    step1: [
      [{ text: t.b_open, url: LINK_BROKER }],
      [{ text: t.b_done_account, callback_data: 'done:account' }],
      [{ text: t.b_help, callback_data: 'help' }],
    ],
    step2: [
      [{ text: t.b_done_deposit, callback_data: 'done:deposit' }],
      [{ text: t.b_stuck, callback_data: 'help' }],
    ],
    step3: [
      [{ text: t.b_apply, url: LINK_APPLY }],
      [{ text: t.b_done_apply, callback_data: 'done:apply' }],
      [{ text: t.b_help, callback_data: 'help' }],
    ],
    mail: (origin, lang, uid) => [
      [{ text: t.b_mail, url: `${origin}/mail?lang=${lang}${uid ? '&uid=' + encodeURIComponent(uid) : ''}` }],
      [{ text: t.b_mail_sent, callback_data: 'mail:sent' }],
      [{ text: t.b_help, callback_data: 'help' }],
    ],
    rob: [[{ text: t.b_rob, url: LINK_ROB }]],
    robMsg: (msg) => [[{ text: t.b_rob, url: robWithText(msg) }]],
    finish: (msg) => [
      ...(LINK_WA ? [[{ text: t.b_wa, url: LINK_WA }]] : []),
      [{ text: t.b_rob, url: robWithText(msg) }],
    ],
    chat: [[{ text: t.b_chat, url: LINK_ROB }]],
  };
}

async function handleStart(env, msg) {
  const from = msg.from;
  const parts = (msg.text || '').split(' ');
  const source = parts.length > 1 ? parts.slice(1).join(' ').slice(0, 60) : 'direkt';
  await upsertLead(env, from, source);
  await send(env, from.id, '👋 <b>Willkommen!</b>\n\nBitte wähle deine Sprache.\nPlease choose your language.', kb(T.de).lang);
}

async function handleCallback(env, cq, origin) {
  const from = cq.from;
  const data = cq.data || '';
  await tg(env, 'answerCallbackQuery', { callback_query_id: cq.id });

  let lead = await getLead(env, from.id);
  if (!lead) {
    await upsertLead(env, from, 'direkt');
    lead = await getLead(env, from.id);
  }

  const lang = data.startsWith('lang:') ? data.slice(5) : (lead.lang || 'de');
  const t = T[lang] || T.de;
  const k = kb(t);

  if (data.startsWith('lang:')) {
    await setField(env, from.id, 'lang', lang);
    lead.lang = lang;
    await send(env, from.id, t.welcome(esc(from.first_name || '')), k.welcome);
    await notify(env, from, 'started', lead);
    return;
  }

  if (data === 'needs') {
    await send(env, from.id, t.needs, k.needs);
    return;
  }

  if (data === 'go') {
    await send(env, from.id, t.region, k.region);
    return;
  }

  if (data === 'region:us') {
    await setField(env, from.id, 'region', 'us_au');
    await logStage(env, from.id, 'region_us');
    await send(env, from.id, t.us, k.robMsg(t.dm_us));
    await notify(env, from, 'region_us', lead);
    return;
  }

  if (data === 'region:row') {
    await setField(env, from.id, 'region', 'row');
    await send(env, from.id, t.ask_existing, k.existing);
    return;
  }

  if (data === 'acct:has') {
    await setField(env, from.id, 'existing_account', 1);
    await logStage(env, from.id, 'awaiting_uid');
    await send(env, from.id, t.ask_uid);
    await notify(env, from, 'account_existing', lead);
    return;
  }

  if (data === 'mail:sent') {
    await logStage(env, from.id, 'switch_mail_sent');
    await send(env, from.id, t.mail_sent, k.robMsg(t.dm_switch(lead.uid || '')));
    await notify(env, from, 'switch_mail_sent', lead, lead.uid ? '🔢 UID: <code>' + esc(lead.uid) + '</code>' : '');
    return;
  }

  if (data === 'acct:new') {
    await send(env, from.id, t.step1, k.step1);
    return;
  }

  if (data === 'done:account') {
    await logStage(env, from.id, 'account_open');
    await send(env, from.id, t.step2, k.step2);
    await notify(env, from, 'account_open', lead);
    return;
  }

  if (data === 'done:deposit') {
    await logStage(env, from.id, 'deposited');
    await send(env, from.id, t.step3(from.username), k.step3);
    await notify(env, from, 'deposited', lead);
    return;
  }

  if (data === 'done:apply') {
    await logStage(env, from.id, 'applied');
    await send(env, from.id, t.done, k.finish(t.dm_done));
    await notify(env, from, 'applied', lead);
    return;
  }

  if (data === 'help') {
    const before = lead.stage;
    await logStage(env, from.id, 'help');
    await send(env, from.id, t.help, k.robMsg(dmHelp(t, before)));
    await notify(env, from, 'help', lead);
    return;
  }
}

async function handleUpdate(env, update, origin) {
  try {
    if (update.message && update.message.chat && update.message.chat.type === 'private') {
      const msg = update.message;

      // Foto von dir: file_id zurueckmelden, damit es im Kanal-Post genutzt werden kann
      if (msg.photo && String(msg.from.id) === String(env.ROB_CHAT_ID)) {
        const best = msg.photo[msg.photo.length - 1];
        await send(env, msg.from.id, 'file_id für den Kanal-Post:\n\n<code>' + esc(best.file_id) + '</code>');
        return;
      }

      if ((msg.text || '').startsWith('/start')) {
        await handleStart(env, msg);
      } else {
        const lead = await getLead(env, msg.from.id);
        const t = T[(lead && lead.lang) || 'de'] || T.de;

        if (lead && lead.stage === 'awaiting_uid') {
          const uid = (msg.text || '').replace(/[^0-9]/g, '');
          if (uid.length < 4 || uid.length > 15) {
            await send(env, msg.from.id, t.uid_invalid);
            return;
          }
          await setField(env, msg.from.id, 'uid', uid);
          await logStage(env, msg.from.id, 'uid_given');
          await send(env, msg.from.id, t.uid_ok(esc(uid)), kb(t).mail(origin, lead.lang || 'de', uid));
          await notify(env, msg.from, 'uid_given', lead, '🔢 UID: <code>' + esc(uid) + '</code>');
          return;
        }

        await send(env, msg.from.id, t.fallback, kb(t).robMsg(dmHelp(t, lead && lead.stage)));
        const said = (msg.text || '').slice(0, 300);
        if (said) await notify(env, msg.from, 'free_text', lead, '„' + esc(said) + '"');
      }
    } else if (update.callback_query) {
      await handleCallback(env, update.callback_query, origin);
    }
  } catch (err) {
    console.log('handleUpdate error: ' + (err && err.stack ? err.stack : err));
  }
}


/* ------------------------------------------------------- Seite für die Switch-Mail */

const MAIL_PAGE_TEXT = {
  de: {
    title: `Konto zu ${NAME} übertragen`,
    warn_head: 'Von der richtigen Adresse senden',
    warn_body: 'Verschick die Mail von genau der E-Mail-Adresse, mit der dein PU-Prime-Konto angemeldet ist. Von einer anderen Adresse wird der Antrag nicht bearbeitet.',
    to: 'Empfänger',
    subject: 'Betreff',
    body: 'Nachricht',
    copy: 'Kopieren',
    copied: 'Kopiert',
    open: 'Mail-App öffnen',
    open_hint: 'Öffnet dein Standard-Postfach mit fertigem Text. Prüf vorher, ob dort die richtige Adresse eingestellt ist.',
    back: 'Danach zurück zu Telegram und auf „Mail ist raus" tippen.',
    note: 'Der Text bleibt auf Englisch, der Broker-Manager spricht kein Deutsch.',
  },
  en: {
    title: `Transfer your account to ${NAME}`,
    warn_head: 'Send from the right address',
    warn_body: 'Send the email from exactly the address your PU Prime account is registered with. From any other address the request will not be processed.',
    to: 'Recipient',
    subject: 'Subject',
    body: 'Message',
    copy: 'Copy',
    copied: 'Copied',
    open: 'Open mail app',
    open_hint: 'Opens your default mailbox with the text filled in. Check that the right address is set there first.',
    back: 'Then go back to Telegram and tap "Email sent".',
    note: '',
  },
};

function mailPage(lang, uid) {
  const p = MAIL_PAGE_TEXT[lang] || MAIL_PAGE_TEXT.de;
  const body = MAIL_BODY(uid);
  const mailto = `mailto:${MAIL_TO}?subject=${encodeURIComponent(MAIL_SUBJECT)}&body=${encodeURIComponent(body)}`;
  return `<!doctype html><html lang="${lang === 'en' ? 'en' : 'de'}"><head>
<meta charset="utf-8"><meta name="viewport" content="width=device-width,initial-scale=1">
<title>${p.title}</title><style>
:root{--bg:#080d14;--card:#0f1723;--line:#1d2b3d;--ink:#e8eef6;--dim:#94a7bd;--cy:#38d6e0;--warn:#f4b942}
*{box-sizing:border-box}
body{margin:0;background:var(--bg);color:var(--ink);font:15px/1.6 -apple-system,BlinkMacSystemFont,"Segoe UI",Roboto,sans-serif;padding:20px 16px 48px}
.wrap{max-width:560px;margin:0 auto}
h1{font-size:20px;margin:0 0 20px;letter-spacing:-.01em}
.warn{background:rgba(244,185,66,.1);border:1px solid rgba(244,185,66,.35);border-radius:12px;padding:14px 16px;margin-bottom:24px}
.warn b{color:var(--warn);display:block;margin-bottom:4px}
.warn p{margin:0;color:#e3d9c2;font-size:14px}
.f{margin-bottom:18px}
.lbl{font-size:11px;letter-spacing:.09em;text-transform:uppercase;color:var(--dim);margin-bottom:6px}
.box{background:var(--card);border:1px solid var(--line);border-radius:10px;padding:12px 14px;font-family:ui-monospace,SFMono-Regular,Menlo,monospace;font-size:13px;white-space:pre-wrap;word-break:break-word}
button{width:100%;margin-top:8px;padding:11px;border-radius:9px;border:1px solid var(--line);background:#16202e;color:var(--ink);font-size:14px;font-weight:600;cursor:pointer;font-family:inherit}
button:active{background:#1d2b3d}
button.done{border-color:var(--cy);color:var(--cy)}
a.mail{display:block;text-align:center;margin-top:28px;padding:14px;border-radius:10px;background:var(--cy);color:#06202a;font-weight:700;text-decoration:none}
.hint{color:var(--dim);font-size:13px;margin-top:10px;text-align:center}
.back{margin-top:28px;padding-top:20px;border-top:1px solid var(--line);color:var(--dim);font-size:13px;text-align:center}
</style></head><body><div class="wrap">
<h1>${p.title}</h1>
<div class="warn"><b>&#9888; ${p.warn_head}</b><p>${p.warn_body}</p></div>
<div class="f"><div class="lbl">${p.to}</div><div class="box" id="a">${MAIL_TO}</div><button data-c="a">${p.copy}</button></div>
<div class="f"><div class="lbl">${p.subject}</div><div class="box" id="b">${MAIL_SUBJECT}</div><button data-c="b">${p.copy}</button></div>
<div class="f"><div class="lbl">${p.body}</div><div class="box" id="c">${body.replace(/&/g,'&amp;').replace(/</g,'&lt;')}</div><button data-c="c">${p.copy}</button></div>
${p.note ? '<p class="hint">' + p.note + '</p>' : ''}
<a class="mail" href="${mailto.replace(/"/g, '&quot;')}">${p.open}</a>
<p class="hint">${p.open_hint}</p>
<div class="back">${p.back}</div>
</div><script>
document.querySelectorAll('button[data-c]').forEach(function(btn){
  btn.addEventListener('click', function(){
    var el = document.getElementById(btn.getAttribute('data-c'));
    var txt = el.innerText;
    var done = function(){ btn.textContent = ${JSON.stringify('')} + '\u2713 ' + ${JSON.stringify(p.copied)}; btn.className='done'; };
    if (navigator.clipboard && navigator.clipboard.writeText) {
      navigator.clipboard.writeText(txt).then(done, function(){});
    } else {
      var ta=document.createElement('textarea'); ta.value=txt; document.body.appendChild(ta);
      ta.select(); try{document.execCommand('copy'); done();}catch(e){} document.body.removeChild(ta);
    }
  });
});
</script></body></html>`;
}

/* ---------------------------------------------------------------- Router */

export default {
  async fetch(request, env, ctx) {
    const url = new URL(request.url);

    // Telegram-Webhook
    if (url.pathname === '/webhook' && request.method === 'POST') {
      if (request.headers.get('x-telegram-bot-api-secret-token') !== env.HOOK_SECRET) {
        return new Response('forbidden', { status: 403 });
      }
      const update = await request.json();
      ctx.waitUntil(handleUpdate(env, update, url.origin));
      return new Response('ok');
    }

    // Seite mit der Switch-Mail
    if (url.pathname === '/mail') {
      const lang = url.searchParams.get('lang') === 'en' ? 'en' : 'de';
      const uid = (url.searchParams.get('uid') || '').replace(/[^0-9]/g, '').slice(0, 15);
      return new Response(mailPage(lang, uid), {
        headers: { 'content-type': 'text/html; charset=utf-8' },
      });
    }

    // Kanal-Post mit Start-Button einstellen
    if (url.pathname === '/post') {
      if (url.searchParams.get('token') !== env.ADMIN_TOKEN) return new Response('forbidden', { status: 403 });
      const chat = url.searchParams.get('chat');
      if (!chat) return new Response('Parameter chat fehlt, zum Beispiel ?chat=@meinkanal', { status: 400 });
      const src = url.searchParams.get('src') || 'kanal';
      const photo = url.searchParams.get('photo');
      // Text und Button lassen sich per Parameter setzen, sonst gilt die Fassung oben im Code.
      const body = url.searchParams.get('text') || CHANNEL_POST;
      const label = url.searchParams.get('btn') || CHANNEL_BUTTON;
      const markup = {
        inline_keyboard: [[{ text: label, url: `https://t.me/${BOT_USERNAME}?start=${encodeURIComponent(src)}` }]],
      };
      const payload = photo
        ? { chat_id: chat, photo, caption: body, parse_mode: 'HTML', reply_markup: markup }
        : { chat_id: chat, text: body, parse_mode: 'HTML', disable_web_page_preview: true, reply_markup: markup };
      const r = await tg(env, photo ? 'sendPhoto' : 'sendMessage', payload);
      return new Response(JSON.stringify(r, null, 2), { headers: { 'content-type': 'application/json' } });
    }

    // Tabellen anlegen, einmalig
    if (url.pathname === '/setup') {
      if (url.searchParams.get('token') !== env.ADMIN_TOKEN) return new Response('forbidden', { status: 403 });
      for (const sql of SCHEMA) await env.DB.prepare(sql).run();
      for (const sql of MIGRATIONS) {
        try { await env.DB.prepare(sql).run(); } catch (e) { /* Spalte existiert bereits */ }
      }
      return new Response('Tabellen angelegt.');
    }

    // Webhook bei Telegram registrieren, einmalig
    if (url.pathname === '/sethook') {
      if (url.searchParams.get('token') !== env.ADMIN_TOKEN) return new Response('forbidden', { status: 403 });
      const r = await tg(env, 'setWebhook', {
        url: `${url.origin}/webhook`,
        secret_token: env.HOOK_SECRET,
        allowed_updates: ['message', 'callback_query'],
      });
      return new Response(JSON.stringify(r, null, 2), { headers: { 'content-type': 'application/json' } });
    }

    // Leads abholen, wird vom MacBook aufgerufen
    if (url.pathname === '/export') {
      if (url.searchParams.get('token') !== env.ADMIN_TOKEN) return new Response('forbidden', { status: 403 });
      const since = url.searchParams.get('since') || '1970-01-01T00:00:00.000Z';
      const leads = await env.DB.prepare(
        'SELECT * FROM leads WHERE updated_at > ? ORDER BY updated_at ASC'
      ).bind(since).all();
      const events = await env.DB.prepare(
        'SELECT * FROM events WHERE at > ? ORDER BY at ASC'
      ).bind(since).all();
      return new Response(
        JSON.stringify({ exported_at: new Date().toISOString(), leads: leads.results, events: events.results }, null, 2),
        { headers: { 'content-type': 'application/json' } }
      );
    }

    return new Response('Limitless Start Bot läuft.');
  },
};
