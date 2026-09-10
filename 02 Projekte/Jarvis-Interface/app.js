/* =========================================================================
   JARVIS INTERFACE — v0.1 (Prototyp)
   -------------------------------------------------------------------------
   Sprach-Engine: aktuell die Web Speech API des Browsers (SpeechRecognition
   + SpeechSynthesis). Das ist ein Platzhalter, bis klar ist, wie "Hermes"
   technisch angebunden wird (eigenes SDK? WebSocket? eigene Audio-Pipeline?).

   Sobald das feststeht, muss NUR der Block "SPRACH-ENGINE" unten ersetzt
   werden — der Rest der App (UI, Zustände, Verlauf, Antwortlogik) bleibt
   unverändert, weil alles über die Funktionen startListening() / speak()
   läuft statt direkt mit der Browser-API zu arbeiten.

   Ebenso ist die eigentliche "Intelligenz" (was Jarvis auf einen Befehl
   antwortet) in generateResponse() ausgelagert und aktuell nur ein Mock.
   Dort kommt später der echte Claude-Aufruf rein (E-Mails beantworten,
   Instagram posten, Dashboards bauen, etc. — siehe Vault-Notiz zur
   Jarvis-Vision).
   ========================================================================= */

const els = {
  core: document.getElementById('core'),
  coreStatus: document.getElementById('coreStatus'),
  statusLine: document.getElementById('statusLine'),
  transcript: document.getElementById('transcript'),
  micToggle: document.getElementById('micToggle'),
  textForm: document.getElementById('textForm'),
  textInput: document.getElementById('textInput'),
  wakeWordInput: document.getElementById('wakeWordInput'),
  voiceSelect: document.getElementById('voiceSelect'),
  continuousToggle: document.getElementById('continuousToggle'),
  clock: document.getElementById('clock'),
  vaultConnectBtn: document.getElementById('vaultConnectBtn'),
  vaultInput: document.getElementById('vaultInput'),
  vaultStatus: document.getElementById('vaultStatus'),
};

let state = 'standby'; // standby | listening | thinking | speaking
let micEnabled = false;
let selectedVoice = null;

/* ---------- Uhr ---------- */
function tickClock() {
  els.clock.textContent = new Date().toLocaleTimeString('de-DE');
}
setInterval(tickClock, 1000);
tickClock();

/* ---------- UI-Helfer ---------- */
function setState(next) {
  state = next;
  els.core.classList.remove('listening', 'thinking', 'speaking');
  if (next !== 'standby') els.core.classList.add(next);

  const labels = {
    standby: 'STANDBY',
    listening: 'HÖRT ZU',
    thinking: 'DENKT NACH',
    speaking: 'ANTWORTET',
  };
  els.coreStatus.textContent = labels[next] || next.toUpperCase();
}

function setStatusLine(text) {
  els.statusLine.textContent = text;
}

function addEntry(text, kind) {
  const div = document.createElement('div');
  div.className = `entry ${kind}`;
  div.textContent = text;
  els.transcript.appendChild(div);
  els.transcript.scrollTop = els.transcript.scrollHeight;
}

/* =========================================================================
   SPRACH-ENGINE (Platzhalter — hier wird später Hermes eingehängt)
   ========================================================================= */

const SpeechRecognitionAPI = window.SpeechRecognition || window.webkitSpeechRecognition;
let recognizer = null;
let wakeWordActive = false;

function speak(text) {
  addEntry(text, 'jarvis');

  if (!('speechSynthesis' in window)) {
    console.warn('speechSynthesis nicht verfügbar in diesem Browser.');
    return Promise.resolve();
  }

  return new Promise((resolve) => {
    setState('speaking');
    const utter = new SpeechSynthesisUtterance(text);
    utter.lang = 'de-DE';
    if (selectedVoice) utter.voice = selectedVoice;
    utter.onend = () => {
      resolve();
    };
    utter.onerror = () => resolve();
    window.speechSynthesis.speak(utter);
  });
}

