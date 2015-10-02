namespace AerolineaFrba
{
    partial class Login
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.wrongLabel = new System.Windows.Forms.Label();
            this.lContrasenia = new System.Windows.Forms.Label();
            this.passBox = new System.Windows.Forms.TextBox();
            this.lUsuario = new System.Windows.Forms.Label();
            this.usrBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Controls.Add(this.wrongLabel);
            this.panel1.Controls.Add(this.lContrasenia);
            this.panel1.Controls.Add(this.passBox);
            this.panel1.Controls.Add(this.lUsuario);
            this.panel1.Controls.Add(this.usrBox);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(442, 190);
            this.panel1.TabIndex = 0;
            // 
            // wrongLabel
            // 
            this.wrongLabel.AutoSize = true;
            this.wrongLabel.BackColor = System.Drawing.Color.Transparent;
            this.wrongLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wrongLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.wrongLabel.Location = new System.Drawing.Point(103, 146);
            this.wrongLabel.Name = "wrongLabel";
            this.wrongLabel.Size = new System.Drawing.Size(0, 20);
            this.wrongLabel.TabIndex = 4;
            // 
            // lContrasenia
            // 
            this.lContrasenia.AutoSize = true;
            this.lContrasenia.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lContrasenia.Location = new System.Drawing.Point(28, 89);
            this.lContrasenia.Name = "lContrasenia";
            this.lContrasenia.Size = new System.Drawing.Size(114, 25);
            this.lContrasenia.TabIndex = 3;
            this.lContrasenia.Text = "Contraseña";
            // 
            // passBox
            // 
            this.passBox.Location = new System.Drawing.Point(149, 92);
            this.passBox.Name = "passBox";
            this.passBox.PasswordChar = '•';
            this.passBox.Size = new System.Drawing.Size(262, 20);
            this.passBox.TabIndex = 2;
            // 
            // lUsuario
            // 
            this.lUsuario.AutoSize = true;
            this.lUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lUsuario.Location = new System.Drawing.Point(28, 40);
            this.lUsuario.Name = "lUsuario";
            this.lUsuario.Size = new System.Drawing.Size(79, 25);
            this.lUsuario.TabIndex = 1;
            this.lUsuario.Text = "Usuario";
            // 
            // usrBox
            // 
            this.usrBox.Location = new System.Drawing.Point(149, 42);
            this.usrBox.Name = "usrBox";
            this.usrBox.Size = new System.Drawing.Size(262, 20);
            this.usrBox.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(12, 208);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(442, 35);
            this.button1.TabIndex = 1;
            this.button1.Text = "Login >>";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(466, 257);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Aerolineas Btrees ";
            this.Load += new System.EventHandler(this.Login_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lContrasenia;
        private System.Windows.Forms.TextBox passBox;
        private System.Windows.Forms.Label lUsuario;
        private System.Windows.Forms.TextBox usrBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label wrongLabel;
    }
}