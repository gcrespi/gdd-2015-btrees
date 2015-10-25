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
    public partial class AltaForm : Form
    {
        public AltaForm()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            btnLimpiar.PerformClick();
            this.Close();
        }

        protected virtual void btnLimpiar_Click(object sender, EventArgs e)
        {

        }

        protected virtual void btnGuardar_Click(object sender, EventArgs e)
        {

        }
    }
}
