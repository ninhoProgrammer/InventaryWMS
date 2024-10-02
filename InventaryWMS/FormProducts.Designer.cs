namespace InventaryWMS
{
    partial class FormProducts
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormProducts));
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.textBoxNumberPartProvider = new System.Windows.Forms.TextBox();
            this.textBoxNumberPartClient = new System.Windows.Forms.TextBox();
            this.comboBoxCurrency = new System.Windows.Forms.ComboBox();
            this.comboBoxMeassurmentUnit = new System.Windows.Forms.ComboBox();
            this.comboBoxContry = new System.Windows.Forms.ComboBox();
            this.textBoxReferrence = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.comboBoxDescription = new System.Windows.Forms.ComboBox();
            this.buttonNew = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelPropiedades = new System.Windows.Forms.Panel();
            this.numericUpDownWeight = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownStandarPack = new System.Windows.Forms.NumericUpDown();
            this.spinner = new InventaryWMS.LoadingSpinner();
            this.panelValid = new System.Windows.Forms.Panel();
            this.Ver = new System.Windows.Forms.Label();
            this.pictureBoxValid = new System.Windows.Forms.PictureBox();
            this.pictureBoxNotValid = new System.Windows.Forms.PictureBox();
            this.numericUpDownUnitValue = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDownItemForBox = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownTariffFraction = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBoxEdit = new System.Windows.Forms.PictureBox();
            this.pictureBoxCancel = new System.Windows.Forms.PictureBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label16 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panelPropiedades.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStandarPack)).BeginInit();
            this.panelValid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxValid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNotValid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownUnitValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownItemForBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTariffFraction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCancel)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.AccessibleName = "Nombre";
            this.textBoxDescription.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBoxDescription.ForeColor = System.Drawing.SystemColors.GrayText;
            this.textBoxDescription.Location = new System.Drawing.Point(92, 100);
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(244, 23);
            this.textBoxDescription.TabIndex = 0;
            this.textBoxDescription.Click += new System.EventHandler(this.control_Click);
            this.textBoxDescription.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxDescription_KeyPress);
            // 
            // textBoxNumberPartProvider
            // 
            this.textBoxNumberPartProvider.AccessibleName = "N.P.";
            this.textBoxNumberPartProvider.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBoxNumberPartProvider.ForeColor = System.Drawing.SystemColors.GrayText;
            this.textBoxNumberPartProvider.Location = new System.Drawing.Point(92, 129);
            this.textBoxNumberPartProvider.Name = "textBoxNumberPartProvider";
            this.textBoxNumberPartProvider.Size = new System.Drawing.Size(244, 23);
            this.textBoxNumberPartProvider.TabIndex = 1;
            this.textBoxNumberPartProvider.Click += new System.EventHandler(this.control_Click);
            this.textBoxNumberPartProvider.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxNumberPartProvider_KeyPress);
            // 
            // textBoxNumberPartClient
            // 
            this.textBoxNumberPartClient.AccessibleName = "Número de Parte del Cliente";
            this.textBoxNumberPartClient.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBoxNumberPartClient.ForeColor = System.Drawing.SystemColors.GrayText;
            this.textBoxNumberPartClient.Location = new System.Drawing.Point(92, 158);
            this.textBoxNumberPartClient.Name = "textBoxNumberPartClient";
            this.textBoxNumberPartClient.Size = new System.Drawing.Size(244, 23);
            this.textBoxNumberPartClient.TabIndex = 2;
            this.textBoxNumberPartClient.Click += new System.EventHandler(this.control_Click);
            this.textBoxNumberPartClient.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxNumberPartClient_KeyPress);
            // 
            // comboBoxCurrency
            // 
            this.comboBoxCurrency.AccessibleName = "Moneda";
            this.comboBoxCurrency.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboBoxCurrency.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxCurrency.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.comboBoxCurrency.ForeColor = System.Drawing.SystemColors.GrayText;
            this.comboBoxCurrency.FormattingEnabled = true;
            this.comboBoxCurrency.Location = new System.Drawing.Point(538, 259);
            this.comboBoxCurrency.Name = "comboBoxCurrency";
            this.comboBoxCurrency.Size = new System.Drawing.Size(103, 23);
            this.comboBoxCurrency.TabIndex = 11;
            this.comboBoxCurrency.Click += new System.EventHandler(this.control_Click);
            this.comboBoxCurrency.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBoxCurrency_KeyPress);
            this.comboBoxCurrency.MouseDown += new System.Windows.Forms.MouseEventHandler(this.comboBox_MouseDown);
            // 
            // comboBoxMeassurmentUnit
            // 
            this.comboBoxMeassurmentUnit.AccessibleName = "Unidad de Medida";
            this.comboBoxMeassurmentUnit.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboBoxMeassurmentUnit.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxMeassurmentUnit.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.comboBoxMeassurmentUnit.ForeColor = System.Drawing.SystemColors.GrayText;
            this.comboBoxMeassurmentUnit.FormattingEnabled = true;
            this.comboBoxMeassurmentUnit.Location = new System.Drawing.Point(538, 234);
            this.comboBoxMeassurmentUnit.Name = "comboBoxMeassurmentUnit";
            this.comboBoxMeassurmentUnit.Size = new System.Drawing.Size(103, 23);
            this.comboBoxMeassurmentUnit.TabIndex = 10;
            this.comboBoxMeassurmentUnit.Click += new System.EventHandler(this.control_Click);
            this.comboBoxMeassurmentUnit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBoxMeassurmentUnit_KeyPress);
            this.comboBoxMeassurmentUnit.MouseDown += new System.Windows.Forms.MouseEventHandler(this.comboBox_MouseDown);
            // 
            // comboBoxContry
            // 
            this.comboBoxContry.AccessibleName = "Pais de Origen";
            this.comboBoxContry.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboBoxContry.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxContry.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.comboBoxContry.ForeColor = System.Drawing.SystemColors.GrayText;
            this.comboBoxContry.FormattingEnabled = true;
            this.comboBoxContry.Location = new System.Drawing.Point(92, 216);
            this.comboBoxContry.Name = "comboBoxContry";
            this.comboBoxContry.Size = new System.Drawing.Size(244, 23);
            this.comboBoxContry.TabIndex = 4;
            this.comboBoxContry.Click += new System.EventHandler(this.control_Click);
            this.comboBoxContry.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBoxContry_KeyPress);
            this.comboBoxContry.MouseDown += new System.Windows.Forms.MouseEventHandler(this.comboBox_MouseDown);
            // 
            // textBoxReferrence
            // 
            this.textBoxReferrence.AccessibleName = "Referencia";
            this.textBoxReferrence.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBoxReferrence.ForeColor = System.Drawing.SystemColors.GrayText;
            this.textBoxReferrence.Location = new System.Drawing.Point(92, 187);
            this.textBoxReferrence.Name = "textBoxReferrence";
            this.textBoxReferrence.Size = new System.Drawing.Size(244, 23);
            this.textBoxReferrence.TabIndex = 3;
            this.textBoxReferrence.Click += new System.EventHandler(this.control_Click);
            this.textBoxReferrence.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxReferrence_KeyPress);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackgroundImage = global::InventaryWMS.Properties.Resources.Logo_preview_rev_1__2_;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Location = new System.Drawing.Point(346, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1019, 516);
            this.panel1.TabIndex = 20;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel2.Controls.Add(this.comboBoxDescription);
            this.panel2.Controls.Add(this.buttonNew);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(10, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(671, 96);
            this.panel2.TabIndex = 21;
            // 
            // comboBoxDescription
            // 
            this.comboBoxDescription.AccessibleName = "Pais de Origen";
            this.comboBoxDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboBoxDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxDescription.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.comboBoxDescription.ForeColor = System.Drawing.SystemColors.GrayText;
            this.comboBoxDescription.FormattingEnabled = true;
            this.comboBoxDescription.Location = new System.Drawing.Point(116, 37);
            this.comboBoxDescription.Name = "comboBoxDescription";
            this.comboBoxDescription.Size = new System.Drawing.Size(430, 23);
            this.comboBoxDescription.TabIndex = 79;
            this.comboBoxDescription.SelectedIndexChanged += new System.EventHandler(this.comboBoxDescription_SelectedIndexChanged);
            this.comboBoxDescription.Click += new System.EventHandler(this.comboBoxDescription_SelectedIndexChanged);
            this.comboBoxDescription.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBoxDescription_KeyPress);
            this.comboBoxDescription.MouseDown += new System.Windows.Forms.MouseEventHandler(this.comboBox_MouseDown);
            // 
            // buttonNew
            // 
            this.buttonNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(47)))), ((int)(((byte)(75)))));
            this.buttonNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonNew.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.buttonNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNew.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonNew.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonNew.Location = new System.Drawing.Point(577, 20);
            this.buttonNew.Name = "buttonNew";
            this.buttonNew.Size = new System.Drawing.Size(86, 27);
            this.buttonNew.TabIndex = 78;
            this.buttonNew.Text = "Nuevo";
            this.buttonNew.UseVisualStyleBackColor = false;
            this.buttonNew.Click += new System.EventHandler(this.buttonNew_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 15.75F, System.Drawing.FontStyle.Bold);
            this.label15.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label15.Location = new System.Drawing.Point(8, 3);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(94, 25);
            this.label15.TabIndex = 43;
            this.label15.Text = "Productos";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(15, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "Nombre";
            // 
            // panelPropiedades
            // 
            this.panelPropiedades.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panelPropiedades.Controls.Add(this.numericUpDownWeight);
            this.panelPropiedades.Controls.Add(this.numericUpDownStandarPack);
            this.panelPropiedades.Controls.Add(this.spinner);
            this.panelPropiedades.Controls.Add(this.panelValid);
            this.panelPropiedades.Controls.Add(this.numericUpDownUnitValue);
            this.panelPropiedades.Controls.Add(this.label4);
            this.panelPropiedades.Controls.Add(this.numericUpDownItemForBox);
            this.panelPropiedades.Controls.Add(this.comboBoxContry);
            this.panelPropiedades.Controls.Add(this.numericUpDownTariffFraction);
            this.panelPropiedades.Controls.Add(this.label7);
            this.panelPropiedades.Controls.Add(this.label6);
            this.panelPropiedades.Controls.Add(this.comboBoxMeassurmentUnit);
            this.panelPropiedades.Controls.Add(this.label3);
            this.panelPropiedades.Controls.Add(this.textBoxReferrence);
            this.panelPropiedades.Controls.Add(this.label2);
            this.panelPropiedades.Controls.Add(this.comboBoxCurrency);
            this.panelPropiedades.Controls.Add(this.pictureBoxEdit);
            this.panelPropiedades.Controls.Add(this.pictureBoxCancel);
            this.panelPropiedades.Controls.Add(this.buttonSave);
            this.panelPropiedades.Controls.Add(this.label5);
            this.panelPropiedades.Controls.Add(this.textBoxDescription);
            this.panelPropiedades.Controls.Add(this.textBoxNumberPartClient);
            this.panelPropiedades.Controls.Add(this.textBoxNumberPartProvider);
            this.panelPropiedades.Controls.Add(this.panel4);
            this.panelPropiedades.Controls.Add(this.panel1);
            this.panelPropiedades.Location = new System.Drawing.Point(10, 115);
            this.panelPropiedades.Name = "panelPropiedades";
            this.panelPropiedades.Size = new System.Drawing.Size(671, 313);
            this.panelPropiedades.TabIndex = 22;
            // 
            // numericUpDownWeight
            // 
            this.numericUpDownWeight.DecimalPlaces = 3;
            this.numericUpDownWeight.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numericUpDownWeight.ForeColor = System.Drawing.SystemColors.GrayText;
            this.numericUpDownWeight.InterceptArrowKeys = false;
            this.numericUpDownWeight.Location = new System.Drawing.Point(538, 209);
            this.numericUpDownWeight.Maximum = new decimal(new int[] {
            900000,
            0,
            0,
            0});
            this.numericUpDownWeight.Name = "numericUpDownWeight";
            this.numericUpDownWeight.Size = new System.Drawing.Size(103, 23);
            this.numericUpDownWeight.TabIndex = 9;
            this.numericUpDownWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownWeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericUpDownWeight_KeyPress);
            // 
            // numericUpDownStandarPack
            // 
            this.numericUpDownStandarPack.DecimalPlaces = 3;
            this.numericUpDownStandarPack.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numericUpDownStandarPack.ForeColor = System.Drawing.SystemColors.GrayText;
            this.numericUpDownStandarPack.InterceptArrowKeys = false;
            this.numericUpDownStandarPack.Location = new System.Drawing.Point(538, 184);
            this.numericUpDownStandarPack.Maximum = new decimal(new int[] {
            9000,
            0,
            0,
            0});
            this.numericUpDownStandarPack.Name = "numericUpDownStandarPack";
            this.numericUpDownStandarPack.Size = new System.Drawing.Size(103, 23);
            this.numericUpDownStandarPack.TabIndex = 8;
            this.numericUpDownStandarPack.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownStandarPack.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericUpDownStandarPack_KeyPress);
            // 
            // spinner
            // 
            this.spinner.BackColor = System.Drawing.Color.Transparent;
            this.spinner.Location = new System.Drawing.Point(531, 2);
            this.spinner.MaximumSize = new System.Drawing.Size(40, 40);
            this.spinner.MinimumSize = new System.Drawing.Size(40, 40);
            this.spinner.Name = "spinner";
            this.spinner.Size = new System.Drawing.Size(40, 40);
            this.spinner.TabIndex = 0;
            this.spinner.TabStop = false;
            this.spinner.Visible = false;
            // 
            // panelValid
            // 
            this.panelValid.Controls.Add(this.Ver);
            this.panelValid.Controls.Add(this.pictureBoxValid);
            this.panelValid.Controls.Add(this.pictureBoxNotValid);
            this.panelValid.Location = new System.Drawing.Point(154, 244);
            this.panelValid.Name = "panelValid";
            this.panelValid.Size = new System.Drawing.Size(115, 54);
            this.panelValid.TabIndex = 88;
            // 
            // Ver
            // 
            this.Ver.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.Ver.AutoSize = true;
            this.Ver.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Ver.ForeColor = System.Drawing.SystemColors.GrayText;
            this.Ver.Location = new System.Drawing.Point(7, 18);
            this.Ver.Name = "Ver";
            this.Ver.Size = new System.Drawing.Size(23, 15);
            this.Ver.TabIndex = 79;
            this.Ver.Text = "Ver";
            // 
            // pictureBoxValid
            // 
            this.pictureBoxValid.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxValid.BackgroundImage")));
            this.pictureBoxValid.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBoxValid.Location = new System.Drawing.Point(36, 9);
            this.pictureBoxValid.Name = "pictureBoxValid";
            this.pictureBoxValid.Size = new System.Drawing.Size(67, 37);
            this.pictureBoxValid.TabIndex = 82;
            this.pictureBoxValid.TabStop = false;
            this.pictureBoxValid.Click += new System.EventHandler(this.pictureBoxValid_Click);
            // 
            // pictureBoxNotValid
            // 
            this.pictureBoxNotValid.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxNotValid.BackgroundImage")));
            this.pictureBoxNotValid.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBoxNotValid.Location = new System.Drawing.Point(36, 9);
            this.pictureBoxNotValid.Name = "pictureBoxNotValid";
            this.pictureBoxNotValid.Size = new System.Drawing.Size(67, 37);
            this.pictureBoxNotValid.TabIndex = 81;
            this.pictureBoxNotValid.TabStop = false;
            this.pictureBoxNotValid.Click += new System.EventHandler(this.pictureBoxNotValid_Click);
            // 
            // numericUpDownUnitValue
            // 
            this.numericUpDownUnitValue.DecimalPlaces = 3;
            this.numericUpDownUnitValue.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numericUpDownUnitValue.ForeColor = System.Drawing.SystemColors.GrayText;
            this.numericUpDownUnitValue.InterceptArrowKeys = false;
            this.numericUpDownUnitValue.Location = new System.Drawing.Point(538, 159);
            this.numericUpDownUnitValue.Maximum = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            this.numericUpDownUnitValue.Name = "numericUpDownUnitValue";
            this.numericUpDownUnitValue.Size = new System.Drawing.Size(103, 23);
            this.numericUpDownUnitValue.TabIndex = 7;
            this.numericUpDownUnitValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownUnitValue.ValueChanged += new System.EventHandler(this.numericUpDownUnitValue_ValueChanged);
            this.numericUpDownUnitValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericUpDownUnitValue_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(17, 219);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 15);
            this.label4.TabIndex = 87;
            this.label4.Text = "Pais Origen";
            // 
            // numericUpDownItemForBox
            // 
            this.numericUpDownItemForBox.DecimalPlaces = 3;
            this.numericUpDownItemForBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numericUpDownItemForBox.ForeColor = System.Drawing.SystemColors.GrayText;
            this.numericUpDownItemForBox.InterceptArrowKeys = false;
            this.numericUpDownItemForBox.Location = new System.Drawing.Point(538, 134);
            this.numericUpDownItemForBox.Maximum = new decimal(new int[] {
            9000,
            0,
            0,
            0});
            this.numericUpDownItemForBox.Name = "numericUpDownItemForBox";
            this.numericUpDownItemForBox.Size = new System.Drawing.Size(103, 23);
            this.numericUpDownItemForBox.TabIndex = 6;
            this.numericUpDownItemForBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownItemForBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericUpDownItemForBox_KeyPress);
            // 
            // numericUpDownTariffFraction
            // 
            this.numericUpDownTariffFraction.DecimalPlaces = 3;
            this.numericUpDownTariffFraction.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numericUpDownTariffFraction.ForeColor = System.Drawing.SystemColors.GrayText;
            this.numericUpDownTariffFraction.InterceptArrowKeys = false;
            this.numericUpDownTariffFraction.Location = new System.Drawing.Point(538, 109);
            this.numericUpDownTariffFraction.Maximum = new decimal(new int[] {
            9000,
            0,
            0,
            0});
            this.numericUpDownTariffFraction.Name = "numericUpDownTariffFraction";
            this.numericUpDownTariffFraction.Size = new System.Drawing.Size(103, 23);
            this.numericUpDownTariffFraction.TabIndex = 5;
            this.numericUpDownTariffFraction.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownTariffFraction.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericUpDownTariffFraction_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label7.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label7.Location = new System.Drawing.Point(17, 190);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 15);
            this.label7.TabIndex = 84;
            this.label7.Text = "Referencia";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label6.Location = new System.Drawing.Point(17, 161);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 15);
            this.label6.TabIndex = 83;
            this.label6.Text = "N.P. Cliente";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(17, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 15);
            this.label3.TabIndex = 82;
            this.label3.Text = "N.P.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 15.75F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(8, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 25);
            this.label2.TabIndex = 81;
            this.label2.Text = "Propiedades";
            // 
            // pictureBoxEdit
            // 
            this.pictureBoxEdit.AccessibleDescription = "Editar";
            this.pictureBoxEdit.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxEdit.BackgroundImage = global::InventaryWMS.Properties.Resources.icons8_editar_archivo_64;
            this.pictureBoxEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBoxEdit.Location = new System.Drawing.Point(628, 44);
            this.pictureBoxEdit.Name = "pictureBoxEdit";
            this.pictureBoxEdit.Size = new System.Drawing.Size(35, 28);
            this.pictureBoxEdit.TabIndex = 80;
            this.pictureBoxEdit.TabStop = false;
            this.pictureBoxEdit.Click += new System.EventHandler(this.pictureBoxEdit_Click);
            // 
            // pictureBoxCancel
            // 
            this.pictureBoxCancel.AccessibleDescription = "Cancelar";
            this.pictureBoxCancel.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxCancel.BackgroundImage = global::InventaryWMS.Properties.Resources.icons8_cancelar_38;
            this.pictureBoxCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBoxCancel.Location = new System.Drawing.Point(628, 44);
            this.pictureBoxCancel.Name = "pictureBoxCancel";
            this.pictureBoxCancel.Size = new System.Drawing.Size(35, 28);
            this.pictureBoxCancel.TabIndex = 79;
            this.pictureBoxCancel.TabStop = false;
            this.pictureBoxCancel.Click += new System.EventHandler(this.pictureBoxCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(47)))), ((int)(((byte)(75)))));
            this.buttonSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonSave.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonSave.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonSave.Location = new System.Drawing.Point(577, 8);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(86, 27);
            this.buttonSave.TabIndex = 12;
            this.buttonSave.Text = "Guardar";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Visible = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            this.buttonSave.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.buttonSave_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Location = new System.Drawing.Point(17, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 15);
            this.label5.TabIndex = 23;
            this.label5.Text = "Nombre";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.Control;
            this.panel4.Controls.Add(this.label16);
            this.panel4.Controls.Add(this.label14);
            this.panel4.Controls.Add(this.label13);
            this.panel4.Controls.Add(this.label12);
            this.panel4.Controls.Add(this.label11);
            this.panel4.Controls.Add(this.label10);
            this.panel4.Controls.Add(this.label9);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Location = new System.Drawing.Point(354, 78);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(309, 217);
            this.panel4.TabIndex = 86;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label16.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label16.Location = new System.Drawing.Point(57, 183);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(51, 15);
            this.label16.TabIndex = 92;
            this.label16.Text = "Moneda";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label14.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label14.Location = new System.Drawing.Point(57, 158);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(104, 15);
            this.label14.TabIndex = 91;
            this.label14.Text = "Unidad de Medida";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label13.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label13.Location = new System.Drawing.Point(57, 107);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(75, 15);
            this.label13.TabIndex = 90;
            this.label13.Text = "Standar Pack";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label12.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label12.Location = new System.Drawing.Point(57, 132);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(32, 15);
            this.label12.TabIndex = 89;
            this.label12.Text = "Peso";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label11.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label11.Location = new System.Drawing.Point(57, 82);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(78, 15);
            this.label11.TabIndex = 88;
            this.label11.Text = "Valor Unitario";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label10.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label10.Location = new System.Drawing.Point(57, 35);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(112, 15);
            this.label10.TabIndex = 87;
            this.label10.Text = "Fracción arancelaria";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 12F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label9.Location = new System.Drawing.Point(22, 10);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 19);
            this.label9.TabIndex = 86;
            this.label9.Text = "Unidad";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label8.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label8.Location = new System.Drawing.Point(57, 57);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 15);
            this.label8.TabIndex = 85;
            this.label8.Text = "Articulos por caja";
            // 
            // FormProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(47)))), ((int)(((byte)(75)))));
            this.ClientSize = new System.Drawing.Size(691, 434);
            this.Controls.Add(this.panelPropiedades);
            this.Controls.Add(this.panel2);
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormProducts";
            this.ShowInTaskbar = false;
            this.Text = "Productos";
            this.Activated += new System.EventHandler(this.FormProducts_Activated);
            this.Load += new System.EventHandler(this.FormProducts_Load);
            this.Click += new System.EventHandler(this.FormProducts_Click);
            this.Enter += new System.EventHandler(this.FormProducts_Enter);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FormProducts_MouseClick);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panelPropiedades.ResumeLayout(false);
            this.panelPropiedades.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStandarPack)).EndInit();
            this.panelValid.ResumeLayout(false);
            this.panelValid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxValid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNotValid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownUnitValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownItemForBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTariffFraction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCancel)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.TextBox textBoxNumberPartProvider;
        private System.Windows.Forms.TextBox textBoxNumberPartClient;
        private System.Windows.Forms.ComboBox comboBoxCurrency;
        private System.Windows.Forms.ComboBox comboBoxMeassurmentUnit;
        private System.Windows.Forms.ComboBox comboBoxContry;
        private System.Windows.Forms.TextBox textBoxReferrence;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelPropiedades;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBoxEdit;
        private System.Windows.Forms.PictureBox pictureBoxCancel;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button buttonNew;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panelValid;
        private System.Windows.Forms.PictureBox pictureBoxValid;
        private System.Windows.Forms.Label Ver;
        private System.Windows.Forms.PictureBox pictureBoxNotValid;
        private System.Windows.Forms.NumericUpDown numericUpDownItemForBox;
        private System.Windows.Forms.NumericUpDown numericUpDownTariffFraction;
        private System.Windows.Forms.NumericUpDown numericUpDownUnitValue;
        private System.Windows.Forms.NumericUpDown numericUpDownWeight;
        private System.Windows.Forms.NumericUpDown numericUpDownStandarPack;
        private LoadingSpinner spinner;
        private System.Windows.Forms.ComboBox comboBoxDescription;
    }
}