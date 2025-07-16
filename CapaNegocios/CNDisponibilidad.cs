using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    // Cambié 'class' por 'public class' para hacerla accesible desde otras clases
    public class CNDisponibilidad
    {
        public static string Insertar(int pIdEmpleado, string pDiaSemana, DateTime pHoraInicio, DateTime pHoraFin)
        {
            CDDisponibilidad obj = new CDDisponibilidad();
            obj.IdEmpleado = pIdEmpleado;
            obj.DiaSemana = pDiaSemana;
            obj.HoraInicio = pHoraInicio;
            obj.HoraFin = pHoraFin;

            return obj.Insertar(obj);
        }

        public static string Actualizar(int pIdDisponibilidad, int pIdEmpleado, string pDiaSemana, DateTime pHoraInicio, DateTime pHoraFin)
        {
            CDDisponibilidad objDisponibilidad = new CDDisponibilidad();
            objDisponibilidad.IdDisponibilidad = pIdDisponibilidad;
            objDisponibilidad.IdEmpleado = pIdEmpleado;
            objDisponibilidad.DiaSemana = pDiaSemana;
            objDisponibilidad.HoraInicio = pHoraInicio;
            objDisponibilidad.HoraFin = pHoraFin;

            return objDisponibilidad.Actualizar(objDisponibilidad);
        }

        public DataTable ObtenerDisponibilidad(string miparametro)
        {
            CDDisponibilidad objDisponibilidad = new CDDisponibilidad();
            DataTable dt = new DataTable();
            dt = objDisponibilidad.DisponibilidadConsultar(miparametro);
            return dt;
        }

        public DataTable ObtenerDisponibilidadRegistro(string miparametro)
        {
            CDDisponibilidad objDisponibilidad = new CDDisponibilidad();
            DataTable dt = new DataTable();
            dt = objDisponibilidad.DisponibilidadConsultarRegistro(miparametro);
            return dt;
        }
    }
}
