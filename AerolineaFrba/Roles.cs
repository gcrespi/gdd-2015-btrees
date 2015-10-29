using AerolineaFrba.Abm_Rol;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sql = System.Data.SqlClient;

namespace AerolineaFrba
{
    class Roles
    {

        public static DataTable getWithFunc(int rolID)
        {
            DataTable dt = new DataTable();
            string strProc = "THE_BTREES.TraerRolConFuncionalidades";

            using (var da = new sql.SqlDataAdapter(strProc, Conexion.strCon))
            {
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@RolID", rolID);
                da.Fill(dt);
            }

            return dt;
        }

        public static bool allreadyExistWithOtherID(UctrlRol rolAttrs)
        {
            bool _self;

            using (var conn = new SqlConnection(Conexion.strCon))
            using (var command = new SqlCommand("THE_BTREES.ExistsNameWithOtherID", conn))  
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@RolID", rolAttrs.RolID);
                command.Parameters.AddWithValue("@Nombre", rolAttrs.Nombre);
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

        public static void darAlta(UctrlRol rolAttrs)
        {
            using (var conn = new SqlConnection(Conexion.strCon))
            using (var command = new SqlCommand("THE_BTREES.Crear_Rol", conn)
            {
                CommandType = CommandType.StoredProcedure
            })
            {
                command.Parameters.AddWithValue("@Rol_Nombre", rolAttrs.Nombre);
                command.Parameters.Add(funcionalidadesParametro(rolAttrs));
                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
            }
        }

        public static void darBajaLogica(UctrlRol rolAttrs)
        {
            using (var conn = new SqlConnection(Conexion.strCon))
            using (var command = new SqlCommand("THE_BTREES.Deshabilitar_Rol", conn)
            {
                CommandType = CommandType.StoredProcedure
            })
            {
                command.Parameters.AddWithValue("@RolID", rolAttrs.RolID);
                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
            }
        }

        private static SqlParameter funcionalidadesParametro(UctrlRol rolAttrs)
        {
            DataTable funcionalidadesCheckeadas = rolAttrs.FuncionalidadesCheckeadas;
            var pList = new SqlParameter("@funcionalidadesSeleccionadas", SqlDbType.Structured);
            pList.TypeName = "THE_BTREES.IntList";
            pList.Value = funcionalidadesCheckeadas;
            return pList;
        }

        public static void darModif(UctrlRol rolAttrs)
        {
            using (var conn = new SqlConnection(Conexion.strCon))
            using (var command = new SqlCommand("THE_BTREES.Modificar_Rol", conn)
            {
                CommandType = CommandType.StoredProcedure
            })
            {
                command.Parameters.AddWithValue("@RolID", rolAttrs.RolID);
                command.Parameters.AddWithValue("@Rol_Nombre", rolAttrs.Nombre);
                command.Parameters.Add(funcionalidadesParametro(rolAttrs));
                command.Parameters.AddWithValue("@Rol_Activo", rolAttrs.Activo);
                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}
