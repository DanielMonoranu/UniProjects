package Problema2;

import java.awt.EventQueue;

import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

import javax.swing.JFrame;
import javax.swing.JPanel;
import javax.swing.border.EmptyBorder;
import javax.swing.JTextField;
import javax.swing.JList;
import javax.swing.JOptionPane;
import javax.swing.DefaultListModel;
import javax.swing.ImageIcon;
import javax.swing.JButton;

import java.awt.BorderLayout;

public class Main extends JFrame {

	private JPanel contentPane;
	private JTextField tfAdaugare;
	private JButton btnStergere;
	private JList<String> lista;
	private DefaultListModel<String> model;

	/**
	 * Launch the application.
	 */
	public static void main(String[] args) {
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				ImageIcon icon = new ImageIcon("music.png");
				try {
					Main frame = new Main();
					frame.setVisible(true);
					frame.setIconImage(icon.getImage());
					frame.setLocationRelativeTo(null);
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
		model = new DefaultListModel<String>();
		setResizable(true);
		setTitle("Formatii");
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setBounds(100, 100, 450, 300);
		contentPane = new JPanel();
		contentPane.setBorder(new EmptyBorder(5, 5, 5, 5));
		setContentPane(contentPane);
		contentPane.setLayout(new BorderLayout(0, 0));

		tfAdaugare = new JTextField();
		 
		contentPane.add(tfAdaugare, BorderLayout.NORTH);
		tfAdaugare.setColumns(10);
		tfAdaugare.setToolTipText("Introduceti formatia si apasati Enter");

		btnStergere = new JButton("Stergere");
		btnStergere.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				int[] n = lista.getSelectedIndices();
				for (int i = n.length - 1; i >= 0; i--) {
					model.removeElementAt(n[i]);
				}
			}
		});
		btnStergere.setToolTipText("Sterge liniile selectate");
		contentPane.add(btnStergere, BorderLayout.SOUTH);

		lista = new JList<String>();
		contentPane.add(lista, BorderLayout.CENTER);
		tfAdaugare.addActionListener(new EnterApasat());

	}

	class EnterApasat implements ActionListener {
		@Override
		public void actionPerformed(ActionEvent e) {
			lista.setModel(model);
			model.addElement(tfAdaugare.getText());

		}

	}
	
}
