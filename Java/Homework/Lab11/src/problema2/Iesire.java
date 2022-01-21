package problema2;

public class Iesire extends Thread {
	private Parcare parcare;
	public Iesire(String nume, Parcare parcare) {
	    super(nume);
	    this.parcare = parcare;
	}
	public void run() {
		while(true) {
			parcare.iesireMasina();
			try{
				sleep((int)(Math.random() * 500));
			}
			catch(InterruptedException e){}

		}
	}
}
