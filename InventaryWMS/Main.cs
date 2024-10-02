using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace InventaryWMS
{
    public partial class Main : Form
    {
        #region Variables and triggers
        SelectSQL selectSQL = new SelectSQL();
        InsertSQL insertSQL = new InsertSQL();
        public int _idUser { get; set; }
        public int _idClient { get; set; }
        public int _idPermissionUser { get; set; }
        public bool floatingWindow { get; set; }
        private bool _colorWindow { get; set; }
        private bool _notExit { get; set; }
        private Color _color { get; set; }
        public DataTable permission = new DataTable();
        public Main(int user, int client)
        {
            InitializeComponent();
            this._idUser = user;
            this._idClient = client;
            InitializeForm();
        }
        public Size getPanelContainerSize()
        {
            return this.panelContainer.Size;
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            this.MaximumSize = SystemInformation.PrimaryMonitorMaximizedWindowSize;
            this.WindowState = FormWindowState.Maximized;
            panelContainer.Width = this.ClientSize.Width;
            panelContainer.Height = this.ClientSize.Height - 85;
            panelButtons.Width = this.ClientSize.Width;
        }

        private void InitializeForm()
        {
            companyToolStripStatusLabel.Text = selectSQL.GetClients(_idClient);
            userToolStripStatusLabel.Text = selectSQL.GetUser(_idUser);
            var textBinnacle = " Usuario: " + userToolStripStatusLabel.Text + " - Empresa: " + companyToolStripStatusLabel.Text;
            this.Text = textBinnacle;
            insertSQL.SaveToBinnacle("Inicio de sesion: " + textBinnacle);
            System.Console.WriteLine("Inicio de sesion: " + textBinnacle);
            FormPermissions();
        }

        #endregion

        #region Buttons and MenuItems
        private void ButtonInput_Click(object sender, EventArgs e)
        {
            bool productFilled = fullComboBoxProduct();
            bool providersFilled = fullComboBoxProviders();
            bool warehouseFilled = fullComboBoxWarehouse();

            if (!productFilled)
            {
                DialogResult result = MessageBox.Show("¿Quieres dar de alta uno?", "Alerta no se encontraron productos", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    FormProducts form = new FormProducts(this);
                    form.ShowDialog();
                    productFilled = fullComboBoxProduct();  // Vuelve a verificar después de agregar un producto
                }
            }

            if (!providersFilled)
            {
                DialogResult result = MessageBox.Show("¿Quieres dar de alta uno?", "Alerta no se encontraron proveedores", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    FormClientsProviders form = new FormClientsProviders(this);
                    form.ShowDialog();
                    providersFilled = fullComboBoxProviders();  // Vuelve a verificar después de agregar un proveedor
                }
            }

            if (!warehouseFilled)
            {
                DialogResult result = MessageBox.Show("¿Quieres dar de alta uno?", "Alerta no se encuentraron Almacenes", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    ManageWarehouses form = new ManageWarehouses(this);
                    form.ShowDialog();
                    warehouseFilled = fullComboBoxWarehouse();  // Vuelve a verificar después de agregar un proveedor
                    if (warehouseFilled)
                    {
                        DialogResult resultFilled = MessageBox.Show("¿Quieres asignar a Cliente?", "Almacen dado de alta con Exito", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (result == DialogResult.Yes)
                        {
                            FormClientsWarehouses formCW = new FormClientsWarehouses(this);
                            formCW.ShowDialog();
                            warehouseFilled = fullComboBoxWarehouse();  // Vuelve a verificar después de agregar un proveedor

                        }
                    }
                }
            }

            // Solo entra en el bloque else si ambos tienen datos
            if (productFilled && providersFilled && warehouseFilled)
            {
                if (!floatingWindow)
                    AddControlInPanel<Input>();
                else
                    AddForm<Input>();
            }
        }

        private void ButtonOutput_Click(object sender, EventArgs e)
        {
            bool clientFilled = fullcomboBox();

            if (!clientFilled)
            {
                DialogResult result = MessageBox.Show("¿Quieres dar de alta uno?", "Alerta no se encuentraron clientes de destino", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    FormDestinations form = new FormDestinations();
                    form.ShowDialog();
                    clientFilled = fullcomboBox();
                }
                
            }

            if (clientFilled)
            {
                if (!floatingWindow)
                    AddControlInPanel<Output>();
                else
                    AddForm<Output>();
            }
        }

        private void ButtonBinnacle_Click(object sender, EventArgs e)
        {
            if (!floatingWindow)
                AddControlInPanel<Binnacle>();
            else
                AddForm<Binnacle>();
        }

        private void ButtonProducts_Click(object sender, EventArgs e)
        {
            if (!floatingWindow)
                AddControlInPanel<Product>();
            else
                AddForm<Product>();
        }

        private void ButtonReports_Click(object sender, EventArgs e)
        {
            if (!floatingWindow)
                AddControlInPanel<Reports>();
            else
                AddForm<Reports>();
        }

        private void destinationsEditMenuItem_Click(object sender, EventArgs e)
        {
            /*if (!_floatingWindow)
                AddControlInPanel<FormDestinations>();
            else
                AddForm<FormDestinations>();*/
            var form = Application.OpenForms.OfType<FormDestinations>().FirstOrDefault();
            if (form == null)
            {
                FormDestinations mwForm = new FormDestinations(this);
                AddFormInPanel(mwForm);
            }
        }

        private void proveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Application.OpenForms.OfType<FormClientsProviders>().FirstOrDefault();
            if (form == null)
            {
                FormClientsProviders mwForm = new FormClientsProviders(this);
                AddFormInPanel(mwForm);
            }
        }

        private void productEditMenuItem_Click(object sender, EventArgs e)
        {
            /*if (!_floatingWindow)
                AddControlInPanel<FormProducts>();
            else
                AddForm<FormProducts>();*/
            var form = Application.OpenForms.OfType<FormProducts>().FirstOrDefault();
            if (form == null)
            {
                FormProducts mwForm = new FormProducts(this);
                AddFormInPanel(mwForm);
            }
        }

        private void ButtonSentency_Click(object sender, EventArgs e)
        {
            MessageBox.Show(panelContainer.ClientSize.Width + " " + panelContainer.ClientSize.Height + " Queso");
        }

        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void UserMenuItem_Click(object sender, EventArgs e)
        {
            FormLogin(false);
        }

        private void CompanyMenuItem_Click(object sender, EventArgs e)
        {
            FormLogin(true);
        }

        private void SignOffMenuItem_Click(object sender, EventArgs e)
        {
            FormLogin(false);
        }

        private void SystemConfigurationMenuItem_Click(object sender, EventArgs e)
        {
            SystemConfiguration systemConfiguration = new SystemConfiguration(floatingWindow, _colorWindow);
            systemConfiguration.ShowDialog();
            floatingWindow = systemConfiguration.floatingWindow;
            _colorWindow = systemConfiguration.colorWindow;

        }

        private void addPermissionsEditMenuItem_Click(object sender, EventArgs e)
        {
            if (!floatingWindow)
                AddControlInPanel<FormPermissions>();
            else
                AddForm<FormPermissions>();
        }

        private void updatePermissionsEditMenuItem_Click(object sender, EventArgs e)
        {
            if (!floatingWindow)
                AddControlInPanelUpdate<FormPermissions>(true);
            else
                AddFormUpdate<FormPermissions>(true);
        }

        private void deletePermissionsEditMenuItem_Click(object sender, EventArgs e)
        {
            if (!floatingWindow)
                AddControlInPanelDelete<FormPermissions>(true);
            else
                AddFormDelete<FormPermissions>(true);
        }

        private void addEmailEditMenuItem_Click(object sender, EventArgs e)
        {
            if (!floatingWindow)
                AddControlInPanel<FormEmails>();
            else
                AddForm<FormEmails>();
        }

        private void updateEmailEditMenuItem_Click(object sender, EventArgs e)
        {
            if (!floatingWindow)
                AddControlInPanelUpdate<FormEmails>(true);
            else
                AddFormUpdate<FormEmails>(true);
        }

        private void deleteEmailEditMenuItem_Click(object sender, EventArgs e)
        {
            if (!floatingWindow)
                AddControlInPanelDelete<FormEmails>(true);
            else
                AddFormDelete<FormEmails>(true);
        }



        private void addWarehouseEditMenuItem_Click(object sender, EventArgs e)
        {
            if (!floatingWindow)
                AddControlInPanel<FormWarehouse>();
            else
                AddForm<FormWarehouse>();
        }

        private void updateWarehouseEditMenuItem_Click(object sender, EventArgs e)
        {
            if (!floatingWindow)
                AddControlInPanelUpdate<FormWarehouse>(true);
            else
                AddFormUpdate<FormWarehouse>(true);
        }

        private void deleteWarehouseEditMenuItem_Click(object sender, EventArgs e)
        {
            if (!floatingWindow)
                AddControlInPanelDelete<FormWarehouse>(true);
            else
                AddFormDelete<FormWarehouse>(true);
        }


        private void clientsEditMenuItem_Click(object sender, EventArgs e)
        {
            /*if (!_floatingWindow)
                AddControlInPanel<FormClient>();
            else
                AddForm<FormClient>();  */
            var form = Application.OpenForms.OfType<FormClient>().FirstOrDefault();
            if (form == null)
            {
                FormClient mwForm = new FormClient(this);
                AddFormInPanel(mwForm);
            }

        }
        private void inveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*var form = Application.OpenForms.OfType<ManageInventary>().FirstOrDefault();
            if (form == null)
            {
                ManageInventary mInvForm = new ManageInventary(this);
                AddFormInPanel(mInvForm);
            }*/

        }

        private void permisosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!floatingWindow)
                AddControlInPanel<FormPermissions>();
            else
                AddForm<FormPermissions>();
        }

        private void userEditMenuItem_Click(object sender, EventArgs e)
        {
            /*if (!_floatingWindow)
                AddControlInPanel<FormUser>();
            else
                AddForm<FormUser>();*/
            var form = Application.OpenForms.OfType<FormUser>().FirstOrDefault();
            if (form == null)
            {
                FormUser mwForm = new FormUser(this);
                AddFormInPanel(mwForm);
            }
        }

        private void warehouseEditMenuItem_Click(object sender, EventArgs e)
        {
            var form = Application.OpenForms.OfType<ManageWarehouses>().FirstOrDefault();
            if (form == null)
            {
                ManageWarehouses mwForm = new ManageWarehouses(this);
                AddFormInPanel(mwForm);
            }
        }

        #endregion

        #region Functions

        public void FormPermissions()
        {
            _idPermissionUser = selectSQL.GetIDpermissionFromUser(_idUser);
            permission = selectSQL.GetPermission(_idPermissionUser);
            if (permission.Rows[0]["INVOICES_ACCESS"].ToString() == "False")
            {
                buttonInput.Visible = false;
            }
            if (permission.Rows[0]["REMISSIONS_ACCESS"].ToString() == "False")
            {
                button2.Visible = false;
            }
            if (permission.Rows[0]["LOCATE_ACESS"].ToString() == "False")
            {
                btnStoreProducts.Visible = false;
            }
            if (permission.Rows[0]["REPORT_ACESS"].ToString() == "False")
            {
                button3.Visible = false;
            }
            if (permission.Rows[0]["INVENTORY_ACCESS"].ToString() == "False")
            {
                buttonInventory.Visible = false;
            }
            if (permission.Rows[0]["PRODUCTS_ACCESS"].ToString() == "False")
            {
                buttonProducts.Visible = false;
                productEditMenuItem.Visible = false;
            }
            if (permission.Rows[0]["BINNACLE_ACESS"].ToString() == "False")
            {
                buttonBinnacle.Visible = false;
            }
            if (permission.Rows[0]["WAREHOUSE_ACESS"].ToString() == "False")
            {
                warehouseEditMenuItem.Visible = false;
            }
            if (permission.Rows[0]["CLIENTS_ACCESS"].ToString() == "False")
            {
                clientsEditMenuItem.Visible = false;
                proToolStripMenuItem.Visible = false;
            }
            if (permission.Rows[0]["DESTINATIONS_ACESS"].ToString() == "False")
            {
                destinationsEditMenuItem.Visible = false;
            }
            if (permission.Rows[0]["PERMISSIONS_ACESS"].ToString() == "False")
            {
                permisosToolStripMenuItem.Visible = false;
            }
            if (permission.Rows[0]["WORK_ORDER_ACESS"].ToString() == "False")
            {
                commandEditMenuItem.Visible = false;
            }
            if (permission.Rows[0]["USERS_ACCESS"].ToString() == "False")
            {
                userEditMenuItem.Visible = false;
            }
            if (permission.Rows[0]["MAIL_ACESS"].ToString() == "False")
            {
                emailEditMenuItem.Visible = false;
            }
            if (permission.Rows[0]["TRANSFERS_ACCESS"].ToString() == "False")
            {
                inveToolStripMenuItem.Visible = false;
            }
            /*
            string[] listPermissions = selectSQL.FillDatePermissions("IDPERMISSIONS = '" + selectSQL.GetIdPermissions(_idUser) + "'");

            try
            {
                //textBoxDescription.Text = listPermissions[1];
                buttonSentency.Enabled = bool.Parse(listPermissions[2]);
                listCompanyListMenuItem.Enabled = bool.Parse(listPermissions[2]);
                listUserListMenuItem.Enabled = bool.Parse(listPermissions[2]);
                //USER
                userEditMenuItem.Enabled = bool.Parse(listPermissions[2]);
                //dataPermissions.Rows[0].Cells[2].Value = bool.Parse(listPermissions[3]);
                addUserEditMenuItem.Enabled = bool.Parse(listPermissions[4]);
                updateUserEditMenuItem.Enabled = bool.Parse(listPermissions[5]);
                deleteUserEditMenuItem.Enabled = bool.Parse(listPermissions[6]);
                //PERMISSIONS
                permissionsEditMenuItem.Enabled = bool.Parse(listPermissions[2]);
                //dataPermissions.Rows[0].Cells[2].Value = bool.Parse(listPermissions[3]);
                addPermissionsEditMenuItem.Enabled = bool.Parse(listPermissions[4]);
                deletePermissionsEditMenuItem.Enabled = bool.Parse(listPermissions[5]);
                deletePermissionsEditMenuItem.Enabled = bool.Parse(listPermissions[6]);
                //CLIENTS
                clientsEditMenuItem.Enabled = bool.Parse(listPermissions[7]);
                //dataPermissions.Rows[1].Cells[2].Value = bool.Parse(listPermissions[8]);
                //clientsEditMenuItem.Enabled = bool.Parse(listPermissions[9]);

                //EMAILS
                emailEditMenuItem.Enabled = bool.Parse(listPermissions[7]);
                //dataPermissions.Rows[1].Cells[2].Value = bool.Parse(listPermissions[8]);
                addEmailEditMenuItem.Enabled = bool.Parse(listPermissions[9]);
                updateEmailEditMenuItem.Enabled = bool.Parse(listPermissions[10]);
                deleteEmailEditMenuItem.Enabled = bool.Parse(listPermissions[11]);
                //PRODUCTS
                buttonProducts.Enabled = bool.Parse(listPermissions[12]);
                /*dataPermissions.Rows[2].Cells[2].Value = bool.Parse(listPermissions[13]);
                dataPermissions.Rows[2].Cells[3].Value = bool.Parse(listPermissions[14]);
                dataPermissions.Rows[2].Cells[4].Value = bool.Parse(listPermissions[15]);
                dataPermissions.Rows[2].Cells[5].Value = bool.Parse(listPermissions[16]);
                //INVOICE
                dataPermissions.Rows[3].Cells[1].Value = bool.Parse(listPermissions[17]);
                dataPermissions.Rows[3].Cells[2].Value = bool.Parse(listPermissions[18]);
                dataPermissions.Rows[3].Cells[3].Value = bool.Parse(listPermissions[19]);
                dataPermissions.Rows[3].Cells[4].Value = bool.Parse(listPermissions[20]);
                dataPermissions.Rows[3].Cells[5].Value = bool.Parse(listPermissions[21]);
                //REMI
                dataPermissions.Rows[4].Cells[1].Value = bool.Parse(listPermissions[22]);
                dataPermissions.Rows[4].Cells[2].Value = bool.Parse(listPermissions[23]);
                dataPermissions.Rows[4].Cells[3].Value = bool.Parse(listPermissions[24]);
                dataPermissions.Rows[4].Cells[4].Value = bool.Parse(listPermissions[25]);
                dataPermissions.Rows[4].Cells[5].Value = bool.Parse(listPermissions[26]);
                //TRANFER
                dataPermissions.Rows[5].Cells[1].Value = bool.Parse(listPermissions[27]);
                dataPermissions.Rows[5].Cells[2].Value = bool.Parse(listPermissions[28]);
                dataPermissions.Rows[5].Cells[3].Value = bool.Parse(listPermissions[29]);
                dataPermissions.Rows[5].Cells[4].Value = bool.Parse(listPermissions[30]);
                dataPermissions.Rows[5].Cells[5].Value = bool.Parse(listPermissions[31]);
                //INVENTARY
                PictureInvetary(bool.Parse(listPermissions[32]));
                //BINACLE
                buttonBinnacle.Enabled = bool.Parse(listPermissions[33]);
                //dataPermissions.Rows[6].Cells[2].Value = bool.Parse(listPermissions[34]);
                //dataPermissions.Rows[6].Cells[3].Value = bool.Parse(listPermissions[35]);
                //dataPermissions.Rows[6].Cells[4].Value = bool.Parse(listPermissions[36]);
                //dataPermissions.Rows[6].Cells[5].Value = bool.Parse(listPermissions[37]);
                //CANAUTORIZE
                //PictureCanAutorize(bool.Parse(listPermissions[38]));

            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Error : " + ex.Message);
            }
                */
        }

        //
        private void AddForm<T>() where T : Form, new()
        {
            T form = new T();
            form.ShowDialog();
        }

        private void AddControlInPanel<T>() where T : Form, new()
        {
            var form = Application.OpenForms.OfType<T>().FirstOrDefault();

            // Si el formulario ya está abierto, lo trae al frente
            if (form != null)
            {
                form.BringToFront();
            }
            else
            {
                // Si el formulario no está abierto, crea una nueva instancia y agrégalo al panel
                form = new T();
                AddFormInPanel(form);
            }
        }

        private void AddControlInPanel<T>(int _CLIENT) where T : Form, new()
        {
            var form = Application.OpenForms.OfType<T>().FirstOrDefault();
            T son = form ?? new T();
            AddFormInPanel(son);
        }

        private void ProcessForm<T>(T form, bool isUpdate) where T : Form, new()
        {
            if (isUpdate)
            {
                if (form is FormUser formUserForm)
                    formUserForm.Modify(isUpdate, _idUser);
                else if (form is FormClient formClientForm)
                    formClientForm.Modify(isUpdate, _idUser);

                else if (form is FormEmails formFormEmails)
                    formFormEmails.Modify(isUpdate, _idUser);
                else if (form is FormProducts formFormProducts)
                    formFormProducts.Modify(isUpdate, _idUser, _idClient);
                //else if (form is FormWarehouse formFormWarehouse)
                //formFormWarehouse.Modify(isUpdate, _idUser);
                // Agregar más casos según sea necesario
            }

            AddFormInPanel(form);
        }

        private void AddFormUpdate<T>(bool isUpdate) where T : Form, new()
        {
            ProcessForm(new T(), isUpdate);
        }

        private void AddControlInPanelUpdate<T>(bool isUpdate) where T : Form, new()
        {
            var form = Application.OpenForms.OfType<T>().FirstOrDefault() ?? new T();
            ProcessForm(form, isUpdate);
        }

        private void ProcessDeleteForm<T>(T form, bool isUpdate) where T : Form, new()
        {
            if (isUpdate)
            {
                if (form is FormUser formUserForm)
                    formUserForm.Delete(_idUser);
                else if (form is FormClient formClientForm)
                    formClientForm.Delete(_idUser);

                else if (form is FormEmails formFormEmails)
                    formFormEmails.Delete(_idUser);
                //else if (form is FormWarehouse formFormWarehouse)
                //formFormWarehouse.Delete(_idUser, _idClient);
                // Agregar más casos según sea necesario
            }

            AddFormInPanel(form);
        }

        private void AddFormDelete<T>(bool isUpdate) where T : Form, new()
        {
            ProcessDeleteForm(new T(), isUpdate);
        }

        private void AddControlInPanelDelete<T>(bool isUpdate) where T : Form, new()
        {
            var form = Application.OpenForms.OfType<T>().FirstOrDefault() ?? new T();
            ProcessDeleteForm(form, isUpdate);
        }

        public void AddFormInPanel(Form fh)
        {
            int last = 0;
            fh.TopLevel = false;
            fh.FormBorderStyle = FormBorderStyle.Fixed3D;
            panelContainer.Controls.Add(fh);
            panelContainer.Tag = fh;
            last = panelContainer.Controls.Count - 1;
            panelContainer.Controls[last].BringToFront();
            panelContainer.Width = this.ClientSize.Width;
            panelContainer.Height = this.ClientSize.Height - 85;
            if (fh is Input formInput)
                formInput.Inicialize(this, _idUser, _idClient);
            if (fh is FormInventory formFormInventory)
                formFormInventory.Inicialize(_idUser, _idClient);
            else if (fh is Output formOutput)
                formOutput.Inicialize(_idUser, _idClient);
            fh.Show();
        }

        // 
        private void FormLogin(bool sampleCompany)
        {
            _notExit = true;

            FormLogin login = new FormLogin();
            if (sampleCompany)
            {
                login.fillCompany(_idUser);
            }
            login.Show();
            Close();
            _notExit = false;
        }
        #endregion

        #region Timers and FormClosing
        private void Timer1_Tick(object sender, EventArgs e)//
        {
            var RedActiva = System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();

            if (RedActiva)
            {
                statusToolStripStatusLabel.Text = "Conexión: SI";
                withoutInternetToolStripStatusLabel.Visible = false;
                withInternetToolStripStatusLabel.Visible = true;
            }
            else
            {
                statusToolStripStatusLabel.Text = "Conexión: NO";
                withoutInternetToolStripStatusLabel.Visible = true;
                withInternetToolStripStatusLabel.Visible = false;
            }


        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_notExit)
                Application.Exit();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            this.MaximumSize = SystemInformation.PrimaryMonitorMaximizedWindowSize;
            this.WindowState = FormWindowState.Maximized;
            panelContainer.Width = this.ClientSize.Width;
            panelContainer.Height = this.ClientSize.Height - 85;
            panelButtons.Width = this.ClientSize.Width;
            FormPermissions();
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!_notExit)
                Application.Exit();
        }

        private bool fullComboBoxProduct()
        {
            ComboBox comboBoxProduct = new ComboBox();
            selectSQL.ProductsAComboBox(comboBoxProduct, _idClient);
            
            if (comboBoxProduct.Items.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool fullComboBoxProviders()
        {
            ComboBox comboBoxProviders = new ComboBox();
            selectSQL.ProvidersAComboBox(comboBoxProviders, _idClient);

            if (comboBoxProviders.Items.Count > 0)
            {
                
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool fullComboBoxWarehouse()
        {
            ComboBox comboBoxLocation = new ComboBox();


            selectSQL.WarehouseAComboBox(comboBoxLocation);
            // Verificar si se encontró el elemento
            if (comboBoxLocation.Items.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private bool fullcomboBox()
        {
            ComboBox comboBoxBill = new ComboBox();
            selectSQL.DestinatiosAComboBox(comboBoxBill, _idClient);

            if (comboBoxBill.Items.Count != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        public void toolStripButton3_Click(object sender, EventArgs e)
        {
            /*if (!_floatingWindow)
                AddControlInPanel<WorkOrder>();
            else
                AddForm<WorkOrder>();*/
        }

        private void commandEditMenuItem_Click(object sender, EventArgs e)
        {
            if (!floatingWindow)
                AddControlInPanel<WorkOrder>();
            else
                AddForm<WorkOrder>();
        }

        private void transferenciasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Application.OpenForms.OfType<InventaryTransfer>().FirstOrDefault();
            if (form == null)
            {
                InventaryTransfer mInvForm = new InventaryTransfer(this);
                AddFormInPanel(mInvForm);
            }


        }

        private void transferenciasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var form = Application.OpenForms.OfType<InventaryTransfer>().FirstOrDefault();
            if (form == null)
            {
                InventaryTransfer mInvForm = new InventaryTransfer(this);
                AddFormInPanel(mInvForm);
            }
        }

        private void btnStoreProducts_Click(object sender, EventArgs e)
        {
            var form = Application.OpenForms.OfType<LocateProducts>().FirstOrDefault();
            if (form == null)
            {
                LocateProducts locateForm = new LocateProducts(this);
                AddFormInPanel(locateForm);
            }
            else
            {
                form.BringToFront();
            }
        }

        private void buttonInventory_Click(object sender, EventArgs e)
        {
            if (!floatingWindow)
                AddControlInPanel<FormInventory>();
            else
                AddForm<FormInventory>();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void asignarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormClientsWarehouses form = new FormClientsWarehouses(this);
            form.ShowDialog();
        }
    }
}
