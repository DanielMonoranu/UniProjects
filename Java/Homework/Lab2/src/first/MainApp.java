package first;

import java.io.BufferedReader;
import java.io.FileInputStream;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.PrintStream;

public class MainApp {

	public static void main(String[] args) throws IOException {

		System.out.println("Problema 1:");
		Parabola p1 = new Parabola(2, 3, 5);
		Parabola p2 = new Parabola(1, 4, 6);
		p1.afisare();
		p2.afisare();
		Parabola.calcul(p1, p2);
		System.out.println("\n\nProblema 2:");

		BufferedReader flux_in = new BufferedReader(new InputStreamReader(new FileInputStream("produse.txt")));
		BufferedReader tas = new BufferedReader(new InputStreamReader(System.in));
		String linie;
		int i = 0;
		Produs p[] = new Produs[10];
		Produs pmax = new Produs("0", "0", "0");
		Produs pmin = new Produs("0", "100", "0");

		while ((linie = flux_in.readLine()) != null) {

			String[] b = linie.split(";");

			p[i] = new Produs(b[0], b[1], b[2]);

			if ((p[i].getPret()) < pmin.getPret())
				pmin = new Produs(b[0], b[1], b[2]);

			if ((p[i].getPret()) > pmax.getPret())
				pmax = new Produs(b[0], b[1], b[2]);
			i++;
		}

		PrintStream flux_out = new PrintStream("Afisaj.txt");
		for (int j = 0; j < p.length; j++)
			if ((p[j] != null))
				flux_out.println(p[j].toString());
		flux_out.println("Produsul cel mai scump este: " + pmax.toString());
		flux_out.println("Produsul cel mai ieftin este: " + pmin.toString());

		System.out.print("Introduceti cantitatea:");
		String tastatura = tas.readLine();
		int canti = Integer.parseInt(tastatura);
		for (int k = 0; k < p.length; k++) {

			if (p[k] != null && p[k].getCantitate() < canti)
				System.out.println(p[k].toString());
		}

	}

}
