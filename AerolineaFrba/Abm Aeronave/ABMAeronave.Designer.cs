namespace AerolineaFrba.Abm_Aeronave
{
    partial class ABMAeronave
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnServicio = new System.Windows.Forms.Button();
            this.pnlOpciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlOpciones
            // 
            this.pnlOpciones.Controls.Add(this.btnServicio);
            this.pnlOpciones.Location = new System.Drawing.Point(0, 346);
            this.pnlOpciones.Size = new System.Drawing.Size(931, 116);
            this.pnlOpciones.Controls.SetChildIndex(this.btnListar, 0);
            this.pnlOpciones.Controls.SetChildIndex(this.btnAgregar, 0);
            this.pnlOpciones.Controls.SetChildIndex(this.btnModificar, 0);
            this.pnlOpciones.Controls.SetChildIndex(this.btnEliminar, 0);
            this.pnlOpciones.Controls.SetChildIndex(this.btnServicio, 0);
            // 
            // btnListar
            // 
            this.btnListar.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(43, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "ABMAeronave";
            // 
            // btnServicio
            // 
            this.btnServicio.BackColor = System.Drawing.Color.Silver;
            this.btnServicio.FlatAppearance.BorderSize = 0;
            this.btnServicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnServicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnServicio.Location = new System.Drawing.Point(624, 39);
            this.btnServicio.Name = "btnServicio";
            this.btnServicio.Size = new System.Drawing.Size(128, 37);
            this.btnServicio.TabIndex = 4;
            this.btnServicio.Text = "Fuera de Servicio";
            this.btnServicio.UseVisualStyleBackColor = false;
            this.btnServicio.Click += new System.EventHandler(this.btnServicio_Click);
            // 
            // ABMAeronave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 532);
            this.Controls.Add(this.label1);
            this.Name = "ABMAeronave";
            this.Text = "ABM Aeronave";
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.pnlOpciones, 0);
            this.pnlOpciones.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        protected System.Windows.Forms.Button btnServicio;
    }
}