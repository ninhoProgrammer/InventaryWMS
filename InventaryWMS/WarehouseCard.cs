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
    public partial class WarehouseCard : UserControl
    {
        private int id;
        public string shortName;
        public delegate void Detalles(int id);
        public Detalles delegado;
        public WarehouseCard()
        {
            InitializeComponent();
        }

        public void SetProperties(string title, int warehouse_id)
        {
            titleLabel.Text = "Almacén " + title;
            shortName = title;
            id = warehouse_id;

        }

        private void WarehouseCard_MouseClick(object sender, MouseEventArgs e)
        {
            delegado(id);
        }

    }
}
