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
    public class CDServicio
    {
        private int dIdServicio, dPrecio, dDuracion;
        private String dNombreServicio, dEstado;

        public CDServicio() { }
        public CDServicio(int pIdServicio, string pNombreServicio, int pPrecio, int pDuracion, string pEstado)
        {
            this.dIdServicio = pIdServicio;
            this.dNombreServicio = pNombreServicio;
            this.dPrecio = pPrecio;
            this.dDuracion = pDuracion;
            this.dEstado = pEstado;
        }
        public int IdServicio
        {
            get { return dIdServicio; }
            set { dIdServicio = value; }
        }

        public string NombreServicio
        {
            get { return dNombreServicio; }
            set { dNombreServicio = value; }
        }

        public int Precio
        {
            get { return dPrecio; }
            set { dPrecio = value; }
        }

        public int Duracion
        {
            get { return dDuracion; }
            set { dDuracion = value; }
        }
        public string Estado
        {
            get { return dEstado; }
            set { dEstado = value; }
        }

        public string Insertar(CDServicio objServicio)
        {
            string mensaje = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = ConexionDB.miconexion;
                SqlCommand micomando = new SqlCommand("ServicioInsertar", sqlCon);
                micomando.CommandType = CommandType.StoredProcedure;

                micomando.Parameters.AddWithValue("@pNombreServicio", objServicio.NombreServicio);
                micomando.Parameters.AddWithValue("@pPrecio", objServicio.Precio);
                micomando.Parameters.AddWithValue("@pDuracion", objServicio.Duracion);
                micomando.Parameters.AddWithValue("@pEstado", objServicio.Estado);

                SqlParameter outputId = new SqlParameter("@pIdServicio", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                micomando.Parameters.Add(outputId);

                // Agregamos un parámetro de retorno
                SqlParameter returnValue = new SqlParameter("@ReturnVal", SqlDbType.Int);
                returnValue.Direction = ParameterDirection.ReturnValue;
                micomando.Parameters.Add(returnValue);

                sqlCon.Open();
                micomando.ExecuteNonQuery();

                int result = (int)returnValue.Value;

                if (result == 1)
                {
                    mensaje = "Datos del Servicio insertados correctamente!";
                }
                else if (result == -1)
                {
                    mensaje = "Error: El servicio ya está registrado.";
                }
                else if (result == -2)
                {
                    mensaje = "Error: El precio del servicio no puede ser menor a 1.";
                }
                else
                {
                    mensaje = "No se pudo insertar correctamente los datos del Servicio.";
                }
            }
            catch (SqlException ex)
            {
                mensaje = "Error: " + ex.Message;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();
            }
            return mensaje;
        }

        public string Actualizar(CDServicio objServicio)
        {
            string mensaje = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = ConexionDB.miconexion;
                SqlCommand micomando = new SqlCommand("ServicioActualizar", sqlCon);
                sqlCon.Open(); 
                micomando.CommandType = CommandType.StoredProcedure;
                micomando.Parameters.AddWithValue("@pIdServicio", objServicio.IdServicio);
                micomando.Parameters.AddWithValue("@pNombreServicio", objServicio.NombreServicio);
                micomando.Parameters.AddWithValue("@pDuracion", objServicio.Duracion);
                micomando.Parameters.AddWithValue("@pPrecio", objServicio.Precio);
                micomando.Parameters.AddWithValue("@pEstado", objServicio.Estado);

                int result = micomando.ExecuteNonQuery();
                if (result > 0)
                {
                    mensaje = "Datos del Servicio actualizados correctamente!";
                }
                else
                {
                    mensaje = "No se pudo actualizar correctamente los datos del Servicio!";
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 50000) // Número de error lanzado por RAISERROR
                {
                    mensaje = "El nombre del servicio ya existe. No se puede actualizar.";
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

        public DataTable ServicioConsultar(String miparametro)
        {
            DataTable dt = new DataTable(); 
            SqlDataReader leerDatos; 
            try
            {
                SqlCommand sqlCmd = new SqlCommand(); 
                sqlCmd.Connection = new ConexionDB().dbconexion; 
                sqlCmd.Connection.Open(); 
                sqlCmd.CommandText = "ServicioConsultar"; 
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


        //Obtener los 3 servicios más Solicitados en Citas
        public DataTable ObtenerTop3Servicios()
        {
            DataTable dt = new DataTable();
            SqlDataReader leerDatos;

            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = new ConexionDB().dbconexion;
                sqlCmd.Connection.Open();
                sqlCmd.CommandText = "ObtenerTop3Servicios";
                sqlCmd.CommandType = CommandType.StoredProcedure;

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
    }
}