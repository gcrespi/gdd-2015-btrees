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
        public static DataTable ListCiudades()
        {
            DataTable ds = new DataTable();
            string strSQL = "THE_BTREES.GetCiudades";
            SqlDataAdapter da = new SqlDataAdapter(strSQL, Conexion.strCon);
            da.Fill(ds);
            return ds;        
        }

        public static DataTable TraerCiudadesCombo()
        {
            DataTable ds = Ciudad.ListCiudades();
            Utiles.agregarCampoDefaultADT(ds);
            return ds;
        }
    }

}
