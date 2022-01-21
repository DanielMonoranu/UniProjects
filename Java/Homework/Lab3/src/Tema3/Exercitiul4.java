package Tema3;

import java.io.File;
import java.io.FileNotFoundException;
import java.util.ArrayList;
import java.util.Collections;
import java.util.Comparator;
import java.util.List;
import java.util.Scanner;

public class Exercitiul4 {

	public static void main(String[] args) throws FileNotFoundException {
		List<Melodie> melodie = new ArrayList<Melodie>();
		File f = new File("melodie_in.txt");
		Scanner scan = new Scanner(f);

		while (scan.hasNextLine()) {
			String[] linie = scan.nextLine().split("; ");
			Melodie e = new Melodie(linie[0], linie[1], linie[2], Integer.parseInt(linie[3]));
			melodie.add(e);

		}
		scan.close();
		System.out.println("...................AFISARE:...................");
		for (Melodie i : melodie)
			System.out.println(i.toString());

		System.out.println("...................AFISARE CLASAMENT:...................");
		Collections.sort(melodie, new ComparaViz());
		for (Melodie i : melodie)
			System.out.println(i.toString());
		System.out.println("...................AFISARE MELODII ARTIST:...................");
		System.out.println("Dati numele artistului:");

		String artist = new Scanner(System.in).nextLine();

		for (Melodie i : melodie) {
			if (artist.equals(i.getNume_artist())) {
				System.out.println(i.toString());
			}
		}

	}
}

class ComparaViz implements Comparator<Melodie> {
	@Override
	public int compare(Melodie o1, Melodie o2) {

		if (o1.getNumar_vizualizari_youtube() < o2.getNumar_vizualizari_youtube())
			return 1;
		else if (o1.getNumar_vizualizari_youtube() > o2.getNumar_vizualizari_youtube())
			return -1;
		else
			return 0;
	}
}