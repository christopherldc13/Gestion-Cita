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
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Net;
using System.Net.Mail;


namespace Gestor_de_Citas
{
    public partial class MantCita : Form
    {
        public string valorparametro = "", mensaje = "";

        public MantCita()
        {
            InitializeComponent();
        }

        private void MantCita_Load(object sender, EventArgs e)
        {
            Program.nuevo = false; 
            Program.modificar = false;
            HabilitaBotones(); 
            dtpFecha.Value = DateTime.Today; 
            dtpHora.Value = DateTime.Now;
            dtpHora.Format = DateTimePickerFormat.Custom;
            comboBox1.Enabled = false;

            //Convertir Hora en Formato 12H sin Segundos
            dtpHora.CustomFormat = "hh:mm tt";

        }

        private void BSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MantCita_FormClosing(object sender, FormClosingEventArgs e)
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

        public void LimpiaObjetos()
        {
            tbIdCita.Clear(); 
            dtpFecha.Value = DateTime.Today; 
            dtpHora.Value = DateTime.Now;
            cbEstado.SelectedIndex = -1;
            tbServicio.Clear();
            tbPrecio.Clear();
            comboBox1.SelectedIndex = -1;
            tbIdServicio.Clear();
            tbIdCliente.Clear(); 
            tbNombreCliente.Clear(); 
            tbApellidoCliente.Clear();
            tbCorreoCliente.Clear();
            tbIdEmpleado.Clear(); 
            tbNombreEmpleado.Clear();
            tbTelefonoEmpleado.Clear();
        } 

        private void HabilitaControles(bool valor)
        {
            tbIdCita.ReadOnly = true;
            cbEstado.Enabled = valor;
            tbIdCita.Enabled = false;
            tbIdCliente.Enabled = false;
            tbNombreCliente.Enabled = false;
            tbApellidoCliente.Enabled = false;
            tbCorreoCliente.Enabled = false;
            tbIdEmpleado.Enabled = false;
            tbNombreEmpleado.Enabled = false;
            tbTelefonoEmpleado.Enabled = false;
            dtpHora.Enabled = true;
            tbIdServicio.Enabled = false;
            comboBox1.Enabled = false;
            tbServicio.Enabled = false;
            tbPrecio.Enabled = false;
            if (Program.nuevo)
                cbEstado.SelectedIndex = 0;
               // comboBox1.SelectedIndex = -1;
        } 

        private void BNuevo_Click(object sender, EventArgs e)
        {
            LimpiaObjetos(); 
            Program.nuevo = true; 
            Program.modificar = false;
            HabilitaBotones(); 
            dtpFecha.Focus(); 
            cbEstado.Enabled = false;
            //comboBox1.SelectedIndex = 0;  
        }

        private void BGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(dtpFecha.Text))
            {
                MessageBox.Show("Debe indicar la fecha en la que desee hacer la Cita!");
                dtpFecha.Focus();
                return;
            }
            else if (string.IsNullOrWhiteSpace(dtpHora.Text))
            {
                MessageBox.Show("Debes de Indicar la Hora de la Cita");
                dtpHora.Focus();
                return;
            }
            else if (string.IsNullOrWhiteSpace(cbEstado.Text))
            {
                MessageBox.Show("Debe indicar el estado de la Cita!");
                cbEstado.Focus();
                return;
            }
            else if (string.IsNullOrWhiteSpace(tbIdServicio.Text))
            {
                MessageBox.Show("Debe Cargar los datos del Servicio");
                bBuscarServicio.Focus();
                return;
            }
            else if (string.IsNullOrWhiteSpace(tbIdCliente.Text))
            {
                MessageBox.Show("Debe Cargar los datos del Cliente");
                bBuscarCliente.Focus();
                return;
            }
            else if (string.IsNullOrWhiteSpace(tbIdEmpleado.Text))
            {
                MessageBox.Show("Debe cargar los datos del Empleado");
                bBuscarEmpleado.Focus();
                return;
            }

