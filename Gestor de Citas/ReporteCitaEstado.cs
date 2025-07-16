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
    public partial class ReporteCitaEstado : Form
    {
        public ReporteCitaEstado()
        {
            InitializeComponent();
        }

        private void ReporteCitaEstado_Load(object sender, EventArgs e)
        {


        }

        private void Bbuscar_Click(object sender, EventArgs e)
        {
            string Estado = cbEstado.Text;
            string FiltroFecha = cbFiltroFecha.Text;
            // TODO: esta línea de código carga datos en la tabla 'DataSetCitaEstado.CitaEstado' Puede moverla o quitarla según sea necesario.
            this.CitaEstadoTableAdapter.Fill(this.DataSetCitaEstado.CitaEstado, Estado, FiltroFecha);

            this.reportViewer1.RefreshReport();
        }
    }
}
