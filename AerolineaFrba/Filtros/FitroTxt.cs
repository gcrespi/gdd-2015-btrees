using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba.Filtros
{
    class FiltroTxt : Filtro
    {
        private TextBox txtFiltro;

        public FiltroTxt(TextBox txtFiltro, String campo) : base(campo)
        {
            this.txtFiltro = txtFiltro;
        }

        public override String whereClause()
        {
            if (txtFiltro.Text.Length > 0)
            {
                return this.campoDeTabla + " LIKE '%" + txtFiltro.Text + "%'";
            }
            else
            {
                return "";
            }
        }

        public override void limpiar()
        {
            txtFiltro.Text = "";
        }
    }
}
