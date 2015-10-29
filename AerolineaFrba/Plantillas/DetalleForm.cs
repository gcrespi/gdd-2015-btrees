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
    public partial class DetalleForm : Form, IBmdForm
    {
        private IAbmControl abmControl;

        public DetalleForm(IAbmControl abmControl)
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

        public void showUp(DataGridViewRow selectedRow)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Show();
            this.abmControl.retrieveInfoFrom(selectedRow);
        }

        public String nameButtonAccess()
        {
            return "Detalles";
        }
    }
}
