using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba.Utils
{
    public partial class NumericBox : TextBox
    {
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            base.OnKeyPress(e);
        }

        public int TextValue
        {   get { return (Text == "") ? 0 : Int32.Parse(Text);}
            set { Text = value.ToString();}
        }
    }
}
