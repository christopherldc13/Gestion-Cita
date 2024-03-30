
namespace Sistema_Barberia
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
            this.BBuscarCliente = new System.Windows.Forms.Button();
            this.tbIdEmpleado = new System.Windows.Forms.TextBox();
            this.BBuscarEmpleado = new System.Windows.Forms.Button();
            this.dtpHora = new System.Windows.Forms.DateTimePicker();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label11 = new System.Windows.Forms.Label();
            this.tbApellidoCliente = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tbTelefonoCliente = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.label14 = new System.Windows.Forms.Label();
            this.tbTelefonoEmpleado = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
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
            this.BBuscarCita.Location = new System.Drawing.Point(197, 106);
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
            this.cbEstado.FormattingEnabled = true;
            this.cbEstado.Items.AddRange(new object[] {
            "Pendiente",
            "Realizado"});
            this.cbEstado.Location = new System.Drawing.Point(50, 367);
            this.cbEstado.Name = "cbEstado";
            this.cbEstado.Size = new System.Drawing.Size(198, 21);
            this.cbEstado.TabIndex = 58;
            this.toolTip1.SetToolTip(this.cbEstado, "Estado de la Cita");
            this.cbEstado.SelectedIndexChanged += new System.EventHandler(this.cbEstado_SelectedIndexChanged);
            // 
            // tbNombreCliente
            // 
            this.tbNombreCliente.Location = new System.Drawing.Point(417, 161);
            this.tbNombreCliente.Name = "tbNombreCliente";
            this.tbNombreCliente.Size = new System.Drawing.Size(155, 20);
            this.tbNombreCliente.TabIndex = 54;
            this.toolTip1.SetToolTip(this.tbNombreCliente, "Nombre del Cliente");
            // 
            // tbIdCita
            // 
            this.tbIdCita.Location = new System.Drawing.Point(99, 116);
            this.tbIdCita.Name = "tbIdCita";
            this.tbIdCita.Size = new System.Drawing.Size(89, 20);
            this.tbIdCita.TabIndex = 53;
            this.toolTip1.SetToolTip(this.tbIdCita, "Id de la Cita");
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(111, 330);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 26);
            this.label7.TabIndex = 52;
            this.label7.Text = "Estado";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(80, 166);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(141, 26);
            this.label5.TabIndex = 50;
            this.label5.Text = "Fecha de la Cita";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(92, 252);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 26);
            this.label4.TabIndex = 49;
            this.label4.Text = "Hora de Cita";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(333, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 26);
            this.label3.TabIndex = 48;
            this.label3.Text = "Nombre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(34, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 26);
            this.label2.TabIndex = 46;
            this.label2.Text = "Id Cita";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // PBotones
            // 
            this.PBotones.BackColor = System.Drawing.Color.LightSteelBlue;
            this.PBotones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PBotones.Controls.Add(this.BSalir);
            this.PBotones.Controls.Add(this.BCancelar);
            this.PBotones.Controls.Add(this.BEditar);
            this.PBotones.Controls.Add(this.BGuardar);
            this.PBotones.Controls.Add(this.BNuevo);
            this.PBotones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PBotones.Location = new System.Drawing.Point(0, 417);
            this.PBotones.Name = "PBotones";
            this.PBotones.Size = new System.Drawing.Size(800, 75);
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
            this.BSalir.Location = new System.Drawing.Point(672, 13);
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
            this.BCancelar.Location = new System.Drawing.Point(415, 14);
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
            this.BEditar.Location = new System.Drawing.Point(288, 14);
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
            this.BGuardar.Location = new System.Drawing.Point(153, 14);
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
            this.BNuevo.Location = new System.Drawing.Point(19, 14);
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
            this.PTitulo.BackColor = System.Drawing.Color.CornflowerBlue;
            this.PTitulo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PTitulo.Controls.Add(this.label1);
            this.PTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.PTitulo.Location = new System.Drawing.Point(0, 0);
            this.PTitulo.Name = "PTitulo";
            this.PTitulo.Size = new System.Drawing.Size(800, 62);
            this.PTitulo.TabIndex = 44;
            this.PTitulo.Paint += new System.Windows.Forms.PaintEventHandler(this.PTitulo_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(240, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(289, 38);
            this.label1.TabIndex = 1;
            this.label1.Text = "Gestión de Cita";
            // 
            // tbNombreEmpleado
            // 
            this.tbNombreEmpleado.Location = new System.Drawing.Point(534, 331);
            this.tbNombreEmpleado.Name = "tbNombreEmpleado";
            this.tbNombreEmpleado.Size = new System.Drawing.Size(222, 20);
            this.tbNombreEmpleado.TabIndex = 59;
            this.toolTip1.SetToolTip(this.tbNombreEmpleado, "Nombre del Empleado");
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(335, 117);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 26);
            this.label8.TabIndex = 60;
            this.label8.Text = "Id Cliente";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(335, 287);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(119, 26);
            this.label9.TabIndex = 62;
            this.label9.Text = "Id Empleado";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(332, 327);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(201, 26);
            this.label10.TabIndex = 63;
            this.label10.Text = "Nombre del Empleado";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Location = new System.Drawing.Point(50, 208);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(200, 20);
            this.dtpFecha.TabIndex = 65;
            this.toolTip1.SetToolTip(this.dtpFecha, "Fecha de la Cita");
            // 
            // tbIdCliente
            // 
            this.tbIdCliente.Location = new System.Drawing.Point(427, 123);
            this.tbIdCliente.Name = "tbIdCliente";
            this.tbIdCliente.Size = new System.Drawing.Size(89, 20);
            this.tbIdCliente.TabIndex = 67;
            this.toolTip1.SetToolTip(this.tbIdCliente, "Id del Cliente");
            // 
            // BBuscarCliente
            // 
            this.BBuscarCliente.BackColor = System.Drawing.Color.Transparent;
            this.BBuscarCliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BBuscarCliente.FlatAppearance.BorderSize = 0;
            this.BBuscarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BBuscarCliente.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BBuscarCliente.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BBuscarCliente.Image = ((System.Drawing.Image)(resources.GetObject("BBuscarCliente.Image")));
            this.BBuscarCliente.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.BBuscarCliente.Location = new System.Drawing.Point(522, 117);
            this.BBuscarCliente.Name = "BBuscarCliente";
            this.BBuscarCliente.Size = new System.Drawing.Size(84, 37);
            this.BBuscarCliente.TabIndex = 68;
            this.BBuscarCliente.Text = "&Buscar";
            this.BBuscarCliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.BBuscarCliente, "Buscar Cliente");
            this.BBuscarCliente.UseVisualStyleBackColor = false;
            this.BBuscarCliente.Click += new System.EventHandler(this.BBuscarCliente_Click);
            // 
            // tbIdEmpleado
            // 
            this.tbIdEmpleado.Location = new System.Drawing.Point(450, 291);
            this.tbIdEmpleado.Name = "tbIdEmpleado";
            this.tbIdEmpleado.Size = new System.Drawing.Size(89, 20);
            this.tbIdEmpleado.TabIndex = 69;
            this.toolTip1.SetToolTip(this.tbIdEmpleado, "Id de Empleado");
            // 
            // BBuscarEmpleado
            // 
            this.BBuscarEmpleado.BackColor = System.Drawing.Color.Transparent;
            this.BBuscarEmpleado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BBuscarEmpleado.FlatAppearance.BorderSize = 0;
            this.BBuscarEmpleado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BBuscarEmpleado.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BBuscarEmpleado.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BBuscarEmpleado.Image = ((System.Drawing.Image)(resources.GetObject("BBuscarEmpleado.Image")));
            this.BBuscarEmpleado.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.BBuscarEmpleado.Location = new System.Drawing.Point(546, 283);
            this.BBuscarEmpleado.Name = "BBuscarEmpleado";
            this.BBuscarEmpleado.Size = new System.Drawing.Size(97, 38);
            this.BBuscarEmpleado.TabIndex = 70;
            this.BBuscarEmpleado.Text = "&Buscar";
            this.BBuscarEmpleado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.BBuscarEmpleado, "Buscar Barbero");
            this.BBuscarEmpleado.UseVisualStyleBackColor = false;
            this.BBuscarEmpleado.Click += new System.EventHandler(this.BBuscarEmpleado_Click);
            // 
            // dtpHora
            // 
            this.dtpHora.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHora.Location = new System.Drawing.Point(50, 294);
            this.dtpHora.Name = "dtpHora";
            this.dtpHora.ShowUpDown = true;
            this.dtpHora.Size = new System.Drawing.Size(198, 20);
            this.dtpHora.TabIndex = 71;
            this.toolTip1.SetToolTip(this.dtpHora, "Hora de la Cita");
            this.dtpHora.Value = new System.DateTime(2024, 3, 23, 14, 2, 0, 0);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flowLayoutPanel1.Location = new System.Drawing.Point(19, 99);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(285, 306);
            this.flowLayoutPanel1.TabIndex = 72;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(92, 72);
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
            this.flowLayoutPanel2.Location = new System.Drawing.Point(328, 111);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(458, 124);
            this.flowLayoutPanel2.TabIndex = 74;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(333, 196);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(83, 26);
            this.label11.TabIndex = 75;
            this.label11.Text = "Apellido";
            // 
            // tbApellidoCliente
            // 
            this.tbApellidoCliente.Location = new System.Drawing.Point(417, 198);
            this.tbApellidoCliente.Name = "tbApellidoCliente";
            this.tbApellidoCliente.Size = new System.Drawing.Size(155, 20);
            this.tbApellidoCliente.TabIndex = 76;
            this.toolTip1.SetToolTip(this.tbApellidoCliente, "Apellido del Cliente");
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(638, 161);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(84, 26);
            this.label12.TabIndex = 77;
            this.label12.Text = "Telefono";
            // 
            // tbTelefonoCliente
            // 
            this.tbTelefonoCliente.Location = new System.Drawing.Point(597, 196);
            this.tbTelefonoCliente.Name = "tbTelefonoCliente";
            this.tbTelefonoCliente.Size = new System.Drawing.Size(163, 20);
            this.tbTelefonoCliente.TabIndex = 78;
            this.toolTip1.SetToolTip(this.tbTelefonoCliente, "Telefono del Cliente");
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(484, 84);
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
            this.flowLayoutPanel3.Location = new System.Drawing.Point(328, 280);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(458, 125);
            this.flowLayoutPanel3.TabIndex = 80;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(335, 367);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(84, 26);
            this.label14.TabIndex = 81;
            this.label14.Text = "Telefono";
            // 
            // tbTelefonoEmpleado
            // 
            this.tbTelefonoEmpleado.Location = new System.Drawing.Point(418, 371);
            this.tbTelefonoEmpleado.Name = "tbTelefonoEmpleado";
            this.tbTelefonoEmpleado.Size = new System.Drawing.Size(222, 20);
            this.tbTelefonoEmpleado.TabIndex = 82;
            this.toolTip1.SetToolTip(this.tbTelefonoEmpleado, "Telefono del Empleado");
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(472, 251);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(179, 26);
            this.label15.TabIndex = 83;
            this.label15.Text = "Datos del Empleado";
            // 
            // MantCita
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 492);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.tbTelefonoEmpleado);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.tbTelefonoCliente);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.tbApellidoCliente);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dtpHora);
            this.Controls.Add(this.BBuscarEmpleado);
            this.Controls.Add(this.tbIdEmpleado);
            this.Controls.Add(this.BBuscarCliente);
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
        private System.Windows.Forms.Button BBuscarCliente;
        private System.Windows.Forms.TextBox tbIdEmpleado;
        private System.Windows.Forms.Button BBuscarEmpleado;
        private System.Windows.Forms.DateTimePicker dtpHora;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbApellidoCliente;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbTelefonoCliente;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tbTelefonoEmpleado;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}