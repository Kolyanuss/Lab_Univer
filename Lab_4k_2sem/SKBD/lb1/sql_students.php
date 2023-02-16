<meta http-equiv="Content-Type" content="text/html; charset=utf8">
<?php
// імена стовпців в бд
$field_name = 'name';
$field_surname = 'surname';
$field_lastname = 'lastname';
$field_address = 'address';
$field_phone = 'phone';

// Змінні з форми
$name = $_POST['name'];
$surname = $_POST['surname'];
$lastname = $_POST['lastname'];
$address = $_POST['address'];
$phone = $_POST['phone'];

// Параметри для підключення
$db_host = 'lb1sskbd';
$db_user = 'root'; // Логін БД
$db_password = ''; // Пароль БД
$db_base = 'facultativ'; // Назва БД
$db_table = 'students'; // Назва таблиці БД
// Підключення до бази даних
$mysqli = new mysqli($db_host, $db_user, $db_password, $db_base);
// Якщо є помилка підключення, виводимо її і ліквідуємо підключення
if ($mysqli->connect_error) {
    die('Помилка: (' . $mysqli->connect_errno . ') ' . $mysqli->connect_error);
}
// Виконуємо запит
$result = $mysqli->query(
    'INSERT INTO '.$db_table .
        " ($field_name,$field_surname,$field_lastname,$field_address,$field_phone) VALUES" .
        " ('$name','$surname','$lastname','$address','$phone')"
);
// Перевіряємо виконання запиту та виводимо відповідне повідомлення
if ($result == true) {
    echo '<center>Інформація занесена в базу даних!</br><a href="index.html">Повернутись на головну</a></center>';
    $sql_select = 'SELECT * FROM '.$db_table;
    $result2 = mysqli_query($mysqli, $sql_select);
    $row = mysqli_fetch_array($result2);
    do {
        printf(
            '<p>Імя: '.$row[$field_name].'</p>
            <p>Прізвище: '.$row[$field_surname].'</p>
            <p>По ботькові: '.$row[$field_lastname].'</p>
            <p>Адреса: '.$row[$field_address].'</p>
            <p>Телефон: '.$row[$field_phone].'</p>
            </br>'
        );
    } while ($row = mysqli_fetch_array($result2));
} else {
    echo 'Інформація не занесена в базу даних';
}
mysqli_close($mysqli);

?>
