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
    public partial class ListadoRutasForm : Form
    {
        public ListadoRutasForm(UserControl sarasa)
        {
            InitializeComponent();
        }

        protected String nombreProcedure()
        {
            return "RutaAerea";
        }

    }
}
