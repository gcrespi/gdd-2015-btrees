namespace AerolineaFrba.Abm_Rol
{
    partial class uctrlRol
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
            this.grbDatosRol = new System.Windows.Forms.GroupBox();
            this.chlFuncionalidades = new System.Windows.Forms.CheckedListBox();
            this.lblFuncionalidades = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.grbDatosRol.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbDatosRol
            // 
            this.grbDatosRol.Controls.Add(this.chlFuncionalidades);
            this.grbDatosRol.Controls.Add(this.lblFuncionalidades);
            this.grbDatosRol.Controls.Add(this.txtNombre);
            this.grbDatosRol.Controls.Add(this.lblNombre);
            this.grbDatosRol.Location = new System.Drawing.Point(3, 3);
            this.grbDatosRol.Name = "grbDatosRol";
            this.grbDatosRol.Size = new System.Drawing.Size(751, 337);
            this.grbDatosRol.TabIndex = 10;
            this.grbDatosRol.TabStop = false;
            this.grbDatosRol.Text = "Datos del nuevo Rol";
            // 
            // chlFuncionalidades
            // 
            this.chlFuncionalidades.FormattingEnabled = true;
            this.chlFuncionalidades.Location = new System.Drawing.Point(353, 99);
            this.chlFuncionalidades.Name = "chlFuncionalidades";
            this.chlFuncionalidades.Size = new System.Drawing.Size(271, 199);
            this.chlFuncionalidades.TabIndex = 12;
            // 
            // lblFuncionalidades
            // 
            this.lblFuncionalidades.AutoSize = true;
            this.lblFuncionalidades.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFuncionalidades.Location = new System.Drawing.Point(126, 99);
            this.lblFuncionalidades.Name = "lblFuncionalidades";
            this.lblFuncionalidades.Size = new System.Drawing.Size(150, 24);
            this.lblFuncionalidades.TabIndex = 11;
            this.lblFuncionalidades.Text = "Funcionalidades";
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(353, 38);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(0);
            this.txtNombre.MaxLength = 60;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(271, 30);
            this.txtNombre.TabIndex = 10;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(126, 42);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(79, 24);
            this.lblNombre.TabIndex = 9;
            this.lblNombre.Text = "Nombre";
            // 
            // uctrlRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grbDatosRol);
            this.Name = "uctrlRol";
            this.Size = new System.Drawing.Size(761, 349);
            this.grbDatosRol.ResumeLayout(false);
            this.grbDatosRol.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbDatosRol;
        private System.Windows.Forms.CheckedListBox chlFuncionalidades;
        private System.Windows.Forms.Label lblFuncionalidades;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblNombre;
    }
}
