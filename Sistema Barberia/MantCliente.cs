using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//para poder utilizar las instrucciones de SQL
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
//Para acceder a la capa de negocio
using CapaNegocios;

namespace Sistema_Barberia
{
    public partial class MantCliente : Form
    {
        public string valorparametro = "", mensaje = "";
        public MantCliente()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void MantCliente_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void MantCliente_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Esto hara salir del formulario! \n Seguro que desea hacerlo?",
                                "Mensaje de JAC",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question,
                                MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                e.Cancel = false;
            else
                e.Cancel = true;

        }

        private void BSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
        public void LimpiaObjetos()
        {
            tbIdCliente.Clear(); //Para limpiar TextBox.
            tbNombre.Clear(); //Para limpiar TextBox.
            tbApellido.Clear(); //Para limpiar TextBox.
            tbTelefono.Clear(); //Para limpiar TextBox.
            tbCorreo.Clear(); //Para limpiar TextBox.
            cbEstado.SelectedItem = 0; //Establece el valor por defecto del Combobox
        } //Fin del método LimpiaObjetos

        private void BGuardar_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void BSalir_Click_1(object sender, EventArgs e)
        {

        }

        private void BBuscar_Click(object sender, EventArgs e)
        {

        }

        private void BNuevo_Click(object sender, EventArgs e)
        {

        }

        //Habilita / inhabilita los objetos del formulario segun lo indicado por el parámetro valor
        private void HabilitaControles(bool valor)
        {
            tbIdCliente.ReadOnly = true; //la propiedad ReadOnly hace de solo lectura un objeto
            tbNombre.Enabled = valor;
            tbApellido.Enabled = valor;
            tbTelefono.Enabled = valor;
            tbCorreo.Enabled = valor;
            cbEstado.Enabled = valor;
            if (nuevo)
                cbEstado.SelectedIndex = 0;
        }

       



    }
}
