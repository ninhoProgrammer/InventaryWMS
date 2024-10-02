using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows.Forms;

namespace InventaryWMS
{
    public partial class CreateVirtualRack : Form
    {                
        private bool automatedCreate;
        private int idClient;
        private SelectSQL selectSQL = new SelectSQL();
        private List<WarehouseRack> currentRackNames = new List<WarehouseRack>();
        public CreateVirtualRack(int idClient)
        {
            InitializeComponent();
            this.idClient = idClient;
            automatedCreate = false;            
        }

        public CreateVirtualRack(int idClient, List<WarehouseRack> rackList)
        {
            InitializeComponent();            
            this.idClient = idClient; 
            currentRackNames = rackList;
            automatedCreate = true;            
        }
        

        private void saveRackBtn_Click(object sender, EventArgs e)
        {
            if (!checkIsNullOrEmptyOrWhitespaces(rackName.Text))
            {
                if (checkValidName(rackName.Text.Trim()))
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("El nombre que ingresó ya está en uso, escriba uno diferente.", "Nombre no disponible", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }               
            }
            else
            {
                MessageBox.Show("Complete todos los campos", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }         
        }

        private bool checkValidName(string name)
        {
            foreach (WarehouseRack rack in currentRackNames)
            {
                if (rack.name.ToLower() == name.ToLower()) 
                {
                    return false;
                }
            }
            return true;
        }

        private bool checkIsNullOrEmptyOrWhitespaces(string str)
        {
            if (string.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str))
            {
                return true;
            }
            return false;
        }

        private void rackName_TextChanged(object sender, EventArgs e)
        {
            if(rackName.Text.Length > 5)
            {
                warningLabel.Visible = true;
                rackName.Text = rackName.Text.Substring(0, 6);
            }
            else
            {
                warningLabel.Visible = false;
            }
        }        

        private void CreateVirtualRack_Load(object sender, EventArgs e)
        {
            var count = currentRackNames.Count + 1;
            
            var shortName = "BAHI";
            if(count > 10)
            {
                shortName += count.ToString();
            }
            else if(count > 0 && count < 10)
            {
                shortName += "0" + count.ToString();
            }
            rackName.Text = shortName;
            Task.Run(() =>
            {
                var client = selectSQL.GetClients(idClient);
                Invoke((Action)(() =>
                {
                    spinner.Visible = false;
                    clientName.Text = client;
                    clientName.Visible = true;
                }));
            });
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
