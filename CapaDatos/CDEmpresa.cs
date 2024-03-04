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
    public class CDEmpresa
    {
        private int dIdEmpresa;
        private String dNombre, dTelefono, dDireccion, dCorreo, dLogo, dEslogan;

        public CDEmpresa() { }
        public CDEmpresa(int pIdEmpresa, string pNombre, string pTelefono, string pDireccion, string pCorreo, string pLogo, string pEslogan)
        {
            this.dIdEmpresa = pIdEmpresa;
            this.dNombre = pNombre;
            this.dTelefono = pTelefono;
            this.dDireccion = pDireccion;
            this.dCorreo = pCorreo;
            this.dLogo = pLogo;
            this.dEslogan = pEslogan;
        }
        public int IdEmpresa
        {
            get { return dIdEmpresa; }
            set { dIdEmpresa = value; }
        }

        public string Nombre
        {
            get { return dNombre; }
            set { dNombre = value; }
        }

        public string Telefono
        {
            get { return dTelefono; }
            set { dTelefono = value; }
        }
        public string Direccion
        {
            get { return dDireccion; }
            set { dDireccion = value; }
        }

        public string Correo
        {
            get { return dCorreo; }
            set { dCorreo = value; }
        }

        public string Logo
        {
            get { return dLogo; }
            set { dLogo = value; }
        }

        public string Eslogan
        {
            get { return dEslogan; }
            set { dEslogan = value; }
        }

        public string Insertar(CDEmpresa objEmpresa)
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
                SqlCommand micomando = new SqlCommand("EmpresaInsertar", sqlCon);
                sqlCon.Open(); //Abro la conexióna
                               //indico que se ejecutara un procedimiento almacenado
                micomando.CommandType = CommandType.StoredProcedure;
                micomando.Parameters.AddWithValue("@pNombre", objEmpresa.Nombre);
                micomando.Parameters.AddWithValue("@pTelefono", objEmpresa.Telefono);
                micomando.Parameters.AddWithValue("@pDireccion", objEmpresa.Direccion);
                micomando.Parameters.AddWithValue("@pCorreo", objEmpresa.Correo);
                micomando.Parameters.AddWithValue("@pLogo", objEmpresa.Logo);
                micomando.Parameters.AddWithValue("@pEslogan", objEmpresa.Eslogan);
                //Metodo Insertar
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
        }//Metodo
         //método para actualizar los datos del Suplidor. Recibirá el objeto objSuplidor como parámetro
        public string Actualizar(CDEmpresa objEmpresa)
        {
            string mensaje = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = ConexionDB.miconexion;
                SqlCommand micomando = new SqlCommand("EmpresaActualizar", sqlCon);
                sqlCon.Open();
                micomando.Parameters.AddWithValue("@pNombre", objEmpresa.Nombre);
                micomando.Parameters.AddWithValue("@pTelefono", objEmpresa.Telefono);
                micomando.Parameters.AddWithValue("@pDireccion", objEmpresa.Direccion);
                micomando.Parameters.AddWithValue("@pCorreo", objEmpresa.Correo);
                micomando.Parameters.AddWithValue("@pLogo", objEmpresa.Logo);
                micomando.Parameters.AddWithValue("@pEslogan", objEmpresa.Eslogan);
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
        public DataTable EmpresaConsultar(String miparametro)
        {
            DataTable dt = new DataTable(); //Se Crea DataTable que tomará los datos de los Suplidores
            SqlDataReader leerDatos; //Creamos el DataReader
            try
            {
                SqlCommand sqlCmd = new SqlCommand(); //Establecer el comando
                sqlCmd.Connection = new ConexionDB().dbconexion; //Conexión que va a usar el comando
                sqlCmd.Connection.Open(); //Se abre la conexión
                sqlCmd.CommandText = "EmpresaConsultar"; //Nombre del Proc. Almacenado a usar
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
        }//Fin del método MostrarConFiltro

    }
}//Fin de la clase CDCliente
