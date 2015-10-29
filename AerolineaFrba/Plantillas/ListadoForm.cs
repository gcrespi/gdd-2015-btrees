using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AerolineaFrba;
using sql = System.Data.SqlClient;

namespace AerolineaFrba.Plantillas
{
    public enum TipoListado { Detalle, Modif, Baja };

    public partial class ListadoForm : Form
    {
        protected TipoListado tipo;

        public ListadoForm()
        {
            InitializeComponent();
        }

        public void setTipo(TipoListado tipo)
        { 
            this.tipo = tipo;
        }

        protected virtual String nombreProcedure()
        {
            return "THE_BTREES.TraerDataConFiltros";
        }

        protected virtual void agregarColumna()
        {
            var columnaDetalles = new DataGridViewButtonColumn();
            {
                switch (this.tipo)
                {
                    case TipoListado.Detalle:
                        columnaDetalles.Text = "Detalles";
                        break;

                    case TipoListado.Modif:
                        columnaDetalles.Text = "Modificar";
                        break;

                    case TipoListado.Baja:
                        columnaDetalles.Text = "Eliminar";
                        break;
                }
                columnaDetalles.UseColumnTextForButtonValue = true;
                columnaDetalles.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                columnaDetalles.FlatStyle = FlatStyle.Standard;
                columnaDetalles.CellTemplate.Style.BackColor = Color.Honeydew;
            }
            DataGrid.Columns.Add(columnaDetalles);
        }

        protected virtual void llenarGrilla(String whereClause)
        {
            DataGrid.DataSource = null;
            DataGrid.Columns.Clear();

            DataTable dt = new DataTable();
            string strProc = this.nombreProcedure();

            using (var da = new sql.SqlDataAdapter(strProc, Conexion.strCon))
            {
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@WhereClause", whereClause);

                da.Fill(dt);
                DataGrid.DataSource = dt;
            }
        }

        protected virtual void DataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        { 
            
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected virtual void btnBuscar_Click(object sender, EventArgs e)
        {
            
        }

        protected virtual void btnLimpiar_Click(object sender, EventArgs e)
        {

        }
    }
}
