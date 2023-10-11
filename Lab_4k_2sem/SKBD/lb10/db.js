const oracledb = require('oracledb');
const dbConfig = {
  user: 'your_username',
  password: 'your_password',
  connectString: 'your_connection_string'
};

async function initialize() {
  await oracledb.createPool(dbConfig);
}

function close() {
  oracledb.getPool().close();
}

module.exports.initialize = initialize;
module.exports.close = close;
