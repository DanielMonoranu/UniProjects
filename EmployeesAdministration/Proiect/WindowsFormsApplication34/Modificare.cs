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
    public partial class Modificare : Form
    {
        public Modificare()
        {
            InitializeComponent();
        }
        OracleConnection conn;
        private void ModificareBtn_Click(object sender, EventArgs e)
        {
            if (parolaTextBox.Text == String.Empty)
            {
                EroriLAbel.Text = "Eroare! Un camp este gol!";
            }
            else
            {
                conn = new OracleConnection("DATA SOURCE=localhost:1521/XE;PASSWORD=STUDENT;USER ID=STUDENT");
                try
                {
                    conn.Open();
                    string sqlAdd = "UPDATE PROCENTE SET ID=0, CAS_PROCENT= :p1, CASS_PROCENT= :p2, IMPOZIT_PROCENT= :p3, PAROLA= :p4";
                    OracleCommand cmd = new OracleCommand(sqlAdd, conn);
                    OracleParameter p1 = cmd.Parameters.Add("p1", OracleType.Number, 10);
                    OracleParameter p2 = cmd.Parameters.Add("p2", OracleType.Number, 10);
                    OracleParameter p3 = cmd.Parameters.Add("p3", OracleType.Number, 10);
                    OracleParameter p4 = cmd.Parameters.Add("p4", OracleType.Char, 9);
                    p1.Value = CASnumeric.Value;
                    p2.Value = CASSNumeric.Value;
                    p3.Value = ImpozitNumeric.Value;
                    p4.Value = parolaTextBox.Text;
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Succes!");
                    this.Close();
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


        private void anulareBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CASnumeric_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar != '-') && (!char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void CASSNumeric_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar != '-') && (!char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void ImpozitNumeric_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar != '-') && (!char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void CASSNumeric_ValueChanged(object sender, EventArgs e)
        {

        }

        private void CASnumeric_ValueChanged(object sender, EventArgs e)
        {

        }

        private void EroriLAbel_Click(object sender, EventArgs e)
        {

        }

        private void parolaTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void ImpozitNumeric_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
