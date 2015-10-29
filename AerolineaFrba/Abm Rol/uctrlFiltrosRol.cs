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

namespace AerolineaFrba.Abm_Rol
{
    public partial class uctrlFiltrosRol : UserControl
    {
        private List<Filtro> filtros;
        private DataTable funcionalidadesTable;
        
        public String ProcedureName { get { return "THE_BTREES.Listar_Roles"; } }

        public uctrlFiltrosRol()
        {
            InitializeComponent();
            filtros = new List<Filtro>();
            filtros.Add(new FiltroChb(chbHabilitado, "r.Rol_Activo"));
            filtros.Add(new FiltroTxt(txtNombre, "r.Rol_Nombre"));
            filtros.Add(new FiltroChlb<byte>(chlFuncionalidades, "fr.FuncionalidadRef"));

            this.fillFuncionalidades();
            this.limpiar();
        }

        public void fillFuncionalidades()
        {
            funcionalidadesTable = Funcionalidades.listFuncionalidades();
            chlFuncionalidades.DataSource = funcionalidadesTable;
            chlFuncionalidades.DisplayMember = "Funcionalidad_Nombre";
            chlFuncionalidades.ValueMember = "FuncionalidadID";
        }

        public string whereClause()
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

        public void limpiar()
        {
            filtros.ForEach(f => f.limpiar());
        }
    }
}
