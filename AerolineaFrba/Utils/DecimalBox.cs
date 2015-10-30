using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba.Utils
{
    public partial class DecimalBox : TextBox
    {
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.' || e.KeyChar == ',') && (Text.IndexOf('.') > -1 || Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }

            base.OnKeyPress(e);
        }

        public Decimal TextValue 
        { 
            get
            {
                Decimal _self;
                if (Text.Contains('.'))
                    Decimal.TryParse(Text, NumberStyles.Number, CultureInfo.CreateSpecificCulture("en-US"), out _self);
                else
                    Decimal.TryParse(Text, NumberStyles.Number, CultureInfo.CreateSpecificCulture("es-AR"), out _self);
                return _self;
            }

            set
            {
                Text = value.ToString(CultureInfo.CreateSpecificCulture("es-AR"));
            }
        }

        public String DecimalText
        {
            get
            {
                return TextValue.ToString(CultureInfo.CreateSpecificCulture("en-US"));
            }
        }
    }
}
