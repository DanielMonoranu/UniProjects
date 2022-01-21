
namespace incauna
{
    partial class AdaugareRadiografie
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
            this.dtp2Date = new System.Windows.Forms.DateTimePicker();
            this.tb2Comentarii = new System.Windows.Forms.TextBox();
            this.tb2Diagnostic = new System.Windows.Forms.TextBox();
            this.tb2Imagine = new System.Windows.Forms.TextBox();
            this.tb2CNP = new System.Windows.Forms.TextBox();
            this.btn2Cancel = new System.Windows.Forms.Button();
            this.btn2OK = new System.Windows.Forms.Button();
            this.btn2Puncte = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dtp2Date
            // 
            this.dtp2Date.CustomFormat = "dd.MM.yyyy";
            this.dtp2Date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp2Date.Location = new System.Drawing.Point(97, 71);
            this.dtp2Date.Name = "dtp2Date";
            this.dtp2Date.Size = new System.Drawing.Size(163, 20);
            this.dtp2Date.TabIndex = 29;
            // 
            // tb2Comentarii
            // 
            this.tb2Comentarii.Location = new System.Drawing.Point(97, 172);
            this.tb2Comentarii.Multiline = true;
            this.tb2Comentarii.Name = "tb2Comentarii";
            this.tb2Comentarii.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tb2Comentarii.Size = new System.Drawing.Size(174, 72);
            this.tb2Comentarii.TabIndex = 25;
            // 
            // tb2Diagnostic
            // 
            this.tb2Diagnostic.Location = new System.Drawing.Point(97, 143);
            this.tb2Diagnostic.Name = "tb2Diagnostic";
            this.tb2Diagnostic.Size = new System.Drawing.Size(163, 20);
            this.tb2Diagnostic.TabIndex = 26;
            // 
            // tb2Imagine
            // 
            this.tb2Imagine.Location = new System.Drawing.Point(97, 105);
            this.tb2Imagine.Name = "tb2Imagine";
            this.tb2Imagine.Size = new System.Drawing.Size(100, 20);
            this.tb2Imagine.TabIndex = 27;
            // 
            // tb2CNP
            // 
            this.tb2CNP.Location = new System.Drawing.Point(97, 29);
            this.tb2CNP.Name = "tb2CNP";
            this.tb2CNP.Size = new System.Drawing.Size(163, 20);
            this.tb2CNP.TabIndex = 28;
            // 
            // btn2Cancel
            // 
            this.btn2Cancel.Location = new System.Drawing.Point(162, 256);
            this.btn2Cancel.Name = "btn2Cancel";
            this.btn2Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn2Cancel.TabIndex = 22;
            this.btn2Cancel.Text = "Cancel";
            this.btn2Cancel.UseVisualStyleBackColor = true;
            this.btn2Cancel.Click += new System.EventHandler(this.btn2Cancel_Click_1);
            // 
            // btn2OK
            // 
            this.btn2OK.Location = new System.Drawing.Point(41, 256);
            this.btn2OK.Name = "btn2OK";
            this.btn2OK.Size = new System.Drawing.Size(75, 23);
            this.btn2OK.TabIndex = 23;
            this.btn2OK.Text = "OK";
            this.btn2OK.UseVisualStyleBackColor = true;
            this.btn2OK.Click += new System.EventHandler(this.btn2OK_Click_1);
            // 
            // btn2Puncte
            // 
            this.btn2Puncte.Location = new System.Drawing.Point(215, 103);
            this.btn2Puncte.Name = "btn2Puncte";
            this.btn2Puncte.Size = new System.Drawing.Size(45, 23);
            this.btn2Puncte.TabIndex = 24;
            this.btn2Puncte.Text = "...";
            this.btn2Puncte.UseVisualStyleBackColor = true;
            this.btn2Puncte.Click += new System.EventHandler(this.btn2Puncte_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 187);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Comentarii";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Diagnostic";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Imagine";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Data";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "CNP";
            // 
            // AdaugareRadiografie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 316);
            this.Controls.Add(this.dtp2Date);
            this.Controls.Add(this.tb2Comentarii);
            this.Controls.Add(this.tb2Diagnostic);
            this.Controls.Add(this.tb2Imagine);
            this.Controls.Add(this.tb2CNP);
            this.Controls.Add(this.btn2Cancel);
            this.Controls.Add(this.btn2OK);
            this.Controls.Add(this.btn2Puncte);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AdaugareRadiografie";
            this.Text = "AdaugaRadiografie";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtp2Date;
        private System.Windows.Forms.TextBox tb2Comentarii;
        private System.Windows.Forms.TextBox tb2Diagnostic;
        private System.Windows.Forms.TextBox tb2Imagine;
        private System.Windows.Forms.TextBox tb2CNP;
        private System.Windows.Forms.Button btn2Cancel;
        private System.Windows.Forms.Button btn2OK;
        private System.Windows.Forms.Button btn2Puncte;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}