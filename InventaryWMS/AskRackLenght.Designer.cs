using System.Drawing;
using System.Windows.Forms;

namespace InventaryWMS
{
    partial class AskRackLenght
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AskRackLenght));
            this.dgridNamesList = new System.Windows.Forms.DataGridView();
            this.rackName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rackLenght = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firstIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.actionButton1 = new InventaryWMS.ActionButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.helpPanel = new System.Windows.Forms.Panel();
            this.closeHelp = new System.Windows.Forms.Button();
            this.propsTitle = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.labelError = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgridNamesList)).BeginInit();
            this.panel1.SuspendLayout();
            this.helpPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgridNamesList
            // 
            this.dgridNamesList.BackgroundColor = System.Drawing.SystemColors.HighlightText;
            this.dgridNamesList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgridNamesList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgridNamesList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.rackName,
            this.rackLenght,
            this.firstIndex});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Bahnschrift SemiBold Condensed", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgridNamesList.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgridNamesList.Location = new System.Drawing.Point(14, 132);
            this.dgridNamesList.Name = "dgridNamesList";
            this.dgridNamesList.RowHeadersVisible = false;
            this.dgridNamesList.RowTemplate.Height = 25;
            this.dgridNamesList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgridNamesList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgridNamesList.Size = new System.Drawing.Size(374, 242);
            this.dgridNamesList.TabIndex = 0;
            this.dgridNamesList.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgridNamesList_CellValidating);
            // 
            // rackName
            // 
            this.rackName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.rackName.HeaderText = "Nombre del rack";
            this.rackName.Name = "rackName";
            this.rackName.ReadOnly = true;
            this.rackName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // rackLenght
            // 
            this.rackLenght.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = null;
            this.rackLenght.DefaultCellStyle = dataGridViewCellStyle1;
            this.rackLenght.HeaderText = "Longitud";
            this.rackLenght.Name = "rackLenght";
            this.rackLenght.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // firstIndex
            // 
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            this.firstIndex.DefaultCellStyle = dataGridViewCellStyle2;
            this.firstIndex.HeaderText = "Inicia en";
            this.firstIndex.Name = "firstIndex";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.actionButton1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(14, 14);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(374, 90);
            this.panel1.TabIndex = 2;
            // 
            // actionButton1
            // 
            this.actionButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.actionButton1.BackColor = System.Drawing.Color.Transparent;
            this.actionButton1.Location = new System.Drawing.Point(303, 8);
            this.actionButton1.MaximumSize = new System.Drawing.Size(60, 75);
            this.actionButton1.MinimumSize = new System.Drawing.Size(60, 75);
            this.actionButton1.Name = "actionButton1";
            this.actionButton1.Size = new System.Drawing.Size(60, 75);
            this.actionButton1.TabIndex = 23;
            this.actionButton1.UserImage = ((System.Drawing.Image)(resources.GetObject("actionButton1.UserImage")));
            this.actionButton1.UserLabelText = "Ayuda";
            this.actionButton1.ButtonClick += new System.EventHandler(this.actionButton1_ButtonClick);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Bahnschrift Light", 9.75F);
            this.label3.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label3.Location = new System.Drawing.Point(14, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(267, 33);
            this.label3.TabIndex = 22;
            this.label3.Text = "Ingrese la longitud (cantidad de espacios) para cada rack en la tabla";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 15.75F, System.Drawing.FontStyle.Bold);
            this.label15.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label15.Location = new System.Drawing.Point(14, 10);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(102, 25);
            this.label15.TabIndex = 9;
            this.label15.Text = "Almacenes";
            // 
            // helpPanel
            // 
            this.helpPanel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.helpPanel.Controls.Add(this.closeHelp);
            this.helpPanel.Controls.Add(this.propsTitle);
            this.helpPanel.Controls.Add(this.pictureBox1);
            this.helpPanel.Location = new System.Drawing.Point(12, 16);
            this.helpPanel.Name = "helpPanel";
            this.helpPanel.Size = new System.Drawing.Size(377, 393);
            this.helpPanel.TabIndex = 3;
            this.helpPanel.Visible = false;
            // 
            // closeHelp
            // 
            this.closeHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeHelp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(47)))), ((int)(((byte)(75)))));
            this.closeHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.closeHelp.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.closeHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeHelp.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 9F);
            this.closeHelp.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.closeHelp.Location = new System.Drawing.Point(287, 362);
            this.closeHelp.Name = "closeHelp";
            this.closeHelp.Size = new System.Drawing.Size(86, 26);
            this.closeHelp.TabIndex = 36;
            this.closeHelp.Text = "Volver";
            this.closeHelp.UseVisualStyleBackColor = false;
            this.closeHelp.Click += new System.EventHandler(this.closeHelp_Click);
            // 
            // propsTitle
            // 
            this.propsTitle.AutoSize = true;
            this.propsTitle.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 15.75F, System.Drawing.FontStyle.Bold);
            this.propsTitle.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.propsTitle.Location = new System.Drawing.Point(3, 0);
            this.propsTitle.Name = "propsTitle";
            this.propsTitle.Size = new System.Drawing.Size(184, 25);
            this.propsTitle.TabIndex = 14;
            this.propsTitle.Text = "Diagrama de un rack";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(2, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(374, 361);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 37;
            this.pictureBox1.TabStop = false;
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.BackColor = System.Drawing.Color.SteelBlue;
            this.saveButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.saveButton.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveButton.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 9F);
            this.saveButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.saveButton.Location = new System.Drawing.Point(300, 381);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(86, 26);
            this.saveButton.TabIndex = 37;
            this.saveButton.Text = "Aplicar";
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // labelError
            // 
            this.labelError.Font = new System.Drawing.Font("Bahnschrift Light SemiCondensed", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelError.ForeColor = System.Drawing.Color.Red;
            this.labelError.Location = new System.Drawing.Point(14, 107);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(374, 19);
            this.labelError.TabIndex = 24;
            this.labelError.Text = "Error text";
            this.labelError.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelError.Visible = false;
            // 
            // AskRackLenght
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(47)))), ((int)(((byte)(75)))));
            this.ClientSize = new System.Drawing.Size(402, 415);
            this.Controls.Add(this.helpPanel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgridNamesList);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.labelError);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AskRackLenght";
            this.Padding = new System.Windows.Forms.Padding(14);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Longitud";
            this.Load += new System.EventHandler(this.AskRackLenght_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgridNamesList)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.helpPanel.ResumeLayout(false);
            this.helpPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dgridNamesList;
        private Panel panel1;
        private Label label15;
        private Label label3;
        private Panel helpPanel;
        private Label propsTitle;
        private Button closeHelp;
        private PictureBox pictureBox1;
        private Button saveButton;
        private ActionButton actionButton1;
        private Label labelError;
        private DataGridViewTextBoxColumn rackName;
        private DataGridViewTextBoxColumn rackLenght;
        private DataGridViewTextBoxColumn firstIndex;
    }
}