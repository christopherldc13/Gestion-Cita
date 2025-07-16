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
    public class CDUsuario
    {
        private int dIdUsuario, dIdEmpleado, dIdRol;
        private String dUsuario, dClave, dEstado;

        public CDUsuario() { }
        public CDUsuario(int pIdUsuario, string pUsuario, string pClave, int pIdRol, string pEstado, int pIdEmpleado)
        {
            this.dIdUsuario = pIdUsuario;
            this.dUsuario = pUsuario;
            this.dClave = pClave;
            this.dIdRol = pIdRol;
            this.dEstado = pEstado;
            this.dIdEmpleado = pIdEmpleado;
        }
        public int IdUsuario
        {
            get { return dIdUsuario; }
            set { dIdUsuario = value; }
        }

        public string Usuario
        {
            get { return dUsuario; }
            set { dUsuario = value; }
        }

        public string Clave
        {
            get { return dClave; }
            set { dClave = value; }
        }

        public int IdRol
        {
            get { return dIdRol; }
            set { dIdRol = value; }
        }

        public string Estado
        {
            get { return dEstado; }
            set { dEstado = value; }
        }

        public int IdEmpleado
        {
            get { return dIdEmpleado; }
            set { dIdEmpleado = value; }
        }

        //public string Insertar(CDUsuario objUsuario)
        //{
        //    string mensaje = "";
        //    SqlConnection sqlCon = new SqlConnection();
        //    try
        //    {
        //        sqlCon.ConnectionString = ConexionDB.miconexion;
        //        SqlCommand micomando = new SqlCommand("UsuarioInsertar", sqlCon);
        //        sqlCon.Open(); //Abro la conexión
        //                       //indico que se ejecutara un procedimiento almacenado
        //        micomando.CommandType = CommandType.StoredProcedure;
        //        micomando.Parameters.AddWithValue("@pIdUsuario", objUsuario.IdUsuario);
        //        micomando.Parameters.AddWithValue("@pUsuario", objUsuario.Usuario);
        //        micomando.Parameters.AddWithValue("@pClave", objUsuario.Clave);
        //        micomando.Parameters.AddWithValue("@pRole", objUsuario.Role);
        //        micomando.Parameters.AddWithValue("@pEstado", objUsuario.Estado);
        //        micomando.Parameters.AddWithValue("@pIdEmpleado", objUsuario.IdEmpleado);
        //        mensaje = micomando.ExecuteNonQuery() == 1 ? "Datos del Usuario insertados correctamente!" :
        //                                                     "No se pudo insertar correctamente los datos del Usuario!";
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

        public string Insertar(CDUsuario objUsuario)
        {
            string mensaje = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = ConexionDB.miconexion;
                SqlCommand micomando = new SqlCommand("UsuarioInsertar", sqlCon);
                sqlCon.Open(); 
                micomando.CommandType = CommandType.StoredProcedure;
                //micomando.Parameters.AddWithValue("@pIdUsuario", objUsuario.IdUsuario);
                micomando.Parameters.AddWithValue("@pUsuario", objUsuario.Usuario);
                micomando.Parameters.AddWithValue("@pClave", objUsuario.Clave);
                micomando.Parameters.AddWithValue("@pIdRol", objUsuario.IdRol);
                micomando.Parameters.AddWithValue("@pEstado", objUsuario.Estado);
                micomando.Parameters.AddWithValue("@pIdEmpleado", objUsuario.IdEmpleado);

                SqlParameter outputId = new SqlParameter("@pIdUsuario", SqlDbType.Int);
                outputId.Direction = ParameterDirection.Output;
                micomando.Parameters.Add(outputId);

                // Ejecutar el procedimiento
                micomando.ExecuteNonQuery();

                // Verificar si el procedimiento almacenado devolvió un error
                int result = (int)micomando.Parameters["@pIdUsuario"].Value;

                if (result == -1) // El usuario ya existe
                {
                    mensaje = "Error: El nombre de usuario ya está registrado.";
                }
                else
                {
                    mensaje = "Datos del Usuario insertados correctamente!";
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

        public string Actualizar(CDUsuario objUsuario)
        {
            string mensaje = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = ConexionDB.miconexion;
                SqlCommand micomando = new SqlCommand("UsuarioActualizar", sqlCon);
                micomando.CommandType = CommandType.StoredProcedure;
                micomando.Parameters.AddWithValue("@pIdUsuario", objUsuario.IdUsuario);
                micomando.Parameters.AddWithValue("@pUsuario", objUsuario.Usuario);
                micomando.Parameters.AddWithValue("@pClave", objUsuario.Clave);
                micomando.Parameters.AddWithValue("@pIdRol", objUsuario.IdRol);
                micomando.Parameters.AddWithValue("@pEstado", objUsuario.Estado);
                micomando.Parameters.AddWithValue("@pIdEmpleado", objUsuario.IdEmpleado);

                sqlCon.Open();
                micomando.ExecuteNonQuery(); // Ejecutar el procedimiento almacenado

                // Si llega aquí, significa que no hubo errores de RAISERROR
                mensaje = "Datos del Usuario actualizados correctamente!";
            }
            catch (SqlException ex)
            {
                // Capturar errores específicos de SQL Server
                if (ex.Number == 50000) // Número de error para RAISERROR (puedes ajustarlo)
                {
                    mensaje = ex.Message; // Obtener el mensaje de RAISERROR
                }
                else
                {
                    mensaje = "Error de SQL Server: " + ex.Message; // Otros errores de SQL Server
                }
            }
            catch (Exception ex)
            {
                mensaje = "Error general: " + ex.Message; // Otros errores
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();
            }
            return mensaje;
        }

        //public string Actualizar(CDUsuario objUsuario)
        //{
        //    string mensaje = "";
        //    SqlConnection sqlCon = new SqlConnection();
        //    try
        //    {
        //        sqlCon.ConnectionString = ConexionDB.miconexion;
        //        SqlCommand micomando = new SqlCommand("UsuarioActualizar", sqlCon);
        //        sqlCon.Open();
        //        micomando.CommandType = CommandType.StoredProcedure;

        //        // Agregar parámetros al comando
        //        micomando.Parameters.AddWithValue("@pIdUsuario", objUsuario.IdUsuario);
        //        micomando.Parameters.AddWithValue("@pUsuario", objUsuario.Usuario);
        //        micomando.Parameters.AddWithValue("@pClave", objUsuario.Clave);
        //        micomando.Parameters.AddWithValue("@pIdRol", objUsuario.IdRol);
        //        micomando.Parameters.AddWithValue("@pEstado", objUsuario.Estado);
        //        micomando.Parameters.AddWithValue("@pIdEmpleado", objUsuario.IdEmpleado);

        //        // Leer los mensajes del procedimiento
        //        SqlDataReader reader = micomando.ExecuteReader();

        //        // Comprobar si se encontró un mensaje de éxito
        //        if (reader.Read())
        //        {
        //            mensaje = reader[0].ToString();
        //        }

        //        reader.Close();
        //    }
        //    catch (SqlException sqlEx)
        //    {
        //        // Manejo específico de errores SQL
        //        mensaje = "Error de base de datos: " + sqlEx.Message;
        //    }
        //    catch (Exception ex)
        //    {
        //        // Manejo general de errores
        //        mensaje = "Error: " + ex.Message;
        //    }
        //    finally
        //    {
        //        if (sqlCon.State == ConnectionState.Open)
        //        {
        //            sqlCon.Close();
        //        }
        //    }

        //    return mensaje;
        //}

        public DataTable UsuarioConsultar(String miparametro)
        {
            DataTable dt = new DataTable(); 
            SqlDataReader leerDatos; 
            try
            {
                SqlCommand sqlCmd = new SqlCommand(); 
                sqlCmd.Connection = new ConexionDB().dbconexion; 
                sqlCmd.Connection.Open(); 
                sqlCmd.CommandText = "UsuarioConsultar"; 
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

        //public bool AutenticarUsuario(string usuario, string clave)
        //{
        //    bool autenticado = false;
        //    SqlConnection sqlCon = new SqlConnection();
        //    try
        //    {
        //        sqlCon.ConnectionString = ConexionDB.miconexion;
        //        SqlCommand sqlCommand = new SqlCommand("AutenticarUsuario", sqlCon);
        //        sqlCommand.CommandType = CommandType.StoredProcedure;

        //        sqlCommand.Parameters.AddWithValue("@Usuario", usuario);
        //        sqlCommand.Parameters.AddWithValue("@Clave", clave);

        //        sqlCon.Open();
        //        int count = Convert.ToInt32(sqlCommand.ExecuteScalar());

        //        if (count == 1)
        //        {
        //            autenticado = true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Error al autenticar usuario: " + ex.Message);
        //    }
        //    finally
        //    {
        //        if (sqlCon.State == ConnectionState.Open)
        //            sqlCon.Close();
        //    }
        //    return autenticado;
        //}

        //public string AutenticarUsuario(string usuario, string clave)
        //{
        //    string mensaje = "";
        //    SqlConnection sqlCon = new SqlConnection();
        //    try
        //    {
        //        sqlCon.ConnectionString = ConexionDB.miconexion;
        //        SqlCommand sqlCommand = new SqlCommand("AutenticarUsuario", sqlCon);
        //        sqlCommand.CommandType = CommandType.StoredProcedure;

        //        sqlCommand.Parameters.AddWithValue("@Usuario", usuario);
        //        sqlCommand.Parameters.AddWithValue("@Clave", clave);

        //        sqlCon.Open();
        //        object result = sqlCommand.ExecuteScalar();

        //        if (result != null)
        //        {
        //            mensaje = result.ToString(); // Guardar el mensaje recibido
        //        }
        //        else
        //        {
        //            mensaje = "Error: No se pudo autenticar el usuario.";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        mensaje = "Error al autenticar usuario: " + ex.Message;
        //    }
        //    finally
        //    {
        //        if (sqlCon.State == ConnectionState.Open)
        //            sqlCon.Close();
        //    }
        //    return mensaje;
        //}

        //public (string mensaje, string rol) AutenticarUsuario(string usuario, string clave)
        //{
        //    string mensaje = "";
        //    string rol = "";
        //    SqlConnection sqlCon = new SqlConnection();

        //    try
        //    {
        //        sqlCon.ConnectionString = ConexionDB.miconexion;
        //        SqlCommand sqlCommand = new SqlCommand("AutenticarUsuario", sqlCon);
        //        sqlCommand.CommandType = CommandType.StoredProcedure;

        //        sqlCommand.Parameters.AddWithValue("@Usuario", usuario);
        //        sqlCommand.Parameters.AddWithValue("@Clave", clave);

        //        sqlCon.Open();
        //        SqlDataReader reader = sqlCommand.ExecuteReader();

        //        if (reader.Read())
        //        {
        //            mensaje = reader["Mensaje"].ToString();
        //            rol = reader["Role"] != DBNull.Value ? reader["Role"].ToString() : "";
        //        }

        //        reader.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        mensaje = "Error al autenticar usuario: " + ex.Message;
        //    }
        //    finally
        //    {
        //        if (sqlCon.State == ConnectionState.Open)
        //            sqlCon.Close();
        //    }

        //    return (mensaje, rol);
        //}

        public (string mensaje, string rol) AutenticarUsuario(string usuario, string clave)
        {
            using (SqlConnection sqlCon = new SqlConnection(ConexionDB.miconexion))
            {
                try
                {
                    using (SqlCommand sqlCommand = new SqlCommand("AutenticarUsuario", sqlCon))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@Usuario", usuario);
                        sqlCommand.Parameters.AddWithValue("@Clave", clave);

                        sqlCon.Open();
                        using (SqlDataReader reader = sqlCommand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string mensaje = reader["Mensaje"].ToString();
                                string rol = reader["Rol"] != DBNull.Value ? reader["Rol"].ToString() : "";
                                return (mensaje, rol);
                            }
                        }
                    }

                    return ("Usuario no encontrado.", ""); // Si no hay resultados
                }
                catch (Exception ex)
                {
                    return ("Error al autenticar usuario: " + ex.Message, "");
                }
            }
        }

    }
}