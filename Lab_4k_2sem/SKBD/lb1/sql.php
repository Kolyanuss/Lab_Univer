<meta http-equiv="Content-Type" content="text/html; charset=utf8">
<?php
// Змінні з форми
$pib = $_POST['pib'];
$tel = $_POST['tel'];
$com = $_POST['com'];
// Параметри для підключення
$db_host = "lb1sskbd";
$db_user = "root"; // Логін БД
$db_password = ""; // Пароль БД
$db_base = 'zakaz'; // Назва БД
$db_table = "zakaz"; // Назва таблиці БД
// Підключення до бази даних
$mysqli = new mysqli($db_host, $db_user, $db_password, $db_base);
// Якщо є помилка підключення, виводимо її і ліквідуємо підключення
if ($mysqli->connect_error) {
    die('Помилка: (' . $mysqli->connect_errno . ') ' . $mysqli->connect_error);
}
// Виконуємо запит
$result = $mysqli->query("INSERT INTO " . $db_table . " (pib,tel, com) VALUES ('$pib','$tel','$com')");
// Перевіряємо виконання запиту та виводимо відповідне повідомлення
if ($result == true) {
    echo '<center>Інформація занесена в базу даних!</br><a href="index.html">Повернутись на головну</a></center>';
    $sql_select = "SELECT * FROM zakaz";
    $result2 = mysqli_query($mysqli, $sql_select);
    $row = mysqli_fetch_array($result2);
    do {
        printf("<p>ПІБ: " . $row['pib'] . "</p><p>Номер телефону: " . $row['tel'] . "</p>
        <p>Коментар: " . $row['com'] . "</p></br>");
    } while ($row = mysqli_fetch_array($result2));
} else {
    echo 'Інформація не занесена в базу даних';
}
mysqli_close($mysqli);
?>