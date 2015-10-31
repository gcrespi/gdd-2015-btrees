namespace AerolineaFrba.Abm_Ruta
{
    partial class UctrlRuta
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
            this.grbDatosRuta = new System.Windows.Forms.GroupBox();
            this.dcmPrecioBPas = new AerolineaFrba.Utils.DecimalBox();
            this.dcmPrecioBEnc = new AerolineaFrba.Utils.DecimalBox();
            this.lblValPrecioBEnc = new System.Windows.Forms.Label();
            this.lblValPrecioBPas = new System.Windows.Forms.Label();
            this.lblValServicio = new System.Windows.Forms.Label();
            this.lblValDestino = new System.Windows.Forms.Label();
            this.lblValOrigen = new System.Windows.Forms.Label();
            this.chbHabilitado = new System.Windows.Forms.CheckBox();
            this.lblHabilitado = new System.Windows.Forms.Label();
            this.lblPrecioBEnc = new System.Windows.Forms.Label();
            this.lblPrecioBPas = new System.Windows.Forms.Label();
            this.chlServicios = new System.Windows.Forms.CheckedListBox();
            this.lblServicio = new System.Windows.Forms.Label();
            this.lblDestino = new System.Windows.Forms.Label();
            this.cboCiudadDestino = new System.Windows.Forms.ComboBox();
            this.cboCiudadOrigen = new System.Windows.Forms.ComboBox();
            this.lblOrigen = new System.Windows.Forms.Label();
            this.numCodigoRuta = new AerolineaFrba.Utils.NumericBox();
            this.lblCodigoRuta = new System.Windows.Forms.Label();
            this.lblValCodigoRuta = new System.Windows.Forms.Label();
            this.grbDatosRuta.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbDatosRuta
            // 
            this.grbDatosRuta.Controls.Add(this.lblValCodigoRuta);
            this.grbDatosRuta.Controls.Add(this.numCodigoRuta);
            this.grbDatosRuta.Controls.Add(this.lblCodigoRuta);
            this.grbDatosRuta.Controls.Add(this.dcmPrecioBPas);
            this.grbDatosRuta.Controls.Add(this.dcmPrecioBEnc);
            this.grbDatosRuta.Controls.Add(this.lblValPrecioBEnc);
            this.grbDatosRuta.Controls.Add(this.lblValPrecioBPas);
            this.grbDatosRuta.Controls.Add(this.lblValServicio);
            this.grbDatosRuta.Controls.Add(this.lblValDestino);
            this.grbDatosRuta.Controls.Add(this.lblValOrigen);
            this.grbDatosRuta.Controls.Add(this.chbHabilitado);
            this.grbDatosRuta.Controls.Add(this.lblHabilitado);
            this.grbDatosRuta.Controls.Add(this.lblPrecioBEnc);
            this.grbDatosRuta.Controls.Add(this.lblPrecioBPas);
            this.grbDatosRuta.Controls.Add(this.chlServicios);
            this.grbDatosRuta.Controls.Add(this.lblServicio);
            this.grbDatosRuta.Controls.Add(this.lblDestino);
            this.grbDatosRuta.Controls.Add(this.cboCiudadDestino);
            this.grbDatosRuta.Controls.Add(this.cboCiudadOrigen);
            this.grbDatosRuta.Controls.Add(this.lblOrigen);
            this.grbDatosRuta.Location = new System.Drawing.Point(3, 3);
            this.grbDatosRuta.Name = "grbDatosRuta";
            this.grbDatosRuta.Size = new System.Drawing.Size(751, 337);
            this.grbDatosRuta.TabIndex = 10;
            this.grbDatosRuta.TabStop = false;
            this.grbDatosRuta.Text = "Datos de la Ruta";
            // 
            // dcmPrecioBPas
            // 
            this.dcmPrecioBPas.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dcmPrecioBPas.Location = new System.Drawing.Point(157, 236);
            this.dcmPrecioBPas.Margin = new System.Windows.Forms.Padding(0);
            this.dcmPrecioBPas.MaxLength = 60;
            this.dcmPrecioBPas.Name = "dcmPrecioBPas";
            this.dcmPrecioBPas.Size = new System.Drawing.Size(120, 24);
            this.dcmPrecioBPas.TabIndex = 40;
            this.dcmPrecioBPas.TextValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // dcmPrecioBEnc
            // 
            this.dcmPrecioBEnc.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dcmPrecioBEnc.Location = new System.Drawing.Point(503, 234);
            this.dcmPrecioBEnc.Margin = new System.Windows.Forms.Padding(0);
            this.dcmPrecioBEnc.MaxLength = 60;
            this.dcmPrecioBEnc.Name = "dcmPrecioBEnc";
            this.dcmPrecioBEnc.Size = new System.Drawing.Size(120, 24);
            this.dcmPrecioBEnc.TabIndex = 39;
            this.dcmPrecioBEnc.TextValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // lblValPrecioBEnc
            // 
            this.lblValPrecioBEnc.AutoSize = true;
            this.lblValPrecioBEnc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValPrecioBEnc.ForeColor = System.Drawing.Color.DarkRed;
            this.lblValPrecioBEnc.Location = new System.Drawing.Point(352, 271);
            this.lblValPrecioBEnc.Name = "lblValPrecioBEnc";
            this.lblValPrecioBEnc.Size = new System.Drawing.Size(0, 17);
            this.lblValPrecioBEnc.TabIndex = 37;
            // 
            // lblValPrecioBPas
            // 
            this.lblValPrecioBPas.AutoSize = true;
            this.lblValPrecioBPas.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValPrecioBPas.ForeColor = System.Drawing.Color.DarkRed;
            this.lblValPrecioBPas.Location = new System.Drawing.Point(37, 271);
            this.lblValPrecioBPas.Name = "lblValPrecioBPas";
            this.lblValPrecioBPas.Size = new System.Drawing.Size(0, 17);
            this.lblValPrecioBPas.TabIndex = 36;
            // 
            // lblValServicio
            // 
            this.lblValServicio.AutoSize = true;
            this.lblValServicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValServicio.ForeColor = System.Drawing.Color.DarkRed;
            this.lblValServicio.Location = new System.Drawing.Point(388, 157);
            this.lblValServicio.Name = "lblValServicio";
            this.lblValServicio.Size = new System.Drawing.Size(0, 17);
            this.lblValServicio.TabIndex = 35;
            // 
            // lblValDestino
            // 
            this.lblValDestino.AutoSize = true;
            this.lblValDestino.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValDestino.ForeColor = System.Drawing.Color.DarkRed;
            this.lblValDestino.Location = new System.Drawing.Point(407, 99);
            this.lblValDestino.Name = "lblValDestino";
            this.lblValDestino.Size = new System.Drawing.Size(0, 17);
            this.lblValDestino.TabIndex = 34;
            // 
            // lblValOrigen
            // 
            this.lblValOrigen.AutoSize = true;
            this.lblValOrigen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValOrigen.ForeColor = System.Drawing.Color.DarkRed;
            this.lblValOrigen.Location = new System.Drawing.Point(37, 99);
            this.lblValOrigen.Name = "lblValOrigen";
            this.lblValOrigen.Size = new System.Drawing.Size(0, 17);
            this.lblValOrigen.TabIndex = 33;
            // 
            // chbHabilitado
            // 
            this.chbHabilitado.AutoSize = true;
            this.chbHabilitado.Location = new System.Drawing.Point(157, 308);
            this.chbHabilitado.Name = "chbHabilitado";
            this.chbHabilitado.Size = new System.Drawing.Size(15, 14);
            this.chbHabilitado.TabIndex = 30;
            this.chbHabilitado.UseVisualStyleBackColor = true;
            // 
            // lblHabilitado
            // 
            this.lblHabilitado.AutoSize = true;
            this.lblHabilitado.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHabilitado.Location = new System.Drawing.Point(37, 305);
            this.lblHabilitado.Name = "lblHabilitado";
            this.lblHabilitado.Size = new System.Drawing.Size(71, 17);
            this.lblHabilitado.TabIndex = 29;
            this.lblHabilitado.Text = "Habilitado";
            // 
            // lblPrecioBEnc
            // 
            this.lblPrecioBEnc.AutoSize = true;
            this.lblPrecioBEnc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecioBEnc.Location = new System.Drawing.Point(326, 241);
            this.lblPrecioBEnc.Name = "lblPrecioBEnc";
            this.lblPrecioBEnc.Size = new System.Drawing.Size(170, 17);
            this.lblPrecioBEnc.TabIndex = 28;
            this.lblPrecioBEnc.Text = "Precio Base Encomienda:";
            // 
            // lblPrecioBPas
            // 
            this.lblPrecioBPas.AutoSize = true;
            this.lblPrecioBPas.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecioBPas.Location = new System.Drawing.Point(14, 241);
            this.lblPrecioBPas.Name = "lblPrecioBPas";
            this.lblPrecioBPas.Size = new System.Drawing.Size(135, 17);
            this.lblPrecioBPas.TabIndex = 27;
            this.lblPrecioBPas.Text = "Precio Base Pasaje:";
            // 
            // chlServicios
            // 
            this.chlServicios.FormattingEnabled = true;
            this.chlServicios.Location = new System.Drawing.Point(157, 131);
            this.chlServicios.Name = "chlServicios";
            this.chlServicios.Size = new System.Drawing.Size(205, 79);
            this.chlServicios.TabIndex = 26;
            // 
            // lblServicio
            // 
            this.lblServicio.AutoSize = true;
            this.lblServicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServicio.Location = new System.Drawing.Point(14, 131);
            this.lblServicio.Name = "lblServicio";
            this.lblServicio.Size = new System.Drawing.Size(94, 17);
            this.lblServicio.TabIndex = 25;
            this.lblServicio.Text = "Tipo Servicio:";
            // 
            // lblDestino
            // 
            this.lblDestino.AutoSize = true;
            this.lblDestino.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDestino.Location = new System.Drawing.Point(388, 63);
            this.lblDestino.Name = "lblDestino";
            this.lblDestino.Size = new System.Drawing.Size(108, 17);
            this.lblDestino.TabIndex = 22;
            this.lblDestino.Text = "Ciudad Destino:";
            // 
            // cboCiudadDestino
            // 
            this.cboCiudadDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCiudadDestino.FormattingEnabled = true;
            this.cboCiudadDestino.Location = new System.Drawing.Point(502, 63);
            this.cboCiudadDestino.Name = "cboCiudadDestino";
            this.cboCiudadDestino.Size = new System.Drawing.Size(121, 21);
            this.cboCiudadDestino.TabIndex = 20;
            // 
            // cboCiudadOrigen
            // 
            this.cboCiudadOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCiudadOrigen.FormattingEnabled = true;
            this.cboCiudadOrigen.Location = new System.Drawing.Point(157, 63);
            this.cboCiudadOrigen.Name = "cboCiudadOrigen";
            this.cboCiudadOrigen.Size = new System.Drawing.Size(121, 21);
            this.cboCiudadOrigen.TabIndex = 19;
            // 
            // lblOrigen
            // 
            this.lblOrigen.AutoSize = true;
            this.lblOrigen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrigen.Location = new System.Drawing.Point(14, 63);
            this.lblOrigen.Name = "lblOrigen";
            this.lblOrigen.Size = new System.Drawing.Size(103, 17);
            this.lblOrigen.TabIndex = 9;
            this.lblOrigen.Text = "Ciudad Origen:";
            // 
            // numCodigoRuta
            // 
            this.numCodigoRuta.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numCodigoRuta.Location = new System.Drawing.Point(158, 23);
            this.numCodigoRuta.Margin = new System.Windows.Forms.Padding(0);
            this.numCodigoRuta.MaxLength = 60;
            this.numCodigoRuta.Name = "numCodigoRuta";
            this.numCodigoRuta.Size = new System.Drawing.Size(120, 24);
            this.numCodigoRuta.TabIndex = 49;
            this.numCodigoRuta.TextValue = 0;
            // 
            // lblCodigoRuta
            // 
            this.lblCodigoRuta.AutoSize = true;
            this.lblCodigoRuta.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodigoRuta.Location = new System.Drawing.Point(14, 26);
            this.lblCodigoRuta.Name = "lblCodigoRuta";
            this.lblCodigoRuta.Size = new System.Drawing.Size(90, 17);
            this.lblCodigoRuta.TabIndex = 48;
            this.lblCodigoRuta.Text = "Codigo Ruta:";
            // 
            // lblValCodigoRuta
            // 
            this.lblValCodigoRuta.AutoSize = true;
            this.lblValCodigoRuta.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValCodigoRuta.ForeColor = System.Drawing.Color.DarkRed;
            this.lblValCodigoRuta.Location = new System.Drawing.Point(352, 23);
            this.lblValCodigoRuta.Name = "lblValCodigoRuta";
            this.lblValCodigoRuta.Size = new System.Drawing.Size(0, 17);
            this.lblValCodigoRuta.TabIndex = 50;
            // 
            // UctrlRuta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grbDatosRuta);
            this.Name = "UctrlRuta";
            this.Size = new System.Drawing.Size(761, 349);
            this.grbDatosRuta.ResumeLayout(false);
            this.grbDatosRuta.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbDatosRuta;
        private System.Windows.Forms.Label lblOrigen;
        private System.Windows.Forms.Label lblServicio;
        private System.Windows.Forms.Label lblDestino;
        private System.Windows.Forms.ComboBox cboCiudadDestino;
        private System.Windows.Forms.ComboBox cboCiudadOrigen;
        private System.Windows.Forms.Label lblPrecioBEnc;
        private System.Windows.Forms.Label lblPrecioBPas;
        private System.Windows.Forms.CheckedListBox chlServicios;
        private System.Windows.Forms.CheckBox chbHabilitado;
        private System.Windows.Forms.Label lblHabilitado;
        private System.Windows.Forms.Label lblValPrecioBEnc;
        private System.Windows.Forms.Label lblValPrecioBPas;
        private System.Windows.Forms.Label lblValServicio;
        private System.Windows.Forms.Label lblValDestino;
        private System.Windows.Forms.Label lblValOrigen;
        private Utils.DecimalBox dcmPrecioBPas;
        private Utils.DecimalBox dcmPrecioBEnc;
        private System.Windows.Forms.Label lblValCodigoRuta;
        private Utils.NumericBox numCodigoRuta;
        private System.Windows.Forms.Label lblCodigoRuta;
    }
}
