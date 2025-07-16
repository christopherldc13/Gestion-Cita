using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    public class CNRol
    {
        public DataTable ObtenerRol(string miparametro)
        {
            CDRol objRol = new CDRol();
            DataTable dt = new DataTable();
            dt = objRol.RolConsultar(miparametro);
            return dt;
        }
    }
}
