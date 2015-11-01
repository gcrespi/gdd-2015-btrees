using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AerolineaFrba.Utils;

namespace AerolineaFrba.Compras
{
    public partial class CompraFormDatosEncomienda: Form
    {

        private Compra compra;

        public CompraFormDatosEncomienda(Compra compra)
        {
            InitializeComponent();
            this.compra = compra;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void checkIfFilled()
        {
            if (tbNom.Text != "" && tbApe.Text != "" && tbDNI.Text != "" && tbDirec.Text != ""
                && tbTel.Text != "" && tbMail.Text != "" && dtpFechaNac.Value.Date < DateTime.Now.Date)
                btnContinue.Enabled = true;
            else
                btnContinue.Enabled = false;

        }

        private DataTable getClientData()
        {
            return Cliente.TraerDatosCliente(tbNom.Text, tbApe.Text, Convert.ToInt32(tbDNI.Text));
        }


        private void btnContinue_Click(object sender, EventArgs e)
        {
               
            
            Cliente cliente = new Cliente(tbDNI.Text,tbNom.Text,tbApe.Text,tbDirec.Text,tbTel.Text,
                                                   tbMail.Text,dtpFechaNac.Value);
            DataTable dt = getClientData();
            if (dt.Rows.Count == 1) cliente.clienteID = (int)dt.Rows[0]["ClienteID"];
            compra.encomiendaResp = cliente;
            Program.main.addForm(new CompraFormPago(compra));
        }

        private void fillIfExist()
        {
            if (tbDNI.Text.Length >= 7 && tbDNI.Text.Length <= 9)
            {
                DataTable dt = getClientData();
                if (dt.Rows.Count == 1)
                {
                    tbDirec.Text = dt.Rows[0]["Cliente_Direccion"].ToString();
                    tbTel.Text = dt.Rows[0]["Cliente_Telefono"].ToString();
                    tbMail.Text = dt.Rows[0]["Cliente_Mail"].ToString();
                    dtpFechaNac.Value = (DateTime)dt.Rows[0]["Cliente_FechaNac"];
                }
            }
        }

        private void tbDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextValidations.ValidateJustNumbers(e);
        }

        private void tbApe_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextValidations.ValidateJustLetters(e);
        }

        private void tbNom_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextValidations.ValidateJustLetters(e);
        }

        private void tbDNI_TextChanged(object sender, EventArgs e)
        {
            fillIfExist();
            checkIfFilled();
        }

        private void tbApe_TextChanged(object sender, EventArgs e)
        {
            fillIfExist();
            checkIfFilled();
        }

        private void tbNom_TextChanged(object sender, EventArgs e)
        {
            fillIfExist();
            checkIfFilled();
        }

        private void tbDirec_TextChanged(object sender, EventArgs e)
        {
            checkIfFilled();
        }

        private void tbTel_TextChanged(object sender, EventArgs e)
        {
            checkIfFilled();
        }

        private void tbMail_TextChanged(object sender, EventArgs e)
        {
            checkIfFilled();
        }

        private void dtpFechaNac_ValueChanged(object sender, EventArgs e)
        {
            checkIfFilled();
        }

    }
}