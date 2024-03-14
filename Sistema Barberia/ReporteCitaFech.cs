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
    public partial class ReporteCitaFech : Form
    {
        public ReporteCitaFech()
        {
            InitializeComponent();
        }

        private void ReporteCitaFech_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'DBCitaDataSetCitasFech.CitaFechaConsultar' Puede moverla o quitarla según sea necesario.
            //this.CitaFechaConsultarTableAdapter.Fecha(this.DBCitaDataSetCitasFech.CitaFechaConsultar, fecha1Str, fecha2Str);

            //this.reportViewer1.RefreshReport();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Obtener las fechas seleccionadas de los DateTimePicker
            DateTime fecha1 = fecha1Picker.Value;
            DateTime fecha2 = fecha2Picker.Value;

            // Convertir las fechas a cadenas con el formato deseado
            this.CitaFechaConsultarTableAdapter.Fecha(this.DBCitaDataSetCitasFech.CitaFechaConsultar, fecha1, fecha2);

            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
