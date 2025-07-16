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
using Microsoft.Reporting.Map.WebForms.BingMaps;

namespace Gestor_de_Citas
{
    public partial class Login : Form
    {
        private CNUsuario cnUsuario = new CNUsuario();
        public Login()
        {
            InitializeComponent();
            //Iniciarlizar los * para que no se vea la clace
            tbClave.PasswordChar = '*';
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
        }

        private void Login_Load(object sender, EventArgs e)
        {
            //Carga el copyright con la variable Program.copyright, y el año se actualiza según el equipo
            toolStripStatusLabel1.Text = $"Copyright {Program.copyright} {DateTime.Now.Year}, La Vega Rep. Dom.";
        }

        // Maneja el proceso de inicio de sesión del usuario, incluyendo autenticación, validación y redirección.
        private async void bIniciarSesion_Click(object sender, EventArgs e)
        {
            // Obtener los valores ingresados por el usuario
            string usuario = tbUsuario.Text;
            string clave = tbClave.Text;

            // Deshabilitar el botón y cambiar su texto mientras se procesa la autenticación
            bIniciarSesion.Enabled = false;
            bIniciarSesion.Text = "Cargando...";
            tbMensaje.Clear();
            tbMensaje.Visible = true;

            // Obtener el mensaje y el rol del usuario desde la base de datos
            (string mensaje, string rol) = cnUsuario.AutenticarUsuario(usuario, clave);

            // Ajustar el tamaño de la fuente si el usuario está inactivo
            if (mensaje == "El usuario está inactivo. Intente con otro usuario.")
            {
                tbMensaje.Font = new Font(tbMensaje.Font.FontFamily, 10); 
            }
            else
            {
                tbMensaje.Font = new Font(tbMensaje.Font.FontFamily, 12); 
            }

            // Si la autenticación fue exitosa
            if (mensaje == "Autenticación exitosa")
            {
                tbMensaje.Text = mensaje;
                tbMensaje.ForeColor = Color.Green;

                // Guardar el rol del usuario en la variable global
                Program.Rol = rol;

                progressBar1.Visible = true;
                progressBar1.Value = 0;

                int tiempoTotal = 2000; // Tiempo total de espera en milisegundos (2 segundos)
                int pasos = 100; // Número de pasos en la barra de progreso
                int delay = tiempoTotal / (pasos / 5); // Calcular retraso entre cada incremento

                // Simular carga de progreso antes de redirigir al usuario
                for (int i = 0; i <= 100; i += 5)
                {
                    progressBar1.Value = i;
                    await Task.Delay(delay); 
                }

                // Ocultar el formulario de inicio de sesión
                this.Hide();
                Program.usuario = usuario;
              
                // Abrir la pantalla de bienvenida
                FBienvenida fBienvenida = new FBienvenida();
                fBienvenida.ShowDialog();
                this.Close();
            }
            else
            {
                tbMensaje.Text = mensaje;
                tbMensaje.ForeColor = Color.Red;
                tbUsuario.Clear();
                tbClave.Clear();
            }

            // Restaurar el estado del botón después de la autenticación
            bIniciarSesion.Enabled = true;
            bIniciarSesion.Text = "Iniciar Sesión";
            tbClave.Clear();
            tbUsuario.Focus(); 
        }


        // Detecta cuando se presiona la tecla Enter y mueve el foco al siguiente control sin reproducir sonido.
        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; 
                SendKeys.Send("{TAB}");
            }
        }

        // Muestra u oculta la contraseña en el TextBox según el estado del CheckBox.
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            tbClave.PasswordChar = checkBox1.Checked ? '\0' : '*';
        }

        //Cierra el Formulario
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void tbMensaje_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
