const Student = require("../models/student");

const studentsController = {
  // Отримання списку всіх студентів
  async getAll(req, res) {
    try {
      const items = await Student.find();
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
      const item = new Student(req.body);
      await item.save();
      res.redirect("/students");
    } catch (err) {
      console.error(err);
      res.status(500).send("Server Error");
    }
  },

  // Отримання форми для оновлення предмету
  async updateForm(req, res) {
    try {
      const item = await Student.findById(req.params.id);
      if (!item) return res.status(404).send("Student not found");
      res.render("students/update", { item });
    } catch (err) {
      console.error(err);
      res.status(500).send("Server Error");
    }
  },

  // Оновлення предмету
  async update(req, res) {
    try {
      let item = await Student.findById(req.params.id);
      if (!item) return res.status(404).send("Student not found");
      item.name = req.body.name;
      item.surname = req.body.surname;
      item.lastname = req.body.lastname;
      item.address = req.body.address;
      item.phone = req.body.phone;
      await item.save();
      res.redirect("/students");
    } catch (err) {
      console.error(err);
      res.status(500).send("Server Error");
    }
  },

  // Видалення предмету
  async delete(req, res) {
    try {
      let item = await Student.findByIdAndRemove(req.params.id);
      if (!item) return res.status(404).send("Student not found");
      res.redirect("/students");
    } catch (err) {
      console.error(err);
      res.status(500).send("Server Error");
    }
  },
};

module.exports = studentsController;
