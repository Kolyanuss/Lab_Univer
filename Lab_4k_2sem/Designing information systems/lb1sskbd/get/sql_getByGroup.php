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

// Виконуємо запит
$sql_select = 'SELECT MAX('.$field_5.') AS maxGrade, '.$field_1.', '.$field_2.' FROM '.$db_table_syll.'
    WHERE '.$field_2.' != 12    
    GROUP BY '.$field_2.'
    ORDER BY maxGrade DESC';
$result = $mysqli->query($sql_select);
while ($row = mysqli_fetch_array($result))
{
    $sql_select2 = 'SELECT name FROM '.$db_table_predm.' WHERE id = '.$row[$field_2];
    $row2 = mysqli_fetch_array($mysqli->query($sql_select2));
    $sql_select3 = 'SELECT name, surname, lastname FROM '.$db_table_stud.' WHERE id = '.$row[$field_1];
    $row3 = mysqli_fetch_array($mysqli->query($sql_select3));
    printf(
        '<p>Предмет: '.$row2['name'].'</p>
        <p>Максимальна оцінка: '.$row['maxGrade'].'</p>
        <p>В студента: '.$row3['name'].' '.$row3['surname'].' '.$row3['lastname'].'</p>
        </br>'
    );
}
mysqli_close($mysqli);
?>
