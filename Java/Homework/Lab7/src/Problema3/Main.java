package Problema3;

import java.awt.Component;
import java.awt.EventQueue;

import javax.swing.BorderFactory;
import javax.swing.ImageIcon;
import javax.swing.JFrame;
import javax.swing.JPanel;
import javax.swing.JScrollPane;
import javax.swing.border.EmptyBorder;
import javax.swing.table.DefaultTableModel;
import javax.swing.JLabel;
import javax.swing.JOptionPane;

import java.awt.Font;
import javax.swing.JTextField;
import javax.swing.JSpinner;
import javax.swing.JCheckBox;
import javax.swing.JButton;
import javax.swing.JTable;
import javax.swing.SpinnerNumberModel;
import java.awt.event.ActionListener;
import java.awt.event.ActionEvent;

@SuppressWarnings("serial")
public class Main extends JFrame {

	private JPanel contentPane;
	private JTextField tfFilm;
	private JTextField tfActori;
	private DefaultTableModel model;
	private JTable table;

	/**
	 * Launch the application.
	 */
	public static void main(String[] args) {
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				ImageIcon icon = new ImageIcon("video-camera.png");
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
		ImageIcon icon = new ImageIcon("warning.png");
		setTitle("FILME");
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setBounds(100, 100, 495, 514);
		contentPane = new JPanel();
		contentPane.setBorder(new EmptyBorder(5, 5, 5, 5));
		setContentPane(contentPane);
		contentPane.setLayout(null);
		
		// JPANEL-URI------------------------------------------------------------ 
		
		JPanel panelAdaugare = new JPanel();
		panelAdaugare.setBounds(65, 0, 363, 102);
		contentPane.add(panelAdaugare);
		panelAdaugare.setLayout(null);
		panelAdaugare.setBorder(BorderFactory.createTitledBorder("Adaugare"));

		JPanel panelGenuri = new JPanel();
		panelGenuri.setBounds(65, 112, 363, 102);
		contentPane.add(panelGenuri);
		panelGenuri.setLayout(null);
		panelGenuri.setBorder(BorderFactory.createTitledBorder("Genuri"));

		// ETICHETE------------------------------------------------------------ 
		
		JLabel lblFilm = new JLabel("Film");
		lblFilm.setFont(new Font("Times New Roman", Font.BOLD, 14));
		lblFilm.setToolTipText("Numele filmului");
		lblFilm.setBounds(10, 19, 30, 21);
		panelAdaugare.add(lblFilm);

		JLabel lblActori = new JLabel("Actori");
		lblActori.setFont(new Font("Times New Roman", Font.BOLD, 14));
		lblActori.setToolTipText("Actorii care joaca in film");
		lblActori.setBounds(10, 42, 40, 21);
		panelAdaugare.add(lblActori);

		JLabel lblAnLansare = new JLabel("An lansare");
		lblAnLansare.setFont(new Font("Times New Roman", Font.BOLD, 14));
		lblAnLansare.setToolTipText("Anul de lansare al filmului");
		lblAnLansare.setBounds(10, 65, 70, 21);
		panelAdaugare.add(lblAnLansare);

		// CASETE TEXT------------------------------------------------------------ 
		tfFilm = new JTextField();
		tfFilm.setBounds(96, 17, 222, 21);
		panelAdaugare.add(tfFilm);	
		tfFilm.setColumns(10);

		tfActori = new JTextField();
		tfActori.setColumns(10);
		tfActori.setBounds(96, 40, 222, 21);
		panelAdaugare.add(tfActori);

		JSpinner sAn = new JSpinner();
		sAn.setModel(new SpinnerNumberModel(2015, 2015, 2021, 1));
		sAn.setBounds(96, 63, 77, 21);
		panelAdaugare.add(sAn);

		// CASETE BIFAT------------------------------------------------------------ 
		
		JCheckBox CheckBoxActiune = new JCheckBox("Actiune");
		CheckBoxActiune.setFont(new Font("Tahoma", Font.BOLD, 12));
		CheckBoxActiune.setBounds(142, 54, 93, 21);
		panelGenuri.add(CheckBoxActiune);

		JCheckBox CheckBoxDrama = new JCheckBox("Drama");
		CheckBoxDrama.setFont(new Font("Tahoma", Font.BOLD, 12));
		CheckBoxDrama.setBounds(266, 19, 93, 21);
		panelGenuri.add(CheckBoxDrama);

		JCheckBox CheckBoxIstoric = new JCheckBox("Istoric");
		CheckBoxIstoric.setFont(new Font("Tahoma", Font.BOLD, 12));
		CheckBoxIstoric.setBounds(101, 19, 93, 21);
		panelGenuri.add(CheckBoxIstoric);

		JCheckBox CheckBoxRomantic = new JCheckBox("Romantic");
		CheckBoxRomantic.setFont(new Font("Tahoma", Font.BOLD, 12));
		CheckBoxRomantic.setBounds(6, 19, 93, 21);
		panelGenuri.add(CheckBoxRomantic);

		JCheckBox CheckBoxComedie = new JCheckBox("Comedie");
		CheckBoxComedie.setFont(new Font("Tahoma", Font.BOLD, 12));
		CheckBoxComedie.setBounds(171, 19, 93, 21);
		panelGenuri.add(CheckBoxComedie);

		//  BUTOANE------------------------------------------------------
		
		JButton btnAdaugare = new JButton("Adauga");
		btnAdaugare.setFont(new Font("Times New Roman", Font.PLAIN, 12));
		btnAdaugare.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				String textGen = "";
				for (Component component : panelGenuri.getComponents()) {
					if (component instanceof JCheckBox) {
						JCheckBox box = (JCheckBox) component;
						if (box.isSelected())
							textGen += box.getText() + " ";
					}
				}
				if (tfFilm.getText().isBlank())
					JOptionPane.showMessageDialog(null, "Nu ati introdus numele filmului!", "Nume film lipsa",
							JOptionPane.INFORMATION_MESSAGE, icon);
				else if (tfActori.getText().isBlank())
					JOptionPane.showMessageDialog(null, "Nu ati introdus actori!", "Actori lipsa",
							JOptionPane.INFORMATION_MESSAGE, icon);
				else if (!CheckBoxActiune.isSelected() && !CheckBoxComedie.isSelected() && !CheckBoxDrama.isSelected()
						&& !CheckBoxIstoric.isSelected() && !CheckBoxRomantic.isSelected())
					JOptionPane.showMessageDialog(null, "Nu ati selectat niciun gen de film!", "Gen lipsa",
							JOptionPane.INFORMATION_MESSAGE, icon);
				else {
					DefaultTableModel model = (DefaultTableModel) table.getModel();
					model.addRow(new Object[] { tfFilm.getText(), tfActori.getText(), sAn.getValue(), textGen });
				}
			}
		});
		btnAdaugare.setBounds(98, 224, 85, 21);
		btnAdaugare.setToolTipText("Adauga datele introduse mai sus in tabel");
		contentPane.add(btnAdaugare);

		JButton btnStergere = new JButton("Sterge");
		btnStergere.setFont(new Font("Times New Roman", Font.PLAIN, 12));
		btnStergere.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				int[] n = table.getSelectedRows();
				for (int i = n.length - 1; i >= 0; i--) {
					model.removeRow(n[i]);
				}
			}
		});
		btnStergere.setBounds(283, 232, 85, 21);
		btnStergere.setToolTipText("Sterge randurile din tabel selectate");
		contentPane.add(btnStergere);

		//TABEL ------------------------------------------------------------ 
		model = new DefaultTableModel();
		JScrollPane scrollPane = new JScrollPane();
		scrollPane.setBounds(10, 284, 418, 158);
		contentPane.add(scrollPane);
		table = new JTable(model);
		model.addColumn("FILM");
		model.addColumn("ACTORI");
		model.addColumn("AN");
		model.addColumn("GENURI");
		scrollPane.setViewportView(table);

	}

}
