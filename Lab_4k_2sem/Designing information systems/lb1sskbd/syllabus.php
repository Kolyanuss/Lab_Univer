<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <link rel="stylesheet" type="text/css" href="css/style.css?version=1">
    <title>Звітність</title>
</head>
<body>
<a href="index.html">Повернутись на головну сторінку</a>
<center>
    <h2>Звітність</h2>
    <form method="POST" action="">
        <p>
            Предмет: 
            <select name="predmets">                
                <?php require 'database/DB_connection.php';
                require 'get/sql_getAllPredmets.php'; ?>
            </select>
        </p>
        <p>
            Студент: 
            <select name="students">
                <?php require 'database/DB_connection.php';
                require 'get/sql_getAllStudents.php'; ?>
            </select>
        </p>
        
        <p>Рік навчання: 
            <input type="number" name="year"
            min="1900" max="2099" step="1" placeholder="ex: 2023" value="2023"></input>
        </p>

        <p>Семестр:</p>
        <p>
            <input type="radio" checked id="semester1" name="semester" value="0">
            <label for="semester1">Перший (вересень - грудень)</label>
            <br>
            <input type="radio" id="semester2" name="semester" value="1">
            <label for="semester2">Другий (лютий - травень)</label><br>  
        </p>
        <p>
            Оцінка: 
            <input type="number" name="grade" placeholder="0-100" min="0" max="100">
        </p>
        <p><input type="submit" name="submit" value="Надіслати"/></p>
    </form>
</center>
</body>
</html>
<?php include 'post/sql_add_syllabus.php'; ?>