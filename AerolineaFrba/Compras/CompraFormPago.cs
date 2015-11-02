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
    public partial class CompraFormPago : Form
    {
        private Compra compra;
        
        public CompraFormPago(Compra compra)
        {
            InitializeComponent();
            this.compra = compra;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbApe_TextChanged(object sender, EventArgs e)
        {
            fillIfExist();
            checkIfFilled();
        }

        private void CompraFormPago_Load(object sender, EventArgs e)
        {
            dtpFechaVencimiento.MinDate = DateTime.Now;
            dtpFechaNac.MaxDate = DateTime.Now;
            updCuotas.Maximum = 18;
        }

        private DataTable getClientData()
        {
            return Cliente.TraerDatosCliente(tbNom.Text, tbApe.Text, Convert.ToInt32(tbDNI.Text));
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

        private void checkIfFilled()
        {
            if (tbNom.Text != "" && tbApe.Text != "" && tbDNI.Text != "" && tbDirec.Text != ""
                && tbTel.Text != "" && tbMail.Text != "" && dtpFechaNac.Value.Date < DateTime.Now.Date)
            {
                if (rdTarjeta.Checked && updCuotas.Value != 0 && tbNroTarjeta.Text != "" &&
                      tbCodSeg.Text != "" && dtpFechaVencimiento.Value.Month >= DateTime.Now.Month &&
                        dtpFechaVencimiento.Value.Year >= DateTime.Now.Year)
                    btnContinue.Enabled = true;
                else if (rdEfectivo.Checked)
                    btnContinue.Enabled = true;
                else
                    btnContinue.Enabled = false;
            }
            else
                btnContinue.Enabled = false;
        }

        private void tbNom_TextChanged(object sender, EventArgs e)
        {
            fillIfExist();
            checkIfFilled();
        }

        private void tbDNI_TextChanged(object sender, EventArgs e)
        {
            fillIfExist();
            checkIfFilled();
        }

        private void dtpFechaNac_ValueChanged(object sender, EventArgs e)
        {
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

        private void rdEfectivo_CheckedChanged(object sender, EventArgs e)
        {
            checkIfFilled();
        }

        private void rdTarjeta_CheckedChanged(object sender, EventArgs e)
        {
            checkIfFilled();
        }

        private void updCuotas_ValueChanged(object sender, EventArgs e)
        {
            checkIfFilled();
        }

        private void cboTipoTarjeta_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkIfFilled();
        }

        private void tbNroTarjeta_TextChanged(object sender, EventArgs e)
        {
            checkIfFilled();
        }

        private void tbCodSeg_TextChanged(object sender, EventArgs e)
        {
            checkIfFilled();
        }

        private void dtpFechaVencimiento_ValueChanged(object sender, EventArgs e)
        {
            checkIfFilled();
        }

        private void btnBack_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente(tbDNI.Text, tbNom.Text, tbApe.Text, tbDirec.Text, Convert.ToInt32(tbTel.Text),
                                                  tbMail.Text, dtpFechaNac.Value);
            DataTable dt = getClientData();
            if (dt.Rows.Count == 1) cliente.clienteID = (int)dt.Rows[0]["ClienteID"];
            compra.comprador = cliente;
            if (rdTarjeta.Checked)
            {
                compra.efectivo = 0;
                compra.cantCuotas = (int)updCuotas.Value;
                compra.tipoTarjeta = (int)cboTipoTarjeta.SelectedValue;
                compra.numTarjeta = Convert.ToInt32(tbNroTarjeta.Text);
                compra.codSeg = Convert.ToInt32(tbCodSeg.Text);
                compra.fechaVenc = dtpFechaVencimiento.Value;

            }
            else compra.efectivo = 1;
            try
            {
                compra.store();
                Program.main.addForm(new CompraFormFinal(compra.compraRef));
            }
            catch (Exception)
            {
                MessageBox.Show("Error en la solicitud, por favor intente nuevamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnContinue_EnabledChanged(object sender, EventArgs e)
        {
            if (btnContinue.Enabled)
                btnContinue.BackColor = Color.OrangeRed;
            else
                btnContinue.BackColor = Color.DimGray;
        }





    }
}
