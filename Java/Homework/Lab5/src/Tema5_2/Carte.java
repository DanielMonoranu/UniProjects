package Tema5_2;

public class Carte {
	private String titlu;
	private String autor;
	private int anAparitie;

	public Carte(String titlu, String autor, int anAparitie) {
		super();
		this.titlu = titlu;
		this.autor = autor;
		this.anAparitie = anAparitie;
	}

	public String getTitlu() {
		return titlu;
	}

	public void setTitlu(String titlu) {
		this.titlu = titlu;
	}

	public String getAutor() {
		return autor;
	}

	public void setAutor(String autor) {
		this.autor = autor;
	}

	public int getAnAparitie() {
		return anAparitie;
	}

	public void setAnAparitie(int anAparitie) {
		this.anAparitie = anAparitie;
	}

	@Override
	public String toString() {
		return "  " + titlu + "; " + autor + "; " + anAparitie;
	}

}
