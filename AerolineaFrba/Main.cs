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
using AerolineaFrba.Abm_Rol;
using AerolineaFrba.Compras;
using AerolineaFrba.Generacion_Viaje;
using AerolineaFrba.Listado_Estadistico;
using AerolineaFrba.Devolucion;

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
            replaceForm(new Home());
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
           replaceForm(new RutaAereaForm());
           setColor(bAdministracion);
        }

        private void bHome_Click(object sender, EventArgs e)
        {
           replaceForm(new Home());
           setColor(bHome);
        }

        private void bCompras_Click(object sender, EventArgs e)
        {
            replaceForm(new CompraFormPickViaje());
        }
        private void aBMAeronaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
           replaceForm(new ABMAeronave());
           setColor(bAdministracion);
        }


        // Para agregar formularios
        public void addForm(Form form)
        {
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            this.panel.Controls.Add(form);
            this.panel.Tag = form;
            form.BringToFront();
            form.Show();
        }

        // Para reemplazar formularios
        public void replaceForm(Form form)
        {
            if (this.panel.Controls.Count > 0) 
                this.panel.Controls.Clear();
            addForm(form);
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


        private void aBMRolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            replaceForm(new RolForm());
            setColor(bAdministracion);
        
        }

        private void generarViajeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            replaceForm(new GenerarViajeForm());
        }

        private void bleh_Click(object sender, EventArgs e)
        {
            replaceForm(new Estadisticas());
        }

        private void bDevolucion_Click(object sender, EventArgs e)
        {
            replaceForm(new DevolucionForm());
        }
   
   

    }
}
