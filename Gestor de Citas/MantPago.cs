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
using System.Net.Mail;
using System.Net;

namespace Gestor_de_Citas
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
            if (MessageBox.Show("¡Esto hara salir del formulario! \n ¿Seguro que desea hacerlo?",
                               "Mensaje de" + " " + Program.copyright,
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
            if (Program.modificar) 
            {
                RecuperaDatosCita();
                cbEstado.SelectedIndex = 0;
                //BEditar_Click(sender, e); 
            }
            else 
            {
                //LimpiaObjetos(); 
                bBuscarCita.Focus();
            }
        }

        //public void RecuperaDatosCita()
        //{
        //    string vparametro = Program.vidCita.ToString();
        //    CNCita cNCita = new CNCita();
        //    DataTable dt = new DataTable(); //creamos un nuevo DataTable
        //    dt = cNCita.ObtenerCita(vparametro); //Llenamos el DataTable

        //    foreach (DataRow row in dt.Rows)
        //    {

        //        tbIdCita.Text = row["ID"].ToString();
        //        tbIdCliente.Text = row["IdCliente"].ToString();
        //        tbNombre.Text = row["Cliente"].ToString();
        //        dtpFecha.Text = row["Fecha"].ToString();
        //        dtpHora.Text = row["Hora"].ToString();
        //        tbServicio.Text = row["Servicio"].ToString();
        //        tbPrecio.Text = row["Precio"].ToString();
        //        cbEstado.Text = row["Estado"].ToString();
        //        Program.vidCita = Convert.ToInt32(tbIdCita.Text);
        //        Program.vidCliente = Convert.ToInt32(tbIdCliente.Text);
        //    }

        //}

        public void RecuperaDatosCita()
        {
            string vparametro = Program.vidCita.ToString();
            CNCita cNCita = new CNCita();
            DataTable dt = new DataTable();
            dt = cNCita.ObtenerCita(vparametro);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    string estadoCita = row["Estado"].ToString(); // Asegúrate de que el campo se llama "Estado"

                    // Verificamos si la cita está cancelada
                    if (estadoCita.Equals("Cancelada", StringComparison.OrdinalIgnoreCase))
                    {
                        MessageBox.Show("No se puede cargar esta cita porque ha sido cancelada.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbIdCita.Clear();
                        tbServicio.Clear();
                        tbPrecio.Clear();
                        tbIdCliente.Clear();
                        tbNombre.Clear();
                        tbCorreo.Clear();
                        return; // Salimos del método para evitar seguir cargando los datos
                    }

                    // Verificamos si la cita está marcada como "No Realizada"
                    if (estadoCita.Equals("No Realizada", StringComparison.OrdinalIgnoreCase))
                    {
                        MessageBox.Show("La cita está vencida y ha sido marcada como 'No Realizada'. No se puede cargar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbIdCita.Clear();
                        tbServicio.Clear();
                        tbPrecio.Clear();
                        tbIdCliente.Clear();
                        tbNombre.Clear();
                        tbCorreo.Clear();
                        return; // Salimos del método para evitar seguir cargando los datos
                    }

                    // Si la cita no está cancelada ni "No Realizada", asignamos los datos a los controles
                    tbIdCita.Text = row["ID"].ToString();
                    tbIdCliente.Text = row["IdCliente"].ToString();
                    tbNombre.Text = row["Cliente"].ToString();
                    tbCorreo.Text = row["Correo"].ToString();
                    dtpFecha.Text = row["Fecha"].ToString();
                    dtpHora.Text = row["Hora"].ToString();
                    tbServicio.Text = row["Servicio"].ToString();
                    tbPrecio.Text = row["Precio"].ToString();
                    cbEstado.Text = estadoCita;
                    Program.vidCita = Convert.ToInt32(tbIdCita.Text);
                    Program.vidCliente = Convert.ToInt32(tbIdCliente.Text);
                }
            }
            else
            {
                MessageBox.Show("No se encontró la cita.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BNuevo_Click(object sender, EventArgs e)
        {
            LimpiaObjetos(); 
            Program.nuevo = true; 
            Program.modificar = false;
            HabilitaBotones(); 
            cbMetodo.Focus();
        }

        private void BGuardar_Click(object sender, EventArgs e)
        {
            if (cbMetodo.Text == String.Empty)
            {
                MessageBox.Show("Debes de Indicar el Método de Pago de la Cita");
                cbMetodo.Focus();
                return;
            }
            else
            if (cbEstado.Text == String.Empty)
            {
                MessageBox.Show("Debes de Indicar el Estado del Pago de la Cita");
                cbEstado.Focus();
                return;
            }
            else
            if (tbIdCita.Text == String.Empty)
            {
                MessageBox.Show("Debes de Indicar el ID de la Cita");
                bBuscarCita.Focus();
                return;
            }
            else
            {
                if (Program.nuevo)
                {

                    mensaje = CNPago.Insertar(Program.vidPago, Program.vidCita, cbMetodo.Text, cbEstado.Text);
                    if (mensaje == "Datos del Pago insertados correctamente!")
                    {
                            EnviarCorreoPagoRealizado(
                            tbCorreo.Text,             // correoDestino
                            tbNombre.Text,             // nombre
                            "",                        // apellido (valor vacío)
                            tbCorreo.Text,             // correoCliente (usamos el mismo que correoDestino)
                            tbServicio.Text,           // servicio
                            dtpFecha.Text,             // fecha
                            dtpHora.Text,              // hora
                            tbPrecio.Text,             // precio
                            cbMetodo.Text,             // metodoPago
                            cbEstado.Text             // estadoPago
                     // referenciaPago (valor vacío)
                         );
                    }


                }
                else
                {
                    mensaje = CNPago.Actualizar(Program.vidPago, Program.vidCita, cbMetodo.Text, cbEstado.Text);
                    if (mensaje == "Datos del Pago actualizados correctamente!")
                    {
                        EnviarCorreoPagoActualizado(
                        tbCorreo.Text,             // correoDestino
                        tbNombre.Text,             // nombre
                        "",                        // apellido (valor vacío)
                        tbCorreo.Text,             // correoCliente (usamos el mismo que correoDestino)
                        tbServicio.Text,           // servicio
                        dtpFecha.Text,             // fecha
                        dtpHora.Text,              // hora
                        tbPrecio.Text,             // precio
                        cbMetodo.Text,             // metodoPago
                        cbEstado.Text             // estadoPago
                                                  // referenciaPago (valor vacío)
                     );
                    }
                }


                MessageBox.Show(mensaje, "Mensaje de " + Program.copyright, MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            if (mensaje.Contains("insertados correctamente") || mensaje.Contains("actualizados correctamente"))
            {
                Program.nuevo = false;
                Program.modificar = false;
                HabilitaBotones();
                LimpiaObjetos();
            }
        }

        private void MantPago_Load(object sender, EventArgs e)
        {
            Program.nuevo = false;
            Program.modificar = false;
            HabilitaBotones();
            dtpHora.CustomFormat = "hh:mm tt";
            dtpHora.Format = DateTimePickerFormat.Custom;
        }

        public void LimpiaObjetos()
        {
            tbIdPago.Clear();
            cbEstado.SelectedIndex = -1;
            tbIdCita.Clear(); 
            dtpFecha.Value = DateTime.Today;
            dtpHora.Value = DateTime.Today;
            tbServicio.Clear();
            tbPrecio.Clear();
            tbIdCliente.Clear();
            tbNombre.Clear();
            tbCorreo.Clear();
            cbMetodo.SelectedIndex = -1;

        } 

        private void HabilitaControles(bool valor)
        {
            tbIdPago.Enabled = false;
            cbEstado.Enabled = valor;
            tbIdCita.Enabled = false;
            dtpFecha.Enabled = false;
            dtpHora.Enabled = false;
            tbServicio.Enabled = false;
            tbPrecio.Enabled = false;
            cbMetodo.Enabled = valor;
            tbIdCliente.Enabled = false;
            tbNombre.Enabled = false;
            tbCorreo.Enabled = false;
            if (Program.nuevo)
                cbEstado.SelectedIndex = 0;
        } 

        private void BCancelar_Click(object sender, EventArgs e)
        {
            Program.nuevo = false;
            Program.modificar = false;
            HabilitaBotones(); 
            LimpiaObjetos(); 
        }

        private void BEditar_Click(object sender, EventArgs e)
        {
            if (!tbIdPago.Equals(""))
            {
                Program.modificar = true; 
                HabilitaBotones();
            }
            else
            {
                MessageBox.Show("Debe de buscar un Pago para poder Modificar sus datos!");
            }
        }

        private void BBuscar_Click(object sender, EventArgs e)
        {
            FBuscarPago fBuscarPago = new FBuscarPago();
            fBuscarPago.ShowDialog();
            if (Program.modificar) //Si se está en modo de edición
            {
                RecuperaDatosPago(); 
                //BEditar_Click(sender, e); 
            }
            else 
            {
                LimpiaObjetos();
                bBuscarCita.Focus();
            }
        }

        //public void RecuperaDatosPago()
        //{
        //    string vparametro = Program.vidPago.ToString();
        //    CNPago cNPago = new CNPago();
        //    DataTable dt = new DataTable(); 
        //    dt = cNPago.ObtenerPago(vparametro); 

        //    foreach (DataRow row in dt.Rows)
        //    {
        //        tbIdPago.Text = row["ID"].ToString();
        //        tbConceptoPago.Text = row["Concepto Pago"].ToString();
        //        cbEstado.Text = row["Estado"].ToString();
        //        tbIdCita.Text = row["ID Cita"].ToString();
        //        dtpFecha.Text = row["Fecha"].ToString();
        //        dtpHora.Text = row["Hora"].ToString();
        //        tbPrecio.Text = row["Precio"].ToString();
        //        tbServicio.Text = row["Servicio"].ToString();
        //        tbIdCliente.Text = row["ID Cliente"].ToString();
        //        tbNombre.Text = row["Cliente"].ToString();
        //        Program.vidCita = Convert.ToInt32(tbIdCita.Text);
        //        Program.vidPago = Convert.ToInt32(tbIdPago.Text);
        //    }
        //} 

        public void RecuperaDatosPago()
        {
            string vparametro = Program.vidPago.ToString();
            CNPago cNPago = new CNPago();
            DataTable dt = new DataTable();
            dt = cNPago.ObtenerPago(vparametro);

            foreach (DataRow row in dt.Rows)
            {
                string estadoPago = row["Estado"].ToString();

                if (Program.Rol == "SuperAdmin" || Program.Rol == "Admin" || estadoPago == "Pendiente")
                {
                    tbIdPago.Text = row["ID"].ToString();
                    cbMetodo.Text = row["Concepto Pago"].ToString();
                    cbEstado.Text = estadoPago;
                    tbIdCita.Text = row["ID Cita"].ToString();
                    dtpFecha.Text = row["Fecha"].ToString();
                    dtpHora.Text = row["Hora"].ToString();
                    tbPrecio.Text = row["Precio"].ToString();
                    tbServicio.Text = row["Servicio"].ToString();
                    tbIdCliente.Text = row["ID Cliente"].ToString();
                    tbNombre.Text = row["Cliente"].ToString();
                    tbCorreo.Text = row["Correo"].ToString();
                    Program.vidCita = Convert.ToInt32(tbIdCita.Text);
                    Program.vidPago = Convert.ToInt32(tbIdPago.Text);
                }
                else if (estadoPago == "Pagado")
                {
                    MessageBox.Show("No tienes suficientes privilegios para cargar estos datos.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            BEditar_Click(sender: null, e: null);
        }


        private void MantPago_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; 
                SendKeys.Send("{TAB}");
            }
        }

        private void label12_Click(object sender, EventArgs e)
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
                BBuscar.Enabled = false;
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

        private void EnviarCorreoPagoRealizado(
            string correoDestino,
            string nombre,
            string apellido,
            string correoCliente,
            string servicio,
            string fecha,
            string hora,
            string precio,
            string metodoPago,
            string estadoPago
        )
        {
            try
            {
                MailAddress addressFrom = new MailAddress("g.cita.express@gmail.com", "CitaExpress");
                MailAddress addressTo = new MailAddress(correoDestino);
                MailMessage message = new MailMessage(addressFrom, addressTo);

                message.Subject = "Confirmación de Pago - CitaExpress";
                message.IsBodyHtml = true;

                message.Body = $@"
                <div style='font-family: Arial, sans-serif; color: #333; padding: 20px;'>
                    <h2 style='color: #28a745;'>Hola {nombre},</h2>
                    <p>Hemos recibido tu pago en <strong>CitaExpress</strong>. A continuación, los detalles de tu transacción:</p>

                    <h3 style='margin-top: 20px;'>💳 Detalles del Pago:</h3>
                    <ul style='line-height: 1.8;'>
                        <li><strong>Nombre del cliente:</strong> {nombre} {apellido}</li>
                        <li><strong>Correo del cliente:</strong> {correoCliente}</li>
                        <li><strong>Servicio pagado:</strong> {servicio}</li>
                        <li><strong>Fecha de la cita:</strong> {fecha}</li>
                        <li><strong>Hora de la cita:</strong> {hora}</li>
                        <li><strong>Monto pagado:</strong> RD${precio}</li>
                        <li><strong>Método de pago:</strong> {metodoPago}</li>
                        <li><strong>Estado del pago:</strong> {estadoPago}</li>
                    </ul>

                    <p style='margin-top: 20px;'>Gracias por confiar en nosotros. Si tienes alguna pregunta, no dudes en contactarnos.</p>

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
                MessageBox.Show("Error al enviar el correo de pago: " + ex.Message);
            }
        }

        private void EnviarCorreoPagoActualizado(
            string correoDestino,
            string nombre,
            string apellido,
            string correoCliente,
            string servicio,
            string fecha,
            string hora,
            string precio,
            string metodoPago,
            string estadoPago
            )
        {
            try
            {
                MailAddress addressFrom = new MailAddress("g.cita.express@gmail.com", "CitaExpress");
                MailAddress addressTo = new MailAddress(correoDestino);
                MailMessage message = new MailMessage(addressFrom, addressTo);

                message.Subject = "Actualización de Pago - CitaExpress";
                message.IsBodyHtml = true;

                message.Body = $@"
                <div style='font-family: Arial, sans-serif; color: #333; padding: 20px;'>
                    <h2 style='color: #ffc107;'>Hola {nombre},</h2>
                    <p>Queremos informarte que se ha realizado una <strong>actualización en los detalles de tu pago</strong> en <strong>CitaExpress</strong>. A continuación, te presentamos la información actualizada:</p>

                    <h3 style='margin-top: 20px;'>📋 Detalles Actualizados del Pago:</h3>
                    <ul style='line-height: 1.8;'>
                        <li><strong>Nombre del cliente:</strong> {nombre} {apellido}</li>
                        <li><strong>Correo del cliente:</strong> {correoCliente}</li>
                        <li><strong>Servicio:</strong> {servicio}</li>
                        <li><strong>Fecha de la cita:</strong> {fecha}</li>
                        <li><strong>Hora de la cita:</strong> {hora}</li>
                        <li><strong>Monto:</strong> RD${precio}</li>
                        <li><strong>Método de pago:</strong> {metodoPago}</li>
                        <li><strong>Estado del pago:</strong> {estadoPago}</li>
                    </ul>

                    <p style='margin-top: 20px;'>Gracias por mantenerte al tanto. Si tienes dudas, no dudes en contactarnos.</p>

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
                MessageBox.Show("Error al enviar el correo de actualización de pago: " + ex.Message);
            }
        }




    }
}
