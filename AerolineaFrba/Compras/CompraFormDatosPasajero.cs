using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba.Compras
{
    public partial class CompraFormDatosPasajero : CompraFormDatosEncomienda
    {

        public CompraFormDatosPasajero(Compra compra, int nroPasajero) : base(compra,nroPasajero)
        {
            InitializeComponent();
        }

    }
}
