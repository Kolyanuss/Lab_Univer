const mongoose = require("mongoose");

const predmetSchema = new mongoose.Schema({
  name: {
    type: String,
    required: true,
  },
  lecturesize: {
    type: Number,
    required: true,
  },
  practicesize: {
    type: Number,
    required: true,
  },
  labsize: {
    type: Number,
    required: true,
  },
});

const Predmet = mongoose.model("Predmet", predmetSchema);

module.exports = Predmet;