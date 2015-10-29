using AerolineaFrba.Plantillas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba.Filtros
{
    public interface FiltroControl
    {
        String ProcedureName();

        string whereClause();

        void limpiar();

        void drawIn(Form aForm);
    }
}
