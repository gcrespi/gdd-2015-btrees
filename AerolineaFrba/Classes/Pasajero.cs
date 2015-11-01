using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AerolineaFrba
{
    public class Pasajero : Cliente
    {
        public int butacaRef { get; set; }

        public Pasajero(string dni, string nombre, string apellido, string direccion,
                        string telefono, string mail, DateTime fechaNac, int butacaRef)
            : base(dni, nombre, apellido, direccion, telefono, mail, fechaNac)
        {
            this.butacaRef = butacaRef;
        }


    }
}
