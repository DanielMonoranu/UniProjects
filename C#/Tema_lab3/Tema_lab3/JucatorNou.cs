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
    public partial class JucatorNou : Form
    {
        // proprietati
        public string Cnp { get => tb3CNP.Text; set => tb3CNP.Text = value; }
        public string Nume { get => tb3Nume.Text; set => tb3Nume.Text = value; }
        internal Post Post { get => (Post)Enum.Parse(typeof(Post), cmb3Post.Text); set => cmb3Post.Text = value.ToString(); }
        public JucatorNou()
        {
            InitializeComponent();
        }

        private void btn3Adauga_Click(object sender, EventArgs e)
        {
            if (DateValide())
            {
                DialogResult = DialogResult.OK;
            }


        }

        private bool DateValide()
        {
            bool result = true;
            errorProvider1.Clear();
            errorProvider2.Clear();

            if (tb3Nume.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(tb3Nume, "Nume incorect!");
                result = false;
            }
            if (tb3CNP.Text.Trim().Length == 0)
            {
                errorProvider2.SetError(tb3CNP, "CNP gol");
                result = false;

            }
            else if (tb3CNP.Text.Trim().Length != 13)
            {
                errorProvider2.SetError(tb3CNP, "CNP incorect (13cifre)");
                result = false;
            }
            else
            {
                try
                {
                    int.TryParse(tb3CNP.Text.Substring(1, 2), out int an);
                    int.TryParse(tb3CNP.Text.Substring(3, 2), out int luna);
                    int.TryParse(tb3CNP.Text.Substring(5, 2), out int zi);
                    DateTime dn = new DateTime(2000 + an, luna, zi);  //poate avem probleme

                }
                catch (Exception ex)
                {
                    result = false;
                    errorProvider2.SetError(tb3CNP, "Probleme la CNP!");
                }



            }
            return result;
        }

        private void btn3Anulare_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
