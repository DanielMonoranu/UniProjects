using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OracleClient;

namespace WindowsFormsApplication34
{
    public partial class Adaugare : Form
    {
        public Adaugare()
        {
            InitializeComponent();
        }
        OracleConnection conn;

        private void anulareBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AdaugareBtn_Click(object sender, EventArgs e)
        {
            if (numeTextBox.Text == String.Empty || prenumeTextBox.Text == String.Empty || FunctieTextBox.Text == String.Empty)
            {
                EroriLAbel.Text = "Eroare! Un camp este gol!";
            }
            else if (SporNumeric.Value > 100)
            {
                EroriLAbel.Text = "Eroare! Sporul nu este un procent!";
            }
            else
            {
                EroriLAbel.Text = String.Empty;
                conn = new OracleConnection("DATA SOURCE=localhost:1521/XE;PASSWORD=STUDENT;USER ID=STUDENT");
                try
                {
                    conn.Open();
                    string sqlAdd = "INSERT INTO ANGAJATI VALUES(1, :p1, :p2, :p3, :p4, :p5, :p6,0,0,0,0,0, :p7,0)";
                    OracleCommand cmd = new OracleCommand(sqlAdd, conn);
                    OracleParameter p1 = cmd.Parameters.Add("p1", OracleType.Char, 10);
                    OracleParameter p2 = cmd.Parameters.Add("p2", OracleType.Char, 10);
                    OracleParameter p3 = cmd.Parameters.Add("p3", OracleType.Char, 10);
                    OracleParameter p4 = cmd.Parameters.Add("p4", OracleType.Int32, 9);
                    OracleParameter p5 = cmd.Parameters.Add("p5", OracleType.Int32, 9);
                    OracleParameter p6 = cmd.Parameters.Add("p6", OracleType.Int32, 9);
                    OracleParameter p7 = cmd.Parameters.Add("p7", OracleType.Int32, 9);
                    p1.Value = numeTextBox.Text;
                    p2.Value = prenumeTextBox.Text;
                    p3.Value = FunctieTextBox.Text;
                    p4.Value = SalarBazaNumeric.Value;
                    p5.Value = SporNumeric.Value;
                    p6.Value = PremiiBruteNumeric.Value;
                    p7.Value = retineriNumeric.Value;
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Angajat adaugat!");
                }
                catch (Exception ex)
                {
                    EroriLAbel.Text = "Eroare " + ex.ToString();
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                }
            }
        }

      

        private void numeTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsNumber(e.KeyChar)) && (!char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void prenumeTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsNumber(e.KeyChar)) && (!char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void FunctieTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsNumber(e.KeyChar)) && (!char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void SalarBazaNumeric_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar != '-') && (!char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void SporNumeric_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar != '-') && (!char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void PremiiBruteNumeric_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar != '-') && (!char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

       

        private void retineriNumeric_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar != '-') && (!char.IsControl(e.KeyChar)))
                e.Handled = true;
        }
    }
}
