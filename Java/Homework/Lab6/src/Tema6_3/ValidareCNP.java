package Tema6_3;

import Tema6_1.ExceptiaMea;

public class ValidareCNP {
	public static void NrCifre(String cnp) throws ExceptiaMea {
		if (cnp.length() != 13)
			throw new ExceptiaMea("CNP-ul trebuie sa aiba 13 cifre!");
	}

	public static void Caractere(String cnp) throws ExceptiaMea {
		if (!(cnp.matches("[0-9]+")))
			throw new ExceptiaMea("CNP-ul trebuie sa contina numai cifre!");
	}

	public static void Altele(String cnp) throws ExceptiaMea {
		if (Integer.valueOf(cnp.substring(0, 1)) < 1 || Integer.valueOf(cnp.substring(0, 1)) > 6
				|| Integer.valueOf(cnp.substring(3, 5)) > 12 || Integer.valueOf(cnp.substring(3, 5)) < 1
				|| Integer.valueOf(cnp.substring(5, 7)) > 31 || Integer.valueOf(cnp.substring(5, 7)) < 1)
			throw new ExceptiaMea("CNP incorect" + Integer.valueOf(cnp.indexOf(0)));
	}
}
