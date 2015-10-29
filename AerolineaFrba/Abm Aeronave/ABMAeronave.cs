using AerolineaFrba.Abm_Ruta;
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

namespace AerolineaFrba.Abm_Aeronave
{
    public partial class ABMAeronave : OpcionesABMForm

    {
        public ABMAeronave()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        protected override ListadoForm nuevoListado()
        {
            return new ListadoForm(new UctrlFiltrosRol());
        }

        protected override AltaForm nuevoAlta()
        {
            return new AltaAeronaveForm();
        }
    }
}
