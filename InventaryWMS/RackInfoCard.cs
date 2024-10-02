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
    public partial class RackInfoCard : UserControl
    {
        private int rack_id;
        private string rack_name;
        private Main mainForm;
        public delegate void Detalles(int id, bool edit);
        public Detalles openForm;

        public RackInfoCard()
        {
            InitializeComponent();
        }
        public RackInfoCard(Main mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        public void setProperties(string name, int idRack)
        {
            rack_id = idRack;
            rack_name = nameLabel.Text = name;
        }     

        private void RackInfoCard_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                openForm(rack_id, false);
            }
            else if (e.Button == MouseButtons.Right)
            {
                openForm(rack_id, true);
            }            
        }
    }
}
