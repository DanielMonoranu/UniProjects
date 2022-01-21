package exemplu;

import java.util.Random;

public class Ex4 {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		Random rand=new Random();
		int max=30;
		int nr1=rand.nextInt(max);
		int nr2=rand.nextInt(max);
		int rest=0;
		//System.out.println(nr1+" "+nr2);
		while(nr2!=0) {
			rest=nr1%nr2;
			nr1=nr2;
			nr2=rest;
		}
		System.out.print("cmmdc este "+nr1);

	}

}
