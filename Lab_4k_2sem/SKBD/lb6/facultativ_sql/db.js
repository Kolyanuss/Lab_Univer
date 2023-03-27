const mysql = require('mysql2');
const util = require('util');

const pool = mysql.createPool({
  connectionLimit: 10,
  host: 'localhost',
  user: 'Kolyanus',
  password: 'root',
  database: 'facultativ'
});

pool.getConnection((err, connection) => {
  if (err) {
    console.error('Error connecting to database: ', err);
    return;
  }
  console.log('Connected to database!');
});

pool.query = util.promisify(pool.query);

module.exports = pool;
