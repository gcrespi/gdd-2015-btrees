using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba.Plantillas
{
    public partial class BajaForm : Form
    {
        public BajaForm()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected virtual void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void BajaForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            AutoValidate = AutoValidate.Disable;
        }
    }
}
