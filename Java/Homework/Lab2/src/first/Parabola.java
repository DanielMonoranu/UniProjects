package first;

public class Parabola {
	double a;
	double b;
	double c;
	double x, y;

	public Parabola(double a, double b, double c) {
		this.a = a;
		this.b = b;
		this.c = c;

	}

	public Parabola(Parabola p) { // parabola p
		this(p.a, p.b, p.c);
	}

	public void afisare() {
		System.out.println("f(x)=" + (int) a + "x^2+" + (int) b + "x+" + (int) c);
	}

	void genvarf() {

		Varf v = new Varf();
		v.setVfa(-b / (2 * a));
		v.setVfb((-(b * b) + 4 * a * c) / (4 * a));

		x = v.vfa;
		y = v.vfb;
		// System.out.print(x + " " + y);
	}

	static void calcul(Parabola a, Parabola b) {
		double c1, c2;
		a.genvarf();
		b.genvarf();
		c1 = (a.x + b.x) / 2;
		c2 = (a.y + b.y) / 2;
		System.out.print("x=" + c1 + "  " + "y=" + c2);

	}

}
