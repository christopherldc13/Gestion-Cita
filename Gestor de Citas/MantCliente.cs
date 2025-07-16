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
using System.Net;
using System.Net.Mail;
using System.Globalization;
using System.Net.Mime; // arriba del todo


namespace Gestor_de_Citas
{
    public partial class MantCliente : Form
    {


        public string valorparametro = "", mensaje = "";
        public MantCliente()
        {
            InitializeComponent();
            tbTelefono.TextChanged += tbTelefono_TextChanged;

        }


        private void MantCliente_Load(object sender, EventArgs e)
        {
            Program.nuevo = false; //Valores de las variables globales nuevo y modificar
            Program.modificar = false;
            HabilitaBotones(); //Se habilitarán los objetos y los botones necesarios.
            tbNombre.KeyPress += tbNombre_KeyPress;
            tbNombre.TextChanged += tbNombre_TextChanged;
            tbApellido.KeyPress += tbApellido_KeyPress;
            tbApellido.TextChanged += tbApellido_TextChanged;

        }

        private void MantCliente_FormClosing(object sender, FormClosingEventArgs e)
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

        private void BSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void LimpiaObjetos()
        {
            tbIdCliente.Clear(); //Para limpiar TextBox.
            tbNombre.Clear(); //Para limpiar TextBox.
            tbApellido.Clear(); //Para limpiar TextBox.
            tbTelefono.Clear(); //Para limpiar TextBox.
            tbCorreo.Clear(); //Para limpiar TextBox.
            cbEstado.SelectedIndex = -1; //Establece el valor por defecto del Combobox
        } 

