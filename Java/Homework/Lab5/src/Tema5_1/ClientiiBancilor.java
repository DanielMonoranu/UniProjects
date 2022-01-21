package Tema5_1;

import java.io.IOException;
import java.util.Calendar;
import java.util.Scanner;
import java.util.Vector;


public class ClientiiBancilor {

	private static void pressKey() {
		System.out.println("Press Enter to continue");
		try {
			System.in.read();
		} catch (Exception e) {
		}
	}

	public static void main(String[] args) throws IOException {
		Vector<Banca> banci = new Vector<Banca>();
		Scanner scan = new Scanner(System.in);
		String numeBanca, numeClient, numeAdresa, nrCont, moneda;
		float suma;

		int opt;
		String opt2;
		boolean k;
		do {

			System.out.print(
					"1.Adaugare banci, clienti sau conturi\n2.Afisarea tuturor bancilor\n3.Depunerea unei sume intr-un cont\n4.Extragerea sumei dintr-un cont\n5.Transfer de bani intre 2 conturi\n0.Iesire");
			opt = scan.nextInt();
			switch (opt) {
			case 1:
				do {
					System.out.println("Introduceti optiunea: (banca/client/cont). Pentru iesire introduceti gata.");
					opt2 = scan.next();
					switch (opt2) {

					case "banca":
						System.out.println("Introduceti banca:");
						k = true;
						numeBanca = scan.next();
						for (var i : banci) {
							if (numeBanca.equals(i.getDenumire_banca())) {
								System.out.println("Banca deja exista!");
								k = false;
							}
						}
						if (k == true) {
							banci.add(new Banca(numeBanca));
							System.out.println("Banca " + numeBanca + " a fost introdusa!");

						}
						break;
					case "client":
						k = true;
						System.out.println("La ce banca doriti sa introduceti un client:");
						numeBanca = scan.next();
						for (var i : banci) {
							if (numeBanca.equals(i.getDenumire_banca())) {
								System.out.println("Numele clientului:");
								numeClient = scan.next();
								System.out.println("Adresa clientului:");
								numeAdresa = scan.next();
								Client client = new Client(numeClient, numeAdresa);
								i.AdaugaClient(client);
								System.out.println("Clientul " + numeClient + " a fost introdus!");
								k = false;
							}
						}
						if (k == true)
							System.out.println("Banca nu exista!");
						break;
					case "cont":
						k = false;
						System.out.println("La ce banca doriti sa adaugati un cont:");
						numeBanca = scan.next();
						System.out.println("La ce client doriti sa adaugati un cont:");
						numeClient = scan.next();
						for (var i : banci)
							if (numeBanca.equals(i.getDenumire_banca()))
								for (Client v : i.getLista())
									if (numeClient.equals(v.getNume())) {
										System.out.println("Introduceti nr. contului:");
										nrCont = scan.next();
										System.out.println("Introduceti suma:");
										suma = scan.nextFloat();
										System.out.println("Introduceti moneda:(RON/EUR)");
										moneda = scan.next();
										Calendar cal = Calendar.getInstance();
										ContBancar cb = new ContBancar(nrCont, suma, moneda, cal, cal);
										v.adaugaCont(cb);
										k = true;
										System.out.println("Contul a fost introdus!");

									}
						if (k == false)
							System.out.println("Contul nu a fost introdus!");
						break;

					default:
						opt2 = "gata";
						break;
					}
				} while (opt2 != "gata");
				break;

			case 2:
				System.out.println(banci);
				break;
			case 3:
				k = false;
				System.out.println("Introduceti banca unde se afla clientul dorit:");
				numeBanca = scan.next();
				System.out.println("Introduceti clientul la care doriti sa adaugati suma:");
				numeClient = scan.next();
				System.out.println("Introduceti nr.contului dorit:");
				nrCont = scan.next();
				for (var i : banci)
					if (numeBanca.equals(i.getDenumire_banca()))
						for (Client v : i.getLista())
							if (numeClient.equals(v.getNume()))
								for (ContBancar c : v.getConturi())
									if (nrCont.equals(c.getNumarCont())) {
										System.out.print("Introdu suma:");
										suma = scan.nextFloat();
										c.depunere(suma);
										System.out.println("Suma depusa cu succes!");
										k = true;
									}
				if (k == false) {
					System.out.print("Nu s-a putut depunde suma\n");
				}
				break;
			case 4:
				k = false;
				System.out.println("Introduceti banca unde se afla clientul dorit:");
				numeBanca = scan.next();
				System.out.println("Introduceti clientul la care doriti sa adaugati suma:");
				numeClient = scan.next();
				System.out.println("Introduceti nr.contului dorit:");
				nrCont = scan.next();
				for (var i : banci)
					if (numeBanca.equals(i.getDenumire_banca()))
						for (Client v : i.getLista())
							if (numeClient.equals(v.getNume()))
								for (ContBancar c : v.getConturi())
									if (nrCont.equals(c.getNumarCont())) {
										System.out.print("Introdu suma:");
										suma = scan.nextFloat();
										c.extragere(suma);
										System.out.println("Suma extrasa cu succes!");
										k = true;
									}
				if (k == false) {
					System.out.print("Nu s-a putut extrage suma\n");
				}
				break;
			case 5:
				float nrBani = 0;
				k = false;
				System.out.print("Introdu banca de la cine trimite banii");
				numeBanca = scan.next();
				System.out.println("Introduceti clientul de la care luam banii");
				numeClient = scan.next();
				System.out.println("Introduceti nr.contului dorit:");
				nrCont = scan.next();
				for (var i : banci)
					if (numeBanca.equals(i.getDenumire_banca()))
						for (Client v : i.getLista())
							if (numeClient.equals(v.getNume()))
								for (ContBancar c : v.getConturi())
									if (nrCont.equals(c.getNumarCont())) {
										System.out.print("Introdu suma:");
										suma = scan.nextFloat();
										c.extragere(suma);
										nrBani = suma;
										System.out.println("Suma extrasa cu succes!");
										k = true;
									}
				if (k == false) {
					System.out.print("Nu s-a putut extrage suma\n");
				}

				System.out.print("Introdu banca cui trimiteti banii");
				numeBanca = scan.next();
				System.out.println("Introduceti clientul care primeste banii");
				numeClient = scan.next();
				System.out.println("Introduceti nr.contului dorit:");
				nrCont = scan.next();
				for (var i : banci)
					if (numeBanca.equals(i.getDenumire_banca()))
						for (Client v : i.getLista())
							if (numeClient.equals(v.getNume()))
								for (ContBancar c : v.getConturi())
									if (nrCont.equals(c.getNumarCont())) {
										c.depunere(nrBani);

										System.out.println("Suma depusa cu succes!");
										k = true;
									}
				if (k == false) {
					System.out.print("Nu s-a putut extrage suma\n");
				}
				break;
			default:
				System.out.println("Optiune invalida");

				break;
			case 0:
				System.out.println("Multumim. La revedere!");

				opt = 0;
				break;
			}
			pressKey();
		} while (opt != 0);
		scan.close();
	}

}
