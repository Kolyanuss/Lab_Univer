<meta http-equiv="Content-Type" content="text/html; charset=utf8">
<?php
// імена стовпців в бд
$field_name = 'name';
$field_lecturesize = 'lecturesize';
$field_practicesize = 'practicesize';
$field_labsize = 'labsize';

// Змінні з форми
$name = $_POST['name'];
$countLec = $_POST['countLec'];
$countPrac = $_POST['countPrac'];
$countLab = $_POST['countLab'];

// Параметри для підключення
$db_host = 'lb1sskbd';
$db_user = 'root'; // Логін БД
$db_password = ''; // Пароль БД
$db_base = 'facultativ'; // Назва БД
$db_table = 'predmets'; // Назва таблиці БД
// Підключення до бази даних
$mysqli = new mysqli($db_host, $db_user, $db_password, $db_base);
// Якщо є помилка підключення, виводимо її і ліквідуємо підключення
if ($mysqli->connect_error) {
    die('Помилка: (' . $mysqli->connect_errno . ') ' . $mysqli->connect_error);
}
// Виконуємо запит
$result = $mysqli->query(
    'INSERT INTO '.$db_table .
        " ($field_name,$field_lecturesize,$field_practicesize,$field_labsize) VALUES".
        " ('$name','$countLec','$countPrac','$countLab')"
);
// Перевіряємо виконання запиту та виводимо відповідне повідомлення
if ($result == true) {
    echo '<center>Інформація занесена в базу даних!</br><a href="index.html">Повернутись на головну</a></center>';
    $sql_select = 'SELECT * FROM '.$db_table;
    $result2 = mysqli_query($mysqli, $sql_select);
    $row = mysqli_fetch_array($result2);
    do {
        printf(
            '<p>Назва предмету: '.$row[$field_name].'</p>
            <p>Ксть Лекцій: '.$row[$field_lecturesize].'</p>
            <p>Ксть Практик: '.$row[$field_practicesize].'</p>
            <p>Ксть Лаб: '.$row[$field_labsize].'</p>
            </br>'
        );
    } while ($row = mysqli_fetch_array($result2));
} else {
    echo 'Інформація не занесена в базу даних';
}
mysqli_close($mysqli);

?>
