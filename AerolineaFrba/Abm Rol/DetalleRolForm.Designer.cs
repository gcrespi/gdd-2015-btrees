namespace AerolineaFrba.Abm_Rol
{
    partial class DetalleRolForm
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
            this.uctrlRolDetalle = new AerolineaFrba.Abm_Rol.UctrlRol();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            // 
            // uctrlRolDetalle
            // 
            this.uctrlRolDetalle.Location = new System.Drawing.Point(12, 12);
            this.uctrlRolDetalle.Name = "uctrlRolDetalle";
            this.uctrlRolDetalle.Size = new System.Drawing.Size(761, 349);
            this.uctrlRolDetalle.TabIndex = 6;
            // 
            // DetalleRolForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 490);
            this.Controls.Add(this.uctrlRolDetalle);
            this.Name = "DetalleRolForm";
            this.Text = "DetalleRolForm";
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.uctrlRolDetalle, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private UctrlRol uctrlRolDetalle;
    }
}