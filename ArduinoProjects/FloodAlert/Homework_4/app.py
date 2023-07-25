from flask import Flask, request
import serial
import time
import re
import smtplib, ssl
app = Flask(__name__)

ser = serial.Serial('COM7')
print(ser.name)
#.baudrate, .open(), .port

def send_leak_mail():
    # message = """S-a detectat o inundatie!"""
    # Important in Gmail, enable la POP3, IMAP si bifati https://myaccount.google.com/u/2/lesssecureapp 
    # context = ssl.create_default_context()
    # with smtplib.SMTP("smtp.gmail.com", 587) as server:
    #     server.starttls(context=context)
    #     server.login('psincretic@gmail.com', '*MonoMot2022*')
    #     server.sendmail('psincretic@gmail.com', "laurentiumot21@gmail.com", message)
    # server.quit()


    # with open('index.html', 'r+') as f:
    #     html_string = f.read()
    #     html_string=html_string.replace("23",'flood')
    #     return html_string
    return 'text'



@app.route('/')
def hello_world():
    text = 'Proiect Sincretic 2022'
    temp = '- Temperatura este '
    ser.flushInput()

    data_str=ser.readline().decode()
    data_str = data_str.replace(' ','') # Remove whitespace.
    data_str = data_str.replace('\r','') # Remove return.
    data_str = data_str.replace('\n','') # Remove new line. 
    if data_str.startswith('!'):  
        send_leak_mail()
        message = """S-a detectat o inundatie!"""
    # Important in Gmail, enable la POP3, IMAP si bifati https://myaccount.google.com/u/2/lesssecureapp 
        context = ssl.create_default_context()
        with smtplib.SMTP("smtp.gmail.com", 587) as server:
            server.starttls(context=context)
            server.login('psincretic@gmail.com', '*MonoMot2022*')
            server.sendmail('psincretic@gmail.com', "laurentiumot21@gmail.com", message)
        server.quit()
        return 'text'
        # with open('index.html', 'r+') as f:
        #     html_string = f.read()
        #     html_string=html_string.replace("23",'flood')
        #     return html_string
            
    else:
        with open('index.html', 'r') as f:
            html_string = f.read()
            return html_string
    

@app.route('/led_on')
def led_on():
    ser.write("1 A".encode())
    return "Am aprins ledul" + "\n" + '<button type="button" onclick="window.location.href=index.html;">Go back</button>'

@app.route('/led_off')
def led_off():
    ser.write("1 S".encode())
    return "Am stins ledul" + "\n" + '<button type="button" onclick="window.location.href=index.html;">Go back</button>'

 

html_str = """
 <p>ceva text</p>
"""

@app.route('/', defaults={'path': ''})
@app.route('/<path:path>')
def catch_all(path):
    default_value = '0'

    if "c" in path:
        data = request.args.get('color_form', default_value)
        pwm = data.split("#")[1]
        #pwm="#"+pwm
        ser.write(pwm.encode())
        return "You want path: %s" % pwm + "\n" + '<button type="button" onclick="window.location.href=index.html;">Go back</button>' +'   '+ path 

    #with open('index.html', 'r') as f:   varianta finala sa arate frumos
    #    html_string = f.read()
    #return html_string

    elif "m" in path:
        data = request.args.get('message_form', default_value)
        data="0"+data
        ser.write(data.encode())
        return "Message: %s has beem sent to serial Arduino" %data  + "\n" + '<button type="button" onclick="window.location.href=index.html;">Go back</button>'  +'   '+ path 

    elif "t" in path:
        while True:
            data_str=ser.readline().decode()
            data_str = data_str.replace(' ','') # Remove whitespace.
            data_str = data_str.replace('\r','') # Remove return.
            data_str = data_str.replace('\n','') # Remove new line. 
            if data_str.startswith('3'):  
                temp_value=str(data_str)
                with open('index.html', 'r+') as f:
                    html_string = f.read()
                    html_string=html_string.replace("23",temp_value.split(',')[1])
                    return html_string  
           

 
 

 