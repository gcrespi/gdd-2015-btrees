using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sql = System.Data.SqlClient;


namespace AerolineaFrba
{
    class Funcionalidades
    {

        public static DataTable listFuncionalidades()
        {
            var _self = new DataTable();

            string strProc = "THE_BTREES.TraerData";

            using (var da = new sql.SqlDataAdapter(strProc, Conexion.strCon))
            {
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Tabla", "Funcionalidades");

                da.Fill(_self);
            }

            return _self;
        }


    }
}