function startListening({ onResult, continuous = false }) {
  if (!SpeechRecognitionAPI) {
    setStatusLine('Spracherkennung wird von diesem Browser nicht unterstützt (Chrome empfohlen).');
    return null;
  }

  const rec = new SpeechRecognitionAPI();
  rec.lang = 'de-DE';
  rec.continuous = continuous;
  rec.interimResults = false;
  rec.maxAlternatives = 1;

  rec.onresult = (event) => {
    const last = event.results[event.results.length - 1];
    const text = last[0].transcript.trim();
    onResult(text);
  };

  rec.onerror = (event) => {
    console.warn('Spracherkennung-Fehler:', event.error);
    if (event.error === 'not-allowed' || event.error === 'service-not-allowed') {
      setStatusLine('Mikrofon-Zugriff wurde verweigert. Bitte in den Browser-Einstellungen erlauben.');
      stopEverything();
    }
  };

  rec.onend = () => {
    // Bei Dauer-Lauschen (Wake-Word) automatisch neu starten, solange aktiv.
    if (continuous && wakeWordActive) {
      try { rec.start(); } catch (e) { /* schon aktiv */ }
    }
  };

  rec.start();
  return rec;
}

function stopEverything() {
  wakeWordActive = false;
  micEnabled = false;
  if (recognizer) {
    try { recognizer.stop(); } catch (e) {}
    recognizer = null;
  }
  setState('standby');
  els.micToggle.textContent = '🎤 Mikrofon aktivieren';
  setStatusLine(`Sage „${els.wakeWordInput.value || 'Hallo Jarvis'}", um zu starten…`);
}

/* =========================================================================
   ABLAUF-LOGIK (Wake-Word → Begrüßung → Befehl → Antwort)
   ========================================================================= */

function handleWakeWordDetected() {
  setState('speaking');
  speak('Hallo Mike, was kann ich für dich tun?').then(() => {
    listenForCommand();
  });
}

function listenForCommand() {
  setState('listening');
  setStatusLine('Ich höre zu…');

  // Kurzes Ein-Satz-Erkennen für den eigentlichen Befehl.
  const cmdRec = startListening({
    continuous: false,
    onResult: (text) => {
      addEntry(text, 'user');
      handleCommand(text);
    },
  });

  if (cmdRec) {
    cmdRec.onend = () => {
      // Nach dem Befehl zurück ins Wake-Word-Lauschen (falls aktiv).
      if (wakeWordActive) restartWakeWordListening();
    };
  }
}

async function handleCommand(text) {
  setState('thinking');
  setStatusLine('Verarbeite Anfrage…');

  const response = await generateResponse(text);

  await speak(response);

  if (wakeWordActive) {
    restartWakeWordListening();
  } else {
    setState('standby');
    setStatusLine(`Sage „${els.wakeWordInput.value || 'Hallo Jarvis'}", um zu starten…`);
  }
}

/* -------------------------------------------------------------------------
   ANTWORT-LOGIK
   1) Erst versuchen, die Frage aus dem Obsidian-Vault ("Gehirn") zu
      beantworten.
   2) Danach folgen hier nach und nach die "Hand"-Agenten (E-Mail,
      Dashboard, Kalender, ...) — aktuell noch Mock/Platzhalter.
   ------------------------------------------------------------------------- */
