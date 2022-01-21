package Tema3;

import java.util.Scanner;

public class Exercitiul2 {

	public static void main(String[] args) {

		Scanner scan = new Scanner(System.in);
		String sir1, sir2;
		byte p;
		System.out.println("Dati primul sir: ");
		sir1 = scan.nextLine();
		System.out.println("Dati al doilea sir: ");
		sir2 = scan.nextLine();
		StringBuilder sb = new StringBuilder(sir1);
		System.out.println("Introduceti pozitia: ");

		while ((p = scan.nextByte()) > sir1.length()) {
			System.out.println("Pozitia depaseste lungimea primului sir! \nDati alta valoare: ");
		}
		sb.insert(p, sir2);
		System.out.println(sb);

		System.out.println("Dati pozitiile de unde vom sterge:");
		int s1 = scan.nextByte();
		int s2 = scan.nextByte();
		System.out.println("Noul sir:");
		sb.delete(s1, s2);
		System.out.println(sb);
		scan.close();
	}
}
