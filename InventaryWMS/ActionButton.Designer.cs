
namespace InventaryWMS
{
    partial class ActionButton
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
            mainImage = new System.Windows.Forms.PictureBox();
            ActionBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)mainImage).BeginInit();
            SuspendLayout();
            // 
            // mainImage
            // 
            mainImage.BackColor = System.Drawing.Color.Transparent;
            mainImage.Image = Properties.Resources.delete_ic;
            mainImage.Location = new System.Drawing.Point(3, 12);
            mainImage.Name = "mainImage";
            mainImage.Size = new System.Drawing.Size(54, 20);
            mainImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            mainImage.TabIndex = 110;
            mainImage.TabStop = false;
            // 
            // ActionBtn
            // 
            ActionBtn.Font = new System.Drawing.Font("Bahnschrift Light SemiCondensed", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            ActionBtn.ForeColor = System.Drawing.SystemColors.GrayText;
            ActionBtn.Location = new System.Drawing.Point(0, 38);
            ActionBtn.Name = "ActionBtn";
            ActionBtn.Size = new System.Drawing.Size(60, 37);
            ActionBtn.TabIndex = 111;
            ActionBtn.Text = "Text";
            ActionBtn.UseVisualStyleBackColor = true;
            ActionBtn.Click += YourButton_Click;
            // 
            // ActionButton
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            BackColor = System.Drawing.Color.White;
            Controls.Add(mainImage);
            Controls.Add(ActionBtn);
            MaximumSize = new System.Drawing.Size(60, 75);
            MinimumSize = new System.Drawing.Size(60, 75);
            Name = "ActionButton";
            Size = new System.Drawing.Size(60, 75);
            ((System.ComponentModel.ISupportInitialize)mainImage).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.PictureBox mainImage;
        private System.Windows.Forms.Button ActionBtn;
    }
}
