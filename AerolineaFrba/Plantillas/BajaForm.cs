using AerolineaFrba.Abm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba.Plantillas
{
    public partial class BajaForm : Form, IBmdForm
    {
        private IAbmControl abmControl;

        public BajaForm(IAbmControl abmControl)
        {
            InitializeComponent();

            this.abmControl = abmControl;
            this.abmControl.drawIn(this);
            this.abmControl.blockAttrs();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            abmControl.darBaja();
            MessageBox.Show("Se ha Deshabilitado " + abmControl.accionConcretadaMessage() + " con Exito!", "Baja Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Hide();
        }

        private void BajaForm_Load(object sender, EventArgs e)
        {

        }

        public void showUp(DataGridViewRow selectedRow)
        {
            this.abmControl.retrieveInfoFrom(selectedRow);
            if (!abmControl.validateBaja())
            {
                MessageBox.Show("No se puede deshabilitar, " + abmControl.accionRechazadaMessage() + " ya estaba deshabilitado!", "Ya deshabilitado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            this.StartPosition = FormStartPosition.CenterScreen;
            this.Show();
        }

        public String nameButtonAccess()
        {
            return "Eliminar";
        }

        private void BajaForm_VisibleChanged(object sender, EventArgs e)
        {

        }

    }
}
