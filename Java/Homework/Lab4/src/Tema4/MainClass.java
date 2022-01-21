package Tema4;

import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.util.Scanner;

import Tema4.Copiator.Format;
import Tema4.Echipament.Stare;
import Tema4.Imprimanta.Tiparire;
import Tema4.SistemDeCalcul.SO;

public class MainClass {

	static void pressKey() {
		Scanner scan = new Scanner("System.in");
		System.out.print("Press any key to continue");
		try {
			System.in.read();

		} catch (Exception e) {
		}

	}

	static void scrie(Object o, String fis) {
		try {
			FileOutputStream f = new FileOutputStream(fis);
			ObjectOutputStream oos = new ObjectOutputStream(f);
			oos.writeObject(o);
			oos.close();
			f.close();
		} catch (IOException e) {
			e.printStackTrace();
		}
	}

	static Object citeste(String fis) {
		try {
			FileInputStream f = new FileInputStream(fis);
			ObjectInputStream ois = new ObjectInputStream(f);
			Object o = ois.readObject();
			ois.close();
			f.close();
			return o;
		} catch (IOException | ClassNotFoundException e) {
			e.printStackTrace();
		}
		return null;
	}

	public static void main(String[] args) {
		Echipament[] array = new Echipament[10];
		Scanner scan = new Scanner(System.in);
		byte opt;
		int contor = 0;
		int nrInventar;
		try {
			File file = new File("echipamente.txt");
			Scanner myReader = new Scanner(file);
			String sir;
			while (myReader.hasNextLine()) {
				sir = myReader.nextLine();
				String[] s = sir.split(";");
				if (s[5].equals("imprimanta")) {
					Imprimanta imp = new Imprimanta(s[0], Integer.valueOf(s[1]), Integer.valueOf(s[2]), s[3],
							Stare.valueOf(s[4]), Integer.valueOf(s[6]), s[7], Integer.valueOf(s[8]),
							Tiparire.valueOf(s[9]));
					array[contor] = imp;
				} else if (s[5].equals("copiator")) {
					Copiator cop = new Copiator(s[0], Integer.valueOf(s[1]), Integer.valueOf(s[2]), s[3],
							Stare.valueOf(s[4]), Integer.valueOf(s[6]), Integer.valueOf(s[7]), Format.valueOf(s[8]));
					array[contor] = cop;
				} else if (s[5].equals("sistem de calcul")) {
					SistemDeCalcul sdc = new SistemDeCalcul(s[0], Integer.valueOf(s[1]), Integer.valueOf(s[2]), s[3],
							Stare.valueOf(s[4]), String.valueOf(s[6]), Float.valueOf(s[7]), Integer.valueOf(s[8]),
							SO.valueOf(s[9]));
					array[contor] = sdc;
				}
				contor++;
			}
			myReader.close();
		} catch (FileNotFoundException e) {
			e.printStackTrace();

		}
		do {
			System.out.println("\n1 -  Afisarea imprimantelor\n" + "2 -  Afisarea copiatoarelor\n"
					+ "3 -  Afisarea sistemelor de calcul\n" + "4 -  Modificarea starii în care se afla un echipament\n"
					+ "5 -  Setarea unui anumit mod de scriere pentru o imprimanta\n"
					+ "6 -  Setarea unui format de copiere pentru copiatoare\n"
					+ "7 -  Instalarea unui anumit sistem de operare pe un sistem de calcul\n"
					+ "8 -  Afisarea echipamentelor vandute\n"
					+ "9 -  Sa se realizeze doua metode statice pentru serializarea / deserializarea colectiei de obiecte în fisierul echip.bin \n");
			System.out.println("Dati optiunea: ");
			opt = scan.nextByte();
			switch (opt) {
			case 1:
				for (int i = 0; i < contor; i++) {
					if (array[i] instanceof Imprimanta)
						System.out.println(array[i]);
				}

				break;
			case 2:
				for (int i = 0; i < contor; i++) {
					if (String.valueOf(array[i].getClass()).contains("Copiator"))
						System.out.println(array[i]);
				}
				break;
			case 3:
				for (int i = 0; i < contor; i++) {
					if (array[i] instanceof SistemDeCalcul)
						System.out.println(array[i]);
				}
				break;
			case 4:
				System.out.println("Introduceti nr inventar al echipamentului a carui stare doriti sa o modificati: ");
				nrInventar = scan.nextInt();
				String stare;
				boolean flag = false;
				for (int i = 0; i < contor; i++) {
					if (array[i].getNrInventar() == nrInventar) {
						System.out.println("Alegeti starea: (achizitionat, expus, vandut)");
						stare = scan.next();
						array[i].setStare(Stare.valueOf(stare));
						flag = true;
						System.out.println("Modificare efectuata cu succes!");
						System.out.println(array[i]);
						break;
					}

				}
				if (flag == false) {
					System.out.println("Nu exista");
				}
				break;

			case 5:
				System.out.println(
						"Introduceti nr inventar al imprimantei al carei mod de scriere doriti sa il modificati: ");
				nrInventar = scan.nextInt();
				for (int i = 0; i < contor; i++) {
					if (array[i] instanceof Imprimanta && array[i].getNrInventar() == nrInventar) {
						System.out.println("Alegeti modul de scriere: (AlbNegru, Color)");
						stare = scan.next();
						((Imprimanta) array[i]).setTiparire(Tiparire.valueOf(stare));
						System.out.println("Modificare efectuata cu succes!");
						System.out.println(array[i]);
						break;
					}
				}
				break;
			case 6:
				System.out.println(
						"Introduceti nr inventar al copiatorului al carui format de copiere doriti sa il modificati: ");
				nrInventar = scan.nextInt();
				for (int i = 0; i < contor; i++) {
					if (array[i] instanceof Copiator && array[i].getNrInventar() == nrInventar) {
						System.out.println("Alegeti formatul de copiere: (A3, A4)");
						stare = scan.next();
						((Copiator) array[i]).setFormat(Format.valueOf(stare));
						System.out.println("Modificare efectuata cu succes!");
						System.out.println(array[i]);
						break;
					}
				}
				break;
			case 7:
				System.out.println(
						"Introduceti nr inventar al sistemului de calcul al carui sistem doriti sa il modificati: ");
				nrInventar = scan.nextInt();
				for (int i = 0; i < contor; i++) {
					if (array[i] instanceof SistemDeCalcul && array[i].getNrInventar() == nrInventar) {
						System.out.println("Alegeti sistemul de operare : (windows, linux)");
						stare = scan.next();
						((SistemDeCalcul) array[i]).setSistemOperare(SO.valueOf(stare));
						System.out.println("Modificare efectuata cu succes!");
						System.out.println(array[i]);
						break;
					}
				}
				break;
			case 8:
				for (int i = 0; i < contor; i++) {
					if (String.valueOf(array[i].getStare()) == "vandut")
						System.out.println(array[i]);
				}
				break;
			case 9:
				scrie(array, "echip.bin");
				Echipament[] e;
				e = (Echipament[]) citeste("echip.bin");
				for (Echipament p : e)
					System.out.println(p);
				break;

			default:
				break;
			}

			pressKey();

		} while (opt != 0);

		scan.close();
	}

}
