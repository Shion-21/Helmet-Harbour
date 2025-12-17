<?php
$servername = "localhost";
$username = "root";
$password = "HelmetHarbour";
$dbname = "helmetharbour";

// Reminder: This code is to be placed after checking if the RFID matches in the esp
$conn = new mysqli($servername, $username, $password, $dbname);


$rfid = isset($_POST['RFIDNUMBER']) ? $_POST['RFIDNUMBER'] : '';
if (!empty($rfid)) {

    $stmt = $conn->prepare(
	"UPDATE `rfids`
         SET 
            `Failed Attempts` = CASE 
                WHEN `Failed Attempts` < 3 THEN `Failed Attempts` + 1
                ELSE `Failed Attempts`
            END,
            `Status` = CASE
                WHEN `Failed Attempts` + 1 >= 3 THEN 'Locked'
                ELSE 'Active'
            END
         WHERE `RFID Number` = ?"
    );

    $stmt->bind_param("s", $rfid);

    if ($stmt->execute()) {
        echo "Attempts Logged";
    } else {
        echo "Error updating Attempts: " . $stmt->error;
    }

    $stmt->close();
} else {
    echo "Missing RFIDNUMBER";
}

$conn->close();
?>
