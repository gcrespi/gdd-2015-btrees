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


namespace AerolineaFrba
{
    public partial class OpcionesABMForm : Form
    {
        public OpcionesABMForm()
        {
            InitializeComponent();
        }

        protected virtual ListadoForm nuevoListado()
        {
            return new ListadoForm();
        }

        protected virtual AltaForm nuevoAlta()
        {
            return new AltaForm();
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            this.crearListadoForm(TipoListado.Detalle);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            this.crearListadoForm(TipoListado.Modif);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            this.crearListadoForm(TipoListado.Baja);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AltaForm frmDetalle = this.nuevoAlta();
            frmDetalle.StartPosition = FormStartPosition.CenterScreen;
            frmDetalle.Show();
        }

        private void crearListadoForm(TipoListado tipoListado)
        {
            ListadoForm frmDetalle = this.nuevoListado();
            frmDetalle.setTipo(tipoListado);
            frmDetalle.StartPosition = FormStartPosition.CenterScreen;
            frmDetalle.Show();
        }

    }
}
