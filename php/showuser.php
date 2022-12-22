<?php 

$dsn ="mysql:host=localhost;dbname=mydatabase";
$user ='root';
$pass ='';
$db = new PDO($dsn, $user, $pass); 

$sql = "select * from user ORDER BY SCORE DESC";

$ketqua = $db -> query($sql);

while($row=$ketqua->fetch()){
    // echo $row[0];

    printf("%s-%s-%s-%s-%s", $row[0], $row[1], $row[2], $row[3], $row[4]);
    print(",");
}

?>