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

        public DateTime FechaBaja { get; set; }

        public bool BajaPorFueraDeServicio { get; set; }
        public int FueraDeServicioId { get; set; }

        public UctrlAeronave()
        {
            InitializeComponent();

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


        public bool validateAttrsModif()
        {
            //TODO
            return true;
        }


        public bool validateAttrs()
        {
            //TODO
            return true;
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
            this.Size = new System.Drawing.Size(770, 171);
            this.TabIndex = 7;

            aForm.Controls.Add(this);
            aForm.Controls.SetChildIndex(this, 0);
        }

        public bool validateBaja()
        {

            //TODO
            //TODO Fecha de baja la del día o dejar ingresarla
            return Activo;
        }

    }
}
