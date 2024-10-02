using Microsoft.Reporting.WinForms;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace InventaryWMS
{
    public partial class Output : Form
    {
        Main mainForm;
        SelectSQL selectSQL = new SelectSQL();
        InsertSQL insertSQL = new InsertSQL();
        UpdateSQL updateSQL = new UpdateSQL();
        DeleteSQL deleteSQL = new DeleteSQL();
        Security security = new Security();
        FormValidate formValidate { get; set; }
        WorkOrder form { get; set; }
        Configurations configurations { get; set; }
        private bool _saveFull { get; set; }
        List<string> eleme { get; set; }
        string[] reportDate { get; set; }
        static string reportPath { get; set; }
        private bool _order { get; set; }
        private bool _up { get; set; }
        private int _idClient { get; set; }
        private int _iduser { get; set; }
        private bool _fifo { get; set; }
        private int _orderedBox { get; set; }
        private int _quantity { get; set; }
        private int _picking { get; set; }
        private string where { get; set; }
        private string _prefix { get; set; }
        private DataTable aux { get; set; }
        private int _internalwarehouse { get; set; }
        private int _quantityBox { get; set; }

        public Output()
        {
            InitializeComponent();
            
        }

        public void Inicialize(int IDUSER, int IDCLIENT)
        {
            inicilizeForm(false);
            _iduser = IDUSER;
            _idClient = IDCLIENT;
            Inicialice();
            comboBoxBill.SelectedIndex = 0;
            comboBoxShip.SelectedIndex = 0;
            //Inicialice();
        }

        private void Inicialice()
        {
            try
            {
                //_idClient = int.Parse(security.createFile("address.txt"));
                selectSQL.ProductsInNumPartAComboBox(comboBoxPart, _idClient);
                comboBoxWare.SelectedIndex = 0;
                bacthCombo(true);
                selectSQL.SerialNoIdProductsNoBatchAComboBox(comboBoxSerial, _idClient, _internalwarehouse);
                configurations = new Configurations();
                Clients clients = selectSQL.FillDateClients(selectSQL.GetClients(_idClient));
                _picking = 0;
                dateTimePickerInitialDate.Value = DateTime.Now;
                eleme = new List<string>();
                _orderedBox = 0;
                buttonRemission.Enabled = false;
                buttonProforma.Enabled = false;
                buttonOrder.Enabled = false;
                forBoxOrQuantity(true);
                visibleFormOrder(true);
                visibleFifo(true);
                FillDataGrid();
                panel2.Enabled = false;
                buttonRemmisionCancel.Enabled = false;
                _order = true;
                _prefix = clients.PREFIX + textBoxF.Text;
                buttonAsentar.Enabled = false;
                _up = false;
                _saveFull = false;
                fillComboBox();
            }
            catch { }
        }

        private void fillComboBox()
        {

            if (!fullcomboBox())
            {
                DialogResult result = MessageBox.Show("¿Quieres dar de alta uno?", "Alerta no se encuentraron clientes de destino", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    FormDestinations form = new FormDestinations(mainForm);
                    form.ShowDialog();
                    fullcomboBox();
                }
            }


        }

        private bool fullcomboBox()
        {
            comboBoxBill.Items.Clear();
            comboBoxShip.Items.Clear();
            selectSQL.DestinatiosAComboBox(comboBoxBill, _idClient);
            selectSQL.DestinatiosAComboBox(comboBoxShip, _idClient);

            if (comboBoxBill.Items.Count != 0)
            {
               
                return true;
            }
            else
            {
                return false;
            }
        }

        public void FillDataGrid()
        {
            if (dataProducts.Rows.Count != 0)
            {
                dataProducts.DataSource = null;
            }
            dataProducts.AllowUserToAddRows = false;
            dataProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataProducts.RowHeadersVisible = false;
            dataProducts.ClearSelection();

        }

        private void buttonAsentar_Click(object sender, EventArgs e)
        {
            DialogResult resultCantidad = MessageBox.Show("Tienes " + textBoxCount.Text + " articulos. ¿Estas de acuerdo?", "Alerta verifica articulos", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (resultCantidad == DialogResult.Yes)
            {
                DialogResult result = MessageBox.Show("¿Es correcto el responsable y quien recibio?", "Alerta verificar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    spinner.Visible = true;
                    buttonAsentar.Enabled = false;
                    try
                    {
                        Task.Run(() =>
                        {                            
                            this.Invoke((Action)(() =>
                            {
                                workOrderInsertAsync();
                            }));
                        });

                    }
                    catch (Exception ex)
                    {
                        spinner.Visible = false;
                        buttonAsentar.Enabled = true;
                    }
                    insertSQL.SaveToBinnacle("Remision: " + _prefix + " creada con exito");

                }
            }
        }

        private void bacthCombo(bool product)
        {
            if (product)
                selectSQL.BatchAComboBox(comboBoxLote, _idClient.ToString(), _internalwarehouse);
            else
                selectSQL.BatchAComboBox(comboBoxLote, selectSQL.TakeIdProducts(comboBoxPart.Text), _internalwarehouse);

            List<object> uniqueElements = new List<object>();

            // Iteras sobre los elementos existentes en el ComboBox.
            foreach (object item in comboBoxLote.Items)
            {
                // Verificas si el elemento ya existe en la lista auxiliar.
                if (!uniqueElements.Contains(item))
                {
                    // Si no existe, lo agregas a la lista auxiliar y al ComboBox.
                    uniqueElements.Add(item);
                }
            }

            // Limpia el ComboBox.
            comboBoxLote.Items.Clear();

            // Agrega los elementos únicos de nuevo al ComboBox.
            comboBoxLote.Items.AddRange(uniqueElements.ToArray());
            selectSQL.SerialNoBatchAComboBox(comboBoxSerial, selectSQL.TakeIdProducts(comboBoxPart.Text), _internalwarehouse);
        }

        private async Task workOrderInsertAsync()
        {
            for (int i = 0; i < dataProducts.Rows.Count; i++)
            {
                //obtiene tupla de tabla INVENTORY correspondiente al idInvoiceItem
                Inventary inventary = selectSQL.FillDateInventory(int.Parse(dataProducts.Rows[i].Cells[1].Value.ToString()));

                //actualiza tabla INVOICE_ITEMS columnas(REMISION,PROFORMA,STATUS,VALID)
                //NOTA: prefix incluye prefijo y folio concatenados
                updateSQL.UpdateProformaAndRemission(_prefix, inventary.ID_INVOICE_ITEM, 0, false);

                //Actualiza tabla INVENTORY, columnas STATUS, VALID
                updateSQL.UpdateInventary(inventary.ID_INVOICE_ITEM, 0, false);
            }

            //Actualiza cantidades en inventario
            fillItemInvoice();

            //Actualiza REMISSION_HEADER
            updateSQL.UpdateRemision(_prefix, 1, true, DateTime.Parse(textBoxInitialDate.Text));
            validate(1);




        }

        private void remissionInsert(int sts, bool formValidate)
        {
            WorkOrderHeader wOrder = new WorkOrderHeader();
            wOrder.CLIENT_ID = _idClient;
            wOrder.ID_WORKORDER_HEADER = _prefix;
            wOrder.TYPE = 1;
            wOrder.PURCHASE_ORDER_CLIENT = selectSQL.TakeIdDestinations(comboBoxBill.Text);
            wOrder.CLIENT_DESTINATION = selectSQL.TakeIdDestinations(comboBoxShip.Text);
            wOrder.STATUS = sts;
            wOrder.SESSION_ID = 1;
            wOrder.CREATE_AT = DateTime.Now;
            wOrder.UPDATED_AT = DateTime.Now;
            wOrder.WORKORDER_AT = DateTime.Parse(textBoxInitialDate.Text);
            wOrder.VALID = formValidate;
            RemissionHeader remissionHeader = new RemissionHeader();
            remissionHeader.TRANSPORT_INFO_ID = selectSQL.TakeTransport(_idClient); ;
            remissionHeader.STATUS = sts;
            if (insertSQL.saveToOrder(wOrder, remissionHeader, filltableOrder(), filltableRemission(), int.Parse(textBoxF.Text)))
            {
                //validate(sts);
                updateSQL.Updateconfiguration(_idClient, int.Parse(textBoxF.Text));
                spinner.Visible = false;
                //buttonAsentar.Enabled = true;
                insertSQL.SaveToBinnacle("Remision: " + _prefix + " creada con exito");
            }
            else
            {
                spinner.Visible = false;
                buttonAsentar.Enabled = true;

                if (insertSQL.message == "El WORK_ORDER_ID ya existe en la WORK_ORDER_HEADER. No se realizaron inserciones.")
                {
                    DialogResult resultCantidad = MessageBox.Show("¿Quieres usar el siguiente folio?", "Alerta: Error insert not complete: FOLIO ocupado", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (resultCantidad == DialogResult.Yes)
                    {
                        updateSQL.Updateconfiguration(_idClient, int.Parse(textBoxF.Text));
                        Clients clients = selectSQL.FillDateClients(selectSQL.GetClients(_idClient));
                        configurations = selectSQL.TakeOutpotInvoice(_idClient);
                        textBoxF.Text = configurations.OUTPUT.ToString("D4");
                        _prefix = clients.PREFIX + textBoxF.Text;
                    }
                }
            }

        }

        private void Output_Click(object sender, EventArgs e)
        {
            // Aqui refresh combo box 
            comboBoxBill.Items.Clear();

            selectSQL.DestinatiosAComboBox(comboBoxBill, _idClient);
            comboBoxShip.Items.Clear();

            selectSQL.DestinatiosAComboBox(comboBoxShip, _idClient);
            BringToFront();
        }

        private void Fifo()
        {
            if (comboBoxPart.Text != "" || comboBoxLote.Text != "" || comboBoxSerial.Text != "")
            {
                createWhere();
                DataTable dataT = selectSQL.SearchInOrder(_idClient, where);

                Task.Run(() =>
                {
                    this.Invoke((Action)(() =>
                    {
                        DataTable dataTable = new DataTable();
                        if (_order)
                        {
                            if (textBoxBox.Text != "")
                            {
                                int AmountObtained = dataT.Rows.Count;
                                int OrderedQuantity = int.Parse(textBoxBox.Text);
                                if (OrderedQuantity <= AmountObtained)
                                {
                                    FifoBox(dataT);
                                    if (dataProducts.Rows.Count > 0)
                                    {
                                        buttonValid.Enabled = true;
                                        buttonOrder.Enabled = true;
                                        dataProducts.Columns[0].Visible = false;
                                        dataProducts.Columns[1].Visible = false;
                                        dataProducts.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                                        panel2.Enabled = true;
                                        comboBoxPart.Text = "";
                                        comboBoxLote.Text = "";
                                        comboBoxSerial.Text = "";
                                        dataProducts.ClearSelection();
                                    }
                                }
                                else
                                    MessageBox.Show("No cuenta con el suficiente material para este embarque solo tienes : " + AmountObtained + " artículos");
                            }
                            else
                                MessageBox.Show("Seleccione cuántas cajas quiere agregar");
                        }
                        else
                        {
                            if (textBoxQuantity.Text != "")
                            {
                                FifoQuantity(dataT);
                                int AmountObtained = dataT.Rows.Count;
                                int OrderedQuantity = int.Parse(textBoxQuantity.Text);
                                if (OrderedQuantity <= AmountObtained)
                                {
                                    if (dataProducts.Rows.Count < 0)
                                    {
                                        dataProducts.Columns[0].Visible = false;
                                        dataProducts.Columns[1].Visible = false;
                                        panel2.Enabled = true;
                                        comboBoxSerial.SelectedIndex = -1;
                                        comboBoxPart.SelectedIndex = -1;
                                        comboBoxLote.SelectedIndex = -1;
                                    }
                                }
                                else
                                    MessageBox.Show("No cuenta con el suficiente material para este embarque solo tienes : " + AmountObtained + " articulos");
                            }
                            else
                                MessageBox.Show("Seleccione la cantidad que quiere agregar");
                        }

                    }));
                });
            }

            else
            {
                MessageBox.Show("Error : Seleccione que producto agregar");
            }

        }

        private DataTable filltableOrder()
        {
            DataTable tableB = new DataTable();

            try
            {
                tableB.Columns.Add("INVENTORY_ID", typeof(int));
                tableB.Columns.Add("IDINVOICE_ITEMS", typeof(int));
                tableB.Columns.Add("QUANTITY_REQUESTED", typeof(int));
                tableB.Columns.Add("STATUS", typeof(string));
                tableB.Columns.Add("CREATE_AT", typeof(DateTime));
                tableB.Columns.Add("SESSION_ID", typeof(int));
                tableB.Columns.Add("VALID", typeof(bool));

                // Agregar filas a la DataTable
                for (int i = 0; i < dataProducts.Rows.Count; i++)
                {
                    Inventary inventary = selectSQL.FillDateInventory(int.Parse(dataProducts.Rows[i].Cells[0].Value.ToString()));
                    tableB.Rows.Add(inventary.IDINVENTORY, inventary.ID_INVOICE_ITEM, inventary.QUANTITY, 1, DateTime.Now, 1, true);
                }

                return tableB;
            }
            catch
            {
                return tableB;
            }
        }

        private DataTable filltableRemission()
        {
            DataTable remisionItemsTable = new DataTable();
            try
            {
                remisionItemsTable.Columns.Add("INVENTORY_ITEM_ID", typeof(int));
                remisionItemsTable.Columns.Add("QUANTITY", typeof(int));
                remisionItemsTable.Columns.Add("PICKING", typeof(int));
                remisionItemsTable.Columns.Add("REMAINING_QUANTITY", typeof(int));
                remisionItemsTable.Columns.Add("LOCATION", typeof(string));
                remisionItemsTable.Columns.Add("STATUS", typeof(string));
                remisionItemsTable.Columns.Add("VALID", typeof(bool));


                // Agregar filas a la DataTable
                for (int i = 0; i < dataProducts.Rows.Count; i++)
                {
                    Inventary inventary = selectSQL.FillDateInventory(int.Parse(dataProducts.Rows[i].Cells[0].Value.ToString()));
                    remisionItemsTable.Rows.Add(inventary.IDINVENTORY, inventary.QUANTITY, _picking, inventary.QUANTITY - _picking, DateTime.Now, 1, true);
                }

                return remisionItemsTable;
            }
            catch
            {
                return remisionItemsTable;
            }
        }

        private bool fillItemInvoice()
        {
            try
            {
                for (int i = 0; i < dataProducts.Rows.Count; i++)
                {                    
                    Inventary inventary = selectSQL.FillDateInventory(int.Parse(dataProducts.Rows[i].Cells[1].Value.ToString()));


                    /*string remissionId = _prefix;
                    int inventoryItemId = inventary.ID_INVOICE_ITEM;
                    float quantity = inventary.ID_INVOICE_ITEM;//Error !!!!!!!!!!!
                    float remainingQuantity = inventary.QUANTITY - _picking;
                    string location = inventary.IDWAREHOUSE_RACK_POSITIONS;
                    int status = 1;
                    DateTime createAt = DateTime.Now;
                    int sessionId = 3;
                    bool valid = true;*/

                    //Guarda la remision en [REMISSION_ITEMS]
                    //Esta tupla contiene cantidad original(QUANTITY), cantidad restante(REMAINING_QUANTITY)
                    insertSQL.saveToRemmsionItems(_prefix, inventary.IDINVENTORY, inventary.QUANTITY, _picking, inventary.QUANTITY - _picking, inventary.IDWAREHOUSE_RACK_POSITIONS, 1, DateTime.Now, _iduser, inventary.VALID);
                    WorkOrderInventoryItem workOrderInventoryItem = new WorkOrderInventoryItem
                    {
                        WORK_ORDER_ID = _prefix,
                        INVENTORY_ID = inventary.IDINVENTORY,
                        QUANTITY_REQUESTED = inventary.QUANTITY - _picking,//Es correcto??
                        STATUS = 1,
                        CREATE_AT = DateTime.Now,
                        SESSION_ID = 3,
                        VALID = true
                    };
                    //Guarda la orden de salida (WORK_ORDER_INVENTORY_ITEM)
                    //C
                    insertSQL.InsertarWorkOrderInventoryItem(workOrderInventoryItem);
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
        private void createWhere()
        {
            where = "";
            if (comboBoxPart.Text != "")
            {
                char[] separador = { '|' };
                string[] subcadenas = comboBoxPart.Text.Split(separador, StringSplitOptions.RemoveEmptyEntries);
                where = "AND PRODUCTS.PART_NUMBER_PROVIDER = '" + subcadenas[1] + "' ";
            }
            if (comboBoxLote.Text != "")
            {
                where = where + "AND BATCH = '" + comboBoxLote.Text + "' ";
            }
            if (comboBoxSerial.Text != "")
            {
                where = where + "AND SERIAL = '" + comboBoxSerial.Text + "' ";
            }
        }

        private void panelCanAutorize_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FifoBox(DataTable dataT)
        {
            List<string> chain = new List<string>();
            _orderedBox = 0;
            _quantity = int.Parse(textBoxBox.Text);
            foreach (DataRow row in dataT.Rows)
            {
                if (_orderedBox < _quantity)
                {
                    _orderedBox = _orderedBox + int.Parse(row[5].ToString());
                    chain.Add(row[0].ToString());
                    Console.WriteLine(row[0].ToString());
                }
                else
                {
                    break;
                    //dataTable.Rows.Remove(row);
                }
            }
            AddFifo(chain);
        }

        private void FifoQuantity(DataTable dataT)
        {
            List<string> chain = new List<string>();
            _orderedBox = 0;
            _quantity = int.Parse(textBoxQuantity.Text);
            foreach (DataRow row in dataT.Rows)
            {
                if (_orderedBox <= _quantity)
                {
                    _orderedBox = _orderedBox + int.Parse(row[6].ToString());
                    chain.Add(row[0].ToString());
                    Console.WriteLine(row[0].ToString());
                }
                else
                {
                    break;
                    //dataTable.Rows.Remove(row);
                }
            }
            AddFifo(chain);
        }

        public void AddFifo(List<string> chain)
        {
            DataTable dataTable = new DataTable();
            DataTable dataTableNew = new DataTable();
            string result = string.Join(", ", chain);
            if (dataProducts.Rows.Count == 0)
            {
                if (chain.Count < 1)
                    dataProducts.DataSource = selectSQL.SearchInOrder(result, _idClient, true, where);
                else
                    dataProducts.DataSource = selectSQL.SearchInOrder(result, _idClient, false, where);
            }
            else
            {
                if (chain.Count < 1)
                    dataTableNew = selectSQL.SearchInOrder(result, _idClient, true, where);
                else
                    dataTableNew = selectSQL.SearchInOrder(result, _idClient, false, where);

                foreach (DataGridViewColumn col in dataProducts.Columns)
                {
                    dataTable.Columns.Add(col.Name, col.ValueType);
                }

                foreach (DataGridViewRow row in dataProducts.Rows)
                {
                    DataRow newRow = dataTable.NewRow();

                    foreach (DataGridViewColumn col in dataProducts.Columns)
                    {

                        newRow[col.Name] = row.Cells[col.Name].Value;
                    }

                    dataTable.Rows.Add(newRow);
                }
                foreach (DataRow row in dataTableNew.Rows)
                {
                    // Verificas si la DataTable original ya contiene una fila con los mismos valores en las columnas específicas.
                    if (!ContieneFila(dataTable, row))
                    {
                        DataRow newRow = dataTable.NewRow();
                        newRow.ItemArray = row.ItemArray; // Copia los datos de la fila

                        dataTable.Rows.Add(newRow);
                    }
                }

                dataProducts.DataSource = null;
                FillDataGrid();
                dataProducts.DataSource = dataTable;
                aux = dataTable.Copy();

                for (int i = 0; i < dataProducts.Rows.Count; i++)
                {
                    Inventary inventary = selectSQL.FillDateInventory(int.Parse(dataProducts.Rows[i].Cells[1].Value.ToString()));

                    updateSQL.UpdateProformaAndRemission(_prefix, inventary.ID_INVOICE_ITEM, 2, false);
                    updateSQL.UpdateInventary(inventary.ID_INVOICE_ITEM, 2, false);
                }

                for (int i = 0; i < dataProducts.Rows.Count; i++)
                {
                    Inventary inventary = selectSQL.FillDateInventory(int.Parse(dataProducts.Rows[i].Cells[1].Value.ToString()));

                    updateSQL.UpdateProformaAndRemission(_prefix, inventary.ID_INVOICE_ITEM, 2, false);
                    updateSQL.UpdateInventary(inventary.ID_INVOICE_ITEM, 2, false);
                }

            }
            textBoxCount.Text = dataProducts.Rows.Count.ToString();
            addQuetityBox();
            dataProducts.ClearSelection();
        }


        // Método para verificar si una DataTable contiene una fila con los mismos valores en columnas específicas.
        private static bool ContieneFila(DataTable dataTable, DataRow rowToCheck)
        {
            foreach (DataRow existingRow in dataTable.Rows)
            {
                if (DataRowEqual(existingRow, rowToCheck))
                {
                    return true;
                }
            }
            return false;
        }

        // Método para comparar dos filas en columnas específicas y verificar si son iguales.
        private static bool DataRowEqual(DataRow row1, DataRow row2)
        {
            return object.Equals(row1[1], row2[1]);
        }

        private void pictureBoxOrder_Click(object sender, EventArgs e)
        {
            visibleFormOrder(false);
            form = new WorkOrder();
            form.VisibleForm(true);
            form.Show();
        }

        private void pictureBoxDelele_Click(object sender, EventArgs e)
        {
            form.Close();
            visibleFormOrder(true);
        }

        private void pictureBoxSaveOrder_Click(object sender, EventArgs e)
        {
            form.buttonSave_Click(sender, e);
            visibleFormOrder(true);
            insertSQL.SaveToBinnacle("Orden: " + form.labelOrder.Text + ", agregada con exito");

        }

        private void visibleFormOrder(bool panel)
        {
            if (panel)
            {
                for (int i = 0; i < dataProducts.Rows.Count; i++)
                {
                    dataProducts.Rows[i].Selected = true;
                    dataProducts.Rows[i].DefaultCellStyle.ForeColor = SystemColors.GrayText;

                }
            }
            pictureBoxDelete.Visible = panel;
            textBoxCount.Visible = panel;
            textBoxAmount.Visible = panel;
        }

        private void dateTimePickerInitialDate_ValueChanged(object sender, EventArgs e)
        {
            textBoxInitialDate.Text = dateTimePickerInitialDate.Value.ToString("dd/MM/yyyy");
        }

        private void pictureBoxBox_Click(object sender, EventArgs e)
        {
            forBoxOrQuantity(false);
        }

        public void forBoxOrQuantity(bool Panel)
        {
            labelBox.Visible = Panel;
            textBoxBox.Visible = Panel;
            pictureBoxBox.Visible = Panel;
            labelQuantity.Visible = !Panel;
            textBoxQuantity.Visible = !Panel;
            pictureBoxQuantity.Visible = !Panel;
            _order = Panel;
        }

        private void pictureBoxQuantity_Click(object sender, EventArgs e)
        {
            forBoxOrQuantity(true);
        }


        private void pictureBoxNotFifo_Click(object sender, EventArgs e)
        {
            visibleFifo(true);
        }

        private void pictureBoxFifo_Click(object sender, EventArgs e)
        {
            visibleFifo(false);
        }

        private void visibleFifo(bool panel)
        {
            _fifo = panel;
            pictureBoxFifo.Visible = panel;
            pictureBoxNotFifo.Visible = !panel;
            label10.Text = _fifo.ToString();
        }


        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (_fifo)
            {
                Fifo();
            }
        }

        private void comboBoxLote_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxSerial.Items.Clear();
            comboBoxSerial.Text = "";
            if (comboBoxPart.Text == "")
                selectSQL.SerialNoIdProductsAComboBox(comboBoxSerial, comboBoxLote.Text, _internalwarehouse);
            else
                selectSQL.SerialAComboBox(comboBoxSerial, selectSQL.TakeIdProducts(comboBoxPart.Text), comboBoxLote.Text, _internalwarehouse);
        }

        private void pictureBoxDelete_Click(object sender, EventArgs e)
        {
            if (dataProducts.SelectedRows.Count > 0)
            {
                //int res = 
                foreach (DataGridViewRow Rw in dataProducts.SelectedRows)
                {
                    if (_up)
                    {
                        int i = 0;
                        updateSQL.UpdateProformaAndRemission("", int.Parse(Rw.Cells[1].Value.ToString()), 1, true);
                        updateSQL.UpdateInventary(int.Parse(Rw.Cells[1].Value.ToString()), 1, true);

                    }
                    dataProducts.Rows.Remove(Rw);
                }
                textBoxCount.Text = dataProducts.Rows.Count.ToString();
                if (dataProducts.Rows.Count == 0)
                {
                    buttonValid.Enabled = false;
                    buttonAsentar.Enabled = false;
                }
                addQuetityBox();
                dataProducts.ClearSelection();
                //textBoxAmount.
            }

        }

        private void control_Click(object sender, EventArgs e)
        {
            if (sender is TextBox textBox && !String.IsNullOrEmpty(textBox.Text))
            {
                textBox.SelectionStart = 0;
                textBox.SelectionLength = textBox.Text.Length;
            }

        }

        private void comboBoxPart_DropDown(object sender, EventArgs e)
        {
            if (sender is ComboBox comboBox2)
            {
                comboBox2.Focus();
            }
        }

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

        private void comboBoxPart_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxLote.Items.Clear();
            comboBoxLote.Text = string.Empty;

            if (comboBoxBill.Text == "")
                bacthCombo(true);
            else
                bacthCombo(false);

            comboBoxSerial.Items.Clear();
            comboBoxSerial.Text = "";
            selectSQL.SerialNoBatchAComboBox(comboBoxSerial, selectSQL.TakeIdProducts(comboBoxPart.Text), _internalwarehouse);

        }

        private void numericUpDownOrder_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                configurations.ORDEROUTPUT = int.Parse(numericUpDownOrder.Value.ToString());
                if (updateSQL.UpdateOrderPrint(configurations))
                    configurations = selectSQL.TakeOutpotInvoice(_idClient);
            }
            catch { }
        }

        private void numericUpDownRemission_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                configurations.REMISSIONOUTPUT = int.Parse(numericUpDownRemission.Value.ToString());
                if (updateSQL.UpdateRemissionsPrint(configurations))
                    configurations = selectSQL.TakeOutpotInvoice(_idClient);
            }
            catch { }
        }

        private void numericUpDownProforma_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                configurations.PROFORMAOUTPUT = int.Parse(numericUpDownProforma.Value.ToString());
                if (updateSQL.UpdateProformaPrint(configurations))
                    configurations = selectSQL.TakeOutpotInvoice(_idClient);
            }
            catch { }
        }

        private void buttonOrder_Click(object sender, EventArgs e)
        {
            //reportDate = selectSQL.FillDateRepots("Orden");
            reportPath = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\\..\\Orden.rdlc")); ;

            

            ReportParameter[] reportParameters = new ReportParameter[1];
            reportParameters[0] = new ReportParameter("FOLIO", _prefix, false);
            try
            {
                Task.Run(() =>
                {
                    ReportDataSource reportData = new ReportDataSource("DataSet", dataProducts.DataSource);
                    this.Invoke((Action)(() =>
                    {
                        FormReports formReports = new FormReports();
                        formReports.reportViewer1.LocalReport.ReportPath = reportPath;
                        formReports.reportViewer1.LocalReport.SetParameters(reportParameters);
                        formReports.reportViewer1.LocalReport.DataSources.Clear();
                        formReports.reportViewer1.LocalReport.DataSources.Add(reportData);


                        formReports.Controls.Add(formReports.reportViewer1);

                        // Refresca el informe
                        formReports.reportViewer1.RefreshReport();
                        formReports.ShowDialog();
                    }));
                });
            }
            catch (Exception ex) { }
        }

        private void buttonRemission_Click(object sender, EventArgs e)
        {
            //reportDate = selectSQL.FillDateRepots("Remision");
            reportPath = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\\..\\Remision.rdlc")); ;
            //reportPath = @"C:\Users\ABG_SISTEMAS\Documents\GitHub\ReisWMS\ReisWMS\Remision.rdlc";
            updateSQL.UpdateRemisionSeal(_prefix, textBoxSeal.Text, textBoxNote.Text);

            opcionCompressed();

        }

        private void opcionCompressed()
        {
            FormPopupWindow ventanaEmergente = new FormPopupWindow();

            // Mostrar el formulario emergente como un cuadro de diálogo
            DialogResult resultado = ventanaEmergente.ShowDialog();

            // Verificar la opción seleccionada por el usuario
            if (resultado == DialogResult.OK)
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable compressed = new DataTable();
                //DataTable.Parse(dataProducts.DataSource)
                aux = selectSQL.SearchInRemission(_idClient, _prefix);
                compressed = selectSQL.SearchInRemission(_idClient, _prefix);
                compressed.Rows.Clear();
                foreach (DataRow row in aux.Rows)
                {
                    if (serachindatatable(compressed, "PROVPARTNUM", row["PROVPARTNUM"].ToString()) == false || serachindatatable(compressed, "LOTE", row["LOTE"].ToString()) == false)
                    {
                        DataRow newrow = compressed.NewRow();
                        newrow["PROVPARTNUM"] = row["PROVPARTNUM"].ToString();
                        newrow["CUSTPARTNUM"] = row["CUSTPARTNUM"].ToString();
                        newrow["LOTE"] = row["LOTE"].ToString();
                        newrow["DESCRIPTION"] = row["DESCRIPTION"].ToString();
                        newrow["PC"] = row["PC"].ToString();
                        newrow["QTY"] = row["QTY"].ToString();
                        newrow["UM"] = row["UM"].ToString();
                        newrow["FACTURA"] = row["FACTURA"].ToString();
                        newrow["PEDIMENTO"] = row["PEDIMENTO"].ToString();
                        newrow["REGIMEN"] = row["REGIMEN"].ToString();
                        newrow["NAME"] = row["NAME"].ToString();
                        newrow["REMISSION_AT"] = row["REMISSION_AT"].ToString();
                        compressed.Rows.Add(newrow);
                    }
                    else
                    {
                        double valorActual = Convert.ToDouble(row["PC"]);
                        double sumar = Convert.ToDouble(compressed.Rows[compressed.Rows.Count - 1]["PC"].ToString());
                        double nuevovalor = valorActual + sumar;
                        compressed.Rows[compressed.Rows.Count - 1]["PC"] = nuevovalor;
                        valorActual = Convert.ToDouble(row["QTY"]);
                        sumar = Convert.ToDouble(compressed.Rows[compressed.Rows.Count - 1]["QTY"].ToString());
                        nuevovalor = valorActual + sumar;
                        compressed.Rows[compressed.Rows.Count - 1]["QTY"] = nuevovalor;
                    }
                }
                ReportParameter[] reportParameters = new ReportParameter[5];
                reportParameters[0] = new ReportParameter("FOLIO", _prefix, false);
                if (textBoxSeal.Text != "")
                {
                    reportParameters[1] = new ReportParameter("SELLO", "SELLO: " + textBoxSeal.Text, true);
                    if (textBoxSeal.Text != "")
                        reportParameters[2] = new ReportParameter("NOTA", "Nota: " + textBoxNote.Text, true);
                    else
                        reportParameters[2] = new ReportParameter("NOTA", " ", true);
                }
                else
                {
                    reportParameters[1] = new ReportParameter("SELLO", " ", false);
                    reportParameters[2] = new ReportParameter("NOTA", " ", true);
                }
                reportParameters[3] = new ReportParameter("DATEREMISSION", textBoxInitialDate.Text, false);
                reportParameters[4] = new ReportParameter("NAME", comboBoxBill.Text, false);
                try
                {
                    ReportDataSource reportData = new ReportDataSource("DataSet", compressed);
                    ReportDataSource reportDataBill = new ReportDataSource("DataSetBill", selectSQL.ShowDataClientDestination(comboBoxShip.Text, _idClient));
                    Task.Run(() =>
                    {

                        this.Invoke((Action)(() =>
                        {
                            FormReports formReports = new FormReports();
                            formReports.reportViewer1.LocalReport.ReportPath = reportPath;
                            formReports.reportViewer1.LocalReport.SetParameters(reportParameters);
                            formReports.reportViewer1.LocalReport.DataSources.Clear();
                            formReports.reportViewer1.LocalReport.DataSources.Add(reportData);
                            formReports.reportViewer1.LocalReport.DataSources.Add(reportDataBill);

                            formReports.Controls.Add(formReports.reportViewer1);

                            // Refresca el informe
                            formReports.reportViewer1.RefreshReport();
                            formReports.ShowDialog();
                        }));
                    });
                }
                catch (Exception ex) { }
                this.Cursor = Cursors.Default;
            }
            else if (resultado == DialogResult.Cancel)
            {
                ReportParameter[] reportParameters = new ReportParameter[5];
                reportParameters[0] = new ReportParameter("FOLIO", _prefix, false);
                if (textBoxSeal.Text != "")
                {
                    reportParameters[1] = new ReportParameter("SELLO", "SELLO: " + textBoxSeal.Text, true);
                    if (textBoxSeal.Text != "")
                        reportParameters[2] = new ReportParameter("NOTA", "Nota: " + textBoxNote.Text, true);
                    else
                        reportParameters[2] = new ReportParameter("NOTA", " ", true);
                }
                else
                {
                    reportParameters[1] = new ReportParameter("SELLO", " ", false);
                    reportParameters[2] = new ReportParameter("NOTA", " ", true);
                }
                reportParameters[3] = new ReportParameter("DATEREMISSION", textBoxInitialDate.Text, false);
                reportParameters[4] = new ReportParameter("NAME", comboBoxBill.Text, false);

                try
                {
                    ReportDataSource reportData = new ReportDataSource("DataSet", dataProducts.DataSource);
                    ReportDataSource reportDataBill = new ReportDataSource("DataSetBill", selectSQL.ShowDataClientDestination(comboBoxShip.Text, _idClient));
                    Task.Run(() =>
                    {

                        this.Invoke((Action)(() =>
                        {
                            FormReports formReports = new FormReports();
                            formReports.reportViewer1.LocalReport.ReportPath = reportPath;
                            formReports.reportViewer1.LocalReport.DataSources.Clear();
                            formReports.reportViewer1.LocalReport.DataSources.Add(reportData);
                            formReports.reportViewer1.LocalReport.DataSources.Add(reportDataBill);
                            formReports.reportViewer1.LocalReport.SetParameters(reportParameters);
                            formReports.Controls.Add(formReports.reportViewer1);

                            // Refresca el informe
                            formReports.reportViewer1.RefreshReport();
                            formReports.ShowDialog();
                        }));
                    });
                }
                catch (Exception ex) { }
            }

        }
               
        private bool serachindatatable(DataTable aux, string column, string value)
        {
            foreach (DataRow row in aux.Rows)
            {
                if (row[column].Equals(value))
                {
                    return true; // El valor está presente en la columna
                }
            }
            return false;
        }
        private void buttonProforma_Click(object sender, EventArgs e)
        {
            //reportDate = selectSQL.FillDateRepots("Proforma");
            reportPath = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\\..\\Proforma.rdlc"));
            //reportPath = @"C:\Users\ABG_SISTEMAS\Documents\GitHub\ReisWMS\ReisWMS\Proforma.rdlc";

            opcionCompressedProforma();

        }

        private void opcionCompressedProforma()
        {
            FormPopupWindow ventanaEmergente = new FormPopupWindow();

            // Mostrar el formulario emergente como un cuadro de diálogo
            DialogResult resultado = ventanaEmergente.ShowDialog();

            // Verificar la opción seleccionada por el usuario
            if (resultado == DialogResult.OK)
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable compressed = new DataTable();
                //DataTable.Parse(dataProducts.DataSource)
                aux = selectSQL.SearchInRemission(_idClient, _prefix);
                compressed = selectSQL.SearchInRemission(_idClient, _prefix);
                compressed.Rows.Clear();
                foreach (DataRow row in aux.Rows)
                {
                    if (serachindatatable(compressed, "PROVPARTNUM", row["PROVPARTNUM"].ToString()) == false || serachindatatable(compressed, "LOTE", row["LOTE"].ToString()) == false)
                    {
                        DataRow newrow = compressed.NewRow();
                        newrow["PROVPARTNUM"] = row["PROVPARTNUM"].ToString();
                        newrow["CUSTPARTNUM"] = row["CUSTPARTNUM"].ToString();
                        newrow["LOTE"] = row["LOTE"].ToString();
                        newrow["DESCRIPTION"] = row["DESCRIPTION"].ToString();
                        newrow["QTY"] = row["QTY"].ToString();
                        newrow["PRECIO"] = row["PRECIO"].ToString();
                        newrow["NAME"] = row["NAME"].ToString();
                        newrow["REMISSION_AT"] = row["REMISSION_AT"].ToString();
                        newrow["IMPORTE"] = row["IMPORTE"].ToString();
                        newrow["CURRENCY"] = row["CURRENCY"].ToString();
                        newrow["UM"] = row["UM"].ToString();
                        compressed.Rows.Add(newrow);
                    }
                    else
                    {
                        double valorActual = Convert.ToDouble(row["PRECIO"]);
                        double sumar = Convert.ToDouble(compressed.Rows[compressed.Rows.Count - 1]["PRECIO"].ToString());
                        double nuevovalor = valorActual + sumar;
                        compressed.Rows[compressed.Rows.Count - 1]["PRECIO"] = nuevovalor;
                        valorActual = Convert.ToDouble(row["QTY"]);
                        sumar = Convert.ToDouble(compressed.Rows[compressed.Rows.Count - 1]["QTY"].ToString());
                        double nuevovalor2;
                        nuevovalor2 = valorActual + sumar;
                        compressed.Rows[compressed.Rows.Count - 1]["QTY"] = nuevovalor2;
                    }
                }
                for (int l = 0; l < compressed.Rows.Count; l++)
                {
                    double valorActual = Convert.ToDouble(compressed.Rows[l]["QTY"].ToString());
                    double sumar = Convert.ToDouble(compressed.Rows[l]["PRECIO"].ToString());
                    double nuevovalor = valorActual * sumar;
                    compressed.Rows[l]["IMPORTE"] = nuevovalor;
                }
                ReportParameter[] reportParameters = new ReportParameter[2];
                reportParameters[0] = new ReportParameter("FOLIO", _prefix, false);
                reportParameters[1] = new ReportParameter("NAME", comboBoxBill.Text, false);
                ReportDataSource reportData = new ReportDataSource("DataSet", compressed);
                ReportDataSource reportDataBill = new ReportDataSource("DataSetBill", selectSQL.ShowDataClientDestination(comboBoxBill.Text, _idClient));
                ReportDataSource reportDataShip = new ReportDataSource("DataSetShip", selectSQL.ShowDataClientDestination(comboBoxShip.Text, _idClient));
                try
                {
                    Task.Run(() =>
                    {

                        this.Invoke((Action)(() =>
                        {
                            FormReports formReports = new FormReports();
                            formReports.reportViewer1.LocalReport.ReportPath = reportPath;
                            formReports.reportViewer1.LocalReport.SetParameters(reportParameters);
                            formReports.reportViewer1.LocalReport.DataSources.Clear();
                            formReports.reportViewer1.LocalReport.DataSources.Add(reportData);
                            formReports.reportViewer1.LocalReport.DataSources.Add(reportDataBill);
                            formReports.reportViewer1.LocalReport.DataSources.Add(reportDataShip);
                            ////////fyuftueiwfewufyuwfg yuewgfueiwftucdebgewfevgbcaewbfgiew etfbtygfucvsrtygluegfvbasrgrevgregre
                            ///pasa datasetbill
                            formReports.Controls.Add(formReports.reportViewer1);

                            // Refresca el informe
                            formReports.reportViewer1.RefreshReport();
                            formReports.ShowDialog();
                        }));
                    });
                }
                catch (Exception ex) { }
                this.Cursor = Cursors.Default;
            }
            else if (resultado == DialogResult.Cancel)
            {
                ReportParameter[] reportParameters = new ReportParameter[2];
                reportParameters[0] = new ReportParameter("FOLIO", _prefix, false);
                reportParameters[1] = new ReportParameter("NAME", comboBoxBill.Text, false);
                string valorComoString;
                string valorComoString2;
                aux = selectSQL.SearchInRemission(_idClient, _prefix);
                for (int l = 0; l < aux.Rows.Count; l++)
                {
                    double valorActual = Convert.ToDouble(aux.Rows[l]["QTY"].ToString());
                    double sumar = Convert.ToDouble(aux.Rows[l]["PRECIO"].ToString());
                    double nuevovalor = valorActual * sumar;
                    aux.Rows[l]["IMPORTE"] = nuevovalor;
                }
                ReportDataSource reportData = new ReportDataSource("DataSet", aux);
                ReportDataSource reportDataBill = new ReportDataSource("DataSetBill", selectSQL.ShowDataClientDestination(comboBoxBill.Text, _idClient));
                ReportDataSource reportDataShip = new ReportDataSource("DataSetShip", selectSQL.ShowDataClientDestination(comboBoxShip.Text, _idClient));
                try
                {
                    Task.Run(() =>
                    {

                        this.Invoke((Action)(() =>
                        {
                            FormReports formReports = new FormReports();
                            formReports.reportViewer1.LocalReport.ReportPath = reportPath;
                            formReports.reportViewer1.LocalReport.SetParameters(reportParameters);
                            formReports.reportViewer1.LocalReport.DataSources.Clear();
                            formReports.reportViewer1.LocalReport.DataSources.Add(reportData);
                            formReports.reportViewer1.LocalReport.DataSources.Add(reportDataBill);
                            formReports.reportViewer1.LocalReport.DataSources.Add(reportDataShip);
                            ////////fyuftueiwfewufyuwfg yuewgfueiwftucdebgewfevgbcaewbfgiew etfbtygfucvsrtygluegfvbasrgrevgregre
                            ///pasa datasetbill
                            formReports.Controls.Add(formReports.reportViewer1);

                            // Refresca el informe
                            formReports.reportViewer1.RefreshReport();
                            formReports.ShowDialog();
                        }));
                    });
                }
                catch (Exception ex) { }
            }

        }
        private void comboBoxSerial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxPart.Text == "" && comboBoxLote.Text == "" && comboBoxSerial.Text == "")
            {
                selectSQL.SerialNoIdProductsNoBatchAComboBox(comboBoxSerial, _idClient, _internalwarehouse);
                textBoxBox.Text = "";
            }
            else
                textBoxBox.Text = "1";

        }

        private void comboBoxWare_SelectedIndexChanged(object sender, EventArgs e)
        {
            _internalwarehouse = selectSQL.TakeIdInternalWarehouse(comboBoxWare.Text);
        }

        private void textBoxBox_TextChanged(object sender, EventArgs e)
        {

        }

        public void ejecutarEn(string datos, string datos2)
        {
            object value2 = datos;
            for (int i = 0; i < dataProducts.Rows.Count; i++)
            {
                object value1 = dataProducts.Rows[i].Cells["SERIAL"].Value;
                if (object.Equals(value1, value2))
                {
                    dataProducts.Rows[i].Cells["SERIAL"].Style.BackColor = Color.Green;
                    dataProducts.Rows[i].Cells["SERIAL"].Style.ForeColor = Color.White;
                }
            }
        }

        private void textBoxBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;//elimina el sonido
                buttonAdd_Click(sender, e);
            }
        }

        private void comboBoxSerial_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;//elimina el sonido
                buttonAdd_Click(sender, e);
            }
        }

        private void comboBoxSerial_Enter(object sender, EventArgs e)
        {


        }

        private void comboBoxSerial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ComboBox comboBox = (ComboBox)sender;
                if (comboBox.SelectedItem != null)
                {
                    buttonAdd_Click(sender, e);
                }
            }

        }

        private void pictureBoxCancel_Click(object sender, EventArgs e)
        {
            if (dataProducts.Rows.Count < 0)
            {
                for (int i = 0; i < dataProducts.Rows.Count; i++)
                {
                    Inventary inventary = selectSQL.FillDateInventory(int.Parse(dataProducts.Rows[i].Cells[1].Value.ToString()));

                    updateSQL.UpdateProformaAndRemission("", inventary.ID_INVOICE_ITEM, 1, true);
                    updateSQL.UpdateInventary(inventary.ID_INVOICE_ITEM, 1, true);
                }
            }

            dataProducts.DataSource = null;
            dataProducts.Rows.Clear();
            panel2.Enabled = false;
            textBoxAmount.Text = "0";
            textBoxCount.Text = "0";
            buttonAdd.Enabled = true;
            _quantityBox = 0;
        }

        private void addQuetityBox()
        {
            _quantityBox = 0;
            foreach (DataGridViewRow row in dataProducts.Rows)
            {
                if (row.Cells[7].Value != null && row.Cells[7].Value != DBNull.Value)
                {

                    _quantityBox += int.Parse(row.Cells[7].Value.ToString());
                }
            }
            textBoxAmount.Text = _quantityBox.ToString();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        public void validate(int sts)
        {
            if (sts == 1)
            {
                buttonAsentar.Enabled = true;
                trueValidacion();
            }
            else
            {
                buttonAsentar.Enabled = false;
            }

        }

        public void trueValidacion()
        {
            buttonProforma.Enabled = true;
            buttonRemission.Enabled = true;
            buttonOrder.Enabled = true;
            buttonAdd.Enabled = false;
            buttonAsentar.Visible = false;
            buttonValid.Visible = false;
            buttonClear.Enabled = false;
            buttonRemmisionCancel.Enabled = true;
            comboBoxWare.Enabled = false;
            comboBoxPart.Enabled = false;
            comboBoxLote.Enabled = false;
            comboBoxSerial.Enabled = false;
            spinner.Visible = false;
            pictureBoxDelete.Visible = false;
            _saveFull = true;
        }

        private async void buttonValid_Click(object sender, EventArgs e)
        {
            int sts = 0;
            DialogResult resultValidate = MessageBox.Show("¿Quieres validar la mercancia?", "Alerta: Validar mercancia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (resultValidate == DialogResult.Yes)
            {
                formValidate = new FormValidate(dataProducts, textBoxF.Text);

                formValidate.enviado += new FormValidate.enviar(ejecutarEn);
                await formValidate.ShowAsync();
                //this.mainForm.AddFormInPanel(formValidate);

                sts = formValidate.sts;


                if (sts == 1)
                {
                    for (int i = 0; i < dataProducts.Rows.Count; i++)
                    {
                        Inventary inventary = selectSQL.FillDateInventory(int.Parse(dataProducts.Rows[i].Cells[1].Value.ToString()));

                        updateSQL.UpdateProformaAndRemission(_prefix, inventary.ID_INVOICE_ITEM, 0, false);
                        updateSQL.UpdateInventary(inventary.ID_INVOICE_ITEM, 0, false);
                    }
                    insertSQL.SaveToBinnacle("Remision: " + _prefix + " Se valido con exito");
                    buttonAdd.Enabled = false;
                    buttonValid.Enabled = false;
                    buttonAsentar.Enabled = true;
                }

            }
        }

        private void comboBoxBill_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateSQL.UpdateRemisionDestinatios(_prefix, selectSQL.TakeIdDestinations(comboBoxBill.Text));


        }

        private void panel1_Click(object sender, EventArgs e)
        {

        }

        private void textBoxInitialDate_TextChanged(object sender, EventArgs e)
        {
            try
            {
                updateSQL.UpdateRemisionRemissionAt(_prefix, DateTime.Parse(textBoxInitialDate.Text));
            }
            catch { }
        }

        private void Output_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void comboBoxPart_TextChanged(object sender, EventArgs e)
        {
            if (comboBoxPart.Text == "")
            {
                selectSQL.SerialNoIdProductsNoBatchAComboBox(comboBoxSerial, _idClient, _internalwarehouse);
                bacthCombo(true);
            }

        }

        private void Output_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (textBoxF.Text != "")
            {
                if (!_saveFull)
                {

                    DialogResult resultValidate = MessageBox.Show("¿Quieres cancelar el folio?", "Alerta: No has guardado", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (resultValidate == DialogResult.No)
                    {
                        DialogResult result = MessageBox.Show("¿Deseas salir?", "Alerta: No has guardado", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (result == DialogResult.No)
                        {
                            e.Cancel = true;
                        }
                    }
                    else
                    {
                        insertSQL.SaveToBinnacle("Remision: " + _prefix + " Se cancelo con exito");
                        updateSQL.UpdateRemision(_prefix, 4, false, DateTime.Parse(textBoxInitialDate.Text));
                        if (dataProducts.Rows.Count != 0)
                        {
                            for (int i = 0; i < dataProducts.Rows.Count; i++)
                            {
                                Inventary inventary = selectSQL.FillDateInventory(int.Parse(dataProducts.Rows[i].Cells[1].Value.ToString()));

                                updateSQL.UpdateProformaAndRemission("", inventary.ID_INVOICE_ITEM, 1, true);
                                updateSQL.UpdateInventary(inventary.ID_INVOICE_ITEM, 1, true);
                            }
                        }
                    }
                }
                else
                {
                    DialogResult result = MessageBox.Show("¿Deseas salir?", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.No)
                    {
                        e.Cancel = true;
                    }
                }
            }


        }

        private void comboBoxShip_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateSQL.UpdateRemisionShip(_prefix, selectSQL.TakeIdDestinations(comboBoxShip.Text));
        }

        private void Output_Load(object sender, EventArgs e)
        {
           //ataProducts = new DataGridView();
            /*comboBoxBill.Items.Clear();

            selectSQL.DestinatiosAComboBox(comboBoxBill, _idClient);
            comboBoxShip.Items.Clear();

            selectSQL.DestinatiosAComboBox(comboBoxShip, _idClient);     */
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            if (dataProducts.Rows.Count < 0)
            {
                for (int i = 0; i < dataProducts.Rows.Count; i++)
                {
                    Inventary inventary = selectSQL.FillDateInventory(int.Parse(dataProducts.Rows[i].Cells[1].Value.ToString()));

                    updateSQL.UpdateProformaAndRemission("", inventary.ID_INVOICE_ITEM, 1, true);
                    updateSQL.UpdateInventary(inventary.ID_INVOICE_ITEM, 1, true);
                }
            }

            dataProducts.DataSource = null;
            dataProducts.Rows.Clear();
            panel2.Enabled = false;
            textBoxAmount.Text = "0";
            textBoxCount.Text = "0";
            buttonAdd.Enabled = true;
            _quantityBox = 0;
        }

        private void buttonRemmisionCancel_Click(object sender, EventArgs e)
        {
            string cancelSerial = "";

            if (MessageBox.Show("¿Estás seguro de que deseas cancelar la remision " + _prefix + "? ", "Alerta: Cancelando remision", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                InputForm inputForm = new InputForm();
                if (inputForm.ShowDialog() == DialogResult.OK)
                {
                    string razon = inputForm.RazonCancelacion;
                    MessageBox.Show($"Formulario cancelado. Razón: {razon}", "Cancelado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    
                    if (dataProducts.Rows.Count != 0)
                    {
                        for (int i = 0; i < dataProducts.Rows.Count; i++)
                        {
                            Inventary inventary = selectSQL.FillDateInventory(int.Parse(dataProducts.Rows[i].Cells[1].Value.ToString()));

                            updateSQL.UpdateProformaAndRemission("", inventary.ID_INVOICE_ITEM, 1, true);
                            updateSQL.UpdateInventary(inventary.ID_INVOICE_ITEM, 1, true);
                            cancelSerial = cancelSerial + dataProducts.Rows[i].Cells[0].Value.ToString();
                        }
                    }
                    //MessageBox.Show("Remision: " + _prefix + "cancelada con exito");
                    updateSQL.UpdateRemision(_prefix, 3, false, DateTime.Parse(textBoxInitialDate.Text));
                    updateSQL.UpdateRemisionSeal(_prefix, cancelSerial, " Se cancelo con exito por: " + razon + " ");
                    insertSQL.SaveToBinnacle("Remision: " + _prefix + " Se cancelo con exito por: " + razon +" Seriales de la remision: "+  cancelSerial + " ");
                    buttonClear_Click(sender, e);
                    comboBoxPart.Enabled = true;
                    comboBoxLote.Enabled = true;
                    comboBoxSerial.Enabled = true;
                    textBoxNote.Text = "";
                    textBoxSeal.Text = "";
                    textBoxF.Text = "";
                    Inicialice();
                    inicilizeForm(false);
                }

            }

        }

        private void panel2_Click(object sender, EventArgs e)
        {
            if (dataProducts.Rows.Count != 0)
                dataProducts.ClearSelection();
        }

        private void comboBoxSerial_TextChanged(object sender, EventArgs e)
        {

            if (comboBoxPart.Text == "" && comboBoxLote.Text == "" && comboBoxSerial.Text == "")
            {
                comboBoxSerial.Items.Clear();
                comboBoxSerial.Text = "";
                selectSQL.SerialNoIdProductsNoBatchAComboBox(comboBoxSerial, _idClient, _internalwarehouse);
                textBoxBox.Text = "";
            }
        }

        private void comboBoxLote_TextChanged(object sender, EventArgs e)
        {

            if (comboBoxPart.Text == "" && comboBoxLote.Text == "")
            {
                comboBoxLote.Items.Clear();
                comboBoxLote.Text = "";
                bacthCombo(true);
            }

        }

        private void buttonNuevo_Click(object sender, EventArgs e)
        {
            buttonNew.Enabled = false;
            buttonLoad.Enabled = false;
            buttonValid.Enabled = false;
            buttonAsentar.Enabled = false;
            comboBoxWare.Enabled = true;
            comboBoxPart.Enabled = true;
            comboBoxLote.Enabled = true;
            comboBoxSerial.Enabled = true;
            if (textBoxF.Text != "")
            {
                RemissionHeader remissionHeader = selectSQL.FillRemissionHeader(_prefix, _idClient);

                if (remissionHeader.STATUS != 1)
                {
                    DialogResult resultValidate = MessageBox.Show("¿Quieres crear una nueva remision?", "Alerta: Remision", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (resultValidate == DialogResult.Yes)
                    {
                        DialogResult result = MessageBox.Show("¿Quieres cancelar el folio?", "Alerta: No has guardado", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (result == DialogResult.Yes)
                        {
                            updateSQL.UpdateRemision(_prefix, 4, false, DateTime.Parse(textBoxInitialDate.Text));
                            if (dataProducts.Rows.Count == 0)
                            {
                                buttonClear_Click(sender, e);
                            }

                        }

                        newRemission();
                    }
                }
                else
                {
                    newRemission();
                }
            }
            else
            {
                newRemission();
            }

        }

        private void newRemission()
        {
            buttonAsentar.Visible = true;
            configurations = selectSQL.TakeOutpotInvoice(_idClient);
            textBoxF.Text = configurations.OUTPUT.ToString("D4");
            numericUpDownOrder.Value = configurations.ORDEROUTPUT;
            numericUpDownRemission.Value = configurations.REMISSIONOUTPUT;
            numericUpDownProforma.Value = configurations.PROFORMAOUTPUT;
            Inicialice();
            remissionInsert(2, true);
            inicilizeForm(true);
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {

            Clients clients = selectSQL.FillDateClients(selectSQL.GetClients(_idClient));
            
            FormShowQuantity formShowQuantity = new FormShowQuantity();

            try
            {
                formShowQuantity.ShowDialog();
                if (formShowQuantity.comboBoxRemission.Text != "")
                {
                    if (selectSQL.existsRemission(formShowQuantity.prefix))
                    {
                        comboBoxWare.Enabled = true;
                        comboBoxPart.Enabled = true;
                        comboBoxLote.Enabled = true;
                        comboBoxSerial.Enabled = true;
                        Inicialice();
                        //updateSQL.UpdateRemision(_prefix, 4, false, DateTime.Parse(textBoxInitialDate.Text));
                        textBoxF.Text = formShowQuantity.quitity.ToString("D4");
                        dataProducts.DataSource = selectSQL.SearchInRemission(_idClient, formShowQuantity.prefix);
                        textBoxCount.Text = dataProducts.Rows.Count.ToString();
                        dataProducts.Columns[0].Visible = false;
                        dataProducts.Columns[1].Visible = false;
                        dataProducts.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                        addQuetityBox();
                        forBoxOrQuantity(true);
                        panel2.Enabled = true;
                        _up = true;
                        //_prefix = clients.PREFIX + textBoxF.Text;
                        _prefix = formShowQuantity.prefix;
                        RemissionHeader remissionHeader = selectSQL.FillRemissionHeader(formShowQuantity.prefix, _idClient);
                        comboBoxBill.SelectedItem = selectSQL.TakeDestinatios(remissionHeader.CLIENT_DESTINATION, _idClient);
                        comboBoxShip.SelectedItem = selectSQL.TakeDestinatios(remissionHeader.PURCHASE_ORDER_ID_CLIENT, _idClient);
                        dateTimePickerInitialDate.Value = DateTime.Parse(remissionHeader.REMISSION_AT);
                        _saveFull = true;
                        inicilizeForm(true);
                        
                        int gsr = selectSQL.GetStausRemission(_prefix);
                        if (gsr == 1)
                        {
                            trueValidacion();
                        }
                        

                    }
                }
                else 
                {
                    MessageBox.Show("No existe la remision");
                }
            }
            catch { }
            dataProducts.ClearSelection();
        }

        public void inicilizeForm(bool form)
        {
            //taProducts = new DataGridView();
            pictureBoxDelete.Visible = form;
            panel2.Enabled = form;
            panel4.Visible = form;
            panel5.Visible = form;
            panel6.Visible = form;
            buttonAsentar.Visible = form;
            buttonValid.Visible = form;
            buttonClear.Visible = form;
            buttonRemmisionCancel.Visible = form;
            buttonOrder.Visible = form;
            buttonProforma.Visible = form;
            buttonRemission.Visible = form;
            labelRem.Visible = form;
            labelRepots.Visible = form;
        }

        private void textBoxInitialDate_Leave(object sender, EventArgs e)
        {
            if (!DateTime.TryParse(textBoxInitialDate.Text, out DateTime fecha))
            {
                // La conversión falló, mostrar un mensaje de error
                MessageBox.Show("Formato de fecha inválido. Ingrese una fecha válida.");
                textBoxInitialDate.Focus();
            }

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBoxShip_Leave(object sender, EventArgs e)
        {


        }

        private void labelRem_Click(object sender, EventArgs e)
        {

        }

        private void Control_Click(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
            {
                //textBox.ForeColor = Color.Blue;
                textBox.SelectionStart = textBox.Text.Length;
                textBox.SelectionLength = 0;
                textBox.SelectAll();
            }
            else if (sender is ComboBox comboBox)
            {
                //comboBox.ForeColor = Color.Blue;
                comboBox.SelectAll();
            }            
        }

        private void Control_Leave(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
            {
                // Desmarcar el texto al dejar el campo
                textBox.SelectionLength = 0;
            }
            else if (sender is ComboBox comboBox)
            {
                // Desmarcar el texto al dejar el campo
                comboBox.SelectionLength = 0;
            }
        }
    }

   


}
