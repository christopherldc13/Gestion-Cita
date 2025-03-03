using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocios;
using System.Drawing.Drawing2D;
using System.Windows.Forms.DataVisualization.Charting;

namespace Gestor_de_Citas
{
    public partial class FMenu : Form
    {
        public FMenu()
        {
            InitializeComponent();
            CargarDatos(); // Carga inicial
            ConfigurarTemporizador(); // Configura el temporizador
            string usuarioFormateado = char.ToUpper(Program.usuario[0]) + Program.usuario.Substring(1).ToLower();
            toolStripStatusLabel4.Text = "Usuario: " + usuarioFormateado;
        }

        private void porBarberoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //FReporteCitaEmpleado fReporteEmpleado = new FReporteCitaEmpleado();
           // fReporteEmpleado.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            statusStrip1.Items[1].Text = "Fecha/Hora: " +DateTime.Now.ToString();
        }

        private void FMenu_Load(object sender, EventArgs e)
        {
            CargarGanancias();
            //CargarLogo();
        }

        private void salidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.Close();
        }

        private void FMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Preguntar al usuario si realmente quiere salir
            if (MessageBox.Show("Esto le hará salir de la aplicación. ¿Seguro que desea hacerlo?",
                "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                e.Cancel = false; // Permite el cierre del formulario
                this.Hide(); // Oculta el formulario (si lo deseas)
                Login login = new Login();
                login.ShowDialog(); // Muestra el formulario de Login
            }
            else
            {
                e.Cancel = true; // Cancela el cierre del formulario
            }
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MantCliente formulario = new MantCliente();
            formulario.ShowDialog();
        }

        private void empleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MantEmpleado formulario = new MantEmpleado();
            formulario.ShowDialog();
        }

        private void citaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MantCita formulario = new MantCita();
            formulario.ShowDialog();
        }

        private void registrarEmpresaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MantEmpresa mantEmpresa = new MantEmpresa();
            mantEmpresa.ShowDialog();
        }

        private void usuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MantUsuario formulario = new MantUsuario();
            formulario.ShowDialog();
        }

        private void pagoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MantPago formulario = new MantPago();
            formulario.ShowDialog();
        }

        private void datosGeneralesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //FReporteClientesGenerales fReporteClientesGenerales = new FReporteClientesGenerales();
            //fReporteClientesGenerales.ShowDialog();
        }

        private void datosGeneralesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           // FReporteEmpleadoGeneral fReporteEmpleadoGeneral = new /FReporteEmpleadoGeneral();
           // fReporteEmpleadoGeneral.ShowDialog();
        }

        private void porFechaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Form1 form1 = new Form1();
           // form1.ShowDialog();
        }

        private void porClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //FReporteCitaCliente fReporteCitaCliente = new FReporteCitaCliente();
           // fReporteCitaCliente.ShowDialog();
        }

        private void porFechaToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            //FReportePagoFecha fPagoFech = new FReportePagoFecha();
           // fPagoFech.ShowDialog();
        }

        private void porNombreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //FReportePagoCliente fReportePagoCliente = new FReportePagoCliente();
            //fReportePagoCliente.ShowDialog();
        }

        private void porEstadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //FReporteBarberoEstado fReporteBarberoEstado = new FReporteBarberoEstado();
            //fReporteBarberoEstado.ShowDialog();
        }

        private void consultarClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultasCliente consultasCliente = new ConsultasCliente();
            consultasCliente.ShowDialog();
        }

        private void consultarDeDatosEmpresaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FBuscarEmpresa formulario = new FBuscarEmpresa();
            formulario.ShowDialog();
        }

        private void consultarBarberosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultasEmpleado consultasEmpleado = new ConsultasEmpleado();
            consultasEmpleado.ShowDialog();
        
        }

        private void pruebaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //FReportePagoFecha formulario = new FReportePagoFecha();
            //formulario.ShowDialog();
        }

        private void pruebaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FAcercaDe fAcerca = new FAcercaDe();
            fAcerca.ShowDialog();
        }

        private void porSuEstadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //fReporteClienteEstado.ShowDialog();
        }

        private void porEstadoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           // FReportePagoEstado fReportePagoEstado = new FReportePagoEstado();
           // fReportePagoEstado.ShowDialog();
        }

        private void consultarCitasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FConsultasCita fConsultasCita = new FConsultasCita();
            fConsultasCita.ShowDialog();
        }

        private void consultarPagosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultaPago consultaPago = new ConsultaPago();
            consultaPago.ShowDialog();
        }

        private void servicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MantServicio mantServicio = new MantServicio();
            mantServicio.ShowDialog();
        }

        private void consultaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultaServicio consultaServicio = new ConsultaServicio();
            consultaServicio.ShowDialog();
        }

        private void gToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Form1 form2 = new Form1();
            //form2.ShowDialog();
        }

        private void CargarDatos()
        {
            try
            {
                // Llamamos al método de la capa de negocios para obtener los datos sin parámetros
                DataTable citas = CNCita.ObtenerCitasPorFechaYHora();

                if (citas != null && citas.Rows.Count > 0)
                {
                    // Limpia el DataGridView antes de asignar nuevos datos
                    dataGridView2.DataSource = null;
                    dataGridView2.Rows.Clear();
                    dataGridView2.Columns.Clear();
                    dataGridView2.AllowUserToOrderColumns = false;
                    dataGridView2.AllowUserToResizeColumns = false;
                    dataGridView2.AllowUserToResizeRows = false;

                    // Asigna los datos obtenidos al DataGridView
                    dataGridView2.DataSource = citas;

                    // Configuración de columnas: se ajustan automáticamente para evitar barras de desplazamiento
                    dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    // Opcionalmente puedes ajustar las columnas específicas si prefieres un tamaño manual:
                    dataGridView2.Columns[0].HeaderText = "Cliente";
                    dataGridView2.Columns[1].HeaderText = "Teléfono";
                    dataGridView2.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView2.Columns[2].HeaderText = "Empleado";
                    dataGridView2.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView2.Columns[3].HeaderText = "Fecha";
                    dataGridView2.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView2.Columns[4].HeaderText = "Hora";
                    dataGridView2.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView2.Columns[5].HeaderText = "Servicio";
                }
                else
                {
                    dataGridView2.DataSource = null;
                    dataGridView2.Rows.Clear();
                    dataGridView2.Columns.Clear();
                    dataGridView2.Columns.Add("Mensaje", "Mensaje");
                    dataGridView2.Rows.Add("No hay citas actualmente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void ConfigurarTemporizador()
        {
            Timer temporizador = new Timer
            {
                Interval = 5000 
            };
            temporizador.Tick += (s, e) => CargarDatos(); // Recarga los datos
            temporizador.Tick += (s, e) => CargarGanancias(); //Actualiza el grafico
            temporizador.Start();
        }

        private void CargarGananciaDiaria()
        {
            decimal ganancia = CNCita.ObtenerGananciaDiaria();
            //label2.Text = "Ganancia del día: $" + ganancia.ToString("N2");
        }

        private void CargarGananciasSemanales()
        {
            decimal ganancia = CNCita.ObtenerGananciasSemanales();
            //label3.Text = "Ganancia de la semana: $" + ganancia.ToString("N2");
        }

        private void CargarGananciasMensuales()
        {
            decimal ganancia = CNCita.ObtenerGananciasMensuales();
            //label4.Text = "Ganancia del mes: $" + ganancia.ToString("N2");
        }

        private void actualizarGananciasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Llamada para actualizar las ganancias al seleccionar "Actualizar Ganancias" desde el menú
            CargarGanancias();
        }

        private void CargarGanancias()
        {
            // Obtener las ganancias de las funciones que ya tienes implementadas
            decimal gananciaDiaria = CNCita.ObtenerGananciaDiaria();
            decimal gananciaSemanal = CNCita.ObtenerGananciasSemanales();
            decimal gananciaMensual = CNCita.ObtenerGananciasMensuales();

            // Llamar al método para actualizar el gráfico de pastel
            ActualizarGraficoPastel(gananciaDiaria, gananciaSemanal, gananciaMensual);
        }

        // Método para actualizar el gráfico de pastel con las ganancias
        private void ActualizarGraficoPastel(decimal gananciaDiaria, decimal gananciaSemanal, decimal gananciaMensual)
        {
            chart1.Series.Clear();
            chart1.Titles.Clear();

            // Asegúrate de mantener el borde exterior del gráfico
            Series serie = new Series
            {
                Name = "Ganancias",
                ChartType = SeriesChartType.Pie,
                IsValueShownAsLabel = true,
                LabelForeColor = System.Drawing.Color.Black,
                Font = new System.Drawing.Font("", 10),
                BorderWidth = 2,  // Mantener siempre el borde exterior del círculo
                BorderColor = System.Drawing.Color.Transparent // Borde negro permanente
            };

            Dictionary<string, decimal> ganancias = new Dictionary<string, decimal>();

            if (gananciaDiaria > 0) ganancias.Add("Diaria", gananciaDiaria);
            if (gananciaSemanal > 0) ganancias.Add("Semanal", gananciaSemanal);
            if (gananciaMensual > 0) ganancias.Add("Mensual", gananciaMensual);

            Dictionary<string, System.Drawing.Color> colores = new Dictionary<string, System.Drawing.Color>
            {
                { "Diaria", System.Drawing.Color.FromArgb(120, 190, 255) },
                { "Semanal", System.Drawing.Color.FromArgb(50, 150, 255) },
                { "Mensual", System.Drawing.Color.FromArgb(20, 90, 180) }
            };

            foreach (var item in ganancias)
            {
                DataPoint punto = new DataPoint();
                punto.SetValueXY(item.Key, item.Value);
                punto.Color = colores[item.Key];
                punto.Label = item.Key + "\n" + item.Value.ToString("C2");
                punto.CustomProperties = "PieLabelStyle=Inside";

                serie.Points.Add(punto);
            }

            // Si no hay ganancias, agregar un punto "Sin datos"
            if (serie.Points.Count == 0)
            {
                serie.Points.AddXY("Sin datos", 1);
                serie.Points[0].Color = System.Drawing.Color.Gray;
                serie.Points[0].Label = "Sin datos";
            }

            // No eliminar el borde exterior, pero eliminar las divisiones internas si hay solo un dato
            if (serie.Points.Count == 1)
            {
                // Si hay solo una ganancia, asegúrate de que no haya divisiones internas
                serie.Points[0].BorderWidth = 0;
            }
            else
            {
                // Si hay más de un dato, mantén el borde entre los segmentos
                foreach (var punto in serie.Points)
                {
                    punto.BorderWidth = 2;
                }
            }

            chart1.Series.Add(serie);

            // Configurar apariencia
            chart1.ChartAreas[0].BackColor = System.Drawing.Color.Transparent;

            // Centrar la leyenda en el gráfico
            chart1.Legends[0].Docking = Docking.Bottom;
            chart1.Legends[0].Alignment = StringAlignment.Center; // Centra el texto de la leyenda
            chart1.Legends[0].BackColor = System.Drawing.Color.Transparent;

            // Agregar título
            Title titulo = new Title
            {
                Text = "Distribución de Ganancias",
                Font = new System.Drawing.Font("Arial", 14, System.Drawing.FontStyle.Bold),
                ForeColor = System.Drawing.Color.Black
            };
            chart1.Titles.Add(titulo);
        }

        /*private void CargarLogo()
        {
            string rutaImagen = CNEmpresa.ObtenerRutaLogo();

            if (!string.IsNullOrEmpty(rutaImagen) && System.IO.File.Exists(rutaImagen))
            {
                pictureBox1.Image = Image.FromFile(rutaImagen);
            }
            else
            {
                MessageBox.Show("No se encontró la imagen en la ruta guardada.");
            }
        }*/
    }
}
