using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba
{
    public partial class Login : Form
    {
        private int usuarioID;

        public Login()
        {
            InitializeComponent();
        }

        private int idUsuarioWith(String nombre, String pass)
        {   
            int _usuarioID = 0;
            bool _usuarioActivo = false;
            bool _wrongPassword = false;

            using (var conn = new SqlConnection(Conexion.strCon))
            using (var command = new SqlCommand("THE_BTREES.CheckearUsuarioAdministrador", conn)
            {
                CommandType = CommandType.StoredProcedure
            })
            {
                // set up the parameters
                command.Parameters.Add("@UsuarioID", SqlDbType.Int).Direction = ParameterDirection.Output;
                command.Parameters.Add("@Usuario_Activo", SqlDbType.Bit).Direction = ParameterDirection.Output;
                command.Parameters.Add("@Usuario_Wrong_Password", SqlDbType.Bit).Direction = ParameterDirection.Output;

                // set parameter values
                command.Parameters.AddWithValue("@Usuario_Nombre", nombre);
                command.Parameters.AddWithValue("@Usuario_Password", pass);
                conn.Open();

                command.ExecuteNonQuery();

                // read output value from output variables
                _usuarioID = Convert.ToInt32(command.Parameters["@UsuarioID"].Value);
                _usuarioActivo = Convert.ToBoolean(command.Parameters["@Usuario_Activo"].Value);
                _wrongPassword = Convert.ToBoolean(command.Parameters["@Usuario_Wrong_Password"].Value);
                conn.Close();
            }

            return validarUsuario(_usuarioID, _usuarioActivo, _wrongPassword);
        }

        private int validarUsuario(int usuarioID, bool usuarioActivo, bool wrongPassword) 
        {   
            if (usuarioID == 0)
            {
                wrongLabel.Text = "Usuario  o contraseña incorrecto";
                return 0;
            }

            if (!usuarioActivo)
            {
                wrongLabel.Text = "Usuario Inhabilitado!";
                return 0;
            }

            if (wrongPassword)
            {
                wrongLabel.Text = "Usuario  o contraseña incorrecto";
                return 0;
            }

            return usuarioID;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            usuarioID = idUsuarioWith(usrBox.Text, passBox.Text);
            if(usuarioID != 0)
                Program.userID = usuarioID;
                this.DialogResult = DialogResult.OK;
        }

        private void usrBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter)) button1_Click(sender, e);
        }

        private void passBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter)) button1_Click(sender, e);
        }


    }
}
