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
    public partial class MantEmpleado : Form
    {
        public string valorparametro = "", mensaje = "";
        public MantEmpleado()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void MantEmpleado_Load(object sender, EventArgs e)
        {
            Program.nuevo = false; //Valores de las variables globales nuevo y modificar
            Program.modificar = false;
            HabilitaBotones(); //Se habilitarán los objetos y los botones necesarios.

        }

        private void MantEmpleado_FormClosing(object sender, FormClosingEventArgs e)
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

        private void BNuevo_Click(object sender, EventArgs e)
        {
            LimpiaObjetos(); //LLama al método LimpiaObjetos para prepararlos para la nueva entrada
            Program.nuevo = true; //Se especifica que se agregará un nuevo registro
            Program.modificar = false;
            HabilitaBotones(); //Se habilitan solo aquellos botones que sean necesarios
            tbNombre.Focus(); //Coloca el cursor en el TextBox indicado
        }

        public void LimpiaObjetos()
        {
            tbIdBarbero.Clear(); //Para limpiar TextBox.
            tbNombre.Clear(); //Para limpiar TextBox.
            tbApellido.Clear(); //Para limpiar TextBox.
            tbTelefono.Clear(); //Para limpiar TextBox.
            tbDisponibilidad.Clear(); //Para limpiar TextBox.
            cbEstado.SelectedItem = 0; //Establece el valor por defecto del Combobox
        } //Fin del método LimpiaObjetos

        private void HabilitaControles(bool valor)
        {
            tbIdBarbero.ReadOnly = true; //la propiedad ReadOnly hace de solo lectura un objeto
            tbNombre.Enabled = valor;
            tbApellido.Enabled = valor;
            tbTelefono.Enabled = valor;
            tbDisponibilidad.Enabled = valor;
            cbEstado.Enabled = valor;
            if (Program.nuevo)
                cbEstado.SelectedIndex = 0;
        }
        private void HabilitaBotones()
        {
            if (Program.nuevo || Program.modificar)
            {
                HabilitaControles(true); //Llamada al método para habilitar los objetos
                BNuevo.Enabled = false;
                BGuardar.Enabled = true;
                BEditar.Enabled = false;
                BBuscar.Enabled = false;
                BCancelar.Enabled = true;
            }
            else
            {
                HabilitaControles(false); //Llamada al método para inhabilitar los objetos
                BNuevo.Enabled = true;
                BGuardar.Enabled = false;
                BEditar.Enabled = false;
                BBuscar.Enabled = true;
                BCancelar.Enabled = false;
            }
        }

        private void BEditar_Click(object sender, EventArgs e)
        {
            //Si no ha seleccionado un Suplidor no se puede modificar
            if (!tbIdBarbero.Equals(""))
            {
                Program.modificar = true; //el formulaario se prepara para modificar datos
                HabilitaBotones();
            }
            else
            {
                MessageBox.Show("Debe de buscar un Barbero para poder Modificar sus datos!");
            }
        }

        private void BGuardar_Click(object sender, EventArgs e)
        {
            //Validamos los datos requeridos entes de Insertar o Actualizar
            if (tbNombre.Text == String.Empty) //Si el textbox está vacío mostrar un error y ubicar
            { // el cursor en dicho textbox
                MessageBox.Show("Debe indicar el Nombre del Barbero!");
                tbNombre.Focus();
            }
            else
            if (tbApellido.Text == String.Empty)
            {
                MessageBox.Show("Debe indicar el Apellido del Barbero!");
                tbApellido.Focus();
            }
            else
            if (tbTelefono.Text == String.Empty)
            {
                MessageBox.Show("Debe indicar el Teléfono del Barbero!");
                tbTelefono.Focus();
            }
            else
            if (tbDisponibilidad.Text == String.Empty)
            {
                MessageBox.Show("Debe indicar la Disponibilidad del Barbero!");
                tbDisponibilidad.Focus();
            }
            else
            if (cbEstado.Text == String.Empty)
            {
                MessageBox.Show("Debe indicar el Estado del Barbero!");
                cbEstado.Focus();
            }
            else
            {
                //Si todo es correcto procede a Insertar o actualizar según corresponda, usaremos las variables globales a toda la solución contenidas en Program.CS
                if (Program.nuevo)//Si la variable nuevo llega con valor true se van a Insertar nuevos datos
                {
                    //Se llama al método Insertar de la clase CNSuplidor de la capa de negocio
                    //pasándole como parámetros los valores leídos en los controles del formulario. como:
                    //textbox, combobox, DateTimePicker, etc.
                    //Los parámetros se pasan en el orden en que se reciben y con el tipo de dato esperado

                    mensaje = CNBarbero.Insertar(Program.vidBarbero, tbNombre.Text, tbApellido.Text,
                     tbTelefono.Text, tbDisponibilidad.Text, cbEstado.Text);
                }
                else //de lo contrario se Modificarán los datos del registro correspondiente
                {
                    //Se llama al método Insertar de la clase CNSuplidor de la capa de negocio
                    //pasándole como parámetros los valores leídos en los controles del formulario.
                    // como: textbox, combobox, DateTimePicker, etc.
                    //Los parámetros se pasan en el orden en que se reciben y con el tipo de dato esperado
                    mensaje = CNBarbero.Actualizar(Program.vidBarbero, tbNombre.Text, tbApellido.Text,
                      tbTelefono.Text, tbDisponibilidad.Text, cbEstado.Text);
                }
                //Se muestra el mensaje devuelto por la capa de negocio respecto al resultado de la operación
                MessageBox.Show(mensaje, "Mensaje de JAC", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            }

            //Se prepara todo para la próxima operación
            Program.nuevo = false;
            Program.modificar = false;
            HabilitaBotones(); //Habilita los objetos y botones correspondientes
            LimpiaObjetos(); //Llama al método LimpiaObjetos
        }

        private void MantEmpleado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void BCancelar_Click(object sender, EventArgs e)
        {
            Program.nuevo = false;
            Program.modificar = false;
            HabilitaBotones(); //Habilita los objetos y botones correspondientes
            LimpiaObjetos(); //Llama al método LimpiaObjetos
        }

        private void BBuscar_Click(object sender, EventArgs e)
        {
            //Creamos la instancia del formulario de búsqueda y lo mostramos
            FBuscarBarbero fConsultaBarbero = new FBuscarBarbero();
            fConsultaBarbero.ShowDialog();
            if (Program.modificar) //Si se está en modo de edición
            {
                RecuperaDatos(); //Llamo al método para recuperar el registro seleccionado
                BEditar_Click(sender, e); //Llamo el método del botón Editar
            }
            else //Si no estamos en modo de edición no permite la acción.
            {
                LimpiaObjetos(); //Llama al método LimpiaObjetos
                BBuscar.Focus();
            }

        }

        public void RecuperaDatos()
        {
            string vparametro = Program.vidBarbero.ToString();
            CNBarbero cNBarbero = new CNBarbero();
            DataTable dt = new DataTable(); //creamos un nuevo DataTable
            dt = cNBarbero.ObtenerBarbero(vparametro); //Llenamos el DataTable
                                                       //Recorremos cada fila del DataTable asignando a los controles de edición los valores de
                                                       //los campos correspondientes
            foreach (DataRow row in dt.Rows)
            {
                tbIdBarbero.Text = row["IdBarbero"].ToString();
                tbNombre.Text = row["Nombre"].ToString();
                tbApellido.Text = row["Apellido"].ToString();
                tbTelefono.Text = row["Telefono"].ToString();
                tbDisponibilidad.Text = row["Disponibilidad"].ToString();
                cbEstado.Text = row["Estado"].ToString();
            }
        } //Fin del metodo RecuperarDatos
    }

}
