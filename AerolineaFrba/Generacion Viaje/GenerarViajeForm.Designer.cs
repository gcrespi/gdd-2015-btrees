namespace AerolineaFrba.Generacion_Viaje
{
    partial class GenerarViajeForm
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpFechaSalida = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaLlegadaEstimada = new System.Windows.Forms.DateTimePicker();
            this.gridRutaAerea = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.gridAeronave = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridRutaAerea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAeronave)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fecha Salida:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Fecha Llegada Estimada:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Aeronave:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 230);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Ruta Aerea:";
            // 
            // dtpFechaSalida
            // 
            this.dtpFechaSalida.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpFechaSalida.Location = new System.Drawing.Point(156, 13);
            this.dtpFechaSalida.Name = "dtpFechaSalida";
            this.dtpFechaSalida.Size = new System.Drawing.Size(86, 20);
            this.dtpFechaSalida.TabIndex = 5;
            // 
            // dtpFechaLlegadaEstimada
            // 
            this.dtpFechaLlegadaEstimada.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpFechaLlegadaEstimada.Location = new System.Drawing.Point(156, 39);
            this.dtpFechaLlegadaEstimada.Name = "dtpFechaLlegadaEstimada";
            this.dtpFechaLlegadaEstimada.Size = new System.Drawing.Size(86, 20);
            this.dtpFechaLlegadaEstimada.TabIndex = 7;
            // 
            // gridRutaAerea
            // 
            this.gridRutaAerea.AllowUserToAddRows = false;
            this.gridRutaAerea.AllowUserToDeleteRows = false;
            this.gridRutaAerea.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridRutaAerea.Location = new System.Drawing.Point(156, 220);
            this.gridRutaAerea.Name = "gridRutaAerea";
            this.gridRutaAerea.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridRutaAerea.Size = new System.Drawing.Size(584, 156);
            this.gridRutaAerea.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(631, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 31);
            this.button1.TabIndex = 10;
            this.button1.Text = "Guardar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // gridAeronave
            // 
            this.gridAeronave.AllowUserToAddRows = false;
            this.gridAeronave.AllowUserToDeleteRows = false;
            this.gridAeronave.AllowUserToOrderColumns = true;
            this.gridAeronave.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridAeronave.Location = new System.Drawing.Point(156, 65);
            this.gridAeronave.Name = "gridAeronave";
            this.gridAeronave.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridAeronave.Size = new System.Drawing.Size(584, 149);
            this.gridAeronave.TabIndex = 11;
            // 
            // GenerarViajeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 447);
            this.Controls.Add(this.gridAeronave);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.gridRutaAerea);
            this.Controls.Add(this.dtpFechaLlegadaEstimada);
            this.Controls.Add(this.dtpFechaSalida);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "GenerarViajeForm";
            this.Text = "Generación de Viaje";
            this.Load += new System.EventHandler(this.GenerarViajeForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridRutaAerea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAeronave)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpFechaSalida;
        private System.Windows.Forms.DateTimePicker dtpFechaLlegadaEstimada;
        private System.Windows.Forms.DataGridView gridRutaAerea;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView gridAeronave;
    }
}