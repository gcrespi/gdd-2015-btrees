using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace AerolineaFrba
{
    class Pasaje
    {
 
        public int Id { get; set; }
  
        public static DataTable TraerPasajesDeCompra(int idCompra)
        {
            DataTable dt = new DataTable();
            string strProc = "THE_BTREES.GetPasajesDeCompraList";

            using (var da = new SqlDataAdapter(strProc, Conexion.strCon))
            {
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@CompraID", idCompra);
                da.Fill(dt);
            }
            return dt;
        }
    }
}
