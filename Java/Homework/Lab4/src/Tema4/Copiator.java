package Tema4;

import java.io.Serializable;

public class Copiator extends Echipament implements Serializable {
	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;

	public enum Format {
		A3, A4
	}

	private int ppm;
	private int p_ton;
	private Format format;

	public Copiator(String denumire, int nrInventar, int pret, String zonaMag, Stare stare, int ppm, int p_ton,
			Format format) {
		super(denumire, nrInventar, pret, zonaMag, stare);
		this.p_ton = p_ton;
		this.ppm = ppm;
		this.format = format;
	}

	public String toString() {
		return super.toString() + "; " + ppm + "; " + p_ton + "; " + format;
	}

	public void setFormat(Format format) {
		this.format = format;
	}
	

	
}
