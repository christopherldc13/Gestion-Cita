using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Gestor_de_Citas;
using CapaNegocios;
using System.Windows.Forms.DataVisualization.Charting;
using System.Globalization;

namespace GUI_MODERNISTA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ConfigurarTemporizador(); // Configura el temporizador
            tbBienvenido.Text = ("Bienvenido: "+ Program.usuario);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            copyright.Text = $"Copyright {Program.copyright} {DateTime.Now.Year}, La Vega Rep. Dom.";
            timerOcultar = new Timer();
            timerOcultar.Interval = 200; // Pequeño retraso para evitar parpadeos
            timerOcultar.Tick += TimerOcultar_Tick;
            cargarcuadro();

            //Carga los Chart
            CargarGraficoCitas(); 
            CargarChartGananciasDiarias();
            CargarChartGananciaSemanal();
            CargarGraficoGananciasMensuales();
            MostrarTop3Servicios();
        }

        //Temporizador para recargar cada 5s
        private void ConfigurarTemporizador()
        {
            Timer temporizador = new Timer
            {
                Interval = 5000
            };
            temporizador.Tick += (s, e) => cargarcuadro(); // Recarga los datos
            temporizador.Tick += (s, e) => CargarGraficoCitas(); // Recarga los datos
            temporizador.Tick += (s, e) => CargarChartGananciasDiarias(); // Recarga los datos
            temporizador.Tick += (s, e) => CargarChartGananciaSemanal(); // Recarga los datos
            temporizador.Tick += (s, e) => CargarGraficoGananciasMensuales(); // Recarga los datos
            temporizador.Tick += (s, e) => MostrarTop3Servicios(); // Recarga los datos
            temporizador.Start();
        }

        //Cuadros del DASHBOARD
        private void cargarcuadro()
        {
            //Cuadro de Cliente: Cliente activos
            int cantidadActivos = CNCliente.ObtenerCantidadClientesActivos();
            label5.Text = cantidadActivos.ToString();

            //Cuadro de Empleado: Empleados activos
            int cantidadActivosEmpleado = CNEmpleado.ObtenerCantidadEmpleadosActivos();
            label6.Text = cantidadActivosEmpleado.ToString();

            //Cuadro de Cita: PENDIENTE, REALIZADO Y CANCELADO
            int pendientes, realizadas, canceladas;
            CNCita.ObtenerEstadisticasCitasDeHoy(out pendientes, out realizadas, out canceladas);
            pendiente.Text = pendientes.ToString();
            realizada.Text = realizadas.ToString();
            cancelada.Text = canceladas.ToString();

            //Cuadro de Pagos: PENDIENTE y PAGADO
            int pendientepago, pagadas;
            CNPago.ObtenerEstadisticasPagosHoy(out pendientepago, out pagadas);
            Pendientes.Text = pendientepago.ToString();
            Pagados.Text = pagadas.ToString();

            //Cuadro de Pagos: Ganancias diarias
            decimal ganancias = CNCita.ObtenerGananciaDiaria();
            label8.Text = "RD$ " + ganancias.ToString("N2", new CultureInfo("es-DO"));
        }

        //Grafico de cargar citas Cancelada y Realizadas en el año
        private void CargarGraficoCitas()
        {
            chart1.Series.Clear();
            chart1.ChartAreas.Clear();
            chart1.Legends.Clear();
            chart1.Titles.Clear();

            // Área del gráfico
            ChartArea area = new ChartArea("CitasArea");

            // Fondo blanco semitransparente (ARGB: 204 = 80% opacidad)
            area.BackColor = Color.FromArgb(204, 255, 255, 255);

            area.AxisX.TitleFont = new Font("Segoe UI", 10, FontStyle.Bold);
            area.AxisY.TitleFont = new Font("Segoe UI", 10, FontStyle.Bold);
            area.AxisX.LabelStyle.Font = new Font("Segoe UI", 9);
            area.AxisY.LabelStyle.Font = new Font("Segoe UI", 9);

            area.AxisX.LabelStyle.ForeColor = Color.White;
            area.AxisY.LabelStyle.ForeColor = Color.White;
            area.AxisX.TitleForeColor = Color.White;
            area.AxisY.TitleForeColor = Color.White;

            // Asegurarse de rotar las etiquetas del eje X
            area.AxisX.LabelStyle.Angle = 90; // Rotar las etiquetas del eje X a 90 grados (vertical)

            // Asegurarse de que haya suficiente espacio en el eje X
            area.AxisX.IsMarginVisible = true; // Esto permite el espacio adicional para las etiquetas
            area.AxisX.Interval = 1;

            area.AxisX.MajorGrid.Enabled = true;
            area.AxisY.MajorGrid.Enabled = true;
            area.AxisX.MajorGrid.LineColor = Color.LightGray;
            area.AxisY.MajorGrid.LineColor = Color.LightGray;
            area.AxisX.LineColor = Color.White;
            area.AxisY.LineColor = Color.White;

            chart1.ChartAreas.Add(area);

            // Leyenda
            Legend legend = new Legend();
            legend.Docking = Docking.Top;
            legend.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            legend.ForeColor = Color.White;
            legend.BackColor = Color.Transparent;
            chart1.Legends.Add(legend);

            // Serie: Realizadas
            Series realizadas = new Series("Citas Realizadas")
            {
                ChartType = SeriesChartType.Line,
                BorderWidth = 3,
                Color = Color.FromArgb(0, 120, 215),
                IsValueShownAsLabel = false,
                MarkerStyle = MarkerStyle.None,
                ToolTip = "#VALX: #VAL citas realizadas"
            };

            // Serie: Canceladas
            Series canceladas = new Series("Citas Canceladas")
            {
                ChartType = SeriesChartType.Line,
                BorderWidth = 3,
                Color = Color.FromArgb(141, 110, 99),
                IsValueShownAsLabel = false,
                MarkerStyle = MarkerStyle.None,
                ToolTip = "#VALX: #VAL citas canceladas"
            };

            // Cargar datos últimos 12 meses
            DateTime fechaActual = DateTime.Now;
            for (int i = 11; i >= 0; i--)
            {
                DateTime mes = fechaActual.AddMonths(-i);
                string nombreMes = mes.ToString("MMM yyyy", new System.Globalization.CultureInfo("es-ES")); // Mes abreviado

                int realizadasCount = ObtenerCantidadCitasPorEstadoYMes("Realizada", mes.Month, mes.Year);
                int canceladasCount = ObtenerCantidadCitasPorEstadoYMes("Cancelada", mes.Month, mes.Year);

                realizadas.Points.AddXY(nombreMes, realizadasCount);
                canceladas.Points.AddXY(nombreMes, canceladasCount);
            }

            chart1.Series.Add(realizadas);
            chart1.Series.Add(canceladas);

            // Título del gráfico
            chart1.Titles.Add(new Title("Número de citas realizadas y canceladas", Docking.Top,
                new Font("Segoe UI", 14, FontStyle.Bold), Color.White));

            chart1.TabStop = false;
            chart1.Enabled = true;
            chart1.MouseDown += (s, e) => this.ActiveControl = null;
            chart1.Enter += (s, e) => this.ActiveControl = null;

            chart1.GetToolTipText += (s, e) => { };
        }

        //Carga los datos para el grafico de citas Canceladas y realizadas en el año
        private int ObtenerCantidadCitasPorEstadoYMes(string estado, int mes, int año)
        {
            int cantidad = 0;

            try
            {
                DataTable dt = CNCita.ObtenerCitasPorEstadoYMes();

                var filas = dt.AsEnumerable().Where(f =>
                    f["Estado"].ToString() == estado &&
                    Convert.ToInt32(f["NumeroMes"]) == mes &&
                    Convert.ToInt32(f["Anio"]) == año
                );

                if (filas.Any())
                {
                    cantidad = filas.Sum(f => Convert.ToInt32(f["Cantidad"]));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener cantidad de citas: " + ex.Message);
            }

            return cantidad;
        }

        //Grafico 1, Ganancias Diarias
        private void CargarChartGananciasDiarias()
        {
            DataTable dt = CNPago.ObtenerGananciasDiariasChart();

            // Diccionario de abreviaturas
            Dictionary<DayOfWeek, string> abreviaturas = new Dictionary<DayOfWeek, string>
            {
                { DayOfWeek.Monday, "L" },
                { DayOfWeek.Tuesday, "M" },
                { DayOfWeek.Wednesday, "W" },
                { DayOfWeek.Thursday, "J" },
                { DayOfWeek.Friday, "V" },
                { DayOfWeek.Saturday, "S" },
                { DayOfWeek.Sunday, "D" }
            };

            chart2.Series.Clear();
            chart2.Legends.Clear();
            chart2.Titles.Clear();

            var series = new System.Windows.Forms.DataVisualization.Charting.Series
            {
                Name = "GananciaDiaria",
                IsValueShownAsLabel = false,
                ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column,
                Color = Color.FromArgb(46, 139, 87)
            };
            series["PointWidth"] = "0.7";
            series["PixelPointWidth"] = "20";
            series.ToolTip = " ";

            decimal maxGanancia = 0;

            if (dt == null || dt.Rows.Count == 0)
            {
                // Mostrar todos los días con ganancia 0
                foreach (var dia in abreviaturas)
                {
                    series.Points.AddXY(dia.Value, 0);
                }

                //var noDatos = chart2.Titles.Add("No hay datos disponibles");
                //noDatos.ForeColor = Color.Gray;
                //noDatos.Alignment = ContentAlignment.MiddleCenter;
                //noDatos.Font = new Font("Segoe UI", 10, FontStyle.Italic);
            }
            else
            {
                // Mostrar solo los días que tienen datos
                foreach (DataRow row in dt.Rows)
                {
                    DateTime fecha = Convert.ToDateTime(row["Fecha"]);
                    string diaAbreviado = abreviaturas[fecha.DayOfWeek];
                    string diaCompleto = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(
                        fecha.ToString("dddd", new CultureInfo("es-ES"))
                    );
                    decimal ganancia = Convert.ToDecimal(row["GananciaTotal"]);

                    int index = series.Points.AddXY(diaAbreviado, ganancia);
                    series.Points[index].ToolTip = $"{diaCompleto}: RD${ganancia:N0}";

                    if (ganancia > maxGanancia)
                        maxGanancia = ganancia;
                }
            }

            chart2.Series.Add(series);

            var titulo = chart2.Titles.Add("Ganancias Diarias - Últimos 7 días");
            titulo.ForeColor = Color.White;
            titulo.Alignment = ContentAlignment.TopCenter;
            titulo.Font = new Font("Segoe UI", 11, FontStyle.Bold);

            var area = chart2.ChartAreas[0];
            area.AxisX.MajorGrid.LineWidth = 0;
            area.AxisY.MajorGrid.LineWidth = 0;
            area.AxisX.MinorGrid.Enabled = false;
            area.AxisY.MinorGrid.Enabled = false;
            area.BorderWidth = 0;
            area.BackColor = Color.Transparent;

            area.AxisX.LabelStyle.ForeColor = Color.White;
            area.AxisY.LabelStyle.ForeColor = Color.White;
            area.AxisX.LabelStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            area.AxisY.LabelStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            area.AxisX.TitleForeColor = Color.White;
            area.AxisY.TitleForeColor = Color.White;

            area.AxisY.Minimum = 0;
            area.AxisY.Maximum = (double)(maxGanancia * 1.2m);
            area.AxisY.Interval = maxGanancia > 0 ? Math.Ceiling((double)(maxGanancia * 1.2m) / 4) : 1;

            // Etiquetas personalizadas en el eje Y
            area.AxisY.CustomLabels.Clear();
            for (double i = area.AxisY.Minimum; i <= area.AxisY.Maximum; i += area.AxisY.Interval)
            {
                string texto = FormatearNumero((decimal)i);
                var etiqueta = new CustomLabel
                {
                    FromPosition = i - area.AxisY.Interval / 2,
                    ToPosition = i + area.AxisY.Interval / 2,
                    Text = texto
                };
                area.AxisY.CustomLabels.Add(etiqueta);
            }

            // Ajustes para tooltips
            chart2.TabStop = false;
            chart2.Enabled = true;
            chart2.MouseDown += (s, e) => this.ActiveControl = null;
            chart2.Enter += (s, e) => this.ActiveControl = null;
            chart2.GetToolTipText += (s, e) => { };
        }

        //Graficos 2, Ganancias Semanales
        private void CargarChartGananciaSemanal()
        {
            DataTable dt = CNPago.ObtenerGananciasSemanalesChart();

            chart3.Series.Clear();
            chart3.Legends.Clear();
            chart3.Titles.Clear();

            // Este título siempre se muestra
            var titulo = chart3.Titles.Add("Ganancia Semanal - Últimas 4 Semanas");
            titulo.ForeColor = Color.White;
            titulo.Alignment = ContentAlignment.TopCenter;
            titulo.Font = new Font("Segoe UI", 11, FontStyle.Bold);

            var series = new System.Windows.Forms.DataVisualization.Charting.Series
            {
                Name = "GananciaSemanal",
                IsValueShownAsLabel = false,
                ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineArea,
                BorderWidth = 2,
                BorderColor = Color.MediumSeaGreen,
                Color = Color.FromArgb(144, 238, 144),
                ToolTip = " ",
                BorderDashStyle = ChartDashStyle.Solid,
                MarkerStyle = MarkerStyle.Circle,
                MarkerSize = 3,
                MarkerColor = Color.SeaGreen
            };

            decimal maxGanancia = 0;

            if (dt == null || dt.Rows.Count == 0)
            {
                // Mostrar 4 semanas con ganancia 0
                for (int i = 1; i <= 4; i++)
                {
                    string semana = "S-" + i;
                    series.Points.AddXY(semana, 0);
                }
            }
            else
            {
                foreach (DataRow row in dt.Rows)
                {
                    string semanaCompleta = row["Semana"].ToString(); // Ej. "Semana 14"
                    string[] partes = semanaCompleta.Split(' ');
                    string semanaCorta = "S-" + partes[1];

                    decimal ganancia = Convert.ToDecimal(row["GananciaTotal"]);
                    int index = series.Points.AddXY(semanaCorta, ganancia);

                    series.Points[index].ToolTip = $"Semana {semanaCompleta}: RD${ganancia:N0}";
                    series.Points[index].IsValueShownAsLabel = false;

                    if (ganancia > maxGanancia)
                        maxGanancia = ganancia;
                }
            }

            chart3.Series.Add(series);

            var area = chart3.ChartAreas[0];
            area.Area3DStyle.Enable3D = false;
            area.AxisX.MajorGrid.LineWidth = 0;
            area.AxisY.MajorGrid.LineWidth = 0;
            area.AxisX.MinorGrid.Enabled = false;
            area.AxisY.MinorGrid.Enabled = false;
            area.BorderWidth = 0;
            area.BackColor = Color.Transparent;

            area.AxisX.LabelStyle.ForeColor = Color.White;
            area.AxisY.LabelStyle.ForeColor = Color.White;
            area.AxisX.LabelStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            area.AxisY.LabelStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            area.AxisX.TitleForeColor = Color.White;
            area.AxisY.TitleForeColor = Color.White;

            area.AxisY.Minimum = 0;
            area.AxisY.Maximum = (double)(maxGanancia * 1.2m);
            area.AxisY.Interval = maxGanancia > 0 ? Math.Ceiling((double)(maxGanancia * 1.2m) / 4) : 1;

            area.AxisY.CustomLabels.Clear();
            for (double i = area.AxisY.Minimum; i <= area.AxisY.Maximum; i += area.AxisY.Interval)
            {
                string texto = FormatearNumero((decimal)i);
                var etiqueta = new CustomLabel
                {
                    FromPosition = i - area.AxisY.Interval / 2,
                    ToPosition = i + area.AxisY.Interval / 2,
                    Text = texto
                };
                area.AxisY.CustomLabels.Add(etiqueta);
            }

            chart3.TabStop = false;
            chart3.Enabled = true;
            chart3.MouseDown += (s, e) => this.ActiveControl = null;
            chart3.Enter += (s, e) => this.ActiveControl = null;
        }

        //Grafico 3, Grafico mensual, solo llega a los 6 meses
        private void CargarGraficoGananciasMensuales()
        {
            DataTable dt = CNPago.ObtenerGananciasMensualesChart();

            Dictionary<int, string> meses = new Dictionary<int, string>
            {
                {1, "Ene"}, {2, "Feb"}, {3, "Mar"}, {4, "Abr"},
                {5, "May"}, {6, "Jun"}, {7, "Jul"}, {8, "Ago"},
                {9, "Sep"}, {10, "Oct"}, {11, "Nov"}, {12, "Dic"}
            };

            chart4.Series.Clear();
            chart4.Legends.Clear();
            chart4.Titles.Clear();

            var series = new Series
            {
                Name = "GananciaMensual",
                IsValueShownAsLabel = false,
                ChartType = SeriesChartType.Column,
                Color = Color.FromArgb(46, 139, 87)
            };
            series["PointWidth"] = "0.7";
            series["PixelPointWidth"] = "20";
            series.ToolTip = " ";

            decimal maxGanancia = 0;

            if (dt == null || dt.Rows.Count == 0)
            {
                DateTime actual = DateTime.Now;
                for (int i = 11; i >= 0; i--)
                {
                    DateTime mes = actual.AddMonths(-i);
                    string etiqueta = meses[mes.Month];
                    series.Points.AddXY(etiqueta, 0);
                }
            }
            else
            {
                foreach (DataRow row in dt.Rows)
                {
                    string mesTexto = row["Mes"].ToString(); // formato "yyyy-MM"
                    DateTime fechaMes = DateTime.ParseExact(mesTexto + "-01", "yyyy-MM-dd", CultureInfo.InvariantCulture);

                    string abreviado = meses[fechaMes.Month];
                    string completo = fechaMes.ToString("MMMM yyyy", new CultureInfo("es-ES"));
                    decimal ganancia = Convert.ToDecimal(row["GananciaTotal"]);

                    int index = series.Points.AddXY(abreviado, ganancia);
                    series.Points[index].ToolTip = $"{completo}: RD${ganancia:N0}";

                    if (ganancia > maxGanancia)
                        maxGanancia = ganancia;
                }
            }

            chart4.Series.Add(series);

            var titulo = chart4.Titles.Add("Ganancias de los Últimos 6 Meses");
            titulo.ForeColor = Color.White;
            titulo.Alignment = ContentAlignment.TopCenter;
            titulo.Font = new Font("Segoe UI", 11, FontStyle.Bold);

            ChartArea area = chart4.ChartAreas.Count > 0 ? chart4.ChartAreas[0] : chart4.ChartAreas.Add("AreaMensual");
            area.AxisX.MajorGrid.LineWidth = 0;
            area.AxisY.MajorGrid.LineWidth = 0;
            area.AxisX.MinorGrid.Enabled = false;
            area.AxisY.MinorGrid.Enabled = false;
            area.BorderWidth = 0;
            area.BackColor = Color.Transparent;

            area.AxisX.LabelStyle.ForeColor = Color.White;
            area.AxisY.LabelStyle.ForeColor = Color.White;

            // Reducir el tamaño de las fechas en el eje X
            area.AxisX.LabelStyle.Font = new Font("Segoe UI", 8, FontStyle.Bold); // Cambié el tamaño a 8

            area.AxisY.LabelStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            area.AxisX.TitleForeColor = Color.White;
            area.AxisY.TitleForeColor = Color.White;

            area.AxisY.Minimum = 0;
            area.AxisY.Maximum = (double)(maxGanancia * 1.2m);
            area.AxisY.Interval = maxGanancia > 0 ? Math.Ceiling((double)(maxGanancia * 1.2m) / 4) : 1;

            // Etiquetas personalizadas en el eje Y
            area.AxisY.CustomLabels.Clear();
            for (double i = area.AxisY.Minimum; i <= area.AxisY.Maximum; i += area.AxisY.Interval)
            {
                string texto = FormatearNumero((decimal)i);
                var etiqueta = new CustomLabel
                {
                    FromPosition = i - area.AxisY.Interval / 2,
                    ToPosition = i + area.AxisY.Interval / 2,
                    Text = texto
                };
                area.AxisY.CustomLabels.Add(etiqueta);
            }

            // Ajustes para tooltips
            chart4.TabStop = false;
            chart4.Enabled = true;
            chart4.MouseDown += (s, e) => this.ActiveControl = null;
            chart4.Enter += (s, e) => this.ActiveControl = null;
            chart4.GetToolTipText += (s, e) => { };
        }

        //Los 3 servicios mas solicitados en Citas
        private void MostrarTop3Servicios()
        {
            try
            {
                DataTable dt = CapaNegocios.CNServicio.ObtenerTop3Servicios();

                Dictionary<int, Color> podiumColors = new Dictionary<int, Color>
                {
                    {0, Color.Gold},
                    {1, Color.Silver},
                    {2, Color.Peru}
                };

                chart5.Series.Clear();
                chart5.Legends.Clear();
                chart5.Titles.Clear();

                var serie = new Series("TopServicios")
                {
                    ChartType = SeriesChartType.Column,
                    IsValueShownAsLabel = true,
                    Color = Color.White,
                    Font = new Font("Segoe UI", 9, FontStyle.Bold)
                };

                decimal maxValor = 0;
                int pos = 0;

                foreach (DataRow row in dt.Rows)
                {
                    string servicio = row["Servicio"].ToString();
                    int total = Convert.ToInt32(row["TotalSolicitudes"]);

                    int index = serie.Points.AddXY(servicio, total);
                    serie.Points[index].ToolTip = $"{servicio}: {total} solicitudes";

                    if (podiumColors.ContainsKey(pos))
                        serie.Points[index].Color = podiumColors[pos];

                    if (total > maxValor)
                        maxValor = total;

                    pos++;
                }

                chart5.Series.Add(serie);

                // TÍTULO
                Title titulo = chart5.Titles.Add("Top de los 3 Servicios Más Solicitados");
                titulo.Font = new Font("Segoe UI", 11, FontStyle.Bold);
                titulo.ForeColor = Color.White;
                titulo.Alignment = ContentAlignment.TopCenter;

                // ÁREA DEL CHART
                ChartArea area = chart5.ChartAreas.Count > 0 ? chart5.ChartAreas[0] : chart5.ChartAreas.Add("AreaTopServicios");
                area.AxisX.MajorGrid.LineWidth = 0;
                area.AxisY.MajorGrid.LineWidth = 0;
                area.AxisX.MinorGrid.Enabled = false;
                area.AxisY.MinorGrid.Enabled = false;
                area.BackColor = Color.Transparent;

                area.AxisX.LabelStyle.ForeColor = Color.White;
                area.AxisY.LabelStyle.ForeColor = Color.White;
                area.AxisX.LabelStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                area.AxisY.LabelStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                area.AxisY.Minimum = 0;
                area.AxisY.Maximum = (double)(maxValor * 1.2m);
                area.AxisY.Interval = maxValor > 0 ? Math.Ceiling((double)(maxValor * 1.2m) / 3) : 1;

                // ETIQUETAS PERSONALIZADAS EN EL EJE Y
                area.AxisY.CustomLabels.Clear();
                for (double i = area.AxisY.Minimum; i <= area.AxisY.Maximum; i += area.AxisY.Interval)
                {
                    string texto = i.ToString("N0");
                    var etiqueta = new CustomLabel
                    {
                        FromPosition = i - area.AxisY.Interval / 2,
                        ToPosition = i + area.AxisY.Interval / 2,
                        Text = texto
                    };
                    area.AxisY.CustomLabels.Add(etiqueta);
                }

                // DESACTIVAR FOCUS
                chart5.TabStop = false;
                chart5.Enabled = true;
                chart5.MouseDown += (s, e) => this.ActiveControl = null;
                chart5.Enter += (s, e) => this.ActiveControl = null;
                chart5.GetToolTipText += (s, e) => { };
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar el Top 3 de servicios: " + ex.Message);
            }
        }

        //Formatar numeros 
        private string FormatearNumero(decimal numero)
        {
            if (numero >= 1_000_000)
                return (numero / 1_000_000M).ToString("0.#") + "M";
            else if (numero >= 1_000)
                return (numero / 1_000M).ToString("0.#") + "k";
            else
                return numero.ToString("0");
        }


        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnMaximizar.Visible = false;
            btnRestaurar.Visible = true;
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnRestaurar.Visible = false;
            btnMaximizar.Visible = true;
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

        private void btnMinimizar_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            SubmenuReportes.Visible = true;
        }

        private void btnrptventa_Click(object sender, EventArgs e)
        {
            SubmenuReportes.Visible = false;
        }

        private void btnrptcompra_Click(object sender, EventArgs e)
        {
            SubmenuReportes.Visible = false;
        }

        private void btnrptpagos_Click(object sender, EventArgs e)
        {
            SubmenuReportes.Visible = false;
        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MantDisponibilidad mantDisponibilidad = new MantDisponibilidad();
            mantDisponibilidad.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MantCliente mantCliente = new MantCliente();
            mantCliente.ShowDialog();

        }

        private Timer timerOcultar;

        private void btnReportes_MouseEnter(object sender, EventArgs e)
        {
            SubmenuReportes.Visible = true;
            timerOcultar.Stop(); // Detenemos el temporizador si el mouse vuelve
        }

        private void btnReportes_MouseLeave(object sender, EventArgs e)
        {
            timerOcultar.Start(); // Empieza a verificar si debe ocultar
        }

        private void SubmenuReportes_MouseEnter(object sender, EventArgs e)
        {
            timerOcultar.Stop(); // Sigue visible si entra al submenu
        }

        private void SubmenuReportes_MouseLeave(object sender, EventArgs e)
        {
            timerOcultar.Start(); // Comienza a ocultar si sale del submenu
        }


        private void TimerOcultar_Tick(object sender, EventArgs e)
        {
            // Verifica si el mouse NO está en el botón NI en el submenú
            if (!btnReportes.Bounds.Contains(PointToClient(System.Windows.Forms.Cursor.Position)) &&
                !SubmenuReportes.Bounds.Contains(PointToClient(System.Windows.Forms.Cursor.Position)))
            {
                SubmenuReportes.Visible = false;
                timerOcultar.Stop();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MantCita mantCita = new MantCita();
            mantCita.ShowDialog();
        }

        private void Empleados_Click(object sender, EventArgs e)
        {
            ManteEmpleado manteEmpleado = new ManteEmpleado();
            manteEmpleado.ShowDialog();
        }

        private void Usuarios_Click(object sender, EventArgs e)
        {
            MantUsuario mantUsuario = new MantUsuario();
            mantUsuario.ShowDialog();
        }

        private void Pago_Click(object sender, EventArgs e)
        {
            MantPago mantPago = new MantPago();
            mantPago.ShowDialog();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Hide();
            Login login = new Login();
            login.ShowDialog();
        }

        private void CitasPendientes_Click(object sender, EventArgs e)
        {
            CitasPendientes citasPendientes = new CitasPendientes();
            citasPendientes.ShowDialog();
        }

        private void BServicios_Click(object sender, EventArgs e)
        {
            MantServicio mantServicio = new MantServicio();
            mantServicio.ShowDialog();
        }

        private void BarraTitulo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCerrar_Click_1(object sender, EventArgs e)
        {
            this.Close();
            this.Hide();
            Login login = new Login();
            login.ShowDialog(); ;
        }
    }
}
