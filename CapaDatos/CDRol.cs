using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CDRol
    {
        private int dIdRol;
        private String dNombreRol;

        public CDRol() { }
        public CDRol(int pIdRol, string pNombreRol)
        {
            this.dIdRol = pIdRol;
            this.dNombreRol = pNombreRol;
        }
        public int IdRol
        {
            get { return dIdRol; }
            set { dIdRol = value; }
        }

        public string NombreRol
        {
            get { return dNombreRol; }
            set { dNombreRol = value; }
        }

        public DataTable RolConsultar(String miparametro)
        {
            DataTable dt = new DataTable();
            SqlDataReader leerDatos;
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = new ConexionDB().dbconexion;
                sqlCmd.Connection.Open();
                sqlCmd.CommandText = "RolConsultar";
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
