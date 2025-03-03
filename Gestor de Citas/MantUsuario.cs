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

namespace Gestor_de_Citas
{
    public partial class MantUsuario : Form
    {
        public string valorparametro = "", mensaje = "";
        public MantUsuario()
        {
            InitializeComponent();
        }

        private void BSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MantUsuario_FormClosing(object sender, FormClosingEventArgs e)
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

        private void MantUsuario_Load(object sender, EventArgs e)
        {
            Program.nuevo = false; //Valores de las variables globales nuevo y modificar
            Program.modificar = false;
            HabilitaBotones(); //Se habilitarán los objetos y los botones necesarios.
        }
        public void LimpiaObjetos()
        {
            tbIdUsuario.Clear(); //Para limpiar TextBox.
            tbUsuario.Clear(); //Para limpiar TextBox.
            tbClave.Clear(); //Para limpiar TextBox.
            tbRol.Clear(); //Para limpiar TextBox.
            cbEstado.SelectedItem = 0; //Para limpiar TextBox.
            tbIdEmpleado.Clear();
            tbNombreEmpleado.Clear(); //Establece el valor por defecto del Combobox
        } //Fin del método LimpiaObjetos

        private void HabilitaControles(bool valor)
        {
            tbIdUsuario.ReadOnly = true; //la propiedad ReadOnly hace de solo lectura un objeto
            tbUsuario.Enabled = valor; //la propiedad Enabled habilita o inhabilita un objeto
            tbClave.Enabled = valor;
            tbRol.Enabled = valor;
            cbEstado.Enabled = valor;
            tbIdEmpleado.Enabled = false;
            tbNombreEmpleado.Enabled = false;

        } //Fin del método HabilitaControles

        private void BNuevo_Click(object sender, EventArgs e)
        {
            LimpiaObjetos(); //LLama al método LimpiaObjetos para prepararlos para la nueva entrada
            Program.nuevo = true; //Se especifica que se agregará un nuevo registro
            Program.modificar = false;
            HabilitaBotones(); //Se habilitan solo aquellos botones que sean necesarios
            tbUsuario.Focus(); //Coloca el cursor en el TextBox indicado
        }

        private void BGuardar_Click(object sender, EventArgs e)
        {
            //Validamos los datos requeridos entes de Insertar o Actualizar
            if (tbUsuario.Text == String.Empty) //Si el textbox está vacío mostrar un error y ubicar
            { // el cursor en dicho textbox
                MessageBox.Show("Debe indicar el Nombre del Empleado!");
                tbUsuario.Focus();
            }
            else
            if (tbClave.Text == String.Empty)
            {
                MessageBox.Show("Debe indicar el Apellido del Empleado!");
                tbClave.Focus();
            }
            else
            if (tbRol.Text == String.Empty)
            {
                MessageBox.Show("Debe indicar el Teléfono del Empleado!");
                tbRol.Focus();
            }
            else
            if (cbEstado.Text == String.Empty)
            {
                MessageBox.Show("Debe indicar la Disponibilidad del Empleado!");
                cbEstado.Focus();
            }

            else
            {
                //Si todo es correcto procede a Insertar o actualizar según corresponda, usaremos las variables globales a toda la solución contenidas en Program.CS
                if (Program.nuevo)//Si la variable nuevo llega con valor true se van a Insertar nuevos datos
                {

                    mensaje = CNUsuario.Insertar(Program.vidUsuario, tbUsuario.Text, tbClave.Text,
                     tbRol.Text, cbEstado.Text, Program.vidEmpleado);
                }
                else //de lo contrario se Modificarán los datos del registro correspondiente
                {

                    mensaje = CNUsuario.Actualizar(Program.vidUsuario, tbUsuario.Text, tbClave.Text,
                     tbRol.Text, cbEstado.Text, Program.vidEmpleado);
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

        private void BBuscar_Click(object sender, EventArgs e)
        {
            FBuscarUsuario fConsultaUsuario = new FBuscarUsuario();
            fConsultaUsuario.ShowDialog();
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
            string vparametro = Program.vidUsuario.ToString();
            CNUsuario cNUsuario = new CNUsuario();
            DataTable dt = new DataTable(); //creamos un nuevo DataTable
            dt = cNUsuario.ObtenerUsuario(vparametro); //Llenamos el DataTable
                                                      
            foreach (DataRow row in dt.Rows)
            {
                tbIdUsuario.Text = row["ID"].ToString();
                tbUsuario.Text = row["Usuario"].ToString();
                tbClave.Text = row["Clave"].ToString();
                tbRol.Text = row["Role"].ToString();
                cbEstado.Text = row["Estado"].ToString();
                tbIdEmpleado.Text = row["IDEmp"].ToString();
                tbNombreEmpleado.Text = row["Nombre"].ToString();
                Program.vidEmpleado = Convert.ToInt32(tbIdEmpleado.Text);

            }
        } //Fin del metodo RecuperarDatos

        private void BEditar_Click(object sender, EventArgs e)
        {
            //Si no ha seleccionado un Suplidor no se puede modificar
            if (!tbIdUsuario.Equals(""))
            {
                Program.modificar = true; //el formulaario se prepara para modificar datos
                HabilitaBotones();
            }
            else
            {
                MessageBox.Show("Debe de buscar un Barbero para poder Modificar sus datos!");
            }
        }
        private void BCancelar_Click(object sender, EventArgs e)
        {
            Program.nuevo = false;
            Program.modificar = false;
            HabilitaBotones(); //Habilita los objetos y botones correspondientes
            LimpiaObjetos(); //Llama al método LimpiaObjetos
        }

        private void bBuscarEmpleado_Click(object sender, EventArgs e)
        {
            //Creamos la instancia del formulario de búsqueda y lo mostramos
            FBuscarEmpleado fBuscarBarbero = new FBuscarEmpleado();
            fBuscarBarbero.ShowDialog();
            if (Program.modificar) //Si se está en modo de edición
            {
                RecuperaDatosEmpleados(); //Llamo al método para recuperar el registro seleccionado
                //BEditar_Click(sender, e); //Llamo el método del botón Editar
            }
            else //Si no estamos en modo de edición no permite la acción.
            {
                //LimpiaObjetos(); //Llama al método LimpiaObjetos
                //BBuscar.Focus();
            }
        }

        public void RecuperaDatosEmpleados()
        {
            string vparametro = Program.vidEmpleado.ToString();
            CNEmpleado cNEmpleado = new CNEmpleado();
            DataTable dt = new DataTable(); //creamos un nuevo DataTable
            dt = cNEmpleado.ObtenerEmpleado(vparametro); //Llenamos el DataTable
                                                     
            foreach (DataRow row in dt.Rows)
            {
                tbIdEmpleado.Text = row["ID"].ToString();
                tbNombreEmpleado.Text = row["Nombre"].ToString();
                
            }
        } //Fin del metodo RecuperarDatos

        private void MantUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Esto evita que el sonido de la tecla sea reproducido
                SendKeys.Send("{TAB}");
            }
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
