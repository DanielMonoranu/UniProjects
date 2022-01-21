package exemplu;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class Ex1 {

	public static void main(String[] args) throws IOException {

		String lungime, latime;
		System.out.print("lungime=");
		BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));
		lungime = reader.readLine();

		int x = Integer.parseInt(lungime);
		System.out.print("Latime=");
		latime = reader.readLine();
		int y = Integer.parseInt(latime);
		int perimetru, arie;
		perimetru = 2 * (x + y);
		arie = x * y;
		System.out.print("Perimetrul este: " + perimetru + "\nAria este: " + arie);
	}

}
