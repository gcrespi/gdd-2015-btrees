namespace AerolineaFrba.Registro_Llegada_Destino
{
    partial class RegLlegadaADestinoForm
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
            this.cboCiudadOrigen = new System.Windows.Forms.ComboBox();
            this.cboCiudadDestino = new System.Windows.Forms.ComboBox();
            this.dtpFechaLlegada = new System.Windows.Forms.DateTimePicker();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.cboAvion = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Avión (Matrícula):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ciudad de Origen:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Ciudad de Llegada:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Fecha Llegada:";
            // 
            // cboCiudadOrigen
            // 
            this.cboCiudadOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCiudadOrigen.FormattingEnabled = true;
            this.cboCiudadOrigen.Location = new System.Drawing.Point(124, 38);
            this.cboCiudadOrigen.Name = "cboCiudadOrigen";
            this.cboCiudadOrigen.Size = new System.Drawing.Size(121, 21);
            this.cboCiudadOrigen.TabIndex = 5;
            // 
            // cboCiudadDestino
            // 
            this.cboCiudadDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCiudadDestino.FormattingEnabled = true;
            this.cboCiudadDestino.Location = new System.Drawing.Point(124, 70);
            this.cboCiudadDestino.Name = "cboCiudadDestino";
            this.cboCiudadDestino.Size = new System.Drawing.Size(121, 21);
            this.cboCiudadDestino.TabIndex = 6;
            // 
            // dtpFechaLlegada
            // 
            this.dtpFechaLlegada.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpFechaLlegada.Location = new System.Drawing.Point(124, 99);
            this.dtpFechaLlegada.Name = "dtpFechaLlegada";
            this.dtpFechaLlegada.Size = new System.Drawing.Size(121, 20);
            this.dtpFechaLlegada.TabIndex = 7;
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Location = new System.Drawing.Point(77, 136);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(101, 30);
            this.btnRegistrar.TabIndex = 8;
            this.btnRegistrar.Text = "Registrar";
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // cboAvion
            // 
            this.cboAvion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAvion.FormattingEnabled = true;
            this.cboAvion.Location = new System.Drawing.Point(124, 10);
            this.cboAvion.Name = "cboAvion";
            this.cboAvion.Size = new System.Drawing.Size(121, 21);
            this.cboAvion.TabIndex = 9;
            // 
            // RegLlegadaADestinoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 256);
            this.Controls.Add(this.cboAvion);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.dtpFechaLlegada);
            this.Controls.Add(this.cboCiudadDestino);
            this.Controls.Add(this.cboCiudadOrigen);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "RegLlegadaADestinoForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.RegLlegadaADestinoForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboCiudadOrigen;
        private System.Windows.Forms.ComboBox cboCiudadDestino;
        private System.Windows.Forms.DateTimePicker dtpFechaLlegada;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.ComboBox cboAvion;
    }
}