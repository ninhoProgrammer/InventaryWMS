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
    public partial class SystemConfiguration : Form
    {
        Security security = new Security();
        public bool floatingWindow { get; set; }
        private bool _floating { get; set; }
        public bool colorWindow { get; set; }
        private bool _color { get; set; }
        private bool _cerrar { get; set; }

        public SystemConfiguration(bool fw, bool cw)
        {
            InitializeComponent();
            string con = security.createFile("conections.txt");
            
            string[] conectionsString = con.Split('|');
            if (conectionsString.Length != 0)
            {
                textBoxServer.Text = conectionsString[0];
                textBoxUser.Text = conectionsString[1];
                textBoxPassword.Text = conectionsString[2];
            }
            floatingWindow = fw;
            _floating = fw;
            colorWindow = cw;
            _color = cw;
            pictureBoxTurnON.Visible = fw;
        }

        private void pictureBoxTurnON_Click(object sender, EventArgs e)
        {
            pictureBoxTurnON.Visible = false;
            pictureBoxTurnOFF.Visible = true;
            floatingWindow = false;
        }

        private void pictureBoxTurnOFF_Click(object sender, EventArgs e)
        {
            pictureBoxTurnON.Visible = true;
            pictureBoxTurnOFF.Visible = false;
            floatingWindow = true;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            floatingWindow = _floating;
            colorWindow = _color;
            this.Close();
        }

        private void SystemConfiguration_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void SystemConfiguration_Load(object sender, EventArgs e)
        {

        }

        private void buttonSaved_Click(object sender, EventArgs e)
        {
            security.writeFile("conections.txt", ""+ textBoxServer.Text +"|"+ textBoxUser.Text +"|"+ textBoxPassword.Text +"");
            _cerrar = true;
            this.Close();
        }

        private void SystemConfiguration_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_cerrar)
            {
                floatingWindow = _floating;
                colorWindow = _color;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
