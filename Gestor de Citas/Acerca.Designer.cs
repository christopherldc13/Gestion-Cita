namespace Gestor_de_Citas
{
    partial class Acerca
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Acerca));
            this.panel1 = new System.Windows.Forms.Panel();
            this.PTitulo = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.contacto = new System.Windows.Forms.Button();
            this.acercade = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.PTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Location = new System.Drawing.Point(0, 85);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(799, 363);
            this.panel1.TabIndex = 0;
            // 
            // PTitulo
            // 
            this.PTitulo.BackColor = System.Drawing.SystemColors.Control;
            this.PTitulo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PTitulo.Controls.Add(this.button1);
            this.PTitulo.Controls.Add(this.contacto);
            this.PTitulo.Controls.Add(this.acercade);
            this.PTitulo.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.PTitulo.Location = new System.Drawing.Point(152, -9);
            this.PTitulo.Name = "PTitulo";
            this.PTitulo.Size = new System.Drawing.Size(655, 107);
            this.PTitulo.TabIndex = 64;
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.Location = new System.Drawing.Point(523, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 30);
            this.button1.TabIndex = 3;
            this.button1.Text = "Salir";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // contacto
            // 
            this.contacto.FlatAppearance.BorderSize = 0;
            this.contacto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.contacto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contacto.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.contacto.Location = new System.Drawing.Point(283, 38);
            this.contacto.Name = "contacto";
            this.contacto.Size = new System.Drawing.Size(100, 30);
            this.contacto.TabIndex = 2;
            this.contacto.Text = "Contacto";
            this.contacto.UseVisualStyleBackColor = true;
            this.contacto.Click += new System.EventHandler(this.contacto_Click);
            // 
            // acercade
            // 
            this.acercade.FlatAppearance.BorderSize = 0;
            this.acercade.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.acercade.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.acercade.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.acercade.Location = new System.Drawing.Point(87, 38);
            this.acercade.Name = "acercade";
            this.acercade.Size = new System.Drawing.Size(89, 30);
            this.acercade.TabIndex = 1;
            this.acercade.Text = "Acerca de";
            this.acercade.UseVisualStyleBackColor = true;
            this.acercade.Click += new System.EventHandler(this.acercade_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(2, -5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(173, 97);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // Acerca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.PTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Acerca";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Acerca";
            this.Load += new System.EventHandler(this.Acerca_Load_1);
            this.PTitulo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel PTitulo;
        private System.Windows.Forms.Button contacto;
        private System.Windows.Forms.Button acercade;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}