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
        public static string Insertar(int pIdCita, int pIdCliente, int pIdEmpleado, DateTime pFecha,
            DateTime pHora, int pIdServicio, string pEstado)
        {
            CDCita objCita = new CDCita();
            objCita.IdCita = pIdCita;
            objCita.IdCliente = pIdCliente;
            objCita.IdEmpleado = pIdEmpleado;
            objCita.Fecha = pFecha;
            objCita.Hora = pHora;
            objCita.IdServicio = pIdServicio;
            objCita.Estado = pEstado;
            return objCita.Insertar(objCita);
        } 
        public static string Actualizar(int pIdCita, int pIdCliente, int pIdEmpleado, DateTime pFecha,
            DateTime pHora, int pIdServicio, string pEstado)
        {
            CDCita objCita = new CDCita();
            objCita.IdCita = pIdCita;
            objCita.IdCliente = pIdCliente;
            objCita.IdEmpleado = pIdEmpleado;
            objCita.Fecha = pFecha;
            objCita.Hora = pHora;
            objCita.IdServicio = pIdServicio;
            objCita.Estado = pEstado;
            return objCita.Actualizar(objCita);
        } 

        public DataTable ObtenerCita(string miparametro)
        {
            CDCita objCita = new CDCita();
            DataTable dt = new DataTable(); 
            dt = objCita.CitaConsultar(miparametro);
            return dt; 
        }

        public static DataTable ObtenerCitasPorFechaYHora()
        {
            try
            {
                return new CDCita().ObtenerCitasPorFechaYHora();
            }
            catch
            {
                return null; 
            }
        }
        public static decimal ObtenerGananciaDiaria()
        {
            return new CDCita().ObtenerGananciaDiaria();
        }

        public static decimal ObtenerGananciasMensuales()
        {
            return new CDCita().ObtenerGananciasMensuales();
        }

        public static decimal ObtenerGananciasSemanales()
        {
            return new CDCita().ObtenerGananciasSemanales();
        }
    }
}