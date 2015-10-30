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

namespace AerolineaFrba.Abm_Ruta
{
    public partial class UctrlFiltrosRuta : UserControl, FiltroControl
    {
        private List<Filtro> filtros;
        
        public String ProcedureName() 
        {
            return "THE_BTREES.Listar_Rutas"; 
        } 

        public UctrlFiltrosRuta()
        {
            InitializeComponent();
            filtros = new List<Filtro>();
            filtros.Add(new FiltroChb(chbHabilitado, "r.Ruta_Activo"));
            filtros.Add(new FiltroCbo<Int16>(cboCiudadOrigen, "r.Ruta_CiudadOrigenRef"));
            filtros.Add(new FiltroCbo<Int16>(cboCiudadDestino, "r.Ruta_CiudadDestinoRef"));
            filtros.Add(new FiltroChlb<byte>(chlServicios, "ts.TipoServicioRef"));
            filtros.Add(new FiltroDcm(dcmPrecioBPas, "r.Ruta_PrecioBasePasaje"));
            filtros.Add(new FiltroDcm(dcmPrecioBEnc, "r.Ruta_PrecioBaseKg"));

            this.fillCiudades();
            this.limpiar();
        }


        private void fillCiudades()
        {
            var ciudadesOrigen = Ciudad.TraerCiudadesCombo();
            var ciudadesDestino = Ciudad.TraerCiudadesCombo();

            cboCiudadOrigen.DataSource = ciudadesOrigen;
            cboCiudadOrigen.DisplayMember = "Ciudad_Nombre";
            cboCiudadOrigen.ValueMember = "CiudadID";
            cboCiudadDestino.DataSource = ciudadesDestino;
            cboCiudadDestino.DisplayMember = "Ciudad_Nombre";
            cboCiudadDestino.ValueMember = "CiudadID";

            var serviciosTable = TipoServicio.GetTiposDeServicio();
            chlServicios.DataSource = serviciosTable;
            chlServicios.DisplayMember = "TipoSer_Nombre";
            chlServicios.ValueMember = "TipoServicioID";
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
