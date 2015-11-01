using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace AerolineaFrba
{
    class Butaca
    {

        public static DataTable GetButacasDisponiblesCombo(int viajeRef) 
       {
           DataTable ds = new DataTable();
           string strSQL = "THE_BTREES.GetButacasDisponiblesViajeList";
           SqlDataAdapter da = new SqlDataAdapter(strSQL, Conexion.strCon);
           da.SelectCommand.CommandType = CommandType.StoredProcedure;
           da.SelectCommand.Parameters.AddWithValue("@Viaje", viajeRef); 
           da.Fill(ds);
           return ds;
       }
                 
    }
}
