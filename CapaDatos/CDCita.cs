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
    public class CDCita
    {
        private int dIdCita, dIdCliente, dIdEmpleado, dIdServicio, dPrecio;
        private String dEstado;
        private DateTime dFecha, dHora;

        public CDCita() { }
        public CDCita(int pIdCita, int pIdCliente, int pIdEmpleado, DateTime pFecha,
                      DateTime pHora, int pIdServicio, int pPrecio,string pEstado)
        {
            this.dIdCita = pIdCita;
            this.dIdCliente = pIdCliente;
            this.dIdEmpleado = pIdEmpleado;
            this.dFecha = pFecha;
            this.dHora = pHora;
            this.dIdServicio = pIdServicio;
            this.dPrecio = pPrecio;
            this.dEstado = pEstado;
        }
        public int IdCita
        {
            get { return dIdCita; }
            set { dIdCita = value; }
        }

        public int IdCliente
        {
            get { return dIdCliente; }
            set { dIdCliente = value; }
        }

        public int IdEmpleado
        {
            get { return dIdEmpleado; }
            set { dIdEmpleado = value; }
        }
        public DateTime Fecha
        {
            get { return dFecha; }
            set { dFecha = value; }
        }

        public DateTime Hora
        {
            get { return dHora; }
            set { dHora = value; }
        }

        public int IdServicio
        {
            get { return dIdServicio; }
            set { dIdServicio = value; }
        }

        public int Precio
        {
            get { return dPrecio; }
            set { dPrecio = value; }
        }
      
        public string Estado
        {
            get { return dEstado; }
            set { dEstado = value; }
        }


        public string Insertar(CDCita objCita)
        {
            string mensaje = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = ConexionDB.miconexion;
                SqlCommand micomando = new SqlCommand("CitaInsertar", sqlCon);
                sqlCon.Open();
                micomando.CommandType = CommandType.StoredProcedure;
                micomando.Parameters.AddWithValue("@pIdCliente", objCita.IdCliente);
                micomando.Parameters.AddWithValue("@pIdEmpleado", objCita.IdEmpleado);
                micomando.Parameters.AddWithValue("@pFecha", objCita.Fecha);
                micomando.Parameters.AddWithValue("@pHora", objCita.Hora);
                micomando.Parameters.AddWithValue("@pIdServicio", objCita.IdServicio);
                micomando.Parameters.AddWithValue("@pPrecio", objCita.Precio);
                micomando.Parameters.AddWithValue("@pEstado", objCita.Estado);

                SqlParameter outputParamIdCita = new SqlParameter("@pidcita", SqlDbType.Int);
                outputParamIdCita.Direction = ParameterDirection.Output;
                micomando.Parameters.Add(outputParamIdCita);

                // Nuevo parámetro de retorno del stored procedure
                SqlParameter returnValueParam = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
                returnValueParam.Direction = ParameterDirection.ReturnValue;
                micomando.Parameters.Add(returnValueParam);

                // Ejecutar el comando
                micomando.ExecuteNonQuery();

                // Obtener el valor de retorno del stored procedure
                int returnValue = (int)returnValueParam.Value;

                // Verificar el valor de retorno
                if (returnValue == -1)
                {
                    throw new Exception("Ya existe una cita para este empleado en la fecha y hora seleccionada.");
                }
                else if (returnValue == 0)
                {
                    objCita.IdCita = (int)outputParamIdCita.Value;
                    mensaje = "Datos de la Cita insertados correctamente!";
                }
                else
                {
                    mensaje = "Ocurrió un error desconocido al insertar la Cita.";
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

        public string Actualizar(CDCita objCita)
        {
            string mensaje = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = ConexionDB.miconexion;
                SqlCommand micomando = new SqlCommand("CitaActualizar", sqlCon);
                sqlCon.Open();
                micomando.CommandType = CommandType.StoredProcedure;
                micomando.Parameters.AddWithValue("@pIdCita", objCita.IdCita);
                micomando.Parameters.AddWithValue("@pIdCliente", objCita.IdCliente);
                micomando.Parameters.AddWithValue("@pIdEmpleado", objCita.IdEmpleado);
                micomando.Parameters.AddWithValue("@pFecha", objCita.Fecha);
                micomando.Parameters.AddWithValue("@pHora", objCita.Hora);
                micomando.Parameters.AddWithValue("@pIdServicio", objCita.IdServicio);
                micomando.Parameters.AddWithValue("@pPrecio", objCita.Precio);
                micomando.Parameters.AddWithValue("@pEstado", objCita.Estado);

                // Parámetro de salida para capturar el código de retorno
                SqlParameter returnValue = new SqlParameter();
                returnValue.Direction = ParameterDirection.ReturnValue;
                micomando.Parameters.Add(returnValue);

                micomando.ExecuteNonQuery();

                // Capturar el valor de retorno
                int resultado = Convert.ToInt32(returnValue.Value);
                if (resultado == -1)
                {
                    mensaje = "No se puede actualizar la cita porque tiene un pago en estado 'Pendiente' o 'Pagado'.";
                }
                else if (resultado == -2)
                {
                    mensaje = "No se puede actualizar la cita porque ya fue realizada.";
                }
                else
                {
                    mensaje = "Datos de la Cita actualizados correctamente!";
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

        public DataTable CitaConsultar(String miparametro)
        {
            DataTable dt = new DataTable(); 
            SqlDataReader leerDatos; 
            try
            {
                SqlCommand sqlCmd = new SqlCommand(); 
                sqlCmd.Connection = new ConexionDB().dbconexion; 
                sqlCmd.Connection.Open(); 
                sqlCmd.CommandText = "CitaConsultar"; 
                sqlCmd.CommandType = CommandType.StoredProcedure; 
                sqlCmd.Parameters.AddWithValue("@pvalor", miparametro); 
                leerDatos = sqlCmd.ExecuteReader(); 
                dt.Load(leerDatos); 
                sqlCmd.Connection.Close(); 
            }
            catch (Exception ex)
            {
                dt = null;
            }
            return dt; 
        }

        //Muestra las citas Pendientes actuales
        public DataTable ObtenerCitasPorFechaYHora()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(ConexionDB.miconexion))
                {
                    using (SqlCommand sqlCmd = new SqlCommand("CitaObtenerPorFechaYHora", sqlCon))
                    {
                        sqlCmd.CommandType = CommandType.StoredProcedure;

                        sqlCon.Open();
                        SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);
                        sqlDa.Fill(dt);
                    }
                }
            }
            catch
            {
                dt = null; 
            }
            return dt;
        }

        //Cuadro de Pagos: Ganancias diarias
        public decimal ObtenerGananciaDiaria()
        {
            decimal ganancia = 0;
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(ConexionDB.miconexion))
                {
                    using (SqlCommand sqlCmd = new SqlCommand("ObtenerGananciaDiariaActual", sqlCon))
                    {
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCon.Open();

                        object resultado = sqlCmd.ExecuteScalar();
                        if (resultado != DBNull.Value)
                        {
                            ganancia = Convert.ToDecimal(resultado);
                        }
                    }
                }
            }
            catch
            {
                ganancia = 0; 
            }
            return ganancia;
        }

        public decimal ObtenerGananciasMensuales()
        {
            decimal ganancia = 0;
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(ConexionDB.miconexion))
                {
                    using (SqlCommand sqlCmd = new SqlCommand("ObtenerGananciasMensuales", sqlCon))
                    {
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCon.Open();

                        object resultado = sqlCmd.ExecuteScalar();
                        if (resultado != DBNull.Value)
                        {
                            ganancia = Convert.ToDecimal(resultado);
                        }
                    }
                }
            }
            catch
            {
                ganancia = 0; 
            }
            return ganancia;
        }

        public decimal ObtenerGananciasSemanales()
        {
            decimal ganancia = 0;
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(ConexionDB.miconexion))
                {
                    using (SqlCommand sqlCmd = new SqlCommand("ObtenerGananciasSemanales", sqlCon))
                    {
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCon.Open();

                        object resultado = sqlCmd.ExecuteScalar();
                        if (resultado != DBNull.Value)
                        {
                            ganancia = Convert.ToDecimal(resultado);
                        }
                    }
                }
            }
            catch
            {
                ganancia = 0; 
            }
            return ganancia;
        }

        public int ObtenerCitasRealizadasHoy()
        {
            int cantidadCitas = 0;
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(ConexionDB.miconexion))
                {
                    using (SqlCommand sqlCmd = new SqlCommand("CitasRealizadasHoy", sqlCon))
                    {
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCon.Open();

                        object resultado = sqlCmd.ExecuteScalar();
                        if (resultado != DBNull.Value)
                        {
                            cantidadCitas = Convert.ToInt32(resultado);
                        }
                    }
                }
            }
            catch
            {
                cantidadCitas = 0; 
            }
            return cantidadCitas;
        }

        public int ObtenerCitasPendientesHoy()
        {
            int cantidadCitas = 0;
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(ConexionDB.miconexion))
                {
                    using (SqlCommand sqlCmd = new SqlCommand("CitasPendientesHoy", sqlCon))
                    {
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCon.Open();

                        object resultado = sqlCmd.ExecuteScalar();
                        if (resultado != DBNull.Value)
                        {
                            cantidadCitas = Convert.ToInt32(resultado);
                        }
                    }
                }
            }
            catch
            {
                cantidadCitas = 0; // Si ocurre un error, devuelve 0.
            }
            return cantidadCitas;
        }

        //Pendiente de revision
        public void ActualizarEstadoCitaNoRealizadaSilencioso()
        {
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = ConexionDB.miconexion;  // Asegúrate de que esta cadena de conexión esté configurada correctamente
                SqlCommand micomando = new SqlCommand("ActualizarEstadoCitaNoRealizada", sqlCon);
                micomando.CommandType = CommandType.StoredProcedure;

                sqlCon.Open();

                micomando.ExecuteNonQuery();
            }
            catch (SqlException)
            {

            }
            catch (Exception)
            {

            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();
            }
        }

        //Pendiente de revisar
        public DataTable CargarEmpleadosComboBox()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(ConexionDB.miconexion))
                {
                    using (SqlCommand sqlCmd = new SqlCommand("CargarEmpleadoComboBox", sqlCon))
                    {
                        sqlCon.Open();
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd))
                        {
                            sqlDa.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en CargarEmpleadosComboBox: {ex.Message}");
                dt = null;
            }
            return dt;
        }

        //Cuadro de Cita: PENDIENTE, REALIZADO Y CANCELADO
        public void ObtenerEstadisticasCitasDeHoy(out int pendientes, out int realizadas, out int canceladas)
        {
            pendientes = realizadas = canceladas = 0;

            using (SqlConnection sqlCon = new SqlConnection(ConexionDB.miconexion))
            {
                SqlCommand cmd = new SqlCommand("EstadisticasCitasHoy", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Pendientes", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@Realizadas", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@Canceladas", SqlDbType.Int).Direction = ParameterDirection.Output;

                try
                {
                    sqlCon.Open();
                    cmd.ExecuteNonQuery();

                    pendientes = Convert.ToInt32(cmd.Parameters["@Pendientes"].Value);
                    realizadas = Convert.ToInt32(cmd.Parameters["@Realizadas"].Value);
                    canceladas = Convert.ToInt32(cmd.Parameters["@Canceladas"].Value);
                }
                catch
                {
                    pendientes = realizadas = canceladas = -1;  // Valor de error en caso de fallo
                }
            }
        }

        //Grafico de cargar citas Cancelada y Realizadas en el año
        public DataTable ObtenerCitasPorEstadoYMes()
        {
            DataTable dtResultado = new DataTable();
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon.ConnectionString = ConexionDB.miconexion;
                SqlCommand sqlCmd = new SqlCommand("ObtenerCitasPorEstadoYMes", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);
                sqlDa.Fill(dtResultado);
            }
            catch (Exception ex)
            {
                dtResultado = null;
                Console.WriteLine("Error al obtener citas por estado y mes: " + ex.Message);
            }

            return dtResultado;
        }
    }
}