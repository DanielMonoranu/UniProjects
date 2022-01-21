using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tema_lab3
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();

        }

        private void btnOK_Click(object sender, EventArgs e)
        {

            if (tbUtilizator.Text == "user" && tbParola.Text == "parola")
            {
                timer1.Start();
                timer1.Tick += timer1_Tick;
                btnCancel.Enabled = false;
                btnOK.Enabled = false;

            }
            else
            {
                errorProvider1.SetError(tbParola, "User sau parola gresite!");
                errorProvider1.SetError(tbUtilizator, "User sau parola gresite!");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value == progressBar1.Maximum)
            {
                this.DialogResult = DialogResult.OK;
                return;
            }
            progressBar1.Value += 1;
        }

        private void tbUtilizator_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        private void tbParola_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();

        }
    }
}
