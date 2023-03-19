const Syllabus = require("../models/syllabus");

const syllabusController = {
  // Отримання списку
  async getAll(req, res) {
    try {
      const items = await Syllabus.find();
      res.render("syllabus/index", { items });
    } catch (err) {
      console.error(err);
      res.status(500).send("Server Error");
    }
  },

  // Отримання форми для створення нового предмету
  createForm(req, res) {
    res.render("syllabus/create");
  },

  // Створення нового предмету
  async create(req, res) {
    try {
      const item = new Syllabus(req.body);
      await item.save();
      res.redirect("/syllabus");
    } catch (err) {
      console.error(err);
      res.status(500).send("Server Error");
    }
  },

  // Отримання форми для оновлення предмету
  async updateForm(req, res) {
    try {
      const item = await Syllabus.findById(req.params.id);
      if (!item) return res.status(404).send("Syllabus not found");
      res.render("syllabus/update", { item });
    } catch (err) {
      console.error(err);
      res.status(500).send("Server Error");
    }
  },

  // Оновлення предмету
  async update(req, res) {
    try {
      let item = await Syllabus.findById(req.params.id);
      if (!item) return res.status(404).send("Syllabus not found");
      item.id_student = req.body.id_student;
      item.id_predmet = req.body.id_predmet;
      item.grade = req.body.grade;
      await item.save();
      res.redirect("/syllabus");
    } catch (err) {
      console.error(err);
      res.status(500).send("Server Error");
    }
  },

  // Видалення предмету
  async delete(req, res) {
    try {
      let item = await Syllabus.findByIdAndRemove(req.params.id);
      if (!item) return res.status(404).send("Syllabus not found");
      res.redirect("/syllabus");
    } catch (err) {
      console.error(err);
      res.status(500).send("Server Error");
    }
  },
};

module.exports = syllabusController;
