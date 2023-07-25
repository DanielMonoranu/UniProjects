//Pt comunicatia seriala:
#define FOSC 16000000 // viteza clock
#define BAUD 9600  //alta viteza 19200
#define MYUBRR FOSC/16/BAUD-1

void USART_Init(unsigned int ubrr)
{
  //set baud rate
  UBRR0H = (unsigned char)(ubrr >> 8);
  UBRR0L = (unsigned char)ubrr;
  //enable recevier and transmitter
  UCSR0B = (1 << RXEN0) | (1 << TXEN0) | (1 << RXCIE0);
  //set frame format:sdata,2stop bit
  UCSR0C = (1 << USBS0) | (3 << UCSZ00);
}

void USART_transmit(unsigned char data)
{
  while (!(UCSR0A & (1 << UDRE0))); //asteptap cat e gol
  UDR0 = data;

}
unsigned char USART_Receive(void)
{
  while (!(UCSR0A & (1 << RXC0))); //asteptam
  return UDR0;
}

//-----------------------------------------------------------------------------

volatile int temp_q;
#define HISTEREZIS (0.5)
#define TEMP_SET_POINT (35)
volatile int t;


//Pt Convertor analog numeric:
void ADC_Init() {
  ADCSRA |= 1 << ADEN; // Alimentarea perifericului.
  ADCSRA |= 1 << ADIE; // Pornim intreruperile ADC.
  ADMUX |= 1 << REFS0; // Setam ca referinta 5V.
  ADCSRA |= 1 << ADSC; // Pornim prima conversie.
}


int main()
{
  ADC_Init();
  USART_Init(MYUBRR);

  //PT PWM:
  TCCR0A |= 1 << COM0A1; // OC0A Non-inverting mode FAST-PWM
  TCCR0A |= 1 << WGM01 | 1 << WGM00; // Selectam modul FAST-PWM
  TCCR0B |= 1 << CS00 | 1 << CS01; // Selectam prescaler 1024
  //-----------------------------------------------------------------------------

  //Pt Timer:
  TCCR1B |= 1 << CS10 | 1 << CS12;  //prescaler de 1024
  TIMSK1 |= 1 << TOIE1;  //intrerupere overflow
  TCNT1 = 49910;  //val_max-f_CPU/Prescaler

  //-----------------------------------------------------------------------------

  sei(); //pornim intreruperile la nivelul microntrolerului
  DDRB |= 0xFF;
  DDRD |= 0xFF;

  while (1)
  {

    //ledul cu dimming cu PWM:
    for (int i = 0; i <= 256; i++) {
      OCR0A = i;
      _delay_ms(5);
    }

    for (int i = 255; i > 0; i--) {
      OCR0A = i;
      _delay_ms(5);
    }

  }
}

//Rutina pt timer:
ISR(TIMER1_OVF_vect)
{
  float voltage = 0;
  voltage = (temp_q * 5) / 1023.0;
  float temperatura = 0;
  temperatura = voltage / 0.01;
  char buf[100];
  t = temperatura;
  int t2 = temperatura * 100;

  memset(buf, 0, sizeof(buf));
  sprintf(buf, "Temperatura este %d.%d°C\n", t2 / 100, t2 % 100);
  for (int i = 0; i < strlen(buf); i++)
  {
    USART_transmit(buf[i]);
  }

  if ((TEMP_SET_POINT + HISTEREZIS) < t)
  {
    PORTB &= ~(1 << 4); //stingem led
  }
  else if (t < (TEMP_SET_POINT - HISTEREZIS))
  {
    PORTB |= (1 << 4); //aprindem led
  }
  //LED care palpaie:
  PORTB ^= (1 << PB1);
  if (PORTB & (1 << PB1))
  {
    PORTB &= ~((1 << 2) | (1 << 5));
    PORTD &= ~((1 << 2) | (1 << 3) | (1 << 4));

    PORTB |= (1 << 3) | (1 << 5);
    PORTD |= (1 << 2) | (1 << 4); //M


  }
  else if (!(PORTB & (1 << PB1)))
  {
    PORTB &= ~((1 << 3) | (1 << 5));
    PORTD &= ((1 << 2) | (1 << 4));
    PORTB |= (1 << 2) | (1 << 5);
    PORTD |= (1 << 2) | (1 << 3) | (1 << 4); //D


  }
  TCNT1 = 49910;
}
//-----------------------------------------------------------------------------
ISR(USART_RX_vect)   //rutina pt comunicatia seriala
{
  char var = USART_Receive();
  if (var == 'A')
  {
    PORTB |= (1 << PB0);
  }
  else if (var == 'S')
  {
    PORTB &= ~(1 << PB0);
  }
}
//-----------------------------------------------------------------------------
ISR(ADC_vect)  //rutina pentru CAN
{
  temp_q = ADC;

  ADCSRA |= 1 << ADSC;
}
