namespace AerolineaFrba
{
    partial class Main
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
            this.aBMRolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMRutaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generarViajeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bCompras = new System.Windows.Forms.ToolStripMenuItem();
            this.bMillas = new System.Windows.Forms.ToolStripMenuItem();
            this.consultaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.canjeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bDevolucion = new System.Windows.Forms.ToolStripMenuItem();
            this.bAuditoria = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.bEstadisticas = new System.Windows.Forms.ToolStripMenuItem();
            this.panel = new System.Windows.Forms.Panel();
            this.menuPanel = new System.Windows.Forms.Panel();
            this.menu.SuspendLayout();
            this.menuPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.AutoSize = false;
            this.menu.BackColor = System.Drawing.Color.White;
            this.menu.Dock = System.Windows.Forms.DockStyle.None;
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bHome,
            this.bAdministracion,
            this.bCompras,
            this.bMillas,
            this.bDevolucion,
            this.bAuditoria,
            this.bEstadisticas});
            this.menu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Padding = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.menu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menu.Size = new System.Drawing.Size(105, 570);
            this.menu.TabIndex = 2;
            this.menu.Text = "menu";
            // 
            // bHome
            // 
            this.bHome.AutoSize = false;
            this.bHome.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.bHome.Font = new System.Drawing.Font("Calibri Light", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bHome.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.bHome.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.bHome.Name = "bHome";
            this.bHome.Padding = new System.Windows.Forms.Padding(0);
            this.bHome.Size = new System.Drawing.Size(103, 30);
            this.bHome.Text = "Home";
            this.bHome.Click += new System.EventHandler(this.bHome_Click);
            // 
            // bAdministracion
            // 
            this.bAdministracion.AutoSize = false;
            this.bAdministracion.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.bAdministracion.Checked = true;
            this.bAdministracion.CheckState = System.Windows.Forms.CheckState.Checked;
            this.bAdministracion.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aBMAeronaveToolStripMenuItem,
            this.aBMRolToolStripMenuItem,
            this.aBMRutaToolStripMenuItem,
            this.generarViajeToolStripMenuItem});
            this.bAdministracion.Font = new System.Drawing.Font("Calibri Light", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bAdministracion.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.bAdministracion.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.bAdministracion.Name = "bAdministracion";
            this.bAdministracion.Padding = new System.Windows.Forms.Padding(0);
            this.bAdministracion.Size = new System.Drawing.Size(103, 30);
            this.bAdministracion.Text = "Admin";
            // 
            // aBMAeronaveToolStripMenuItem
            // 
            this.aBMAeronaveToolStripMenuItem.AutoSize = false;
            this.aBMAeronaveToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.aBMAeronaveToolStripMenuItem.Name = "aBMAeronaveToolStripMenuItem";
            this.aBMAeronaveToolStripMenuItem.Size = new System.Drawing.Size(200, 28);
            this.aBMAeronaveToolStripMenuItem.Text = "ABM Aeronave";
            this.aBMAeronaveToolStripMenuItem.Click += new System.EventHandler(this.aBMAeronaveToolStripMenuItem_Click);
            // 
            // aBMRolToolStripMenuItem
            // 
            this.aBMRolToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.aBMRolToolStripMenuItem.Name = "aBMRolToolStripMenuItem";
            this.aBMRolToolStripMenuItem.Size = new System.Drawing.Size(213, 28);
            this.aBMRolToolStripMenuItem.Text = "ABM Rol";
            this.aBMRolToolStripMenuItem.Click += new System.EventHandler(this.aBMRolToolStripMenuItem_Click);
            // 
            // aBMRutaToolStripMenuItem
            // 
            this.aBMRutaToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.aBMRutaToolStripMenuItem.Name = "aBMRutaToolStripMenuItem";
            this.aBMRutaToolStripMenuItem.Size = new System.Drawing.Size(213, 28);
            this.aBMRutaToolStripMenuItem.Text = "ABM Ruta Aerea";
            this.aBMRutaToolStripMenuItem.Click += new System.EventHandler(this.aBMRutaToolStripMenuItem_Click);
            // 
            // generarViajeToolStripMenuItem
            // 
            this.generarViajeToolStripMenuItem.Name = "generarViajeToolStripMenuItem";
            this.generarViajeToolStripMenuItem.Size = new System.Drawing.Size(213, 28);
            this.generarViajeToolStripMenuItem.Text = "Generar Viaje";
            this.generarViajeToolStripMenuItem.Click += new System.EventHandler(this.generarViajeToolStripMenuItem_Click);
            // 
            // bCompras
            // 
            this.bCompras.AutoSize = false;
            this.bCompras.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.bCompras.Font = new System.Drawing.Font("Calibri Light", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bCompras.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.bCompras.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.bCompras.Name = "bCompras";
            this.bCompras.Padding = new System.Windows.Forms.Padding(0);
            this.bCompras.Size = new System.Drawing.Size(103, 30);
            this.bCompras.Text = "Comprar";
            this.bCompras.Click += new System.EventHandler(this.bCompras_Click);
            // 
            // bMillas
            // 
            this.bMillas.AutoSize = false;
            this.bMillas.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.bMillas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.consultaToolStripMenuItem,
            this.canjeToolStripMenuItem});
            this.bMillas.Font = new System.Drawing.Font("Calibri Light", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bMillas.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.bMillas.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.bMillas.Name = "bMillas";
            this.bMillas.Padding = new System.Windows.Forms.Padding(0);
            this.bMillas.Size = new System.Drawing.Size(103, 30);
            this.bMillas.Text = "Millas";
            // 
            // consultaToolStripMenuItem
            // 
            this.consultaToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.consultaToolStripMenuItem.Name = "consultaToolStripMenuItem";
            this.consultaToolStripMenuItem.Size = new System.Drawing.Size(225, 28);
            this.consultaToolStripMenuItem.Text = "Consulta de Millas";
            this.consultaToolStripMenuItem.Click += new System.EventHandler(this.consultaToolStripMenuItem_Click);
            // 
            // canjeToolStripMenuItem
            // 
            this.canjeToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.canjeToolStripMenuItem.Name = "canjeToolStripMenuItem";
            this.canjeToolStripMenuItem.Size = new System.Drawing.Size(225, 28);
            this.canjeToolStripMenuItem.Text = "Canje de Millas";
            this.canjeToolStripMenuItem.Click += new System.EventHandler(this.canjeToolStripMenuItem_Click);
            // 
            // bDevolucion
            // 
            this.bDevolucion.AutoSize = false;
            this.bDevolucion.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.bDevolucion.Font = new System.Drawing.Font("Calibri Light", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bDevolucion.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.bDevolucion.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.bDevolucion.Name = "bDevolucion";
            this.bDevolucion.Padding = new System.Windows.Forms.Padding(0);
            this.bDevolucion.Size = new System.Drawing.Size(103, 30);
            this.bDevolucion.Text = "Cancelacion";
            this.bDevolucion.Click += new System.EventHandler(this.bDevolucion_Click);
            // 
            // bAuditoria
            // 
            this.bAuditoria.AutoSize = false;
            this.bAuditoria.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.bAuditoria.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem6});
            this.bAuditoria.Font = new System.Drawing.Font("Calibri Light", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bAuditoria.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.bAuditoria.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.bAuditoria.Name = "bAuditoria";
            this.bAuditoria.Padding = new System.Windows.Forms.Padding(0);
            this.bAuditoria.Size = new System.Drawing.Size(103, 30);
            this.bAuditoria.Text = "Auditoría";
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.BackColor = System.Drawing.Color.White;
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(240, 28);
            this.toolStripMenuItem6.Text = "Reg Llegada Destino";
            this.toolStripMenuItem6.Click += new System.EventHandler(this.toolStripMenuItem6_Click);
            // 
            // bEstadisticas
            // 
            this.bEstadisticas.AutoSize = false;
            this.bEstadisticas.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.bEstadisticas.Font = new System.Drawing.Font("Calibri Light", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bEstadisticas.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.bEstadisticas.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.bEstadisticas.Name = "bEstadisticas";
            this.bEstadisticas.Padding = new System.Windows.Forms.Padding(0);
            this.bEstadisticas.Size = new System.Drawing.Size(103, 30);
            this.bEstadisticas.Text = "Estadisticas";
            this.bEstadisticas.Click += new System.EventHandler(this.bleh_Click);
            // 
            // panel
            // 
            this.panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel.BackColor = System.Drawing.Color.Gainsboro;
            this.panel.Location = new System.Drawing.Point(105, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(780, 570);
            this.panel.TabIndex = 4;
            // 
            // menuPanel
            // 
            this.menuPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.menuPanel.BackColor = System.Drawing.Color.DimGray;
            this.menuPanel.Controls.Add(this.menu);
            this.menuPanel.Location = new System.Drawing.Point(0, 0);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(132, 570);
            this.menuPanel.TabIndex = 5;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(885, 570);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.menuPanel);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Aerolineas Btrees";
            this.Load += new System.EventHandler(this.MasterForm_Load);
            this.Resize += new System.EventHandler(this.Main_Resize);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.menuPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.ToolStripMenuItem bCompras;
        protected System.Windows.Forms.ToolStripMenuItem bAdministracion;
        private System.Windows.Forms.ToolStripMenuItem aBMRolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aBMRutaToolStripMenuItem;
        protected System.Windows.Forms.ToolStripMenuItem bMillas;
        protected System.Windows.Forms.ToolStripMenuItem bDevolucion;
        private System.Windows.Forms.ToolStripMenuItem consultaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem canjeToolStripMenuItem;
        protected System.Windows.Forms.ToolStripMenuItem bHome;
        protected System.Windows.Forms.ToolStripMenuItem aBMAeronaveToolStripMenuItem;
        public System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Panel menuPanel;
        protected System.Windows.Forms.ToolStripMenuItem bAuditoria;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        protected System.Windows.Forms.ToolStripMenuItem bEstadisticas;
        private System.Windows.Forms.ToolStripMenuItem generarViajeToolStripMenuItem;
    }
}