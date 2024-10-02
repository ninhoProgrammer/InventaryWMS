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
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace InventaryWMS
{
    public partial class FormClientsProviders : Form
    {
        SelectSQL selectSQL = new SelectSQL();
        InsertSQL insertSQL = new InsertSQL();
        UpdateSQL updateSQL = new UpdateSQL();
        DeleteSQL deleteSQL = new DeleteSQL();
        Security security = new Security();
        Provider provider { get; set; }
        Main mainForm { get; set; }
        private string _Name { get; set; }
        private int _idClient { get; set; }
        private bool _valid { get; set; }
        private bool _save { get; set; }
        private bool _new { get; set; }

        public FormClientsProviders(Main main)
        {
            this.mainForm = main;
            InitializeComponent();
            inicialize();
            permission();
        }

        private void permission()
        {
            if (mainForm.permission.Rows[0]["CLIENTS_CREATE"].ToString() == "False")
            {
                buttonNew.Visible = false;

            }
            if (mainForm.permission.Rows[0]["CLIENTS_EDIT"].ToString() == "False")
            {
                pictureBoxEdit.Visible = false;

            }
        }

        public FormClientsProviders()
        {
            //this.mainForm = main;
            InitializeComponent();
            inicialize();
        }

        private void inicialize()
        {
            
            provider = new Provider();
            _idClient = int.Parse(security.createFile("address.txt"));
            selectSQL.ProviderAComboBox(comboBoxName, _idClient);
            _valid = true;
            _save = false;
            _new = false;
            pictureBoxEdit.Visible = _save;
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            _new = true;
            fullProviders(new Provider());
            VisibleForm(_new);
            textboxName.Focus();
        }

        private void pictureBoxEdit_Click(object sender, EventArgs e)
        {
            _save = true;

            VisibleForm(_save);
            textboxName.Focus();
        }

        private void VisibleForm(bool panel)
        {
            if (panel == false)
                comboBoxName.Text = provider.NAME;

            textBoxDescription.Enabled = panel;
            textboxName.Enabled = panel;
            pictureBoxCancel.Visible = panel;
            buttonSave.Visible = panel;
            pictureBoxEdit.Visible = !panel;
            comboBoxName.Enabled = !panel;
            permission();

        }

        private void pictureBoxCancel_Click(object sender, EventArgs e)
        {
            _save = false;
            _new = false;
            //comboBoxName_SelectedIndexChanged(sender, e);
            VisibleForm(false);
            if (comboBoxName.SelectedIndex != -1)
            {
                int l = comboBoxName.SelectedIndex;
                comboBoxName.SelectedIndex = 0;
                comboBoxName.SelectedIndex = l;
                comboBoxName.Focus();
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            spinner.Visible = true;
            buttonSave.Enabled = false;
            try
            {
                fillProvider();
                if (_new)
                    InsertSentency();

                else if (_save)
                    UpdateSentency();
            }
            catch { }
        }

        private void fillProvider()
        {
            provider.IDCLIENTE = _idClient;
            provider.NAME = textboxName.Text;
            provider.DESCRIPTION = textBoxDescription.Text;
            provider.VALID = _valid;
            
        }


        public void InsertSentency()
        {

            Task.Run(() =>
            {

                this.Invoke((Action)(() =>
                {
                    spinner.Visible = false;
                    if (insertSQL.saveToProvider(provider))
                    {
                        insertSQL.SaveToBinnacle("Proveedor dado de alta: " + textBoxDescription.Text);
                        MessageBox.Show("Proveedor dado de alta con exito");
                        _new = false;
                        fetchDestinations();
                    }
                    else
                    {
                        spinner.Visible = false;
                        buttonSave.Enabled = true;
                    }
                }));
            });

        }

        private void UpdateSentency()
        {

            Task.Run(() =>
            {

                this.Invoke((Action)(() =>
                {
                    spinner.Visible = false;
                    if (updateSQL.UpdateProvider(provider))
                    {
                        insertSQL.SaveToBinnacle("Proveedor: " + textBoxDescription.Text + ", modificado con exito");
                        MessageBox.Show("Proveedor modificado con exito");
                        _save = false;
                        fetchDestinations();
                    }
                    else
                    {
                        spinner.Visible = false;
                        buttonSave.Enabled = true;
                    }
                }));
            });


        }

        private void fetchDestinations()
        {
            comboBoxName.Items.Clear();
            selectSQL.ProviderAComboBox(comboBoxName, _idClient);
            spinner.Visible = false;
            buttonSave.Enabled = true;
            VisibleForm(false);

        }

        private void fullProviders(Provider prov)
        {
            textboxName.Text = prov.NAME;
            textBoxDescription.Text = prov.DESCRIPTION;
            Valid(prov.VALID);
        }


        private void comboBoxName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxName.Text != "")
                {
                    if (mainForm.permission.Rows[0]["CLIENTS_EDIT"].ToString() == "True")
                    {
                        pictureBoxEdit.Visible = true;
                    }
                    provider = selectSQL.FillDateProviders(comboBoxName.Text, _idClient);
                }
                else
                {
                    pictureBoxEdit.Visible = false;

                }

                fullProviders(provider);
            }

            catch (Exception ex)
            {
                System.Console.WriteLine("Error : " + ex.Message);
            }
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
    }

   
}
