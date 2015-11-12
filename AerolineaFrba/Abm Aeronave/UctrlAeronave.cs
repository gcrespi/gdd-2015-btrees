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
using AerolineaFrba.Utils;

namespace AerolineaFrba.Abm_Aeronave
{
    public partial class UctrlAeronave : UserControl, IAbmControl
    {
        private DataTable serviciosTable = new DataTable();

        private String _matriculaAnterior = "";
        private String _modeloAnterior;
        private String _fabricanteAnterior;

        private byte _tipoDeServicioAnterior;
        private String _fechaAltaAnterior;

        private int _butacasPasilloAnterior;
        private int _butacasVentanaAnterior;
        private int _kgsEncomiendaAnterior;

        public int RealocarViajesAeroID { get; set; }

        public bool Activo          { get; set; }

        public int AeronaveID       { get; set; }

        public String Matricula     { get { return txtMatricula.Text; } }
        public String Modelo        { get { return txtModelo.Text; } }
        public String Fabricante    { get { return txtFabricante.Text; } }

        public byte TipoDeServicio  { get { return (byte)cboServicio.SelectedValue; } }
        public String FechaAlta     { get { return dtpFechaAlta.Value.ToString("yyyy-MM-dd"); } }

        public int ButacasPasillo   { get { return Int32.Parse(upbButacaPasillo.Value.ToString()); } }
        public int ButacasVentana   { get { return Int32.Parse(upbButacaVentana.Value.ToString()); } }
        public int KgsEncomienda    { get { return Int32.Parse(upbKgs.Value.ToString()); } }

        public DateTime FechaBaja { get { return Config.dateTimeNow; } }

        public bool BajaPorFueraDeServicio { get; set; }
        public int FueraDeServicioId { get; set; }

        public UctrlAeronave()
        {
            InitializeComponent();
            RealocarViajesAeroID = 0;
        }

        public bool activo()
        {
            return Activo;
        }

        public void retrieveInfoFrom(DataGridViewRow selectedRow)
        {
            this.AeronaveID = (int)selectedRow.Cells[0].Value;
            this.fillAttrsDefault();
            DataTable dt = Avion.getWithServicioAndButacas(AeronaveID);

            var row = dt.Rows[0];

            txtMatricula.Text = (String)row["Avion_Matricula"];
            txtModelo.Text = (String)row["Avion_Modelo"];
            txtFabricante.Text = (String)row["Avion_Fabricante"];

            var servicio = (byte)row["Avion_TipoDeServicioRef"];
            cboServicio.SelectedValue = servicio;
            dtpFechaAlta.Value = (DateTime)row["Avion_FechaDeAlta"];
            dtpFechaAlta.Checked = true;

            upbButacaPasillo.Value = (int)row["Butacas_Pasillo"];
            upbButacaVentana.Value = (int)row["Butacas_Ventanilla"];
            upbKgs.Value = (Decimal)row["Avion_CantidadKgsDisponibles"];
            Activo = !(bool)row["Avion_BajaPorVidaUtil"];

            BajaPorFueraDeServicio = (bool)row["Avion_BajaPorFueraDeServicio"];

            if (BajaPorFueraDeServicio)
            {
                DataTable dtS = Avion.getLastFueraDeServicio(AeronaveID);
                
                var rowS = dtS.Rows[0];

                dtpFechaFuera.Value = (DateTime)rowS["Fuera_FechaFuera"];
                dtpFechaFuera.Checked = true;
                FueraDeServicioId = (int)rowS["FueraDeServicioId"];
            }

            lblFuera.Visible = BajaPorFueraDeServicio;
            dtpFechaFuera.Visible = BajaPorFueraDeServicio;


            _matriculaAnterior = Matricula;
            _modeloAnterior = Modelo;
            _fabricanteAnterior = Fabricante;

            _butacasPasilloAnterior = ButacasPasillo;
            _butacasVentanaAnterior = ButacasVentana;

            _fechaAltaAnterior = FechaAlta;
            _kgsEncomiendaAnterior = KgsEncomienda;
            _tipoDeServicioAnterior = TipoDeServicio;

        }

