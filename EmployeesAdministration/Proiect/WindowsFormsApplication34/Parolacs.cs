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
    public partial class Parolacs : Form
    {
        public Parolacs()
        {
            InitializeComponent();
        }
        OracleConnection conn;
        private void parolaTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void enterButton_Click(object sender, EventArgs e)
        {
            conn = new OracleConnection("DATA SOURCE=localhost:1521/XE;PASSWORD=STUDENT;USER ID=STUDENT");
            string parola = String.Empty;
            try
            {
                conn.Open();
                string sqlQuery = "select * from procente where id=0";
                using (OracleCommand cmd = new OracleCommand(sqlQuery, conn))
                {
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            parola = reader.GetString(4);
                        }
                    }
                }
                if (parolaTextBox.Text == parola)
                {
                    Modificare form = new Modificare();
                    form.Show();
                    this.Close();
                }
                else
                {
                    eroarelabel.Text = "Parola gresita!";
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                eroarelabel.Text = "Parola gresita! ";
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }

        }
    }
}
