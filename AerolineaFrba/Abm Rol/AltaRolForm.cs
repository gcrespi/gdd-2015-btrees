using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using sql = System.Data.SqlClient;

namespace AerolineaFrba.Abm_Rol
{
    public partial class AltaRolForm : AltaForm
    {
        private DataTable funcionalidadesTable = new DataTable();
            
        public AltaRolForm()
        {
            InitializeComponent();
        }

        private void AltaRolForm_Load(object sender, EventArgs e)
        {
            this.fill_funcionalidades();
        }

        private void fill_funcionalidades()
        {
            string query = "SELECT * FROM THE_BTREES.Funcionalidades";

            using (var da = new sql.SqlDataAdapter(query, Conexion.strCon))
            {
                da.SelectCommand.CommandType = CommandType.Text;
                da.Fill(funcionalidadesTable);
                chlFuncionalidades.DataSource = funcionalidadesTable;
                chlFuncionalidades.DisplayMember = "Funcionalidad_Nombre";
            }
        }

        protected override void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombre.Text = "";
            foreach (int i in chlFuncionalidades.CheckedIndices)
            {
                chlFuncionalidades.SetItemCheckState(i, CheckState.Unchecked);
            }
        }


        protected override void btnGuardar_Click(object sender, EventArgs e)
        {
            //validar cosas
            //Grabar cosas
        }
    }
}
