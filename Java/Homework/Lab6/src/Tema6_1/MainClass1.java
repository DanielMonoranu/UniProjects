package Tema6_1;

import java.util.Scanner;

//
public class MainClass1 {
	public static void main(String[] args) throws ExceptiaMea {
		Scanner sc = new Scanner(System.in);
		int nr1, nr2;
		boolean flag = false;
		do {
			try {
				System.out.println("Dati nr1: ");
				nr1 = sc.nextInt();
				System.out.println("Dati nr2: ");
				nr2 = sc.nextInt();
				Compara.Comparare(nr1, nr2);
				flag = true;
				System.out.println("Secventa este corecta!");
			} catch (ExceptiaMea e) {
				System.out.println(e);
			}
		} while (!flag);
		sc.close();
	}
}
