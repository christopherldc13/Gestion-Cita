using CapaNegocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestor_de_Citas
{
    public partial class MantDisponibilidad: Form
    {
        public string valorparametro = "", mensaje = "";
        public MantDisponibilidad()
        {
            InitializeComponent();
        }

        private void BNuevo_Click(object sender, EventArgs e)
        {
            LimpiaObjetos();
            Program.nuevo = true;
            Program.modificar = false;
            HabilitaBotones();

        }
        public void LimpiaObjetos()
        {
            textBox1.Clear();
            tbIdEmpleado.Clear();
            comboBox1.SelectedIndex = -1; //Establece el valor por defecto del Combobox
            dtpInicio.Value = DateTime.Now;
            dtpFin.Value = DateTime.Now;
            textBox2.Clear();
        }

        private void BGuardar_Click(object sender, EventArgs e)
        {
            
            
            if (comboBox1.Text == String.Empty)
            {
                MessageBox.Show("Debe indicar el dia de Disponibilidad");
                comboBox1.Focus();
                return;
            }
            if (tbIdEmpleado.Text == String.Empty)
            {
                MessageBox.Show("Debe indicar el Empleado");
                tbIdEmpleado.Focus();
                return;
            }
            else
            {
                if (Program.nuevo)
                {
                    mensaje = CNDisponibilidad.Insertar(Program.vidEmpleado, comboBox1.Text,
                     dtpInicio.Value, dtpFin.Value);
                    MessageBox.Show("Estoy Insertando");
                }
                else
                {
                    // Mostrar los datos que se van a enviar
                    string datos = $"ID Disponibilidad: {Program.vidDisponibilidad}\n" +
                                   $"ID Empleado: {Program.vidEmpleado}\n" +
                                   $"Día: {comboBox1.Text}\n" +
                                   $"Hora Inicio: {dtpInicio.Value.ToShortTimeString()}\n" +
                                   $"Hora Fin: {dtpFin.Value.ToShortTimeString()}";

                    MessageBox.Show("Datos a enviar:\n\n" + datos, "Verificación de datos", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Proceder con la actualización
                    mensaje = CNDisponibilidad.Actualizar(Program.vidDisponibilidad, Program.vidEmpleado, comboBox1.Text,
                        dtpInicio.Value, dtpFin.Value);

                    MessageBox.Show("Estoy Actualizando");
                }
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

        private void BEditar_Click(object sender, EventArgs e)
        {
            if (!tbIdEmpleado.Equals(""))
            {
                Program.modificar = true;
                HabilitaBotones();
            }
            else
            {
                MessageBox.Show("Debe de buscar un Cliente para poder Modificar sus datos!");
            }
        }

        private void BCancelar_Click(object sender, EventArgs e)
        {
            Program.nuevo = false;
            Program.modificar = false;
            HabilitaBotones();
            LimpiaObjetos();
        }

        private void HabilitaBotones()
        {
            if (Program.nuevo || Program.modificar)
            {
                HabilitaControles(true);
                BNuevo.Enabled = false;
                BGuardar.Enabled = true;
                BEditar.Enabled = false;
               // BBuscar.Enabled = false;
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
            }
        }

        private void HabilitaControles(bool valor)
        {
            // Solo habilitar si es nuevo o modificar
            if (Program.nuevo || Program.modificar)
            {
                tbIdEmpleado.Enabled = false;
                textBox2.Enabled = false;
                comboBox1.Enabled = true;
                textBox1.Enabled = false;
                if (Program.nuevo)
                {
                    BBuscarDisponibilidad.Enabled = false;
                }
            }
            else
            {
                tbIdEmpleado.Enabled = false;
                textBox2.Enabled = false;
                comboBox1.Enabled = false;
                textBox1.Enabled = false;
                BBuscar.Enabled = false;
                BBuscarDisponibilidad.Enabled = true;
            }
        }

        private void BBuscar_Click(object sender, EventArgs e)
        {
            FBuscarEmpleado fConsultaBarbero = new FBuscarEmpleado();
            fConsultaBarbero.ShowDialog();
            if (Program.modificar) //Si se está en modo de edición
            {
                RecuperaDatosEmpleado(); //Llamo al método para recuperar el registro seleccionado


            }
            else //Si no estamos en modo de edición no permite la acción.
            {
                //LimpiaObjetos(); //Llama al método LimpiaObjetos
                //bBuscarEmpleado.Focus();
            }
        }

        public void RecuperaDatosEmpleado()
        {
            string vparametro = Program.vidEmpleado.ToString();
            CNEmpleado cNEmpleado = new CNEmpleado();
            DataTable dt = new DataTable(); //creamos un nuevo DataTable
            dt = cNEmpleado.ObtenerEmpleado(vparametro); //Llenamos el DataTable

            // Verificamos si hay datos
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    string estadoEmpleado = row["Estado"].ToString(); // Suponiendo que el campo se llama "Estado"

                    // Verificamos si el estado es "Inactivo"
                    if (estadoEmpleado == "Inactivo")
                    {
                        MessageBox.Show("Este empleado está inactivo y no se puede cargar.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //LimpiaObjetos(); // Limpiamos los campos en caso de empleado inactivo
                        return; // Salimos del método para evitar seguir cargando los datos
                    }

                    // Si el empleado está activo, asignamos los datos a los controles
                    tbIdEmpleado.Text = row["ID"].ToString();
                    textBox2.Text = row["Nombre"].ToString();
                    
                }
            }
            else
            {
                //MessageBox.Show("No se encontró el empleado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void BBuscarDisponibilidad_Click(object sender, EventArgs e)
        {
            FBuscarDisponibilidad fBuscarDisponibilidad = new FBuscarDisponibilidad();
            fBuscarDisponibilidad.ShowDialog();
            if (Program.modificar)
            {
                RecuperaDatosDisponibilidad();
                BEditar_Click(sender, e); 
            }
            else
            {
                LimpiaObjetos();
                BBuscarDisponibilidad.Focus();
            }
            
        }

        private void MantDisponibilidad_Load(object sender, EventArgs e)
        {
            Program.nuevo = false; //Valores de las variables globales nuevo y modificar
            Program.modificar = false;
            HabilitaBotones(); //Se habilitarán los objetos y los botones necesarios.
            dtpInicio.Format = DateTimePickerFormat.Custom;
            dtpFin.Format = DateTimePickerFormat.Custom;
            dtpInicio.CustomFormat = "hh:mm tt";
            dtpFin.CustomFormat = "hh:mm tt";
            dtpInicio.Value = DateTime.Now;
            dtpFin.Value = DateTime.Now;
        }

        private void BSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void MantDisponibilidad_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void MantDisponibilidad_FormClosing(object sender, FormClosingEventArgs e)
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

        public void RecuperaDatosDisponibilidad()
        {
            string vparametro = Program.vidDisponibilidad.ToString();
            CNDisponibilidad cNDisponibilidad = new CNDisponibilidad();
            DataTable dt = new DataTable();
            dt = cNDisponibilidad.ObtenerDisponibilidad(vparametro);

            foreach (DataRow row in dt.Rows)
            {
                textBox1.Text = row["ID"].ToString();
                tbIdEmpleado.Text = row["IdEmpleado"].ToString();
                textBox2.Text = row["Empleado"].ToString();
                comboBox1.Text = row["DiaSemana"].ToString();
                dtpInicio.Text = row["HoraInicio"].ToString();
                dtpFin.Text = row["HoraFin"].ToString();

                Program.vidEmpleado = Convert.ToInt32(tbIdEmpleado.Text);
            }
        }
    }
}
