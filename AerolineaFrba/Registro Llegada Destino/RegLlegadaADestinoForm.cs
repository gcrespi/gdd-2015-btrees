using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba.Registro_Llegada_Destino
{
    public partial class RegLlegadaADestinoForm : Form
    {
        public RegLlegadaADestinoForm()
        {
            InitializeComponent();
        }

        private void RegLlegadaADestinoForm_Load(object sender, EventArgs e)
        {
            cboCiudadOrigen.DataSource = Ciudad.ListCiudades();
            cboCiudadOrigen.DisplayMember = "Ciudad_Nombre";
            cboCiudadOrigen.ValueMember = "CiudadID";
            cboCiudadDestino.DataSource = Ciudad.ListCiudades();
            cboCiudadDestino.DisplayMember = "Ciudad_Nombre";
            cboCiudadDestino.ValueMember = "CiudadID";
            cboAvion.DataSource = Avion.TraerAvionesMatricula();
            cboAvion.DisplayMember = "Avion_Matricula";
            cboAvion.ValueMember = "AvionID";
 
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            Int32 avion=Convert.ToInt32(cboAvion.SelectedValue);
            Int16 origen=Convert.ToInt16(cboCiudadOrigen.SelectedValue);
            Int16 destino=Convert.ToInt16(cboCiudadDestino.SelectedValue);
            string rdo = Viaje.RegistrarLlegada(avion, destino, origen, dtpFechaLlegada.Value);
            MessageBox.Show(rdo);
        }
    }
}
