/* =========================================================================
   VAULT (GEHIRN) — Wissensabruf aus dem Obsidian-Vault
   -------------------------------------------------------------------------
   MVP-Ansatz: Läuft komplett im Browser, ohne eigenen Server.
   Nutzt den klassischen <input type="file" webkitdirectory> statt der
   neueren File System Access API, weil letztere auf file://-Seiten
   (also wenn man index.html einfach per Doppelklick öffnet) von Chrome
   blockiert wird. Nachteil: der Ordner muss nach jedem Neuladen der Seite
   einmal neu ausgewählt werden — das ist der Preis für "kein Server nötig".

   Sobald wir stattdessen einen kleinen lokalen Server laufen lassen
   (später sinnvoll, wenn Jarvis auch selbstständig/dauerhaft laufen soll),
   kann man hier auf die File System Access API umsteigen und die
   Ordner-Berechtigung dauerhaft speichern.
   ========================================================================= */

const Vault = (() => {
  let notes = []; // [{ title, path, content }]
  let loaded = false;

  const IGNORE_DIRS = ['.obsidian', '.trash', '.git'];

  function shouldIgnore(relPath) {
    return IGNORE_DIRS.some(dir => relPath.includes(`/${dir}/`) || relPath.startsWith(`${dir}/`));
  }

  async function loadFromFileList(fileList) {
    const mdFiles = Array.from(fileList).filter(f =>
      f.name.toLowerCase().endsWith('.md') && !shouldIgnore(f.webkitRelativePath)
    );

    const loadedNotes = await Promise.all(mdFiles.map(async (file) => {
      const content = await file.text();
      const title = file.name.replace(/\.md$/i, '');
      return { title, path: file.webkitRelativePath, content };
    }));

    notes = loadedNotes;
    loaded = true;
    return notes.length;
  }

  function isLoaded() {
    return loaded;
  }

  function noteCount() {
    return notes.length;
  }

  /* ---------- Sehr einfache Stichwort-Suche ---------- */
  function tokenize(text) {
    return text
      .toLowerCase()
      .replace(/[^\p{L}\p{N}\s]/gu, ' ')
      .split(/\s+/)
      .filter(w => w.length > 2);
  }

  // Häufige deutsche Füllwörter, die die Suche nicht verfälschen sollen.
  const STOPWORDS = new Set([
    'der', 'die', 'das', 'und', 'oder', 'ist', 'sind', 'war', 'waren',
    'was', 'wie', 'wer', 'wann', 'welche', 'welcher', 'welches',
    'ich', 'du', 'wir', 'ihr', 'sie', 'mein', 'meine', 'meinen', 'meiner',
    'hast', 'habe', 'haben', 'kannst', 'kann', 'jarvis', 'bitte', 'mal',
    'für', 'zum', 'zur', 'einen', 'eine', 'einer', 'über', 'noch',
  ]);

  function search(query, topN = 3) {
    const queryTokens = tokenize(query).filter(t => !STOPWORDS.has(t));
    if (!queryTokens.length || !notes.length) return [];

    const scored = notes.map(note => {
      const titleTokens = tokenize(note.title);
      const contentTokens = tokenize(note.content);

      let score = 0;
      queryTokens.forEach(qt => {
        titleTokens.forEach(tt => { if (tt.includes(qt) || qt.includes(tt)) score += 5; });
        contentTokens.forEach(ct => { if (ct === qt) score += 1; });
      });

      return { note, score };
    });

    return scored
      .filter(s => s.score > 0)
      .sort((a, b) => b.score - a.score)
      .slice(0, topN);
  }

  function extractSnippet(content, queryTokens, maxLen = 260) {
    const lower = content.toLowerCase();
    let hitIndex = -1;
    for (const qt of queryTokens) {
      const idx = lower.indexOf(qt);
      if (idx !== -1 && (hitIndex === -1 || idx < hitIndex)) hitIndex = idx;
    }
    if (hitIndex === -1) hitIndex = 0;

    const start = Math.max(0, hitIndex - 60);
    let snippet = content.slice(start, start + maxLen).replace(/\s+/g, ' ').trim();
    // Markdown-Syntax für die Sprachausgabe grob entfernen.
    snippet = snippet.replace(/[#*_`\[\]]/g, '');
    return snippet;
  }

  function answer(query) {
    const results = search(query);
    if (!results.length) return null;

    const top = results[0];
    const queryTokens = tokenize(query).filter(t => !STOPWORDS.has(t));
    const snippet = extractSnippet(top.note.content, queryTokens);

    return {
      title: top.note.title,
      path: top.note.path,
      snippet,
      alternatives: results.slice(1).map(r => r.note.title),
    };
  }

  return { loadFromFileList, isLoaded, noteCount, answer };
})();
