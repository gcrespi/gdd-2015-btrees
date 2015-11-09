using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace AerolineaFrba
{
    class Canje
    {
        public int prodId { get; set; }
        public int prodCantidad { get; set; }
        public int prodMillas { get; set; }

        public static void TraerMillasDisponible(ref int millasDisp, ref int idUsuario,string ape, string dni)
        {
            SqlConnection objConexion = new SqlConnection(Conexion.strCon);
            string strProc = "THE_BTREES.GetCantMillasDisponibles";
            SqlCommand comando = new SqlCommand(strProc, objConexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Apellido", ape);
            comando.Parameters.AddWithValue("@DNI", dni);
            comando.Parameters.AddWithValue("@Fecha", Config.dateTimeNow);
            SqlParameter idCli = new SqlParameter("@ClienteRef", 0);
            idCli.Direction = ParameterDirection.Output;
            comando.Parameters.Add(idCli);
            SqlParameter cantMil = new SqlParameter("@CantMillasDisponibles", 0);
            cantMil.Direction = ParameterDirection.Output;
            comando.Parameters.Add(cantMil);
            objConexion.Open();
            comando.ExecuteNonQuery();
            idUsuario= Convert.ToInt32(comando.Parameters["@ClienteRef"].Value);
            millasDisp = Convert.ToInt32(comando.Parameters["@CantMillasDisponibles"].Value);
            objConexion.Close();
            objConexion.Dispose();
          }

        public static DataTable ListProductosDisponibles(int cantMillas)
        {
            DataTable ds = new DataTable();
            string strSQL = "THE_BTREES.GetProductosDisponibles";
            SqlDataAdapter da = new SqlDataAdapter(strSQL, Conexion.strCon);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@CantMillas", cantMillas);
            da.Fill(ds);
            return ds;
        }

        public static void RegistrarCanjes(List<Canje> lCanje, int idUsuario)
        {
            SqlConnection objConexion = new SqlConnection(Conexion.strCon);
            SqlTransaction tran = null;
            try
            {
                objConexion.Open();
                tran = objConexion.BeginTransaction();
                string strP = "THE_BTREES.AddCanjeProducto";
                foreach (Canje itm in lCanje)
                {
                    SqlCommand coman = new SqlCommand(strP, objConexion);
                    coman.Transaction = tran;
                    coman.CommandType = CommandType.StoredProcedure;
                    coman.Parameters.AddWithValue("@ClienteID", idUsuario);
                    coman.Parameters.AddWithValue("@ProductoID", itm.prodId);
                    coman.Parameters.AddWithValue("@CantProducto", itm.prodCantidad);
                    coman.Parameters.AddWithValue("@MillasCanje", itm.prodCantidad*itm.prodMillas);
                    coman.Parameters.AddWithValue("@Fecha", Config.dateTimeNow);
                    coman.ExecuteNonQuery();
                }
                tran.Commit();
            }

            catch (Exception)
            {
                tran.Rollback();
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
    }
}
