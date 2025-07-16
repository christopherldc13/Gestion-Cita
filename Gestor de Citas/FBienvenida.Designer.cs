
namespace Gestor_de_Citas
{
    partial class FBienvenida
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FBienvenida));
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.bContinuar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bSalir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 29.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(43, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(251, 52);
            this.label2.TabIndex = 11;
            this.label2.Text = "Bienvenido/a";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(521, 40);
            this.label3.TabIndex = 12;
            this.label3.Text = "Bienvenido al Sistema de Gestión de Citas. Has iniciado sesión correctamente.\nSi " +
    "deseas continuar, haz clic en Continuar. Si prefieres salir, selecciona Salir.";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // bContinuar
            // 
            this.bContinuar.FlatAppearance.BorderSize = 0;
            this.bContinuar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bContinuar.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bContinuar.Image = ((System.Drawing.Image)(resources.GetObject("bContinuar.Image")));
            this.bContinuar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bContinuar.Location = new System.Drawing.Point(79, 7);
            this.bContinuar.Name = "bContinuar";
            this.bContinuar.Size = new System.Drawing.Size(124, 43);
            this.bContinuar.TabIndex = 14;
            this.bContinuar.Text = "Continuar...";
            this.bContinuar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bContinuar.UseVisualStyleBackColor = true;
            this.bContinuar.Click += new System.EventHandler(this.bContinuar_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Controls.Add(this.bSalir);
            this.panel1.Controls.Add(this.bContinuar);
            this.panel1.Location = new System.Drawing.Point(-5, 228);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(560, 66);
            this.panel1.TabIndex = 15;
            // 
            // bSalir
            // 
            this.bSalir.FlatAppearance.BorderSize = 0;
            this.bSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bSalir.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bSalir.Image = ((System.Drawing.Image)(resources.GetObject("bSalir.Image")));
            this.bSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bSalir.Location = new System.Drawing.Point(374, 7);
            this.bSalir.Name = "bSalir";
            this.bSalir.Size = new System.Drawing.Size(79, 43);
            this.bSalir.TabIndex = 15;
            this.bSalir.Text = "Salir";
            this.bSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bSalir.UseVisualStyleBackColor = true;
            this.bSalir.Click += new System.EventHandler(this.bSalir_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 27.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(74, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(413, 49);
            this.label1.TabIndex = 16;
            this.label1.Text = "Sistema Gestor de Citas";
            // 
            // FBienvenida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(548, 286);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FBienvenida";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bienvenida";
            this.Load += new System.EventHandler(this.FBienvenida_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FBienvenida_KeyDown);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bContinuar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button bSalir;
        private System.Windows.Forms.Label label1;
    }
}