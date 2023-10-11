const sqlite3 = require('sqlite3').verbose();
const { createPool } = require('generic-pool');

// Функція для створення нового з'єднання до бази даних
function createConnection(callback) {
  const db = new sqlite3.Database('facultativ.db');

  callback(null, db);
}

// Створення пула з'єднань
const dbPool = createPool({
  create: createConnection,
  destroy: (db) => db.close(),
});

module.exports = dbPool;
