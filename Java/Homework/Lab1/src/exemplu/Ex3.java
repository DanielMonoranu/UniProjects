package exemplu;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class Ex3 {

	public static void main(String[] args) throws IOException {
		BufferedReader flux = new BufferedReader(new InputStreamReader(System.in));
		String x;
		System.out.printf("Introdu nr:");
		x = flux.readLine();
		int contor=0;
		int nr = Integer.parseInt(x);
		System.out.print("Divizorii sunt: ");
		for (int i = 1; i <= nr; i++)
			if (nr % i == 0)
			{
				contor++;
				System.out.print(i+" ");
				
			}
		if(contor==2)
			System.out.print("\nNr "+nr+" este prim.");
			}

}
