const sqlite3 = require('sqlite3').verbose();

// Шлях до файлу бази даних SQLite
const DB_PATH = './facultativ.db';

// Встановлюємо підключення до бази даних
const db = new sqlite3.Database(DB_PATH, (err) => {
  if (err) {
    console.error(err.message);
  }
  console.log('Connected to the SQLite database.');
});

module.exports = db;
