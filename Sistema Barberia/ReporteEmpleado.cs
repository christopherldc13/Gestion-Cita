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
    public partial class ReporteEmpleado : Form
    {
        public ReporteEmpleado()
        {
            InitializeComponent();
        }

        private void ReporteEmpleado_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'DBCitaDataSetEmpleado.Barbero' Puede moverla o quitarla según sea necesario.
            this.BarberoTableAdapter.Fill(this.DBCitaDataSetEmpleado.Barbero);

            this.reportViewer1.RefreshReport();
        }
    }
}
