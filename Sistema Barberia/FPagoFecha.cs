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
    public partial class FPagoFecha : Form
    {
        public FPagoFecha()
        {
            InitializeComponent();
        }

        private void FPagoFecha_Load(object sender, EventArgs e)
        {
            
        }

        private void bBuscar_Click(object sender, EventArgs e)
        {
            DateTime fecha1 = dtpFecha1.Value;
            DateTime fecha2 = dtpFecha2.Value;

           
            // TODO: esta línea de código carga datos en la tabla 'DBCitaDataSetPagoCita.PagoFecha' Puede moverla o quitarla según sea necesario.
            this.PagoFechaTableAdapter.Fill(this.DBCitaDataSetPagoCita.PagoFecha,fecha1, fecha2);

            this.reportViewer1.RefreshReport();
        }
    }
}
