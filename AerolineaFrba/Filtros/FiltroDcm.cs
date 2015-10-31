using AerolineaFrba.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba.Filtros
{
    class FiltroDcm : Filtro
    {
        private DecimalBox dcmFiltro;

        public FiltroDcm(DecimalBox dcmFiltro, String campo) 
            :base(campo)
        {
            this.dcmFiltro = dcmFiltro;
        }

        public override String whereClause()
        {
            return (dcmFiltro.Text == "") ? "" : this.campoDeTabla + " = '" + dcmFiltro.DecimalText + "'";
        }

        public override void limpiar()
        {
            dcmFiltro.Text = "";
        }
    }
}
