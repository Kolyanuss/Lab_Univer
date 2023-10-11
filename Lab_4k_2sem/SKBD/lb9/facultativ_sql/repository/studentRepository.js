const db = require('../db');

const studentRepository = {
  // Отримання списку всіх предметів
  async getAll() {    
    return await db.query('SELECT * FROM students');
  },
  
  async getById(id) {    
    return await db.query('SELECT * FROM students WHERE id = ?', [id]);
  },

  // Створення нового предмету
  async create(name,surname,lastname,address,phone) {    
    await db.query(
      'INSERT INTO students (name, surname, lastname, address, phone) VALUES (?, ?, ?, ?, ?)', 
      [name,surname,lastname,address,phone]);
  },

  // Оновлення предмету
  async update(id,name,surname,lastname,address,phone) {
    await db.query(
      'UPDATE students SET name = ?, surname = ?, lastname = ?, address = ?, phone = ? WHERE id = ?', 
      [name,surname,lastname,address,phone,id]);
  },

  // Видалення предмету
  async delete(id) {
    await db.query('DELETE FROM students WHERE id = ?', [id]);
  },
};

module.exports = studentRepository;