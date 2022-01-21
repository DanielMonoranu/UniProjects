package Tema4;

import java.io.Serializable;

public class Echipament implements Serializable {


	public enum Stare {
		achizitionat, expus, vandut
	}

	private String denumire;
	private int nrInventar;
	private int pret;
	private String zonaMag;
	private Stare stare;

	public Echipament() {
		denumire = "";
		nrInventar = 0;
		pret = 0;
		zonaMag = "";
		stare = Stare.achizitionat;
	}

	public Echipament(String denumire, int nrInventar, int pret, String zonaMag, Stare stare) {
		super();
		this.denumire = denumire;
		this.nrInventar = nrInventar;
		this.pret = pret;
		this.zonaMag = zonaMag;
		this.stare = stare;
	}

	public String toString() {
		return denumire + "; " + nrInventar + "; " + pret + "; " + zonaMag + "; " + stare;
	}

	public Stare getStare() {
		return stare;
	}

	public void setStare(Stare stare) {
		this.stare = stare;
	}

	public String getDenumire() {
		return denumire;
	}

	public void setDenumire(String denumire) {
		this.denumire = denumire;
	}

	public int getNrInventar() {
		return nrInventar;
	}

	public void setNrInventar(int nrInventar) {
		this.nrInventar = nrInventar;
	}

	public int getPret() {
		return pret;
	}

	public void setPret(int pret) {
		this.pret = pret;
	}

	public String getZonaMag() {
		return zonaMag;
	}

	public void setZonaMag(String zonaMag) {
		this.zonaMag = zonaMag;
	}

}
