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
        public int telefono { get; set; }
        public string mail { get; set; }
        public DateTime fechaNac { get; set; }
 

        public Cliente(string dni, string nombre, string apellido, string direccion,
                        int telefono, string mail, DateTime fechaNac)
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

        public static DataTable createDtClientStructure()
        {
            DataTable dtCli = new DataTable("UPD_clientes");
            dtCli.Columns.Add("ClienteID", typeof(int));
            dtCli.Columns.Add("Cliente_DNI", typeof(int));
            dtCli.Columns.Add("Cliente_Nombre", typeof(string));
            dtCli.Columns.Add("Cliente_Apellido", typeof(string));
            dtCli.Columns.Add("Cliente_Direccion", typeof(string));
            dtCli.Columns.Add("Cliente_Telefono", typeof(int));
            dtCli.Columns.Add("Cliente_Mail", typeof(string));
            dtCli.Columns.Add("Cliente_FechaNac", typeof(DateTime));
            return dtCli;
        }

        public static DataTable ToDataTable(Cliente cli)
        {
            List<Cliente> lCli = new List<Cliente>();
            lCli.Add(cli);
            return Cliente.ToDataTable(lCli);
        }

        public static DataTable ToDataTable(List<Cliente> lCli)
        {
            DataTable dtCli = Cliente.createDtClientStructure();
            foreach (Cliente cli in lCli)
            {
                var row = dtCli.NewRow();
                row["ClienteID"] = cli.clienteID;
                row["Cliente_DNI"] = cli.dni;
                row["Cliente_Nombre"] = cli.nombre;
                row["Cliente_Apellido"] = cli.apellido;
                row["Cliente_Direccion"] = cli.direccion;
                row["Cliente_Telefono"] = cli.telefono;
                row["Cliente_Mail"] = cli.mail;
                row["Cliente_FechaNac"] = cli.fechaNac;
                dtCli.Rows.Add(row);
            }
            return dtCli;
        }

    }
}
