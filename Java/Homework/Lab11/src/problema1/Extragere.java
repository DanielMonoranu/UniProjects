package problema1;

public class Extragere extends Thread {
	private ContBancar cont;

	public Extragere(String name, ContBancar cont) {
		super(name);
		this.cont = cont;

	}

	public void run() {
		while (true) {
			cont.Retrage();
			try{
				sleep((int)(Math.random()*1000));
				}
				catch(InterruptedException e){}
		}
	}

	
}
