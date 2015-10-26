using AerolineaFrba.Plantillas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba.Abm_Rol
{
    public partial class ListadoRolForm : ListadoForm
    {
        public ListadoRolForm()
        {
            InitializeComponent();
        }

        protected override String nombreTabla()
        {
            return "Roles";
        }

        protected override void llenarGrilla()
        {
            base.llenarGrilla();

            var columnaDetalles = new DataGridViewButtonColumn();
            {
                columnaDetalles.Text = "Detalles";
                columnaDetalles.UseColumnTextForButtonValue = true;
                columnaDetalles.AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.AllCells;
                columnaDetalles.FlatStyle = FlatStyle.Standard;
                columnaDetalles.CellTemplate.Style.BackColor = Color.Honeydew;
            }
            DataGrid.Columns.Add(columnaDetalles);



            //TODO agregar evento para mostrar detalles

        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                DetalleForm frmDetalle = new DetalleRolForm();//senderGrid.Rows[e.RowIndex].Cells[0]);
                frmDetalle.StartPosition = FormStartPosition.CenterScreen;
                frmDetalle.Show();
                
            }
        }
    }
}
