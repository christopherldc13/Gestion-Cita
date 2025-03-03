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
        private int dIdCita, dIdCliente, dIdEmpleado, dIdServicio;
        private String dEstado;
        private DateTime dFecha, dHora;

        public CDCita() { }
        public CDCita(int pIdCita, int pIdCliente, int pIdEmpleado, DateTime pFecha, DateTime pHora, int pIdServicio, string pEstado)
        {
            this.dIdCita = pIdCita;
            this.dIdCliente = pIdCliente;
            this.dIdEmpleado = pIdEmpleado;
            this.dFecha = pFecha;
            this.dHora = pHora;
            this.dIdServicio = pIdServicio;
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
                micomando.Parameters.AddWithValue("@pEstado", objCita.Estado);
                mensaje = micomando.ExecuteNonQuery() == 1 ? "Datos de la Cita insertados correctamente!" :
                                                 "No se pudo insertar correctamente los datos de la Cita!";
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();
            }
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
                micomando.Parameters.AddWithValue("@pEstado", objCita.Estado);
                mensaje = micomando.ExecuteNonQuery() == 1 ? "Datos de la Cita actualizados correctamente!" :
                "No se pudo actualizar correctamente los datos de la Cita!";
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();
            }
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
    }
}