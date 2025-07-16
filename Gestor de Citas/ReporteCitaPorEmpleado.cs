using CapaNegocios;
using System.Data;
using System.Windows.Forms;
using System;

namespace Gestor_de_Citas
{
    public partial class ReporteCitaPorEmpleado : Form
    {
        public ReporteCitaPorEmpleado()
        {
            InitializeComponent();
            cbEmpleado.DropDown += cbEmpleado_DropDown;
            cbEmpleado.SelectedIndexChanged += cbEmpleado_SelectedIndexChanged; // Manejar la selección
        }

        private void ReporteCitaPorEmpleado_Load(object sender, EventArgs e)
        {
            // No cargamos nada al inicio, el ComboBox está vacío
        }

        private void CargarEmpleados()
        {
            DataTable empleados = CNCita.CargarEmpleadosComboBox();

            if (empleados != null && empleados.Rows.Count > 0)
            {
                cbEmpleado.DataSource = empleados;
                cbEmpleado.DisplayMember = "Empleado";
                cbEmpleado.ValueMember = "Empleado";
            }
            else
            {
                MessageBox.Show("No se pudieron cargar los empleados.");
            }
        }

        private void Bbuscar_Click(object sender, EventArgs e)
        {
            string NombreEmpleado = cbEmpleado.Text;
            string FiltroFecha = cbFiltroFecha.Text;

            this.CitaPorEmpleadoTableAdapter.Fill(this.DataSetCitaPorEmpleado.CitaPorEmpleado, NombreEmpleado, FiltroFecha);
            this.reportViewer1.RefreshReport();
        }

        private void cbEmpleado_DropDown(object sender, EventArgs e)
        {
            if (cbEmpleado.DataSource == null)
            {
                CargarEmpleados();
                cbEmpleado.SelectedIndex = -1; // No seleccionar ningún elemento al desplegar
            }
        }

        private void cbEmpleado_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Aquí puedes manejar la selección de un elemento
            // Por ejemplo, puedes obtener el valor seleccionado:
            // string empleadoSeleccionado = cbEmpleado.SelectedValue?.ToString();
        }
    }
}