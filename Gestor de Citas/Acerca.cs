using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocios;

namespace Gestor_de_Citas
{
    public partial class Acerca : Form
    {
        public Acerca()
        {
            InitializeComponent();
            MostrarAcercaDe(); // Cargar "Inicio" por defecto
        }

        private void Inicio_Click(object sender, EventArgs e)
        {
            MostrarInicio();
        }



        private void acercade_Click(object sender, EventArgs e)
        {
            MostrarAcercaDe();
        }

        //private void MostrarInicio()
        //{
        //    panel1.Controls.Clear();

        //    string rutaBase = AppDomain.CurrentDomain.BaseDirectory;
        //    string rutaImagen = Path.Combine(rutaBase, @"..\..\..\Multimedia\Inicio.png");
        //    rutaImagen = Path.GetFullPath(rutaImagen);

        //    try
        //    {
        //        if (File.Exists(rutaImagen))
        //        {
        //            pictureBox1.Image = Image.FromFile(rutaImagen);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // Aquí puedes manejar el error si es necesario, sin mostrar el mensaje
        //        // Se puede dejar vacío si no se quiere hacer nada con el error
        //    }


        //    // Título de la sección de inicio
        //    Label lblTitulo = new Label
        //    {
        //        Text = "Inicio",
        //        AutoSize = false,
        //        Font = new Font("Arial", 16, FontStyle.Bold),
        //        ForeColor = Color.DarkBlue,
        //        Size = new Size(760, 40),
        //        Location = new Point(20, 10),
        //        TextAlign = ContentAlignment.MiddleLeft
        //    };
        //    panel1.Controls.Add(lblTitulo);

        //    // Espaciado entre el título y el contenido
        //    int y = lblTitulo.Bottom + 10;

        //    // Crear las etiquetas con formato para cada dato de inicio
        //    Label lblDescripcion = new Label
        //    {
        //        Text = "Sistema local de gestión de citas diseñado para uso interno por personal autorizado. Centraliza la programación, modificación y seguimiento de reservas, optimizando la organización diaria.",
        //        AutoSize = false,
        //        Font = new Font("Arial", 12, FontStyle.Regular),
        //        ForeColor = Color.Black,
        //        Size = new Size(760, 60),
        //        Location = new Point(20, y),
        //        TextAlign = ContentAlignment.TopLeft
        //    };
        //    panel1.Controls.Add(lblDescripcion);
        //    y += lblDescripcion.Height + 10;

        //    Label lblDesarrolladoPor = new Label
        //    {
        //        Text = "Desarrollado por: Alfrin Mejía Adrián (2022-0927), Christopher Lantigua De La Cruz (2022-1018)",
        //        AutoSize = false,
        //        Font = new Font("Arial", 12, FontStyle.Regular),
        //        ForeColor = Color.Black,
        //        Size = new Size(760, 30),
        //        Location = new Point(20, y),
        //        TextAlign = ContentAlignment.TopLeft
        //    };
        //    panel1.Controls.Add(lblDesarrolladoPor);
        //}

