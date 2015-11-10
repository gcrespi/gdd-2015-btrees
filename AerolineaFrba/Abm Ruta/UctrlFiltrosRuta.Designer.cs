namespace AerolineaFrba.Abm_Ruta
{
    partial class UctrlFiltrosRuta
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
            this.numCodigoRuta = new AerolineaFrba.Utils.NumericBox();
            this.lblCodigoRuta = new System.Windows.Forms.Label();
            this.dcmPrecioBPas = new AerolineaFrba.Utils.DecimalBox();
            this.dcmPrecioBEnc = new AerolineaFrba.Utils.DecimalBox();
            this.chbHabilitado = new System.Windows.Forms.CheckBox();
            this.lblHabilitado = new System.Windows.Forms.Label();
            this.lblPrecioBEnc = new System.Windows.Forms.Label();
            this.lblPrecioBPas = new System.Windows.Forms.Label();
            this.chlServicios = new System.Windows.Forms.CheckedListBox();
            this.lblServicio = new System.Windows.Forms.Label();
            this.lblDestino = new System.Windows.Forms.Label();
            this.cboCiudadDestino = new AerolineaFrba.Utils.ComboBoxWithAllOption();
            this.cboCiudadOrigen = new AerolineaFrba.Utils.ComboBoxWithAllOption();
            this.lblOrigen = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numCodigoRuta);
            this.groupBox1.Controls.Add(this.lblCodigoRuta);
            this.groupBox1.Controls.Add(this.dcmPrecioBPas);
            this.groupBox1.Controls.Add(this.dcmPrecioBEnc);
            this.groupBox1.Controls.Add(this.chbHabilitado);
            this.groupBox1.Controls.Add(this.lblHabilitado);
            this.groupBox1.Controls.Add(this.lblPrecioBEnc);
            this.groupBox1.Controls.Add(this.lblPrecioBPas);
            this.groupBox1.Controls.Add(this.chlServicios);
            this.groupBox1.Controls.Add(this.lblServicio);
            this.groupBox1.Controls.Add(this.lblDestino);
            this.groupBox1.Controls.Add(this.cboCiudadDestino);
            this.groupBox1.Controls.Add(this.cboCiudadOrigen);
            this.groupBox1.Controls.Add(this.lblOrigen);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(762, 166);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros Rutas Aereas";
            // 
            // numCodigoRuta
            // 
            this.numCodigoRuta.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numCodigoRuta.Location = new System.Drawing.Point(166, 14);
            this.numCodigoRuta.Margin = new System.Windows.Forms.Padding(0);
            this.numCodigoRuta.MaxLength = 60;
            this.numCodigoRuta.Name = "numCodigoRuta";
            this.numCodigoRuta.Size = new System.Drawing.Size(120, 24);
            this.numCodigoRuta.TabIndex = 47;
            this.numCodigoRuta.Text = "0";
            this.numCodigoRuta.TextValue = 0;
            // 
            // lblCodigoRuta
            // 
            this.lblCodigoRuta.AutoSize = true;
            this.lblCodigoRuta.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodigoRuta.Location = new System.Drawing.Point(22, 17);
            this.lblCodigoRuta.Name = "lblCodigoRuta";
            this.lblCodigoRuta.Size = new System.Drawing.Size(90, 17);
            this.lblCodigoRuta.TabIndex = 46;
            this.lblCodigoRuta.Text = "Codigo Ruta:";
            // 
            // dcmPrecioBPas
            // 
            this.dcmPrecioBPas.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dcmPrecioBPas.Location = new System.Drawing.Point(590, 54);
            this.dcmPrecioBPas.Margin = new System.Windows.Forms.Padding(0);
            this.dcmPrecioBPas.MaxLength = 60;
            this.dcmPrecioBPas.Name = "dcmPrecioBPas";
            this.dcmPrecioBPas.Size = new System.Drawing.Size(120, 24);
            this.dcmPrecioBPas.TabIndex = 45;
            this.dcmPrecioBPas.Text = "0";
            this.dcmPrecioBPas.TextValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // dcmPrecioBEnc
            // 
            this.dcmPrecioBEnc.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dcmPrecioBEnc.Location = new System.Drawing.Point(590, 20);
            this.dcmPrecioBEnc.Margin = new System.Windows.Forms.Padding(0);
            this.dcmPrecioBEnc.MaxLength = 60;
            this.dcmPrecioBEnc.Name = "dcmPrecioBEnc";
            this.dcmPrecioBEnc.Size = new System.Drawing.Size(120, 24);
            this.dcmPrecioBEnc.TabIndex = 44;
            this.dcmPrecioBEnc.Text = "0";
            this.dcmPrecioBEnc.TextValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // chbHabilitado
            // 
            this.chbHabilitado.AutoSize = true;
            this.chbHabilitado.Location = new System.Drawing.Point(166, 136);
            this.chbHabilitado.Name = "chbHabilitado";
            this.chbHabilitado.Size = new System.Drawing.Size(15, 14);
            this.chbHabilitado.TabIndex = 43;
            this.chbHabilitado.UseVisualStyleBackColor = true;
            // 
            // lblHabilitado
            // 
            this.lblHabilitado.AutoSize = true;
            this.lblHabilitado.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHabilitado.Location = new System.Drawing.Point(22, 136);
            this.lblHabilitado.Name = "lblHabilitado";
            this.lblHabilitado.Size = new System.Drawing.Size(71, 17);
            this.lblHabilitado.TabIndex = 42;
            this.lblHabilitado.Text = "Habilitado";
            // 
            // lblPrecioBEnc
            // 
            this.lblPrecioBEnc.AutoSize = true;
            this.lblPrecioBEnc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecioBEnc.Location = new System.Drawing.Point(406, 18);
            this.lblPrecioBEnc.Name = "lblPrecioBEnc";
            this.lblPrecioBEnc.Size = new System.Drawing.Size(170, 17);
            this.lblPrecioBEnc.TabIndex = 39;
            this.lblPrecioBEnc.Text = "Precio Base Encomienda:";
            // 
            // lblPrecioBPas
            // 
            this.lblPrecioBPas.AutoSize = true;
            this.lblPrecioBPas.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecioBPas.Location = new System.Drawing.Point(406, 54);
            this.lblPrecioBPas.Name = "lblPrecioBPas";
            this.lblPrecioBPas.Size = new System.Drawing.Size(135, 17);
            this.lblPrecioBPas.TabIndex = 38;
            this.lblPrecioBPas.Text = "Precio Base Pasaje:";
            // 
            // chlServicios
            // 
            this.chlServicios.FormattingEnabled = true;
            this.chlServicios.Location = new System.Drawing.Point(517, 91);
            this.chlServicios.Name = "chlServicios";
            this.chlServicios.Size = new System.Drawing.Size(193, 64);
            this.chlServicios.TabIndex = 37;
            // 
            // lblServicio
            // 
            this.lblServicio.AutoSize = true;
            this.lblServicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServicio.Location = new System.Drawing.Point(406, 89);
            this.lblServicio.Name = "lblServicio";
            this.lblServicio.Size = new System.Drawing.Size(94, 17);
            this.lblServicio.TabIndex = 36;
            this.lblServicio.Text = "Tipo Servicio:";
            // 
            // lblDestino
            // 
            this.lblDestino.AutoSize = true;
            this.lblDestino.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDestino.Location = new System.Drawing.Point(22, 88);
            this.lblDestino.Name = "lblDestino";
            this.lblDestino.Size = new System.Drawing.Size(108, 17);
            this.lblDestino.TabIndex = 26;
            this.lblDestino.Text = "Ciudad Destino:";
            // 
            // cboCiudadDestino
            // 
            this.cboCiudadDestino.DataTableSource = null;
            this.cboCiudadDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCiudadDestino.FormattingEnabled = true;
            this.cboCiudadDestino.Location = new System.Drawing.Point(165, 88);
            this.cboCiudadDestino.Name = "cboCiudadDestino";
            this.cboCiudadDestino.Size = new System.Drawing.Size(121, 21);
            this.cboCiudadDestino.TabIndex = 25;
            // 
            // cboCiudadOrigen
            // 
            this.cboCiudadOrigen.DataTableSource = null;
            this.cboCiudadOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCiudadOrigen.FormattingEnabled = true;
            this.cboCiudadOrigen.Location = new System.Drawing.Point(165, 54);
            this.cboCiudadOrigen.Name = "cboCiudadOrigen";
            this.cboCiudadOrigen.Size = new System.Drawing.Size(121, 21);
            this.cboCiudadOrigen.TabIndex = 24;
            // 
            // lblOrigen
            // 
            this.lblOrigen.AutoSize = true;
            this.lblOrigen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrigen.Location = new System.Drawing.Point(22, 54);
            this.lblOrigen.Name = "lblOrigen";
            this.lblOrigen.Size = new System.Drawing.Size(103, 17);
            this.lblOrigen.TabIndex = 23;
            this.lblOrigen.Text = "Ciudad Origen:";
            // 
            // UctrlFiltrosRuta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "UctrlFiltrosRuta";
            this.Size = new System.Drawing.Size(770, 171);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblDestino;
        private AerolineaFrba.Utils.ComboBoxWithAllOption cboCiudadDestino;
        private AerolineaFrba.Utils.ComboBoxWithAllOption cboCiudadOrigen;
        private System.Windows.Forms.Label lblOrigen;
        private System.Windows.Forms.CheckedListBox chlServicios;
        private System.Windows.Forms.Label lblServicio;
        private System.Windows.Forms.Label lblPrecioBEnc;
        private System.Windows.Forms.Label lblPrecioBPas;
        private System.Windows.Forms.CheckBox chbHabilitado;
        private System.Windows.Forms.Label lblHabilitado;
        private Utils.DecimalBox dcmPrecioBPas;
        private Utils.DecimalBox dcmPrecioBEnc;
        private Utils.NumericBox numCodigoRuta;
        private System.Windows.Forms.Label lblCodigoRuta;
    }
}
