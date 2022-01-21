package Tema4;

import java.io.Serializable;

public class SistemDeCalcul extends Echipament implements Serializable{
	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;

	enum SO {
		windows, linux
	}
	private String monitor;
	private float vit_proc;
	private int c_hdd;
	private SO sistemOperare;

	public SistemDeCalcul(String denumire, int nrInventar, int pret, String zonaMag, Stare stare, String monitor,
			float vit_proc, int c_hdd, SO sistemOperare) {
		super(denumire, nrInventar, pret, zonaMag, stare);
		this.monitor = monitor;
		this.vit_proc = vit_proc;
		this.c_hdd = c_hdd;
		this.sistemOperare = sistemOperare;
	}

	

	public String toString() {
		return super.toString() + "; " + monitor + "; " + vit_proc + "; " + c_hdd + "; "+ sistemOperare;
	}

	public void setSistemOperare(SO sistemOperare) {
		
		this.sistemOperare = sistemOperare;
	}

}
