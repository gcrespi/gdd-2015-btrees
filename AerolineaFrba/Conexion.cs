using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace AerolineaFrba
{
    class Conexion
    {
        public static string strCon = ConfigurationManager.ConnectionStrings["ConexionSQL"].ConnectionString;

        public static bool callBooleanFunctionWithParameters(Dictionary<String, Object> parameters, String functionName)
        {
            bool _self;

            using (var conn = new SqlConnection(Conexion.strCon))
            using (var command = new SqlCommand("THE_BTREES." + functionName, conn))
            {
                command.CommandType = CommandType.StoredProcedure;

                foreach (KeyValuePair<String, Object> param in parameters)
                {
                    command.Parameters.AddWithValue(param.Key, param.Value);
                }
                SqlParameter returnValue = new SqlParameter("@Result", SqlDbType.Bit);
                returnValue.Direction = ParameterDirection.ReturnValue;
                command.Parameters.Add(returnValue);

                conn.Open();
                command.ExecuteNonQuery();
                _self = (bool)returnValue.Value;
                conn.Close();
            }
            return _self;
        }
    }
}
