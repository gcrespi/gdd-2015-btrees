using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba.Generacion_Viaje
{
    public partial class GenerarViajeForm : Form
    {
        public GenerarViajeForm()
        {
            InitializeComponent();
        }

        private void GenerarViajeForm_Load(object sender, EventArgs e)
        {
            dtpFechaSalida.MinDate = DateTime.Today;
            dtpFechaLlegada.MinDate = DateTime.Today;
            dtpFechaLlegadaEstimada.MinDate = DateTime.Today;
            gridAeronave.DataSource = Avion.TraerAvionesParaCompra();
            gridAeronave.Columns["AvionID"].Visible = false;
            gridAeronave.Columns["ServicioRef"].Visible = false;
            gridRutaAerea.DataSource = RutaAerea.TraerRutasParaCompra();
            gridRutaAerea.Columns["RutaAereaID"].Visible = false;
            gridRutaAerea.Columns["ServicioRef"].Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dtpFechaSalida.Value > dtpFechaLlegada.Value | dtpFechaSalida.Value > dtpFechaLlegadaEstimada.Value)
            {
                MessageBox.Show("La fecha de llegada (o estimada) no puede ser menor que la fecha de salida");
                return;
            }
            if (dtpFechaLlegadaEstimada.Value>dtpFechaLlegada.Value.AddHours(24)) 
            {
                MessageBox.Show("La fecha de llegada estimada no puede ser 24hs mayor que la de llegada");
                return;
            }
            
            if (gridRutaAerea.SelectedRows.Count != 1 | gridAeronave.SelectedRows.Count != 1)
            {
                MessageBox.Show("Debe seleccionar solo una Ruta y Aeronave");
                return;
            }
            int tsRuta=Convert.ToByte(gridRutaAerea.SelectedRows[0].Cells["ServicioRef"].Value);
            int tsAvion =Convert.ToByte(gridAeronave.SelectedRows[0].Cells["ServicioRef"].Value);
            if (tsRuta != tsAvion)
             {
                MessageBox.Show("Debe seleccionar una Ruta y Aeronave con igual Tipo de Servicio");
                return;
            }
            int ruta = Convert.ToInt32(gridRutaAerea.SelectedRows[0].Cells["RutaAereaID"].Value);
            int avion = Convert.ToByte(gridAeronave.SelectedRows[0].Cells["AvionID"].Value);
            try
            {
                Viaje.CrearViaje(dtpFechaSalida.Value, dtpFechaLlegada.Value, dtpFechaLlegadaEstimada.Value, avion, ruta);
                MessageBox.Show("Viaje creado correctamente");
                Close();
            }
            catch(Exception)
            {
                MessageBox.Show("La Aeronave seleccionada se encuentra asignada a otro viaje en la fecha elegida");
            }                  
        }
    }
}
