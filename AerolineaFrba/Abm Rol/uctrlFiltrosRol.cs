using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AerolineaFrba.Filtros;
using AerolineaFrba.Plantillas;

namespace AerolineaFrba.Abm_Rol
{
    public partial class UctrlFiltrosRol : FiltroControl
    {
        private List<Filtro> filtros;
        private DataTable funcionalidadesTable;
        
        public override String ProcedureName() 
        { 
            return "THE_BTREES.Listar_Roles"; 
        } 

        public UctrlFiltrosRol()
        {
            InitializeComponent();
            filtros = new List<Filtro>();
            filtros.Add(new FiltroChb(chbHabilitado, "r.Rol_Activo"));
            filtros.Add(new FiltroTxt(txtNombre, "r.Rol_Nombre"));
            filtros.Add(new FiltroChlb<byte>(chlFuncionalidades, "fr.FuncionalidadRef"));

            this.fillFuncionalidades();
            this.limpiar();
        }

        private void fillFuncionalidades()
        {
            funcionalidadesTable = Funcionalidades.listFuncionalidades();
            chlFuncionalidades.DataSource = funcionalidadesTable;
            chlFuncionalidades.DisplayMember = "Funcionalidad_Nombre";
            chlFuncionalidades.ValueMember = "FuncionalidadID";
        }

        public override string whereClause()
        {
            var _self = "";

            foreach(Filtro filtro in filtros)
            {
                var _parcial = filtro.whereClause();
                if(_parcial.Length > 0)
                {
                    _self += " AND " + _parcial;
                }
            }
            return _self;
        }

        public override void limpiar()
        {
            filtros.ForEach(f => f.limpiar());
        }

        public override void callBMDForm(DataGridView senderGrid, int rowIndex, int columnIndex, TipoListado tipoForm)
        {
            var RolID = (byte)senderGrid.Rows[rowIndex].Cells[0].Value;
            Form frm;

            switch (tipoForm)
            {
                case TipoListado.Detalle:
                    frm = new DetalleRolForm(RolID);
                    break;

                case TipoListado.Modif:
                    frm = new ModifRolForm(RolID);
                    break;

                case TipoListado.Baja:
                    frm = new BajaRolForm(RolID);
                    break;

                default:
                    throw new ArgumentOutOfRangeException("TipoListado");
            }

            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }
    }
}
