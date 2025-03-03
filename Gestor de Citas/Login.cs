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

namespace Gestor_de_Citas
{
    public partial class Login : Form
    {
        private CNUsuario cnUsuario = new CNUsuario();
        public Login()
        {
            InitializeComponent();
            tbClave.PasswordChar = '*';
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
        }

        private async void bIniciarSesion_Click(object sender, EventArgs e)
        {
            string usuario = tbUsuario.Text;
            string clave = tbClave.Text;

            if (cnUsuario.AutenticarUsuario(usuario, clave))
            {
                tbMensaje.Clear();
                tbMensaje.Text = "Inicio de sesión exitoso";
                tbMensaje.ForeColor = Color.Green;
                tbMensaje.Visible = true;

                // Mostrar la barra de progreso
                progressBar1.Visible = true;
                progressBar1.Value = 0;

                // Simular carga durante 3 segundos
                for (int i = 0; i <= 100; i += 5)
                {
                    progressBar1.Value = i;
                    await Task.Delay(150); // Controla la velocidad de la barra de progreso
                }

                this.Hide();
                Program.usuario = tbUsuario.Text;
                FBienvenida fBienvenida = new FBienvenida();
                fBienvenida.ShowDialog();
                this.Close();
            }
            else
            {
                tbMensaje.Clear();
                tbMensaje.Text = "Nombre de usuario o contraseña incorrectos";
                tbMensaje.ForeColor = Color.Red;
                tbUsuario.Clear();
                tbClave.Clear();
                tbUsuario.Focus();
            }
        }

        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Esto evita que el sonido de la tecla sea reproducido
                SendKeys.Send("{TAB}");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            tbClave.PasswordChar = checkBox1.Checked ? '\0' : '*';
        }

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
