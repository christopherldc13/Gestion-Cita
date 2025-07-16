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
    public class CNEmpleado
    {
        public static string Insertar(int pIdEmpleado, string pNombre, string pApellido, string pTelefono,
            //string pDisponibilidad, 
            string pEstado)
        {
            CDEmpleado objEmpleado = new CDEmpleado();
            objEmpleado.IdEmpleado = pIdEmpleado;
            objEmpleado.Nombre = pNombre;
            objEmpleado.Apellido = pApellido;
            objEmpleado.Telefono = pTelefono;
            //objEmpleado.Disponibilidad = pDisponibilidad;
            objEmpleado.Estado = pEstado;
            return objEmpleado.Insertar(objEmpleado);
        }

        public static string Actualizar(int pIdEmpleado, string pNombre, string pApellido, string pTelefono,
           // string pDisponibilidad,
            string pEstado)
        {
            CDEmpleado objEmpleado = new CDEmpleado();
            objEmpleado.IdEmpleado = pIdEmpleado;
            objEmpleado.Nombre = pNombre;
            objEmpleado.Apellido = pApellido;
            objEmpleado.Telefono = pTelefono;
            //objEmpleado.Disponibilidad = pDisponibilidad;
            objEmpleado.Estado = pEstado;
            return objEmpleado.Actualizar(objEmpleado);
        }

        public DataTable ObtenerEmpleado(string miparametro)
        {
            CDEmpleado objEmpleado = new CDEmpleado();
            DataTable dt = new DataTable(); 
            dt = objEmpleado.EmpleadoConsultar(miparametro);
            return dt; 
        }

        public static int ObtenerCantidadEmpleadosActivos()
        {
            CDEmpleado objEmpleado = new CDEmpleado();
            return objEmpleado.ObtenerCantidadEmpleadosActivos();
        }
    }
}
