using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data.Sql;
using System.Windows.Forms;

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
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = ConexionDB.miconexion;
                SqlCommand micomando = new SqlCommand("EmpresaInsertar", sqlCon);
                sqlCon.Open(); 
                micomando.CommandType = CommandType.StoredProcedure;
                micomando.Parameters.AddWithValue("@pNombre", objEmpresa.Nombre);
                micomando.Parameters.AddWithValue("@pTelefono", objEmpresa.Telefono);
                micomando.Parameters.AddWithValue("@pDireccion", objEmpresa.Direccion);
                micomando.Parameters.AddWithValue("@pCorreo", objEmpresa.Correo);
                micomando.Parameters.AddWithValue("@pLogo", objEmpresa.Logo);
                micomando.Parameters.AddWithValue("@pEslogan", objEmpresa.Eslogan);
                mensaje = micomando.ExecuteNonQuery() == 1 ? "Datos de la Empresa insertados correctamente!" :
                                                 "No se pudo insertar correctamente los datos de la Empresa!";
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

        public string Actualizar(CDEmpresa objEmpresa)
        {
            string mensaje = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = ConexionDB.miconexion;
                SqlCommand micomando = new SqlCommand("EmpresaActualizar", sqlCon);
                sqlCon.Open();
                micomando.CommandType = CommandType.StoredProcedure;
                micomando.Parameters.AddWithValue("@pIdEmpresa", objEmpresa.IdEmpresa);
                micomando.Parameters.AddWithValue("@pNombre", objEmpresa.Nombre);
                micomando.Parameters.AddWithValue("@pTelefono", objEmpresa.Telefono);
                micomando.Parameters.AddWithValue("@pDireccion", objEmpresa.Direccion);
                micomando.Parameters.AddWithValue("@pCorreo", objEmpresa.Correo);
                micomando.Parameters.AddWithValue("@pLogo", objEmpresa.Logo);
                micomando.Parameters.AddWithValue("@pEslogan", objEmpresa.Eslogan);
                mensaje = micomando.ExecuteNonQuery() == 1 ? "Datos de la Empresa actualizados correctamente!" :
                 "No se pudo actualizar correctamente los datos de la empresa!";
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

        public DataTable EmpresaConsultar(String miparametro)
        {
            DataTable dt = new DataTable(); 
            SqlDataReader leerDatos; 
            try
            {
                SqlCommand sqlCmd = new SqlCommand(); 
                sqlCmd.Connection = new ConexionDB().dbconexion; 
                sqlCmd.Connection.Open(); 
                sqlCmd.CommandText = "EmpresaConsultar"; 
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

        //public string ObtenerRutaImagenDesdeBD()
        //{
        //    string ruta = "";
        //    SqlConnection sqlCon = new SqlConnection(ConexionDB.miconexion);

        //    try
        //    {
        //        sqlCon.Open();
        //        SqlCommand cmd = new SqlCommand("SELECT Logo FROM Empresa WHERE IdEmpresa = 1", sqlCon);
        //        SqlDataReader reader = cmd.ExecuteReader();

        //        if (reader.Read())
        //        {
        //            ruta = reader["Logo"].ToString();
        //        }
        //        reader.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error al obtener la imagen: " + ex.Message);
        //    }
        //    finally
        //    {
        //        sqlCon.Close();
        //    }
        //    return ruta;
        //}
    }
}