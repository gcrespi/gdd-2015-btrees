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
using AerolineaFrba.Filtros;
using AerolineaFrba.Abm;

namespace AerolineaFrba.Plantillas
{
    public enum TipoListado { Detalle, Modif, Baja };
    
    public partial class ListadoForm : Form
    {
        private TipoListado tipo;
        private AbstractBMDFactory bmdFactory;
        private FiltroControl filtroCtrl;

        public ListadoForm(FiltroControl filtroCtrl, AbstractBMDFactory bmdFactory)
        {
            InitializeComponent();
            this.filtroCtrl = filtroCtrl;
            this.bmdFactory = bmdFactory;

            filtroCtrl.drawIn(this);
        }

        public void setTipo(TipoListado tipo)
        { 
            this.tipo = tipo;
        }

        private void agregarColumna()
        {
            var columnaDetalles = new DataGridViewButtonColumn();
            {
                columnaDetalles.Text = bmdFactory.nameButtonAccess();
                columnaDetalles.UseColumnTextForButtonValue = true;
                columnaDetalles.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                columnaDetalles.FlatStyle = FlatStyle.Standard;
                columnaDetalles.CellTemplate.Style.BackColor = Color.Honeydew;
            }
            DataGrid.Columns.Add(columnaDetalles);
        }

        private void llenarGrilla(String whereClause)
        {
            DataGrid.DataSource = null;
            DataGrid.Columns.Clear();

            DataTable dt = new DataTable();
            string strProc = filtroCtrl.ProcedureName();

            using (var da = new sql.SqlDataAdapter(strProc, Conexion.strCon))
            {
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@WhereClause", whereClause);

                da.Fill(dt);
                DataGrid.DataSource = dt;
            }
        }

        private void DataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                var frm = bmdFactory.create(senderGrid.Rows[e.RowIndex]);
                Program.main.addForm(frm);
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.llenarGrilla(filtroCtrl.whereClause());
            this.agregarColumna();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            filtroCtrl.limpiar();
        }

        private void ListadoForm_Load(object sender, EventArgs e)
        {
           
        }

        public void buscar()
        {
            btnBuscar.PerformClick();
        }

        private void ListadoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
    }
}
