const studentRepository = require("../repository/studentRepository");

const studentsController = {
  // Отримання списку всіх предметів
  async getAll(req, res) {
    try {
      const items = await studentRepository.getAll();
      res.render("students/index", { items });
    } catch (err) {
      console.error(err);
      res.status(500).send("Server Error");
    }
  },

  // Отримання форми для створення нового предмету
  createForm(req, res) {
    res.render("students/create");
  },

  // Створення нового предмету
  async create(req, res) {
    try {
      const {name,surname,lastname,address,phone} = req.body;
      await studentRepository.create(name,surname,lastname,address,phone);
      res.redirect("/students");
    } catch (err) {
      console.error(err);
      res.status(500).send("Server Error");
    }
  },

  // Отримання форми для оновлення предмету
  async updateForm(req, res) {
    try {
      const items = await studentRepository.getById(req.params.id);
      if (!items) return res.status(404).send("student not found");
      res.render("students/update", {"item": items[0]});
    } catch (err) {
      console.error(err);
      res.status(500).send("Server Error");
    }
  },

  // Оновлення предмету
  async update(req, res) {
    try {
      const id = req.params.id;
      const {name,surname,lastname,address,phone} = req.body;
      if (!await studentRepository.getById(id)) 
        return res.status(404).send("student not found");

      await studentRepository.update(id,name,surname,lastname,address,phone)      
      res.redirect("/students");
    } catch (err) {
      console.error(err);
      res.status(500).send("Server Error");
    }
  },

  // Видалення предмету
  async delete(req, res) {
    try {
      const id = req.params.id;
      if (!await studentRepository.getById(id)) 
        return res.status(404).send("student not found");

      await studentRepository.delete(id);      
      res.redirect("/students");
    } catch (err) {
      console.error(err);
      res.status(500).send("Server Error");
    }
  },
};

module.exports = studentsController;
