namespace AerolineaFrba.Abm_Ruta
{
    partial class RutaAereaForm
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
            this.pnlOpciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.pnlOpciones.Size = new System.Drawing.Size(792, 116);
            // 
            // btnListar
            // 
            this.btnListar.Location = new System.Drawing.Point(22, 47);
            this.btnListar.Click += new System.EventHandler(this.button1_Click);
            // 
            // button4
            // 
            this.btnEliminar.Location = new System.Drawing.Point(448, 47);
            // 
            // button3
            // 
            this.btnModificar.Location = new System.Drawing.Point(295, 47);
            // 
            // button2
            // 
            this.btnAgregar.Location = new System.Drawing.Point(151, 47);
            // 
            // RutaAereaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 486);
            this.Name = "RutaAereaForm";
            this.Text = "Ruta Aerea";
            this.pnlOpciones.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
    }
}