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
    public class CNCliente
    {
        public static string Insertar(int pIdCliente, string pNombre, string pApellido, string pTelefono,
         string pCorreo, string pEstado)
        {
            CDCliente objCliente = new CDCliente();
            objCliente.IdCliente = pIdCliente;
            objCliente.Nombre = pNombre;
            objCliente.Apellido = pApellido;
            objCliente.Telefono = pTelefono;
            objCliente.Correo = pCorreo;
            objCliente.Estado = pEstado;
            return objCliente.Insertar(objCliente);
        } 

        public static string Actualizar(int pIdCliente, string pNombre, string pApellido, string pTelefono,
         string pCorreo, string pEstado)
        {
            CDCliente objCliente = new CDCliente();
            objCliente.IdCliente = pIdCliente;
            objCliente.Nombre = pNombre;
            objCliente.Apellido = pApellido;
            objCliente.Telefono = pTelefono;
            objCliente.Correo = pCorreo;
            objCliente.Estado = pEstado;
            return objCliente.Actualizar(objCliente);
        } 

        public DataTable ObtenerCliente(string miparametro)
        {
            CDCliente objCliente = new CDCliente();
            DataTable dt = new DataTable(); 
            dt = objCliente.ClienteConsultar(miparametro);
            return dt; 
        }

        //Cuadro de Cliente: Cliente activos
        public static int ObtenerCantidadClientesActivos()
        {
            CDCliente objCliente = new CDCliente();
            return objCliente.ObtenerCantidadClientesActivos();
        }

    }
}
