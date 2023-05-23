// general config
const express = require("express");
const bodyParser = require("body-parser");

const app = express();
app.set("view engine", "ejs");
app.use(bodyParser.urlencoded({ extended: true }));
app.use(bodyParser.json())
app.use(express.static("public"));


// налаштування маршрутів
const indexRouter = require('./routes/index');
const predmetsRouter = require("./routes/predmets");
const studentsRouter = require("./routes/students");
const syllabusRouter = require("./routes/syllabus");
app.use('/', indexRouter);
app.use("/predmets", predmetsRouter);
app.use("/students", studentsRouter);
app.use("/syllabus", syllabusRouter);
  

// Запуск сервера
const port = process.env.PORT || 3000;
app.listen(port, () => console.log(`Сервер запущено на порті ${port}`));
