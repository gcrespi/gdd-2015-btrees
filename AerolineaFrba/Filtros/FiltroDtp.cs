using AerolineaFrba.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba.Filtros
{
    class FiltroDtp : Filtro
    {
        private DisableableDate dtpFiltro;

        public FiltroDtp(DisableableDate dtpFiltro, String campo)
            : base(campo)
        {
            this.dtpFiltro = dtpFiltro;
        }

        public override String whereClause()
        {
            if (dtpFiltro.EnableDate)
            {
                return "CONVERT(date, " + this.campoDeTabla + ") = '" + dtpFiltro.SqlFormatDate + "'";
            }
            else
            {
                return "";
            }
        }

        public override void limpiar()
        {
            dtpFiltro.Value = Config.dateTimeNow;
            dtpFiltro.EnableDate = false;
        }
    }
}
