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
    public partial class CompraFormFinal : Form
    {
        private int codCompra;

        public CompraFormFinal(int codCompra)
        {
            InitializeComponent();
            this.codCompra = codCompra;
        }

        private void CompraFormFinal_Load(object sender, EventArgs e)
        {
            lbCompraRef.Text = codCompra.ToString();
        }





    }
}
