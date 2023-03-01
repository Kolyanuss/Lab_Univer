<?php
require 'DB_config.php';

// Підключення до бази даних
$mysqli = new mysqli($db_host, $db_user, $db_password, $db_base);
$mysqli->set_charset("utf8");
// Якщо є помилка підключення, виводимо її і ліквідуємо підключення
if ($mysqli->connect_error) {
    die('Помилка: (' . $mysqli->connect_errno . ') ' . $mysqli->connect_error);
}
// echo("connected sucseful");
?>