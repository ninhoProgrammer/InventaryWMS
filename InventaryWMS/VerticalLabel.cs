using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventaryWMS
{
    public partial class VerticalLabel : UserControl
    {
        public VerticalLabel()
        {
            InitializeComponent();
            this.Paint += new PaintEventHandler(RotatedLabelControl_Paint);
        }

        void RotatedLabelControl_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.TranslateTransform(this.Width / 2, this.Height / 2);
            e.Graphics.RotateTransform(-90);
            e.Graphics.DrawString("Nivel", new Font("Bahnschrift Light SemiCondensed", 12f), Brushes.Gray, -this.Height / 2, -this.Width / 2);
        }
    }
}
