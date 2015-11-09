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
        private Compra compra;

        public CompraFormFinal(Compra compra)
        {
            InitializeComponent();
            this.compra = compra;
        }

        private void CompraFormFinal_Load(object sender, EventArgs e)
        {
            lbCompraRef.Text = compra.compraRef.ToString();
            lbPrecio.Text = "$" + (compra.precioPasaje * compra.cantPasajes + compra.kg * compra.precioXKg).ToString();
        }

        private void lbCompraRef_Click(object sender, EventArgs e)
        {

        }





    }
}
