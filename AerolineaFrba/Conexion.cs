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
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        public static string strCon = ConfigurationManager.ConnectionStrings["ConexionSQL"].ConnectionString;

        public Conexion()
        {
            try
            {
                con = new SqlConnection(strCon);
                con.Open();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error con conexión con la base de Datos" + ex.ToString());
            }
        }

        public bool existsAnyThat(string sqlQuery)
        {
            bool any = false;

            try
            {
                cmd = new SqlCommand(sqlQuery, con);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    any = true;
                }
                dr.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error al tratar de realizar Query: " + ex.ToString());
            }

            return any;
        }

        
    }
}
