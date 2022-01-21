using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tema_lab3
{
    public partial class EchipaNoua : Form
    {
        public EchipaNoua()
        {
            InitializeComponent();
        }

        private void btn2Adauga_Click(object sender, EventArgs e)
        {

            string numeEchipa = tb2NumeEchipa.Text;
            if (numeEchipa.Trim().Length == 0)
            {
                errorProvider1.SetError(tb2NumeEchipa, "Numele gresit!");
                return;
            }


            else if (Directory.Exists(Application.StartupPath + "\\Echipe\\" + numeEchipa))
            {
                errorProvider1.SetError(tb2NumeEchipa, "Numele gresit!");
                return;
            }
            Directory.CreateDirectory(Application.StartupPath + "\\Echipe\\" + numeEchipa);



            DialogResult = DialogResult.OK;
        }

        private void btn2Anulare_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
