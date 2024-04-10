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

namespace Sistema_Barberia
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bIniciarSesion_Click(object sender, EventArgs e)
        {
            string usuario = tbUsuario.Text;
            string clave = tbClave.Text;

            // Verificar si las credenciales son válidas llamando al método en la capa de negocios
            if (cnUsuario.AutenticarUsuario(usuario, clave))
            {
                MessageBox.Show("Inicio de sesión exitoso");
                this.Hide();
                FBienvenida fBienvenida = new FBienvenida();
                fBienvenida.ShowDialog();
                this.Close();
                // Aquí puedes abrir el formulario principal o realizar otras acciones
                //FMenu fMenu = new FMenu();
                //fMenu.ShowDialog();
                //this.Close();

                // Cerrar completamente la aplicación


            }
            else
            {
                tbMensaje.Clear();
                tbMensaje.Text = "Nombre de usuario o contraseña incorrectos";
                tbMensaje.ForeColor = Color.Red; // Cambia el color del texto a rojo
                tbUsuario.Clear();
                tbClave.Clear();
                tbUsuario.Focus();
            }
        }

        private void pictureBox1_Click_2(object sender, EventArgs e)
        {

        }

        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void tbMensaje_TextChanged(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            tbClave.PasswordChar = checkBox1.Checked ? '\0' : '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
