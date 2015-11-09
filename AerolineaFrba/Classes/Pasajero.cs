using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AerolineaFrba
{
    public class Pasajero : Cliente
    {
        public int butacaRef { get; set; }

        public Pasajero(string dni, string nombre, string apellido, string direccion,
                        int telefono, string mail, DateTime fechaNac, int butacaRef)
            : base(dni, nombre, apellido, direccion, telefono, mail, fechaNac)
        {
            this.butacaRef = butacaRef;
        }

        public static DataTable ToDataTable(Pasajero psj)
        {
            List<Pasajero> lPsj = new List<Pasajero>();
            lPsj.Add(psj);
            return Pasajero.ToDataTable(lPsj);
        }

        public static DataTable ToDataTable(List<Pasajero> lPsj)
        {
            DataTable dtPsj = Cliente.createDtClientStructure();
            dtPsj.Columns.Add("Cliente_ButacaRef", typeof(int));
            foreach (Pasajero psj in lPsj)
            {
                var row = dtPsj.NewRow();
                row["ClienteID"] = psj.clienteID;
                row["Cliente_DNI"] = psj.dni;
                row["Cliente_Nombre"] = psj.nombre;
                row["Cliente_Apellido"] = psj.apellido;
                row["Cliente_Direccion"] = psj.direccion;
                row["Cliente_Telefono"] = psj.telefono;
                row["Cliente_Mail"] = psj.mail;
                row["Cliente_FechaNac"] = psj.fechaNac;
                row["Cliente_ButacaRef"] = psj.butacaRef;
                dtPsj.Rows.Add(row);
            }
            return dtPsj;
        }

    }
}
