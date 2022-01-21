package Tema3;

public class Melodie {
	private String nume_melodie;
	private String nume_artist;
	private String an_lansare;
	private int numar_vizualizari_youtube;

	public Melodie(String nume_melodie, String nume_artist, String an_lansare, int numar_vizualizari_youtube) {
		super();
		this.nume_melodie = nume_melodie;
		this.nume_artist = nume_artist;
		this.an_lansare = an_lansare;
		this.numar_vizualizari_youtube = numar_vizualizari_youtube;
	}

	public String getNume_melodie() {
		return nume_melodie;
	}

	public void setNume_melodie(String nume_melodie) {
		this.nume_melodie = nume_melodie;
	}

	public String getNume_artist() {
		return nume_artist;
	}

	public void setNume_artist(String nume_artist) {
		this.nume_artist = nume_artist;
	}

	public String getAn_lansare() {
		return an_lansare;
	}

	public void setAn_lansare(String an_lansare) {
		this.an_lansare = an_lansare;
	}

	public int getNumar_vizualizari_youtube() {
		return numar_vizualizari_youtube;
	}

	public void setNumar_vizualizari_youtube(int numar_vizualizari_youtube) {
		this.numar_vizualizari_youtube = numar_vizualizari_youtube;
	}

	@Override
	public String toString() {
		return "Melodia:" + nume_melodie + ", nume artist:" + nume_artist + ", an lansare:" + an_lansare
				+ ", nr.viz.youtube:" + numar_vizualizari_youtube;
	}
}
