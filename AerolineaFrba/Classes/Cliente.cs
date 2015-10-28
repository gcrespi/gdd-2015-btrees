using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AerolineaFrba
{
    class Cliente
    {
        public static DataTable TraerDatosCliente(string nombre,string apellido, int dni)
        {
            DataTable ds = new DataTable();
            string strSQL = "THE_BTREES.GetDatosCliente";
            SqlDataAdapter da = new SqlDataAdapter(strSQL, Conexion.strCon);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@nombre", nombre);
            da.SelectCommand.Parameters.AddWithValue("@apellido", apellido);
            da.SelectCommand.Parameters.AddWithValue("@dni", dni);
            da.Fill(ds);
            return ds;
        }
    }
}
