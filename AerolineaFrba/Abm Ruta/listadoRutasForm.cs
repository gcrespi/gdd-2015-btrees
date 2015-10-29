using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using sql = System.Data.SqlClient;
using AerolineaFrba.Plantillas;

namespace AerolineaFrba.Abm_Ruta
{
    public partial class ListadoRutasForm : ListadoForm
    {
        public ListadoRutasForm()
        {
            InitializeComponent();
        }

        protected override String nombreProcedure()
        {
            return "RutaAerea";
        }

    }
}
