using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AerolineaFrba
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Aca se chequea la infiguracion para determinar la terminal
            int bleh = -1;
            if (bleh == 1)
            {
                Login login = new Login();
                if (login.ShowDialog() == DialogResult.OK) Application.Run(new Main());
                else Application.Exit();
            }
            else
            {
                Application.Run(new Main());
            }

        }

    }
}
