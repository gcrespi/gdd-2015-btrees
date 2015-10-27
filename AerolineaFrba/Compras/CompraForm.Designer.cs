namespace AerolineaFrba.Compras
{
    partial class CompraForm
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
            this.label5 = new System.Windows.Forms.Label();
            this.cboCiudadOrigen = new System.Windows.Forms.ComboBox();
            this.cboCiudadDestino = new System.Windows.Forms.ComboBox();
            this.cboTipoServicio = new System.Windows.Forms.ComboBox();
            this.timePickerFecha = new System.Windows.Forms.DateTimePicker();
            this.gridViajes = new System.Windows.Forms.DataGridView();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnContinue = new System.Windows.Forms.Button();
            this.checkBoxFecha = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridViajes)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Seleccione un Viaje:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tipo de Servicio:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(161, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Fecha:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Ciudad Origen:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(262, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Ciudad Destino:";
            // 
            // cboCiudadOrigen
            // 
            this.cboCiudadOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCiudadOrigen.FormattingEnabled = true;
            this.cboCiudadOrigen.Location = new System.Drawing.Point(117, 39);
            this.cboCiudadOrigen.Name = "cboCiudadOrigen";
            this.cboCiudadOrigen.Size = new System.Drawing.Size(121, 21);
            this.cboCiudadOrigen.TabIndex = 5;
            // 
            // cboCiudadDestino
            // 
            this.cboCiudadDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCiudadDestino.FormattingEnabled = true;
            this.cboCiudadDestino.Location = new System.Drawing.Point(353, 45);
            this.cboCiudadDestino.Name = "cboCiudadDestino";
            this.cboCiudadDestino.Size = new System.Drawing.Size(121, 21);
            this.cboCiudadDestino.TabIndex = 6;
            // 
            // cboTipoServicio
            // 
            this.cboTipoServicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoServicio.FormattingEnabled = true;
            this.cboTipoServicio.Location = new System.Drawing.Point(126, 72);
            this.cboTipoServicio.Name = "cboTipoServicio";
            this.cboTipoServicio.Size = new System.Drawing.Size(121, 21);
            this.cboTipoServicio.TabIndex = 7;
            // 
            // timePickerFecha
            // 
            this.timePickerFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.timePickerFecha.Location = new System.Drawing.Point(208, 10);
            this.timePickerFecha.Name = "timePickerFecha";
            this.timePickerFecha.Size = new System.Drawing.Size(98, 20);
            this.timePickerFecha.TabIndex = 8;
            // 
            // gridViajes
            // 
            this.gridViajes.AllowUserToAddRows = false;
            this.gridViajes.AllowUserToDeleteRows = false;
            this.gridViajes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridViajes.Location = new System.Drawing.Point(12, 107);
            this.gridViajes.Name = "gridViajes";
            this.gridViajes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridViajes.Size = new System.Drawing.Size(724, 295);
            this.gridViajes.TabIndex = 9;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(588, 48);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 10;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnContinue
            // 
            this.btnContinue.Location = new System.Drawing.Point(600, 427);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(136, 23);
            this.btnContinue.TabIndex = 11;
            this.btnContinue.Text = "Continuar";
            this.btnContinue.UseVisualStyleBackColor = true;
            this.btnContinue.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBoxFecha
            // 
            this.checkBoxFecha.AutoSize = true;
            this.checkBoxFecha.Location = new System.Drawing.Point(313, 12);
            this.checkBoxFecha.Name = "checkBoxFecha";
            this.checkBoxFecha.Size = new System.Drawing.Size(99, 17);
            this.checkBoxFecha.TabIndex = 12;
            this.checkBoxFecha.Text = "Filtrar por fecha";
            this.checkBoxFecha.UseVisualStyleBackColor = true;
            this.checkBoxFecha.CheckedChanged += new System.EventHandler(this.checkBoxFecha_CheckedChanged);
            // 
            // CompraForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 474);
            this.Controls.Add(this.checkBoxFecha);
            this.Controls.Add(this.btnContinue);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.gridViajes);
            this.Controls.Add(this.timePickerFecha);
            this.Controls.Add(this.cboTipoServicio);
            this.Controls.Add(this.cboCiudadDestino);
            this.Controls.Add(this.cboCiudadOrigen);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "CompraForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.CompraForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridViajes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboCiudadOrigen;
        private System.Windows.Forms.ComboBox cboCiudadDestino;
        private System.Windows.Forms.ComboBox cboTipoServicio;
        private System.Windows.Forms.DateTimePicker timePickerFecha;
        private System.Windows.Forms.DataGridView gridViajes;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnContinue;
        private System.Windows.Forms.CheckBox checkBoxFecha;
    }
}