using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestor_de_Citas
{
    static class Program
    {
        //Variables globales para todo el proyecto/solución.
        public static int vidCliente = 0; 
        public static int vidEmpleado = 0;
        public static int vidEmpresa = 0;
        public static int vidUsuario = 0;
        public static int vidCita = 0;
        public static int vidPago = 0;
        public static int vidServicio = 0;
        public static string usuario = "";

        public static int vidDepto = 0; //colocar una por cada clave primaria que tengamos
                                        //en nuestra base de datos
        public static bool nuevo = false; //variable usada para identificar si se trabaja con
                                          //un nuevo dato o no
        public static bool modificar = false; //variable usada para identificar si se está
                                              //modificando un dato o no
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
            //Application.Run(new Log_in());
        }

    }
}
