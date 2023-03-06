<meta http-equiv="Content-Type" content="text/html; charset=utf8">
<?php
// імена стовпців в таблиці
$field_1 = 'id_student';
$field_2 = 'id_predmet';
$field_3 = 'year';
$field_4 = 'semester';
$field_5 = 'grade';

require '../database/DB_connection.php';

echo '<center><a href="../index.html">Повернутись на головну</a></center>';
echo '<center><a href="sql_getByGroup.php">Інформація про окремий предмет</a></center>';

// Запит обчислення  середньої оцінки
$sql_select = 'SELECT AVG('.$field_5.') FROM '.$db_table_syll;
$result = $mysqli->query($sql_select);
$row = mysqli_fetch_array($result);
printf("<p>Середня оцінка: ".$row[0]."</p><br>");

// Виконуємо запит
$sql_select = 'SELECT * FROM '.$db_table_syll;
$result = $mysqli->query($sql_select);

while ($row = mysqli_fetch_array($result))
{
    $sql_select2 = 'SELECT name, surname, lastname FROM '.$db_table_stud.' WHERE id = '.$row[$field_1];
    $sql_select3 = 'SELECT name FROM '.$db_table_predm.' WHERE id = '.$row[$field_2];
    $row2 = mysqli_fetch_array($mysqli->query($sql_select2));
    $row3 = mysqli_fetch_array($mysqli->query($sql_select3));
    printf(
        '<p>Студент: '.$row2['name'].' '.$row2['surname'].' '.$row2['lastname'].'</p>
        <p>Предмет: '.$row3['name'].'</p>
        <p>Рік: '.$row[$field_3].'</p>
        <p>Семестер: '.(($row[$field_4])+1).'</p>
        <p>Оцінка: '.$row[$field_5].'</p>
        </br>'
    );
}
mysqli_close($mysqli);
?>
