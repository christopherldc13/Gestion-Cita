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
                mensaje = micomando.ExecuteNonQuery() == 1 ? "Datos del Pago actualizados correctamente!" :
                 "No se pudo actualizar correctamente los datos del Pago!";
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
        //Método para consultar datos filtrados de la tabla. Se recibe el valor del parámetro
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
    }
}