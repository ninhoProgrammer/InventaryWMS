namespace InventaryWMS
{
    partial class FormClientsProviders
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormClientsProviders));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxName = new System.Windows.Forms.ComboBox();
            this.Remision = new System.Windows.Forms.Label();
            this.buttonNew = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelValid = new System.Windows.Forms.Panel();
            this.Ver = new System.Windows.Forms.Label();
            this.pictureBoxNotValid = new System.Windows.Forms.PictureBox();
            this.pictureBoxValid = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.textboxName = new System.Windows.Forms.TextBox();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.pictureBoxEdit = new System.Windows.Forms.PictureBox();
            this.pictureBoxCancel = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.loadingSpinner1 = new InventaryWMS.LoadingSpinner();
            this.spinner = new InventaryWMS.LoadingSpinner();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelValid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNotValid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxValid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCancel)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.BackgroundImage = global::InventaryWMS.Properties.Resources.LOGO_REIS_RGB;
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.comboBoxName);
            this.panel1.Controls.Add(this.Remision);
            this.panel1.Controls.Add(this.buttonNew);
            this.panel1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(424, 78);
            this.panel1.TabIndex = 62;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Location = new System.Drawing.Point(15, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 15);
            this.label5.TabIndex = 59;
            this.label5.Text = "Nombre";
            // 
            // comboBoxName
            // 
            this.comboBoxName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboBoxName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxName.FormattingEnabled = true;
            this.comboBoxName.Location = new System.Drawing.Point(97, 37);
            this.comboBoxName.Name = "comboBoxName";
            this.comboBoxName.Size = new System.Drawing.Size(195, 23);
            this.comboBoxName.TabIndex = 58;
            this.comboBoxName.SelectedIndexChanged += new System.EventHandler(this.comboBoxName_SelectedIndexChanged);
            // 
            // Remision
            // 
            this.Remision.AutoSize = true;
            this.Remision.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 15.75F, System.Drawing.FontStyle.Bold);
            this.Remision.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Remision.Location = new System.Drawing.Point(8, 3);
            this.Remision.Name = "Remision";
            this.Remision.Size = new System.Drawing.Size(97, 25);
            this.Remision.TabIndex = 56;
            this.Remision.Text = "Proveedor";
            // 
            // buttonNew
            // 
            this.buttonNew.AccessibleDescription = "Cancelar";
            this.buttonNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(47)))), ((int)(((byte)(75)))));
            this.buttonNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonNew.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.buttonNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNew.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonNew.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonNew.Location = new System.Drawing.Point(325, 18);
            this.buttonNew.Name = "buttonNew";
            this.buttonNew.Size = new System.Drawing.Size(86, 27);
            this.buttonNew.TabIndex = 55;
            this.buttonNew.Text = "Nuevo";
            this.buttonNew.UseVisualStyleBackColor = false;
            this.buttonNew.Click += new System.EventHandler(this.buttonNew_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel2.Controls.Add(this.loadingSpinner1);
            this.panel2.Controls.Add(this.panelValid);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.buttonSave);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.textboxName);
            this.panel2.Controls.Add(this.spinner);
            this.panel2.Controls.Add(this.textBoxDescription);
            this.panel2.Controls.Add(this.pictureBoxEdit);
            this.panel2.Controls.Add(this.pictureBoxCancel);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Location = new System.Drawing.Point(12, 97);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(424, 275);
            this.panel2.TabIndex = 63;
            // 
            // panelValid
            // 
            this.panelValid.Controls.Add(this.Ver);
            this.panelValid.Controls.Add(this.pictureBoxNotValid);
            this.panelValid.Controls.Add(this.pictureBoxValid);
            this.panelValid.Location = new System.Drawing.Point(137, 208);
            this.panelValid.Name = "panelValid";
            this.panelValid.Size = new System.Drawing.Size(155, 54);
            this.panelValid.TabIndex = 101;
            // 
            // Ver
            // 
            this.Ver.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.Ver.AutoSize = true;
            this.Ver.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Ver.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Ver.Location = new System.Drawing.Point(21, 19);
            this.Ver.Name = "Ver";
            this.Ver.Size = new System.Drawing.Size(39, 15);
            this.Ver.TabIndex = 79;
            this.Ver.Text = "Valido";
            // 
            // pictureBoxNotValid
            // 
            this.pictureBoxNotValid.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxNotValid.BackgroundImage")));
            this.pictureBoxNotValid.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBoxNotValid.Location = new System.Drawing.Point(85, 9);
            this.pictureBoxNotValid.Name = "pictureBoxNotValid";
            this.pictureBoxNotValid.Size = new System.Drawing.Size(67, 37);
            this.pictureBoxNotValid.TabIndex = 81;
            this.pictureBoxNotValid.TabStop = false;
            this.pictureBoxNotValid.Click += new System.EventHandler(this.pictureBoxNotValid_Click);
            // 
            // pictureBoxValid
            // 
            this.pictureBoxValid.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxValid.BackgroundImage")));
            this.pictureBoxValid.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBoxValid.Location = new System.Drawing.Point(85, 9);
            this.pictureBoxValid.Name = "pictureBoxValid";
            this.pictureBoxValid.Size = new System.Drawing.Size(67, 37);
            this.pictureBoxValid.TabIndex = 82;
            this.pictureBoxValid.TabStop = false;
            this.pictureBoxValid.Click += new System.EventHandler(this.pictureBoxValid_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 15.75F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(8, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 25);
            this.label1.TabIndex = 83;
            this.label1.Text = "Propiedades";
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(47)))), ((int)(((byte)(75)))));
            this.buttonSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonSave.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonSave.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonSave.Location = new System.Drawing.Point(326, 20);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(86, 27);
            this.buttonSave.TabIndex = 68;
            this.buttonSave.Text = "Guardar";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Visible = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label8.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label8.Location = new System.Drawing.Point(15, 126);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 15);
            this.label8.TabIndex = 65;
            this.label8.Text = "Descripción ";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label15.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label15.Location = new System.Drawing.Point(15, 97);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(51, 15);
            this.label15.TabIndex = 62;
            this.label15.Text = "Nombre";
            // 
            // textboxName
            // 
            this.textboxName.BackColor = System.Drawing.SystemColors.HighlightText;
            this.textboxName.Enabled = false;
            this.textboxName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textboxName.ForeColor = System.Drawing.Color.DimGray;
            this.textboxName.Location = new System.Drawing.Point(90, 94);
            this.textboxName.Name = "textboxName";
            this.textboxName.Size = new System.Drawing.Size(321, 23);
            this.textboxName.TabIndex = 61;
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.BackColor = System.Drawing.SystemColors.HighlightText;
            this.textBoxDescription.Enabled = false;
            this.textBoxDescription.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBoxDescription.ForeColor = System.Drawing.Color.DimGray;
            this.textBoxDescription.Location = new System.Drawing.Point(90, 123);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(321, 79);
            this.textBoxDescription.TabIndex = 66;
            // 
            // pictureBoxEdit
            // 
            this.pictureBoxEdit.AccessibleDescription = "Editar";
            this.pictureBoxEdit.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxEdit.BackgroundImage = global::InventaryWMS.Properties.Resources.icons8_editar_archivo_64;
            this.pictureBoxEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBoxEdit.Location = new System.Drawing.Point(376, 53);
            this.pictureBoxEdit.Name = "pictureBoxEdit";
            this.pictureBoxEdit.Size = new System.Drawing.Size(35, 28);
            this.pictureBoxEdit.TabIndex = 75;
            this.pictureBoxEdit.TabStop = false;
            this.pictureBoxEdit.Click += new System.EventHandler(this.pictureBoxEdit_Click);
            // 
            // pictureBoxCancel
            // 
            this.pictureBoxCancel.AccessibleDescription = "Cancelar";
            this.pictureBoxCancel.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxCancel.BackgroundImage = global::InventaryWMS.Properties.Resources.icons8_cerrar_ventana_64;
            this.pictureBoxCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBoxCancel.Location = new System.Drawing.Point(376, 53);
            this.pictureBoxCancel.Name = "pictureBoxCancel";
            this.pictureBoxCancel.Size = new System.Drawing.Size(35, 28);
            this.pictureBoxCancel.TabIndex = 74;
            this.pictureBoxCancel.TabStop = false;
            this.pictureBoxCancel.Visible = false;
            this.pictureBoxCancel.Click += new System.EventHandler(this.pictureBoxCancel_Click);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackgroundImage = global::InventaryWMS.Properties.Resources.Logo_preview_rev_1__2_;
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel3.Location = new System.Drawing.Point(240, 65);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(651, 396);
            this.panel3.TabIndex = 57;
            // 
            // loadingSpinner1
            // 
            this.loadingSpinner1.BackColor = System.Drawing.Color.Transparent;
            this.loadingSpinner1.Location = new System.Drawing.Point(282, 12);
            this.loadingSpinner1.MaximumSize = new System.Drawing.Size(40, 40);
            this.loadingSpinner1.MinimumSize = new System.Drawing.Size(40, 40);
            this.loadingSpinner1.Name = "loadingSpinner1";
            this.loadingSpinner1.Size = new System.Drawing.Size(40, 40);
            this.loadingSpinner1.TabIndex = 103;
            this.loadingSpinner1.Visible = false;
            // 
            // spinner
            // 
            this.spinner.BackColor = System.Drawing.Color.Transparent;
            this.spinner.Location = new System.Drawing.Point(565, 0);
            this.spinner.MaximumSize = new System.Drawing.Size(40, 40);
            this.spinner.MinimumSize = new System.Drawing.Size(40, 40);
            this.spinner.Name = "spinner";
            this.spinner.Size = new System.Drawing.Size(40, 40);
            this.spinner.TabIndex = 71;
            this.spinner.Visible = false;
            // 
            // FormClientsProviders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(47)))), ((int)(((byte)(75)))));
            this.ClientSize = new System.Drawing.Size(442, 384);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "FormClientsProviders";
            this.Text = "FormCancelRemission";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panelValid.ResumeLayout(false);
            this.panelValid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNotValid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxValid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCancel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxName;
        private System.Windows.Forms.Label Remision;
        private System.Windows.Forms.Button buttonNew;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelValid;
        private System.Windows.Forms.Label Ver;
        private System.Windows.Forms.PictureBox pictureBoxValid;
        private System.Windows.Forms.PictureBox pictureBoxNotValid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBoxEdit;
        private System.Windows.Forms.PictureBox pictureBoxCancel;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textboxName;
        private LoadingSpinner spinner;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox textBoxDescription;
        private LoadingSpinner loadingSpinner1;
    }
}