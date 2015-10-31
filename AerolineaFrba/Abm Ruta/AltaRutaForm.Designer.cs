namespace AerolineaFrba.Abm_Ruta
{
    partial class AltaRutaForm
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
            this.uctrlRuta = new AerolineaFrba.Abm_Ruta.UctrlRuta();
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
            // uctrlRuta
            // 
            this.uctrlRuta.Location = new System.Drawing.Point(51, 12);
            this.uctrlRuta.Name = "uctrlRuta";
            this.uctrlRuta.Size = new System.Drawing.Size(761, 349);
            this.uctrlRuta.TabIndex = 5;
            // 
            // AltaRutaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 486);
            this.Controls.Add(this.uctrlRuta);
            this.Name = "AltaRutaForm";
            this.Text = "AltaRutaForm";
            this.Load += new System.EventHandler(this.AltaRutaForm_Load);
            this.Controls.SetChildIndex(this.btnGuardar, 0);
            this.Controls.SetChildIndex(this.btnLimpiar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.uctrlRuta, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private UctrlRuta uctrlRuta;
    }
}