package Tema3;

import java.io.File;
import java.io.FileNotFoundException;
import java.util.Arrays;
import java.util.Scanner;

public class Exercitiul3 {

	public static void main(String[] args) {
		String judet[] = new String[42];
		int i = 0;
		try {
			File f = new File("judete_in.txt");
			Scanner myReader = new Scanner(f);
			while (myReader.hasNextLine()) {
				judet[i] = myReader.nextLine();
				i++;
			}
			myReader.close();
		} catch (FileNotFoundException e) {
			e.printStackTrace();
		}
		Arrays.sort(judet);

		// diferite afisari:
		System.out.println(Arrays.toString(judet));

		// for(int j=0;j<judet.length;j++)
		// System.out.println(judet[j]);

		// for(String k:judet)
		// System.out.println(k);

		Scanner citire = new Scanner(System.in);
		System.out.println("Ce judet cautati? ");
		String judetCautat = citire.nextLine();
		System.out.println(Arrays.binarySearch(judet, judetCautat));
		citire.close();
	}

}
