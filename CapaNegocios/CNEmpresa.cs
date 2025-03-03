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
            return objEmpresa.Insertar(objEmpresa);
        } 
        public static string Actualizar(int pIdEmpresa, string pNombre, string pTelefono, string pDireccion,
         string pCorreo, string pLogo, string pEslogan)
        {
            CDEmpresa objEmpresa = new CDEmpresa();
            objEmpresa.IdEmpresa = pIdEmpresa;
            objEmpresa.Nombre = pNombre;
            objEmpresa.Telefono = pTelefono;
            objEmpresa.Direccion= pDireccion;
            objEmpresa.Correo = pCorreo;
            objEmpresa.Logo = pLogo;
            objEmpresa.Eslogan = pEslogan;
            return objEmpresa.Actualizar(objEmpresa);
        } 

        public DataTable ObtenerEmpresa(string miparametro)
        {
            CDEmpresa objEmpresa = new CDEmpresa();
            DataTable dt = new DataTable(); 
            dt = objEmpresa.EmpresaConsultar(miparametro);
            return dt; 
        }

        public static string ObtenerRutaLogo()
        {
            CDEmpresa objEmpresa = new CDEmpresa();
            return objEmpresa.ObtenerRutaImagenDesdeBD();
        }
    }
}
