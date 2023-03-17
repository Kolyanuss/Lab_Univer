const express = require("express");
const mongoose = require("mongoose");
const bodyParser = require("body-parser");
// const Predmet = require("./models/predmet");
// const Student = require("./models/student");
// const Syllabus = require("./models/syllabus");

const app = express();
app.set("view engine", "ejs");
app.use(bodyParser.urlencoded({ extended: true }));

// Підключення до бази даних
mongoose
  .connect("mongodb://localhost:27017/sskbd_facultativ", { useNewUrlParser: true })
  .then(() => console.log("Підключено до бази даних"))
  .catch((err) => console.error(err));

// налаштування маршрутів
const indexRouter = require('./routes/index');
const predmetsRouter = require("./routes/predmets");
// const studentsRouter = require("./routes/students");
// const syllabusRouter = require("./routes/syllabus");
app.use('/', indexRouter);
app.use("/predmets", predmetsRouter);
// app.use("/students", studentsRouter);
// app.use("/syllabus", syllabusRouter);

// Запуск сервера
const port = process.env.PORT || 3000;
app.listen(port, () => console.log(`Сервер запущено на порті ${port}`));
