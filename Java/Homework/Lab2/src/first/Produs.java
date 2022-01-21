package first;

public class Produs {
	private String nume;
	private float pret;
	private int cantitate;

	public String getNume() {
		return nume;
	}

	public void setNume(String nume) {
		this.nume = nume;
	}

	public float getPret() {
		return pret;
	}

	public void setPret(float pret) {
		this.pret = pret;
	}

	public int getCantitate() {
		return cantitate;
	}

	public void setCantitate(int cantitate) {
		this.cantitate = cantitate;
	}

	public Produs(String b1, String b2, String b3) {
		nume = b1;
		pret = Float.parseFloat(b2);
		cantitate = Integer.parseInt(b3);
	}

	public Produs() {
	}

	public String toString() {
		String s = "Nume:" + nume + ", pret:" + pret + ", cantitate:" + cantitate;
		return s;

	}

	void afisare() {
		String p = Float.toString(pret);
		String c = Integer.toString(cantitate);
		System.out.println(nume + " " + pret + " " + cantitate);

	}

}
