using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace AerolineaFrba
{
    class Ciudad
    {
        public static DataTable TraerCiudadesCombo()
        {
            DataTable ds = new DataTable();
            string strSQL = "THE_BTREES.GetCiudades";
            SqlDataAdapter da = new SqlDataAdapter(strSQL, Conexion.strCon);
            da.Fill(ds);
            Utiles.agregarCampoDefaultADT(ds);
            return ds;
        }
    }

}
