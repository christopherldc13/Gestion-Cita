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
                                "Mensaje de JAC",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Warning,
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
        }

        public void LimpiaObjetos()
        {
            tbIdServicio.Clear(); 
            tbNombreServicio.Clear(); 
            cbEstado.SelectedItem = 0;
            tbPrecio.Clear(); 

        } 

        private void HabilitaControles(bool valor)
        {
            tbIdServicio.ReadOnly = true; //la propiedad ReadOnly hace de solo lectura un objeto
            tbNombreServicio.Enabled = valor; //la propiedad Enabled habilita o inhabilita un objeto
            tbPrecio.Enabled = valor;
            cbEstado.Enabled = valor;
            if (Program.nuevo)
                cbEstado.SelectedIndex = 0;
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
            }
            else //Si no estamos en modo de edición no permite la acción.
            {
                LimpiaObjetos(); //Llama al método LimpiaObjetos
                BBuscar.Focus();
            }
        }

        public void RecuperaDatos()
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
                tbNombreServicio.Text = row["NombreServicio"].ToString();
                tbPrecio.Text = row["Precio"].ToString();
                cbEstado.Text = row["Estado"].ToString();

            }
        } //Fin del metodo RecuperarDatos

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
            tbNombreServicio.Focus(); //Coloca el cursor en el TextBox indicado
        }

        private void BGuardar_Click(object sender, EventArgs e)
        {
            //Validamos los datos requeridos entes de Insertar o Actualizar
            if (tbNombreServicio.Text == String.Empty) //Si el textbox está vacío mostrar un error y ubicar
            { // el cursor en dicho textbox
                MessageBox.Show("Debe indicar el Nombre del Servicio!");
                tbNombreServicio.Focus();
            }
            else
            if (tbPrecio.Text == String.Empty)
            {
                MessageBox.Show("Debe indicar el Precio del Servicio!");
                tbPrecio.Focus();
            }
            else
            if (cbEstado.Text == String.Empty)
            {
                MessageBox.Show("Debe indicar el Estado del Servicio!");
                cbEstado.Focus();
            }
            else
            {
                //Si todo es correcto procede a Insertar o actualizar según corresponda, usaremos las variables globales a toda la solución contenidas en Program.CS
                if (Program.nuevo)//Si la variable nuevo llega con valor true se van a Insertar nuevos datos
                {

                    mensaje = CNServicio.Insertar(Program.vidServicio, tbNombreServicio.Text, Convert.ToInt32(tbPrecio.Text),
                      cbEstado.Text);
                }
                else //de lo contrario se Modificarán los datos del registro correspondiente
                {

                    mensaje = CNServicio.Actualizar(Program.vidServicio, tbNombreServicio.Text, Convert.ToInt32(tbPrecio.Text),
                      cbEstado.Text);
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

        private void MantServicio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Esto evita que el sonido de la tecla sea reproducido
                SendKeys.Send("{TAB}");
            }

        }

        private void BEditar_Click(object sender, EventArgs e)
        {
            if (!tbIdServicio.Equals(""))
            {
                Program.modificar = true; //el formulaario se prepara para modificar datos
                HabilitaBotones();
            }
            else
            {
                MessageBox.Show("Debe de buscar un Servicio para poder Modificar sus datos!");
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
