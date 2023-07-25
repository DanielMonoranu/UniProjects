import smtplib, ssl

# s = smtplib.SMTP('smtp.gmail.com', 587)

# mail_id = "psincretic@gmail.com"
# r_mail_id = "laurentiumot21@gmail.com"
# password = "*MonoMot2022*"

# s.starttls()

# s.login(mail_id, password)

# message = 'Hi Veer bhai kaise hain aap?'

# s.sendmail(mail_id, r_mail_id, message)

# s.quit()

message = """!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!"""
	# Important in Gmail, enable la POP3, IMAP si bifati https://myaccount.google.com/u/2/lesssecureapp 
context = ssl.create_default_context()
with smtplib.SMTP("smtp.gmail.com", 587) as server:
	server.starttls(context=context)
	server.login('psincretic@gmail.com', '*MonoMot2022*')
	server.sendmail('psincretic@gmail.com', "laurentiumot21@gmail.com", message)
server.quit()