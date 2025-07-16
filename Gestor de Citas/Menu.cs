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
using Microsoft.VisualBasic;
using System.Windows.Forms.DataVisualization.Charting;

namespace Gestor_de_Citas
{
    public partial class FMenu : Form
    {
        public FMenu()
        {
            InitializeComponent();
            CargarDatos(); 
            ConfigurarTemporizador(); // Configura el temporizador
            toolStripStatusLabel4.Text = "Usuario: " + Program.usuario;
        }

        //Muestra la fecha y hora actual
        private void timer1_Tick(object sender, EventArgs e)
        {
            statusStrip1.Items[1].Text = "Fecha/Hora: " +DateTime.Now.ToString();
        }

        // Carga datos iniciales y muestra el mensaje de copyright al abrir el menú.
        private void FMenu_Load(object sender, EventArgs e)
        {
            CargarGanancias();
            CargarCitasPendientesRealizadas();
            toolStripStatusLabel1.Text = $"Copyright {Program.copyright} {DateTime.Now.Year}, La Vega Rep. Dom.";

            // Llamar al método de la capa de negocios para actualizar el estado de las citas
            CNCita.ActualizarEstadoCitaNoRealizada();

        }

        private void CargarCitasPendientesRealizadas()
        {
            int citasHoy = CNCita.ObtenerCitasRealizadasHoy();

            // Configurar el texto del Label
            label3.Text = "Citas realizadas hoy: " + citasHoy.ToString();
            label3.Font = new Font("Palatino Linotype", 15, FontStyle.Bold);
            label3.ForeColor = Color.Black; // Texto en negro
            label3.BackColor = Color.Transparent; // Fondo transparente
            label3.TextAlign = ContentAlignment.MiddleCenter; // Alineación centrada
            label3.AutoSize = false; // Desactivar autoajuste de tamaño
            label3.Size = new Size(250, 40); // Ajustar el tamaño del Label


            int citaspendienteshoy = CNCita.ObtenerCitasPendientesHoy();

            label2.Text = "Citas Pendiente hoy: " + citaspendienteshoy.ToString();
            // Aplicar estilos al Label
            label2.Font = new Font("Palatino Linotype", 15, FontStyle.Bold); // Fuente más grande y en negrita
            label2.ForeColor = Color.Black; // Texto en negro
            label2.BackColor = Color.Transparent; // Fondo transparente
            label2.TextAlign = ContentAlignment.MiddleCenter; // Alineación centrada
            label2.AutoSize = false; // Desactivar autoajuste de tamaño
            label2.Size = new Size(250, 40); // Ajustar el tamaño del Label
        }

