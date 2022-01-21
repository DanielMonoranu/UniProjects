package problema1;

public class ContBancar {
	private int suma;


	public synchronized void Depune() {
		int a = (int) (Math.random() * 1000) + 1;
	
		suma += a;
		System.out.println("+ A fost depusa suma de " + a + "RON, in cont sunt: " + suma + " RON");
		notify();
	}

	public synchronized void Retrage() {
		int a = (int) (Math.random() * 1000);
		while(suma - a < 0) {
			try {
				wait();
			} catch (InterruptedException e) {
				
				e.printStackTrace();
			}
		}
		suma -= a;
		System.out.println("- A fost retrasa suma de " + a + "RON, in cont sunt: " + suma + " RON");
		
		
	}

	public ContBancar() {
		super();
		suma = 0;

	}

}
