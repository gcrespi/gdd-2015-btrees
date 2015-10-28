namespace AerolineaFrba.Abm_Rol
{
    partial class ModifRolForm
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
            this.uctrlRolModif = new AerolineaFrba.Abm_Rol.uctrlRol();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            // 
            // btnModif
            // 
            this.btnModif.FlatAppearance.BorderSize = 0;
            // 
            // uctrlRolModif
            // 
            this.uctrlRolModif.Location = new System.Drawing.Point(12, 12);
            this.uctrlRolModif.Name = "uctrlRolModif";
            this.uctrlRolModif.Size = new System.Drawing.Size(761, 349);
            this.uctrlRolModif.TabIndex = 7;
            // 
            // ModifRolForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 490);
            this.Controls.Add(this.uctrlRolModif);
            this.Name = "ModifRolForm";
            this.Text = "ModifRolForm";
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnModif, 0);
            this.Controls.SetChildIndex(this.uctrlRolModif, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private uctrlRol uctrlRolModif;

    }
}