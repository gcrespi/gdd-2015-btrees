using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AerolineaFrba.Filtros
{
    abstract class Filtro
    {
        protected String campoDeTabla;
        public String Campo { get { return campoDeTabla; } }

        public Filtro(String campo)
        {
            this.campoDeTabla = campo;
        }

        public abstract String whereClause();

        public abstract void limpiar();
    }
}
