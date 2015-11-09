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

        protected virtual IAbmControl abmControl()
        { 
            return new UctrlRol();
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            this.crearListadoForm(new DetalleForm(this.abmControl()));
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            this.crearListadoForm(new ModifForm(this.abmControl()));
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            this.crearListadoForm(new BajaForm(this.abmControl()));
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AltaForm frmDetalle = new AltaForm(this.abmControl());
            frmDetalle.StartPosition = FormStartPosition.CenterScreen;
            frmDetalle.Show();
        }

        private void crearListadoForm(IBmdForm bmdForm)
        {
            
            Program.main.replaceForm(new ListadoForm(this.filtroControl(), bmdForm));
            
        }

    }
}
