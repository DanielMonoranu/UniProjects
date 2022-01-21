package exemplu;

import java.io.BufferedReader;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.PrintStream;

public class Ex2 {

	public static void main(String[] args) throws NumberFormatException, IOException {

		String linie;
		BufferedReader flux_in;
		flux_in = new BufferedReader(new InputStreamReader(new FileInputStream("in.txt")));
		int suma = 0;
		int i = 0;
		int max = 0;
		int min = 10;

		while ((linie = flux_in.readLine()) != null) {
			int nr = Integer.parseInt(linie);
			suma = suma + nr;
			//System.out.println(linie);
			i++;
			if (nr > max)
				max = nr;
			if (nr < min)
				min = nr;

		}
		float medie = (float) suma / (float) i;

		PrintStream flux_out = new PrintStream("out.txt");
		flux_out.println("Suma este:" + suma);
		flux_out.println("Media aritmetica este" + medie);
		flux_out.println("Nr. maxim este: " + max + " iar cel mai mic este " + min);


	}

}
