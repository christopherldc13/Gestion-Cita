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
        public static string Insertar(int pIdUsuario, string pUsuario, string pClave, int pIdRol,
         string pEstado, int pIdEmpleado)
        {
            CDUsuario objUsuario = new CDUsuario();
            objUsuario.IdUsuario = pIdUsuario;
            objUsuario.Usuario = pUsuario;
            objUsuario.Clave = pClave;
            objUsuario.IdRol = pIdRol;
            objUsuario.Estado = pEstado;
            objUsuario.IdEmpleado = pIdEmpleado;
            return objUsuario.Insertar(objUsuario);
        } 
        public static string Actualizar(int pIdUsuario, string pUsuario, string pClave, int pIdRol,
         string pEstado, int pIdEmpleado)
        {
            CDUsuario objUsuario = new CDUsuario();
            objUsuario.IdUsuario = pIdUsuario;
            objUsuario.Usuario = pUsuario;
            objUsuario.Clave = pClave;
            objUsuario.IdRol = pIdRol;
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

        public (string mensaje, string rol) AutenticarUsuario(string usuario, string clave)
        {
            CDUsuario objUsuario = new CDUsuario();
            return objUsuario.AutenticarUsuario(usuario, clave);
        }
    }
}