        public void fillAttrsDefault()
        {
            serviciosTable = TipoServicio.GetTiposDeServicio();
            cboServicio.DataSource = serviciosTable;
            cboServicio.DisplayMember = "TipoSer_Nombre";
            cboServicio.ValueMember = "TipoServicioID";

            this.limpiar_campos();
        }

        public void limpiar_campos()
        {
            txtMatricula.Text = "";
            txtModelo.Text = "";
            txtFabricante.Text = "";
            
            cboServicio.SelectedIndex = -1;
            dtpFechaAlta.Value = Config.dateTimeNow;
            dtpFechaAlta.Checked = true;

            upbButacaPasillo.Value = 1;
            upbButacaVentana.Value = 1;
            upbKgs.Value = 1;
        }

        public void blockAttrs()
        {

            txtMatricula.Enabled = false;
            txtModelo.Enabled = false;
            txtFabricante.Enabled = false;

            cboServicio.Enabled = false;
            dtpFechaAlta.Enabled = false;
            dtpFechaAlta.Enabled = false;

            upbButacaPasillo.Enabled = false;
            upbButacaVentana.Enabled = false;
            upbKgs.Enabled = false;
        }

        public void blockKeyAttrs()
        {

        }

        public void darModif()
        {
            Avion.darModif(this);
        }

        public void darBaja()
        {
            Avion.darBajaLogica(this);
        }

        public void darAlta()
        {
            Avion.darAlta(this);
        }

        public String accionConcretadaMessage()
        {
            return "la Aeronave: " + this.Matricula;
        }

        public String accionRechazadaMessage()
        {
            return "la Aeronave";
        }

        public void drawIn(Form aForm)
        {
            this.Location = new System.Drawing.Point(12, 12);
            this.Name = "uctrlRolModif";
            this.Size = new System.Drawing.Size(761, 349);
            this.TabIndex = 7;

            aForm.Controls.Add(this);
            aForm.Controls.SetChildIndex(this, 0);
        }

