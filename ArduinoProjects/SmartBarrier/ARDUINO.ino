//SENSORS:
#define SENSORPIN_ENTRANCE 6
#define SENSORPIN_EXIT 5
int sensorStateEntrance = 0, lastStateEntrance = 0; // variables for reading the pushbutton status
int sensorStateExit = 0, lastStateExit = 0;

//FLAGS:
bool gate = false; // a flag to ensure that the gate closes only once
//flags to determine which way a car moves through the barriers:
bool entranceSense = false;
bool exitSense = false;


//LEDs:
#define greenpin A0
#define yellownpin A1
#define bluepin A2
#define redpin A3

//BLUETOOTH
#include <SoftwareSerial.h>
SoftwareSerial mySerial(10, 11); // TX,RX

//SERVOMOTOR:
#include <Servo.h>
Servo myservo;
int pos = 0;

String aux;  //string to comunicate with server and bluetooth

bool function() {
  //1-car with its register code
  //2-pedestrian
  //3-profile update
  //4-activity report

  while (mySerial.available() == 0) {
    //Wait for user input
  }

  aux = mySerial.readStringUntil('\n');
  //Serial.println(aux);
  if (aux.startsWith("1")) {
    String sent = aux.substring(2, 18);
    Serial.println(sent);
    Serial.println("The code is valid?");
    while (Serial.available() == 0) {
    }
    String aux2 = Serial.readStringUntil('\n');
    if (aux2 == "true") {
      mySerial.println("Code valid. Go!");
      digitalWrite(greenpin, HIGH);
      return true;
    }
    else {
      mySerial.println("Code invalid. You can't go!");
      digitalWrite(redpin, HIGH);
      return false;
    }
  }
  else if (aux.startsWith("2")) {
    mySerial.println("Pedestrian walking!");
    Serial.println("Pedestrian walking!");
    
    return false;
  }

  else if (aux.startsWith("3")) {
    String s1 = "Mandache/Sergiu/IT/GJ00MOR/10:00-18:00";
    String s2 = "Ridicheanu/Alexandrina/HR/IS08HAI/9:00-20:00";
    mySerial.println(s1);
    return false;
  }
  else if (aux.startsWith("4")) {
    String s3 = "01;10:00;18:00/02;10:00;19:00";
    String s4 = "01;8:00;19:00/02;9:00;20:00";
    mySerial.println(s3);
    return false;

  }
  else {
    Serial.println("Nothing sent");
    return false;
  }

}


void setup() {
  // Open serial communications and wait for port to open:
  Serial.begin(38400);
  mySerial.begin(38400);
  //Serial.println("Goodnight moon!\n");
  //mySerial.println("Hello, world?");

  myservo.attach(9);  // attaches the servo on pin 9 to the servo object
  myservo.write(0);

  //for light barriers:
  pinMode(SENSORPIN_ENTRANCE, INPUT);
  digitalWrite(SENSORPIN_ENTRANCE, HIGH); // turn on the pullup
  pinMode(SENSORPIN_EXIT, INPUT);
  digitalWrite(SENSORPIN_EXIT, HIGH); // turn on the pullup

  //for LEDs:
  pinMode(bluepin, OUTPUT);
  pinMode(greenpin, OUTPUT);
  pinMode(yellownpin, OUTPUT);
  pinMode(redpin, OUTPUT);
}

void loop() {
  //if the arduino its connected to Ethernet
  digitalWrite(yellownpin, HIGH);

  // read the state of the sensors value:
  sensorStateEntrance = digitalRead(SENSORPIN_ENTRANCE);
  sensorStateExit = digitalRead(SENSORPIN_EXIT);

  // check if the sensor beam is broken
  // if it is, the sensorState is LOW

  //the car is between the entrance light barriers:
  if (sensorStateEntrance == LOW) {
    Serial.println("Someone in entrance");
    if ( gate == false )
      if (pos == 0)
        if (function() == true)
          for (pos = 0; pos < 180; pos += 1) { // goes from 0 degrees to 180 degrees in steps of 1 degree
            myservo.write(pos);              // tell servo to go to position in variable 'pos'
            delay(15);
            digitalWrite(bluepin, HIGH);
          }


    entranceSense = true;
    gate = true;

  }


  //the car is between the exit light barriers:
  if (sensorStateExit == LOW) {
    Serial.println("Someone in exit!");

    if ( gate == false)
      if (pos == 0)
        if (function() == true)
          for (pos = 0; pos < 180; pos += 1) { // goes from 0 degrees to 180 degrees in steps of 1 degree
            myservo.write(pos);              // tell servo to go to position in variable 'pos'
            delay(15);
            digitalWrite(bluepin, HIGH);
          }


    exitSense = true;
    gate = true;

  }
  else {
    //no car is between the barriers:
    //Serial.println("else");
  }

  // when a car just came out the entrance:
  if (sensorStateEntrance && !lastStateEntrance) {
    Serial.println("No one at entrance!");
    gate = false;
    if (pos == 180 && exitSense == true) {
      for (pos = 180; pos > 0; pos -= 1) {
        myservo.write(pos);
        delay(15);
        digitalWrite(bluepin, HIGH);

      }

      entranceSense = false;
    }

    exitSense = false;
    digitalWrite(bluepin, LOW);
    digitalWrite(greenpin, LOW);
    digitalWrite(redpin, LOW);

  }

  // when a car just came out the exit:
  if (sensorStateExit && !lastStateExit) {
    gate = false;
    Serial.println("No one at exit! ");
    if (pos == 180 && entranceSense == true) {
      for (pos = 180; pos > 0; pos -= 1) {
        myservo.write(pos);
        delay(15);
        digitalWrite(bluepin, HIGH);
      }

      exitSense = false;
    }

    entranceSense = false;
    digitalWrite(bluepin, LOW);
    digitalWrite(greenpin, LOW);
    digitalWrite(redpin, LOW);

  }

  lastStateEntrance = sensorStateEntrance;
  lastStateExit = sensorStateExit;

}
