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
    public class CDEmpleado
    {
        private int dIdEmpleado;
        private String dNombre, dApellido, dTelefono, dEstado; //dDisponibilidad, dEstado;

        public CDEmpleado() { }
        public CDEmpleado(int pIdEmpleado, string pNombre, string pApellido, string pTelefono, string pEstado) //string pDisponibilidad, string pEstado)
        {
            this.dIdEmpleado = pIdEmpleado;
            this.dNombre = pNombre;
            this.dApellido = pApellido;
            this.dTelefono = pTelefono;
            //this.dDisponibilidad = pDisponibilidad;
            this.dEstado = pEstado;
        }
        public int IdEmpleado
        {
            get { return dIdEmpleado; }
            set { dIdEmpleado = value; }
        }

        public string Nombre
        {
            get { return dNombre; }
            set { dNombre = value; }
        }

        public string Apellido
        {
            get { return dApellido; }
            set { dApellido = value; }
        }

        public string Telefono
        {
            get { return dTelefono; }
            set { dTelefono = value; }
        }

        //public string Disponibilidad
        //{
        //    get { return dDisponibilidad; }
        //    set { dDisponibilidad = value; }
        //}

        public string Estado
        {
            get { return dEstado; }
            set { dEstado = value; }
        }

        //public string Insertar(CDEmpleado objEmpleado)
        //{
        //    string mensaje = "";
        //    SqlConnection sqlCon = new SqlConnection();
        //    try
        //    {
        //        sqlCon.ConnectionString = ConexionDB.miconexion;
        //        SqlCommand micomando = new SqlCommand("EmpleadoInsertar", sqlCon);
        //        sqlCon.Open(); //Abro la conexión
        //                       //indico que se ejecutara un procedimiento almacenado
        //        micomando.CommandType = CommandType.StoredProcedure;
        //        micomando.Parameters.AddWithValue("@pNombre", objEmpleado.Nombre);
        //        micomando.Parameters.AddWithValue("@pApellido", objEmpleado.Apellido);
        //        micomando.Parameters.AddWithValue("@pTelefono", objEmpleado.Telefono);
        //        micomando.Parameters.AddWithValue("@pDisponibilidad", objEmpleado.Disponibilidad);
        //        micomando.Parameters.AddWithValue("@pEstado", objEmpleado.Estado);
        //        mensaje = micomando.ExecuteNonQuery() == 1 ? "Datos del Empleado insertados correctamente!" :
        //                                                     "No se pudo insertar correctamente los datos del Empleado!";
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

        public string Insertar(CDEmpleado objEmpleado)
        {
            string mensaje = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = ConexionDB.miconexion;
                SqlCommand micomando = new SqlCommand("EmpleadoInsertar", sqlCon);
                sqlCon.Open(); 
                micomando.CommandType = CommandType.StoredProcedure;
                micomando.Parameters.AddWithValue("@pNombre", objEmpleado.Nombre);
                micomando.Parameters.AddWithValue("@pApellido", objEmpleado.Apellido);
                micomando.Parameters.AddWithValue("@pTelefono", objEmpleado.Telefono);
                //micomando.Parameters.AddWithValue("@pDisponibilidad", objEmpleado.Disponibilidad);
                micomando.Parameters.AddWithValue("@pEstado", objEmpleado.Estado);

                SqlParameter outputId = new SqlParameter("@pIdEmpleado", SqlDbType.Int);
                outputId.Direction = ParameterDirection.Output;
                micomando.Parameters.Add(outputId);

                int result = micomando.ExecuteNonQuery();
                if (result > 0)
                {
                    mensaje = "Datos del Empleado insertados correctamente!";
                }
                else
                {
                    mensaje = "No se pudo insertar correctamente los datos del Empleado!";
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 50000) // Número de error lanzado por RAISERROR
                {
                    mensaje = "Error: El empleado ya está registrado.";
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

        //public string Actualizar(CDEmpleado objEmpleado)
        //{
        //    string mensaje = "";
        //    SqlConnection sqlCon = new SqlConnection();
        //    try
        //    {
        //        sqlCon.ConnectionString = ConexionDB.miconexion;
        //        SqlCommand micomando = new SqlCommand("EmpleadoActualizar", sqlCon);
        //        sqlCon.Open();
        //        micomando.CommandType = CommandType.StoredProcedure;
        //        micomando.Parameters.AddWithValue("@pIdEmpleado", objEmpleado.IdEmpleado);
        //        micomando.Parameters.AddWithValue("@pNombre", objEmpleado.Nombre);
        //        micomando.Parameters.AddWithValue("@pApellido", objEmpleado.Apellido);
        //        micomando.Parameters.AddWithValue("@pTelefono", objEmpleado.Telefono);
        //        micomando.Parameters.AddWithValue("@pDisponibilidad", objEmpleado.Disponibilidad);
        //        micomando.Parameters.AddWithValue("@pEstado", objEmpleado.Estado);
        //        mensaje = micomando.ExecuteNonQuery() == 1 ? "Datos del Empleado actualizados correctamente!" :
        //         "No se pudo actualizar correctamente los datos del Empleado!";
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

        public string Actualizar(CDEmpleado objEmpleado)
        {
            string mensaje = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = ConexionDB.miconexion;
                SqlCommand micomando = new SqlCommand("EmpleadoActualizar", sqlCon);
                sqlCon.Open(); 
                micomando.CommandType = CommandType.StoredProcedure;
                micomando.Parameters.AddWithValue("@pIdEmpleado", objEmpleado.IdEmpleado);
                micomando.Parameters.AddWithValue("@pNombre", objEmpleado.Nombre);
                micomando.Parameters.AddWithValue("@pApellido", objEmpleado.Apellido);
                micomando.Parameters.AddWithValue("@pTelefono", objEmpleado.Telefono);
                //micomando.Parameters.AddWithValue("@pDisponibilidad", objEmpleado.Disponibilidad);
                micomando.Parameters.AddWithValue("@pEstado", objEmpleado.Estado);

                // Aquí se captura el valor de retorno del procedimiento almacenado
                SqlParameter returnParam = new SqlParameter("@RETURN_VALUE", SqlDbType.Int)
                {
                    Direction = ParameterDirection.ReturnValue
                };
                micomando.Parameters.Add(returnParam);

                micomando.ExecuteNonQuery();

                // Verificar el valor de retorno
                int returnValue = (int)returnParam.Value;
                if (returnValue == -1)
                {
                    mensaje = "Ya existe un empleado con los mismos datos.";
                }
                else if (returnValue == 1)
                {
                    mensaje = "Datos del Empleado actualizados correctamente!";
                }
                else
                {
                    mensaje = "No se pudo actualizar correctamente los datos del Empleado!";
                }
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

        public DataTable EmpleadoConsultar(String miparametro)
        {
            DataTable dt = new DataTable(); 
            SqlDataReader leerDatos; 
            try
            {
                SqlCommand sqlCmd = new SqlCommand(); 
                sqlCmd.Connection = new ConexionDB().dbconexion; 
                sqlCmd.Connection.Open(); 
                sqlCmd.CommandText = "EmpleadoConsultar"; 
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

        //Cuadro de Empleado: Empleados activos
        public int ObtenerCantidadEmpleadosActivos()
        {
            int cantidad = 0;
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = ConexionDB.miconexion;
                SqlCommand micomando = new SqlCommand("CantidadEmpleados", sqlCon);
                micomando.CommandType = CommandType.StoredProcedure;
                sqlCon.Open();

                object resultado = micomando.ExecuteScalar();
                if (resultado != null && resultado != DBNull.Value)
                {
                    cantidad = Convert.ToInt32(resultado);
                }
            }
            catch (Exception ex)
            {
                cantidad = -1; // podrías manejarlo con un valor de error si es necesario
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();
            }
            return cantidad;
        }
    }
}