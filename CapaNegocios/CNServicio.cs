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
    public class CNServicio
    {
        public static string Insertar(int pIdServicio, string pNombreServicio, int pPrecio, int pDuracion, string pEstado)
        {
            CDServicio objServicio = new CDServicio();
            objServicio.IdServicio = pIdServicio;
            objServicio.NombreServicio = pNombreServicio;
            objServicio.Precio = pPrecio;
            objServicio.Duracion = pDuracion;
            objServicio.Estado = pEstado;
            return objServicio.Insertar(objServicio);
        }
        public static string Actualizar(int pIdServicio, string pNombreServicio, int pPrecio, int pDuracion, string pEstado)
        {
            CDServicio objServicio = new CDServicio();
            objServicio.IdServicio = pIdServicio;
            objServicio.NombreServicio = pNombreServicio;
            objServicio.Precio = pPrecio;
            objServicio.Duracion= pDuracion;
            objServicio.Estado = pEstado;
            return objServicio.Actualizar(objServicio);
        } 

        public DataTable ObtenerServicio(string miparametro)
        {
            CDServicio objServicio = new CDServicio();
            DataTable dt = new DataTable(); 
            dt = objServicio.ServicioConsultar(miparametro);
            return dt; 
        }

        //Obtener los 3 servicios más Solicitados en Citas
        public static DataTable ObtenerTop3Servicios()
        {
            CDServicio objServicio = new CDServicio();
            return objServicio.ObtenerTop3Servicios();
        }
    }
}
