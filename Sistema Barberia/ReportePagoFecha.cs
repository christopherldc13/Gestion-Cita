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
    public partial class ReportePagoFecha : Form
    {
        public ReportePagoFecha()
        {
            InitializeComponent();
        }

        private void ReportePagoFecha_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime Fecha1 = FechaPicker1.Value;
            DateTime Fecha2 = FechaPicker2.Value;
            // TODO: esta línea de código carga datos en la tabla 'DBCitaDataSetPagoFecha.PagoFecha' Puede moverla o quitarla según sea necesario.
            this.PagoFechaTableAdapter.Fill(this.DBCitaDataSetPagoFecha.PagoFecha, Fecha1, Fecha2);

            this.reportViewer1.RefreshReport();
        }
    }
}
