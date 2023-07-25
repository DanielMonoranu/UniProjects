#include <EEPROM.h>
#include <LiquidCrystal.h>
LiquidCrystal lcd(12, 11, 5, 4, 3, 7);
#define BUTTON_OK A4
#define BUTTON_CANCEL A3
#define BUTTON_PREV A2
#define BUTTON_NEXT A1

//Controling the RGB LED
int redPin = 10;
int greenPin = 9;
int bluePin = 6;

int last_read=0; //for sending in 1 sec interval

int flood_sensor = 0;
//EEPROM message:
int addr = 0;
char msg[10][30];

bool control = false;

double temperature()
{
  double temp = analogRead(A5);
  temp = temp * 0.48828125;
  return temp;
}

void setColor(int red, int green, int blue) {
  analogWrite(redPin, red);
  analogWrite(greenPin, green);
  analogWrite(bluePin, blue);
}
void flood(){
  Serial.println("!Flood!");
}

enum Buttons {
  EV_OK,
  EV_CANCEL,
  EV_NEXT,
  EV_PREV,
  EV_NONE,
  EV_MAX_NUM
};

enum Menus {
  MENU_MAIN = 0,
  MENU_UNREAD_MESSAGES,
  MENU_READ_MESSAGES,
  MENU_DELETE_MESSAGES,
  MENU_CONTROL_MAN,
  MENU_CONTROL_AUTO,
  MENU_TEMPERATURE,
  MENU_FLOOD,
  MENU_MAX_NUM

};


Menus scroll_menu = MENU_MAIN;
Menus current_menu =  MENU_MAIN;

void state_machine(enum Menus menu, enum Buttons button);
Buttons GetButtons(void);
void print_menu(enum Menus menu);

typedef void (state_machine_handler_t)(void);

void print_menu(enum Menus menu)
{
  lcd.clear();
  switch (menu)
  {
    default:
      lcd.print("PROJECT DM & LM");
      break;
    case MENU_UNREAD_MESSAGES:
      lcd.print("UNREAD MESSAGES");
      break;
    case MENU_READ_MESSAGES:
      lcd.print("READ MESSAGES");
      break;
    case MENU_DELETE_MESSAGES:
      lcd.print("DELETE MESSAGES");
      break;
    case MENU_CONTROL_MAN:
      lcd.print("CONTROL MANUAL");
      break;
    case MENU_CONTROL_AUTO:
      lcd.print("CONTROL AUTOMAT");
      break;
    case MENU_FLOOD:
      lcd.print("FLOOD STATE");
      break;
    case MENU_TEMPERATURE:
      lcd.print("TEMPERATURE");

      break;


  }
  if (current_menu != MENU_MAIN  )
  {
    lcd.setCursor(0, 1);
    lcd.print("press <  >");
  }
}

void enter_menu(void)
{
  current_menu = scroll_menu;


}

void go_home(void)
{
  scroll_menu = MENU_MAIN;
  current_menu = scroll_menu;

}

void go_next(void)
{
  scroll_menu = (Menus) ((int)scroll_menu + 1);
  scroll_menu = (Menus) ((int)scroll_menu % MENU_MAX_NUM);
}

void go_prev(void)
{
  scroll_menu = (Menus) ((int)scroll_menu - 1);
  scroll_menu = (Menus) ((int)scroll_menu % MENU_MAX_NUM);
}

void show_temp(void) {
  lcd.clear();
  lcd.setCursor(0, 0);
  lcd.println( "Current Temp:     ");
  lcd.setCursor(0, 1);

  temperature();
  lcd.print(" ");
  lcd.print(temperature());
  delay(5000);


}


void show_unread_messages(void) {

  lcd.clear();
  EEPROM.get(addr, msg); //show the last 10 messages
  bool unread = false;
  bool flag = false;
  for (int i = 0; i < 10; i++)
  {

    int length = strlen(msg[i]);
    if (msg[i][length - 1] == '.') {
      unread = true;
      lcd.clear();
      flag = false;
      lcd.setCursor(0, 0);

      //lcd.print(i);
      //lcd.print(' ');

      for (int j = 1; j < strlen(msg[i]); j++)
      {
        if (j >= 16 && flag == false) {
          lcd.setCursor(0, 1);
          flag = true;
        }


        lcd.print(msg[i][j]);
      }
      delay(2000);
      Serial.println(msg[i]);
      msg[i][strlen(msg[i]) - 1] = ' ';
      EEPROM.put(addr, msg);
    }

  }
  if (unread == false) {
    Serial.println("nu avem mesaje");
    lcd.clear();
    lcd.setCursor(0, 0);
    lcd.print("No new messages!");
    delay(2000);
  }
}
void show_read_messages(void) {
  lcd.clear();
  bool flag = false;
  EEPROM.get(addr, msg); //show the last 10 messages
  for (int i = 0; i < 10; i++)
  {
    int length = strlen(msg[i]);
    if (msg[i][length - 1] == ' ') {
      lcd.clear();
      flag = false;
      lcd.setCursor(0, 0);

      //lcd.print(i);
      //lcd.print(' ');

      for (int j = 1; j < strlen(msg[i]); j++)
      {
        if (j >= 16 && flag == false) {
          lcd.setCursor(0, 1);
          flag = true;
        }


        lcd.print(msg[i][j]);
      }
      delay(2000);
      Serial.println(msg[i]);
    }

  }
}

