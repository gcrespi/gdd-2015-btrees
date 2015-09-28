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

        private void listadoRutasForm_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string strProc = "TraerData";
            sql.SqlDataAdapter da = new sql.SqlDataAdapter(strProc, Conexion.strCon);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@Tabla", "RutaAerea");
            da.Fill(dt);
            DataGrid.DataSource = dt;
        }

       

    }
}
