using CapaNegocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestor_de_Citas
{
    public partial class FBuscarDisponibilidad: Form
    {
        public int indice = 0, vtieneparametro = 0;
        public string valorparametro = "";
        public FBuscarDisponibilidad()
        {
            InitializeComponent();
        }

        private void bUltimo_Click(object sender, EventArgs e)
        {

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
                Program.modificar = true;
                Program.vidDisponibilidad = Convert.ToInt32(DGVDatos.CurrentRow.Cells[0].Value);
            }
            Close();
        }

        private void FBuscarDisponibilidad_Load(object sender, EventArgs e)
        {
            valorparametro = "";
            vtieneparametro = 0;
            Program.vidDisponibilidad = 0;
            MostrarDatos();
            tbBuscar.Focus(); //El TextBox Buscar recibe el cursor
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

        private void DGVDatos_CurrentCellChanged(object sender, EventArgs e)
        {
            if (DGVDatos.CurrentRow != null)
                indice = DGVDatos.CurrentRow.Index;
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

        }

        private void MostrarDatos()
        {
            valorparametro = tbBuscar.Text.Trim();
            CNDisponibilidad objDisponibilidad = new CNDisponibilidad();
            if (objDisponibilidad.ObtenerDisponibilidad(valorparametro) != null)
            {
                DGVDatos.DataSource = objDisponibilidad.ObtenerDisponibilidad(valorparametro);
                DGVDatos.Columns[0].Width = 100; //IdServicio
            }
            else
                MessageBox.Show("No se retorno ningun valor!");
            DGVDatos.Refresh(); //Se refresca el DataGripView

        }
    }

}
