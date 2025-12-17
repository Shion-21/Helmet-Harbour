#include <ESP8266WiFi.h>
#include <ESP8266HTTPClient.h>
#include <MFRC522.h>
#include "HX711.h"
#include <FastLED.h>
#define LED_PIN     D0
#define NUM_LEDS    1
#define BRIGHTNESS  10
#define LED_TYPE    WS2812
#define COLOR_ORDER GRB
CRGB leds[NUM_LEDS];
const char* ssid = "OPPO Reno7 Z 5G";
const char* password = "akinnaperam";
const char* SLOT = "A1";
#define SS_PIN D4
#define RST_PIN -1
#define Solenoid D3
#define DT  D2
#define SCK D8 
#define Reed D1
int reedsignal;
int ReedOnce = 0;
MFRC522 rfid(SS_PIN, RST_PIN);
int opened = 1;
int closed = 0;
static String RFIDNUM;
static int ScanOnceforlock = 0;
static bool access = true; 
bool WeightINIT;
static bool cardpresent = false;
double Helmet_weight, Helmet_weightINIT;
HX711 scale;
static bool accessonce, tareonce;


void ReedSecurity() {
  reedsignal = digitalRead(Reed);

  if (reedsignal == closed) {
    access = false;
    accessonce = true;

    if (!tareonce) {
      scale.tare();
      Helmet_weightINIT = scale.get_units(5);
      tareonce = true;
      Serial.println("TARED: " + String(Helmet_weightINIT));
    } else {
      double currentWeight = scale.get_units(5);
      Serial.println("Weight: " + String(currentWeight));
      const double WEIGHT_TOLERANCE = 5.0;
      if (abs(currentWeight - Helmet_weightINIT) > WEIGHT_TOLERANCE) {
        breachalarm(SLOT);
      }
    }
    ReedOnce = 0;
  } 
  else if (reedsignal == opened && !access) {
    if (ReedOnce == 0) {
      ReedOnce = 1;
      breachalarm(SLOT);
    }
  }
}

void Lock_mechanism(){
  if(access){
    if(!accessonce) return;
    digitalWrite(Solenoid, LOW);
    leds[0] = CRGB(255, 255, 0);
    FastLED.show();
    delay(5000);
    digitalWrite(Solenoid, HIGH);
    leds[0] = CRGB::Red;
    FastLED.show();
    accessonce = false;
    rfid.PCD_Init();
    return;
  }else{
    digitalWrite(Solenoid, HIGH);
    
    return;
  }
}

