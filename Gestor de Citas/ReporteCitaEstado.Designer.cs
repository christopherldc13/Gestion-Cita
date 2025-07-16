
namespace Gestor_de_Citas
{
    partial class ReporteCitaEstado
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource8 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReporteCitaEstado));
            this.CitaEstadoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSetCitaEstado = new Gestor_de_Citas.DataSetCitaEstado();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.PTitulo = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.cbFiltroFecha = new System.Windows.Forms.ComboBox();
            this.cbEstado = new System.Windows.Forms.ComboBox();
            this.CitaEstadoTableAdapter = new Gestor_de_Citas.DataSetCitaEstadoTableAdapters.CitaEstadoTableAdapter();
            this.Bbuscar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.CitaEstadoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetCitaEstado)).BeginInit();
            this.PTitulo.SuspendLayout();
            this.SuspendLayout();
            // 
            // CitaEstadoBindingSource
            // 
            this.CitaEstadoBindingSource.DataMember = "CitaEstado";
            this.CitaEstadoBindingSource.DataSource = this.DataSetCitaEstado;
            // 
            // DataSetCitaEstado
            // 
            this.DataSetCitaEstado.DataSetName = "DataSetCitaEstado";
            this.DataSetCitaEstado.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(313, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 22);
            this.label3.TabIndex = 54;
            this.label3.Text = "Filtrar por:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(58, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 22);
            this.label2.TabIndex = 53;
            this.label2.Text = "Estado: ";
            // 
            // PTitulo
            // 
            this.PTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(107)))), ((int)(((byte)(123)))));
            this.PTitulo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PTitulo.Controls.Add(this.label1);
            this.PTitulo.Location = new System.Drawing.Point(-7, 0);
            this.PTitulo.Name = "PTitulo";
            this.PTitulo.Size = new System.Drawing.Size(822, 66);
            this.PTitulo.TabIndex = 52;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(151, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(516, 38);
            this.label1.TabIndex = 1;
            this.label1.Text = "Reporte de Citas por Estado";
            // 
            // reportViewer1
            // 
            this.reportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            reportDataSource8.Name = "DataSetCitaEstado";
            reportDataSource8.Value = this.CitaEstadoBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource8);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Gestor_de_Citas.ReporteCitaEstado.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(-1, 136);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(802, 315);
            this.reportViewer1.TabIndex = 51;
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
            this.cbFiltroFecha.Location = new System.Drawing.Point(414, 88);
            this.cbFiltroFecha.Name = "cbFiltroFecha";
            this.cbFiltroFecha.Size = new System.Drawing.Size(124, 25);
            this.cbFiltroFecha.TabIndex = 50;
            // 
            // cbEstado
            // 
            this.cbEstado.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.cbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbEstado.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbEstado.FormattingEnabled = true;
            this.cbEstado.Items.AddRange(new object[] {
            "Realizada",
            "No Realizada",
            "Pendiente",
            "Cancelada"});
            this.cbEstado.Location = new System.Drawing.Point(138, 88);
            this.cbEstado.Name = "cbEstado";
            this.cbEstado.Size = new System.Drawing.Size(131, 25);
            this.cbEstado.TabIndex = 49;
            // 
            // CitaEstadoTableAdapter
            // 
            this.CitaEstadoTableAdapter.ClearBeforeFill = true;
            // 
            // Bbuscar
            // 
            this.Bbuscar.FlatAppearance.BorderSize = 0;
            this.Bbuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Bbuscar.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Bbuscar.Image = ((System.Drawing.Image)(resources.GetObject("Bbuscar.Image")));
            this.Bbuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Bbuscar.Location = new System.Drawing.Point(613, 80);
            this.Bbuscar.Name = "Bbuscar";
            this.Bbuscar.Size = new System.Drawing.Size(86, 40);
            this.Bbuscar.TabIndex = 48;
            this.Bbuscar.Text = "Buscar";
            this.Bbuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Bbuscar.UseVisualStyleBackColor = true;
            this.Bbuscar.Click += new System.EventHandler(this.Bbuscar_Click);
            // 
            // ReporteCitaEstado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PTitulo);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.cbFiltroFecha);
            this.Controls.Add(this.cbEstado);
            this.Controls.Add(this.Bbuscar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReporteCitaEstado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte de Citas";
            this.Load += new System.EventHandler(this.ReporteCitaEstado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CitaEstadoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetCitaEstado)).EndInit();
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
        private System.Windows.Forms.ComboBox cbEstado;
        private System.Windows.Forms.Button Bbuscar;
        private System.Windows.Forms.BindingSource CitaEstadoBindingSource;
        private DataSetCitaEstado DataSetCitaEstado;
        private DataSetCitaEstadoTableAdapters.CitaEstadoTableAdapter CitaEstadoTableAdapter;
    }
}