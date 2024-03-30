
namespace Sistema_Barberia
{
    partial class FBuscarUsuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FBuscarUsuario));
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.DGVDatos = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.bAceptar = new System.Windows.Forms.Button();
            this.bCancelar = new System.Windows.Forms.Button();
            this.bUltimo = new System.Windows.Forms.Button();
            this.bSiguiente = new System.Windows.Forms.Button();
            this.bAnterior = new System.Windows.Forms.Button();
            this.bPrimero = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BBuscar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbBuscar = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DGVDatos)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DGVDatos
            // 
            this.DGVDatos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVDatos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DGVDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVDatos.Location = new System.Drawing.Point(-3, 101);
            this.DGVDatos.Name = "DGVDatos";
            this.DGVDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVDatos.Size = new System.Drawing.Size(874, 398);
            this.DGVDatos.TabIndex = 7;
            this.DGVDatos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVDatos_CellDoubleClick);
            this.DGVDatos.CurrentCellChanged += new System.EventHandler(this.DGVDatos_CurrentCellChanged);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel3.Controls.Add(this.bAceptar);
            this.panel3.Controls.Add(this.bCancelar);
            this.panel3.Controls.Add(this.bUltimo);
            this.panel3.Controls.Add(this.bSiguiente);
            this.panel3.Controls.Add(this.bAnterior);
            this.panel3.Controls.Add(this.bPrimero);
            this.panel3.Location = new System.Drawing.Point(1, 499);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(870, 70);
            this.panel3.TabIndex = 6;
            // 
            // bAceptar
            // 
            this.bAceptar.Location = new System.Drawing.Point(761, 18);
            this.bAceptar.Name = "bAceptar";
            this.bAceptar.Size = new System.Drawing.Size(75, 33);
            this.bAceptar.TabIndex = 5;
            this.bAceptar.Text = "Acept&ar";
            this.bAceptar.UseVisualStyleBackColor = true;
            this.bAceptar.Click += new System.EventHandler(this.bAceptar_Click);
            // 
            // bCancelar
            // 
            this.bCancelar.Location = new System.Drawing.Point(625, 18);
            this.bCancelar.Name = "bCancelar";
            this.bCancelar.Size = new System.Drawing.Size(75, 33);
            this.bCancelar.TabIndex = 4;
            this.bCancelar.Text = "&Cancelar";
            this.bCancelar.UseVisualStyleBackColor = true;
            this.bCancelar.Click += new System.EventHandler(this.bCancelar_Click);
            // 
            // bUltimo
            // 
            this.bUltimo.Location = new System.Drawing.Point(358, 18);
            this.bUltimo.Name = "bUltimo";
            this.bUltimo.Size = new System.Drawing.Size(75, 33);
            this.bUltimo.TabIndex = 3;
            this.bUltimo.Text = "&Ultimo";
            this.bUltimo.UseVisualStyleBackColor = true;
            this.bUltimo.Click += new System.EventHandler(this.bUltimo_Click);
            // 
            // bSiguiente
            // 
            this.bSiguiente.Location = new System.Drawing.Point(250, 18);
            this.bSiguiente.Name = "bSiguiente";
            this.bSiguiente.Size = new System.Drawing.Size(75, 33);
            this.bSiguiente.TabIndex = 2;
            this.bSiguiente.Text = "&Siguiente";
            this.bSiguiente.UseVisualStyleBackColor = true;
            this.bSiguiente.Click += new System.EventHandler(this.bSiguiente_Click);
            // 
            // bAnterior
            // 
            this.bAnterior.Location = new System.Drawing.Point(132, 18);
            this.bAnterior.Name = "bAnterior";
            this.bAnterior.Size = new System.Drawing.Size(75, 33);
            this.bAnterior.TabIndex = 1;
            this.bAnterior.Text = "&Anterios";
            this.bAnterior.UseVisualStyleBackColor = true;
            this.bAnterior.Click += new System.EventHandler(this.bAnterior_Click);
            // 
            // bPrimero
            // 
            this.bPrimero.Location = new System.Drawing.Point(33, 18);
            this.bPrimero.Name = "bPrimero";
            this.bPrimero.Size = new System.Drawing.Size(75, 33);
            this.bPrimero.TabIndex = 0;
            this.bPrimero.Text = "&Primero";
            this.bPrimero.UseVisualStyleBackColor = true;
            this.bPrimero.Click += new System.EventHandler(this.bPrimero_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.panel2.Controls.Add(this.BBuscar);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.tbBuscar);
            this.panel2.Location = new System.Drawing.Point(0, 60);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(871, 48);
            this.panel2.TabIndex = 5;
            // 
            // BBuscar
            // 
            this.BBuscar.BackColor = System.Drawing.Color.Transparent;
            this.BBuscar.FlatAppearance.BorderSize = 0;
            this.BBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BBuscar.Image = ((System.Drawing.Image)(resources.GetObject("BBuscar.Image")));
            this.BBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BBuscar.Location = new System.Drawing.Point(396, 5);
            this.BBuscar.Name = "BBuscar";
            this.BBuscar.Size = new System.Drawing.Size(75, 32);
            this.BBuscar.TabIndex = 2;
            this.BBuscar.Text = "Buscar";
            this.BBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BBuscar.UseVisualStyleBackColor = false;
            this.BBuscar.Click += new System.EventHandler(this.BBuscar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(14, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ingrese los datos a buscar";
            // 
            // tbBuscar
            // 
            this.tbBuscar.Location = new System.Drawing.Point(189, 15);
            this.tbBuscar.Name = "tbBuscar";
            this.tbBuscar.Size = new System.Drawing.Size(196, 20);
            this.tbBuscar.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(867, 62);
            this.panel1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(237, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(361, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "Consultas de Usuario";
            // 
            // FBuscarUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 569);
            this.Controls.Add(this.DGVDatos);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FBuscarUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FConsultaUsuario";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FConsultaUsuario_FormClosing);
            this.Load += new System.EventHandler(this.FConsultaUsuario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVDatos)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.DataGridView DGVDatos;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button bAceptar;
        private System.Windows.Forms.Button bCancelar;
        private System.Windows.Forms.Button bUltimo;
        private System.Windows.Forms.Button bSiguiente;
        private System.Windows.Forms.Button bAnterior;
        private System.Windows.Forms.Button bPrimero;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button BBuscar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbBuscar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
    }
}