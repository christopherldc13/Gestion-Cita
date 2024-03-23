
namespace Sistema_Barberia
{
    partial class FPagoFecha
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.DBCitaDataSetPagoCita = new Sistema_Barberia.DBCitaDataSetPagoCita();
            this.PagoFechaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PagoFechaTableAdapter = new Sistema_Barberia.DBCitaDataSetPagoCitaTableAdapters.PagoFechaTableAdapter();
            this.dtpFecha1 = new System.Windows.Forms.DateTimePicker();
            this.dtpFecha2 = new System.Windows.Forms.DateTimePicker();
            this.bBuscar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DBCitaDataSetPagoCita)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PagoFechaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.PagoFechaBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Sistema_Barberia.ReportePagoFecha.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 104);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(756, 334);
            this.reportViewer1.TabIndex = 0;
            // 
            // DBCitaDataSetPagoCita
            // 
            this.DBCitaDataSetPagoCita.DataSetName = "DBCitaDataSetPagoCita";
            this.DBCitaDataSetPagoCita.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // PagoFechaBindingSource
            // 
            this.PagoFechaBindingSource.DataMember = "PagoFecha";
            this.PagoFechaBindingSource.DataSource = this.DBCitaDataSetPagoCita;
            // 
            // PagoFechaTableAdapter
            // 
            this.PagoFechaTableAdapter.ClearBeforeFill = true;
            // 
            // dtpFecha1
            // 
            this.dtpFecha1.Location = new System.Drawing.Point(67, 13);
            this.dtpFecha1.Name = "dtpFecha1";
            this.dtpFecha1.Size = new System.Drawing.Size(200, 20);
            this.dtpFecha1.TabIndex = 1;
            // 
            // dtpFecha2
            // 
            this.dtpFecha2.Location = new System.Drawing.Point(67, 62);
            this.dtpFecha2.Name = "dtpFecha2";
            this.dtpFecha2.Size = new System.Drawing.Size(200, 20);
            this.dtpFecha2.TabIndex = 2;
            // 
            // bBuscar
            // 
            this.bBuscar.Location = new System.Drawing.Point(426, 29);
            this.bBuscar.Name = "bBuscar";
            this.bBuscar.Size = new System.Drawing.Size(75, 23);
            this.bBuscar.TabIndex = 3;
            this.bBuscar.Text = "Buscar";
            this.bBuscar.UseVisualStyleBackColor = true;
            this.bBuscar.Click += new System.EventHandler(this.bBuscar_Click);
            // 
            // FPagoFecha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.bBuscar);
            this.Controls.Add(this.dtpFecha2);
            this.Controls.Add(this.dtpFecha1);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FPagoFecha";
            this.Text = "FPagoFecha";
            this.Load += new System.EventHandler(this.FPagoFecha_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DBCitaDataSetPagoCita)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PagoFechaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource PagoFechaBindingSource;
        private DBCitaDataSetPagoCita DBCitaDataSetPagoCita;
        private DBCitaDataSetPagoCitaTableAdapters.PagoFechaTableAdapter PagoFechaTableAdapter;
        private System.Windows.Forms.DateTimePicker dtpFecha1;
        private System.Windows.Forms.DateTimePicker dtpFecha2;
        private System.Windows.Forms.Button bBuscar;
    }
}