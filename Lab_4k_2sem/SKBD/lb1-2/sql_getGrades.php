<meta http-equiv="Content-Type" content="text/html; charset=utf8">
<?php
// імена стовпців в бд
$field_1 = 'id_student';
$field_2 = 'id_predmet';
$field_3 = 'grade';

// Параметри для підключення
$db_host = 'lb1sskbd';
$db_user = 'root'; // Логін БД
$db_password = ''; // Пароль БД
$db_base = 'facultativ'; // Назва БД
$db_table = 'syllabus'; // Назва таблиці БД
$db_table2 = 'students'; // Назва 2 таблиці БД
$db_table3 = 'predmets'; // Назва 3 таблиці БД
// Підключення до бази даних
$mysqli = new mysqli($db_host, $db_user, $db_password, $db_base);
// Якщо є помилка підключення, виводимо її і ліквідуємо підключення
if ($mysqli->connect_error) {
    die('Помилка: (' . $mysqli->connect_errno . ') ' . $mysqli->connect_error);
}

echo '<center><a href="index.html">Повернутись на головну</a></center>';

// Виконуємо запит
$sql_select = 'SELECT * FROM '.$db_table;
$result = $mysqli->query($sql_select);
$row = mysqli_fetch_array($result);
do {
    $sql_select2 = 'SELECT name, surname, lastname FROM '.$db_table2.' WHERE id = '.$row[$field_1];
    $sql_select3 = 'SELECT name FROM '.$db_table3.' WHERE id = '.$row[$field_2];
    $row2 = mysqli_fetch_array($mysqli->query($sql_select2));
    $row3 = mysqli_fetch_array($mysqli->query($sql_select3));
    printf(
        '<p>Студент: '.$row2['name'].' '.$row2['surname'].' '.$row2['lastname'].'</p>
        <p>Предмет: '.$row3['name'].'</p>
        <p>Оцінка: '.$row[$field_3].'</p>
        </br>'
    );
} while ($row = mysqli_fetch_array($result));
mysqli_close($mysqli);
?>
