
using System.Drawing;
using System.Windows.Forms;

namespace InventaryWMS
{
    partial class RackView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RackView));
            this.panel1 = new System.Windows.Forms.Panel();
            this.infoCard3 = new InventaryWMS.InfoCard();
            this.infoCard2 = new InventaryWMS.InfoCard();
            this.rackName = new System.Windows.Forms.Label();
            this.infoCard1 = new InventaryWMS.InfoCard();
            this.warehouseNameLabel = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.spinner = new InventaryWMS.LoadingSpinner();
            this.currentSelected = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.rackGrid = new System.Windows.Forms.DataGridView();
            this.changedCellsPanel = new System.Windows.Forms.GroupBox();
            this.gboxOptions = new System.Windows.Forms.GroupBox();
            this.actionBtnSave = new InventaryWMS.ActionButton();
            this.actionBtnCancel = new InventaryWMS.ActionButton();
            this.actionBtnUnselect = new InventaryWMS.ActionButton();
            this.actionBtnNotValid = new InventaryWMS.ActionButton();
            this.actionBtnValid = new InventaryWMS.ActionButton();
            this.nivel_Label = new InventaryWMS.VerticalLabel();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button46 = new System.Windows.Forms.Button();
            this.button45 = new System.Windows.Forms.Button();
            this.posicion_Label = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rackGrid)).BeginInit();
            this.gboxOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Controls.Add(this.infoCard3);
            this.panel1.Controls.Add(this.infoCard2);
            this.panel1.Controls.Add(this.rackName);
            this.panel1.Controls.Add(this.infoCard1);
            this.panel1.Controls.Add(this.warehouseNameLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Location = new System.Drawing.Point(14, 14);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1079, 143);
            this.panel1.TabIndex = 24;
            // 
            // infoCard3
            // 
            this.infoCard3.BackColor = System.Drawing.SystemColors.Control;
            this.infoCard3.Location = new System.Drawing.Point(468, 19);
            this.infoCard3.Margin = new System.Windows.Forms.Padding(0);
            this.infoCard3.MaximumSize = new System.Drawing.Size(100, 100);
            this.infoCard3.MinimumSize = new System.Drawing.Size(100, 100);
            this.infoCard3.Name = "infoCard3";
            this.infoCard3.Size = new System.Drawing.Size(100, 100);
            this.infoCard3.TabIndex = 20;
            // 
            // infoCard2
            // 
            this.infoCard2.BackColor = System.Drawing.SystemColors.Control;
            this.infoCard2.Location = new System.Drawing.Point(347, 19);
            this.infoCard2.Margin = new System.Windows.Forms.Padding(0);
            this.infoCard2.MaximumSize = new System.Drawing.Size(100, 100);
            this.infoCard2.MinimumSize = new System.Drawing.Size(100, 100);
            this.infoCard2.Name = "infoCard2";
            this.infoCard2.Size = new System.Drawing.Size(100, 100);
            this.infoCard2.TabIndex = 19;
            // 
            // rackName
            // 
            this.rackName.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 20.25F, System.Drawing.FontStyle.Bold);
            this.rackName.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.rackName.Location = new System.Drawing.Point(10, 19);
            this.rackName.Name = "rackName";
            this.rackName.Size = new System.Drawing.Size(196, 33);
            this.rackName.TabIndex = 13;
            this.rackName.Text = "Name";
            // 
            // infoCard1
            // 
            this.infoCard1.BackColor = System.Drawing.SystemColors.Control;
            this.infoCard1.Location = new System.Drawing.Point(226, 19);
            this.infoCard1.Margin = new System.Windows.Forms.Padding(0);
            this.infoCard1.MaximumSize = new System.Drawing.Size(100, 100);
            this.infoCard1.MinimumSize = new System.Drawing.Size(100, 100);
            this.infoCard1.Name = "infoCard1";
            this.infoCard1.Size = new System.Drawing.Size(100, 100);
            this.infoCard1.TabIndex = 18;
            // 
            // warehouseNameLabel
            // 
            this.warehouseNameLabel.AutoSize = true;
            this.warehouseNameLabel.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F);
            this.warehouseNameLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.warehouseNameLabel.Location = new System.Drawing.Point(12, 49);
            this.warehouseNameLabel.Name = "warehouseNameLabel";
            this.warehouseNameLabel.Size = new System.Drawing.Size(89, 19);
            this.warehouseNameLabel.TabIndex = 14;
            this.warehouseNameLabel.Text = "Almacén name";
            this.warehouseNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel2.Controls.Add(this.spinner);
            this.panel2.Controls.Add(this.currentSelected);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.rackGrid);
            this.panel2.Controls.Add(this.changedCellsPanel);
            this.panel2.Controls.Add(this.gboxOptions);
            this.panel2.Controls.Add(this.nivel_Label);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.button46);
            this.panel2.Controls.Add(this.button45);
            this.panel2.Controls.Add(this.posicion_Label);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(14, 163);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1079, 419);
            this.panel2.TabIndex = 25;
            // 
            // spinner
            // 
            this.spinner.BackColor = System.Drawing.Color.Transparent;
            this.spinner.Location = new System.Drawing.Point(278, 13);
            this.spinner.MaximumSize = new System.Drawing.Size(40, 40);
            this.spinner.MinimumSize = new System.Drawing.Size(40, 40);
            this.spinner.Name = "spinner";
            this.spinner.Size = new System.Drawing.Size(40, 40);
            this.spinner.TabIndex = 216;
            // 
            // currentSelected
            // 
            this.currentSelected.AutoSize = true;
            this.currentSelected.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F);
            this.currentSelected.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.currentSelected.Location = new System.Drawing.Point(84, 104);
            this.currentSelected.Name = "currentSelected";
            this.currentSelected.Size = new System.Drawing.Size(63, 19);
            this.currentSelected.TabIndex = 215;
            this.currentSelected.Text = "00-00-00";
            this.currentSelected.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.currentSelected.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(32, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 19);
            this.label2.TabIndex = 214;
            this.label2.Text = "Espacio:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::InventaryWMS.Properties.Resources.info_2_ic;
            this.pictureBox1.Location = new System.Drawing.Point(355, 64);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(17, 17);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 213;
            this.pictureBox1.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox1, "Los espacios marcados como no válidos indican que fisicamente no existen o no es " +
        "posible usarlos, el sistema usa esta propiedad para descartarlos");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift Light SemiCondensed", 9.75F);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(56, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 114;
            this.label1.Text = "Espacio libre";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.Enabled = false;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(37, 67);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(13, 13);
            this.button1.TabIndex = 113;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // rackGrid
            // 
            this.rackGrid.AllowUserToAddRows = false;
            this.rackGrid.AllowUserToDeleteRows = false;
            this.rackGrid.AllowUserToResizeColumns = false;
            this.rackGrid.AllowUserToResizeRows = false;
            this.rackGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rackGrid.BackgroundColor = System.Drawing.SystemColors.HighlightText;
            this.rackGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rackGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.rackGrid.ColumnHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.rackGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.rackGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.rackGrid.Location = new System.Drawing.Point(40, 132);
            this.rackGrid.Name = "rackGrid";
            this.rackGrid.RowHeadersVisible = false;
            this.rackGrid.RowHeadersWidth = 10;
            this.rackGrid.RowTemplate.Height = 25;
            this.rackGrid.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.rackGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.rackGrid.Size = new System.Drawing.Size(1031, 147);
            this.rackGrid.TabIndex = 112;
            this.rackGrid.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.rackGrid_CellEnter);
            this.rackGrid.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.rackGrid_DataBindingComplete);
            this.rackGrid.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DataGridView1_MouseUp);
            // 
            // changedCellsPanel
            // 
            this.changedCellsPanel.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 9.75F);
            this.changedCellsPanel.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.changedCellsPanel.Location = new System.Drawing.Point(40, 308);
            this.changedCellsPanel.Name = "changedCellsPanel";
            this.changedCellsPanel.Size = new System.Drawing.Size(1059, 105);
            this.changedCellsPanel.TabIndex = 105;
            this.changedCellsPanel.TabStop = false;
            this.changedCellsPanel.Text = "Resumen de espacios a modificar";
            // 
            // gboxOptions
            // 
            this.gboxOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxOptions.Controls.Add(this.actionBtnSave);
            this.gboxOptions.Controls.Add(this.actionBtnCancel);
            this.gboxOptions.Controls.Add(this.actionBtnUnselect);
            this.gboxOptions.Controls.Add(this.actionBtnNotValid);
            this.gboxOptions.Controls.Add(this.actionBtnValid);
            this.gboxOptions.Font = new System.Drawing.Font("Bahnschrift Light Condensed", 9.75F);
            this.gboxOptions.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.gboxOptions.Location = new System.Drawing.Point(410, 20);
            this.gboxOptions.Name = "gboxOptions";
            this.gboxOptions.Size = new System.Drawing.Size(338, 106);
            this.gboxOptions.TabIndex = 104;
            this.gboxOptions.TabStop = false;
            this.gboxOptions.Text = "Opciones";
            // 
            // actionBtnSave
            // 
            this.actionBtnSave.BackColor = System.Drawing.Color.White;
            this.actionBtnSave.Enabled = false;
            this.actionBtnSave.Location = new System.Drawing.Point(270, 25);
            this.actionBtnSave.MaximumSize = new System.Drawing.Size(60, 75);
            this.actionBtnSave.MinimumSize = new System.Drawing.Size(60, 75);
            this.actionBtnSave.Name = "actionBtnSave";
            this.actionBtnSave.Size = new System.Drawing.Size(60, 75);
            this.actionBtnSave.TabIndex = 122;
            this.actionBtnSave.UserImage = ((System.Drawing.Image)(resources.GetObject("actionBtnSave.UserImage")));
            this.actionBtnSave.UserLabelText = "Guardar Cambios";
            this.actionBtnSave.ButtonClick += new System.EventHandler(this.actionBtnSave_ButtonClick);
            // 
            // actionBtnCancel
            // 
            this.actionBtnCancel.BackColor = System.Drawing.Color.White;
            this.actionBtnCancel.Enabled = false;
            this.actionBtnCancel.Location = new System.Drawing.Point(204, 25);
            this.actionBtnCancel.MaximumSize = new System.Drawing.Size(60, 75);
            this.actionBtnCancel.MinimumSize = new System.Drawing.Size(60, 75);
            this.actionBtnCancel.Name = "actionBtnCancel";
            this.actionBtnCancel.Size = new System.Drawing.Size(60, 75);
            this.actionBtnCancel.TabIndex = 121;
            this.actionBtnCancel.UserImage = ((System.Drawing.Image)(resources.GetObject("actionBtnCancel.UserImage")));
            this.actionBtnCancel.UserLabelText = "Descartar Todo";
            this.actionBtnCancel.ButtonClick += new System.EventHandler(this.actionBtnCancel_ButtonClick);
            // 
            // actionBtnUnselect
            // 
            this.actionBtnUnselect.BackColor = System.Drawing.Color.White;
            this.actionBtnUnselect.Enabled = false;
            this.actionBtnUnselect.Location = new System.Drawing.Point(138, 25);
            this.actionBtnUnselect.MaximumSize = new System.Drawing.Size(60, 75);
            this.actionBtnUnselect.MinimumSize = new System.Drawing.Size(60, 75);
            this.actionBtnUnselect.Name = "actionBtnUnselect";
            this.actionBtnUnselect.Size = new System.Drawing.Size(60, 75);
            this.actionBtnUnselect.TabIndex = 120;
            this.actionBtnUnselect.UserImage = ((System.Drawing.Image)(resources.GetObject("actionBtnUnselect.UserImage")));
            this.actionBtnUnselect.UserLabelText = "Quitar Selección";
            this.actionBtnUnselect.ButtonClick += new System.EventHandler(this.actionBtnUnselect_ButtonClick);
            // 
            // actionBtnNotValid
            // 
            this.actionBtnNotValid.BackColor = System.Drawing.Color.White;
            this.actionBtnNotValid.Enabled = false;
            this.actionBtnNotValid.Location = new System.Drawing.Point(72, 25);
            this.actionBtnNotValid.MaximumSize = new System.Drawing.Size(60, 75);
            this.actionBtnNotValid.MinimumSize = new System.Drawing.Size(60, 75);
            this.actionBtnNotValid.Name = "actionBtnNotValid";
            this.actionBtnNotValid.Size = new System.Drawing.Size(60, 75);
            this.actionBtnNotValid.TabIndex = 119;
            this.actionBtnNotValid.UserImage = ((System.Drawing.Image)(resources.GetObject("actionBtnNotValid.UserImage")));
            this.actionBtnNotValid.UserLabelText = "Marcar No Válida";
            this.actionBtnNotValid.ButtonClick += new System.EventHandler(this.actionBtnNotValid_ButtonClick);
            // 
            // actionBtnValid
            // 
            this.actionBtnValid.BackColor = System.Drawing.Color.White;
            this.actionBtnValid.Enabled = false;
            this.actionBtnValid.Location = new System.Drawing.Point(6, 25);
            this.actionBtnValid.MaximumSize = new System.Drawing.Size(60, 75);
            this.actionBtnValid.MinimumSize = new System.Drawing.Size(60, 75);
            this.actionBtnValid.Name = "actionBtnValid";
            this.actionBtnValid.Size = new System.Drawing.Size(60, 75);
            this.actionBtnValid.TabIndex = 118;
            this.actionBtnValid.UserImage = ((System.Drawing.Image)(resources.GetObject("actionBtnValid.UserImage")));
            this.actionBtnValid.UserLabelText = "Marcar Válida";
            this.actionBtnValid.ButtonClick += new System.EventHandler(this.actionBtnValid_ButtonClick);
            // 
            // nivel_Label
            // 
            this.nivel_Label.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.nivel_Label.Font = new System.Drawing.Font("Bahnschrift Light SemiCondensed", 12F);
            this.nivel_Label.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.nivel_Label.Location = new System.Drawing.Point(12, 198);
            this.nivel_Label.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nivel_Label.Name = "nivel_Label";
            this.nivel_Label.Size = new System.Drawing.Size(17, 36);
            this.nivel_Label.TabIndex = 103;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Bahnschrift Light SemiCondensed", 9.75F);
            this.label7.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label7.Location = new System.Drawing.Point(160, 66);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 16);
            this.label7.TabIndex = 102;
            this.label7.Text = "Espacio en uso";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Bahnschrift Light SemiCondensed", 9.75F);
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label6.Location = new System.Drawing.Point(278, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 16);
            this.label6.TabIndex = 101;
            this.label6.Text = "No Válido";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button46
            // 
            this.button46.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(20)))), ((int)(((byte)(80)))));
            this.button46.Enabled = false;
            this.button46.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button46.FlatAppearance.BorderSize = 0;
            this.button46.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button46.Location = new System.Drawing.Point(260, 67);
            this.button46.Name = "button46";
            this.button46.Size = new System.Drawing.Size(13, 13);
            this.button46.TabIndex = 99;
            this.button46.UseVisualStyleBackColor = false;
            // 
            // button45
            // 
            this.button45.BackColor = System.Drawing.Color.Teal;
            this.button45.Enabled = false;
            this.button45.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button45.FlatAppearance.BorderSize = 0;
            this.button45.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button45.Location = new System.Drawing.Point(141, 67);
            this.button45.Name = "button45";
            this.button45.Size = new System.Drawing.Size(13, 13);
            this.button45.TabIndex = 18;
            this.button45.UseVisualStyleBackColor = false;
            // 
            // posicion_Label
            // 
            this.posicion_Label.AutoSize = true;
            this.posicion_Label.Font = new System.Drawing.Font("Bahnschrift Light SemiCondensed", 12F);
            this.posicion_Label.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.posicion_Label.Location = new System.Drawing.Point(519, 281);
            this.posicion_Label.Name = "posicion_Label";
            this.posicion_Label.Size = new System.Drawing.Size(133, 19);
            this.posicion_Label.TabIndex = 98;
            this.posicion_Label.Text = "Número del espacio";
            this.posicion_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F);
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(32, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(251, 23);
            this.label3.TabIndex = 14;
            this.label3.Text = "Mapa de Espacios de Almacenamiento";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RackView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(47)))), ((int)(((byte)(75)))));
            this.ClientSize = new System.Drawing.Size(1107, 596);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RackView";
            this.Padding = new System.Windows.Forms.Padding(14);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Propiedades del rack";
            this.Load += new System.EventHandler(this.RackView_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rackGrid)).EndInit();
            this.gboxOptions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Panel panel1;
        private Label rackName;
        private Label warehouseNameLabel;
        private Panel panel2;
        private Label label5;
        private Label label3;
        private VerticalLabel vertical_Label1;
        private GroupBox gboxOptions;
        private GroupBox changedCellsPanel;
        private DataGridView rackGrid;
        private VerticalLabel nivel_Label;
        private Label posicion_Label;
        private PictureBox pictureBox1;
        private ToolTip toolTip1;
        private Label currentSelected;
        private Label label2;
        private InfoCard infoCard1;
        private InfoCard infoCard3;
        private InfoCard infoCard2;
        private Label label1;
        private Button button1;
        private Label label7;
        private Label label6;
        private Button button46;
        private Button button45;
        private LoadingSpinner spinner;
        private ActionButton actionBtnNotValid;
        private ActionButton actionBtnValid;
        private ActionButton actionBtnSave;
        private ActionButton actionBtnCancel;
        private ActionButton actionBtnUnselect;
    }

}