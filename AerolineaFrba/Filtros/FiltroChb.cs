using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba.Filtros
{
    class FiltroChb : Filtro
    {
        private CheckBox chbFiltro;

        public FiltroChb(CheckBox chbFiltro, String campo) 
            :base(campo)
        {
            this.chbFiltro = chbFiltro;
        }

        public override String whereClause()
        {
            return this.campoDeTabla + " = " + (chbFiltro.Checked? "1":"0");
        }

        public override void limpiar()
        {
            chbFiltro.Checked = true;
        }
    }
}
