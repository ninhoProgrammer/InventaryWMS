using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;

namespace InventaryWMS
{
    public partial class Input : Form
    {
        static string imagenClick = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\\..\\Resources\grupoabg.png"));
        private PrintDocument printDocument1 = new PrintDocument();
        List<string> eleme = new List<string>();
        SelectSQL selectsql = new SelectSQL();
        InsertSQL insertsql = new InsertSQL();
        DateTime currentdate = DateTime.Today;
        Security security = new Security();
        private int valueserial;
        DataTable miDataTable { get; set; }
        Main mainForm { get; set; }
        private int xClick { get; set; }
        private int yClick { get; set; }
        private int _iduser { get; set; }
        private int _idclient { get; set; }
        private int etiquetaActual { get; set; }
        string lastserial { get; set; }
        int SelectedRowNumber { get; set; }
        double subtotal { get; set; }
        double IVA { get; set; }
        double TotalPzs { get; set; }
        double tax { get; set; }
        double discount { get; set; }
        string serial { get; set; }
        int idwarehouse { get; set; }
        string namewarehouse { get; set; }

        public Input()
        {
            InitializeComponent();
            valueserial = 0;
        }

        public void Inicialize(Main main, int iduser, int idclient)
        {
            this.mainForm = main;
            _iduser = iduser;
            _idclient = idclient;
            Inicialice();
        }

        private void Inicialice()
        {
            inicilizeForm(false);
            miDataTable = new DataTable();
            valueserial = 0;
            discount = 0.0;
            idwarehouse = 0;
            etiquetaActual = 0;
            SelectedRowNumber = -1;
            Task.Run(() =>
            {
                
                this.Invoke((Action)(() =>
                {
                    dateTimePickerReception.Text = currentdate.ToString();
                    dateTimePickerPay.Text = currentdate.ToString();
                    dateTimePickerExpires.Value = DateTime.Now.AddYears(+1);
                    //temporaryDataTable = miDataTable.Clone();
                    
                    fillComboBox();
                    // Configura el autocompletado en el TextBox con los elementos del ComboBox
                    //textBox2.AutoCompleteMode = AutoCompleteMode.Suggest;
                    //textBox2.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    dataGridViewInputs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    // Agrega los elementos del ComboBox al AutoCompleteCustomSource del TextBox
                    /*foreach (var item in comboBoxProduct.Items)
                    {
                        textBox2.AutoCompleteCustomSource.Add(item.ToString());
                    }*/
                    printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
                    comboBoxStore.SelectedIndex = 0;
                    //
                    buttonEneble(false);
                    //Por si le dan de nuevo al boton y contienen 
                    inicializeButton(false);
                    buttonAdd.Enabled = true;
                    fillDataGrid();
                }));
            });
        }

        public void inicilizeForm(bool form)
        {
            //taProducts = new DataGridView();
            panel2.Enabled = form;
            panel8.Visible = form;
            panel9.Visible = form;
            panel10.Visible = form;
            panel5.Visible = form;
            panel6.Visible = form;
            textBoxInvoice.Visible = form;
            comboBoxProviders.Visible = form;
            labelInvoice.Visible = form;
            labelProvider.Visible = form;
        }

        private void fillDataGrid()
        {
            // Agregar columnas a la DataTable
            miDataTable.Columns.Add("Código", typeof(string));
            miDataTable.Columns.Add("NumeroParteCliente", typeof(string));
            miDataTable.Columns.Add("Nombre", typeof(string));
            miDataTable.Columns.Add("Serie", typeof(string));
            miDataTable.Columns.Add("Cantidad", typeof(string));
            miDataTable.Columns.Add("Costo", typeof(string));
            miDataTable.Columns.Add("Precio", typeof(string));
            miDataTable.Columns.Add("Importe", typeof(string));
            miDataTable.Columns.Add("Factura", typeof(string));
            miDataTable.Columns.Add("Regimen", typeof(string));
            miDataTable.Columns.Add("Pedimento", typeof(string));
            miDataTable.Columns.Add("FechaPedimento", typeof(string));
            miDataTable.Columns.Add("Caduca", typeof(string));
            miDataTable.Columns.Add("Ubicación", typeof(string));
            miDataTable.Columns.Add("Lote", typeof(string));
            miDataTable.Columns.Add("Piezas", typeof(string));
            miDataTable.Columns.Add("Unidad", typeof(string));
            miDataTable.Columns.Add("Bodega", typeof(string));
            miDataTable.Columns.Add("Provedor", typeof(string));
            miDataTable.Columns.Add("Contenedor", typeof(string));
            miDataTable.Columns.Add("FechaRecepcion", typeof(string));
            miDataTable.Columns.Add("FechaPagar", typeof(string));
            miDataTable.Columns.Add("Remision", typeof(string));
            miDataTable.Columns.Add("Transporte", typeof(string));
        }

        private void fillComboBox()
        {
            if (!fullComboBoxProduct())
            {
                DialogResult result = MessageBox.Show("¿Quieres dar de alta uno?", "Alerta no se encuentraron Productos", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    FormProducts form = new FormProducts(mainForm);
                    form.ShowDialog();
                    fullComboBoxProduct();
                }
            }

            if (!fullComboBoxProviders())
            {
                DialogResult result = MessageBox.Show("¿Quieres dar de alta uno?", "Alerta no se encuentraron Proveedores", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    FormClientsProviders form = new FormClientsProviders(mainForm);
                    form.ShowDialog();
                    fullComboBoxProviders();
                }
            }

            if (!fullComboBoxWarehouse())
            {
                DialogResult result = MessageBox.Show("¿Quieres dar de alta uno?", "Alerta no se encuentraron Almacenes", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    ManageWarehouses form = new ManageWarehouses(mainForm);
                    form.ShowDialog();
                    fullComboBoxWarehouse();
                }
            }
        }

