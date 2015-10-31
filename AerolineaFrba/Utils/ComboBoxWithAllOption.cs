using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba.Utils
{
    class ComboBoxWithAllOption : ComboBox
    {
        public DataTable DataTableSource
        { 
            get { return (DataTable)DataSource;}
            set 
            {
                DataSource = value;

                if (DataSource == null)
                    return;

                DataRow row = ((DataTable)DataSource).NewRow();
                row[1] = "<Todos>";
                ((DataTable)base.DataSource).Rows.Add(row);
            }
        }

        public bool isAllSelected()
        {
            return this.SelectedIndex == this.Items.Count - 1;
        }

        public void selectAllOption()
        {
            this.SelectedIndex = this.Items.Count - 1;
        }

    }
}
