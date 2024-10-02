namespace InventaryWMS
{
    partial class FormPermissions
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.textBoxPermissions = new System.Windows.Forms.TextBox();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.dataPermissions = new System.Windows.Forms.DataGridView();
            this.Permission = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Access = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Consult = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Add = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Edit = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DeleteDataGrid = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.buttonSave = new System.Windows.Forms.Button();
            this.comboBoxPermissions = new System.Windows.Forms.ComboBox();
            this.panelCanAutorize = new System.Windows.Forms.Panel();
            this.pictureBoxCanAutorize = new System.Windows.Forms.PictureBox();
            this.pictureBoxNotCanAutorize = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelInventary = new System.Windows.Forms.Panel();
            this.pictureBoxInventary = new System.Windows.Forms.PictureBox();
            this.pictureBoxNotInventary = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.spinner = new InventaryWMS.LoadingSpinner();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBoxEdit = new System.Windows.Forms.PictureBox();
            this.pictureBoxCancel = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonSerch = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataPermissions)).BeginInit();
            this.panelCanAutorize.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCanAutorize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNotCanAutorize)).BeginInit();
            this.panelInventary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxInventary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNotInventary)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCancel)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxPermissions
            // 
            this.textBoxPermissions.AccessibleName = "Permisos";
            this.textBoxPermissions.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBoxPermissions.Location = new System.Drawing.Point(97, 82);
            this.textBoxPermissions.Name = "textBoxPermissions";
            this.textBoxPermissions.Size = new System.Drawing.Size(402, 23);
            this.textBoxPermissions.TabIndex = 2;
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.AccessibleName = "Descripcion";
            this.textBoxDescription.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBoxDescription.Location = new System.Drawing.Point(97, 111);
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(402, 23);
            this.textBoxDescription.TabIndex = 4;
            // 
            // dataPermissions
            // 
            this.dataPermissions.AllowUserToAddRows = false;
            this.dataPermissions.AllowUserToDeleteRows = false;
            this.dataPermissions.BackgroundColor = System.Drawing.SystemColors.WindowFrame;
            this.dataPermissions.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataPermissions.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dataPermissions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataPermissions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Permission,
            this.Access,
            this.Consult,
            this.Add,
            this.Edit,
            this.DeleteDataGrid});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataPermissions.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataPermissions.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.dataPermissions.Location = new System.Drawing.Point(11, 152);
            this.dataPermissions.Name = "dataPermissions";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataPermissions.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dataPermissions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataPermissions.Size = new System.Drawing.Size(719, 178);
            this.dataPermissions.TabIndex = 6;
            this.dataPermissions.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataPermissions_CellContentClick);
            // 
            // Permission
            // 
            this.Permission.HeaderText = "Permiso";
            this.Permission.Name = "Permission";
            // 
            // Access
            // 
            this.Access.HeaderText = "Acceso";
            this.Access.Name = "Access";
            this.Access.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Access.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Consult
            // 
            this.Consult.HeaderText = "Consulta";
            this.Consult.Name = "Consult";
            // 
            // Add
            // 
            this.Add.HeaderText = "Añadir";
            this.Add.Name = "Add";
            this.Add.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Add.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Edit
            // 
            this.Edit.HeaderText = "Editar";
            this.Edit.Name = "Edit";
            this.Edit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Edit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // DeleteDataGrid
            // 
            this.DeleteDataGrid.HeaderText = "Eliminar";
            this.DeleteDataGrid.Name = "DeleteDataGrid";
            this.DeleteDataGrid.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DeleteDataGrid.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(47)))), ((int)(((byte)(75)))));
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonSave.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSave.Location = new System.Drawing.Point(644, 8);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(86, 27);
            this.buttonSave.TabIndex = 15;
            this.buttonSave.Text = "Guardar";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // comboBoxPermissions
            // 
            this.comboBoxPermissions.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxPermissions.FormattingEnabled = true;
            this.comboBoxPermissions.Location = new System.Drawing.Point(97, 36);
            this.comboBoxPermissions.Name = "comboBoxPermissions";
            this.comboBoxPermissions.Size = new System.Drawing.Size(402, 23);
            this.comboBoxPermissions.TabIndex = 17;
            this.comboBoxPermissions.SelectedIndexChanged += new System.EventHandler(this.comboBoxPermissions_SelectedIndexChanged);
            // 
            // panelCanAutorize
            // 
            this.panelCanAutorize.Controls.Add(this.pictureBoxCanAutorize);
            this.panelCanAutorize.Controls.Add(this.pictureBoxNotCanAutorize);
            this.panelCanAutorize.Controls.Add(this.label1);
            this.panelCanAutorize.Location = new System.Drawing.Point(505, 75);
            this.panelCanAutorize.Name = "panelCanAutorize";
            this.panelCanAutorize.Size = new System.Drawing.Size(225, 34);
            this.panelCanAutorize.TabIndex = 18;
            // 
            // pictureBoxCanAutorize
            // 
            this.pictureBoxCanAutorize.BackgroundImage = global::InventaryWMS.Properties.Resources.icons8_encender_64;
            this.pictureBoxCanAutorize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBoxCanAutorize.Location = new System.Drawing.Point(142, 2);
            this.pictureBoxCanAutorize.Name = "pictureBoxCanAutorize";
            this.pictureBoxCanAutorize.Size = new System.Drawing.Size(54, 27);
            this.pictureBoxCanAutorize.TabIndex = 2;
            this.pictureBoxCanAutorize.TabStop = false;
            this.pictureBoxCanAutorize.Click += new System.EventHandler(this.pictureBoxCanAutorize_Click);
            // 
            // pictureBoxNotCanAutorize
            // 
            this.pictureBoxNotCanAutorize.BackgroundImage = global::InventaryWMS.Properties.Resources.icons8_apagar_64;
            this.pictureBoxNotCanAutorize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBoxNotCanAutorize.Location = new System.Drawing.Point(142, 2);
            this.pictureBoxNotCanAutorize.Name = "pictureBoxNotCanAutorize";
            this.pictureBoxNotCanAutorize.Size = new System.Drawing.Size(54, 27);
            this.pictureBoxNotCanAutorize.TabIndex = 1;
            this.pictureBoxNotCanAutorize.TabStop = false;
            this.pictureBoxNotCanAutorize.Click += new System.EventHandler(this.PictureBoxNotCanAutorize_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(29, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Puede Autorizar:";
            // 
            // panelInventary
            // 
            this.panelInventary.Controls.Add(this.pictureBoxInventary);
            this.panelInventary.Controls.Add(this.pictureBoxNotInventary);
            this.panelInventary.Controls.Add(this.label2);
            this.panelInventary.Location = new System.Drawing.Point(505, 110);
            this.panelInventary.Name = "panelInventary";
            this.panelInventary.Size = new System.Drawing.Size(225, 34);
            this.panelInventary.TabIndex = 19;
            // 
            // pictureBoxInventary
            // 
            this.pictureBoxInventary.BackgroundImage = global::InventaryWMS.Properties.Resources.icons8_encender_64;
            this.pictureBoxInventary.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBoxInventary.Location = new System.Drawing.Point(142, 2);
            this.pictureBoxInventary.Name = "pictureBoxInventary";
            this.pictureBoxInventary.Size = new System.Drawing.Size(54, 27);
            this.pictureBoxInventary.TabIndex = 2;
            this.pictureBoxInventary.TabStop = false;
            this.pictureBoxInventary.Click += new System.EventHandler(this.PictureBoxInventary_Click);
            // 
            // pictureBoxNotInventary
            // 
            this.pictureBoxNotInventary.BackgroundImage = global::InventaryWMS.Properties.Resources.icons8_apagar_64;
            this.pictureBoxNotInventary.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBoxNotInventary.Location = new System.Drawing.Point(142, 2);
            this.pictureBoxNotInventary.Name = "pictureBoxNotInventary";
            this.pictureBoxNotInventary.Size = new System.Drawing.Size(54, 27);
            this.pictureBoxNotInventary.TabIndex = 1;
            this.pictureBoxNotInventary.TabStop = false;
            this.pictureBoxNotInventary.Click += new System.EventHandler(this.PictureBoxNotInventary_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(29, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Inventario:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel2.Controls.Add(this.spinner);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.panelInventary);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.pictureBoxEdit);
            this.panel2.Controls.Add(this.buttonSave);
            this.panel2.Controls.Add(this.panelCanAutorize);
            this.panel2.Controls.Add(this.textBoxDescription);
            this.panel2.Controls.Add(this.pictureBoxCancel);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.dataPermissions);
            this.panel2.Controls.Add(this.textBoxPermissions);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Location = new System.Drawing.Point(12, 112);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(739, 338);
            this.panel2.TabIndex = 21;
            // 
            // spinner
            // 
            this.spinner.BackColor = System.Drawing.Color.Transparent;
            this.spinner.Location = new System.Drawing.Point(598, 3);
            this.spinner.MaximumSize = new System.Drawing.Size(40, 40);
            this.spinner.MinimumSize = new System.Drawing.Size(40, 40);
            this.spinner.Name = "spinner";
            this.spinner.Size = new System.Drawing.Size(40, 40);
            this.spinner.TabIndex = 79;
            this.spinner.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 15.75F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label6.Location = new System.Drawing.Point(1, 1);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 25);
            this.label6.TabIndex = 78;
            this.label6.Text = "Propiedades";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(8, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 15);
            this.label4.TabIndex = 20;
            this.label4.Text = "Descripción";
            // 
            // pictureBoxEdit
            // 
            this.pictureBoxEdit.AccessibleDescription = "Editar";
            this.pictureBoxEdit.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxEdit.BackgroundImage = global::InventaryWMS.Properties.Resources.icons8_editar_archivo_64;
            this.pictureBoxEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBoxEdit.Location = new System.Drawing.Point(695, 41);
            this.pictureBoxEdit.Name = "pictureBoxEdit";
            this.pictureBoxEdit.Size = new System.Drawing.Size(35, 28);
            this.pictureBoxEdit.TabIndex = 77;
            this.pictureBoxEdit.TabStop = false;
            this.pictureBoxEdit.Click += new System.EventHandler(this.PictureBoxEdit_Click);
            // 
            // pictureBoxCancel
            // 
            this.pictureBoxCancel.AccessibleDescription = "Cancelar";
            this.pictureBoxCancel.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxCancel.BackgroundImage = global::InventaryWMS.Properties.Resources.icons8_cerrar_ventana_64;
            this.pictureBoxCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBoxCancel.Location = new System.Drawing.Point(695, 41);
            this.pictureBoxCancel.Name = "pictureBoxCancel";
            this.pictureBoxCancel.Size = new System.Drawing.Size(35, 28);
            this.pictureBoxCancel.TabIndex = 76;
            this.pictureBoxCancel.TabStop = false;
            this.pictureBoxCancel.Click += new System.EventHandler(this.PictureBoxCancel_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Location = new System.Drawing.Point(8, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 15);
            this.label5.TabIndex = 21;
            this.label5.Text = "Nombre";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel3.Controls.Add(this.buttonSerch);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.comboBoxPermissions);
            this.panel3.Location = new System.Drawing.Point(12, 12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(739, 94);
            this.panel3.TabIndex = 22;
            // 
            // buttonSerch
            // 
            this.buttonSerch.AccessibleDescription = "Nuevo Destino";
            this.buttonSerch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSerch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(47)))), ((int)(((byte)(75)))));
            this.buttonSerch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonSerch.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.buttonSerch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSerch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonSerch.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonSerch.Location = new System.Drawing.Point(644, 20);
            this.buttonSerch.Name = "buttonSerch";
            this.buttonSerch.Size = new System.Drawing.Size(86, 27);
            this.buttonSerch.TabIndex = 58;
            this.buttonSerch.Text = "Nuevo";
            this.buttonSerch.UseVisualStyleBackColor = false;
            this.buttonSerch.Click += new System.EventHandler(this.buttonSerch_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 15.75F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label7.Location = new System.Drawing.Point(3, 1);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 25);
            this.label7.TabIndex = 57;
            this.label7.Text = "Permiso";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(15, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 15);
            this.label3.TabIndex = 18;
            this.label3.Text = "Permiso";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackgroundImage = global::InventaryWMS.Properties.Resources.Logo_preview_rev_1__2_;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel1.Location = new System.Drawing.Point(484, 166);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(740, 322);
            this.panel1.TabIndex = 80;
            // 
            // FormPermissions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(47)))), ((int)(((byte)(75)))));
            this.ClientSize = new System.Drawing.Size(763, 462);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Name = "FormPermissions";
            this.Text = "Permisos";
            this.Click += new System.EventHandler(this.FormPermissions_Click);
            ((System.ComponentModel.ISupportInitialize)(this.dataPermissions)).EndInit();
            this.panelCanAutorize.ResumeLayout(false);
            this.panelCanAutorize.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCanAutorize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNotCanAutorize)).EndInit();
            this.panelInventary.ResumeLayout(false);
            this.panelInventary.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxInventary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNotInventary)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCancel)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxPermissions;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.DataGridView dataPermissions;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.ComboBox comboBoxPermissions;
        private System.Windows.Forms.Panel panelCanAutorize;
        private System.Windows.Forms.PictureBox pictureBoxCanAutorize;
        private System.Windows.Forms.PictureBox pictureBoxNotCanAutorize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelInventary;
        private System.Windows.Forms.PictureBox pictureBoxInventary;
        private System.Windows.Forms.PictureBox pictureBoxNotInventary;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Permission;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Access;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Consult;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Add;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Edit;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DeleteDataGrid;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBoxEdit;
        private System.Windows.Forms.PictureBox pictureBoxCancel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button buttonSerch;
        private LoadingSpinner spinner;
        private System.Windows.Forms.Panel panel1;
    }
}