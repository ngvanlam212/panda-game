<?php 

$dsn ="mysql:host=localhost;dbname=mydatabase";
$user ='root';
$pass ='';
$db = new PDO($dsn, $user, $pass); 

$user_nhan = $_POST['user_chuyenn'];
$pass_nhan = $_POST['pass_chuyenn'];

$sql = "select * from user WHERE username='$user_nhan' and password='$pass_nhan'";

$ketqua = $db -> query($sql);

if($db->query($sql) == TRUE){
    while($row = $ketqua -> fetch()){
        echo "Ngon";
    }
}else{
    echo "Non";
}

?>