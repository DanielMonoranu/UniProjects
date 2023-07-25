namespace WindowsFormsApplication34
{
    partial class Modificare
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
            this.anulareBtn = new System.Windows.Forms.Button();
            this.ModificareBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.parolaTextBox = new System.Windows.Forms.TextBox();
            this.EroriLAbel = new System.Windows.Forms.Label();
            this.CASnumeric = new System.Windows.Forms.NumericUpDown();
            this.CASSNumeric = new System.Windows.Forms.NumericUpDown();
            this.ImpozitNumeric = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.CASnumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CASSNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImpozitNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // anulareBtn
            // 
            this.anulareBtn.Location = new System.Drawing.Point(46, 247);
            this.anulareBtn.Name = "anulareBtn";
            this.anulareBtn.Size = new System.Drawing.Size(100, 48);
            this.anulareBtn.TabIndex = 19;
            this.anulareBtn.Text = "Anulare";
            this.anulareBtn.UseVisualStyleBackColor = true;
            this.anulareBtn.Click += new System.EventHandler(this.anulareBtn_Click);
            // 
            // ModificareBtn
            // 
            this.ModificareBtn.Location = new System.Drawing.Point(163, 247);
            this.ModificareBtn.Name = "ModificareBtn";
            this.ModificareBtn.Size = new System.Drawing.Size(101, 48);
            this.ModificareBtn.TabIndex = 18;
            this.ModificareBtn.Text = "Modificare";
            this.ModificareBtn.UseVisualStyleBackColor = true;
            this.ModificareBtn.Click += new System.EventHandler(this.ModificareBtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(56, 171);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "PAROLA";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(57, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "IMPOZIT";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 17);
            this.label2.TabIndex = 13;
            this.label2.Text = "CASS %";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 17);
            this.label1.TabIndex = 14;
            this.label1.Text = "CAS %";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // parolaTextBox
            // 
            this.parolaTextBox.Location = new System.Drawing.Point(163, 166);
            this.parolaTextBox.Name = "parolaTextBox";
            this.parolaTextBox.Size = new System.Drawing.Size(100, 22);
            this.parolaTextBox.TabIndex = 17;
            this.parolaTextBox.UseSystemPasswordChar = true;
            this.parolaTextBox.TextChanged += new System.EventHandler(this.parolaTextBox_TextChanged);
            // 
            // EroriLAbel
            // 
            this.EroriLAbel.AutoSize = true;
            this.EroriLAbel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EroriLAbel.ForeColor = System.Drawing.Color.Red;
            this.EroriLAbel.Location = new System.Drawing.Point(55, 314);
            this.EroriLAbel.Name = "EroriLAbel";
            this.EroriLAbel.Size = new System.Drawing.Size(0, 25);
            this.EroriLAbel.TabIndex = 20;
            this.EroriLAbel.Click += new System.EventHandler(this.EroriLAbel_Click);
            // 
            // CASnumeric
            // 
            this.CASnumeric.DecimalPlaces = 2;
            this.CASnumeric.Location = new System.Drawing.Point(144, 31);
            this.CASnumeric.Name = "CASnumeric";
            this.CASnumeric.Size = new System.Drawing.Size(120, 22);
            this.CASnumeric.TabIndex = 21;
            this.CASnumeric.ValueChanged += new System.EventHandler(this.CASnumeric_ValueChanged);
            this.CASnumeric.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CASnumeric_KeyPress);
            // 
            // CASSNumeric
            // 
            this.CASSNumeric.DecimalPlaces = 2;
            this.CASSNumeric.Location = new System.Drawing.Point(144, 73);
            this.CASSNumeric.Name = "CASSNumeric";
            this.CASSNumeric.Size = new System.Drawing.Size(120, 22);
            this.CASSNumeric.TabIndex = 21;
            this.CASSNumeric.ValueChanged += new System.EventHandler(this.CASSNumeric_ValueChanged);
            this.CASSNumeric.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CASSNumeric_KeyPress);
            // 
            // ImpozitNumeric
            // 
            this.ImpozitNumeric.DecimalPlaces = 2;
            this.ImpozitNumeric.Location = new System.Drawing.Point(144, 120);
            this.ImpozitNumeric.Name = "ImpozitNumeric";
            this.ImpozitNumeric.Size = new System.Drawing.Size(120, 22);
            this.ImpozitNumeric.TabIndex = 21;
            this.ImpozitNumeric.ValueChanged += new System.EventHandler(this.ImpozitNumeric_ValueChanged);
            this.ImpozitNumeric.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ImpozitNumeric_KeyPress);
            // 
            // Modificare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 386);
            this.Controls.Add(this.ImpozitNumeric);
            this.Controls.Add(this.CASSNumeric);
            this.Controls.Add(this.CASnumeric);
            this.Controls.Add(this.EroriLAbel);
            this.Controls.Add(this.anulareBtn);
            this.Controls.Add(this.ModificareBtn);
            this.Controls.Add(this.parolaTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Modificare";
            this.Text = "Modificare";
            ((System.ComponentModel.ISupportInitialize)(this.CASnumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CASSNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImpozitNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button anulareBtn;
        private System.Windows.Forms.Button ModificareBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox parolaTextBox;
        private System.Windows.Forms.Label EroriLAbel;
        private System.Windows.Forms.NumericUpDown CASnumeric;
        private System.Windows.Forms.NumericUpDown CASSNumeric;
        private System.Windows.Forms.NumericUpDown ImpozitNumeric;
    }
}