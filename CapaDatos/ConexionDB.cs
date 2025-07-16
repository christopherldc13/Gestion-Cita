using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;

namespace CapaDatos
{
    public class ConexionDB
    {
        public static string miconexion = @"Data Source=.\SQLEXPRESS;Initial Catalog=Gestor_Cita;Persist Security Info=True;User ID=sa;Password=1234;Encrypt=True;TrustServerCertificate=True";
        public SqlConnection dbconexion = new SqlConnection(miconexion);

        //public static string miconexion = @"Data Source=sqlserver-gestor.database.windows.net;Initial Catalog=Gestor_Cita;Persist Security Info=True;User ID=sql-gestor;Password=@Cristopher13;Encrypt=True;TrustServerCertificate=True";
        //public SqlConnection dbconexion = new SqlConnection(miconexion);

        //public static string miconexion = @"Data Source=34.102.42.63;Initial Catalog=Gestor_Cita;Persist Security Info=True;User ID=sqlserver;Password=H.TMM8pe+}u@7m+?;TrustServerCertificate=True";
        //public SqlConnection dbconexion = new SqlConnection(miconexion);

        //Conexión Local
        //public static string miconexion = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\laragon\JAC-Software\Gestion-Cita\CapaDatos\DBCita.mdf;Integrated Security=True";
        //Conexion SqlServer 
        //public static string miconexion = @"Data Source=DESKTOP-0LAM0C8\SQLEXPRESS;Initial Catalog=DBCita;User Id=sa;Password=1234;TrustServerCertificate=True;";
        //public static string miconexion = @"Data Source=DESKTOP-0LAM0C8\SQLEXPRESS;Initial Catalog=DBCita;Persist Security Info=True;User ID=sa;Password=1234;Encrypt=True;TrustServerCertificate=True";
    }
}