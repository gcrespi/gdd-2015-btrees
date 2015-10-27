using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace AerolineaFrba
{
    public class Compra
    {
        public string dni { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string mail { get; set; }
        public DateTime fechaNac { get; set; }
        public bool efectivo { get; set; }
        public int cantCuotas { get; set; }
        public int tipoTarjeta { get; set; }
        public int numTarjeta { get; set; }
        public int codSeg { get; set; }
        public DateTime fechaVenc { get; set; }
        public double precio { get; set; }
        public int compraRef { get; set; }
        public int clienteRef { get; set; }
        public int viajeRef { get; set; }
        

        //Devuelve el ID de la compra
        public void CrearCompra(SqlConnection openedObjConexion) 
        {
            try
            {
                string strProc = "THE_BTREES.AddCompra";
                SqlCommand comando = new SqlCommand(strProc, openedObjConexion);
                comando.CommandType = CommandType.StoredProcedure;
	            comando.Parameters.AddWithValue("@dni",dni);
	            comando.Parameters.AddWithValue("@nombre",nombre);
	            comando.Parameters.AddWithValue("@apellido",apellido);
	            comando.Parameters.AddWithValue("@direccion",direccion);
	            comando.Parameters.AddWithValue("@telefono",telefono);
	            comando.Parameters.AddWithValue("@mail",mail);
	            comando.Parameters.AddWithValue("@fechaNac",fechaNac);
	            comando.Parameters.AddWithValue("@efectivo",efectivo);
	            comando.Parameters.AddWithValue("@cantCuotas",cantCuotas);
	            comando.Parameters.AddWithValue("@tipoTarjeta",tipoTarjeta);
                comando.Parameters.AddWithValue("@numTarjeta",numTarjeta);
	            comando.Parameters.AddWithValue("@codSeg",codSeg);
	            comando.Parameters.AddWithValue("@fechaVenc",fechaVenc);
                SqlParameter compraID = new SqlParameter("@compraID", 0);
                compraID.Direction = ParameterDirection.Output;
                comando.Parameters.Add(compraID);
                comando.ExecuteNonQuery();
                compraRef = Convert.ToInt32(comando.Parameters["@CancelID"].Value);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

    }
}
