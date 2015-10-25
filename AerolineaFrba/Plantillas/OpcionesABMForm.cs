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
    public partial class OpcionesABMForm : Form
    {
        public OpcionesABMForm()
        {
            InitializeComponent();
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            ListadoForm frmListado = this.nuevoListado();
            frmListado.StartPosition = FormStartPosition.CenterScreen;
            frmListado.Show();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AltaForm frmAlta = this.nuevoAlta();
            frmAlta.StartPosition = FormStartPosition.CenterScreen;
            frmAlta.Show();
        }

        protected virtual ListadoForm nuevoListado()
        {
            return new ListadoForm();
        }

        protected virtual AltaForm nuevoAlta()
        {
            return new AltaForm();
        }


    }
}
