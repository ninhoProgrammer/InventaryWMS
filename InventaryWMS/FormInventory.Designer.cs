namespace InventaryWMS
{
    partial class FormInventory
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridViewInventary = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonClear = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.comboBoxOpcionlocation = new System.Windows.Forms.ComboBox();
            this.comboBoxOpcionserch = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.comboBoxFolio = new System.Windows.Forms.ComboBox();
            this.labelSerch = new System.Windows.Forms.Label();
            this.pictureBoxEneble = new System.Windows.Forms.PictureBox();
            this.pictureBoxNotEneble = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInventary)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEneble)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNotEneble)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.buttonClear);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Location = new System.Drawing.Point(10, 115);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(910, 343);
            this.panel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridViewInventary, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(13, 41);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(886, 279);
            this.tableLayoutPanel1.TabIndex = 86;
            // 
            // dataGridViewInventary
            // 
            this.dataGridViewInventary.AllowUserToAddRows = false;
            this.dataGridViewInventary.AllowUserToDeleteRows = false;
            this.dataGridViewInventary.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewInventary.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewInventary.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridViewInventary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewInventary.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewInventary.Name = "dataGridViewInventary";
            this.dataGridViewInventary.ReadOnly = true;
            this.dataGridViewInventary.RowHeadersVisible = false;
            this.dataGridViewInventary.Size = new System.Drawing.Size(880, 273);
            this.dataGridViewInventary.TabIndex = 3;
            this.dataGridViewInventary.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewInventary_CellContentClick);
            this.dataGridViewInventary.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewInventary_CellContentDoubleClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 15.75F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(8, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 25);
            this.label4.TabIndex = 85;
            this.label4.Text = "Información";
            // 
            // buttonClear
            // 
            this.buttonClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(47)))), ((int)(((byte)(75)))));
            this.buttonClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonClear.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.buttonClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClear.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonClear.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonClear.Location = new System.Drawing.Point(814, 8);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(86, 27);
            this.buttonClear.TabIndex = 84;
            this.buttonClear.Text = "Limpiar";
            this.buttonClear.UseVisualStyleBackColor = false;
            this.buttonClear.Visible = false;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackgroundImage = global::InventaryWMS.Properties.Resources.Logo_preview_rev_1__2_;
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel3.Location = new System.Drawing.Point(670, 152);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(736, 346);
            this.panel3.TabIndex = 83;
            // 
            // comboBoxOpcionlocation
            // 
            this.comboBoxOpcionlocation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxOpcionlocation.FormattingEnabled = true;
            this.comboBoxOpcionlocation.Location = new System.Drawing.Point(610, 52);
            this.comboBoxOpcionlocation.Name = "comboBoxOpcionlocation";
            this.comboBoxOpcionlocation.Size = new System.Drawing.Size(158, 21);
            this.comboBoxOpcionlocation.TabIndex = 0;
            // 
            // comboBoxOpcionserch
            // 
            this.comboBoxOpcionserch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxOpcionserch.FormattingEnabled = true;
            this.comboBoxOpcionserch.Location = new System.Drawing.Point(316, 38);
            this.comboBoxOpcionserch.Name = "comboBoxOpcionserch";
            this.comboBoxOpcionserch.Size = new System.Drawing.Size(217, 21);
            this.comboBoxOpcionserch.TabIndex = 0;
            this.comboBoxOpcionserch.SelectedIndexChanged += new System.EventHandler(this.comboBoxOpcionserch_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel2.Controls.Add(this.comboBoxFolio);
            this.panel2.Controls.Add(this.labelSerch);
            this.panel2.Controls.Add(this.pictureBoxEneble);
            this.panel2.Controls.Add(this.pictureBoxNotEneble);
            this.panel2.Controls.Add(this.comboBoxOpcionlocation);
            this.panel2.Controls.Add(this.comboBoxOpcionserch);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.buttonLoad);
            this.panel2.Location = new System.Drawing.Point(10, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(910, 96);
            this.panel2.TabIndex = 84;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // comboBoxFolio
            // 
            this.comboBoxFolio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxFolio.FormattingEnabled = true;
            this.comboBoxFolio.Location = new System.Drawing.Point(610, 20);
            this.comboBoxFolio.Name = "comboBoxFolio";
            this.comboBoxFolio.Size = new System.Drawing.Size(158, 21);
            this.comboBoxFolio.TabIndex = 111;
            // 
            // labelSerch
            // 
            this.labelSerch.AutoSize = true;
            this.labelSerch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelSerch.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelSerch.Location = new System.Drawing.Point(183, 40);
            this.labelSerch.Name = "labelSerch";
            this.labelSerch.Size = new System.Drawing.Size(59, 15);
            this.labelSerch.TabIndex = 108;
            this.labelSerch.Text = "Busqueda";
            // 
            // pictureBoxEneble
            // 
            this.pictureBoxEneble.BackgroundImage = global::InventaryWMS.Properties.Resources.icons8_encender_64;
            this.pictureBoxEneble.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBoxEneble.Location = new System.Drawing.Point(104, 30);
            this.pictureBoxEneble.Name = "pictureBoxEneble";
            this.pictureBoxEneble.Size = new System.Drawing.Size(67, 37);
            this.pictureBoxEneble.TabIndex = 109;
            this.pictureBoxEneble.TabStop = false;
            this.pictureBoxEneble.Click += new System.EventHandler(this.pictureBoxEneble_Click);
            // 
            // pictureBoxNotEneble
            // 
            this.pictureBoxNotEneble.BackgroundImage = global::InventaryWMS.Properties.Resources.icons8_apagar_64;
            this.pictureBoxNotEneble.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBoxNotEneble.Location = new System.Drawing.Point(104, 30);
            this.pictureBoxNotEneble.Name = "pictureBoxNotEneble";
            this.pictureBoxNotEneble.Size = new System.Drawing.Size(67, 37);
            this.pictureBoxNotEneble.TabIndex = 110;
            this.pictureBoxNotEneble.TabStop = false;
            this.pictureBoxNotEneble.Click += new System.EventHandler(this.pictureBoxNotEneble_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(546, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 15);
            this.label3.TabIndex = 107;
            this.label3.Text = "Buscar en";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(280, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 15);
            this.label1.TabIndex = 106;
            this.label1.Text = "Tipo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 15.75F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(8, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 25);
            this.label2.TabIndex = 105;
            this.label2.Text = "Inventario";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Location = new System.Drawing.Point(546, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 15);
            this.label5.TabIndex = 104;
            this.label5.Text = "Buscar por";
            // 
            // buttonLoad
            // 
            this.buttonLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLoad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(47)))), ((int)(((byte)(75)))));
            this.buttonLoad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonLoad.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.buttonLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLoad.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonLoad.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonLoad.Location = new System.Drawing.Point(813, 20);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(86, 27);
            this.buttonLoad.TabIndex = 103;
            this.buttonLoad.Text = "Cargar";
            this.buttonLoad.UseVisualStyleBackColor = false;
            this.buttonLoad.Click += new System.EventHandler(this.buttonsearch_Click);
            // 
            // FormInventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(47)))), ((int)(((byte)(75)))));
            this.ClientSize = new System.Drawing.Size(931, 470);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FormInventory";
            this.Text = "Inventario";
            this.MaximumSizeChanged += new System.EventHandler(this.FormInventory_MaximumSizeChanged);
            this.Load += new System.EventHandler(this.FormInventory_Load);
            this.Resize += new System.EventHandler(this.FormInventory_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInventary)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEneble)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNotEneble)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridViewInventary;
        private System.Windows.Forms.ComboBox comboBoxOpcionlocation;
        private System.Windows.Forms.ComboBox comboBoxOpcionserch;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelSerch;
        private System.Windows.Forms.PictureBox pictureBoxEneble;
        private System.Windows.Forms.PictureBox pictureBoxNotEneble;
        private System.Windows.Forms.ComboBox comboBoxFolio;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}