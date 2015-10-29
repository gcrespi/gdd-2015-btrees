using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba.Abm
{
    public interface IBmdForm
    {
        void showUp(DataGridViewRow selectedRow);

        string nameButtonAccess();

        void Close();
    }
}
