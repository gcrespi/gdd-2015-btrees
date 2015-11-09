using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba.Utils
{
    public partial class DisableableDate : UserControl
    {
        public DisableableDate()
        {
            InitializeComponent();
            dtpFecha.Checked = true;
            chbFecha.Checked = false;
            dtpFecha.Enabled = false;
        }

        private void checkBoxFecha_CheckedChanged(object sender, EventArgs e)
        {
            dtpFecha.Enabled = chbFecha.Checked;
        }

        public DateTime Value { 
            get { return dtpFecha.Value; }
            set { dtpFecha.Value = value; chbFecha.Checked = true; } 
        }

        public String SqlFormatDate 
        { 
            get { return this.Value.ToString("yyyy-MM-dd"); } 
        }

        public bool EnableDate 
        { 
            get { return chbFecha.Checked; } 
            set { chbFecha.Checked = value; } 
        }

        public String TextCheck
        {
            get { return chbFecha.Text; }
            set { chbFecha.Text = value; }
        }
    }
}
