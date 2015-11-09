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
using AerolineaFrba.Filtros;
using AerolineaFrba.Abm;

namespace AerolineaFrba.Abm_Aeronave
{
    public partial class ABMAeronave : OpcionesABMForm

    {
        public ABMAeronave()
        {
            InitializeComponent();
        }

        protected override FiltroControl filtroControl()
        {
            return new UctrlFiltrosAeronave();
        }

        protected override IAbmControl abmControl()
        {
            return new UctrlAeronave();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
