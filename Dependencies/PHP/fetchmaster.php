<?php
$servername = "localhost";
$username = "root";
$password = "HelmetHarbour";
$dbname = "helmetharbour";

$conn = new mysqli($servername, $username, $password, $dbname);

if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}
$sql = "SELECT `master card` FROM `rfid controller` WHERE `idRFID controller` = 1";

$stmt = $conn->prepare($sql);
$stmt->execute();

$result = $stmt->get_result();
if ($row = $result->fetch_assoc()) {
    echo $row['master card']; 
} 

$stmt->close();
$conn->close();
?>