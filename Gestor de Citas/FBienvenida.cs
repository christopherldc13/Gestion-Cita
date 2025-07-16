using GUI_MODERNISTA;
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
    public partial class FBienvenida : Form
    {
        public FBienvenida()
        {
            InitializeComponent();
            bContinuar.Focus();
        }

        // Al presionarse Enter, mueve el foco al siguiente control y ejecuta el botón "Continuar".
        private void FBienvenida_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
                bContinuar.PerformClick(); // Llama al evento Click del button2

            }
        }

        // Establece el foco en el botón "Continuar".
        private void FBienvenida_Load(object sender, EventArgs e)
        {
            bContinuar.Focus();
        }

        //Cierra el formulario
        private void bSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Oculta el formulario actual y abre el Menú
        private void bContinuar_Click(object sender, EventArgs e)
        {
            this.Hide();
            //this.Close();
            //FMenu fmenu = new FMenu();
            //fmenu.ShowDialog(); 
            Form1 form1 = new Form1();
            form1.ShowDialog();
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
