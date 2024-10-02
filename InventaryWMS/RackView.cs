using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventaryWMS
{
    public partial class RackView : Form
    {
        private SelectSQL selectSQL = new SelectSQL();
        private UpdateSQL updateSQL = new UpdateSQL();
        WarehouseRack currentRack;
        Warehouse currentWarehouse;
        List<WarehouseRack_Position> rackPositions = new List<WarehouseRack_Position>();
        List<DataGridViewCell> changedCells = new List<DataGridViewCell>();
        Main mainForm;

        int totalPositions = 0, usedPositions = 0, porcentajeUso = 0;


        public RackView()
        {
            InitializeComponent();
        }

        public RackView(Main mainForm, WarehouseRack rack, Warehouse warehouse)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            currentRack = rack;
            currentWarehouse = warehouse;
            if(rack.type == 1)
            {
                rackName.Text = "Rack " + rack.name;
            }
            else if(rack.type == 2)
            {
                rackName.Text = "Bahía " + rack.name;
            }
            warehouseNameLabel.Text = "Almacén " + warehouse.SHORT_NAME;
        }

        private void RackView_Load(object sender, EventArgs e)
        {
            setWindowSize();
            setStyle(rackGrid);
            setOptionsState(false);
            fetchRackPositions(currentRack.IDRACK);            
        }

        private void setWindowSize()
        {
            var bounds = Screen.FromControl(this).Bounds;
            this.Width = bounds.Width;
            this.Height = mainForm.getPanelContainerSize().Height;
            this.WindowState = FormWindowState.Normal;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void setStyle(DataGridView dt)
        {
            rackGrid.ColumnCount = currentRack.totalPositions / currentRack.levels;
            dt.EditMode = DataGridViewEditMode.EditProgrammatically;
            dt.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dt.AllowUserToAddRows = false;
            dt.RowHeadersVisible = true;
            dt.ColumnHeadersVisible = true;
            dt.RowHeadersWidth = 60;
            dt.ColumnHeadersHeight = 20;
            dt.BorderStyle = BorderStyle.Fixed3D;
            dt.BackgroundColor = SystemColors.ButtonHighlight;
            dt.AllowUserToResizeRows = false;
            dt.AllowUserToOrderColumns = false;
            dt.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            dt.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dt.DefaultCellStyle.SelectionBackColor = SystemColors.Highlight;
            dt.DefaultCellStyle.SelectionForeColor = SystemColors.HighlightText;

            changedCellsPanel.Width = panel2.Width - 80;

            setColumnWidth();
        }

        private void setColumnWidth()
        {
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.Font = new Font("Bahnschrift Light SemiCondensed", 8.25F);
            style.ForeColor = Color.Transparent;
            foreach (DataGridViewColumn col in rackGrid.Columns)
            {
                col.DefaultCellStyle = style;
                col.Width = 20;
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void setRowHeight()
        {
            foreach (DataGridViewRow row in rackGrid.Rows)
            {
                row.Height = 20;
            }
        }

        private void fetchRackPositions(int idRack)
        {
            Task.Run((Action)(async () =>
            {
                List<WarehouseRack_Position> positions = await selectSQL.GetWarehousePositions(idRack);
                List<WarehouseRack_Position> positionsOnUse = await selectSQL.GetWarehousePositionsOnUse(idRack);
                Invoke((Action)(() =>
                {
                    spinner.Visible = false;
                    rackPositions.Clear();
                    rackPositions = positions;
                    displayRackPositions(positions, positionsOnUse);
                }));
            }));
        }

        private void showRackStats()
        {
            porcentajeUso = usedPositions * 100 / totalPositions;

            infoCard1.SetProperties("Espacios", totalPositions.ToString());
            infoCard2.SetProperties("Espacios en uso", usedPositions.ToString());
            infoCard3.SetProperties("Uso del Rack", porcentajeUso.ToString() + "%");
        }

        private void placeTableLabels()
        {
            int nivel_y_coord = rackGrid.Location.Y + (rackGrid.Size.Height / 2) - nivel_Label.Size.Height / 2;
            int nivel_x_coord = rackGrid.Location.X - 20;
            int pos_y_coord = rackGrid.Location.Y + rackGrid.Size.Height + 3;
            int pos_x_coord = rackGrid.Location.X + rackGrid.Size.Width / 2 - posicion_Label.Size.Width / 2;
            nivel_Label.Location = new Point(nivel_x_coord, nivel_y_coord);
            posicion_Label.Location = new Point(pos_x_coord, pos_y_coord);
        }

        private bool isPositionOnUse(string posName, List<WarehouseRack_Position> positionsOnUse)
        {
            var itemName = positionsOnUse.FirstOrDefault(elem => elem.name == posName);
            if (itemName != null) return true;
            return false;
        }

        private void displayRackPositions(List<WarehouseRack_Position> positions, List<WarehouseRack_Position> positionsOnUse)
        {
            int cont = 0;
            rackGrid.Rows.Clear();
            totalPositions = positions.Count;
            usedPositions = positionsOnUse.Count;
            for (int i = 0; i < currentRack.levels; i++)
            {
                DataGridViewRow row = new DataGridViewRow();

                // Crear las celdas para la fila en base al modelo creado
                row.CreateCells(rackGrid);

                for (int j = 0; j < row.Cells.Count; j++)
                { //                                    NAME-POS-LEV: A0-01-01
                    row.Cells[j].Value = positions[cont].name;
                    rackGrid.Columns[j].HeaderText = positions[cont].name.Substring(3,2);

                    if (isPositionOnUse(positions[cont].name, positionsOnUse)) //en uso
                    {
                        row.Cells[j].Style = setOnUseCellStyle();                        
                    }
                    else if (positions[cont].valid == false)//no valido
                    {
                        row.Cells[j].Style = setNotValidCellStyle();
                        totalPositions--;
                    }

                    cont++;
                }
                rackGrid.Rows.Add(row);
                rackGrid.Rows[i].HeaderCell.Value = (i + 1).ToString();

            }

            
            rackGrid.Height = (currentRack.levels + 1) * 20 + 5;
            rackGrid.Width = panel2.Width - 80;
            setRowHeight();
            SortDataGridViewDesc(rackGrid);
            rackGrid.ClearSelection();
            showRackStats();
            placeTableLabels();
        }

        public void SortDataGridViewDesc(DataGridView dgv)
        {
            foreach (DataGridViewColumn columna in dgv.Columns)
            {
                // Ordenar cada columna en orden descendente
                columna.SortMode = DataGridViewColumnSortMode.Programmatic;
                dgv.Sort(columna, ListSortDirection.Descending);
            }
        }

        private void showToastMessage(string message)
        {
            ToolTip tt = new ToolTip();
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

            timer.Interval = 3000; // Duración del mensaje en milisegundos
            timer.Tick += (s, e) =>
            {
                tt.Hide(this);
                timer.Stop();
            };

            tt.Show(message, this, PointToClient(MousePosition));

            timer.Start();
        }

        private void DataGridView1_MouseUp(object sender, MouseEventArgs e)
        {
            if (rackGrid.SelectedCells.Count > 0)
            {
                setOptionsState(true);
                actionBtnSave.Enabled = false;
                Color currentColor = rackGrid.SelectedCells[0].Style.BackColor;


                foreach (DataGridViewCell cell in rackGrid.SelectedCells)
                {
                    if (cell.Style.BackColor == Color.FromArgb(255, 20, 80)) //No es valida
                    {
                        actionBtnValid.Enabled = true;
                        actionBtnNotValid.Enabled = false;
                    }
                    else //es válida
                    {
                        actionBtnValid.Enabled = false;
                        actionBtnNotValid.Enabled = true;
                    }                    
                    if (currentColor != cell.Style.BackColor)//se selecciono mas de un tipo
                    {
                        //falta corregir color verde
                        actionBtnValid.Enabled = false;
                        actionBtnNotValid.Enabled = false;

                        showToastMessage("El grupo de celdas debe ser del mismo tipo");

                        break;
                    }
                }
            }

        }

        private DataGridViewCellStyle setNotValidCellStyle()
        {
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.BackColor = Color.FromArgb(255, 20, 80); //No válida                              
            return style;
        }
        private DataGridViewCellStyle setOnUseCellStyle()
        {
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.BackColor = Color.FromArgb(0, 128, 128); //en uso                   
            return style;
        }

        private void rackGrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            rackGrid.ClearSelection();
            currentSelected.Visible = false;
        }

        private void setOptionsState(bool state)
        {
            actionBtnNotValid.Enabled = state;
            actionBtnUnselect.Enabled = state;
            actionBtnValid.Enabled = state;
        }

        private void actionBtnSave_ButtonClick(object sender, EventArgs e)
        {
            submitChanges();
            spinner.Visible = true;
            actionBtnSave.Enabled = false;
            actionBtnCancel.Enabled = false;
            rackGrid.ClearSelection();
            clearChangedCellsPanel();
            setOptionsState(false);
            fetchRackPositions(currentRack.IDRACK);
        }

        private List<WarehouseRack_Position> getModifiedPositions()
        {
            List<WarehouseRack_Position> positionsChanged = new List<WarehouseRack_Position>();

            foreach (DataGridViewCell cell in changedCells)
            {
                var temp = rackPositions.FirstOrDefault(elem => elem.name.Equals(cell.Value));
                if (temp != null)
                {
                    if (cell.Style.BackColor == Color.White)
                    {
                        temp.valid = true;
                    }
                    else
                    {
                        temp.valid = false;
                    }
                    positionsChanged.Add(temp);
                }
            }

            return positionsChanged;
        }

        private void displayChangedCells()
        {
            int maxWidth = panel2.Width - 80;
            int x = 20, y = 30;

            clearChangedCellsPanel();

            List<string> changedPositions = changedCells.Select(elem => elem.Value.ToString()).ToList();

            //HashSet para eliminar los elementos repetidos
            HashSet<string> hashSet = new HashSet<string>(changedPositions);

            //HashSet to list
            changedPositions = new List<string>(hashSet);

            foreach (string cellName in changedPositions)
            {
                Label tempLabel = new Label();
                tempLabel.Location = new Point(x, y);                
                tempLabel.Font = new Font("Bahnschrift SemiBold SemiCondensed", 9F);
                tempLabel.Text = cellName;
                tempLabel.Size = new Size(61, 14);
                
                changedCellsPanel.Controls.Add(tempLabel);
                x += 70;

                if(x + 70 > maxWidth)
                {
                    x = 20;
                    y += 20;
                }
            }
        }

        private void clearChangedCellsPanel()
        {
            foreach (var control in changedCellsPanel.Controls.OfType<Label>().ToList())
            {
                changedCellsPanel.Controls.Remove(control);
            }
        }

        private void submitChanges()
        {
            //falta implementar que si la posicion esta en uso, no se cambie el estado
            updateSQL.UpdateStoragePositionState(getModifiedPositions());
            changedCells.Clear();
        }

        private void handleChangedCells(bool valid)
        {
            bool isValidSelection = true;
            foreach (DataGridViewCell cell in rackGrid.SelectedCells)
            {
                if (cell.Style.BackColor == Color.FromArgb(0, 128, 128))
                {
                    MessageBox.Show("No es posible cambiar los espacios en uso", "Advertencia",  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    isValidSelection = false;
                    break;
                }
            }
            if (isValidSelection)
            {
                foreach (DataGridViewCell cell in rackGrid.SelectedCells)
                {
                    if (valid)
                    {
                        cell.Style.BackColor = Color.White;
                    }
                    else
                    {
                        cell.Style.BackColor = Color.FromArgb(255, 20, 80);
                    }
                    var temp = changedCells.FirstOrDefault(elem => elem.Value == cell.Value);

                    if (temp != null && temp.Style.BackColor != cell.Style.BackColor)
                    {
                        changedCells.Remove(temp);
                    }
                    changedCells.Add(cell);
                    displayChangedCells();
                }
            }
        }

        private void actionBtnValid_ButtonClick(object sender, EventArgs e)
        {

            handleChangedCells(true);
            actionBtnSave.Enabled = true;
            actionBtnCancel.Enabled = true;
            actionBtnValid.Enabled = false;
            rackGrid.ClearSelection();
            actionBtnUnselect.Enabled = false;
        }

        private void actionBtnNotValid_ButtonClick(object sender, EventArgs e)
        {
            handleChangedCells(false);
            actionBtnSave.Enabled = true;
            actionBtnCancel.Enabled = true;
            actionBtnNotValid.Enabled = false;
            rackGrid.ClearSelection();
            actionBtnUnselect.Enabled = false;
        }

        private void actionBtnCancel_ButtonClick(object sender, EventArgs e)
        {
            spinner.Visible = true;
            changedCells.Clear();
            fetchRackPositions(currentRack.IDRACK);
            actionBtnCancel.Enabled = false;
            actionBtnSave.Enabled = false;
            rackGrid.ClearSelection();
            displayChangedCells();
        }

        private void actionBtnUnselect_ButtonClick(object sender, EventArgs e)
        {
            rackGrid.ClearSelection();
            setOptionsState(false);
            label2.Visible = false;
            currentSelected.Visible = false;

            if (changedCells.Count > 0)
            {
                actionBtnCancel.Enabled = true;
                actionBtnSave.Enabled = true;
            }
        }

        private void rackGrid_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (rackGrid.SelectedCells.Count == 1)
            {
                label2.Visible = true;
                currentSelected.Visible = true;
                DataGridViewCell cell = rackGrid.Rows[e.RowIndex].Cells[e.ColumnIndex];
                currentSelected.Text = cell.Value.ToString();
            }
            else
            {
                label2.Visible = false;
                currentSelected.Visible = false;
            }
        }
    }
}

