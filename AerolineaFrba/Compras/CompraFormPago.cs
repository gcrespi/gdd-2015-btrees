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
            dtpFechaVencimiento.MinDate = Config.dateTimeNow;
            dtpFechaNac.MaxDate = Config.dateTimeNow;
            tbNom.Focus();
            cboTipoTarjeta.DataSource = TipoTarjeta.ListTipoTarjeta();
            cboTipoTarjeta.DisplayMember = "Descripcion";
            cboTipoTarjeta.ValueMember = "TipoTarjetaID";
            if (Program.terminal == "kiosco")
            {
                rdTarjeta.Checked = true;
                checkMetodoDePago();
                rdEfectivo.Enabled = false;
            }
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
                && tbTel.Text != "" && tbMail.Text != "" && dtpFechaNac.Value.Date < Config.dateTimeNow.Date)
            {
                if (rdTarjeta.Checked && updCuotas.Value != 0 && 
                      tbNroTarjeta.Text != "" && tbCodSeg.Text != "")
                    btnContinue.Enabled = true;
                else if (rdEfectivo.Checked)
                    btnContinue.Enabled = true;
                else
                    btnContinue.Enabled = false;
            }
            else
                btnContinue.Enabled = false;
        }

        private void checkMetodoDePago()
        {
            if (rdTarjeta.Checked)
            {
                updCuotas.Enabled = true;
                cboTipoTarjeta.Enabled = true;
                tbNroTarjeta.Enabled = true;
                tbCodSeg.Enabled = true;
                dtpFechaVencimiento.Enabled = true;
            }
            else
            {
                updCuotas.Enabled = false;
                cboTipoTarjeta.Enabled = false;
                tbNroTarjeta.Enabled = false;
                tbCodSeg.Enabled = false;
                dtpFechaVencimiento.Enabled = false;
            }
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
            checkMetodoDePago();
        }

        private void rdTarjeta_CheckedChanged(object sender, EventArgs e)
        {
            checkIfFilled();
            checkMetodoDePago();
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
            if (rdTarjeta.Checked && !TipoTarjeta.cantCuotasIsOK((int)cboTipoTarjeta.SelectedValue, (int)updCuotas.Value))
            {
                MessageBox.Show("El tipo de tarjeta seleccionado no permite esa cantidad de cuotas", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
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
                Program.main.replaceForm(new CompraFormFinal(compra));
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
