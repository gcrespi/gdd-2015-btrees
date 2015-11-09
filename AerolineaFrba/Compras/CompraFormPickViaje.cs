using AerolineaFrba.Utils;
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
    public partial class CompraFormPickViaje : Form
    {
        private DateTime fechaViaje;
        private Compra compra = new Compra();
 
        public CompraFormPickViaje()
        {
            InitializeComponent();
        }

        private void CompraForm_Load(object sender, EventArgs e)
        {
            cboTipoServicio.DataSource = TipoServicio.TraerTiposDeServicioCombo();
            cboTipoServicio.DisplayMember = "TipoSer_Nombre";
            cboTipoServicio.ValueMember = "TipoServicioID";
            cboTipoServicio.SelectedValue = 0;
            cboCiudadOrigen.DataSource=Ciudad.TraerCiudadesCombo();
            cboCiudadOrigen.DisplayMember = "Ciudad_Nombre";
            cboCiudadOrigen.ValueMember = "CiudadID";
            cboCiudadOrigen.SelectedValue = 0;
            cboCiudadDestino.DataSource = Ciudad.TraerCiudadesCombo();
            cboCiudadDestino.DisplayMember = "Ciudad_Nombre";
            cboCiudadDestino.ValueMember = "CiudadID";
            cboCiudadDestino.SelectedValue = 0;
            timePickerFecha.MinDate = Config.dateTimeNow;
            timePickerFecha.Enabled = false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Byte tipoSer=Convert.ToByte(cboTipoServicio.SelectedValue);
            Int16 origen=Convert.ToInt16(cboCiudadOrigen.SelectedValue);
            Int16 destino=Convert.ToInt16(cboCiudadDestino.SelectedValue);
            if (checkBoxFecha.Checked) fechaViaje = timePickerFecha.Value;
            else fechaViaje = DateTime.Parse("2000-01-01");
            gridViajes.DataSource = Viaje.TraerViajesDisponibles(tipoSer, fechaViaje, destino, origen);
            gridViajes.Columns["ViajeId"].Visible=false;  
                
        }

        private void checkBtnContinue()
        {
            if ((upDownPasajes.Value > 0 || upDownKg.Value > 0) && gridViajes.CurrentRow != null )
                btnContinue.Enabled = true;
            else btnContinue.Enabled = false;
        }

        private void checkBoxFecha_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxFecha.Checked) timePickerFecha.Enabled = true;
            else timePickerFecha.Enabled = false;
        }

        private void upDownPasajes_ValueChanged(object sender, EventArgs e)
        {
            checkBtnContinue();
        }

        private void upDownKg_ValueChanged(object sender, EventArgs e)
        {
            checkBtnContinue();
        }

        private void gridViajes_MouseClick(object sender, MouseEventArgs e)
        {
            checkBtnContinue();
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            if (upDownPasajes.Value <= (int)gridViajes.CurrentRow.Cells["Cant Butacas Disponibles"].Value)
            {
                if (upDownKg.Value <= 
                    (decimal)gridViajes.CurrentRow.Cells["Cant KG Disponibles"].Value)
                {
                    compra.viajeRef = (int)gridViajes.CurrentRow.Cells["ViajeID"].Value;
                    compra.cantPasajes = (int)upDownPasajes.Value;
                    compra.precioPasaje = Utiles.parseDoubleFromPrice(gridViajes.CurrentRow.Cells["Precio Pasaje"].Value.ToString());
                    compra.kg = (int)upDownKg.Value;
                    compra.precioXKg = Utiles.parseDoubleFromPrice(gridViajes.CurrentRow.Cells["Precio por KG"].Value.ToString());
                    if (compra.cantPasajes > 0)
                    {
                        compra.butacasDisponibles = Butaca.GetButacasDisponiblesCombo(compra.viajeRef);
                        Program.main.addForm(new CompraFormDatosPasajero(compra, 0));
                    }
                    else
                        Program.main.addForm(new CompraFormDatosEncomienda(compra));
                }
                else
                {
                    MessageBox.Show("No hay suficientes kg disponibles para su encomienda", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

            else
            {
                MessageBox.Show("No hay suficientes pasajes para su vuelo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

    }
}
