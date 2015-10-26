using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace AerolineaFrba
{
    class Estadistica
    {
        public static DataTable TraerEstadistica(int opcion, int semestre, int año)
        {
            DataTable ds = new DataTable();
            string strSQL = "THE_BTREES.GetEstadisticaSelecionada";
            SqlDataAdapter da = new SqlDataAdapter(strSQL, Conexion.strCon);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@Opcion", opcion);
            da.SelectCommand.Parameters.AddWithValue("@Semestre", semestre);
            da.SelectCommand.Parameters.AddWithValue("@Año", año);
            da.Fill(ds);
            return ds;
        }


    }
}
