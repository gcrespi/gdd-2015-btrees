using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace AerolineaFrba
{
    class Pasaje : Compra
    {
 
        public int Id { get; set; }
        public int butacaRef { get; set; }
  
        public static DataTable TraerPasajesDeCompra(int idCompra)
        {
            DataTable dt = new DataTable();
            string strProc = "THE_BTREES.GetPasajesDeCompraList";

            using (var da = new SqlDataAdapter(strProc, Conexion.strCon))
            {
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@CompraID", idCompra);
                da.Fill(dt);
            }
            return dt;
        }

        public void CrearPasaje()
        {
            SqlConnection objConexion = new SqlConnection(Conexion.strCon);
            SqlTransaction tran = null;
            try
            {
                objConexion.Open();
                tran = objConexion.BeginTransaction();
                CrearCompra(objConexion);
                string strProc = "THE_BTREES.AddPasaje";
                SqlCommand comando = new SqlCommand(strProc, objConexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@butacaRef", butacaRef);
                comando.Parameters.AddWithValue("@precio", precio);
                comando.Parameters.AddWithValue("@compraRef", compraRef);
                comando.Parameters.AddWithValue("@clienteRef", clienteRef);
                comando.Parameters.AddWithValue("@viajeRef", viajeRef);
                comando.ExecuteNonQuery();
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
