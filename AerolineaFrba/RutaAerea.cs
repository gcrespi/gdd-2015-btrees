using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace AerolineaFrba
{
    class RutaAerea
    {
        public static DataTable TraerRutasParaCompra()
        {
            DataTable ds = new DataTable();
            string strSQL = "THE_BTREES.GetRutasAereasParaCompraList";
            SqlDataAdapter da = new SqlDataAdapter(strSQL, Conexion.strCon);
            da.Fill(ds);
            return ds;
        }
    }
}