        private void BGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbNombre.Text))
            {
                MessageBox.Show("Debe indicar el Nombre del Cliente!");
                tbNombre.Focus();
                return;
            }
            else if (string.IsNullOrWhiteSpace(tbApellido.Text))
            {
                MessageBox.Show("Debe indicar el Apellido del Cliente!");
                tbApellido.Focus();
                return;
            }
            else if (string.IsNullOrWhiteSpace(tbTelefono.Text))
            {
                MessageBox.Show("Debe indicar el Teléfono del Cliente!");
                tbTelefono.Focus();
                return;
            }
            else if (string.IsNullOrWhiteSpace(tbCorreo.Text))
            {
                MessageBox.Show("Debe indicar el Correo del Cliente!");
                tbCorreo.Focus();
                return;
            }
            else if (!tbCorreo.Text.EndsWith("@gmail.com") || tbCorreo.Text.Length <= "@gmail.com".Length)
            {
                MessageBox.Show("Debe ingresar un correo válido de Gmail (por ejemplo: ejemplo@gmail.com).");
                tbCorreo.Focus();
                return;
            }
            else if (string.IsNullOrWhiteSpace(cbEstado.Text))
            {
                MessageBox.Show("Debe indicar el Estado del Cliente!");
                cbEstado.Focus();
                return;
            }

            else
            {
                if (Program.nuevo)
                {
                    mensaje = CNCliente.Insertar(Program.vidCliente, tbNombre.Text, tbApellido.Text,
                     tbTelefono.Text, tbCorreo.Text, cbEstado.Text);
                    if (mensaje == "Datos del Cliente insertados correctamente!")
                    {
                        EnviarCorreoBienvenida(tbCorreo.Text, tbNombre.Text, tbApellido.Text, tbTelefono.Text);
                    }
                        

                }
                else 
                {
                    mensaje = CNCliente.Actualizar(Program.vidCliente, tbNombre.Text, tbApellido.Text,
                      tbTelefono.Text, tbCorreo.Text, cbEstado.Text);
                    if (mensaje == "Datos del Cliente actualizados correctamente!")
                    {
                        EnviarCorreoActualizacion(tbCorreo.Text, tbNombre.Text, tbApellido.Text, tbTelefono.Text);
                    }
                        

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

        private void BSalir_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BBuscar_Click(object sender, EventArgs e)
        {
            FBuscarCliente fConsultaCliente = new FBuscarCliente();
            fConsultaCliente.ShowDialog();
            if (Program.modificar) 
            {
                RecuperaDatos(); 
                BEditar_Click(sender, e); 
            }
            else 
            {
                LimpiaObjetos(); 
                BBuscar.Focus();
            }
        }
        public void RecuperaDatos()
        {
            string vparametro = Program.vidCliente.ToString();
            CNCliente cNCliente = new CNCliente();
            DataTable dt = new DataTable(); 
            dt = cNCliente.ObtenerCliente(vparametro); 
                                                             
            foreach (DataRow row in dt.Rows)
            {
                tbIdCliente.Text = row["ID"].ToString();
                tbNombre.Text = row["Nombre"].ToString();
                tbApellido.Text = row["Apellido"].ToString();
                tbTelefono.Text = row["Telefono"].ToString();
                tbCorreo.Text = row["Correo"].ToString();
                cbEstado.Text = row["Estado"].ToString();
            }
        } 


        private void BNuevo_Click(object sender, EventArgs e)
        {
            LimpiaObjetos(); 
            Program.nuevo = true; 
            Program.modificar = false;
            HabilitaBotones(); 
            tbNombre.Focus(); 
        }

        private void HabilitaControles(bool valor)
        {
            tbIdCliente.Enabled = false; 
            tbNombre.Enabled = valor;
            tbApellido.Enabled = valor;
            tbTelefono.Enabled = valor;
            tbCorreo.Enabled = valor;
            cbEstado.Enabled = valor;
            if (Program.nuevo)
            {
                cbEstado.SelectedIndex = 0;
                cbEstado.Enabled = false;
            }
                

        }

        private void BCancelar_Click(object sender, EventArgs e)
        {
            Program.nuevo = false;
            Program.modificar = false;
            HabilitaBotones(); 
            LimpiaObjetos(); 
        }

        private void MantCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; 
                SendKeys.Send("{TAB}");
            }
        }
        private void BEditar_Click(object sender, EventArgs e)
        {
            if (!tbIdCliente.Equals(""))
            {
                Program.modificar = true; 
                HabilitaBotones();
            }
            else
            {
                MessageBox.Show("Debe de buscar un Cliente para poder Modificar sus datos!");
            }
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

        private void tbTelefono_TextChanged(object sender, EventArgs e)
        {
            string numeros = new string(tbTelefono.Text.Where(char.IsDigit).ToArray());

            if (numeros.Length > 10)
                numeros = numeros.Substring(0, 10); // Limitar a 10 dígitos

            string formattedNumber = FormatPhoneNumber(numeros);

            // Solo actualizar el texto si ha cambiado realmente
            if (tbTelefono.Text != formattedNumber)
            {
                tbTelefono.Text = formattedNumber;
                tbTelefono.SelectionStart = formattedNumber.Length; // Mantener el cursor al final
            }
        }

        private string FormatPhoneNumber(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return ""; // Si el input está vacío, no hay paréntesis ni formato
            }
            else if (input.Length <= 3)
            {
                return $"({input}";
            }
            else if (input.Length <= 6)
            {
                return $"({input.Substring(0, 3)}) {input.Substring(3)}";
            }
            else
            {
                return $"({input.Substring(0, 3)}) {input.Substring(3, 3)}-{input.Substring(6)}";
            }
        }

        private void EnviarCorreoBienvenida(string correoDestino, string nombre, string apellido, string telefono)
        {
            try
            {
                MailAddress addressFrom = new MailAddress("g.cita.express@gmail.com", "CitaExpress");
                MailAddress addressTo = new MailAddress(correoDestino);
                MailMessage message = new MailMessage(addressFrom, addressTo);

                message.Subject = "Registro Exitoso - CitaExpress";
                message.IsBodyHtml = true;

                message.Body = $@"
        <div style='font-family: Arial, sans-serif; color: #333; padding: 20px;'>
            <h2 style='color: #0066cc;'>¡Hola {nombre} {apellido}!</h2>
            <p>Te damos la bienvenida a <strong>CitaExpress</strong>.</p>
            <p>Tu registro ha sido <strong>realizado exitosamente</strong>. A partir de ahora podrás agendar y gestionar tus citas de manera fácil y rápida.</p>

            <h3 style='color: #444;'>Tus datos registrados:</h3>
            <ul style='list-style: none; padding: 0;'>
                <li><strong>Nombre:</strong> {nombre}</li>
                <li><strong>Apellido:</strong> {apellido}</li>
                <li><strong>Teléfono:</strong> {telefono}</li>
                <li><strong>Correo:</strong> {correoDestino}</li>
            </ul>

            <p>Gracias por registrarte con nosotros.</p>
            <br/>
            <p style='color: #888;'>Este mensaje fue enviado automáticamente, por favor no respondas a este correo.</p>
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




        private void EnviarCorreoActualizacion(string correoDestino, string nombre, string apellido, string telefono)
        {
            try
            {
                MailAddress addressFrom = new MailAddress("g.cita.express@gmail.com", "CitaExpress");
                MailAddress addressTo = new MailAddress(correoDestino);
                MailMessage message = new MailMessage(addressFrom, addressTo);

                message.Subject = "Actualización de Datos - CitaExpress";
                message.IsBodyHtml = true;

                message.Body = $@"
        <div style='font-family: Arial, sans-serif; color: #000 !important; padding: 20px;'>
            <h2 style='color: #0066cc;'>Hola {nombre} {apellido},</h2>
            <p style='color: #000 !important;'>Te informamos que tus datos han sido <strong style='color: #000 !important;'>actualizados correctamente</strong> en nuestro sistema.</p>

            <h3 style='color: #000 !important;'>Datos actualizados:</h3>
            <ul style='list-style: none; padding: 0; color: #000 !important;'>
                <li><strong style='color: #000 !important;'>Nombre:</strong> <span style='color: #000 !important;'>{nombre}</span></li>
                <li><strong style='color: #000 !important;'>Apellido:</strong> <span style='color: #000 !important;'>{apellido}</span></li>
                <li><strong style='color: #000 !important;'>Teléfono:</strong> <span style='color: #000 !important;'>{telefono}</span></li>
                <li><strong style='color: #000 !important;'>Correo:</strong> <span style='color: #000 !important;'>{correoDestino}</span></li>
            </ul>

            <p style='color: #000 !important;'>Gracias por preferirnos.</p>
            <br/>
            <p style='color: #888;'>Este mensaje fue enviado automáticamente, por favor no respondas a este correo.</p>
            <hr/>
            <p style='font-size: 12px; color: #888;'>© {DateTime.Now.Year} CitaExpress. Todos los derechos reservados.</p>
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




        private bool EsCorreoGmailValido(string correo)
        {
            return correo.EndsWith("@gmail.com") && correo.Length > "@gmail.com".Length;
        }

        private void tbNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && e.KeyChar != '-' && e.KeyChar != '.')
            {
                e.Handled = true; // Bloquea la tecla si no es letra, espacio, guion o punto
            }
        }

        private void tbApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && e.KeyChar != '-' && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void tbNombre_TextChanged(object sender, EventArgs e)
        {
            int cursorPos = tbNombre.SelectionStart;
            tbNombre.Text = ToTitleCase(tbNombre.Text);
            tbNombre.SelectionStart = cursorPos;
        }

        private void tbApellido_TextChanged(object sender, EventArgs e)
        {
            int cursorPos = tbApellido.SelectionStart;
            tbApellido.Text = ToTitleCase(tbApellido.Text);
            tbApellido.SelectionStart = cursorPos;
        }

        private void PBotones_Paint(object sender, PaintEventArgs e)
        {

        }

        private string ToTitleCase(string text)
        {
            CultureInfo cultureInfo = CultureInfo.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            return textInfo.ToTitleCase(text.ToLower());
        }


    }
}
