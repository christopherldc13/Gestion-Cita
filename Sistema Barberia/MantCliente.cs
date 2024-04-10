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
            Program.nuevo = false; //Valores de las variables globales nuevo y modificar
            Program.modificar = false;
            HabilitaBotones(); //Se habilitarán los objetos y los botones necesarios.
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
            //Validamos los datos requeridos entes de Insertar o Actualizar
            if (tbNombre.Text == String.Empty) //Si el textbox está vacío mostrar un error y ubicar
            { // el cursor en dicho textbox
                MessageBox.Show("Debe indicar el Nombre del Cliente!");
                tbNombre.Focus();
            }
            else
            if (tbApellido.Text == String.Empty)
            {
                MessageBox.Show("Debe indicar el Apellido del Cliente!");
                tbApellido.Focus();
            }
            else
            if (tbTelefono.Text == String.Empty)
            {
                MessageBox.Show("Debe indicar el Teléfono del Cliente!");
                tbTelefono.Focus();
            }
            else
            if (tbCorreo.Text == String.Empty)
            {
                MessageBox.Show("Debe indicar el Correo del Cliente!");
                tbCorreo.Focus();
            }
            else
            if (cbEstado.Text == String.Empty)
            {
                MessageBox.Show("Debe indicar el Estado del Cliente!");
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

                    mensaje = CNCliente.Insertar(Program.vidCliente, tbNombre.Text, tbApellido.Text,
                     tbTelefono.Text, tbCorreo.Text, cbEstado.Text);
                }
                else //de lo contrario se Modificarán los datos del registro correspondiente
                {
                    //Se llama al método Insertar de la clase CNSuplidor de la capa de negocio
                    //pasándole como parámetros los valores leídos en los controles del formulario.
                    // como: textbox, combobox, DateTimePicker, etc.
                    //Los parámetros se pasan en el orden en que se reciben y con el tipo de dato esperado
                    mensaje = CNCliente.Actualizar(Program.vidCliente, tbNombre.Text, tbApellido.Text,
                      tbTelefono.Text, tbCorreo.Text, cbEstado.Text);
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
            } //Fin del else para validar los datos

        

        //Se llama al método Insertar de la clase CNSuplidor de la capa de negocio
        //pasándole como parámetros los valores leídos en los controles del formulario. como:
        //textbox, combobox, DateTimePicker, etc.
        //Los parámetros se pasan en el orden en que se reciben y con el tipo de dato esperado
    


        private void BSalir_Click_1(object sender, EventArgs e)
        {
            this.Close();

        }

        private void BBuscar_Click(object sender, EventArgs e)
        {
           
            //Creamos la instancia del formulario de búsqueda y lo mostramos
            FBuscarCliente fConsultaCliente = new FBuscarCliente();
            fConsultaCliente.ShowDialog();
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
            string vparametro = Program.vidCliente.ToString();
            CNCliente cNCliente = new CNCliente();
            DataTable dt = new DataTable(); //creamos un nuevo DataTable
            dt = cNCliente.ObtenerCliente(vparametro); //Llenamos el DataTable
                                                              //Recorremos cada fila del DataTable asignando a los controles de edición los valores de
                                                              //los campos correspondientes
            foreach (DataRow row in dt.Rows)
            
            {
                tbIdCliente.Text = row["IdCliente"].ToString();
                tbNombre.Text = row["Nombre"].ToString();
                tbApellido.Text = row["Apellido"].ToString();
                tbTelefono.Text = row["Telefono"].ToString();
                tbCorreo.Text = row["Correo"].ToString();
                cbEstado.Text = row["Estado"].ToString();
            }
        } //Fin del metodo RecuperarDatos


        private void BNuevo_Click(object sender, EventArgs e)
        {
            LimpiaObjetos(); //LLama al método LimpiaObjetos para prepararlos para la nueva entrada
            Program.nuevo = true; //Se especifica que se agregará un nuevo registro
            Program.modificar = false;
            HabilitaBotones(); //Se habilitan solo aquellos botones que sean necesarios
            tbNombre.Focus(); //Coloca el cursor en el TextBox indicado
        }

        private void label1_Click_2(object sender, EventArgs e)
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
            if (Program.nuevo)
                cbEstado.SelectedIndex = 0;
        }

        private void BCancelar_Click(object sender, EventArgs e)
        {
            Program.nuevo = false;
            Program.modificar = false;
            HabilitaBotones(); //Habilita los objetos y botones correspondientes
            LimpiaObjetos(); //Llama al método LimpiaObjetos
        }

        private void MantCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }

        }

        private void BEditar_Click(object sender, EventArgs e)
        {
            //Si no ha seleccionado un Suplidor no se puede modificar
            if (!tbIdCliente.Equals(""))
            {
                Program.modificar = true; //el formulaario se prepara para modificar datos
                HabilitaBotones();
            }
            else
            {
                MessageBox.Show("Debe de buscar un Cliente para poder Modificar sus datos!");
            }
        }

        private void BGuardar_Click_1(object sender, EventArgs e)
        {

        }

        //Habilita los botones según el valor que tengan las variables globales nuevo y modificar
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

    }

}
