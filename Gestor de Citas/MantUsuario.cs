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
    public partial class MantUsuario : Form
    {
        public string valorparametro = "", mensaje = "";
        public MantUsuario()
        {
            InitializeComponent();
            tbClave.PasswordChar = '*';
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            tbClave.PasswordChar = checkBox1.Checked ? '\0' : '*';
        }


        private void BSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MantUsuario_FormClosing(object sender, FormClosingEventArgs e)
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

        private void MantUsuario_Load(object sender, EventArgs e)
        {
            Program.nuevo = false; //Valores de las variables globales nuevo y modificar
            Program.modificar = false;
            HabilitaBotones(); 
        }
        public void LimpiaObjetos()
        {
            tbIdUsuario.Clear(); 
            tbUsuario.Clear(); 
            tbClave.Clear(); 
            cbEstado.SelectedIndex = -1; 
            tbIdEmpleado.Clear();
            tbNombreEmpleado.Clear(); 
            tbIdRol.Clear();
            tbNombreRol.Clear();
        } //Fin del método LimpiaObjetos

        private void HabilitaControles(bool valor)
        {
            tbIdUsuario.Enabled = false ; //la propiedad ReadOnly hace de solo lectura un objeto
            tbUsuario.Enabled = valor; //la propiedad Enabled habilita o inhabilita un objeto
            tbClave.Enabled = valor;
            cbEstado.Enabled = valor;
            tbIdEmpleado.Enabled = false;
            tbNombreEmpleado.Enabled = false;
            tbIdRol.Enabled = false;
            tbNombreRol.Enabled = false;
            if (Program.nuevo)
            {
                cbEstado.SelectedIndex = 0;
                cbEstado.Enabled = false;
            }
           

        } //Fin del método HabilitaControles

        private void BNuevo_Click(object sender, EventArgs e)
        {
            LimpiaObjetos(); 
            Program.nuevo = true; 
            Program.modificar = false;
            HabilitaBotones(); 
            tbUsuario.Focus(); 
            //cbEstado.SelectedIndex = 0;
        }

        private void BGuardar_Click(object sender, EventArgs e)
        {
            //Validamos los datos requeridos entes de Insertar o Actualizar
            if (tbUsuario.Text == String.Empty) //Si el textbox está vacío mostrar un error y ubicar
            { 
                MessageBox.Show("Debe indicar el usuario!");
                tbUsuario.Focus();
                return;
            }
            else
            if (tbClave.Text == String.Empty)
            {
                MessageBox.Show("Debe indicar la clave del usuario!");
                tbClave.Focus();
                return;
            }
            else
            if (cbEstado.Text == String.Empty)
            {
                MessageBox.Show("Debe indicar el estado del usuario");
                cbEstado.Focus();
                return;
            }
            else
            if (tbIdRol.Text == String.Empty)
            {
                MessageBox.Show("Debe indicar el ID del rol que tendra el usuario!");
                bBuscarRol.Focus();
                return;
            }
            else
            if(tbIdEmpleado.Text == String.Empty)
            {
                MessageBox.Show("Debe indicar el ID del Empleado al cual registra un usuario");
                bBuscarEmpleado.Focus();
                return;
            }
            else
            {
               
                if (Program.nuevo)//Si la variable nuevo llega con valor true se van a Insertar nuevos datos
                {

                    mensaje = CNUsuario.Insertar(Program.vidUsuario, tbUsuario.Text, tbClave.Text,
                     Program.vidRol, cbEstado.Text, Program.vidEmpleado);
                }
                else //de lo contrario se Modificarán los datos del registro correspondiente
                {

                    mensaje = CNUsuario.Actualizar(Program.vidUsuario, tbUsuario.Text, tbClave.Text,
                     Program.vidRol, cbEstado.Text, Program.vidEmpleado);
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
                tbIdRol.Text = row["IdRol"].ToString();
                tbNombreRol.Text = row["Rol"].ToString();
                cbEstado.Text = row["Estado"].ToString();
                tbIdEmpleado.Text = row["IDEmp"].ToString();
                tbNombreEmpleado.Text = row["Nombre"].ToString();
                Program.vidEmpleado = Convert.ToInt32(tbIdEmpleado.Text);
                Program.vidRol = Convert.ToInt32(tbIdRol.Text);

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
                MessageBox.Show("Debe de buscar un usuario para poder Modificar sus datos!");
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
            FBuscarEmpleado fBuscarEmpleado = new FBuscarEmpleado();
            fBuscarEmpleado.ShowDialog();
            if (Program.modificar) //Si se está en modo de edición
            {
                RecuperaDatosEmpleados(); //Llamo al método para recuperar el registro seleccionado
                //BEditar_Click(sender, e); //Llamo el método del botón Editar
            }
            else 
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
                tbNombreEmpleado.Text = row["Nombre"].ToString() + " " + row["Apellido"].ToString();

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

        private void bBuscarRol_Click(object sender, EventArgs e)
        {
            FBuscarRol fBuscarRol = new FBuscarRol();
            fBuscarRol.ShowDialog();
            if (Program.modificar) //Si se está en modo de edición
            {
                RecuperaDatosRol(); //Llamo al método para recuperar el registro seleccionado
                //BEditar_Click(sender, e); //Llamo el método del botón Editar
            }
            else //Si no estamos en modo de edición no permite la acción.
            {
                //LimpiaObjetos(); //Llama al método LimpiaObjetos
                //bBuscarRol.Focus();
            }
        }

        public void RecuperaDatosRol()
        {
            string vparametro = Program.vidRol.ToString();
            CNRol cNRol = new CNRol();
            DataTable dt = new DataTable(); // Creamos un nuevo DataTable
            dt = cNRol.ObtenerRol(vparametro); // Llenamos el DataTable

            // Verificamos si se recuperaron datos
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    // Asignamos los valores a los controles
                    tbIdRol.Text = row["IdRol"].ToString();
                    tbNombreRol.Text = row["NombreRol"].ToString();
                }
            }
            else
            {
                MessageBox.Show("No se encontraron datos para el rol con el ID: " + vparametro,
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
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
                //cbEstado.SelectedIndex = 0;
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
