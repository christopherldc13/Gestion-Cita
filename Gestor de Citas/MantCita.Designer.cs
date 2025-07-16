
namespace Gestor_de_Citas
{
    partial class MantCita
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MantCita));
            this.BBuscarCita = new System.Windows.Forms.Button();
            this.cbEstado = new System.Windows.Forms.ComboBox();
            this.tbNombreCliente = new System.Windows.Forms.TextBox();
            this.tbIdCita = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.PBotones = new System.Windows.Forms.Panel();
            this.BSalir = new System.Windows.Forms.Button();
            this.BCancelar = new System.Windows.Forms.Button();
            this.BEditar = new System.Windows.Forms.Button();
            this.BGuardar = new System.Windows.Forms.Button();
            this.BNuevo = new System.Windows.Forms.Button();
            this.PTitulo = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.tbNombreEmpleado = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.tbIdCliente = new System.Windows.Forms.TextBox();
            this.tbIdEmpleado = new System.Windows.Forms.TextBox();
            this.dtpHora = new System.Windows.Forms.DateTimePicker();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label11 = new System.Windows.Forms.Label();
            this.tbApellidoCliente = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tbCorreoCliente = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.label14 = new System.Windows.Forms.Label();
            this.tbTelefonoEmpleado = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tbServicio = new System.Windows.Forms.TextBox();
            this.tbPrecio = new System.Windows.Forms.TextBox();
            this.tbIdServicio = new System.Windows.Forms.TextBox();
            this.bBuscarCliente = new System.Windows.Forms.Button();
            this.bBuscarEmpleado = new System.Windows.Forms.Button();
            this.bBuscarServicio = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.duracion = new System.Windows.Forms.Label();
            this.PBotones.SuspendLayout();
            this.PTitulo.SuspendLayout();
            this.SuspendLayout();
            // 
            // BBuscarCita
            // 
            this.BBuscarCita.BackColor = System.Drawing.Color.Transparent;
            this.BBuscarCita.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BBuscarCita.FlatAppearance.BorderSize = 0;
            this.BBuscarCita.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BBuscarCita.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BBuscarCita.Image = ((System.Drawing.Image)(resources.GetObject("BBuscarCita.Image")));
            this.BBuscarCita.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.BBuscarCita.Location = new System.Drawing.Point(182, 89);
            this.BBuscarCita.Name = "BBuscarCita";
            this.BBuscarCita.Size = new System.Drawing.Size(83, 38);
            this.BBuscarCita.TabIndex = 47;
            this.BBuscarCita.Text = "&Buscar";
            this.BBuscarCita.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.BBuscarCita, "Buscar Cita");
            this.BBuscarCita.UseVisualStyleBackColor = false;
            this.BBuscarCita.Click += new System.EventHandler(this.BBuscarCita_Click);
            // 
            // cbEstado
            // 
            this.cbEstado.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.cbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbEstado.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbEstado.FormattingEnabled = true;
            this.cbEstado.Items.AddRange(new object[] {
            "Pendiente",
            "Realizada",
            "Cancelada"});
            this.cbEstado.Location = new System.Drawing.Point(94, 207);
            this.cbEstado.Name = "cbEstado";
            this.cbEstado.Size = new System.Drawing.Size(154, 25);
            this.cbEstado.TabIndex = 58;
            this.toolTip1.SetToolTip(this.cbEstado, "Estado de la Cita");
            // 
            // tbNombreCliente
            // 
            this.tbNombreCliente.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNombreCliente.Location = new System.Drawing.Point(415, 153);
            this.tbNombreCliente.Name = "tbNombreCliente";
            this.tbNombreCliente.Size = new System.Drawing.Size(155, 24);
            this.tbNombreCliente.TabIndex = 54;
            this.toolTip1.SetToolTip(this.tbNombreCliente, "Nombre del Cliente");
            // 
            // tbIdCita
            // 
            this.tbIdCita.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbIdCita.Location = new System.Drawing.Point(63, 98);
            this.tbIdCita.Name = "tbIdCita";
            this.tbIdCita.Size = new System.Drawing.Size(115, 24);
            this.tbIdCita.TabIndex = 53;
            this.toolTip1.SetToolTip(this.tbIdCita, "Id de la Cita");
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(23, 205);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 26);
            this.label7.TabIndex = 52;
            this.label7.Text = "Estado";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(24, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 26);
            this.label5.TabIndex = 50;
            this.label5.Text = "Fecha";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(24, 168);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 26);
            this.label4.TabIndex = 49;
            this.label4.Text = "Hora";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(333, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 26);
            this.label3.TabIndex = 48;
            this.label3.Text = "Nombre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 26);
            this.label2.TabIndex = 46;
            this.label2.Text = "ID";
            // 
            // PBotones
            // 
            this.PBotones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(107)))), ((int)(((byte)(123)))));
            this.PBotones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PBotones.Controls.Add(this.BSalir);
            this.PBotones.Controls.Add(this.BCancelar);
            this.PBotones.Controls.Add(this.BEditar);
            this.PBotones.Controls.Add(this.BGuardar);
            this.PBotones.Controls.Add(this.BNuevo);
            this.PBotones.Location = new System.Drawing.Point(-10, 423);
            this.PBotones.Name = "PBotones";
            this.PBotones.Size = new System.Drawing.Size(821, 80);
            this.PBotones.TabIndex = 45;
            // 
            // BSalir
            // 
            this.BSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BSalir.FlatAppearance.BorderSize = 0;
            this.BSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BSalir.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BSalir.Image = ((System.Drawing.Image)(resources.GetObject("BSalir.Image")));
            this.BSalir.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.BSalir.Location = new System.Drawing.Point(715, 11);
            this.BSalir.Name = "BSalir";
            this.BSalir.Size = new System.Drawing.Size(76, 45);
            this.BSalir.TabIndex = 5;
            this.BSalir.Text = "&Salir";
            this.BSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.BSalir, "Salir de la ventana");
            this.BSalir.UseVisualStyleBackColor = true;
            this.BSalir.Click += new System.EventHandler(this.BSalir_Click);
            // 
            // BCancelar
            // 
            this.BCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BCancelar.FlatAppearance.BorderSize = 0;
            this.BCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BCancelar.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BCancelar.Image = ((System.Drawing.Image)(resources.GetObject("BCancelar.Image")));
            this.BCancelar.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.BCancelar.Location = new System.Drawing.Point(344, 11);
            this.BCancelar.Name = "BCancelar";
            this.BCancelar.Size = new System.Drawing.Size(106, 45);
            this.BCancelar.TabIndex = 3;
            this.BCancelar.Text = "&Cancelar";
            this.BCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.BCancelar, "Cancelar modificación de registro");
            this.BCancelar.UseVisualStyleBackColor = true;
            this.BCancelar.Click += new System.EventHandler(this.BCancelar_Click);
            // 
            // BEditar
            // 
            this.BEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BEditar.FlatAppearance.BorderSize = 0;
            this.BEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BEditar.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BEditar.Image = ((System.Drawing.Image)(resources.GetObject("BEditar.Image")));
            this.BEditar.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.BEditar.Location = new System.Drawing.Point(241, 11);
            this.BEditar.Name = "BEditar";
            this.BEditar.Size = new System.Drawing.Size(90, 45);
            this.BEditar.TabIndex = 2;
            this.BEditar.Text = "&Editar";
            this.BEditar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.BEditar, "Editar registro");
            this.BEditar.UseVisualStyleBackColor = true;
            this.BEditar.Click += new System.EventHandler(this.BEditar_Click);
            // 
            // BGuardar
            // 
            this.BGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BGuardar.FlatAppearance.BorderSize = 0;
            this.BGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BGuardar.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BGuardar.Image = ((System.Drawing.Image)(resources.GetObject("BGuardar.Image")));
            this.BGuardar.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.BGuardar.Location = new System.Drawing.Point(129, 11);
            this.BGuardar.Name = "BGuardar";
            this.BGuardar.Size = new System.Drawing.Size(103, 45);
            this.BGuardar.TabIndex = 1;
            this.BGuardar.Text = "&Guardar";
            this.BGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.BGuardar, "Guardar cambios o nuevo registro");
            this.BGuardar.UseVisualStyleBackColor = true;
            this.BGuardar.Click += new System.EventHandler(this.BGuardar_Click);
            // 
            // BNuevo
            // 
            this.BNuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BNuevo.FlatAppearance.BorderSize = 0;
            this.BNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BNuevo.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BNuevo.Image = ((System.Drawing.Image)(resources.GetObject("BNuevo.Image")));
            this.BNuevo.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.BNuevo.Location = new System.Drawing.Point(27, 11);
            this.BNuevo.Name = "BNuevo";
            this.BNuevo.Size = new System.Drawing.Size(90, 45);
            this.BNuevo.TabIndex = 0;
            this.BNuevo.Text = "&Nuevo";
            this.BNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.BNuevo, "Nuevo registro");
            this.BNuevo.UseVisualStyleBackColor = true;
            this.BNuevo.Click += new System.EventHandler(this.BNuevo_Click);
            // 
            // PTitulo
            // 
            this.PTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(107)))), ((int)(((byte)(123)))));
            this.PTitulo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PTitulo.Controls.Add(this.label1);
            this.PTitulo.Location = new System.Drawing.Point(-10, 0);
            this.PTitulo.Name = "PTitulo";
            this.PTitulo.Size = new System.Drawing.Size(813, 63);
            this.PTitulo.TabIndex = 44;
            this.PTitulo.Paint += new System.Windows.Forms.PaintEventHandler(this.PTitulo_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(258, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(294, 38);
            this.label1.TabIndex = 1;
            this.label1.Text = "Proceso de Cita";
            // 
            // tbNombreEmpleado
            // 
            this.tbNombreEmpleado.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNombreEmpleado.Location = new System.Drawing.Point(418, 337);
            this.tbNombreEmpleado.Name = "tbNombreEmpleado";
            this.tbNombreEmpleado.Size = new System.Drawing.Size(222, 24);
            this.tbNombreEmpleado.TabIndex = 59;
            this.toolTip1.SetToolTip(this.tbNombreEmpleado, "Nombre del Empleado");
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(332, 106);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 26);
            this.label8.TabIndex = 60;
            this.label8.Text = "ID";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(334, 296);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 26);
            this.label9.TabIndex = 62;
            this.label9.Text = "ID";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(335, 335);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(82, 26);
            this.label10.TabIndex = 63;
            this.label10.Text = "Nombre";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(94, 134);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(152, 24);
            this.dtpFecha.TabIndex = 65;
            this.toolTip1.SetToolTip(this.dtpFecha, "Fecha de la Cita");
            this.dtpFecha.Value = new System.DateTime(2025, 1, 31, 0, 0, 0, 0);
            // 
            // tbIdCliente
            // 
            this.tbIdCliente.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbIdCliente.Location = new System.Drawing.Point(372, 109);
            this.tbIdCliente.Name = "tbIdCliente";
            this.tbIdCliente.Size = new System.Drawing.Size(98, 24);
            this.tbIdCliente.TabIndex = 67;
            this.toolTip1.SetToolTip(this.tbIdCliente, "Id del Cliente");
            // 
            // tbIdEmpleado
            // 
            this.tbIdEmpleado.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbIdEmpleado.Location = new System.Drawing.Point(374, 298);
            this.tbIdEmpleado.Name = "tbIdEmpleado";
            this.tbIdEmpleado.Size = new System.Drawing.Size(96, 24);
            this.tbIdEmpleado.TabIndex = 69;
            this.toolTip1.SetToolTip(this.tbIdEmpleado, "Id de Empleado");
            // 
            // dtpHora
            // 
            this.dtpHora.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpHora.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHora.Location = new System.Drawing.Point(95, 171);
            this.dtpHora.Name = "dtpHora";
            this.dtpHora.ShowUpDown = true;
            this.dtpHora.Size = new System.Drawing.Size(152, 24);
            this.dtpHora.TabIndex = 71;
            this.toolTip1.SetToolTip(this.dtpHora, "Hora de la Cita");
            this.dtpHora.Value = new System.DateTime(2025, 1, 31, 16, 44, 26, 0);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flowLayoutPanel1.Location = new System.Drawing.Point(14, 76);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(287, 169);
            this.flowLayoutPanel1.TabIndex = 72;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(28, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(141, 26);
            this.label6.TabIndex = 73;
            this.label6.Text = "Datos de la Cita";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel2.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flowLayoutPanel2.Location = new System.Drawing.Point(323, 76);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(458, 169);
            this.flowLayoutPanel2.TabIndex = 74;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(332, 196);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(83, 26);
            this.label11.TabIndex = 75;
            this.label11.Text = "Apellido";
            // 
            // tbApellidoCliente
            // 
            this.tbApellidoCliente.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbApellidoCliente.Location = new System.Drawing.Point(416, 199);
            this.tbApellidoCliente.Name = "tbApellidoCliente";
            this.tbApellidoCliente.Size = new System.Drawing.Size(155, 24);
            this.tbApellidoCliente.TabIndex = 76;
            this.toolTip1.SetToolTip(this.tbApellidoCliente, "Apellido del Cliente");
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(644, 163);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(67, 26);
            this.label12.TabIndex = 77;
            this.label12.Text = "Correo";
            // 
            // tbCorreoCliente
            // 
            this.tbCorreoCliente.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCorreoCliente.Location = new System.Drawing.Point(582, 199);
            this.tbCorreoCliente.Name = "tbCorreoCliente";
            this.tbCorreoCliente.Size = new System.Drawing.Size(183, 24);
            this.tbCorreoCliente.TabIndex = 78;
            this.toolTip1.SetToolTip(this.tbCorreoCliente, "Telefono del Cliente");
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(340, 65);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(152, 26);
            this.label13.TabIndex = 79;
            this.label13.Text = "Datos del Cliente";
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel3.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flowLayoutPanel3.Location = new System.Drawing.Point(323, 277);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(458, 139);
            this.flowLayoutPanel3.TabIndex = 80;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(335, 376);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(84, 26);
            this.label14.TabIndex = 81;
            this.label14.Text = "Teléfono";
            // 
            // tbTelefonoEmpleado
            // 
            this.tbTelefonoEmpleado.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTelefonoEmpleado.Location = new System.Drawing.Point(418, 378);
            this.tbTelefonoEmpleado.Name = "tbTelefonoEmpleado";
            this.tbTelefonoEmpleado.Size = new System.Drawing.Size(222, 24);
            this.tbTelefonoEmpleado.TabIndex = 82;
            this.toolTip1.SetToolTip(this.tbTelefonoEmpleado, "Telefono del Empleado");
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(339, 264);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(179, 26);
            this.label15.TabIndex = 83;
            this.label15.Text = "Datos del Empleado";
            // 
            // tbServicio
            // 
            this.tbServicio.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbServicio.Location = new System.Drawing.Point(98, 325);
            this.tbServicio.Name = "tbServicio";
            this.tbServicio.Size = new System.Drawing.Size(191, 24);
            this.tbServicio.TabIndex = 85;
            this.toolTip1.SetToolTip(this.tbServicio, "Id del Cliente");
            // 
            // tbPrecio
            // 
            this.tbPrecio.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPrecio.Location = new System.Drawing.Point(91, 355);
            this.tbPrecio.Name = "tbPrecio";
            this.tbPrecio.Size = new System.Drawing.Size(121, 24);
            this.tbPrecio.TabIndex = 87;
            this.toolTip1.SetToolTip(this.tbPrecio, "Id del Cliente");
            // 
            // tbIdServicio
            // 
            this.tbIdServicio.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbIdServicio.Location = new System.Drawing.Point(65, 294);
            this.tbIdServicio.Name = "tbIdServicio";
            this.tbIdServicio.Size = new System.Drawing.Size(93, 24);
            this.tbIdServicio.TabIndex = 90;
            this.toolTip1.SetToolTip(this.tbIdServicio, "Id del Cliente");
            // 
            // bBuscarCliente
            // 
            this.bBuscarCliente.BackColor = System.Drawing.Color.Transparent;
            this.bBuscarCliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bBuscarCliente.FlatAppearance.BorderSize = 0;
            this.bBuscarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bBuscarCliente.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bBuscarCliente.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bBuscarCliente.Image = ((System.Drawing.Image)(resources.GetObject("bBuscarCliente.Image")));
            this.bBuscarCliente.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.bBuscarCliente.Location = new System.Drawing.Point(476, 104);
            this.bBuscarCliente.Name = "bBuscarCliente";
            this.bBuscarCliente.Size = new System.Drawing.Size(84, 37);
            this.bBuscarCliente.TabIndex = 93;
            this.bBuscarCliente.Text = "&Buscar";
            this.bBuscarCliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.bBuscarCliente, "Buscar Cliente");
            this.bBuscarCliente.UseVisualStyleBackColor = false;
            this.bBuscarCliente.Click += new System.EventHandler(this.bBuscarCliente_Click);
            // 
            // bBuscarEmpleado
            // 
            this.bBuscarEmpleado.BackColor = System.Drawing.Color.Transparent;
            this.bBuscarEmpleado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bBuscarEmpleado.FlatAppearance.BorderSize = 0;
            this.bBuscarEmpleado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bBuscarEmpleado.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bBuscarEmpleado.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bBuscarEmpleado.Image = ((System.Drawing.Image)(resources.GetObject("bBuscarEmpleado.Image")));
            this.bBuscarEmpleado.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.bBuscarEmpleado.Location = new System.Drawing.Point(476, 292);
            this.bBuscarEmpleado.Name = "bBuscarEmpleado";
            this.bBuscarEmpleado.Size = new System.Drawing.Size(97, 38);
            this.bBuscarEmpleado.TabIndex = 94;
            this.bBuscarEmpleado.Text = "&Buscar";
            this.bBuscarEmpleado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.bBuscarEmpleado, "Buscar Empleado");
            this.bBuscarEmpleado.UseVisualStyleBackColor = false;
            this.bBuscarEmpleado.Click += new System.EventHandler(this.bBuscarEmpleado_Click);
            // 
            // bBuscarServicio
            // 
            this.bBuscarServicio.BackColor = System.Drawing.Color.Transparent;
            this.bBuscarServicio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bBuscarServicio.FlatAppearance.BorderSize = 0;
            this.bBuscarServicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bBuscarServicio.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bBuscarServicio.Image = ((System.Drawing.Image)(resources.GetObject("bBuscarServicio.Image")));
            this.bBuscarServicio.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.bBuscarServicio.Location = new System.Drawing.Point(176, 284);
            this.bBuscarServicio.Name = "bBuscarServicio";
            this.bBuscarServicio.Size = new System.Drawing.Size(83, 38);
            this.bBuscarServicio.TabIndex = 95;
            this.bBuscarServicio.Text = "&Buscar";
            this.bBuscarServicio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.bBuscarServicio, "Buscar Cita");
            this.bBuscarServicio.UseVisualStyleBackColor = false;
            this.bBuscarServicio.Click += new System.EventHandler(this.bBuscarServicio_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox1.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "20",
            "25",
            "30",
            "35",
            "40",
            "45",
            "50",
            "55",
            "60"});
            this.comboBox1.Location = new System.Drawing.Point(109, 385);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(152, 25);
            this.comboBox1.TabIndex = 97;
            this.toolTip1.SetToolTip(this.comboBox1, "Estado de la Cita");
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(21, 322);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(77, 26);
            this.label16.TabIndex = 84;
            this.label16.Text = "Servicio";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(22, 352);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(63, 26);
            this.label17.TabIndex = 86;
            this.label17.Text = "Precio";
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel4.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flowLayoutPanel4.Location = new System.Drawing.Point(14, 276);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(287, 140);
            this.flowLayoutPanel4.TabIndex = 88;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(23, 291);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(34, 26);
            this.label18.TabIndex = 89;
            this.label18.Text = "ID";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(28, 263);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(160, 26);
            this.label19.TabIndex = 92;
            this.label19.Text = "Datos del Servicio";
            // 
            // duracion
            // 
            this.duracion.AutoSize = true;
            this.duracion.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.duracion.Location = new System.Drawing.Point(22, 383);
            this.duracion.Name = "duracion";
            this.duracion.Size = new System.Drawing.Size(88, 26);
            this.duracion.TabIndex = 96;
            this.duracion.Text = "Duración";
            // 
            // MantCita
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 494);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.duracion);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.bBuscarServicio);
            this.Controls.Add(this.bBuscarEmpleado);
            this.Controls.Add(this.bBuscarCliente);
            this.Controls.Add(this.tbIdServicio);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.tbPrecio);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.tbServicio);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.tbTelefonoEmpleado);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.tbCorreoCliente);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.tbApellidoCliente);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.dtpHora);
            this.Controls.Add(this.tbIdEmpleado);
            this.Controls.Add(this.tbIdCliente);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbNombreEmpleado);
            this.Controls.Add(this.BBuscarCita);
            this.Controls.Add(this.cbEstado);
            this.Controls.Add(this.tbNombreCliente);
            this.Controls.Add(this.tbIdCita);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PBotones);
            this.Controls.Add(this.PTitulo);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.flowLayoutPanel3);
            this.Controls.Add(this.flowLayoutPanel4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MantCita";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registro Cita";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MantCita_FormClosing);
            this.Load += new System.EventHandler(this.MantCita_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MantCita_KeyDown);
            this.PBotones.ResumeLayout(false);
            this.PTitulo.ResumeLayout(false);
            this.PTitulo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BBuscarCita;
        private System.Windows.Forms.ComboBox cbEstado;
        private System.Windows.Forms.TextBox tbNombreCliente;
        private System.Windows.Forms.TextBox tbIdCita;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel PBotones;
        private System.Windows.Forms.Button BSalir;
        private System.Windows.Forms.Button BCancelar;
        private System.Windows.Forms.Button BEditar;
        private System.Windows.Forms.Button BGuardar;
        private System.Windows.Forms.Button BNuevo;
        private System.Windows.Forms.Panel PTitulo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbNombreEmpleado;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.TextBox tbIdCliente;
        private System.Windows.Forms.TextBox tbIdEmpleado;
        private System.Windows.Forms.DateTimePicker dtpHora;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbApellidoCliente;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbCorreoCliente;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tbTelefonoEmpleado;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox tbServicio;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox tbPrecio;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox tbIdServicio;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button bBuscarCliente;
        private System.Windows.Forms.Button bBuscarEmpleado;
        private System.Windows.Forms.Button bBuscarServicio;
        private System.Windows.Forms.Label duracion;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}