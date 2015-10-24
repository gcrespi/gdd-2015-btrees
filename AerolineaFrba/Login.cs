using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private Conexion conn = null;

        private void button1_Click(object sender, EventArgs e)
        {
            if (conn == null)
            {
                conn = new Conexion();
            }
            // Falta codificar Pass con SHA256
            // Falta bloquear luego de 3 intentos
            // Averiguar como hacer que la app rompa si hay una exeption
            if (conn.existsAnyThat("SELECT Usuarios.id_usuario FROM Usuarios, Claves WHERE name = '"+ usrBox.Text +"' AND clave = '"+ passBox.Text +"' AND id_rol = 1"))
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                wrongLabel.Text = "Usuario  o contraseña incorrecto";
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            
        }


    }
}
