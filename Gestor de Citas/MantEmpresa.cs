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

namespace Gestor_de_Citas
{
    public partial class MantEmpresa : Form
    {
        public string valorparametro = "", mensaje = "";
        public MantEmpresa()
        {
            InitializeComponent();
            tbTelefono.TextChanged += tbTelefono_TextChanged;
        }

        private void MantEmpresa_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¡Esto hara salir del formulario! \n ¿Seguro que desea hacerlo?",
                                "Mensaje de " + Program.copyright,
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

        private void MantEmpresa_Load(object sender, EventArgs e)
        {
            
            Program.nuevo = false; 
            Program.modificar = false;
            HabilitaBotones(); 

        }

        public void LimpiaObjetos()
        {
            tbIdEmpresa.Clear(); 
            tbNombre.Clear(); 
            tbTelefono.Clear(); 
            tbDireccion.Clear(); 
            tbCorreo.Clear(); 
            tbLogo.Clear();
            tbEslogan.Clear();
        }

        //Habilita / inhabilita los objetos del formulario segun lo indicado por el parámetro valor
        private void HabilitaControles(bool valor)
        {
            tbIdEmpresa.Enabled = false; //la propiedad ReadOnly hace de solo lectura un objeto
            tbNombre.Enabled = valor; //la propiedad Enabled habilita o inhabilita un objeto
            tbTelefono.Enabled = valor;
            tbDireccion.Enabled = valor;
            tbCorreo.Enabled = valor;
            tbLogo.Enabled = valor;
            tbEslogan.Enabled = valor;
        } //Fin del método HabilitaControles

        private void BNuevo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Esta Opción está deshabilitada, pulse buscar para editar los datos de la empresa", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //LimpiaObjetos(); //LLama al método LimpiaObjetos para prepararlos para la nueva entrada
            //Program.nuevo = true; //Se especifica que se agregará un nuevo registro
            //Program.modificar = false;
            //HabilitaBotones(); //Se habilitan solo aquellos botones que sean necesarios
            //tbNombre.Focus(); //Coloca el cursor en el TextBox indicado
        }

        private void BGuardar_Click(object sender, EventArgs e)
        {
            //Validamos los datos requeridos entes de Insertar o Actualizar
            if (tbNombre.Text == String.Empty) //Si el textbox está vacío mostrar un error y ubicar
            { // el cursor en dicho textbox
                MessageBox.Show("Debe indicar el Nombre de la Empresa!");
                tbNombre.Focus();
            }
            else
            if (tbTelefono.Text == String.Empty)
            {
                MessageBox.Show("Debe indicar el Telefono de la Empresa!");
                tbTelefono.Focus();
            }
            else
            if (tbDireccion.Text == String.Empty)
            {
                MessageBox.Show("Debe indicar la Direccion de la Empresa!");
                tbDireccion.Focus();
            }
            else
            if (tbCorreo.Text == String.Empty)
            {
                MessageBox.Show("Debe indicar el Correo de la Empresa!");
                tbCorreo.Focus();
            }
            else
            if (tbLogo.Text == String.Empty)
            {
                MessageBox.Show("Debe indicar el Logo de la Empresa!");
                tbLogo.Focus();
            }
            else
            if (tbEslogan.Text == String.Empty)
            {
                MessageBox.Show("Debe indicar el Eslogan de la Empresa!");
                tbEslogan.Focus();
            }
            else
            {
                //Si todo es correcto procede a Insertar o actualizar según corresponda, usaremos las variables globales a toda la solución contenidas en Program.CS
                if (Program.nuevo)//Si la variable nuevo llega con valor true se van a Insertar nuevos datos
                {
                    mensaje = CNEmpresa.Insertar(Program.vidEmpresa, tbNombre.Text, tbTelefono.Text,
                     tbDireccion.Text, tbCorreo.Text, tbLogo.Text, tbEslogan.Text);
                }
                else //de lo contrario se Modificarán los datos del registro correspondiente
                {

                    mensaje = CNEmpresa.Actualizar(Program.vidEmpresa, tbNombre.Text, tbTelefono.Text,
                    tbDireccion.Text, tbCorreo.Text, tbLogo.Text, tbEslogan.Text);
                }
                MessageBox.Show(mensaje, "Mensaje de " + Program.copyright, MessageBoxButtons.OK,
               MessageBoxIcon.None);

            }


            //Se prepara todo para la próxima operación
            Program.nuevo = false;
            Program.modificar = false;
            HabilitaBotones(); //Habilita los objetos y botones correspondientes
            LimpiaObjetos(); //Llama al método LimpiaObjetos
        }

