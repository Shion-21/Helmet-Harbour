<?php
$servername = "localhost";
$username = "root";
$password = "HelmetHarbour";
$dbname = "helmetharbour";

$conn = new mysqli($servername, $username, $password, $dbname);

$rfid = isset($_POST['RFIDNUM']) ? $_POST['RFIDNUM'] : '';
$slot = isset($_POST['SLOT']) ? $_POST['SLOT'] : '';
if (!empty($rfid) && !empty($slot)) {
    $stmt = $conn->prepare("INSERT INTO helmetharbour.`usage log` (`RFID NO.`, `Slot`, `Date & Time`) VALUES (?,?, NOW())");
    $stmt->bind_param("ss", $rfid, $slot);

    if ($stmt->execute()) {
        echo "Data updated successfully";
    } else {
        echo "Error updating data: " . $stmt->error;
    }

    $stmt->close();
} else {
    echo "Missing RFIDNUMBER or SLOT parameter.";
}

$conn->close();
?>
