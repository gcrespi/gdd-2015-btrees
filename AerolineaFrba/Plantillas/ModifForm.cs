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
    public partial class ModifForm : Form
    {
        private IAbmControl abmControl;

        public ModifForm(IAbmControl abmControl, DataGridViewRow selectedRow)
        {
            InitializeComponent();

            this.abmControl = abmControl;
            this.abmControl.drawIn(this);
            this.abmControl.blockKeyAttrs();
            this.showUp(selectedRow);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected virtual void btnModif_Click(object sender, EventArgs e)
        {
            if (abmControl.validateAttrsModif())
            {
                abmControl.darModif();
                MessageBox.Show("Se ha Modificado " + abmControl.accionConcretadaMessage() + " con Exito!", "Modificación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("No se ha podido guardar " + abmControl.accionRechazadaMessage(), "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void showUp(DataGridViewRow selectedRow)
        {
            this.abmControl.retrieveInfoFrom(selectedRow);
        }

    }
}
