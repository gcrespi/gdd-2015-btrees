using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace AerolineaFrba
{
    class TipoServicio
    {

        public static DataTable GetTiposDeServicio()
        {
            DataTable ds = new DataTable();
            string strSQL = "THE_BTREES.GetTipoServicios";
            SqlDataAdapter da = new SqlDataAdapter(strSQL, Conexion.strCon);
            da.Fill(ds);
            return ds;
        }

        public static DataTable TraerTiposDeServicioCombo() 
       {
           DataTable ds = TipoServicio.GetTiposDeServicio();
           Utiles.agregarCampoDefaultADT(ds);
           return ds;
       }
                 
    }
}
