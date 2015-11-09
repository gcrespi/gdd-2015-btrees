using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace AerolineaFrba
{
    class Encomienda : Compra
    {
        public static int TraerEncomiendaKGDeCompra(int idCompra)
        {
            SqlConnection objConexion = new SqlConnection(Conexion.strCon);
            string strProc = "THE_BTREES.GetEncomiendaKGCompra";
            SqlCommand comando = new SqlCommand(strProc, objConexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@CompraID", idCompra);
            comando.Parameters.AddWithValue("@Fecha", Config.dateTimeNow);
            SqlParameter cantkg = new SqlParameter("@CantKg", 0);
            cantkg.Direction = ParameterDirection.Output;
            comando.Parameters.Add(cantkg);
            objConexion.Open();
            comando.ExecuteNonQuery();
            int nro = Convert.ToInt16(comando.Parameters["@CantKg"].Value);
            objConexion.Close();
            objConexion.Dispose();
            return  nro;
        }
    }
}
