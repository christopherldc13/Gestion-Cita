using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestor_de_Citas
{
    public partial class ReportePagoEstado : Form
    {
        public ReportePagoEstado()
        {
            InitializeComponent();
        }

        private void ReportePagoEstado_Load(object sender, EventArgs e)
        {
            
        }

        private void Bbuscar_Click(object sender, EventArgs e)
        {
            String Estado = cbEstado.Text;
            String FiltroFecha = cbFiltroFecha.Text;
            // TODO: esta línea de código carga datos en la tabla 'DataSetPagoEstado.PagoEstado' Puede moverla o quitarla según sea necesario.
            this.PagoEstadoTableAdapter.Fill(this.DataSetPagoEstado.PagoEstado, Estado, FiltroFecha);

            this.reportViewer1.RefreshReport();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
