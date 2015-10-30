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
        private List<int> serviciosRefs;
        private int rutaID;
        private Decimal codigoRuta;

        private DataTable serviciosTable = new DataTable();
        private DataTable ciudadesOrigen = new DataTable();
        private DataTable ciudadesDestino = new DataTable();

        public int RutaID { get { return rutaID; } }
        public Decimal CodigoRuta { get { return codigoRuta; } }
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

        public UctrlRuta()
        {
            InitializeComponent();
        }

        public void retrieveInfoFrom(DataGridViewRow selectedRow)
        {
            this.rutaID = (int)selectedRow.Cells[0].Value;
            this.fillAttrsDefault();
            var dt = RutaAerea.getWithServicios(rutaID);

            codigoRuta = (Decimal)dt.Rows[0][0];
            var origen =(Int16)dt.Rows[0][1];
            cboCiudadOrigen.SelectedValue = origen;
            var destino = (Int16)dt.Rows[0][2];
            cboCiudadDestino.SelectedValue = destino;

            dcmPrecioBPas.Text = ((Decimal)dt.Rows[0][3]).ToString();
            dcmPrecioBEnc.Text = ((Decimal)dt.Rows[0][4]).ToString();
            chbHabilitado.Checked = (bool)dt.Rows[0][5];
            serviciosRefs = dt.AsEnumerable().Select(row => Convert.ToInt32((byte)row[6])).ToList();

            this.checkRutaFunc();
        }

        private void checkRutaFunc()
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
        }

        public void blockKeyAttrs()
        {
            //TODO ver si hace falta codigo de Ruta
        }

        public bool validateAttrs()
        {
            return true; //TODO
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
            return "la Ruta: " + this.codigoRuta;
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
            //TODO Falta validación tiene Vuelos
            return chbHabilitado.Checked;
        }

    }
}
