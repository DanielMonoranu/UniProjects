package problema1;

public class Depunere extends Thread {
	private ContBancar cont;

	public Depunere(String name, ContBancar cont) {
		super(name);
		this.cont = cont;

	}

	public void run() {
		while (true) {
			cont.Depune();
			try{
				sleep((int)(Math.random()*1000));
				}
				catch(InterruptedException e){}
		}
	}

	
}
