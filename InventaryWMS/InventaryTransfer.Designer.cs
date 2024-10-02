namespace InventaryWMS
{
    partial class InventaryTransfer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InventaryTransfer));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label15 = new System.Windows.Forms.Label();
            this.spinner = new InventaryWMS.LoadingSpinner();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbNumParte = new System.Windows.Forms.ComboBox();
            this.cbPartidas = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.searchButton = new System.Windows.Forms.Button();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.transferPropspanel = new System.Windows.Forms.Panel();
            this.spinner2 = new InventaryWMS.LoadingSpinner();
            this.cantidadTransfer = new System.Windows.Forms.Label();
            this.cbOptionsTransfer = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.infoCantidad = new System.Windows.Forms.Label();
            this.origenInfo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbDestino = new System.Windows.Forms.ComboBox();
            this.applyChangesBtn = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.resultDataGrid = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ALMACEN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UBICACIÓN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.transferPropspanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resultDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(16, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(905, 81);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::InventaryWMS.Properties.Resources.LOGO_REIS_RGB;
            this.pictureBox1.InitialImage = global::InventaryWMS.Properties.Resources.LOGO_REIS_RGB;
            this.pictureBox1.Location = new System.Drawing.Point(787, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 38;
            this.pictureBox1.TabStop = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 15.75F, System.Drawing.FontStyle.Bold);
            this.label15.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label15.Location = new System.Drawing.Point(19, 28);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(247, 25);
            this.label15.TabIndex = 36;
            this.label15.Text = "Transferencias de Inventario";
            // 
            // spinner
            // 
            this.spinner.BackColor = System.Drawing.Color.Transparent;
            this.spinner.Location = new System.Drawing.Point(645, 79);
            this.spinner.Margin = new System.Windows.Forms.Padding(4);
            this.spinner.MaximumSize = new System.Drawing.Size(29, 31);
            this.spinner.MinimumSize = new System.Drawing.Size(29, 31);
            this.spinner.Name = "spinner";
            this.spinner.Size = new System.Drawing.Size(29, 31);
            this.spinner.TabIndex = 37;
            this.spinner.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.panel2.Controls.Add(this.cbNumParte);
            this.panel2.Controls.Add(this.cbPartidas);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.searchButton);
            this.panel2.Controls.Add(this.searchTextBox);
            this.panel2.Controls.Add(this.transferPropspanel);
            this.panel2.Controls.Add(this.resultDataGrid);
            this.panel2.Location = new System.Drawing.Point(16, 109);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(905, 387);
            this.panel2.TabIndex = 1;
            // 
            // cbNumParte
            // 
            this.cbNumParte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNumParte.Font = new System.Drawing.Font("Bahnschrift SemiLight SemiConde", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbNumParte.ForeColor = System.Drawing.SystemColors.GrayText;
            this.cbNumParte.FormattingEnabled = true;
            this.cbNumParte.Items.AddRange(new object[] {
            "Número de Parte del Proveedor",
            "Número de Parte del Cliente"});
            this.cbNumParte.Location = new System.Drawing.Point(643, 22);
            this.cbNumParte.Name = "cbNumParte";
            this.cbNumParte.Size = new System.Drawing.Size(210, 24);
            this.cbNumParte.TabIndex = 122;
            // 
            // cbPartidas
            // 
            this.cbPartidas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPartidas.Font = new System.Drawing.Font("Bahnschrift SemiLight SemiConde", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPartidas.ForeColor = System.Drawing.SystemColors.GrayText;
            this.cbPartidas.FormattingEnabled = true;
            this.cbPartidas.Items.AddRange(new object[] {
            "Partidas Individuales"});
            this.cbPartidas.Location = new System.Drawing.Point(486, 22);
            this.cbPartidas.Name = "cbPartidas";
            this.cbPartidas.Size = new System.Drawing.Size(151, 24);
            this.cbPartidas.TabIndex = 121;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 12F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label5.Location = new System.Drawing.Point(20, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(189, 19);
            this.label5.TabIndex = 118;
            this.label5.Text = "Buscar por Número de Parte";
            // 
            // searchButton
            // 
            this.searchButton.BackColor = System.Drawing.Color.Transparent;
            this.searchButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("searchButton.BackgroundImage")));
            this.searchButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.searchButton.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.searchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchButton.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 9F);
            this.searchButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.searchButton.Location = new System.Drawing.Point(420, 22);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(52, 27);
            this.searchButton.TabIndex = 116;
            this.searchButton.UseVisualStyleBackColor = false;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // searchTextBox
            // 
            this.searchTextBox.AccessibleDescription = "Buscar almacén";
            this.searchTextBox.BackColor = System.Drawing.SystemColors.HighlightText;
            this.searchTextBox.Font = new System.Drawing.Font("Bahnschrift SemiLight SemiConde", 12F);
            this.searchTextBox.ForeColor = System.Drawing.Color.DimGray;
            this.searchTextBox.Location = new System.Drawing.Point(215, 21);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(199, 27);
            this.searchTextBox.TabIndex = 117;
            this.searchTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.searchTextBox_KeyUp);
            // 
            // transferPropspanel
            // 
            this.transferPropspanel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.transferPropspanel.BackColor = System.Drawing.SystemColors.Control;
            this.transferPropspanel.Controls.Add(this.spinner2);
            this.transferPropspanel.Controls.Add(this.cantidadTransfer);
            this.transferPropspanel.Controls.Add(this.cbOptionsTransfer);
            this.transferPropspanel.Controls.Add(this.label4);
            this.transferPropspanel.Controls.Add(this.infoCantidad);
            this.transferPropspanel.Controls.Add(this.origenInfo);
            this.transferPropspanel.Controls.Add(this.label1);
            this.transferPropspanel.Controls.Add(this.cbDestino);
            this.transferPropspanel.Controls.Add(this.applyChangesBtn);
            this.transferPropspanel.Controls.Add(this.label7);
            this.transferPropspanel.Controls.Add(this.label16);
            this.transferPropspanel.Controls.Add(this.label17);
            this.transferPropspanel.Controls.Add(this.label18);
            this.transferPropspanel.Controls.Add(this.spinner);
            this.transferPropspanel.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.transferPropspanel.Location = new System.Drawing.Point(20, 172);
            this.transferPropspanel.Name = "transferPropspanel";
            this.transferPropspanel.Size = new System.Drawing.Size(867, 141);
            this.transferPropspanel.TabIndex = 115;
            // 
            // spinner2
            // 
            this.spinner2.BackColor = System.Drawing.Color.Transparent;
            this.spinner2.Location = new System.Drawing.Point(662, 102);
            this.spinner2.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.spinner2.MaximumSize = new System.Drawing.Size(29, 31);
            this.spinner2.MinimumSize = new System.Drawing.Size(29, 31);
            this.spinner2.Name = "spinner2";
            this.spinner2.Size = new System.Drawing.Size(29, 31);
            this.spinner2.TabIndex = 116;
            this.spinner2.Visible = false;
            // 
            // cantidadTransfer
            // 
            this.cantidadTransfer.AutoSize = true;
            this.cantidadTransfer.Font = new System.Drawing.Font("Bahnschrift Light SemiCondensed", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cantidadTransfer.ForeColor = System.Drawing.SystemColors.Desktop;
            this.cantidadTransfer.Location = new System.Drawing.Point(160, 85);
            this.cantidadTransfer.Name = "cantidadTransfer";
            this.cantidadTransfer.Size = new System.Drawing.Size(15, 18);
            this.cantidadTransfer.TabIndex = 115;
            this.cantidadTransfer.Text = "0";
            // 
            // cbOptionsTransfer
            // 
            this.cbOptionsTransfer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOptionsTransfer.Enabled = false;
            this.cbOptionsTransfer.Font = new System.Drawing.Font("Bahnschrift SemiLight SemiConde", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbOptionsTransfer.ForeColor = System.Drawing.SystemColors.GrayText;
            this.cbOptionsTransfer.FormattingEnabled = true;
            this.cbOptionsTransfer.Items.AddRange(new object[] {
            "Otro almacén"});
            this.cbOptionsTransfer.Location = new System.Drawing.Point(309, 47);
            this.cbOptionsTransfer.Name = "cbOptionsTransfer";
            this.cbOptionsTransfer.Size = new System.Drawing.Size(216, 24);
            this.cbOptionsTransfer.TabIndex = 47;
            this.cbOptionsTransfer.SelectedIndexChanged += new System.EventHandler(this.cbOptionsTransfer_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Bahnschrift Light", 9.75F);
            this.label4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label4.Location = new System.Drawing.Point(228, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 16);
            this.label4.TabIndex = 46;
            this.label4.Text = "Transferir a";
            // 
            // infoCantidad
            // 
            this.infoCantidad.AutoSize = true;
            this.infoCantidad.Font = new System.Drawing.Font("Bahnschrift Light SemiCondensed", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoCantidad.ForeColor = System.Drawing.SystemColors.Desktop;
            this.infoCantidad.Location = new System.Drawing.Point(146, 49);
            this.infoCantidad.Name = "infoCantidad";
            this.infoCantidad.Size = new System.Drawing.Size(15, 18);
            this.infoCantidad.TabIndex = 45;
            this.infoCantidad.Text = "0";
            // 
            // origenInfo
            // 
            this.origenInfo.Font = new System.Drawing.Font("Bahnschrift Light SemiCondensed", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.origenInfo.ForeColor = System.Drawing.SystemColors.Desktop;
            this.origenInfo.Location = new System.Drawing.Point(279, 85);
            this.origenInfo.Name = "origenInfo";
            this.origenInfo.Size = new System.Drawing.Size(115, 46);
            this.origenInfo.TabIndex = 44;
            this.origenInfo.Text = "N/A";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift Light", 9.75F);
            this.label1.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label1.Location = new System.Drawing.Point(19, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 16);
            this.label1.TabIndex = 43;
            this.label1.Text = "Cantidad Disponible";
            // 
            // cbDestino
            // 
            this.cbDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDestino.Enabled = false;
            this.cbDestino.Font = new System.Drawing.Font("Bahnschrift SemiLight SemiConde", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDestino.ForeColor = System.Drawing.SystemColors.GrayText;
            this.cbDestino.FormattingEnabled = true;
            this.cbDestino.Location = new System.Drawing.Point(453, 83);
            this.cbDestino.Name = "cbDestino";
            this.cbDestino.Size = new System.Drawing.Size(194, 24);
            this.cbDestino.TabIndex = 42;
            this.cbDestino.SelectedIndexChanged += new System.EventHandler(this.cbDestino_SelectedIndexChanged);
            // 
            // applyChangesBtn
            // 
            this.applyChangesBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.applyChangesBtn.BackColor = System.Drawing.Color.SteelBlue;
            this.applyChangesBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.applyChangesBtn.Enabled = false;
            this.applyChangesBtn.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.applyChangesBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.applyChangesBtn.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 9F);
            this.applyChangesBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.applyChangesBtn.Location = new System.Drawing.Point(692, 105);
            this.applyChangesBtn.Name = "applyChangesBtn";
            this.applyChangesBtn.Size = new System.Drawing.Size(165, 26);
            this.applyChangesBtn.TabIndex = 114;
            this.applyChangesBtn.Text = "Realizar Transferencia";
            this.applyChangesBtn.UseVisualStyleBackColor = false;
            this.applyChangesBtn.Click += new System.EventHandler(this.applyChangesBtn_Click);
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
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Bahnschrift Light", 9.75F);
            this.label16.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label16.Location = new System.Drawing.Point(396, 87);
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
            this.label17.Location = new System.Drawing.Point(228, 87);
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
            this.label18.Location = new System.Drawing.Point(19, 87);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(135, 16);
            this.label18.TabIndex = 19;
            this.label18.Text = "Cantidad seleccionada";
            // 
            // resultDataGrid
            // 
            this.resultDataGrid.AllowUserToAddRows = false;
            this.resultDataGrid.AllowUserToDeleteRows = false;
            this.resultDataGrid.AllowUserToResizeColumns = false;
            this.resultDataGrid.AllowUserToResizeRows = false;
            this.resultDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resultDataGrid.BackgroundColor = System.Drawing.SystemColors.HighlightText;
            this.resultDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Bahnschrift SemiLight", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.resultDataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.resultDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.ALMACEN,
            this.UBICACIÓN,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column10,
            this.Column9,
            this.Column4,
            this.Column11});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.resultDataGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.resultDataGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.resultDataGrid.Location = new System.Drawing.Point(20, 59);
            this.resultDataGrid.Name = "resultDataGrid";
            this.resultDataGrid.RowHeadersVisible = false;
            this.resultDataGrid.RowHeadersWidth = 10;
            this.resultDataGrid.RowTemplate.Height = 25;
            this.resultDataGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.resultDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.resultDataGrid.Size = new System.Drawing.Size(867, 254);
            this.resultDataGrid.TabIndex = 113;
            this.resultDataGrid.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.resultDataGrid_CellEnter);
            this.resultDataGrid.MouseUp += new System.Windows.Forms.MouseEventHandler(this.resultDataGrid_MouseUp);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.HeaderText = "#";
            this.Column1.Name = "Column1";
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.HeaderText = "Serial";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.HeaderText = "Núm. Parte";
            this.Column3.Name = "Column3";
            // 
            // ALMACEN
            // 
            this.ALMACEN.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ALMACEN.HeaderText = "Descripción";
            this.ALMACEN.Name = "ALMACEN";
            // 
            // UBICACIÓN
            // 
            this.UBICACIÓN.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.UBICACIÓN.HeaderText = "Cantidad";
            this.UBICACIÓN.Name = "UBICACIÓN";
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column5.HeaderText = "Proveedor";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column6.HeaderText = "Factura";
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column7.HeaderText = "Pedimento";
            this.Column7.Name = "Column7";
            // 
            // Column8
            // 
            this.Column8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column8.HeaderText = "Fecha Exp.";
            this.Column8.Name = "Column8";
            // 
            // Column10
            // 
            this.Column10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column10.HeaderText = "Serial Externo";
            this.Column10.Name = "Column10";
            // 
            // Column9
            // 
            this.Column9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column9.HeaderText = "Lote";
            this.Column9.Name = "Column9";
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column4.HeaderText = "Ubicación";
            this.Column4.Name = "Column4";
            // 
            // Column11
            // 
            this.Column11.HeaderText = "Almacén";
            this.Column11.Name = "Column11";
            // 
            // InventaryTransfer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(937, 515);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InventaryTransfer";
            this.Padding = new System.Windows.Forms.Padding(16);
            this.Text = "Transferencias";
            this.Load += new System.EventHandler(this.InventaryTransfer_Load);
            this.DoubleClick += new System.EventHandler(this.InventaryTransfer_DoubleClick);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.transferPropspanel.ResumeLayout(false);
            this.transferPropspanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resultDataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label15;
        private LoadingSpinner spinner;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView resultDataGrid;
        private System.Windows.Forms.Button applyChangesBtn;
        private System.Windows.Forms.Panel transferPropspanel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox cbDestino;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbNumParte;
        private System.Windows.Forms.ComboBox cbPartidas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label origenInfo;
        private System.Windows.Forms.ComboBox cbOptionsTransfer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label infoCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn ALMACEN;
        private System.Windows.Forms.DataGridViewTextBoxColumn UBICACIÓN;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.Label cantidadTransfer;
        private LoadingSpinner spinner2;
    }
}