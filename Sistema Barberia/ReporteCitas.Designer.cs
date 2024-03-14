
namespace Sistema_Barberia
{
    partial class ReporteCitas
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReporteCitas));
            this.CitaConsultarBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DBCitaDataSetCita = new Sistema_Barberia.DBCitaDataSetCita();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.CitaConsultarTableAdapter = new Sistema_Barberia.DBCitaDataSetCitaTableAdapters.CitaConsultarTableAdapter();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Buscar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.CitaConsultarBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DBCitaDataSetCita)).BeginInit();
            this.SuspendLayout();
            // 
            // CitaConsultarBindingSource
            // 
            this.CitaConsultarBindingSource.DataMember = "CitaConsultar";
            this.CitaConsultarBindingSource.DataSource = this.DBCitaDataSetCita;
            // 
            // DBCitaDataSetCita
            // 
            this.DBCitaDataSetCita.DataSetName = "DBCitaDataSetCita";
            this.DBCitaDataSetCita.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.CitaConsultarBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Sistema_Barberia.ReportesCitas.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 69);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(666, 369);
            this.reportViewer1.TabIndex = 0;
            // 
            // CitaConsultarTableAdapter
            // 
            this.CitaConsultarTableAdapter.ClearBeforeFill = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(76, 24);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(115, 20);
            this.textBox1.TabIndex = 1;
            // 
            // Buscar
            // 
            this.Buscar.Location = new System.Drawing.Point(247, 24);
            this.Buscar.Name = "Buscar";
            this.Buscar.Size = new System.Drawing.Size(75, 23);
            this.Buscar.TabIndex = 2;
            this.Buscar.Text = "Buscar";
            this.Buscar.UseVisualStyleBackColor = true;
            this.Buscar.Click += new System.EventHandler(this.Buscar_Click);
            // 
            // ReporteCitas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 450);
            this.Controls.Add(this.Buscar);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReporteCitas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InformeCitas";
            this.Load += new System.EventHandler(this.InformeCitas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CitaConsultarBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DBCitaDataSetCita)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource CitaConsultarBindingSource;
        private DBCitaDataSetCita DBCitaDataSetCita;
        private DBCitaDataSetCitaTableAdapters.CitaConsultarTableAdapter CitaConsultarTableAdapter;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button Buscar;
    }
}