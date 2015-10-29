using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AerolineaFrba.Plantillas;
using AerolineaFrba.Abm_Rol;

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
        }

        protected override AltaForm nuevoAlta()
        {
            return new AltaRutaForm();
        }
    }
}
