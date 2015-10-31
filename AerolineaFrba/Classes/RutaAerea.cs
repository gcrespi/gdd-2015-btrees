using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using sql = System.Data.SqlClient;
using AerolineaFrba.Abm_Ruta;

namespace AerolineaFrba
{
    class RutaAerea
    {
        public static DataTable TraerRutasParaCompra()
        {
            DataTable ds = new DataTable();
            string strSQL = "THE_BTREES.GetRutasAereasParaCompraList";
            SqlDataAdapter da = new SqlDataAdapter(strSQL, Conexion.strCon);
            da.Fill(ds);
            return ds;
        }


        public static void darAlta(UctrlRuta rutaAttrs)
        {
            using (var conn = new SqlConnection(Conexion.strCon))
            using (var command = new SqlCommand("THE_BTREES.Crear_Ruta", conn)
            {
                CommandType = CommandType.StoredProcedure
            })
            {
                command.Parameters.AddWithValue("@Ruta_Codigo", rutaAttrs.CodigoRuta);
                command.Parameters.AddWithValue("@Ruta_CiudadOrigenRef", rutaAttrs.CiudadOrigenKey);
                command.Parameters.AddWithValue("@Ruta_CiudadDestinoRef", rutaAttrs.CiudadDestinoKey);
                command.Parameters.AddWithValue("@Ruta_PrecioBaseKg", rutaAttrs.PrecioBEnc);
                command.Parameters.AddWithValue("@Ruta_PrecioBasePasaje", rutaAttrs.PrecioBPas);
                command.Parameters.AddWithValue("@Ruta_Activo", rutaAttrs.Activo);
                
                command.Parameters.Add(TiposDeServicioParametro(rutaAttrs));
                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
            }
        }

        public static void darBajaLogica(UctrlRuta rolAttrs)
        {
            using (var conn = new SqlConnection(Conexion.strCon))
            using (var command = new SqlCommand("THE_BTREES.Deshabilitar_Ruta", conn)
            {
                CommandType = CommandType.StoredProcedure
            })
            {
                command.Parameters.AddWithValue("@RutaAereaID ", rolAttrs.RutaID);
                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
            }
        }

        private static SqlParameter TiposDeServicioParametro(UctrlRuta rutaAttrs)
        {
            DataTable tiposServicioCheckeados = rutaAttrs.ServiciosCheckeados;
            var pList = new SqlParameter("@ServiciosSeleccionados", SqlDbType.Structured);
            pList.TypeName = "THE_BTREES.IntList";
            pList.Value = tiposServicioCheckeados;
            return pList;
        }

        public static void darModif(UctrlRuta rutaAttrs)
        {
            using (var conn = new SqlConnection(Conexion.strCon))
            using (var command = new SqlCommand("THE_BTREES.Modificar_Ruta", conn)
            {
                CommandType = CommandType.StoredProcedure
            })
            {
                command.Parameters.AddWithValue("@RutaAereaID ", rutaAttrs.RutaID);
                command.Parameters.AddWithValue("@Ruta_Codigo", rutaAttrs.CodigoRuta);
                command.Parameters.AddWithValue("@Ruta_CiudadOrigenRef", rutaAttrs.CiudadOrigenKey);
                command.Parameters.AddWithValue("@Ruta_CiudadDestinoRef", rutaAttrs.CiudadDestinoKey);
                command.Parameters.AddWithValue("@Ruta_PrecioBaseKg", rutaAttrs.PrecioBEnc);
                command.Parameters.AddWithValue("@Ruta_PrecioBasePasaje", rutaAttrs.PrecioBPas);
                command.Parameters.AddWithValue("@Ruta_Activo", rutaAttrs.Activo);

                command.Parameters.Add(TiposDeServicioParametro(rutaAttrs));
                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
            }
        }

        public static DataTable getWithServicios(int rutaID)
        {
            DataTable dt = new DataTable();
            string strProc = "THE_BTREES.TraerRutaConServicios";

            using (var da = new sql.SqlDataAdapter(strProc, Conexion.strCon))
            {
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@RutaID", rutaID);
                da.Fill(dt);
            }

            return dt;
        }

    }
}
