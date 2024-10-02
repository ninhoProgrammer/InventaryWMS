namespace InventaryWMS
{
    partial class FormPopupWindow
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonSerch = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(434, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Selecciona opción de impresión de comprobante";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackgroundImage = global::InventaryWMS.Properties.Resources.Logo_preview_rev_1__2_;
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel3.Location = new System.Drawing.Point(208, 163);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(740, 322);
            this.panel3.TabIndex = 58;
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
            this.buttonSerch.Location = new System.Drawing.Point(188, 63);
            this.buttonSerch.Name = "buttonSerch";
            this.buttonSerch.Size = new System.Drawing.Size(86, 27);
            this.buttonSerch.TabIndex = 59;
            this.buttonSerch.Text = "Comprimido";
            this.buttonSerch.UseVisualStyleBackColor = false;
            this.buttonSerch.Click += new System.EventHandler(this.buttoncompressed_Click);
            // 
            // button1
            // 
            this.button1.AccessibleDescription = "Nuevo Destino";
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(47)))), ((int)(((byte)(75)))));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(188, 123);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 27);
            this.button1.TabIndex = 60;
            this.button1.Text = "Desglosado";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.buttondown_Click);
            // 
            // FormPopupWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(463, 338);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonSerch);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Name = "FormPopupWindow";
            this.Text = "Comprobante entrada";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormPopupWindow_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button buttonSerch;
        private System.Windows.Forms.Button button1;
    }
}