void WIFISET(){
  Serial.begin(115200);
    WiFi.begin(ssid, password);
  
    while (WiFi.status() != WL_CONNECTED) {
        Serial.println("Connecting to WiFi...");
        delay(4000);
    }
    Serial.println("Connected to WiFi");
}
void setup() {
    WIFISET();
    SPI.begin();      
    rfid.PCD_Init();
    scale.begin(DT, SCK);
    Serial.println("RFID module initialized!");
    pinMode(Solenoid, OUTPUT);
    digitalWrite(Solenoid, HIGH);
    pinMode(Reed, INPUT_PULLUP);
    scale.set_scale(2280.f);
    FastLED.addLeds<LED_TYPE, LED_PIN, COLOR_ORDER>(leds, NUM_LEDS);
    FastLED.setBrightness(BRIGHTNESS);
}
void LOCK(String masterRFID){
  String storedRFID = fetchRFID(SLOT);
  if ((RFIDNUM.equals(storedRFID)  || RFIDNUM.equals(masterRFID)) && !RFIDNUM.isEmpty()) {
    access = true;
    tareonce = false;
  }else{
    SendAttempts(RFIDNUM);
  }
}
void breachalarm(String SLOT){
  if (WiFi.status() == WL_CONNECTED) {
        String server = "http://192.168.42.96/esp/BreachAlarm.php";
        WiFiClient client;
        HTTPClient http;

        http.begin(client, server);
        http.addHeader("Content-Type", "application/x-www-form-urlencoded");

        String postData = "SLOT="+SLOT+"&SECURITY=Breached";
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
String fetchMaster() {
    
    if (WiFi.status() == WL_CONNECTED) {
        WiFiClient client;
        HTTPClient http;
        
        String url = "http://192.168.42.96/esp/fetchmaster.php";
        

        http.begin(client, url);
        http.setTimeout(800);
        int httpResponseCode = http.GET();

        if (httpResponseCode > 0) {
            String response = http.getString();
            Serial.println("triggered");
            return response;
        } else {
            Serial.println("Error fetching data");
            Serial.println("error 1");
            return "";
        }
        http.end();
        }
        Serial.println("error 2");
        return "";
    }

String fetchRFID(String slotNumber) {
    
    if (WiFi.status() == WL_CONNECTED) {
        WiFiClient client;
        HTTPClient http;
        
        String url = "http://192.168.42.96/esp/fetch.php";
        url += "?SLOT=" + slotNumber;

        http.begin(client, url);
        http.setTimeout(800);
        int httpResponseCode = http.GET();

        if (httpResponseCode > 0) {
            String response = http.getString();
            return response;
        } else {
            Serial.println("Error fetching data");
            Serial.println("error 1");
            return "";
        }
        http.end();
        }
        Serial.println("error 2");
        return "";
    }


String fetchRFIDCON(String slotNumber) {
    
    if (WiFi.status() == WL_CONNECTED) {
        WiFiClient client;
        HTTPClient http;
        
        String url = "http://192.168.42.96/esp/fetchRFIDCON.php";
        url += "?SLOT=" + slotNumber;

        http.begin(client, url);
        http.setTimeout(800);
        int httpResponseCode = http.GET();

        String response = http.getString();
        http.end();
        return response;
    }
    return "";
}


void senddata(String RFIDNUM, String SLOT, String RFIDset){
  if (WiFi.status() == WL_CONNECTED) {
        String server = "http://192.168.42.96/esp/Insert.php";
        WiFiClient client;
        HTTPClient http;

        http.begin(client, server);
        http.addHeader("Content-Type", "application/x-www-form-urlencoded");

        String postData = "RFIDNUMBER="+RFIDNUM+"&SLOT="+ SLOT+"&RFIDset=" +RFIDset;
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


void setRFID(){
  String response = fetchRFIDCON(SLOT);
  if (response.equals("0")){
      if (!RFIDNUM.isEmpty()) {
        String RFIDset = "1";
        
        senddata(RFIDNUM, SLOT, RFIDset);
        access = true;
      }
    }  
  }

void CardCheck() {
  ReedSecurity();

  if (!rfid.PICC_IsNewCardPresent()) {
    RFIDNUM = "";
    cardpresent = false;
    return;
  }

  if (!rfid.PICC_ReadCardSerial()) {
    return;
  }

  cardpresent = true;
  RFIDNUM = "";
  for (byte i = 0; i < rfid.uid.size; i++) {
    if (rfid.uid.uidByte[i] < 0x10) RFIDNUM += "0";
    RFIDNUM += String(rfid.uid.uidByte[i], HEX);
  }
  RFIDNUM.toUpperCase();
  
  SendUsage(RFIDNUM, SLOT);
  String masterkey = fetchMaster();
  if (RFIDNUM.equals(masterkey)){
  }else{
    String CardStatus = fetchStatus(RFIDNUM);
    if (!CardStatus.equals("Active")) return;
    
    if (!RFIDExist(RFIDNUM)) {
    setRFID();
  }
  }
  
  Serial.println("Here before lock"); 
  LOCK(masterkey);
}

void loop() {
  ensureWiFi();
  availabilitycheck();
  CardCheck();
  Lock_mechanism();
  delay(10);
}

bool RFIDExist(String RFIDNUM) {
    
    if (WiFi.status() == WL_CONNECTED) {
        WiFiClient client;
        HTTPClient http;
        
        String url = "http://192.168.42.96/esp/RFIDExist.php";
        url += "?RFIDNum=" + RFIDNUM;

        http.begin(client, url);
        http.setTimeout(800);
        int httpResponseCode = http.GET();

        String response = http.getString();
        http.end();
        if (response.indexOf("true") >= 0) {
        Serial.print("True");
        return true;
        } else {
        Serial.print("False");
        return false;
        
        }
        
    }
    return true;
}

String fetchStatus(String RFIDNUM) {
    
    if (WiFi.status() == WL_CONNECTED) {
        WiFiClient client;
        HTTPClient http;
        
        String url = "http://192.168.42.96/esp/FetchStatus.php";
        url += "?RFIDNUM=" + RFIDNUM;

        http.begin(client, url);
        http.setTimeout(800);
        int httpResponseCode = http.GET();

        String response = http.getString();
        http.end();
        return response;
    }
    return "";
}


void SendAttempts(String RFIDNUM){
  if (WiFi.status() == WL_CONNECTED) {
        String server = "http://192.168.42.96/esp/FailedAttempt.php";
        WiFiClient client;
        HTTPClient http;

        http.begin(client, server);
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

void SendUsage(String RFIDNUM, String SLOT){
  if (WiFi.status() == WL_CONNECTED) {
        String server = "http://192.168.42.96/esp/InsertUsage.php";
        WiFiClient client;
        HTTPClient http;

        http.begin(client, server);
        http.addHeader("Content-Type", "application/x-www-form-urlencoded");

        String postData = "RFIDNUM="+RFIDNUM+"&SLOT="+ SLOT;  
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
void ensureWiFi() {
    if (WiFi.status() != WL_CONNECTED) {
        Serial.println("Reconnecting WiFi...");
        WiFi.disconnect();
        WiFi.begin(ssid, password);
        unsigned long startAttemptTime = millis();
        while (WiFi.status() != WL_CONNECTED && millis() - startAttemptTime < 10000) {
            delay(500);
            Serial.print(".");
        }
        Serial.println(WiFi.status() == WL_CONNECTED ? "\nReconnected!" : "\nReconnect Failed!");
    }
}

void availabilitycheck(){
  String availability = fetchRFIDCON(SLOT);
  if (availability.equals("0")){
    leds[0] = CRGB::Green;
    FastLED.show();
  }else{
    leds[0] = CRGB::Red;
    FastLED.show();
  }

}

