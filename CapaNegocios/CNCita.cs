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
    public class CNCita
    {
        //Preparamos los datos para insertar un nuevo Suplidor. A los parametros recibidos les pongo el prefijo p
        public static string Insertar(int pIdCita, int pIdCliente, int pIdBarbero, DateTime pFecha,
            DateTime pHora, string pEstado)
        {
            CDCita objCita = new CDCita();
            objCita.IdCita = pIdCita;
            objCita.IdCliente = pIdCliente;
            objCita.IdBarbero = pIdBarbero;
            objCita.Fecha = pFecha;
            objCita.Hora = pHora;
            objCita.Estado = pEstado;
            //Llamamos al método insertar del suplidor pasándole el objeto creado
            //y retornando el mensaje que indica si se pudo o no realizar la acción
            return objCita.Insertar(objCita);
        } //Fin del método Insertar
        public static string Actualizar(int pIdCita, int pIdCliente, int pIdBarbero, DateTime pFecha,
            DateTime pHora, string pEstado)
        {
            CDCita objCita = new CDCita();
            objCita.IdCita = pIdCita;
            objCita.IdCliente = pIdCliente;
            objCita.IdBarbero = pIdBarbero;
            objCita.Fecha = pFecha;
            objCita.Hora = pHora;
            objCita.Estado = pEstado;
            //Llamamos al método insertar del suplidor pasándole el objeto creado
            //y retornando el mensaje que indica si se pudo o no realizar la acción
            return objCita.Insertar(objCita);
        } //Fin del método Actualizar
          //Método utilizado para obtener un DataTable con todos los datos de la tabla
          //correspondiente
        public DataTable ObtenerCita(string miparametro)
        {
            CDCita objCita = new CDCita();
            DataTable dt = new DataTable(); //creamos un nuevo DataTable
                                            //El DataTable se llena con todos los datos devueltos
            dt = objCita.CitaConsultar(miparametro);
            return dt; //Se retorna el DataTable con los datos adquiridos
        }
    }

}