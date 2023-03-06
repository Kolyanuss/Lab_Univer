<meta http-equiv="Content-Type" content="text/html; charset=utf8">
<?php
// імена стовпців в таблиці
$field_name = 'name';
$field_lecturesize = 'lecturesize';
$field_practicesize = 'practicesize';
$field_labsize = 'labsize';

// Змінні з форми
$name = $_POST['name'];
$countLec = $_POST['countLec'];
$countPrac = $_POST['countPrac'];
$countLab = $_POST['countLab'];

require '../database/DB_connection.php';

// Виконуємо запит
$result = $mysqli->query(
    'INSERT INTO '.$db_table_predm .
        " ($field_name,$field_lecturesize,$field_practicesize,$field_labsize) VALUES".
        " ('$name','$countLec','$countPrac','$countLab')"
);
// Перевіряємо виконання запиту та виводимо відповідне повідомлення
if ($result == true) {
    echo '<center>Інформація занесена в базу даних!</br><a href="../index.html">Повернутись на головну</a></center>';
    $sql_select = 'SELECT * FROM '.$db_table_predm;
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
