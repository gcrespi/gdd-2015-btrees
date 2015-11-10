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
using AerolineaFrba.Filtros;
using AerolineaFrba.Abm;

namespace AerolineaFrba.Abm_Ruta
{
    public partial class RutaAereaForm : OpcionesABMForm
    {
        public RutaAereaForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        protected override FiltroControl filtroControl()
        {
            return new UctrlFiltrosRuta();
        }

        public override IAbmControl abmControl()
        {
            return new UctrlRuta();
        }
    }
}
