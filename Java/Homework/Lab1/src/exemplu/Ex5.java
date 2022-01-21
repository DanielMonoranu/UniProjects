package exemplu;

import java.util.Random;

public class Ex5 {

	public static void main(String[] args) {
		Random rand = new Random();
		int max = 20;
		int nr = rand.nextInt(max);
		int t=0;
		int a = 0;
		int b = 1;
		if (nr == a || nr == b) {
			System.out.print("Nr " + nr + " face parte din sirul Fibonacci");
			t=1;
		}
		int c = a + b;
		while (c <= nr) {
			if (nr == c) {
				System.out.print("Nr " + nr + " face parte din sirul Fibonacci");
			t=1;	
			}
			else
			a = b;
			b = c;
			c = a + b;
		
		}
		if(t==0)
			System.out.print("Nr " + nr + " nu face parte din sirul Fibonacci");

	}

}
