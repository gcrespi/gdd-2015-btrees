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
    public partial class AltaForm : Form
    {
        private IAbmControl abmControl;

        public AltaForm(IAbmControl abmControl)
        {
            InitializeComponent();
        
            this.abmControl = abmControl;
            this.abmControl.drawIn(this);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            btnLimpiar.PerformClick();
            this.Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            abmControl.limpiar_campos();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (abmControl.validateAttrs())
            {
                abmControl.darAlta();
                MessageBox.Show("Se ha Guardado " + abmControl.accionConcretadaMessage() + " con Exito!", "Alta Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();   
            }
            else
            {
                MessageBox.Show("No se ha podido guardar " + abmControl.accionRechazadaMessage(), "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AltaForm_Load(object sender, EventArgs e)
        {
            abmControl.fillAttrsDefault();
        }
    }
    
}
