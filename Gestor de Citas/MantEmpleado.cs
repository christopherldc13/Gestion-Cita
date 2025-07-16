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
using System.Globalization;

namespace Gestor_de_Citas
{
    public partial class MantEmpleado : Form
    {
        public string valorparametro = "", mensaje = "";
        public MantEmpleado()
        {
            InitializeComponent();
            tbTelefono.TextChanged += tbTelefono_TextChanged; //Llama el evento que le da formato al numero
        }

        private void MantEmpleado_Load(object sender, EventArgs e)
        {
            Program.nuevo = false; //Valores de las variables globales nuevo y modificar
            Program.modificar = false;
            HabilitaBotones(); //Se habilitarán los objetos y los botones necesarios.

        }

        private void MantEmpleado_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¡Esto hara salir del formulario! \n ¿Seguro que desea hacerlo?",
                               "Mensaje de " + Program.copyright,
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

        private void BNuevo_Click(object sender, EventArgs e)
        {
            LimpiaObjetos(); 
            Program.nuevo = true; 
            Program.modificar = false;
            HabilitaBotones(); 
            tbNombre.Focus(); 
        }

        public void LimpiaObjetos()
        {
            tbIdEmpleado.Clear(); 
            tbNombre.Clear(); 
            tbApellido.Clear(); 
            tbTelefono.Clear(); 
            tbDisponibilidad.Clear(); 
            cbEstado.SelectedIndex = -1; 
        } 

        private void HabilitaControles(bool valor)
        {
            tbIdEmpleado.Enabled = false; 
            tbNombre.Enabled = valor;
            tbApellido.Enabled = valor;
            tbTelefono.Enabled = valor;
            tbDisponibilidad.Enabled = valor;
            cbEstado.Enabled = valor;
            if (Program.nuevo)
                cbEstado.SelectedIndex = 0;
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

        private void BEditar_Click(object sender, EventArgs e)
        {
            if (!tbIdEmpleado.Equals(""))
            {
                Program.modificar = true; 
                HabilitaBotones();
            }
            else
            {
                MessageBox.Show("Debe de buscar un Empleado para poder Modificar sus datos!");
            }
        }

        private void BGuardar_Click(object sender, EventArgs e)
        {
            if (tbNombre.Text == String.Empty) 
            { 
                MessageBox.Show("Debe indicar el Nombre del Empleado!");
                tbNombre.Focus();
                return;
            }
            else
            if (tbApellido.Text == String.Empty)
            {
                MessageBox.Show("Debe indicar el Apellido del Empleado!");
                tbApellido.Focus();
                return;
            }
            else
            if (tbTelefono.Text == String.Empty)
            {
                MessageBox.Show("Debe indicar el Teléfono del Empleado!");
                tbTelefono.Focus();
                return;
            }
            else
            if (tbDisponibilidad.Text == String.Empty)
            {
                MessageBox.Show("Debe indicar la Disponibilidad del Empleado!");
                tbDisponibilidad.Focus();
                return;
            }
            else
            if (cbEstado.Text == String.Empty)
            {
                MessageBox.Show("Debe indicar el Estado del Empleado!");
                cbEstado.Focus();
                return;
            }
            else
            {
                if (Program.nuevo)
                {

                    //mensaje = CNEmpleado.Insertar(Program.vidEmpleado, tbNombre.Text, tbApellido.Text,
                    // tbTelefono.Text, tbDisponibilidad.Text, cbEstado.Text);
                }
                else 
                {

                    //mensaje = CNEmpleado.Actualizar(Program.vidEmpleado, tbNombre.Text, tbApellido.Text,
                    //  tbTelefono.Text, tbDisponibilidad.Text, cbEstado.Text);
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

        private void MantEmpleado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void BCancelar_Click(object sender, EventArgs e)
        {
            Program.nuevo = false;
            Program.modificar = false;
            HabilitaBotones(); 
            LimpiaObjetos(); 
        }

        private void BBuscar_Click(object sender, EventArgs e)
        {
            FBuscarEmpleado fBuscarEmpleado = new FBuscarEmpleado();
            fBuscarEmpleado.ShowDialog();
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

        private void PTitulo_Paint(object sender, PaintEventArgs e)
        {

        }

        public void RecuperaDatos()
        {
            string vparametro = Program.vidEmpleado.ToString();
            CNEmpleado cNEmpleado = new CNEmpleado();
            DataTable dt = new DataTable(); 
            dt = cNEmpleado.ObtenerEmpleado(vparametro); 

            foreach (DataRow row in dt.Rows)
            {
                tbIdEmpleado.Text = row["ID"].ToString();
                tbNombre.Text = row["Nombre"].ToString();
                tbApellido.Text = row["Apellido"].ToString();
                tbTelefono.Text = row["Telefono"].ToString();
                tbDisponibilidad.Text = row["Disponibilidad"].ToString();
                cbEstado.Text = row["Estado"].ToString();
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

        private string ToTitleCase(string text)
        {
            CultureInfo cultureInfo = CultureInfo.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            return textInfo.ToTitleCase(text.ToLower());
        }
    }
}
