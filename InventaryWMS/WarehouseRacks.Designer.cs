using System.Drawing;
using InventaryWMS;
using System.Windows.Forms;
namespace InventaryWMS
{
    partial class WarehouseRacks
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WarehouseRacks));
            this.panel1 = new System.Windows.Forms.Panel();
            this.spinner = new InventaryWMS.LoadingSpinner();
            this.infoCard3 = new InventaryWMS.InfoCard();
            this.infoCard2 = new InventaryWMS.InfoCard();
            this.infoCard1 = new InventaryWMS.InfoCard();
            this.label3 = new System.Windows.Forms.Label();
            this.whShortName = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.tabs = new System.Windows.Forms.TabControl();
            this.rackPageA = new System.Windows.Forms.TabPage();
            this.newRackPanel = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveNewRackBtn = new System.Windows.Forms.Button();
            this.loadingSpinner1 = new InventaryWMS.LoadingSpinner();
            this.newRackBtn = new System.Windows.Forms.Button();
            this.rackPageB = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.addBahia = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.tabs.SuspendLayout();
            this.rackPageA.SuspendLayout();
            this.newRackPanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.rackPageB.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Controls.Add(this.spinner);
            this.panel1.Controls.Add(this.infoCard3);
            this.panel1.Controls.Add(this.infoCard2);
            this.panel1.Controls.Add(this.infoCard1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.whShortName);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(14, 14);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(881, 146);
            this.panel1.TabIndex = 25;
            // 
            // spinner
            // 
            this.spinner.BackColor = System.Drawing.Color.Transparent;
            this.spinner.Location = new System.Drawing.Point(66, 79);
            this.spinner.MaximumSize = new System.Drawing.Size(40, 40);
            this.spinner.MinimumSize = new System.Drawing.Size(40, 40);
            this.spinner.Name = "spinner";
            this.spinner.Size = new System.Drawing.Size(40, 40);
            this.spinner.TabIndex = 215;
            // 
            // infoCard3
            // 
            this.infoCard3.BackColor = System.Drawing.SystemColors.Control;
            this.infoCard3.Location = new System.Drawing.Point(486, 19);
            this.infoCard3.Margin = new System.Windows.Forms.Padding(0);
            this.infoCard3.MaximumSize = new System.Drawing.Size(100, 100);
            this.infoCard3.MinimumSize = new System.Drawing.Size(100, 100);
            this.infoCard3.Name = "infoCard3";
            this.infoCard3.Size = new System.Drawing.Size(100, 100);
            this.infoCard3.TabIndex = 214;
            this.infoCard3.Visible = false;
            // 
            // infoCard2
            // 
            this.infoCard2.BackColor = System.Drawing.SystemColors.Control;
            this.infoCard2.Location = new System.Drawing.Point(368, 19);
            this.infoCard2.Margin = new System.Windows.Forms.Padding(0);
            this.infoCard2.MaximumSize = new System.Drawing.Size(100, 100);
            this.infoCard2.MinimumSize = new System.Drawing.Size(100, 100);
            this.infoCard2.Name = "infoCard2";
            this.infoCard2.Size = new System.Drawing.Size(100, 100);
            this.infoCard2.TabIndex = 213;
            // 
            // infoCard1
            // 
            this.infoCard1.BackColor = System.Drawing.SystemColors.Control;
            this.infoCard1.Location = new System.Drawing.Point(249, 19);
            this.infoCard1.Margin = new System.Windows.Forms.Padding(0);
            this.infoCard1.MaximumSize = new System.Drawing.Size(100, 100);
            this.infoCard1.MinimumSize = new System.Drawing.Size(100, 100);
            this.infoCard1.Name = "infoCard1";
            this.infoCard1.Size = new System.Drawing.Size(100, 100);
            this.infoCard1.TabIndex = 212;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F);
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(14, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(167, 19);
            this.label3.TabIndex = 61;
            this.label3.Text = "Mapa de Racks en el almacén";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // whShortName
            // 
            this.whShortName.AutoSize = true;
            this.whShortName.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 20.25F, System.Drawing.FontStyle.Bold);
            this.whShortName.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.whShortName.Location = new System.Drawing.Point(113, 19);
            this.whShortName.Name = "whShortName";
            this.whShortName.Size = new System.Drawing.Size(74, 33);
            this.whShortName.TabIndex = 13;
            this.whShortName.Text = "name";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 20.25F, System.Drawing.FontStyle.Bold);
            this.label15.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label15.Location = new System.Drawing.Point(12, 19);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(108, 33);
            this.label15.TabIndex = 8;
            this.label15.Text = "Almacén";
            // 
            // tabs
            // 
            this.tabs.Controls.Add(this.rackPageA);
            this.tabs.Controls.Add(this.rackPageB);
            this.tabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabs.Font = new System.Drawing.Font("Bahnschrift SemiLight Condensed", 11F);
            this.tabs.Location = new System.Drawing.Point(14, 160);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(881, 371);
            this.tabs.TabIndex = 185;
            this.tabs.SelectedIndexChanged += new System.EventHandler(this.tabs_SelectedIndexChanged);
            // 
            // rackPageA
            // 
            this.rackPageA.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.rackPageA.Controls.Add(this.newRackPanel);
            this.rackPageA.Controls.Add(this.newRackBtn);
            this.rackPageA.Location = new System.Drawing.Point(4, 27);
            this.rackPageA.Name = "rackPageA";
            this.rackPageA.Padding = new System.Windows.Forms.Padding(3);
            this.rackPageA.Size = new System.Drawing.Size(873, 340);
            this.rackPageA.TabIndex = 0;
            this.rackPageA.Text = "Racks";
            // 
            // newRackPanel
            // 
            this.newRackPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.newRackPanel.BackColor = System.Drawing.SystemColors.HighlightText;
            this.newRackPanel.Controls.Add(this.groupBox1);
            this.newRackPanel.Controls.Add(this.cancelButton);
            this.newRackPanel.Controls.Add(this.saveNewRackBtn);
            this.newRackPanel.Controls.Add(this.loadingSpinner1);
            this.newRackPanel.Location = new System.Drawing.Point(1309, 41);
            this.newRackPanel.Name = "newRackPanel";
            this.newRackPanel.Size = new System.Drawing.Size(253, 205);
            this.newRackPanel.TabIndex = 201;
            this.newRackPanel.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.numericUpDown2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.numericUpDown1);
            this.groupBox1.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 9.75F);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.groupBox1.Location = new System.Drawing.Point(95, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(225, 130);
            this.groupBox1.TabIndex = 202;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Registrar nuevo rack";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F);
            this.label5.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label5.Location = new System.Drawing.Point(142, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 19);
            this.label5.TabIndex = 215;
            this.label5.Text = "AA";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F);
            this.label4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label4.Location = new System.Drawing.Point(26, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 19);
            this.label4.TabIndex = 214;
            this.label4.Text = "Nombre (Automático)";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(142, 92);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(57, 23);
            this.numericUpDown2.TabIndex = 213;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F);
            this.label2.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label2.Location = new System.Drawing.Point(88, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 19);
            this.label2.TabIndex = 212;
            this.label2.Text = "Niveles";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F);
            this.label1.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label1.Location = new System.Drawing.Point(74, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 19);
            this.label1.TabIndex = 211;
            this.label1.Text = "Posiciones";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(142, 60);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(57, 23);
            this.numericUpDown1.TabIndex = 210;
            // 
            // cancelButton
            // 
            this.cancelButton.BackColor = System.Drawing.Color.Transparent;
            this.cancelButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cancelButton.BackgroundImage")));
            this.cancelButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cancelButton.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.cancelButton.FlatAppearance.BorderSize = 0;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 9F);
            this.cancelButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cancelButton.Location = new System.Drawing.Point(225, 11);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(14, 14);
            this.cancelButton.TabIndex = 211;
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Visible = false;
            // 
            // saveNewRackBtn
            // 
            this.saveNewRackBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.saveNewRackBtn.BackColor = System.Drawing.Color.SteelBlue;
            this.saveNewRackBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.saveNewRackBtn.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.saveNewRackBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveNewRackBtn.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 9F);
            this.saveNewRackBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.saveNewRackBtn.Location = new System.Drawing.Point(235, 172);
            this.saveNewRackBtn.Name = "saveNewRackBtn";
            this.saveNewRackBtn.Size = new System.Drawing.Size(86, 20);
            this.saveNewRackBtn.TabIndex = 202;
            this.saveNewRackBtn.Text = "Aceptar";
            this.saveNewRackBtn.UseVisualStyleBackColor = false;
            // 
            // loadingSpinner1
            // 
            this.loadingSpinner1.BackColor = System.Drawing.Color.Transparent;
            this.loadingSpinner1.Location = new System.Drawing.Point(118, 155);
            this.loadingSpinner1.MaximumSize = new System.Drawing.Size(34, 35);
            this.loadingSpinner1.MinimumSize = new System.Drawing.Size(34, 35);
            this.loadingSpinner1.Name = "loadingSpinner1";
            this.loadingSpinner1.Size = new System.Drawing.Size(34, 35);
            this.loadingSpinner1.TabIndex = 210;
            this.loadingSpinner1.Visible = false;
            // 
            // newRackBtn
            // 
            this.newRackBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.newRackBtn.BackColor = System.Drawing.Color.SteelBlue;
            this.newRackBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.newRackBtn.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.newRackBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.newRackBtn.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 9F);
            this.newRackBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.newRackBtn.Location = new System.Drawing.Point(1476, 16);
            this.newRackBtn.Name = "newRackBtn";
            this.newRackBtn.Size = new System.Drawing.Size(86, 20);
            this.newRackBtn.TabIndex = 199;
            this.newRackBtn.Text = "Nuevo";
            this.newRackBtn.UseVisualStyleBackColor = false;
            // 
            // rackPageB
            // 
            this.rackPageB.Controls.Add(this.label6);
            this.rackPageB.Controls.Add(this.addBahia);
            this.rackPageB.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.rackPageB.Location = new System.Drawing.Point(4, 27);
            this.rackPageB.Name = "rackPageB";
            this.rackPageB.Padding = new System.Windows.Forms.Padding(3);
            this.rackPageB.Size = new System.Drawing.Size(873, 340);
            this.rackPageB.TabIndex = 1;
            this.rackPageB.Text = "Racks Virtuales (Bahías)";
            this.rackPageB.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Bahnschrift Light SemiCondensed", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label6.Location = new System.Drawing.Point(659, 324);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(208, 13);
            this.label6.TabIndex = 62;
            this.label6.Text = "*Se muestran solo las bahías del cliente actual";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // addBahia
            // 
            this.addBahia.Font = new System.Drawing.Font("Bahnschrift SemiLight", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addBahia.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.addBahia.Location = new System.Drawing.Point(10, 20);
            this.addBahia.Name = "addBahia";
            this.addBahia.Size = new System.Drawing.Size(70, 70);
            this.addBahia.TabIndex = 1;
            this.addBahia.Text = "+";
            this.toolTip1.SetToolTip(this.addBahia, "Crear nuevo rack");
            this.addBahia.UseVisualStyleBackColor = true;
            this.addBahia.Click += new System.EventHandler(this.button2_Click);
            // 
            // WarehouseRacks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(47)))), ((int)(((byte)(75)))));
            this.ClientSize = new System.Drawing.Size(909, 545);
            this.Controls.Add(this.tabs);
            this.Controls.Add(this.panel1);
            this.Name = "WarehouseRacks";
            this.Padding = new System.Windows.Forms.Padding(14);
            this.Text = "Almacén";
            this.Load += new System.EventHandler(this.WarehouseRacks_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabs.ResumeLayout(false);
            this.rackPageA.ResumeLayout(false);
            this.newRackPanel.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.rackPageB.ResumeLayout(false);
            this.rackPageB.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Label whShortName;
        private Label label15;
        private Label label3;
        private TabControl tabs;
        private TabPage rackPageA;
        private Panel newRackPanel;
        private GroupBox groupBox1;
        private Label label5;
        private Label label4;
        private NumericUpDown numericUpDown2;
        private Label label2;
        private Label label1;
        private NumericUpDown numericUpDown1;
        private Button cancelButton;
        private Button saveNewRackBtn;
        private LoadingSpinner loadingSpinner1;
        private Button newRackBtn;
        private TabPage rackPageB;
        private LoadingSpinner spinner;
        private InfoCard infoCard3;
        private InfoCard infoCard2;
        private InfoCard infoCard1;
        private Button addBahia;
        private ToolTip toolTip1;
        private Label label6;
    }
}