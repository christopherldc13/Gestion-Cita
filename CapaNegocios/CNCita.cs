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
            DateTime pHora, int pIdServicio, int pPrecio,string pEstado)
        {
            CDCita objCita = new CDCita();
            objCita.IdCita = pIdCita;
            objCita.IdCliente = pIdCliente;
            objCita.IdEmpleado = pIdEmpleado;
            objCita.Fecha = pFecha;
            objCita.Hora = pHora;
            objCita.IdServicio = pIdServicio;
            objCita.Precio = pPrecio;
            objCita.Estado = pEstado;
            return objCita.Insertar(objCita);
        } 
        public static string Actualizar(int pIdCita, int pIdCliente, int pIdEmpleado, DateTime pFecha,
            DateTime pHora, int pIdServicio, int pPrecio, string pEstado)
        {
            CDCita objCita = new CDCita();
            objCita.IdCita = pIdCita;
            objCita.IdCliente = pIdCliente;
            objCita.IdEmpleado = pIdEmpleado;
            objCita.Fecha = pFecha;
            objCita.Hora = pHora;
            objCita.IdServicio = pIdServicio;
            objCita.Precio = pPrecio;
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

        //Muestra las citas Pendientes actuales
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

        //Cuadro de Pagos: Ganancias diarias
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

        public static int ObtenerCitasRealizadasHoy()
        {
            return new CDCita().ObtenerCitasRealizadasHoy();
        }

        public static int ObtenerCitasPendientesHoy()
        {
            return new CDCita().ObtenerCitasPendientesHoy();
        }


        public static void ActualizarEstadoCitaNoRealizada()
        {
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                // Usamos la cadena de conexión desde la clase CDCita
                sqlCon.ConnectionString = ConexionDB.miconexion;

                SqlCommand cmd = new SqlCommand("ActualizarEstadoCitaNoRealizada", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;

                // Abrir la conexión
                sqlCon.Open();

                // Ejecutar el procedimiento almacenado
                cmd.ExecuteNonQuery();
            }
            catch (SqlException)
            {
                // Aquí puedes manejar el error de forma silenciosa
                // Si no se desea hacer nada en caso de error, se puede omitir este bloque
            }
            catch (Exception)
            {
                // Si ocurren otros errores, también puedes manejarlos de la misma manera
            }
            finally
            {
                // Asegurarse de cerrar la conexión
                if (sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();
            }
        }

        public static DataTable CargarEmpleadosComboBox()
        {
            try
            {
                return new CDCita().CargarEmpleadosComboBox();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en CargarEmpleadosComboBox (Capa de Negocios): {ex.Message}");
                return null;
            }
        }

        //Cuadro de Cita: PENDIENTE, REALIZADO Y CANCELADO
        public static void ObtenerEstadisticasCitasDeHoy(out int pendientes, out int realizadas, out int canceladas)
        {
            CDCita cita = new CDCita();
            cita.ObtenerEstadisticasCitasDeHoy(out pendientes, out realizadas, out canceladas);
        }

        //Grafico de cargar citas Cancelada y Realizadas en el año
        public static DataTable ObtenerCitasPorEstadoYMes()
        {
            CDCita objCita = new CDCita();
            return objCita.ObtenerCitasPorEstadoYMes();
        }

    }
}