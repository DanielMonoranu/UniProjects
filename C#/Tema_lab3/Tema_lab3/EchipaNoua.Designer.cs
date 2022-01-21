
namespace Tema_lab3
{
    partial class EchipaNoua
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
            this.label1 = new System.Windows.Forms.Label();
            this.tb2NumeEchipa = new System.Windows.Forms.TextBox();
            this.btn2Adauga = new System.Windows.Forms.Button();
            this.btn2Anulare = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nume";
            // 
            // tb2NumeEchipa
            // 
            this.tb2NumeEchipa.Location = new System.Drawing.Point(111, 37);
            this.tb2NumeEchipa.Name = "tb2NumeEchipa";
            this.tb2NumeEchipa.Size = new System.Drawing.Size(100, 23);
            this.tb2NumeEchipa.TabIndex = 2;
            // 
            // btn2Adauga
            // 
            this.btn2Adauga.Location = new System.Drawing.Point(37, 93);
            this.btn2Adauga.Name = "btn2Adauga";
            this.btn2Adauga.Size = new System.Drawing.Size(75, 23);
            this.btn2Adauga.TabIndex = 3;
            this.btn2Adauga.Text = "Adauga";
            this.btn2Adauga.UseVisualStyleBackColor = true;
            this.btn2Adauga.Click += new System.EventHandler(this.btn2Adauga_Click);
            // 
            // btn2Anulare
            // 
            this.btn2Anulare.Location = new System.Drawing.Point(136, 93);
            this.btn2Anulare.Name = "btn2Anulare";
            this.btn2Anulare.Size = new System.Drawing.Size(75, 23);
            this.btn2Anulare.TabIndex = 3;
            this.btn2Anulare.Text = "Anulare";
            this.btn2Anulare.UseVisualStyleBackColor = true;
            this.btn2Anulare.Click += new System.EventHandler(this.btn2Anulare_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // EchipaNoua
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(241, 153);
            this.Controls.Add(this.btn2Anulare);
            this.Controls.Add(this.btn2Adauga);
            this.Controls.Add(this.tb2NumeEchipa);
            this.Controls.Add(this.label1);
            this.Name = "EchipaNoua";
            this.Text = "EchipaNoua";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb2NumeEchipa;
        private System.Windows.Forms.Button btn2Adauga;
        private System.Windows.Forms.Button btn2Anulare;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}