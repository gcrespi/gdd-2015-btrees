using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace AerolineaFrba
{
    class Utiles
    {
        public static void agregarCampoDefaultADT(DataTable ds)
        {
            DataRow row = ds.NewRow();
            row[0] = 0;
            row[1] = "<Todos>";
            ds.Rows.Add(row);
        }
    }
}
