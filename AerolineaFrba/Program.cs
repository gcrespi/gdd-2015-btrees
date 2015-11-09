using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace AerolineaFrba
{
    static class Program
    {
        public static Main main { get; set; }
        public static int userID { get; set; }
        public static string terminal { get; set; }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            terminal = Config.terminal;
            if(Config.terminal == "administrativa")
            {
                Login login = new Login();
                if (login.ShowDialog() == DialogResult.OK)
                {
                    List<string> botonesDisponibles = new List<string> { "Home" };
                    DataTable dt = Funcionalidades.listFuncionalidadesDeUsuario(userID);
                    foreach (DataRow row in dt.Rows)
                    {
                        botonesDisponibles.Add(row["Funcionalidad"].ToString());
                    }
                    main = new Main(botonesDisponibles);
                    Application.Run(main);
                }
                else Application.Exit();
            }
            else
            {
                List<string> botonesDisponibles = new List<string> { "Home", "Comprar", "Consulta de Millas" };
                main = new Main(botonesDisponibles);
                Application.Run(main);
            }

        }

    }
}
