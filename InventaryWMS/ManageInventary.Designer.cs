namespace ReisWMS
{
    partial class ManageInventary
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.spinner = new ReisWMS.LoadingSpinner();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rackGrid = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ALMACEN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UBICACIÓN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.applyChanges = new System.Windows.Forms.Button();
            this.rackPropertiespanel = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.numRacks = new System.Windows.Forms.NumericUpDown();
            this.cbFormat = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rackGrid)).BeginInit();
            this.rackPropertiespanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRacks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.spinner);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(16, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(905, 100);
            this.panel1.TabIndex = 0;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 15.75F, System.Drawing.FontStyle.Bold);
            this.label15.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label15.Location = new System.Drawing.Point(23, 21);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(305, 25);
            this.label15.TabIndex = 36;
            this.label15.Text = "Administración Global de Inventario";
            // 
            // spinner
            // 
            this.spinner.BackColor = System.Drawing.Color.Transparent;
            this.spinner.Location = new System.Drawing.Point(320, 15);
            this.spinner.MaximumSize = new System.Drawing.Size(40, 40);
            this.spinner.MinimumSize = new System.Drawing.Size(40, 40);
            this.spinner.Name = "spinner";
            this.spinner.Size = new System.Drawing.Size(40, 40);
            this.spinner.TabIndex = 37;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::ReisWMS.Properties.Resources.LOGO_REIS_RGB;
            this.pictureBox1.InitialImage = global::ReisWMS.Properties.Resources.LOGO_REIS_RGB;
            this.pictureBox1.Location = new System.Drawing.Point(787, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 38;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.panel2.Controls.Add(this.rackPropertiespanel);
            this.panel2.Controls.Add(this.applyChanges);
            this.panel2.Controls.Add(this.rackGrid);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(16, 141);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(905, 358);
            this.panel2.TabIndex = 1;
            // 
            // rackGrid
            // 
            this.rackGrid.AllowUserToAddRows = false;
            this.rackGrid.AllowUserToDeleteRows = false;
            this.rackGrid.AllowUserToResizeColumns = false;
            this.rackGrid.AllowUserToResizeRows = false;
            this.rackGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rackGrid.BackgroundColor = System.Drawing.SystemColors.HighlightText;
            this.rackGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rackGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.rackGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.ALMACEN,
            this.UBICACIÓN});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.rackGrid.DefaultCellStyle = dataGridViewCellStyle1;
            this.rackGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.rackGrid.Location = new System.Drawing.Point(28, 44);
            this.rackGrid.Name = "rackGrid";
            this.rackGrid.RowHeadersVisible = false;
            this.rackGrid.RowHeadersWidth = 10;
            this.rackGrid.RowTemplate.Height = 25;
            this.rackGrid.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.rackGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.rackGrid.Size = new System.Drawing.Size(859, 150);
            this.rackGrid.TabIndex = 113;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.HeaderText = "IDPERMISSIONS";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.HeaderText = "CANTIDAD";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.HeaderText = "STATUS";
            this.Column3.Name = "Column3";
            // 
            // ALMACEN
            // 
            this.ALMACEN.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ALMACEN.HeaderText = "ALMACÉN";
            this.ALMACEN.Name = "ALMACEN";
            // 
            // UBICACIÓN
            // 
            this.UBICACIÓN.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.UBICACIÓN.HeaderText = "UBICACIÓN";
            this.UBICACIÓN.Name = "UBICACIÓN";
            // 
            // applyChanges
            // 
            this.applyChanges.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.applyChanges.BackColor = System.Drawing.Color.SteelBlue;
            this.applyChanges.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.applyChanges.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.applyChanges.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.applyChanges.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 9F);
            this.applyChanges.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.applyChanges.Location = new System.Drawing.Point(708, 319);
            this.applyChanges.Name = "applyChanges";
            this.applyChanges.Size = new System.Drawing.Size(165, 26);
            this.applyChanges.TabIndex = 114;
            this.applyChanges.Text = "Realizar movimiento";
            this.applyChanges.UseVisualStyleBackColor = false;
            // 
            // rackPropertiespanel
            // 
            this.rackPropertiespanel.BackColor = System.Drawing.SystemColors.Control;
            this.rackPropertiespanel.Controls.Add(this.numericUpDown1);
            this.rackPropertiespanel.Controls.Add(this.label1);
            this.rackPropertiespanel.Controls.Add(this.comboBox1);
            this.rackPropertiespanel.Controls.Add(this.label7);
            this.rackPropertiespanel.Controls.Add(this.numRacks);
            this.rackPropertiespanel.Controls.Add(this.cbFormat);
            this.rackPropertiespanel.Controls.Add(this.label16);
            this.rackPropertiespanel.Controls.Add(this.label17);
            this.rackPropertiespanel.Controls.Add(this.label18);
            this.rackPropertiespanel.Font = new System.Drawing.Font("Bahnschrift Light SemiCondensed", 9F);
            this.rackPropertiespanel.Location = new System.Drawing.Point(28, 85);
            this.rackPropertiespanel.Name = "rackPropertiespanel";
            this.rackPropertiespanel.Size = new System.Drawing.Size(859, 189);
            this.rackPropertiespanel.TabIndex = 115;
            this.rackPropertiespanel.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 12F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label7.Location = new System.Drawing.Point(18, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(167, 19);
            this.label7.TabIndex = 41;
            this.label7.Text = "Resumen del movimiento";
            // 
            // numRacks
            // 
            this.numRacks.Font = new System.Drawing.Font("Bahnschrift Light SemiCondensed", 12F);
            this.numRacks.ForeColor = System.Drawing.SystemColors.GrayText;
            this.numRacks.InterceptArrowKeys = false;
            this.numRacks.Location = new System.Drawing.Point(92, 43);
            this.numRacks.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numRacks.Name = "numRacks";
            this.numRacks.Size = new System.Drawing.Size(103, 27);
            this.numRacks.TabIndex = 38;
            this.numRacks.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numRacks.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cbFormat
            // 
            this.cbFormat.Font = new System.Drawing.Font("Bahnschrift SemiLight SemiConde", 12F);
            this.cbFormat.ForeColor = System.Drawing.SystemColors.GrayText;
            this.cbFormat.FormattingEnabled = true;
            this.cbFormat.Items.AddRange(new object[] {
            "Numérico - (1, 2, 3...)",
            "Letras -(A, B, C...)"});
            this.cbFormat.Location = new System.Drawing.Point(349, 48);
            this.cbFormat.Name = "cbFormat";
            this.cbFormat.Size = new System.Drawing.Size(194, 27);
            this.cbFormat.TabIndex = 35;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Bahnschrift Light", 9.75F);
            this.label16.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label16.Location = new System.Drawing.Point(594, 54);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(51, 16);
            this.label16.TabIndex = 23;
            this.label16.Text = "Destino";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Bahnschrift Light", 9.75F);
            this.label17.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label17.Location = new System.Drawing.Point(289, 48);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(45, 16);
            this.label17.TabIndex = 21;
            this.label17.Text = "Origen";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Bahnschrift Light", 9.75F);
            this.label18.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label18.Location = new System.Drawing.Point(19, 48);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(57, 16);
            this.label18.TabIndex = 19;
            this.label18.Text = "Cantidad";
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Bahnschrift SemiLight SemiConde", 12F);
            this.comboBox1.ForeColor = System.Drawing.SystemColors.GrayText;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Numérico - (1, 2, 3...)",
            "Letras -(A, B, C...)"});
            this.comboBox1.Location = new System.Drawing.Point(651, 48);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(194, 27);
            this.comboBox1.TabIndex = 42;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Font = new System.Drawing.Font("Bahnschrift Light SemiCondensed", 12F);
            this.numericUpDown1.ForeColor = System.Drawing.SystemColors.GrayText;
            this.numericUpDown1.InterceptArrowKeys = false;
            this.numericUpDown1.Location = new System.Drawing.Point(92, 88);
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(103, 27);
            this.numericUpDown1.TabIndex = 44;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift Light", 9.75F);
            this.label1.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label1.Location = new System.Drawing.Point(19, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 16);
            this.label1.TabIndex = 43;
            this.label1.Text = "Lote";
            // 
            // ManageInventary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(937, 515);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ManageInventary";
            this.Padding = new System.Windows.Forms.Padding(16);
            this.Text = "Administración de Inventario";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rackGrid)).EndInit();
            this.rackPropertiespanel.ResumeLayout(false);
            this.rackPropertiespanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRacks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label15;
        private LoadingSpinner spinner;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView rackGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn ALMACEN;
        private System.Windows.Forms.DataGridViewTextBoxColumn UBICACIÓN;
        private System.Windows.Forms.Button applyChanges;
        private System.Windows.Forms.Panel rackPropertiespanel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numRacks;
        private System.Windows.Forms.ComboBox cbFormat;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}