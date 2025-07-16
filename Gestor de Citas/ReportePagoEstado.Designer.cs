
namespace Gestor_de_Citas
{
    partial class ReportePagoEstado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportePagoEstado));
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.PagoEstadoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSetPagoEstado = new Gestor_de_Citas.DataSetPagoEstado();
            this.Bbuscar = new System.Windows.Forms.Button();
            this.cbEstado = new System.Windows.Forms.ComboBox();
            this.cbFiltroFecha = new System.Windows.Forms.ComboBox();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.PagoEstadoTableAdapter = new Gestor_de_Citas.DataSetPagoEstadoTableAdapters.PagoEstadoTableAdapter();
            this.PTitulo = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PagoEstadoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetPagoEstado)).BeginInit();
            this.PTitulo.SuspendLayout();
            this.SuspendLayout();
            // 
            // PagoEstadoBindingSource
            // 
            this.PagoEstadoBindingSource.DataMember = "PagoEstado";
            this.PagoEstadoBindingSource.DataSource = this.DataSetPagoEstado;
            // 
            // DataSetPagoEstado
            // 
            this.DataSetPagoEstado.DataSetName = "DataSetPagoEstado";
            this.DataSetPagoEstado.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Bbuscar
            // 
            this.Bbuscar.FlatAppearance.BorderSize = 0;
            this.Bbuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Bbuscar.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Bbuscar.Image = ((System.Drawing.Image)(resources.GetObject("Bbuscar.Image")));
            this.Bbuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Bbuscar.Location = new System.Drawing.Point(616, 79);
            this.Bbuscar.Name = "Bbuscar";
            this.Bbuscar.Size = new System.Drawing.Size(90, 40);
            this.Bbuscar.TabIndex = 0;
            this.Bbuscar.Text = "Buscar";
            this.Bbuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Bbuscar.UseVisualStyleBackColor = true;
            this.Bbuscar.Click += new System.EventHandler(this.Bbuscar_Click);
            // 
            // cbEstado
            // 
            this.cbEstado.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.cbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbEstado.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbEstado.FormattingEnabled = true;
            this.cbEstado.Items.AddRange(new object[] {
            "Pagado",
            "Pendiente"});
            this.cbEstado.Location = new System.Drawing.Point(95, 87);
            this.cbEstado.Name = "cbEstado";
            this.cbEstado.Size = new System.Drawing.Size(130, 25);
            this.cbEstado.TabIndex = 1;
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
            this.cbFiltroFecha.Location = new System.Drawing.Point(399, 88);
            this.cbFiltroFecha.Name = "cbFiltroFecha";
            this.cbFiltroFecha.Size = new System.Drawing.Size(128, 25);
            this.cbFiltroFecha.TabIndex = 2;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSetPagoEstado";
            reportDataSource1.Value = this.PagoEstadoBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Gestor_de_Citas.ReportePagoEstado.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(-4, 135);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(811, 315);
            this.reportViewer1.TabIndex = 3;
            // 
            // PagoEstadoTableAdapter
            // 
            this.PagoEstadoTableAdapter.ClearBeforeFill = true;
            // 
            // PTitulo
            // 
            this.PTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(107)))), ((int)(((byte)(123)))));
            this.PTitulo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PTitulo.Controls.Add(this.label1);
            this.PTitulo.Location = new System.Drawing.Point(-4, -1);
            this.PTitulo.Name = "PTitulo";
            this.PTitulo.Size = new System.Drawing.Size(829, 66);
            this.PTitulo.TabIndex = 45;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(147, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(534, 38);
            this.label1.TabIndex = 1;
            this.label1.Text = "Reporte de Pagos por Estado";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 22);
            this.label2.TabIndex = 46;
            this.label2.Text = "Estado: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(313, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 22);
            this.label3.TabIndex = 47;
            this.label3.Text = "Filtrar por:";
            // 
            // ReportePagoEstado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PTitulo);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.cbFiltroFecha);
            this.Controls.Add(this.cbEstado);
            this.Controls.Add(this.Bbuscar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReportePagoEstado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReportePagoEstado";
            this.Load += new System.EventHandler(this.ReportePagoEstado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PagoEstadoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetPagoEstado)).EndInit();
            this.PTitulo.ResumeLayout(false);
            this.PTitulo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Bbuscar;
        private System.Windows.Forms.ComboBox cbEstado;
        private System.Windows.Forms.ComboBox cbFiltroFecha;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource PagoEstadoBindingSource;
        private DataSetPagoEstado DataSetPagoEstado;
        private DataSetPagoEstadoTableAdapters.PagoEstadoTableAdapter PagoEstadoTableAdapter;
        private System.Windows.Forms.Panel PTitulo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}