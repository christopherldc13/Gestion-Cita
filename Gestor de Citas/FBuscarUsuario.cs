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
    public partial class FBuscarUsuario : Form
    {
        public int indice = 0, vtieneparametro = 0;
        public string valorparametro = "";
        public FBuscarUsuario()
        {
            InitializeComponent();
        }

        private void FConsultaUsuario_FormClosing(object sender, FormClosingEventArgs e)
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

        private void FConsultaUsuario_Load(object sender, EventArgs e)
        {
            valorparametro = "";
            vtieneparametro = 0;
            Program.vidUsuario = 0; 
            MostrarDatos(); 
            tbBuscar.Focus();
            DGVDatos.CellFormatting += DGVDatos_CellFormatting;

        }

        private void DGVDatos_CurrentCellChanged(object sender, EventArgs e)
        {
            if (DGVDatos.CurrentRow != null) 
                indice = DGVDatos.CurrentRow.Index; 
        }

        private void bCancelar_Click(object sender, EventArgs e)
        {
            Program.modificar = false; 
            Close(); 
        }

        private void bAceptar_Click(object sender, EventArgs e)
        {
            if (DGVDatos.CurrentRow != null) 
            {
                Program.modificar = true;
                Program.vidUsuario = Convert.ToInt32(DGVDatos.CurrentRow.Cells[0].Value);
            }
            Close();
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

        private void DGVDatos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!(e.RowIndex > -1))
            {
                return;
            }
            bAceptar_Click(sender, e); 
        }

        private void BBuscar_Click(object sender, EventArgs e)
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
        }

        private void FBuscarUsuario_KeyDown(object sender, KeyEventArgs e)
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

        private void DGVDatos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Si estamos en la columna de "Clave"
            if (e.ColumnIndex == DGVDatos.Columns["Clave"].Index && e.Value != null)
            {
                // Reemplazar la clave por asteriscos (basado en la longitud)
                string clave = e.Value.ToString();
                e.Value = new string('*', clave.Length);
            }
        }

        private void MostrarDatos()
        {
            valorparametro = tbBuscar.Text.Trim();
            CNUsuario objUsuario = new CNUsuario();

            DGVDatos.AllowUserToResizeRows = false;
            DGVDatos.AllowUserToOrderColumns = false;
            DGVDatos.AllowUserToResizeColumns = false;

            if (objUsuario.ObtenerUsuario(valorparametro) != null)
            {
                DGVDatos.DataSource = objUsuario.ObtenerUsuario(valorparametro);
                DGVDatos.Columns[0].Width = 70; 
                DGVDatos.Columns[1].Width = 125;
                DGVDatos.Columns[2].Width = 125;
                DGVDatos.Columns[3].Width = 70;
                DGVDatos.Columns[4].Width = 90;
                DGVDatos.Columns[5].Width = 100;
                DGVDatos.Columns[6].Width = 70;
            }
            else
                MessageBox.Show("No se retorno ningun valor!");
                DGVDatos.Refresh(); 

        }
    }
}
