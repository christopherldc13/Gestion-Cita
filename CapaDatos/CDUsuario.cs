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
        private int dIdUsuario, dIdEmpleado;
        private String dUsuario, dClave, dRole, dEstado;

        public CDUsuario() { }
        public CDUsuario(int pIdUsuario, string pUsuario, string pClave, string pRole, string pEstado, int pIdEmpleado)
        {
            this.dIdUsuario = pIdUsuario;
            this.dUsuario = pUsuario;
            this.dClave = pClave;
            this.dRole = pRole;
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

        public string Role
        {
            get { return dRole; }
            set { dRole = value; }
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

        public string Insertar(CDUsuario objUsuario)
        {
            string mensaje = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = ConexionDB.miconexion;
                SqlCommand micomando = new SqlCommand("UsuarioInsertar", sqlCon);
                sqlCon.Open(); //Abro la conexión
                               //indico que se ejecutara un procedimiento almacenado
                micomando.CommandType = CommandType.StoredProcedure;
                micomando.Parameters.AddWithValue("@pIdUsuario", objUsuario.IdUsuario);
                micomando.Parameters.AddWithValue("@pUsuario", objUsuario.Usuario);
                micomando.Parameters.AddWithValue("@pClave", objUsuario.Clave);
                micomando.Parameters.AddWithValue("@pRole", objUsuario.Role);
                micomando.Parameters.AddWithValue("@pEstado", objUsuario.Estado);
                micomando.Parameters.AddWithValue("@pIdEmpleado", objUsuario.IdEmpleado);
                mensaje = micomando.ExecuteNonQuery() == 1 ? "Datos del Usuario insertados correctamente!" :
                                                             "No se pudo insertar correctamente los datos del Usuario!";
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

        public string Actualizar(CDUsuario objUsuario)
        {
            string mensaje = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = ConexionDB.miconexion;
                SqlCommand micomando = new SqlCommand("UsuarioActualizar", sqlCon);
                sqlCon.Open();
                micomando.CommandType = CommandType.StoredProcedure;
                micomando.Parameters.AddWithValue("@pIdUsuario", objUsuario.IdUsuario);
                micomando.Parameters.AddWithValue("@pUsuario", objUsuario.Usuario);
                micomando.Parameters.AddWithValue("@pClave", objUsuario.Clave);
                micomando.Parameters.AddWithValue("@pRole", objUsuario.Role);
                micomando.Parameters.AddWithValue("@pEstado", objUsuario.Estado);
                micomando.Parameters.AddWithValue("@pIdEmpleado", objUsuario.IdEmpleado);
                mensaje = micomando.ExecuteNonQuery() == 1 ? "Datos del Usuario actualizados correctamente!" :
                 "No se pudo actualizar correctamente los datos del Usuarrio!";
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

        public bool AutenticarUsuario(string usuario, string clave)
        {
            bool autenticado = false;
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = ConexionDB.miconexion;
                SqlCommand sqlCommand = new SqlCommand("AutenticarUsuario", sqlCon);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@Usuario", usuario);
                sqlCommand.Parameters.AddWithValue("@Clave", clave);

                sqlCon.Open();
                int count = Convert.ToInt32(sqlCommand.ExecuteScalar());

                if (count == 1)
                {
                    autenticado = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al autenticar usuario: " + ex.Message);
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();
            }
            return autenticado;
        }
    }
}//Fin de la clase CDCliente