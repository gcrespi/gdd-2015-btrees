using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


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

        public static void CrearViaje(DateTime fSal, DateTime fLle, DateTime fLleEst, int avionId, int rutaID)
        {
            SqlConnection objConexion = new SqlConnection(Conexion.strCon);
            try
            {
                string strProc = "THE_BTREES.AddViaje";
                SqlCommand comando = new SqlCommand(strProc, objConexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@FechaSalida", fSal);
                comando.Parameters.AddWithValue("@FechaLlegada", fLle);
                comando.Parameters.AddWithValue("@FechaLlegadaEst",fLleEst);
                comando.Parameters.AddWithValue("@Avion", avionId);
                comando.Parameters.AddWithValue("@RutaAerea", rutaID);
                objConexion.Open();
                comando.ExecuteNonQuery();
                objConexion.Close();
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
            }
        }
    }
}
