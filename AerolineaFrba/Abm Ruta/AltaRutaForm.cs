using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AerolineaFrba.Plantillas;

namespace AerolineaFrba.Abm_Ruta
{
    public partial class AltaRutaForm : AltaForm
    {
        public AltaRutaForm()
        {
            InitializeComponent();
        }

        private void AltaRutaForm_Load(object sender, EventArgs e)
        {
            uctrlRuta.fillAttrsDefault();
        }

        protected override void btnLimpiar_Click(object sender, EventArgs e)
        {
            uctrlRuta.limpiar_campos();
        }


        protected override void btnGuardar_Click(object sender, EventArgs e)
        {
            if (uctrlRuta.validateAttrs())
            {
                RutaAerea.darAlta(uctrlRuta);
                MessageBox.Show("Se ha Guardado el Rol: " + uctrlRuta.CodigoRuta + " con Exito!", "Alta Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();   
            }
            else
            {
                MessageBox.Show("No se ha podido guardar " + uctrlRuta.accionRechazadaMessage(), "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
