using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using CapaNegocios;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Gestor_de_Citas
{
    public partial class MantServicio : Form
    {
        public string valorparametro = "", mensaje = "";
        public MantServicio()
        {
            InitializeComponent();
        }

        private void MantServicio_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¡Esto hara salir del formulario! \n ¿Seguro que desea hacerlo?",
                               "Mensaje de" + " " + Program.copyright,
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
        private void MantServicio_Load(object sender, EventArgs e)
        {
            Program.nuevo = false; //Valores de las variables globales nuevo y modificar
            Program.modificar = false;
            HabilitaBotones(); //Se habilitarán los objetos y los botones necesarios.
            textBox1.KeyPress += new KeyPressEventHandler(textBox1_KeyPress);

        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es un número (0-9) o la tecla de retroceso (Backspace)
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                // Si no es un número ni la tecla de retroceso, se cancela la acción
                e.Handled = true;
            }
        }
        public void LimpiaObjetos()
        {
            tbIdServicio.Clear(); 
            tbNombreServicio.Clear(); 
            cbDuracion.SelectedIndex = -1;
            textBox1.Clear();
            comboBox2.SelectedIndex = -1;

        } 

        private void HabilitaControles(bool valor)
        {
            tbIdServicio.Enabled = false; //la propiedad ReadOnly hace de solo lectura un objeto
            tbNombreServicio.Enabled = valor; //la propiedad Enabled habilita o inhabilita un objeto
            textBox1.Enabled = valor;
            cbDuracion.Enabled = valor;
            comboBox2.Enabled = valor;
            if (Program.nuevo)
            {
                comboBox2.SelectedIndex = 0;
                comboBox2.Enabled = false;
                cbDuracion.SelectedIndex = 0;
            }
                

        } //Fin del método HabilitaControles

        private void BBuscar_Click(object sender, EventArgs e)
        {
            //Creamos la instancia del formulario de búsqueda y lo mostramos
            FBuscarServicio fConsultaServicio = new FBuscarServicio();
            fConsultaServicio.ShowDialog();
            if (Program.modificar) //Si se está en modo de edición
            {
                RecuperaDatos(); //Llamo al método para recuperar el registro seleccionado
                BEditar_Click(sender, e); //Llamo el método del botón Editar
                tbNombreServicio.Focus();
            }
            else //Si no estamos en modo de edición no permite la acción.
            {
                LimpiaObjetos(); //Llama al método LimpiaObjetos
                BBuscar.Focus();
            }
        }

        //public void RecuperaDatos()
        //{
        //    string vparametro = Program.vidServicio.ToString();
        //    CNServicio cNServicio = new CNServicio();
        //    DataTable dt = new DataTable(); //creamos un nuevo DataTable
        //    dt = cNServicio.ObtenerServicio(vparametro); //Llenamos el DataTable
        //                                                 //Recorremos cada fila del DataTable asignando a los controles de edición los valores de
        //                                                 //los campos correspondientes
        //    foreach (DataRow row in dt.Rows)

        //    {
        //        tbIdServicio.Text = row["ID"].ToString();
        //        tbNombreServicio.Text = row["NombreServicio"].ToString();
        //        textBox1.Text = row["Precio"].ToString();
        //        cbDuracion.Text = row["Duracion"].ToString();
        //        comboBox2.Text = row["Estado"].ToString();


        //    }
        //} //Fin del metodo RecuperarDatos

        public void RecuperaDatos()
        {
            string vparametro = Program.vidServicio.ToString();
            CNServicio cNServicio = new CNServicio();
            DataTable dt = new DataTable(); // Creamos un nuevo DataTable
            dt = cNServicio.ObtenerServicio(vparametro); // Llenamos el DataTable

            // Recorremos cada fila del DataTable asignando a los controles de edición los valores de los campos correspondientes
            foreach (DataRow row in dt.Rows)
            {
                tbIdServicio.Text = row["ID"].ToString();
                tbNombreServicio.Text = row["NombreServicio"].ToString();

                // Extraer solo los números del precio (quitando RD$, espacios u otros caracteres)
                string precioNumerico = System.Text.RegularExpressions.Regex.Match(row["Precio"].ToString(), @"\d+").Value;
                textBox1.Text = precioNumerico;

                // Extraer solo los números de la duración (quitando "Min" u otras letras)
                string duracionNumerica = System.Text.RegularExpressions.Regex.Match(row["Duracion"].ToString(), @"\d+").Value;
                cbDuracion.Text = duracionNumerica;

                comboBox2.Text = row["Estado"].ToString();
            }
        } // Fin del método RecuperaDatos


        private void BCancelar_Click(object sender, EventArgs e)
        {
            Program.nuevo = false;
            Program.modificar = false;
            HabilitaBotones(); //Habilita los objetos y botones correspondientes
            LimpiaObjetos(); //Llama al método LimpiaObjetos
        }

        private void BNuevo_Click(object sender, EventArgs e)
        {
            LimpiaObjetos(); //LLama al método LimpiaObjetos para prepararlos para la nueva entrada
            Program.nuevo = true; //Se especifica que se agregará un nuevo registro
            Program.modificar = false;
            HabilitaBotones(); //Se habilitan solo aquellos botones que sean necesarios
            //comboBox2.Enabled = false;
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
                MessageBoxIcon.None);
            }
            if (mensaje.Contains("insertados correctamente") || mensaje.Contains("actualizados correctamente"))
            {
                Program.nuevo = false;
                Program.modificar = false;
                HabilitaBotones();
                LimpiaObjetos();
            }
        }

        private void MantServicio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; 
                SendKeys.Send("{TAB}");
            }
        }

        private void BEditar_Click(object sender, EventArgs e)
        {
            if (!tbIdServicio.Equals(""))
            {
                Program.modificar = true;
                HabilitaBotones();
            }
            else
            {
                MessageBox.Show("Debe de buscar un Servicio para poder Modificar sus datos!");
            }
        }

        private void PTitulo_Paint(object sender, PaintEventArgs e)
        {

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
                comboBox2.Enabled = false;
            }
        }
    }
}