        private void BEditar_Click(object sender, EventArgs e)
        {
            //Si no ha seleccionado un Suplidor no se puede modificar
            if (!tbIdEmpresa.Equals(""))
            {
                Program.modificar = true; //el formulario se prepara para modificar datos
                HabilitaBotones();
            }
            else
            {
                MessageBox.Show("Debe de buscar un algo de la Empresa para poder Modificar sus datos!");
            }
        }

        private void MantEmpresa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Esto evita que el sonido de la tecla sea reproducido
                SendKeys.Send("{TAB}");
            }

        }

        private void BCancelar_Click(object sender, EventArgs e)
        {
            Program.nuevo = false;
            Program.modificar = false;
            HabilitaBotones(); //Habilita los objetos y botones correspondientes
            LimpiaObjetos(); //Llama al método LimpiaObjetos
            BNuevo.Focus();
        }

        //private void BBuscar_Click(object sender, EventArgs e)
        //{

        //}
        public void RecuperaDatos()
        {
            string vparametro = Program.vidEmpresa.ToString();
            CNEmpresa cNEmpresa = new CNEmpresa();
            DataTable dt = new DataTable(); //creamos un nuevo DataTable
            dt = cNEmpresa.ObtenerEmpresa(vparametro); //Llenamos el DataTable
                                                       //Recorremos cada fila del DataTable asignando a los controles de edición los valores de
                                                       //los campos correspondientes
            foreach (DataRow row in dt.Rows)
            {
                tbIdEmpresa.Text = row["IdEmpresa"].ToString();
                tbNombre.Text = row["Nombre"].ToString();
                tbTelefono.Text = row["Telefono"].ToString();
                tbDireccion.Text = row["Direccion"].ToString();
                tbCorreo.Text = row["Correo"].ToString();
                tbLogo.Text = row["Logo"].ToString();
                tbEslogan.Text = row["Eslogan"].ToString();
            }
        } //Fin del metodo RecuperarDatos

        private void button2_Click(object sender, EventArgs e)
        {
            //Creamos la instancia del formulario de búsqueda y lo mostramos
            FBuscarEmpresa fConsultaEmpresa = new FBuscarEmpresa();
            fConsultaEmpresa.ShowDialog();
            if (Program.modificar) //Si se está en modo de edición
            {
                RecuperaDatos(); //Llamo al método para recuperar el registro seleccionado
                BEditar_Click(sender, e); //Llamo el método del botón Editar
            }
            else //Si no estamos en modo de edición no permite la acción.
            {
                LimpiaObjetos(); //Llama al método LimpiaObjetos
                //BSalir.Focus();
            }
        }

        private void BBuscar_Click(object sender, EventArgs e)
        {

        }

        private void HabilitaBotones()
        {
            if (Program.nuevo || Program.modificar)
            {
                HabilitaControles(true); //Llamada al método para habilitar los objetos
                BNuevo.Enabled = false;
                BGuardar.Enabled = true;
                BEditar.Enabled = false;
                button2.Enabled = false;
                BCancelar.Enabled = true;
            }
            else
            {
                HabilitaControles(false); //Llamada al método para inhabilitar los objetos
                BNuevo.Enabled = true;
                BGuardar.Enabled = false;
                BEditar.Enabled = false;
                button2.Enabled = true;
                BCancelar.Enabled = false;
            }
        }

        private void tbTelefono_TextChanged(object sender, EventArgs e)
        {
            string numeros = new string(tbTelefono.Text.Where(char.IsDigit).ToArray());

            if (numeros.Length > 10)
                numeros = numeros.Substring(0, 10); // Limitar a 10 dígitos

            string formattedNumber = FormatPhoneNumber(numeros);

            // Solo actualizar el texto si ha cambiado realmente
            if (tbTelefono.Text != formattedNumber)
            {
                tbTelefono.Text = formattedNumber;
                tbTelefono.SelectionStart = formattedNumber.Length; // Mantener el cursor al final
            }
        }

        private string FormatPhoneNumber(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return ""; // Si el input está vacío, no hay paréntesis ni formato
            }
            else if (input.Length <= 3)
            {
                return $"({input}";
            }
            else if (input.Length <= 6)
            {
                return $"({input.Substring(0, 3)}) {input.Substring(3)}";
            }
            else
            {
                return $"({input.Substring(0, 3)}) {input.Substring(3, 3)}-{input.Substring(6)}";
            }
        }
    }
}
