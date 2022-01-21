package Tema3;

import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileWriter;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class Exercitiul1 {

	public static void main(String[] args) throws IOException {
		
		List<Vers> lista = new ArrayList<Vers>();
	
			File file1 = new File("cantec_in.txt");
			Scanner myReader = new Scanner(file1);

			Scanner citire = new Scanner(System.in);
			System.out.println("Dati gruparea de litere cu care sa se termine sirul: ");
			String end = citire.nextLine();

			while (myReader.hasNextLine()) {
				Vers vers = new Vers(myReader.nextLine());
				vers.setVers(vers.AdaugaSteluta(end).toString());
				vers.setVers(vers.UpperVers().toString());
				System.out.println(vers);
				lista.add(vers);
			}
			myReader.close();
			citire.close();
		
		

	
			FileWriter myWriter = new FileWriter("cantec_out.txt");
			for (int i = 0; i < lista.size(); i++) {
				myWriter.write(lista.get(i).toString() + "\n");
			}

			System.out.println("\nScriere efectuata cu succes.");
			myWriter.close();
		
		}
	}

