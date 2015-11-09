using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba.Consulta_Millas
{
    public partial class ConsultaMillasForm : Form
    {
        public ConsultaMillasForm()
        {
            InitializeComponent();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            int cantMillas = 0;
            int clienteID = 0;
            DataTable dt;
            Millas.TraerMillasDisponible(ref cantMillas,ref clienteID,tbApe.Text,tbDNI.Text);
            lbCantMillas.Text = cantMillas.ToString();
            dt = Millas.TraerDetalleTransMillas(clienteID);
            dataGridDetalle.DataSource = dt;
        }

        private void checkIfFilled()
        {
            if (tbApe.Text != "" && tbDNI.Text != "")
                btnConsultar.Enabled = true;
            else
                btnConsultar.Enabled = false;

        }

        private void tbApe_TextChanged(object sender, EventArgs e)
        {
            checkIfFilled();
        }


        private void tbDNI_TextChanged(object sender, EventArgs e)
        {
            checkIfFilled();
        }


    }
}
