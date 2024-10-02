using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;


namespace InventaryWMS
{
    public partial class WarehouseRacks : Form
    {
        private Main mainForm;
        private Warehouse warehouse;
        private SelectSQL selectSQL = new SelectSQL();
        private InsertSQL insertSQL = new InsertSQL();
        private WarehouseRack selectedRack;
        List<WarehouseRack> racksListGlobal;

        public WarehouseRacks(Main main, Warehouse wh)
        {
            this.mainForm = main;
            this.warehouse = wh;
            InitializeComponent();
            setProps();
        }

        private void setProps()
        {
            whShortName.Text = warehouse.SHORT_NAME;
        }

        private void newRackBtn_Click(object sender, EventArgs e)
        {
            setRegisterRackState(true);
        }

        private void saveNewRackBtn_Click(object sender, EventArgs e)
        {
            setRegisterRackState(false);
        }

        private void setRegisterRackState(bool state)
        {

            newRackBtn.Enabled = !state;
            newRackPanel.Visible = state;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            setRegisterRackState(false);
        }

        private void WarehouseRacks_Load(object sender, EventArgs e)
        {
            setWindowSize();
            fetchWarehouseRacks(1); //Por default inicia con los racks de almacen
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

        private void fetchWarehouseStats()
        {
            Task.Run((Action)(async () =>//implementar async/await para stats
            {
                int count = await selectSQL.GetRacksCount(warehouse.IDWAREHOUSES, 1, -1);
                int count2 = await selectSQL.GetRacksCount(warehouse.IDWAREHOUSES, 2, mainForm._idClient);
                this.Invoke(new Action(() =>
                {
                    infoCard1.SetProperties("Racks", count.ToString());
                    infoCard1.Visible = true;

                    infoCard2.SetProperties("Bahías", count2.ToString());
                    infoCard2.Visible = true;

                    spinner.Visible = false;
                    tabs.Enabled = true;
                }));
            }));
        }

        private void fetchWarehouseRacks(int rackType)
        {
            tabs.Enabled = false;
            Task.Run((Action)( async() =>
            {
                List<WarehouseRack> rackList = await selectSQL.GetRacksListByWarehouse(warehouse.IDWAREHOUSES, rackType, mainForm._idClient);
                if(rackType == 2)//Si son bahias, incluir las globales
                {
                    List<WarehouseRack> rackListGlobal = await selectSQL.GetRacksListByWarehouse(warehouse.IDWAREHOUSES, 3, mainForm._idClient);

                    rackList.AddRange(rackListGlobal);
                }
                this.Invoke(new Action(() =>
                {
                    fetchWarehouseStats();
                    displayRacks(rackList);
                }));
            }));
        }

        private void displayRacks(List<WarehouseRack> racks)
        {
            spinner.Visible = false;
            var currentPage = tabs.SelectedTab;
            racksListGlobal = racks;
            clearRacksPanel(currentPage);
            int xinicial = 10, yinicial = 20, margin = 22;
            Point ini = new Point(xinicial, yinicial);

            foreach (var rack in racks)
            {
                RackInfoCard card = new RackInfoCard(this.mainForm);
                card.setProperties(rack.name, rack.IDRACK);
                card.Location = ini;                
                card.openForm = new RackInfoCard.Detalles(DisplayRackProperties); //Referencia al delegado                
                currentPage.Controls.Add(card);
                
                ini.X += card.Size.Width + margin;

                if (ini.X > currentPage.Width)
                {
                    ini.X = 10;
                    ini.Y += card.Size.Height + margin;
                }
            }
            switch (tabs.SelectedIndex)
            {
                case 1:
                    addBahia.Location = ini;
                    break;                
                default: 
                    break;
            }

        }

       

       
        private void DisplayRackProperties(int id_rack, bool edit)
        {
            selectedRack = racksListGlobal.FirstOrDefault(elem => elem.IDRACK == id_rack);
            if (edit)
            {
                
            }
            else
            {
                if(selectedRack.type == 1)
                {
                    RackView mwForm = new RackView(this.mainForm, selectedRack, warehouse);
                    this.mainForm.AddFormInPanel(mwForm);
                }
                else if (selectedRack.type == 2 || selectedRack.type == 3)
                {
                    MessageBox.Show("El mapa de espacios de almacenamiento no está disponible para bahías.","Mapa no disponible", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }                
            }
        }

        private void clearRacksPanel(TabPage page)
        {
            foreach (var control in page.Controls.OfType<RackInfoCard>().ToList())
            {
                page.Controls.Remove(control);
            }            
        }        

        private void actionButton4_MouseClick(object sender, MouseEventArgs e)
        {
            ConfirmDeleteRack();
        }

        public void ConfirmDeleteRack()
        {
            DialogResult result = MessageBox.Show(
                "¿Desea eliminar el rack?",
                "Eliminar rack",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Information
            );

            if (result == DialogResult.OK)
            {
                // El usuario hizo clic en OK
            }
            else if (result == DialogResult.Cancel)
            {
                // El usuario hizo clic en Cancel
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AskRackPropsWindow();
        }

        private void AskRackPropsWindow()
        {               
            CreateVirtualRack window = new CreateVirtualRack(mainForm._idClient, racksListGlobal);
            if (window.ShowDialog() == DialogResult.OK)
            {
                int rackType = 2;//default para guardar bahias
                if(!window.checkAssignToClient.Checked)//Si NO se va a asignar a un cliente (Bahia Rack)
                {
                    rackType = 3;//la bahia se mostrará en todos los clientes
                }
                saveRack(window.rackName.Text, 1, 1, rackType);
            }            
        }

        private void saveRack(string rackName, int rackLenght, int levels, int rackType)
        {
            WarehouseRack temp = new WarehouseRack();
            temp.idWarehouse = warehouse.IDWAREHOUSES;
            temp.levels = levels;
            temp.type = rackType;
            temp.name = rackName;
            temp.totalPositions = rackLenght * levels;            
            temp.valid = true;
            if (temp.type == 2)
            {
                temp.clientId = mainForm._idClient;
            }
            else
            {
                temp.clientId = null;
            }

            spinner.Visible = true;
            Task.Run(async () =>
            {
                int result = await insertSQL.saveWHRack(temp);                
                this.Invoke((Action)(() =>
                {
                    spinner.Visible = false; 
                    if(result == -1)
                    {
                        MessageBox.Show("No se pudo completar el registro, ocurrió un error","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if(result > 0) 
                    {                                                                     
                        temp.IDRACK = result; //el insert devuelve el id del registro insertado
                        DataTable positions = generatePositions(temp, rackLenght, 1);
                        savePositions(positions);                      
                    }
                }));
            });
        }        

        private DataTable generatePositions(WarehouseRack rack, int rackLenght, int startIndex)
        {
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

            for(int i = 0; i < rack.levels; i++)//Niveles del rack
            {
                for(int j = 0; j< rackLenght; j++)//Logitud horizontal del rack
                {
                    string name = rack.name;
                    // Crear una nueva fila
                    DataRow row = dt.NewRow();

                    // Asignar valores a las columnas de la fila
                    row["idwarehouse_racks"] = rack.IDRACK;
                    row["name"] = name;
                    row["level"] = i + 1;
                    row["type"] = 1;//que es?
                    row["excluded"] = 0;
                    row["valid"] = 1;

                    // Agregar la fila al DataTable
                    dt.Rows.Add(row);                    
                }
            }
            return dt;
        }

        private void savePositions(DataTable positions)
        {
            Task.Run(async () =>
            {
                bool result = await insertSQL.saveToRackPositions(positions);
                Invoke((Action)(() =>
                {
                    if(result)
                    {
                        fetchWarehouseRacks(tabs.SelectedIndex + 1);                    
                    }
                    else
                    {
                        MessageBox.Show("No se pudo completar la operación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }));
            });
        }

        private void tabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadRacksPage();
        }

        private void loadRacksPage()
        {
            spinner.Visible = true;
            switch (tabs.SelectedIndex)
            {
                case 0: //Racks fisicos (Tipo 1)                    
                    fetchWarehouseRacks(1);
                    break;
                case 1: //Racks Virtuales (Tipo 2)
                    fetchWarehouseRacks(2);
                    break;                
            }
        }
    }
}
