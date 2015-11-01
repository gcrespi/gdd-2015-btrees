using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AerolineaFrba
{
    public class Cliente
    {
        public int clienteID { get; set; }
        public string dni { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string mail { get; set; }
        public DateTime fechaNac { get; set; }
 

        public Cliente(string dni, string nombre, string apellido, string direccion,
                        string telefono, string mail, DateTime fechaNac)
        {
            this.dni = dni;
            this.nombre = nombre;           
            this.apellido = apellido;
            this.direccion = direccion;
            this.telefono = telefono;
            this.mail = mail;
            this.fechaNac = fechaNac;
        }

        public static DataTable TraerDatosCliente(string nombre,string apellido, int dni)
        {
            DataTable ds = new DataTable();
            string strSQL = "THE_BTREES.GetDatosCliente";
            SqlDataAdapter da = new SqlDataAdapter(strSQL, Conexion.strCon);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@nombre", nombre);
            da.SelectCommand.Parameters.AddWithValue("@apellido", apellido);
            da.SelectCommand.Parameters.AddWithValue("@dni", dni);
            da.Fill(ds);
            return ds;
        }
    }
}