        private void salidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Muestra un mensaje de confirmación al intentar cerrar el formulario, y si se confirma, oculta el formulario y abre el de inicio de sesión.
        private void FMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Esto le hará salir de la aplicación. ¿Seguro que desea hacerlo?",
                "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                e.Cancel = false;
                this.Hide(); // Oculta el formulario
                Login login = new Login();
                login.ShowDialog(); 
            }
            else
            {
                e.Cancel = true; 
            }
        }

        //Abre el Formulario de Registro de Clientes
        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MantCliente formulario = new MantCliente();
            formulario.ShowDialog();
        }

        private void citaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MantCita formulario = new MantCita();
            formulario.ShowDialog();
        }

        private void pagoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MantPago formulario = new MantPago();
            formulario.ShowDialog();
        }
        
        
        private void datosGeneralesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MServicio mServicio = new MServicio();
            mServicio.ShowDialog();
        }


        private void porFechaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReporteCitaPorEmpleado reporteCitaPorEmpleado = new ReporteCitaPorEmpleado();
            reporteCitaPorEmpleado.ShowDialog();
        }

        //Abre el Formulario de Consultas de Clientes
        private void consultarClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultasCliente consultasCliente = new ConsultasCliente();
            consultasCliente.ShowDialog();
        }

        //Abre el formulario de Consulta de Empresa
        private void consultarDeDatosEmpresaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FBuscarEmpresa formulario = new FBuscarEmpresa();
            formulario.ShowDialog();
        }

        private void porEstadoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ReportePagoEstado reportePagoEstado = new ReportePagoEstado();
            reportePagoEstado.ShowDialog();
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
            if (Program.Rol == "SuperAdmin" || Program.Rol == "Admin")
            {
                MantServicio mantServicio = new MantServicio();
                mantServicio.ShowDialog();
            }
            else
            {
                MessageBox.Show("No tienes suficientes Privilegios");
            }
        }

        private void consultaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultaServicio consultaServicio = new ConsultaServicio();
            consultaServicio.ShowDialog();
        }

        private void CargarDatos()
        {
            try
            {
                DataTable citas = CNCita.ObtenerCitasPorFechaYHora();

                if (citas != null && citas.Rows.Count > 0)
                {
                    dataGridView2.DataSource = null;
                    dataGridView2.Rows.Clear();
                    dataGridView2.Columns.Clear();
                    dataGridView2.AllowUserToOrderColumns = false;
                    dataGridView2.AllowUserToResizeColumns = false;
                    dataGridView2.AllowUserToResizeRows = false;
                    dataGridView2.DataSource = citas;

                    // Configuración de columnas: se ajustan automáticamente para evitar barras de desplazamiento
                    dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    // Fuente Palatino Linotype para el contenido de las celdas
                    Font palatinoFont = new Font("Palatino Linotype", 10); // Puedes ajustar el tamaño de la fuente aquí

                    // Fuente Palatino Linotype para los encabezados de las columnas
                    Font palatinoHeaderFont = new Font("Palatino Linotype", 12, FontStyle.Bold); // Puedes ajustar el tamaño y el estilo aquí

                    // Aplicar la fuente a cada columna
                    foreach (DataGridViewColumn column in dataGridView2.Columns)
                    {
                        column.DefaultCellStyle.Font = palatinoFont;
                        column.HeaderCell.Style.Font = palatinoHeaderFont;

                        // Configuración de encabezados de columnas
                        if (column.Index == 0) column.HeaderText = "Cliente";
                        else if (column.Index == 1)
                        {
                            column.HeaderText = "Teléfono";
                            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        }
                        else if (column.Index == 2)
                        {
                            column.HeaderText = "Empleado";
                            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        }
                        else if (column.Index == 3)
                        {
                            column.HeaderText = "Fecha";
                            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        }
                        else if (column.Index == 4)
                        {
                            column.HeaderText = "Hora";
                            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        }
                        else if (column.Index == 5)
                        {
                            column.HeaderText = "Duración";
                            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        }
                        else if (column.Index == 6) column.HeaderText = "Servicio";
                    }
                }
                else
                {
                    dataGridView2.DataSource = null;
                    dataGridView2.Rows.Clear();
                    dataGridView2.Columns.Clear();

                    // Fuente Palatino Linotype para la celda de mensaje
                    Font palatinoMessageFont = new Font("Palatino Linotype", 12);

                    dataGridView2.Columns.Add("Mensaje", "Mensaje");
                    dataGridView2.Columns[0].DefaultCellStyle.Font = palatinoMessageFont;
                    dataGridView2.Rows.Add("No hay citas actualmente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        //private void CargarDatos()
        //{
        //    try
        //    {
        //        DataTable citas = CNCita.ObtenerCitasPorFechaYHora();

        //        dataGridView2.DataSource = null;
        //        dataGridView2.Rows.Clear();
        //        dataGridView2.Columns.Clear();
        //        dataGridView2.AllowUserToOrderColumns = false;
        //        dataGridView2.AllowUserToResizeColumns = false;
        //        dataGridView2.AllowUserToResizeRows = false;;
        //        dataGridView2.ReadOnly = true; // Evita que editen las celdas

        //        if (citas != null && citas.Rows.Count > 0)
        //        {
        //            dataGridView2.DataSource = citas;
        //            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

        //            // Asegurar que las columnas existen antes de acceder a ellas
        //            dataGridView2.Refresh();

        //            if (dataGridView2.Columns.Count > 0)
        //            {
        //                // Ancho total = 690 px
        //                int[] widths = { 110, 100, 110, 90, 75, 75, 70 };
        //                string[] headers = { "Cliente", "Teléfono", "Empleado", "Fecha", "Hora", "Duración", "Servicio" };

        //                for (int i = 0; i < dataGridView2.Columns.Count && i < widths.Length; i++)
        //                {
        //                    dataGridView2.Columns[i].HeaderText = headers[i];
        //                    dataGridView2.Columns[i].Width = widths[i];
        //                }
        //            }
        //        }
        //        else
        //        {
        //            // Si no hay datos, agregar una columna con mensaje
        //            dataGridView2.Columns.Add("Mensaje", "Mensaje");
        //            dataGridView2.Rows.Add("No hay citas actualmente.");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error: " + ex.Message);
        //    }
        //}

        private void ConfigurarTemporizador()
        {
            Timer temporizador = new Timer
            {
                Interval = 5000 
            };
            temporizador.Tick += (s, e) => CargarDatos(); // Recarga los datos
            temporizador.Tick += (s, e) => CargarGanancias(); //Actualiza el grafico
            temporizador.Tick += (s, e) => CargarCitasPendientesRealizadas(); 
            temporizador.Start();
        }

        private void actualizarGananciasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CargarGanancias();
        }

        private void CargarGanancias()
        {
            // Obtener las ganancias de las funciones que ya tienes implementadas
            decimal gananciaDiaria = CNCita.ObtenerGananciaDiaria();
            decimal gananciaSemanal = CNCita.ObtenerGananciasSemanales();
            decimal gananciaMensual = CNCita.ObtenerGananciasMensuales();

            // Llamar al método para actualizar el gráfico de pastel
            ActualizarGraficoColumnas(gananciaDiaria, gananciaSemanal, gananciaMensual);
        }

        //private void ActualizarGraficoColumnas(decimal gananciaDiaria, decimal gananciaSemanal, decimal gananciaMensual)
        //{
        //    chart1.Series.Clear();
        //    chart1.Titles.Clear();
        //    chart1.Legends.Clear();

        //    // Crear una serie única para mostrar las columnas de ganancias
        //    Series serie = new Series
        //    {
        //        ChartType = SeriesChartType.Column,
        //        IsValueShownAsLabel = true,
        //        LabelForeColor = System.Drawing.Color.Black,
        //        Font = new System.Drawing.Font("Palatino Linotype", 11, System.Drawing.FontStyle.Bold),
        //        BorderWidth = 2,
        //        IsVisibleInLegend = false
        //    };

        //    // Crear un diccionario de las ganancias
        //    Dictionary<string, decimal> ganancias = new Dictionary<string, decimal>();

        //    if (gananciaDiaria > 0) ganancias.Add("Diaria", gananciaDiaria);
        //    if (gananciaSemanal > 0) ganancias.Add("Semanal", gananciaSemanal);
        //    if (gananciaMensual > 0) ganancias.Add("Mensual", gananciaMensual);

        //    // Definir los colores para cada tipo de ganancia
        //    Dictionary<string, System.Drawing.Color> colores = new Dictionary<string, System.Drawing.Color>
        //    {
        //        { "Diaria", System.Drawing.Color.FromArgb(120, 190, 255) },
        //        { "Semanal", System.Drawing.Color.FromArgb(50, 150, 255) },
        //        { "Mensual", System.Drawing.Color.FromArgb(20, 90, 180) }
        //    };

        //    // Variable para almacenar el valor máximo
        //    decimal maxGanancia = 0;

        //    // Agregar las columnas a la serie
        //    foreach (var item in ganancias)
        //    {
        //        // Crear un punto para cada ganancia (Diaria, Semanal, Mensual)
        //        DataPoint punto = new DataPoint();
        //        punto.SetValueXY(item.Key, (double)item.Value);
        //        punto.Color = colores[item.Key];
        //        // Cambiar el formato de la etiqueta para incluir "RD$"
        //        punto.Label = item.Key + "\n" + "RD$ " + item.Value.ToString("N2"); // Formato con dos decimales

        //        // Agregar el punto a la serie
        //        serie.Points.Add(punto);

        //        // Actualizar el valor máximo
        //        if (item.Value > maxGanancia)
        //        {
        //            maxGanancia = item.Value;
        //        }
        //    }

        //    // Si no hay ganancias, agregar un punto "Sin datos"
        //    if (serie.Points.Count == 0)
        //    {
        //        serie.Points.AddXY("Sin datos", 1);
        //        serie.Points[0].Color = System.Drawing.Color.Gray;
        //        serie.Points[0].Label = "Sin datos";
        //    }

        //    // Agregar la serie al gráfico
        //    chart1.Series.Add(serie);

        //    // Configurar apariencia del gráfico
        //    chart1.ChartAreas[0].BackColor = System.Drawing.Color.Transparent;
        //    chart1.ChartAreas[0].AxisX.Title = "Período";
        //    chart1.ChartAreas[0].AxisY.Title = "Ganancia";
        //    chart1.ChartAreas[0].AxisX.LabelStyle.Font = new System.Drawing.Font("Palatino Linotype", 11);
        //    chart1.ChartAreas[0].AxisY.LabelStyle.Font = new System.Drawing.Font("Palatino Linotype", 11);

        //    // Cambiar el formato de las etiquetas del eje Y para incluir "RD$"
        //    chart1.ChartAreas[0].AxisY.LabelStyle.Format = "RD$ #,##0.00"; // Formato con símbolo de peso dominicano

        //    // Ajustar el rango del eje Y para que se adapte al valor máximo de ganancia
        //    chart1.ChartAreas[0].AxisY.LabelStyle.Font = new System.Drawing.Font("Palatino Linotype", 8);
        //    chart1.ChartAreas[0].AxisY.Minimum = 0;
        //    chart1.ChartAreas[0].AxisY.Maximum = (double)(maxGanancia + (maxGanancia * 0.2m));

        //    // Ocultar las líneas de la cuadrícula
        //    chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
        //    chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;

        //    // Agregar título al gráfico
        //    Title titulo = new Title
        //    {
        //        Text = "Distribución de Ganancias",
        //        Font = new System.Drawing.Font("Palatino Linotype", 15, System.Drawing.FontStyle.Bold),
        //        ForeColor = System.Drawing.Color.Black,
        //        Alignment = ContentAlignment.TopCenter // Centrar el título
        //    };
        //    chart1.Titles.Add(titulo);
        //}
        private void ActualizarGraficoColumnas(decimal gananciaDiaria, decimal gananciaSemanal, decimal gananciaMensual)
        {
            chart1.Series.Clear();
            chart1.Titles.Clear();
            chart1.Legends.Clear();

            Series serie = new Series
            {
                ChartType = SeriesChartType.Column,
                IsValueShownAsLabel = true,
                LabelForeColor = System.Drawing.Color.Black,
                Font = new System.Drawing.Font("Palatino Linotype", 11, System.Drawing.FontStyle.Bold),
                BorderWidth = 2,
                IsVisibleInLegend = false
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

            decimal maxGanancia = 0;

            foreach (var item in ganancias)
            {
                DataPoint punto = new DataPoint();
                punto.SetValueXY(item.Key, (double)item.Value);
                punto.Color = colores[item.Key];
                punto.Label = item.Key + "\n" + "RD$ " + item.Value.ToString("N2");

                serie.Points.Add(punto);

                if (item.Value > maxGanancia)
                {
                    maxGanancia = item.Value;
                }
            }

            if (serie.Points.Count == 0)
            {
                serie.Points.AddXY("Sin datos", 1);
                serie.Points[0].Color = System.Drawing.Color.Gray;
                serie.Points[0].Label = "Sin datos";
            }

            chart1.Series.Add(serie);

            chart1.ChartAreas[0].BackColor = System.Drawing.Color.Transparent;
            chart1.ChartAreas[0].AxisX.Title = "Período";
            chart1.ChartAreas[0].AxisY.Title = "Ganancia";
            chart1.ChartAreas[0].AxisX.LabelStyle.Font = new System.Drawing.Font("Palatino Linotype", 11);
            chart1.ChartAreas[0].AxisY.LabelStyle.Font = new System.Drawing.Font("Palatino Linotype", 11);
            chart1.ChartAreas[0].AxisY.LabelStyle.Format = "RD$ #,##0.00";
            chart1.ChartAreas[0].AxisY.LabelStyle.Font = new System.Drawing.Font("Palatino Linotype", 8);
            chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;

            if (serie.Points.Count > 0 && maxGanancia > 0)
            {
                chart1.ChartAreas[0].AxisY.Minimum = 0;
                chart1.ChartAreas[0].AxisY.Maximum = (double)(maxGanancia + (maxGanancia * 0.2m));
            }
            else
            {
                // Si no hay datos o maxGanancia es 0, establece un rango mínimo para el eje Y
                chart1.ChartAreas[0].AxisY.Minimum = 0;
                chart1.ChartAreas[0].AxisY.Maximum = 10; // Puedes ajustar este valor mínimo según tus necesidades
            }

            Title titulo = new Title
            {
                Text = "Distribución de Ganancias",
                Font = new System.Drawing.Font("Palatino Linotype", 15, System.Drawing.FontStyle.Bold),
                ForeColor = System.Drawing.Color.Black,
                Alignment = ContentAlignment.TopCenter
            };
            chart1.Titles.Add(titulo);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Acerca acerca = new Acerca();
            acerca.ShowDialog();
        }

        //Abre el formulario acerca de 
        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Acerca acerca = new Acerca();
            acerca.ShowDialog();
        }

        private void seguridadToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (Program.Rol == "SuperAdmin")
            {
                MantEmpresa mantEmpresa = new MantEmpresa();
                mantEmpresa.ShowDialog();
            }
            else
            {
                //MessageBox.Show("No tienes suficientes permisos") MessageBoxIcon.Warning;
                MessageBox.Show($"No tienes sufiente permiso, INICIA SESION CON UN USUARIO CON ROL ADMINISTRATIVO",
                                    "Acceso bloqueado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void consultarEmpleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultasEmpleado consultasEmpleado = new ConsultasEmpleado();
            consultasEmpleado.ShowDialog();
        }

        private void toolStripMenuItem2_Click_1(object sender, EventArgs e)
        {
            MantCliente mantCliente = new MantCliente();
            mantCliente.ShowDialog();
        }

        //Variables de acceso temporal
        private int intentosFallidos = 0;
        private DateTime tiempoBloqueo;
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            // Verificar si el usuario está bloqueado
            if (intentosFallidos >= 3)
            {
                TimeSpan tiempoRestante = tiempoBloqueo - DateTime.Now;
                if (tiempoRestante.TotalSeconds > 0)
                {
                    MessageBox.Show($"Acceso bloqueado. Vuelve a intentar en {tiempoRestante.Minutes}:{tiempoRestante.Seconds} minutos.",
                                    "Acceso bloqueado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    intentosFallidos = 0;
                }
            }

            // Verificar si el usuario actual tiene permisos
            if (Program.Rol == "SuperAdmin" || Program.Rol == "Admin")
            {
                ManteEmpleado formulario = new ManteEmpleado();
                formulario.ShowDialog();
            }
            else
            {
                while (intentosFallidos < 3)
                {
                    string usuario = Microsoft.VisualBasic.Interaction.InputBox("Usuario:", "Requiere privilegios", "");
                    if (string.IsNullOrEmpty(usuario)) return; // Salir si el usuario cancela

                    string clave = Microsoft.VisualBasic.Interaction.InputBox("Contraseña:", "Requiere privilegios", "", -1, -1);
                    if (string.IsNullOrEmpty(clave)) return; // Salir si el usuario cancela

                    // Verificar credenciales
                    CNUsuario cnUsuario = new CNUsuario();
                    (string mensaje, string nuevoRol) = cnUsuario.AutenticarUsuario(usuario, clave);

                    Console.WriteLine($"Intento de autenticación - Usuario: {usuario}, Mensaje: {mensaje}, Rol: '{nuevoRol}'");

                    if (mensaje == "Autenticación exitosa" && (nuevoRol.Trim() == "SuperAdmin" || nuevoRol.Trim() == "Admin"))
                    {
                        intentosFallidos = 0; // Resetear intentos fallidos si el usuario es válido
                        ManteEmpleado formulario = new ManteEmpleado();
                        formulario.ShowDialog();
                        return;
                    }
                    else
                    {
                        intentosFallidos++;  // Aumentar contador de intentos fallidos

                        if (intentosFallidos >= 3)
                        {
                            tiempoBloqueo = DateTime.Now.AddMinutes(2);
                            MessageBox.Show("Has superado el número máximo de intentos. Estás bloqueado durante 2 minutos.",
                                            "Bloqueo por seguridad", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        else
                        {
                            MessageBox.Show("Acceso denegado. Usuario sin privilegios o credenciales incorrectas.",
                                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        //Variables de Acesso Temporal
        private int intentosFallidosServicio = 0;
        private DateTime tiempoBloqueoServicio;

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            if (intentosFallidosServicio >= 3)
            {
                TimeSpan tiempoRestante = tiempoBloqueoServicio - DateTime.Now;
                if (tiempoRestante.TotalSeconds > 0)
                {
                    MessageBox.Show($"Acceso bloqueado. Vuelve a intentar en {tiempoRestante.Minutes}:{tiempoRestante.Seconds} minutos.",
                                    "Acceso bloqueado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    intentosFallidosServicio = 0;
                }
            }

            // Verificar si el usuario actual tiene permisos
            if (Program.Rol == "SuperAdmin" || Program.Rol == "Admin")
            {
                MantServicio mantServicio = new MantServicio();
                mantServicio.ShowDialog();
            }
            else
            {
                while (intentosFallidosServicio < 3)
                {
                    string usuario = Microsoft.VisualBasic.Interaction.InputBox("Usuario:", "Requiere privilegios", "");
                    if (string.IsNullOrEmpty(usuario)) return; // Salir si el usuario cancela

                    string clave = Microsoft.VisualBasic.Interaction.InputBox("Contraseña:", "Requiere privilegios", "", -1, -1);
                    if (string.IsNullOrEmpty(clave)) return; // Salir si el usuario cancela

                    // Verificar credenciales
                    CNUsuario cnUsuario = new CNUsuario();
                    (string mensaje, string nuevoRol) = cnUsuario.AutenticarUsuario(usuario, clave);

                    Console.WriteLine($"Intento de autenticación - Usuario: {usuario}, Mensaje: {mensaje}, Rol: '{nuevoRol}'");

                    if (mensaje == "Autenticación exitosa" && (nuevoRol.Trim() == "SuperAdmin" || nuevoRol.Trim() == "Admin"))
                    {
                        intentosFallidosServicio = 0; // Resetear intentos fallidos si el usuario es válido
                        MantServicio formulario = new MantServicio();
                        formulario.ShowDialog();
                        return;
                    }
                    else
                    {
                        intentosFallidosServicio++;  // Aumentar contador de intentos fallidos

                        if (intentosFallidosServicio >= 3)
                        {
                            tiempoBloqueoUsuario = DateTime.Now.AddMinutes(2);
                            MessageBox.Show("Has superado el número máximo de intentos. Estás bloqueado durante 2 minutos.",
                                            "Bloqueo por seguridad", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        else
                        {
                            MessageBox.Show("Acceso denegado. Usuario sin privilegios o credenciales incorrectas.",
                                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        //Variables de acceso temporal
        private int intentosFallidosUsuario = 0;
        private DateTime tiempoBloqueoUsuario;

        private void toolStripMenuUsuario_Click(object sender, EventArgs e)
        {
            if (intentosFallidosUsuario >= 3)
            {
                TimeSpan tiempoRestante = tiempoBloqueoUsuario - DateTime.Now;
                if (tiempoRestante.TotalSeconds > 0)
                {
                    MessageBox.Show($"Acceso bloqueado. Vuelve a intentar en {tiempoRestante.Minutes}:{tiempoRestante.Seconds} minutos.",
                                    "Acceso bloqueado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    intentosFallidos = 0;
                }
            }

            // Verificar si el usuario actual tiene permisos
            if (Program.Rol == "SuperAdmin" || Program.Rol == "Admin")
            {
                MantUsuario mantUsuario = new MantUsuario();
                mantUsuario.ShowDialog();
            }
            else
            {
                while (intentosFallidosUsuario < 3)
                {
                    string usuario = Microsoft.VisualBasic.Interaction.InputBox("Usuario:", "Requiere privilegios", "");
                    if (string.IsNullOrEmpty(usuario)) return; // Salir si el usuario cancela

                    string clave = Microsoft.VisualBasic.Interaction.InputBox("Contraseña:", "Requiere privilegios", "", -1, -1);
                    if (string.IsNullOrEmpty(clave)) return; // Salir si el usuario cancela

                    // Verificar credenciales
                    CNUsuario cnUsuario = new CNUsuario();
                    (string mensaje, string nuevoRol) = cnUsuario.AutenticarUsuario(usuario, clave);

                    Console.WriteLine($"Intento de autenticación - Usuario: {usuario}, Mensaje: {mensaje}, Rol: '{nuevoRol}'");

                    if (mensaje == "Autenticación exitosa" && (nuevoRol.Trim() == "SuperAdmin" || nuevoRol.Trim() == "Admin"))
                    {
                        intentosFallidosUsuario = 0; // Resetear intentos fallidos si el usuario es válido
                        MantUsuario formulario = new MantUsuario();
                        formulario.ShowDialog();
                        return;
                    }
                    else
                    {
                        intentosFallidosUsuario++;  // Aumentar contador de intentos fallidos

                        if (intentosFallidosUsuario >= 3)
                        {
                            tiempoBloqueoUsuario = DateTime.Now.AddMinutes(2);
                            MessageBox.Show("Has superado el número máximo de intentos. Estás bloqueado durante 2 minutos.",
                                            "Bloqueo por seguridad", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        else
                        {
                            MessageBox.Show("Acceso denegado. Usuario sin privilegios o credenciales incorrectas.",
                                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void porEmpleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReporteCitaEstado reporteCitaEstado = new ReporteCitaEstado();
            reporteCitaEstado.ShowDialog();
        }

        private void pruebaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManteEmpleado manteEmpleado = new ManteEmpleado();
            manteEmpleado.ShowDialog();
        }

        private void aToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MantDisponibilidad mantDisponibilidad = new MantDisponibilidad();
            mantDisponibilidad.ShowDialog();
        }



        //Variables de Acesso Temporal
        private int intentosFallidosDisponibilidad = 0;
        private DateTime tiempoBloqueoDisponibilidad;
        private void disponibilidadToolStripMenuItem_Click(object sender, EventArgs e)
        {
           

            if (intentosFallidosServicio >= 3)
            {
                TimeSpan tiempoRestante = tiempoBloqueoServicio - DateTime.Now;
                if (tiempoRestante.TotalSeconds > 0)
                {
                    MessageBox.Show($"Acceso bloqueado. Vuelve a intentar en {tiempoRestante.Minutes}:{tiempoRestante.Seconds} minutos.",
                                    "Acceso bloqueado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    intentosFallidosServicio = 0;
                }
            }

            // Verificar si el usuario actual tiene permisos
            if (Program.Rol == "SuperAdmin" || Program.Rol == "Admin")
            {
                MantDisponibilidad mantDisponibilidad = new MantDisponibilidad();
                mantDisponibilidad.ShowDialog();
            }
            else
            {
                while (intentosFallidosDisponibilidad < 3)
                {
                    string usuario = Microsoft.VisualBasic.Interaction.InputBox("Usuario:", "Requiere privilegios", "");
                    if (string.IsNullOrEmpty(usuario)) return; // Salir si el usuario cancela

                    string clave = Microsoft.VisualBasic.Interaction.InputBox("Contraseña:", "Requiere privilegios", "", -1, -1);
                    if (string.IsNullOrEmpty(clave)) return; // Salir si el usuario cancela

                    // Verificar credenciales
                    CNUsuario cnUsuario = new CNUsuario();
                    (string mensaje, string nuevoRol) = cnUsuario.AutenticarUsuario(usuario, clave);

                    Console.WriteLine($"Intento de autenticación - Usuario: {usuario}, Mensaje: {mensaje}, Rol: '{nuevoRol}'");

                    if (mensaje == "Autenticación exitosa" && (nuevoRol.Trim() == "SuperAdmin" || nuevoRol.Trim() == "Admin"))
                    {
                        intentosFallidosDisponibilidad = 0; // Resetear intentos fallidos si el usuario es válido
                        MantDisponibilidad mantDisponibilidad = new MantDisponibilidad();
                        mantDisponibilidad.ShowDialog();
                        return;
                    }
                    else
                    {
                        intentosFallidosDisponibilidad++;  // Aumentar contador de intentos fallidos

                        if (intentosFallidosDisponibilidad >= 3)
                        {
                            tiempoBloqueoUsuario = DateTime.Now.AddMinutes(2);
                            MessageBox.Show("Has superado el número máximo de intentos. Estás bloqueado durante 2 minutos.",
                                            "Bloqueo por seguridad", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        else
                        {
                            MessageBox.Show("Acceso denegado. Usuario sin privilegios o credenciales incorrectas.",
                                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }
    }
}
