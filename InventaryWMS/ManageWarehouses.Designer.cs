using InventaryWMS;
using static System.Net.Mime.MediaTypeNames;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;

namespace InventaryWMS
{
    partial class ManageWarehouses
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
            this.components = new System.ComponentModel.Container();
            this.wareHousesPanel = new System.Windows.Forms.Panel();
            this.panelWHList = new System.Windows.Forms.Panel();
            this.createWarehouse = new System.Windows.Forms.Button();
            this.endSearchButton = new System.Windows.Forms.Button();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.spinnerWhList = new InventaryWMS.LoadingSpinner();
            this.whPropertiesPanel = new System.Windows.Forms.Panel();
            this.rackPropertiespanel = new System.Windows.Forms.Panel();
            this.setRacksLenBtn = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.numLevels = new System.Windows.Forms.NumericUpDown();
            this.numRacks = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.cbFormat = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.viewRacksBtn = new System.Windows.Forms.Button();
            this.propsTitle = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.locationPanel = new System.Windows.Forms.Panel();
            this.cbState = new System.Windows.Forms.ComboBox();
            this.cbCountry = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tbZipcode = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbStreet = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tbColony = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tbCity = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.whDescription = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.whShortName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.whFullName = new System.Windows.Forms.TextBox();
            this.spinner = new InventaryWMS.LoadingSpinner();
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonCW = new System.Windows.Forms.Button();
            this.nuevoAlmacénToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarElAlmacénSeleccionadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.wareHousesPanel.SuspendLayout();
            this.whPropertiesPanel.SuspendLayout();
            this.rackPropertiespanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLevels)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRacks)).BeginInit();
            this.locationPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // wareHousesPanel
            // 
            this.wareHousesPanel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.wareHousesPanel.Controls.Add(this.panelWHList);
            this.wareHousesPanel.Controls.Add(this.createWarehouse);
            this.wareHousesPanel.Controls.Add(this.endSearchButton);
            this.wareHousesPanel.Controls.Add(this.searchTextBox);
            this.wareHousesPanel.Controls.Add(this.label15);
            this.wareHousesPanel.Controls.Add(this.spinnerWhList);
            this.wareHousesPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.wareHousesPanel.Location = new System.Drawing.Point(14, 14);
            this.wareHousesPanel.Name = "wareHousesPanel";
            this.wareHousesPanel.Padding = new System.Windows.Forms.Padding(14, 9, 14, 9);
            this.wareHousesPanel.Size = new System.Drawing.Size(849, 225);
            this.wareHousesPanel.TabIndex = 23;
            // 
            // panelWHList
            // 
            this.panelWHList.AutoScroll = true;
            this.panelWHList.AutoScrollMargin = new System.Drawing.Size(10, 10);
            this.panelWHList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelWHList.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelWHList.Location = new System.Drawing.Point(14, 53);
            this.panelWHList.Name = "panelWHList";
            this.panelWHList.Size = new System.Drawing.Size(821, 163);
            this.panelWHList.TabIndex = 41;
            // 
            // createWarehouse
            // 
            this.createWarehouse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.createWarehouse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(47)))), ((int)(((byte)(75)))));
            this.createWarehouse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.createWarehouse.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.createWarehouse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createWarehouse.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.createWarehouse.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.createWarehouse.Location = new System.Drawing.Point(506, 17);
            this.createWarehouse.Name = "createWarehouse";
            this.createWarehouse.Size = new System.Drawing.Size(86, 27);
            this.createWarehouse.TabIndex = 35;
            this.createWarehouse.Text = "Nuevo Almacén";
            this.createWarehouse.UseVisualStyleBackColor = false;
            this.createWarehouse.Click += new System.EventHandler(this.createWarehouse_Click);
            // 
            // endSearchButton
            // 
            this.endSearchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.endSearchButton.BackColor = System.Drawing.Color.Transparent;
            this.endSearchButton.BackgroundImage = global::InventaryWMS.Properties.Resources.icons8_cancelar_64;
            this.endSearchButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.endSearchButton.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.endSearchButton.FlatAppearance.BorderSize = 0;
            this.endSearchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.endSearchButton.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 9F);
            this.endSearchButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.endSearchButton.Location = new System.Drawing.Point(802, 16);
            this.endSearchButton.Name = "endSearchButton";
            this.endSearchButton.Size = new System.Drawing.Size(35, 28);
            this.endSearchButton.TabIndex = 39;
            this.endSearchButton.UseVisualStyleBackColor = false;
            this.endSearchButton.Visible = false;
            this.endSearchButton.Click += new System.EventHandler(this.endSearchButton_Click_1);
            // 
            // searchTextBox
            // 
            this.searchTextBox.AccessibleDescription = "Buscar almacén";
            this.searchTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.searchTextBox.BackColor = System.Drawing.SystemColors.HighlightText;
            this.searchTextBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchTextBox.ForeColor = System.Drawing.Color.DimGray;
            this.searchTextBox.Location = new System.Drawing.Point(602, 20);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(199, 23);
            this.searchTextBox.TabIndex = 40;
            this.searchTextBox.TextChanged += new System.EventHandler(this.searchTextBox_TextChanged_1);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 15.75F, System.Drawing.FontStyle.Bold);
            this.label15.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label15.Location = new System.Drawing.Point(8, 3);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(255, 25);
            this.label15.TabIndex = 8;
            this.label15.Text = "Administración de almacenes";
            // 
            // spinnerWhList
            // 
            this.spinnerWhList.BackColor = System.Drawing.Color.Transparent;
            this.spinnerWhList.Location = new System.Drawing.Point(460, 10);
            this.spinnerWhList.MaximumSize = new System.Drawing.Size(40, 40);
            this.spinnerWhList.MinimumSize = new System.Drawing.Size(40, 40);
            this.spinnerWhList.Name = "spinnerWhList";
            this.spinnerWhList.Size = new System.Drawing.Size(40, 40);
            this.spinnerWhList.TabIndex = 35;
            // 
            // whPropertiesPanel
            // 
            this.whPropertiesPanel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.whPropertiesPanel.Controls.Add(this.rackPropertiespanel);
            this.whPropertiesPanel.Controls.Add(this.statusLabel);
            this.whPropertiesPanel.Controls.Add(this.cancelButton);
            this.whPropertiesPanel.Controls.Add(this.editButton);
            this.whPropertiesPanel.Controls.Add(this.viewRacksBtn);
            this.whPropertiesPanel.Controls.Add(this.propsTitle);
            this.whPropertiesPanel.Controls.Add(this.saveButton);
            this.whPropertiesPanel.Controls.Add(this.locationPanel);
            this.whPropertiesPanel.Controls.Add(this.whDescription);
            this.whPropertiesPanel.Controls.Add(this.label3);
            this.whPropertiesPanel.Controls.Add(this.label2);
            this.whPropertiesPanel.Controls.Add(this.whShortName);
            this.whPropertiesPanel.Controls.Add(this.label1);
            this.whPropertiesPanel.Controls.Add(this.whFullName);
            this.whPropertiesPanel.Controls.Add(this.spinner);
            this.whPropertiesPanel.Controls.Add(this.panel3);
            this.whPropertiesPanel.Controls.Add(this.buttonCW);
            this.whPropertiesPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.whPropertiesPanel.Enabled = false;
            this.whPropertiesPanel.Location = new System.Drawing.Point(14, 245);
            this.whPropertiesPanel.Name = "whPropertiesPanel";
            this.whPropertiesPanel.Size = new System.Drawing.Size(849, 364);
            this.whPropertiesPanel.TabIndex = 24;
            // 
            // rackPropertiespanel
            // 
            this.rackPropertiespanel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.rackPropertiespanel.Controls.Add(this.setRacksLenBtn);
            this.rackPropertiespanel.Controls.Add(this.label7);
            this.rackPropertiespanel.Controls.Add(this.numLevels);
            this.rackPropertiespanel.Controls.Add(this.numRacks);
            this.rackPropertiespanel.Controls.Add(this.label6);
            this.rackPropertiespanel.Controls.Add(this.cbFormat);
            this.rackPropertiespanel.Controls.Add(this.label16);
            this.rackPropertiespanel.Controls.Add(this.label17);
            this.rackPropertiespanel.Controls.Add(this.label18);
            this.rackPropertiespanel.Font = new System.Drawing.Font("Bahnschrift Light SemiCondensed", 9F);
            this.rackPropertiespanel.Location = new System.Drawing.Point(17, 152);
            this.rackPropertiespanel.Name = "rackPropertiespanel";
            this.rackPropertiespanel.Size = new System.Drawing.Size(396, 189);
            this.rackPropertiespanel.TabIndex = 36;
            this.rackPropertiespanel.Visible = false;
            // 
            // setRacksLenBtn
            // 
            this.setRacksLenBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.setRacksLenBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(47)))), ((int)(((byte)(75)))));
            this.setRacksLenBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.setRacksLenBtn.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.setRacksLenBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.setRacksLenBtn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.setRacksLenBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.setRacksLenBtn.Location = new System.Drawing.Point(290, 149);
            this.setRacksLenBtn.Name = "setRacksLenBtn";
            this.setRacksLenBtn.Size = new System.Drawing.Size(86, 27);
            this.setRacksLenBtn.TabIndex = 41;
            this.setRacksLenBtn.Text = "Establecer";
            this.setRacksLenBtn.UseVisualStyleBackColor = false;
            this.setRacksLenBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label7.Location = new System.Drawing.Point(18, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(211, 15);
            this.label7.TabIndex = 41;
            this.label7.Text = "Carácteristicas generales de los racks";
            // 
            // numLevels
            // 
            this.numLevels.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numLevels.ForeColor = System.Drawing.SystemColors.GrayText;
            this.numLevels.InterceptArrowKeys = false;
            this.numLevels.Location = new System.Drawing.Point(290, 112);
            this.numLevels.Name = "numLevels";
            this.numLevels.Size = new System.Drawing.Size(86, 23);
            this.numLevels.TabIndex = 39;
            this.numLevels.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numLevels.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            // 
            // numRacks
            // 
            this.numRacks.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numRacks.ForeColor = System.Drawing.SystemColors.GrayText;
            this.numRacks.InterceptArrowKeys = false;
            this.numRacks.Location = new System.Drawing.Point(290, 79);
            this.numRacks.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numRacks.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numRacks.Name = "numRacks";
            this.numRacks.Size = new System.Drawing.Size(86, 23);
            this.numRacks.TabIndex = 38;
            this.numRacks.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numRacks.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numRacks.ValueChanged += new System.EventHandler(this.numRacks_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label6.Location = new System.Drawing.Point(19, 154);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(147, 15);
            this.label6.TabIndex = 37;
            this.label6.Text = "Longitud máxima por rack";
            this.toolTip1.SetToolTip(this.label6, "Representa el número de posiciones horizontales del rack");
            // 
            // cbFormat
            // 
            this.cbFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFormat.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFormat.ForeColor = System.Drawing.SystemColors.GrayText;
            this.cbFormat.FormattingEnabled = true;
            this.cbFormat.Items.AddRange(new object[] {
            "Numérico - (1, 2, 3...)",
            "Letras -(A, B, C...)"});
            this.cbFormat.Location = new System.Drawing.Point(182, 46);
            this.cbFormat.Name = "cbFormat";
            this.cbFormat.Size = new System.Drawing.Size(194, 23);
            this.cbFormat.TabIndex = 35;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label16.Location = new System.Drawing.Point(19, 117);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(153, 15);
            this.label16.TabIndex = 23;
            this.label16.Text = "Número máximo de niveles";
            this.toolTip1.SetToolTip(this.label16, "Representa el número máximo de niveles que tiene el rack");
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label17.Location = new System.Drawing.Point(19, 84);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(165, 15);
            this.label17.TabIndex = 21;
            this.label17.Text = "Cantidad de racks en almacén";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label18.Location = new System.Drawing.Point(19, 48);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(113, 15);
            this.label18.TabIndex = 19;
            this.label18.Text = "Formato de nombre";
            // 
            // statusLabel
            // 
            this.statusLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLabel.ForeColor = System.Drawing.SystemColors.GrayText;
            this.statusLabel.Location = new System.Drawing.Point(442, 13);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(257, 17);
            this.statusLabel.TabIndex = 37;
            this.statusLabel.Text = "Estado";
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.statusLabel.Visible = false;
            // 
            // cancelButton
            // 
            this.cancelButton.BackColor = System.Drawing.Color.Transparent;
            this.cancelButton.BackgroundImage = global::InventaryWMS.Properties.Resources.icons8_cancelar_64;
            this.cancelButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cancelButton.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.cancelButton.FlatAppearance.BorderSize = 0;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 9F);
            this.cancelButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cancelButton.Location = new System.Drawing.Point(378, 23);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(35, 28);
            this.cancelButton.TabIndex = 32;
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Visible = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // editButton
            // 
            this.editButton.BackColor = System.Drawing.Color.Transparent;
            this.editButton.BackgroundImage = global::InventaryWMS.Properties.Resources.icons8_editar_archivo_64;
            this.editButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.editButton.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.editButton.FlatAppearance.BorderSize = 0;
            this.editButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editButton.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 9F);
            this.editButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.editButton.Location = new System.Drawing.Point(378, 23);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(35, 28);
            this.editButton.TabIndex = 31;
            this.editButton.UseVisualStyleBackColor = false;
            this.editButton.Visible = false;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // viewRacksBtn
            // 
            this.viewRacksBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(47)))), ((int)(((byte)(75)))));
            this.viewRacksBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.viewRacksBtn.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.viewRacksBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.viewRacksBtn.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 9F);
            this.viewRacksBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.viewRacksBtn.Location = new System.Drawing.Point(308, 300);
            this.viewRacksBtn.Name = "viewRacksBtn";
            this.viewRacksBtn.Size = new System.Drawing.Size(86, 28);
            this.viewRacksBtn.TabIndex = 28;
            this.viewRacksBtn.Text = "Ver Almacén";
            this.viewRacksBtn.UseVisualStyleBackColor = false;
            this.viewRacksBtn.Click += new System.EventHandler(this.button4_Click);
            // 
            // propsTitle
            // 
            this.propsTitle.AutoSize = true;
            this.propsTitle.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 15.75F, System.Drawing.FontStyle.Bold);
            this.propsTitle.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.propsTitle.Location = new System.Drawing.Point(8, 3);
            this.propsTitle.Name = "propsTitle";
            this.propsTitle.Size = new System.Drawing.Size(114, 25);
            this.propsTitle.TabIndex = 13;
            this.propsTitle.Text = "Propiedades";
            // 
            // saveButton
            // 
            this.saveButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(47)))), ((int)(((byte)(75)))));
            this.saveButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.saveButton.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.saveButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.saveButton.Location = new System.Drawing.Point(751, 8);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(86, 27);
            this.saveButton.TabIndex = 24;
            this.saveButton.Text = "Guardar";
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.Visible = false;
            this.saveButton.Click += new System.EventHandler(this.editWhPropertiesBtn_Click);
            // 
            // locationPanel
            // 
            this.locationPanel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.locationPanel.Controls.Add(this.cbState);
            this.locationPanel.Controls.Add(this.cbCountry);
            this.locationPanel.Controls.Add(this.label5);
            this.locationPanel.Controls.Add(this.label10);
            this.locationPanel.Controls.Add(this.tbZipcode);
            this.locationPanel.Controls.Add(this.label11);
            this.locationPanel.Controls.Add(this.tbStreet);
            this.locationPanel.Controls.Add(this.label12);
            this.locationPanel.Controls.Add(this.tbColony);
            this.locationPanel.Controls.Add(this.label13);
            this.locationPanel.Controls.Add(this.tbCity);
            this.locationPanel.Controls.Add(this.label14);
            this.locationPanel.Controls.Add(this.label4);
            this.locationPanel.Location = new System.Drawing.Point(442, 58);
            this.locationPanel.Name = "locationPanel";
            this.locationPanel.Size = new System.Drawing.Size(395, 283);
            this.locationPanel.TabIndex = 23;
            // 
            // cbState
            // 
            this.cbState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbState.Enabled = false;
            this.cbState.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbState.ForeColor = System.Drawing.SystemColors.GrayText;
            this.cbState.FormattingEnabled = true;
            this.cbState.Location = new System.Drawing.Point(82, 85);
            this.cbState.Name = "cbState";
            this.cbState.Size = new System.Drawing.Size(277, 23);
            this.cbState.TabIndex = 36;
            // 
            // cbCountry
            // 
            this.cbCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCountry.Enabled = false;
            this.cbCountry.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCountry.ForeColor = System.Drawing.SystemColors.GrayText;
            this.cbCountry.FormattingEnabled = true;
            this.cbCountry.Location = new System.Drawing.Point(82, 50);
            this.cbCountry.Name = "cbCountry";
            this.cbCountry.Size = new System.Drawing.Size(277, 23);
            this.cbCountry.TabIndex = 35;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label5.Location = new System.Drawing.Point(22, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 15);
            this.label5.TabIndex = 13;
            this.label5.Text = "Ubicación";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label10.Location = new System.Drawing.Point(23, 223);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(28, 15);
            this.label10.TabIndex = 29;
            this.label10.Text = "C.P.";
            // 
            // tbZipcode
            // 
            this.tbZipcode.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tbZipcode.Enabled = false;
            this.tbZipcode.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbZipcode.ForeColor = System.Drawing.Color.DimGray;
            this.tbZipcode.Location = new System.Drawing.Point(82, 217);
            this.tbZipcode.Name = "tbZipcode";
            this.tbZipcode.Size = new System.Drawing.Size(277, 23);
            this.tbZipcode.TabIndex = 28;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label11.Location = new System.Drawing.Point(23, 190);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(33, 15);
            this.label11.TabIndex = 27;
            this.label11.Text = "Calle";
            // 
            // tbStreet
            // 
            this.tbStreet.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tbStreet.Enabled = false;
            this.tbStreet.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbStreet.ForeColor = System.Drawing.Color.DimGray;
            this.tbStreet.Location = new System.Drawing.Point(82, 184);
            this.tbStreet.Name = "tbStreet";
            this.tbStreet.Size = new System.Drawing.Size(277, 23);
            this.tbStreet.TabIndex = 26;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label12.Location = new System.Drawing.Point(23, 157);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(48, 15);
            this.label12.TabIndex = 25;
            this.label12.Text = "Colonia";
            // 
            // tbColony
            // 
            this.tbColony.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tbColony.Enabled = false;
            this.tbColony.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbColony.ForeColor = System.Drawing.Color.DimGray;
            this.tbColony.Location = new System.Drawing.Point(82, 151);
            this.tbColony.Name = "tbColony";
            this.tbColony.Size = new System.Drawing.Size(277, 23);
            this.tbColony.TabIndex = 24;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label13.Location = new System.Drawing.Point(23, 124);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(45, 15);
            this.label13.TabIndex = 23;
            this.label13.Text = "Ciudad";
            // 
            // tbCity
            // 
            this.tbCity.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tbCity.Enabled = false;
            this.tbCity.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCity.ForeColor = System.Drawing.Color.DimGray;
            this.tbCity.Location = new System.Drawing.Point(82, 118);
            this.tbCity.Name = "tbCity";
            this.tbCity.Size = new System.Drawing.Size(277, 23);
            this.tbCity.TabIndex = 22;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label14.Location = new System.Drawing.Point(23, 91);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(42, 15);
            this.label14.TabIndex = 21;
            this.label14.Text = "Estado";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label4.Location = new System.Drawing.Point(23, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 15);
            this.label4.TabIndex = 19;
            this.label4.Text = "País";
            // 
            // whDescription
            // 
            this.whDescription.BackColor = System.Drawing.SystemColors.HighlightText;
            this.whDescription.Enabled = false;
            this.whDescription.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.whDescription.ForeColor = System.Drawing.Color.DimGray;
            this.whDescription.Location = new System.Drawing.Point(111, 123);
            this.whDescription.Name = "whDescription";
            this.whDescription.Size = new System.Drawing.Size(302, 23);
            this.whDescription.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(15, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 15);
            this.label3.TabIndex = 21;
            this.label3.Text = "Descripción";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(14, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 20;
            this.label2.Text = "Nombre corto";
            // 
            // whShortName
            // 
            this.whShortName.BackColor = System.Drawing.SystemColors.HighlightText;
            this.whShortName.Enabled = false;
            this.whShortName.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.whShortName.ForeColor = System.Drawing.Color.DimGray;
            this.whShortName.Location = new System.Drawing.Point(111, 90);
            this.whShortName.Name = "whShortName";
            this.whShortName.Size = new System.Drawing.Size(302, 23);
            this.whShortName.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(14, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 15);
            this.label1.TabIndex = 18;
            this.label1.Text = "Nombre";
            // 
            // whFullName
            // 
            this.whFullName.BackColor = System.Drawing.SystemColors.HighlightText;
            this.whFullName.Enabled = false;
            this.whFullName.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.whFullName.ForeColor = System.Drawing.Color.DimGray;
            this.whFullName.Location = new System.Drawing.Point(111, 57);
            this.whFullName.Name = "whFullName";
            this.whFullName.Size = new System.Drawing.Size(302, 23);
            this.whFullName.TabIndex = 17;
            // 
            // spinner
            // 
            this.spinner.BackColor = System.Drawing.Color.Transparent;
            this.spinner.Location = new System.Drawing.Point(705, 1);
            this.spinner.MaximumSize = new System.Drawing.Size(40, 40);
            this.spinner.MinimumSize = new System.Drawing.Size(40, 40);
            this.spinner.Name = "spinner";
            this.spinner.Size = new System.Drawing.Size(40, 40);
            this.spinner.TabIndex = 34;
            this.spinner.Visible = false;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackgroundImage = global::InventaryWMS.Properties.Resources.Logo_preview_rev_1__2_;
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel3.Location = new System.Drawing.Point(594, 193);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(740, 322);
            this.panel3.TabIndex = 58;
            // 
            // buttonCW
            // 
            this.buttonCW.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(47)))), ((int)(((byte)(75)))));
            this.buttonCW.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonCW.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.buttonCW.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCW.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 9F);
            this.buttonCW.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonCW.Location = new System.Drawing.Point(216, 300);
            this.buttonCW.Name = "buttonCW";
            this.buttonCW.Size = new System.Drawing.Size(86, 28);
            this.buttonCW.TabIndex = 59;
            this.buttonCW.Text = "Asignar";
            this.buttonCW.UseVisualStyleBackColor = false;
            // 
            // nuevoAlmacénToolStripMenuItem
            // 
            this.nuevoAlmacénToolStripMenuItem.Name = "nuevoAlmacénToolStripMenuItem";
            this.nuevoAlmacénToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.nuevoAlmacénToolStripMenuItem.Text = "Nuevo Almacén";
            // 
            // editarElAlmacénSeleccionadoToolStripMenuItem
            // 
            this.editarElAlmacénSeleccionadoToolStripMenuItem.Name = "editarElAlmacénSeleccionadoToolStripMenuItem";
            this.editarElAlmacénSeleccionadoToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.editarElAlmacénSeleccionadoToolStripMenuItem.Text = "Editar el almacén seleccionado";
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip1.ToolTipTitle = "Información";
            // 
            // ManageWarehouses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(47)))), ((int)(((byte)(75)))));
            this.ClientSize = new System.Drawing.Size(877, 623);
            this.Controls.Add(this.whPropertiesPanel);
            this.Controls.Add(this.wareHousesPanel);
            this.MinimizeBox = false;
            this.Name = "ManageWarehouses";
            this.Padding = new System.Windows.Forms.Padding(14);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Almacenes";
            this.Load += new System.EventHandler(this.ManageWarehouses_Load);
            this.wareHousesPanel.ResumeLayout(false);
            this.wareHousesPanel.PerformLayout();
            this.whPropertiesPanel.ResumeLayout(false);
            this.whPropertiesPanel.PerformLayout();
            this.rackPropertiespanel.ResumeLayout(false);
            this.rackPropertiespanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLevels)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRacks)).EndInit();
            this.locationPanel.ResumeLayout(false);
            this.locationPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Panel wareHousesPanel;
        private Label label15;
        private Panel whPropertiesPanel;
        private Label propsTitle;
        private Button saveButton;
        private Panel locationPanel;
        private Label label5;
        private Label label10;
        private TextBox tbZipcode;
        private Label label11;
        private TextBox tbStreet;
        private Label label12;
        private TextBox tbColony;
        private Label label13;
        private TextBox tbCity;
        private Label label14;
        private Label label4;
        private TextBox whDescription;
        private Label label3;
        private Label label2;
        private TextBox whShortName;
        private Label label1;
        private TextBox whFullName;
        private Button viewRacksBtn;
        private ToolStripMenuItem nuevoAlmacénToolStripMenuItem;
        private ToolStripMenuItem editarElAlmacénSeleccionadoToolStripMenuItem;
        private Button editButton;
        private Button cancelButton;
        private ComboBox cbCountry;
        private LoadingSpinner spinnerWhList;
        private LoadingSpinner spinner;
        private Button endSearchButton;
        private TextBox searchTextBox;
        private Button createWarehouse;
        private Panel rackPropertiespanel;
        private ComboBox cbFormat;
        private Label label17;
        private Label label18;
        private Label label16;
        private Label label6;
        private ToolTip toolTip1;
        private NumericUpDown numLevels;
        private NumericUpDown numRacks;
        private Label statusLabel;
        private Label label7;
        private Button setRacksLenBtn;
        private ComboBox cbState;
        private Panel panelWHList;
        private Panel panel3;
        private Button buttonCW;
    }
}