package Tema4;

import java.io.Serializable;

public class Imprimanta extends Echipament implements Serializable {

	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;
	enum Tiparire {
		AlbNegru, Color
	}
	private int ppm;
	private String rezolutie;
	private int p_car;
	private Tiparire tiparire;
	public Imprimanta() {
		ppm = 0;
		rezolutie = "";
		p_car = 0;
		tiparire = Tiparire.AlbNegru;
	}
	public Imprimanta(
			String denumire, int nrInventar, int pret, String zonaMag, Stare stare, int ppm, 
			String rezolutie, int p_car, Tiparire tiparire) {
		super(denumire, nrInventar, pret, zonaMag, stare);
		this.ppm = ppm;
		this.rezolutie = rezolutie;
		this.p_car = p_car;
		this.tiparire = tiparire;
	}

	public String toString() {
		return super.toString() + "; " + ppm + "; " + rezolutie + "; " + p_car + "; " + tiparire;
	}
	public void setTiparire(Tiparire tiparire) {
		this.tiparire = tiparire;
	}

	
}
