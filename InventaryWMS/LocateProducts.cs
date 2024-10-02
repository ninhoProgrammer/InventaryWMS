using Microsoft.Reporting.WinForms;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.UI.WebControls.WebParts;
using System.Windows.Forms;
using ZXing;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace InventaryWMS
{
    public partial class LocateProducts : Form
    {        
        private SelectSQL selectSQL = new SelectSQL();        
        private UpdateSQL updateSQL = new UpdateSQL();
        
        
        private List<Warehouse> warehouses = new List<Warehouse>();        
        private Dictionary<string, Invoice_items> serialNumbers = new Dictionary<string, Invoice_items>();
        private Dictionary<string, WarehouseRack_Position> positionsName = new Dictionary<string, WarehouseRack_Position>();
        private List<WarehouseRack> virtualRacksList = new List<WarehouseRack>();


        private int typeAction = -1;
        private Main main;

        private List<int> idPositionsList = new List<int>();
        private List<int> idInvoiceItemsList = new List<int>();
        private bool rowsValidationError = false;

        private DataTable reportTable;
        private string reportPath = "..\\..\\Ubicacion.rdlc";
        private string username;

        public LocateProducts()
        {
            InitializeComponent();
        }

        private void LocateProducts_Load(object sender, EventArgs e)
        {
            loadWarehousesList();
        }

        public LocateProducts(Main main)
        {
            this.main = main;
            InitializeComponent();
        }

        //evento DragEnter para permitir que se suelten archivos.
        private void targetDataGrid_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private void loadWarehousesList()
        {            
            Task.Run(() =>
            {
                warehouses = selectSQL.GetWarehousesList("San Luis Potosí");                 
                this.Invoke((Action)(() =>
                {                                                            
                    List<string> warehouseNames = warehouses.Select(warehouse => warehouse.NAME).ToList();                    
                    
                    cbDestino.SelectedIndexChanged -= cbDestino_SelectedIndexChanged;
                    // Cambiar el DataSource
                    cbDestino.DataSource = warehouseNames;
                    cbDestino.SelectedIndex = -1;                    
                    cbDestino.SelectedIndexChanged += cbDestino_SelectedIndexChanged;   
                    loadCurrentUserName();

                }));
            });
        }   
        
        private void loadCurrentUserName()
        {
            Task.Run(() =>
            {
                var user = selectSQL.GetUser(main._idUser);
                Invoke((Action)(() =>
                {
                    //Si no se pudo obtener el nombre, asigna un default value
                    username = user != null ? user : "Unknown user";
                    whListSpinner.Visible = false;
                    pasteButton.Enabled = false;
                    targetDataGrid.AllowDrop = false;
                    pbInfo.AllowDrop = false;
                    labelInfo.AllowDrop = false;
                    cbDestino.Enabled = true;
                }));
            });
        }

        private int findWarehouseID(string name)
        {
            Warehouse result = warehouses.FirstOrDefault(elem => elem.NAME == name);
            return result.IDWAREHOUSES;
        }

        //evento DragDrop para cargar el archivo Excel en tu DataGrid.
        private void targetDataGrid_DragDrop(object sender, DragEventArgs e)
        {
            pasteSpinner.Visible = true;
            bool error = false;
            Task.Run(() =>
            {
                var files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files.Length > 0)
                {                    
                    string path = files[0];
                    string connectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=Excel 12.0;", path);
                    using (OleDbConnection conn = new OleDbConnection(connectionString))
                    {
                        conn.Open();
                        DataTable dtSchema = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                        if (dtSchema == null)
                        {
                            error = true;
                        }
                        else
                        {
                            List<string> excelSheets = new List<string>();
                            foreach (DataRow row in dtSchema.Rows)
                            {
                                excelSheets.Add(row["TABLE_NAME"].ToString());
                            }

                            //nombre de la primera hoja
                            string firstSheetName = excelSheets[0];
                            string query = $"SELECT * FROM [{firstSheetName}]";
                            using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn))
                            {
                                var ds = new System.Data.DataSet();
                                adapter.Fill(ds);
                                Invoke((Action)(() =>
                                {
                                    if (ds.Tables.Count > 0)
                                    {
                                        Clipboard.SetText(DataTableToString(ds.Tables[0]));
                                        if (!error)
                                        {
                                            typeAction = 1;
                                            PasteClipboardValue();
                                        }
                                        else
                                        {
                                            pasteSpinner.Visible = false;
                                            showFormatErrorMessage();
                                        }
                                    }
                                    else
                                    {
                                        pasteSpinner.Visible = false;
                                        showFormatErrorMessage();
                                    }                                    
                                }));                                
                            }
                        }                        
                    }

                }                
            });                   
        }
        
        private void setDataGridStyle()
        {
            foreach(DataGridViewColumn col in targetDataGrid.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }   
        
        private void initDataGrid()
        {
            clearCurrentTable();

            // Crear las columnas
            DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
            column.Name = "Serial";//Encabezado de columna
            targetDataGrid.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.Name = "Ubicación";//Encabezado de columna
            targetDataGrid.Columns.Add(column);

        }
        

        private async void PasteClipboardValue()
        {
            // Comprobar si hay algo en el portapapeles para pegar en el DataGridView
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text))
            {                                

                string clipboard = Clipboard.GetText();
                string[] splitRows = clipboard.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

                if(splitRows.Count() > 0)
                {
                    string[] splitCells = splitRows[0].Split(new[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);

                    int cont = 0;
                    while (splitCells.Length != 2 && cont < splitRows.Count())
                    {
                        splitCells = splitRows[cont++].Split(new[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    }


                    if (splitCells.Length == 2 && cont < splitRows.Count())
                    {
                        pasteButton.Enabled = false;                                              
                        
                        changeButtonsState(true);
                        saveBtn.Enabled = true;
                        if (!pasteSpinner.Visible)
                        {
                            pasteSpinner.Visible = true;
                        }
                        

                        virtualRacksList = await selectSQL.GetRacksListByWarehouse(findWarehouseID(cbDestino.Text), 2, main._idClient);
                        
                        initDataGrid();
                        var err = false;

                        // Agregar las filas
                        for (int i = cont; i < splitRows.Count(); i++)
                        {
                            splitCells = splitRows[i].Split(new[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
                            DataGridViewRow row = new DataGridViewRow();
                            for (int j = 0; j < splitCells.Count(); j++)
                            {
                                if (!string.IsNullOrWhiteSpace(splitCells[j]))
                                {
                                    DataGridViewCell cell = new DataGridViewTextBoxCell();
                                    if(j == 0) //Numero serial
                                    {
                                        var serialNumber = formatSerialNumber(splitCells[j]);
                                        cell.Value = serialNumber;
                                    }
                                    if(j == 1)//Ubicacion
                                    {
                                        var positionName = formatPositionName(splitCells[j]);
                                        cell.Value = positionName;
                                    }                                    
                                    row.Cells.Add(cell);
                                }
                            }
                            if (row.Cells.Count > 0 && row.Cells.Count <= 2)
                            {
                                targetDataGrid.Rows.Add(row);
                            }
                            else if (row.Cells.Count > 2)
                            {
                                err = true;
                            }
                        }

                        pasteSpinner.Visible = false;

                        if (err == false)
                        {
                            targetDataGrid.ClearSelection();
                            setDataGridStyle();
                            if (cbDestino.SelectedIndex >= 0)
                            {
                                saveBtn.Enabled = true;
                            }
                        }
                        else
                        {
                            clearButton.PerformClick();
                            showFormatErrorMessage();
                        }

                    }
                    else
                    {
                        showFormatErrorMessage();
                    }
                }
                else
                {
                    showFormatErrorMessage();
                }
            }
            else
            {
                MessageBox.Show("No hay datos en el portapapeles", "Reis WMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void showFormatErrorMessage()
        {
            string errorText = "La tabla de datos no tiene un formato válido, asegúrese que tenga dos columnas con el número Serial y Ubicación respectivamente.";
            string msgTitle = "Formato incorrecto";

            if(typeAction == 1)//Drop file
            {
                errorText += "\n\nNota: \nAntes de arrastrar un archivo de Excel, guarde los cambios para que el sistema pueda leerlos.";
            }

            MessageBox.Show(errorText, msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public bool evaluateTableHeader(string title, string inputTitle)
        {
            inputTitle = removeAccents(inputTitle.Trim().ToLower());
            title = removeAccents(title.ToLower());

            return title.Contains(inputTitle);
        }

        //elimina acentos ortograficos de la cadena
        public string removeAccents(string input)
        {
            string normalized = input.Normalize(NormalizationForm.FormD);
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < normalized.Length; i++)
            {
                char c = normalized[i];
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }
        /**
           Revisa si hay columnas generadas por OLE DB
        */
        public bool checkOLEdbColumnNameFormat(string columnName)
        {
            // La expresión regular coincide con una cadena que comienza con "F", seguida de cualquier número entero positivo.
            return Regex.IsMatch(columnName, "^F[1-9][0-9]*$");
        }

        public string DataTableToString(DataTable dt)
        {
            
            /*
             * Primero limpiar nombres de columnas (OLE DB usa como nombre de columna el encabezado de la columna de la hoja en excel en algunos casos)
            */
            string empty = " ";
            foreach (DataColumn column in dt.Columns)
            {
                if (column.ColumnName.Length < 6 && checkOLEdbColumnNameFormat(column.ColumnName))
                {
                    //Los nombres de columna que no nos interesan se ponen en blanco(No se pueden repetir, por eso aumenta el numero de espacios)
                    column.ColumnName = empty;
                    empty += " ";
                }                
            }

            StringBuilder sb = new StringBuilder();
            //Obtener nombres de columna (OLE DB considera el 1er renglon como encabezado)
            IEnumerable<string> columnNames = dt.Columns.Cast<DataColumn>()
                .Where(column => !string.IsNullOrWhiteSpace(column.ColumnName))
                .Select(column => column.ColumnName);            

            sb.AppendLine(string.Join("\t", columnNames));

            foreach (DataRow row in dt.Rows)
            {
                IEnumerable<string> fields = row.ItemArray.Select(field => field.ToString());
                sb.AppendLine(string.Join("\t", fields));
            }

            return sb.ToString();
        }

        /*
         * Validar que:
         * El numero serial exista
         * El nombre de la posicion exista         
         *          
         */
        private void validateDataTable()
        {            
            targetDataGrid.ClearSelection();
            int idWarehouse = findWarehouseID(cbDestino.Text);
            statusLabel.Visible = true;
            spinnerStatus.Visible = true;
            Task.Run((Action)( async() =>
            {
                //Obtener lista de seriales sin ubicar aun
                var tempDictionary1 = await selectSQL.GetSerialNumbersListPending();

                //Obtener lista de seriales ubicados en rack/bahia
                 var tempDictionary2 = await selectSQL.GetSerialNumbersListLocated(idWarehouse);

                foreach (KeyValuePair<string, Invoice_items> item in tempDictionary2)
                {
                    if (!tempDictionary1.ContainsKey(item.Key))
                    {
                        tempDictionary1.Add(item.Key, item.Value);
                    }
                }

                serialNumbers = tempDictionary1;
                //Obtener lista de nombres de ubicaciones

                var positionsDict1 = await selectSQL.GetBahiaPositionsByWarehouseAndClient(idWarehouse,main._idClient);

                var positionsDict2 = await selectSQL.GetPositionsNameByWarehouse(idWarehouse);

                foreach (KeyValuePair<string, WarehouseRack_Position> item in positionsDict2)
                {
                    if (!positionsDict1.ContainsKey(item.Key))
                    {
                        positionsDict1.Add(item.Key, item.Value);
                    }
                }

                positionsName = positionsDict1;   

                Invoke((Action)(() =>
                {                    
                    compareDataTable();               
                }));
            }));                                    
        }                

        private void compareDataTable()
        {   
            idInvoiceItemsList.Clear();
            idPositionsList.Clear();
            
            evaluateSerialNumbersAndPositions(idInvoiceItemsList, idPositionsList);

            updateRackPositions();

        }

        private void evaluateSerialNumbersAndPositions(List<int> idInvoiceItemsList, List<int> idPositionsList)
        {
            bool res = false;
            int idInvoice = 0, idPosition = 0;

            reportTable = generateReportTable();            


            foreach (DataGridViewRow row in targetDataGrid.Rows)
            {
                DataRow rowRPT = reportTable.NewRow();                

                var serial = row.Cells[0].Value;

                if (serial != null && serialNumbers.TryGetValue(serial.ToString(), out Invoice_items item)) //evalua serial
                {
                    row.Cells[0].Style = setValidCellStyle();
                    idInvoice = item.idInvoice;
                    res = false;
                    rowRPT["serialNumber"] = serial.ToString();                    
                }
                else
                {
                    row.Cells[0].Style = setNotValidCellStyle();
                    res = true; //hubo un error
                    rowsValidationError = true;                    
                }

                //Evaluar existencia de ubicacion
                var position = row.Cells[1].Value;
                if (position != null && positionsName.TryGetValue(position.ToString(), out WarehouseRack_Position pos))
                {
                    row.Cells[1].Style = setValidCellStyle();
                    idPosition = pos.idPosition;
                    rowRPT["ubicacion"] = position.ToString();                    
                }
                else
                {
                    row.Cells[1].Style = setNotValidCellStyle();
                    res = true; //hubo un error
                    rowsValidationError = true;                    
                }                

                if (!res)//Solo las tuplas de datos sin error se guardan, las demas se quedan
                {
                    rowRPT["fechaUbicacion"] = DateTime.Now;
                    rowRPT["userName"] = username;
                    idInvoiceItemsList.Add(idInvoice);
                    idPositionsList.Add(idPosition);
                    reportTable.Rows.Add(rowRPT);
                }
                
            }            
        }

        public string formatSerialNumber(string numSerial)
        {                        
            if (numSerial.Length != 16 || numSerial.Count(c => c == '-') > 0)
            {
                // Si la longitud no es 6 o ya contiene guiones, devolver el número serial tal cual.
                return numSerial;
            }

            // Insertar guiones cada dos posiciones.
            return string.Format("{0}-{1}", numSerial.Substring(0, 12), numSerial.Substring(12, 4));
        }

        public string formatPositionName(string namePosition)
        {
            // Si la longitud no es 6 o ya contiene guiones, devolver el nombre tal cual.
            if (namePosition.Length != 6 || namePosition.Count(c => c == '-') > 0)
            {                
                return namePosition;
            }

            //Si es una bahia devolver el nombre tal cual
            if (isBahiaName(namePosition))
            {
                return namePosition;
            }
            // Insertar guiones cada dos posiciones.
            return string.Format("{0}-{1}-{2}", namePosition.Substring(0, 2), namePosition.Substring(2, 2), namePosition.Substring(4, 2));
        }

        //es necesario que busque para todos los clientes?
        private bool isBahiaName(string name)
        {
            var result = virtualRacksList.FirstOrDefault(elem => elem.name == name);
            if (result == null)
                return false;
            else return true;
        }


        private int removeInsertedRegisters()
        {
            int total = 0;
            // Lista para almacenar las filas que deben ser eliminadas
            List<DataGridViewRow> rowsToRemove = new List<DataGridViewRow>();
            
            foreach (DataGridViewRow row in targetDataGrid.Rows)
            {
                bool remove = true;
                foreach (DataGridViewCell cell in row.Cells)
                {                    
                    if (cell.Style.BackColor == Color.FromArgb(255, 134, 134))
                    {                                                
                        remove = false;
                        break;
                    }
                }
                if (remove)
                {
                    rowsToRemove.Add(row);
                }
            }

            total = rowsToRemove.Count;
            // Elimina las filas identificadas de la lista
            foreach (DataGridViewRow rowToRemove in rowsToRemove)
            {
                targetDataGrid.Rows.Remove(rowToRemove);
            }
            return total;
        }
        

        private DataGridViewCellStyle setNotValidCellStyle()
        {
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.BackColor = Color.FromArgb(255, 134, 134); //No válida                              
            return style;
        }
        

        private DataGridViewCellStyle setValidCellStyle()
        {
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.BackColor = SystemColors.HighlightText; //válida                              
            return style;
        }


        private void clearCurrentTable()
        {
            labelInfo.Visible = false;
            pbInfo.Visible = false;

            if(targetDataGrid.DataSource != null)
            {
                targetDataGrid.DataSource = null;
            }

            targetDataGrid.Rows.Clear();
            targetDataGrid.Columns.Clear();
        }

        private void setEditMode(bool value)
        {
            clearButton.Enabled = value;
            editButton.Visible = !value;
            okButton.Visible = value;
            okButton.Enabled = value;
            deleteRowButton.Enabled = value;
            deleteRowButton.Visible = value;
            saveBtn.Enabled = !value;
            if (value)
            {
                targetDataGrid.EditMode = DataGridViewEditMode.EditOnEnter;
            }
            else
            {
                targetDataGrid.EditMode = DataGridViewEditMode.EditProgrammatically;
            }
        }

        private void changeButtonsState(bool state)
        {
            editButton.Enabled = state;
            editButton.Visible = state;                             
            clearButton.Enabled = state;
        }        

        private void pasteButton_Click(object sender, EventArgs e)
        {
            typeAction = 2;
            PasteClipboardValue();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            pbInfo.Visible = true;
            labelInfo.Visible = true;
            if(targetDataGrid.DataSource != null)
            {
                targetDataGrid.DataSource = null;
            }
            targetDataGrid.Rows.Clear();
            targetDataGrid.Columns.Clear();
            targetDataGrid.EditMode = DataGridViewEditMode.EditProgrammatically;
            okButton.Enabled = false;
            okButton.Visible = false;
            deleteRowButton.Enabled = false;
            deleteRowButton.Visible = false;
            pasteButton.Enabled = true;            
            saveBtn.Enabled = false;            
            changeButtonsState(false);
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            setEditMode(true);            
        }

        private async void okButton_Click(object sender, EventArgs e)
        {
            editButton.Visible = true;
            editButton.Enabled= true;

            deleteRowButton.Enabled = false;
            deleteRowButton.Visible = false;

            okButton.Visible = false;
            targetDataGrid.EditMode= DataGridViewEditMode.EditProgrammatically;
            targetDataGrid.ClearSelection();

            pasteSpinner.Visible = true;
            await formatNewValues();
            pasteSpinner.Visible = false;

            saveBtn.Enabled = true;            
        }

        private async Task<int> formatNewValues()
        {
            virtualRacksList = await selectSQL.GetRacksListByWarehouse(findWarehouseID(cbDestino.Text), 2, main._idClient);

            foreach (DataGridViewRow row in targetDataGrid.Rows)
            {
                if (row.Cells.Count == 2)
                {
                    var serial = row.Cells[0].Value;
                    var position = row.Cells[1].Value;

                    if (!string.IsNullOrWhiteSpace((string)serial))
                    {
                        var serialNumber = formatSerialNumber((string)serial);
                        row.Cells[0].Value = serialNumber;
                    }

                    if (!string.IsNullOrWhiteSpace((string)position))
                    {
                        var positionName = formatPositionName((string)position);
                        row.Cells[1].Value = positionName;
                    }
                }
            }
            return 0;
        }
        

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (cbDestino.SelectedIndex != -1)
            {
                validateDataTable();
            }
            else
            {
                MessageBox.Show("Seleccione ubicación");
            }
        }
        

        private void cbDestino_SelectedIndexChanged(object sender, EventArgs e)
        {
            clearButton.Enabled = true;
            addRowBtn.Enabled = true;
            pasteButton.Enabled = true;
            targetDataGrid.AllowDrop = true;
            pbInfo.AllowDrop = true;
            labelInfo.AllowDrop = true;            
        }               

        private void deleteRowButton_Click(object sender, EventArgs e)
        {
            if (targetDataGrid.Rows.Count > 0 && targetDataGrid.CurrentRow.Index != -1)
            {
                targetDataGrid.Rows.RemoveAt(targetDataGrid.CurrentRow.Index);
            }
            if(targetDataGrid.Rows.Count == 0)
            {
                clearButton.PerformClick();
            }
        }              

        private void updateRackPositions()
        {
            var res = false;
            Task.Run(() =>
            {
                if (idPositionsList.Count == idInvoiceItemsList.Count)
                {
                    res = updateSQL.updateStoragePosition(idInvoiceItemsList, idPositionsList);
                }
                Invoke((Action)(() =>
                {
                    statusLabel.Visible = false;
                    spinnerStatus.Visible = false;
                    if (res)
                    {                        
                        var insertedRows = removeInsertedRegisters();                        
                        if (!rowsValidationError)
                        {
                            MessageBox.Show("Los datos se guardaron correctamente.", "WMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if(insertedRows > 0)
                            {
                                openReportForm();
                            }
                            clearButton.PerformClick();                            
                        }
                        else
                        {
                            targetDataGrid.ClearSelection();
                            MessageBox.Show("Algunos registros no se pudieron guardar, los datos no existen en el sistema o no corresponden al almacén seleccionado, asegúrese de que estén escritos correctamente.\n\nNota: \nEl reporte muestra los datos que se guardaron correctamente. Los registros incorrectos quedan pendientes en la tabla de ubicación.", "Registro incompleto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            if (insertedRows > 0)
                            {
                                openReportForm();
                            }
                            rowsValidationError = false;
                        }
                                               
                    }
                    //Es necesario volver a mostrar mensaje de que hubo error de conexion?
                }));
            });            
            
        }

        private DataTable generateReportTable()
        {
            DataTable dt = new DataTable();

            // Agregar columnas a la tabla debe coincidir exactamente a la BD
            dt.Columns.Add("serialNumber", typeof(string));
            dt.Columns.Add("ubicacion", typeof(string));
            dt.Columns.Add("fechaUbicacion", typeof(DateTime));
            dt.Columns.Add("estado", typeof(string));
            dt.Columns.Add("userName", typeof(string)); 
            
            return dt;
        }       

        private void openReportForm()
        {
            ReportDataSource reportData = new ReportDataSource("DataSet1", reportTable);
            FormReports formReports = new FormReports(reportPath, reportData);
            formReports.ShowDialog();
        }

        private void addRowBtn_Click(object sender, EventArgs e)
        {
            setEditMode(true);
            if (targetDataGrid.Columns.Count == 0)
            {
                initDataGrid();
                setDataGridStyle();
            }            
            targetDataGrid.Rows.Insert(0,1);
            pasteButton.Enabled = false;            
        }
    }    
}
