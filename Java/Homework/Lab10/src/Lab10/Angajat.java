package Lab10;

import java.time.LocalDate;

public class Angajat {
	private String nume;
	private String post;
	private LocalDate data;
	private float salariu;

	public String getNume() {
		return nume;
	}

	public void setNume(String nume) {
		this.nume = nume;
	}

	public String getPost() {
		return post;
	}

	public void setPost(String post) {
		this.post = post;
	}

	public LocalDate getData() {
		return data;
	}

	public void setData(LocalDate data) {
		this.data = data;
	}

	public float getSalariu() {
		return salariu;
	}

	public void setSalariu(float salariu) {
		this.salariu = salariu;
	}

	public Angajat(String nume, String post, LocalDate data, float salariu) {
		super();
		this.nume = nume;
		this.post = post;
		this.data = data;
		this.salariu = salariu;
	}

	@Override
	public String toString() {
		return   nume + ", post=" + post + ", data angajarii=" + data + ", salariu=" + salariu;
	}

}

