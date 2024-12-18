const Predmet = require("../models/predmet");

const predmetsController = {
  // Отримання списку всіх предметів
  async getAll(req, res) {
    try {
      const items = await Predmet.find();
      res.render("predmets/index", { items });
    } catch (err) {
      console.error(err);
      res.status(500).send("Server Error");
    }
  },

  // Отримання форми для створення нового предмету
  createForm(req, res) {
    res.render("predmets/create");
  },

  // Створення нового предмету
  async create(req, res) {
    try {
      const item = new Predmet(req.body);
      await item.save();
      res.redirect("/predmets");
    } catch (err) {
      console.error(err);
      res.status(500).send("Server Error");
    }
  },

  // Отримання форми для оновлення предмету
  async updateForm(req, res) {
    try {
      const item = await Predmet.findById(req.params.id);
      if (!item) return res.status(404).send("Predmet not found");
      res.render("predmets/update", { item });
    } catch (err) {
      console.error(err);
      res.status(500).send("Server Error");
    }
  },

  // Оновлення предмету
  async update(req, res) {
    try {
      let item = await Predmet.findById(req.params.id);
      if (!item) return res.status(404).send("Predmet not found");
      item.name = req.body.name;
      item.lecturesize = req.body.lect;
      item.practicesize = req.body.prac;
      item.labsize = req.body.lab;
      await item.save();
      res.redirect("/predmets");
    } catch (err) {
      console.error(err);
      res.status(500).send("Server Error");
    }
  },

  // Видалення предмету
  async delete(req, res) {
    try {
      let item = await Predmet.findByIdAndRemove(req.params.id);
      if (!item) return res.status(404).send("Predmet not found");
      res.redirect("/predmets");
    } catch (err) {
      console.error(err);
      res.status(500).send("Server Error");
    }
  },
};

module.exports = predmetsController;
