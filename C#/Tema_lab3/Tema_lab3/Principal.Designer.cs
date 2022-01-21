
namespace Tema_lab3
{
    partial class Principal
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
            this.cmb1Echipa = new System.Windows.Forms.ComboBox();
            this.btn1Echipa = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btn1Jucator = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dt1Data = new System.Windows.Forms.DateTimePicker();
            this.tb1Varsta = new System.Windows.Forms.TextBox();
            this.tb1CNP = new System.Windows.Forms.TextBox();
            this.tb1Post = new System.Windows.Forms.TextBox();
            this.tb1Nume = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Echipa";
            // 
            // cmb1Echipa
            // 
            this.cmb1Echipa.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmb1Echipa.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cmb1Echipa.FormattingEnabled = true;
            this.cmb1Echipa.Location = new System.Drawing.Point(109, 27);
            this.cmb1Echipa.Name = "cmb1Echipa";
            this.cmb1Echipa.Size = new System.Drawing.Size(121, 23);
            this.cmb1Echipa.TabIndex = 1;
            this.cmb1Echipa.SelectedIndexChanged += new System.EventHandler(this.cmb1Echipa_SelectedIndexChanged);
            // 
            // btn1Echipa
            // 
            this.btn1Echipa.Location = new System.Drawing.Point(236, 27);
            this.btn1Echipa.Name = "btn1Echipa";
            this.btn1Echipa.Size = new System.Drawing.Size(105, 23);
            this.btn1Echipa.TabIndex = 2;
            this.btn1Echipa.Text = "Echipa noua";
            this.btn1Echipa.UseVisualStyleBackColor = true;
            this.btn1Echipa.Click += new System.EventHandler(this.btn1Echipa_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(41, 97);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(300, 214);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // btn1Jucator
            // 
            this.btn1Jucator.Location = new System.Drawing.Point(236, 326);
            this.btn1Jucator.Name = "btn1Jucator";
            this.btn1Jucator.Size = new System.Drawing.Size(105, 23);
            this.btn1Jucator.TabIndex = 5;
            this.btn1Jucator.Text = "Jucator nou";
            this.btn1Jucator.UseVisualStyleBackColor = true;
            this.btn1Jucator.Click += new System.EventHandler(this.btn1Jucator_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dt1Data);
            this.groupBox1.Controls.Add(this.tb1Varsta);
            this.groupBox1.Controls.Add(this.tb1CNP);
            this.groupBox1.Controls.Add(this.tb1Post);
            this.groupBox1.Controls.Add(this.tb1Nume);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(379, 97);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(347, 214);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detalii jucator";
            // 
            // dt1Data
            // 
            this.dt1Data.CustomFormat = "dd.MM.yyyy";
            this.dt1Data.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt1Data.Location = new System.Drawing.Point(87, 125);
            this.dt1Data.Name = "dt1Data";
            this.dt1Data.Size = new System.Drawing.Size(178, 23);
            this.dt1Data.TabIndex = 3;
            // 
            // tb1Varsta
            // 
            this.tb1Varsta.Location = new System.Drawing.Point(85, 154);
            this.tb1Varsta.Name = "tb1Varsta";
            this.tb1Varsta.Size = new System.Drawing.Size(180, 23);
            this.tb1Varsta.TabIndex = 2;
            // 
            // tb1CNP
            // 
            this.tb1CNP.Location = new System.Drawing.Point(85, 94);
            this.tb1CNP.Name = "tb1CNP";
            this.tb1CNP.Size = new System.Drawing.Size(180, 23);
            this.tb1CNP.TabIndex = 2;
            // 
            // tb1Post
            // 
            this.tb1Post.Location = new System.Drawing.Point(85, 64);
            this.tb1Post.Name = "tb1Post";
            this.tb1Post.Size = new System.Drawing.Size(180, 23);
            this.tb1Post.TabIndex = 2;
            // 
            // tb1Nume
            // 
            this.tb1Nume.Location = new System.Drawing.Point(85, 35);
            this.tb1Nume.Name = "tb1Nume";
            this.tb1Nume.Size = new System.Drawing.Size(180, 23);
            this.tb1Nume.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 15);
            this.label5.TabIndex = 1;
            this.label5.Text = "Data nasterii:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 157);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label6.Size = new System.Drawing.Size(41, 15);
            this.label6.TabIndex = 1;
            this.label6.Text = "Varsta:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 97);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label4.Size = new System.Drawing.Size(34, 15);
            this.label4.TabIndex = 1;
            this.label4.Text = "CNP:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "Post:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nume:";
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 421);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn1Jucator);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.btn1Echipa);
            this.Controls.Add(this.cmb1Echipa);
            this.Controls.Add(this.label1);
            this.Name = "Principal";
            this.Text = "Principal";
            this.Load += new System.EventHandler(this.Principal_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb1Echipa;
        private System.Windows.Forms.Button btn1Echipa;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btn1Jucator;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dt1Data;
        private System.Windows.Forms.TextBox tb1Post;
        private System.Windows.Forms.TextBox tb1Nume;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb1Varsta;
        private System.Windows.Forms.TextBox tb1CNP;
        private System.Windows.Forms.Label label6;
    }
}