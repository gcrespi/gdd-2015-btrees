using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AerolineaFrba.Abm_Ruta;
using AerolineaFrba.Abm_Aeronave;

namespace AerolineaFrba
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            menu.Renderer = new MyRenderer();
        }

        private void MasterForm_Load(object sender, EventArgs e)
        {
            mostrarForm(new Home());
            setColor(bHome);
            menu.Parent = menuPanel;
            menuPanel.AutoScroll = true;
        }

        private class MyRenderer : ToolStripProfessionalRenderer
        {
            public MyRenderer() : base(new MyColors()) { }
        }

        private class MyColors : ProfessionalColorTable
        {
            public override Color MenuItemSelectedGradientBegin
            {
                get { return Color.DeepSkyBlue; }
            }
            public override Color MenuItemSelectedGradientEnd
            {
                get { return Color.DeepSkyBlue; }
            }
            public override Color MenuItemPressedGradientBegin
            {
                get { return Color.SkyBlue; }
            }
            public override Color MenuItemPressedGradientEnd
            {
                get { return Color.SkyBlue; }
            }

        }

        private void aBMRutaToolStripMenuItem_Click(object sender, EventArgs e)
        {
           mostrarForm(new RutaAereaForm());
           setColor(bAdministracion);
        }

        private void bHome_Click(object sender, EventArgs e)
        {
           mostrarForm(new Home());
           setColor(bHome);
        }

        private void aBMAeronaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
           mostrarForm(new ABMAeronave());
           setColor(bAdministracion);
        }


        // Para mostrar formularios
        private void mostrarForm(Form form)
        {
            if (this.panel.Controls.Count > 0)
                this.panel.Controls.RemoveAt(0);            
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            this.panel.Controls.Add(form);
            this.panel.Tag = form;
            form.Show();
        }

        // Para seteaer el color
        private void setColor(ToolStripMenuItem btn)
        {
            foreach (ToolStripItem item in menu.Items)
            {
                item.BackColor = SystemColors.MenuHighlight;
            }
            btn.BackColor = Color.SteelBlue;
        }

    }
}
