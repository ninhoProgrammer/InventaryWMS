namespace InventaryWMS
{
    partial class Product
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
            this.labelOf = new System.Windows.Forms.Label();
            this.textBoxDateLast = new System.Windows.Forms.TextBox();
            this.dateTimePickerInitial = new System.Windows.Forms.DateTimePicker();
            this.labelA = new System.Windows.Forms.Label();
            this.dateTimePickerLast = new System.Windows.Forms.DateTimePicker();
            this.textBoxDateInitial = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelDescription = new System.Windows.Forms.Panel();
            this.labelDescrition = new System.Windows.Forms.Label();
            this.textSearch = new System.Windows.Forms.TextBox();
            this.dataProducts = new System.Windows.Forms.DataGridView();
            this.pictureBoxNotEneble = new System.Windows.Forms.PictureBox();
            this.pictureBoxEneble = new System.Windows.Forms.PictureBox();
            this.buttonSerch = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBoxCancel = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonClear = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panelDescription.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNotEneble)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEneble)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCancel)).BeginInit();
            this.SuspendLayout();
            // 
            // labelOf
            // 
            this.labelOf.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelOf.AutoSize = true;
            this.labelOf.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelOf.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelOf.Location = new System.Drawing.Point(331, 21);
            this.labelOf.Name = "labelOf";
            this.labelOf.Size = new System.Drawing.Size(72, 15);
            this.labelOf.TabIndex = 39;
            this.labelOf.Text = "Fecha Inicial";
            // 
            // textBoxDateLast
            // 
            this.textBoxDateLast.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDateLast.Location = new System.Drawing.Point(430, 44);
            this.textBoxDateLast.Name = "textBoxDateLast";
            this.textBoxDateLast.ReadOnly = true;
            this.textBoxDateLast.Size = new System.Drawing.Size(311, 20);
            this.textBoxDateLast.TabIndex = 48;
            // 
            // dateTimePickerInitial
            // 
            this.dateTimePickerInitial.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePickerInitial.Location = new System.Drawing.Point(741, 18);
            this.dateTimePickerInitial.Name = "dateTimePickerInitial";
            this.dateTimePickerInitial.Size = new System.Drawing.Size(16, 20);
            this.dateTimePickerInitial.TabIndex = 40;
            this.dateTimePickerInitial.ValueChanged += new System.EventHandler(this.dateTimePickerInitial_ValueChanged);
            // 
            // labelA
            // 
            this.labelA.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelA.AutoSize = true;
            this.labelA.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelA.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelA.Location = new System.Drawing.Point(331, 46);
            this.labelA.Name = "labelA";
            this.labelA.Size = new System.Drawing.Size(66, 15);
            this.labelA.TabIndex = 46;
            this.labelA.Text = "Fecha Final";
            // 
            // dateTimePickerLast
            // 
            this.dateTimePickerLast.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePickerLast.Location = new System.Drawing.Point(741, 44);
            this.dateTimePickerLast.Name = "dateTimePickerLast";
            this.dateTimePickerLast.Size = new System.Drawing.Size(16, 20);
            this.dateTimePickerLast.TabIndex = 47;
            this.dateTimePickerLast.ValueChanged += new System.EventHandler(this.dateTimePickerLast_ValueChanged);
            // 
            // textBoxDateInitial
            // 
            this.textBoxDateInitial.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDateInitial.Location = new System.Drawing.Point(430, 18);
            this.textBoxDateInitial.Name = "textBoxDateInitial";
            this.textBoxDateInitial.ReadOnly = true;
            this.textBoxDateInitial.Size = new System.Drawing.Size(311, 20);
            this.textBoxDateInitial.TabIndex = 45;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(162, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 15);
            this.label1.TabIndex = 41;
            this.label1.Text = "Busqueda";
            // 
            // panelDescription
            // 
            this.panelDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelDescription.BackColor = System.Drawing.Color.Transparent;
            this.panelDescription.Controls.Add(this.labelDescrition);
            this.panelDescription.Controls.Add(this.textSearch);
            this.panelDescription.Location = new System.Drawing.Point(324, 10);
            this.panelDescription.Name = "panelDescription";
            this.panelDescription.Size = new System.Drawing.Size(443, 58);
            this.panelDescription.TabIndex = 49;
            // 
            // labelDescrition
            // 
            this.labelDescrition.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelDescrition.AutoSize = true;
            this.labelDescrition.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelDescrition.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelDescrition.Location = new System.Drawing.Point(6, 23);
            this.labelDescrition.Name = "labelDescrition";
            this.labelDescrition.Size = new System.Drawing.Size(90, 15);
            this.labelDescrition.TabIndex = 12;
            this.labelDescrition.Text = "Por Descripcion";
            // 
            // textSearch
            // 
            this.textSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textSearch.Location = new System.Drawing.Point(106, 20);
            this.textSearch.Name = "textSearch";
            this.textSearch.Size = new System.Drawing.Size(327, 20);
            this.textSearch.TabIndex = 3;
            // 
            // dataProducts
            // 
            this.dataProducts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataProducts.Location = new System.Drawing.Point(10, 75);
            this.dataProducts.Name = "dataProducts";
            this.dataProducts.ReadOnly = true;
            this.dataProducts.Size = new System.Drawing.Size(890, 270);
            this.dataProducts.TabIndex = 53;
            this.dataProducts.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataProducts_CellDoubleClick);
            // 
            // pictureBoxNotEneble
            // 
            this.pictureBoxNotEneble.BackgroundImage = global::InventaryWMS.Properties.Resources.icons8_apagar_64;
            this.pictureBoxNotEneble.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBoxNotEneble.Location = new System.Drawing.Point(227, 21);
            this.pictureBoxNotEneble.Name = "pictureBoxNotEneble";
            this.pictureBoxNotEneble.Size = new System.Drawing.Size(67, 37);
            this.pictureBoxNotEneble.TabIndex = 43;
            this.pictureBoxNotEneble.TabStop = false;
            this.pictureBoxNotEneble.Click += new System.EventHandler(this.pictureBoxNotEneble_Click);
            // 
            // pictureBoxEneble
            // 
            this.pictureBoxEneble.BackgroundImage = global::InventaryWMS.Properties.Resources.icons8_encender_64;
            this.pictureBoxEneble.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBoxEneble.Location = new System.Drawing.Point(227, 21);
            this.pictureBoxEneble.Name = "pictureBoxEneble";
            this.pictureBoxEneble.Size = new System.Drawing.Size(67, 37);
            this.pictureBoxEneble.TabIndex = 42;
            this.pictureBoxEneble.TabStop = false;
            this.pictureBoxEneble.Click += new System.EventHandler(this.pictureBoxEneble_Click);
            // 
            // buttonSerch
            // 
            this.buttonSerch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSerch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(47)))), ((int)(((byte)(75)))));
            this.buttonSerch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonSerch.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.buttonSerch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSerch.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 9F);
            this.buttonSerch.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonSerch.Location = new System.Drawing.Point(814, 17);
            this.buttonSerch.Name = "buttonSerch";
            this.buttonSerch.Size = new System.Drawing.Size(86, 27);
            this.buttonSerch.TabIndex = 54;
            this.buttonSerch.Text = "Buscar";
            this.buttonSerch.UseVisualStyleBackColor = false;
            this.buttonSerch.Click += new System.EventHandler(this.buttonSerch_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.buttonSerch);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBoxEneble);
            this.panel1.Controls.Add(this.labelOf);
            this.panel1.Controls.Add(this.textBoxDateInitial);
            this.panel1.Controls.Add(this.textBoxDateLast);
            this.panel1.Controls.Add(this.pictureBoxNotEneble);
            this.panel1.Controls.Add(this.dateTimePickerInitial);
            this.panel1.Controls.Add(this.dateTimePickerLast);
            this.panel1.Controls.Add(this.labelA);
            this.panel1.Controls.Add(this.panelDescription);
            this.panel1.Location = new System.Drawing.Point(8, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(911, 78);
            this.panel1.TabIndex = 55;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 15.75F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(3, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 25);
            this.label2.TabIndex = 55;
            this.label2.Text = "Productos";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel2.Controls.Add(this.pictureBoxCancel);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.buttonClear);
            this.panel2.Controls.Add(this.dataProducts);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Location = new System.Drawing.Point(8, 96);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(911, 362);
            this.panel2.TabIndex = 56;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // pictureBoxCancel
            // 
            this.pictureBoxCancel.AccessibleDescription = "Cancelar";
            this.pictureBoxCancel.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxCancel.BackgroundImage = global::InventaryWMS.Properties.Resources.icons8_cerrar_ventana_64;
            this.pictureBoxCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBoxCancel.Location = new System.Drawing.Point(865, 41);
            this.pictureBoxCancel.Name = "pictureBoxCancel";
            this.pictureBoxCancel.Size = new System.Drawing.Size(35, 28);
            this.pictureBoxCancel.TabIndex = 81;
            this.pictureBoxCancel.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 15.75F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(3, 1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 25);
            this.label3.TabIndex = 58;
            this.label3.Text = "Información";
            // 
            // buttonClear
            // 
            this.buttonClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(47)))), ((int)(((byte)(75)))));
            this.buttonClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonClear.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.buttonClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClear.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 9F);
            this.buttonClear.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonClear.Location = new System.Drawing.Point(816, 8);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(86, 27);
            this.buttonClear.TabIndex = 55;
            this.buttonClear.Text = "Limpiar";
            this.buttonClear.UseVisualStyleBackColor = false;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackgroundImage = global::InventaryWMS.Properties.Resources.Logo_preview_rev_1__2_;
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel3.Location = new System.Drawing.Point(671, 170);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(736, 346);
            this.panel3.TabIndex = 82;
            // 
            // Product
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(47)))), ((int)(((byte)(75)))));
            this.ClientSize = new System.Drawing.Size(931, 470);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "Product";
            this.Text = "Products";
            this.Click += new System.EventHandler(this.Product_Click);
            this.panelDescription.ResumeLayout(false);
            this.panelDescription.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNotEneble)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEneble)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCancel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelOf;
        private System.Windows.Forms.TextBox textBoxDateLast;
        private System.Windows.Forms.DateTimePicker dateTimePickerInitial;
        private System.Windows.Forms.Label labelA;
        private System.Windows.Forms.DateTimePicker dateTimePickerLast;
        private System.Windows.Forms.PictureBox pictureBoxNotEneble;
        private System.Windows.Forms.TextBox textBoxDateInitial;
        private System.Windows.Forms.PictureBox pictureBoxEneble;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelDescription;
        private System.Windows.Forms.Label labelDescrition;
        private System.Windows.Forms.TextBox textSearch;
        private System.Windows.Forms.DataGridView dataProducts;
        private System.Windows.Forms.Button buttonSerch;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBoxCancel;
        private System.Windows.Forms.Panel panel3;
    }
}