using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba.Listado_Estadistico
{
    public partial class Estadisticas : Form
    {
        public Estadisticas()
        {
            InitializeComponent();
        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int semestre=2;
            int listado;
            if (radio1.Checked){listado = 1;}
            else if (radio2.Checked){listado = 2;}
            else if (radio3.Checked){listado = 3;}
            else if (radio4.Checked){listado = 4;}
            else {listado = 5;}

            if (radioPrimero.Checked){semestre = 1;}
            gridListado.DataSource = Estadistica.TraerEstadistica(listado, semestre, tdpAño.Value.Year);
                                        
        }


    }
}