        public bool validateBaja()
        {
            if (!Avion.tieneViajeAsignado(AeronaveID))
                return true;

            var decision = new DecisionBajaAeronaveForm().ShowDialog();

            switch (decision)
            {
                case DialogResult.OK:
                    RealocarViajesAeroID = Avion.VerificarSiHayAvionParaReemplazar(AeronaveID);
                    if (RealocarViajesAeroID > 0)
                    {
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("No existe ninguna Aeronave que pueda reemplazarlo!", "Sin Reemplazo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    break;

                case DialogResult.Yes:
                    RealocarViajesAeroID = 0;
                    return true;                  
            }
            return false;
        }

        public bool validateAttrsModif()
        {
            if (this.validateAttrs())
                return false;

            bool tieneViajeAsignado = Avion.tieneViajeAsignado(AeronaveID);

            bool _self = validateFabricanteModif(tieneViajeAsignado);
            _self = validateModeloModif(tieneViajeAsignado) && _self;
            _self = validateTipoServicioModif(tieneViajeAsignado) && _self;
            _self = validateButacasPasillo(tieneViajeAsignado) && _self;
            _self = validateButacasVentana(tieneViajeAsignado) && _self;
            _self = validateKgs(tieneViajeAsignado) && _self;
            
            return _self;
        }

        private bool validateFabricanteModif(bool tieneViajeAsignado)
        {
            lblValFabricante.Text = "";

            if (_fabricanteAnterior != Fabricante && tieneViajeAsignado)
            {
                lblValFabricante.Text = "Fabricante no puede cambiar si tiene viajes asignados!";
                return false;
            }
            return false;
        }

        private bool validateModeloModif(bool tieneViajeAsignado)
        {
            lblValModelo.Text = "";

            if (_modeloAnterior != Modelo && tieneViajeAsignado)
            {
                lblValModelo.Text = "Modelo no puede cambiar si tiene viajes asignados!";
                return false;
            }
            return false;
        }

        private bool validateTipoServicioModif(bool tieneViajeAsignado)
        {
            lblValServicio.Text = "";

            if (_tipoDeServicioAnterior != TipoDeServicio && tieneViajeAsignado)
            {
                lblValServicio.Text = "Servicio no puede cambiar si tiene viajes asignados!";
                return false;
            }
            return false;
        }


        private bool validateButacasPasillo(bool tieneViajeAsignado)
        {
            lblValButacasPasillo.Text = "";

            if (_butacasPasilloAnterior != ButacasPasillo && tieneViajeAsignado)
            {
                lblValButacasPasillo.Text = "Butacas Pasillo no puede cambiar si tiene viajes asignados!";
                return false;
            }
            return false;
        }

        private bool validateButacasVentana(bool tieneViajeAsignado)
        {
            lblValButacasVentana.Text = "";

            if (_butacasVentanaAnterior != ButacasVentana && tieneViajeAsignado)
            {
                lblValButacasVentana.Text = "Butacas Ventana no puede cambiar si tiene viajes asignados!";
                return false;
            }
            return false;
        }

        private bool validateKgs(bool tieneViajeAsignado)
        {
            lblValKgs.Text = "";

            if (_kgsEncomiendaAnterior != KgsEncomienda && tieneViajeAsignado)
            {
                lblValKgs.Text = "Kgs max de Encomienda no puede cambiar\n si tiene viajes asignados!";
                return false;
            }
            return false;
        }


        public bool validateAttrs()
        {
            var _self = validateMatricula();
            _self = validateFabricante() && _self;
            _self = validateModelo() && _self;

            _self = validateTipoServicio() && _self;
            _self = validateButacasPasillo() && _self;

            _self = validateButacasVentana() && _self;
            _self = validateKgsEncomienda() && _self;

            return _self;
        }

        private bool validateFabricante()
        {
            lblValFabricante.Text = "";

            if (Fabricante == "")
            {
                lblValFabricante.Text = "Debe indicar Fabricante!";
                return false;
            }
            return true;
        }

        private bool validateModelo()
        {
            lblValModelo.Text = "";

            if (Modelo == "")
            {
                lblValModelo.Text = "Debe indicar Modelo!";
                return false;
            }
            return true;
        }

        private bool validateTipoServicio()
        {
            lblValServicio.Text = "";

            if (cboServicio.SelectedIndex  == -1)
            {
                lblValServicio.Text = "Debe indicar Servicio!";
                return false;
            }
            return true;
        }

        private bool validateButacasPasillo()
        {
            lblValButacasPasillo.Text = "";

            if (ButacasPasillo == 0)
            {
                lblValButacasPasillo.Text = "Debe indicar más de 0 Butacas Pasillo!";
                return false;
            }
            return true;
        }

        private bool validateButacasVentana()
        {
            lblValButacasVentana.Text = "";

            if (ButacasVentana == 0)
            {
                lblValButacasVentana.Text = "Debe indicar más de 0 Butacas Ventana!";
                return false;
            }
            return true;
        }

        private bool validateKgsEncomienda()
        {
            lblValKgs.Text = "";

            if (KgsEncomienda == 0)
            {
                lblValKgs.Text = "Debe indicar capacidad en Kgs para Encomiendas!";
                return false;
            }
            return true;
        }

        public bool validateMatricula()
        {
            lblValMatricula.Text = "";

            if(txtMatricula.Text == "")
            {
                lblValMatricula.Text = "Debe ingresar una matrícula!";
                return false;
            }

            if (_matriculaAnterior != Matricula && Avion.matriculaYaExistente(Matricula))
            {
                lblValMatricula.Text = "La matricula debe ser única!";
                return false;
            }
            return true;
        }

        internal object cambioButacas()
        {
            return _butacasPasilloAnterior != ButacasPasillo || _butacasVentanaAnterior != ButacasVentana;
        }
    }
}
