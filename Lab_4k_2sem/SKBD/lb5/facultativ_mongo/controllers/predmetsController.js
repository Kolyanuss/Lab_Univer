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
      const name = req.body.name;
      const lecturesize = req.body.lect;
      const practicesize = req.body.prac;
      const labsize = req.body.lab;
      const item = new Predmet({name,lecturesize,practicesize,labsize});
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
    console.log("pin0");
    try {
      const name = req.body.name;
      const lecturesize = req.body.lect;
      const practicesize = req.body.prac;
      const labsize = req.body.lab;
      console.log("pin1");
      let item = await Predmet.findById(req.params.id);
      console.log("pin2");
      if (!item) return res.status(404).send("Predmet not found");
      item.name = name;
      item.lecturesize = lecturesize;
      item.practicesize = practicesize;
      item.labsize = labsize;
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
      let item = await Predmet.findById(req.params.id);
      if (!item) return res.status(404).send("Predmet not found");
      await item.remove();
      res.redirect("/predmets");
    } catch (err) {
      console.error(err);
      res.status(500).send("Server Error");
    }
  },
};

module.exports = predmetsController;
