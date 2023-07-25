#include <LiquidCrystal.h>
LiquidCrystal lcd(12, 11, 5, 4, 3, 2);
#define BUTTON_OK 6
#define BUTTON_CANCEL 7
#define BUTTON_PREV 8
#define BUTTON_NEXT 9
#define ROOM_TEMP 24

volatile bool flag = false;
bool flag2 = true;
volatile double timpul;
volatile int timp_curent;

int analogPin = A5;
volatile int val = 0;
volatile int voltageValue;
volatile int T_Current;
double eroare = 0;
static double suma_erori = 0;
double eroare_anterioara = 0;
double derivativa = 0;

int ledPin = 10;  // LED connected to digital pin 10
int i;
int output;

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
  MENU_tincalzire,
  MENU_tmentinere,
  MENU_tracire,
  MENU_KP,
  MENU_KI,
  MENU_KD,
  MENU_TEMP,
  MENU_PROIECT,
  MENU_MAX_NUM

};

//DE MODIFICAT:
double temp = 31; //SET_POINT
double kp = 20;
double ki = 20;
double kd = 0.2;
double tincalzire = 120;
double tmentinere = 30;
double tracire = 180;
////

double moving_sp = ROOM_TEMP;
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
    case MENU_tincalzire:
      lcd.print("ti = ");
      lcd.print(tincalzire);
      break;
    case MENU_tmentinere:
      lcd.print("tm = ");
      lcd.print(tmentinere);
      break;
    case MENU_tracire:
      lcd.print("tr = ");
      lcd.print(tracire);
      break;
    case MENU_KP:
      lcd.print("KP = ");
      lcd.print(kp);
      break;
    case MENU_KI:
      lcd.print("KI = ");
      lcd.print(ki);
      break;
    case MENU_KD:
      lcd.print("KD = ");
      lcd.print(kd);
      break;
    case MENU_TEMP:
      lcd.print("TEMP = ");
      lcd.print(temp);
      break;
    case MENU_MAIN:
      lcd.setCursor(0, 0);
      lcd.print("Mot Laurentiu");
      lcd.setCursor(0, 1);
      lcd.print("Daniel Monoranu");
      break;
    case MENU_PROIECT:
      if (flag == false) {
        lcd.print("START:");
      }
      else if (flag == true) {
        val = analogRead(analogPin); // read the input pin
        voltageValue = val * (5000.0 / 1023.0);
        T_Current = voltageValue / 10;

        lcd.print("T*");
        lcd.print(T_Current);
        lcd.print(" S ");
        lcd.print(temp);
        afisare_timp();
      }
      break;
    default:
      lcd.print("Proiect Sincretic");
      break;
  }
  if (current_menu != MENU_MAIN && current_menu != MENU_PROIECT)
  {
    lcd.setCursor(0, 1);
    lcd.print("modifica");
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
  flag = false;
  flag2 = true;
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

void save_ti(void)
{
}

void save_tm(void)
{
}

void save_tr(void)
{
}

void save_kp(void)
{
}

void save_ki(void)
{
}

void save_kd(void)
{
}

void inc_ti(void)
{
  tincalzire++;
}

void inc_tm(void)
{
  tmentinere++;
}

void inc_tr(void)
{
  tracire++;
}

void inc_kp(void)
{
  kp++;
}

void inc_ki(void)
{
  ki++;
}

void inc_kd(void)
{
  kd++;
}

void dec_ti(void)
{
  tincalzire--;
}

void dec_tm(void)
{
  tmentinere--;
}

void dec_tr(void)
{
  tracire--;
}

void dec_kp(void)
{
  kp--;
}

void dec_ki(void)
{
  ki--;
}

void dec_kd(void)
{
  kd--;
}

void save_temp(void)
{
}

void inc_temp(void)
{
  temp++;
}

void dec_temp(void)
{
  temp--;
}
void start_proiect(void) {
  flag = true;
}

state_machine_handler_t* sm[MENU_MAX_NUM][EV_MAX_NUM] =
{ //events: OK , CANCEL , NEXT, PREV
  {enter_menu, go_home, go_next, go_prev},  // MENU_MAIN
  {go_home, go_home, inc_ti, dec_ti},       // MENU_tincalzire
  {go_home, go_home, inc_tm, dec_tm},       // MENU_tmentinere
  {go_home, go_home, inc_tr, dec_tr},       // MENU_tracire
  {go_home, go_home, inc_kp, dec_kp},       // MENU_KP
  {go_home, go_home, inc_ki, dec_ki},       // MENU_Ki
  {go_home, go_home, inc_kd, dec_kd},       // MENU_Kd
  {go_home, go_home, inc_temp, dec_temp},   // MENU_TEMP
  {start_proiect, go_home, start_proiect, start_proiect}, //MENU_PROIECT
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
  Serial.begin(9600);
  lcd.begin(16, 2);
  pinMode(6, INPUT);
  digitalWrite(6, LOW); // pull-down
  pinMode(7, INPUT);
  digitalWrite(7, LOW); // pull-down
  pinMode(8, INPUT);
  digitalWrite(8, LOW); // pull-down
  pinMode(9, INPUT);
  digitalWrite(9, LOW); // pull-down
}

void loop()
{

  volatile Buttons event = GetButtons();
  if (event != EV_NONE)
  {
    state_machine(current_menu, event);
  }
  analogWrite(10, PID_Output_Calculate());


  print_menu(scroll_menu);
  delay(1000);
}

void afisare_timp(void)
{

  if (flag2 == true) {

    timpul = millis();
    timp_curent = timpul / 1000;
    moving_sp = ROOM_TEMP;
    eroare = 0;
    suma_erori = 0;
    derivativa = 0;
    output = 0;
    eroare_anterioara = 0;

  }
  int min = 0;
  int sec = 0;

  lcd.setCursor(0, 1);
  lcd.print("P:");
  lcd.print(moving_sp);

  double now = millis();
  int total_seconds = now / 1000;
  Serial.println(total_seconds);

  if ((total_seconds - timp_curent)  <= tincalzire)
  {
    Serial.print("Incalzire: ");
    Serial.println(total_seconds);
    lcd.print(" inc: ");
    moving_sp = ROOM_TEMP + (temp - ROOM_TEMP) * (total_seconds - timp_curent) / tincalzire;
    Serial.print("Moving SP:");
    Serial.println(moving_sp);
  }
  else if ((total_seconds - timp_curent) <= (tincalzire + tmentinere))
  {
    Serial.print("Mentinere:");
    Serial.println(total_seconds);
    lcd.print(" men: ");
    Serial.print("Moving SP: ");
    Serial.println(moving_sp);

  }
  else if ((total_seconds - timp_curent) <= (tincalzire + tmentinere + tracire))
  {
    Serial.print("Racire:");
    Serial.println(total_seconds);
    lcd.print(" rac: ");
    moving_sp = ROOM_TEMP + (temp - ROOM_TEMP) - (temp - ROOM_TEMP) * (total_seconds - timp_curent) / (tincalzire + tmentinere + tracire);
    Serial.print("Moving SP: ");
    Serial.println(moving_sp);
  }
  else
  {
    lcd.print("Oprit: ");
    Serial.println(total_seconds);
  }

  lcd.print(total_seconds - timp_curent);
  flag2 = false;

}

int PID_Output_Calculate(void)
{

  val = analogRead(analogPin);  // read the input pin
  voltageValue = val * (5000.0 / 1023.0);
  T_Current = (voltageValue / 10);

  Serial.print("Temp:");
  Serial.print(T_Current);

  eroare = moving_sp - T_Current;
  suma_erori = suma_erori + eroare;
  derivativa = (eroare - eroare_anterioara);
  output = (kp * eroare) + (ki * suma_erori ) + (kd * derivativa);
  eroare_anterioara = eroare;

  Serial.print("kp:");
  Serial.println(kp);

  Serial.print("value PWM:");
  Serial.println(output);

  lcd.setCursor(0, 0);
  lcd.print("Temp = ");
  lcd.print(T_Current);

  if (output > 255)
  {
    output = 255;
  }
  else if (output < 0)
  {
    output = 0;
  }
  // lcd.setCursor(0, 1);
  // lcd.print(" PWM:");
  //lcd.print(output);
  return output;
}
