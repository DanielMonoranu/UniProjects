package Tema3;

import java.util.Random;

public class Vers {
	private String vers;

	Vers(String vers) {
		this.vers = vers;
	}

	public String getVers() {
		return vers;
	}

	public void setVers(String vers) {
		this.vers = vers;
	}

	public byte NrCuvinte() {
		String[] s = vers.split(" ");
		return (byte) s.length;
	}

	public byte NrVocale() {
		byte contor = 0;
		String[] c = vers.split("");
		for (byte i = 0; i < c.length; i++)
			if (c[i].equalsIgnoreCase("a") || c[i].equalsIgnoreCase("e") || c[i].equalsIgnoreCase("i")
					|| c[i].equalsIgnoreCase("o") || c[i].equalsIgnoreCase("u"))
				contor++;
		return contor;
	}

	public StringBuilder AdaugaSteluta(String sir) {
		StringBuilder sb = new StringBuilder(vers);
		if (vers.endsWith(sir) == true) {
			sb.insert(0, "*");
		}
		return sb;
	}

	public StringBuilder UpperVers() {
		Random rand = new Random();
		StringBuilder inputStrT = new StringBuilder(vers);
		if (rand.nextFloat() < 0.3) {
			for (int i = 0; i < inputStrT.length(); i++) {
				if (inputStrT.charAt(i) >= 97 && inputStrT.charAt(i) <= 122)
					inputStrT.setCharAt(i, (char) (inputStrT.charAt(i) - 32));
			}
		}
		return inputStrT;
	}

	public String mare() {
		Random x = new Random();
		if (x.nextFloat() < 0.3) {
			vers = vers.toUpperCase();
		}
		return vers;
	}

	public String toString() {
		return vers + " - Nr.cuvinte: " + NrCuvinte() + " Nr.vocale: " + NrVocale();
	}
}
