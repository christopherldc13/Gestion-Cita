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
            button2.Focus();
        }

        private void BSalir_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Se ejecuta");
            //this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
            FMenu fmenu = new FMenu();
            fmenu.ShowDialog();
        }

        private void FBienvenida_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
                button2.PerformClick(); // Llama al evento Click del button2

            }
        }

        private void FBienvenida_Load(object sender, EventArgs e)
        {
            button2.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
