using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;


namespace AerolineaFrba
{
    class Viaje
    {
        public static DataTable TraerViajesDisponibles(byte tipoSer, DateTime fecha, Int16 ciudadDestino, Int16 ciudadOrigen)
        {
            DataTable dt = new DataTable();
            string strProc = "THE_BTREES.GetViajesDisponiblesList";

            using (var da = new SqlDataAdapter(strProc, Conexion.strCon))
            {
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@TipoServicio",tipoSer);
                da.SelectCommand.Parameters.AddWithValue("@Fecha", fecha);
                da.SelectCommand.Parameters.AddWithValue("@CiudadDestino", ciudadDestino);
                da.SelectCommand.Parameters.AddWithValue("@CiudadOrigen", ciudadOrigen);
                da.Fill(dt);                         
            }
            return dt;
        }

        public static void CrearViaje(DateTime fSal,DateTime fLleEst, int avionId, int rutaID)
        {
            SqlConnection objConexion = new SqlConnection(Conexion.strCon);
            try
            {
                string strProc = "THE_BTREES.AddViaje";
                SqlCommand comando = new SqlCommand(strProc, objConexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@FechaSalida", fSal);
                comando.Parameters.AddWithValue("@FechaLlegadaEst",fLleEst);
                comando.Parameters.AddWithValue("@Avion", avionId);
                comando.Parameters.AddWithValue("@RutaAerea", rutaID);
                objConexion.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new Exception();
            }
            finally
            {
                if (objConexion.State == System.Data.ConnectionState.Open)
                {
                    objConexion.Close();
                }
                objConexion.Dispose();
            }
        }

        public static string RegistrarLlegada(int avionID, Int16 ciudadDestino, Int16 ciudadOrigen, DateTime fLle)
        {
            SqlConnection objConexion = new SqlConnection(Conexion.strCon);
            try
            {
                string strProc = "THE_BTREES.RegistrarLlegadaViaje";
                SqlCommand comando = new SqlCommand(strProc, objConexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@AvionID", avionID);
                comando.Parameters.AddWithValue("@CiudadOrigen", ciudadOrigen);
                comando.Parameters.AddWithValue("@CiudadDestino", ciudadDestino);
                comando.Parameters.AddWithValue("@FechaLlegada", fLle);
                SqlParameter param = new SqlParameter("@Resultado", SqlDbType.VarChar, 100);
                param.Direction = ParameterDirection.Output;
                comando.Parameters.Add(param);
                objConexion.Open();
                comando.ExecuteReader();
                return Convert.ToString(param.Value);
            }
            catch (Exception ex)
            {
                return "Excepcion técnica: " + ex.Message;
            }
            finally
            {
                if (objConexion.State == System.Data.ConnectionState.Open)
                {
                    objConexion.Close();
                }
                objConexion.Dispose();
            }
        }

    }
}
