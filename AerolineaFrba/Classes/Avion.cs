using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using AerolineaFrba.Abm_Aeronave;
using sql = System.Data.SqlClient;

namespace AerolineaFrba
{
    class Avion
    {
        public static DataTable TraerAvionesParaCompra()
        {
            DataTable ds = new DataTable();
            string strSQL = "THE_BTREES.GetAeronavesParaCompraList";
            SqlDataAdapter da = new SqlDataAdapter(strSQL, Conexion.strCon);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@Fecha",Config.dateTimeNow);
            da.Fill(ds);
            return ds;
        }

        internal static DataTable getWithServicioAndButacas(int AeronaveID)
        {
            DataTable dt = new DataTable();
            string strProc = "THE_BTREES.TraerAvionConServicioYButacas";

            using (var da = new sql.SqlDataAdapter(strProc, Conexion.strCon))
            {
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@AvionID", AeronaveID);
                da.Fill(dt);
            }

            return dt;
        }

        public static void darAlta(UctrlAeronave avionAttrs)
        {
            using (var conn = new SqlConnection(Conexion.strCon))
            using (var command = new SqlCommand("THE_BTREES.Crear_Avion", conn)
            {
                CommandType = CommandType.StoredProcedure
            })
            {
                command.Parameters.AddWithValue("@Avion_FechaDeAlta", avionAttrs.FechaAlta);
                command.Parameters.AddWithValue("@Avion_Modelo", avionAttrs.Modelo);
                command.Parameters.AddWithValue("@Avion_Matricula", avionAttrs.Matricula);
                command.Parameters.AddWithValue("@Avion_Fabricante", avionAttrs.Fabricante);
                command.Parameters.AddWithValue("@Avion_TipoDeServicioRef", avionAttrs.TipoDeServicio);
                command.Parameters.AddWithValue("@Avion_CantidadKgsDisponibles", avionAttrs.KgsEncomienda);
                command.Parameters.AddWithValue("@Butacas_Pasillo", avionAttrs.ButacasPasillo);
                command.Parameters.AddWithValue("@Butacas_Ventana", avionAttrs.ButacasVentana);

                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
            }
        }

        public static void darBajaLogica(UctrlAeronave avionAttrs)
        {
            using (var conn = new SqlConnection(Conexion.strCon))
            using (var command = new SqlCommand("THE_BTREES.DarDeBaja_Avion", conn)
            {
                CommandType = CommandType.StoredProcedure
            })
            {
                command.Parameters.AddWithValue("@AvionID", avionAttrs.AeronaveID);
                command.Parameters.AddWithValue("@Avion_FechaDeBajaDefinitiva", avionAttrs.FechaBaja);
                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
            }
        }

        public static void darModif(UctrlAeronave avionAttrs)
        {
            using (var conn = new SqlConnection(Conexion.strCon))
            using (var command = new SqlCommand("THE_BTREES.Modificar_Avion", conn)
            {
                CommandType = CommandType.StoredProcedure
            })
            {
                command.Parameters.AddWithValue("@AvionID", avionAttrs.AeronaveID);
                command.Parameters.AddWithValue("@Avion_FechaDeAlta", avionAttrs.FechaAlta);
                command.Parameters.AddWithValue("@Avion_Modelo", avionAttrs.Modelo);
                command.Parameters.AddWithValue("@Avion_Matricula", avionAttrs.Matricula);
                command.Parameters.AddWithValue("@Avion_Fabricante", avionAttrs.Fabricante);
                command.Parameters.AddWithValue("@Avion_TipoDeServicioRef", avionAttrs.TipoDeServicio);
                command.Parameters.AddWithValue("@Avion_CantidadKgsDisponibles", avionAttrs.KgsEncomienda);
                command.Parameters.AddWithValue("@Butacas_Pasillo", avionAttrs.ButacasPasillo);
                command.Parameters.AddWithValue("@Butacas_Ventana", avionAttrs.ButacasVentana);

                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
            }
        }

        public static DataTable TraerAvionesMatricula()
        {
            DataTable ds = new DataTable();
            string strSQL = "THE_BTREES.GetAvionesMatricula";
            SqlDataAdapter da = new SqlDataAdapter(strSQL, Conexion.strCon);
            da.Fill(ds);
            return ds;
        }


        public static DataTable getLastFueraDeServicio(int AeronaveID)
        {
            DataTable dt = new DataTable();
            string strProc = "THE_BTREES.TraerUltimoFueraDeServicioAvion";

            using (var da = new sql.SqlDataAdapter(strProc, Conexion.strCon))
            {
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@AvionID", AeronaveID);
                da.Fill(dt);
            }

            return dt;
        }

        public static void DarFueraServicio(UctrlAeronave avionAttrs)
        {
            using (var conn = new SqlConnection(Conexion.strCon))
            using (var command = new SqlCommand("THE_BTREES.DarFueraServicio_Avion", conn)
            {
                CommandType = CommandType.StoredProcedure
            })
            {
                command.Parameters.AddWithValue("@AvionID", avionAttrs.AeronaveID);
                command.Parameters.AddWithValue("@Avion_FechaFueraServicio", Config.dateTimeNow);
                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
            }
        }

        public static void DarReinicioServicio(UctrlAeronave avionAttrs)
        {
            using (var conn = new SqlConnection(Conexion.strCon))
            using (var command = new SqlCommand("THE_BTREES.DarReinicioServicio_Avion", conn)
            {
                CommandType = CommandType.StoredProcedure
            })
            {
                command.Parameters.AddWithValue("@AvionID", avionAttrs.AeronaveID);
                command.Parameters.AddWithValue("@Avion_FechaReinicioServicio", Config.dateTimeNow);
                command.Parameters.AddWithValue("@FueraDeServicioId", avionAttrs.FueraDeServicioId);

                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}
