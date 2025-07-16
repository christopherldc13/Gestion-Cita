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
    public partial class FConsultasCita : Form
    {
        public int indice = 0, vtieneparametro = 0;
        public string valorparametro = "";
        public FConsultasCita()
        {
            InitializeComponent();
        }

        private void FConsultasCita_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (MessageBox.Show("Esto hara salir del formulario! \n Seguro que desea hacerlo?",
            //                   "Mensaje de JAC",
            //                   MessageBoxButtons.YesNo,
            //                   MessageBoxIcon.Question,
            //                   MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            //    e.Cancel = false;
            //else
            //    e.Cancel = true;
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
                DGVDatos.CurrentCell =
                DGVDatos.Rows[indice].Cells[DGVDatos.CurrentCell.ColumnIndex];
            }
        }

        private void bSiguiente_Click(object sender, EventArgs e)
        {
            if (indice < this.DGVDatos.RowCount - 1) 
            {
                indice++;
                DGVDatos.CurrentCell =
               DGVDatos.Rows[indice].Cells[DGVDatos.CurrentCell.ColumnIndex];
            }
        }

        private void bUltimo_Click(object sender, EventArgs e)
        {
            if (indice < this.DGVDatos.RowCount - 1) 
            {
                indice = DGVDatos.Rows.Count - 1; 
                DGVDatos.CurrentCell =
               DGVDatos.Rows[indice].Cells[DGVDatos.CurrentCell.ColumnIndex];
            }
        }

        private void FConsultasCita_Load(object sender, EventArgs e)
        {
            valorparametro = "";
            vtieneparametro = 0;
            Program.vidUsuario = 0; 
            MostrarDatos(); 
            tbBuscar.Focus(); 
        }

        private void FConsultasCita_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void tbBuscar_TextChanged(object sender, EventArgs e)
        {
            valorparametro = tbBuscar.Text.Trim(); // Obtener el texto ingresado
            vtieneparametro = string.IsNullOrEmpty(valorparametro) ? 0 : 1; // Si el texto está vacío, no hay filtro

            MostrarDatos(); // Filtrar y mostrar los datos
        }


        private void MostrarDatos()
        {
            valorparametro = tbBuscar.Text.Trim();
            CNCita objCita = new CNCita();

            var datos = objCita.ObtenerCita(valorparametro);

            if (datos != null)
            {
                string[] headers = { "ID Cita", "ID Cliente", "Cliente", "Apellido", "Teléfono Cliente",
                             "ID Empleado", "Empleado", "Teléfono Empleado", "Fecha", "Hora",
                             "ID Servicio", "Servicio", "Precio", "Duración", "Estado" };

                DGVDatos.DataSource = datos;
                DGVDatos.AllowUserToResizeRows = false;
                DGVDatos.AllowUserToOrderColumns = false;
                DGVDatos.AllowUserToResizeColumns = false;

                int[] widths = { 60, 60, 80, 75, 90, 70, 90, 85, 80, 70, 60, 90, 50, 60, 85 };

                for (int i = 0; i < headers.Length && i < DGVDatos.Columns.Count; i++)
                {
                    DGVDatos.Columns[i].HeaderText = headers[i];
                    DGVDatos.Columns[i].Width = widths[i];
                }
            }
            else
            {
                MessageBox.Show("No se retornó ningún valor!");
            }

            DGVDatos.Refresh();
            LCantidadCita.Text = "Cantidad de Citas: " + Convert.ToString(DGVDatos.RowCount);
        }

    }
}
