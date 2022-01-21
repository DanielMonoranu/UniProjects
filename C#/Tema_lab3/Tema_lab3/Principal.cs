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
    public partial class Principal : Form
    {
        public Principal()
        {

            InitializeComponent();
            IncarcaEchipe();
        }

        private void IncarcaEchipe()
        {

            flowLayoutPanel1.Controls.Clear();
            cmb1Echipa.Items.Clear();
            //MessageBox.Show(Application.StartupPath.ToString());
            foreach (string dirPath in Directory.EnumerateDirectories(Application.StartupPath + "\\Echipe\\"))
            {
                DirectoryInfo dirName = new DirectoryInfo(dirPath);
                cmb1Echipa.Items.Add(dirName.Name);
            }

        }

        private void Principal_Load(object sender, EventArgs e)
        {
            
            Login login = new Login();
            
            if (login.ShowDialog() == DialogResult.Cancel)
            {
                this.Close();
            }
            


        }

        private void btn1Echipa_Click(object sender, EventArgs e)
        {
            EchipaNoua echipa = new EchipaNoua();
            if (echipa.ShowDialog() == DialogResult.OK)
                IncarcaEchipe();
        }

        private void btn1Jucator_Click(object sender, EventArgs e)
        {
            JucatorNou jucator = new JucatorNou();

            if (jucator.ShowDialog() == DialogResult.OK)
            {
                string filename = Application.StartupPath + "\\Echipe\\" + "\\" + cmb1Echipa.Text + "\\" + jucator.Cnp + ".lpf";
                using (StreamWriter sw = new StreamWriter(filename))
                {
                    sw.WriteLine(jucator.Nume);
                    sw.WriteLine(jucator.Post);
                }
                IncarcaJucatoriEchipa(cmb1Echipa.Text);


            }



        }

        private void IncarcaJucatoriEchipa(string echipa)
        {
            flowLayoutPanel1.Controls.Clear();
            string path = Application.StartupPath + "\\Echipe\\" + echipa;
            foreach (string fileName in Directory.EnumerateFiles(path, "*lpf"))
            {
                using (StreamReader sr = new StreamReader(fileName))
                {
                    string cnp = Path.GetFileNameWithoutExtension(fileName);
                    string nume = sr.ReadLine();
                    Post post = (Post)Enum.Parse(typeof(Post), sr.ReadLine());
                    Jucator j = new Jucator(nume, cnp, post);

                    Button btn = new Button();
                    btn.Text = j.Nume;
                    btn.Width = 200;
                    btn.Tag = j;
                    flowLayoutPanel1.Controls.Add(btn);
          
                    btn.Click += Btn_Click;
                }
            }
        }



        /*  //Metoda anonima pt transmitere date la eveniment:
           button.Click += (Sender, E) => {
           Button btn = (Button)Sender;
           Jucator jucator = (Jucator)btn.Tag;
            NumeTextBox.Text = jucator.Nume;
           PostTextBox.Text = jucator.Pozitie.ToString();
           CnptTextBox.Text = jucator.Cnp;
           dataNasteriiDateTimePicker.Value = jucator.DataNasterii;
           VarstaTextBox.Text = jucator.Varsta.ToString();
           MessageBox.Show("Buttonul " + fileName);
       };
*/

        private void Btn_Click(object sender, EventArgs e)
        {

            Button btn = (Button)sender;
            Jucator jucator = (Jucator)btn.Tag;
            tb1Nume.Text = jucator.Nume;
            tb1CNP.Text = jucator.Cnp;
            dt1Data.Value = jucator.DataNasterii;
            tb1Post.Text = jucator.Post.ToString();
            tb1Varsta.Text = jucator.Varsta.ToString();



        }

        private void cmb1Echipa_SelectedIndexChanged(object sender, EventArgs e)
        {
            IncarcaJucatoriEchipa(cmb1Echipa.Text);
        }
    }
}

