package problema1;

public class Main {
	public static void main(String[] args) {
		ContBancar cont = new ContBancar();
		Depunere dep = new Depunere("Depunere", cont);
		Extragere ext = new Extragere("Extragere", cont);
		dep.start();
		ext.start();
	}
}
