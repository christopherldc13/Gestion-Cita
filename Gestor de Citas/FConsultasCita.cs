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
            if (MessageBox.Show("Esto hara salir del formulario! \n Seguro que desea hacerlo?",
                               "Mensaje de JAC",
                               MessageBoxButtons.YesNo,
                               MessageBoxIcon.Question,
                               MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                e.Cancel = false;
            else
                e.Cancel = true;
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
        private void MostrarDatos()
        {
            valorparametro = tbBuscar.Text.Trim();
            CNCita objCita = new CNCita();
            if (objCita.ObtenerCita(valorparametro) != null)
            {
                DGVDatos.DataSource = objCita.ObtenerCita(valorparametro);
                DGVDatos.Columns[0].Width = 80; //IdCita
                DGVDatos.Columns[1].Width = 70;//IdCliente
                DGVDatos.Columns[2].Width = 100;//NombreCliente
                DGVDatos.Columns[3].Width = 90;//ApeliidoCliente
                DGVDatos.Columns[4].Width = 90;//Telefono
                DGVDatos.Columns[5].Width = 70;//IdEmpleado
                DGVDatos.Columns[6].Width = 100;//Nombre
                DGVDatos.Columns[7].Width = 110;//Telefono
                DGVDatos.Columns[8].Width = 80;//Telefono
                DGVDatos.Columns[9].Width = 60;//Telefono
                DGVDatos.Columns[10].Width = 63;//Telefono
                DGVDatos.Columns[11].Width = 120;//Telefono
                DGVDatos.Columns[12].Width = 60;//Telefono
                DGVDatos.Columns[13].Width = 80;//Telefono
            }
            else
                MessageBox.Show("No se retorno ningun valor!");
            DGVDatos.Refresh(); 
            LCantidadCita.Text = "Cantidad de Citas: " + Convert.ToString(DGVDatos.RowCount); 
            if (DGVDatos.RowCount <= 0) 
            {
                MessageBox.Show("Ningún dato que mostrar!"); 
            }
        }
    }
}
