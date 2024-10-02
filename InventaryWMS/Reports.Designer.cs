
namespace InventaryWMS
{
    partial class Reports
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.dataReport = new System.Windows.Forms.DataGridView();
            this.buttonPrint = new System.Windows.Forms.Button();
            this.loadingSpinner1 = new InventaryWMS.LoadingSpinner();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.panelCanAutorize = new System.Windows.Forms.Panel();
            this.propsTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxInitialDate = new System.Windows.Forms.TextBox();
            this.textBoxEndDate = new System.Windows.Forms.TextBox();
            this.dateTimePickerEndDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerInitialDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxReportName = new System.Windows.Forms.ComboBox();
            this.buttonCharger = new System.Windows.Forms.Button();
            this.spinner = new InventaryWMS.LoadingSpinner();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataReport)).BeginInit();
            this.panel2.SuspendLayout();
            this.panelCanAutorize.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.dataReport);
            this.panel1.Controls.Add(this.buttonPrint);
            this.panel1.Controls.Add(this.loadingSpinner1);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Location = new System.Drawing.Point(12, 115);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1004, 362);
            this.panel1.TabIndex = 24;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 15.75F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(3, 1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 25);
            this.label3.TabIndex = 81;
            this.label3.Text = "Información";
            // 
            // dataReport
            // 
            this.dataReport.AllowUserToAddRows = false;
            this.dataReport.AllowUserToDeleteRows = false;
            this.dataReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataReport.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataReport.Location = new System.Drawing.Point(10, 52);
            this.dataReport.Name = "dataReport";
            this.dataReport.ReadOnly = true;
            this.dataReport.Size = new System.Drawing.Size(985, 294);
            this.dataReport.TabIndex = 39;
            // 
            // buttonPrint
            // 
            this.buttonPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(47)))), ((int)(((byte)(75)))));
            this.buttonPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonPrint.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.buttonPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPrint.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonPrint.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonPrint.Location = new System.Drawing.Point(909, 15);
            this.buttonPrint.Name = "buttonPrint";
            this.buttonPrint.Size = new System.Drawing.Size(86, 27);
            this.buttonPrint.TabIndex = 37;
            this.buttonPrint.Text = "Imprimir";
            this.buttonPrint.UseVisualStyleBackColor = false;
            this.buttonPrint.Visible = false;
            this.buttonPrint.Click += new System.EventHandler(this.button1_Click);
            // 
            // loadingSpinner1
            // 
            this.loadingSpinner1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.loadingSpinner1.BackColor = System.Drawing.Color.Transparent;
            this.loadingSpinner1.Location = new System.Drawing.Point(864, 6);
            this.loadingSpinner1.MaximumSize = new System.Drawing.Size(40, 40);
            this.loadingSpinner1.MinimumSize = new System.Drawing.Size(40, 40);
            this.loadingSpinner1.Name = "loadingSpinner1";
            this.loadingSpinner1.Size = new System.Drawing.Size(40, 40);
            this.loadingSpinner1.TabIndex = 38;
            this.loadingSpinner1.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.panelCanAutorize);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.comboBoxReportName);
            this.panel2.Controls.Add(this.buttonCharger);
            this.panel2.Controls.Add(this.spinner);
            this.panel2.ForeColor = System.Drawing.SystemColors.GrayText;
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1004, 97);
            this.panel2.TabIndex = 25;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Location = new System.Drawing.Point(15, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 15);
            this.label5.TabIndex = 42;
            this.label5.Text = "Nombre";
            // 
            // panelCanAutorize
            // 
            this.panelCanAutorize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelCanAutorize.Controls.Add(this.propsTitle);
            this.panelCanAutorize.Controls.Add(this.label1);
            this.panelCanAutorize.Controls.Add(this.label2);
            this.panelCanAutorize.Controls.Add(this.textBoxInitialDate);
            this.panelCanAutorize.Controls.Add(this.textBoxEndDate);
            this.panelCanAutorize.Controls.Add(this.dateTimePickerEndDate);
            this.panelCanAutorize.Controls.Add(this.dateTimePickerInitialDate);
            this.panelCanAutorize.Location = new System.Drawing.Point(570, 4);
            this.panelCanAutorize.Name = "panelCanAutorize";
            this.panelCanAutorize.Size = new System.Drawing.Size(288, 89);
            this.panelCanAutorize.TabIndex = 40;
            // 
            // propsTitle
            // 
            this.propsTitle.AutoSize = true;
            this.propsTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.propsTitle.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.propsTitle.Location = new System.Drawing.Point(8, 4);
            this.propsTitle.Name = "propsTitle";
            this.propsTitle.Size = new System.Drawing.Size(72, 15);
            this.propsTitle.TabIndex = 37;
            this.propsTitle.Text = "Propiedades";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(8, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 15);
            this.label1.TabIndex = 38;
            this.label1.Text = "Fecha Inicial";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(8, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 15);
            this.label2.TabIndex = 39;
            this.label2.Text = "Fecha Final";
            // 
            // textBoxInitialDate
            // 
            this.textBoxInitialDate.AccessibleName = "";
            this.textBoxInitialDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBoxInitialDate.Location = new System.Drawing.Point(89, 26);
            this.textBoxInitialDate.Name = "textBoxInitialDate";
            this.textBoxInitialDate.Size = new System.Drawing.Size(167, 23);
            this.textBoxInitialDate.TabIndex = 18;
            this.textBoxInitialDate.TextChanged += new System.EventHandler(this.textBoxInitialDate_TextChanged);
            // 
            // textBoxEndDate
            // 
            this.textBoxEndDate.AccessibleName = "";
            this.textBoxEndDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBoxEndDate.Location = new System.Drawing.Point(89, 55);
            this.textBoxEndDate.Name = "textBoxEndDate";
            this.textBoxEndDate.Size = new System.Drawing.Size(167, 23);
            this.textBoxEndDate.TabIndex = 18;
            // 
            // dateTimePickerEndDate
            // 
            this.dateTimePickerEndDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dateTimePickerEndDate.Location = new System.Drawing.Point(255, 55);
            this.dateTimePickerEndDate.Name = "dateTimePickerEndDate";
            this.dateTimePickerEndDate.Size = new System.Drawing.Size(20, 23);
            this.dateTimePickerEndDate.TabIndex = 19;
            this.dateTimePickerEndDate.ValueChanged += new System.EventHandler(this.dateTimePickerEndDate_ValueChanged);
            // 
            // dateTimePickerInitialDate
            // 
            this.dateTimePickerInitialDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dateTimePickerInitialDate.Location = new System.Drawing.Point(255, 26);
            this.dateTimePickerInitialDate.Name = "dateTimePickerInitialDate";
            this.dateTimePickerInitialDate.Size = new System.Drawing.Size(20, 23);
            this.dateTimePickerInitialDate.TabIndex = 19;
            this.dateTimePickerInitialDate.ValueChanged += new System.EventHandler(this.dateTimePickerInitialDate_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 15.75F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(3, 1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 25);
            this.label4.TabIndex = 41;
            this.label4.Text = "Reporte";
            // 
            // comboBoxReportName
            // 
            this.comboBoxReportName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxReportName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboBoxReportName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxReportName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxReportName.FormattingEnabled = true;
            this.comboBoxReportName.Location = new System.Drawing.Point(72, 37);
            this.comboBoxReportName.Name = "comboBoxReportName";
            this.comboBoxReportName.Size = new System.Drawing.Size(487, 23);
            this.comboBoxReportName.TabIndex = 20;
            this.comboBoxReportName.SelectedIndexChanged += new System.EventHandler(this.comboBoxReportName_SelectedIndexChanged);
            // 
            // buttonCharger
            // 
            this.buttonCharger.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCharger.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(47)))), ((int)(((byte)(75)))));
            this.buttonCharger.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonCharger.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.buttonCharger.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCharger.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonCharger.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonCharger.Location = new System.Drawing.Point(909, 29);
            this.buttonCharger.Name = "buttonCharger";
            this.buttonCharger.Size = new System.Drawing.Size(86, 27);
            this.buttonCharger.TabIndex = 35;
            this.buttonCharger.Text = "Cargar";
            this.buttonCharger.UseVisualStyleBackColor = false;
            this.buttonCharger.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // spinner
            // 
            this.spinner.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.spinner.BackColor = System.Drawing.Color.Transparent;
            this.spinner.Location = new System.Drawing.Point(864, 20);
            this.spinner.MaximumSize = new System.Drawing.Size(40, 40);
            this.spinner.MinimumSize = new System.Drawing.Size(40, 40);
            this.spinner.Name = "spinner";
            this.spinner.Size = new System.Drawing.Size(40, 40);
            this.spinner.TabIndex = 36;
            this.spinner.Visible = false;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackgroundImage = global::InventaryWMS.Properties.Resources.Logo_preview_rev_1__2_;
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel3.Location = new System.Drawing.Point(764, 170);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(736, 346);
            this.panel3.TabIndex = 82;
            // 
            // Reports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(47)))), ((int)(((byte)(75)))));
            this.ClientSize = new System.Drawing.Size(1028, 489);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.SystemColors.GrayText;
            this.Name = "Reports";
            this.Text = "Reportes";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataReport)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panelCanAutorize.ResumeLayout(false);
            this.panelCanAutorize.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonPrint;
        private LoadingSpinner loadingSpinner1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxReportName;
        private System.Windows.Forms.Panel panelCanAutorize;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label propsTitle;
        private System.Windows.Forms.DateTimePicker dateTimePickerEndDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerInitialDate;
        private System.Windows.Forms.TextBox textBoxEndDate;
        private System.Windows.Forms.TextBox textBoxInitialDate;
        private System.Windows.Forms.Button buttonCharger;
        private LoadingSpinner spinner;
        private System.Windows.Forms.DataGridView dataReport;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
    }
}