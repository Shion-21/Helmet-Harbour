<?php
$servername = "localhost";
$username = "root";
$password = "HelmetHarbour";
$dbname = "helmetharbour";


$conn = new mysqli($servername, $username, $password, $dbname);

$rfid = isset($_POST['RFIDNUMBER']) ? $_POST['RFIDNUMBER'] : '';
if (!empty($rfid)) {

    $stmt = $conn->prepare("UPDATE `rfid controller` SET `RFID scan` = ? WHERE `idRFID controller` = 1");
    $stmt->bind_param("s", $rfid);

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