            // Intentar insertar o actualizar
            if (Program.nuevo)
            {
                mensaje = CNCita.Insertar(Program.vidCita, Program.vidCliente, Program.vidEmpleado,
                 dtpFecha.Value, dtpHora.Value, Program.vidServicio, Convert.ToInt32(tbPrecio.Text), cbEstado.Text);
                if (mensaje == "Datos de la Cita insertados correctamente!")
                {
                    EnviarCorreoCitaInsertada(tbCorreoCliente.Text, tbNombreCliente.Text, tbApellidoCliente.Text, tbCorreoCliente.Text, tbNombreEmpleado.Text, tbTelefonoEmpleado.Text, tbServicio.Text, dtpFecha.Text, dtpHora.Text, comboBox1.Text, tbPrecio.Text, cbEstado.Text);
                }

            }
            else
            {
                mensaje = CNCita.Actualizar(Program.vidCita, Program.vidCliente, Program.vidEmpleado,
                 dtpFecha.Value, dtpHora.Value, Program.vidServicio, Convert.ToInt32(tbPrecio.Text), cbEstado.Text);
                if (mensaje == "Datos de la Cita actualizados correctamente!")
                {
                    EnviarCorreoCitaActualizada(tbCorreoCliente.Text, tbNombreCliente.Text, tbApellidoCliente.Text, tbCorreoCliente.Text,
                                                 tbNombreEmpleado.Text, tbTelefonoEmpleado.Text, tbServicio.Text,
                                                 dtpFecha.Text, dtpHora.Text, comboBox1.Text, tbPrecio.Text, cbEstado.Text);
                }


            }

            // Mostrar el resultado
            MessageBox.Show(mensaje, "Mensaje de " + Program.copyright, MessageBoxButtons.OK,
                            MessageBoxIcon.None);

