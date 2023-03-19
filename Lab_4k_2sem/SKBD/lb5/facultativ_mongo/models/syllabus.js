const mongoose = require("mongoose");

const syllabusSchema = new mongoose.Schema({
  id_student : {
    type: Number,
    required: true,
  },
  id_predmet: {
    type: Number,
    required: true,
  },
  grade: {
    type: Number,
    required: true,
  },
});

const Syllabus = mongoose.model("Syllabus", syllabusSchema);

module.exports = Syllabus;