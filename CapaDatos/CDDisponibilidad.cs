using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data.Sql;

namespace CapaDatos
{
    public class CDDisponibilidad
    {
        private int dIdDisponibilidad, dIdEmpleado;
        private string dDiaSemana;
        private DateTime dHoraInicio, dHoraFin;

        public CDDisponibilidad() { }

        public CDDisponibilidad(int pIdDisponibilidad, int pIdEmpleado, string pDiaSemana, DateTime pHoraInicio, DateTime pHoraFin)
        {
            this.dIdDisponibilidad = pIdDisponibilidad;
            this.dIdEmpleado = pIdEmpleado;
            this.dDiaSemana = pDiaSemana;
            this.dHoraInicio = pHoraInicio;
            this.dHoraFin = pHoraFin;
        }

        public int IdDisponibilidad
        {
            get { return dIdDisponibilidad; }
            set { dIdDisponibilidad = value; }
        }

        public int IdEmpleado
        {
            get { return dIdEmpleado; }
            set { dIdEmpleado = value; }
        }

        public string DiaSemana
        {
            get { return dDiaSemana; }
            set { dDiaSemana = value; }
        }

        public DateTime HoraInicio
        {
            get { return dHoraInicio; }
            set { dHoraInicio = value; }
        }

        public DateTime HoraFin
        {
            get { return dHoraFin; }
            set { dHoraFin = value; }
        }

        public string Insertar(CDDisponibilidad objDisponibilidad)
        {
            string mensaje = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = ConexionDB.miconexion;
                SqlCommand micomando = new SqlCommand("DisponibilidadInsertar", sqlCon);
                sqlCon.Open();
                micomando.CommandType = CommandType.StoredProcedure;
                micomando.Parameters.AddWithValue("@pidempleado", objDisponibilidad.IdEmpleado);
                micomando.Parameters.AddWithValue("@pdiasemana", objDisponibilidad.DiaSemana);
                micomando.Parameters.AddWithValue("@phorainicio", objDisponibilidad.HoraInicio);
                micomando.Parameters.AddWithValue("@phorafin", objDisponibilidad.HoraFin);

                SqlParameter outputParam = new SqlParameter("@piddisponibilidad", SqlDbType.Int);
                outputParam.Direction = ParameterDirection.Output;
                micomando.Parameters.Add(outputParam);

                int resultado = micomando.ExecuteNonQuery();

                if (resultado == 1)
                {
                    mensaje = "Datos de la Disponibilidad insertados correctamente!";
                }
                else
                {
                    mensaje = "No se pudo registrar la disponibilidad.";
                }
            }
            catch (SqlException ex)
            {
                mensaje = "ADVERTENCIA: " + ex.Message;
            }
            catch (Exception ex)
            {
                mensaje = "Error: " + ex.Message;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();
            }

            Console.WriteLine(mensaje);
            return mensaje;
        }

        public string Actualizar(CDDisponibilidad objDisponibilidad)
        {
            string mensaje = "";

            try
            {
                using (SqlConnection sqlCon = new SqlConnection(ConexionDB.miconexion))
                {
                    using (SqlCommand micomando = new SqlCommand("DisponibilidadActualizar", sqlCon))
                    {
                        micomando.CommandType = CommandType.StoredProcedure;
                        micomando.Parameters.AddWithValue("@piddisponibilidad", objDisponibilidad.IdDisponibilidad);
                        micomando.Parameters.AddWithValue("@pidempleado", objDisponibilidad.IdEmpleado);
                        micomando.Parameters.AddWithValue("@pdiasemana", objDisponibilidad.DiaSemana);
                        micomando.Parameters.AddWithValue("@phorainicio", objDisponibilidad.HoraInicio);
                        micomando.Parameters.AddWithValue("@phorafin", objDisponibilidad.HoraFin);

                        sqlCon.Open();
                        int resultado = micomando.ExecuteNonQuery();

                        if (resultado > 0)
                            mensaje = "Datos de la Disponibilidad actualizados correctamente!";
                        else
                            mensaje = "No se pudo actualizar la disponibilidad.";
                    }
                }
            }
            catch (SqlException ex)
            {
                mensaje = "ADVERTENCIA: " + ex.Message;
            }
            catch (Exception ex)
            {
                mensaje = "Error: " + ex.Message;
            }

            Console.WriteLine(mensaje);
            return mensaje;
        }

        public DataTable DisponibilidadConsultar(string miparametro)
        {
            DataTable dt = new DataTable();
            SqlDataReader leerDatos;
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = new ConexionDB().dbconexion;
                sqlCmd.Connection.Open();
                sqlCmd.CommandText = "DisponibilidadConsultar"; // Asegúrate de que este procedimiento almacenado exista
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@pvalor", miparametro);
                leerDatos = sqlCmd.ExecuteReader();
                dt.Load(leerDatos);
                sqlCmd.Connection.Close();
            }
            catch (Exception ex)
            {
                dt = null;
                // O loguear el error para poder ver qué sucedió
                Console.WriteLine("Error: " + ex.Message);
            }
            return dt;
        }

        public DataTable DisponibilidadConsultarRegistro(string miparametro)
        {
            DataTable dt = new DataTable();
            SqlDataReader leerDatos;
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = new ConexionDB().dbconexion;
                sqlCmd.Connection.Open();
                sqlCmd.CommandText = "DisponibilidadConsultarRegistro"; // Asegúrate de que este procedimiento almacenado exista
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@pvalor", miparametro);
                leerDatos = sqlCmd.ExecuteReader();
                dt.Load(leerDatos);
                sqlCmd.Connection.Close();
            }
            catch (Exception ex)
            {
                dt = null;
                // O loguear el error para poder ver qué sucedió
                Console.WriteLine("Error: " + ex.Message);
            }
            return dt;
        }

    }
}
