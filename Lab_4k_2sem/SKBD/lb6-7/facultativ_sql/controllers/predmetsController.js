const predmetRepository = require("../repository/predmetRepository");

const predmetsController = {
  // Отримання списку всіх предметів
  async getAll(req, res) {
    try {
      const items = await predmetRepository.getAll();
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
      const {name,lecturesize,practicesize,labsize} = req.body;
      await predmetRepository.create(name,lecturesize,practicesize,labsize);
      res.redirect("/predmets");
    } catch (err) {
      console.error(err);
      res.status(500).send("Server Error");
    }
  },

  // Отримання форми для оновлення предмету
  async updateForm(req, res) {
    try {
      const items = await predmetRepository.getById(req.params.id);
      if (!items) return res.status(404).send("Predmet not found");
      res.render("predmets/update", {"item": items[0]});
    } catch (err) {
      console.error(err);
      res.status(500).send("Server Error");
    }
  },

  // Оновлення предмету
  async update(req, res) {
    try {
      const id = req.params.id;
      const {name,lecturesize,practicesize,labsize} = req.body;
      if (!await predmetRepository.getById(id)) 
        return res.status(404).send("Predmet not found");

      await predmetRepository.update(id,name,lecturesize,practicesize,labsize)      
      res.redirect("/predmets");
    } catch (err) {
      console.error(err);
      res.status(500).send("Server Error");
    }
  },

  // Видалення предмету
  async delete(req, res) {
    try {
      const id = req.params.id;
      if (!await predmetRepository.getById(id)) 
        return res.status(404).send("Predmet not found");

      await predmetRepository.delete(id);      
      res.redirect("/predmets");
    } catch (err) {
      console.error(err);
      res.status(500).send("Server Error");
    }
  },
};

module.exports = predmetsController;
