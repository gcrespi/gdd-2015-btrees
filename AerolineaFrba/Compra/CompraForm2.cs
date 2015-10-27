using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba.Compra
{
    public partial class CompraForm2 : Form
    {

        private Compra compra;

        public CompraForm2(Compra compra)
        {
            InitializeComponent();
            this.compra = compra;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private bool isChecked()
        {
            return true;
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            if (isChecked())
            {
                compra.nombre = tbNom.Text;
                compra.apellido = tbApe.Text;
                compra.dni = tbDNI.Text;
                compra.direccion = tbDirec.Text;
                compra.telefono = tbTel.Text;
                compra.mail = tbMail.Text;
                compra.fechaNac = dtpFechaNac.Value;
            }
        }

        private void tbDNI_TextChanged(object sender, EventArgs e)
        {
            if (tbDNI.Text.Length >= 7)
            {

            }

        }
    }
}