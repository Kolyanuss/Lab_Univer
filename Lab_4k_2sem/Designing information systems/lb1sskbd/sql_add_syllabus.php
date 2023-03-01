<meta http-equiv="Content-Type" content="text/html; charset=utf8">
<?php
// імена стовпців в табилці
$field_1 = 'id_student';
$field_2 = 'id_predmet';
$field_3 = 'year';
$field_4 = 'semester';
$field_5 = 'grade';

if (isset($_POST['submit'])) {
    // Змінні з форми
    $idPredmet = $_POST['predmets'];
    $idStudent = $_POST['students'];
    $year = $_POST['year'];
    $semester = $_POST['semester'];
    $grade = $_POST['grade'];

    require 'database/DB_connection.php';

    // Виконуємо запит
    $result = $mysqli->query(
        'INSERT INTO '.$db_table_syll.
            " ($field_1,$field_2,$field_3,$field_4,$field_5) VALUES".
            " ('$listOfStudentsId[$idStudent]','$listOfPredmetsId[$idPredmet]','$year','$semester','$grade')"
    );
    // Перевіряємо виконання запиту та виводимо відповідне повідомлення
    if ($result == true) {
        echo '<center>Інформація занесена в базу даних!</center>';
    } else {
        echo 'Інформація не занесена в базу даних';
    }
    mysqli_close($mysqli);
}
?>
