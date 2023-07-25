namespace WindowsFormsApplication34
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridViewAngajat = new System.Windows.Forms.DataGridView();
            this.labelInfo = new System.Windows.Forms.Label();
            this.labelErori = new System.Windows.Forms.Label();
            this.Adaugarebtn = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.ActualizareBtn = new System.Windows.Forms.Button();
            this.dataGridViewProcente = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cautareTextBox = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button5 = new System.Windows.Forms.Button();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.button1 = new System.Windows.Forms.Button();
            this.modificareDateBtn = new System.Windows.Forms.Button();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAngajat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProcente)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewAngajat
            // 
            this.dataGridViewAngajat.AllowUserToAddRows = false;
            this.dataGridViewAngajat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAngajat.Location = new System.Drawing.Point(4, 18);
            this.dataGridViewAngajat.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewAngajat.Name = "dataGridViewAngajat";
            this.dataGridViewAngajat.Size = new System.Drawing.Size(2023, 404);
            this.dataGridViewAngajat.TabIndex = 0;
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.Location = new System.Drawing.Point(23, 523);
            this.labelInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(46, 17);
            this.labelInfo.TabIndex = 1;
            this.labelInfo.Text = "label1";
            // 
            // labelErori
            // 
            this.labelErori.AutoSize = true;
            this.labelErori.Location = new System.Drawing.Point(23, 482);
            this.labelErori.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelErori.Name = "labelErori";
            this.labelErori.Size = new System.Drawing.Size(46, 17);
            this.labelErori.TabIndex = 2;
            this.labelErori.Text = "label2";
            // 
            // Adaugarebtn
            // 
            this.Adaugarebtn.Location = new System.Drawing.Point(26, 566);
            this.Adaugarebtn.Margin = new System.Windows.Forms.Padding(4);
            this.Adaugarebtn.Name = "Adaugarebtn";
            this.Adaugarebtn.Size = new System.Drawing.Size(120, 50);
            this.Adaugarebtn.TabIndex = 3;
            this.Adaugarebtn.Text = "Adaugare Angajat";
            this.Adaugarebtn.UseVisualStyleBackColor = true;
            this.Adaugarebtn.Click += new System.EventHandler(this.Adaugare_click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(26, 696);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(120, 50);
            this.button2.TabIndex = 3;
            this.button2.Text = "Stergere";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Stergere_Click);
            // 
            // ActualizareBtn
            // 
            this.ActualizareBtn.Location = new System.Drawing.Point(187, 566);
            this.ActualizareBtn.Margin = new System.Windows.Forms.Padding(4);
            this.ActualizareBtn.Name = "ActualizareBtn";
            this.ActualizareBtn.Size = new System.Drawing.Size(129, 46);
            this.ActualizareBtn.TabIndex = 3;
            this.ActualizareBtn.Text = "Actualizare";
            this.ActualizareBtn.UseVisualStyleBackColor = true;
            this.ActualizareBtn.Click += new System.EventHandler(this.Actualizare_Click);
            // 
            // dataGridViewProcente
            // 
            this.dataGridViewProcente.AllowUserToAddRows = false;
            this.dataGridViewProcente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProcente.Location = new System.Drawing.Point(15, 23);
            this.dataGridViewProcente.Name = "dataGridViewProcente";
            this.dataGridViewProcente.RowTemplate.Height = 24;
            this.dataGridViewProcente.Size = new System.Drawing.Size(917, 146);
            this.dataGridViewProcente.TabIndex = 7;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(6, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(2487, 815);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.cautareTextBox);
            this.tabPage1.Controls.Add(this.dataGridViewAngajat);
            this.tabPage1.Controls.Add(this.Adaugarebtn);
            this.tabPage1.Controls.Add(this.labelInfo);
            this.tabPage1.Controls.Add(this.labelErori);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.ActualizareBtn);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(2479, 786);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Angajati";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(69, 639);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Cautare";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(194, 675);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 17);
            this.label1.TabIndex = 8;
            // 
            // cautareTextBox
            // 
            this.cautareTextBox.Location = new System.Drawing.Point(187, 634);
            this.cautareTextBox.Name = "cautareTextBox";
            this.cautareTextBox.Size = new System.Drawing.Size(129, 22);
            this.cautareTextBox.TabIndex = 6;
            this.cautareTextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button5);
            this.tabPage2.Controls.Add(this.crystalReportViewer1);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.modificareDateBtn);
            this.tabPage2.Controls.Add(this.dataGridViewProcente);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(2479, 786);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Procente";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(1171, 23);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(152, 65);
            this.button5.TabIndex = 11;
            this.button5.Text = "Afisare Raport";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.crystalReportViewer1.Location = new System.Drawing.Point(3, 207);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(2473, 576);
            this.crystalReportViewer1.TabIndex = 10;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(985, 115);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(149, 54);
            this.button1.TabIndex = 9;
            this.button1.Text = "Actualizare";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // modificareDateBtn
            // 
            this.modificareDateBtn.Location = new System.Drawing.Point(985, 23);
            this.modificareDateBtn.Name = "modificareDateBtn";
            this.modificareDateBtn.Size = new System.Drawing.Size(149, 65);
            this.modificareDateBtn.TabIndex = 8;
            this.modificareDateBtn.Text = "Modificare Date";
            this.modificareDateBtn.UseVisualStyleBackColor = true;
            this.modificareDateBtn.Click += new System.EventHandler(this.modificareprocente_click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2493, 846);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAngajat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProcente)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewAngajat;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.Label labelErori;
        private System.Windows.Forms.Button Adaugarebtn;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button ActualizareBtn;
        private System.Windows.Forms.DataGridView dataGridViewProcente;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.TextBox cautareTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button modificareDateBtn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button5;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
    }
}

