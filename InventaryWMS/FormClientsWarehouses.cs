using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace InventaryWMS
{
    public partial class FormClientsWarehouses : Form
    {
        SelectSQL selectSQL = new SelectSQL();
        InsertSQL insertSQL = new InsertSQL();
        UpdateSQL updateSQL = new UpdateSQL();
        DeleteSQL deleteSQL = new DeleteSQL();
        Security security = new Security();
        Main mainForm { get; set; }
        private string _Name { get; set; }
        private int _idClient { get; set; }
        private bool _valid { get; set; }
        private bool _save { get; set; }
        private bool _new { get; set; }

        public FormClientsWarehouses(Main main)
        {
            this.mainForm = main;
            InitializeComponent();
            inicialize();
            permission();
        }

        private void permission()
        {
            if (mainForm.permission.Rows[0]["CLIENTS_EDIT"].ToString() == "False" && mainForm.permission.Rows[0]["WAREHOUSE_EDIT"].ToString() == "False")
            {
                buttonSave.Visible = false;

            }
        }

        public FormClientsWarehouses(Main main, int Client)
        {
            this.mainForm = main;
            InitializeComponent();
            inicialize();
            _idClient = Client;
            comboBoxClient.SelectedItem = selectSQL.GetClients(_idClient);
            comboBoxClient.Enabled = false;
            permission();
        }

        private void inicialize()
        {
            selectSQL.ClientsAComboBox(comboBoxClient);
            selectSQL.WarehouseAComboBox(comboBoxWarehouse);
            _save = false;
            _new = false;
        }

       

        private void VisibleForm(bool panel)
        {
            spinner.Visible = panel;
            buttonSave.Enabled = !panel;
            permission();

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            VisibleForm(true);
            int IDCLIENT = selectSQL.GetIdOnCheckClients(comboBoxClient.Text);
            int IDWAREHOUSE = selectSQL.GetIdOnShortNameWarehoses(comboBoxWarehouse.Text);

            try
            {
                if (!selectSQL.CheckClientsExitsWarehouse(IDCLIENT, IDWAREHOUSE))
                {
                    if (_valid)
                    {
                        if (insertSQL.saveToClientWarehouse(IDCLIENT, IDWAREHOUSE))
                        {
                            VisibleForm(false);
                            MessageBox.Show("Cliente: " + comboBoxClient.Text + " asignado a almacen "+ comboBoxWarehouse.Text + " con exito");
                            Close();
                        }
                    }
                }
                else
                {
                    if (!_valid)
                    {
                        if (deleteSQL.DeleteClientsWarehouse(IDCLIENT, IDWAREHOUSE))
                        {
                            VisibleForm(false);
                            MessageBox.Show("Cliente" + comboBoxClient.Text + " removido de almacen " + comboBoxWarehouse.Text + " con exito");
                            Close();
                        }
                    }
                }
            }
            catch { }
        }

        private void comboBoxName_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {

        }
        private void pictureBoxValid_Click(object sender, EventArgs e)
        {
            Valid(false);
        }

        private void pictureBoxNotValid_Click(object sender, EventArgs e)
        {
            Valid(true);


        }

        private void Valid(bool val)
        {
            _valid = val;
            pictureBoxValid.Visible = val;
            pictureBoxNotValid.Visible = !val;
        }

        private void comboBoxWarehouse_SelectedIndexChanged(object sender, EventArgs e)
        { 
            try
            {
                int IDCLIENT = selectSQL.GetIdOnCheckClients(comboBoxClient.Text);
                int IDWAREHOUSE = selectSQL.GetIdOnShortNameWarehoses(comboBoxWarehouse.Text);
                if (comboBoxClient.Text != "")
                {
                    Valid(selectSQL.CheckClientsExitsWarehouse(IDCLIENT, IDWAREHOUSE));
                }
            }

            catch (Exception ex)
            {
                System.Console.WriteLine("Error : " + ex.Message);
            }
        }
    }

   
}
