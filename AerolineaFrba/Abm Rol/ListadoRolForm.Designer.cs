﻿namespace AerolineaFrba.Abm_Rol
{
    partial class ListadoRolForm
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
            this.uctrlFiltrosRol1 = new AerolineaFrba.Abm_Rol.uctrlFiltrosRol();
            this.SuspendLayout();
            // 
            // btnVolver
            // 
            this.btnVolver.FlatAppearance.BorderSize = 0;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.FlatAppearance.BorderSize = 0;
            // 
            // uctrlFiltrosRol1
            // 
            this.uctrlFiltrosRol1.Location = new System.Drawing.Point(12, -1);
            this.uctrlFiltrosRol1.Name = "uctrlFiltrosRol1";
            this.uctrlFiltrosRol1.Size = new System.Drawing.Size(868, 177);
            this.uctrlFiltrosRol1.TabIndex = 8;
            // 
            // ListadoRolForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 486);
            this.Controls.Add(this.uctrlFiltrosRol1);
            this.Name = "ListadoRolForm";
            this.Text = "ListadoRolForm";
            this.Load += new System.EventHandler(this.ListadoForm_Load);
            this.Controls.SetChildIndex(this.btnVolver, 0);
            this.Controls.SetChildIndex(this.btnLimpiar, 0);
            this.Controls.SetChildIndex(this.uctrlFiltrosRol1, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private uctrlFiltrosRol uctrlFiltrosRol1;




    }
}