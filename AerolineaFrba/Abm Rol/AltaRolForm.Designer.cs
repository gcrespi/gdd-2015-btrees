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
            this.uctrlRolAlta = new AerolineaFrba.Abm_Rol.UctrlRol();
            this.SuspendLayout();
            // 
            // btnGuardar
            // 
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.FlatAppearance.BorderSize = 0;
            // 
            // btnCancelar
            // 
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            // 
            // uctrlRolAlta
            // 
            this.uctrlRolAlta.Location = new System.Drawing.Point(51, 27);
            this.uctrlRolAlta.Name = "uctrlRolAlta";
            this.uctrlRolAlta.Size = new System.Drawing.Size(761, 349);
            this.uctrlRolAlta.TabIndex = 5;
            // 
            // AltaRolForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 486);
            this.Controls.Add(this.uctrlRolAlta);
            this.Name = "AltaRolForm";
            this.Text = "AltaRolForm";
            this.Load += new System.EventHandler(this.AltaRolForm_Load);
            this.Controls.SetChildIndex(this.btnGuardar, 0);
            this.Controls.SetChildIndex(this.btnLimpiar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.uctrlRolAlta, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private UctrlRol uctrlRolAlta;


    }
}