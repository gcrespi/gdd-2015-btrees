using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace AerolineaFrba
{
    class Encomienda : Compra
    {
        public int kg { get; set; }

        public static int TraerEncomiendaKGDeCompra(int idCompra)
        {
            SqlConnection objConexion = new SqlConnection(Conexion.strCon);
            string strProc = "THE_BTREES.GetEncomiendaKGCompra";
            SqlCommand comando = new SqlCommand(strProc, objConexion);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@CompraID", idCompra);
            SqlParameter cantkg = new SqlParameter("@CantKg", 0);
            cantkg.Direction = ParameterDirection.Output;
            comando.Parameters.Add(cantkg);
            objConexion.Open();
            comando.ExecuteNonQuery();
            int nro = Convert.ToInt16(comando.Parameters["@CantKg"].Value);
            objConexion.Close();
            objConexion.Dispose();
            return  nro;
        }

        public void CrearEncomienda()
        {
            SqlConnection objConexion = new SqlConnection(Conexion.strCon);
            SqlTransaction tran = null;
            try
            {
                objConexion.Open();
                tran = objConexion.BeginTransaction();
                CrearCompra(objConexion);
                string strProc = "THE_BTREES.AddEncomienda";
                SqlCommand comando = new SqlCommand(strProc, objConexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@kg", kg);
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
