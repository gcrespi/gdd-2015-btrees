using AerolineaFrba.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba.Filtros
{
    class FiltroCbo<TipoKey> : Filtro
    {
        private ComboBoxWithAllOption cboFiltro;

        public FiltroCbo(ComboBoxWithAllOption cboFiltro, String campo) 
            :base(campo)
        {
            this.cboFiltro = cboFiltro;
        }

        public override String whereClause()
        {
            return (cboFiltro.isAllSelected()) ? "" : this.campoDeTabla + " = '" + ((TipoKey)cboFiltro.SelectedValue) + "'";
        }

        public override void limpiar()
        {
            cboFiltro.selectAllOption();
        }
    }
}
