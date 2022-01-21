package Tema5_1;

import java.util.Calendar;



public class ContBancar implements Operatiuni {
	private String numarCont;
	private float suma;
	private String moneda;
	private Calendar data_deschiderii;
	private Calendar data_ultimei_operatiuni;

	public ContBancar(String numarCont, float suma, String moneda, Calendar data_deschiderii,
			Calendar data_ultimei_operatiuni) {
		super();
		this.numarCont = numarCont;
		this.suma = suma;
		this.moneda = moneda;
		this.data_deschiderii = data_deschiderii;
		this.data_ultimei_operatiuni = data_ultimei_operatiuni;
	}

	public String getNumarCont() {
		return numarCont;
	}

	public void setNumarCont(String numarCont) {
		this.numarCont = numarCont;
	}

	public float getSuma() {
		return suma;
	}

	public void setSuma(float suma) {
		this.suma = suma;
	}

	public String getMoneda() {
		return moneda;
	}

	public void setMoneda(String moneda) {
		this.moneda = moneda;
	}

	public Calendar getData_deschiderii() {
		return data_deschiderii;
	}

	public void setData_deschiderii(Calendar data_deschiderii) {
		this.data_deschiderii = data_deschiderii;
	}

	public Calendar getData_ultimei_operatiuni() {
		return data_ultimei_operatiuni;
	}

	public void setData_ultimei_operatiuni(Calendar data_ultimei_operatiuni) {
		this.data_ultimei_operatiuni = data_ultimei_operatiuni;
	}

	@Override
	public String toString() {
		return "\nNr.cont:" + numarCont + ", suma=" + suma + ", moneda=" + moneda + ", data_deschiderii="
				+ data_deschiderii.get(Calendar.DAY_OF_MONTH) + ", " + (data_deschiderii.get(Calendar.MONTH) + 1) + ", "
				+ data_deschiderii.get(Calendar.YEAR) + ", " + "data ultiemei_operatiuni=" +
				+ data_ultimei_operatiuni.get(Calendar.DAY_OF_MONTH) + ", "
				+ (data_ultimei_operatiuni.get(Calendar.MONTH) + 1) + ", " + data_ultimei_operatiuni.get(Calendar.YEAR);

	}

	@Override
	public float calculeaza_dobanda() {
		Calendar c = Calendar.getInstance();
		float timp = c.getTimeInMillis() - data_ultimei_operatiuni.getTimeInMillis();
	
		float zile = timp / (1000 * 60 * 60 * 24);
		if (moneda == "RON")
			return (suma > 500 ? 0.3f * zile : 0.8f * zile);
		else
			
			return (0.1f * zile);
	}

	@Override
	public float actualizare_suma() {

		suma = suma + calculeaza_dobanda();
		data_ultimei_operatiuni = Calendar.getInstance();
		return suma;
	}

	@Override
	public void depunere(float suma) {
		this.suma = actualizare_suma();
		data_ultimei_operatiuni = Calendar.getInstance();
		this.suma += suma;

	}

	@Override
	public void extragere(float suma) {
		this.suma = actualizare_suma();
		data_ultimei_operatiuni = Calendar.getInstance();
		this.suma -= suma;
	}

}