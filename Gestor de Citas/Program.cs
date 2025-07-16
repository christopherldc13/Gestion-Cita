using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestor_de_Citas
{
    static class Program
    {
        //Variables globales para todo el proyecto
        public static int vidCliente = 0; 
        public static int vidEmpleado = 0;
        public static int vidEmpresa = 0;
        public static int vidUsuario = 0;
        public static int vidCita = 0;
        public static int vidPago = 0;
        public static int vidServicio = 0;
        public static int vidRol = 0;
        public static int vidDisponibilidad = 0;
        public static string usuario = "";
        public static string copyright = "CitaExpress";
        public static string Rol = "";

        //variables globales booleanas
                                       
        public static bool nuevo = false; 
                                         
        public static bool modificar = false; 
                                              
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
