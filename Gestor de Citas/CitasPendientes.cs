using CapaNegocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestor_de_Citas
{
    public partial class CitasPendientes : Form
    {
        public CitasPendientes()
        {
            InitializeComponent();
        }

        private void CitasPendientes_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        //Cargar citas Pendientes actual
        private void CargarDatos()
        {
            try
            {
                DataTable citas = CNCita.ObtenerCitasPorFechaYHora();

                dataGridView2.DataSource = null;
                dataGridView2.Rows.Clear();
                dataGridView2.Columns.Clear();

                // Ajustes generales
                dataGridView2.Width = 780;
                dataGridView2.Height = 450;
                dataGridView2.RowHeadersVisible = false;
                dataGridView2.AllowUserToOrderColumns = false;
                dataGridView2.AllowUserToResizeColumns = false;
                dataGridView2.AllowUserToResizeRows = false;

                // Estilos de bordes y líneas divisorias
                dataGridView2.CellBorderStyle = DataGridViewCellBorderStyle.Single;
                dataGridView2.GridColor = Color.LightGray;
                dataGridView2.EnableHeadersVisualStyles = false;
                dataGridView2.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                dataGridView2.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

                // Fuentes
                Font palatinoFont = new Font("Palatino Linotype", 10);
                Font palatinoHeaderFont = new Font("Palatino Linotype", 12, FontStyle.Bold);

                if (citas != null && citas.Rows.Count > 0)
                {
                    dataGridView2.DataSource = citas;

                    string[] encabezados = { "Cliente", "Teléfono", "Empleado", "Fecha", "Hora", "Duración", "Servicio" };

                    for (int i = 0; i < dataGridView2.Columns.Count && i < encabezados.Length; i++)
                    {
                        var column = dataGridView2.Columns[i];
                        column.HeaderText = encabezados[i];
                        column.DefaultCellStyle.Font = palatinoFont;
                        column.HeaderCell.Style.Font = palatinoHeaderFont;

                        // Ajuste de ancho
                        if (i == dataGridView2.Columns.Count - 1) // Última columna (Servicio)
                        {
                            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        }
                        else
                        {
                            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        }
                    }
                }
                else
                {
                    // Fuente para mensaje sin citas
                    Font palatinoMessageFont = new Font("Palatino Linotype", 12, FontStyle.Bold);

                    // Crear columna y ajustarla
                    DataGridViewTextBoxColumn mensajeCol = new DataGridViewTextBoxColumn();
                    mensajeCol.HeaderText = "Mensaje";
                    mensajeCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    mensajeCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    mensajeCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    mensajeCol.DefaultCellStyle.Font = palatinoMessageFont;
                    mensajeCol.HeaderCell.Style.Font = palatinoMessageFont;

                    dataGridView2.Columns.Add(mensajeCol);
                    dataGridView2.Rows.Add("No hay citas actualmente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void BarraTitulo_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