            // Limpiar y deshabilitar solo si fue exitoso
            if (mensaje.Contains("insertados correctamente") || mensaje.Contains("actualizados correctamente"))
            {
                Program.nuevo = false;
                Program.modificar = false;
                HabilitaBotones();
                LimpiaObjetos();
            }
        }


        private void BBuscarCita_Click(object sender, EventArgs e)
        {
            FBuscarCita fConsultaCita = new FBuscarCita();
            fConsultaCita.ShowDialog();
            if (Program.modificar)
            {
                RecuperaDatosCita(); 
                //BEditar_Click(sender, e); 
            }
            else 
            {
                LimpiaObjetos();
                BBuscarCita.Focus();
            }
        }

        //public void RecuperaDatosCita()
        //{
        //    string vparametro = Program.vidCita.ToString();
        //    CNCita cNCita = new CNCita();
        //    DataTable dt = new DataTable(); 
        //    dt = cNCita.ObtenerCita(vparametro); 

        //    foreach (DataRow row in dt.Rows)
        //    {
        //        tbIdCita.Text = row["ID"].ToString();
        //        tbIdCliente.Text = row["IdCliente"].ToString();
        //        tbNombreCliente.Text = row["Cliente"].ToString();
        //        tbApellidoCliente.Text = row["Apellido"].ToString();
        //        tbTelefonoCliente.Text = row["Telefono"].ToString();
        //        tbIdEmpleado.Text = row["IdEmpleado"].ToString();
        //        tbNombreEmpleado.Text = row["Empleado"].ToString();
        //        tbTelefonoEmpleado.Text = row["Telefono"].ToString();
        //        dtpFecha.Text = row["Fecha"].ToString();
        //        dtpHora.Text = row["Hora"].ToString();
        //        tbIdServicio.Text = row["IdServicio"].ToString();
        //        tbServicio.Text = row["Servicio"].ToString();
        //        tbPrecio.Text = row["Precio"].ToString();

        //        // Modificación aquí:
        //        string duracion = row["Duracion"].ToString();
        //        string duracionNumerica = System.Text.RegularExpressions.Regex.Match(duracion, @"\d+").Value; // Extrae solo los dígitos
        //        comboBox1.Text = duracionNumerica;

        //        cbEstado.Text = row["Estado"].ToString();
        //        Program.vidEmpleado = Convert.ToInt32(tbIdEmpleado.Text);
        //        Program.vidCliente = Convert.ToInt32(tbIdCliente.Text);
        //        Program.vidServicio = Convert.ToInt32(tbIdServicio.Text);
        //    }
        //} 

        //public void RecuperaDatosCita()
        //{
        //    string vparametro = Program.vidCita.ToString();
        //    CNCita cNCita = new CNCita();
        //    DataTable dt = new DataTable();
        //    dt = cNCita.ObtenerCita(vparametro);

        //    foreach (DataRow row in dt.Rows)
        //    {
        //        // Convertir la fecha de la cita a DateTime
        //        DateTime fechaCita = Convert.ToDateTime(row["Fecha"]);
        //        DateTime fechaHoy = DateTime.Today;

        //        // Verificar si la cita es para otro día
        //        if (fechaCita.Date != fechaHoy)
        //        {

        //            MessageBox.Show("No puedes cargar una cita que no es del día de hoy.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            return; 
        //            // Salir del método sin cargar los datos
        //        }

        //        // Si la fecha es válida, cargar los datos
        //        tbIdCita.Text = row["ID"].ToString();
        //        tbIdCliente.Text = row["IdCliente"].ToString();
        //        tbNombreCliente.Text = row["Cliente"].ToString();
        //        tbApellidoCliente.Text = row["Apellido"].ToString();
        //        tbTelefonoCliente.Text = row["Telefono"].ToString();
        //        tbIdEmpleado.Text = row["IdEmpleado"].ToString();
        //        tbNombreEmpleado.Text = row["Empleado"].ToString();
        //        tbTelefonoEmpleado.Text = row["Telefono"].ToString();
        //        dtpFecha.Text = row["Fecha"].ToString();
        //        dtpHora.Text = row["Hora"].ToString();
        //        tbIdServicio.Text = row["IdServicio"].ToString();
        //        tbServicio.Text = row["Servicio"].ToString();
        //        tbPrecio.Text = row["Precio"].ToString();

        //        // Extraer solo los números de la duración
        //        string duracion = row["Duracion"].ToString();
        //        string duracionNumerica = System.Text.RegularExpressions.Regex.Match(duracion, @"\d+").Value;
        //        comboBox1.Text = duracionNumerica;

        //        cbEstado.Text = row["Estado"].ToString();
        //        Program.vidEmpleado = Convert.ToInt32(tbIdEmpleado.Text);
        //        Program.vidCliente = Convert.ToInt32(tbIdCliente.Text);
        //        Program.vidServicio = Convert.ToInt32(tbIdServicio.Text);
        //    }


        //}

        public void RecuperaDatosCita()
        {
            string vparametro = Program.vidCita.ToString();
            CNCita cNCita = new CNCita();
            DataTable dt = new DataTable();
            dt = cNCita.ObtenerCita(vparametro);

            // Verifica si no se encuentran datos
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("No se encontró la cita. Se cancelará la operación.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                BCancelar_Click(null, null);
                return;
            }

            foreach (DataRow row in dt.Rows)
            {
                // Verificar si la cita está cancelada
                if (row["Estado"].ToString().Equals("Cancelada", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("No se puede cargar una cita cancelada.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    BCancelar_Click(null, null);
                    return;
                }

                // Convertir la fecha de la cita a DateTime
                DateTime fechaCita = Convert.ToDateTime(row["Fecha"]);
                DateTime fechaHoy = DateTime.Today;

                // Verificar si la cita es para otro día
                //if (fechaCita.Date != fechaHoy ||fechaCita.Date < fechaHoy)
                if (fechaCita.Date < fechaHoy)
                {
                    MessageBox.Show("No puedes cargar una cita que no es del día de hoy.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    BCancelar_Click(null, null);
                    return;
                }

                // Si la fecha es válida, cargar los datos
                tbIdCita.Text = row["ID"].ToString();
                tbIdCliente.Text = row["IdCliente"].ToString();
                tbNombreCliente.Text = row["Cliente"].ToString();
                tbApellidoCliente.Text = row["Apellido"].ToString();
                tbCorreoCliente.Text = row["Correo"].ToString();
                tbIdEmpleado.Text = row["IdEmpleado"].ToString();
                tbNombreEmpleado.Text = row["Empleado"].ToString();
                tbTelefonoEmpleado.Text = row["Em.Telefono"].ToString();
                dtpFecha.Text = row["Fecha"].ToString();
                dtpHora.Text = row["Hora"].ToString();
                tbIdServicio.Text = row["IdServicio"].ToString();
                tbServicio.Text = row["Servicio"].ToString();

                // Extraer solo los números del precio, eliminando el símbolo de RD$ y cualquier otro carácter no numérico
                string precioConSimbolo = row["Precio"].ToString();
                string precioNumerico = System.Text.RegularExpressions.Regex.Replace(precioConSimbolo, @"[^\d\.]", "");
                tbPrecio.Text = precioNumerico;

                // Extraer solo los números de la duración
                string duracion = row["Duracion"].ToString();
                string duracionNumerica = System.Text.RegularExpressions.Regex.Match(duracion, @"\d+").Value;
                comboBox1.Text = duracionNumerica;

                cbEstado.Text = row["Estado"].ToString();
                Program.vidEmpleado = Convert.ToInt32(tbIdEmpleado.Text);
                Program.vidCliente = Convert.ToInt32(tbIdCliente.Text);
                Program.vidServicio = Convert.ToInt32(tbIdServicio.Text);

            }

            // Si los datos se recuperan correctamente, habilitar los botones (como lo hace BEditar_Click)
            BEditar_Click(sender: null, e: null);

        }

        private void BEditar_Click(object sender, EventArgs e)
        {
            if (!tbIdCita.Equals(""))
            {
                Program.modificar = true; //el formulaario se prepara para modificar datos
                HabilitaBotones();
                cbEstado.Enabled = true;
                //cbEstado.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("Debe de buscar un Cliente para poder Modificar sus datos!");
            }
        }

        //public void RecuperaDatosCliente()
        //{
        //    string vparametro = Program.vidCliente.ToString();
        //    CNCliente cNCliente = new CNCliente();
        //    DataTable dt = new DataTable(); //creamos un nuevo DataTable
        //    dt = cNCliente.ObtenerCliente(vparametro); //Llenamos el DataTable
        //                                         //Recorremos cada fila del DataTable asignando a los controles de edición los valores de
        //                                         //los campos correspondientes
        //    foreach (DataRow row in dt.Rows)
        //    {
        //        tbIdCliente.Text = row["ID"].ToString();
        //        tbNombreCliente.Text = row["Nombre"].ToString();
        //        tbApellidoCliente.Text = row["Apellido"].ToString();
        //        tbTelefonoCliente.Text = row["Telefono"].ToString();
        //    }
        //} //Fin del metodo RecuperarDatos

        public void RecuperaDatosCliente()
        {
            string vparametro = Program.vidCliente.ToString();
            CNCliente cNCliente = new CNCliente();
            DataTable dt = new DataTable(); //creamos un nuevo DataTable
            dt = cNCliente.ObtenerCliente(vparametro); //Llenamos el DataTable

            // Verificamos si hay datos
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    string estadoCliente = row["Estado"].ToString(); // Supongo que el campo de estado se llama "Estado"

                    // Verificamos si el estado es "Inactivo"
                    if (estadoCliente == "Inactivo")
                    {
                        MessageBox.Show("Este cliente está inactivo y no se puede cargar.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //LimpiaObjetos(); // Limpiamos los campos en caso de cliente inactivo
                        return; // Salimos del método para evitar seguir cargando los datos del cliente
                    }
                    // Si el cliente está activo, asignamos los datos a los controles
                    tbIdCliente.Text = row["ID"].ToString();
                    tbNombreCliente.Text = row["Nombre"].ToString();
                    tbApellidoCliente.Text = row["Apellido"].ToString();
                    tbCorreoCliente.Text = row["Correo"].ToString();
                }
            }
            else
            {
               // MessageBox.Show("No se encontró el cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    tbNombreEmpleado.Text = row["Nombre"].ToString();
                    tbTelefonoEmpleado.Text = row["Telefono"].ToString();
                }
            }
            else
            {
                //MessageBox.Show("No se encontró el empleado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //public void RecuperaDatosEmpleado()
        //{
        //    string vparametro = Program.vidEmpleado.ToString();
        //    CNEmpleado cNEmpleado = new CNEmpleado();
        //    DataTable dt = new DataTable(); //creamos un nuevo DataTable
        //    dt = cNEmpleado.ObtenerEmpleado(vparametro); //Llenamos el DataTable

        //    foreach (DataRow row in dt.Rows)
        //    {
        //        tbIdEmpleado.Text = row["ID"].ToString();
        //        tbNombreEmpleado.Text = row["Nombre"].ToString();
        //        tbTelefonoEmpleado.Text = row["Telefono"].ToString();
        //    }
        //} //Fin del metodo RecuperarDatos


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

        //public void RecuperaDatosServicio()
        //{
        //    string vparametro = Program.vidServicio.ToString();
        //    CNServicio cNServicio = new CNServicio();
        //    DataTable dt = new DataTable(); //creamos un nuevo DataTable
        //    dt = cNServicio.ObtenerServicio(vparametro); //Llenamos el DataTable
        //                                               //Recorremos cada fila del DataTable asignando a los controles de edición los valores de
        //                                               //los campos correspondientes
        //    foreach (DataRow row in dt.Rows)
        //    {
        //        tbIdServicio.Text = row["ID"].ToString();
        //        tbServicio.Text = row["NombreServicio"].ToString();
        //        tbPrecio.Text = row["Precio"].ToString();
        //    }
        //} //Fin del metodo RecuperarDatos

        //public void RecuperaDatosServicio()
        //{
        //    string vparametro = Program.vidServicio.ToString();
        //    CNServicio cNServicio = new CNServicio();
        //    DataTable dt = new DataTable(); // Creamos un nuevo DataTable
        //    dt = cNServicio.ObtenerServicio(vparametro); // Llenamos el DataTable

        //    // Verificamos si hay datos
        //    if (dt.Rows.Count > 0)
        //    {
        //        foreach (DataRow row in dt.Rows)
        //        {
        //            string estadoServicio = row["Estado"].ToString(); // Supongo que el campo de estado se llama "Estado"

        //            // Verificamos si el estado es "Inactivo"
        //            if (estadoServicio == "Inactivo")
        //            {
        //                MessageBox.Show("Este servicio está inactivo y no se puede cargar.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //                //LimpiaObjetos(); // Limpiamos los campos en caso de servicio inactivo
        //                return; // Salimos del método para evitar seguir cargando los datos del servicio
        //            }
        //            // Si el servicio está activo, asignamos los datos a los controles
        //            tbIdServicio.Text = row["ID"].ToString();
        //            tbServicio.Text = row["NombreServicio"].ToString();
        //            tbPrecio.Text = row["Precio"].ToString();
        //            comboBox1.Text = row["Duracion"].ToString();
        //        }
        //    }
        //    else
        //    {
        //        //MessageBox.Show("No se encontró el servicio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        public void RecuperaDatosServicio()
        {
            string vparametro = Program.vidServicio.ToString();
            CNServicio cNServicio = new CNServicio();
            DataTable dt = new DataTable(); // Creamos un nuevo DataTable
            dt = cNServicio.ObtenerServicio(vparametro); // Llenamos el DataTable

            // Verificamos si hay datos
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    string estadoServicio = row["Estado"].ToString(); // Supongo que el campo de estado se llama "Estado"

                    // Verificamos si el estado es "Inactivo"
                    if (estadoServicio == "Inactivo")
                    {
                        MessageBox.Show("Este servicio está inactivo y no se puede cargar.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        // LimpiaObjetos(); // Limpiamos los campos en caso de servicio inactivo
                        return; // Salimos del método para evitar seguir cargando los datos del servicio
                    }

                    // Si el servicio está activo, asignamos los datos a los controles
                    tbIdServicio.Text = row["ID"].ToString();
                    tbServicio.Text = row["NombreServicio"].ToString();

                    // Extraer solo los números del precio (quitando RD$, espacios u otros caracteres)
                    string precioNumerico = System.Text.RegularExpressions.Regex.Match(row["Precio"].ToString(), @"\d+").Value;
                    tbPrecio.Text = precioNumerico;

                    // Extraer solo los números de la duración (quitando "Min" u otras letras)
                    string duracionNumerica = System.Text.RegularExpressions.Regex.Match(row["Duracion"].ToString(), @"\d+").Value;
                    comboBox1.Text = duracionNumerica;
                }

            }
            else
            {
                //MessageBox.Show("No se encontró el servicio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void bBuscarCliente_Click(object sender, EventArgs e)
        {
            FBuscarCliente fConsultaCliente = new FBuscarCliente();
            fConsultaCliente.ShowDialog();
            if (Program.modificar) //Si se está en modo de edición
            {
                RecuperaDatosCliente(); 
                //BEditar_Click(sender, e);
            }
            else 
            {
                //LimpiaObjetos(); //Llama al método LimpiaObjetos
                //bBuscarCliente.Focus();
            }
        }

        private void bBuscarEmpleado_Click(object sender, EventArgs e)
        {
            FBuscarEmpleado fConsultaBarbero = new FBuscarEmpleado();
            fConsultaBarbero.ShowDialog();
            if (Program.modificar) //Si se está en modo de edición
            {
                RecuperaDatosEmpleado(); //Llamo al método para recuperar el registro seleccionado
               // BEditar_Click(sender, e); //Llamo el método del botón Editar
                cbEstado.Enabled = false;

            }
            else //Si no estamos en modo de edición no permite la acción.
            {
                //LimpiaObjetos(); //Llama al método LimpiaObjetos
                //bBuscarEmpleado.Focus();
            }
        }

        private void bBuscarServicio_Click(object sender, EventArgs e)
        {
            FBuscarServicio fConsultaServicio = new FBuscarServicio();
            fConsultaServicio.ShowDialog();
            if (Program.modificar) //Si se está en modo de edición
            {
                RecuperaDatosServicio(); //Llamo al método para recuperar el registro seleccionado
                //BEditar_Click(sender, e); //Llamo al método editar
            }
            else //Si no estamos en modo de edición no permite la acción.
            {
                //LimpiaObjetos(); //Llama al método LimpiaObjetos
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
                HabilitaControles(true); 
                BNuevo.Enabled = false;
                BGuardar.Enabled = true;
                BEditar.Enabled = false;
                BBuscarCita.Enabled = false;
                BCancelar.Enabled = true;
                
            }
            else
            {
                HabilitaControles(false); 
                BNuevo.Enabled = true;
                BGuardar.Enabled = false;
                BEditar.Enabled = false;
                BBuscarCita.Enabled = true;
                BCancelar.Enabled = false;
                //cbEstado.Enabled = true;
            }
        }

        private void EnviarCorreoCitaActualizada(
                string correoDestino,
                string nombre,
                string apellido,
                string correoCliente,
                string empleado,
                string telefonoEmpleado,
                string servicio,
                string fecha,
                string hora,
                string duracion,
                string precio,
                string estado)
                    {
            try
            {
                MailAddress addressFrom = new MailAddress("g.cita.express@gmail.com", "CitaExpress");
                MailAddress addressTo = new MailAddress(correoDestino);
                MailMessage message = new MailMessage(addressFrom, addressTo);

                message.Subject = "Actualización de Cita - CitaExpress";
                message.IsBodyHtml = true;

                message.Body = $@"
                    <div style='font-family: Arial, sans-serif; color: #333; padding: 20px;'>
                        <h2 style='color: #d35400;'>Hola {nombre},</h2>
                        <p>Te informamos que tu cita en <strong>CitaExpress</strong> ha sido <strong>actualizada</strong> con los siguientes detalles:</p>

                        <h3 style='margin-top: 20px;'>📌 Nuevos detalles de la Cita:</h3>
                        <ul style='line-height: 1.8;'>
                            <li><strong>Nombre del cliente:</strong> {nombre} {apellido}</li>
                            <li><strong>Correo del cliente:</strong> {correoCliente}</li>
                            <li><strong>Empleado asignado:</strong> {empleado}</li>
                            <li><strong>Teléfono del empleado:</strong> {telefonoEmpleado}</li>
                            <li><strong>Servicio solicitado:</strong> {servicio}</li>
                            <li><strong>Fecha:</strong> {fecha}</li>
                            <li><strong>Hora:</strong> {hora}</li>
                            <li><strong>Duración estimada:</strong> {duracion} minutos</li>
                            <li><strong>Precio:</strong> RD${precio}</li>
                            <li><strong>Estado actualizado:</strong> <strong>{estado}</strong></li>
                        </ul>

                        <p style='margin-top: 20px;'>Gracias por utilizar nuestros servicios. Estamos comprometidos en ofrecerte la mejor atención.</p>

                        <br/>
                        <p style='color: #888;'>Este mensaje fue enviado automáticamente. Por favor, no respondas a este correo.</p>
                        <hr/>
                        <p style='font-size: 12px;'>© {DateTime.Now.Year} CitaExpress. Todos los derechos reservados.</p>
                    </div>";

                SmtpClient client = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    EnableSsl = true,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential("g.cita.express@gmail.com", "lwff mklg eryo ekqu")
                };

                client.Send(message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al enviar el correo: " + ex.Message);
            }
        }

        private void EnviarCorreoCitaInsertada(
            string correoDestino,
            string nombre,
            string apellido,
            string correoCliente,
            string empleado,
            string telefonoEmpleado,
            string servicio,
            string fecha,
            string hora,
            string duracion,
            string precio,
            string estado)
        {
            try
            {
                MailAddress addressFrom = new MailAddress("g.cita.express@gmail.com", "CitaExpress");
                MailAddress addressTo = new MailAddress(correoDestino);
                MailMessage message = new MailMessage(addressFrom, addressTo);

                message.Subject = "Confirmación de Cita - CitaExpress";
                message.IsBodyHtml = true;

                message.Body = $@"
                <div style='font-family: Arial, sans-serif; color: #333; padding: 20px;'>
                    <h2 style='color: #0066cc;'>Hola {nombre},</h2>
                    <p>Has agendado una cita en <strong>CitaExpress</strong> con los siguientes detalles:</p>

                    <h3 style='margin-top: 20px;'>📌 Detalles de la Cita:</h3>
                    <ul style='line-height: 1.8;'>
                        <li><strong>Nombre del cliente:</strong> {nombre} {apellido}</li>
                        <li><strong>Correo del cliente:</strong> {correoCliente}</li>
                        <li><strong>Empleado asignado:</strong> {empleado}</li>
                        <li><strong>Teléfono del empleado:</strong> {telefonoEmpleado}</li>
                        <li><strong>Servicio solicitado:</strong> {servicio}</li>
                        <li><strong>Fecha:</strong> {fecha}</li>
                        <li><strong>Hora:</strong> {hora}</li>
                        <li><strong>Duración estimada:</strong> {duracion} minutos</li>
                        <li><strong>Precio:</strong> RD${precio}</li>
                        <li><strong>Estado de la cita:</strong> {estado}</li>
                    </ul>

                    <p style='margin-top: 20px;'>Gracias por utilizar nuestros servicios. Estamos comprometidos en ofrecerte la mejor atención.</p>

                    <br/>
                    <p style='color: #888;'>Este mensaje fue enviado automáticamente. Por favor, no respondas a este correo.</p>
                    <hr/>
                    <p style='font-size: 12px;'>© {DateTime.Now.Year} CitaExpress. Todos los derechos reservados.</p>
                </div>";

                SmtpClient client = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    EnableSsl = true,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential("g.cita.express@gmail.com", "ytet akwf ccjp aovf")
                };

                client.Send(message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al enviar el correo: " + ex.Message);
            }
        }

    }
}
