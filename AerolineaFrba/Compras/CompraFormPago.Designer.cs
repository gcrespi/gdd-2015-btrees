namespace AerolineaFrba.Compras
{
    partial class CompraFormPago
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
            this.btnBack = new System.Windows.Forms.Button();
            this.btnContinue = new System.Windows.Forms.Button();
            this.lbTitulo = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpFechaNac = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.tbApe = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbDNI = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbDirec = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbTel = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbMail = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbNom = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dtpFechaVencimiento = new System.Windows.Forms.DateTimePicker();
            this.cboTipoTarjeta = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tbNroTarjeta = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbCodSeg = new System.Windows.Forms.TextBox();
            this.updCuotas = new System.Windows.Forms.NumericUpDown();
            this.rdTarjeta = new System.Windows.Forms.RadioButton();
            this.rdEfectivo = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.updCuotas)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(24, 388);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(136, 23);
            this.btnBack.TabIndex = 17;
            this.btnBack.Text = "Atras";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click_1);
            // 
            // btnContinue
            // 
            this.btnContinue.BackColor = System.Drawing.Color.DimGray;
            this.btnContinue.Enabled = false;
            this.btnContinue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContinue.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnContinue.Location = new System.Drawing.Point(589, 371);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(136, 40);
            this.btnContinue.TabIndex = 16;
            this.btnContinue.Text = "Finalizar";
            this.btnContinue.UseVisualStyleBackColor = false;
            this.btnContinue.EnabledChanged += new System.EventHandler(this.btnContinue_EnabledChanged);
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // lbTitulo
            // 
            this.lbTitulo.AutoSize = true;
            this.lbTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitulo.Location = new System.Drawing.Point(80, 24);
            this.lbTitulo.Name = "lbTitulo";
            this.lbTitulo.Size = new System.Drawing.Size(58, 25);
            this.lbTitulo.TabIndex = 18;
            this.lbTitulo.Text = "Pago";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 128);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 13);
            this.label7.TabIndex = 32;
            this.label7.Text = "Fecha Nacimiento";
            // 
            // dtpFechaNac
            // 
            this.dtpFechaNac.Checked = false;
            this.dtpFechaNac.CustomFormat = "";
            this.dtpFechaNac.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaNac.Location = new System.Drawing.Point(117, 124);
            this.dtpFechaNac.Name = "dtpFechaNac";
            this.dtpFechaNac.Size = new System.Drawing.Size(142, 20);
            this.dtpFechaNac.TabIndex = 23;
            this.dtpFechaNac.ValueChanged += new System.EventHandler(this.dtpFechaNac_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 31;
            this.label6.Text = "Apellido";
            // 
            // tbApe
            // 
            this.tbApe.Location = new System.Drawing.Point(117, 72);
            this.tbApe.Name = "tbApe";
            this.tbApe.Size = new System.Drawing.Size(142, 20);
            this.tbApe.TabIndex = 20;
            this.tbApe.TextChanged += new System.EventHandler(this.tbApe_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 30;
            this.label5.Text = "DNI";
            // 
            // tbDNI
            // 
            this.tbDNI.Location = new System.Drawing.Point(117, 98);
            this.tbDNI.Name = "tbDNI";
            this.tbDNI.Size = new System.Drawing.Size(142, 20);
            this.tbDNI.TabIndex = 22;
            this.tbDNI.TextChanged += new System.EventHandler(this.tbDNI_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 29;
            this.label4.Text = "Direccion";
            // 
            // tbDirec
            // 
            this.tbDirec.Location = new System.Drawing.Point(117, 150);
            this.tbDirec.Name = "tbDirec";
            this.tbDirec.Size = new System.Drawing.Size(142, 20);
            this.tbDirec.TabIndex = 25;
            this.tbDirec.TextChanged += new System.EventHandler(this.tbDirec_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 179);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Telefono";
            // 
            // tbTel
            // 
            this.tbTel.Location = new System.Drawing.Point(117, 176);
            this.tbTel.Name = "tbTel";
            this.tbTel.Size = new System.Drawing.Size(142, 20);
            this.tbTel.TabIndex = 27;
            this.tbTel.TextChanged += new System.EventHandler(this.tbTel_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 205);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Mail";
            // 
            // tbMail
            // 
            this.tbMail.Location = new System.Drawing.Point(117, 202);
            this.tbMail.Name = "tbMail";
            this.tbMail.Size = new System.Drawing.Size(142, 20);
            this.tbMail.TabIndex = 28;
            this.tbMail.TextChanged += new System.EventHandler(this.tbMail_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Nombre";
            // 
            // tbNom
            // 
            this.tbNom.Location = new System.Drawing.Point(117, 46);
            this.tbNom.Name = "tbNom";
            this.tbNom.Size = new System.Drawing.Size(142, 20);
            this.tbNom.TabIndex = 19;
            this.tbNom.TextChanged += new System.EventHandler(this.tbNom_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbNom);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.tbMail);
            this.groupBox1.Controls.Add(this.dtpFechaNac);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.tbTel);
            this.groupBox1.Controls.Add(this.tbApe);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.tbDirec);
            this.groupBox1.Controls.Add(this.tbDNI);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(53, 83);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(293, 256);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos Personaless";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.dtpFechaVencimiento);
            this.groupBox2.Controls.Add(this.cboTipoTarjeta);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.tbNroTarjeta);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.tbCodSeg);
            this.groupBox2.Controls.Add(this.updCuotas);
            this.groupBox2.Controls.Add(this.rdTarjeta);
            this.groupBox2.Controls.Add(this.rdEfectivo);
            this.groupBox2.Location = new System.Drawing.Point(391, 83);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(298, 256);
            this.groupBox2.TabIndex = 34;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Metodo de Pago";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(49, 216);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(97, 13);
            this.label10.TabIndex = 36;
            this.label10.Text = "Fecha vencimiento";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(57, 115);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "Tipo terjeta";
            // 
            // dtpFechaVencimiento
            // 
            this.dtpFechaVencimiento.Checked = false;
            this.dtpFechaVencimiento.CustomFormat = "MM/yyyy";
            this.dtpFechaVencimiento.Enabled = false;
            this.dtpFechaVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaVencimiento.Location = new System.Drawing.Point(152, 212);
            this.dtpFechaVencimiento.Name = "dtpFechaVencimiento";
            this.dtpFechaVencimiento.Size = new System.Drawing.Size(97, 20);
            this.dtpFechaVencimiento.TabIndex = 34;
            this.dtpFechaVencimiento.ValueChanged += new System.EventHandler(this.dtpFechaVencimiento_ValueChanged);
            // 
            // cboTipoTarjeta
            // 
            this.cboTipoTarjeta.Enabled = false;
            this.cboTipoTarjeta.FormattingEnabled = true;
            this.cboTipoTarjeta.Location = new System.Drawing.Point(127, 112);
            this.cboTipoTarjeta.Name = "cboTipoTarjeta";
            this.cboTipoTarjeta.Size = new System.Drawing.Size(121, 21);
            this.cboTipoTarjeta.TabIndex = 4;
            this.cboTipoTarjeta.SelectedIndexChanged += new System.EventHandler(this.cboTipoTarjeta_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(59, 150);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 13);
            this.label12.TabIndex = 35;
            this.label12.Text = "Nro tarjeta";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(52, 184);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(89, 13);
            this.label11.TabIndex = 35;
            this.label11.Text = "Codigo seguridad";
            // 
            // tbNroTarjeta
            // 
            this.tbNroTarjeta.Enabled = false;
            this.tbNroTarjeta.Location = new System.Drawing.Point(127, 147);
            this.tbNroTarjeta.Name = "tbNroTarjeta";
            this.tbNroTarjeta.Size = new System.Drawing.Size(122, 20);
            this.tbNroTarjeta.TabIndex = 33;
            this.tbNroTarjeta.TextChanged += new System.EventHandler(this.tbNroTarjeta_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(58, 77);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Cantidad de coutas";
            // 
            // tbCodSeg
            // 
            this.tbCodSeg.Enabled = false;
            this.tbCodSeg.Location = new System.Drawing.Point(152, 181);
            this.tbCodSeg.Name = "tbCodSeg";
            this.tbCodSeg.Size = new System.Drawing.Size(97, 20);
            this.tbCodSeg.TabIndex = 33;
            this.tbCodSeg.TextChanged += new System.EventHandler(this.tbCodSeg_TextChanged);
            // 
            // updCuotas
            // 
            this.updCuotas.Enabled = false;
            this.updCuotas.Location = new System.Drawing.Point(171, 75);
            this.updCuotas.Name = "updCuotas";
            this.updCuotas.Size = new System.Drawing.Size(54, 20);
            this.updCuotas.TabIndex = 2;
            this.updCuotas.ValueChanged += new System.EventHandler(this.updCuotas_ValueChanged);
            // 
            // rdTarjeta
            // 
            this.rdTarjeta.AutoSize = true;
            this.rdTarjeta.Location = new System.Drawing.Point(165, 35);
            this.rdTarjeta.Name = "rdTarjeta";
            this.rdTarjeta.Size = new System.Drawing.Size(76, 17);
            this.rdTarjeta.TabIndex = 1;
            this.rdTarjeta.Text = "Con tarjeta";
            this.rdTarjeta.UseVisualStyleBackColor = true;
            this.rdTarjeta.CheckedChanged += new System.EventHandler(this.rdTarjeta_CheckedChanged);
            // 
            // rdEfectivo
            // 
            this.rdEfectivo.AutoSize = true;
            this.rdEfectivo.Checked = true;
            this.rdEfectivo.Location = new System.Drawing.Point(42, 35);
            this.rdEfectivo.Name = "rdEfectivo";
            this.rdEfectivo.Size = new System.Drawing.Size(79, 17);
            this.rdEfectivo.TabIndex = 0;
            this.rdEfectivo.TabStop = true;
            this.rdEfectivo.Text = "En efectivo";
            this.rdEfectivo.UseVisualStyleBackColor = true;
            this.rdEfectivo.CheckedChanged += new System.EventHandler(this.rdEfectivo_CheckedChanged);
            // 
            // CompraFormPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 429);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbTitulo);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnContinue);
            this.Name = "CompraFormPago";
            this.Text = "CompraFormPago";
            this.Load += new System.EventHandler(this.CompraFormPago_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.updCuotas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnContinue;
        private System.Windows.Forms.Label lbTitulo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpFechaNac;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbApe;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbDNI;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbDirec;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbTel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbMail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbNom;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdTarjeta;
        private System.Windows.Forms.RadioButton rdEfectivo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown updCuotas;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboTipoTarjeta;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtpFechaVencimiento;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbNroTarjeta;
        private System.Windows.Forms.TextBox tbCodSeg;

    }
}