﻿namespace AerolineaFrba
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
            this.aBMCiudadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMRolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMRutaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generarViajeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bCompras = new System.Windows.Forms.ToolStripMenuItem();
            this.bMillas = new System.Windows.Forms.ToolStripMenuItem();
            this.consultaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.canjeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bDevolucion = new System.Windows.Forms.ToolStripMenuItem();
            this.bAuditoria = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.Estadisticas = new System.Windows.Forms.ToolStripMenuItem();
            this.blih = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.bloh = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem14 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem15 = new System.Windows.Forms.ToolStripMenuItem();
            this.bluh = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem11 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem12 = new System.Windows.Forms.ToolStripMenuItem();
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
            this.Estadisticas,
            this.blih,
            this.bloh,
            this.bluh});
            this.menu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Padding = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.menu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menu.Size = new System.Drawing.Size(100, 890);
            this.menu.TabIndex = 2;
            this.menu.Text = "menu";
            this.menu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menu_ItemClicked);
            // 
            // bHome
            // 
            this.bHome.AutoSize = false;
            this.bHome.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.bHome.Font = new System.Drawing.Font("Calibri Light", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bHome.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.bHome.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.bHome.Name = "bHome";
            this.bHome.Padding = new System.Windows.Forms.Padding(0);
            this.bHome.Size = new System.Drawing.Size(98, 30);
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
            this.aBMCiudadToolStripMenuItem,
            this.aBMRolToolStripMenuItem,
            this.aBMRutaToolStripMenuItem,
            this.generarViajeToolStripMenuItem});
            this.bAdministracion.Font = new System.Drawing.Font("Calibri Light", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bAdministracion.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.bAdministracion.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.bAdministracion.Name = "bAdministracion";
            this.bAdministracion.Padding = new System.Windows.Forms.Padding(0);
            this.bAdministracion.Size = new System.Drawing.Size(98, 30);
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
            this.aBMRolToolStripMenuItem.Click += new System.EventHandler(this.aBMRolToolStripMenuItem_Click);
            // 
            // aBMRutaToolStripMenuItem
            // 
            this.aBMRutaToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.aBMRutaToolStripMenuItem.Name = "aBMRutaToolStripMenuItem";
            this.aBMRutaToolStripMenuItem.Size = new System.Drawing.Size(200, 28);
            this.aBMRutaToolStripMenuItem.Text = "ABM Ruta";
            this.aBMRutaToolStripMenuItem.Click += new System.EventHandler(this.aBMRutaToolStripMenuItem_Click);
            // 
            // generarViajeToolStripMenuItem
            // 
            this.generarViajeToolStripMenuItem.Name = "generarViajeToolStripMenuItem";
            this.generarViajeToolStripMenuItem.Size = new System.Drawing.Size(200, 28);
            this.generarViajeToolStripMenuItem.Text = "Generar Viaje";
            this.generarViajeToolStripMenuItem.Click += new System.EventHandler(this.generarViajeToolStripMenuItem_Click);
            // 
            // bCompras
            // 
            this.bCompras.AutoSize = false;
            this.bCompras.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.bCompras.Font = new System.Drawing.Font("Calibri Light", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bCompras.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.bCompras.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.bCompras.Name = "bCompras";
            this.bCompras.Padding = new System.Windows.Forms.Padding(0);
            this.bCompras.Size = new System.Drawing.Size(98, 30);
            this.bCompras.Text = "Compras";
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
            this.bMillas.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.bMillas.Name = "bMillas";
            this.bMillas.Padding = new System.Windows.Forms.Padding(0);
            this.bMillas.Size = new System.Drawing.Size(98, 30);
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
            this.canjeToolStripMenuItem.Click += new System.EventHandler(this.canjeToolStripMenuItem_Click);
            // 
            // bDevolucion
            // 
            this.bDevolucion.AutoSize = false;
            this.bDevolucion.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.bDevolucion.Font = new System.Drawing.Font("Calibri Light", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bDevolucion.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.bDevolucion.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.bDevolucion.Name = "bDevolucion";
            this.bDevolucion.Padding = new System.Windows.Forms.Padding(0);
            this.bDevolucion.Size = new System.Drawing.Size(98, 30);
            this.bDevolucion.Text = "Devolución";
            this.bDevolucion.Click += new System.EventHandler(this.bDevolucion_Click);
            // 
            // bAuditoria
            // 
            this.bAuditoria.AutoSize = false;
            this.bAuditoria.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.bAuditoria.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem5,
            this.toolStripMenuItem6});
            this.bAuditoria.Font = new System.Drawing.Font("Calibri Light", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bAuditoria.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.bAuditoria.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.bAuditoria.Name = "bAuditoria";
            this.bAuditoria.Padding = new System.Windows.Forms.Padding(0);
            this.bAuditoria.Size = new System.Drawing.Size(98, 30);
            this.bAuditoria.Text = "Auditoría";
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.BackColor = System.Drawing.Color.White;
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(244, 28);
            this.toolStripMenuItem5.Text = "Reg Usuarios";
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.BackColor = System.Drawing.Color.White;
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(244, 28);
            this.toolStripMenuItem6.Text = "Reg LLegada Destino";
            this.toolStripMenuItem6.Click += new System.EventHandler(this.toolStripMenuItem6_Click);
            // 
            // Estadisticas
            // 
            this.Estadisticas.AutoSize = false;
            this.Estadisticas.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.Estadisticas.Font = new System.Drawing.Font("Calibri Light", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Estadisticas.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Estadisticas.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.Estadisticas.Name = "Estadisticas";
            this.Estadisticas.Padding = new System.Windows.Forms.Padding(0);
            this.Estadisticas.Size = new System.Drawing.Size(98, 30);
            this.Estadisticas.Text = "Estadisticas";
            this.Estadisticas.Click += new System.EventHandler(this.bleh_Click);
            // 
            // blih
            // 
            this.blih.AutoSize = false;
            this.blih.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.blih.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3});
            this.blih.Font = new System.Drawing.Font("Calibri Light", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.blih.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.blih.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.blih.Name = "blih";
            this.blih.Padding = new System.Windows.Forms.Padding(0);
            this.blih.Size = new System.Drawing.Size(98, 30);
            this.blih.Text = "Blih";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.BackColor = System.Drawing.Color.White;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(244, 28);
            this.toolStripMenuItem2.Text = "Reg Usuarios";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.BackColor = System.Drawing.Color.White;
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(244, 28);
            this.toolStripMenuItem3.Text = "Reg LLegada Destino";
            // 
            // bloh
            // 
            this.bloh.AutoSize = false;
            this.bloh.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.bloh.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem14,
            this.toolStripMenuItem15});
            this.bloh.Font = new System.Drawing.Font("Calibri Light", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bloh.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.bloh.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.bloh.Name = "bloh";
            this.bloh.Padding = new System.Windows.Forms.Padding(0);
            this.bloh.Size = new System.Drawing.Size(98, 30);
            this.bloh.Text = "Bloh";
            // 
            // toolStripMenuItem14
            // 
            this.toolStripMenuItem14.BackColor = System.Drawing.Color.White;
            this.toolStripMenuItem14.Name = "toolStripMenuItem14";
            this.toolStripMenuItem14.Size = new System.Drawing.Size(244, 28);
            this.toolStripMenuItem14.Text = "Reg Usuarios";
            // 
            // toolStripMenuItem15
            // 
            this.toolStripMenuItem15.BackColor = System.Drawing.Color.White;
            this.toolStripMenuItem15.Name = "toolStripMenuItem15";
            this.toolStripMenuItem15.Size = new System.Drawing.Size(244, 28);
            this.toolStripMenuItem15.Text = "Reg LLegada Destino";
            // 
            // bluh
            // 
            this.bluh.AutoSize = false;
            this.bluh.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.bluh.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem11,
            this.toolStripMenuItem12});
            this.bluh.Font = new System.Drawing.Font("Calibri Light", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bluh.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.bluh.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.bluh.Name = "bluh";
            this.bluh.Padding = new System.Windows.Forms.Padding(0);
            this.bluh.Size = new System.Drawing.Size(98, 30);
            this.bluh.Text = "Bluh";
            // 
            // toolStripMenuItem11
            // 
            this.toolStripMenuItem11.BackColor = System.Drawing.Color.White;
            this.toolStripMenuItem11.Name = "toolStripMenuItem11";
            this.toolStripMenuItem11.Size = new System.Drawing.Size(244, 28);
            this.toolStripMenuItem11.Text = "Reg Usuarios";
            // 
            // toolStripMenuItem12
            // 
            this.toolStripMenuItem12.BackColor = System.Drawing.Color.White;
            this.toolStripMenuItem12.Name = "toolStripMenuItem12";
            this.toolStripMenuItem12.Size = new System.Drawing.Size(244, 28);
            this.toolStripMenuItem12.Text = "Reg LLegada Destino";
            // 
            // panel
            // 
            this.panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel.BackColor = System.Drawing.Color.Gainsboro;
            this.panel.Location = new System.Drawing.Point(100, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(785, 570);
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
            this.menuPanel.Size = new System.Drawing.Size(117, 570);
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
        protected System.Windows.Forms.ToolStripMenuItem aBMCiudadToolStripMenuItem;
        public System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Panel menuPanel;
        protected System.Windows.Forms.ToolStripMenuItem bAuditoria;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        protected System.Windows.Forms.ToolStripMenuItem Estadisticas;
        protected System.Windows.Forms.ToolStripMenuItem bloh;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem15;
        protected System.Windows.Forms.ToolStripMenuItem bluh;
        protected System.Windows.Forms.ToolStripMenuItem blih;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem14;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem11;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem12;
        private System.Windows.Forms.ToolStripMenuItem generarViajeToolStripMenuItem;
    }
}