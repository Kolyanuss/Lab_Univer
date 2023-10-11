// general config
const express = require("express");
const bodyParser = require("body-parser");

const app = express();
app.set("view engine", "ejs");
app.use(bodyParser.urlencoded({ extended: true }));
app.use(bodyParser.json())
app.use(express.static("public"));

// Ініціалізація підключення до бази даних
const db = require('./db');
db.initialize();


// налаштування маршрутів
// const indexRouter = require('./routes/index');
// const predmetsRouter = require("./routes/predmets");
// const studentsRouter = require("./routes/students");
// const syllabusRouter = require("./routes/syllabus");
// app.use('/', indexRouter);
// app.use("/predmets", predmetsRouter);
// app.use("/students", studentsRouter);
// app.use("/syllabus", syllabusRouter);

app.get('/', (req, res) => {

    // Формуємо HTML відповідь
    let htmlResponse = '<h1>main page</h1>';
    htmlResponse += '<ul>';

    htmlResponse += `<li><a href='/student'>Студенти</a></li>`;
    htmlResponse += `<li><a href='/predmet'>Предмети</a></li>`;

    htmlResponse += '</ul>';

    res.send(htmlResponse);

});

app.get('/predmet', async (req, res) => {
  try {
    // Виконання запиту до таблиці
    const connection = await oracledb.getConnection();
    const result = await connection.execute('SELECT * FROM predmets');
    connection.release();

    // Виведення результату на сторінку
    res.send(`<pre>${JSON.stringify(result.rows, null, 2)}</pre>`);
  } catch (err) {
    console.error(err);
    res.status(500).send('Помилка сервера');
  }
});

app.get('/student', async (req, res) => {
  try {
    // Виконання запиту до таблиці
    const connection = await oracledb.getConnection();
    const result = await connection.execute('SELECT * FROM students');
    connection.release();

    // Виведення результату на сторінку
    res.send(`<pre>${JSON.stringify(result.rows, null, 2)}</pre>`);
  } catch (err) {
    console.error(err);
    res.status(500).send('Помилка сервера');
  }
});
  

// Запуск сервера
const port = process.env.PORT || 3000;
app.listen(port, () => console.log(`Сервер запущено на порті ${port}`));

