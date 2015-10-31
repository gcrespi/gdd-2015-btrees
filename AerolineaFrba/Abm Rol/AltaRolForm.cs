using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using sql = System.Data.SqlClient;
using AerolineaFrba.Plantillas;

namespace AerolineaFrba.Abm_Rol
{
    public partial class AltaRolForm : AltaForm
    {    
        public AltaRolForm()
        {
            InitializeComponent();
        }

        private void AltaRolForm_Load(object sender, EventArgs e)
        {
            uctrlRolAlta.fillAttrsDefault();
        }

        protected override void btnLimpiar_Click(object sender, EventArgs e)
        {
            uctrlRolAlta.limpiar_campos();
        }

        protected override void btnGuardar_Click(object sender, EventArgs e)
        {
            if (uctrlRolAlta.validateAttrs())
            {
                Roles.darAlta(uctrlRolAlta);
                MessageBox.Show("Se ha Guardado el Rol: " + uctrlRolAlta.Nombre + " con Exito!", "Alta Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();   
            }
            else
            {
                MessageBox.Show("No se ha podido guardar el Rol.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
