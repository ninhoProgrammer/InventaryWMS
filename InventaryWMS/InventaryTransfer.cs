using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace InventaryWMS
{
    public partial class InventaryTransfer : Form
    {
        private Main mainForm;
        private SelectSQL selectSQL = new SelectSQL();
        private UpdateSQL updateSQL = new UpdateSQL();
        private List<TransferTableRow> currentSearchResult = new List<TransferTableRow>();
        private List<int> freeSpacesFound = new List<int>();
        private List<Warehouse> warehouses = new List<Warehouse>();
        private int requiredPositions = 0;

        public InventaryTransfer()
        {
            InitializeComponent();
        }

        private void InventaryTransfer_Load(object sender, EventArgs e)
        {
            setWindowSize();
            setStyle(resultDataGrid);
            setDefaultSettings();
        }

        public InventaryTransfer(Main mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        private void searchTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                resultDataGrid.Rows.Clear();
                currentSearchResult = selectSQL.GetInventaryByPartNumber(searchTextBox.Text);
                loadResultDataTable();
            }
        }

        private void setDefaultSettings()
        {
            cbNumParte.SelectedIndex = 0;
            cbPartidas.SelectedIndex = 0;
        }

        private void setStyle(DataGridView dt)
        {                                    
            dt.AllowUserToAddRows = false;           
            dt.ColumnHeadersVisible = true;                        
            dt.BorderStyle = BorderStyle.Fixed3D;
            dt.BackgroundColor = SystemColors.ButtonHighlight;
            dt.AllowUserToResizeRows = false;
            dt.AllowUserToOrderColumns = true;
            dt.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            dt.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dt.DefaultCellStyle.SelectionBackColor = Color.Teal;
            dt.DefaultCellStyle.SelectionForeColor = SystemColors.HighlightText;
            dt.Width = panel2.Width - 40;   
            
            transferPropspanel.Location = new Point(20, dt.Location.Y + dt.Height + 15);
            resultDataGrid.ClearSelection();
            
        }

        private void setWindowSize()
        {
            var bounds = Screen.FromControl(this).Bounds;
            this.Width = bounds.Width;
            this.Height = mainForm.getPanelContainerSize().Height;
            this.WindowState = FormWindowState.Normal;            
            this.MinimizeBox = false;
        }

        private void loadResultDataTable()
        {
            int count = 0;
            foreach (TransferTableRow item in currentSearchResult)
            {
                DataGridViewRow row = new DataGridViewRow();

                // Crear las celdas para la fila en base al modelo creado
                row.CreateCells(resultDataGrid);
                row.Cells[0].Value = item.localId;
                row.Cells[1].Value = item.serial;
                if (cbNumParte.SelectedIndex == 0)
                {
                    row.Cells[2].Value = item.partNumberProvider;
                }
                else
                {
                    row.Cells[2].Value = item.partNumberClient;
                }                
                row.Cells[3].Value = item.description;
                row.Cells[4].Value = item.quantity;                
                row.Cells[5].Value = item.clientName;
                row.Cells[6].Value = item.invoice;
                row.Cells[7].Value = item.pedimentoAduanal;
                row.Cells[8].Value = item.expirationDate;
                row.Cells[9].Value = item.externalSerial;
                row.Cells[10].Value = item.batch;
                row.Cells[11].Value = item.rackPositionName;
                row.Cells[12].Value = item.warehouse;

                resultDataGrid.Rows.Add(row);
                count += int.Parse(row.Cells[4].Value.ToString());
            }
            infoCantidad.Text = count.ToString();
            resultDataGrid.ClearSelection();
        }

        private void InventaryTransfer_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            resultDataGrid.Rows.Clear();
            currentSearchResult = selectSQL.GetInventaryByPartNumber(searchTextBox.Text);
            loadResultDataTable();
        }

        private void resultDataGrid_MouseUp(object sender, MouseEventArgs e)
        {
            calcularCantidad();
            displayItemsSource();
        }

        private void displayItemsSource()
        {
            if (resultDataGrid.SelectedRows.Count > 0)
            {
                //Almacen y Posicion del primer elemento seleccionado                
                string sourcePosition = resultDataGrid.SelectedRows[0].Cells[11].Value.ToString();
                string sourceWarehouse = resultDataGrid.SelectedRows[0].Cells[12].Value.ToString();
                
                
                foreach (DataGridViewRow row in resultDataGrid.SelectedRows)
                {
                    if(sourcePosition != row.Cells[11].Value.ToString())//posicion
                    {
                        sourcePosition = "Múltiple";
                        break;
                    }
                }

                foreach (DataGridViewRow row in resultDataGrid.SelectedRows)
                {
                    if (sourceWarehouse != row.Cells[12].Value.ToString()) //almacen
                    {
                        sourceWarehouse = "Múltiple";
                    }
                }

                if(sourceWarehouse != "Múltiple")
                {
                    origenInfo.Text = "Almacén " + sourceWarehouse;

                    if(sourcePosition != "Múltiple")
                    {
                        origenInfo.Text += "   " + sourcePosition;
                    }
                }
                else
                {
                    origenInfo.Text = "Múltiple";
                }
                cbOptionsTransfer.Enabled = true;

            }
            else
            {
                origenInfo.Text = "N/A";
            }
        }

        private void calcularCantidad()
        {
            if(resultDataGrid.SelectedRows.Count > 0)
            {
                int count = 0;
                foreach (DataGridViewRow row in resultDataGrid.SelectedRows)
                {
                    count += int.Parse(row.Cells[4].Value.ToString());
                }                
                cantidadTransfer.Text = count.ToString();
            }
            else
            {
                cantidadTransfer.Text = "0";
            }
        }

        private void cbOptionsTransfer_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadOptionsToTransfer();
        }

        private void loadOptionsToTransfer()
        {
            switch (cbOptionsTransfer.SelectedIndex)
            {
                case 0://Otro almacen
                    displayWarehousesList();
                    break;
                case 1://Salida
                    break;                
            }
        }        

        private void displayWarehousesList()
        {
            Task.Run(() =>
            {
                warehouses = selectSQL.GetWarehousesList("San Luis Potosí");
                this.Invoke((Action)(() =>
                {
                    // Deshabilitar el evento
                    cbDestino.SelectedIndexChanged -= cbDestino_SelectedIndexChanged;

                    List<string> warehouseNames = warehouses.Select(warehouse => warehouse.NAME).ToList();
                    
                    foreach (DataGridViewRow row in resultDataGrid.SelectedRows)
                    {
                        if (warehouseNames.Contains(row.Cells[12].Value.ToString()))
                        {
                            warehouseNames.Remove(row.Cells[12].Value.ToString());
                        }
                    }

                    // Cambiar el DataSource
                    cbDestino.DataSource = warehouseNames;
                    cbDestino.SelectedIndex = -1;
                    cbDestino.Enabled = true;

                    // Habilitar el evento
                    cbDestino.SelectedIndexChanged += cbDestino_SelectedIndexChanged;                     
                }));
            });
        }

        private void setupOutWarehouse()
        {
            //Crear una bahia especial de salidas?
        }

        private void resultDataGrid_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            calcularCantidad();
            displayItemsSource();
        }

        private void cbDestino_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbDestino.SelectedIndex >= 0)
            {
                int id = findWarehouseID(cbDestino.SelectedItem.ToString());
                
                //determinar la cantidad de espacios
                string currentPos = resultDataGrid.SelectedRows[0].Cells[11].Value.ToString();
                List<string> usedPositions = new List<string>();
                usedPositions.Add(currentPos);                

                foreach(DataGridViewRow row in resultDataGrid.SelectedRows)
                {
                    if(!usedPositions.Contains(row.Cells[11].Value.ToString()))
                    {                        
                        usedPositions.Add(row.Cells[11].Value.ToString());
                    }
                }
                requiredPositions = usedPositions.Count;

                searchFreeSpaces(id, requiredPositions);
            }
        }

        private int findWarehouseID(string name)
        {
            Warehouse result = warehouses.FirstOrDefault(elem => elem.NAME == name);
            return result.IDWAREHOUSES;
        }

        private void searchFreeSpaces(int idWarehouse, int numSpaces)
        {
            
            applyChangesBtn.Enabled = false; 
            spinner.Visible = true;
            Task.Run((Action)(() =>
            {
                freeSpacesFound = selectSQL.GetFreePositionsByWarehouse(idWarehouse, numSpaces);

                Invoke((Action)(() =>
                {
                    if(freeSpacesFound.Count == numSpaces)
                    {
                        applyChangesBtn.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("No es posible continuar con la transferencia, seleccione otro almacén", "Sin espacio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        // Deshabilitar el evento
                        cbDestino.SelectedIndexChanged -= cbDestino_SelectedIndexChanged;

                       
                        cbDestino.SelectedIndex = -1;                        

                        // Habilitar el evento
                        cbDestino.SelectedIndexChanged += cbDestino_SelectedIndexChanged;
                    }                    
                    spinner.Visible = false;
                }));
            }));
                        
        }

        private void transferItems()
        {
            //Buscar N espacios vacios
            //para cada uno de los registros de inventario a transferir, actualizar el id de la posicion con el nuevo encontrado
            if(freeSpacesFound.Count == requiredPositions)
            {
                spinner2.Visible = true;
                Task.Run((Action)(() =>
                {
                    int i = 0;
                    foreach (DataGridViewRow row in resultDataGrid.SelectedRows)
                    {
                        int id = getIdInventoryFromCurrentSearch((int)row.Cells[0].Value);
                        updateSQL.updateInventory(id, freeSpacesFound[i]);
                    }
                    Invoke((Action)(() =>
                    {
                        spinner2.Visible=false;
                        MessageBox.Show("Se realizo la transferencia");

                        cbOptionsTransfer.SelectedIndexChanged -= cbOptionsTransfer_SelectedIndexChanged;
                        cbOptionsTransfer.SelectedIndex = -1;
                        cbOptionsTransfer.SelectedIndexChanged += cbOptionsTransfer_SelectedIndexChanged;

                        // Deshabilitar el evento
                        cbDestino.SelectedIndexChanged -= cbDestino_SelectedIndexChanged;
                        cbDestino.SelectedIndex = -1;
                        // Habilitar el evento
                        cbDestino.SelectedIndexChanged += cbDestino_SelectedIndexChanged;

                        applyChangesBtn.Enabled = false;
                        cantidadTransfer.Text = "0";

                        //Actualizar informacion visible al usuario
                        resultDataGrid.Rows.Clear();
                        currentSearchResult = selectSQL.GetInventaryByPartNumber(searchTextBox.Text);
                        loadResultDataTable();

                    }));
                }));
            }
        }

        private int getIdInventoryFromCurrentSearch(int localId)
        {
            TransferTableRow result = currentSearchResult.FirstOrDefault(elem => elem.localId == localId);
            return result.idInventory;
        }

        private void applyChangesBtn_Click(object sender, EventArgs e)
        {
            transferItems();
        }
    }
}
