using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace AerolineaFrba.Canje_Millas
{
    public partial class CanjeMillasForm : Form
    {

        private int cantMillasDisp;
        private List<Canje> lCanjes;
        private int sumaMillas=0;
        private int idUsuario;

        public CanjeMillasForm()
        {
            InitializeComponent();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (txtDNI.Text=="" | txtApellido.Text=="")
            {
                MessageBox.Show("Debe ingresar su apellido y DNI");
                return;
            }
                   
            Millas.TraerMillasDisponible(ref cantMillasDisp, ref idUsuario,txtApellido.Text,txtDNI.Text);
            
            if (cantMillasDisp==0)
            {
                MessageBox.Show("No tiene millas disponibles");
                return;
            }
 
            dgvProductos.DataSource = Canje.ListProductosDisponibles(cantMillasDisp);
            if (dgvProductos.RowCount == 0)
            {
                MessageBox.Show("No hay ningun producto disponible para que pueda canjear con esa cantidad de millas. Lo sentimos");
                return;
            }
            groupBox2.Enabled=true;
            lblCantMillas.Text=cantMillasDisp.ToString();
        }

        private void btnCanjear_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvProductos.Rows)
            {
                if (Convert.ToBoolean(row.Cells["Seleccionar"].Value))
                {
                    if ((Convert.ToInt32(row.Cells["CantProductos"].Value)) > (Convert.ToInt32(row.Cells["Producto_Stock"].Value)))
                    {
                        MessageBox.Show("No puede canjear más productos de los disponibles en stock");
                        return;
                    }
                    Canje itm = new Canje();
                    itm.prodCantidad=Convert.ToInt32(row.Cells["CantProductos"].Value);
                    itm.prodId=Convert.ToInt32(row.Cells["ProductoID"].Value);
                    sumaMillas += itm.prodCantidad * Convert.ToInt32(row.Cells["Producto_Millas"].Value);
                    lCanjes.Add(itm);
                }
            }
            if (lCanjes.Count == 0)
            {
                MessageBox.Show("Debe seleccionar al menos un producto para canjear");
                return;
            }
            if (sumaMillas > cantMillasDisp)
            {
                MessageBox.Show("No puede realizar el canje debido a que no le alcanzan las millas que tiene disponible");
                return;
            }            
            try
                {
                    Canje.RegistrarCanjes(lCanjes,idUsuario);
                    MessageBox.Show("Canjes realizados correctamente");
                    Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Hubo un error en el proceso de canje, vuelva a intentarlo");
                }
    
        }
    }
}
