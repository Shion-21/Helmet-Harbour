<?php
$servername = "localhost";
$username = "root";
$password = "HelmetHarbour";
$dbname = "helmetharbour";

$conn = new mysqli($servername, $username, $password, $dbname);


$rfid = isset($_POST['RFIDNUMBER']) ? $_POST['RFIDNUMBER'] : '';
$slot = isset($_POST['SLOT']) ? $_POST['SLOT'] : '';
$RFIDset = isset($_POST['RFIDset']) ? $_POST['RFIDset'] : '';
if (!empty($rfid) && !empty($slot)) {

    $stmt = $conn->prepare("UPDATE `helmet racks` SET `RFID #` = ?, RFIDSet = ?, `Time Start` = CURRENT_TIME() WHERE `Rack Slot` = ?");
    $stmt->bind_param("sss", $rfid, $RFIDset, $slot);

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
