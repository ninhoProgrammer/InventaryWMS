namespace InventaryWMS
{
    partial class FormDestinations
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDestinations));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxName = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonSerch = new System.Windows.Forms.Button();
            this.textboxDestination = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.pictureBoxCancel = new System.Windows.Forms.PictureBox();
            this.pictureBoxEdit = new System.Windows.Forms.PictureBox();
            this.panelPropiedades = new System.Windows.Forms.Panel();
            this.panelValid = new System.Windows.Forms.Panel();
            this.Ver = new System.Windows.Forms.Label();
            this.pictureBoxValid = new System.Windows.Forms.PictureBox();
            this.pictureBoxNotValid = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBoxContry = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxRFC = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.textBoxZipCode = new System.Windows.Forms.TextBox();
            this.textBoxState = new System.Windows.Forms.TextBox();
            this.textBoxStreet = new System.Windows.Forms.TextBox();
            this.textBoxDistrict = new System.Windows.Forms.TextBox();
            this.textBoxCity = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxImmex = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.spinner = new InventaryWMS.LoadingSpinner();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEdit)).BeginInit();
            this.panelPropiedades.SuspendLayout();
            this.panelValid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxValid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNotValid)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.BackgroundImage = global::InventaryWMS.Properties.Resources.LOGO_REIS_RGB;
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.comboBoxName);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.buttonSerch);
            this.panel1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Location = new System.Drawing.Point(10, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(725, 78);
            this.panel1.TabIndex = 60;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Location = new System.Drawing.Point(30, 43);
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
            this.comboBoxName.Location = new System.Drawing.Point(93, 40);
            this.comboBoxName.Name = "comboBoxName";
            this.comboBoxName.Size = new System.Drawing.Size(487, 23);
            this.comboBoxName.TabIndex = 58;
            this.comboBoxName.SelectedIndexChanged += new System.EventHandler(this.comboBoxName_SelectedIndexChanged);
            this.comboBoxName.MouseDown += new System.Windows.Forms.MouseEventHandler(this.comboBox_MouseDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 15.75F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(8, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 25);
            this.label2.TabIndex = 56;
            this.label2.Text = "Responsable";
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
            this.buttonSerch.Location = new System.Drawing.Point(629, 20);
            this.buttonSerch.Name = "buttonSerch";
            this.buttonSerch.Size = new System.Drawing.Size(86, 27);
            this.buttonSerch.TabIndex = 55;
            this.buttonSerch.Text = "Nuevo";
            this.buttonSerch.UseVisualStyleBackColor = false;
            this.buttonSerch.Click += new System.EventHandler(this.buttonNew_Click);
            // 
            // textboxDestination
            // 
            this.textboxDestination.AccessibleName = "Nombre";
            this.textboxDestination.BackColor = System.Drawing.SystemColors.HighlightText;
            this.textboxDestination.Enabled = false;
            this.textboxDestination.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textboxDestination.ForeColor = System.Drawing.Color.DimGray;
            this.textboxDestination.Location = new System.Drawing.Point(87, 107);
            this.textboxDestination.Name = "textboxDestination";
            this.textboxDestination.Size = new System.Drawing.Size(218, 23);
            this.textboxDestination.TabIndex = 61;
            this.textboxDestination.Click += new System.EventHandler(this.textBox_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label15.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label15.Location = new System.Drawing.Point(11, 110);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(51, 15);
            this.label15.TabIndex = 62;
            this.label15.Text = "Nombre";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label8.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label8.Location = new System.Drawing.Point(11, 139);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 15);
            this.label8.TabIndex = 65;
            this.label8.Text = "Descripción";
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.BackColor = System.Drawing.SystemColors.HighlightText;
            this.textBoxDescription.Enabled = false;
            this.textBoxDescription.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBoxDescription.ForeColor = System.Drawing.Color.DimGray;
            this.textBoxDescription.Location = new System.Drawing.Point(87, 136);
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(218, 23);
            this.textBoxDescription.TabIndex = 66;
            this.textBoxDescription.Click += new System.EventHandler(this.textBox_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(47)))), ((int)(((byte)(75)))));
            this.buttonSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonSave.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonSave.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonSave.Location = new System.Drawing.Point(623, 9);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(86, 27);
            this.buttonSave.TabIndex = 68;
            this.buttonSave.Text = "Guardar";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Visible = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // pictureBoxCancel
            // 
            this.pictureBoxCancel.AccessibleDescription = "Cancelar";
            this.pictureBoxCancel.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxCancel.BackgroundImage = global::InventaryWMS.Properties.Resources.icons8_cancelar_38;
            this.pictureBoxCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBoxCancel.Location = new System.Drawing.Point(674, 42);
            this.pictureBoxCancel.Name = "pictureBoxCancel";
            this.pictureBoxCancel.Size = new System.Drawing.Size(35, 28);
            this.pictureBoxCancel.TabIndex = 74;
            this.pictureBoxCancel.TabStop = false;
            this.pictureBoxCancel.Click += new System.EventHandler(this.pictureBoxCancel_Click);
            // 
            // pictureBoxEdit
            // 
            this.pictureBoxEdit.AccessibleDescription = "Editar";
            this.pictureBoxEdit.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxEdit.BackgroundImage = global::InventaryWMS.Properties.Resources.icons8_editar_archivo_64;
            this.pictureBoxEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBoxEdit.Location = new System.Drawing.Point(674, 42);
            this.pictureBoxEdit.Name = "pictureBoxEdit";
            this.pictureBoxEdit.Size = new System.Drawing.Size(35, 28);
            this.pictureBoxEdit.TabIndex = 75;
            this.pictureBoxEdit.TabStop = false;
            this.pictureBoxEdit.Click += new System.EventHandler(this.pictureBoxEdit_Click);
            // 
            // panelPropiedades
            // 
            this.panelPropiedades.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panelPropiedades.Controls.Add(this.panelValid);
            this.panelPropiedades.Controls.Add(this.label9);
            this.panelPropiedades.Controls.Add(this.comboBoxContry);
            this.panelPropiedades.Controls.Add(this.label6);
            this.panelPropiedades.Controls.Add(this.textBoxRFC);
            this.panelPropiedades.Controls.Add(this.panel4);
            this.panelPropiedades.Controls.Add(this.label4);
            this.panelPropiedades.Controls.Add(this.textBoxImmex);
            this.panelPropiedades.Controls.Add(this.label1);
            this.panelPropiedades.Controls.Add(this.pictureBoxEdit);
            this.panelPropiedades.Controls.Add(this.pictureBoxCancel);
            this.panelPropiedades.Controls.Add(this.buttonSave);
            this.panelPropiedades.Controls.Add(this.label8);
            this.panelPropiedades.Controls.Add(this.label15);
            this.panelPropiedades.Controls.Add(this.textboxDestination);
            this.panelPropiedades.Controls.Add(this.spinner);
            this.panelPropiedades.Controls.Add(this.textBoxDescription);
            this.panelPropiedades.Controls.Add(this.panel3);
            this.panelPropiedades.Location = new System.Drawing.Point(10, 95);
            this.panelPropiedades.Name = "panelPropiedades";
            this.panelPropiedades.Size = new System.Drawing.Size(725, 382);
            this.panelPropiedades.TabIndex = 61;
            // 
            // panelValid
            // 
            this.panelValid.Controls.Add(this.Ver);
            this.panelValid.Controls.Add(this.pictureBoxValid);
            this.panelValid.Controls.Add(this.pictureBoxNotValid);
            this.panelValid.Location = new System.Drawing.Point(115, 253);
            this.panelValid.Name = "panelValid";
            this.panelValid.Size = new System.Drawing.Size(115, 54);
            this.panelValid.TabIndex = 101;
            // 
            // Ver
            // 
            this.Ver.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.Ver.AutoSize = true;
            this.Ver.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Ver.ForeColor = System.Drawing.SystemColors.ControlLightLight;
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
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label9.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label9.Location = new System.Drawing.Point(11, 226);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(28, 15);
            this.label9.TabIndex = 100;
            this.label9.Text = "Pais";
            // 
            // comboBoxContry
            // 
            this.comboBoxContry.AccessibleName = "";
            this.comboBoxContry.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboBoxContry.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxContry.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.comboBoxContry.FormattingEnabled = true;
            this.comboBoxContry.Location = new System.Drawing.Point(87, 223);
            this.comboBoxContry.Name = "comboBoxContry";
            this.comboBoxContry.Size = new System.Drawing.Size(218, 23);
            this.comboBoxContry.TabIndex = 99;
            this.comboBoxContry.SelectedIndexChanged += new System.EventHandler(this.comboBoxContry_SelectedIndexChanged);
            this.comboBoxContry.MouseDown += new System.Windows.Forms.MouseEventHandler(this.comboBox_MouseDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label6.Location = new System.Drawing.Point(11, 198);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 15);
            this.label6.TabIndex = 98;
            this.label6.Text = "RFC";
            // 
            // textBoxRFC
            // 
            this.textBoxRFC.AccessibleName = "RFC";
            this.textBoxRFC.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBoxRFC.Location = new System.Drawing.Point(87, 194);
            this.textBoxRFC.Name = "textBoxRFC";
            this.textBoxRFC.Size = new System.Drawing.Size(218, 23);
            this.textBoxRFC.TabIndex = 97;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.Control;
            this.panel4.Controls.Add(this.label14);
            this.panel4.Controls.Add(this.label13);
            this.panel4.Controls.Add(this.label12);
            this.panel4.Controls.Add(this.label11);
            this.panel4.Controls.Add(this.label10);
            this.panel4.Controls.Add(this.label19);
            this.panel4.Controls.Add(this.textBoxZipCode);
            this.panel4.Controls.Add(this.textBoxState);
            this.panel4.Controls.Add(this.textBoxStreet);
            this.panel4.Controls.Add(this.textBoxDistrict);
            this.panel4.Controls.Add(this.textBoxCity);
            this.panel4.Location = new System.Drawing.Point(329, 94);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(380, 213);
            this.panel4.TabIndex = 96;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label14.Location = new System.Drawing.Point(18, 167);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(72, 13);
            this.label14.TabIndex = 94;
            this.label14.Text = "Código Postal";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label13.Location = new System.Drawing.Point(17, 137);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(30, 13);
            this.label13.TabIndex = 93;
            this.label13.Text = "Calle";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label12.Location = new System.Drawing.Point(18, 108);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(39, 13);
            this.label12.TabIndex = 92;
            this.label12.Text = "Distrito";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label11.Location = new System.Drawing.Point(17, 79);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 13);
            this.label11.TabIndex = 91;
            this.label11.Text = "Ciudad";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label10.Location = new System.Drawing.Point(17, 49);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 13);
            this.label10.TabIndex = 90;
            this.label10.Text = "Estado";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 12F, System.Drawing.FontStyle.Bold);
            this.label19.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label19.Location = new System.Drawing.Point(22, 10);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(71, 19);
            this.label19.TabIndex = 86;
            this.label19.Text = "Ubicación";
            // 
            // textBoxZipCode
            // 
            this.textBoxZipCode.AccessibleName = "";
            this.textBoxZipCode.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBoxZipCode.Location = new System.Drawing.Point(107, 163);
            this.textBoxZipCode.Name = "textBoxZipCode";
            this.textBoxZipCode.Size = new System.Drawing.Size(253, 23);
            this.textBoxZipCode.TabIndex = 88;
            // 
            // textBoxState
            // 
            this.textBoxState.AccessibleName = "";
            this.textBoxState.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBoxState.Location = new System.Drawing.Point(107, 46);
            this.textBoxState.Name = "textBoxState";
            this.textBoxState.Size = new System.Drawing.Size(253, 23);
            this.textBoxState.TabIndex = 84;
            // 
            // textBoxStreet
            // 
            this.textBoxStreet.AccessibleName = "";
            this.textBoxStreet.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBoxStreet.Location = new System.Drawing.Point(107, 134);
            this.textBoxStreet.Name = "textBoxStreet";
            this.textBoxStreet.Size = new System.Drawing.Size(253, 23);
            this.textBoxStreet.TabIndex = 87;
            // 
            // textBoxDistrict
            // 
            this.textBoxDistrict.AccessibleName = "";
            this.textBoxDistrict.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBoxDistrict.Location = new System.Drawing.Point(107, 105);
            this.textBoxDistrict.Name = "textBoxDistrict";
            this.textBoxDistrict.Size = new System.Drawing.Size(253, 23);
            this.textBoxDistrict.TabIndex = 86;
            // 
            // textBoxCity
            // 
            this.textBoxCity.AccessibleName = "";
            this.textBoxCity.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBoxCity.Location = new System.Drawing.Point(107, 76);
            this.textBoxCity.Name = "textBoxCity";
            this.textBoxCity.Size = new System.Drawing.Size(253, 23);
            this.textBoxCity.TabIndex = 85;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(11, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 95;
            this.label4.Text = "IMMEX";
            // 
            // textBoxImmex
            // 
            this.textBoxImmex.AccessibleName = "";
            this.textBoxImmex.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBoxImmex.Location = new System.Drawing.Point(87, 165);
            this.textBoxImmex.Name = "textBoxImmex";
            this.textBoxImmex.Size = new System.Drawing.Size(218, 23);
            this.textBoxImmex.TabIndex = 89;
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
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackgroundImage = global::InventaryWMS.Properties.Resources.Logo_preview_rev_1__2_;
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel3.Location = new System.Drawing.Point(485, 190);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(736, 346);
            this.panel3.TabIndex = 102;
            // 
            // FormDestinations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(47)))), ((int)(((byte)(75)))));
            this.ClientSize = new System.Drawing.Size(747, 489);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelPropiedades);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormDestinations";
            this.Text = "Destinos";
            this.Load += new System.EventHandler(this.FormDestinations_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEdit)).EndInit();
            this.panelPropiedades.ResumeLayout(false);
            this.panelPropiedades.PerformLayout();
            this.panelValid.ResumeLayout(false);
            this.panelValid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxValid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNotValid)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonSerch;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxName;
        private LoadingSpinner spinner;
        private System.Windows.Forms.TextBox textboxDestination;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.PictureBox pictureBoxCancel;
        private System.Windows.Forms.PictureBox pictureBoxEdit;
        private System.Windows.Forms.Panel panelPropiedades;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxImmex;
        private System.Windows.Forms.TextBox textBoxZipCode;
        private System.Windows.Forms.TextBox textBoxStreet;
        private System.Windows.Forms.TextBox textBoxState;
        private System.Windows.Forms.TextBox textBoxCity;
        private System.Windows.Forms.TextBox textBoxDistrict;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxRFC;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBoxContry;
        private System.Windows.Forms.Panel panelValid;
        private System.Windows.Forms.PictureBox pictureBoxValid;
        private System.Windows.Forms.Label Ver;
        private System.Windows.Forms.PictureBox pictureBoxNotValid;
        private System.Windows.Forms.Panel panel3;
    }
}