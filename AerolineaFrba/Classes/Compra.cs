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
        public Cliente comprador { get; set; }
        public int efectivo { get; set; }
        public int cantCuotas { get; set; }
        public int tipoTarjeta { get; set; }
        public int numTarjeta { get; set; }
        public int codSeg { get; set; }
        public DateTime fechaVenc { get; set; }
        public double precio { get; set; }
        public int viajeRef { get; set; }
        public int cantPasajes { get; set; }
        public List<Pasajero> pasajeros { get; set; }
        public DataTable butacasDisponibles { get; set; }
        public Cliente encomiendaResp { get; set; }
        public int kg { get; set; }
        public int compraRef { get; set; }

        public Compra()
        {
            pasajeros = new List<Pasajero>();
        }

        public Compra clone() 
        {
            Compra clon = new Compra();
            clon.comprador = comprador;
            clon.efectivo = efectivo;
            clon.cantCuotas = cantCuotas;
            clon.tipoTarjeta = tipoTarjeta;
            clon.numTarjeta = numTarjeta;
            clon.codSeg = codSeg;
            clon.fechaVenc = fechaVenc;
            clon.viajeRef = viajeRef;
            clon.cantPasajes = cantPasajes;
            clon.pasajeros = new List<Pasajero>();
            clon.pasajeros.AddRange(pasajeros);
            if (butacasDisponibles != null)
                clon.butacasDisponibles = butacasDisponibles.Copy();
            clon.encomiendaResp = encomiendaResp;
            clon.kg = kg;
            return clon;
        }
        
        public void store()
        {
            SqlConnection objConexion = new SqlConnection(Conexion.strCon);
            SqlTransaction tran = null;
           try
            {
                objConexion.Open();
                tran = objConexion.BeginTransaction();
                crearCompra(objConexion,tran);
                if (cantPasajes > 0) crearPasajes(objConexion,tran);
                if (kg > 0) crearEncomienda(objConexion,tran);
                tran.Commit();
            }
            catch (Exception)
            {
                tran.Rollback();
                throw new Exception("Error al guardar la compra");
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

        //Setea el compraRef
        public void crearCompra(SqlConnection openedObjConexion, SqlTransaction tran) 
        {
            string strProc = "THE_BTREES.AddCompra";
            SqlCommand comando = new SqlCommand(strProc, openedObjConexion);
            comando.Transaction = tran;
            comando.CommandType = CommandType.StoredProcedure;
	        comando.Parameters.AddWithValue("@dtComprador", Cliente.ToDataTable(comprador));
	        comando.Parameters.AddWithValue("@efectivo",efectivo);
            if (efectivo != 1)
            {
                comando.Parameters.AddWithValue("@cantCuotas", cantCuotas);
                comando.Parameters.AddWithValue("@tipoTarjeta", tipoTarjeta);
                comando.Parameters.AddWithValue("@numTarjeta", numTarjeta);
                comando.Parameters.AddWithValue("@codSeg", codSeg);
                comando.Parameters.AddWithValue("@fechaVenc", fechaVenc);
            }
            SqlParameter compraID = new SqlParameter("@compraID", 0);
            compraID.Direction = ParameterDirection.Output;
            comando.Parameters.Add(compraID);
            comando.ExecuteNonQuery();
            compraRef = Convert.ToInt32(comando.Parameters["@compraID"].Value);
        }

        public void crearPasajes(SqlConnection openedObjConexion, SqlTransaction tran)
        {
            string strProc = "THE_BTREES.AddPasaje";
            SqlCommand comando = new SqlCommand(strProc, openedObjConexion);
            comando.Transaction = tran;
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@dtPasajeros", Pasajero.ToDataTable(pasajeros));
            comando.Parameters.AddWithValue("@precio", precio);
            comando.Parameters.AddWithValue("@compraRef", compraRef);
            comando.Parameters.AddWithValue("@viajeRef", viajeRef);
            comando.ExecuteNonQuery();
        }

        public void crearEncomienda(SqlConnection openedObjConexion, SqlTransaction tran)
        {
            string strProc = "THE_BTREES.AddEncomienda";
            SqlCommand comando = new SqlCommand(strProc, openedObjConexion);
            comando.Transaction = tran;
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@kg", kg);
            comando.Parameters.AddWithValue("@precio", precio);
            comando.Parameters.AddWithValue("@compraRef", compraRef);
            comando.Parameters.AddWithValue("@dtResponsable", Cliente.ToDataTable(encomiendaResp));
            comando.Parameters.AddWithValue("@viajeRef", viajeRef);
            comando.ExecuteNonQuery();
        }

    }
}
