namespace InventaryWMS
{
    partial class LoadingSpinner
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoadingSpinner));
            this.spinnerWhList = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.spinnerWhList)).BeginInit();
            this.SuspendLayout();
            // 
            // spinnerWhList
            // 
            this.spinnerWhList.BackColor = System.Drawing.Color.Transparent;
            this.spinnerWhList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spinnerWhList.Image = ((System.Drawing.Image)(resources.GetObject("spinnerWhList.Image")));
            this.spinnerWhList.Location = new System.Drawing.Point(0, 0);
            this.spinnerWhList.Name = "spinnerWhList";
            this.spinnerWhList.Size = new System.Drawing.Size(40, 40);
            this.spinnerWhList.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.spinnerWhList.TabIndex = 37;
            this.spinnerWhList.TabStop = false;
            // 
            // LoadingSpinner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.spinnerWhList);
            this.MaximumSize = new System.Drawing.Size(40, 40);
            this.MinimumSize = new System.Drawing.Size(40, 40);
            this.Name = "LoadingSpinner";
            this.Size = new System.Drawing.Size(40, 40);
            ((System.ComponentModel.ISupportInitialize)(this.spinnerWhList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox spinnerWhList;
    }
}
