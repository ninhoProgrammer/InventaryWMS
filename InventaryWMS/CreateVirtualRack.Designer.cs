namespace InventaryWMS
{
    partial class CreateVirtualRack
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
            this.label15 = new System.Windows.Forms.Label();
            this.rackPropertiespanel = new System.Windows.Forms.Panel();
            this.warningLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.rackName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.saveRackBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.clientName = new System.Windows.Forms.Label();
            this.spinner = new InventaryWMS.LoadingSpinner();
            this.label6 = new System.Windows.Forms.Label();
            this.checkAssignToClient = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.rackPropertiespanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(16, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(395, 83);
            this.panel1.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Bahnschrift Light", 9.75F);
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(14, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(267, 33);
            this.label3.TabIndex = 22;
            this.label3.Text = "Ingrese los siguientes datos para completar el registro";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 15.75F, System.Drawing.FontStyle.Bold);
            this.label15.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label15.Location = new System.Drawing.Point(8, 3);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(206, 25);
            this.label15.TabIndex = 9;
            this.label15.Text = "Establecer propiedades";
            // 
            // rackPropertiespanel
            // 
            this.rackPropertiespanel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.rackPropertiespanel.Controls.Add(this.saveRackBtn);
            this.rackPropertiespanel.Controls.Add(this.checkAssignToClient);
            this.rackPropertiespanel.Controls.Add(this.warningLabel);
            this.rackPropertiespanel.Controls.Add(this.spinner);
            this.rackPropertiespanel.Controls.Add(this.label6);
            this.rackPropertiespanel.Controls.Add(this.label7);
            this.rackPropertiespanel.Controls.Add(this.clientName);
            this.rackPropertiespanel.Controls.Add(this.rackName);
            this.rackPropertiespanel.Controls.Add(this.label1);
            this.rackPropertiespanel.Controls.Add(this.label4);
            this.rackPropertiespanel.Controls.Add(this.label2);
            this.rackPropertiespanel.Font = new System.Drawing.Font("Bahnschrift Light SemiCondensed", 9F);
            this.rackPropertiespanel.Location = new System.Drawing.Point(12, 109);
            this.rackPropertiespanel.Name = "rackPropertiespanel";
            this.rackPropertiespanel.Size = new System.Drawing.Size(396, 247);
            this.rackPropertiespanel.TabIndex = 47;
            // 
            // warningLabel
            // 
            this.warningLabel.AutoSize = true;
            this.warningLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.warningLabel.ForeColor = System.Drawing.Color.Orange;
            this.warningLabel.Location = new System.Drawing.Point(278, 28);
            this.warningLabel.Name = "warningLabel";
            this.warningLabel.Size = new System.Drawing.Size(98, 15);
            this.warningLabel.TabIndex = 51;
            this.warningLabel.Text = "6 caracteres max.";
            this.warningLabel.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 15.75F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label7.Location = new System.Drawing.Point(8, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(137, 25);
            this.label7.TabIndex = 41;
            this.label7.Text = "Carácteristicas";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // rackName
            // 
            this.rackName.BackColor = System.Drawing.SystemColors.HighlightText;
            this.rackName.Font = new System.Drawing.Font("Bahnschrift SemiLight SemiConde", 12F);
            this.rackName.ForeColor = System.Drawing.Color.DimGray;
            this.rackName.Location = new System.Drawing.Point(129, 46);
            this.rackName.Name = "rackName";
            this.rackName.Size = new System.Drawing.Size(250, 27);
            this.rackName.TabIndex = 38;
            this.rackName.TextChanged += new System.EventHandler(this.rackName_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(32, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 15);
            this.label4.TabIndex = 39;
            this.label4.Text = "Nombre corto";
            // 
            // saveRackBtn
            // 
            this.saveRackBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(47)))), ((int)(((byte)(75)))));
            this.saveRackBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.saveRackBtn.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.saveRackBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveRackBtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveRackBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.saveRackBtn.Location = new System.Drawing.Point(290, 208);
            this.saveRackBtn.Name = "saveRackBtn";
            this.saveRackBtn.Size = new System.Drawing.Size(86, 27);
            this.saveRackBtn.TabIndex = 44;
            this.saveRackBtn.Text = "Crear";
            this.saveRackBtn.UseVisualStyleBackColor = false;
            this.saveRackBtn.Click += new System.EventHandler(this.saveRackBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(18, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 21);
            this.label2.TabIndex = 49;
            this.label2.Text = "Resumen";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(32, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 15);
            this.label1.TabIndex = 50;
            this.label1.Text = "Tamaño de la bahía:";
            // 
            // clientName
            // 
            this.clientName.BackColor = System.Drawing.Color.Transparent;
            this.clientName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clientName.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.clientName.Location = new System.Drawing.Point(248, 135);
            this.clientName.Name = "clientName";
            this.clientName.Size = new System.Drawing.Size(131, 26);
            this.clientName.TabIndex = 54;
            this.clientName.Text = "cliente";
            this.clientName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.clientName.Visible = false;
            // 
            // spinner
            // 
            this.spinner.BackColor = System.Drawing.Color.Transparent;
            this.spinner.Location = new System.Drawing.Point(347, 168);
            this.spinner.Margin = new System.Windows.Forms.Padding(4);
            this.spinner.MaximumSize = new System.Drawing.Size(29, 33);
            this.spinner.MinimumSize = new System.Drawing.Size(29, 33);
            this.spinner.Name = "spinner";
            this.spinner.Size = new System.Drawing.Size(29, 33);
            this.spinner.TabIndex = 145;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label6.Location = new System.Drawing.Point(244, 109);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(135, 26);
            this.label6.TabIndex = 146;
            this.label6.Text = "Automático";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // checkAssignToClient
            // 
            this.checkAssignToClient.AutoSize = true;
            this.checkAssignToClient.BackColor = System.Drawing.Color.Transparent;
            this.checkAssignToClient.Checked = true;
            this.checkAssignToClient.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkAssignToClient.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkAssignToClient.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.checkAssignToClient.Location = new System.Drawing.Point(32, 143);
            this.checkAssignToClient.Name = "checkAssignToClient";
            this.checkAssignToClient.Size = new System.Drawing.Size(119, 19);
            this.checkAssignToClient.TabIndex = 147;
            this.checkAssignToClient.Text = "Asignar al cliente:";
            this.checkAssignToClient.UseVisualStyleBackColor = false;
            // 
            // CreateVirtualRack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(47)))), ((int)(((byte)(75)))));
            this.ClientSize = new System.Drawing.Size(427, 375);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.rackPropertiespanel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreateVirtualRack";
            this.Padding = new System.Windows.Forms.Padding(16);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Crear Bahía";
            this.Load += new System.EventHandler(this.CreateVirtualRack_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.rackPropertiespanel.ResumeLayout(false);
            this.rackPropertiespanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Panel rackPropertiespanel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button saveRackBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox rackName;
        private System.Windows.Forms.Label warningLabel;
        private System.Windows.Forms.Label clientName;
        private LoadingSpinner spinner;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.CheckBox checkAssignToClient;
    }
}