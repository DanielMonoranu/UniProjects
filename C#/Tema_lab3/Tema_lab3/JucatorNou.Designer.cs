
namespace Tema_lab3
{
    partial class JucatorNou
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
            this.btn3Adauga = new System.Windows.Forms.Button();
            this.tb3Nume = new System.Windows.Forms.TextBox();
            this.cmb3Post = new System.Windows.Forms.ComboBox();
            this.tb3CNP = new System.Windows.Forms.TextBox();
            this.btn3Anulare = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider2 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nume:";
            // 
            // btn3Adauga
            // 
            this.btn3Adauga.Location = new System.Drawing.Point(21, 121);
            this.btn3Adauga.Name = "btn3Adauga";
            this.btn3Adauga.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btn3Adauga.Size = new System.Drawing.Size(75, 23);
            this.btn3Adauga.TabIndex = 1;
            this.btn3Adauga.Text = "Adauga";
            this.btn3Adauga.UseVisualStyleBackColor = true;
            this.btn3Adauga.Click += new System.EventHandler(this.btn3Adauga_Click);
            // 
            // tb3Nume
            // 
            this.tb3Nume.Location = new System.Drawing.Point(79, 36);
            this.tb3Nume.Name = "tb3Nume";
            this.tb3Nume.Size = new System.Drawing.Size(100, 23);
            this.tb3Nume.TabIndex = 2;
            // 
            // cmb3Post
            // 
            this.cmb3Post.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb3Post.FormattingEnabled = true;
            this.cmb3Post.Items.AddRange(new object[] {
            "Portar",
            "Fundas",
            "Mijlocas",
            "Atacant"});
            this.cmb3Post.Location = new System.Drawing.Point(79, 63);
            this.cmb3Post.Name = "cmb3Post";
            this.cmb3Post.Size = new System.Drawing.Size(100, 23);
            this.cmb3Post.TabIndex = 3;
            // 
            // tb3CNP
            // 
            this.tb3CNP.Location = new System.Drawing.Point(79, 92);
            this.tb3CNP.Name = "tb3CNP";
            this.tb3CNP.Size = new System.Drawing.Size(100, 23);
            this.tb3CNP.TabIndex = 2;
            // 
            // btn3Anulare
            // 
            this.btn3Anulare.Location = new System.Drawing.Point(106, 121);
            this.btn3Anulare.Name = "btn3Anulare";
            this.btn3Anulare.Size = new System.Drawing.Size(75, 23);
            this.btn3Anulare.TabIndex = 1;
            this.btn3Anulare.Text = "Anulare";
            this.btn3Anulare.UseVisualStyleBackColor = true;
            this.btn3Anulare.Click += new System.EventHandler(this.btn3Anulare_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Post:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "CNP:";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // errorProvider2
            // 
            this.errorProvider2.ContainerControl = this;
            // 
            // JucatorNou
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(210, 177);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmb3Post);
            this.Controls.Add(this.tb3CNP);
            this.Controls.Add(this.tb3Nume);
            this.Controls.Add(this.btn3Anulare);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn3Adauga);
            this.Controls.Add(this.label1);
            this.Name = "JucatorNou";
            this.Text = "JucatorNou";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn3Adauga;
        private System.Windows.Forms.TextBox tb3Nume;
        private System.Windows.Forms.ComboBox cmb3Post;
        private System.Windows.Forms.TextBox tb3CNP;
        private System.Windows.Forms.Button btn3Anulare;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ErrorProvider errorProvider2;
    }
}