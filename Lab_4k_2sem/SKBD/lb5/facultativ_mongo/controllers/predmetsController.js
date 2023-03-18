const Predmet = require("../models/predmet");

const predmetsController = {
  // Отримання списку всіх предметів
  async getAll(req, res) {
    try {
      const predmets = await Predmet.find();
      res.render("predmets/index", { predmets });
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
      const { name } = req.body;
      const predmet = new Predmet({ name });
      await predmet.save();
      res.redirect("/predmets");
    } catch (err) {
      console.error(err);
      res.status(500).send("Server Error");
    }
  },

  // Отримання форми для оновлення предмету
  async updateForm(req, res) {
    try {
      const predmet = await Predmet.findById(req.params.id);
      if (!predmet) return res.status(404).send("Predmet not found");
      res.render("predmets/update", { predmet });
    } catch (err) {
      console.error(err);
      res.status(500).send("Server Error");
    }
  },

  // Оновлення предмету
  async update(req, res) {
    try {
      const { name } = req.body;
      let predmet = await Predmet.findById(req.params.id);
      if (!predmet) return res.status(404).send("Predmet not found");
      predmet.name = name;
      await predmet.save();
      res.redirect("/predmets");
    } catch (err) {
      console.error(err);
      res.status(500).send("Server Error");
    }
  },

  // Видалення предмету
  async delete(req, res) {
    try {
      let predmet = await Predmet.findById(req.params.id);
      if (!predmet) return res.status(404).send("Predmet not found");
      await predmet.remove();
      res.redirect("/predmets");
    } catch (err) {
      console.error(err);
      res.status(500).send("Server Error");
    }
  },
};

module.exports = predmetsController;
