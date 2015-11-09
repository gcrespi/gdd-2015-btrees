using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AerolineaFrba
{
    class Config
    {
        public static string strCon = ConfigurationManager.ConnectionStrings["ConexionSQL"].ConnectionString;
        public static DateTime dateTimeNow = DateTime.Parse(ConfigurationManager.AppSettings["DateTimeMock"]);
        public static String terminal = ConfigurationManager.AppSettings["Terminal"];
    }
}
