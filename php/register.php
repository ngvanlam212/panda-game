<?php

    //Kết nối với Database
    $dsn = "mysql:host=localhost;dbname=mydatabase";
    $user = 'root';
    $pass = '';
    $dn = new PDO($dsn, $user, $pass);

    // Khai báo biến 

    $id_nhan = $_POST['id_chuyen'];
    $name_nhan = $_POST['name_chuyen'];
    $score_nhan = $_POST['score_chuyen'];
    $user_nhan = $_POST['user_chuyen'];
    $pass_nhan = $_POST['pass_chuyen'];

    $sql = "insert into user value ($id_nhan,'$name_nhan',$score_nhan,'$user_nhan','$pass_nhan')";
    if($dn->exec($sql) == TRUE){
        echo "Ngon";
    }else{
        echo "Gà";
    }


?>