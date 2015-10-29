using AerolineaFrba.Plantillas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba.Filtros
{
    public abstract class FiltroControl : UserControl
    {
        public abstract String ProcedureName();

        public abstract string whereClause();

        public abstract void limpiar();

        public abstract void callBMDForm(DataGridView senderGrid, int rowIndex, int columnIndex, TipoListado tipoForm);
    }
}
