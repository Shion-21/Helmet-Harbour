<?php
$servername = "localhost";
$username = "root";
$password = "HelmetHarbour";
$dbname = "helmetharbour";

$conn = new mysqli($servername, $username, $password, $dbname);

if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}

$RFIDNum = isset($_GET['RFIDNum']) ? $_GET['RFIDNum'] : '';

if (!empty($RFIDNum)) {
    $sql = "SELECT EXISTS (SELECT `RFID #` FROM `helmet racks` WHERE `RFID #` = ?)";
    $stmt = $conn->prepare($sql);
    $stmt->bind_param("s", $RFIDNum);
    $stmt->execute();
    $stmt->bind_result($exists);
    $stmt->fetch();
    echo $exists ? "true" : "false";
    $stmt->close();
}

$conn->close();
?>