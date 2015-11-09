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
using AerolineaFrba.Registro_Llegada_Destino;
using AerolineaFrba.Canje_Millas;
using AerolineaFrba.Consulta_Millas;

namespace AerolineaFrba
{
    public partial class Main : Form
    {
        private List<string> botonesVisibles;

        public Main(List<string> botonesVisibles)
        {
            InitializeComponent();
            menu.Renderer = new MyRenderer();
            this.botonesVisibles = botonesVisibles;
        }

        private void MasterForm_Load(object sender, EventArgs e)
        {
            replaceForm(new Home());
            setColor(bHome);
            menu.Parent = menuPanel;
            menuPanel.AutoScroll = true;
            foreach (ToolStripMenuItem item in menu.Items)
            {
                item.Height = 70;
                if (!botonesVisibles.Contains(item.ToString()))
                    item.Visible = false;
                foreach (ToolStripItem subitem in item.DropDown.Items)
                {
                    if (!botonesVisibles.Contains(subitem.ToString()))
                        subitem.Visible = false;
                    else
                        item.Visible = true;
                }
            }
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
            setColor(bCompras);
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
            setColor(bAdministracion);
        }

        private void bleh_Click(object sender, EventArgs e)
        {
            replaceForm(new Estadisticas());
            setColor(bEstadisticas);
        }

        private void bDevolucion_Click(object sender, EventArgs e)
        {
            replaceForm(new DevolucionForm());
            setColor(bDevolucion);
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            replaceForm(new RegLlegadaADestinoForm());
            setColor(bAuditoria);
        }

        private void canjeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            replaceForm(new CanjeMillasForm());
            setColor(bMillas);
        }

        private void consultaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            replaceForm(new ConsultaMillasForm());
            setColor(bMillas);
        }
   
    }
}
