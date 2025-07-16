
namespace Gestor_de_Citas
{
    partial class ReporteCitaPorEmpleado
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReporteCitaPorEmpleado));
            this.CitaPorEmpleadoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSetCitaPorEmpleado = new Gestor_de_Citas.DataSetCitaPorEmpleado();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.PTitulo = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.cbFiltroFecha = new System.Windows.Forms.ComboBox();
            this.cbEmpleado = new System.Windows.Forms.ComboBox();
            this.Bbuscar = new System.Windows.Forms.Button();
            this.CitaPorEmpleadoTableAdapter = new Gestor_de_Citas.DataSetCitaPorEmpleadoTableAdapters.CitaPorEmpleadoTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.CitaPorEmpleadoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetCitaPorEmpleado)).BeginInit();
            this.PTitulo.SuspendLayout();
            this.SuspendLayout();
            // 
            // CitaPorEmpleadoBindingSource
            // 
            this.CitaPorEmpleadoBindingSource.DataMember = "CitaPorEmpleado";
            this.CitaPorEmpleadoBindingSource.DataSource = this.DataSetCitaPorEmpleado;
            // 
            // DataSetCitaPorEmpleado
            // 
            this.DataSetCitaPorEmpleado.DataSetName = "DataSetCitaPorEmpleado";
            this.DataSetCitaPorEmpleado.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(351, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 22);
            this.label3.TabIndex = 61;
            this.label3.Text = "Filtrar por:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(50, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 22);
            this.label2.TabIndex = 60;
            this.label2.Text = "Empleado: ";
            // 
            // PTitulo
            // 
            this.PTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(107)))), ((int)(((byte)(123)))));
            this.PTitulo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PTitulo.Controls.Add(this.label1);
            this.PTitulo.Location = new System.Drawing.Point(-7, 0);
            this.PTitulo.Name = "PTitulo";
            this.PTitulo.Size = new System.Drawing.Size(814, 66);
            this.PTitulo.TabIndex = 59;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(117, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(570, 38);
            this.label1.TabIndex = 1;
            this.label1.Text = "Reporte de Citas por Empleado";
            // 
            // reportViewer1
            // 
            this.reportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            reportDataSource3.Name = "DataSetCitaPorEmpleado";
            reportDataSource3.Value = this.CitaPorEmpleadoBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Gestor_de_Citas.ReporteCitaPorEmpleado.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(-1, 136);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(807, 315);
            this.reportViewer1.TabIndex = 58;
            // 
            // cbFiltroFecha
            // 
            this.cbFiltroFecha.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.cbFiltroFecha.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFiltroFecha.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbFiltroFecha.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFiltroFecha.FormattingEnabled = true;
            this.cbFiltroFecha.Items.AddRange(new object[] {
            "Hoy",
            "Semana",
            "Mes"});
            this.cbFiltroFecha.Location = new System.Drawing.Point(444, 88);
            this.cbFiltroFecha.Name = "cbFiltroFecha";
            this.cbFiltroFecha.Size = new System.Drawing.Size(124, 25);
            this.cbFiltroFecha.TabIndex = 57;
            // 
            // cbEmpleado
            // 
            this.cbEmpleado.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.cbEmpleado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEmpleado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbEmpleado.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbEmpleado.FormattingEnabled = true;
            this.cbEmpleado.Location = new System.Drawing.Point(135, 88);
            this.cbEmpleado.Name = "cbEmpleado";
            this.cbEmpleado.Size = new System.Drawing.Size(182, 25);
            this.cbEmpleado.TabIndex = 56;
            // 
            // Bbuscar
            // 
            this.Bbuscar.FlatAppearance.BorderSize = 0;
            this.Bbuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Bbuscar.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Bbuscar.Image = ((System.Drawing.Image)(resources.GetObject("Bbuscar.Image")));
            this.Bbuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Bbuscar.Location = new System.Drawing.Point(632, 80);
            this.Bbuscar.Name = "Bbuscar";
            this.Bbuscar.Size = new System.Drawing.Size(86, 40);
            this.Bbuscar.TabIndex = 55;
            this.Bbuscar.Text = "Buscar";
            this.Bbuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Bbuscar.UseVisualStyleBackColor = true;
            this.Bbuscar.Click += new System.EventHandler(this.Bbuscar_Click);
            // 
            // CitaPorEmpleadoTableAdapter
            // 
            this.CitaPorEmpleadoTableAdapter.ClearBeforeFill = true;
            // 
            // ReporteCitaPorEmpleado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PTitulo);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.cbFiltroFecha);
            this.Controls.Add(this.cbEmpleado);
            this.Controls.Add(this.Bbuscar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReporteCitaPorEmpleado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte de Citas";
            this.Load += new System.EventHandler(this.ReporteCitaPorEmpleado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CitaPorEmpleadoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetCitaPorEmpleado)).EndInit();
            this.PTitulo.ResumeLayout(false);
            this.PTitulo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel PTitulo;
        private System.Windows.Forms.Label label1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.ComboBox cbFiltroFecha;
        private System.Windows.Forms.ComboBox cbEmpleado;
        private System.Windows.Forms.Button Bbuscar;
        private System.Windows.Forms.BindingSource CitaPorEmpleadoBindingSource;
        private DataSetCitaPorEmpleado DataSetCitaPorEmpleado;
        private DataSetCitaPorEmpleadoTableAdapters.CitaPorEmpleadoTableAdapter CitaPorEmpleadoTableAdapter;
    }
}