using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace AerolineaFrba
{
    class TipoTarjeta
    {
        public static DataTable ListTipoTarjeta()
        {
            DataTable ds = new DataTable();
            string strSQL = "THE_BTREES.GetTiposTarjeta";
            SqlDataAdapter da = new SqlDataAdapter(strSQL, Conexion.strCon);
            da.Fill(ds);
            return ds;
        }

        public static bool cantCuotasIsOK(int tipoTarjetaID,int cantCuotas)
        {
            SqlConnection objConexion = new SqlConnection(Conexion.strCon);
            string strProc = "THE_BTREES.GetCantCuotas";
            SqlCommand comando = new SqlCommand(strProc, objConexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@TipoTarjetaID", tipoTarjetaID);
            SqlParameter cantCuotasParam = new SqlParameter("@CantCuotas", 0);
            cantCuotasParam.Direction = ParameterDirection.Output;
            comando.Parameters.Add(cantCuotasParam);
            objConexion.Open();
            comando.ExecuteNonQuery();
            int cantCuotasMax = Convert.ToInt32(comando.Parameters["@CantCuotas"].Value);
            objConexion.Close();
            objConexion.Dispose();
            if (cantCuotas <= cantCuotasMax) return true;
            else return false;
        }

    }
}
