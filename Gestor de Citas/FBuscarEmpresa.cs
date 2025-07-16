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
    public partial class FBuscarEmpresa : Form
    {
        public int indice = 0, vtieneparametro = 0;
        public string valorparametro = "";
        public FBuscarEmpresa()
        {
            InitializeComponent();
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

        private void FConsultaEmpresa_Load(object sender, EventArgs e)
        {
            valorparametro = "";
            vtieneparametro = 0;
            Program.vidEmpresa = 0; 
            MostrarDatos(); 
            tbBuscar.Focus(); 
        }

        private void FConsultaEmpresa_FormClosing(object sender, FormClosingEventArgs e)
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

        //private void MostrarDatos()
        //{
        //    valorparametro = tbBuscar.Text.Trim();
        //    CNEmpresa objEmpresa = new CNEmpresa();
        //    if (objEmpresa.ObtenerEmpresa(valorparametro) != null)
        //    {
        //        DGVDatos.DataSource = objEmpresa.ObtenerEmpresa(valorparametro);
        //        DGVDatos.Columns[0].Width = 70; //IdEmpresa
        //        DGVDatos.Columns[1].Width = 200;//Nombre
        //        DGVDatos.Columns[2].Width = 90;//Telefono
        //        DGVDatos.Columns[3].Width = 100;//Direccion
        //        DGVDatos.Columns[4].Width = 125;//Correo
        //        DGVDatos.Columns[5].Width = 125;//Logo
        //        DGVDatos.Columns[6].Width = 150;//Eslogan
        //    }
        //    else
        //        MessageBox.Show("No se retorno ningun valor!");
        //        DGVDatos.Refresh(); 
        //}

        private void MostrarDatos()
        {
            valorparametro = tbBuscar.Text.Trim();
            CNEmpresa objEmpresa = new CNEmpresa();

            var datos = objEmpresa.ObtenerEmpresa(valorparametro);

            if (datos != null)
            {
                string[] headers = { "ID Empresa", "Nombre", "Teléfono", "Dirección", "Correo", "Logo", "Eslogan" };
                int[] widths = { 70, 200, 90, 100, 125, 125, 150 };

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
                Program.vidEmpresa = Convert.ToInt32(DGVDatos.CurrentRow.Cells[0].Value);
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

        private void FBuscarEmpresa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void DGVDatos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!(e.RowIndex > -1))
            {
                return;
            }
            bAceptar_Click(sender, e); 
        }

        private void DGVDatos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!(e.RowIndex > -1))
            {
                return;
            }
            bAceptar_Click(sender, e); 
        }
    }
}