        private bool fullComboBoxProduct()
        {
            comboBoxProduct.Items.Clear();
            comboBoxProduct.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBoxProduct.AutoCompleteSource = AutoCompleteSource.CustomSource;
            selectsql.IdProductsAComboBox(comboBoxProduct, _idclient, eleme);
            //selectsql.ProvidersAComboBox(comboBoxProviders, _idclient);

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
            //valueserial = 0;
            comboBoxProviders.Items.Clear();
            comboBoxProviders.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBoxProviders.AutoCompleteSource = AutoCompleteSource.ListItems;
            //comboBoxProduct.AutoCompleteMode = AutoCompleteMode.Suggest;
            //comboBoxProduct.AutoCompleteSource = AutoCompleteSource.CustomSource;

            selectsql.ProvidersAComboBox(comboBoxProviders, _idclient);

            if (comboBoxProviders.Items.Count > 0)
            {
                comboBoxProviders.SelectedIndex = 0;
                comboBoxRegimen.SelectedIndex = 1;
                
                dateTimePickerPedimento.Value = DateTime.Now.AddDays(-1);
                selectsql.UserATextBox(textBox1, _iduser);
                lastserial = selectsql.GetLastSerial();
                int.TryParse(lastserial, out valueserial);
                if (valueserial == 9999)
                {
                    valueserial = -1;
                }
                string nombreDelDispositivo = Environment.MachineName;
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool fullComboBoxWarehouse()
        {
            comboBoxLocation.Items.Clear();
            comboBoxLocation.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBoxLocation.AutoCompleteSource = AutoCompleteSource.ListItems;
            selectsql.WarehouseAComboBox(comboBoxLocation);
            //comboBoxProduct.AutoCompleteMode = AutoCompleteMode.Suggest;
            //comboBoxProduct.AutoCompleteSource = AutoCompleteSource.CustomSource;

            idwarehouse = selectsql.GetIdWarehouse(_idclient);
            namewarehouse = selectsql.GetnameWarehouses(idwarehouse);
            int index = comboBoxLocation.FindStringExact(namewarehouse);
            // Verificar si se encontró el elemento
            if (index != -1)
            {
                // Seleccionar el elemento en el ComboBox
                comboBoxLocation.SelectedIndex = index;
                return true;
            }
            else
            {
                return false;
            }
            
        }

        private void Input_Load(object sender, EventArgs e)
        {
            
        }

        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {
            Text = dateTimePickerPedimento.Value.ToString();
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            /* warehouse = comboBoxWarehouse.SelectedItem.ToString();
             number_parts = textBoxParts.Text;
             invoice = textBoxRFC.Text;
             description = textBoxDescription.Text;
             pedimento = textBoxPedimento.Text;
             serial = textBoxSerial.Text;
             //amount = textBoxAmount.Text;
             batch = textBoxBatch.Text;
             box = textBoxBox.Text;
             //revision = textBoxRevision.Text;
             //pallet = comboBoxPallet.SelectedItem.ToString();
             //bulk = textBoxBulk.Text;
             //location = textBoxLocation.Text;
             provider = comboBox_Providers.SelectedItem.ToString();
             MessageBox.Show(provider);*/

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void textBoxParts_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxBulk_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxPallet_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            int integervalue;
            string date;
            string idmeasuring;
            string abre;
            int auxselect = SelectedRowNumber;
            bool invoiceready;
            invoiceready = selectsql.searchInvoice(textBoxInvoice.Text);

            if (invoiceready == false)
            {
                //fillComboBox();
                if (int.TryParse(textBoxBox.Text, out integervalue))
                {
                    for (int i = 0; i < integervalue; i++)
                    {
                        serial = "";
                        DataRow newrow = miDataTable.NewRow();
                        newrow["Código"] = comboBoxProduct.Text;
                        newrow["NumeroParteCliente"] = selectsql.GetPartClientwhitPartProvider(_idclient.ToString(), comboBoxProduct.Text);
                        newrow["Nombre"] = textBoxNameProduct.Text;
                        newrow["Cantidad"] = 1;
                        newrow["Costo"] = textBoxCost.Text;
                        newrow["Precio"] = textBoxPrice.Text;
                        date = dateTimePickerExpires.Value.ToString("yyyy-MM-dd HH:mm:ss");
                        newrow["Caduca"] = date;
                        serial = selectsql.GetPrefixClients(_idclient);
                        serial += currentdate.ToString("yyMMdd");
                        serial += "ABCD-";
                        valueserial += 1;
                        serial += valueserial.ToString("D4");
                        newrow["Serie"] = serial;
                        newrow["Pedimento"] = textBoxPedimento.Text;
                        newrow["Ubicación"] = comboBoxLocation.Text;
                        if (textBoxBatch.Text == "")
                            newrow["Lote"] = "S/L";
                        else
                            newrow["Lote"] = textBoxBatch.Text;
                        newrow["Piezas"] = textBoxParts.Text;
                        idmeasuring = selectsql.GetidMeasuring_unit(_idclient.ToString(), comboBoxProduct.Text);
                        abre = selectsql.GetAbreviationMeasuring_unit(idmeasuring);
                        newrow["Unidad"] = abre;
                        newrow["Bodega"] = comboBoxStore.Text;
                        newrow["Factura"] = textBoxInvoice.Text;
                        newrow["Provedor"] = comboBoxProviders.Text;
                        newrow["Regimen"] = comboBoxRegimen.Text;
                        date = dateTimePickerPedimento.Value.ToString("yyyy-MM-dd HH:mm:ss");
                        newrow["FechaPedimento"] = date;
                        newrow["Contenedor"] = comboBoxContainer.Text;
                        date = dateTimePickerReception.Value.ToString("yyyy-MM-dd HH:mm:ss");
                        newrow["FechaRecepcion"] = date;
                        date = dateTimePickerPay.Value.ToString("yyyy-MM-dd HH:mm:ss");
                        newrow["FechaPagar"] = date;
                        newrow["Remision"] = textBoxRemission.Text;
                        newrow["Transporte"] = comboBoxTransport.Text;
                        // Establece los valores de otras columnas según sea necesario.
                        if (miDataTable.Rows.Count > 0 && checkBoxinsertar.Checked == true && auxselect != -1)
                        {
                            auxselect++;
                            miDataTable.Rows.InsertAt(newrow, auxselect);
                        }
                        else
                        {
                            miDataTable.Rows.Add(newrow);
                        }
                        if (checkBoxImprimir.Checked == true)
                        {
                            DataRow miDataRow = miDataTable.Rows[miDataTable.Rows.Count - 1];
                            // DataRow nuevoDataRow = temporaryDataTable.NewRow();
                            //nuevoDataRow.ItemArray = miDataRow.ItemArray.Clone() as object[];
                            //temporaryDataTable.Rows.Add(nuevoDataRow);
                        }
                    }
                    if (miDataTable.Rows.Count > 0 && checkBoxinsertar.Checked == true && auxselect != -1)
                    {
                        rearrangeTable(SelectedRowNumber, 1, 0);
                    }
                    dataGridViewInputs.DataSource = miDataTable;
                    // crear una funcion  con esto /////////////////////////////////////////

                    for (int y = 0; y < dataGridViewInputs.Columns.Count; y++)
                    {
                        DataGridViewColumn column = dataGridViewInputs.Columns[y];
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        dataGridViewInputs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                    }
                    dataGridViewInputs.Columns["Importe"].Visible = false;
                    dataGridViewInputs.ClearSelection();
                    SelectedRowNumber = -1;
                    if (checkBoxImprimir.Checked == true)
                    {
                        DataTable table = (DataTable)dataGridViewInputs.DataSource;
                        printTag(table);
                        //temporaryDataTable.Rows.Clear();

                    }

                    textBoxNumberrows.Clear();
                    textBoxNumberrows.Text = dataGridViewInputs.Rows.Count.ToString();
                    // Utiliza LINQ para calcular la suma de la columna "MiColumna" después de convertir los valores a decimales.
                    subtotal = miDataTable.AsEnumerable()
                                            .Sum(row => double.Parse(row.Field<string>("Costo").TrimStart('$')));
                    TotalPzs = miDataTable.AsEnumerable()
                                            .Sum(row => double.Parse(row.Field<string>("Piezas").TrimStart('$')));
                    textBoxSubtotal.Clear();
                    textBoxSubtotal.Text = "$" + subtotal.ToString("N2");
                    textBoxDiscount2.Clear();
                    textBoxDiscount2.Text = "$0";
                    tax = (subtotal * 16) / 100;
                    textBoxTax.Clear();
                    textBoxTax.Text = "$" + tax.ToString("N2");
                    textBoxTotal.Clear();
                    textBoxTotal.Text = "$" + ((subtotal - discount) + tax).ToString("N2");
                    CleanAll();
                    buttonEneble(true);
                    inicializeButton(true);
                }
                else
                {
                    MessageBox.Show("Faltan datos.");
                }
            }
            else
            {
                MessageBox.Show("Factura ya existe");
                textBoxInvoice.Clear();
            }


        }

        private void printTag(DataTable auxdatatable)
        {
            try
            {

                PrintDocument printDocument = new PrintDocument();
                PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
                printDocument.DefaultPageSettings.PaperSize = new PaperSize("Custom", Convert.ToInt32(4 * 100.0), Convert.ToInt32(2 * 100.0)); // Convertir pulgadas a píxeles
                int etiquetaActual = 0;
                printDocument.PrintPage += (sender, e) =>
                {
                    while (etiquetaActual < auxdatatable.Rows.Count)
                    {

                        DataRow row = auxdatatable.Rows[etiquetaActual];

                        Brush brushNegro = Brushes.Black;
                        Brush brushRojo = Brushes.Red;
                        Font fuente = new Font("Arial", 8, FontStyle.Bold);
                        Pen bordePen = new Pen(Color.Blue, 2); // Color y ancho del borde
                        Image logo = Image.FromFile(imagenClick);
                        int y = 10;

                        // Restaurar el valor de x al principio de la página para cada etiqueta
                        int x = 5;

                        // Dibuja el logo (reemplaza "logo.jpg" con la ruta de tu logo)
                        e.Graphics.DrawImage(logo, new Rectangle(40, y + 115, 140, 60));
                        // Generar el código de barras
                        Bitmap codigoBarrasBitmap = generateBarcode(row["Serie"].ToString());

                        // Dibujar el borde alrededor de la etiqueta
                        e.Graphics.DrawRectangle(bordePen, 5, y - 5, Convert.ToInt32(4 * 100.0) - 10, Convert.ToInt32(2 * 100.0) - 10);

                        // Dibujar el código de barras
                        e.Graphics.DrawImage(codigoBarrasBitmap, new Point(45, y));

                        // Dibujar otros datos
                        //e.Graphics.DrawString($"Serial: {row["Serie"]}", fuente, brushNegro, new Point(150, y+80));
                        e.Graphics.DrawString($"Número Parte: {row["Código"]}", fuente, brushRojo, new Point(190, y + 110));
                        e.Graphics.DrawString($"Factura: {row["Factura"]}", fuente, brushNegro, new Point(190, y + 130));
                        e.Graphics.DrawString($"Lote: {row["Lote"]}", fuente, brushNegro, new Point(190, y + 150));
                        e.Graphics.DrawString($"{row["Unidad"]}: ", fuente, brushNegro, new Point(190, y + 170));
                        e.Graphics.DrawString($"{row["Piezas"]}", fuente, brushNegro, new Point(210, y + 170));

                        // Ajustar la posición para la próxima etiqueta
                        y += Convert.ToInt32(2 * 100.0);
                        //MERKLE_ABG_RH

                        etiquetaActual++;

                        if (etiquetaActual == 9)
                            etiquetaActual = etiquetaActual;

                        // Verificar si hay espacio suficiente para la próxima etiqueta
                        if (y + Convert.ToInt32(2 * 100.0) > e.MarginBounds.Bottom && etiquetaActual < auxdatatable.Rows.Count)
                        {
                            e.HasMorePages = true; // Indicar que hay más páginas para imprimir
                            return;
                        }
                    }
                    // Si no hay más etiquetas, restablecer el índice y finalizar la impresión
                    etiquetaActual = 0;
                    e.HasMorePages = false;
                    // Configurar estilos y colores
                    /*Brush brushNegro = Brushes.Black;
                    Brush brushRojo = Brushes.Red;
                    Font fuente = new Font("Arial", 8, FontStyle.Bold);
                    Pen bordePen = new Pen(Color.Blue, 2); // Color y ancho del borde
                    Image logo = Image.FromFile("..\\..\\bin\\Debug\\Images\\LOGO REIS RGB.png");
                    int y = 10;

                    foreach (DataRow row in auxdatatable.Rows)
                    {
                        // Dibuja el logo (reemplaza "logo.jpg" con la ruta de tu logo)
                        e.Graphics.DrawImage(logo, new Rectangle(10, y + 80, 130, 100));
                        // Generar el código de barras
                        Bitmap codigoBarrasBitmap = generateBarcode(row["Serie"].ToString());

                        // Dibujar el borde alrededor de la etiqueta
                        e.Graphics.DrawRectangle(bordePen, 5, y - 5, Convert.ToInt32(4 * 100.0) - 10, Convert.ToInt32(2 * 100.0) - 10);

                        // Dibujar el código de barras
                        e.Graphics.DrawImage(codigoBarrasBitmap, new Point(45, y));

                        // Dibujar otros datos
                        //e.Graphics.DrawString($"Serial: {row["Serie"]}", fuente, brushNegro, new Point(150, y+80));
                        e.Graphics.DrawString($"Número Parte: {row["Código"]}", fuente, brushRojo, new Point(190, y + 110));
                        e.Graphics.DrawString($"Factura: {row["Factura"]}", fuente, brushNegro, new Point(190, y + 130));
                        e.Graphics.DrawString($"Lote: {row["Lote"]}", fuente, brushNegro, new Point(190, y + 150));
                        e.Graphics.DrawString($"{row["Unidad"]}: ", fuente, brushNegro, new Point(190, y + 170));
                        e.Graphics.DrawString($"{row["Piezas"]}", fuente, brushNegro, new Point(210, y + 170));

                        // Ajustar la posición para la próxima etiqueta
                        y += Convert.ToInt32(2 * 100.0); // Ajustar según tus necesidades
                    }*/
                };

                // Puedes configurar otras propiedades del documento de impresión aquí

                // Imprimir en la impresora predeterminada
                printPreviewDialog.Document = printDocument;

                // Mostrar la vista previa
                printPreviewDialog.ShowDialog();
                //printDocument.Print();
            }
            catch (Exception ex)
            {

            }
        }
        static Bitmap generateBarcode(string contenido)
        {
            BarcodeWriter barcodeWriter = new BarcodeWriter();
            barcodeWriter.Format = BarcodeFormat.CODE_128; // Puedes elegir el formato de código de barras que necesites
            barcodeWriter.Options = new ZXing.Common.EncodingOptions
            {
                Width = 320,  // Ancho del código de barras
                Height = 105  // Altura del código de barras
            };

            Bitmap bitmap = barcodeWriter.Write(contenido);
            return bitmap;
        }

        private void CleanAll()
        {
            comboBoxProduct.Text = "";
            textBoxNameProduct.Clear();
            textBoxBox.Clear();
            textBoxCost.Clear();
            dateTimePickerExpires.Text = currentdate.ToString();
            textBoxSerial.Clear();
            textBoxBatch.Clear();
            textBoxParts.Clear();
            dateTimePickerReception.Text = currentdate.ToString();
            dateTimePickerPay.Text = currentdate.ToString();
            comboBoxContainer.Text = "";
            textBoxPrice.Clear();
        }
        private void comboBoxProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            //textBox2.Text = comboBoxProduct.SelectedItem.ToString();
            double price;
            double cost;
            double box;
            textBoxSerial.Clear();
            selectsql.SerialATextBox(textBoxSerial, _idclient, comboBoxProduct.Text);
            textBoxNameProduct.Clear();
            selectsql.ProductsATextBox(textBoxNameProduct, _idclient, comboBoxProduct.Text);
            textBoxCost.Clear();
            selectsql.CostATextBox(textBoxCost, _idclient, comboBoxProduct.Text);
            textBoxParts.Clear();
            selectsql.ItemsPerBoxATextBox(textBoxParts, _idclient, comboBoxProduct.Text);
            textBoxPrice.Clear();
            Double.TryParse(textBoxCost.Text, out cost);
            Double.TryParse(textBoxBox.Text, out box);
            price = cost * box;
            textBoxPrice.Text = price.ToString();
        }

        private void rearrangeTable(int selectrow, int opcion, int numrows)
        {
            string serialdelete;
            int length;
            serialdelete = miDataTable.Rows[selectrow]["Serie"].ToString();
            length = serialdelete.Length;
            serialdelete = serialdelete.Substring(length - 4);
            int.TryParse(serialdelete, out valueserial);
            if (opcion == 1)
            {
                valueserial += 1;
                for (int i = selectrow + 1; i < miDataTable.Rows.Count; i++)
                {
                    if (miDataTable.Rows[i]["Serie"] != DBNull.Value)
                    {
                        string currentValue = miDataTable.Rows[i]["Serie"].ToString();

                        if (currentValue.Length >= 4)
                        {
                            string currentserialnumber = valueserial.ToString("D4"); // Reemplaza con lo que desees
                            string newValue = currentValue.Substring(0, currentValue.Length - 4) + currentserialnumber;
                            miDataTable.Rows[i]["Serie"] = newValue;
                            valueserial += 1;
                        }
                    }
                }
            }
            else
            {
                if (dataGridViewInputs.RowCount - numrows == 0)
                {
                    lastserial = selectsql.GetLastSerial();
                    int.TryParse(lastserial, out valueserial);
                    valueserial += 1;
                }
                for (int i = selectrow; i < miDataTable.Rows.Count - numrows; i++)
                {
                    if (miDataTable.Rows[i]["Serie"] != DBNull.Value)
                    {
                        string currentValue = miDataTable.Rows[i]["Serie"].ToString();

                        if (currentValue.Length >= 4)
                        {
                            string currentserialnumber = valueserial.ToString("D4"); // Reemplaza con lo que desees
                            string newValue = currentValue.Substring(0, currentValue.Length - 4) + currentserialnumber;
                            miDataTable.Rows[i + numrows]["Serie"] = newValue;
                            valueserial += 1;
                        }
                    }
                }
            }

        }
        private void buttonRemove_Click(object sender, EventArgs e)
        {
            try
            {
                //rearrangeTable(SelectedRowNumber, 0);
                //miDataTable.Rows.RemoveAt(SelectedRowNumber);
                DataGridViewSelectedRowCollection selectedRows = dataGridViewInputs.SelectedRows;
                if (selectedRows.Count == 0)
                {
                    MessageBox.Show("Seleccione filas");
                }
                else
                {
                    DialogResult result = MessageBox.Show("¿Esta seguro de eliminar " + selectedRows.Count + " productos?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    // Verificar la respuesta del usuario
                    if (result == DialogResult.Yes)
                    {
                        rearrangeTable(selectedRows[selectedRows.Count - 1].Index, 0, selectedRows.Count);
                        // Itera a través de las filas seleccionadas
                        foreach (DataGridViewRow row in selectedRows)
                        {
                            // Obtén la DataRow asociada al índice de la fila en el DataTable
                            DataRow dataRow = ((DataRowView)row.DataBoundItem).Row;

                            // Elimina la fila del DataTable
                            miDataTable.Rows.Remove(dataRow);

                        }
                        dataGridViewInputs.DataSource = null;
                        dataGridViewInputs.DataSource = miDataTable;
                        for (int y = 0; y < dataGridViewInputs.Columns.Count; y++)
                        {
                            DataGridViewColumn column = dataGridViewInputs.Columns[y];
                            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                            dataGridViewInputs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                        }
                        dataGridViewInputs.Columns["Importe"].Visible = false;
                        textBoxNumberrows.Clear();
                        textBoxNumberrows.Text = dataGridViewInputs.Rows.Count.ToString();
                        // Utiliza LINQ para calcular la suma de la columna "MiColumna" después de convertir los valores a decimales.
                        subtotal = miDataTable.AsEnumerable()
                                                .Sum(row => double.Parse(row.Field<string>("Costo").TrimStart('$')));
                        TotalPzs = miDataTable.AsEnumerable()
                                                    .Sum(row => double.Parse(row.Field<string>("Piezas").TrimStart('$')));
                        textBoxSubtotal.Clear();
                        textBoxSubtotal.Text = "$" + subtotal.ToString("N2");
                        tax = (subtotal * 16) / 100;
                        textBoxTax.Clear();
                        textBoxTax.Text = "$" + tax.ToString("N2");
                        textBoxTotal.Clear();
                        textBoxTotal.Text = "$" + ((subtotal - discount) + tax).ToString("N2");
                        dataGridViewInputs.ClearSelection();
                        SelectedRowNumber = -1;
                        valueserial -= 1;
                        if (dataGridViewInputs.Rows.Count == 0)
                        {
                            buttonEneble(false);
                            buttonAdd.Enabled = true;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Seleccione una fila");
            }

        }

        public void buttonEneble(bool yes)
        {
            buttonClear.Enabled = yes;
            buttonSettle.Enabled = yes;
            buttonRemove.Enabled = yes;
            buttonAdd.Enabled = yes;
            buttonHand.Enabled = yes;
        }

        private void inicializeButton(bool yes)
        {
            buttonPrintLabel.Enabled = yes;
            buttonReport.Enabled = yes;
            
        }
        private void dataGridViewInputs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectedRowNumber = dataGridViewInputs.CurrentRow.Index;

        }

        private void textBoxPedimento_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es Enter o Tab
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Tab)
            {
                if (sender == textBoxPedimento)
                {
                    comboBoxProduct.Select();
                }
            }
        }

        private void textBoxCost_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica si el carácter presionado no es un número o no es la tecla BackSpace (borrar).
            /*if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Suprime la pulsación si no es un número.
            }
            // Asegura que solo se permita un punto decimal.
            if (e.KeyChar == '.' && textBoxCost.Text.Contains("."))
            {
                e.Handled = true;
            }*/
            // Verificar si la tecla presionada es Enter o Tab
            double cost;
            double price;
            double box;
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Tab)
            {
                // Cambiar al siguiente controlador
                Double.TryParse(textBoxCost.Text, out cost);
                Double.TryParse(textBoxBox.Text, out box);
                price = cost * box;
                textBoxPrice.Text = price.ToString();
                SelectNextControl((Control)sender, true, true, true, true);
            }

        }

