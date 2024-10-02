namespace InventaryWMS
{
    partial class FormClientsWarehouses
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormClientsWarehouses));
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxClient = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxWarehouse = new System.Windows.Forms.ComboBox();
            this.panelValid = new System.Windows.Forms.Panel();
            this.Ver = new System.Windows.Forms.Label();
            this.pictureBoxNotValid = new System.Windows.Forms.PictureBox();
            this.pictureBoxValid = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.loadingSpinner1 = new InventaryWMS.LoadingSpinner();
            this.spinner = new InventaryWMS.LoadingSpinner();
            this.panel2.SuspendLayout();
            this.panelValid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNotValid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxValid)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Location = new System.Drawing.Point(21, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 15);
            this.label5.TabIndex = 59;
            this.label5.Text = "Cliente";
            // 
            // comboBoxClient
            // 
            this.comboBoxClient.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxClient.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboBoxClient.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxClient.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxClient.FormattingEnabled = true;
            this.comboBoxClient.Location = new System.Drawing.Point(103, 87);
            this.comboBoxClient.Name = "comboBoxClient";
            this.comboBoxClient.Size = new System.Drawing.Size(195, 23);
            this.comboBoxClient.TabIndex = 58;
            this.comboBoxClient.SelectedIndexChanged += new System.EventHandler(this.comboBoxName_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.comboBoxWarehouse);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.loadingSpinner1);
            this.panel2.Controls.Add(this.comboBoxClient);
            this.panel2.Controls.Add(this.panelValid);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.buttonSave);
            this.panel2.Controls.Add(this.spinner);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(311, 215);
            this.panel2.TabIndex = 63;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(21, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 15);
            this.label2.TabIndex = 105;
            this.label2.Text = "Almacen";
            // 
            // comboBoxWarehouse
            // 
            this.comboBoxWarehouse.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxWarehouse.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboBoxWarehouse.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxWarehouse.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxWarehouse.FormattingEnabled = true;
            this.comboBoxWarehouse.Location = new System.Drawing.Point(103, 116);
            this.comboBoxWarehouse.Name = "comboBoxWarehouse";
            this.comboBoxWarehouse.Size = new System.Drawing.Size(195, 23);
            this.comboBoxWarehouse.TabIndex = 104;
            this.comboBoxWarehouse.SelectedIndexChanged += new System.EventHandler(this.comboBoxWarehouse_SelectedIndexChanged);
            // 
            // panelValid
            // 
            this.panelValid.Controls.Add(this.Ver);
            this.panelValid.Controls.Add(this.pictureBoxNotValid);
            this.panelValid.Controls.Add(this.pictureBoxValid);
            this.panelValid.Location = new System.Drawing.Point(78, 147);
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
            this.Ver.Size = new System.Drawing.Size(57, 15);
            this.Ver.TabIndex = 79;
            this.Ver.Text = "Asignado";
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
            this.buttonSave.Location = new System.Drawing.Point(212, 20);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(86, 27);
            this.buttonSave.TabIndex = 68;
            this.buttonSave.Text = "Guardar";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackgroundImage = global::InventaryWMS.Properties.Resources.Logo_preview_rev_1__2_;
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel3.Location = new System.Drawing.Point(127, 5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(651, 396);
            this.panel3.TabIndex = 57;
            // 
            // loadingSpinner1
            // 
            this.loadingSpinner1.BackColor = System.Drawing.Color.Transparent;
            this.loadingSpinner1.Location = new System.Drawing.Point(168, 12);
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
            // FormClientsWarehouses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(47)))), ((int)(((byte)(75)))));
            this.ClientSize = new System.Drawing.Size(332, 237);
            this.Controls.Add(this.panel2);
            this.Name = "FormClientsWarehouses";
            this.Text = "FormClientsWarehouses";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panelValid.ResumeLayout(false);
            this.panelValid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNotValid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxValid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxClient;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonSave;
        private LoadingSpinner spinner;
        private System.Windows.Forms.Panel panel3;
        private LoadingSpinner loadingSpinner1;
        private System.Windows.Forms.Panel panelValid;
        private System.Windows.Forms.Label Ver;
        private System.Windows.Forms.PictureBox pictureBoxNotValid;
        private System.Windows.Forms.PictureBox pictureBoxValid;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxWarehouse;
    }
}