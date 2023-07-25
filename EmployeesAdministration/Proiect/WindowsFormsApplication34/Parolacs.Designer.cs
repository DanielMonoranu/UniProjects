namespace WindowsFormsApplication34
{
    partial class Parolacs
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
            this.label2 = new System.Windows.Forms.Label();
            this.parolaTextBox = new System.Windows.Forms.TextBox();
            this.enterButton = new System.Windows.Forms.Button();
            this.eroarelabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(66, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Introduceti parola";
            // 
            // parolaTextBox
            // 
            this.parolaTextBox.Location = new System.Drawing.Point(84, 78);
            this.parolaTextBox.Name = "parolaTextBox";
            this.parolaTextBox.Size = new System.Drawing.Size(100, 22);
            this.parolaTextBox.TabIndex = 2;
            this.parolaTextBox.UseSystemPasswordChar = true;
            this.parolaTextBox.TextChanged += new System.EventHandler(this.parolaTextBox_TextChanged);
            // 
            // enterButton
            // 
            this.enterButton.Location = new System.Drawing.Point(94, 117);
            this.enterButton.Name = "enterButton";
            this.enterButton.Size = new System.Drawing.Size(75, 23);
            this.enterButton.TabIndex = 3;
            this.enterButton.Text = "Enter";
            this.enterButton.UseVisualStyleBackColor = true;
            this.enterButton.Click += new System.EventHandler(this.enterButton_Click);
            // 
            // eroarelabel
            // 
            this.eroarelabel.AutoSize = true;
            this.eroarelabel.Location = new System.Drawing.Point(12, 155);
            this.eroarelabel.Name = "eroarelabel";
            this.eroarelabel.Size = new System.Drawing.Size(0, 17);
            this.eroarelabel.TabIndex = 4;
            this.eroarelabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Parolacs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(271, 198);
            this.Controls.Add(this.eroarelabel);
            this.Controls.Add(this.enterButton);
            this.Controls.Add(this.parolaTextBox);
            this.Controls.Add(this.label2);
            this.Name = "Parolacs";
            this.Text = "Parolacs";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox parolaTextBox;
        private System.Windows.Forms.Button enterButton;
        private System.Windows.Forms.Label eroarelabel;
    }
}