using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_Barberia
{
    public partial class ReportesPagos : Form
    {
        public ReportesPagos()
        {
            InitializeComponent();
        }

        private void ReportesPagos_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String pvalor;
            pvalor = (tbValor.Text);

            // TODO: esta línea de código carga datos en la tabla 'DBCitaDataSetPagos.PagoConsultar' Puede moverla o quitarla según sea necesario.
            this.PagoConsultarTableAdapter.Pago(this.DBCitaDataSetPagos.PagoConsultar, pvalor);

            this.reportViewer1.RefreshReport();
        }
    }
}
