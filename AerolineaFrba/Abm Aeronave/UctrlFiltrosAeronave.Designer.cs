namespace AerolineaFrba.Abm_Aeronave
{
    partial class UctrlFiltrosAeronave
    {
        /// <summary> 
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar 
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chbFueraServicio = new System.Windows.Forms.CheckBox();
            this.lblFueraServicio = new System.Windows.Forms.Label();
            this.txtMatricula = new System.Windows.Forms.TextBox();
            this.txtFabricante = new System.Windows.Forms.TextBox();
            this.lblMatricula = new System.Windows.Forms.Label();
            this.lblFabricante = new System.Windows.Forms.Label();
            this.lblModelo = new System.Windows.Forms.Label();
            this.chbEnBaja = new System.Windows.Forms.CheckBox();
            this.lblEnBaja = new System.Windows.Forms.Label();
            this.lblServicio = new System.Windows.Forms.Label();
            this.txtModelo = new System.Windows.Forms.TextBox();
            this.lblFechaAlta = new System.Windows.Forms.Label();
            this.dtpAlta = new AerolineaFrba.Utils.DisableableDate();
            this.cboServicios = new AerolineaFrba.Utils.ComboBoxWithAllOption();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtpAlta);
            this.groupBox1.Controls.Add(this.cboServicios);
            this.groupBox1.Controls.Add(this.chbFueraServicio);
            this.groupBox1.Controls.Add(this.lblFueraServicio);
            this.groupBox1.Controls.Add(this.txtMatricula);
            this.groupBox1.Controls.Add(this.txtFabricante);
            this.groupBox1.Controls.Add(this.lblMatricula);
            this.groupBox1.Controls.Add(this.lblFabricante);
            this.groupBox1.Controls.Add(this.lblModelo);
            this.groupBox1.Controls.Add(this.chbEnBaja);
            this.groupBox1.Controls.Add(this.lblEnBaja);
            this.groupBox1.Controls.Add(this.lblServicio);
            this.groupBox1.Controls.Add(this.txtModelo);
            this.groupBox1.Controls.Add(this.lblFechaAlta);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(765, 166);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros Aeronave";
            // 
            // chbFueraServicio
            // 
            this.chbFueraServicio.AutoSize = true;
            this.chbFueraServicio.Location = new System.Drawing.Point(529, 127);
            this.chbFueraServicio.Name = "chbFueraServicio";
            this.chbFueraServicio.Size = new System.Drawing.Size(15, 14);
            this.chbFueraServicio.TabIndex = 31;
            this.chbFueraServicio.UseVisualStyleBackColor = true;
            // 
            // lblFueraServicio
            // 
            this.lblFueraServicio.AutoSize = true;
            this.lblFueraServicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFueraServicio.Location = new System.Drawing.Point(403, 124);
            this.lblFueraServicio.Name = "lblFueraServicio";
            this.lblFueraServicio.Size = new System.Drawing.Size(123, 17);
            this.lblFueraServicio.TabIndex = 30;
            this.lblFueraServicio.Text = "Fuera de Servicio:";
            // 
            // txtMatricula
            // 
            this.txtMatricula.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMatricula.Location = new System.Drawing.Point(91, 29);
            this.txtMatricula.Margin = new System.Windows.Forms.Padding(0);
            this.txtMatricula.MaxLength = 60;
            this.txtMatricula.Name = "txtMatricula";
            this.txtMatricula.Size = new System.Drawing.Size(199, 23);
            this.txtMatricula.TabIndex = 29;
            // 
            // txtFabricante
            // 
            this.txtFabricante.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFabricante.Location = new System.Drawing.Point(91, 58);
            this.txtFabricante.Margin = new System.Windows.Forms.Padding(0);
            this.txtFabricante.MaxLength = 60;
            this.txtFabricante.Name = "txtFabricante";
            this.txtFabricante.Size = new System.Drawing.Size(199, 23);
            this.txtFabricante.TabIndex = 28;
            // 
            // lblMatricula
            // 
            this.lblMatricula.AutoSize = true;
            this.lblMatricula.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMatricula.Location = new System.Drawing.Point(9, 29);
            this.lblMatricula.Name = "lblMatricula";
            this.lblMatricula.Size = new System.Drawing.Size(69, 17);
            this.lblMatricula.TabIndex = 27;
            this.lblMatricula.Text = "Matricula:";
            // 
            // lblFabricante
            // 
            this.lblFabricante.AutoSize = true;
            this.lblFabricante.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFabricante.Location = new System.Drawing.Point(9, 58);
            this.lblFabricante.Name = "lblFabricante";
            this.lblFabricante.Size = new System.Drawing.Size(79, 17);
            this.lblFabricante.TabIndex = 26;
            this.lblFabricante.Text = "Fabricante:";
            // 
            // lblModelo
            // 
            this.lblModelo.AutoSize = true;
            this.lblModelo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModelo.Location = new System.Drawing.Point(9, 85);
            this.lblModelo.Name = "lblModelo";
            this.lblModelo.Size = new System.Drawing.Size(58, 17);
            this.lblModelo.TabIndex = 25;
            this.lblModelo.Text = "Modelo:";
            // 
            // chbEnBaja
            // 
            this.chbEnBaja.AutoSize = true;
            this.chbEnBaja.Location = new System.Drawing.Point(134, 133);
            this.chbEnBaja.Name = "chbEnBaja";
            this.chbEnBaja.Size = new System.Drawing.Size(15, 14);
            this.chbEnBaja.TabIndex = 22;
            this.chbEnBaja.UseVisualStyleBackColor = true;
            // 
            // lblEnBaja
            // 
            this.lblEnBaja.AutoSize = true;
            this.lblEnBaja.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnBaja.Location = new System.Drawing.Point(9, 130);
            this.lblEnBaja.Name = "lblEnBaja";
            this.lblEnBaja.Size = new System.Drawing.Size(119, 17);
            this.lblEnBaja.TabIndex = 21;
            this.lblEnBaja.Text = "En Baja Definitiva";
            // 
            // lblServicio
            // 
            this.lblServicio.AutoSize = true;
            this.lblServicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServicio.Location = new System.Drawing.Point(403, 29);
            this.lblServicio.Name = "lblServicio";
            this.lblServicio.Size = new System.Drawing.Size(114, 17);
            this.lblServicio.TabIndex = 19;
            this.lblServicio.Text = "Tipo de Servicio:";
            // 
            // txtModelo
            // 
            this.txtModelo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtModelo.Location = new System.Drawing.Point(91, 85);
            this.txtModelo.Margin = new System.Windows.Forms.Padding(0);
            this.txtModelo.MaxLength = 60;
            this.txtModelo.Name = "txtModelo";
            this.txtModelo.Size = new System.Drawing.Size(199, 23);
            this.txtModelo.TabIndex = 18;
            // 
            // lblFechaAlta
            // 
            this.lblFechaAlta.AutoSize = true;
            this.lblFechaAlta.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaAlta.Location = new System.Drawing.Point(403, 79);
            this.lblFechaAlta.Name = "lblFechaAlta";
            this.lblFechaAlta.Size = new System.Drawing.Size(99, 17);
            this.lblFechaAlta.TabIndex = 17;
            this.lblFechaAlta.Text = "Fecha de Alta:";
            // 
            // dtpAlta
            // 
            this.dtpAlta.EnableDate = true;
            this.dtpAlta.Location = new System.Drawing.Point(529, 75);
            this.dtpAlta.Name = "dtpAlta";
            this.dtpAlta.Size = new System.Drawing.Size(217, 27);
            this.dtpAlta.TabIndex = 33;
            this.dtpAlta.TextCheck = "Filtrar por fecha";
            this.dtpAlta.Value = new System.DateTime(2015, 11, 1, 19, 30, 27, 129);
            // 
            // cboServicios
            // 
            this.cboServicios.DataTableSource = null;
            this.cboServicios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboServicios.FormattingEnabled = true;
            this.cboServicios.Location = new System.Drawing.Point(529, 28);
            this.cboServicios.Name = "cboServicios";
            this.cboServicios.Size = new System.Drawing.Size(200, 21);
            this.cboServicios.TabIndex = 32;
            // 
            // UctrlFiltrosAeronave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "UctrlFiltrosAeronave";
            this.Size = new System.Drawing.Size(770, 171);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chbEnBaja;
        private System.Windows.Forms.Label lblEnBaja;
        private System.Windows.Forms.Label lblServicio;
        private System.Windows.Forms.TextBox txtModelo;
        private System.Windows.Forms.Label lblFechaAlta;
        private System.Windows.Forms.TextBox txtMatricula;
        private System.Windows.Forms.TextBox txtFabricante;
        private System.Windows.Forms.Label lblMatricula;
        private System.Windows.Forms.Label lblFabricante;
        private System.Windows.Forms.Label lblModelo;
        private System.Windows.Forms.CheckBox chbFueraServicio;
        private System.Windows.Forms.Label lblFueraServicio;
        private Utils.ComboBoxWithAllOption cboServicios;
        private Utils.DisableableDate dtpAlta;
    }
}
