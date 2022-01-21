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
    public partial class Form1 : Form
    {
        volatile int i;
        public Form1()
        {
            InitializeComponent();
        }

        private void pacientiBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.pacientiBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.pacientiDataSet);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'pacientiDataSet.Radiografii' table. You can move, or remove it, as needed.
            this.radiografiiTableAdapter.Fill(this.pacientiDataSet.Radiografii);
            // TODO: This line of code loads data into the 'pacientiDataSet.Radiografii' table. You can move, or remove it, as needed.
            this.radiografiiTableAdapter.Fill(this.pacientiDataSet.Radiografii);
            // TODO: This line of code loads data into the 'pacientiDataSet.Pacienti' table. You can move, or remove it, as needed.
            this.pacientiTableAdapter.Fill(this.pacientiDataSet.Pacienti);

            //pictureBox1.Image = Bitmap.FromFile(@"_IMG/01.jpg");
            // pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            //  pictureBox1.Width = 150;
            //pictureBox1.Height = 150;
        }





        private void btn1AdaugaRadiografie_Click_1(object sender, EventArgs e)
        {
            AdaugareRadiografie rad = new AdaugareRadiografie();
            rad.CNP = (string)((DataRowView)pacientiBindingSource.Current)["CNP"];


            if (rad.ShowDialog() == DialogResult.OK)
            {
                Random random = new Random();
                int randomId = random.Next();

                radiografiiTableAdapter.Insert(rad.CNP, rad.Imagine, rad.Data, rad.Diagnostic, rad.Comentarii);


                tableAdapterManager.UpdateAll(pacientiDataSet);
                radiografiiTableAdapter.Fill(pacientiDataSet.Radiografii);

            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.pacientiBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.pacientiDataSet);
        }

        private void pacientiBindingSource_PositionChanged(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            foreach (DataRowView drv in radiografiiBindingSource.List)
            {
                string newline = Environment.NewLine;
                PictureBox pic = new PictureBox();
                pic.SetBounds(0, 0, 100, 100);
                pic.BackColor = Color.Black;
                pic.BorderStyle = BorderStyle.Fixed3D;

                pic.SizeMode = PictureBoxSizeMode.Zoom;

                string img = (string)drv["Imagine"];
                DateTime data = (DateTime)drv["Data"];
                string diagnostic = (string)drv["Diagnostic"];
                string comente = (string)drv["Comentarii"];

                pic.Image = Bitmap.FromFile(img);
                pic.Tag = "Alte informatii despre control";
                flowLayoutPanel1.Controls.Add(pic);


                pic.Click += (Sender, E) =>
                {
                    textBox1.Text = data.ToString() + newline + diagnostic + newline + comente;

                    pictureBox1.Image = ((PictureBox)Sender).Image;
                    pictureBox1.SetBounds(0, 0, 600, 600);
                    pictureBox1.BorderStyle = BorderStyle.Fixed3D;

                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                    panel1.Controls.Add(pictureBox1);
                };

            }

        }

        private void tb1Cautare_TextChanged(object sender, EventArgs e)
        {

            string x = tb1Cautare.Text;


            //pacientiBindingSource.Filter = string.Format("Nume = '{0}'", x);
            pacientiBindingSource.Filter = "Nume LIKE x";

            if (x.Length == 0)
            {
                pacientiBindingSource.RemoveFilter();
            }
        }


    }
}
