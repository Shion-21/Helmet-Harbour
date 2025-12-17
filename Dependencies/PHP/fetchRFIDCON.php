<?php
$servername = "localhost";
$username = "root";
$password = "HelmetHarbour";
$dbname = "helmetharbour";

$conn = new mysqli($servername, $username, $password, $dbname);

if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}

$slot = isset($_GET['SLOT']) ? $_GET['SLOT'] : '';

if (!empty($slot)) {
    $sql = "SELECT `RFIDSet` FROM `helmet racks` WHERE `Rack Slot` = ?";
}

$stmt = $conn->prepare($sql);
if (!empty($slot)) {
    $stmt->bind_param("s", $slot);
}
$stmt->execute();

$result = $stmt->get_result();
if ($row = $result->fetch_assoc()) {
    echo $row['RFIDSet'];
} 

$stmt->close();
$conn->close();
?>