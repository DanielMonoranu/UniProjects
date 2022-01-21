package Tema5_1;
import java.util.HashSet;
import java.util.Set;

public class Client {
	private String nume;
	private String adresa;
	Set<ContBancar> conturi;

	public Client() {
		super();
		this.nume = null;
		this.adresa = null;
		conturi = new HashSet<ContBancar>();
	}

	public Client(String nume, String adresa) {
		super();
		this.nume = nume;
		this.adresa = adresa;
		conturi = new HashSet<ContBancar>();
	}

	public String getNume() {
		return nume;
	}

	public void setNume(String nume) {
		this.nume = nume;
	}

	public String getAdresa() {
		return adresa;
	}

	public void setAdresa(String adresa) {
		this.adresa = adresa;
	}

	public Set<ContBancar> getConturi() {
		return conturi;
	}

	public void setConturi(Set<ContBancar> conturi) {
		this.conturi = conturi;
	}

	public void adaugaCont(ContBancar cont) {
		conturi.add(cont);
	}

	@Override
	public String toString() {
		return "\n" + nume + ", adresa=" + adresa + ". Conturi:" + conturi + "]";
	}

}
