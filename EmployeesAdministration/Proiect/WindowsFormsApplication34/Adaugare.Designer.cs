namespace WindowsFormsApplication34
{
    partial class Adaugare
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Spor = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.FunctieTextBox = new System.Windows.Forms.TextBox();
            this.prenumeTextBox = new System.Windows.Forms.TextBox();
            this.numeTextBox = new System.Windows.Forms.TextBox();
            this.AdaugareBtn = new System.Windows.Forms.Button();
            this.anulareBtn = new System.Windows.Forms.Button();
            this.SalarBazaNumeric = new System.Windows.Forms.NumericUpDown();
            this.SporNumeric = new System.Windows.Forms.NumericUpDown();
            this.PremiiBruteNumeric = new System.Windows.Forms.NumericUpDown();
            this.EroriLAbel = new System.Windows.Forms.Label();
            this.retineriNumeric = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.SalarBazaNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SporNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PremiiBruteNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.retineriNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nume";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Prenume";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Functie";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Salar de baza";
            // 
            // Spor
            // 
            this.Spor.AutoSize = true;
            this.Spor.Location = new System.Drawing.Point(35, 201);
            this.Spor.Name = "Spor";
            this.Spor.Size = new System.Drawing.Size(54, 17);
            this.Spor.TabIndex = 0;
            this.Spor.Text = "Spor %";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(35, 251);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "Premii brute";
            // 
            // FunctieTextBox
            // 
            this.FunctieTextBox.Location = new System.Drawing.Point(141, 104);
            this.FunctieTextBox.Name = "FunctieTextBox";
            this.FunctieTextBox.Size = new System.Drawing.Size(100, 22);
            this.FunctieTextBox.TabIndex = 1;
            this.FunctieTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FunctieTextBox_KeyPress);
            // 
            // prenumeTextBox
            // 
            this.prenumeTextBox.Location = new System.Drawing.Point(142, 57);
            this.prenumeTextBox.Name = "prenumeTextBox";
            this.prenumeTextBox.Size = new System.Drawing.Size(100, 22);
            this.prenumeTextBox.TabIndex = 1;
            this.prenumeTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.prenumeTextBox_KeyPress);
            // 
            // numeTextBox
            // 
            this.numeTextBox.Location = new System.Drawing.Point(141, 20);
            this.numeTextBox.Name = "numeTextBox";
            this.numeTextBox.Size = new System.Drawing.Size(100, 22);
            this.numeTextBox.TabIndex = 1;
            this.numeTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numeTextBox_KeyPress);
            // 
            // AdaugareBtn
            // 
            this.AdaugareBtn.Location = new System.Drawing.Point(140, 324);
            this.AdaugareBtn.Name = "AdaugareBtn";
            this.AdaugareBtn.Size = new System.Drawing.Size(101, 48);
            this.AdaugareBtn.TabIndex = 2;
            this.AdaugareBtn.Text = "Adaugare";
            this.AdaugareBtn.UseVisualStyleBackColor = true;
            this.AdaugareBtn.Click += new System.EventHandler(this.AdaugareBtn_Click);
            // 
            // anulareBtn
            // 
            this.anulareBtn.Location = new System.Drawing.Point(34, 324);
            this.anulareBtn.Name = "anulareBtn";
            this.anulareBtn.Size = new System.Drawing.Size(100, 48);
            this.anulareBtn.TabIndex = 3;
            this.anulareBtn.Text = "Anulare";
            this.anulareBtn.UseVisualStyleBackColor = true;
            this.anulareBtn.Click += new System.EventHandler(this.anulareBtn_Click);
            // 
            // SalarBazaNumeric
            // 
            this.SalarBazaNumeric.Location = new System.Drawing.Point(141, 153);
            this.SalarBazaNumeric.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.SalarBazaNumeric.Name = "SalarBazaNumeric";
            this.SalarBazaNumeric.Size = new System.Drawing.Size(120, 22);
            this.SalarBazaNumeric.TabIndex = 4;
            this.SalarBazaNumeric.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SalarBazaNumeric_KeyPress);
            // 
            // SporNumeric
            // 
            this.SporNumeric.Location = new System.Drawing.Point(142, 199);
            this.SporNumeric.Name = "SporNumeric";
            this.SporNumeric.Size = new System.Drawing.Size(120, 22);
            this.SporNumeric.TabIndex = 4;
            this.SporNumeric.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SporNumeric_KeyPress);
            // 
            // PremiiBruteNumeric
            // 
            this.PremiiBruteNumeric.Location = new System.Drawing.Point(141, 246);
            this.PremiiBruteNumeric.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.PremiiBruteNumeric.Name = "PremiiBruteNumeric";
            this.PremiiBruteNumeric.Size = new System.Drawing.Size(120, 22);
            this.PremiiBruteNumeric.TabIndex = 4;
            this.PremiiBruteNumeric.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PremiiBruteNumeric_KeyPress);
            // 
            // EroriLAbel
            // 
            this.EroriLAbel.AutoSize = true;
            this.EroriLAbel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EroriLAbel.ForeColor = System.Drawing.Color.Red;
            this.EroriLAbel.Location = new System.Drawing.Point(6, 387);
            this.EroriLAbel.Name = "EroriLAbel";
            this.EroriLAbel.Size = new System.Drawing.Size(0, 25);
            this.EroriLAbel.TabIndex = 6;
            // 
            // retineriNumeric
            // 
            this.retineriNumeric.Location = new System.Drawing.Point(140, 284);
            this.retineriNumeric.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.retineriNumeric.Name = "retineriNumeric";
            this.retineriNumeric.Size = new System.Drawing.Size(120, 22);
            this.retineriNumeric.TabIndex = 8;
            this.retineriNumeric.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.retineriNumeric_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 289);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "Retineri";
            // 
            // Adaugare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 472);
            this.Controls.Add(this.retineriNumeric);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.EroriLAbel);
            this.Controls.Add(this.PremiiBruteNumeric);
            this.Controls.Add(this.SporNumeric);
            this.Controls.Add(this.SalarBazaNumeric);
            this.Controls.Add(this.anulareBtn);
            this.Controls.Add(this.AdaugareBtn);
            this.Controls.Add(this.numeTextBox);
            this.Controls.Add(this.prenumeTextBox);
            this.Controls.Add(this.FunctieTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Spor);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Adaugare";
            this.Text = "Adaugare";
            ((System.ComponentModel.ISupportInitialize)(this.SalarBazaNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SporNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PremiiBruteNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.retineriNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label Spor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox FunctieTextBox;
        private System.Windows.Forms.TextBox prenumeTextBox;
        private System.Windows.Forms.TextBox numeTextBox;
        private System.Windows.Forms.Button AdaugareBtn;
        private System.Windows.Forms.Button anulareBtn;
        private System.Windows.Forms.NumericUpDown SalarBazaNumeric;
        private System.Windows.Forms.NumericUpDown SporNumeric;
        private System.Windows.Forms.NumericUpDown PremiiBruteNumeric;
        private System.Windows.Forms.Label EroriLAbel;
        private System.Windows.Forms.NumericUpDown retineriNumeric;
        private System.Windows.Forms.Label label5;
    }
}