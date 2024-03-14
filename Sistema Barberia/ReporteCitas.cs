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
    public partial class ReporteCitas : Form
    {
        public ReporteCitas()
        {
            InitializeComponent();
        }

        private void InformeCitas_Load(object sender, EventArgs e)
        {

        }

        private void Buscar_Click(object sender, EventArgs e)
        {
            String pvalor;
            pvalor = (textBox1.Text);
            // TODO: esta línea de código carga datos en la tabla 'DBCitaDataSetCita.CitaConsultar' Puede moverla o quitarla según sea necesario.
            this.CitaConsultarTableAdapter.Fill(this.DBCitaDataSetCita.CitaConsultar, pvalor);

            this.reportViewer1.RefreshReport();
        }
    }
}
