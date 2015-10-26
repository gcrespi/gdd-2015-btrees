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
                chlFuncionalidades.ValueMember = "FuncionalidadID";
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
            //TODO agregar validaciones, userControl?

            DataTable funcionalidadesCheckeadas = new DataTable();
            funcionalidadesCheckeadas.Columns.Add("Item", typeof(int));

            foreach (DataRowView indexChecked in chlFuncionalidades.CheckedItems)
            {
                funcionalidadesCheckeadas.Rows.Add(indexChecked["FuncionalidadID"]);
            }

            using (var conn = new SqlConnection(Conexion.strCon))
            using (var command = new SqlCommand("THE_BTREES.Crear_Rol", conn)
            {
                CommandType = CommandType.StoredProcedure
            })
            {
                command.Parameters.AddWithValue("@Rol_Nombre", txtNombre.Text);

                var pList = new SqlParameter("@funcionalidadesSeleccionadas", SqlDbType.Structured);
                pList.TypeName = "THE_BTREES.IntList";
                pList.Value = funcionalidadesCheckeadas;
                command.Parameters.Add(pList);

                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Se ha Guardado el Rol: " + txtNombre.Text + " con Exito!");
                btnLimpiar.PerformClick();
                this.Close();
            }

        }
    }
}
