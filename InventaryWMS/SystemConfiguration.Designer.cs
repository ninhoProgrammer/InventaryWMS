namespace InventaryWMS
{
    partial class SystemConfiguration
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
            this.pictureBoxTurnOFF = new System.Windows.Forms.PictureBox();
            this.pictureBoxTurnON = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonRemmisionCancel = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelWind = new System.Windows.Forms.Label();
            this.textBoxUser = new System.Windows.Forms.TextBox();
            this.textBoxServer = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTurnOFF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTurnON)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxTurnOFF
            // 
            this.pictureBoxTurnOFF.BackgroundImage = global::InventaryWMS.Properties.Resources.icons8_apagar_64;
            this.pictureBoxTurnOFF.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBoxTurnOFF.ErrorImage = null;
            this.pictureBoxTurnOFF.Location = new System.Drawing.Point(106, 127);
            this.pictureBoxTurnOFF.Name = "pictureBoxTurnOFF";
            this.pictureBoxTurnOFF.Size = new System.Drawing.Size(56, 36);
            this.pictureBoxTurnOFF.TabIndex = 3;
            this.pictureBoxTurnOFF.TabStop = false;
            this.pictureBoxTurnOFF.Click += new System.EventHandler(this.pictureBoxTurnOFF_Click);
            // 
            // pictureBoxTurnON
            // 
            this.pictureBoxTurnON.BackgroundImage = global::InventaryWMS.Properties.Resources.icons8_encender_64;
            this.pictureBoxTurnON.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBoxTurnON.Location = new System.Drawing.Point(106, 127);
            this.pictureBoxTurnON.Name = "pictureBoxTurnON";
            this.pictureBoxTurnON.Size = new System.Drawing.Size(56, 36);
            this.pictureBoxTurnON.TabIndex = 2;
            this.pictureBoxTurnON.TabStop = false;
            this.pictureBoxTurnON.Click += new System.EventHandler(this.pictureBoxTurnON_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackgroundImage = global::InventaryWMS.Properties.Resources.Logo_preview_rev_1__2_;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel1.Location = new System.Drawing.Point(238, 61);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(702, 398);
            this.panel1.TabIndex = 6;
            // 
            // buttonRemmisionCancel
            // 
            this.buttonRemmisionCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRemmisionCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(47)))), ((int)(((byte)(75)))));
            this.buttonRemmisionCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonRemmisionCancel.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.buttonRemmisionCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRemmisionCancel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonRemmisionCancel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonRemmisionCancel.Location = new System.Drawing.Point(327, 232);
            this.buttonRemmisionCancel.Name = "buttonRemmisionCancel";
            this.buttonRemmisionCancel.Size = new System.Drawing.Size(86, 27);
            this.buttonRemmisionCancel.TabIndex = 16;
            this.buttonRemmisionCancel.Text = "Cancelar";
            this.buttonRemmisionCancel.UseVisualStyleBackColor = false;
            this.buttonRemmisionCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel2.Controls.Add(this.textBoxPassword);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.labelWind);
            this.panel2.Controls.Add(this.textBoxUser);
            this.panel2.Controls.Add(this.textBoxServer);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.buttonRemmisionCancel);
            this.panel2.Controls.Add(this.button4);
            this.panel2.Controls.Add(this.pictureBoxTurnOFF);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.pictureBoxTurnON);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(445, 272);
            this.panel2.TabIndex = 7;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPassword.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBoxPassword.ForeColor = System.Drawing.SystemColors.GrayText;
            this.textBoxPassword.Location = new System.Drawing.Point(106, 104);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(307, 23);
            this.textBoxPassword.TabIndex = 59;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(30, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 15);
            this.label4.TabIndex = 99;
            this.label4.Text = "Server";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(30, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 15);
            this.label3.TabIndex = 98;
            this.label3.Text = "Usuario";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(30, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 97;
            this.label1.Text = "Contraseña";
            // 
            // labelWind
            // 
            this.labelWind.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelWind.AutoSize = true;
            this.labelWind.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWind.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelWind.Location = new System.Drawing.Point(30, 136);
            this.labelWind.Name = "labelWind";
            this.labelWind.Size = new System.Drawing.Size(54, 15);
            this.labelWind.TabIndex = 96;
            this.labelWind.Text = "Ventanas";
            // 
            // textBoxUser
            // 
            this.textBoxUser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxUser.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBoxUser.ForeColor = System.Drawing.SystemColors.GrayText;
            this.textBoxUser.Location = new System.Drawing.Point(106, 75);
            this.textBoxUser.Name = "textBoxUser";
            this.textBoxUser.Size = new System.Drawing.Size(307, 23);
            this.textBoxUser.TabIndex = 58;
            // 
            // textBoxServer
            // 
            this.textBoxServer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxServer.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBoxServer.ForeColor = System.Drawing.SystemColors.GrayText;
            this.textBoxServer.Location = new System.Drawing.Point(106, 46);
            this.textBoxServer.Name = "textBoxServer";
            this.textBoxServer.Size = new System.Drawing.Size(307, 23);
            this.textBoxServer.TabIndex = 57;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(2, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 15);
            this.label2.TabIndex = 56;
            this.label2.Text = "Configuiración";
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(47)))), ((int)(((byte)(75)))));
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button4.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.button4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button4.Location = new System.Drawing.Point(235, 232);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(86, 27);
            this.button4.TabIndex = 17;
            this.button4.Text = "Guardar";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.buttonSaved_Click);
            // 
            // SystemConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(47)))), ((int)(((byte)(75)))));
            this.ClientSize = new System.Drawing.Size(474, 301);
            this.Controls.Add(this.panel2);
            this.Name = "SystemConfiguration";
            this.Text = "SystemConfiguration";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTurnOFF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTurnON)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonRemmisionCancel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxServer;
        private System.Windows.Forms.TextBox textBoxUser;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.PictureBox pictureBoxTurnON;
        public System.Windows.Forms.PictureBox pictureBoxTurnOFF;
        public System.Windows.Forms.Label labelWind;
    }
}