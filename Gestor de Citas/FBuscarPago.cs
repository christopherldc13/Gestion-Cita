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
    public partial class FBuscarPago : Form
    {
        public int indice = 0, vtieneparametro = 0;
        public string valorparametro = "";
        public FBuscarPago()
        {
            InitializeComponent();
        }

        private void FConsultaPago_FormClosing(object sender, FormClosingEventArgs e)
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
                Program.vidPago = Convert.ToInt32(DGVDatos.CurrentRow.Cells[0].Value);
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

        private void FConsultaPago_Load(object sender, EventArgs e)
        {
            valorparametro = "";
            vtieneparametro = 0;
            Program.vidCliente = 0; 
            MostrarDatos(); 
            tbBuscar.Focus(); 
        }

        private void FBuscarPago_KeyDown(object sender, KeyEventArgs e)
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
        //    CNPago objPago = new CNPago();
        //    if (objPago.ObtenerPago(valorparametro) != null)
        //    {
        //        DGVDatos.DataSource = objPago.ObtenerPago(valorparametro);
        //        DGVDatos.Columns[0].Width = 80; //IdPago
        //        DGVDatos.Columns[1].Width = 80;//IdCliente
        //        DGVDatos.Columns[2].Width = 100;//Apellido
        //        DGVDatos.Columns[3].Width = 80;//IdCita
        //        DGVDatos.Columns[4].Width = 80;//Fecha
        //        DGVDatos.Columns[5].Width = 75;//Hora
        //        DGVDatos.Columns[6].Width = 69;//Hora
        //        DGVDatos.Columns[7].Width = 95;//Servicio
        //        DGVDatos.Columns[8].Width = 75;//Concepto Pago
        //        DGVDatos.Columns[9].Width = 110;//Estado
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
            CNPago objPago = new CNPago();

            var datos = objPago.ObtenerPago(valorparametro);

            if (datos != null)
            {
                string[] headers = { "ID Pago", "ID Cliente", "Cliente", "Apellido", "Correo" ,"ID Cita", "Fecha", "Hora", "Servicio", "Precio", "Método de Pago", "Estado" };
                int[] widths = { 80, 65, 100, 80, 145, 75, 69, 70, 90, 60, 110, 70 }; // Añadí el ancho para "Precio"

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
