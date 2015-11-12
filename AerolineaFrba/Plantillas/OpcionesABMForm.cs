using AerolineaFrba.Plantillas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AerolineaFrba;
using AerolineaFrba.Abm_Rol;
using AerolineaFrba.Abm;
using AerolineaFrba.Filtros;


namespace AerolineaFrba
{
    public partial class OpcionesABMForm : Form
    {
        public OpcionesABMForm()
        {
            InitializeComponent();
        }

        protected virtual FiltroControl filtroControl()
        {
            return new UctrlFiltrosRol();
        }

        public virtual IAbmControl abmControl()
        { 
            return new UctrlRol();
        }


        protected void crearListadoForm(AbstractBMDFactory bmdFactory)
        {
            var frmListado = new ListadoForm(this.filtroControl(), bmdFactory);
            Program.main.addForm(frmListado);
            frmListado.buscar();
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            this.crearListadoForm(new DetalleFactory(this));
        }

        private void btnAgr_Click(object sender, EventArgs e)
        {
            AltaForm frmAlta = new AltaForm(this.abmControl());
            Program.main.addForm(frmAlta);
        }

        private void btnModi_Click(object sender, EventArgs e)
        {
            this.crearListadoForm(new ModifFactory(this));
        }

        private void btnElim_Click(object sender, EventArgs e)
        {
            this.crearListadoForm(new BajaFactory(this));
        }

    }
}
