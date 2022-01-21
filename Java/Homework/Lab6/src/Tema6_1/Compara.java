package Tema6_1;

public class Compara {
	public static void Comparare(int a, int b) throws ExceptiaMea {
		if(a>=b) throw new ExceptiaMea("Primul numar trebuie sa fie mai mic decat al doilea numar!");
	}
}
