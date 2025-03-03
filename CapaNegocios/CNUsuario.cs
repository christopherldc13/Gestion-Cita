using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using CapaDatos;
using System.Windows.Forms;

namespace CapaNegocios
{
    public class CNUsuario
    {
        public static string Insertar(int pIdUsuario, string pUsuario, string pClave, string pRole,
         string pEstado, int pIdEmpleado)
        {
            CDUsuario objUsuario = new CDUsuario();
            objUsuario.IdUsuario = pIdUsuario;
            objUsuario.Usuario = pUsuario;
            objUsuario.Clave = pClave;
            objUsuario.Role = pRole;
            objUsuario.Estado = pEstado;
            objUsuario.IdEmpleado = pIdEmpleado;
            return objUsuario.Insertar(objUsuario);
        } 
        public static string Actualizar(int pIdUsuario, string pUsuario, string pClave, string pRole,
         string pEstado, int pIdEmpleado)
        {
            CDUsuario objUsuario = new CDUsuario();
            objUsuario.IdUsuario = pIdUsuario;
            objUsuario.Usuario = pUsuario;
            objUsuario.Clave = pClave;
            objUsuario.Role = pRole;
            objUsuario.Estado = pEstado;
            objUsuario.IdEmpleado = pIdEmpleado;

            return objUsuario.Actualizar(objUsuario);
        } 

        public DataTable ObtenerUsuario(string miparametro)
        {
            CDUsuario objUsuario = new CDUsuario();
            DataTable dt = new DataTable(); 
            dt = objUsuario.UsuarioConsultar(miparametro);
            return dt; 
        }

        public bool AutenticarUsuario(string usuario, string clave)
        {
            bool autenticado = false;
            CDUsuario objUsuario = new CDUsuario();
            try
            {
                autenticado = objUsuario.AutenticarUsuario(usuario, clave);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al autenticar usuario desde la capa de negocios: " + ex.Message);
            }
            return autenticado;
        }
    }
}
