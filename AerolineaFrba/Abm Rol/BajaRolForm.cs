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
    public partial class BajaRolForm : BajaForm
    {
        public BajaRolForm(int rolID)
        {
            InitializeComponent();
            uctrlRolBaja.retrieveInfoFrom(rolID);
            uctrlRolBaja.blockAttrs();
        }

        protected override void btnEliminar_Click(object sender, EventArgs e)
        {
            Roles.darBajaLogica(uctrlRolBaja);
            MessageBox.Show("Se ha Deshabilitado el Rol: " + uctrlRolBaja.Nombre + " con Exito!", "Baja Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
