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
        private int dIdUsuario, dIdBarbero;
        private String dUsuario, dClave, dRole, dEstado;

        public CDUsuario() { }
        public CDUsuario(int pIdUsuario, string pUsuario, string pClave, string pRole, string pEstado, int pIdBarbero)
        {
            this.dIdUsuario = pIdUsuario;
            this.dUsuario = pUsuario;
            this.dClave = pClave;
            this.dRole = pRole;
            this.dEstado = pEstado;
            this.dIdBarbero = pIdBarbero;
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

        public int IdBarbero
        {
            get { return dIdBarbero; }
            set { dIdBarbero = value; }
        }

        public string Insertar(CDUsuario objUsuario)
        {
            string mensaje = "";
            //creamos un nuevo objeto de tipo SqlConnection
            SqlConnection sqlCon = new SqlConnection();
            //trataremos de hacer algunas operaciones con la tabla
            try
            {
                //asignamos a sqlCon la conexión con las base de datos a traves de la clase que creamos
                sqlCon.ConnectionString = ConexionDB.miconexion;
                //Escribo el nombre del procedimiento almacenado que utilizaré, en este caso SuplidorInsertar
                SqlCommand micomando = new SqlCommand("UsuarioInsertar", sqlCon);
                sqlCon.Open(); //Abro la conexión
                               //indico que se ejecutara un procedimiento almacenado
                micomando.CommandType = CommandType.StoredProcedure;
                micomando.Parameters.AddWithValue("@pUsuario", objUsuario.Usuario);
                micomando.Parameters.AddWithValue("@pClave", objUsuario.Clave);
                micomando.Parameters.AddWithValue("@pRole", objUsuario.Role);
                micomando.Parameters.AddWithValue("@pEstado", objUsuario.Estado);
                micomando.Parameters.AddWithValue("@pIdBarbero", objUsuario.IdBarbero);
                //Metodo Insertar
                mensaje = micomando.ExecuteNonQuery() == 1 ? "Datos insertados correctamente!" :
                                                             "No se pudo insertar correctamente los datos!";
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

        }//Metodo
         //método para actualizar los datos del Suplidor. Recibirá el objeto objSuplidor como parámetro
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
                micomando.Parameters.AddWithValue("@pUsuario", objUsuario.Usuario);
                micomando.Parameters.AddWithValue("@pClave", objUsuario.Clave);
                micomando.Parameters.AddWithValue("@pRole", objUsuario.Role);
                micomando.Parameters.AddWithValue("@pEstado", objUsuario.Estado);
                micomando.Parameters.AddWithValue("@pIdBarbero", objUsuario.IdBarbero);
                mensaje = micomando.ExecuteNonQuery() == 1 ? "Datos actualizados correctamente!" :
                 "No se pudo actualizar correctamente los datos!";
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
            DataTable dt = new DataTable(); //Se Crea DataTable que tomará los datos de los Suplidores
            SqlDataReader leerDatos; //Creamos el DataReader
            try
            {
                SqlCommand sqlCmd = new SqlCommand(); //Establecer el comando
                sqlCmd.Connection = new ConexionDB().dbconexion; //Conexión que va a usar el comando
                sqlCmd.Connection.Open(); //Se abre la conexión
                sqlCmd.CommandText = "UsuarioConsultar"; //Nombre del Proc. Almacenado a usar
                sqlCmd.CommandType = CommandType.StoredProcedure; //Se trata de un proc. almacenado
                sqlCmd.Parameters.AddWithValue("@pvalor", miparametro); //Se pasa el valor a buscar
                leerDatos = sqlCmd.ExecuteReader(); //Llenamos el SqlDataReader con los datos resultantes
                dt.Load(leerDatos); //Se cargan los registros devueltos al DataTable
                sqlCmd.Connection.Close(); //Se cierra la conexión
            }
            catch (Exception ex)
            {
                dt = null; //Si ocurre algun error se anula el DataTable
            }
            return dt; ////Se retorna el DataTable segun lo ocurrido arriba
        } //Fin del método MostrarConFiltro


    }
}//Fin de la clase CDCliente