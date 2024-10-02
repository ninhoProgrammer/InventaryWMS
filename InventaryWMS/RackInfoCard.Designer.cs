using System.Drawing;
using InventaryWMS;
using System.Windows.Forms;
namespace InventaryWMS
{
    partial class RackInfoCard
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RackInfoCard));
            pictureBox1 = new PictureBox();
            nameLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.None;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(5, 8);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(61, 37);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.MouseDown += RackInfoCard_MouseDown;
            // 
            // nameLabel
            // 
            nameLabel.Anchor = AnchorStyles.None;
            nameLabel.Font = new Font("Bahnschrift SemiBold SemiConden", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            nameLabel.ForeColor = Color.DarkSlateGray;
            nameLabel.Location = new Point(0, 46);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(70, 21);
            nameLabel.TabIndex = 1;
            nameLabel.Text = "A";
            nameLabel.TextAlign = ContentAlignment.MiddleCenter;
            nameLabel.MouseDown += RackInfoCard_MouseDown;
            // 
            // RackInfoCard
            // 
            AutoScaleMode = AutoScaleMode.None;
            AutoSize = true;
            BackColor = Color.FromArgb(182, 217, 216);
            Controls.Add(nameLabel);
            Controls.Add(pictureBox1);
            Margin = new Padding(0);
            MaximumSize = new Size(70, 70);
            MinimumSize = new Size(70, 70);
            Name = "RackInfoCard";
            Size = new Size(70, 70);
            MouseDown += RackInfoCard_MouseDown;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Label nameLabel;
    }
}
