package Tema6_3;

import java.time.LocalDate;
import java.time.Period;
import java.util.Calendar;
import java.util.Scanner;

import Tema6_1.ExceptiaMea;

public class MainClass3 {

	static void Data(String cnp) {
		Calendar c = Calendar.getInstance();
		int an;
		if (Integer.valueOf(cnp.substring(0, 1)) < 3)
			an = 1900 + Integer.valueOf(cnp.substring(1, 3));
		else if (Integer.valueOf(cnp.substring(0, 1)) > 4)
			an = 2000 + Integer.valueOf(cnp.substring(1, 3));
		else
			an = 1800 + Integer.valueOf(cnp.substring(1, 3));
		int zi, luna;
		zi = Integer.valueOf(cnp.substring(5, 7));
		luna = Integer.valueOf(cnp.substring(3, 5));
		LocalDate dataNasterii = LocalDate.of(an, luna, zi);
		Period varsta = Period.between(dataNasterii, LocalDate.now());
		System.out.println("Data nasterii: " + dataNasterii);
		System.out.println("Varsta: " + varsta.getYears() + " ani, " + varsta.getMonths() + " luni si "
				+ varsta.getDays() + "(de)zile");
	}

	public static void main(String[] args) {
		Scanner scan = new Scanner(System.in);
		String nume, cnp;
		System.out.println("Nume: ");
		nume = scan.next();
		boolean gata = false;
		do {
			try {
				System.out.println("CNP: ");
				cnp = scan.next();
				ValidareCNP.NrCifre(cnp);
				ValidareCNP.Caractere(cnp);
				ValidareCNP.Altele(cnp);
				gata = true;
				System.out.println("Nume: " + nume);
				Data(cnp);
			} catch (ExceptiaMea e) {
				System.out.println(e);
			}
		} while (!gata);

	}

}
