using AerolineaFrba.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AerolineaFrba.Filtros
{
    class FiltroNum : Filtro
    {
        private NumericBox numFiltro;

        public FiltroNum(NumericBox numFiltro, String campo) 
            :base(campo)
        {
            this.numFiltro = numFiltro;
        }

        public override String whereClause()
        {
            return (numFiltro.TextValue == 0) ? "" : this.campoDeTabla + " = '" + numFiltro.TextValue + "'";
        }

        public override void limpiar()
        {
            numFiltro.Text = "";
        }

    }
}
