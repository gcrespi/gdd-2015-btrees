namespace AerolineaFrba.Devolucion
{
    partial class DevolucionForm
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
            this.txtCodCompra = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.gridPasajes = new System.Windows.Forms.DataGridView();
            this.Seleccionar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.txtKGEncomienda = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMotivo = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkCancelarEnco = new System.Windows.Forms.CheckBox();
            this.btnCancelarElem = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.gridPasajes)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ingrese el código de compra:";
            // 
            // txtCodCompra
            // 
            this.txtCodCompra.Location = new System.Drawing.Point(188, 14);
            this.txtCodCompra.Name = "txtCodCompra";
            this.txtCodCompra.Size = new System.Drawing.Size(100, 20);
            this.txtCodCompra.TabIndex = 1;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(303, 11);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(207, 23);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "Pasajes / Encomiendas Comprados";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // gridPasajes
            // 
            this.gridPasajes.AllowUserToAddRows = false;
            this.gridPasajes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridPasajes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Seleccionar});
            this.gridPasajes.Enabled = false;
            this.gridPasajes.Location = new System.Drawing.Point(6, 19);
            this.gridPasajes.Name = "gridPasajes";
            this.gridPasajes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridPasajes.Size = new System.Drawing.Size(547, 170);
            this.gridPasajes.TabIndex = 3;
            // 
            // Seleccionar
            // 
            this.Seleccionar.HeaderText = "Seleccionar";
            this.Seleccionar.Name = "Seleccionar";
            // 
            // txtKGEncomienda
            // 
            this.txtKGEncomienda.Location = new System.Drawing.Point(18, 19);
            this.txtKGEncomienda.Name = "txtKGEncomienda";
            this.txtKGEncomienda.Size = new System.Drawing.Size(192, 20);
            this.txtKGEncomienda.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(185, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Ingrese el Motivo de la Cancelación:  ";
            // 
            // txtMotivo
            // 
            this.txtMotivo.Location = new System.Drawing.Point(6, 26);
            this.txtMotivo.Multiline = true;
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.Size = new System.Drawing.Size(590, 38);
            this.txtMotivo.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtMotivo);
            this.panel2.Enabled = false;
            this.panel2.Location = new System.Drawing.Point(41, 65);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(638, 407);
            this.panel2.TabIndex = 13;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gridPasajes);
            this.groupBox2.Location = new System.Drawing.Point(15, 70);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(581, 242);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Pasajes";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkCancelarEnco);
            this.groupBox1.Controls.Add(this.txtKGEncomienda);
            this.groupBox1.Location = new System.Drawing.Point(15, 328);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(590, 67);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Encomienda: Cant Kg";
            // 
            // chkCancelarEnco
            // 
            this.chkCancelarEnco.AutoSize = true;
            this.chkCancelarEnco.Location = new System.Drawing.Point(236, 19);
            this.chkCancelarEnco.Name = "chkCancelarEnco";
            this.chkCancelarEnco.Size = new System.Drawing.Size(130, 17);
            this.chkCancelarEnco.TabIndex = 7;
            this.chkCancelarEnco.Text = "Cancelar Encomienda";
            this.chkCancelarEnco.UseVisualStyleBackColor = true;
            // 
            // btnCancelarElem
            // 
            this.btnCancelarElem.Location = new System.Drawing.Point(270, 478);
            this.btnCancelarElem.Name = "btnCancelarElem";
            this.btnCancelarElem.Size = new System.Drawing.Size(152, 23);
            this.btnCancelarElem.TabIndex = 9;
            this.btnCancelarElem.Text = "Cancelar Seleccionados";
            this.btnCancelarElem.UseVisualStyleBackColor = true;
            this.btnCancelarElem.Click += new System.EventHandler(this.btnComenzar_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtCodCompra);
            this.panel1.Controls.Add(this.btnBuscar);
            this.panel1.Location = new System.Drawing.Point(41, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(638, 47);
            this.panel1.TabIndex = 14;
            // 
            // DevolucionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 527);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnCancelarElem);
            this.Name = "DevolucionForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.DevolucionForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridPasajes)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCodCompra;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridView gridPasajes;
        private System.Windows.Forms.TextBox txtKGEncomienda;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMotivo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Seleccionar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancelarElem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkCancelarEnco;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}