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
    public partial class FormBarbero : Form
    {
        public FormBarbero()
        {
            InitializeComponent();
        }

        private void FormBarbero_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'DBCitaDataSet2.Barbero' Puede moverla o quitarla según sea necesario.
            this.BarberoTableAdapter.Fill(this.DBCitaDataSet2.Barbero);

            this.reportViewer1.RefreshReport();
        }
    }
}
