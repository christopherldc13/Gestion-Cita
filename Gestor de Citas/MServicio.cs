using CapaNegocios;
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
    public partial class MServicio : Form
    {
        public string valorparametro = "", mensaje = "";
        public MServicio()
        {
            InitializeComponent();
        }

        private void BNuevo_Click(object sender, EventArgs e)
        {
            LimpiaObjetos(); //LLama al método LimpiaObjetos para prepararlos para la nueva entrada
            Program.nuevo = true; //Se especifica que se agregará un nuevo registro
            Program.modificar = false;
            HabilitaBotones(); //Se habilitan solo aquellos botones que sean necesarios
            tbNombreServicio.Focus(); //Coloca el cursor en el TextBox indicado
        }

        private void BGuardar_Click(object sender, EventArgs e)
        {
            if (tbNombreServicio.Text == String.Empty)
            {
                MessageBox.Show("Debe indicar el Nombre del Servicio!");
                tbNombreServicio.Focus();
                return;
            }
            else
            if (textBox1.Text == String.Empty)
            {
                MessageBox.Show("Debe indicar el Precio del Servicio!");
                textBox1.Focus();
                return;
            }
            else
            if (cbDuracion.Text == String.Empty)
            {
                MessageBox.Show("Debe de selecionar la duración del Servicio");
                cbDuracion.Focus();
                return;
            }
            else
            if (comboBox2.Text == String.Empty)
            {
                MessageBox.Show("Debe indicar el Estado del Servicio!");
                comboBox2.Focus();
                return;
            }
            else
            {
                if (Program.nuevo)
                {
                    mensaje = CNServicio.Insertar(Program.vidServicio, tbNombreServicio.Text, Convert.ToInt32(textBox1.Text),
                        Convert.ToInt32(cbDuracion.Text), comboBox2.Text);
                }
                else
                {
                    mensaje = CNServicio.Actualizar(Program.vidServicio, tbNombreServicio.Text, Convert.ToInt32(textBox1.Text),
                        Convert.ToInt32(cbDuracion.Text), comboBox2.Text);
                }
                //Se muestra el mensaje devuelto por la capa de negocio respecto al resultado de la operación
                MessageBox.Show(mensaje, "Mensaje de " + Program.copyright, MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            }

            Program.nuevo = false;
            Program.modificar = false;
            HabilitaBotones();
            LimpiaObjetos();
        }
        public void LimpiaObjetos()
        {
            tbIdServicio.Clear();
            tbNombreServicio.Clear();
            cbDuracion.SelectedIndex = -1;
            textBox1.Clear();
            comboBox2.SelectedIndex = -1;

        }

        private void MServicio_Load(object sender, EventArgs e)
        {
            Program.nuevo = false; //Valores de las variables globales nuevo y modificar
            Program.modificar = false;
            HabilitaBotones(); //Se habilitarán los objetos y los botones necesarios.
        }

        private void HabilitaBotones()
        {
            if (Program.nuevo || Program.modificar)
            {
                HabilitaControles(true);
                BNuevo.Enabled = false;
                BGuardar.Enabled = true;
                BEditar.Enabled = false;
                BBuscar.Enabled = false;
                BCancelar.Enabled = true;
            }
            else
            {
                HabilitaControles(false);
                BNuevo.Enabled = true;
                BGuardar.Enabled = false;
                BEditar.Enabled = false;
                BBuscar.Enabled = true;
                BCancelar.Enabled = false;
            }
        }

        private void MServicio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                // Guarda el valor del control actual
                if (tbNombreServicio.Focused)
                {
                    // Guarda tbNombreServicio.Text en la variable o en la base de datos.
                }
                else if (textBox1.Focused)
                {
                    // Guarda textBox1.Text en la variable o en la base de datos.
                }
                else if (cbDuracion.Focused)
                {
                    // Guarda cbDuracion.Text en la variable o en la base de datos.
                }
                else if (comboBox2.Focused)
                {
                    // Guarda comboBox2.Text en la variable o en la base de datos.
                }

                SendKeys.Send("{TAB}");
            }
        }

        private void HabilitaControles(bool valor)
        {
            tbIdServicio.ReadOnly = true; //la propiedad ReadOnly hace de solo lectura un objeto
            tbNombreServicio.Enabled = valor; //la propiedad Enabled habilita o inhabilita un objeto
            textBox1.Enabled = valor;
            cbDuracion.Enabled = valor;
            comboBox2.Enabled = valor;
            if (Program.nuevo)
                comboBox2.SelectedIndex = 0;
            if (Program.nuevo)
                cbDuracion.SelectedIndex = 0;

        } //Fin del método HabilitaControles
    }
}
