package Lab10;

import java.io.File;
import java.io.FileNotFoundException;
import java.time.LocalDate;
import java.time.LocalDateTime;
import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;
import java.util.stream.Collector;
import java.util.stream.Collectors;

public class Main {

	public static void main(String[] args) throws FileNotFoundException {

		File file1 = new File("in.txt");
		Scanner scan = new Scanner(file1);

		List<Angajat> angajati = new ArrayList<Angajat>();
		while (scan.hasNextLine()) {
			String sir = scan.nextLine();
			String[] s = sir.split(";");
			Angajat ang = new Angajat(s[0], s[1], LocalDate.parse(s[2]), Float.valueOf(s[3]));
			angajati.add(ang);
		}

		System.out.println("Angajatii sunt:");
		angajati.stream().forEach(System.out::println);
		System.out.print("\n");

		System.out.println("Angajatii cu salariul peste 2500ron:");
		angajati.stream().filter((f) -> f.getSalariu() > 2500).forEach(System.out::println);
		System.out.print("\n");

		System.out.println("Sefii sunt:");
		List<Angajat> sefi = new ArrayList<>();

		sefi = angajati.stream().filter((h) -> h.getPost().contains("sef") || h.getPost().contains("director")).filter(
				(h) -> h.getData().getMonthValue() >= 4 && h.getData().getYear() == LocalDateTime.now().getYear())
				.collect(Collectors.toList());
		sefi.stream().forEach(System.out::println);
		System.out.print("\n");
		System.out.println("Angajatii care nu au functie de conducere sunt:");

		angajati.stream().filter((f) -> !f.getPost().contains("sef") && !f.getPost().contains("director"))
				.sorted((a, b) -> {
					if (a.getSalariu() < b.getSalariu())
						return 1;
					else if (a.getSalariu() > b.getSalariu())
						return -1;
					else
						return 0;
				}).forEach(System.out::println);

		System.out.print("\n");
		System.out.println("Numele angajatilor:");

		List<String> numele = new ArrayList<String>();
		numele = angajati.stream().map(Angajat::getNume).map(String::toUpperCase).collect(Collectors.toList());
		numele.stream().forEach(System.out::println);

		System.out.print("\n");
		System.out.println("Salariile mai mici de 3000lei:");
		angajati.stream().map(Angajat::getSalariu).filter((f) -> f < 3000).forEach(System.out::println);
	}

}
