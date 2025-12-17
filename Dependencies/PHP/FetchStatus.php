<?php
$servername = "localhost";
$username = "root";
$password = "HelmetHarbour";
$dbname = "helmetharbour";

// Reminder: This code is to be placed after getting the RFID in the esp
$conn = new mysqli($servername, $username, $password, $dbname);

if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}
$rfid = isset($_GET['RFIDNUM']) ? $_GET['RFIDNUM'] : '';

if (!empty($rfid)) {
    $sql = "SELECT `Status` FROM helmetharbour.`rfids` WHERE `RFID Number` = ?";
}

$stmt = $conn->prepare($sql);
if (!empty($rfid)) {
    $stmt->bind_param("s", $rfid);
}
$stmt->execute();

$result = $stmt->get_result();

if ($row = $result->fetch_assoc()) {
            echo $row['Status'];
        } else {
            echo "Nonexistent";
        }


$stmt->close();

$conn->close();
?>