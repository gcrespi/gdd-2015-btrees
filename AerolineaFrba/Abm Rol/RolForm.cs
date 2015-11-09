using AerolineaFrba.Abm;
using AerolineaFrba.Filtros;
using AerolineaFrba.Plantillas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba.Abm_Rol
{
    public partial class RolForm : OpcionesABMForm
    {
        public RolForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        protected override FiltroControl filtroControl()
        {
            return new UctrlFiltrosRol();
        }

        protected override IAbmControl abmControl()
        {
            return new UctrlRol();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

        }
    }
}
