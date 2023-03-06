<!-- <meta http-equiv="Content-Type" content="text/html; charset=utf8"> -->
<?php
// Виконуємо запит
$sql_select = 'SELECT * FROM '.$db_table_stud;
$result = $mysqli->query($sql_select);
$id = 0;
$listOfStudentsId = [];
while ($row = mysqli_fetch_array($result))
{
    printf(
        '<option value="'.$id.'">'
            .$row['surname'].' '.$row['name'].' '.$row['lastname'].
        '</option>'
    );
    $id+=1;
    array_push($listOfStudentsId,$row['id']);
}
mysqli_close($mysqli);
?>
