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
    public partial class UctrlRol : UserControl
    {
        private DataTable funcionalidadesTable = new DataTable();

        private int rolID;
        private List<int> funcionalidadRefs;

        public int RolID { get { return rolID; } }
        public bool Activo { get { return chbHabilitado.Checked; } }
        public DataTable FuncionalidadesCheckeadas
        {
            get
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
        public String Nombre { get { return txtNombre.Text; } }

        public UctrlRol()
        {
            InitializeComponent();

        }

        public void retrieveInfoFrom(int rolID)
        {
            this.rolID = rolID;
            this.fillAttrsDefault();
            var dt = Roles.getWithFunc(rolID);

            txtNombre.Text = dt.Rows[0][0] as String;
            chbHabilitado.Checked = (bool)dt.Rows[0][2];
            funcionalidadRefs = dt.AsEnumerable().Select(x => Convert.ToInt32((byte)x[1])).ToList();

            this.checkRolFunc();
        }

        public void fillAttrsDefault()
        {
            this.limpiar_campos();

            funcionalidadesTable = Funcionalidades.listFuncionalidades();
            chlFuncionalidades.DataSource = funcionalidadesTable;
            chlFuncionalidades.DisplayMember = "Funcionalidad_Nombre";
            chlFuncionalidades.ValueMember = "FuncionalidadID";
        }

        public void limpiar_campos()
        {
            txtNombre.Text = "";

            foreach (int i in chlFuncionalidades.CheckedIndices)
            {
                chlFuncionalidades.SetItemCheckState(i, CheckState.Unchecked);
            }

            chbHabilitado.Checked = true;
        }

        public void blockAttrs()
        {
            txtNombre.Enabled = false;
            chlFuncionalidades.SelectionMode = SelectionMode.None;
            chbHabilitado.Enabled = false;
        }

        public void blockKeyAttrs()
        {

        }

        public bool validateAttrs()
        {
            var nombreVal = this.validateNombre();
            var funcionalidadesVal = this.validateFunc();

            return nombreVal && funcionalidadesVal;
        }

        private void checkRolFunc()
        {
            for (int i = 0; i < chlFuncionalidades.Items.Count; i++)
            {
                DataRowView view = chlFuncionalidades.Items[i] as DataRowView;
                var value = (byte)view["FuncionalidadID"];

                if (funcionalidadRefs.Contains(value))
                    chlFuncionalidades.SetItemChecked(i, true);                    
            }
        }

        private bool validateNombre()
        {
            lblValNombre.Text = "";

            if (txtNombre.Text == "")
            {
                lblValNombre.Text = "Debe ingresar un \n nombre de Rol!";
                return false;
            }

            if (Roles.allreadyExistWithOtherID(this))
            {
                lblValNombre.Text = "Nombre de Rol ya existente!";
                return false;
            }

            return true;
        }

        private bool validateFunc()
        {
            lblValFuncionalidades.Text = "";

            if (chlFuncionalidades.CheckedItems.Count == 0)
            {
                lblValFuncionalidades.Text = "Debe tener al menos\n una funcionalidad!";
                return false;
            }

            return true;
        }
    }
}
