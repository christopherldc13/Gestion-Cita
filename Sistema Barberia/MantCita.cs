using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocios;
//para poder utilizar las instrucciones de SQL
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace Sistema_Barberia
{
    public partial class MantCita : Form
    {
        public string valorparametro = "", mensaje = "";
        //public static bool nuevo = true;

        public MantCita()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void MantCita_Load(object sender, EventArgs e)
        {
            Program.nuevo = false; //Valores de las variables globales nuevo y modificar
            Program.modificar = false;
            HabilitaBotones(); //Se habilitarán los objetos y los botones necesarios.

        }

        private void BSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MantCita_FormClosing(object sender, FormClosingEventArgs e)
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

        private void cbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void PTitulo_Paint(object sender, PaintEventArgs e)
        {

        }

        public void LimpiaObjetos()
        {

            tbIdCita.Clear(); //Para limpiar TextBox.
            dtpFecha.Value = DateTime.Today; //Para limpiar TextBox.
            dtpHora.Value = DateTime.Now;
            cbEstado.SelectedItem = 0;
            tbIdCliente.Clear(); //Para limpiar TextBox.
            tbNombreCliente.Clear(); //Para limpiar TextBox.
            tbApellidoCliente.Clear();
            tbTelefonoCliente.Clear();
            tbIdEmpleado.Clear(); //Para limpiar TextBox.
            tbNombreEmpleado.Clear();
            tbTelefonoEmpleado.Clear();
            
        } //Fin del método LimpiaObjetos

        //Habilita / inhabilita los objetos del formulario segun lo indicado por el parámetro valor
        private void HabilitaControles(bool valor)
        {
            tbIdCita.ReadOnly = true; //la propiedad ReadOnly hace de solo lectura un objeto
            dtpFecha.Enabled = valor; //la propiedad Enabled habilita o inhabilita un objeto
            cbEstado.Enabled = valor;
            tbIdCliente.ReadOnly = true;
            tbNombreCliente.ReadOnly = true;
            tbApellidoCliente.ReadOnly = true;
            tbTelefonoCliente.ReadOnly = true;
            tbIdEmpleado.ReadOnly = true;
            tbNombreEmpleado.ReadOnly = true;
            tbTelefonoEmpleado.ReadOnly = true;
            if (Program.nuevo)
                cbEstado.SelectedIndex = 0;
        } //Fin del método HabilitaControles

        private void BNuevo_Click(object sender, EventArgs e)
        {
            LimpiaObjetos(); //LLama al método LimpiaObjetos para prepararlos para la nueva entrada
            Program.nuevo = true; //Se especifica que se agregará un nuevo registro
            Program.modificar = false;
            HabilitaBotones(); //Se habilitan solo aquellos botones que sean necesarios
            dtpFecha.Focus(); //Coloca el cursor en el TextBox indicado
            cbEstado.Enabled = false;
        }

        private void BGuardar_Click(object sender, EventArgs e)
        {
            //Validamos los datos requeridos entes de Insertar o Actualizar
            if (dtpFecha.Text == String.Empty) //Si el textbox está vacío mostrar un error y ubicar
            { // el cursor en dicho textbox
                MessageBox.Show("Debe indicar la fecha en la que desee hacer la Cita!");
                dtpFecha.Focus();
            }
            else
            if (dtpHora.Text == String.Empty)
            {
                MessageBox.Show("Debes de Indicar la Hora de la Cita");
                dtpHora.Focus();
            }
            else
            if (cbEstado.Text == String.Empty)//Ojo 
            {
                MessageBox.Show("Debe indicar el estado de la Cita!");
                cbEstado.Focus();
            }
            else
            if (tbIdCliente.Text == String.Empty)
            {
                MessageBox.Show("Debe indicar el Cliente que desea hacer la Cita!");
                BBuscarCliente.Focus();
            }
            else
            if (tbIdEmpleado.Text == String.Empty)
            {
                MessageBox.Show("Debe indicar el Correo del Cliente!");
                BBuscarEmpleado.Focus();
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
                    //MessageBox.Show("Entre a nuevo"+Program.vidCliente.ToString() + " " + Program.vidBarbero.ToString());
                    mensaje = CNCita.Insertar(Program.vidCita, Program.vidCliente, Program.vidBarbero,
                     dtpFecha.Value, dtpHora.Value, cbEstado.Text);
                }
                else  //de lo contrario se Modificarán los datos del registro correspondiente
                {

                    //Se llama al método Insertar de la clase CNSuplidor de la capa de negocio
                    //pasándole como parámetros los valores leídos en los controles del formulario.
                    // como: textbox, combobox, DateTimePicker, etc.
                    //Los parámetros se pasan en el orden en que se reciben y con el tipo de dato esperado
                    //MessageBox.Show("Entre a Actualizar" + Program.vidCliente.ToString() + " " + Program.vidBarbero.ToString());
                    mensaje = CNCita.Actualizar(Program.vidCita, Program.vidCliente, Program.vidBarbero,
                     dtpFecha.Value, dtpHora.Value, cbEstado.Text);
                }
            
            //Se muestra el mensaje devuelto por la capa de negocio respecto al resultado de la operación
            MessageBox.Show(mensaje, "Mensaje de JAC", MessageBoxButtons.OK,  MessageBoxIcon.Information);
            }
            //Se prepara todo para la próxima operación
            Program.nuevo = false;
            Program.modificar = false;
            HabilitaBotones(); //Habilita los objetos y botones correspondientes
            LimpiaObjetos(); //Llama al método LimpiaObjetos
        }

        private void BBuscarCita_Click(object sender, EventArgs e)
        {
            //Creamos la instancia del formulario de búsqueda y lo mostramos
            FBuscarCita fConsultaCita = new FBuscarCita();
            fConsultaCita.ShowDialog();
            if (Program.modificar) //Si se está en modo de edición
            {
                RecuperaDatosCita(); //Llamo al método para recuperar el registro seleccionado
                BEditar_Click(sender, e); //Llamo al método editar
            }
            else //Si no estamos en modo de edición no permite la acción.
            {
                LimpiaObjetos(); //Llama al método LimpiaObjetos
                BBuscarCita.Focus();
            }
        }

        public void RecuperaDatosCita()
        {
            string vparametro = Program.vidCita.ToString();
            CNCita cNCita = new CNCita();
            DataTable dt = new DataTable(); //creamos un nuevo DataTable
            dt = cNCita.ObtenerCita(vparametro); //Llenamos el DataTable
                                                       //Recorremos cada fila del DataTable asignando a los controles de edición los valores de
                                                       //los campos correspondientes
            foreach (DataRow row in dt.Rows)
            {
                
                tbIdCita.Text = row["IdCita"].ToString();
                tbIdCliente.Text = row["IdCliente"].ToString();
                tbNombreCliente.Text = row["NombreCliente"].ToString();
                tbApellidoCliente.Text = row["Apellido"].ToString();
                tbTelefonoCliente.Text = row["Telefono"].ToString();
                tbIdEmpleado.Text = row["IdBarbero"].ToString();
                tbNombreEmpleado.Text = row["NombreBarbero"].ToString();
                tbTelefonoEmpleado.Text = row["Telefono"].ToString();
                dtpFecha.Text = row["Fecha"].ToString();
                dtpHora.Text = row["Hora"].ToString();
                cbEstado.Text = row["Estado"].ToString();
                Program.vidBarbero = Convert.ToInt32(tbIdEmpleado.Text);
                Program.vidCliente = Convert.ToInt32(tbIdCliente.Text);
            }
            
        } //Fin del metodo RecuperarDatos



        private void BEditar_Click(object sender, EventArgs e)
        {
            //Si no ha seleccionado un Suplidor no se puede modificar
            if (!tbIdCita.Equals(""))
            {
                
                Program.modificar = true; //el formulaario se prepara para modificar datos
                HabilitaBotones();
                cbEstado.Enabled = true;

            }
            else
            {
                MessageBox.Show("Debe de buscar un Cliente para poder Modificar sus datos!");
            }
        }

        private void BBuscarCliente_Click(object sender, EventArgs e)
        {
            //Creamos la instancia del formulario de búsqueda y lo mostramos
            FBuscarCliente fConsultaCliente = new FBuscarCliente();
            fConsultaCliente.ShowDialog();
            if (Program.modificar) //Si se está en modo de edición
            {
                RecuperaDatosCliente(); //Llamo al método para recuperar el registro seleccionado
                //BEditar_Click(sender, e); //Llamo el método del botón Editar
            }
            else //Si no estamos en modo de edición no permite la acción.
            {
                LimpiaObjetos(); //Llama al método LimpiaObjetos
                BBuscarCliente.Focus();
            }
        }
        public void RecuperaDatosCliente()
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
                tbNombreCliente.Text = row["Nombre"].ToString();
                tbApellidoCliente.Text = row["Apellido"].ToString();
                tbTelefonoCliente.Text = row["Telefono"].ToString();
            }
        } //Fin del metodo RecuperarDatos

        private void BBuscarEmpleado_Click(object sender, EventArgs e)
        {
            //Creamos la instancia del formulario de búsqueda y lo mostramos
            FBuscarBarbero fConsultaBarbero = new FBuscarBarbero();
            fConsultaBarbero.ShowDialog();
            if (Program.modificar) //Si se está en modo de edición
            {
                RecuperaDatosBarbero(); //Llamo al método para recuperar el registro seleccionado
                BEditar_Click(sender, e); //Llamo el método del botón Editar
                
            }
            else //Si no estamos en modo de edición no permite la acción.
            {
                LimpiaObjetos(); //Llama al método LimpiaObjetos
                BBuscarEmpleado.Focus();
            }
        }
        public void RecuperaDatosBarbero()
        {
            string vparametro = Program.vidBarbero.ToString();
            CNBarbero cNBarbero = new CNBarbero();
            DataTable dt = new DataTable(); //creamos un nuevo DataTable
            dt = cNBarbero.ObtenerBarbero(vparametro); //Llenamos el DataTable
                                                       //Recorremos cada fila del DataTable asignando a los controles de edición los valores de
                                                       //los campos correspondientes
            foreach (DataRow row in dt.Rows)
            {
                tbIdEmpleado.Text = row["IdBarbero"].ToString();
                tbNombreEmpleado.Text = row["Nombre"].ToString();
                tbTelefonoEmpleado.Text = row["Telefono"].ToString();
            }
        } //Fin del metodo RecuperarDatos

        private void BCancelar_Click(object sender, EventArgs e)
        {
            Program.nuevo = false;
            Program.modificar = false;
            HabilitaBotones(); //Habilita los objetos y botones correspondientes
            LimpiaObjetos(); //Llama al método LimpiaObjetos
        }

        private void MantCita_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void HabilitaBotones()
        {
            if (Program.nuevo || Program.modificar)
            {
                HabilitaControles(true); //Llamada al método para habilitar los objetos
                BNuevo.Enabled = false;
                BGuardar.Enabled = true;
                BEditar.Enabled = false;
                BBuscarCita.Enabled = false;
                BCancelar.Enabled = true;
                tbIdCita.Enabled = false;
                tbIdCliente.Enabled = false;
                tbNombreCliente.Enabled = false;
                tbApellidoCliente.Enabled = false;
                tbTelefonoCliente.Enabled = false;
                tbIdEmpleado.Enabled = false;
                tbNombreEmpleado.Enabled = false;
                tbTelefonoEmpleado.Enabled = false;
                dtpHora.Enabled = true;
            }
            else
            {
                HabilitaControles(false); //Llamada al método para inhabilitar los objetos
                BNuevo.Enabled = true;
                BGuardar.Enabled = false;
                BEditar.Enabled = false;
                BBuscarCita.Enabled = true;
                BCancelar.Enabled = false;
                cbEstado.SelectedItem = 0;
                cbEstado.Enabled = true;

                
            }
        }
    }
}
