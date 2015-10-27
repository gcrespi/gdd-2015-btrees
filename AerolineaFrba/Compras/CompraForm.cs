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
    public partial class CompraForm : Form
    {
        private DateTime fechaViaje;
        private Compra compra = new Compra();
 
        public CompraForm()
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
            timePickerFecha.MinDate = DateTime.Today;
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

        private void button1_Click(object sender, EventArgs e)
        {
           compra.viajeID = gridViajes.CurrentRow.Cells[0].Value.ToString();
           Program.main.addForm(new CompraForm2(compra));
        }

        private void checkBoxFecha_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxFecha.Checked) timePickerFecha.Enabled = true;
            else timePickerFecha.Enabled = false;
        }

    }
}
