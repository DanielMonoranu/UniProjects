package Tema5_2;

import java.io.File;
import java.io.FileNotFoundException;
import java.util.ArrayList;
import java.util.Collections;
import java.util.Comparator;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.Scanner;

public class MainCarte {

	public static void main(String[] args) {
		Map<Integer, Carte> map = new HashMap<Integer, Carte>();

		try {
			File f = new File("carte_in.txt");
			Scanner myReader = new Scanner(f);
			String read;
			while (myReader.hasNext()) {
				read = myReader.nextLine();
				String[] sir = read.split("; ");
				map.put(Integer.valueOf(sir[0]), new Carte(sir[1], sir[2], Integer.parseInt(sir[3])));
			}
			myReader.close();
		} catch (FileNotFoundException e) {
			e.printStackTrace();
		}

		// Afisare Map
		for (var key : map.entrySet())
			System.out.println(key);

		List<Carte> lista = new ArrayList<Carte>();
		for (var key : map.values()) {
			lista.add(key);
		}
		for (var l : lista)
			System.out.println(l);

		Collections.sort(lista, new ComparaNume());
		System.out.println(lista);
	}
}

class ComparaNume implements Comparator {
	@Override
	public int compare(Object o1, Object o2) {
		return (((Carte) o1).getTitlu().compareTo(((Carte) o2).getTitlu()));
	}
}
