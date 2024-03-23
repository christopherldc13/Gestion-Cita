using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using CapaDatos;

namespace CapaNegocios
{
    public class CNEmpresa
    {
        //Preparamos los datos para insertar un nuevo Suplidor. A los parametros recibidos les pongo el prefijo p
        public static string Insertar(int pIdEmpresa, string pNombre, string pTelefono, string pDireccion,
         string pCorreo, string pLogo, string pEslogan)
        {
            CDEmpresa objEmpresa = new CDEmpresa();
            objEmpresa.IdEmpresa = pIdEmpresa;
            objEmpresa.Nombre = pNombre;
            objEmpresa.Telefono = pTelefono;
            objEmpresa.Direccion = pDireccion;
            objEmpresa.Correo = pCorreo;
            objEmpresa.Logo = pLogo;
            objEmpresa.Eslogan = pEslogan;
            //Llamamos al método insertar del suplidor pasándole el objeto creado
            //y retornando el mensaje que indica si se pudo o no realizar la acción
            return objEmpresa.Insertar(objEmpresa);
        } //Fin del método Insertar
        public static string Actualizar(int pIdEmpresa, string pNombre, string pTelefono, string pDireccion,
         string pCorreo, string pLogo, string pEslogan)
        {
            CDEmpresa objEmpresa = new CDEmpresa();
            objEmpresa.IdEmpresa = pIdEmpresa;
            objEmpresa.Nombre = pNombre;
            objEmpresa.Telefono = pTelefono;
            objEmpresa.Telefono = pDireccion;
            objEmpresa.Correo = pCorreo;
            objEmpresa.Logo = pLogo;
            objEmpresa.Eslogan = pEslogan;
            //Llamamos al método insertar del suplidor pasándole el objeto creado
            //y retornando el mensaje que indica si se pudo o no realizar la acción
            return objEmpresa.Actualizar(objEmpresa);
        } //Fin del método Actualizar
          //Método utilizado para obtener un DataTable con todos los datos de la tabla
          //correspondiente
        public DataTable ObtenerEmpresa(string miparametro)
        {
            CDEmpresa objEmpresa = new CDEmpresa();
            DataTable dt = new DataTable(); //creamos un nuevo DataTable
                                            //El DataTable se llena con todos los datos devueltos
            dt = objEmpresa.EmpresaConsultar(miparametro);
            return dt; //Se retorna el DataTable con los datos adquiridos
        }
    }

}
