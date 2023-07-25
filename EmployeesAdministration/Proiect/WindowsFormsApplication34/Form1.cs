using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OracleClient;

namespace WindowsFormsApplication34
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        OracleConnection conn;
        OracleDataAdapter daAngajat;
        OracleDataAdapter daProcente;
        DataSet dsANGAJAT;
        DataSet dsPROCENTE;

        string selectAngajat = "SELECT * FROM ANGAJATI";
        string selectProcente = "SELECT * FROM PROCENTE";


        private void Form1_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            conn = new OracleConnection("DATA SOURCE=localhost:1521/XE;PASSWORD=STUDENT;USER ID=STUDENT");
            try
            {
                dsANGAJAT = new DataSet();
                dsPROCENTE = new DataSet();
                conn.Open();
                labelInfo.Text = "Conexiune cu baza de date: " + conn.DataSource;
                labelErori.Text = "Versiune Server Oracle " + conn.ServerVersion;

                daAngajat = new OracleDataAdapter(selectAngajat, conn);
                daProcente = new OracleDataAdapter(selectProcente, conn);
                // ** Fill DataSet
                daAngajat.Fill(dsANGAJAT, "ANGAJATI");
                daProcente.Fill(dsPROCENTE, "PROCENTE");

                dataGridViewAngajat.DataSource = dsANGAJAT.Tables["ANGAJATI"];
                dataGridViewProcente.DataSource = dsPROCENTE.Tables["PROCENTE"];
                conn.Close();

                dataGridViewAngajat.Columns[0].ReadOnly = true;
                dataGridViewAngajat.Columns[7].ReadOnly = true;
                dataGridViewAngajat.Columns[8].ReadOnly = true;
                dataGridViewAngajat.Columns[9].ReadOnly = true;
                dataGridViewAngajat.Columns[10].ReadOnly = true;
                dataGridViewAngajat.Columns[11].ReadOnly = true;
                dataGridViewAngajat.Columns[13].ReadOnly = true;

                dataGridViewProcente.Columns[0].ReadOnly = true;
                dataGridViewProcente.Columns[1].ReadOnly = true;
                dataGridViewProcente.Columns[2].ReadOnly = true;
                dataGridViewProcente.Columns[3].ReadOnly = true;
                dataGridViewProcente.Columns[4].Visible = false;
                bindingSource1.DataSource = dataGridViewAngajat.DataSource;
            }
            catch (Exception ex)
            {
                labelInfo.Text = "Conexiune esuata: " + ex.Message;
            }
        }

        private void Actualizare_Click(object sender, EventArgs e)
        {
            OracleCommandBuilder commandA = new OracleCommandBuilder(daAngajat);
            OracleCommandBuilder commandP = new OracleCommandBuilder(daProcente);
            try
            {
                daAngajat.Update(dsANGAJAT.Tables["ANGAJATI"]);
                daProcente.Update(dsPROCENTE.Tables["PROCENTE"]);
                dsANGAJAT = new DataSet();
                dsPROCENTE = new DataSet();
                conn.Open();
                labelInfo.Text = "Conexiune cu baza de date: " + conn.DataSource;
                labelErori.Text = "Versiune Server Oracle " + conn.ServerVersion;

                daAngajat = new OracleDataAdapter(selectAngajat, conn);
                daProcente = new OracleDataAdapter(selectProcente, conn);
                // ** Fill DataSet
                daAngajat.Fill(dsANGAJAT, "ANGAJATI");
                daProcente.Fill(dsPROCENTE, "PROCENTE");

                dataGridViewAngajat.DataSource = dsANGAJAT.Tables["ANGAJATI"];
                dataGridViewProcente.DataSource = dsPROCENTE.Tables["PROCENTE"];
                cautareTextBox.Text = String.Empty;
                conn.Close();
            }
            catch (Exception ex)
            {
                labelErori.Text = "Eroare:" + ex.Message;
            }
        }
        private void Adaugare_click(object sender, EventArgs e)
        {
            Adaugare form = new Adaugare();
            form.Show();
            labelInfo.Text = TransferClass.angajatNume;
        }

       

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            try
            {
                for (int i = 0; i < dataGridViewAngajat.Rows.Count; i++)
                {

                    if (cautareTextBox.Text == "")
                    {
                        for (int j = 0; j <= dataGridViewAngajat.Rows.Count; j++)
                        {
                            dataGridViewAngajat.Rows[j].Visible = true;
                            dataGridViewAngajat.Rows[j].Selected = false;
                        }
                    }

                    if (dataGridViewAngajat.Rows[i].Cells[1].Value.ToString().StartsWith(cautareTextBox.Text))
                    {
                        dataGridViewAngajat.Rows[i].Selected = true;
                        dataGridViewAngajat.Rows[i].Visible = true;
                    }
                    else
                    {
                        CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[dataGridViewAngajat.DataSource];

                        currencyManager1.SuspendBinding();
                        dataGridViewAngajat.Rows[i].Visible = false;
                        dataGridViewAngajat.Rows[i].Selected = false;
                    }
                }
            }
            catch (Exception ex) { }

        }

        private void Stergere_Click(object sender, EventArgs e)
        {
            int contor = 0;
            int linieCurenta = 0;
            if (cautareTextBox.Text != String.Empty)
            {
                OracleCommandBuilder command = new OracleCommandBuilder(daAngajat);

                if (dsANGAJAT.Tables["ANGAJATI"].Rows.Count > 0)
                {
                    for (int i = 0; i < dataGridViewAngajat.Rows.Count; i++)
                    {
                        if (dataGridViewAngajat.Rows[i].Visible == true)
                        {
                            linieCurenta = i;
                            contor++;
                        }
                    }
                    if (contor == 1)
                    {
                        DialogResult dialog = MessageBox.Show("Doriti sa stergeti angajatul?", "Stergere", MessageBoxButtons.YesNo);
                        if (dialog == DialogResult.Yes)
                        {
                            DataRow Linie = dsANGAJAT.Tables["Angajati"].Rows[linieCurenta];
                            Linie.Delete();
                            daAngajat.Update(dsANGAJAT.Tables["ANGAJATI"]);
                        }
                    }
                    else
                    {
                        label1.Text = "Selectati un singur angajat!";
                    }

                }
            }
        }

        private void modificareprocente_click(object sender, EventArgs e)
        {
            Parolacs form = new Parolacs();
            form.Show();
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            OracleCommandBuilder commandA = new OracleCommandBuilder(daAngajat);
            OracleCommandBuilder commandP = new OracleCommandBuilder(daProcente);
            try
            {
                daAngajat.Update(dsANGAJAT.Tables["ANGAJATI"]);
                daProcente.Update(dsPROCENTE.Tables["PROCENTE"]);
                dsANGAJAT = new DataSet();
                dsPROCENTE = new DataSet();
                conn.Open();
                labelInfo.Text = "Conexiune cu baza de date: " + conn.DataSource;
                labelErori.Text = "Versiune Server Oracle " + conn.ServerVersion;

                daAngajat = new OracleDataAdapter(selectAngajat, conn);
                daProcente = new OracleDataAdapter(selectProcente, conn);
                // ** Fill DataSet
                daAngajat.Fill(dsANGAJAT, "ANGAJATI");
                daProcente.Fill(dsPROCENTE, "PROCENTE");

                dataGridViewAngajat.DataSource = dsANGAJAT.Tables["ANGAJATI"];
                dataGridViewProcente.DataSource = dsPROCENTE.Tables["PROCENTE"];
                cautareTextBox.Text = String.Empty;
                conn.Close();
            }
            catch (Exception ex)
            {
                labelErori.Text = "Eroare:" + ex.Message;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            CrystalReport2 raport = new CrystalReport2();
            crystalReportViewer1.DisplayGroupTree = false;
            raport.SetDataSource(dsANGAJAT.Tables["angajati"]);
            crystalReportViewer1.ReportSource = raport;
        }
    }
}
