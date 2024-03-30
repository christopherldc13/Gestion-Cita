using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_Barberia
{
    static class Program
    {
        //Variables globales para todo el proyecto/solución.
        public static int vidCliente = 0; //variables que tomarán el valor de la clave
        public static int vidBarbero = 0;
        public static int vidEmpresa = 0;
        public static int vidUsuario = 0;
        public static int vidCita = 0;
        public static int vidPago = 0;
        //primaria de la tabla correspondiente
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
        }

    }
}
