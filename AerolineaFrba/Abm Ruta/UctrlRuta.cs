using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using sql = System.Data.SqlClient;
using System.Data.SqlClient;
using AerolineaFrba.Abm;

namespace AerolineaFrba.Abm_Ruta
{
    public partial class UctrlRuta : UserControl, IAbmControl
    {
        private int _codigoRutaAnterior;
        private HashSet<int> _serviciosCheckeadosAnterior = new HashSet<int>();
        private Int16 _ciudadOrigenAnterior = 0;
        private Int16 _ciudadDestinoAnterior = 0;
        private Decimal _precioPasajeAnterior = 0;
        private Decimal _precioEncomiendaAnterior = 0;

        private List<int> serviciosRefs;
        private int rutaID = 0;
        private DataTable serviciosTable = new DataTable();
        private DataTable ciudadesOrigen = new DataTable();
        private DataTable ciudadesDestino = new DataTable();

        public int RutaID { get { return rutaID; } }
        public int CodigoRuta { get { return numCodigoRuta.TextValue; } }
        public Int16 CiudadOrigenKey { get { return (Int16)cboCiudadOrigen.SelectedValue; } }
        public Int16 CiudadDestinoKey { get { return (Int16)cboCiudadDestino.SelectedValue; } }
        public Decimal PrecioBEnc 
        {
            get 
            {
                Decimal _ble;
                Decimal.TryParse(dcmPrecioBEnc.Text, out _ble);
                return _ble;
            } 
        }
        public Decimal PrecioBPas
        {
            get
            {
                Decimal _ble;
                Decimal.TryParse(dcmPrecioBPas.Text, out _ble);
                return _ble;
            }
        }
        public Boolean Activo { get { return chbHabilitado.Checked; } }

        public DataTable ServiciosCheckeados
        {
            get
            {
                DataTable _self = new DataTable();
                _self.Columns.Add("Item", typeof(int));

                foreach (DataRowView indexChecked in chlServicios.CheckedItems)
                {
                    _self.Rows.Add(indexChecked["TipoServicioID"]);
                }

                return _self;
            }
        }
        public HashSet<int> ServiciosCheckeadosSet
        {
            get
            {
                return new HashSet<int>(ServiciosCheckeados.AsEnumerable().Select(row => (int)row[0])); 
            }
        }


        public UctrlRuta()
        {
            InitializeComponent();
        }

        public bool activo()
        {
            return Activo;
        }

        public void retrieveInfoFrom(DataGridViewRow selectedRow)
        {
            this.rutaID = (int)selectedRow.Cells[0].Value;
            this.fillAttrsDefault();
            var dt = RutaAerea.getWithServicios(rutaID);

            numCodigoRuta.TextValue = Decimal.ToInt32(((Decimal)dt.Rows[0][0]));
            
            var origen =(Int16)dt.Rows[0][1];
            cboCiudadOrigen.SelectedValue = origen;
            var destino = (Int16)dt.Rows[0][2];
            cboCiudadDestino.SelectedValue = destino;

            dcmPrecioBPas.Text = ((Decimal)dt.Rows[0][3]).ToString();
            dcmPrecioBEnc.Text = ((Decimal)dt.Rows[0][4]).ToString();
            chbHabilitado.Checked = (bool)dt.Rows[0][5];
            serviciosRefs = dt.AsEnumerable().Select(row => Convert.ToInt32((byte)row[6])).ToList();

            this.checkRutaServicios();

            _codigoRutaAnterior = CodigoRuta;
            _serviciosCheckeadosAnterior = ServiciosCheckeadosSet;
            _ciudadOrigenAnterior = origen;
            _ciudadDestinoAnterior = destino;
            _precioPasajeAnterior = PrecioBPas;
            _precioEncomiendaAnterior = PrecioBEnc;
        }

        private void checkRutaServicios()
        {
            for (int i = 0; i < chlServicios.Items.Count; i++)
            {
                DataRowView view = chlServicios.Items[i] as DataRowView;
                var value = (byte)view["TipoServicioID"];

                if (serviciosRefs.Contains(value))
                    chlServicios.SetItemChecked(i, true);
            }
        }

        public void fillAttrsDefault()
        {
            ciudadesOrigen = Ciudad.ListCiudades();
            ciudadesDestino = Ciudad.ListCiudades();

            cboCiudadOrigen.DataSource = ciudadesOrigen;
            cboCiudadOrigen.DisplayMember = "Ciudad_Nombre";
            cboCiudadOrigen.ValueMember = "CiudadID";
            cboCiudadDestino.DataSource = ciudadesDestino;
            cboCiudadDestino.DisplayMember = "Ciudad_Nombre";
            cboCiudadDestino.ValueMember = "CiudadID";

            serviciosTable = TipoServicio.GetTiposDeServicio();
            chlServicios.DataSource = serviciosTable;
            chlServicios.DisplayMember = "TipoSer_Nombre";
            chlServicios.ValueMember = "TipoServicioID";

            this.limpiar_campos();
        }

        public void limpiar_campos()
        {
            cboCiudadOrigen.SelectedIndex = -1;
            cboCiudadDestino.SelectedIndex = -1;

            dcmPrecioBEnc.Text = "";
            dcmPrecioBPas.Text = "";

            numCodigoRuta.Text = "";

            foreach (int i in chlServicios.CheckedIndices)
            {
                chlServicios.SetItemCheckState(i, CheckState.Unchecked);
            }

            chbHabilitado.Checked = true;
        }

