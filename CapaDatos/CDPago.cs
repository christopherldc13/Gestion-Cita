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
    public class CDPago
    {
        private int dIdPago, dIdCita;
        private String dConceptoPago, dEstado;

        public CDPago() { }
        public CDPago(int pIdPago, int pIdCita, string pConceptoPago, string pEstado)
        {
            this.dIdPago = pIdPago;
            this.dIdCita = pIdCita;
            this.dConceptoPago = pConceptoPago;
            this.dEstado = pEstado;
        }
        public int IdPago
        {
            get { return dIdPago; }
            set { dIdPago = value; }
        }

        public int IdCita
        {
            get { return dIdCita; }
            set { dIdCita = value; }
        }

        public string ConceptoPago
        {
            get { return dConceptoPago; }
            set { dConceptoPago = value; }
        }
        public string Estado
        {
            get { return dEstado; }
            set { dEstado = value; }
        }

        public string Insertar(CDPago objPago)
        {
            string mensaje = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = ConexionDB.miconexion;
                SqlCommand micomando = new SqlCommand("PagoInsertar", sqlCon);
                sqlCon.Open();
                micomando.CommandType = CommandType.StoredProcedure;
                micomando.Parameters.AddWithValue("@pIdCita", objPago.IdCita);
                micomando.Parameters.AddWithValue("@pConceptoPago", objPago.ConceptoPago);
                micomando.Parameters.AddWithValue("@pEstado", objPago.Estado);

                SqlParameter outputId = new SqlParameter("@pIdPago", SqlDbType.Int);
                outputId.Direction = ParameterDirection.Output;
                micomando.Parameters.Add(outputId);

                int result = micomando.ExecuteNonQuery();
                if (result > 0)
                {
                    mensaje = "Datos del Pago insertados correctamente!";
                }
                else
                {
                    mensaje = "No se pudo insertar correctamente los datos del Pago!";
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 50000) // Número de error lanzado por RAISERROR
                {
                    mensaje = "Error: Esta cita ya ha sido pagada.";
                }
                else
                {
                    mensaje = ex.Message;
                }
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();
            }
            return mensaje;
        }

        //public string Actualizar(CDPago objPago)
        //{
        //    string mensaje = "";
        //    SqlConnection sqlCon = new SqlConnection();
        //    try
        //    {
        //        sqlCon.ConnectionString = ConexionDB.miconexion;
        //        SqlCommand micomando = new SqlCommand("PagoActualizar", sqlCon);
        //        sqlCon.Open();
        //        micomando.CommandType = CommandType.StoredProcedure;
        //        micomando.Parameters.AddWithValue("@pIdPago", objPago.IdPago);
        //        micomando.Parameters.AddWithValue("@pIdCita", objPago.IdCita);
        //        micomando.Parameters.AddWithValue("@pConceptoPago", objPago.ConceptoPago);
        //        micomando.Parameters.AddWithValue("@pEstado", objPago.Estado);
        //        mensaje = micomando.ExecuteNonQuery() == 1 ? "Datos del Pago actualizados correctamente!" :
        //         "No se pudo actualizar correctamente los datos del Pago!";
        //    }
        //    catch (Exception ex)
        //    {
        //        mensaje = ex.Message;
        //    }
        //    finally
        //    {
        //        if (sqlCon.State == ConnectionState.Open)
        //            sqlCon.Close();
        //    }
        //    return mensaje;
        //}

        public string Actualizar(CDPago objPago)
        {
            string mensaje = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = ConexionDB.miconexion;
                SqlCommand micomando = new SqlCommand("PagoActualizar", sqlCon);
                sqlCon.Open();
                micomando.CommandType = CommandType.StoredProcedure;
                micomando.Parameters.AddWithValue("@pIdPago", objPago.IdPago);
                micomando.Parameters.AddWithValue("@pIdCita", objPago.IdCita);
                micomando.Parameters.AddWithValue("@pConceptoPago", objPago.ConceptoPago);
                micomando.Parameters.AddWithValue("@pEstado", objPago.Estado);

                // Ejecutar el procedimiento y obtener el valor de retorno
                int result = micomando.ExecuteNonQuery();

                // Revisar si la ejecución fue exitosa o no
                if (result == 1)
                {
                    mensaje = "Datos del Pago actualizados correctamente!";
                }
                else
                {
                    mensaje = "No se pudo actualizar correctamente los datos del Pago!";
                }
            }
            catch (SqlException ex)
            {
                // Manejar el error específico de SQL
                if (ex.Number == 50000) // Número de error lanzado por RAISERROR en el procedimiento
                {
                    mensaje = "Error: " + ex.Message; // Mensaje que llega desde el RAISERROR de la base de datos
                }
                else
                {
                    // Para otros errores de SQL
                    mensaje = "Error de SQL: " + ex.Message;
                }
            }
            catch (Exception ex)
            {
                // Manejar cualquier otro error no relacionado con SQL
                mensaje = "Error: " + ex.Message;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();
            }

            return mensaje;
        }

        public DataTable PagoConsultar(String miparametro)
        {
            DataTable dt = new DataTable(); 
            SqlDataReader leerDatos; 
            try
            {
                SqlCommand sqlCmd = new SqlCommand(); 
                sqlCmd.Connection = new ConexionDB().dbconexion; 
                sqlCmd.Connection.Open(); 
                sqlCmd.CommandText = "PagoConsultar"; 
                sqlCmd.CommandType = CommandType.StoredProcedure; 
                sqlCmd.Parameters.AddWithValue("@pvalor", miparametro); 
                leerDatos = sqlCmd.ExecuteReader(); 
                dt.Load(leerDatos); 
                sqlCmd.Connection.Close(); 
            }
            catch (Exception ex)
            {
                dt = null; //Si ocurre algun error se anula el DataTable
            }
            return dt; 
        }

        //Cuadro de Pagos: PENDIENTE y PAGADO
        public bool ObtenerEstadisticasPagosHoy(out int pendientes, out int pagadas)
        {
            bool exito = false;
            pendientes = 0;
            pagadas = 0;

            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = ConexionDB.miconexion;
                SqlCommand cmd = new SqlCommand("EstadisticasPagosHoy", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Pendientes", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@Pagadas", SqlDbType.Int).Direction = ParameterDirection.Output;

                sqlCon.Open();
                cmd.ExecuteNonQuery();

                pendientes = Convert.ToInt32(cmd.Parameters["@Pendientes"].Value);
                pagadas = Convert.ToInt32(cmd.Parameters["@Pagadas"].Value);

                exito = true;
            }
            catch (Exception ex)
            {
                exito = false;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();
            }

            return exito;
        }

        //Grafico 1, Ganancias Diarias
        public DataTable ObtenerGananciasDiariasChart()
        {
            using (SqlConnection sqlCon = new SqlConnection(ConexionDB.miconexion))
            {
                SqlCommand cmd = new SqlCommand("ObtenerGananciasDiariasChart", sqlCon)
                {
                    CommandType = CommandType.StoredProcedure
                };

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dtResultado = new DataTable();

                try
                {
                    sqlCon.Open();
                    da.Fill(dtResultado);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al cargar las ganancias diarias: " + ex.Message);
                    return null;
                }

                return dtResultado;
            }
        }

        //Graficos 2, Ganancias Semanales
        public DataTable ObtenerGananciasSemanalesChart()
        {
            using (SqlConnection sqlCon = new SqlConnection(ConexionDB.miconexion))
            {
                SqlCommand cmd = new SqlCommand("ObtenerGananciasSemanalesChart", sqlCon)
                {
                    CommandType = CommandType.StoredProcedure
                };

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dtResultado = new DataTable();

                try
                {
                    sqlCon.Open();
                    da.Fill(dtResultado);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al cargar las ganancias semanales: " + ex.Message);
                    return null;
                }

                return dtResultado;
            }
        }

        //Grafico 3, Grafico mensual, solo llega a los 6 meses
        public DataTable ObtenerGananciasMensualesChart()
        {
            using (SqlConnection sqlCon = new SqlConnection(ConexionDB.miconexion))
            {
                SqlCommand cmd = new SqlCommand("ObtenerGananciasMensualesChart", sqlCon)
                {
                    CommandType = CommandType.StoredProcedure
                };

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dtResultado = new DataTable();

                try
                {
                    sqlCon.Open();
                    da.Fill(dtResultado);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al cargar las ganancias mensuales: " + ex.Message);
                    return null;
                }

                return dtResultado;
            }
        }

    }
}