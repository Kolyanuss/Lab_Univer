<meta http-equiv="Content-Type" content="text/html; charset=utf8">
<?php
// імена стовпців в таблиці
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

require 'database/DB_connection.php';

// Виконуємо запит
$result = $mysqli->query(
    'INSERT INTO '.$db_table_stud.
        " ($field_name,$field_surname,$field_lastname,$field_address,$field_phone) VALUES" .
        " ('$name','$surname','$lastname','$address','$phone')"
);
// Перевіряємо виконання запиту та виводимо відповідне повідомлення
if ($result == true) {
    echo '<center>Інформація занесена в базу даних!</br><a href="index.html">Повернутись на головну</a></center>';
    $sql_select = 'SELECT * FROM '.$db_table_stud;
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
