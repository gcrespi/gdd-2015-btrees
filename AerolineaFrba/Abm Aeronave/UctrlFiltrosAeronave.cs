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

namespace AerolineaFrba.Abm_Aeronave
{
    public partial class UctrlFiltrosAeronave : UserControl, FiltroControl
    {
        private List<Filtro> filtros;
        
        public String ProcedureName() 
        { 
            return "THE_BTREES.Listar_Aviones"; 
        }

        public UctrlFiltrosAeronave()
        {
            InitializeComponent();
            filtros = new List<Filtro>();
            filtros.Add(new FiltroTxt(txtMatricula, "a.Avion_Matricula"));
            filtros.Add(new FiltroTxt(txtFabricante, "a.Avion_Fabricante"));
            filtros.Add(new FiltroTxt(txtModelo, "a.Avion_Modelo"));
            filtros.Add(new FiltroChb(chbEnBaja, "a.Avion_BajaPorVidaUtil", false));
            filtros.Add(new FiltroChb(chbFueraServicio, "a.Avion_BajaPorFueraDeServicio", false));
            filtros.Add(new FiltroCbo<byte>(cboServicios, "a.Avion_TipoDeServicioRef"));
            filtros.Add(new FiltroDtp(dtpAlta, "a.Avion_FechaDeAlta"));

            this.fillServicios();
            this.limpiar();
        }

        private void fillServicios()
        {
            var servicios = TipoServicio.TraerTiposDeServicioCombo();

            cboServicios.DataSource = servicios;
            cboServicios.DisplayMember = "TipoSer_Nombre";
            cboServicios.ValueMember = "TipoServicioID";
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

        public void drawIn(Form aForm)
        {
            this.Location = new System.Drawing.Point(12, -1);
            this.Name = "filtroCtrl";
            this.Size = new System.Drawing.Size(868, 177);
            this.TabIndex = 8;

            aForm.Controls.Add(this);
            aForm.Controls.SetChildIndex(this, 0);
        }
    }
}