        public void blockAttrs()
        {
            cboCiudadOrigen.Enabled = false;
            cboCiudadDestino.Enabled = false;
            dcmPrecioBEnc.Enabled = false;
            dcmPrecioBPas.Enabled = false;
            chlServicios.SelectionMode = SelectionMode.None;
            chbHabilitado.Enabled = false;
            numCodigoRuta.Enabled = false;
        }

        public void blockKeyAttrs()
        {}

        public bool validateAttrsModif()
        {
            bool _conViaje = RutaAerea.tieneViajeProgramado(RutaID);
            bool _conPasaje = RutaAerea.tienePasajesVendidos(RutaID);
            bool _conEncomienda = RutaAerea.tieneEncomiendasVendidas(RutaID);

            var _self = this.validateAttrs();
            _self = this.validarTipoServicio(_conViaje) && _self;
            _self = this.validarCiudades(_conViaje) && _self;
            _self = this.validarPrecioPasaje(_conPasaje) && _self;
            _self = this.validarPrecioEncomienda(_conEncomienda) && _self;

            return _self;
        }

        private bool validarPrecioPasaje(bool _conPasaje)
        {
            lblValPrecioBPas.Text = "";

            if ((_precioPasajeAnterior != PrecioBPas) && _conPasaje)
            {
                lblValPrecioBPas.Text = "Hay pasajes vendidos \nno puede cambiar Precio!";
                return false;
            }
            return true;
        }

        private bool validarPrecioEncomienda(bool _conEncomienda)
        {
            lblValPrecioBEnc.Text = "";

            if ((_precioEncomiendaAnterior != PrecioBEnc) && _conEncomienda)
            {
                lblValPrecioBEnc.Text = "Hay encomiendas vendidas \nno puede cambiar Precio!";
                return false;
            }
            return true;
        }

        private bool validarCiudades(bool _conViaje)
        {
            lblValDestino.Text = "";
            lblValOrigen.Text = "";

            var _self = true;

            if ((_ciudadOrigenAnterior != CiudadOrigenKey) && _conViaje)
            {
                lblValOrigen.Text = "Hay viajes planeados \nno puede cambiar Origen!";
                _self = false;
            }

            if ((_ciudadDestinoAnterior != CiudadDestinoKey) && _conViaje)
            {
                lblValDestino.Text = "Hay viajes planeados \nno puede cambiar Destino!";
                _self = false;
            }

            return _self;
        }

        private bool validarTipoServicio(bool conViaje)
        {
            lblValServicio.Text = "";

            if ((!_serviciosCheckeadosAnterior.SetEquals(ServiciosCheckeadosSet)) && conViaje)
            {
                lblValServicio.Text = "Hay viajes planeados \nno puede cambiar Servicio!";
                return false;
            }
            return true;
        }



        public bool validateAttrs()
        {
            var _self = this.validarCodigoRuta();
            _self = this.validarCiudadesAlta() && _self;
            _self = this.validarServiciosAlta() && _self;
            _self = this.validarPreciosAlta() && _self;

            return _self;
        }

        private bool validarPreciosAlta()
        {
            lblValPrecioBPas.Text = "";

            if (PrecioBPas == 0 || PrecioBEnc == 0)
            {
                lblValPrecioBPas.Text = "Los precios no pueden ser nulos!";
                return false;
            }
            return true;
        }

        private bool validarServiciosAlta()
        {
            lblValServicio.Text = "";

            if (!ServiciosCheckeadosSet.Any())
            {
                lblValServicio.Text = "Debe elegir al menos un Servicio!";
                return false;
            }
            return true;
        }

        private bool validarCiudadesAlta()
        {
            lblValOrigen.Text = "";

            if (cboCiudadOrigen.SelectedIndex == -1 || cboCiudadDestino.SelectedIndex == -1)
            {
                lblValOrigen.Text = "Origen y Destino son obligatorios!";
                return false;
            }

            if (CiudadDestinoKey == CiudadOrigenKey)
            {
                lblValOrigen.Text = "El Origen no puede ser la misma ciudad de Destino!";
                return false;
            }

            return true;
        }

        private bool validarCodigoRuta()
        {
            lblValCodigoRuta.Text = "";

            if (CodigoRuta == 0)
            {
                lblValCodigoRuta.Text = "Codigo de Ruta debe ser distinto de 0!";
                return false;
            }

            if (this.cambioCodigoRuta() && RutaAerea.codigoRutaYaExistente(this))
            {
                lblValCodigoRuta.Text = "Codigo de Ruta Repetido!";
                return false;
            }

            return true;
        }

        private bool cambioCodigoRuta()
        {
            return rutaID == 0 || _codigoRutaAnterior!= CodigoRuta;
        }



        public void darModif()
        {
            RutaAerea.darModif(this);
        }

        public void darBaja()
        {
            RutaAerea.darBajaLogica(this);
        }

        public void darAlta()
        {
            RutaAerea.darAlta(this);
        }

        public String accionConcretadaMessage()
        {
            return "la Ruta: " + this.numCodigoRuta.TextValue;
        }

        public String accionRechazadaMessage()
        {
            return "la Ruta";
        }

        public void drawIn(Form aForm)
        {
            this.Location = new System.Drawing.Point(12, 12);
            this.Name = "uctrlRuta";
            this.Size = new System.Drawing.Size(761, 349);
            this.TabIndex = 7;

            aForm.Controls.Add(this);
            aForm.Controls.SetChildIndex(this, 0);
        }

        public bool validateBaja()
        {
            DialogResult dialogResult = MessageBox.Show("Esta seguro que desea dar de baja esta Ruta Aerea?, en caso afirmativo se cancelaran todos las ventas asociadas a ella.", "Baja Ruta Aerea", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return dialogResult == DialogResult.Yes;
        }

    }
}
