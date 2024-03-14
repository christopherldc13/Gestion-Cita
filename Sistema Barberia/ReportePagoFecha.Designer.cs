
namespace Sistema_Barberia
{
    partial class ReportePagoFecha
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.DBCitaDataSetPagoFecha = new Sistema_Barberia.DBCitaDataSetPagoFecha();
            this.PagoFechaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PagoFechaTableAdapter = new Sistema_Barberia.DBCitaDataSetPagoFechaTableAdapters.PagoFechaTableAdapter();
            this.FechaPicker1 = new System.Windows.Forms.DateTimePicker();
            this.FechaPicker2 = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.DBCitaDataSetPagoFecha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PagoFechaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // DBCitaDataSetPagoFecha
            // 
            this.DBCitaDataSetPagoFecha.DataSetName = "DBCitaDataSetPagoFecha";
            this.DBCitaDataSetPagoFecha.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // PagoFechaBindingSource
            // 
            this.PagoFechaBindingSource.DataMember = "PagoFecha";
            this.PagoFechaBindingSource.DataSource = this.DBCitaDataSetPagoFecha;
            // 
            // PagoFechaTableAdapter
            // 
            this.PagoFechaTableAdapter.ClearBeforeFill = true;
            // 
            // FechaPicker1
            // 
            this.FechaPicker1.Location = new System.Drawing.Point(61, 22);
            this.FechaPicker1.Name = "FechaPicker1";
            this.FechaPicker1.Size = new System.Drawing.Size(200, 20);
            this.FechaPicker1.TabIndex = 1;
            // 
            // FechaPicker2
            // 
            this.FechaPicker2.Location = new System.Drawing.Point(61, 62);
            this.FechaPicker2.Name = "FechaPicker2";
            this.FechaPicker2.Size = new System.Drawing.Size(200, 20);
            this.FechaPicker2.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(367, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 45);
            this.button1.TabIndex = 3;
            this.button1.Text = "Buscar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // reportViewer1
            // 
            reportDataSource4.Name = "DataSet1";
            reportDataSource4.Value = this.PagoFechaBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource4);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Sistema_Barberia.ReportePagoFecha.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 112);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(707, 326);
            this.reportViewer1.TabIndex = 4;
            // 
            // ReportePagoFecha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 450);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.FechaPicker2);
            this.Controls.Add(this.FechaPicker1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReportePagoFecha";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReportePagoFecha";
            this.Load += new System.EventHandler(this.ReportePagoFecha_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DBCitaDataSetPagoFecha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PagoFechaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource PagoFechaBindingSource;
        private DBCitaDataSetPagoFecha DBCitaDataSetPagoFecha;
        private DBCitaDataSetPagoFechaTableAdapters.PagoFechaTableAdapter PagoFechaTableAdapter;
        private System.Windows.Forms.DateTimePicker FechaPicker1;
        private System.Windows.Forms.DateTimePicker FechaPicker2;
        private System.Windows.Forms.Button button1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}