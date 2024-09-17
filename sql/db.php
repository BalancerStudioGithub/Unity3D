<?php
$servername = "sql.###.vhostgo.com";
//The server URL of the Virtual Host Database
$dbusername = "*******";
$dbpassword = "######";
$dbname = "***";

// Create connection
$conn = new mysqli($servername, $dbusername, $dbpassword, $dbname);
// Check connection
//Check Connection
if(!$conn){
    die("Connection failed.");
}else{
echo "Connection Successful";
} 
?>