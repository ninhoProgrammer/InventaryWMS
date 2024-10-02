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
    public partial class InfoCard : UserControl
    {
        public InfoCard()
        {
            InitializeComponent();
            this.MinimumSize = new Size(100, 100);
            this.MaximumSize = new Size(100, 100);
            this.Size = new Size(100, 100);
            this.Margin = new Padding(0);
            this.Padding = new Padding(0);
        }                
        

        public void SetProperties(string title, string prop)
        {
            titleLabel.Text = title;
            propLabel.Text = prop;
        }
        
    }
}
