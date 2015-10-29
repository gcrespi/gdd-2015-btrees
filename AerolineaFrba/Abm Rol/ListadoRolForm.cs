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
using AerolineaFrba.Plantillas;

namespace AerolineaFrba.Abm_Rol
{
    public partial class ListadoRolForm : ListadoForm
    {
        public ListadoRolForm()
        {
            InitializeComponent();
        }

        protected override String nombreProcedure()
        {
            return uctrlFiltrosRolListado.ProcedureName;
        }

        protected void ListadoForm_Load(object sender, EventArgs e)
        {
            btnBuscar.PerformClick();
        }

        protected override void btnBuscar_Click(object sender, EventArgs e)
        {
            this.llenarGrilla(uctrlFiltrosRolListado.whereClause());
            this.agregarColumna();
        }


        protected override void DataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                var RolID = (byte)senderGrid.Rows[e.RowIndex].Cells[0].Value;
                Form frm;

                switch (this.tipo)
                {
                    case TipoListado.Detalle:
                        frm = new DetalleRolForm(RolID);
                        break;

                    case TipoListado.Modif:
                        frm = new ModifRolForm(RolID);
                        break;

                    case TipoListado.Baja:
                        if (!(bool)senderGrid.Rows[e.RowIndex].Cells[2].Value)
                        {
                            MessageBox.Show("No se puede deshabilitar un Rol ya deshabilitado!", "Rol ya deshabilitado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                        frm = new BajaRolForm(RolID);
                        break;

                    default:
                        throw new ArgumentOutOfRangeException("TipoListado");
                }

                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.Show();
            }
        }

        protected override void btnLimpiar_Click(object sender, EventArgs e)
        {
            uctrlFiltrosRolListado.limpiar();
        }
    }
}
