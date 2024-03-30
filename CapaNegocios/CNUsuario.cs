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
        //Preparamos los datos para insertar un nuevo Suplidor. A los parametros recibidos les pongo el prefijo p
        public static string Insertar(int pIdUsuario, string pUsuario, string pClave, string pRole,
         string pEstado, int pIdBarbero)
        {
            CDUsuario objUsuario = new CDUsuario();
            objUsuario.IdUsuario = pIdUsuario;
            objUsuario.Usuario = pUsuario;
            objUsuario.Clave = pClave;
            objUsuario.Role = pRole;
            objUsuario.Estado = pEstado;
            objUsuario.IdBarbero = pIdBarbero;
            //Llamamos al método insertar del suplidor pasándole el objeto creado
            //y retornando el mensaje que indica si se pudo o no realizar la acción
            return objUsuario.Insertar(objUsuario);
        } //Fin del método Insertar
        public static string Actualizar(int pIdUsuario, string pUsuario, string pClave, string pRole,
         string pEstado, int pIdBarbero)
        {
            CDUsuario objUsuario = new CDUsuario();
            objUsuario.IdUsuario = pIdUsuario;
            objUsuario.Usuario = pUsuario;
            objUsuario.Clave = pClave;
            objUsuario.Role = pRole;
            objUsuario.Estado = pEstado;
            objUsuario.IdBarbero = pIdBarbero;
            //Llamamos al método insertar del suplidor pasándole el objeto creado
            //y retornando el mensaje que indica si se pudo o no realizar la acción
            return objUsuario.Actualizar(objUsuario);
        } //Fin del método Actualizar
          //Método utilizado para obtener un DataTable con todos los datos de la tabla
          //correspondiente
        public DataTable ObtenerUsuario(string miparametro)
        {
            CDUsuario objUsuario = new CDUsuario();
            DataTable dt = new DataTable(); //creamos un nuevo DataTable
                                            //El DataTable se llena con todos los datos devueltos
            dt = objUsuario.UsuarioConsultar(miparametro);
            return dt; //Se retorna el DataTable con los datos adquiridos
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
                // Manejar excepciones adecuadamente, por ejemplo, registrando en un archivo de registro.
                // Aquí solo se muestra un mensaje en la consola.
                Console.WriteLine("Error al autenticar usuario desde la capa de negocios: " + ex.Message);
            }

            return autenticado;
        }


    }

}
