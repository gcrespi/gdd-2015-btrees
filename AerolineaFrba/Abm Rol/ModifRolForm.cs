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

namespace AerolineaFrba.Abm_Rol
{
    public partial class ModifRolForm : ModifForm
    {
        public ModifRolForm(int RolID)
        {
            InitializeComponent();
            uctrlRolModif.retrieveInfoFrom(RolID);
            uctrlRolModif.blockKeyAttrs();
        }

        protected override void btnModif_Click(object sender, EventArgs e)
        {
            if (uctrlRolModif.validateAttrs())
            {
                Roles.darModif(uctrlRolModif);
                MessageBox.Show("Se ha Modificado el Rol: " + uctrlRolModif.Nombre + " con Exito!", "Modificación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("No se ha podido guardar el Rol.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
