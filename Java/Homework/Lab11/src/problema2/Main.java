package problema2;

public class Main {

	public static void main(String[] args) {
		Parcare p = new Parcare(10, 0);
		Intrare i1 = new Intrare("1", p);
		Intrare i2 = new Intrare("2", p);
		Intrare i3 = new Intrare("3", p);
		Iesire iesire = new Iesire("Iesire", p);
		i1.start();
		i2.start();
		i3.start();
		iesire.start();
		
	}

}
