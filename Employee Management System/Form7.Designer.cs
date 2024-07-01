namespace Employee_Management_System
{
    partial class ReportDisplay
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
            this.employeetableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Employee_databaseDataSet = new Employee_Management_System.Employee_databaseDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.employeetableTableAdapter = new Employee_Management_System.Employee_databaseDataSetTableAdapters.employeetableTableAdapter();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.employeetableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Employee_databaseDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // employeetableBindingSource
            // 
            this.employeetableBindingSource.DataMember = "employeetable";
            this.employeetableBindingSource.DataSource = this.Employee_databaseDataSet;
            // 
            // Employee_databaseDataSet
            // 
            this.Employee_databaseDataSet.DataSetName = "Employee_databaseDataSet";
            this.Employee_databaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.employeetableBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Employee_Management_System.EmployeeReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 29);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(935, 562);
            this.reportViewer1.TabIndex = 0;
            // 
            // employeetableTableAdapter
            // 
            this.employeetableTableAdapter.ClearBeforeFill = true;
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::Employee_Management_System.Properties.Resources.arrow_back_left_icon_123728;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(894, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(29, 21);
            this.button1.TabIndex = 1;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ReportDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(935, 591);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.reportViewer1);
            this.Name = "ReportDisplay";
            this.Text = "Report Display";
            this.Load += new System.EventHandler(this.ReportDisplay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.employeetableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Employee_databaseDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource employeetableBindingSource;
        private Employee_databaseDataSet Employee_databaseDataSet;
        private Employee_databaseDataSetTableAdapters.employeetableTableAdapter employeetableTableAdapter;
        private System.Windows.Forms.Button button1;
    }
}