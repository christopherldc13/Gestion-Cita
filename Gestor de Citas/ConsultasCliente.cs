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
    public partial class ConsultasCliente : Form
    {
        public int indice = 0, vtieneparametro = 0;
        public string valorparametro = "";

        public ConsultasCliente()
        {
            InitializeComponent();
        }

        private void ConsultasCliente_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Puedes agregar la lógica de confirmación de cierre si lo deseas
        }

        private void ConsultasCliente_Load(object sender, EventArgs e)
        {
            valorparametro = "";
            vtieneparametro = 0;
            Program.vidUsuario = 0;
            MostrarDatos();
            tbBuscar.Focus();
        }

        private void DGVDatos_CurrentCellChanged(object sender, EventArgs e)
        {
            if (DGVDatos.CurrentRow != null)
                indice = DGVDatos.CurrentRow.Index;
        }

        private void bSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BConsultar_Click(object sender, EventArgs e)
        {
            // Ya no es necesario, ya que vamos a usar el evento TextChanged para filtrar mientras escriben
            if (tbBuscar.Text != String.Empty)
            {
                vtieneparametro = 1;
                valorparametro = "%" + tbBuscar.Text.Trim() + "%";
            }
            else
            {
                vtieneparametro = 0;
                valorparametro = "";
            }
            MostrarDatos();
            tbBuscar.Focus();
        }

        private void bPrimero_Click(object sender, EventArgs e)
        {
            if (DGVDatos.Rows.Count > 1)
            {
                indice = 0;
                DGVDatos.CurrentCell = DGVDatos.Rows[indice].Cells[DGVDatos.CurrentCell.ColumnIndex];
            }
        }

        private void bAnterior_Click(object sender, EventArgs e)
        {
            if (indice > 0)
            {
                indice = indice - 1;
                DGVDatos.CurrentCell = DGVDatos.Rows[indice].Cells[DGVDatos.CurrentCell.ColumnIndex];
            }
        }

        private void bSiguiente_Click(object sender, EventArgs e)
        {
            if (indice < this.DGVDatos.RowCount - 1)
            {
                indice++;
                DGVDatos.CurrentCell = DGVDatos.Rows[indice].Cells[DGVDatos.CurrentCell.ColumnIndex];
            }
        }

        private void bUltimo_Click(object sender, EventArgs e)
        {
            if (indice < this.DGVDatos.RowCount - 1)
            {
                indice = DGVDatos.Rows.Count - 1;
                DGVDatos.CurrentCell = DGVDatos.Rows[indice].Cells[DGVDatos.CurrentCell.ColumnIndex];
            }
        }

        private void ConsultasCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SendKeys.Send("{TAB}");
            }
        }

        // Evento TextChanged para filtrar los datos mientras el usuario escribe en el TextBox
        private void tbBuscar_TextChanged(object sender, EventArgs e)
        {
            valorparametro = tbBuscar.Text.Trim(); // Obtener el texto ingresado
            vtieneparametro = string.IsNullOrEmpty(valorparametro) ? 0 : 1; // Si el texto está vacío, no hay filtro

            MostrarDatos(); // Filtrar y mostrar los datos
        }

        private void MostrarDatos()
        {
            valorparametro = tbBuscar.Text.Trim();
            CNCliente objCliente = new CNCliente();

            var datos = objCliente.ObtenerCliente(valorparametro); // Pasar el parámetro de búsqueda a la función

            if (datos != null)
            {
                string[] headers = { "ID Cliente", "Nombre", "Apellido", "Teléfono", "Correo", "Estado" };
                int[] widths = { 80, 150, 150, 100, 175, 125 };

                DGVDatos.DataSource = datos;

                // Configurar las columnas
                for (int i = 0; i < headers.Length && i < DGVDatos.Columns.Count; i++)
                {
                    DGVDatos.Columns[i].HeaderText = headers[i];
                    DGVDatos.Columns[i].Width = widths[i];
                    DGVDatos.AllowUserToResizeRows = false;
                    DGVDatos.AllowUserToOrderColumns = false;
                    DGVDatos.AllowUserToResizeColumns = false;
                    LCantidadCliente.Text = "Cantidad de Clientes: " + Convert.ToString(DGVDatos.RowCount);
                }
            }
            else
            {
                MessageBox.Show("No se retornó ningún valor!");
            }

            DGVDatos.Refresh();
        }
    }
}
