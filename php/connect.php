<?php

$connection = mysql_connect("192.168.40.3","root","password");
if (!$connection){
    die("Database Connection Failed" . mysql_error());
}
$select_db = mysql_select_db('CompareTest');
if (!$select_db){
    die("Database Selection Failed" . mysql_error());
}
?>
