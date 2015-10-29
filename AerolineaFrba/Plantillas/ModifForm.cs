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
    public partial class ModifForm : Form, IBmdForm
    {
        private IAbmControl abmControl;

        public ModifForm(IAbmControl abmControl)
        {
            InitializeComponent();

            this.abmControl = abmControl;
            this.abmControl.drawIn(this);
            this.abmControl.blockKeyAttrs();
        
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        protected virtual void btnModif_Click(object sender, EventArgs e)
        {
            if (abmControl.validateAttrs())
            {
                abmControl.darModif();
                MessageBox.Show("Se ha Modificado " + abmControl.accionConcretadaMessage() + " con Exito!", "Modificación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
            }
            else
            {
                MessageBox.Show("No se ha podido guardar " + abmControl.accionRechazadaMessage(), "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void showUp(DataGridViewRow selectedRow)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Show();
            this.abmControl.retrieveInfoFrom(selectedRow);
        }

        public String nameButtonAccess()
        {
            return "Modificar";
        }

    }
}
