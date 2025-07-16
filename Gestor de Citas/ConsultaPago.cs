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
    public partial class ConsultaPago : Form
    {
        public int indice = 0, vtieneparametro = 0;
        public string valorparametro = "";
        public ConsultaPago()
        {
            InitializeComponent();
        }

        private void ConsultaPago_Load(object sender, EventArgs e)
        {
            valorparametro = "";
            vtieneparametro = 0;
            Program.vidUsuario = 0; 
            MostrarDatos(); 
            tbBuscar.Focus();
        }

        //private void MostrarDatos()
        //{
        //    valorparametro = tbBuscar.Text.Trim();
        //    CNPago objPago = new CNPago();
        //    if (objPago.ObtenerPago(valorparametro) != null)
        //    {
        //        DGVDatos.DataSource = objPago.ObtenerPago(valorparametro);
        //        DGVDatos.Columns[0].Width = 70; //IdCita
        //        DGVDatos.Columns[1].Width = 65;//IdCliente
        //        DGVDatos.Columns[2].Width = 85;//NombreCliente
        //        DGVDatos.Columns[3].Width = 80;//ApeliidoCliente
        //        DGVDatos.Columns[4].Width = 70;//Telefono
        //        DGVDatos.Columns[5].Width = 70;//IdEmpleado
        //        DGVDatos.Columns[6].Width = 55;//Nombre
        //        DGVDatos.Columns[7].Width = 100;//Telefono
        //        DGVDatos.Columns[8].Width = 80;//Telefono
        //        DGVDatos.Columns[9].Width = 110;//Telefono
        //        DGVDatos.Columns[10].Width = 80;//Estado
        //    }
        //    else
        //        MessageBox.Show("No se retorno ningun valor!");
        //    DGVDatos.Refresh(); 
        //    LCantidadPago.Text = "Cantidad de Pagos: " + Convert.ToString(DGVDatos.RowCount); 
        //    if (DGVDatos.RowCount <= 0) 
        //    {
        //        MessageBox.Show("Ningún dato que mostrar!"); 
        //    }
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
                string[] headers = { "ID Pago", "ID Cliente", "Cliente", "Apellido", "Correo", "ID Cita", "Fecha", "Hora", "Servicio", "Precio", "Método de Pago", "Estado" };
                int[] widths = { 80, 65, 100, 80, 145, 75, 69, 70, 90, 60, 110, 70 }; // Añadí el ancho para "Precio"

                DGVDatos.DataSource = datos;

                for (int i = 0; i < headers.Length && i < DGVDatos.Columns.Count; i++)
                {
                    DGVDatos.Columns[i].HeaderText = headers[i];
                    DGVDatos.Columns[i].Width = widths[i];
                    DGVDatos.AllowUserToResizeRows = false;
                    DGVDatos.AllowUserToOrderColumns = false;
                    DGVDatos.AllowUserToResizeColumns = false;
                    LCantidadPago.Text = "Cantidad de Pagos: " + Convert.ToString(DGVDatos.RowCount);
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

        private void bSalir_Click(object sender, EventArgs e)
        {
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

        private void ConsultaPago_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void ConsultaPago_FormClosing(object sender, FormClosingEventArgs e)
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
    }
}