async function generateResponse(userText) {
  const lower = userText.toLowerCase();

  if (lower.includes('wie geht') || lower.includes('alles gut')) {
    return 'Mir geht es gut, danke Mike. Bereit, wenn du es bist.';
  }
  if (lower.includes('danke')) {
    return 'Gerne, jederzeit.';
  }

  if (typeof Vault !== 'undefined' && Vault.isLoaded()) {
    const hit = Vault.answer(userText);
    if (hit) {
      addEntry(`(Quelle: ${hit.path})`, 'system');
      return `Ich habe dazu etwas in „${hit.title}" gefunden: ${hit.snippet}…`;
    }
    return `Dazu habe ich in deinem Vault leider nichts gefunden. Formuliere es gern nochmal anders, oder frag mich etwas anderes.`;
  }

  if (typeof Vault !== 'undefined' && !Vault.isLoaded()) {
    return 'Ich habe noch keinen Zugriff auf dein Vault. Klick oben auf „Vault verbinden", dann kann ich deine Notizen durchsuchen.';
  }

  return `Verstanden: „${userText}". Die eigentliche Verarbeitung ist noch nicht angebunden — das kommt, sobald wir die Backend-Anbindung gebaut haben.`;
}

/* ---------- Wake-Word-Dauerlauschen ---------- */
function restartWakeWordListening() {
  setState('standby');
  setStatusLine(`Sage „${els.wakeWordInput.value || 'Hallo Jarvis'}", um zu starten…`);

  recognizer = startListening({
    continuous: true,
    onResult: (text) => {
      const wakeWord = (els.wakeWordInput.value || 'jarvis').toLowerCase();
      if (text.toLowerCase().includes(wakeWord)) {
        if (recognizer) { try { recognizer.stop(); } catch (e) {} }
        handleWakeWordDetected();
      }
    },
  });
}

/* =========================================================================
   UI-EVENTS
   ========================================================================= */

els.micToggle.addEventListener('click', () => {
  if (!micEnabled) {
    micEnabled = true;
    wakeWordActive = els.continuousToggle.checked;
    els.micToggle.textContent = '🔴 Mikrofon deaktivieren';

    if (wakeWordActive) {
      restartWakeWordListening();
    } else {
      listenForCommand();
    }
  } else {
    stopEverything();
  }
});

els.textForm.addEventListener('submit', (e) => {
  e.preventDefault();
  const text = els.textInput.value.trim();
  if (!text) return;
  addEntry(text, 'user');
  els.textInput.value = '';
  handleCommand(text);
});

/* ---------- Vault (Gehirn) verbinden ---------- */
els.vaultConnectBtn.addEventListener('click', () => {
  els.vaultInput.click();
});

els.vaultInput.addEventListener('change', async (e) => {
  const files = e.target.files;
  if (!files || !files.length) return;

  els.vaultStatus.textContent = 'Lade Notizen…';

  try {
    const count = await Vault.loadFromFileList(files);
    els.vaultStatus.textContent = `Verbunden — ${count} Notizen geladen.`;
    els.vaultStatus.classList.add('connected');
    addEntry(`Vault verbunden: ${count} Notizen geladen. Frag mich gern etwas dazu.`, 'system');
  } catch (err) {
    console.error(err);
    els.vaultStatus.textContent = 'Fehler beim Laden — bitte nochmal versuchen.';
  }
});

/* ---------- Stimmen-Auswahl befüllen ---------- */
function populateVoices() {
  const voices = window.speechSynthesis ? window.speechSynthesis.getVoices() : [];
  const germanVoices = voices.filter(v => v.lang.startsWith('de'));
  const list = germanVoices.length ? germanVoices : voices;

  els.voiceSelect.innerHTML = '';
  list.forEach((v, i) => {
    const opt = document.createElement('option');
    opt.value = i;
    opt.textContent = `${v.name} (${v.lang})`;
    els.voiceSelect.appendChild(opt);
  });

  if (list.length) selectedVoice = list[0];

  els.voiceSelect.addEventListener('change', () => {
    selectedVoice = list[els.voiceSelect.value];
  });
}

if ('speechSynthesis' in window) {
  populateVoices();
  window.speechSynthesis.onvoiceschanged = populateVoices;
}

/* ---------- Start ---------- */
setState('standby');
setStatusLine(`Sage „${els.wakeWordInput.value}", um zu starten… (zuerst Mikrofon aktivieren)`);
