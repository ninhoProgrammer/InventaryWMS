using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventaryWMS
{
    public partial class FormClient : Form
    {
        #region Variabls and triggers
        Main mainForm;
        SelectSQL selectSQL = new SelectSQL();
        InsertSQL insertSQL = new InsertSQL();
        UpdateSQL updateSQL = new UpdateSQL();
        DeleteSQL deleteSQL = new DeleteSQL();
        Clients client { get; set; }
        private bool _valid { get; set; }
        private bool _new { get; set; }
        private bool _save { get; set; }
        private bool _updateForm { get; set; }
        private int _idUser { get; set; }
        public FormClient()
        {
            InitializeComponent();
            Inicialice();
        }

        public FormClient(Main main)
        {
            this.mainForm = main;
            InitializeComponent();
            Inicialice();
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

        public void Modify(bool update, int user)
        {
            this.Text = "Modifica Cliente";
            _updateForm = update;
            _idUser = user;
            comboBoxClient.Items.Clear();
            selectSQL.ClientsAComboBoxFromClient(comboBoxClient);
            showNameCompany(update);
            viewGroup(true);
        }

        public void Delete(int user)
        {
            this.Text = "Elimina Cliente";


            showNameCompany(true);
            viewGroup(true);
        }

        private void Inicialice()
        {
            client = new Clients();
            comboBoxContry.Items.Clear();
            this.Text = "Cliente";
            

            selectSQL.ClientsTypeAComboBox(comboBoxType);
            selectSQL.ClientsAComboBoxFromClient(comboBoxClient);
            selectSQL.ContryAComboBox(comboBoxContry);
            comboBoxContry.SelectedIndex = 1;
            VisibleForm(false);
            FillClientsWarehouse(false);
            viewGroup(false);
        }

        private void FormClient_Load(object sender, EventArgs e)
        {

        }
        #endregion

        #region Click And Changed
        private void buttonSave_Click(object sender, EventArgs e)
        {
            spinner.Visible = true;
            try
            {
                if (ValidateNoNull())
                {
                    fillClints();
                    if (_new)
                        InsertSentency();

                    else if (_save)
                        UpdateSentency();
                }
                VisibleForm(false);
                FillClientsWarehouse(false);
            }
            catch
            {
                VisibleForm(false);
                if (mainForm.permission.Rows[0]["CLIENTS_EDIT"].ToString() == "False")
                {
                    buttonNew.Visible = false;

                }
                else
                {
                    buttonNew.Visible = true;
                }
            }

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro de eliminar el Usuario?", "Alerta se eliminara usuario", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                if (deleteSQL.DeleteClient(selectSQL.GetIdClientName(comboBoxClient.Text), comboBoxClient.Text))
                    Close();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBoxClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxAutomaticEmailInventory.Items.Clear();
            comboBoxAutomaticEmailInvoice.Items.Clear();
            comboBoxAutomaticEmailRemission.Items.Clear();
            Clients client = selectSQL.FillDateClients(comboBoxClient.SelectedItem.ToString());
            if (client != null)
            {
                fullClients(client);
                viewGroup(true);
                textBoxNameClient.Focus();
                if (mainForm.permission.Rows[0]["CLIENTS_EDIT"].ToString() == "True")
                {
                    pictureBoxEdit.Visible = true;

                }
            }

        }
        private void control_Click(object sender, EventArgs e)
        {
            if (sender is TextBox textBox && !String.IsNullOrEmpty(textBox.Text))
            {
                textBox.SelectionStart = 0;
                textBox.SelectionLength = textBox.Text.Length;
            }
            else if (sender is ComboBox comboBox && comboBox.SelectedItem != null)
            {
                comboBox.SelectionStart = 0;
                comboBox.SelectionLength = comboBox.Text.Length;
            }
        }

        private void pictureBoxCancel_Click(object sender, EventArgs e)
        {
            VisibleForm(false);
            if (mainForm.permission.Rows[0]["CLIENTS_EDIT"].ToString() == "False")
            {
                buttonNew.Visible = false;

            }
            else
            {
                buttonNew.Visible = true;
            }
            _save = false;
            _new = false;
        }

        private void pictureBoxEdit_Click(object sender, EventArgs e)
        {
            if (comboBoxClient.SelectedIndex != -1)
            {
                VisibleForm(true);
                if (mainForm.permission.Rows[0]["CLIENTS_EDIT"].ToString() == "False")
                {
                    buttonNew.Visible = false;

                }
                FillClientsWarehouse(true);
                textBoxNameClient.Focus();
                _save = true;
            }

        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            _new = true;
            fullClients(new Clients());
            VisibleForm(true);
            textBoxNameClient.Focus();
            viewGroup(false);
        }

        private void FormClient_Click(object sender, EventArgs e)
        {
            BringToFront();
        }

        private void pictureBoxValid_Click(object sender, EventArgs e)
        {
            pictureBox(true);
        }

        private void pictureBoxNotValid_Click(object sender, EventArgs e)
        {
            pictureBox(false);
        }

        #endregion

        #region Keypress

        private void textBoxName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;//elimina el sonido
                textBoxShortName.Focus();
            }
        }

        private void textBoxShortName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;//elimina el sonido
                textBoxPrefix.Focus();
            }
        }

        private void textBoxPrefix_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;//elimina el sonido
                textBoxDocumnetName.Focus();
            }
        }

        private void textBoxDocumnetName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;//elimina el sonido
                textBoxRFC.Focus();
            }
        }

        private void textBoxRFC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;//elimina el sonido
                comboBoxType.Focus();
            }
        }

        private void textBoxType_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;//elimina el sonido
                comboBoxContry.Focus();
            }
        }

        private void textBoxWarehouse_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;//elimina el sonido
                
            }
        }

        private void textBoxContry_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;//elimina el sonido
                textBoxState.Focus();
            }
        }

        private void textBoxState_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;//elimina el sonido
                textBoxCity.Focus();
            }
        }

        private void textBoxCity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;//elimina el sonido
                textBoxDistrict.Focus();
            }
        }

        private void textBoxDistrict_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;//elimina el sonido
                textBoxStreet.Focus();
            }
        }

        private void textBoxStreet_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;//elimina el sonido
                textBoxZipCode.Focus();
            }
        }

        private void textBoxZipCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;//elimina el sonido
                textBoxImmex.Focus();
            }
        }

        private void textBoxImmex_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;//elimina el sonido
                textBoxEmail.Focus();
            }
        }

        private void textBoxEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;//elimina el sonido
                textBoxContactNumber.Focus();
            }
        }

        private void textBoxContactNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;//elimina el sonido
                comboBoxAutomaticEmailInvoice.Focus();
            }
        }


        #endregion

        #region Functions
        private void fullClients(Clients client)
        {
            textBoxNameClient.Text = client.NAME;
            textBoxShortName.Text = client.SHORT_NAME;
            textBoxDocumnetName.Text = client.DOCUMNET_NAME;
            textBoxPrefix.Text = client.PREFIX;
            comboBoxType.SelectedItem = selectSQL.TakeClientType(client.TYPE);
            comboBoxContry.SelectedItem = selectSQL.TakeContry(client.COUNTRY);
            textBoxState.Text = client.STATE;
            textBoxCity.Text = client.CITY;
            textBoxDistrict.Text = client.DISTRICT;
            textBoxStreet.Text = client.STREET;
            textBoxZipCode.Text = client.ZIPCODE;
            textBoxImmex.Text = client.IMMEX;
            textBoxRFC.Text = client.RFC;
            textBoxEmail.Text = client.CONTACT_EMAIL;
            textBoxContactNumber.Text = client.CONTACT_NUMBER.ToString();
            selectSQL.EmailAComboBox(comboBoxAutomaticEmailInvoice, client.IDCLIENTS + " AND INVOICE = 'true'");
            selectSQL.EmailAComboBox(comboBoxAutomaticEmailRemission, client.IDCLIENTS + " AND REMISSION = 'true'");
            selectSQL.EmailAComboBox(comboBoxAutomaticEmailInventory, client.IDCLIENTS + " AND INVENTORY = 'true'");
            if (client.AUTOMATIC_EMAIL_INVOICE != 0)
                comboBoxAutomaticEmailInvoice.SelectedItem = selectSQL.TakeEmais(client.AUTOMATIC_EMAIL_INVOICE, client.IDCLIENTS);
            if (client.AUTOMATIC_EMAIL_REMISSION != 0)
                comboBoxAutomaticEmailRemission.SelectedItem = selectSQL.TakeEmais(client.AUTOMATIC_EMAIL_REMISSION, client.IDCLIENTS);
            if (client.AUTOMATIC_EMAIL_INVENTARY != 0)
                comboBoxAutomaticEmailInventory.SelectedItem = selectSQL.TakeEmais(client.AUTOMATIC_EMAIL_INVENTARY, client.IDCLIENTS);

        }

        private void viewGroup(bool view)
        {
            groupBoxComboBoxAutomaticEmail.Visible = view;
            comboBoxAutomaticEmailInvoice.Visible = view;
            comboBoxAutomaticEmailRemission.Visible = view;
            comboBoxAutomaticEmailInventory.Visible = view;
        }

        private bool ValidateNoNull()
        {
            bool nullC = true;
            string chain = "Campo no puede ser null:";

            foreach (Control control in Controls)
            {
                if (control.Name == "panelPropiedades")
                    if (control is Panel tabControl)
                    {
                        foreach (Control controlTabControl in tabControl.Controls)
                        {
                            if (controlTabControl is TextBox textBox)
                            {

                                if (textBox.AccessibleName == "Nombre" && textBox.Text == "")
                                {
                                    chain += " -" + controlTabControl.Name;
                                    nullC = false;
                                }
                                if (textBox.AccessibleName == "Nombre corto" && textBox.Text == "")
                                {
                                    chain += " -" + controlTabControl.Name;
                                    nullC = false;
                                }

                            }

                        }
                    }




            }
            if (!nullC)

                if (!nullC)
                MessageBox.Show(chain);

            return nullC;
        }

        public void InsertSentency()
        {
            Task.Run(() =>
            {

                this.Invoke((Action)(() =>
                {

                    if (insertSQL.saveToClients(client))
                    {
                        insertSQL.SaveToBinnacle("Cliente dado de alta: " + textBoxNameClient.Text);
                        //insertSQL.saveToConfigurations(new Configurations());
                        //Provider prov = new Provider();
                        //prov.IDCLIENTE = selectSQL.GetIdClientName(textBoxNameClient.Text);
                        //prov.NAME = textBoxNameClient.Text;
                        //prov.DESCRIPTION = textBoxNameClient.Text;
                        //prov.VALID = true;
                        //insertSQL.saveToProvider(prov);
                        Configurations conf = new Configurations();
                        conf.IDCLIENT = selectSQL.GetIdClientName(textBoxNameClient.Text);
                        insertSQL.saveToConfigurations(conf);
                        MessageBox.Show("Cliente dado de alta con exito");
                        comboBoxClient.Items.Clear();
                        selectSQL.ClientsAComboBoxFromClient(comboBoxClient);
                        comboBoxClient.Text = textBoxNameClient.Text;
                        spinner.Visible = false;
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
                    if (updateSQL.UpdateProducts(client))
                    {
                        insertSQL.SaveToBinnacle("Cliente: " + textBoxNameClient.Text + ", modificado con exito");
                        MessageBox.Show("Cliente modificado con exito");
                        comboBoxClient.Items.Clear();
                        selectSQL.ClientsAComboBoxFromClient(comboBoxClient);
                        comboBoxClient.Text = textBoxNameClient.Text;
                        spinner.Visible = false;
                    }
                }));
            });
        }

       

        public void fillComboBoxNameUpdate()
        {
            selectSQL.ClientsAComboBoxFromClient(comboBoxClient);
            string giveListCompany = selectSQL.UserHasTheseClients(_idUser);
            if (giveListCompany == "Y         " || giveListCompany == "Y")
            {
                selectSQL.ClientsAComboBoxFromClient(comboBoxClient);
            }
            else
            {
                selectSQL.ListCompaniesAComboBox(comboBoxClient, _idUser);
            }
            comboBoxClient.SelectedIndex = 0;
        }

        public void showNameCompany(bool isCompany)
        {
            comboBoxClient.Visible = isCompany;
            comboBoxClient.Enabled = isCompany;
            textBoxNameClient.Visible = !isCompany;
            textBoxNameClient.Enabled = !isCompany;
        }

        private void VisibleForm(bool panel)
        {
            textBoxNameClient.Enabled = panel;
            textBoxShortName.Enabled = panel;
            textBoxDocumnetName.Enabled = panel;
            textBoxRFC.Enabled = panel;
            comboBoxType.Enabled = panel;
            comboBoxClient.Enabled = !panel;
            tabControl1.Enabled = panel;
            buttonNew.Enabled = !panel;
            buttonNew.Visible = !panel;
            buttonSave.Visible = panel;
            pictureBoxCancelEdit.Visible = panel;
            pictureBoxCancel.Visible = panel;
            permission();
        }

        private void fillClints()
        {
            client.NAME = textBoxNameClient.Text;
            client.SHORT_NAME = textBoxShortName.Text;
            client.DOCUMNET_NAME = textBoxDocumnetName.Text;
            client.PREFIX = textBoxPrefix.Text;
            client.TYPE = selectSQL.GetIdClientType(comboBoxType.Text);
            client.COUNTRY = selectSQL.GetContry(comboBoxContry.Text);
            client.STATE = textBoxState.Text;
            client.CITY = textBoxCity.Text;
            client.DISTRICT = textBoxDistrict.Text;
            client.STREET = textBoxStreet.Text;
            client.ZIPCODE = textBoxZipCode.Text;
            client.IMMEX = textBoxImmex.Text;
            client.RFC = textBoxRFC.Text;
            client.CONTACT_EMAIL = textBoxEmail.Text;
            client.CONTACT_NUMBER = textBoxContactNumber.Text;
            if (_save)
            {
                client.AUTOMATIC_EMAIL_INVOICE = selectSQL.GetIdAutomaticEmail(comboBoxAutomaticEmailInvoice.Text + " AND IDCLIENT = " + client.IDCLIENTS + " AND INVOICE = 'true'");
                client.AUTOMATIC_EMAIL_REMISSION = selectSQL.GetIdAutomaticEmail(comboBoxAutomaticEmailRemission.Text + " AND IDCLIENT = " + client.IDCLIENTS + " AND REMISSION = 'true'");
                client.AUTOMATIC_EMAIL_INVENTARY = selectSQL.GetIdAutomaticEmail(comboBoxAutomaticEmailInventory.Text + " AND IDCLIENT = " + client.IDCLIENTS + " AND INVENTORY = 'true'");
            }
            client.VALID = _valid;
        }
        private void pictureBox(bool valid)
        {
            _valid = !valid;
            pictureBoxValid.Visible = !valid;
            pictureBoxNotValid.Visible = valid;

        }


        #endregion

        private void comboBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (sender is ComboBox comboBox)
            {
                if (e.Button == MouseButtons.Left)
                {
                    int buttonWidth = SystemInformation.VerticalScrollBarWidth; // Ancho del botón de despliegue
                    int textBoxWidth = comboBox.Width - buttonWidth;

                    // Verifica si se hizo clic en el botón de despliegue
                    if (e.X > textBoxWidth)
                    {
                        //MessageBox.Show("Se hizo clic en la flecha hacia abajo.");
                    }
                    else
                    {
                        //MessageBox.Show("Se hizo clic en el área de texto.");
                        comboBox.Focus();
                    }
                }
            }
        }

        private void pictureBoxCancelEdit_Click(object sender, EventArgs e)
        {
            VisibleForm(false);
            if (comboBoxClient.SelectedIndex != 1)
            {
                int l = comboBoxClient.SelectedIndex;
                comboBoxClient.SelectedIndex = 0;
                comboBoxClient.SelectedIndex = l;
                comboBoxClient.Focus();
            }
            _save = false;
        }

        private void textBoxNameClient_Leave(object sender, EventArgs e)
        {
            string inputText = textBoxNameClient.Text;
            if (!string.IsNullOrEmpty(inputText))
            {
                string prefix = GetPrefix(inputText);

                // Si el prefijo ya existe, elige otro prefijo
                if (selectSQL.existsPrefix(prefix))
                {
                    prefix = GetUniquePrefix(inputText);
                }

                textBoxPrefix.Text = prefix;
            }
            else
            {
                textBoxPrefix.Text = string.Empty;
            }
        }

        private string GetPrefix(string inputText)
        {
            var words = inputText.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (words.Length >= 2)
            {
                return (words[0][0].ToString() + words[1][0].ToString()).ToUpper();
            }
            else if (words.Length == 1 && words[0].Length >= 2)
            {
                return words[0].Substring(0, 2).ToUpper();
            }
            else
            {
                return inputText.Length >= 2 ? inputText.Substring(0, 2).ToUpper() : inputText.ToUpper();
            }
        }

        private string GetUniquePrefix(string inputText)
        {
            var words = inputText.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string prefix = "";

            if (words.Length >= 1)
            {
                // Si el prefijo basado en la primera palabra ya existe, genera otro prefijo único
                for (int i = 1; i < words[0].Length; i++)
                {
                    prefix = words[0].Substring(0, i + 1).ToUpper();
                    if (!selectSQL.existsPrefix(prefix))
                    {
                        return prefix;
                    }
                }
            }

            // Logica simple para generar un prefijo único si todas las otras opciones fallan
            for (char i = 'A'; i <= 'Z'; i++)
            {
                for (char j = 'A'; j <= 'Z'; j++)
                {
                    string newPrefix = i.ToString() + j.ToString();
                    if (!selectSQL.existsPrefix(prefix))
                    {
                        return newPrefix;
                    }
                }
            }

            return prefix;
        }

        private void FormClient_Load_1(object sender, EventArgs e)
        {
            // Asigna el evento TextChanged al textbox principal
            //textBoxNameClient.TextChanged += textBoxNameClient_Leave;
        }

        private void buttonClientsWarehouse_Click(object sender, EventArgs e)
        {
            FormClientsWarehouses form = new FormClientsWarehouses(mainForm, client.IDCLIENTS);
            form.ShowDialog();
        }

        private void FillClientsWarehouse( bool view)
        {
            labelWarehouse.Visible = view;
            buttonClientsWarehouse.Visible = view;
        }
    }
}
