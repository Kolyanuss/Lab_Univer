const db = require('../db');

const syllabusRepository = {
  // Отримання списку всіх предметів
  async getAll() {    
    return await db.query('SELECT * FROM syllabus');
  },
  
  async getById(id) {    
    return await db.query('SELECT * FROM syllabus WHERE id = ?', [id]);
  },

  // Створення нового предмету
  async create(id_student,id_predmet,grade) {    
    await db.query(
      'INSERT INTO syllabus (id_student,id_predmet,grade) VALUES (?, ?, ?)', 
      [id_student,id_predmet,grade]);
  },

  // Оновлення предмету
  async update(id,id_student,id_predmet,grade) {
    await db.query(
      'UPDATE syllabus SET id_student = ?, id_predmet = ?, grade = ? WHERE id = ?', 
      [id_student,id_predmet,grade,id]);
  },

  // Видалення предмету
  async delete(id) {
    await db.query('DELETE FROM syllabus WHERE id = ?', [id]);
  },
};

module.exports = syllabusRepository;