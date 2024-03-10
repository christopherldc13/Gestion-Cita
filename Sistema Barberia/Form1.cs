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
    public partial class FMenu : Form
    {
        public FMenu()
        {
            InitializeComponent();
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void porBarberoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel4_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            statusStrip1.Items[1].Text = "Fecha/Hora: " +DateTime.Now.ToString();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void FMenu_Load(object sender, EventArgs e)
        {

        }

        private void salidaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Esto le hará salir de la Aplicación! Seguro que desea hacerlo?",
                "Mensaje de JAC", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                e.Cancel = false;
            else
                e.Cancel = true;
        }

        private void seguridadToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MantCliente formulario = new MantCliente();
            formulario.ShowDialog();
        }

        private void empleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MantEmpleado formulario = new MantEmpleado();
            formulario.ShowDialog();
        }

        private void citaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MantCita formulario = new MantCita();
            formulario.ShowDialog();
        }

        private void registrarEmpresaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MantEmpresa formulario = new MantEmpresa();
            formulario.ShowDialog();
        }

        private void usuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MantUsuario formulario = new MantUsuario();
            formulario.ShowDialog();
        }

        private void pagoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MantPago formulario = new MantPago();
            formulario.ShowDialog();
        }
    }
}
