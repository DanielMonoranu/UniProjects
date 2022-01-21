package Tema5_1;

import java.util.ArrayList;
import java.util.List;



public class Banca {
	private String denumire_banca;
	List<Client> lista;
	
	public Banca(String denumire_banca) {
		super();
		this.denumire_banca = denumire_banca;
		lista=new ArrayList<Client>();
		
	}

	public String getDenumire_banca() {
		return denumire_banca;
	}

	public void setDenumire_banca(String denumire_banca) {
		this.denumire_banca = denumire_banca;
	}

	public List<Client> getLista() {
		return lista;
	}

	public void setLista(List<Client> lista) {
		this.lista = lista;
	}

	public void AdaugaClient(Client client) {
		lista.add(client);
	}
	@Override
	public String toString() {
		return "Banca:"+ denumire_banca + ". Clientii:" + lista + "\n";
	}
	
	
	
}
