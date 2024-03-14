
namespace Sistema_Barberia
{
    partial class ReportesPagos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportesPagos));
            this.PagoConsultarBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DBCitaDataSetPagos = new Sistema_Barberia.DBCitaDataSetPagos();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.button1 = new System.Windows.Forms.Button();
            this.tbValor = new System.Windows.Forms.TextBox();
            this.PagoConsultarTableAdapter = new Sistema_Barberia.DBCitaDataSetPagosTableAdapters.PagoConsultarTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.PagoConsultarBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DBCitaDataSetPagos)).BeginInit();
            this.SuspendLayout();
            // 
            // PagoConsultarBindingSource
            // 
            this.PagoConsultarBindingSource.DataMember = "PagoConsultar";
            this.PagoConsultarBindingSource.DataSource = this.DBCitaDataSetPagos;
            // 
            // DBCitaDataSetPagos
            // 
            this.DBCitaDataSetPagos.DataSetName = "DBCitaDataSetPagos";
            this.DBCitaDataSetPagos.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.PagoConsultarBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Sistema_Barberia.ReportePagos.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 79);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(776, 359);
            this.reportViewer1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(221, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 42);
            this.button1.TabIndex = 1;
            this.button1.Text = "Buscar";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbValor
            // 
            this.tbValor.Location = new System.Drawing.Point(46, 24);
            this.tbValor.Name = "tbValor";
            this.tbValor.Size = new System.Drawing.Size(139, 20);
            this.tbValor.TabIndex = 2;
            // 
            // PagoConsultarTableAdapter
            // 
            this.PagoConsultarTableAdapter.ClearBeforeFill = true;
            // 
            // ReportesPagos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tbValor);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReportesPagos";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReportesPagos";
            this.Load += new System.EventHandler(this.ReportesPagos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PagoConsultarBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DBCitaDataSetPagos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource PagoConsultarBindingSource;
        private DBCitaDataSetPagos DBCitaDataSetPagos;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbValor;
        private DBCitaDataSetPagosTableAdapters.PagoConsultarTableAdapter PagoConsultarTableAdapter;
    }
}