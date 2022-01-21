package problema2;

public class Parcare {
	private int nrLoc;
	private int locOcupate;

	public Parcare(int nrLoc, int locOcupate) {
		super();
		this.nrLoc = nrLoc;
		this.locOcupate = locOcupate;
	}

	public synchronized void intrareMasina() {
		Thread t = Thread.currentThread();
		while (locOcupate == nrLoc)
			try {
				wait();
			} catch (InterruptedException e) {
			}

		++locOcupate;
		System.out.println(
				"+ A intrat o masina pe intrarea " + t.getName() + ". In parecare sunt " + locOcupate + " masini");
		notify();
	}

	public synchronized void iesireMasina() {

		if (locOcupate == 0)
			try {
				wait();
			} catch (InterruptedException e) {

			}

		--locOcupate;
		System.out.println("- A iesit o masina" + ". In parecare sunt " + locOcupate + " masini");
		notify();
	}
}
