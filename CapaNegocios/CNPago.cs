using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using CapaDatos;

namespace CapaNegocios
{
    public class CNPago
    {
        public static string Insertar(int pIdPago, int pIdCita, string pConceptoPago, string pEstado)
        {
            CDPago objPago = new CDPago();
            objPago.IdPago = pIdPago;
            objPago.IdCita = pIdCita;
            objPago.ConceptoPago = pConceptoPago;
            objPago.Estado = pEstado;
            return objPago.Insertar(objPago);
        }

        public static string Actualizar(int pIdPago, int pIdCita, string pConceptoPago, string pEstado)
        {
            CDPago objPago = new CDPago();
            objPago.IdPago = pIdPago;
            objPago.IdCita = pIdCita;
            objPago.ConceptoPago = pConceptoPago;
            objPago.Estado = pEstado;
            return objPago.Actualizar(objPago);
        }

        public DataTable ObtenerPago(string miparametro)
        {
            CDPago objPago = new CDPago();
            DataTable dt = new DataTable(); //creamos un nuevo DataTable
                                            //El DataTable se llena con todos los datos devueltos
            dt = objPago.PagoConsultar(miparametro);
            return dt; //Se retorna el DataTable con los datos adquiridos
        }

    }
}

