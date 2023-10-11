const db  = require('../db');

const predmetRepository = {
  // Отримання списку всіх предметів
  async getAll() {
    return await db.query('SELECT * FROM predmets');
  },
  
  async getById(id) {    
    return await db.query('SELECT * FROM predmets WHERE id = ?', [id]);
  },

  // Створення нового предмету
  async create(name,lecturesize,practicesize,labsize) {    
    await db.query(
      'INSERT INTO predmets (name, lecturesize, practicesize, labsize) VALUES (?, ?, ?, ?)', 
      [name,lecturesize,practicesize,labsize]);
  },

  // Оновлення предмету
  async update(id,name,lecturesize,practicesize,labsize) {
    await db.query(
      'UPDATE predmets SET name = ?, lecturesize = ?, practicesize = ?, labsize = ? WHERE id = ?', 
      [name,lecturesize,practicesize,labsize,id]);
  },

  // Видалення предмету
  async delete(id) {
    await db.query('DELETE FROM predmets WHERE id = ?', [id]);
  },
};

module.exports = predmetRepository;