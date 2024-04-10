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
    public partial class MantPago : Form
    {
        public string valorparametro = "", mensaje = "";
        public MantPago()
        {
            InitializeComponent();
        }

        private void BSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MantPago_FormClosing(object sender, FormClosingEventArgs e)
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

        private void bBuscarCita_Click(object sender, EventArgs e)
        {
            //Creamos la instancia del formulario de búsqueda y lo mostramos
            FBuscarCita fConsultaCita = new FBuscarCita();
            fConsultaCita.ShowDialog();
            if (Program.modificar) //Si se está en modo de edición
            {
                RecuperaDatosCita(); //Llamo al método para recuperar el registro seleccionado
                //BEditar_Click(sender, e); //Llamo al método editar
            }
            else //Si no estamos en modo de edición no permite la acción.
            {
                LimpiaObjetos(); //Llama al método LimpiaObjetos
                bBuscarCita.Focus();
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
                tbNombre.Text = row["NombreCliente"].ToString();
                dtpFecha.Text = row["Fecha"].ToString();
                dtpHora.Text = row["Hora"].ToString();
                tbServicio.Text = row["Servicio"].ToString();
                tbPrecio.Text = row["Precio"].ToString();
                cbEstado.Text = row["Estado"].ToString();
                Program.vidCita = Convert.ToInt32(tbIdCita.Text);
                Program.vidCliente = Convert.ToInt32(tbIdCliente.Text);
            }

        } //Fin del metodo RecuperarDatos

        private void BNuevo_Click(object sender, EventArgs e)
        {
            LimpiaObjetos(); //LLama al método LimpiaObjetos para prepararlos para la nueva entrada
            Program.nuevo = true; //Se especifica que se agregará un nuevo registro
            Program.modificar = false;
            HabilitaBotones(); //Se habilitan solo aquellos botones que sean necesarios
            
        }

        private void BGuardar_Click(object sender, EventArgs e)
        {
            if (cbEstado.Text == String.Empty)
            {
                MessageBox.Show("Debes de Indicar el Estado del Pago de la Cita");
                dtpHora.Focus();
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
                    //MessageBox.Show("Entre a nuevo" + Program.vidCliente.ToString() + " " + Program.vidBarbero.ToString());
                    mensaje = CNPago.Insertar(Program.vidPago, Program.vidCita, tbConceptoPago.Text, cbEstado.Text);
                }
                else  //de lo contrario se Modificarán los datos del registro correspondiente
                {

                    //Se llama al método Insertar de la clase CNSuplidor de la capa de negocio
                    //pasándole como parámetros los valores leídos en los controles del formulario.
                    // como: textbox, combobox, DateTimePicker, etc.
                    //Los parámetros se pasan en el orden en que se reciben y con el tipo de dato esperado
                    //MessageBox.Show("Entre a Actualizar" + Program.vidCliente.ToString() + " " + Program.vidBarbero.ToString());
                    mensaje = CNPago.Actualizar(Program.vidPago, Program.vidCita, tbConceptoPago.Text, cbEstado.Text);
                }

                //Se muestra el mensaje devuelto por la capa de negocio respecto al resultado de la operación
                MessageBox.Show(mensaje, "Mensaje de JAC", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //Se prepara todo para la próxima operación
            Program.nuevo = false;
            Program.modificar = false;
            HabilitaBotones(); //Habilita los objetos y botones correspondientes
            LimpiaObjetos(); //Llama al método LimpiaObjetos
        }

        private void MantPago_Load(object sender, EventArgs e)
        {
            Program.nuevo = false; //Valores de las variables globales nuevo y modificar
            Program.modificar = false;
            HabilitaBotones(); //Se habilitarán los objetos y los botones necesarios.
        }

        public void LimpiaObjetos()
        {
            tbIdPago.Clear(); //Para limpiar TextBox.
            cbEstado.SelectedItem = 0;
            tbIdCita.Clear(); //Para limpiar TextBox.
            dtpFecha.Value = DateTime.Today;
            dtpHora.Value = DateTime.Today;
            tbServicio.Clear();
            tbPrecio.Clear();
            tbIdCliente.Clear();
            tbNombre.Clear();
            tbConceptoPago.Clear();

        } //Fin del método LimpiaObjetos
          //Habilita / inhabilita los objetos del formulario segun lo indicado por el parámetro valor
        private void HabilitaControles(bool valor)
        {
            tbIdPago.ReadOnly = true; //la propiedad ReadOnly hace de solo lectura un objeto
            cbEstado.Enabled = valor;
            tbIdCita.Enabled = false;
            dtpFecha.Enabled = false;
            dtpHora.Enabled = false;
            tbServicio.Enabled = false;
            tbPrecio.Enabled = false;
            tbConceptoPago.Enabled = valor;
            tbIdCliente.Enabled = false; 
            tbNombre.Enabled = false;
            if (Program.nuevo)
                cbEstado.SelectedIndex = 0;
        } //Fin del método HabilitaControl

        private void BCancelar_Click(object sender, EventArgs e)
        {
            Program.nuevo = false;
            Program.modificar = false;
            HabilitaBotones(); //Habilita los objetos y botones correspondientes
            LimpiaObjetos(); //Llama al método LimpiaObjetos

        }

        private void BEditar_Click(object sender, EventArgs e)
        {
            //Si no ha seleccionado un Suplidor no se puede modificar
            if (!tbIdPago.Equals(""))
            {
                Program.modificar = true; //el formulaario se prepara para modificar datos
                HabilitaBotones();
            }
            else
            {
                MessageBox.Show("Debe de buscar un Suplidor para poder Modificar sus datos!");
            }
        }

        private void BBuscar_Click(object sender, EventArgs e)
        {
            //Creamos la instancia del formulario de búsqueda y lo mostramos
            FBuscarPago fBuscarPago = new FBuscarPago();
            fBuscarPago.ShowDialog();
            if (Program.modificar) //Si se está en modo de edición
            {
                RecuperaDatosPago(); //Llamo al método para recuperar el registro seleccionado
                BEditar_Click(sender, e); //Llamo al método editar
            }
            else //Si no estamos en modo de edición no permite la acción.
            {
                LimpiaObjetos(); //Llama al método LimpiaObjetos
                bBuscarCita.Focus();
            }
        }

        public void RecuperaDatosPago()
        {
            string vparametro = Program.vidPago.ToString();
            CNPago cNPago = new CNPago();
            DataTable dt = new DataTable(); //creamos un nuevo DataTable
            dt = cNPago.ObtenerPago(vparametro); //Llenamos el DataTable
                                                 //Recorremos cada fila del DataTable asignando a los controles de edición los valores de
                                                 //los campos correspondientes
            foreach (DataRow row in dt.Rows)
            {

                tbIdPago.Text = row["IdPago"].ToString();
                tbConceptoPago.Text = row["ConceptoPago"].ToString();
                cbEstado.Text = row["Estado"].ToString();
                tbIdCita.Text = row["IdCita"].ToString();
                dtpFecha.Text = row["Fecha"].ToString();
                dtpHora.Text = row["Hora"].ToString();
                tbIdCliente.Text = row["IdCliente"].ToString();
                tbNombre.Text = row["NombreCliente"].ToString();
                Program.vidCita = Convert.ToInt32(tbIdCita.Text);
                Program.vidPago = Convert.ToInt32(tbIdPago.Text);
            }

        } //Fin del metodo RecuperarDatos

        private void MantPago_KeyDown(object sender, KeyEventArgs e)
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
