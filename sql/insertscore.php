<?php

// Include the database connection file
include_once 'db.php';

// Retrieve POST parameters from the Unity application
$systime_p =$_POST["sysTime"];
$level_p =$_POST["levelNum"];
$abtest_p =$_POST["abTest"];
$timea_p =$_POST["timeA"];
$leveltime_p =$_POST["levelTime"];
$lagtime_p =$_POST["lagTime"];
$levelpick_p =$_POST["levelPick"];
$email_p =$_POST["eMail"];

// Set the character set to UTF-8 to support international characters
$sql = "set names utf8";
// Execute the SQL command
mysqli_query($conn,$sql);

// Prepare the SQL statement to insert data into the database
$sql = "insert into unity_data
(SysTime, Level, A1B0test, TimerA, LevelTimer, LagTime, LevelPick, EmailBox) 
values
('$systime_p',$level_p, $abtest_p, '$timea_p', $leveltime_p,$lagtime_p, $levelpick_p, '$email_p')";
// Execute the SQL statement
$rs = mysqli_query($conn,$sql);
if(!$rs)
{
    // If the query of the $rs'result set' fails, close the database connection and terminate the script with an error message
    mysqli_close($conn);
    die("- code error");
}
else
{
    // If the query is successful, output a success message
    echo "+ Data success";
}
 
// Close the database connection
mysqli_close($conn);
?>
