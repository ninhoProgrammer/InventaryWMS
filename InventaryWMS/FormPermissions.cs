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

namespace InventaryWMS
{
    public partial class FormPermissions : Form
    {
        #region Variables and triggers
        SelectSQL selectSQL = new SelectSQL();
        InsertSQL insertSQL = new InsertSQL();
        UpdateSQL updateSQL = new UpdateSQL();
        private Permisions _role { get; set; }
        private bool _CanAutorize { get; set; }
        private bool _inventary { get; set; }
        private bool _new { get; set; }
        private bool _save { get; set; }


        public FormPermissions()
        {
            InitializeComponent();
            inicialize();
        }

        private void inicialize()
        {
            comboBoxPermissions.Items.Clear();
            selectSQL.PermissionsAComboBox(comboBoxPermissions);
            _role = new Permisions();
            _save = false;
            _new = false;
            VisibleForm(_save);
            pictureBoxEdit.Visible = _save;
            inicializeDataGrid();
            this.Text = "Añade Permisos";

        }

        public void Modify()
        {
            
            this.Text = "Modifiaca Permisos";
        

        }


       
        public void Delete()
        {
            
        }

        private void FormPermissions_Load(object sender, EventArgs e)
        {


        }
        #endregion

        #region Functions
       

        public void inicializeDataGrid()
        {
            AddPersissionsDataGrid();
            FillDataGrid();
            BloquedDataGrid();
        }
        public void FillDataGrid()
        {
            dataPermissions.AllowUserToAddRows = false;
            dataPermissions.RowHeadersVisible = false;
            dataPermissions.AutoResizeColumns();
            dataPermissions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            
            //dataPermissions.Columns.Clear();
            //dataPermissions.DataSource = selectSQL.ShowDataBinnacle();
        }

        public void AddPersissionsDataGrid()
        {
            dataPermissions.Rows.Add("Usuarios", false, false, false, false, false);
            dataPermissions.Rows.Add("Clientes", false, false, false, false, false);
            dataPermissions.Rows.Add("Productos", false, false, false, false, false);
            dataPermissions.Rows.Add("Facturas", false, false, false, false, false);
            dataPermissions.Rows.Add("Remisiones", false, false, false, false, false);
            dataPermissions.Rows.Add("Trasnferencia", false, false, false, false, false);
            dataPermissions.Rows.Add("Bitacora", false, false, false, false, false);
        }

        public void BloquedDataGrid()
        {
            dataPermissions.Columns[2].ReadOnly = true;
            dataPermissions.Columns[3].ReadOnly = true;
            dataPermissions.Columns[4].ReadOnly = true;
            dataPermissions.Columns[5].ReadOnly = true;
        }

        public void PictureCanAutorize(bool can)
        {
            pictureBoxNotCanAutorize.Visible = can;
            pictureBoxCanAutorize.Visible = !can;
            _CanAutorize = can;

        }

        public void PictureInvetary(bool inv)
        {
            pictureBoxNotInventary.Visible = inv;
            pictureBoxInventary.Visible = !inv;
            _inventary = inv;

        }

