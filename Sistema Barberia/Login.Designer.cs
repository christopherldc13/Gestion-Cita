
namespace Sistema_Barberia
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbMensaje = new System.Windows.Forms.TextBox();
            this.bIniciarSesion = new System.Windows.Forms.Button();
            this.tbClave = new System.Windows.Forms.TextBox();
            this.tbUsuario = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.tbMensaje);
            this.panel1.Controls.Add(this.bIniciarSesion);
            this.panel1.Controls.Add(this.tbClave);
            this.panel1.Controls.Add(this.tbUsuario);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(1, 89);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(566, 162);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // tbMensaje
            // 
            this.tbMensaje.BackColor = System.Drawing.Color.White;
            this.tbMensaje.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbMensaje.Location = new System.Drawing.Point(117, 130);
            this.tbMensaje.Name = "tbMensaje";
            this.tbMensaje.Size = new System.Drawing.Size(232, 13);
            this.tbMensaje.TabIndex = 8;
            this.tbMensaje.TextChanged += new System.EventHandler(this.tbMensaje_TextChanged);
            // 
            // bIniciarSesion
            // 
            this.bIniciarSesion.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bIniciarSesion.Location = new System.Drawing.Point(378, 50);
            this.bIniciarSesion.Name = "bIniciarSesion";
            this.bIniciarSesion.Size = new System.Drawing.Size(107, 34);
            this.bIniciarSesion.TabIndex = 7;
            this.bIniciarSesion.Text = "Iniciar Sesion";
            this.bIniciarSesion.UseVisualStyleBackColor = true;
            this.bIniciarSesion.Click += new System.EventHandler(this.bIniciarSesion_Click);
            // 
            // tbClave
            // 
            this.tbClave.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbClave.Location = new System.Drawing.Point(137, 83);
            this.tbClave.Name = "tbClave";
            this.tbClave.Size = new System.Drawing.Size(201, 25);
            this.tbClave.TabIndex = 6;
            // 
            // tbUsuario
            // 
            this.tbUsuario.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbUsuario.Location = new System.Drawing.Point(137, 26);
            this.tbUsuario.Name = "tbUsuario";
            this.tbUsuario.Size = new System.Drawing.Size(201, 25);
            this.tbUsuario.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(54, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 26);
            this.label3.TabIndex = 4;
            this.label3.Text = "Clave";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(49, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 26);
            this.label2.TabIndex = 3;
            this.label2.Text = "Usuario";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("High Tower Text", 27.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(165, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(381, 42);
            this.label1.TabIndex = 2;
            this.label1.Text = "Sistema Gestor de Citas";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-28, -33);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(187, 119);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click_2);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ClientSize = new System.Drawing.Size(566, 251);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Login_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbClave;
        private System.Windows.Forms.TextBox tbUsuario;
        private System.Windows.Forms.Button bIniciarSesion;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox tbMensaje;
    }
}