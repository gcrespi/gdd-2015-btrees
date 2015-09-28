using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba.Abm_Ruta
{
    public partial class RutaAereaForm : AerolineaFrba.OpcionesABMForm
    {
        public RutaAereaForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ListadoRutasForm frmListadoRuta = new ListadoRutasForm();
            frmListadoRuta.StartPosition = FormStartPosition.CenterScreen;
            frmListadoRuta.Show();
        }

        
    }
}
