// general config
const express = require("express");
const bodyParser = require("body-parser");

const app = express();
app.set("view engine", "ejs");
app.use(bodyParser.urlencoded({ extended: true }));
app.use(bodyParser.json())
app.use(express.static("public"));


// налаштування маршрутів
// const indexRouter = require('./routes/index');
// const predmetsRouter = require("./routes/predmets");
// const studentsRouter = require("./routes/students");
// const syllabusRouter = require("./routes/syllabus");
// app.use('/', indexRouter);
// app.use("/predmets", predmetsRouter);
// app.use("/students", studentsRouter);
// app.use("/syllabus", syllabusRouter);
const db = require('./db');

app.get('/', (req, res) => {

    // Формуємо HTML відповідь
    let htmlResponse = '<h1>main page</h1>';
    htmlResponse += '<ul>';

    htmlResponse += `<li><a href='/student'>Студенти</a></li>`;
    htmlResponse += `<li><a href='/predmet'>Предмети</a></li>`;

    htmlResponse += '</ul>';

    res.send(htmlResponse);

});

app.get('/predmet', (req, res) => {
  // Виконуємо запит до таблиці
  db.all('SELECT * FROM predmets', [], (err, rows) => {
    if (err) {
      console.error(err.message);
    }
    // Формуємо HTML відповідь
    let htmlResponse = '<h1>Результат запиту до таблиці:</h1>';
    htmlResponse += '<ul>';
    rows.forEach((row) => {
      htmlResponse += `<li>${row.name}</li>`;
    });
    htmlResponse += '</ul>';

    res.send(htmlResponse);
  });
});
app.get('/student', (req, res) => {
    // Виконуємо запит до таблиці
    db.all('SELECT * FROM students', [], (err, rows) => {
      if (err) {
        console.error(err.message);
      }
      // Формуємо HTML відповідь
      let htmlResponse = '<h1>Результат запиту до таблиці:</h1>';
      htmlResponse += '<ul>';
      rows.forEach((row) => {
        htmlResponse += `<li>${row.name} ${row.surname} ${row.lastname}</li>`;
      });
      htmlResponse += '</ul>';
  
      res.send(htmlResponse);
    });
  });
  

// Запуск сервера
const port = process.env.PORT || 3000;
app.listen(port, () => console.log(`Сервер запущено на порті ${port}`));

