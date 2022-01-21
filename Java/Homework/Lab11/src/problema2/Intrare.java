package problema2;

public class Intrare extends Thread {
    private Parcare parcare;
	public Intrare(String nume, Parcare parcare) {
	    super(nume);
	    this.parcare = parcare;
	}
	public void run() {
		while(true) {
			parcare.intrareMasina();
			try{
				sleep((int)(Math.random()*1000));
			}
			catch(InterruptedException e){}
          
		}
	}
}