        public void InsertSentency()
        {
            
            Task.Run(() =>
            {

                this.Invoke((Action)(() =>
                {

                    if (insertSQL.saveToPermisions(_role))
                    {
                        insertSQL.SaveToBinnacle("Permiso dado de alta: " + textBoxPermissions.Text);
                        MessageBox.Show("Permiso dado de alta con exito");
                        _new = false;
                        fetchPermisions();
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

                    if (updateSQL.UpdatePermisions(_role))
                    {
                        insertSQL.SaveToBinnacle("Permiso: " + textBoxPermissions.Text + ", modificado con exito");
                        MessageBox.Show("Permiso modificado con exito");
                        _save = false;
                        fetchPermisions();
                    }
                    else
                    {
                        spinner.Visible = false;
                        _save = true;
                        buttonSave.Enabled = true;
                    }
                }));
            });

            
        }

        private void fetchPermisions()
        {
            comboBoxPermissions.Items.Clear();
            selectSQL.PermissionsAComboBox(comboBoxPermissions);
            spinner.Visible = false;
            buttonSave.Enabled = true;
            VisibleForm(false);
        }

        private void VisibleForm(bool panel)
        {
            if (panel == false)
                comboBoxPermissions.Text = _role.NAME;

            textBoxPermissions.Enabled = panel;
            textBoxDescription.Enabled = panel;
            dataPermissions.Enabled = panel;
            panelCanAutorize.Enabled = panel;
            panelInventary.Enabled = panel;
            pictureBoxCancel.Visible = panel;
            buttonSave.Visible = panel;
            pictureBoxEdit.Visible = !panel;
            buttonSerch.Enabled = !panel;
            comboBoxPermissions.Enabled = !panel;
            
        }

        private void fullPermisions()
        {
            textBoxPermissions.Text = _role.NAME;
            textBoxDescription.Text = _role.DESCRIPTION;

            // USER
            dataPermissions.Rows[0].Cells[1].Value = _role.USERS_ACCESS;
            dataPermissions.Rows[0].Cells[2].Value = _role.USERS_CONSULT;
            dataPermissions.Rows[0].Cells[3].Value = _role.USERS_CREATE;
            dataPermissions.Rows[0].Cells[4].Value = _role.USERS_EDIT;
            dataPermissions.Rows[0].Cells[5].Value = _role.USERS_DELETE;

            // CLIENTS
            dataPermissions.Rows[1].Cells[1].Value = _role.CLIENTS_ACCESS;
            dataPermissions.Rows[1].Cells[2].Value = _role.CLIENTS_CONSULT;
            dataPermissions.Rows[1].Cells[3].Value = _role.CLIENTS_CREATE;
            dataPermissions.Rows[1].Cells[4].Value = _role.CLIENTS_EDIT;
            dataPermissions.Rows[1].Cells[5].Value = _role.CLIENTS_DELETE;

            // PRODUCTS
            dataPermissions.Rows[2].Cells[1].Value = _role.PRODUCTS_ACCESS;
            dataPermissions.Rows[2].Cells[2].Value = _role.PRODUCTS_CONSULT;
            dataPermissions.Rows[2].Cells[3].Value = _role.PRODUCTS_CREATE;
            dataPermissions.Rows[2].Cells[4].Value = _role.PRODUCTS_EDIT;
            dataPermissions.Rows[2].Cells[5].Value = _role.PRODUCTS_DELETE;

            // INVOICE
            dataPermissions.Rows[3].Cells[1].Value = _role.INVOICES_ACCESS;
            dataPermissions.Rows[3].Cells[2].Value = _role.INVOICES_CONSULT;
            dataPermissions.Rows[3].Cells[3].Value = _role.INVOICES_CREATE;
            dataPermissions.Rows[3].Cells[4].Value = _role.INVOICES_EDIT;
            dataPermissions.Rows[3].Cells[5].Value = _role.INVOICES_DELETE;

            // REMI
            dataPermissions.Rows[4].Cells[1].Value = _role.REMISSIONS_ACCESS;
            dataPermissions.Rows[4].Cells[2].Value = _role.REMISSIONS_CONSULT;
            dataPermissions.Rows[4].Cells[3].Value = _role.REMISSIONS_CREATE;
            dataPermissions.Rows[4].Cells[4].Value = _role.REMISSIONS_EDIT;
            dataPermissions.Rows[4].Cells[5].Value = _role.REMISSIONS_DELETE;

            // TRANSFER
            dataPermissions.Rows[5].Cells[1].Value = _role.TRANSFERS_ACCESS;
            dataPermissions.Rows[5].Cells[2].Value = _role.TRANSFERS_CONSULT;
            dataPermissions.Rows[5].Cells[3].Value = _role.TRANSFERS_CREATE;
            dataPermissions.Rows[5].Cells[4].Value = _role.TRANSFERS_EDIT;
            dataPermissions.Rows[5].Cells[5].Value = _role.TRANSFERS_DELETE;

            // INVENTORY
            PictureInvetary(_role.INVENTORY_ACCESS);

            // BINACLE
            dataPermissions.Rows[6].Cells[1].Value = _role.LOG_ACCESS;
            dataPermissions.Rows[6].Cells[2].Value = _role.LOG_CONSULT;
            // dataPermissions.Rows[6].Cells[3].Value = _role.LOG_CREATE; // Uncomment if needed
            dataPermissions.Rows[6].Cells[4].Value = _role.LOG_EDIT;
            dataPermissions.Rows[6].Cells[5].Value = _role.LOG_DELETE;

            // CANAUTORIZE
            PictureCanAutorize(_role.CAN_AUTORISE);
        }

        private void fillProducts()
        {
            _role.IDPERMISSIONS = selectSQL.GetIdPermissions(comboBoxPermissions.Text);
            _role.NAME = textBoxPermissions.Text;
            _role.DESCRIPTION = textBoxDescription.Text;

            // USER
            _role.USERS_ACCESS = Convert.ToBoolean(dataPermissions.Rows[0].Cells[1].Value);
            _role.USERS_CONSULT = Convert.ToBoolean(dataPermissions.Rows[0].Cells[2].Value);
            _role.USERS_CREATE = Convert.ToBoolean(dataPermissions.Rows[0].Cells[3].Value);
            _role.USERS_EDIT = Convert.ToBoolean(dataPermissions.Rows[0].Cells[4].Value);
            _role.USERS_DELETE = Convert.ToBoolean(dataPermissions.Rows[0].Cells[5].Value);

            // CLIENTS
            _role.CLIENTS_ACCESS = Convert.ToBoolean(dataPermissions.Rows[1].Cells[1].Value);
            _role.CLIENTS_CONSULT = Convert.ToBoolean(dataPermissions.Rows[1].Cells[2].Value);
            _role.CLIENTS_CREATE = Convert.ToBoolean(dataPermissions.Rows[1].Cells[3].Value);
            _role.CLIENTS_EDIT = Convert.ToBoolean(dataPermissions.Rows[1].Cells[4].Value);
            _role.CLIENTS_DELETE = Convert.ToBoolean(dataPermissions.Rows[1].Cells[5].Value);

            // PRODUCTS
            _role.PRODUCTS_ACCESS = Convert.ToBoolean(dataPermissions.Rows[2].Cells[1].Value);
            _role.PRODUCTS_CONSULT = Convert.ToBoolean(dataPermissions.Rows[2].Cells[2].Value);
            _role.PRODUCTS_CREATE = Convert.ToBoolean(dataPermissions.Rows[2].Cells[3].Value);
            _role.PRODUCTS_EDIT = Convert.ToBoolean(dataPermissions.Rows[2].Cells[4].Value);
            _role.PRODUCTS_DELETE = Convert.ToBoolean(dataPermissions.Rows[2].Cells[5].Value);

            // INVOICE
            _role.INVOICES_ACCESS = Convert.ToBoolean(dataPermissions.Rows[3].Cells[1].Value);
            _role.INVOICES_CONSULT = Convert.ToBoolean(dataPermissions.Rows[3].Cells[2].Value);
            _role.INVOICES_CREATE = Convert.ToBoolean(dataPermissions.Rows[3].Cells[3].Value);
            _role.INVOICES_EDIT = Convert.ToBoolean(dataPermissions.Rows[3].Cells[4].Value);
            _role.INVOICES_DELETE = Convert.ToBoolean(dataPermissions.Rows[3].Cells[5].Value);

            // REMI
            _role.REMISSIONS_ACCESS = Convert.ToBoolean(dataPermissions.Rows[4].Cells[1].Value);
            _role.REMISSIONS_CONSULT = Convert.ToBoolean(dataPermissions.Rows[4].Cells[2].Value);
            _role.REMISSIONS_CREATE = Convert.ToBoolean(dataPermissions.Rows[4].Cells[3].Value);
            _role.REMISSIONS_EDIT = Convert.ToBoolean(dataPermissions.Rows[4].Cells[4].Value);
            _role.REMISSIONS_DELETE = Convert.ToBoolean(dataPermissions.Rows[4].Cells[5].Value);

            // TRANSFER
            _role.TRANSFERS_ACCESS = Convert.ToBoolean(dataPermissions.Rows[5].Cells[1].Value);
            _role.TRANSFERS_CONSULT = Convert.ToBoolean(dataPermissions.Rows[5].Cells[2].Value);
            _role.TRANSFERS_CREATE = Convert.ToBoolean(dataPermissions.Rows[5].Cells[3].Value);
            _role.TRANSFERS_EDIT = Convert.ToBoolean(dataPermissions.Rows[5].Cells[4].Value);
            _role.TRANSFERS_DELETE = Convert.ToBoolean(dataPermissions.Rows[5].Cells[5].Value);

            // INVENTORY
            _role.INVENTORY_ACCESS = _inventary;

            // BINACLE
            _role.LOG_ACCESS = Convert.ToBoolean(dataPermissions.Rows[6].Cells[1].Value);
            _role.LOG_CONSULT = Convert.ToBoolean(dataPermissions.Rows[6].Cells[2].Value);
            // _role.LOG_CREATE = Convert.ToBoolean(dataPermissions.Rows[6].Cells[3].Value); // Uncomment if needed
            _role.LOG_EDIT = Convert.ToBoolean(dataPermissions.Rows[6].Cells[4].Value);
            _role.LOG_DELETE = Convert.ToBoolean(dataPermissions.Rows[6].Cells[5].Value);

            // CANAUTORIZE
            _role.CAN_AUTORISE = _CanAutorize;
        }


        #endregion

        #region Click
        private void comboBoxPermissions_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxPermissions.Text != "")
                {
                    pictureBoxEdit.Visible = true;
                    _role = selectSQL.FillDatePermissions("NAME = '" + comboBoxPermissions.SelectedItem.ToString() + "'");
                }
                else
                {
                    pictureBoxEdit.Visible = false;
                }
                fullPermisions();

            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Error : " + ex.Message);
            }
        }

        private void dataPermissions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                bool accessBool = Convert.ToBoolean(dataPermissions.Rows[e.RowIndex].Cells[1].Value);
                dataPermissions.Rows[e.RowIndex].Cells[2].ReadOnly = accessBool;
                dataPermissions.Rows[e.RowIndex].Cells[3].ReadOnly = accessBool;
                dataPermissions.Rows[e.RowIndex].Cells[4].ReadOnly = accessBool;
                dataPermissions.Rows[e.RowIndex].Cells[5].ReadOnly = accessBool;
            }
        }


        private void PictureBoxNotCanAutorize_Click(object sender, EventArgs e)
        {
            PictureCanAutorize(false);
        }

        private void pictureBoxCanAutorize_Click(object sender, EventArgs e)
        {
            PictureCanAutorize(true);
        }

        private void PictureBoxInventary_Click(object sender, EventArgs e)
        {
            PictureInvetary(true);
        }

        private void PictureBoxNotInventary_Click(object sender, EventArgs e)
        {
            PictureInvetary(false);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            spinner.Visible = true;
            buttonSave.Enabled = false;
            try
            {
                fillProducts();
                if (_new)
                    InsertSentency();

                else if (_save)
                    UpdateSentency();
            }
            catch { }
            
        }

        private void buttonSerch_Click(object sender, EventArgs e)
        {
            _new = true;

            VisibleForm(_new);
            _role = new Permisions();
            fullPermisions();
        }

        private void PictureBoxEdit_Click(object sender, EventArgs e)
        {
            _save = true;
            VisibleForm(_save);
            textBoxPermissions.Focus();
        }

        private void PictureBoxCancel_Click(object sender, EventArgs e)
        {
            _save = false;
            _new = false;
            VisibleForm(false);
        }

        private void FormPermissions_Click(object sender, EventArgs e)
        {
            BringToFront();
        }


        #endregion
    }
}
