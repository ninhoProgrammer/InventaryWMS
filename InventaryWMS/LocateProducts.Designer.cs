namespace InventaryWMS
{
    partial class LocateProducts
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.saveBtn = new System.Windows.Forms.Button();
            this.targetDataGrid = new System.Windows.Forms.DataGridView();
            this.labelInfo = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.propsTitle = new System.Windows.Forms.Label();
            this.cbDestino = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.okButton = new System.Windows.Forms.Button();
            this.pasteButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.addRowBtn = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.pbInfo = new System.Windows.Forms.Panel();
            this.deleteRowButton = new System.Windows.Forms.Button();
            this.whListSpinner = new InventaryWMS.LoadingSpinner();
            this.pasteSpinner = new InventaryWMS.LoadingSpinner();
            this.spinnerStatus = new InventaryWMS.LoadingSpinner();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.targetDataGrid)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // saveBtn
            // 
            this.saveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(47)))), ((int)(((byte)(75)))));
            this.saveBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.saveBtn.Enabled = false;
            this.saveBtn.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.saveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveBtn.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 9F);
            this.saveBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.saveBtn.Location = new System.Drawing.Point(526, 253);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(86, 26);
            this.saveBtn.TabIndex = 45;
            this.saveBtn.Text = "Finalizar";
            this.saveBtn.UseVisualStyleBackColor = false;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // targetDataGrid
            // 
            this.targetDataGrid.AllowDrop = true;
            this.targetDataGrid.AllowUserToAddRows = false;
            this.targetDataGrid.AllowUserToDeleteRows = false;
            this.targetDataGrid.AllowUserToResizeColumns = false;
            this.targetDataGrid.AllowUserToResizeRows = false;
            this.targetDataGrid.BackgroundColor = System.Drawing.SystemColors.HighlightText;
            this.targetDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Bahnschrift SemiBold Condensed", 11F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.targetDataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.targetDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.targetDataGrid.DefaultCellStyle = dataGridViewCellStyle4;
            this.targetDataGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.targetDataGrid.Location = new System.Drawing.Point(6, 47);
            this.targetDataGrid.Name = "targetDataGrid";
            this.targetDataGrid.RowHeadersVisible = false;
            this.targetDataGrid.RowHeadersWidth = 10;
            this.targetDataGrid.RowTemplate.Height = 25;
            this.targetDataGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.targetDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.targetDataGrid.Size = new System.Drawing.Size(606, 200);
            this.targetDataGrid.TabIndex = 114;
            this.targetDataGrid.DragDrop += new System.Windows.Forms.DragEventHandler(this.targetDataGrid_DragDrop);
            this.targetDataGrid.DragEnter += new System.Windows.Forms.DragEventHandler(this.targetDataGrid_DragEnter);
            // 
            // labelInfo
            // 
            this.labelInfo.AllowDrop = true;
            this.labelInfo.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelInfo.Font = new System.Drawing.Font("Bahnschrift Light", 9.75F);
            this.labelInfo.ForeColor = System.Drawing.SystemColors.GrayText;
            this.labelInfo.Location = new System.Drawing.Point(203, 139);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(216, 42);
            this.labelInfo.TabIndex = 115;
            this.labelInfo.Text = "Arrastre aquí el archivo Excel o pegue los datos";
            this.labelInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelInfo.DragDrop += new System.Windows.Forms.DragEventHandler(this.targetDataGrid_DragDrop);
            this.labelInfo.DragEnter += new System.Windows.Forms.DragEventHandler(this.targetDataGrid_DragEnter);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel2.Controls.Add(this.propsTitle);
            this.panel2.Controls.Add(this.cbDestino);
            this.panel2.Controls.Add(this.whListSpinner);
            this.panel2.Controls.Add(this.label16);
            this.panel2.Location = new System.Drawing.Point(16, 16);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(623, 81);
            this.panel2.TabIndex = 122;
            // 
            // propsTitle
            // 
            this.propsTitle.AutoSize = true;
            this.propsTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.propsTitle.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.propsTitle.Location = new System.Drawing.Point(3, 3);
            this.propsTitle.Name = "propsTitle";
            this.propsTitle.Size = new System.Drawing.Size(75, 15);
            this.propsTitle.TabIndex = 140;
            this.propsTitle.Text = "Propiedades";
            // 
            // cbDestino
            // 
            this.cbDestino.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDestino.Enabled = false;
            this.cbDestino.Font = new System.Drawing.Font("Bahnschrift SemiLight SemiConde", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDestino.ForeColor = System.Drawing.SystemColors.GrayText;
            this.cbDestino.FormattingEnabled = true;
            this.cbDestino.Location = new System.Drawing.Point(254, 38);
            this.cbDestino.Name = "cbDestino";
            this.cbDestino.Size = new System.Drawing.Size(358, 24);
            this.cbDestino.TabIndex = 136;
            this.cbDestino.SelectedIndexChanged += new System.EventHandler(this.cbDestino_SelectedIndexChanged);
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Bahnschrift Light", 9.75F);
            this.label16.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label16.Location = new System.Drawing.Point(115, 41);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(104, 16);
            this.label16.TabIndex = 135;
            this.label16.Text = "Almacén Destino";
            // 
            // statusLabel
            // 
            this.statusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.statusLabel.AutoSize = true;
            this.statusLabel.Font = new System.Drawing.Font("Bahnschrift Light", 9.75F);
            this.statusLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.statusLabel.Location = new System.Drawing.Point(384, 258);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(99, 16);
            this.statusLabel.TabIndex = 142;
            this.statusLabel.Text = "Validando datos";
            this.statusLabel.Visible = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel3.Controls.Add(this.okButton);
            this.panel3.Controls.Add(this.pasteButton);
            this.panel3.Controls.Add(this.pasteSpinner);
            this.panel3.Controls.Add(this.clearButton);
            this.panel3.Controls.Add(this.addRowBtn);
            this.panel3.Controls.Add(this.editButton);
            this.panel3.Controls.Add(this.pbInfo);
            this.panel3.Controls.Add(this.labelInfo);
            this.panel3.Controls.Add(this.deleteRowButton);
            this.panel3.Controls.Add(this.saveBtn);
            this.panel3.Controls.Add(this.spinnerStatus);
            this.panel3.Controls.Add(this.statusLabel);
            this.panel3.Controls.Add(this.targetDataGrid);
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Location = new System.Drawing.Point(16, 116);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(623, 292);
            this.panel3.TabIndex = 146;
            // 
            // okButton
            // 
            this.okButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.okButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.okButton.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.okButton.BackgroundImage = global::InventaryWMS.Properties.Resources.icons8_entrada_641;
            this.okButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.okButton.Enabled = false;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.Font = new System.Drawing.Font("Bahnschrift Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.okButton.ForeColor = System.Drawing.Color.Transparent;
            this.okButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.okButton.Location = new System.Drawing.Point(582, 8);
            this.okButton.Name = "okButton";
            this.okButton.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.okButton.Size = new System.Drawing.Size(30, 27);
            this.okButton.TabIndex = 136;
            this.okButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.okButton.UseVisualStyleBackColor = false;
            this.okButton.Visible = false;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // pasteButton
            // 
            this.pasteButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(47)))), ((int)(((byte)(75)))));
            this.pasteButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pasteButton.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.pasteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pasteButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.pasteButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pasteButton.Location = new System.Drawing.Point(426, 8);
            this.pasteButton.Name = "pasteButton";
            this.pasteButton.Size = new System.Drawing.Size(86, 27);
            this.pasteButton.TabIndex = 149;
            this.pasteButton.Text = "Pegar";
            this.pasteButton.UseVisualStyleBackColor = false;
            this.pasteButton.Click += new System.EventHandler(this.pasteButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(47)))), ((int)(((byte)(75)))));
            this.clearButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.clearButton.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.clearButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.clearButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.clearButton.Location = new System.Drawing.Point(334, 8);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(86, 27);
            this.clearButton.TabIndex = 148;
            this.clearButton.Text = "Limpiar";
            this.clearButton.UseVisualStyleBackColor = false;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // addRowBtn
            // 
            this.addRowBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(47)))), ((int)(((byte)(75)))));
            this.addRowBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.addRowBtn.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.addRowBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addRowBtn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.addRowBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.addRowBtn.Location = new System.Drawing.Point(242, 8);
            this.addRowBtn.Name = "addRowBtn";
            this.addRowBtn.Size = new System.Drawing.Size(86, 27);
            this.addRowBtn.TabIndex = 147;
            this.addRowBtn.Text = "Nueva Fila";
            this.addRowBtn.UseVisualStyleBackColor = false;
            this.addRowBtn.Click += new System.EventHandler(this.addRowBtn_Click);
            // 
            // editButton
            // 
            this.editButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(47)))), ((int)(((byte)(75)))));
            this.editButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.editButton.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.editButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.editButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.editButton.Location = new System.Drawing.Point(150, 8);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(86, 27);
            this.editButton.TabIndex = 146;
            this.editButton.Text = "Editar";
            this.editButton.UseVisualStyleBackColor = false;
            this.editButton.Visible = false;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // pbInfo
            // 
            this.pbInfo.AllowDrop = true;
            this.pbInfo.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pbInfo.BackgroundImage = global::InventaryWMS.Properties.Resources.icons8_ms_excel_641;
            this.pbInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbInfo.Location = new System.Drawing.Point(249, 79);
            this.pbInfo.Name = "pbInfo";
            this.pbInfo.Size = new System.Drawing.Size(134, 57);
            this.pbInfo.TabIndex = 145;
            this.pbInfo.DragDrop += new System.Windows.Forms.DragEventHandler(this.targetDataGrid_DragDrop);
            this.pbInfo.DragEnter += new System.Windows.Forms.DragEventHandler(this.targetDataGrid_DragEnter);
            // 
            // deleteRowButton
            // 
            this.deleteRowButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(47)))), ((int)(((byte)(75)))));
            this.deleteRowButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.deleteRowButton.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.deleteRowButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteRowButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.deleteRowButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.deleteRowButton.Location = new System.Drawing.Point(58, 8);
            this.deleteRowButton.Name = "deleteRowButton";
            this.deleteRowButton.Size = new System.Drawing.Size(86, 27);
            this.deleteRowButton.TabIndex = 144;
            this.deleteRowButton.Text = "Eliminar";
            this.deleteRowButton.UseVisualStyleBackColor = false;
            this.deleteRowButton.Visible = false;
            this.deleteRowButton.Click += new System.EventHandler(this.deleteRowButton_Click);
            // 
            // whListSpinner
            // 
            this.whListSpinner.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.whListSpinner.BackColor = System.Drawing.Color.Transparent;
            this.whListSpinner.Location = new System.Drawing.Point(222, 34);
            this.whListSpinner.Margin = new System.Windows.Forms.Padding(4);
            this.whListSpinner.MaximumSize = new System.Drawing.Size(29, 31);
            this.whListSpinner.MinimumSize = new System.Drawing.Size(29, 31);
            this.whListSpinner.Name = "whListSpinner";
            this.whListSpinner.Size = new System.Drawing.Size(29, 31);
            this.whListSpinner.TabIndex = 139;
            // 
            // pasteSpinner
            // 
            this.pasteSpinner.BackColor = System.Drawing.Color.Transparent;
            this.pasteSpinner.Location = new System.Drawing.Point(6, 3);
            this.pasteSpinner.Margin = new System.Windows.Forms.Padding(4);
            this.pasteSpinner.MaximumSize = new System.Drawing.Size(29, 31);
            this.pasteSpinner.MinimumSize = new System.Drawing.Size(29, 31);
            this.pasteSpinner.Name = "pasteSpinner";
            this.pasteSpinner.Size = new System.Drawing.Size(29, 31);
            this.pasteSpinner.TabIndex = 140;
            this.pasteSpinner.Visible = false;
            // 
            // spinnerStatus
            // 
            this.spinnerStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.spinnerStatus.BackColor = System.Drawing.Color.Transparent;
            this.spinnerStatus.Location = new System.Drawing.Point(490, 250);
            this.spinnerStatus.Margin = new System.Windows.Forms.Padding(4);
            this.spinnerStatus.MaximumSize = new System.Drawing.Size(29, 31);
            this.spinnerStatus.MinimumSize = new System.Drawing.Size(29, 31);
            this.spinnerStatus.Name = "spinnerStatus";
            this.spinnerStatus.Size = new System.Drawing.Size(29, 31);
            this.spinnerStatus.TabIndex = 143;
            this.spinnerStatus.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackgroundImage = global::InventaryWMS.Properties.Resources.Logo_preview_rev_1__2_;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel1.Location = new System.Drawing.Point(383, 101);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(736, 346);
            this.panel1.TabIndex = 150;
            // 
            // LocateProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(47)))), ((int)(((byte)(75)))));
            this.ClientSize = new System.Drawing.Size(647, 427);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Name = "LocateProducts";
            this.Padding = new System.Windows.Forms.Padding(16);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ubicar productos";
            this.Load += new System.EventHandler(this.LocateProducts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.targetDataGrid)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.DataGridView targetDataGrid;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cbDestino;
        private System.Windows.Forms.Label label16;
        private LoadingSpinner whListSpinner;
        private LoadingSpinner spinnerStatus;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Panel pbInfo;
        private LoadingSpinner pasteSpinner;
        private System.Windows.Forms.Label propsTitle;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button deleteRowButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button pasteButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button addRowBtn;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Panel panel1;
    }
}