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
       
    }
}
