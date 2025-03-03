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
    public partial class ConsultasEmpleado : Form
    {
        public int indice = 0, vtieneparametro = 0;
        public string valorparametro = "";
        public ConsultasEmpleado()
        {
            InitializeComponent();
        }

        private void ConsultasEmpleado_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Esto hara salir del formulario! \n Seguro que desea hacerlo?",
                               "Mensaje de JAC",
                               MessageBoxButtons.YesNo,
                               MessageBoxIcon.Question,
                               MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                e.Cancel = false;
            else
                e.Cancel = true;
        }

        private void ConsultasEmpleado_Load(object sender, EventArgs e)
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

        private void ConsultasEmpleado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void MostrarDatos()
        {
            valorparametro = tbBuscar.Text.Trim();
            CNEmpleado objEmpleado = new CNEmpleado();
            if (objEmpleado.ObtenerEmpleado(valorparametro) != null)
            {
                DGVDatos.DataSource = objEmpleado.ObtenerEmpleado(valorparametro);
                DGVDatos.Columns[0].Width = 70; //IdEmpleado
                DGVDatos.Columns[1].Width = 125; //Nombre
                DGVDatos.Columns[2].Width = 125; //Apellido
                DGVDatos.Columns[3].Width = 100; //Telefono
                DGVDatos.Columns[4].Width = 240; //Disponibilidad
                DGVDatos.Columns[5].Width = 90; //Estado
                LCantidadEmpleados.Text = "Cantidad de Empleados: " + Convert.ToString(DGVDatos.RowCount);
            }
            else 
            {
                MessageBox.Show("No se retornó ningún valor!");
            }
            DGVDatos.Refresh(); 
            if (DGVDatos.RowCount <= 0) 
            {
                MessageBox.Show("Ningún dato que mostrar!"); 
            }
        } 
    }
}
