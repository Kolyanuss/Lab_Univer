<!-- <meta http-equiv="Content-Type" content="text/html; charset=utf8"> -->
<?php
require 'database/DB_connection.php';

// Виконуємо запит
$sql_select = 'SELECT * FROM '.$db_table_predm;
$result = $mysqli->query($sql_select);
$id = 0;
$listOfPredmetsId = [];
while ($row = mysqli_fetch_array($result))
{
    printf(
        '<option value="'.$id.'">'
            .$row['name'].
        '</option>'
    );
    $id+=1;
    array_push($listOfPredmetsId,$row['id']);
}
mysqli_close($mysqli);
?>
