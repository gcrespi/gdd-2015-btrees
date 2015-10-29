using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace AerolineaFrba.Filtros
{
    class FiltroChlb<TipoKey> : Filtro
    {
        private CheckedListBox chlbFiltro;

        public FiltroChlb(CheckedListBox chlbFiltro, String campo) 
            :base(campo)
        {
            this.chlbFiltro = chlbFiltro;
        }

        public override String whereClause()
        {
            String _self = "";
            var _first = true;

            foreach (DataRowView indexChecked in chlbFiltro.CheckedItems)
            {
                var id = indexChecked.Row.Field<TipoKey>(0);

                if (_first)
                    _self = campoDeTabla + " IN (" + id.ToString();
                else
                    _self += ", " + id.ToString();

                _first = false;
            }

            return _first? "" : _self + ")";
        }

        public override void limpiar()
        {
            foreach (int i in chlbFiltro.CheckedIndices)
                chlbFiltro.SetItemCheckState(i, CheckState.Unchecked);
        }
    }
}
