namespace AerolineaFrba
{
    partial class MasterForm
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
            this.menu = new System.Windows.Forms.MenuStrip();
            this.bHome = new System.Windows.Forms.ToolStripMenuItem();
            this.bAdministracion = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMAeronaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMCiudadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMRolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMRutaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bCompras = new System.Windows.Forms.ToolStripMenuItem();
            this.bMillas = new System.Windows.Forms.ToolStripMenuItem();
            this.consultaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.canjeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bDevolucion = new System.Windows.Forms.ToolStripMenuItem();
            this.bAuditoria = new System.Windows.Forms.ToolStripMenuItem();
            this.regUsuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.regLLegadaDestinoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.AutoSize = false;
            this.menu.BackColor = System.Drawing.Color.White;
            this.menu.Dock = System.Windows.Forms.DockStyle.Left;
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bHome,
            this.bAdministracion,
            this.bCompras,
            this.bMillas,
            this.bDevolucion,
            this.bAuditoria});
            this.menu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Padding = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.menu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menu.Size = new System.Drawing.Size(100, 486);
            this.menu.TabIndex = 2;
            this.menu.Text = "menuStrip1";
            // 
            // bHome
            // 
            this.bHome.AutoSize = false;
            this.bHome.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.bHome.Font = new System.Drawing.Font("Calibri Light", 15F);
            this.bHome.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.bHome.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.bHome.Name = "bHome";
            this.bHome.Padding = new System.Windows.Forms.Padding(0);
            this.bHome.Size = new System.Drawing.Size(98, 80);
            this.bHome.Text = "Home";
            // 
            // bAdministracion
            // 
            this.bAdministracion.AutoSize = false;
            this.bAdministracion.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.bAdministracion.Checked = true;
            this.bAdministracion.CheckState = System.Windows.Forms.CheckState.Checked;
            this.bAdministracion.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aBMAeronaveToolStripMenuItem,
            this.aBMCiudadToolStripMenuItem,
            this.aBMRolToolStripMenuItem,
            this.aBMRutaToolStripMenuItem});
            this.bAdministracion.Font = new System.Drawing.Font("Calibri Light", 15F);
            this.bAdministracion.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.bAdministracion.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.bAdministracion.Name = "bAdministracion";
            this.bAdministracion.Padding = new System.Windows.Forms.Padding(0);
            this.bAdministracion.Size = new System.Drawing.Size(98, 80);
            this.bAdministracion.Text = "Admin";
            // 
            // aBMAeronaveToolStripMenuItem
            // 
            this.aBMAeronaveToolStripMenuItem.AutoSize = false;
            this.aBMAeronaveToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.aBMAeronaveToolStripMenuItem.Name = "aBMAeronaveToolStripMenuItem";
            this.aBMAeronaveToolStripMenuItem.Size = new System.Drawing.Size(200, 28);
            this.aBMAeronaveToolStripMenuItem.Text = "ABM Aeronave";
            // 
            // aBMCiudadToolStripMenuItem
            // 
            this.aBMCiudadToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.aBMCiudadToolStripMenuItem.Name = "aBMCiudadToolStripMenuItem";
            this.aBMCiudadToolStripMenuItem.Size = new System.Drawing.Size(200, 28);
            this.aBMCiudadToolStripMenuItem.Text = "ABM Ciudad";
            // 
            // aBMRolToolStripMenuItem
            // 
            this.aBMRolToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.aBMRolToolStripMenuItem.Name = "aBMRolToolStripMenuItem";
            this.aBMRolToolStripMenuItem.Size = new System.Drawing.Size(200, 28);
            this.aBMRolToolStripMenuItem.Text = "ABM Rol";
            // 
            // aBMRutaToolStripMenuItem
            // 
            this.aBMRutaToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.aBMRutaToolStripMenuItem.Name = "aBMRutaToolStripMenuItem";
            this.aBMRutaToolStripMenuItem.Size = new System.Drawing.Size(200, 28);
            this.aBMRutaToolStripMenuItem.Text = "ABM Ruta";
            this.aBMRutaToolStripMenuItem.Click += new System.EventHandler(this.aBMRutaToolStripMenuItem_Click);
            // 
            // bCompras
            // 
            this.bCompras.AutoSize = false;
            this.bCompras.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.bCompras.Font = new System.Drawing.Font("Calibri Light", 15F);
            this.bCompras.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.bCompras.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.bCompras.Name = "bCompras";
            this.bCompras.Padding = new System.Windows.Forms.Padding(0);
            this.bCompras.Size = new System.Drawing.Size(98, 80);
            this.bCompras.Text = "Compras";
            // 
            // bMillas
            // 
            this.bMillas.AutoSize = false;
            this.bMillas.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.bMillas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.consultaToolStripMenuItem,
            this.canjeToolStripMenuItem});
            this.bMillas.Font = new System.Drawing.Font("Calibri Light", 15F);
            this.bMillas.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.bMillas.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.bMillas.Name = "bMillas";
            this.bMillas.Padding = new System.Windows.Forms.Padding(0);
            this.bMillas.Size = new System.Drawing.Size(98, 80);
            this.bMillas.Text = "Millas";
            // 
            // consultaToolStripMenuItem
            // 
            this.consultaToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.consultaToolStripMenuItem.Name = "consultaToolStripMenuItem";
            this.consultaToolStripMenuItem.Size = new System.Drawing.Size(152, 28);
            this.consultaToolStripMenuItem.Text = "Consulta";
            // 
            // canjeToolStripMenuItem
            // 
            this.canjeToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.canjeToolStripMenuItem.Name = "canjeToolStripMenuItem";
            this.canjeToolStripMenuItem.Size = new System.Drawing.Size(152, 28);
            this.canjeToolStripMenuItem.Text = "Canje";
            // 
            // bDevolucion
            // 
            this.bDevolucion.AutoSize = false;
            this.bDevolucion.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.bDevolucion.Font = new System.Drawing.Font("Calibri Light", 15F);
            this.bDevolucion.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.bDevolucion.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.bDevolucion.Name = "bDevolucion";
            this.bDevolucion.Padding = new System.Windows.Forms.Padding(0);
            this.bDevolucion.Size = new System.Drawing.Size(98, 80);
            this.bDevolucion.Text = "Devolución";
            // 
            // bAuditoria
            // 
            this.bAuditoria.AutoSize = false;
            this.bAuditoria.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.bAuditoria.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.regUsuariosToolStripMenuItem,
            this.regLLegadaDestinoToolStripMenuItem});
            this.bAuditoria.Font = new System.Drawing.Font("Calibri Light", 15F);
            this.bAuditoria.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.bAuditoria.Name = "bAuditoria";
            this.bAuditoria.Padding = new System.Windows.Forms.Padding(0);
            this.bAuditoria.Size = new System.Drawing.Size(98, 80);
            this.bAuditoria.Text = "Auditoría";
            // 
            // regUsuariosToolStripMenuItem
            // 
            this.regUsuariosToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.regUsuariosToolStripMenuItem.Name = "regUsuariosToolStripMenuItem";
            this.regUsuariosToolStripMenuItem.Size = new System.Drawing.Size(244, 28);
            this.regUsuariosToolStripMenuItem.Text = "Reg Usuarios";
            // 
            // regLLegadaDestinoToolStripMenuItem
            // 
            this.regLLegadaDestinoToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.regLLegadaDestinoToolStripMenuItem.Name = "regLLegadaDestinoToolStripMenuItem";
            this.regLLegadaDestinoToolStripMenuItem.Size = new System.Drawing.Size(244, 28);
            this.regLLegadaDestinoToolStripMenuItem.Text = "Reg LLegada Destino";
            // 
            // MasterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(884, 486);
            this.Controls.Add(this.menu);
            this.Name = "MasterForm";
            this.Text = "Aerolineas Patito";
            this.Load += new System.EventHandler(this.MasterForm_Load);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.ToolStripMenuItem bCompras;
        protected System.Windows.Forms.ToolStripMenuItem bAdministracion;
        private System.Windows.Forms.ToolStripMenuItem aBMRolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aBMRutaToolStripMenuItem;
        protected System.Windows.Forms.ToolStripMenuItem bMillas;
        protected System.Windows.Forms.ToolStripMenuItem bDevolucion;
        protected System.Windows.Forms.ToolStripMenuItem bAuditoria;
        private System.Windows.Forms.ToolStripMenuItem consultaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem canjeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem regUsuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem regLLegadaDestinoToolStripMenuItem;
        protected System.Windows.Forms.ToolStripMenuItem bHome;
        protected System.Windows.Forms.ToolStripMenuItem aBMAeronaveToolStripMenuItem;
        protected System.Windows.Forms.ToolStripMenuItem aBMCiudadToolStripMenuItem;
        public System.Windows.Forms.MenuStrip menu;
    }
}