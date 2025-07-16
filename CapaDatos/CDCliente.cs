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
    public class CDCliente
    {
        private int dIdCliente;
        private String dNombre, dApellido, dTelefono, dCorreo, dEstado;

        public CDCliente() { }
        public CDCliente(int pIdCliente, string pNombre, string pApellido, string pTelefono, string pCorreo, string pEstado)
        {
            this.dIdCliente = pIdCliente;
            this.dNombre = pNombre;
            this.dApellido = pApellido;
            this.dTelefono = pTelefono;
            this.dCorreo = pCorreo;
            this.dEstado = pEstado;
        }
        public int IdCliente
        {
            get { return dIdCliente; }
            set { dIdCliente = value; }
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

        public string Correo
        {
            get { return dCorreo; }
            set { dCorreo = value; }
        }

        public string Estado
        {
            get { return dEstado; }
            set { dEstado = value; }
        }

        //public string Insertar(CDCliente objCliente)
        //{
        //    string mensaje = "";
        //    SqlConnection sqlCon = new SqlConnection();
        //    try
        //    {
        //        sqlCon.ConnectionString = ConexionDB.miconexion;
        //        SqlCommand micomando = new SqlCommand("ClienteInsertar", sqlCon);
        //        sqlCon.Open(); //Abro la conexión
        //                       //indico que se ejecutara un procedimiento almacenado
        //        micomando.CommandType = CommandType.StoredProcedure;
        //        micomando.Parameters.AddWithValue("@pNombre", objCliente.Nombre);
        //        micomando.Parameters.AddWithValue("@pApellido", objCliente.Apellido);
        //        micomando.Parameters.AddWithValue("@pTelefono", objCliente.Telefono);
        //        micomando.Parameters.AddWithValue("@pCorreo", objCliente.Correo);
        //        micomando.Parameters.AddWithValue("@pEstado", objCliente.Estado);
        //        mensaje = micomando.ExecuteNonQuery() == 1 ? "Datos del Cliente insertados correctamente!" :
        //                                                     "No se pudo insertar correctamente los datos del Cliente!";
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

        //public string Insertar(CDCliente objCliente)
        //{
        //    string mensaje = "";
        //    SqlConnection sqlCon = new SqlConnection();
        //    try
        //    {
        //        sqlCon.ConnectionString = ConexionDB.miconexion;
        //        SqlCommand micomando = new SqlCommand("ClienteInsertar", sqlCon);
        //        sqlCon.Open();
        //        micomando.CommandType = CommandType.StoredProcedure;
        //        micomando.Parameters.AddWithValue("@pNombre", objCliente.Nombre);
        //        micomando.Parameters.AddWithValue("@pApellido", objCliente.Apellido);
        //        micomando.Parameters.AddWithValue("@pTelefono", objCliente.Telefono);
        //        micomando.Parameters.AddWithValue("@pCorreo", objCliente.Correo);
        //        micomando.Parameters.AddWithValue("@pEstado", objCliente.Estado);

        //        SqlParameter outputId = new SqlParameter("@pIdCliente", SqlDbType.Int);
        //        outputId.Direction = ParameterDirection.Output;
        //        micomando.Parameters.Add(outputId);

        //        int result = micomando.ExecuteNonQuery();
        //        if (result > 0)
        //        {
        //            mensaje = "Datos del Cliente insertados correctamente!";
        //        }
        //        else
        //        {
        //            mensaje = "No se pudo insertar correctamente los datos del Cliente!";
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        if (ex.Number == 50000) // Número de error lanzado por RAISERROR
        //        {
        //            mensaje = "Error: Este Cliente ya esta Registrado en el Sistema.";
        //        }
        //        else
        //        {
        //            mensaje = ex.Message;
        //        }
        //    }
        //    finally
        //    {
        //        if (sqlCon.State == ConnectionState.Open)
        //            sqlCon.Close();
        //    }
        //    return mensaje;
        //}

        public string Insertar(CDCliente objCliente)
        {
            string mensaje = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = ConexionDB.miconexion;
                SqlCommand micomando = new SqlCommand("ClienteInsertar", sqlCon);
                sqlCon.Open();
                micomando.CommandType = CommandType.StoredProcedure;
                micomando.Parameters.AddWithValue("@pNombre", objCliente.Nombre);
                micomando.Parameters.AddWithValue("@pApellido", objCliente.Apellido);
                micomando.Parameters.AddWithValue("@pTelefono", objCliente.Telefono);
                micomando.Parameters.AddWithValue("@pCorreo", objCliente.Correo);
                micomando.Parameters.AddWithValue("@pEstado", objCliente.Estado);

                SqlParameter outputId = new SqlParameter("@pIdCliente", SqlDbType.Int);
                outputId.Direction = ParameterDirection.Output;
                micomando.Parameters.Add(outputId);

                micomando.ExecuteNonQuery();

                if (outputId.Value != DBNull.Value)
                {
                    mensaje = "Datos del Cliente insertados correctamente!";
                }
            }
            catch (SqlException ex)
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



        //public string Actualizar(CDCliente objCliente)
        //{
        //    string mensaje = "";
        //    SqlConnection sqlCon = new SqlConnection();
        //    try
        //    {
        //        sqlCon.ConnectionString = ConexionDB.miconexion;
        //        SqlCommand micomando = new SqlCommand("ClienteActualizar", sqlCon);
        //        sqlCon.Open();
        //        micomando.CommandType = CommandType.StoredProcedure;
        //        micomando.Parameters.AddWithValue("@pIdCliente", objCliente.IdCliente);
        //        micomando.Parameters.AddWithValue("@pNombre", objCliente.Nombre);
        //        micomando.Parameters.AddWithValue("@pApellido", objCliente.Apellido);
        //        micomando.Parameters.AddWithValue("@pTelefono", objCliente.Telefono);
        //        micomando.Parameters.AddWithValue("@pCorreo", objCliente.Correo);
        //        micomando.Parameters.AddWithValue("@pEstado", objCliente.Estado);
        //        mensaje = micomando.ExecuteNonQuery() == 1 ? "Datos del Cliente actualizados correctamente!" :
        //         "No se pudo actualizar correctamente los datos del Cliente!";
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

        //public string Actualizar(CDCliente objCliente)
        //{
        //    string mensaje = "";
        //    SqlConnection sqlCon = new SqlConnection();
        //    try
        //    {
        //        sqlCon.ConnectionString = ConexionDB.miconexion;
        //        SqlCommand micomando = new SqlCommand("ClienteActualizar", sqlCon);
        //        sqlCon.Open();
        //        micomando.CommandType = CommandType.StoredProcedure;
        //        micomando.Parameters.AddWithValue("@pIdCliente", objCliente.IdCliente);
        //        micomando.Parameters.AddWithValue("@pNombre", objCliente.Nombre);
        //        micomando.Parameters.AddWithValue("@pApellido", objCliente.Apellido);
        //        micomando.Parameters.AddWithValue("@pTelefono", objCliente.Telefono);
        //        micomando.Parameters.AddWithValue("@pCorreo", objCliente.Correo);
        //        micomando.Parameters.AddWithValue("@pEstado", objCliente.Estado);

        //        int result = micomando.ExecuteNonQuery();

        //        if (result > 0)
        //        {
        //            mensaje = "Datos del Cliente actualizados correctamente!";
        //        }
        //        else
        //        {
        //            mensaje = "No se pudo actualizar correctamente los datos del Cliente!";
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        if (ex.Number == 50000) // Error lanzado por RAISERROR en SQL
        //        {
        //            mensaje = "Error: " + ex.Message;
        //        }
        //        else
        //        {
        //            mensaje = "Error SQL: " + ex.Message;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        mensaje = "Error en la aplicación: " + ex.Message;
        //    }
        //    finally
        //    {
        //        if (sqlCon.State == ConnectionState.Open)
        //            sqlCon.Close();
        //    }
        //    return mensaje;
        //}

        public string Actualizar(CDCliente objCliente)
        {
            string mensaje = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = ConexionDB.miconexion;
                SqlCommand micomando = new SqlCommand("ClienteActualizar", sqlCon);
                sqlCon.Open();
                micomando.CommandType = CommandType.StoredProcedure;
                micomando.Parameters.AddWithValue("@pIdCliente", objCliente.IdCliente);
                micomando.Parameters.AddWithValue("@pNombre", objCliente.Nombre);
                micomando.Parameters.AddWithValue("@pApellido", objCliente.Apellido);
                micomando.Parameters.AddWithValue("@pTelefono", objCliente.Telefono);
                micomando.Parameters.AddWithValue("@pCorreo", objCliente.Correo);
                micomando.Parameters.AddWithValue("@pEstado", objCliente.Estado);

                int result = micomando.ExecuteNonQuery();

                if (result > 0)
                {
                    mensaje = "Datos del Cliente actualizados correctamente!";
                }
            }
            catch (SqlException ex)
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

        public DataTable ClienteConsultar(String miparametro)
        {
            DataTable dt = new DataTable(); 
            SqlDataReader leerDatos; 
            try
            {
                SqlCommand sqlCmd = new SqlCommand(); 
                sqlCmd.Connection = new ConexionDB().dbconexion; 
                sqlCmd.Connection.Open(); 
                sqlCmd.CommandText = "ClienteConsultar"; 
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

        //Cuadro de Cliente: Cliente activos
        public int ObtenerCantidadClientesActivos()
        {
            int cantidad = 0;
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = ConexionDB.miconexion;
                SqlCommand micomando = new SqlCommand("CantidadCliente", sqlCon);
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