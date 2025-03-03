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

namespace Gestor_de_Citas
{
    public partial class MantCita : Form
    {
        public string valorparametro = "", mensaje = "";
        //public static bool nuevo = true;

        public MantCita()
        {
            InitializeComponent();
        }

        private void MantCita_Load(object sender, EventArgs e)
        {
            Program.nuevo = false; //Valores de las variables globales nuevo y modificar
            Program.modificar = false;
            HabilitaBotones(); //Se habilitarán los objetos y los botones necesarios.
            dtpFecha.Value = DateTime.Today; //Para limpiar TextBox.
            dtpHora.Value = DateTime.Now;

        }

        private void BSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MantCita_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¡Esto hara salir del formulario! \n ¿Seguro que desea hacerlo?",
                                "Mensaje de JAC",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Warning,
                                MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                e.Cancel = false;
            else
                e.Cancel = true;
        }

        public void LimpiaObjetos()
        {

            tbIdCita.Clear(); //Para limpiar TextBox.
            dtpFecha.Value = DateTime.Today; //Para limpiar TextBox.
            dtpHora.Value = DateTime.Now;
            cbEstado.SelectedItem = 0;
            tbServicio.Clear();
            tbPrecio.Clear();
            tbIdServicio.Clear();
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
            //la propiedad Enabled habilita o inhabilita un objeto
            cbEstado.Enabled = valor;
            tbIdCita.Enabled = false;
            tbIdCliente.Enabled = false;
            tbNombreCliente.Enabled = false;
            tbApellidoCliente.Enabled = false;
            tbTelefonoCliente.Enabled = false;
            tbIdEmpleado.Enabled = false;
            tbNombreEmpleado.Enabled = false;
            tbTelefonoEmpleado.Enabled = false;
            dtpHora.Enabled = true;
            cbEstado.Enabled = false;
            tbIdServicio.Enabled = false;
            tbServicio.Enabled = false;
            tbPrecio.Enabled = false;
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
            if (tbIdServicio.Text == String.Empty)
            {
                MessageBox.Show("Debe Cargar los datos del Servicios");
                bBuscarServicio.Focus();
            }
            else
            if (tbIdCliente.Text == String.Empty)
            {
                MessageBox.Show("Debe Cargar los datos del Cliente");
                bBuscarCliente.Focus();
            }
            else
            if (tbIdEmpleado.Text == String.Empty)
            {
                MessageBox.Show("Debe cargar los datos del Empleado");
                bBuscarEmpleado.Focus();
            }
            else
            {
                if (Program.nuevo)//Si la variable nuevo llega con valor true se van a Insertar nuevos datos
                {
                   
                    mensaje = CNCita.Insertar(Program.vidCita, Program.vidCliente, Program.vidEmpleado,
                     dtpFecha.Value, dtpHora.Value, Program.vidServicio, cbEstado.Text);
                }
                else  //de lo contrario se Modificarán los datos del registro correspondiente
                {

                    mensaje = CNCita.Actualizar(Program.vidCita, Program.vidCliente, Program.vidEmpleado,
                     dtpFecha.Value, dtpHora.Value, Program.vidServicio, cbEstado.Text);
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
                                                     
            foreach (DataRow row in dt.Rows)
            {
                tbIdCita.Text = row["ID"].ToString();
                tbIdCliente.Text = row["IdCliente"].ToString();
                tbNombreCliente.Text = row["Cliente"].ToString();
                tbApellidoCliente.Text = row["Apellido"].ToString();
                tbTelefonoCliente.Text = row["Telefono"].ToString();
                tbIdEmpleado.Text = row["IdEmpleado"].ToString();
                tbNombreEmpleado.Text = row["Empleado"].ToString();
                tbTelefonoEmpleado.Text = row["Telefono"].ToString();
                dtpFecha.Text = row["Fecha"].ToString();
                dtpHora.Text = row["Hora"].ToString();
                tbIdServicio.Text = row["IdServicio"].ToString();
                tbServicio.Text = row["Servicio"].ToString();
                tbPrecio.Text = row["Precio"].ToString();
                cbEstado.Text = row["Estado"].ToString();
                Program.vidEmpleado = Convert.ToInt32(tbIdEmpleado.Text);
                Program.vidCliente = Convert.ToInt32(tbIdCliente.Text);
                Program.vidServicio = Convert.ToInt32(tbIdServicio.Text);
            }
            
        } //Fin del metodo RecuperarDatos

        private void BEditar_Click(object sender, EventArgs e)
        {
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
                tbIdCliente.Text = row["ID"].ToString();
                tbNombreCliente.Text = row["Nombre"].ToString();
                tbApellidoCliente.Text = row["Apellido"].ToString();
                tbTelefonoCliente.Text = row["Telefono"].ToString();
            }
        } //Fin del metodo RecuperarDatos

        public void RecuperaDatosEmpleado()
        {
            string vparametro = Program.vidEmpleado.ToString();
            CNEmpleado cNEmpleado = new CNEmpleado();
            DataTable dt = new DataTable(); //creamos un nuevo DataTable
            dt = cNEmpleado.ObtenerEmpleado(vparametro); //Llenamos el DataTable

            foreach (DataRow row in dt.Rows)
            {
                tbIdEmpleado.Text = row["ID"].ToString();
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
                e.SuppressKeyPress = true; // Esto evita que el sonido de la tecla sea reproducido
                SendKeys.Send("{TAB}");
            }
        }

        public void RecuperaDatosServicio()
        {
            string vparametro = Program.vidServicio.ToString();
            CNServicio cNServicio = new CNServicio();
            DataTable dt = new DataTable(); //creamos un nuevo DataTable
            dt = cNServicio.ObtenerServicio(vparametro); //Llenamos el DataTable
                                                       //Recorremos cada fila del DataTable asignando a los controles de edición los valores de
                                                       //los campos correspondientes
            foreach (DataRow row in dt.Rows)
            {
                tbIdServicio.Text = row["ID"].ToString();
                tbServicio.Text = row["NombreServicio"].ToString();
                tbPrecio.Text = row["Precio"].ToString();
            }
        } //Fin del metodo RecuperarDatos

        private void bBuscarCliente_Click(object sender, EventArgs e)
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
                bBuscarCliente.Focus();
            }
        }

        private void bBuscarEmpleado_Click(object sender, EventArgs e)
        {
            //Creamos la instancia del formulario de búsqueda y lo mostramos
            FBuscarEmpleado fConsultaBarbero = new FBuscarEmpleado();
            fConsultaBarbero.ShowDialog();
            if (Program.modificar) //Si se está en modo de edición
            {
                RecuperaDatosEmpleado(); //Llamo al método para recuperar el registro seleccionado
                BEditar_Click(sender, e); //Llamo el método del botón Editar
                cbEstado.Enabled = false;

            }
            else //Si no estamos en modo de edición no permite la acción.
            {
                LimpiaObjetos(); //Llama al método LimpiaObjetos
                bBuscarEmpleado.Focus();
            }
        }

        private void bBuscarServicio_Click(object sender, EventArgs e)
        {
            //Creamos la instancia del formulario de búsqueda y lo mostramos
            FBuscarServicio fConsultaServicio = new FBuscarServicio();
            fConsultaServicio.ShowDialog();
            if (Program.modificar) //Si se está en modo de edición
            {
                RecuperaDatosServicio(); //Llamo al método para recuperar el registro seleccionado
                //BEditar_Click(sender, e); //Llamo al método editar
            }
            else //Si no estamos en modo de edición no permite la acción.
            {
                LimpiaObjetos(); //Llama al método LimpiaObjetos
                //BBuscarCita.Focus();
            }
        }

        private void PTitulo_Paint(object sender, PaintEventArgs e)
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
                BBuscarCita.Enabled = false;
                BCancelar.Enabled = true;
                
            }
            else
            {
                HabilitaControles(false); //Llamada al método para inhabilitar los objetos
                BNuevo.Enabled = true;
                BGuardar.Enabled = false;
                BEditar.Enabled = false;
                BBuscarCita.Enabled = true;
                BCancelar.Enabled = false;
                cbEstado.Enabled = true;
            }
        }
    }
}