void delete_messages(void) {
  lcd.clear();
  for (int i = 0 ; i < EEPROM.length() ; i++) {
    EEPROM.write(i, 0);
  }
  lcd.print("messages deleted");
  delay(2000);
}
void control_auto(void) {
  control = false;
  lcd.clear();
  lcd.print("Control set to");
  lcd.setCursor(0, 1);
  lcd.print("Auto");
  delay(2000);
}
void control_manual(void) {
  control = true;
  lcd.clear();
  lcd.print("Control set to");
  lcd.setCursor(0, 1);
  lcd.print("Manual");
  delay(2000);
}
void flood_state(void) {
  lcd.clear();
  flood_sensor = digitalRead(2);
  //lcd.print(flood_sensor);
  if (flood_sensor == 1) {
    lcd.print("no flood");
  }
  else if (flood_sensor == 0) {
    lcd.print("FLOOD!!!");
  }
  delay(2000);

}
state_machine_handler_t* sm[MENU_MAX_NUM][EV_MAX_NUM] =
{ //events: OK , CANCEL , NEXT, PREV
  {enter_menu, go_home, go_next, go_prev},  // MENU_MAIN
  {go_home, go_home, show_unread_messages, show_unread_messages},  //MENU_UNREAD_MESSAGES
  {go_home, go_home, show_read_messages, show_read_messages},      //MENU_READ_MESSAGES
  {go_home, go_home, delete_messages, delete_messages},            //MENU_DELETE_MESSAGES
  {go_home, go_home, control_manual, control_manual},                      //MENU_CONTROL_MAN
  {go_home, go_home, control_auto, control_auto},                  //MENU_CONROL_AUTO
  {show_temp, go_home, show_temp, show_temp},                      //MENU_TEMPERATURE
  {go_home, go_home, flood_state, flood_state},                    //MENU_FLOOD

};

void state_machine(enum Menus menu, enum Buttons button)
{
  sm[menu][button]();
}

Buttons GetButtons(void)
{
  enum Buttons ret_val = EV_NONE;
  if (digitalRead(BUTTON_OK))
  {
    ret_val = EV_OK;
  }
  else if (digitalRead(BUTTON_CANCEL))
  {
    ret_val = EV_CANCEL;
  }
  else if (digitalRead(BUTTON_NEXT))
  {
    ret_val = EV_NEXT;
  }
  else if (digitalRead(BUTTON_PREV))
  {
    ret_val = EV_PREV;
  }
  //Serial.print(ret_val);
  return ret_val;
}

void setup()
{
  DDRB = 1<<5;
  
  EEPROM.get(addr, msg);
  Serial.begin(9600);
  lcd.begin(16, 2);
  pinMode(redPin, OUTPUT);
  pinMode(greenPin, OUTPUT);
  pinMode(bluePin, OUTPUT);
  
  pinMode(BUTTON_OK, INPUT);
  digitalWrite(BUTTON_OK, LOW); // pull-down
  pinMode(BUTTON_CANCEL, INPUT);
  digitalWrite(BUTTON_CANCEL, LOW);
  pinMode(BUTTON_PREV, INPUT);
  digitalWrite(BUTTON_PREV, LOW);
  pinMode(BUTTON_NEXT, INPUT);
  digitalWrite(BUTTON_NEXT, LOW);
  
  pinMode(2, INPUT_PULLUP); //to read the state of the flood sensor
  attachInterrupt(digitalPinToInterrupt(2),flood,FALLING );
}

void loop()
{
  //MENU:
  volatile Buttons event = GetButtons();
  if (event != EV_NONE)
  {
    state_machine(current_menu, event);
  }
  print_menu(scroll_menu);
  delay(1000);

  //Sending temperature at 1 sec interval
 if (millis() > (last_read + 1000)) {   
    Serial.print("3, ");
    Serial.println(temperature());
    last_read = millis();
  }
 
  //entering a message in EEPROM:
  String aux;
  int i;
  if (Serial.available())
  {
    aux = Serial.readString();

    for ( i = 0; i < 10; i++)
    {
      if (strlen(msg[i]) == 0)
      {
        break;
      }
    }
    aux.toCharArray(&msg[i][0], 30);
    if (msg[i][0] == '0')
    {
      msg[i][0] = ' ';
      strcat(msg[i], " .");

      Serial.println("message received");
      Serial.println(msg[i]);
      EEPROM.put(addr, msg);
    }
    else if (aux.equals("1 A")) {
      PORTB |= (1 << 5);
    }
    else if (aux.equals("1 S")) {
       PORTB &= ~(1 << 5);
    }
    else   {

      char buf[50];
      aux.toCharArray(buf, 50);

      char redHex[4];
      char greenHEX[4];
      char blueHEX[4];

      redHex[0] = buf[0];
      redHex[1] = buf[1];
      greenHEX[0] = buf[2];
      greenHEX[1] = buf[3];
      blueHEX[0] = buf[4];
      blueHEX[1] = buf[5];

      setColor((int) strtol(redHex, 0, 16), (int) strtol(greenHEX, 0, 16), (int) strtol(blueHEX, 0, 16));
    }
  }

}
