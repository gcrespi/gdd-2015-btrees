using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace AerolineaFrba
{
    class Cancelacion
    {

        public static void AddNuevaCancelacion(string motivo,int idCompra,List<int> listaPedidosCancelados,bool cancelEco)
         {
            SqlConnection objConexion = new SqlConnection(Conexion.strCon);
            SqlTransaction tran = null;
            try
            {
                 string strProc = "THE_BTREES.AddCancelacion";
                 SqlCommand comando = new SqlCommand(strProc, objConexion);
                 comando.CommandType = CommandType.StoredProcedure;
                 comando.Parameters.AddWithValue("@CompraID", idCompra);
                 comando.Parameters.AddWithValue("@Motivo", motivo);
                 comando.Parameters.AddWithValue("@CancelEco", cancelEco);
                 comando.Parameters.AddWithValue("@Fecha", DateTime.Today);
                 SqlParameter idCanPar = new SqlParameter("@CancelID", 0);
                 idCanPar.Direction = ParameterDirection.Output;
                 comando.Parameters.Add(idCanPar);
                 objConexion.Open();
                 tran =objConexion.BeginTransaction();
                 comando.Transaction = tran;
                 comando.ExecuteNonQuery();
                 int idCancel = Convert.ToInt32(idCanPar.Value);

                 if (listaPedidosCancelados.Count > 0)
                 {
                     string strP = "THE_BTREES.CancelarPasaje";
                     foreach (int pedido in listaPedidosCancelados)
                     {
                         
                         SqlCommand coman = new SqlCommand(strP, objConexion);
                         coman.Transaction = tran;
                         coman.CommandType = CommandType.StoredProcedure;
                         coman.Parameters.AddWithValue("@CancelID", idCancel);
                         coman.Parameters.AddWithValue("@PasajeID", pedido);
                         coman.ExecuteNonQuery();           
                     }
                 }
                 

                 tran.Commit();
                //abrir transaccion e ir mandando pedido por pedido, que este de arriba me devuelva el id de compra
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


            
