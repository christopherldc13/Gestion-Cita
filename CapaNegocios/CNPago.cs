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
            DataTable dt = new DataTable(); 
            dt = objPago.PagoConsultar(miparametro);
            return dt; 
        }

        //Cuadro de Pagos: PENDIENTE y PAGADO
        public static bool ObtenerEstadisticasPagosHoy(out int pendientes, out int pagadas)
        {
            CDPago obj = new CDPago();
            return obj.ObtenerEstadisticasPagosHoy(out pendientes, out pagadas);
        }


        //Grafico 1, Ganancias Diarias
        public static DataTable ObtenerGananciasDiariasChart()
        {
            CDPago obj = new CDPago();
            return obj.ObtenerGananciasDiariasChart();
        }

        //Graficos 2, Ganancias Semanales
        public static DataTable ObtenerGananciasSemanalesChart()
        {
            CDPago obj = new CDPago();
            return obj.ObtenerGananciasSemanalesChart();
        }

        //Grafico 3, Grafico mensual, solo llega a los 6 meses
        public static DataTable ObtenerGananciasMensualesChart()
        {
            return new CDPago().ObtenerGananciasMensualesChart();
        }


    }
}

