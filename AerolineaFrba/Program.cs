using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba
{
    static class Program
    {
        public static Main main;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Aca se chequea la infiguracion para determinar la terminal
            List<string> botonesDisponibles = new List<string> {"Todos", "Home", "ABM Rol", "Compras" };
            int bleh = 1;
            if (bleh == 1)
            {
                Login login = new Login();
                main = new Main(botonesDisponibles);
                if (login.ShowDialog() == DialogResult.OK) Application.Run(main);
                else Application.Exit();
            }
            else
            {
                Application.Run(main);
            }

        }

    }
}
