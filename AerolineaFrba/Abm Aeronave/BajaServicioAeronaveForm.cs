using AerolineaFrba.Abm;
using AerolineaFrba.Plantillas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba.Abm_Aeronave
{
    public partial class BajaServicioAeronaveForm : Form
    {
        private UctrlAeronave uctrlAeronave;
        
        public BajaServicioAeronaveForm(UctrlAeronave abmControl, DataGridViewRow selectedRow)
        {
            InitializeComponent();
            this.uctrlAeronave = abmControl;
            this.uctrlAeronave.drawIn(this);
            this.uctrlAeronave.blockAttrs();
            this.showUp(selectedRow);
        }

        public void showUp(DataGridViewRow selectedRow)
        {
            this.uctrlAeronave.retrieveInfoFrom(selectedRow);

            if (uctrlAeronave.BajaPorFueraDeServicio)
            {
                btnBaja.Text = "Reiniciar Servicio";
            }
            else
            {
                btnBaja.Text = "Dar Fuera de Servicio";
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            if (uctrlAeronave.BajaPorFueraDeServicio)
            {
                Avion.DarReinicioServicio(uctrlAeronave);
                MessageBox.Show("Se dio de Baja por fuera de Servicio a la Aeronave: " + uctrlAeronave.Matricula + "con Exito!", "Fuera de Servicio", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Avion.DarFueraServicio(uctrlAeronave);
                MessageBox.Show("Se reinició el Servicio a la Aeronave: " + uctrlAeronave.Matricula + " con Exito!", "Reinicio de Servicio", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            this.Close();
        }
    }
}
