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

namespace AerolineaFrba.Abm_Ruta
{
    public partial class ListadoRutasForm : AerolineaFrba.ListadoForm
    {
        public ListadoRutasForm()
        {
            InitializeComponent();
        }

        protected override String nombreTabla()
        {
            return "RutaAerea";
        }

        private void listadoRutasForm_Load(object sender, EventArgs e)
        { 
        
        }
    }
}
