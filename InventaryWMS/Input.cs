using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
        #region Variable and Objects
        static string imagenClick = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\\..\\Resources\grupoabg.png"));
        private PrintDocument printDocument1 = new PrintDocument();
        List<string> eleme { get; set; }
        SelectSQL selectsql = new SelectSQL();
        InsertSQL insertsql = new InsertSQL();
        DateTime currentdate = DateTime.Today;
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
            // 1. Inicialización de variables y datos
            inicilizeForm(false);
            miDataTable = new DataTable();
            eleme = new List<string>();
            valueserial = 0;
            discount = 0.0;
            idwarehouse = 0;
            etiquetaActual = 0;
            SelectedRowNumber = -1;

            // 2. Inicialización de la interfaz de usuario (UI)
            SetDefaultControlValues();
            ConfigureDataGridView();
            ConfigurePrintDocument();

            // 3. Llenar los controles con datos
            // Estas operaciones deben ser rápidas. Si no lo son, se deben mover a un método asíncrono.
            fillComboBox();
            fillDataGrid();

            // 4. Configurar el estado final de los botones
            buttonEneble(false);
            inicializeButton(false);
            buttonAdd.Enabled = true;
        }
        #endregion
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
            miDataTable.Columns.Add("NumeroSerie", typeof(string));
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
            
            selectsql.IdProductsAComboBox(comboBoxProduct, _idclient, eleme);
            //selectsql.ProvidersAComboBox(comboBoxProviders, _idclient);
            comboBoxProduct.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBoxProduct.AutoCompleteSource = AutoCompleteSource.ListItems;
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
            comboBoxLocation.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
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
            // 1. Validar la factura
            if (selectsql.searchInvoice(textBoxInvoice.Text))
            {
                MessageBox.Show("La factura ya existe.");
                textBoxInvoice.Clear();
                return;
            }

            // 2. Validar la cantidad
            if (!int.TryParse(textBoxBox.Text, out int quantity))
            {
                MessageBox.Show("Faltan datos o la cantidad no es válida.");
                return;
            }

            // 3. Obtener datos del producto y clientes
            var productInfo = new ProductInfo(comboBoxProduct.Text);
            string prefixClient = selectsql.GetPrefixClients(_idclient);

            // 4. Llenar la tabla y crear filas
            CreateAndFillRows(quantity, productInfo, prefixClient);

            // 5. Actualizar la interfaz de usuario
            UpdateUI();

            // 6. Imprimir etiquetas si es necesario
            if (checkBoxImprimir.Checked)
            {
                printTag((DataTable)dataGridViewInputs.DataSource);
            }

            // 7. Calcular y mostrar totales
            CalculateAndDisplayTotals();

            // 8. Limpiar y habilitar controles
            CleanAll();
            buttonEneble(true);
            inicializeButton(true);
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
                                                .Sum(row => double.Parse(row.Field<string>("Costo")
                                                .TrimStart('$')));
                        TotalPzs = miDataTable.AsEnumerable()
                                                    .Sum(row => double.Parse(row.Field<string>("Piezas")
                                                    .TrimStart('$')));
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
            // Mostrar confirmación al usuario
            if (MessageBox.Show("¿Está seguro de Asentar?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return; // Salir si el usuario no confirma
            }

            spinner.Enabled = true;

            try
            {
                // 1. Obtener datos iniciales y validaciones
                var invoiceData = new InvoiceData(
                    selectsql.GetIdOnShortNameWarehoses(comboBoxLocation.Text),
                    selectsql.GetIdSession(_iduser.ToString()),
                    currentdate,
                    textBoxInvoice.Text,
                    textBoxSubtotal.Text,
                    textBoxDiscount2.Text,
                    textBoxTax.Text,
                    textBoxTotal.Text, 
                    textBox1.Text
                );

                // 2. Insertar en la base de datos dentro de una transacción
                bool success = InsertAllInvoiceData(invoiceData);

                // 3. Manejar el resultado de la operación
                if (success)
                {
                    HandleSuccess(invoiceData.InvoiceNumber);
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores centralizado
                MessageBox.Show($"Ocurrió un error inesperado: {ex.Message}");
            }
            finally
            {
                spinner.Enabled = false;
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
                                    newrow["NumeroSerie"] = row["NumeroSerie"].ToString();
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
                                        newrow["NumeroSerie"] = row["NumeroSerie"].ToString();
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
                string[] partProduct = comboBoxProduct.Text.Split('|');
                textBoxSerial.Clear();
                // Pseudocódigo:
                // 1. Localizar la línea: selectsql.SerialATextBox(textBoxSerial, _idclient, partProduct[1]);
                // 2. Antes de pasar partProduct[1], quitarle los espacios en blanco con .Trim().
                // 3. Reemplazar la línea original por la nueva.

                selectsql.SerialATextBox(textBoxSerial, _idclient, partProduct[1].Trim());
                textBoxNameProduct.Clear();
                selectsql.ProductsATextBox(textBoxNameProduct, _idclient, partProduct[1].Trim());
                textBoxCost.Clear();
                selectsql.CostATextBox(textBoxCost, _idclient, partProduct[1].Trim());
                textBoxParts.Clear();
                selectsql.ItemsPerBoxATextBox(textBoxParts, _idclient, partProduct[1].Trim());
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
                        newrow["NumeroSerie"] = row["NumeroSerie"].ToString();
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        // Reemplaza el uso de 'Transaction' por 'SqlTransaction' de System.Data.SqlClient.
        // Modifica el método InsertAllInvoiceData para usar una transacción de SQL Server.

        private bool InsertAllInvoiceData(InvoiceData data)
        {
            using (SqlConnection conn = DBConections.GetConnection())
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // Insertar el encabezado de la factura
                    int invoiceHeaderId = insertsql.InsertInvoiceHeader(transaction, data.InvoiceHeaderParameters);

                    // Insertar el pallet de la factura
                    int invoicePalletId = insertsql.InsertInvoicePallet(transaction, invoiceHeaderId, data.InvoiceNumber);

                    // Insertar los ítems y el inventario
                    InsertInvoiceItemsAndInventory(transaction, invoiceHeaderId, invoicePalletId);

                    // Confirmar transacción si todo fue bien
                    transaction.Commit();
                    return true;
                }
                catch (SqlException sqlEx)
                {
                    transaction.Rollback();
                    MessageBox.Show($"Error en la base de datos: {sqlEx.Message}");
                    return false;
                }
            }
        }

        private void InsertInvoiceItemsAndInventory(SqlTransaction transaction, int invoiceHeaderId, int invoicePalletId)
        {
            foreach (DataRow row in miDataTable.Rows)
            {
                var itemData = new InvoiceItemData(row, _idclient);
                var idSection = selectsql.GetIdSession(_iduser.ToString());
                // Insertar el ítem de la factura
                int invoiceItemId = insertsql.InsertInvoiceItem(transaction, invoiceHeaderId, invoicePalletId, itemData, idSection);

                // Insertar en el inventario
                insertsql.InsertInventory(transaction, invoiceItemId, itemData.Pieces);
            }
        }

        private void HandleSuccess(string invoiceNumber)
        {
            Cursor = Cursors.Default;
            MessageBox.Show("Se ingresó correctamente.");
            insertsql.SaveToBinnacle($"Ingreso con factura: {invoiceNumber} creado con éxito");
            buttonEneble(false);
            lastserial = selectsql.GetLastSerial();
            int.TryParse(lastserial, out valueserial);
            FormPopupWindowLoad();
        }

        //--- Clases de Datos para mayor claridad ---
        
        

        private void CreateAndFillRows(int quantity, ProductInfo productInfo, string prefixClient)
        {
            for (int i = 0; i < quantity; i++)
            {
                var newRow = miDataTable.NewRow();
                PopulateRowData(newRow, productInfo, prefixClient);
                AddRowToDataTable(newRow);
            }
        }

        private void PopulateRowData(DataRow row, ProductInfo productInfo, string prefixClient)
        {
            row["Código"] = productInfo.Code;
            row["Nombre"] = textBoxNameProduct.Text;
            row["Costo"] = textBoxCost.Text;
            row["Precio"] = textBoxPrice.Text;
            row["Cantidad"] = 1;
            row["NumeroSerie"] = textBoxSerial.Text;
            row["Caduca"] = dateTimePickerExpires.Value.ToString("yyyy-MM-dd HH:mm:ss");
            row["Serie"] = GenerateSerialNumber(prefixClient);
            row["Pedimento"] = textBoxPedimento.Text;
            row["Ubicación"] = comboBoxLocation.Text;
            row["Lote"] = GetBatchNumber();
            row["Piezas"] = textBoxParts.Text;
            row["Unidad"] = GetMeasuringUnitAbbreviation(productInfo.Code);
            row["Bodega"] = comboBoxStore.Text;
            row["Factura"] = textBoxInvoice.Text;
            row["Provedor"] = comboBoxProviders.Text;
            row["Regimen"] = comboBoxRegimen.Text;
            row["FechaPedimento"] = dateTimePickerPedimento.Value.ToString("yyyy-MM-dd HH:mm:ss");
            row["Contenedor"] = comboBoxContainer.Text;
            row["FechaRecepcion"] = dateTimePickerReception.Value.ToString("yyyy-MM-dd HH:mm:ss");
            row["FechaPagar"] = dateTimePickerPay.Value.ToString("yyyy-MM-dd HH:mm:ss");
            row["Remision"] = textBoxRemission.Text;
            row["Transporte"] = comboBoxTransport.Text;
        }

        private void AddRowToDataTable(DataRow newRow)
        {
            if (miDataTable.Rows.Count > 0 && checkBoxinsertar.Checked && SelectedRowNumber != -1)
            {
                miDataTable.Rows.InsertAt(newRow, SelectedRowNumber + 1);
            }
            else
            {
                miDataTable.Rows.Add(newRow);
            }
        }

        private string GenerateSerialNumber(string prefixClient)
        {
            serial = $"{prefixClient}{currentdate.ToString("yyMMdd")}ABCD-";
            valueserial += 1;
            serial += valueserial.ToString("D4");
            return serial;
        }

        private string GetBatchNumber()
        {
            return string.IsNullOrEmpty(textBoxBatch.Text) ? "S/L" : textBoxBatch.Text;
        }

        private string GetMeasuringUnitAbbreviation(string productCode)
        {
            string idMeasuring = selectsql.GetidMeasuring_unit(_idclient.ToString(), productCode);
            return selectsql.GetAbreviationMeasuring_unit(idMeasuring);
        }

        private void UpdateUI()
        {
            // Lógica para reorganizar y actualizar el DataGridView
            if (miDataTable.Rows.Count > 0 && checkBoxinsertar.Checked && SelectedRowNumber != -1)
            {
                rearrangeTable(SelectedRowNumber, 1, 0);
            }

            dataGridViewInputs.DataSource = miDataTable;
            SetDataGridViewColumns();
            dataGridViewInputs.ClearSelection();
            SelectedRowNumber = -1;
        }

        private void SetDataGridViewColumns()
        {
            foreach (DataGridViewColumn column in dataGridViewInputs.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            dataGridViewInputs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridViewInputs.Columns["Importe"].Visible = false;
        }

        private void CalculateAndDisplayTotals()
        {
            double subtotal = miDataTable.AsEnumerable()
                                       .Sum(row => double
                                       .Parse(row.Field<string>("Costo")
                                       .TrimStart('$')));

            double totalPieces = miDataTable.AsEnumerable()
                                       .Sum(row => double
                                       .Parse(row.Field<string>("Piezas")
                                       .TrimStart('$')));

            double tax = (subtotal * 16) / 100;
            double total = (subtotal - discount) + tax;

            textBoxNumberrows.Text = dataGridViewInputs.Rows.Count.ToString();
            textBoxSubtotal.Text = $"${subtotal:N2}";
            textBoxDiscount2.Text = "$0";
            textBoxTax.Text = $"${tax:N2}";
            textBoxTotal.Text = $"${total:N2}";
        }

        // Clase auxiliar para la información del producto
        public class ProductInfo
        {
            public string Code { get; private set; }
            public string Description { get; private set; }

            public ProductInfo(string combinedText)
            {
                var parts = combinedText.Split('|');
                if (parts.Length > 1)
                {
                    Description = parts[0].Trim();
                    Code = parts[1].Trim();
                }
            }
        }
        //#endregion

        #region Métodos auxiliares para encapsular la lógica de inicialización
        private void SetDefaultControlValues()
        {
            dateTimePickerReception.Text = currentdate.ToString();
            dateTimePickerPay.Text = currentdate.ToString();
            dateTimePickerExpires.Value = DateTime.Now.AddYears(+1);
            comboBoxStore.SelectedIndex = 0;
        }

        private void ConfigureDataGridView()
        {
            dataGridViewInputs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void ConfigurePrintDocument()
        {
            printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
        }
        #endregion

        private void comboBoxProduct_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
