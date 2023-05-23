const syllabusRepository = require("../repository/syllabusRepository");

const syllabusController = {
  // Отримання списку всіх предметів
  async getAll(req, res) {
    try {
      const items = await syllabusRepository.getAll();
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
      const {id_student,id_predmet,grade} = req.body;
      await syllabusRepository.create(id_student,id_predmet,grade);
      res.redirect("/syllabus");
    } catch (err) {
      console.error(err);
      res.status(500).send("Server Error");
    }
  },

  // Отримання форми для оновлення предмету
  async updateForm(req, res) {
    try {
      const items = await syllabusRepository.getById(req.params.id);
      if (!items) return res.status(404).send("syllabus not found");
      res.render("syllabus/update", {"item": items[0]});
    } catch (err) {
      console.error(err);
      res.status(500).send("Server Error");
    }
  },

  // Оновлення предмету
  async update(req, res) {
    try {
      const id = req.params.id;
      const {id_student,id_predmet,grade} = req.body;
      if (!await syllabusRepository.getById(id)) 
        return res.status(404).send("syllabus not found");

      await syllabusRepository.update(id,id_student,id_predmet,grade)
      res.redirect("/syllabus");
    } catch (err) {
      console.error(err);
      res.status(500).send("Server Error");
    }
  },

  // Видалення предмету
  async delete(req, res) {
    try {
      const id = req.params.id;
      if (!await syllabusRepository.getById(id)) 
        return res.status(404).send("syllabus not found");

      await syllabusRepository.delete(id);      
      res.redirect("/syllabus");
    } catch (err) {
      console.error(err);
      res.status(500).send("Server Error");
    }
  },
};

module.exports = syllabusController;
