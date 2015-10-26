using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using sql = System.Data.SqlClient;
using System.Data.SqlClient;

namespace AerolineaFrba.Abm_Rol
{
    public partial class uctrlRol : UserControl
    {

        private DataTable funcionalidadesTable = new DataTable();

        public uctrlRol()
        {
            InitializeComponent();
        }

        public void retrieve_info_from(int rolID)
        { 
            //retrieve info
        }

        

        public void fill_funcionalidades()
        {
            string query = "SELECT * FROM THE_BTREES.Funcionalidades";

            using (var da = new sql.SqlDataAdapter(query, Conexion.strCon))
            {
                da.SelectCommand.CommandType = CommandType.Text;
                da.Fill(funcionalidadesTable);
                chlFuncionalidades.DataSource = funcionalidadesTable;
                chlFuncionalidades.DisplayMember = "Funcionalidad_Nombre";
                chlFuncionalidades.ValueMember = "FuncionalidadID";
            }
        }

        public void limpiar_campos()
        {
            txtNombre.Text = "";
            foreach (int i in chlFuncionalidades.CheckedIndices)
            {
                chlFuncionalidades.SetItemCheckState(i, CheckState.Unchecked);
            }
        }


        public DataTable funcionalidadesCheckeadas()
        {
            DataTable _self = new DataTable();
            _self.Columns.Add("Item", typeof(int));

            foreach (DataRowView indexChecked in chlFuncionalidades.CheckedItems)
            {
                _self.Rows.Add(indexChecked["FuncionalidadID"]);
            }

            return _self;
        }
    }
}
