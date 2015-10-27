using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba.Devolucion
{
    public partial class DevolucionForm : Form
    {
        public DevolucionForm()
        {
            InitializeComponent();
        }

        private bool hayEncomiendas;
        private bool hayPasajes;
        private int idCompra;
        private List<int> listNumeroPasajesCancel = new List<int>();
        private bool cancelEco;

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtCodCompra.Text=="")
            {
                MessageBox.Show("Debe ingresar un Código de Compra para comenzar la operación");
                return;
            }
            idCompra = Convert.ToInt32(txtCodCompra.Text);
            gridPasajes.DataSource = Pasaje.TraerPasajesDeCompra(idCompra);
            hayPasajes = gridPasajes.RowCount != 0;
            txtKGEncomienda.Text = Encomienda.TraerEncomiendaKGDeCompra(idCompra).ToString();
            txtKGEncomienda.Enabled=false;
            hayEncomiendas = txtKGEncomienda.Text != Convert.ToString(0);
            if (hayEncomiendas | hayPasajes)
            {
                panel2.Enabled = true;
                gridPasajes.Enabled = hayPasajes;
                chkCancelarEnco.Enabled = hayEncomiendas;
            }
            else
            {
                MessageBox.Show("La compra no tiene pasajes ni encomiendas que sea posible cancelar");
            }
        }

        private void btnComenzar_Click(object sender, EventArgs e)
        {
            if (hayPasajes)
            {
                foreach (DataGridViewRow row in gridPasajes.Rows)
                {
                    if (Convert.ToBoolean(row.Cells["Seleccionar"].Value))
                    {
                        listNumeroPasajesCancel.Add(Convert.ToInt32(row.Cells["Codigo de Pasaje"].Value));
                    }
                }
            }
            if (chkCancelarEnco.Checked)
            {
                cancelEco = true;
            }
            if (cancelEco | listNumeroPasajesCancel.Count != 0)
            {
                try
                {
                    Cancelacion.AddNuevaCancelacion(txtMotivo.Text, idCompra, listNumeroPasajesCancel, cancelEco);
                    MessageBox.Show("Cancelacion realizada correctamente");
                    Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Hubo un error en el proceso de cancelación, vuelva a intentarlo");
                }
            }
            else
            {
                MessageBox.Show("No ha seleccionado ningun elemento para cancelar");
            }
                

        }

        private void DevolucionForm_Load(object sender, EventArgs e)
        {
            panel2.Enabled = false;
        }

    }
}
