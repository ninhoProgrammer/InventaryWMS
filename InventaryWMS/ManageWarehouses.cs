using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventaryWMS
{
    public partial class ManageWarehouses : Form
    {
        Main mainForm;
        InsertSQL insertSQL = new InsertSQL();
        SelectSQL selectSQL = new SelectSQL();
        UpdateSQL updateSQL = new UpdateSQL();
        List<Warehouse> warehouses { get; set; }
        List<Country> countries { get; set; }
        List<State> states { get; set; }
        List<int> rackLengtList { get; set; }
        List<int> startIndexList { get; set; }
        List<string> rackNamesList { get; set; }
        Warehouse selected { get; set; }
        private int idCountry { get; set; }
        private int idState { get; set; }
        private int _idClient { get; set; }
        private int tempIdWarehouse { get; set; }
        private bool editMode { get; set; }
        private List<string> generatedRackNamesList { get; set; }

        public delegate void OpenWindow<T>();
        OpenWindow<WarehouseRacks> open;

        public ManageWarehouses(Main main)
        {
            this.mainForm = main;
            InitializeComponent();
            rackLengtList = new List<int>();
            startIndexList = new List<int>();
            rackNamesList = new List<string>();
            editMode = false;
            permission();
        }

        private void permission()
        {
            if (mainForm.permission.Rows[0]["WAREHOUSE_CREATE"].ToString() == "False")
            {
                createWarehouse.Visible = false;
            }
            if (mainForm.permission.Rows[0]["WAREHOUSE_EDIT"].ToString() == "False")
            {
                editButton.Visible = false;

            }
        }

        private void fetchWarehouses()
        {
            Task.Run(() =>
            {
                warehouses = selectSQL.GetWarehousesList("San Luis Potosí");
                this.Invoke((Action)(() =>
                {
                    spinnerWhList.Visible = false;
                    displayWarehouses(warehouses);
                }));
            });
        }

        private void fetchCountriesList()
        {

            Task.Run(async () =>
            {
                states = await selectSQL.GetStatesList();//esperar hasta que termine aqui
                countries = selectSQL.GetCountriesList();
                this.Invoke((Action)(() =>
                {
                    fetchWarehouses();
                    setCountriesList();
                    setStatesList();
                }));
            });
        }

        private void setCountriesList()
        {
            cbCountry.DataSource = countries.Select(pais => pais.NAME).ToList();
            cbCountry.SelectedIndex = -1;
        }

        private void setStatesList()
        {
            cbState.DataSource = states.Select(state => state.NAME).ToList();
            cbCountry.SelectedIndex = -1;
        }

        private void clearWarehousesListPanel()
        {
            foreach (var control in panelWHList.Controls.OfType<WarehouseCard>().ToList())
            {
                panelWHList.Controls.Remove(control);
            }
        }

        private void ManageWarehouses_Load(object sender, EventArgs e)
        {
            if (mainForm.floatingWindow)
            {
                setWindowSize();
                
            }
            fetchCountriesList();
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

        private void displayWarehouses(List<Warehouse> items)
        {
            clearWarehousesListPanel();

            int xinicial = 22, yinicial = 18, margin = 22;
            Point ini = new Point(xinicial, yinicial);


            foreach (Warehouse elem in items)
            {
                WarehouseCard item = new WarehouseCard();
                item.ContextMenuStrip = createOptionsMenu();
                item.SetProperties(elem.SHORT_NAME, elem.IDWAREHOUSES);
                item.Location = ini;
                ini.X += item.Size.Width + margin;
                item.delegado = new WarehouseCard.Detalles(DisplayWarehouseProperties); //Referencia al delegado
                panelWHList.Controls.Add(item);
            }
        }

        private ContextMenuStrip createOptionsMenu()
        {
            // Primero, crea una instancia de ContextMenuStrip
            ContextMenuStrip contextMenuStrip = new ContextMenuStrip();

            ToolStripMenuItem titulo = new ToolStripMenuItem("Opciones");
            titulo.Enabled = false;
            contextMenuStrip.Items.Add(titulo);

            // Luego, agrega las opciones del menú
            ToolStripMenuItem opcion1 = new ToolStripMenuItem("Ver almacén");
            contextMenuStrip.Items.Add(opcion1);
            ToolStripMenuItem opcion2 = new ToolStripMenuItem("Eliminar almacén");
            contextMenuStrip.Items.Add(opcion2);

            // Finalmente, maneja los eventos Click de las opciones del menú
            opcion1.Click += (sender, e) =>
            {
                openWarehouseRacksView();
            };
            opcion2.Click += (sender, e) =>
            {
                //falta ver que se seleccione el objeto
                askToDeleteWarehouse();
            };
            return contextMenuStrip;

        }

        private void askToDeleteWarehouse()
        {
            DialogResult result = MessageBox.Show("¿Desea eliminar este almacén?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                result = MessageBox.Show("Por favor, confirme nuevamente la eliminación del almacén " + selected.NAME + ", ¿Desea continuar?", "Eliminar almacén", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    deleteWarehouse();
                }
            }
        }

        private void deleteWarehouse()
        {
            spinner.Visible = true;
            Task.Run(() =>
            {
                var result = updateSQL.UpdateWarehouseValidState(selected.IDWAREHOUSES, 0);

                Invoke((Action)(() =>
                {
                    spinner.Visible = false;
                    fetchWarehouses();
                    if (result)
                    {
                        MessageBox.Show("Se ha eliminado el almacén", "Informacíon", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clearInputs();
                        clearStats();
                        editButton.Visible = false;
                        viewRacksBtn.Visible = false;
                    }

                }));
            });
        }

        private void displayWarehouseStats(int warehouseID)
        {
            Task.Run(async () =>
            {
                int count = await selectSQL.GetRacksCount(warehouseID, 1, -1);

                this.Invoke((Action)(() =>
                {
                    clearStats();
                    addStatsCards(count);
                }));
            });
        }


        private void addStatsCards(int value)
        {
            int xinicial = 20, yinicial = 178;
            Point ini = new Point(xinicial, yinicial);

            InfoCard temp = new InfoCard();
            temp.Location = ini;
            temp.SetProperties("Racks", value.ToString());
            whPropertiesPanel.Controls.Add(temp);
        }

        private void DisplayWarehouseProperties(int id)
        {
            setDefaultState();
            selected = warehouses.FirstOrDefault(elem => elem.IDWAREHOUSES == id);
            if (selected != null)
            {
                whPropertiesPanel.Enabled = true;
                viewRacksBtn.Visible = true;
                whFullName.Text = selected.NAME;
                whShortName.Text = selected.SHORT_NAME;
                whDescription.Text = selected.DESCRIPTION;
                cbCountry.SelectedItem = findCountryByID(selected.COUNTRY);
                cbState.SelectedItem = findStateByID(selected.STATE);
                tbCity.Text = selected.CITY;
                tbColony.Text = selected.DISTRICT;
                tbStreet.Text = selected.STREET;
                tbZipcode.Text = selected.ZIPCODE;

                displayWarehouseStats(id);
            }
        }

        private string findCountryByID(int id)
        {
            Country result = countries.FirstOrDefault(elem => elem.IDCONTRY == id);
            return result.NAME;
        }

        private string findStateByID(int id)
        {
            State result = states.FirstOrDefault(elem => elem.IDSTATE == id);
            return result.NAME;
        }

        private int findCountryID(string name)
        {
            Country result = countries.FirstOrDefault(elem => elem.NAME == name);
            return result.IDCONTRY;
        }

        private int findStateID(string name)
        {
            State result = states.FirstOrDefault(elem => elem.NAME == name);
            return result.IDSTATE;
        }

        private void setDefaultCountry()
        {
            cbCountry.SelectedItem = findCountryByID(2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            openWarehouseRacksView();
        }

        private void openWarehouseRacksView()
        {
            var form = Application.OpenForms.OfType<WarehouseRacks>().FirstOrDefault();
            if (form == null)
            {
                WarehouseRacks mwForm = new WarehouseRacks(this.mainForm, selected);
                mwForm.WindowState = FormWindowState.Maximized;
                this.mainForm.AddFormInPanel(mwForm);
            }
        }

        private void setControlsEnabled(bool state)
        {
            whFullName.Enabled = state;
            whShortName.Enabled = state;
            whDescription.Enabled = state;
            cbCountry.Enabled = state;
            cbState.Enabled = state;
            tbCity.Enabled = state;
            tbColony.Enabled = state;
            tbStreet.Enabled = state;
            tbZipcode.Enabled = state;
        }

        private void clearInputs()
        {
            whFullName.Clear();
            whShortName.Clear();
            whDescription.Clear();
            cbCountry.SelectedIndex = -1;
            cbState.SelectedIndex = -1;
            tbCity.Clear();
            tbColony.Clear();
            tbStreet.Clear();
            tbZipcode.Clear();

            cbFormat.SelectedIndex = 1;
            //numHPositions.Value = 0;
            //numLevels.Value = 0;
            numLevels.Enabled = false;
            numRacks.Value = 1;
            clearStats();
        }

        private void clearStats()
        {
            foreach (var control in whPropertiesPanel.Controls.OfType<InfoCard>().ToList())
            {
                whPropertiesPanel.Controls.Remove(control);
            }
        }

        private void editWhPropertiesBtn_Click(object sender, EventArgs e)
        {
            if (editMode)
            {
                spinner.Visible = true;
                setDefaultState();
                idCountry = findCountryID(cbCountry.SelectedItem.ToString());
                idState = findStateID(cbState.SelectedItem.ToString());
                Task.Run(() =>
                {
                    updateWarehouseData();

                    this.Invoke((Action)(() =>
                    {
                        spinner.Visible = false;
                        saveButton.Visible = false;
                        cancelButton.Visible = false;
                        fetchWarehouses();
                    }));
                });
            }
            else //Realizar registro
            {
                if (checkWarehouseDataToSave())
                {
                    spinner.Visible = true;
                    statusLabel.Visible = true;
                    editMode = false;
                    saveButton.Enabled = false;
                    setControlsEnabled(false);
                    this.Focus();
                    idCountry = findCountryID(cbCountry.SelectedItem.ToString());
                    idState = findStateID(cbState.SelectedItem.ToString());
                    saveButton.Text = "Procesando";
                    statusLabel.Text = "Creando almacén...";

                    Task.Run(async () =>
                    {
                        var res = await RegisterWarehouse();
                        if (!res)
                        {
                            Invoke((Action)(() =>
                            {
                                MessageBox.Show("Ha ocurrido un error", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }));
                        }
                    });
                }
                else
                {
                    MessageBox.Show("Complete todos los campos por favor", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }


        }
        private void updateWarehouseData()
        {
            string query =
                "UPDATE [dbo].[warehouses] SET [name] = @value1, [short_name] = @value2,[description] = @value3, [country] = @value4, [state] = @value5, [city] = @value6, [district] = @value7, [street] = @value8, [zipcode] = @value9, [updated_at] = @value10 WHERE IDWAREHOUSES = @value11";


            var connection = updateSQL.getConnection();
            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@value1", whFullName.Text);
            cmd.Parameters.AddWithValue("@value2", whShortName.Text);
            cmd.Parameters.AddWithValue("@value3", whDescription.Text);
            cmd.Parameters.AddWithValue("@value4", idCountry);
            cmd.Parameters.AddWithValue("@value5", idState);
            cmd.Parameters.AddWithValue("@value6", tbCity.Text);
            cmd.Parameters.AddWithValue("@value7", tbColony.Text);
            cmd.Parameters.AddWithValue("@value8", tbStreet.Text);
            cmd.Parameters.AddWithValue("@value9", tbZipcode.Text);
            cmd.Parameters.AddWithValue("@value10", DateTime.Now.ToString("yyyyMMdd"));
            cmd.Parameters.AddWithValue("@value11", selected.IDWAREHOUSES);

            cmd.ExecuteNonQuery();

            connection.Close();

        }

        private async Task<bool> RegisterWarehouse()
        {
            var res = await saveWarehouseData();
            if (res)
            {
                tempIdWarehouse = await selectSQL.GetLatestWarehouseID();

                if (tempIdWarehouse > 0)
                {
                    Invoke((Action)(() =>
                    {
                        statusLabel.Text = "Creando Racks...";
                    }));
                    res = await generateAndSaveRacks(tempIdWarehouse);
                }
            }

            if (res)
            {
                Invoke((Action)(() =>
                {
                    spinner.Visible = false;
                    saveButton.Visible = false;
                    clearInputs();
                    propsTitle.Text = "Propiedades";
                    cancelButton.Visible = false;
                    editButton.Visible = false;
                    statusLabel.Visible = false;
                    rackPropertiespanel.Visible = false;
                    createWarehouse.Enabled = true;
                    fetchWarehouses();
                    wareHousesPanel.Enabled = true;
                    whPropertiesPanel.Enabled = false;
                    editMode = false;
                }));
            }

            return true;
        }

        private async Task<bool> saveWarehouseData()
        {
            bool res;
            Warehouse warehouse = new Warehouse();
            warehouse.NAME = whFullName.Text;
            warehouse.SHORT_NAME = whShortName.Text;
            warehouse.DESCRIPTION = whDescription.Text;
            warehouse.COUNTRY = idCountry;
            warehouse.STATE = idState;
            warehouse.CITY = tbCity.Text;
            warehouse.DISTRICT = tbColony.Text;
            warehouse.STREET = tbStreet.Text;
            warehouse.ZIPCODE = tbZipcode.Text;
            warehouse.VALID = true;
            //Guardar los datos del almacen
            res = await insertSQL.saveToWarehouses(warehouse);
            if(res)
                insertSQL.SaveToBinnacle("Almacen dado de alta: " + warehouse.NAME);
            return res;

        }

        private async Task<bool> generateAndSaveRacks(int idWarehouse)
        {
            bool res;
            WarehouseRack temp = new WarehouseRack();
            temp.idWarehouse = idWarehouse;
            temp.levels = (int)numLevels.Value;
            temp.type = 1;

            res = await insertSQL.saveToWarehouseRacks(temp, rackNamesList, rackLengtList);

            Invoke((Action)(() =>
            {
                statusLabel.Text = "Generando posiciones...";
            }));

            List<int> racks = await selectSQL.GetRacksIDListByWarehouse(idWarehouse);

            if (racks.Count > 0)
            {
                res = await generateAndSavePositions(racks);//Espacios para cada rack                 
            }

            return res;
        }

        private async Task<bool> generateAndSavePositions(List<int> rackIdList)
        {

            //name-position-level
            //A0-01-01

            DataTable positions = generatePositionsTable(rackIdList);

            bool res = await insertSQL.saveToRackPositions(positions);

            return res;
        }


        private void searchWarehouse(string searchParam)
        {
            endSearchButton.Visible = true;
            List<Warehouse> warehouseList = new List<Warehouse>();
            foreach (var elem in warehouses)
            {
                if (elem.SHORT_NAME.ToLower().Contains(searchParam))
                {
                    warehouseList.Add(elem);
                }
            }
            displayWarehouses(warehouseList);
            setDefaultState();
            clearInputs();
        }

        private void setRegisterState()
        {
            wareHousesPanel.Enabled = false;
            rackPropertiespanel.Visible = true;
            cancelButton.Visible = true;
            propsTitle.Text = "Registrar Nuevo Almacén";
            editMode = false;
            createWarehouse.Enabled = false;
            editButton.Visible = false;
            saveButton.Enabled = true;
            saveButton.Text = "Guardar";
            saveButton.Visible = true;
            whPropertiesPanel.Enabled = true;
            clearInputs();
            setControlsEnabled(true);
            setDefaultCountry();
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setRegisterState();
            clearInputs();
        }

        private void setDefaultState()
        {
            editMode = false;
            saveButton.Enabled = false;
            if (mainForm.permission.Rows[0]["WAREHOUSE_EDIT"].ToString() == "True")
            {
                editButton.Visible = true;
            }
            setControlsEnabled(false);
            this.Focus();
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (selected != null)
            {
                editMode = true;
                saveButton.Text = "Guardar Cambios";
                saveButton.Visible = true;
                saveButton.Enabled = true;
                editButton.Visible = false;
                cancelButton.Visible = true;
                setControlsEnabled(true);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            editButton.Visible = false;
            propsTitle.Text = "Propiedades";
            setControlsEnabled(false);
            saveButton.Visible = false;
            clearInputs();
            rackPropertiespanel.Visible = false;
            wareHousesPanel.Enabled = true;
            cancelButton.Visible = false;
            viewRacksBtn.Visible = false;
            createWarehouse.Enabled = true;
            whPropertiesPanel.Enabled = false;
        }

        private void endSearchButton_Click_1(object sender, EventArgs e)
        {
            searchTextBox.Text = "";
            displayWarehouses(warehouses);
            setDefaultState();
            clearInputs();
            this.Focus();
            endSearchButton.Visible = false;
        }

        private void searchTextBox_TextChanged_1(object sender, EventArgs e)
        {
            searchWarehouse(searchTextBox.Text);
        }

        private void createWarehouse_Click(object sender, EventArgs e)
        {
            setRegisterState();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AskRackLenghtWindow();
        }

        private void AskRackLenghtWindow()
        {
            generatedRackNamesList = generateRackNames();
            AskRackLenght window = new AskRackLenght(generatedRackNamesList);
            if (window.ShowDialog() == DialogResult.OK)
            {
                rackLengtList = window.getLenghtList();
                rackNamesList = window.getNamesList();
                startIndexList = window.getIndexList();
            }
            else
            {
                rackLengtList.Clear();
                rackNamesList.Clear();
                startIndexList.Clear();
            }
        }

        //Generador de Nombres de los racks:
        //Notas: la longitud del nombre de un rack esta limitada a 2
        //       esto debido a que el nombre de una ubicacion se compone de 3 partes [RACK-POS-LEV]
        //       cada parte es de 2 caracteres y la longitud del nombre esta estandarizada a 6 caracteres
        /*
         * Para formato numerico genera(1 a 99): MAX 99 racks por almacen
         * 01, 02, 03, 04..... 98, 99
         * 
         * Para formato de letras genera:  (26)*(10) = 260 MAX racks (LIMITADO a 99 en variable numRacks)
         * A0, B0, C0, D0....X0, Y0,Z0 -> A1, B1, C1, D1....X1, Y1, Z1 -> A2, B2, C2, D2....X2, Y2, Z2
         * 
        */
        private List<string> generateRackNames()
        {
            char format = 'A', cont = '0';
            int numericFormat = 1;

            List<string> result = new List<string>();
            for (int i = 0; i < (int)numRacks.Value; i++)
            {
                if (cbFormat.SelectedIndex != 0 && format > 'Z')
                {
                    format = 'A';
                    cont++;
                }
                if (cbFormat.SelectedIndex == 0)
                {
                    string tempName = numericFormat.ToString();
                    if (numericFormat < 10)
                    {
                        var aux = tempName;
                        tempName = "0" + aux;
                    }
                    result.Add(tempName);
                    numericFormat++;
                }
                else
                {
                    result.Add(format.ToString() + cont.ToString());

                    if (format == 'N' && i + 1 < (int)numRacks.Value)
                    {
                        result.Add("Ñ" + cont.ToString());
                        i++;
                    }
                }
                format++;
            }
            return result;
        }

        private void numRacks_ValueChanged(object sender, EventArgs e)
        {
            if (numRacks.Value > 0)
            {
                rackNamesList.Clear();
                rackLengtList.Clear();
                setRacksLenBtn.Enabled = true;
            }
            else
                setRacksLenBtn.Enabled = false;
        }

        private bool checkRacksMetadata()
        {
            if (cbFormat.SelectedIndex == -1 || rackLengtList.Count == 0 || rackNamesList.Count == 0)
                return false;
            return true;
        }

        private bool checkIsNullOrEmptyOrWhitespaces(string str)
        {
            if (string.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str))
                return true;
            return false;
        }

        private bool checkWarehouseDataToSave()
        {
            if (!checkRacksMetadata())
                return false;

            foreach (var control in whPropertiesPanel.Controls.OfType<System.Windows.Forms.TextBox>().ToList())
            {
                if(control.Name != "whDescription")
                    if (checkIsNullOrEmptyOrWhitespaces(control.Text))
                        return false;
            }

            if (tbZipcode.Text != "")
            {
                int numero = 0;
                bool esNumero = Int32.TryParse(tbZipcode.Text, out numero);

                if (!esNumero || numero < 10000 || numero > 99999)
                {
                    MessageBox.Show("El código postal debe ser de 5 dígitos", "Formato inválido", MessageBoxButtons.OK);
                    return false;
                }
            }

            return true;
        }

        public string generatePositionName(string rack, int level, int position)
        {
            //padding al inicio
            string posFormatted = position.ToString("D2");
            string levFormatted = level.ToString("D2");

            //padding al final
            string charFormateado = rack.PadRight(2, '0');

            // Concatenar los valores
            string name = $"{charFormateado}-{posFormatted}-{levFormatted}";

            return name;
        }

        private DataTable generatePositionsTable(List<int> rackIdList)
        {
            //rackLengtList, rackNamesList, startIndexList, (int)numLevels.Value
            // Crear una instancia de DataTable
            DataTable dt = new DataTable();

            // Agregar columnas a la tabla debe coincidir exactamente a la BD

            dt.Columns.Add("idwarehouse_racks_positions", typeof(int));
            dt.Columns.Add("idwarehouse_racks", typeof(int));
            dt.Columns.Add("name", typeof(string));
            dt.Columns.Add("level", typeof(int));
            dt.Columns.Add("max_weight", typeof(float));
            dt.Columns.Add("priority", typeof(int));
            dt.Columns.Add("type", typeof(int));
            dt.Columns.Add("excluded", typeof(int));
            dt.Columns.Add("valid", typeof(int));

            for (int i = 0; i < rackIdList.Count; i++)//Total de racks
            {
                for (int j = 0; j < (int)numLevels.Value; j++)//Total de niveles
                {
                    int startIndex = startIndexList[i];
                    for (int k = 0; k < rackLengtList[i]; k++)//longitud del rack
                    {
                        //NAME           LEVEL       POS
                        string name = generatePositionName(rackNamesList[i], j + 1, startIndex + k);
                        // Crear una nueva fila
                        DataRow row = dt.NewRow();

                        // Asignar valores a las columnas de la fila
                        row["idwarehouse_racks"] = rackIdList[i];
                        row["name"] = name;
                        row["level"] = j + 1;
                        row["type"] = 1;
                        row["excluded"] = 0;
                        row["valid"] = 1;

                        // Agregar la fila al DataTable
                        dt.Rows.Add(row);
                    }
                }
            }

            return dt;

        }

    }
}
