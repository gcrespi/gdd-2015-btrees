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
    public partial class DetalleForm : Form
    {
        private IAbmControl abmControl;

        public DetalleForm(IAbmControl abmControl, DataGridViewRow selectedRow)
        {
            InitializeComponent();

            this.abmControl = abmControl;
            this.abmControl.drawIn(this);
            this.abmControl.blockAttrs();
            this.showUp(selectedRow);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public virtual void showUp(DataGridViewRow selectedRow)
        {
            this.abmControl.retrieveInfoFrom(selectedRow);
        }
    }
}
