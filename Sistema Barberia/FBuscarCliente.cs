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

namespace Sistema_Barberia
{
    public partial class FBuscarCliente : Form
    {
        public int indice = 0, vtieneparametro = 0;
        public string valorparametro = "";
        public FBuscarCliente()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void FConsultaCliente_Load(object sender, EventArgs e)
        {
            valorparametro = "";
            vtieneparametro = 0;
            Program.vidCliente = 0; //variable global que tomará el valor seleccionado
            MostrarDatos(); //Llamo al Método que llena el DataGrid
            tbBuscar.Focus(); //El TextBox Buscar recibe el cursor
        }

        private void FConsultaCliente_FormClosing(object sender, FormClosingEventArgs e)
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void DGVDatos_CurrentCellChanged(object sender, EventArgs e)
        {
            if (DGVDatos.CurrentRow != null) //Si el DataGridView no está vacío
                indice = DGVDatos.CurrentRow.Index; //El valor de índice será la fila actual
        }

        private void bCancelar_Click(object sender, EventArgs e)
        {
            Program.modificar = false; //variable global a toda la solución
            Close(); //Se cierra el formulario
        }

        private void bAceptar_Click(object sender, EventArgs e)
        {
            if (DGVDatos.CurrentRow != null) //Si el DataGridView no está vacío
            {
                //variable global a toda la solución se hace verdadera y se le asigna a la variable global vidSuplidor
                // el valor de la clave correspondiente
                Program.modificar = true;
                Program.vidCliente = Convert.ToInt32(DGVDatos.CurrentRow.Cells[0].Value);
            }
            Close();
        }

        private void bPrimero_Click(object sender, EventArgs e)
        {
            if (DGVDatos.Rows.Count > 1) //Si no estamos al inicio del DataGridView, vamos al inicio
            {
                indice = 0;
                DGVDatos.CurrentCell = DGVDatos.Rows[indice].Cells[DGVDatos.CurrentCell.ColumnIndex];
            }
        }

        private void bAnterior_Click(object sender, EventArgs e)
        {
            if (indice > 0) //Si no estamos al inicio del DataGridView, retrocedemos 1 fila
            {
                indice = indice - 1;
                DGVDatos.CurrentCell =
                DGVDatos.Rows[indice].Cells[DGVDatos.CurrentCell.ColumnIndex];
            }
        }

        private void bSiguiente_Click(object sender, EventArgs e)
        {
            if (indice < this.DGVDatos.RowCount - 1) //Si no estamos al final del DataGridView, avanzamos 1 fila
            {
                indice++;
                DGVDatos.CurrentCell =
               DGVDatos.Rows[indice].Cells[DGVDatos.CurrentCell.ColumnIndex];
            }

        }

        private void bUltimo_Click(object sender, EventArgs e)
        {
            if (indice < this.DGVDatos.RowCount - 1) //Si no estamos al final del DataGridView
            {
                indice = DGVDatos.Rows.Count - 1; //vamos a la última fila del DataGridView
                DGVDatos.CurrentCell =
               DGVDatos.Rows[indice].Cells[DGVDatos.CurrentCell.ColumnIndex];
            }
        }

        private void DGVDatos_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //si se pulsa en el encabezado, RowIndex será menor que cero y no se hará nada
            if (!(e.RowIndex > -1))
            {
                return;
            }
            bAceptar_Click(sender, e); //Se ejecuta el método del botón Aceptar
        }

        private void BBuscar_Click(object sender, EventArgs e)
        {
            if (tbBuscar.Text != String.Empty) //Si se introdujo un dato en el textbox
            {
                vtieneparametro = 1; //se indica que se trabajará con parámetros
                                     //Se coloca el signo % para que el dato indicado se busque en cualquier parte del campo
                valorparametro = "%" + tbBuscar.Text.Trim() + "%";
                //valorparametro = tbBuscar.Text.Trim();
            }
            else //si el textbox está vacío
            {
                vtieneparametro = 0; //se indica que no se trabajará con parámetros
                valorparametro = ""; //Se vuelve vacío la variable del parámetro.
            }
            MostrarDatos(); //Se llama al método MostrarDatos

        }

        private void DGVDatos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //si se pulsa en el encabezado, RowIndex será menor que cero y no se hará nada
            if (!(e.RowIndex > -1))
            {
                return;
            }
            bAceptar_Click(sender, e); //Se ejecuta el método del botón Aceptar

        }

        private void MostrarDatos()
        {
            valorparametro = tbBuscar.Text.Trim();
            CNCliente objCliente = new CNCliente();
            if (objCliente.ObtenerCliente(valorparametro) != null)
            {
                DGVDatos.DataSource = objCliente.ObtenerCliente(valorparametro);
                DGVDatos.Columns[0].Width = 80; //IdCliente
                DGVDatos.Columns[1].Width = 200;
                DGVDatos.Columns[2].Width = 225;
                DGVDatos.Columns[3].Width = 100;
                DGVDatos.Columns[4].Width = 125;
                DGVDatos.Columns[5].Width = 125;
            }
            else
                MessageBox.Show("No se retorno ningun valor!");
            DGVDatos.Refresh(); //Se refresca el DataGripView

        }

    }
}
