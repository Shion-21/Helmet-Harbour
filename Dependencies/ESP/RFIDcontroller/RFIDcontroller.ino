#include <ESP8266WiFi.h>
#include <ESP8266HTTPClient.h>
#include <MFRC522.h>
const char* ssid = "MikMik's S24";
const char* password = "12345678";
#define SS_PIN D4
#define RST_PIN -1
MFRC522 rfid(SS_PIN, RST_PIN);
static String RFIDNUM;
bool RFID_ScanOnce = false;

void setup() {
    WIFISET();
    SPI.begin();      
    rfid.PCD_Init();

}

void loop() {
  CardCheck();
}


void CardCheck(){
  if (!rfid.PICC_IsNewCardPresent()) {
    RFID_ScanOnce = false;
    return;
  }
  if (!rfid.PICC_ReadCardSerial()) {
    return;
  }

  if(!RFID_ScanOnce){
  RFIDNUM = "";
  for (byte i = 0; i < rfid.uid.size; i++) {
    if (rfid.uid.uidByte[i] < 0x10) RFIDNUM += "0";
    RFIDNUM += String(rfid.uid.uidByte[i], HEX);
  }

  RFIDNUM.toUpperCase();
  senddata(RFIDNUM);
  RFID_ScanOnce = true;
  }
}

void senddata(String RFIDNUM){
  if (WiFi.status() == WL_CONNECTED) {
        String server = "http://192.168.199.184/esp/RFIDController.php";
        WiFiClient client;
        HTTPClient http;
        
        http.begin(client, server);
        http.setTimeout(1000);
        http.addHeader("Content-Type", "application/x-www-form-urlencoded");

        String postData = "RFIDNUMBER="+RFIDNUM;
        int httpResponseCode = http.POST(postData);

        if (httpResponseCode > 0) {
            String response = http.getString();
            Serial.println("Server Response: " + response);
        } else {
            Serial.println("Error sending request");
        }

        http.end();
    }
}

void WIFISET(){
  Serial.begin(921600);
  WiFi.begin(ssid, password);
    while (WiFi.status() != WL_CONNECTED) {
        Serial.println("Connecting to WiFi...");
        delay(5000);
        
    }
    Serial.println("Connected to WiFi");
}


