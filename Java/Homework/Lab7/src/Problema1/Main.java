package Problema1;

import java.awt.BorderLayout;
import java.awt.EventQueue;

import javax.swing.JFrame;
import javax.swing.JPanel;
import javax.swing.border.EmptyBorder;
import javax.swing.JLabel;
import javax.swing.JOptionPane;
import javax.swing.JTextField;
import javax.swing.ImageIcon;
import javax.swing.JButton;
import java.awt.Color;
import java.awt.event.ActionListener;
import java.awt.event.ActionEvent;

public class Main extends JFrame {

	private JPanel contentPane;
	private JTextField txtOperand1;
	private JTextField txtOperand2;

	/**
	 * Launch the application.
	 */
	public static void main(String[] args) {
		EventQueue.invokeLater(new Runnable() {
			ImageIcon imagine = new ImageIcon("calculator.png");

			public void run() {
				try {
					Main frame = new Main();
					frame.setVisible(true);
					frame.setIconImage(imagine.getImage());
				} catch (Exception e) {
					e.printStackTrace();
				}
			}
		});
	}

	/**
	 * Create the frame.
	 */
	public Main() {
		String mesaj = "Ati introdus gresit numerele";
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setBounds(100, 100, 226, 249);
		contentPane = new JPanel();
		contentPane.setBorder(new EmptyBorder(5, 5, 5, 5));
		setContentPane(contentPane);
		contentPane.setLayout(null);

		JLabel lblOperand1 = new JLabel("Operand 1");
		lblOperand1.setBounds(13, 23, 59, 14);
		contentPane.add(lblOperand1);

		JLabel lblOperand2 = new JLabel("Operand 2");
		lblOperand2.setBounds(13, 51, 59, 14);
		contentPane.add(lblOperand2);

		txtOperand1 = new JTextField();
		txtOperand1.setColumns(10);
		txtOperand1.setBounds(82, 20, 119, 20);
		contentPane.add(txtOperand1);

		txtOperand2 = new JTextField();
		txtOperand2.setColumns(10);
		txtOperand2.setBounds(82, 48, 119, 20);
		contentPane.add(txtOperand2);

		JButton btnAdunare = new JButton("Adunare");

		btnAdunare.setBounds(13, 76, 89, 23);
		contentPane.add(btnAdunare);

		JButton btnScadere = new JButton("Scadere");

		btnScadere.setBounds(112, 76, 89, 23);
		contentPane.add(btnScadere);

		JButton btnImultire = new JButton("Imultire");
		btnImultire.setBounds(13, 110, 89, 23);
		contentPane.add(btnImultire);

		JButton btnImpartire = new JButton("Impartire");
		btnImpartire.setBounds(112, 110, 89, 23);
		contentPane.add(btnImpartire);

		JLabel lblRezultat = new JLabel("");
		lblRezultat.setOpaque(true);
		lblRezultat.setBackground(Color.WHITE);
		lblRezultat.setBounds(10, 144, 191, 14);
		contentPane.add(lblRezultat);

		JButton btnClear = new JButton("Clear");
		btnClear.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				txtOperand1.setText(null);
				txtOperand2.setText(null);
				lblRezultat.setText(null);
			}
		});
		btnClear.setBounds(13, 169, 188, 23);
		contentPane.add(btnClear);

		// ---------------------actiuni butoane------
		btnAdunare.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				try {
					lblRezultat.setText(Integer.toString(
							Integer.parseInt(txtOperand1.getText()) + Integer.parseInt(txtOperand2.getText())));

				} catch (NumberFormatException e1) {
					JOptionPane.showMessageDialog(null, mesaj);
				}
			}
		});
		btnImultire.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				try {
					lblRezultat.setText(Integer.toString(
							Integer.parseInt(txtOperand1.getText()) * Integer.parseInt(txtOperand2.getText())));

				} catch (NumberFormatException e1) {
					JOptionPane.showMessageDialog(null, mesaj);
				}
			}
		});
		btnScadere.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				try {
					lblRezultat.setText(Integer.toString(
							Integer.parseInt(txtOperand1.getText()) - Integer.parseInt(txtOperand2.getText())));

				} catch (NumberFormatException e1) {
					JOptionPane.showMessageDialog(null, mesaj);
				}
			}
		});
		btnImpartire.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				try {
					lblRezultat.setText(Integer.toString(
							Integer.parseInt(txtOperand1.getText()) / Integer.parseInt(txtOperand2.getText())));

				} catch (NumberFormatException e1) {
					JOptionPane.showMessageDialog(null, mesaj);
				} catch (ArithmeticException e3) {
					JOptionPane.showMessageDialog(null, "Nu se poate imparti la 0");
					lblRezultat.setText("Eroare");
				}
			}
		});

	}
}
