using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventaryWMS
{
    public partial class ActionButton : UserControl
    {
        public event EventHandler ButtonClick;
        public ActionButton()
        {
            InitializeComponent();
        }
        
        public string UserLabelText
        {
            get { return ActionBtn.Text; }
            set { ActionBtn.Text = value; }
        }
        public Image UserImage
        {
            get { return mainImage.Image; }
            set { mainImage.Image = value; }
        }

        private void YourButton_Click(object sender, EventArgs e)
        {
            ButtonClick?.Invoke(this, e);
        }
    }
}
