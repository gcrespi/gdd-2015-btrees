namespace AerolineaFrba.Compras
{
    partial class CompraFormDatosPasajero
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
            this.tbNom = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbMail = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbTel = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbDirec = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbDNI = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbApe = new System.Windows.Forms.TextBox();
            this.dtpFechaNac = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.btnContinue = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.lbTitulo = new System.Windows.Forms.Label();
            this.cboButaca = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbNom
            // 
            this.tbNom.Location = new System.Drawing.Point(205, 92);
            this.tbNom.Name = "tbNom";
            this.tbNom.Size = new System.Drawing.Size(142, 20);
            this.tbNom.TabIndex = 0;
            this.tbNom.TextChanged += new System.EventHandler(this.tbNom_TextChanged);
            this.tbNom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbNom_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(104, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(104, 282);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Mail";
            // 
            // tbMail
            // 
            this.tbMail.Location = new System.Drawing.Point(205, 279);
            this.tbMail.Name = "tbMail";
            this.tbMail.Size = new System.Drawing.Size(142, 20);
            this.tbMail.TabIndex = 6;
            this.tbMail.TextChanged += new System.EventHandler(this.tbMail_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(409, 208);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Telefono";
            // 
            // tbTel
            // 
            this.tbTel.Location = new System.Drawing.Point(510, 205);
            this.tbTel.Name = "tbTel";
            this.tbTel.Size = new System.Drawing.Size(142, 20);
            this.tbTel.TabIndex = 5;
            this.tbTel.TextChanged += new System.EventHandler(this.tbTel_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(104, 208);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Direccion";
            // 
            // tbDirec
            // 
            this.tbDirec.Location = new System.Drawing.Point(205, 205);
            this.tbDirec.Name = "tbDirec";
            this.tbDirec.Size = new System.Drawing.Size(142, 20);
            this.tbDirec.TabIndex = 4;
            this.tbDirec.TextChanged += new System.EventHandler(this.tbDirec_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(104, 152);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "DNI";
            // 
            // tbDNI
            // 
            this.tbDNI.Location = new System.Drawing.Point(205, 149);
            this.tbDNI.Name = "tbDNI";
            this.tbDNI.Size = new System.Drawing.Size(142, 20);
            this.tbDNI.TabIndex = 2;
            this.tbDNI.TextChanged += new System.EventHandler(this.tbDNI_TextChanged);
            this.tbDNI.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbDNI_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(409, 95);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Apellido";
            // 
            // tbApe
            // 
            this.tbApe.Location = new System.Drawing.Point(510, 92);
            this.tbApe.Name = "tbApe";
            this.tbApe.Size = new System.Drawing.Size(142, 20);
            this.tbApe.TabIndex = 1;
            this.tbApe.TextChanged += new System.EventHandler(this.tbApe_TextChanged);
            this.tbApe.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbApe_KeyPress);
            // 
            // dtpFechaNac
            // 
            this.dtpFechaNac.Checked = false;
            this.dtpFechaNac.CustomFormat = "";
            this.dtpFechaNac.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaNac.Location = new System.Drawing.Point(510, 148);
            this.dtpFechaNac.Name = "dtpFechaNac";
            this.dtpFechaNac.Size = new System.Drawing.Size(142, 20);
            this.dtpFechaNac.TabIndex = 3;
            this.dtpFechaNac.ValueChanged += new System.EventHandler(this.dtpFechaNac_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(409, 152);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Fecha Nacimiento";
            // 
            // btnContinue
            // 
            this.btnContinue.Enabled = false;
            this.btnContinue.Location = new System.Drawing.Point(625, 401);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(136, 23);
            this.btnContinue.TabIndex = 14;
            this.btnContinue.Text = "Continuar";
            this.btnContinue.UseVisualStyleBackColor = true;
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(42, 401);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(136, 23);
            this.btnBack.TabIndex = 15;
            this.btnBack.Text = "Atras";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lbTitulo
            // 
            this.lbTitulo.AutoSize = true;
            this.lbTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitulo.Location = new System.Drawing.Point(42, 25);
            this.lbTitulo.Name = "lbTitulo";
            this.lbTitulo.Size = new System.Drawing.Size(241, 25);
            this.lbTitulo.TabIndex = 16;
            this.lbTitulo.Text = "Ingrese datos del pasajero";
            // 
            // cboButaca
            // 
            this.cboButaca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboButaca.FormattingEnabled = true;
            this.cboButaca.Location = new System.Drawing.Point(510, 279);
            this.cboButaca.Name = "cboButaca";
            this.cboButaca.Size = new System.Drawing.Size(142, 21);
            this.cboButaca.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(409, 282);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Butaca nro:";
            // 
            // CompraFormDatosPasajero
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 446);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cboButaca);
            this.Controls.Add(this.lbTitulo);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnContinue);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dtpFechaNac);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbApe);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbDNI);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbDirec);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbTel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbMail);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbNom);
            this.Name = "CompraFormDatosPasajero";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.CompraFormDatosPasajero_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbNom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbMail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbTel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbDirec;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbDNI;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbApe;
        private System.Windows.Forms.DateTimePicker dtpFechaNac;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnContinue;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lbTitulo;
        private System.Windows.Forms.ComboBox cboButaca;
        private System.Windows.Forms.Label label8;
    }
}