        private void MostrarInicio()
        {
            panel1.Controls.Clear();

            string rutaBase = AppDomain.CurrentDomain.BaseDirectory;
            string rutaImagen = Path.Combine(rutaBase, @"..\..\..\Multimedia\Inicio.png");
            rutaImagen = Path.GetFullPath(rutaImagen);

            PictureBox pictureBox1 = new PictureBox();

            // Nuevos tamaños y ubicación para la imagen (más grande y centrada verticalmente)
            int imagenAncho = 400;
            int imagenAlto = 280;
            int imagenX = panel1.Width - imagenAncho - 30; // Más margen derecho
            int imagenY = (panel1.Height - imagenAlto) / 2; // Centrada verticalmente

            try
            {
                if (File.Exists(rutaImagen))
                {
                    pictureBox1.Image = Image.FromFile(rutaImagen);
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBox1.Location = new Point(imagenX, imagenY);
                    pictureBox1.Size = new Size(imagenAncho, imagenAlto);
                    panel1.Controls.Add(pictureBox1);
                }
                else
                {
                    pictureBox1.Image = null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cargar la imagen: {ex.Message}");
            }

            // Título
            Label lblTitulo = new Label
            {
                Text = "Inicio",
                AutoSize = false,
                Font = new Font("Arial", 18, FontStyle.Bold), // Título un poco más grande
                ForeColor = Color.DarkBlue,
                Size = new Size(panel1.Width - 40, 40),
                Location = new Point(20, 20), // Más margen superior
                TextAlign = ContentAlignment.MiddleLeft
            };
            panel1.Controls.Add(lblTitulo);

            // Espaciado después del título
            int y = lblTitulo.Bottom + 25; // Aumentar el espaciado

            // Ancho disponible para el texto
            int anchoTexto = imagenX - 40; // Margen izquierdo y espacio antes de la imagen

            // Descripción (texto anterior)
            Label lblDescripcion = new Label
            {
                Text = "Sistema local de gestión de citas diseñado para uso interno por personal autorizado. Centraliza la programación, modificación y seguimiento de reservas, optimizando la organización diaria.",
                AutoSize = false,
                Font = new Font("Arial", 14, FontStyle.Regular), // Texto un poco más grande
                ForeColor = Color.Black,
                Size = new Size(anchoTexto, 0),
                Location = new Point(20, y),
                TextAlign = ContentAlignment.TopLeft
            };
            lblDescripcion.MaximumSize = new Size(anchoTexto, 0);
            lblDescripcion.AutoSize = true;
            panel1.Controls.Add(lblDescripcion);
            y = lblDescripcion.Bottom + 20; // Aumentar el espaciado

            // Desarrollado por (texto anterior)
            Label lblDesarrolladoPor = new Label
            {
                Text = "Desarrollado por: Alfrin Mejía Adrián (2022-0927), Christopher Lantigua De La Cruz (2022-1018)",
                AutoSize = false,
                Font = new Font("Arial", 12, FontStyle.Italic), // Estilo diferente
                ForeColor = Color.Gray, // Color diferente
                Size = new Size(anchoTexto, 0),
                Location = new Point(20, y),
                TextAlign = ContentAlignment.TopLeft
            };
            lblDesarrolladoPor.MaximumSize = new Size(anchoTexto, 0);
            lblDesarrolladoPor.AutoSize = true;
            panel1.Controls.Add(lblDesarrolladoPor);

            // Puedes seguir agregando más contenido de texto aquí si lo deseas.
        }

        //Esto Sirve para mostrar la Información que sale al pulsar Acerca de

        private void MostrarAcercaDe()
        {
            panel1.Controls.Clear();

            string rutaBase = AppDomain.CurrentDomain.BaseDirectory;
            string rutaImagen = Path.Combine(rutaBase, @"..\..\..\Multimedia\acercade.png");
            rutaImagen = Path.GetFullPath(rutaImagen);

            PictureBox pictureBox1 = new PictureBox();

            // Nuevos tamaños y ubicación para la imagen (más grande y centrada verticalmente a la derecha)
            int imagenAncho = 300; // Ajusta el ancho según tu preferencia
            int imagenAlto = 250; // Ajusta la altura según tu preferencia
            int imagenX = panel1.Width - imagenAncho - 30; // Margen derecho
            int imagenY = (panel1.Height - imagenAlto) / 2; // Centrada verticalmente

            try
            {
                if (File.Exists(rutaImagen))
                {
                    pictureBox1.Image = Image.FromFile(rutaImagen);
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBox1.Location = new Point(imagenX, imagenY);
                    pictureBox1.Size = new Size(imagenAncho, imagenAlto);
                    panel1.Controls.Add(pictureBox1);
                }
                else
                {
                    pictureBox1.Image = null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cargar la imagen: {ex.Message}");
            }

            // Título de la sección de Acerca de
            Label lblTitulo = new Label
            {
                Text = "Acerca del Sistema de Citas",
                AutoSize = false,
                Font = new Font("Arial", 18, FontStyle.Bold), // Título un poco más grande
                ForeColor = Color.DarkBlue,
                Size = new Size(panel1.Width - 40, 40),
                Location = new Point(20, 20), // Más margen superior
                TextAlign = ContentAlignment.MiddleLeft
            };
            panel1.Controls.Add(lblTitulo);

            // Espaciado entre el título y el contenido
            int y = lblTitulo.Bottom + 25; // Aumentar el espaciado

            // Ancho disponible para el texto
            int anchoTexto = imagenX - 40; // Margen izquierdo y espacio antes de la imagen

            // Descripción del sistema
            Label lblDescripcion = new Label
            {
                Text = "Sistema local para gestión ágil de citas, diseñado para uso interno por un empleado designado. Permite programar, modificar y cancelar reservas, así como enviar recordatorios automatizados. Optimiza la organización de agendas y garantiza comunicación eficiente con usuarios. Ideal para mejorar la productividad y calidad del servicio.",
                AutoSize = false,
                Font = new Font("Arial", 14, FontStyle.Regular), // Texto un poco más grande
                ForeColor = Color.Black,
                Size = new Size(anchoTexto, 0),
                Location = new Point(20, y),
                TextAlign = ContentAlignment.TopLeft
            };
            lblDescripcion.MaximumSize = new Size(anchoTexto, 0);
            lblDescripcion.AutoSize = true;
            panel1.Controls.Add(lblDescripcion);
            y = lblDescripcion.Bottom + 20; // Aumentar el espaciado

            // Responsable del sistema
            Label lblDesarrolladoPor = new Label
            {
                Text = "Desarrollado por: Alfrin Mejía Adrián (2022-0927), Christopher Lantigua De La Cruz (2022-1018)",
                AutoSize = false,
                Font = new Font("Arial", 12, FontStyle.Italic), // Estilo diferente
                ForeColor = Color.Gray, // Color diferente
                Size = new Size(anchoTexto, 0),
                Location = new Point(20, y),
                TextAlign = ContentAlignment.TopLeft
            };
            lblDesarrolladoPor.MaximumSize = new Size(anchoTexto, 0);
            lblDesarrolladoPor.AutoSize = true;
            panel1.Controls.Add(lblDesarrolladoPor);
        }

        private void contacto_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();

            string rutaBase = AppDomain.CurrentDomain.BaseDirectory;
            string rutaImagen = Path.Combine(rutaBase, @"..\..\..\Multimedia\Contacto.png");
            rutaImagen = Path.GetFullPath(rutaImagen);

            PictureBox pictureBox1 = new PictureBox();

            // Nuevos tamaños y ubicación para la imagen (más grande y centrada verticalmente a la derecha)
            int imagenAncho = 300; // Ajusta el ancho según tu preferencia
            int imagenAlto = 250; // Ajusta la altura según tu preferencia
            int imagenX = panel1.Width - imagenAncho - 30; // Margen derecho
            int imagenY = (panel1.Height - imagenAlto) / 2; // Centrada verticalmente

            try
            {
                if (File.Exists(rutaImagen))
                {
                    pictureBox1.Image = Image.FromFile(rutaImagen);
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBox1.Location = new Point(imagenX, imagenY);
                    pictureBox1.Size = new Size(imagenAncho, imagenAlto);
                    panel1.Controls.Add(pictureBox1);
                }
                else
                {
                    pictureBox1.Image = null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cargar la imagen: {ex.Message}");
            }

            // Título de la sección de contacto
            Label lblTitulo = new Label
            {
                Text = "Contacto",
                AutoSize = false,
                Font = new Font("Arial", 18, FontStyle.Bold), // Título un poco más grande
                ForeColor = Color.DarkBlue,
                Size = new Size(panel1.Width - 40, 40),
                Location = new Point(20, 20), // Más margen superior
                TextAlign = ContentAlignment.MiddleLeft
            };
            panel1.Controls.Add(lblTitulo);

            // Espaciado entre el título y el contenido
            int y = lblTitulo.Bottom + 25; // Aumentar el espaciado

            // Ancho disponible para el texto
            int anchoTexto = imagenX - 40; // Margen izquierdo y espacio antes de la imagen

            // Crear las etiquetas con formato para cada dato de contacto
            Label lblCorreo = new Label
            {
                Text = "✉ Correo: soporte@citaexpress.com",
                AutoSize = false,
                Font = new Font("Arial", 14, FontStyle.Regular), // Texto un poco más grande
                ForeColor = Color.Black,
                Size = new Size(anchoTexto, 30),
                Location = new Point(20, y),
                TextAlign = ContentAlignment.MiddleLeft
            };
            panel1.Controls.Add(lblCorreo);
            y += lblCorreo.Height + 10; // Aumentar el espaciado

            Label lblTelefono = new Label
            {
                Text = "📞 Teléfono Interno: (849) 000-0001",
                AutoSize = false,
                Font = new Font("Arial", 14, FontStyle.Regular), // Texto un poco más grande
                ForeColor = Color.Black,
                Size = new Size(anchoTexto, 30),
                Location = new Point(20, y),
                TextAlign = ContentAlignment.MiddleLeft
            };
            panel1.Controls.Add(lblTelefono);
            y += lblTelefono.Height + 10; // Aumentar el espaciado

            Label lblHorario = new Label
            {
                Text = "🕒 Horario de Asistencia: L-V, 8:00A.M - 6:00P.M",
                AutoSize = false,
                Font = new Font("Arial", 14, FontStyle.Regular), // Texto un poco más grande
                ForeColor = Color.Black,
                Size = new Size(anchoTexto, 30),
                Location = new Point(20, y),
                TextAlign = ContentAlignment.MiddleLeft
            };
            panel1.Controls.Add(lblHorario);
            y += lblHorario.Height + 10; // Aumentar el espaciado

            Label lblOficina = new Label
            {
                Text = "📍 Oficina Responsable: Administración, Piso 2",
                AutoSize = false,
                Font = new Font("Arial", 14, FontStyle.Regular), // Texto un poco más grande
                ForeColor = Color.Black,
                Size = new Size(anchoTexto, 30),
                Location = new Point(20, y),
                TextAlign = ContentAlignment.MiddleLeft
            };
            panel1.Controls.Add(lblOficina);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Acerca_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Acerca_Load_1(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}