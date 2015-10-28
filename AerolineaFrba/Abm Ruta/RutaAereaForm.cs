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

        protected override ListadoForm nuevoListado()
        {
            return new ListadoRutasForm();
        }

        protected override AltaForm nuevoAlta()
        {
            return new AltaRutaForm();
        }
    }
}
