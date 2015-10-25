using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba
{
    public abstract partial class ExampleOpcionesABMForm : Form
    {
        public ExampleOpcionesABMForm()
        {
            InitializeComponent();
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            ListadoForm frmListadoRuta = this.nuevoListado();
            frmListadoRuta.StartPosition = FormStartPosition.CenterScreen;
            frmListadoRuta.Show();
        }

        protected abstract ListadoForm nuevoListado();

        protected abstract ExampleAltaForm nuevoAlta();
    }
}
