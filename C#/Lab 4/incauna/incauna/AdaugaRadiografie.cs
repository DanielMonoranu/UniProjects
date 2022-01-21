using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace incauna
{
    public partial class AdaugareRadiografie : Form
    {

        public string CNP { get => tb2CNP.Text; set => tb2CNP.Text = value; }

        public DateTime Data { get => dtp2Date.Value; set => dtp2Date.Value = value; }
        public string Imagine { get => tb2Imagine.Text; set => tb2Imagine.Text = value; }
        public string Diagnostic { get => tb2Diagnostic.Text; set => tb2Diagnostic.Text = value; }
        public string Comentarii { get => tb2Comentarii.Text; set => tb2Comentarii.Text = value; }

        public AdaugareRadiografie()
        {
            InitializeComponent();
        }



        private void btn2Puncte_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = Application.StartupPath;
            dialog.Filter = "*.jpg|*.jpg";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                //pictureBox1.Image = Bitmap.FromFile(dialog.FileName);
                // label1.Text = dialog.FileName;
                tb2Imagine.Text = dialog.FileName;
            }

        }

        private void btn2Cancel_Click(object sender, EventArgs e)
        {

        }

        private void btn2OK_Click_1(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btn2Cancel_Click_1(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}

