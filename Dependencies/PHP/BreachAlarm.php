<?php
$servername = "localhost";
$username = "root";
$password = "HelmetHarbour";
$dbname = "helmetharbour";

$conn = new mysqli($servername, $username, $password, $dbname);

$security = isset($_POST['SECURITY']) ? $_POST['SECURITY'] : '';
$slot = isset($_POST['SLOT']) ? $_POST['SLOT'] : '';
if (!empty($security) && !empty($slot)) {
    $stmt = $conn->prepare("UPDATE `helmet racks` SET `Security` = ?, `Alarm` = 1 WHERE `Rack Slot` = ?");
    $stmt->bind_param("ss", $security, $slot);

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
