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
    public partial class FBuscarCliente : Form
    {
        public int indice = 0, vtieneparametro = 0;
        public string valorparametro = "";
        public FBuscarCliente()
        {
            InitializeComponent();
        }

        private void FConsultaCliente_Load(object sender, EventArgs e)
        {
            valorparametro = "";
            vtieneparametro = 0;
            Program.vidCliente = 0; 
            MostrarDatos(); 
            tbBuscar.Focus(); 
        }

        private void FConsultaCliente_FormClosing(object sender, FormClosingEventArgs e)
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
                Program.vidCliente = Convert.ToInt32(DGVDatos.CurrentRow.Cells[0].Value);
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

        private void DGVDatos_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
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

        private void DGVDatos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!(e.RowIndex > -1))
            {
                return;
            }
            bAceptar_Click(sender, e); 
        }

        private void FBuscarCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SendKeys.Send("{TAB}");
            }
        }

        //private void MostrarDatos()
        //{
        //    valorparametro = tbBuscar.Text.Trim();
        //    CNCliente objCliente = new CNCliente();
        //    if (objCliente.ObtenerCliente(valorparametro) != null)
        //    {
        //        DGVDatos.DataSource = objCliente.ObtenerCliente(valorparametro);
        //        DGVDatos.Columns[0].Width = 80; //IdCliente
        //        DGVDatos.Columns[1].Width = 150;//Nombre
        //        DGVDatos.Columns[2].Width = 150;//Apellido
        //        DGVDatos.Columns[3].Width = 100;//Telefono
        //        DGVDatos.Columns[4].Width = 175;//Correo
        //        DGVDatos.Columns[5].Width = 125;//Estado
        //    }
        //    else
        //        MessageBox.Show("No se retorno ningun valor!");
        //        DGVDatos.Refresh(); 
        //}

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

            var datos = objCliente.ObtenerCliente(valorparametro);

            if (datos != null)
            {
                string[] headers = { "ID Cliente", "Nombre", "Apellido", "Teléfono", "Correo", "Estado" };
                int[] widths = { 80, 150, 150, 100, 175, 125 };

                DGVDatos.DataSource = datos;

                for (int i = 0; i < headers.Length && i < DGVDatos.Columns.Count; i++)
                {
                    DGVDatos.Columns[i].HeaderText = headers[i];
                    DGVDatos.Columns[i].Width = widths[i];
                    DGVDatos.AllowUserToResizeRows = false;
                    DGVDatos.AllowUserToOrderColumns = false;
                    DGVDatos.AllowUserToResizeColumns = false;
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
