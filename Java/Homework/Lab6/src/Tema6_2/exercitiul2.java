package Tema6_2;

import java.util.Scanner;

public class exercitiul2 {

	public static void main(String[] args) {
		Scanner sc = new Scanner(System.in);
		String a;
		String b;
		boolean flag;
		do {
			flag = false;
			try {
				System.out.println("Dati primul nr: ");
				a = sc.next();
				do {
					try {
						System.out.println("Dati al doilea nr: ");
						b = sc.next();
						System.out.println("Rezultatul impartirii este " + (Integer.valueOf(a) / Integer.valueOf(b)));
						flag = true;
					} catch (ArithmeticException e) {
						System.out.println(e);
					}
				} while (!flag);

			} catch (NumberFormatException e) {
				System.out.println("Acesta nu este un numar\n" + e);
			}

		} while (!flag);
		sc.close();
	}

}
