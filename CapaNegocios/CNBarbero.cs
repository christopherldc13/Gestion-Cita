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
    public class CNBarbero
    {
        public static string Insertar(int pIdBarbero, string pNombre, string pApellido, string pTelefono,
            string pDisponibilidad, string pEstado)
        {
            CDBarbero objBarbero = new CDBarbero();
            objBarbero.IdBarbero = pIdBarbero;
            objBarbero.Nombre = pNombre;
            objBarbero.Apellido = pApellido;
            objBarbero.Telefono = pTelefono;
            objBarbero.Disponibilidad = pDisponibilidad;
            objBarbero.Estado = pEstado;
            return objBarbero.Insertar(objBarbero);
        }

        public static string Actualizar(int pIdBarbero, string pNombre, string pApellido, string pTelefono,
            string pDisponibilidad, string pEstado)
        {
            CDBarbero objBarbero = new CDBarbero();
            objBarbero.IdBarbero = pIdBarbero;
            objBarbero.Nombre = pNombre;
            objBarbero.Apellido = pApellido;
            objBarbero.Telefono = pTelefono;
            objBarbero.Disponibilidad = pDisponibilidad;
            objBarbero.Estado = pEstado;
            return objBarbero.Actualizar(objBarbero);
        }

        public DataTable ObtenerBarbero(string miparametro)
        {
            CDBarbero objBarbero = new CDBarbero();
            DataTable dt = new DataTable(); //creamos un nuevo DataTable
                                            //El DataTable se llena con todos los datos devueltos
            dt = objBarbero.BarberoConsultar(miparametro);
            return dt; //Se retorna el DataTable con los datos adquiridos
        }

    }
}
