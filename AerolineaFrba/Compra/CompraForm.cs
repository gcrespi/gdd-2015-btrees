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
    public partial class CompraForm : Form
    {
           
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
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Byte tipoSer=Convert.ToByte(cboTipoServicio.SelectedValue);
            Int16 origen=Convert.ToInt16(cboCiudadOrigen.SelectedValue);
            Int16 destino=Convert.ToInt16(cboCiudadDestino.SelectedValue);
            gridViajes.DataSource = Viaje.TraerViajesDisponibles(tipoSer, timePickerFecha.Value, destino, origen);
            gridViajes.Columns["ViajeId"].Visible=false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }


    }
}