        private void textBoxBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica si el carácter presionado no es un número o no es la tecla BackSpace (borrar).
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Suprime la pulsación si no es un número.
            }

            // Verificar si la tecla presionada es Enter o Tab
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Tab)
            {
                // Cambiar al siguiente controlador
                SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void textBoxCost_TextChanged(object sender, EventArgs e)
        {
            /*
            // Verifica si el texto en el TextBox es un número válido.
            if (decimal.TryParse(textBoxCost.Text, out decimal numero))
            {
                // Formatea el número con comas y dos decimales, y establece el resultado en el TextBox.
                textBoxCost.Text = numero.ToString("N0");
                textBoxCost.SelectionStart = textBoxCost.Text.Length; // Mantiene el cursor al final del texto.
            }*/
        }

        private void buttonPrintLabel_Click(object sender, EventArgs e)
        {
            DataTable table = (DataTable)dataGridViewInputs.DataSource;
            printTag(table);
            /*PrintDialog printDialog1 = new PrintDialog();
            printDialog1.Document = printDocument1;

            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }*/
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            if (etiquetaActual < miDataTable.Rows.Count)
            {
                // Obtén los datos de la fila actual del DataTable.
                DataRow fila = miDataTable.Rows[etiquetaActual];

                // Define el contenido de la etiqueta con los datos del DataTable.
                string contenidoEtiqueta = $"Serie: {fila["Código"]}\nUbicación: {fila["Ubicación"]}\nCantidad: {fila["Cantidad"]} {fila["Costo"]}";

                int x = 70; // Coordenada X del rectángulo.
                int y = 70; // Coordenada Y del rectángulo.
                int ancho = 400; // Ancho del rectángulo.
                int alto = 150; // Alto del rectángulo.
                e.Graphics.DrawRectangle(Pens.Black, x, y, ancho, alto);

                // Dibuja el contenido en la página.
                e.Graphics.DrawString(contenidoEtiqueta, new Font("Arial", 12), Brushes.Black, 100, 100);

                etiquetaActual++;

                if (etiquetaActual < miDataTable.Rows.Count)
                {
                    e.HasMorePages = true;
                }
            }
            else
            {
                e.HasMorePages = false;
                etiquetaActual = 0;
            }
        }
        private void textBoxIVA_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica si el carácter presionado no es un número o no es la tecla BackSpace (borrar).
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Suprime la pulsación si no es un número.
            }
        }

        private void textBoxParts_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es Enter o Tab
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Tab)
            {
                // Cambiar al siguiente controlador
                SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            CleanAll();
            miDataTable.Clear();
            miDataTable = new DataTable();
            fillDataGrid();
            dataGridViewInputs.DataSource = null;
            textBoxNumberrows.Clear();
            textBoxSubtotal.Clear();
            textBoxDiscount2.Clear();
            textBoxTax.Clear();
            textBoxTotal.Clear();
            textBoxInvoice.Enabled = true;
            textBoxInvoice.Clear();
            textBoxPedimento.Clear();
            lastserial = selectsql.GetLastSerial();
            int.TryParse(lastserial, out valueserial);
            buttonEneble(false);
            inicializeButton(false);
            buttonAdd.Enabled = true;
            checkBoxinsertar.Enabled = true;
            checkBoxImprimir.Enabled = true;
            checkBoxeditar.Enabled = true;
            textBoxRemission.Clear();
            comboBoxTransport.SelectedItem = 0;
            inicilizeForm(true);
        }

        private void buttonSettle_Click(object sender, EventArgs e)
        {
            InvoiceHeader invoiceHeader = new InvoiceHeader();
            InvoiceItem invoiceItem = new InvoiceItem();
            DialogResult result = MessageBox.Show("¿Esta seguro de Asentar?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            spinner.Enabled = true;
            // Verificar la respuesta del usuario
            if (result == DialogResult.Yes)
            {

                this.Cursor = Cursors.WaitCursor;
                string comando;
                int idwarehouse;
                int idsession;
                int idinvoiceheader;
                int idinvoicepallet;
                int idinvoiceitems;
                int idproduct;
                string partnumberclient;
                int idclientprovider;
                int idinternalwarehouse; ;
                string dateformat;
                bool header;
                bool pallet;
                bool items;
                bool inventary;
                bool AllInventary = true;
                DataTable valuesProduct = new DataTable();
                idwarehouse = selectsql.GetIdOnShortNameWarehoses(comboBoxLocation.Text);
                idsession = selectsql.GetIdSession(_iduser.ToString());

                currentdate = DateTime.Now;
                dateformat = currentdate.ToString("yyyyMMdd HH:mm:ss");
                comando = "INSERT INTO [dbo].[INVOICE_HEADERS] ([IDCLIENTE],[INVOICE_INDEX],[CREATE_AT],[INVOICE],[CUSTOMS_DOCUMENTS],[PROFORMA],[CLIENT_REFERENCE],[IDWAREHOUSES],[STATUS],[COMMENTS],[SESSION_IDSESSION],[VALID],[SUBTOTAL],[DISCOUNT],[TAX],[TOTAL],[RECEIVES]) VALUES (" + _idclient + "," + 1 + ",'" + dateformat + "','" + textBoxInvoice.Text + "','" + "Documentos" + "','" + "Remision" + "','" + "Referencia" + "'," + idwarehouse + "," + 1 + ",'" + "Comentarios" + "'," + idsession + "," + 1 + "," + textBoxSubtotal.Text.Replace("$", "") + "," + textBoxDiscount2.Text.Replace("$", "") + "," + textBoxTax.Text.Replace("$", "") + "," + textBoxTotal.Text.Replace("$", "") + ",'" + textBox1.Text + "')"; 
                header = insertsql.insertSentency(comando);
                if (header == true)
                {
                    idinvoiceheader = selectsql.GetLastIdInvoiceHeader();
                    comando = "INSERT INTO [dbo].[INVOICE_PALLETS] ([IDINVOICE_HEADERS],[SERIAL],[VALID]) VALUES (" + idinvoiceheader + ",'" + textBoxInvoice.Text + "'," + 1 + ")";
                    pallet = insertsql.insertSentency(comando);
                    if (pallet == true)
                    {
                        idinvoicepallet = selectsql.GetLastIdInvoicePallet();
                        for (int i = 0; i < miDataTable.Rows.Count; i++)
                        {
                            idproduct = selectsql.GetIdProducts(miDataTable.Rows[i]["Código"].ToString());
                            valuesProduct = selectsql.GetValuesFromProduct(idproduct);
                            partnumberclient = selectsql.GetPartClient(idproduct);
                            idclientprovider = selectsql.GetIdClientProvider(miDataTable.Rows[i]["Provedor"].ToString(), _idclient);
                            idinternalwarehouse = selectsql.GetIdInternalWarehouses(miDataTable.Rows[i]["Bodega"].ToString());
                            //currentdate = DateTime.Now;
                            //dateformat = currentdate.ToString("yyyyMMdd HH:mm:ss");
                            comando = "INSERT INTO [dbo].[INVOICE_ITEMS] ([IDINVOICE_HEADERS],[IDINVOICE_PALLETS],[IDPRODUCTS],[QUANTITY],[INVOICE],[BATCH],[EXTERNAL_SERIAL],[EXPIRATION_DATE],[REVISION],[CUSTOMS_DOCUMENT],[PROFORMA],[SERIAL],[PACKING_LIST],[BOXES],[IDCLIENT_PROVIDERS],[DESCRIPTION],[IDMEASURING_UNIT],[WEIGHT],[UNIT_VALUE],[IDCURRENCY],[TARIFF_FRACTION],[IDCOUNTRIES],[STATUS],[CREATE_AT],[SESSION_IDSESSION],[VALID],[PEDIMENTOADUANAL],[ID_INTERNAL_WAREHOUSE],[REGIMEN],[REMISION],[PEDIMENTO_DATE],[PAY_DATE],[CONTAINER],[COST],[PRICE],[TRANSPORT]) VALUES (" + idinvoiceheader + "," + idinvoicepallet + "," + idproduct + "," + miDataTable.Rows[i]["Piezas"].ToString() + ",'" + miDataTable.Rows[i]["Factura"].ToString() + "','" + miDataTable.Rows[i]["Lote"].ToString() + "','" + partnumberclient + "','" + DateTime.Parse(miDataTable.Rows[i]["Caduca"].ToString()).ToString("yyyyMMdd") + "','" + "Revision" + "','" + "Documentos" + "','" + "Proforma" + "','" + miDataTable.Rows[i]["Serie"].ToString() + "','" + "Lista de embalaje" + "'," + 1 + "," + idclientprovider + ",'" + " " + "'," + valuesProduct.Rows[0][0].ToString() + "," + valuesProduct.Rows[0][1].ToString() + "," + valuesProduct.Rows[0][2].ToString() + "," + valuesProduct.Rows[0][3].ToString() + ",'" + valuesProduct.Rows[0][4].ToString() + "'," + valuesProduct.Rows[0][5].ToString() + "," + 1 + ",'" + dateformat + "'," + idsession + "," + 1 + ",'" + miDataTable.Rows[i]["Pedimento"].ToString() + "'," + idinternalwarehouse + ",'" + miDataTable.Rows[i]["Regimen"].ToString() + "','" + miDataTable.Rows[i]["Remision"].ToString() + "','" + DateTime.Parse(miDataTable.Rows[i]["FechaPedimento"].ToString()).ToString("yyyyMMdd") + "','" + DateTime.Parse(miDataTable.Rows[i]["FechaPagar"].ToString()).ToString("yyyyMMdd") + "','" + miDataTable.Rows[i]["Contenedor"].ToString() + "'," + miDataTable.Rows[i]["Costo"].ToString().Replace("$", "") + "," + miDataTable.Rows[i]["Precio"].ToString().Replace("$", "") + ",'" + miDataTable.Rows[i]["Transporte"].ToString() + "')";
                            items = insertsql.insertSentency(comando);
                            if (items == true)
                            {
                                idinvoiceitems = selectsql.GetLastIdInvoiceItem();
                                comando = "INSERT INTO [dbo].[INVENTORY] ([ID_INVOICE_ITEM],[QUANTITY],[STATUS],[VALID]) VALUES(" + idinvoiceitems + "," + miDataTable.Rows[i]["Piezas"].ToString() + "," + 1 + "," + 1 + ")";
                                inventary = insertsql.insertSentency(comando);
                                if (!inventary)
                                {
                                    MessageBox.Show("fallo en inventory" + comando);
                                    AllInventary = false;
                                }
                                
                            }
                            else
                            {
                                MessageBox.Show("fallo en items" + comando);
                            }

                        }

                        if (AllInventary)
                        {
                            //Todos los elementos entraron correctamente.
                            this.Cursor = Cursors.Default;
                            MessageBox.Show("se ingreso correctamente");
                            insertsql.SaveToBinnacle("Ingreso con factura: " + textBoxInvoice.Text + " creada con exito");
                            buttonEneble(false);
                            lastserial = selectsql.GetLastSerial();
                            int.TryParse(lastserial, out valueserial);
                            // Crear una instancia del formulario emergente
                            FormPopupWindowLoad();   
                        }
                    }
                    else
                    {
                        MessageBox.Show("fallo en pallet" + comando);
                    }

                }
                else
                {
                    MessageBox.Show("fallo en header" + comando);
                }

            }
            else
            {

            }
            spinner.Enabled = false;
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
        private void buttonReport_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            DataTable aux = new DataTable();
            aux = miDataTable.Copy();
            //aux.Columns.Add("Recibio", typeof(string));
            aux.Columns.Add("Subtotal", typeof(string));
            aux.Columns.Add("Descuento", typeof(string));
            aux.Columns.Add("Impuesto", typeof(string));
            aux.Columns.Add("Total", typeof(string));
            aux.Columns.Add("TotalPzs", typeof(string));
            aux.Rows[0]["FechaRecepcion"] = dateTimePickerReception.Text;
            aux.Rows[0]["FechaPagar"] = dateTimePickerPay.Text;
            aux.Rows[0]["Recibio"] = textBox1.Text;
            aux.Rows[0]["Subtotal"] = textBoxSubtotal.Text;
            aux.Rows[0]["Descuento"] = textBoxDiscount2.Text;
            aux.Rows[0]["Impuesto"] = textBoxTax.Text;
            aux.Rows[0]["Total"] = textBoxTotal.Text;
            aux.Rows[0]["TotalPzs"] = TotalPzs.ToString();
            ReportDataSource reportData = new ReportDataSource("DataSet1", aux);
            FormReports formReports = new FormReports("..\\..\\Input.rdlc", reportData);
            formReports.ShowDialog();
            this.Cursor = Cursors.Default;
            try
            {
                Task.Run(() =>
                {

                    this.Invoke((Action)(() =>
                    {

                    }));
                });
            }
            catch { }
        }
        private void comboBoxContainer_SelectedIndexChanged(object sender, EventArgs e)
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

        private void comboBoxProduct_MouseClick(object sender, MouseEventArgs e)
        {

            //comboBoxProduct.DroppedDown = true;
            //comboBoxProduct.Text = "Escribe el codigo";



        }

        private void comboBoxProduct_Layout(object sender, LayoutEventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBoxBox_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es Enter o Tab
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Tab)
            {
                // Cambiar al siguiente controlador
                SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void comboBox_Providers_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es Enter o Tab
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Tab)
            {
                // Cambiar al siguiente controlador
                SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void textBoxInvoice_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es Enter o Tab
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Tab)
            {
                // Cambiar al siguiente controlador
                SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void comboBoxRegimen_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es Enter o Tab
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Tab)
            {
                // Cambiar al siguiente controlador
                SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es Enter o Tab
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Tab)
            {
                // Si la tecla no es válida, establecemos e.Handled en true para suprimir el sonido
                e.Handled = true;
                // Cambiar al siguiente controlador
                SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void comboBoxStore_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es Enter o Tab
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Tab)
            {
                // Cambiar al siguiente controlador
                SelectNextControl((Control)sender, true, true, true, true);

            }
        }

        private void textBoxRemission_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es Enter o Tab
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Tab)
            {
                // Cambiar al siguiente controlador
                SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void dateTimePickerReception_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es Enter o Tab
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Tab)
            {
                // Cambiar al siguiente controlador
                SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void dateTimePickerPay_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es Enter o Tab
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Tab)
            {
                // Cambiar al siguiente controlador
                SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void comboBoxContainer_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es Enter o Tab
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Tab)
            {
                // Cambiar al siguiente controlador
                SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void comboBoxPallet_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es Enter o Tab
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Tab)
            {
                // Cambiar al siguiente controlador
                SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void textBoxBatch_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es Enter o Tab
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Tab)
            {
                // Cambiar al siguiente controlador
                SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void textBoxPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es Enter o Tab
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Tab)
            {
                // Cambiar al siguiente controlador
                SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void dateTimePickerExpires_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es Enter o Tab
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Tab)
            {
                // Cambiar al siguiente controlador
                SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void comboBoxLocation_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es Enter o Tab
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Tab)
            {
                // Cambiar al siguiente controlador
                SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void textBoxNameProduct_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es Enter o Tab
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Tab)
            {
                // Cambiar al siguiente controlador
                SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            // Manejar el evento KeyDown del TextBox
            if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
            {
                // Obtener el texto del TextBox
                string textoFiltrado = comboBoxProduct.Text.ToLower();

                // Limpiar los elementos actuales del ComboBox
                comboBoxProduct.Items.Clear();

                // Filtrar los elementos que contienen el texto ingresado y agregarlos al ComboBox
                foreach (string elemento in eleme
                    .Where(elem => elem.ToLower().Contains(textoFiltrado)))
                {
                    comboBoxProduct.Items.Add(elemento);
                }
                comboBoxProduct.DroppedDown = true;

            }
            else
            {
                // Obtener el texto del TextBox
                string textoFiltrado = comboBoxProduct.Text.ToLower();

                // Limpiar los elementos actuales del ComboBox
                comboBoxProduct.Items.Clear();

                // Filtrar los elementos que contienen el texto ingresado y agregarlos al ComboBox
                foreach (string elemento in eleme
                    .Where(elem => elem.ToLower().Contains(textoFiltrado)))
                {
                    comboBoxProduct.Items.Add(elemento);
                }
                //comboBoxProduct_DropDown(sender, e);
                comboBoxProduct.DroppedDown = true;
                comboBoxProduct.Text = "";
            }
        }

        private void checkBoxeditar_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxeditar.Checked == true)
            {
                dataGridViewInputs.ReadOnly = false;
            }
            else
            {
                dataGridViewInputs.ReadOnly = true;
            }
        }

        private void dataGridViewInputs_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Guarda los cambios en tu DataTable
            miDataTable.AcceptChanges();
        }

        private void buttonbatch_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < miDataTable.Rows.Count; i++)
            {
                if (miDataTable.Rows[i]["Lote"].ToString() == "")
                {
                    miDataTable.Rows[i]["Lote"] = textBoxBatch.Text;
                }
            }
            textBoxBatch.Clear();
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            comboBoxProduct.Items.Clear();
            eleme.Clear();
            selectsql.IdProductsAComboBox(comboBoxProduct, _idclient, eleme);
        }

        private void buttonloadinvoice_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Se va a cargar la factura: " + textBoxInvoice.Text + ", durante este proceso no podra agregar ni eliminar productos.¿Desea continuar?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Verificar la respuesta del usuario
            if (result == DialogResult.Yes)
            {
                string idclientheader;
                idclientheader = selectsql.GetIdClientInvoiceHeader(textBoxInvoice.Text);
                if (idclientheader == _idclient.ToString())
                {
                    DataTable invoicedataTable = new DataTable();
                    invoicedataTable = selectsql.getdatatable(textBoxInvoice.Text);
                    if (invoicedataTable.Rows.Count != 0)
                    {
                        buttonAdd.Enabled = false;
                        checkBoxeditar.Enabled = false;
                        checkBoxImprimir.Enabled = false;
                        checkBoxinsertar.Enabled = false;
                        dataGridViewInputs.DataSource = invoicedataTable;
                        for (int y = 0; y < dataGridViewInputs.Columns.Count; y++)
                        {
                            DataGridViewColumn column = dataGridViewInputs.Columns[y];
                            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                            dataGridViewInputs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                        }
                        FormPopupWindow ventanaEmergente = new FormPopupWindow();

                        // Mostrar el formulario emergente como un cuadro de diálogo
                        DialogResult resultado = ventanaEmergente.ShowDialog();

                        // Verificar la opción seleccionada por el usuario
                        if (resultado == DialogResult.OK)
                        {
                            this.Cursor = Cursors.WaitCursor;
                            DataTable compressed = new DataTable();
                            compressed = invoicedataTable.Copy();
                            compressed.Columns.Add("TotalPzs", typeof(string));
                            compressed.Columns.Add("TotalCantidad", typeof(string));
                            compressed.Rows.Clear();
                            foreach (DataRow row in invoicedataTable.Rows)
                            {
                                if (serachindatatable(compressed, "Código", row["Código"].ToString()) == false)
                                {
                                    DataRow newrow = compressed.NewRow();
                                    string idmeasuring;
                                    newrow["Código"] = row["Código"].ToString();
                                    newrow["NumeroParteCliente"] = row["NumeroParteCliente"].ToString();
                                    newrow["Nombre"] = row["Nombre"].ToString();
                                    newrow["Piezas"] = row["Piezas"].ToString();
                                    newrow["Unidad"] = row["Unidad"].ToString();
                                    newrow["Lote"] = row["Lote"].ToString();
                                    newrow["Bodega"] = row["Bodega"].ToString();
                                    newrow["Regimen"] = row["Regimen"].ToString();
                                    newrow["Factura"] = row["Factura"].ToString();
                                    newrow["FechaRecepcion"] = row["FechaRecepcion"].ToString();
                                    newrow["FechaPagar"] = row["FechaPagar"].ToString();
                                    newrow["Provedor"] = row["Provedor"].ToString();
                                    newrow["Recibio"] = row["Recibio"].ToString();
                                    newrow["Pedimento"] = row["Pedimento"].ToString();
                                    compressed.Rows.Add(newrow);
                                }
                                else
                                {
                                    double valorActual = Convert.ToDouble(row["Piezas"]);
                                    double sumar = Convert.ToDouble(compressed.Rows[compressed.Rows.Count - 1]["Piezas"].ToString());
                                    double nuevovalor = valorActual + sumar;
                                    compressed.Rows[compressed.Rows.Count - 1]["Piezas"] = nuevovalor;
                                }
                            }
                            TotalPzs = invoicedataTable.AsEnumerable().Sum(row => row.Field<double>("Piezas"));
                            compressed.Rows[0]["TotalPzs"] = TotalPzs.ToString();
                            compressed.Rows[0]["TotalCantidad"] = invoicedataTable.Rows.Count.ToString();
                            ReportDataSource reportData = new ReportDataSource("DataSet1", compressed);
                            FormReports formReports = new FormReports("..\\..\\InputCompressed.rdlc", reportData);
                            formReports.ShowDialog();
                            this.Cursor = Cursors.Default;
                        }
                        else if (resultado == DialogResult.Cancel)
                        {
                            this.Cursor = Cursors.WaitCursor;
                            DataTable Tableaux = new DataTable();
                            Tableaux = invoicedataTable.Copy();
                            Tableaux.Columns.Add("TotalPzs", typeof(string));
                            Tableaux.Columns.Add("TotalCantidad", typeof(string));
                            TotalPzs = invoicedataTable.AsEnumerable().Sum(row => row.Field<double>("Piezas"));
                            Tableaux.Rows[0]["TotalPzs"] = TotalPzs.ToString();
                            Tableaux.Rows[0]["TotalCantidad"] = invoicedataTable.Rows.Count.ToString();
                            ReportDataSource reportData = new ReportDataSource("DataSet1", Tableaux);
                            FormReports formReports = new FormReports("..\\..\\InputDown.rdlc", reportData);
                            formReports.ShowDialog();
                            this.Cursor = Cursors.Default;
                        }
                    }
                    else
                    {
                        MessageBox.Show("No existe la factura");
                    }
                }
                else
                {
                    MessageBox.Show("La factura no pertenece al cliente o no existe");
                }

            }
            else
            {

            }

        }

        private void Input_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Mostrar un mensaje de confirmación
            DialogResult result = MessageBox.Show("¿Estás seguro de que quieres salir?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Si el usuario hace clic en "No", cancelar el cierre del formulario
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Se va a cargar la factura: " + textBoxInvoice.Text + ", durante este proceso no podra agregar ni eliminar productos.¿Desea continuar?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            try
            {
                // Verificar la respuesta del usuario
                if (result == DialogResult.Yes)
                {
                    string idclientheader;
                    idclientheader = selectsql.GetIdClientInvoiceHeader(textBoxInvoice.Text);
                    if (idclientheader == _idclient.ToString())
                    {
                        DataTable invoicedataTable = new DataTable();
                        invoicedataTable = selectsql.getdatatable(textBoxInvoice.Text);
                        if (invoicedataTable.Rows.Count != 0)
                        {
                            buttonAdd.Enabled = false;
                            checkBoxeditar.Enabled = false;
                            checkBoxImprimir.Enabled = false;
                            checkBoxinsertar.Enabled = false;
                            dataGridViewInputs.DataSource = invoicedataTable;
                            for (int y = 0; y < dataGridViewInputs.Columns.Count; y++)
                            {
                                DataGridViewColumn column = dataGridViewInputs.Columns[y];
                                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                                dataGridViewInputs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                            }
                            FormPopupWindow ventanaEmergente = new FormPopupWindow();

                            // Mostrar el formulario emergente como un cuadro de diálogo
                            DialogResult resultado = ventanaEmergente.ShowDialog();

                            // Verificar la opción seleccionada por el usuario
                            if (resultado == DialogResult.OK)
                            {
                                this.Cursor = Cursors.WaitCursor;
                                DataTable compressed = new DataTable();
                                compressed = invoicedataTable.Copy();
                                compressed.Columns.Add("TotalPzs", typeof(string));
                                compressed.Columns.Add("TotalCantidad", typeof(string));
                                compressed.Rows.Clear();
                                foreach (DataRow row in invoicedataTable.Rows)
                                {
                                    if (serachindatatable(compressed, "Código", row["Código"].ToString()) == false)
                                    {
                                        DataRow newrow = compressed.NewRow();
                                        string idmeasuring;
                                        newrow["Código"] = row["Código"].ToString();
                                        newrow["NumeroParteCliente"] = row["NumeroParteCliente"].ToString();
                                        newrow["Nombre"] = row["Nombre"].ToString();
                                        newrow["Piezas"] = row["Piezas"].ToString();
                                        newrow["Unidad"] = row["Unidad"].ToString();
                                        newrow["Lote"] = row["Lote"].ToString();
                                        newrow["Bodega"] = row["Bodega"].ToString();
                                        newrow["Regimen"] = row["Regimen"].ToString();
                                        newrow["Factura"] = row["Factura"].ToString();
                                        newrow["FechaRecepcion"] = row["FechaRecepcion"].ToString();
                                        newrow["FechaPagar"] = row["FechaPagar"].ToString();
                                        newrow["Provedor"] = row["Provedor"].ToString();
                                        newrow["Recibio"] = row["Recibio"].ToString();
                                        newrow["Pedimento"] = row["Pedimento"].ToString();
                                        compressed.Rows.Add(newrow);
                                    }
                                    else
                                    {
                                        double valorActual = Convert.ToDouble(row["Piezas"]);
                                        double sumar = Convert.ToDouble(compressed.Rows[compressed.Rows.Count - 1]["Piezas"].ToString());
                                        double nuevovalor = valorActual + sumar;
                                        compressed.Rows[compressed.Rows.Count - 1]["Piezas"] = nuevovalor;
                                    }
                                }
                                TotalPzs = invoicedataTable.AsEnumerable().Sum(row => row.Field<double>("Piezas"));
                                compressed.Rows[0]["TotalPzs"] = TotalPzs.ToString();
                                compressed.Rows[0]["TotalCantidad"] = invoicedataTable.Rows.Count.ToString();
                                ReportDataSource reportData = new ReportDataSource("DataSet1", compressed);
                                FormReports formReports = new FormReports("..\\..\\InputCompressed.rdlc", reportData);
                                formReports.ShowDialog();
                                this.Cursor = Cursors.Default;
                            }
                            else if (resultado == DialogResult.Cancel)
                            {
                                this.Cursor = Cursors.WaitCursor;
                                DataTable Tableaux = new DataTable();
                                Tableaux = invoicedataTable.Copy();
                                Tableaux.Columns.Add("TotalPzs", typeof(string));
                                Tableaux.Columns.Add("TotalCantidad", typeof(string));
                                TotalPzs = invoicedataTable.AsEnumerable().Sum(row => row.Field<double>("Piezas"));
                                Tableaux.Rows[0]["TotalPzs"] = TotalPzs.ToString();
                                Tableaux.Rows[0]["TotalCantidad"] = invoicedataTable.Rows.Count.ToString();
                                ReportDataSource reportData = new ReportDataSource("DataSet1", Tableaux);
                                FormReports formReports = new FormReports("..\\..\\InputDown.rdlc", reportData);
                                formReports.ShowDialog();
                                this.Cursor = Cursors.Default;
                            }
                        }
                        else
                        {
                            MessageBox.Show("No existe la factura");
                        }
                    }
                    else
                    {
                        MessageBox.Show("La factura no pertenece al cliente o no existe");
                    }

                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dateTimePickerPay_ValueChanged(object sender, EventArgs e)
        {
            textBoxPay.Text = dateTimePickerPay.Value.ToString("dd/MM/yyyy");
        }

        private void dateTimePickerReception_ValueChanged(object sender, EventArgs e)
        {
            textBoxReception.Text = dateTimePickerReception.Value.ToString("dd/MM/yyyy");
        }

        private void dateTimePickerPedimento_ValueChanged(object sender, EventArgs e)
        {
            textBoxPediment.Text = dateTimePickerPedimento.Value.ToString("dd/MM/yyyy");
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            //DialogResult result = MessageBox.Show("Se va a cargar la factura: " + textBoxInvoice.Text + ", durante este proceso no podra agregar ni eliminar productos.¿Desea continuar?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            try
            {
                Task.Run(() =>
                {
                    FormShowQuantity formShowQuantity = new FormShowQuantity(true);
                    formShowQuantity.ShowDialog();
                    this.Invoke((Action)(() =>
                    {
                        // Verificar la respuesta no sea nula
                        if (formShowQuantity.comboBoxRemission.Text != "")
                        {
                            string idclientheader;
                            //textBoxInvoice.Text = formShowQuantity.comboBoxRemission.Text;
                            idclientheader = selectsql.GetIdClientInvoiceHeader(formShowQuantity.comboBoxRemission.Text);
                            if (idclientheader == _idclient.ToString())
                            {
                                textBoxInvoice.Text = formShowQuantity.comboBoxRemission.Text;
                                miDataTable = new DataTable();
                                miDataTable = selectsql.getdatatable(formShowQuantity.comboBoxRemission.Text);
                                if (miDataTable.Rows.Count != 0)
                                {

                                    checkBoxeditar.Enabled = false;
                                    checkBoxImprimir.Enabled = false;
                                    checkBoxinsertar.Enabled = false;
                                    dataGridViewInputs.DataSource = miDataTable;
                                    for (int y = 0; y < dataGridViewInputs.Columns.Count; y++)
                                    {
                                        DataGridViewColumn column = dataGridViewInputs.Columns[y];
                                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                                        dataGridViewInputs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                                    }
                                    //FormPopupWindowLoad();
                                    textBoxNumberrows.Clear();
                                    textBoxNumberrows.Text = dataGridViewInputs.Rows.Count.ToString();
                                    buttonEneble(false);
                                    inicializeButton(true);
                                    inicilizeForm(true);
                                }
                                else
                                {
                                    MessageBox.Show("No existe la factura");
                                }
                            }
                            else
                            {
                                MessageBox.Show("La factura no pertenece al cliente o no existe");
                            }
                        }
                }));
                });                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

      

        private void textBoxSerial_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePickerExpires_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBoxNumberrows_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxProduct_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            { 
                double price;
                double cost;
                double itemsbox;
                textBoxSerial.Clear();
                selectsql.SerialATextBox(textBoxSerial, _idclient, comboBoxProduct.Text);
                textBoxNameProduct.Clear();
                selectsql.ProductsATextBox(textBoxNameProduct, _idclient, comboBoxProduct.Text);
                textBoxCost.Clear();
                selectsql.CostATextBox(textBoxCost, _idclient, comboBoxProduct.Text);
                textBoxParts.Clear();
                selectsql.ItemsPerBoxATextBox(textBoxParts, _idclient, comboBoxProduct.Text);
                textBoxPrice.Clear();
                Double.TryParse(textBoxCost.Text, out cost);
                Double.TryParse(textBoxParts.Text, out itemsbox);
                price = cost * itemsbox;
                textBoxPrice.Text = price.ToString();
                comboBoxContainer.SelectedIndex = 0;

                // Restaurar todos los elementos cuando el TextBox pierde el foco y su texto está vacío
                /*if (string.IsNullOrWhiteSpace(textBox2.Text))
                {
                    comboBoxProduct.Items.Clear();
                    comboBoxProduct.Items.AddRange(eleme.ToArray());
                }*/
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FormPopupWindowLoad()
        {
            FormPopupWindow ventanaEmergente = new FormPopupWindow();

            // Mostrar el formulario emergente como un cuadro de diálogo
            DialogResult resultado = ventanaEmergente.ShowDialog();

            // Verificar la opción seleccionada por el usuario
            if (resultado == DialogResult.OK)
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable compressed = new DataTable();
                compressed = miDataTable.Copy();
                compressed.Columns.Add("Recibio", typeof(string));
                compressed.Columns.Add("TotalPzs", typeof(string));
                compressed.Columns.Add("TotalCantidad", typeof(string));
                compressed.Rows.Clear();
                foreach (DataRow row in miDataTable.Rows)
                {
                    if (serachindatatable(compressed, "Código", row["Código"].ToString()) == false)
                    {
                        DataRow newrow = compressed.NewRow();
                        string idmeasuring;
                        newrow["Código"] = row["Código"].ToString();
                        newrow["NumeroParteCliente"] = row["NumeroParteCliente"].ToString();
                        newrow["Nombre"] = row["Nombre"].ToString();
                        newrow["Piezas"] = row["Piezas"].ToString();
                        idmeasuring = selectsql.GetidMeasuring_unit(_idclient.ToString(), row["Código"].ToString());
                        newrow["Unidad"] = selectsql.GetAbreviationMeasuring_unit(idmeasuring);
                        newrow["Lote"] = row["Lote"].ToString();
                        newrow["Bodega"] = row["Bodega"].ToString();
                        newrow["Factura"] = row["Factura"].ToString();
                        newrow["FechaRecepcion"] = row["FechaRecepcion"].ToString();
                        newrow["FechaPagar"] = row["FechaPagar"].ToString();
                        newrow["Provedor"] = row["Provedor"].ToString();
                        newrow["Pedimento"] = row["Pedimento"].ToString();
                        newrow["Regimen"] = row["Regimen"].ToString();
                        compressed.Rows.Add(newrow);
                    }
                    else
                    {
                        double valorActual = Convert.ToDouble(row["Piezas"]);
                        double sumar = Convert.ToDouble(compressed.Rows[compressed.Rows.Count - 1]["Piezas"].ToString());
                        double nuevovalor = valorActual + sumar;
                        compressed.Rows[compressed.Rows.Count - 1]["Piezas"] = nuevovalor;
                    }
                }
                compressed.Rows[0]["Recibio"] = textBox1.Text;
                compressed.Rows[0]["TotalPzs"] = TotalPzs.ToString();
                compressed.Rows[0]["TotalCantidad"] = miDataTable.Rows.Count.ToString();
                ReportDataSource reportData = new ReportDataSource("DataSet1", compressed);
                FormReports formReports = new FormReports("..\\..\\InputCompressed.rdlc", reportData);
                formReports.ShowDialog();
                this.Cursor = Cursors.Default;
            }
            else if (resultado == DialogResult.Cancel)
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable Tableaux = new DataTable();
                Tableaux = miDataTable.Copy();
                Tableaux.Columns.Add("Recibio", typeof(string));
                Tableaux.Columns.Add("TotalPzs", typeof(string));
                Tableaux.Columns.Add("TotalCantidad", typeof(string));
                Tableaux.Rows[0]["TotalCantidad"] = miDataTable.Rows.Count.ToString();
                Tableaux.Rows[0]["FechaRecepcion"] = dateTimePickerReception.Text;
                Tableaux.Rows[0]["FechaPagar"] = dateTimePickerPay.Text;
                Tableaux.Rows[0]["Recibio"] = textBox1.Text;
                Tableaux.Rows[0]["TotalPzs"] = TotalPzs.ToString();
                ReportDataSource reportData = new ReportDataSource("DataSet1", Tableaux);
                FormReports formReports = new FormReports("..\\..\\InputDown.rdlc", reportData);
                formReports.ShowDialog();
                this.Cursor = Cursors.Default;
            }
        }

        private void buttonAdd_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es Enter o Tab
            if (e.KeyChar == (char)Keys.Enter)
            {

                // Cambiar al siguiente controlador
                buttonAdd_Click(sender, e);
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

        private void dataGridViewInputs_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DataGridView.HitTestInfo hit = dataGridViewInputs.HitTest(e.X, e.Y);
                if (hit.Type == DataGridViewHitTestType.Cell)
                {
                    if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
                    {
                        dataGridViewInputs.Rows[hit.RowIndex].Selected = !dataGridViewInputs.Rows[hit.RowIndex].Selected;
                    }
                    else if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
                    {
                        int startRow = Math.Min(dataGridViewInputs.CurrentCell.RowIndex, hit.RowIndex);
                        int endRow = Math.Max(dataGridViewInputs.CurrentCell.RowIndex, hit.RowIndex);

                        for (int i = startRow; i <= endRow; i++)
                        {
                            dataGridViewInputs.Rows[i].Selected = true;
                        }
                    }
                    else
                    {
                        dataGridViewInputs.ClearSelection();
                        dataGridViewInputs.Rows[hit.RowIndex].Selected = true;
                    }
                }
            }
        }
    }
}
