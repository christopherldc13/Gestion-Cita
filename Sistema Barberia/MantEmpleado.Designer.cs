
namespace Sistema_Barberia
{
    partial class MantEmpleado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MantEmpleado));
            this.PBotones = new System.Windows.Forms.Panel();
            this.BSalir = new System.Windows.Forms.Button();
            this.BCancelar = new System.Windows.Forms.Button();
            this.BEditar = new System.Windows.Forms.Button();
            this.BGuardar = new System.Windows.Forms.Button();
            this.BNuevo = new System.Windows.Forms.Button();
            this.PTitulo = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cbEstado = new System.Windows.Forms.ComboBox();
            this.tbDisponibilidad = new System.Windows.Forms.TextBox();
            this.tbTelefono = new System.Windows.Forms.TextBox();
            this.tbApellido = new System.Windows.Forms.TextBox();
            this.tbNombre = new System.Windows.Forms.TextBox();
            this.tbIdBarbero = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BBuscar = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.PBotones.SuspendLayout();
            this.PTitulo.SuspendLayout();
            this.SuspendLayout();
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
            this.PBotones.Location = new System.Drawing.Point(-2, 447);
            this.PBotones.Name = "PBotones";
            this.PBotones.Size = new System.Drawing.Size(805, 75);
            this.PBotones.TabIndex = 30;
            // 
            // BSalir
            // 
            this.BSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BSalir.FlatAppearance.BorderSize = 0;
            this.BSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BSalir.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BSalir.Image = ((System.Drawing.Image)(resources.GetObject("BSalir.Image")));
            this.BSalir.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.BSalir.Location = new System.Drawing.Point(672, 12);
            this.BSalir.Name = "BSalir";
            this.BSalir.Size = new System.Drawing.Size(76, 45);
            this.BSalir.TabIndex = 5;
            this.BSalir.Text = "&Salir";
            this.BSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.BSalir, "Salir de la Ventana");
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
            this.BCancelar.Size = new System.Drawing.Size(104, 45);
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
            this.toolTip1.SetToolTip(this.BEditar, "Editar un Registro");
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
            this.BGuardar.Size = new System.Drawing.Size(102, 45);
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
            this.toolTip1.SetToolTip(this.BNuevo, "Nuevo Registro");
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
            this.PTitulo.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(163, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(473, 38);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mantenimiento Empleado";
            // 
            // cbEstado
            // 
            this.cbEstado.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.cbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbEstado.FormattingEnabled = true;
            this.cbEstado.Items.AddRange(new object[] {
            "Activo",
            "Inactivo"});
            this.cbEstado.Location = new System.Drawing.Point(487, 345);
            this.cbEstado.Name = "cbEstado";
            this.cbEstado.Size = new System.Drawing.Size(200, 21);
            this.cbEstado.TabIndex = 43;
            this.toolTip1.SetToolTip(this.cbEstado, "Estado del Empleado");
            // 
            // tbDisponibilidad
            // 
            this.tbDisponibilidad.Location = new System.Drawing.Point(438, 195);
            this.tbDisponibilidad.Multiline = true;
            this.tbDisponibilidad.Name = "tbDisponibilidad";
            this.tbDisponibilidad.Size = new System.Drawing.Size(299, 77);
            this.tbDisponibilidad.TabIndex = 42;
            this.toolTip1.SetToolTip(this.tbDisponibilidad, "Horario de Disponibilidad del Empleado");
            // 
            // tbTelefono
            // 
            this.tbTelefono.Location = new System.Drawing.Point(82, 363);
            this.tbTelefono.Name = "tbTelefono";
            this.tbTelefono.Size = new System.Drawing.Size(224, 20);
            this.tbTelefono.TabIndex = 41;
            this.toolTip1.SetToolTip(this.tbTelefono, "Telefono del Empleado");
            // 
            // tbApellido
            // 
            this.tbApellido.Location = new System.Drawing.Point(82, 281);
            this.tbApellido.Name = "tbApellido";
            this.tbApellido.Size = new System.Drawing.Size(224, 20);
            this.tbApellido.TabIndex = 40;
            this.toolTip1.SetToolTip(this.tbApellido, "Apellido del Empleado");
            // 
            // tbNombre
            // 
            this.tbNombre.Location = new System.Drawing.Point(82, 200);
            this.tbNombre.Name = "tbNombre";
            this.tbNombre.Size = new System.Drawing.Size(224, 20);
            this.tbNombre.TabIndex = 39;
            this.toolTip1.SetToolTip(this.tbNombre, "Nombre del Empleado");
            // 
            // tbIdBarbero
            // 
            this.tbIdBarbero.Location = new System.Drawing.Point(172, 111);
            this.tbIdBarbero.Name = "tbIdBarbero";
            this.tbIdBarbero.Size = new System.Drawing.Size(142, 20);
            this.tbIdBarbero.TabIndex = 38;
            this.toolTip1.SetToolTip(this.tbIdBarbero, "Id del Empleado");
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(553, 300);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 26);
            this.label7.TabIndex = 37;
            this.label7.Text = "Estado";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(519, 162);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(134, 26);
            this.label6.TabIndex = 36;
            this.label6.Text = "Disponibilidad";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(148, 324);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 26);
            this.label5.TabIndex = 35;
            this.label5.Text = "Telefono";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(148, 246);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 26);
            this.label4.TabIndex = 34;
            this.label4.Text = "Apellido";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(151, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 26);
            this.label3.TabIndex = 33;
            this.label3.Text = "Nombre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(54, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 26);
            this.label2.TabIndex = 31;
            this.label2.Text = "Id Empleado";
            // 
            // BBuscar
            // 
            this.BBuscar.BackColor = System.Drawing.Color.Transparent;
            this.BBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BBuscar.FlatAppearance.BorderSize = 0;
            this.BBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BBuscar.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BBuscar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BBuscar.Image = ((System.Drawing.Image)(resources.GetObject("BBuscar.Image")));
            this.BBuscar.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.BBuscar.Location = new System.Drawing.Point(327, 95);
            this.BBuscar.Name = "BBuscar";
            this.BBuscar.Size = new System.Drawing.Size(142, 45);
            this.BBuscar.TabIndex = 32;
            this.BBuscar.Text = "&Buscar Empleado";
            this.BBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.BBuscar, "Buscar Empleado");
            this.BBuscar.UseVisualStyleBackColor = false;
            this.BBuscar.Click += new System.EventHandler(this.BBuscar_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flowLayoutPanel1.Location = new System.Drawing.Point(20, 82);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(761, 342);
            this.flowLayoutPanel1.TabIndex = 74;
            // 
            // MantEmpleado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 515);
            this.Controls.Add(this.BBuscar);
            this.Controls.Add(this.cbEstado);
            this.Controls.Add(this.tbDisponibilidad);
            this.Controls.Add(this.tbTelefono);
            this.Controls.Add(this.tbApellido);
            this.Controls.Add(this.tbNombre);
            this.Controls.Add(this.tbIdBarbero);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PBotones);
            this.Controls.Add(this.PTitulo);
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MantEmpleado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registro Empleado";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MantEmpleado_FormClosing);
            this.Load += new System.EventHandler(this.MantEmpleado_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MantEmpleado_KeyDown);
            this.PBotones.ResumeLayout(false);
            this.PTitulo.ResumeLayout(false);
            this.PTitulo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PBotones;
        private System.Windows.Forms.Button BSalir;
        private System.Windows.Forms.Button BCancelar;
        private System.Windows.Forms.Button BEditar;
        private System.Windows.Forms.Button BGuardar;
        private System.Windows.Forms.Button BNuevo;
        private System.Windows.Forms.Panel PTitulo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BBuscar;
        private System.Windows.Forms.ComboBox cbEstado;
        private System.Windows.Forms.TextBox tbDisponibilidad;
        private System.Windows.Forms.TextBox tbTelefono;
        private System.Windows.Forms.TextBox tbApellido;
        private System.Windows.Forms.TextBox tbNombre;
        private System.Windows.Forms.TextBox tbIdBarbero;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}