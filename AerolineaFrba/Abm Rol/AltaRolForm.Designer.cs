namespace AerolineaFrba.Abm_Rol
{
    partial class AltaRolForm
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
            this.grbDatosRol.Location = new System.Drawing.Point(39, 28);
            this.grbDatosRol.Name = "grbDatosRol";
            this.grbDatosRol.Size = new System.Drawing.Size(751, 337);
            this.grbDatosRol.TabIndex = 9;
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
            // AltaRolForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 486);
            this.Controls.Add(this.grbDatosRol);
            this.Name = "AltaRolForm";
            this.Text = "AltaRolForm";
            this.Load += new System.EventHandler(this.AltaRolForm_Load);
            this.Controls.SetChildIndex(this.grbDatosRol, 0);
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