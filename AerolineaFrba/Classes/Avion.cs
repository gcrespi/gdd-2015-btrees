using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace AerolineaFrba
{
    class Avion
    {
        public static DataTable TraerAvionesParaCompra()
        {
            DataTable ds = new DataTable();
            string strSQL = "THE_BTREES.GetAeronavesParaCompraList";
            SqlDataAdapter da = new SqlDataAdapter(strSQL, Conexion.strCon);
            da.Fill(ds);
            return ds;
        }

        public static DataTable TraerAvionesMatricula()
        {
            DataTable ds = new DataTable();
            string strSQL = "THE_BTREES.GetAvionesMatricula";
            SqlDataAdapter da = new SqlDataAdapter(strSQL, Conexion.strCon);
            da.Fill(ds);
            return ds;
        }

    }
}
