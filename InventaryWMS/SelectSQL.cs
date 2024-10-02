
using Microsoft.ReportingServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventaryWMS
{
    internal class SelectSQL
    {

        #region Variabls and triggers
        private System.Data.SqlClient.SqlConnection _connection { get; set; }
        private SqlDataReader _dr { get; set; }
        private DataSet _ds { get; set; }

        Security security { get; set; }
        public string message { get; set; }

        DataTable miDataTable { get; set; }

        public SelectSQL()
        {
            _connection = DBConections.GetConnection();
        }

        #endregion

        #region Check
        public bool CheckConections()
        {
            try
            {
                _connection.Open();

                //COMBOBOX.SelectedIndex = 0;
                _connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar a base de datos, intenta configurar la bas ede datos: " + ex.Message);
                _connection.Close();
                return false; 
            }
            return true;
        }


        public int CheckUser(string USERNAME, string PASSWORD)
        {
            int last = 0;

            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT [IDUSER] FROM [dbo].[USERS] WHERE USERNAME = '" + USERNAME + "' AND PASSWORD =  '" + PASSWORD + "'", _connection);
                _dr = cmd.ExecuteReader();
                while (_dr.Read())
                {
                    last = int.Parse(_dr["IDUSER"].ToString());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
                message = "Mensaje:" + ex.Message;

            }

            _connection.Close();
            return last;
        }

        public bool CheckClientsExitsWarehouse(int IDCLIENT, int IDWAREHOUSE)
        {
            bool last = false;

            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM [dbo].[CLIENTS_WAREHOUSE] WHERE IDCLIENT = '" + IDCLIENT + "' AND IDWAREHOUSES =  '" + IDWAREHOUSE + "'", _connection);
                _dr = cmd.ExecuteReader();
                while (_dr.Read())
                {
                    last = true;
                }

            }
            catch (Exception ex)
            {
                
                message = "Mensaje:" + ex.Message;

            }

            _connection.Close();
            return last;
        }

        public int GetIdOnCheckClients(string SHORT_NAME)
        {
            int last = 0;

            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT [IDCLIENTS] FROM [dbo].[CLIENTS] WHERE SHORT_NAME = '" + SHORT_NAME + "' ", _connection);

                _dr = cmd.ExecuteReader();
                while (_dr.Read())
                {
                    last = int.Parse(_dr["IDCLIENTS"].ToString());
                }
                System.Console.WriteLine("last" + last);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Error : " + ex.Message);
                message = "Mensaje:" + ex.Message;

            }

            _connection.Close();
            return last;
        }

        public int GetIDpermissionFromUser(int iduser)
        {
            int last = 0;

            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT [PERMISSIONS] FROM [dbo].[USERS] WHERE IDUSER = " + iduser + " ", _connection);

                _dr = cmd.ExecuteReader();
                while (_dr.Read())
                {
                    last = int.Parse(_dr["PERMISSIONS"].ToString());
                }
                System.Console.WriteLine("last" + last);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Error : " + ex.Message);
                message = "Mensaje:" + ex.Message;

            }

            _connection.Close();
            return last;
        }

        public DataTable GetPermission(int idpermission)
        {
            DataTable registros = new DataTable();
            try
            {
                _connection.Open();
                string query = String.Concat("SELECT USERS_CONSULT,USERS_ACCESS,USERS_CREATE,USERS_EDIT,USERS_DELETE,CLIENTS_ACCESS,CLIENTS_CONSULT,CLIENTS_CREATE,CLIENTS_EDIT,CLIENTS_DELETE,PRODUCTS_ACCESS,PRODUCTS_CONSULT,PRODUCTS_CREATE,PRODUCTS_EDIT,PRODUCTS_DELETE,INVOICES_ACCESS,INVOICES_CONSULT,INVOICES_CREATE,INVOICES_EDIT,INVOICES_DELETE,REMISSIONS_ACCESS,REMISSIONS_CONSULT,REMISSIONS_CREATE,REMISSIONS_EDIT,REMISSIONS_DELETE,TRANSFERS_ACCESS,TRANSFERS_CONSULT,TRANSFERS_CREATE,TRANSFERS_EDIT,TRANSFERS_DELETE,INVENTORY_ACCESS,LOG_ACCESS,LOG_CONSULT,LOG_CREATE,LOG_EDIT,LOG_DELETE,CAN_AUTORISE,LOCATE_ACESS,REPORT_ACESS,BINNACLE_ACESS,WAREHOUSE_ACESS,WAREHOUSE_CREATE,WAREHOUSE_EDIT,DESTINATIONS_ACESS,DESTINATIONS_CREATE,DESTINATIONS_EDIT,PERMISSIONS_ACESS,PERMISSIONS_CREATE,PERMISSIONS_EDIT,WORK_ORDER_ACESS,MAIL_ACESS FROM [dbo].[PERMISSIONS] WHERE IDPERMISSIONS = " + idpermission + " ");
                SqlCommand comando = new SqlCommand(query, _connection);           //Clase para ejecutar comandos SQL usando la conexion actual
                SqlDataAdapter adaptador = new SqlDataAdapter(comando);         //Adaptador de datos para rellenar una tabla
                                                                                //Almacenamos los registros en una tabla
                adaptador.Fill(registros);                                      //Llenamos la tabla con datos
                _connection.Close();                                               //Terminamos la conexion

                return registros;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Error : " + ex.Message);
                message = "Mensaje:" + ex.Message;
                _connection.Close();
                return null;
            }


        }

        #endregion

        #region Get
        public string GetClients(int ID)
        {
            string last = "";

            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT [NAME] FROM [dbo].[CLIENTS] WHERE IDCLIENTS = '" + ID + "' ", _connection);
                _dr = cmd.ExecuteReader();
                while (_dr.Read())
                {
                    last = _dr["NAME"].ToString();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
                message = "Mensaje:" + ex.Message;
                _connection.Close();
            }

            _connection.Close();
            return last;
        }

        public string GetPrefixClients(int ID)
        {
            string last = "";

            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT [PREFIX] FROM [dbo].[CLIENTS] WHERE IDCLIENTS = '" + ID + "' ", _connection);
                _dr = cmd.ExecuteReader();
                while (_dr.Read())
                {
                    last = _dr["PREFIX"].ToString();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
                message = "Mensaje:" + ex.Message;
                _connection.Close();
            }

            _connection.Close();
            return last;
        }

        public int GetIdClientName(string NAME)
        {
            int last = 0;

            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT [IDCLIENTS] FROM [dbo].[CLIENTS] WHERE [NAME] = '" + NAME + "' ", _connection);
                _dr = cmd.ExecuteReader();
                while (_dr.Read())
                {
                    last = int.Parse(_dr["IDCLIENTS"].ToString());
                }

            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Error : " + ex.Message);
                message = "Mensaje:" + ex.Message;
                _connection.Close();
            }

            _connection.Close();
            return last;
        }

        public int GetIdWarehouse(int IDCLIENT)
        {
            int last = 0;

            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT [IDWAREHOUSES] FROM [dbo].[WAREHOUSES] WHERE [IDCLIENT] = " + IDCLIENT + " ", _connection);
                _dr = cmd.ExecuteReader();
                while (_dr.Read())
                {
                    last = int.Parse(_dr["IDWAREHOUSES"].ToString());
                }

            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Error : " + ex.Message);
                message = "Mensaje:" + ex.Message;
            }

            _connection.Close();
            return last;
        }

        public string GetUser(int ID)
        {
            string last = "";
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT [USERNAME] FROM [dbo].[USERS] WHERE IDUSER = '" + ID + "' ", _connection);
                _dr = cmd.ExecuteReader();
                while (_dr.Read())
                {
                    last = _dr["USERNAME"].ToString();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
                message = "Mensaje:" + ex.Message;
                _connection.Close();
            }

            _connection.Close();
            return last;
        }


        public int GetIdPermissions(string NAME)

        {
            int last = 0;
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT [IDPERMISSIONS] FROM [dbo].[PERMISSIONS] WHERE [NAME] = '" + NAME + "' ", _connection);
                _dr = cmd.ExecuteReader();
                while (_dr.Read())
                {
                    last = int.Parse(_dr["IDPERMISSIONS"].ToString());
                }

            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Error : " + ex.Message);
                message = "Mensaje:" + ex.Message;
                _connection.Close();
            }

            _connection.Close();
            return last;
        }


        public int GetIdMeasuringUnit(string ABREVIATION)
        {
            int last = 0;
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT [IDMEASURING_UNIT] FROM [dbo].[MEASURING_UNIT] WHERE [ABREVIATION] = '" + ABREVIATION + "' ", _connection);
                _dr = cmd.ExecuteReader();
                while (_dr.Read())
                {
                    last = int.Parse(_dr["IDMEASURING_UNIT"].ToString());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
                message = "Mensaje:" + ex.Message;
                _connection.Close();
            }

            _connection.Close();
            return last;
        }

        public int GetIdAutomaticEmail(string SENTECY)
        {
            int last = 0;
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT IDCLIENT_EMAILS FROM CLIENT_EMAILS WHERE ADDRESS =  '" + SENTECY + "' ", _connection);
                _dr = cmd.ExecuteReader();
                while (_dr.Read())
                {
                    last = int.Parse(_dr["IDCLIENT_EMAILS"].ToString());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
                message = "Mensaje:" + ex.Message;
                _connection.Close();
            }

            _connection.Close();
            return last;
        }

        public int GetIdCurrency(string ABREVIATION)
        {
            int last = 0;
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT [IDCURRENCIES] FROM [dbo].[CURRENCIES] WHERE ABREVIATION = '" + ABREVIATION + "' ", _connection);
                _dr = cmd.ExecuteReader();
                while (_dr.Read())
                {
                    last = int.Parse(_dr["IDCURRENCIES"].ToString());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
                message = "Mensaje:" + ex.Message;
                _connection.Close();
            }

            _connection.Close();
            return last;
        }

        public int GetIdOnShortNameWarehoses(string SHORT_NAME)
        {
            int last = 0;
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT [IDWAREHOUSES] FROM [dbo].[WAREHOUSES] WHERE [SHORT_NAME] = '" + SHORT_NAME + "' ", _connection);
                _dr = cmd.ExecuteReader();
                while (_dr.Read())
                {
                    last = int.Parse(_dr["IDWAREHOUSES"].ToString());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
                message = "Mensaje:" + ex.Message;
                _connection.Close();
            }

            _connection.Close();
            return last;
        }

        public int GetIdClientType(string NAME)
        {
            int last = 0;
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT [IDCLIENTE_TYPE] FROM [dbo].[CLIENTS_TYPE] WHERE [NAME] = '" + NAME + "' ", _connection);
                _dr = cmd.ExecuteReader();
                while (_dr.Read())
                {
                    last = int.Parse(_dr["IDCLIENTE_TYPE"].ToString());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
                message = "Mensaje:" + ex.Message;
                _connection.Close();
            }

            _connection.Close();
            return last;
        }

        public int GetContry(string NAME)
        {
            int last = 0;
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT [IDCOUNTRIES] FROM [dbo].[COUNTRIES] WHERE [NAME] = '" + NAME + "' ", _connection);
                _dr = cmd.ExecuteReader();
                while (_dr.Read())
                {
                    last = int.Parse(_dr["IDCOUNTRIES"].ToString());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
                message = "Mensaje:" + ex.Message;
                _connection.Close();
            }

            _connection.Close();
            return last;
        }

        public int GetTypeUser(int ID)
        {
            int last = 0;

            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT [TYPE] FROM [dbo].[USERINVENTARY] WHERE IDUSER = '" + ID + "' ", _connection);
                _dr = cmd.ExecuteReader();
                while (_dr.Read())
                {
                    last = int.Parse(_dr["TYPE"].ToString());
                }

            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Error : " + ex.Message);
                message = "Mensaje:" + ex.Message;
                _connection.Close();
            }

            _connection.Close();
            return last;
        }

        public int GetClientEmail(string ADDRESS)
        {
            int last = 0;

            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT [IDCLIENT_EMAILS] FROM [dbo].[CLIENT_EMAILS] WHERE ADDRESS = '" + ADDRESS + "' ", _connection);
                _dr = cmd.ExecuteReader();
                while (_dr.Read())
                {
                    last = int.Parse(_dr["IDCLIENT_EMAILS"].ToString());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
                message = "Mensaje:" + ex.Message;
                _connection.Close();
            }

            _connection.Close();
            return last;
        }



        public List<Warehouse> GetWarehousesList(string STATE)
        {
            List<Warehouse> result = new List<Warehouse>();

            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM [dbo].[WAREHOUSES] INNER JOIN [dbo].[STATES] ON STATES.IDSTATE = WAREHOUSES.STATE WHERE STATES.NAME  = @value1 AND WAREHOUSES.VALID = 1 ", _connection);
                cmd.Parameters.AddWithValue("@value1", STATE);
                _dr = cmd.ExecuteReader();
                while (_dr.Read())
                {

                    Warehouse temp = new Warehouse
                    {
                        IDWAREHOUSES = (int)_dr["IDWAREHOUSES"],
                        NAME = (string)_dr["NAME"],
                        SHORT_NAME = (string)_dr["SHORT_NAME"],
                        DESCRIPTION = (string)_dr["DESCRIPTION"],
                        COUNTRY = (int)_dr["COUNTRY"],
                        STATE = (int)_dr["STATE"],
                        CITY = (string)_dr["CITY"],
                        DISTRICT = (string)_dr["DISTRICT"],
                        STREET = (string)_dr["STREET"],
                        ZIPCODE = (string)_dr["ZIPCODE"],
                        VALID = (bool)_dr["VALID"]
                    };
                    result.Add(temp);
                }
                _connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
                message = "Mensaje:" + ex.Message;
                _connection.Close();
            }

            return result;
        }

        public List<Country> GetCountriesList()
        {
            List<Country> result = new List<Country>();

            try
            {
                _connection.Open();
                string query = "SELECT IDCOUNTRIES, NAME FROM [dbo].[COUNTRIES]";
                SqlCommand cmd = new SqlCommand(query, _connection);
                _dr = cmd.ExecuteReader();
                while (_dr.Read())
                {
                    Country temp = new Country
                    {
                        IDCONTRY = int.Parse(_dr["IDCOUNTRIES"].ToString()),
                        NAME = _dr["NAME"].ToString(),
                    };
                    result.Add(temp);
                }
                _connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
                message = "Mensaje:" + ex.Message;
                _connection.Close();
            }

            return result;
        }

        public async Task<List<State>> GetStatesList()
        {
            List<State> result = new List<State>();

            try
            {
                _connection.Open();
                string query = "SELECT IDSTATE, NAME FROM [dbo].[STATES]";
                SqlCommand cmd = new SqlCommand(query, _connection);
                _dr = await cmd.ExecuteReaderAsync();
                while (_dr.Read())
                {
                    State temp = new State
                    {
                        IDSTATE = (int)_dr["IDSTATE"],
                        NAME = (string)_dr["NAME"]
                    };
                    result.Add(temp);
                }
                _connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
                message = "Mensaje:" + ex.Message;
                _connection.Close();
            }

            return result;
        }

        public async Task<int> GetRacksCount(int idWarehouse, int rackType, int idClient)
        {
            int last = 0;

            try
            {
                _connection.Open();
                string query = "SELECT COUNT(wr.IDWAREHOUSE_RACKS) as TOTAL_RACKS FROM [dbo].[WAREHOUSE_RACKS] as wr WHERE wr.IDWAREHOUSE = @value1 AND TYPE = @value2;";
                if (idClient > 0)
                {
                    query = "SELECT COUNT(wr.IDWAREHOUSE_RACKS) as TOTAL_RACKS FROM [dbo].[WAREHOUSE_RACKS] as wr WHERE wr.IDWAREHOUSE = @value1 AND TYPE = @value2 AND ID_CLIENT = @value3";
                }

                SqlCommand cmd = new SqlCommand(query, _connection);
                cmd.Parameters.AddWithValue("@value1", idWarehouse);
                cmd.Parameters.AddWithValue("@value2", rackType);
                if (idClient > 0)
                {
                    cmd.Parameters.AddWithValue("@value3", idClient);
                }
                _dr = await cmd.ExecuteReaderAsync();
                while (_dr.Read())
                {
                    last = int.Parse(_dr["TOTAL_RACKS"].ToString());
                }

                _connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
                message = "Mensaje:" + ex.Message;
                _connection.Close();
            }

            return last;
        }



        public async Task<List<int>> GetRacksIDListByWarehouse(int idWarehouse)
        {
            List<int> result = new List<int>();

            try
            {
                _connection.Open();
                string query = "SELECT IDWAREHOUSE_RACKS FROM [dbo].[WAREHOUSE_RACKS]  WHERE IDWAREHOUSE = @value1;";

                SqlCommand cmd = new SqlCommand(query, _connection);
                cmd.Parameters.AddWithValue("@value1", idWarehouse);
                _dr = await cmd.ExecuteReaderAsync();
                while (_dr.Read())
                {
                    result.Add(int.Parse(_dr["IDWAREHOUSE_RACKS"].ToString()));
                }

                _connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
                message = "Mensaje:" + ex.Message;
                _connection.Close();
            }

            return result;
        }

        public async Task<List<WarehouseRack>> GetRacksListByWarehouse(int idWarehouse, int rackType, int idClient)
        {
            List<WarehouseRack> result = new List<WarehouseRack>();

            try
            {
                _connection.Open();
                string query = "SELECT * FROM [dbo].[WAREHOUSE_RACKS]  WHERE IDWAREHOUSE = @value1 AND TYPE = @value2 AND VALID = 1;";

                if (rackType == 2)//bahias
                {
                    query = "SELECT * FROM [dbo].[WAREHOUSE_RACKS]  WHERE IDWAREHOUSE = @value1 AND TYPE = @value2 AND ID_CLIENT = @value3 AND VALID = 1;";
                }

                SqlCommand cmd = new SqlCommand(query, _connection);
                cmd.Parameters.AddWithValue("@value1", idWarehouse);
                cmd.Parameters.AddWithValue("@value2", rackType);
                if(rackType == 2)//solo para bahias asignadas a un cliente
                {
                    cmd.Parameters.AddWithValue("@value3", idClient);
                }
                //cmd.Parameters.AddWithValue("@value3", 1);
                _dr = await cmd.ExecuteReaderAsync();
                while (_dr.Read())
                {
                    WarehouseRack rack = new WarehouseRack
                    {
                        IDRACK = (int)_dr["IDWAREHOUSE_RACKS"],
                        idWarehouse = (int)_dr["IDWAREHOUSE"],
                        name = (string)_dr["NAME"],
                        //rack.description = (string)_dr["DESCRIPTION"];
                        type = (int)_dr["TYPE"],
                        totalPositions = (int)_dr["TOTAL_POSITIONS"],
                        levels = (int)_dr["LEVELS"]
                    };
                    //rack.valid = (int)_dr["VALID"];
                    result.Add(rack);
                }

                _connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                message = "Mensaje:" + ex.Message;
                _connection.Close();
            }

            return result;
        }


        public async Task<int> GetLatestWarehouseID()
        {
            int last = 0;

            try
            {
                _connection.Open();
                string query = "SELECT MAX(IDWAREHOUSES) AS ULT_CLAVE FROM [dbo].[WAREHOUSES];";

                SqlCommand cmd = new SqlCommand(query, _connection);
                _dr = await cmd.ExecuteReaderAsync();
                while (_dr.Read())
                {
                    last = int.Parse(_dr["ULT_CLAVE"].ToString());
                }

                _connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
                message = "Mensaje:" + ex.Message;
                _connection.Close();
            }

            return last;
        }

        public Clients getClientsListWithID(int idClient)
        {
            Clients result = new Clients();

            try
            {
                _connection.Open();
                string query = "SELECT c.IDCLIENTS, c.NAME, c.PREFIX FROM dbo.CLIENTS c WHERE c.VALID = 1 AND c.IDCLIENTS = @value1;";

                SqlCommand cmd = new SqlCommand(query, _connection);
                cmd.Parameters.AddWithValue("@value1", idClient);
                _dr = cmd.ExecuteReader();
                while (_dr.Read())
                {
                    result = new Clients
                    {
                        IDCLIENTS = (int)_dr["IDCLIENTS"],
                        NAME = (string)_dr["NAME"],
                        PREFIX = (string)_dr["PREFIX"],
                    };
                }

                _connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
                message = "Mensaje:" + ex.Message;
                _connection.Close();
            }

            return result;
        }

        public InvoiceItem getInvoiceIteam(string SERIAL)
        {
            InvoiceItem item = new InvoiceItem();

            try
            {
                _connection.Open();
                string query = "SELECT * FROM [dbo].[INVOICE_ITEMS] WHERE SERIAL = @SERIAL;";

                SqlCommand cmd = new SqlCommand(query, _connection);
                cmd.Parameters.AddWithValue("@SERIAL", SERIAL);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    
                    item.IDINVOICE_ITEMS = (int)reader["IDINVOICE_ITEMS"];
                    item.IDINVOICE_HEADERS = (int)reader["IDINVOICE_HEADERS"];
                    item.IDINVOICE_PALLETS = (int)reader["IDINVOICE_PALLETS"];
                    item.IDPRODUCTS = (int)reader["IDPRODUCTS"];
                    item.QUANTITY = float.Parse(reader["QUANTITY"].ToString());
                    item.INVOICE = reader["INVOICE"].ToString();
                    item.BATCH = reader["BATCH"].ToString();
                    item.EXTERNAL_SERIAL = reader["EXTERNAL_SERIAL"].ToString();
                    item.EXPIRATION_DATE = reader["EXPIRATION_DATE"].ToString();
                    item.REVISION = reader["REVISION"].ToString();
                    item.IDWAREHOUSE_RACKS_POSITIONS = reader["IDWAREHOUSE_RACKS_POSITIONS"].ToString();
                    item.CUSTOMS_DOCUMENT = reader["CUSTOMS_DOCUMENT"].ToString();
                    item.PROFORMA = reader["PROFORMA"].ToString();
                    item.SERIAL = reader["SERIAL"].ToString();
                    item.PACKING_LIST = reader["PACKING_LIST"].ToString();
                    item.BOXES = (int)reader["BOXES"];
                    item.IDCLIENT_PROVIDERS = (int)reader["IDCLIENT_PROVIDERS"];
                    item.DESCRIPTION = reader["DESCRIPTION"].ToString();
                    item.IDMEASURING_UNIT = (int)reader["IDMEASURING_UNIT"];
                    item.WEIGHT = float.Parse(reader["WEIGHT"].ToString());
                    item.UNIT_VALUE = reader["UNIT_VALUE"].ToString();
                    item.IDCURRENCY = (int)reader["IDCURRENCY"];
                    item.TARIFF_FRACTION = reader["TARIFF_FRACTION"].ToString();
                    item.IDCOUNTRIES = (int)reader["IDCOUNTRIES"];
                    item.STATUS = reader["STATUS"].ToString();
                    item.CREATE_AT = reader["CREATE_AT"].ToString();
                    item.UPDATED_AT = reader["UPDATED_AT"].ToString();
                    item.SESSION_IDSESSION = (int)reader["SESSION_IDSESSION"];
                    item.VALID = (bool)reader["VALID"];
                    item.PEDIMENTOADUANAL = reader["PEDIMENTOADUANAL"].ToString();
                    item.ID_INTERNAL_WAREHOUSE = (int)reader["ID_INTERNAL_WAREHOUSE"];
                    item.REGIMEN = reader["REGIMEN"].ToString();
                    item.REMISION = reader["REMISION"].ToString();
                    item.PEDIMENTO_DATE = reader["PEDIMENTO_DATE"].ToString();
                    item.PAY_DATE = reader["PAY_DATE"].ToString();
                    item.CONTAINER = reader["CONTAINER"].ToString();
                    

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
                message = "Mensaje:" + ex.Message;
                
            }
            _connection.Close();
            return item;
        }

        public async Task<List<WarehouseRack_Position>> GetWarehousePositions(int rackId)
        {
            List<WarehouseRack_Position> result = new List<WarehouseRack_Position>();

            try
            {
                _connection.Open();
                string query = "SELECT * FROM [dbo].[WAREHOUSE_RACKS_POSITIONS] WHERE IDWAREHOUSE_RACKS = @value1;";

                SqlCommand cmd = new SqlCommand(query, _connection);
                cmd.Parameters.AddWithValue("@value1", rackId);
                _dr = await cmd.ExecuteReaderAsync();
                while (_dr.Read())
                {
                    WarehouseRack_Position temp = new WarehouseRack_Position
                    {
                        idPosition = (int)_dr["IDWAREHOUSE_RACKS_POSITIONS"],
                        idRack = (int)_dr["IDWAREHOUSE_RACKS"],
                        name = (string)_dr["NAME"],
                        level = (int)_dr["LEVEL"],
                        //temp.max_weight = int.Parse(_dr["MAX_WEIGHT"].ToString());
                        //temp.priority = int.Parse(_dr["PRIORITY"].ToString());
                        type = (int)_dr["TYPE"],
                        //temp.excluded = int.Parse(_dr["EXCLUDED"].ToString());                    
                        valid = (bool)_dr["VALID"]
                    };
                    result.Add(temp);
                }

                _connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
                message = "Mensaje:" + ex.Message;
                _connection.Close();
            }

            return result;
        }

        public async Task<List<WarehouseRack_Position>> GetWarehousePositionsOnUse(int rackId)
        {
            List<WarehouseRack_Position> result = new List<WarehouseRack_Position>();

            try
            {
                _connection.Open();
                string query = "SELECT *  from [dbo].[WAREHOUSE_RACKS_POSITIONS] AS wrp WHERE wrp.IDWAREHOUSE_RACKS_POSITIONS IN (SELECT i.IDWAREHOUSE_RACK_POSITIONS FROM [dbo].[INVENTORY] i WHERE i.STATUS = 1 ) and wrp.IDWAREHOUSE_RACKS = @value1 and wrp.VALID = 1;";

                SqlCommand cmd = new SqlCommand(query, _connection);
                cmd.Parameters.AddWithValue("@value1", rackId);
                _dr = await cmd.ExecuteReaderAsync();
                while (_dr.Read())
                {
                    WarehouseRack_Position temp = new WarehouseRack_Position
                    {
                        idPosition = (int)_dr["IDWAREHOUSE_RACKS_POSITIONS"],
                        idRack = (int)_dr["IDWAREHOUSE_RACKS"],
                        name = (string)_dr["NAME"],
                        level = (int)_dr["LEVEL"],
                        //temp.max_weight = int.Parse(_dr["MAX_WEIGHT"].ToString());
                        //temp.priority = int.Parse(_dr["PRIORITY"].ToString());
                        type = (int)_dr["TYPE"],
                        //temp.excluded = int.Parse(_dr["EXCLUDED"].ToString());                    
                        valid = (bool)_dr["VALID"]
                    };
                    result.Add(temp);
                }

                _connection.Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error : " + ex.Message);
                message = "Mensaje:" + ex.Message;
                _connection.Close();
            }

            return result;
        }

        public List<TransferTableRow> GetInventaryByPartNumber(string partNumber)
        {
            List<TransferTableRow> result = new List<TransferTableRow>();

            try
            {
                _connection.Open();

                string query = "SELECT inv.IDINVENTORY, i.SERIAL, p.PART_NUMBER_PROVIDER, p.PART_NUMBER_CLIENT, i.DESCRIPTION, inv.QUANTITY, i.INVOICE, i.PEDIMENTOADUANAL, wrp.NAME AS POSITION_NAME,  wrp.IDWAREHOUSE_RACKS_POSITIONS, wr.NAME AS RACK_NAME, wr.IDWAREHOUSE_RACKS, wh.NAME AS WAREHOUSE_NAME, wh.IDWAREHOUSES, cp.IDCLIENTE_PROVIDERS, cp.NAME AS CLIENT_NAME,  i.EXPIRATION_DATE, i.EXTERNAL_SERIAL, i.BATCH FROM INVOICE_ITEMS i INNER JOIN INVENTORY inv ON inv.ID_INVOICE_ITEM = i.IDINVOICE_ITEMS INNER JOIN PRODUCTS p ON p.IDPRODUCTS = i.IDPRODUCTS INNER JOIN WAREHOUSE_RACKS_POSITIONS wrp  ON wrp.IDWAREHOUSE_RACKS_POSITIONS = inv.IDWAREHOUSE_RACK_POSITIONS INNER JOIN WAREHOUSE_RACKS wr ON wr.IDWAREHOUSE_RACKS = wrp.IDWAREHOUSE_RACKS INNER JOIN WAREHOUSES wh ON wh.IDWAREHOUSES = wr.IDWAREHOUSE INNER JOIN CLIENTS_PROVIDERS cp ON cp.IDCLIENTE_PROVIDERS = i.IDCLIENT_PROVIDERS WHERE p.PART_NUMBER_PROVIDER LIKE '%' + @value1 + '%';";

                SqlCommand cmd = new SqlCommand(query, _connection);
                cmd.Parameters.AddWithValue("@value1", partNumber);
                _dr = cmd.ExecuteReader();
                int localId = 1;
                while (_dr.Read())
                {
                    TransferTableRow temp = new TransferTableRow();

                    temp.idInventory = (int)_dr["IDINVENTORY"];
                    temp.localId = localId++;
                    temp.serial = (string)_dr["SERIAL"];
                    temp.partNumberProvider = (string)_dr["PART_NUMBER_PROVIDER"];
                    temp.partNumberClient = (string)_dr["PART_NUMBER_CLIENT"];
                    temp.description = (string)_dr["DESCRIPTION"];
                    temp.quantity = (double)_dr["QUANTITY"];
                    temp.rackPositionName = (string)_dr["POSITION_NAME"];
                    temp.rackPositionId = (int)_dr["IDWAREHOUSE_RACKS_POSITIONS"];
                    temp.rackName = (string)_dr["RACK_NAME"];
                    temp.idRack = (int)_dr["IDWAREHOUSE_RACKS"];
                    temp.warehouse = (string)_dr["WAREHOUSE_NAME"];
                    temp.idWarehouse = (int)_dr["IDWAREHOUSES"];
                    temp.clientId = (int)_dr["IDCLIENTE_PROVIDERS"];
                    temp.clientName = (string)_dr["CLIENT_NAME"];
                    temp.expirationDate = (DateTime)_dr["EXPIRATION_DATE"];
                    temp.externalSerial = (string)_dr["EXTERNAL_SERIAL"];
                    temp.batch = (string)_dr["BATCH"];
                    temp.invoice = (string)_dr["INVOICE"];
                    temp.pedimentoAduanal = (string)_dr["PEDIMENTOADUANAL"];

                    result.Add(temp);
                }

                _connection.Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error : " + ex.Message);
                message = "Mensaje:" + ex.Message;
                _connection.Close();
            }

            return result;
        }


        public List<int> GetFreePositionsByWarehouse(int idWarehouse, int numPositions)
        {
            List<int> result = new List<int>();

            try
            {
                _connection.Open();

                string query = "DECLARE @limite INT = @value1; SELECT TOP (@limite) wrp.IDWAREHOUSE_RACKS_POSITIONS FROM dbo.WAREHOUSE_RACKS_POSITIONS wrp INNER JOIN dbo.WAREHOUSE_RACKS wr ON wr.IDWAREHOUSE_RACKS = wrp.IDWAREHOUSE_RACKS INNER JOIN dbo.WAREHOUSES wh ON wh.IDWAREHOUSES = wr.IDWAREHOUSE WHERE wrp.IDWAREHOUSE_RACKS_POSITIONS NOT IN (SELECT i.IDWAREHOUSE_RACK_POSITIONS FROM [dbo].[INVENTORY] i WHERE i.STATUS = 1 AND i.IDWAREHOUSE_RACK_POSITIONS IS NOT NULL) AND wh.IDWAREHOUSES = @value2 AND wrp.VALID = 1;";

                SqlCommand cmd = new SqlCommand(query, _connection);
                cmd.Parameters.AddWithValue("@value1", numPositions);
                cmd.Parameters.AddWithValue("@value2", idWarehouse);
                _dr = cmd.ExecuteReader();

                while (_dr.Read())
                {
                    result.Add((int)_dr["IDWAREHOUSE_RACKS_POSITIONS"]);
                }

                _connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
                message = "Mensaje:" + ex.Message;
                _connection.Close();
            }

            return result;
        }

        public List<int> GetFreePositionsByRack(int idRack, int numPositions)
        {
            List<int> result = new List<int>();

            try
            {
                _connection.Open();

                string query = "DECLARE @limite INT = @value1; SELECT TOP (@limite) wrp.IDWAREHOUSE_RACKS_POSITIONS FROM dbo.WAREHOUSE_RACKS_POSITIONS wrp WHERE wrp.IDWAREHOUSE_RACKS_POSITIONS NOT IN (SELECT i.IDWAREHOUSE_RACK_POSITIONS FROM [dbo].[INVENTORY] i WHERE i.STATUS = 1 AND i.IDWAREHOUSE_RACK_POSITIONS IS NOT NULL) AND wrp.IDWAREHOUSE_RACKS = @value2;";

                SqlCommand cmd = new SqlCommand(query, _connection);
                cmd.Parameters.AddWithValue("@value1", numPositions);
                cmd.Parameters.AddWithValue("@value2", idRack);
                _dr = cmd.ExecuteReader();

                while (_dr.Read())
                {
                    result.Add((int)_dr["IDWAREHOUSE_RACKS_POSITIONS"]);
                }

                _connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
                message = "Mensaje:" + ex.Message;
                _connection.Close();
            }
            return result;
        }

        public async Task<Dictionary<string, Invoice_items>> GetSerialNumbersListPending()
        {
            Dictionary<string, Invoice_items> result = new Dictionary<string, Invoice_items>();

            try
            {
                _connection.Open();

                string query = "SELECT it.IDINVOICE_ITEMS, it.SERIAL FROM INVOICE_ITEMS it WHERE it.STATUS = 1 AND it.IDWAREHOUSE_RACKS_POSITIONS IS NULL AND it.VALID = 1;";

                SqlCommand cmd = new SqlCommand(query, _connection);
                _dr = await cmd.ExecuteReaderAsync();

                while (_dr.Read())
                {
                    Invoice_items temp = new Invoice_items();
                    temp.idInvoice = (int)_dr["IDINVOICE_ITEMS"];
                    temp.serial = (string)_dr["SERIAL"];
                    result.Add((string)_dr["SERIAL"], temp);
                }

                _connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
                message = "Mensaje:" + ex.Message;
                _connection.Close();
            }

            return result;
        }

        public async Task<Dictionary<string, Invoice_items>> GetSerialNumbersListLocated(int idWarehouse)
        {
            Dictionary<string, Invoice_items> result = new Dictionary<string, Invoice_items>();

            try
            {
                _connection.Open();

                string query = "SELECT it.IDINVOICE_ITEMS, it.SERIAL FROM INVOICE_ITEMS it INNER JOIN WAREHOUSE_RACKS_POSITIONS wrp ON wrp.IDWAREHOUSE_RACKS_POSITIONS = it.IDWAREHOUSE_RACKS_POSITIONS INNER JOIN WAREHOUSE_RACKS wr ON wr.IDWAREHOUSE_RACKS = wrp.IDWAREHOUSE_RACKS INNER JOIN WAREHOUSES w ON w.IDWAREHOUSES = wr.IDWAREHOUSE WHERE it.STATUS = 1 AND w.IDWAREHOUSES = @value1 AND it.VALID = 1;";

                SqlCommand cmd = new SqlCommand(query, _connection);
                cmd.Parameters.AddWithValue("@value1", idWarehouse);
                _dr = await cmd.ExecuteReaderAsync();

                while (_dr.Read())
                {
                    Invoice_items temp = new Invoice_items();
                    temp.idInvoice = (int)_dr["IDINVOICE_ITEMS"];
                    temp.serial = (string)_dr["SERIAL"];
                    result.Add((string)_dr["SERIAL"], temp);
                }

                _connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
                message = "Mensaje:" + ex.Message;
                _connection.Close();
            }

            return result;
        }

        /*
         * Obtiene el nombre e ID de ubicaciones de un almacen completo [Racks], los nombres de ubicaciones son unicos por almacen, no importa si es rack o bahia
        */
        public async Task<Dictionary<string, WarehouseRack_Position>> GetPositionsNameByWarehouse(int idWarehouse)
        {
            Dictionary<string, WarehouseRack_Position> result = new Dictionary<string, WarehouseRack_Position>();

            try
            {
                _connection.Open();

                string query = "SELECT wrp.NAME, wrp.IDWAREHOUSE_RACKS_POSITIONS FROM WAREHOUSE_RACKS_POSITIONS wrp INNER JOIN WAREHOUSE_RACKS wr ON wr.IDWAREHOUSE_RACKS = wrp.IDWAREHOUSE_RACKS INNER JOIN WAREHOUSES w ON w.IDWAREHOUSES = wr.IDWAREHOUSE AND w.IDWAREHOUSES = @value1 AND wrp.VALID = 1 AND wr.TYPE = 1;";

                SqlCommand cmd = new SqlCommand(query, _connection);
                cmd.Parameters.AddWithValue("@value1", idWarehouse);
                _dr = await cmd.ExecuteReaderAsync();

                while (_dr.Read())
                {
                    WarehouseRack_Position temp = new WarehouseRack_Position();
                    temp.idPosition = (int)_dr["IDWAREHOUSE_RACKS_POSITIONS"];
                    temp.name = (string)_dr["NAME"];
                    result.Add((string)_dr["NAME"], temp);
                }

                _connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
                message = "Mensaje:" + ex.Message;
                _connection.Close();
            }

            return result;
        }
        /*
         * Obtener posiciones de bahias por cliente
        */
        public async Task<Dictionary<string, WarehouseRack_Position>> GetBahiaPositionsByWarehouseAndClient(int idWarehouse, int idClient)
        {
            Dictionary<string, WarehouseRack_Position> result = new Dictionary<string, WarehouseRack_Position>();

            try
            {
                _connection.Open();

                string query = "SELECT wrp.NAME, wrp.IDWAREHOUSE_RACKS_POSITIONS FROM WAREHOUSE_RACKS_POSITIONS wrp INNER JOIN WAREHOUSE_RACKS wr ON wr.IDWAREHOUSE_RACKS = wrp.IDWAREHOUSE_RACKS INNER JOIN WAREHOUSES w ON w.IDWAREHOUSES = wr.IDWAREHOUSE AND w.IDWAREHOUSES = @value1 AND wrp.VALID = 1 AND wr.TYPE = 2 AND wr.ID_CLIENT = @value2;";

                SqlCommand cmd = new SqlCommand(query, _connection);
                cmd.Parameters.AddWithValue("@value1", idWarehouse);
                cmd.Parameters.AddWithValue("@value2", idClient);
                _dr = await cmd.ExecuteReaderAsync();

                while (_dr.Read())
                {
                    WarehouseRack_Position temp = new WarehouseRack_Position();
                    temp.idPosition = (int)_dr["IDWAREHOUSE_RACKS_POSITIONS"];
                    temp.name = (string)_dr["NAME"];
                    result.Add((string)_dr["NAME"], temp);
                }

                _connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
                message = "Mensaje:" + ex.Message;
                _connection.Close();
            }

            return result;
        }



        public int GetIdWarehouses(string NAME)
        {
            int last = 0;
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT [IDWAREHOUSES] FROM [dbo].[WAREHOUSES] WHERE [NAME] = '" + NAME + "' ", _connection);
                _dr = cmd.ExecuteReader();
                while (_dr.Read())
                {
                    int.Parse(_dr["IDWAREHOUSES"].ToString());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
                message = "Mensaje:" + ex.Message;
                _connection.Close();
            }

            _connection.Close();
            return last;
        }

        public int GetIdInternalWarehouses(string NAME)
        {
            int last = 0;
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT [ID_INTERNAL_W] FROM [dbo].[INTERNAL_WAREHOUSES] WHERE [NAME] = @NAME ", _connection);
                cmd.Parameters.AddWithValue("@NAME", NAME);
                _dr = cmd.ExecuteReader();
                while (_dr.Read())
                {
                    last = int.Parse(_dr["ID_INTERNAL_W"].ToString());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
                message = "Mensaje:" + ex.Message;

            }

            _connection.Close();
            return last;
        }

        public DataTable getdatatable(string invoice)
        {
            try
            {
                _connection.Open();                                                //Abrimos la conexion 
                string query = String.Concat("SELECT P.PART_NUMBER_PROVIDER AS Código,P.PART_NUMBER_CLIENT AS NumeroParteCliente,P.DESCRIPTION AS Nombre,I.SERIAL AS Serie,I.BOXES AS Cantidad,I.COST AS Costo,I.PRICE AS Precio,I.INVOICE AS Factura,I.REGIMEN AS Regimen,I.PEDIMENTOADUANAL AS Pedimento,I.PEDIMENTO_DATE AS FechaPedimento,I.EXPIRATION_DATE AS Caduca,W.SHORT_NAME AS Ubicación,I.BATCH AS Lote,I.QUANTITY AS Piezas,M.ABREVIATION AS Unidad,B.NAME AS Bodega,C.NAME AS Provedor,I.CONTAINER AS Contenedor,I.CREATE_AT AS FechaRecepcion,I.PAY_DATE AS FechaPagar,I.REMISION AS Remision,H.RECEIVES AS Recibio FROM [dbo].[INVOICE_ITEMS] I,[dbo].[INVOICE_HEADERS] H,[dbo].[PRODUCTS] P,[dbo].[WAREHOUSES] W,[dbo].[INTERNAL_WAREHOUSES] B,[dbo].[CLIENTS_PROVIDERS] C,[MEASURING_UNIT] M WHERE I.INVOICE='" + invoice + "' AND I.INVOICE=H.INVOICE AND I.IDPRODUCTS=P.IDPRODUCTS AND H.IDWAREHOUSES=W.IDWAREHOUSES AND I.ID_INTERNAL_WAREHOUSE=B.ID_INTERNAL_W AND I.IDCLIENT_PROVIDERS=C.IDCLIENTE_PROVIDERS AND P.MEASSURMENT_UNIT=M.IDMEASURING_UNIT"); //Creamos la consulta para ver los datos
                SqlCommand comando = new SqlCommand(query, _connection);           //Clase para ejecutar comandos SQL usando la conexion actual
                SqlDataAdapter adaptador = new SqlDataAdapter(comando);         //Adaptador de datos para rellenar una tabla
                DataTable registros = new DataTable();                          //Almacenamos los registros en una tabla
                adaptador.Fill(registros);                                      //Llenamos la tabla con datos
                _connection.Close();                                               //Terminamos la conexion

                return registros;
            }
            catch (Exception e)
            {
                _connection.Close();                                   //Cerramos la conexion en caso de error
                MessageBox.Show("Error de Conexion: " + e.Message); //Mostrar mensaje de error
                return null;
            }

        }

        public DataTable getdatatableInventary(int option, string data, int idclient,bool type)
        {
            try
            {
                DataTable registros = new DataTable();
                _connection.Open();
                string baseQuery = string.Empty;
                if (type)
                {
                    baseQuery = "SELECT P.DESCRIPTION AS Nombre, P.PART_NUMBER_PROVIDER AS Código, I.SERIAL AS Serie, I.INVOICE AS Factura, I.DESCRIPTION AS Descripción, I.BATCH AS Lote, I.CREATE_AT AS FechaRecepcion " +
                            "FROM [dbo].[INVOICE_ITEMS] I " +
                            "INNER JOIN [dbo].[INVOICE_HEADERS] H ON I.INVOICE = H.INVOICE " +
                            "INNER JOIN [dbo].[PRODUCTS] P ON I.IDPRODUCTS = P.IDPRODUCTS " +
                            "INNER JOIN [dbo].[WAREHOUSES] W ON H.IDWAREHOUSES = W.IDWAREHOUSES " +
                            "INNER JOIN [dbo].[INTERNAL_WAREHOUSES] B ON I.ID_INTERNAL_WAREHOUSE = B.ID_INTERNAL_W " +
                            "INNER JOIN [dbo].[MEASURING_UNIT] M ON P.MEASSURMENT_UNIT = M.IDMEASURING_UNIT " +
                            "INNER JOIN [dbo].[INVENTORY] N ON N.ID_INVOICE_ITEM = I.IDINVOICE_ITEMS " +
                            "INNER JOIN [dbo].[CLIENTS_PROVIDERS] C ON C.IDCLIENTE_PROVIDERS = I.IDCLIENT_PROVIDERS " +
                            "LEFT JOIN [dbo].[WAREHOUSE_RACKS_POSITIONS] R ON N.IDWAREHOUSE_RACK_POSITIONS = R.IDWAREHOUSE_RACKS_POSITIONS " +
                            "WHERE N.VALID = 1 AND C.IDCLIENTE = @idclient ";
                }
                else
                {
                    baseQuery = "SELECT P.PART_NUMBER_PROVIDER AS Código, P.DESCRIPTION AS Nombre, I.SERIAL AS Serie, I.INVOICE AS Factura, I.BATCH AS Lote, RH.CREATE_AT AS FechaSalida, RH.ID_REMISSION_HEADER AS Remision, COALESCE(CD1.name, 'N/A') AS Recibio, COALESCE(CD2.name, 'N/A') AS Responsable " +
                            "FROM [dbo].[INVOICE_ITEMS] I " +
                            "INNER JOIN [dbo].[INVOICE_HEADERS] H ON I.INVOICE = H.INVOICE " +
                            "INNER JOIN [dbo].[REMISSION_HEADER] RH ON I.REMISION = RH.ID_REMISSION_HEADER " +
                            "INNER JOIN [dbo].[CLIENTS_DESTINATIONS] CD1 ON RH.CLIENT_DESTINATION = CD1.IDCLIENTE_DESTINATIONS " +
                            "INNER JOIN [dbo].[CLIENTS_DESTINATIONS] CD2 ON RH.PURCHASE_ORDER_ID_CLIENT = CD2.IDCLIENTE_DESTINATIONS  " +
                            "INNER JOIN [dbo].[PRODUCTS] P ON I.IDPRODUCTS = P.IDPRODUCTS " +
                            "INNER JOIN [dbo].[WAREHOUSES] W ON H.IDWAREHOUSES = W.IDWAREHOUSES " +
                            "INNER JOIN [dbo].[INTERNAL_WAREHOUSES] B ON I.ID_INTERNAL_WAREHOUSE = B.ID_INTERNAL_W " +
                            "INNER JOIN [dbo].[MEASURING_UNIT] M ON P.MEASSURMENT_UNIT = M.IDMEASURING_UNIT " +
                            "INNER JOIN [dbo].[INVENTORY] N ON N.ID_INVOICE_ITEM = I.IDINVOICE_ITEMS " +
                            "INNER JOIN [dbo].[CLIENTS_PROVIDERS] C ON C.IDCLIENTE_PROVIDERS = I.IDCLIENT_PROVIDERS " +
                            "LEFT JOIN [dbo].[WAREHOUSE_RACKS_POSITIONS] R ON N.IDWAREHOUSE_RACK_POSITIONS = R.IDWAREHOUSE_RACKS_POSITIONS " +
                            "WHERE N.VALID = 1 AND C.IDCLIENTE = @idclient ";
                }

                //string baseQuery = "SELECT P.PART_NUMBER_PROVIDER AS Código, P.DESCRIPTION AS Nombre, I.SERIAL AS Serie, I.INVOICE AS Factura, I.BATCH AS Lote, N.QUANTITY AS Piezas, M.ABREVIATION AS Unidad, R.NAME AS Lugar, B.NAME AS Bodega, W.NAME AS Ubicación, I.CREATE_AT AS FechaRecepcion, @clients " +
                

                string condition = string.Empty;

                switch (option)
                {
                    case -1:
                        break;
                    case 0:
                        condition = " AND I.SERIAL = @data";
                        break;
                    case 1:
                        condition = " AND I.INVOICE = @data";
                        break;
                    case 2:
                        condition = " AND I.BATCH = @data";
                        break;
                    case 3:
                        condition = " AND P.PART_NUMBER_PROVIDER = @data";
                        break;
                    case 4:
                        condition = " AND P.DESCRIPTION = @data";
                        break;
                    case 5:
                        condition = " AND CD1.NAME = @data";
                        break;
                    case 6:
                        condition = " AND CD2.NAME = @data";
                        break;
                    default:
                        _connection.Close();
                        return registros;
                }

                string query = baseQuery + condition;
                using (SqlCommand comando = new SqlCommand(query, _connection))
                {
                    comando.Parameters.AddWithValue("@idclient", idclient);
                    if (option != -1)
                    {
                        comando.Parameters.AddWithValue("@data", data);
                    }
                    SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                    adaptador.Fill(registros);
                }

                _connection.Close();
                return registros;
            }
            catch (Exception e)
            {
                _connection.Close();                                   //Cerramos la conexion en caso de error
                MessageBox.Show("Error de Conexion: " + e.Message); //Mostrar mensaje de error
                return null;
            }


        }
        public string GetPartClient(int IDPRODUCT)
        {
            string last = "0";
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT [PART_NUMBER_CLIENT] FROM [dbo].[PRODUCTS] WHERE [IDPRODUCTS] = @IDPRODUCT ", _connection);
                cmd.Parameters.AddWithValue("@IDPRODUCT", IDPRODUCT);
                _dr = cmd.ExecuteReader();
                while (_dr.Read())
                {
                    last = _dr["PART_NUMBER_CLIENT"].ToString();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
                message = "Mensaje:" + ex.Message;
                _connection.Close();
            }

            _connection.Close();
            return last;
        }

        public bool searchInvoice(string invoice)
        {
            string last = "";
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT [INVOICE] FROM [dbo].[INVOICE_HEADERS] WHERE [INVOICE] = '" + invoice + "' ", _connection);
                _dr = cmd.ExecuteReader();
                while (_dr.Read())
                {
                    last = _dr["INVOICE"].ToString();
                }
                _connection.Close();
                if (last == invoice)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
                message = "Mensaje:" + ex.Message;

            }
            return false;

        }


        public string GetPartClientwhitPartProvider(string idclient, string partprovider)
        {
            string last = "";
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT [PART_NUMBER_CLIENT] FROM [dbo].[PRODUCTS] WHERE [IDCLIENTE] = " + idclient + " AND [PART_NUMBER_PROVIDER] ='" + partprovider + "'", _connection);
                _dr = cmd.ExecuteReader();
                while (_dr.Read())
                {
                    last = _dr["PART_NUMBER_CLIENT"].ToString();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
                message = "Mensaje:" + ex.Message;

            }

            _connection.Close();
            return last;
        }

        public string GetidMeasuring_unit(string idclient, string partprovider)
        {
            string last = "";
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT [MEASSURMENT_UNIT] FROM [dbo].[PRODUCTS] WHERE [IDCLIENTE] = " + idclient + " AND [PART_NUMBER_PROVIDER]='" + partprovider + "'", _connection);
                _dr = cmd.ExecuteReader();
                while (_dr.Read())
                {
                    last = _dr["MEASSURMENT_UNIT"].ToString();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
                message = "Mensaje:" + ex.Message;

            }

            _connection.Close();
            return last;
        }

        public string GetAbreviationMeasuring_unit(string idmeasuringunit)
        {
            string last = "";
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT [ABREVIATION] FROM [dbo].[MEASURING_UNIT] WHERE [IDMEASURING_UNIT] = " + idmeasuringunit, _connection);
                _dr = cmd.ExecuteReader();
                while (_dr.Read())
                {
                    last = _dr["ABREVIATION"].ToString();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
                message = "Mensaje:" + ex.Message;

            }

            _connection.Close();
            return last;
        }

        public int GetIdSession(string IDUSER)
        {
            int last = 0;
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT [IDSESSIONS] FROM [dbo].[SESSIONS] WHERE [IDUSER] = @ID", _connection);
                cmd.Parameters.AddWithValue("@ID", IDUSER);
                _dr = cmd.ExecuteReader();
                while (_dr.Read())
                {
                    last = int.Parse(_dr["IDSESSIONS"].ToString());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
                message = "Mensaje:" + ex.Message;
                _connection.Close();
            }

            _connection.Close();
            return last;
        }

        public int GetIdProducts(string PARTNUMBER)
        {
            int last = 0;
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT [IDPRODUCTS] FROM [dbo].[PRODUCTS] WHERE [PART_NUMBER_PROVIDER] = @PARTNUMBER ", _connection);
                cmd.Parameters.AddWithValue("@PARTNUMBER", PARTNUMBER);
                _dr = cmd.ExecuteReader();
                while (_dr.Read())
                {
                    last = int.Parse(_dr["IDPRODUCTS"].ToString());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
                message = "Mensaje:" + ex.Message;
                _connection.Close();
            }

            _connection.Close();
            return last;
        }

        public int GetIdClientProvider(string NAME, int IDCLIENTS)
        {
            int last = 0;
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT [IDCLIENTE_PROVIDERS] FROM [dbo].[CLIENTS_PROVIDERS] WHERE [NAME] = @NAME AND [IDCLIENTE] = @IDCLIENTS" , _connection);
                cmd.Parameters.AddWithValue("@NAME", NAME);
                cmd.Parameters.AddWithValue("@IDCLIENTS", IDCLIENTS);
                _dr = cmd.ExecuteReader();
                while (_dr.Read())
                {
                    last = int.Parse(_dr["IDCLIENTE_PROVIDERS"].ToString());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
                message = "Mensaje:" + ex.Message;
                _connection.Close();
            }

            _connection.Close();
            return last;
        }

        public DataTable GetValuesFromProduct(int IDPRODUCT)
        {
            DataTable Values = new DataTable();
            try
            {
                _connection.Open();
                string query = String.Concat("SELECT [MEASSURMENT_UNIT],[WEIGHT],[UNIT_VALUE],[CURRENCY],[TARIFF_FRACTION],[ORIGIN_COUNTRY] FROM [dbo].[PRODUCTS] WHERE [IDPRODUCTS] = @IDPRODUCT");
                SqlCommand cmd = new SqlCommand(query, _connection);
                cmd.Parameters.AddWithValue("@IDPRODUCT", IDPRODUCT);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(Values);
                /*SqlCommand cmd = new SqlCommand("SELECT [MEASSURMENT_UNIT],[WEIGHT],[UNIT_VALUE],[CURRENCY],[TARIFF_FRACTION],[ORIGIN_COUNTRY] FROM [dbo].[PRODUCTS] WHERE [IDPRODUCTS] = " + idproduct, _connection);
                _dr = cmd.ExecuteReader();
                while (_dr.Read())
                {
                    string value = _dr.GetString(0);
                    Values.Add(value);
                }*/

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
                message = "Mensaje:" + ex.Message;
                _connection.Close();
            }

            _connection.Close();
            return Values;
        }


        public int GetLastIdInvoiceHeader()
        {
            int last = 0;
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT [IDINVOICE_HEADERS] FROM [dbo].[INVOICE_HEADERS] ORDER by IDINVOICE_HEADERS ASC", _connection);
                _dr = cmd.ExecuteReader();
                while (_dr.Read())
                {
                    last = int.Parse(_dr["IDINVOICE_HEADERS"].ToString());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
                message = "Mensaje:" + ex.Message;
                _connection.Close();
            }

            _connection.Close();
            return last;
        }

        public int GetLastIdInvoicePallet()
        {
            int last = 0;
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT [IDINVOICE_PALLETS] FROM [dbo].[INVOICE_PALLETS] ORDER by IDINVOICE_PALLETS ASC", _connection);
                _dr = cmd.ExecuteReader();
                while (_dr.Read())
                {
                    last = int.Parse(_dr["IDINVOICE_PALLETS"].ToString());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
                message = "Mensaje:" + ex.Message;
                _connection.Close();
            }

            _connection.Close();
            return last;
        }

        public int GetLastIdInvoiceItem()
        {
            int last = 0;
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT [IDINVOICE_ITEMS] FROM [dbo].[INVOICE_ITEMS] ORDER by IDINVOICE_ITEMS ASC", _connection);
                _dr = cmd.ExecuteReader();
                while (_dr.Read())
                {
                    last = int.Parse(_dr["IDINVOICE_ITEMS"].ToString());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
                message = "Mensaje:" + ex.Message;
                _connection.Close();
            }

            _connection.Close();
            return last;
        }

        public string GetLastSerial()
        {
            string last = "";
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT RIGHT([SERIAL],4) AS SERIAL FROM [dbo].[INVOICE_ITEMS] ORDER by IDINVOICE_ITEMS ASC", _connection);
                _dr = cmd.ExecuteReader();
                while (_dr.Read())
                {
                    last = _dr["SERIAL"].ToString();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
                message = "Mensaje:" + ex.Message;
                _connection.Close();
            }

            _connection.Close();
            return last;
        }

        public string GetIdClientInvoiceHeader(string invoice)
        {
            string last = "";
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT [IDCLIENTE] FROM [dbo].[INVOICE_HEADERS] WHERE [INVOICE] = '" + invoice + "'", _connection);
                _dr = cmd.ExecuteReader();
                while (_dr.Read())
                {
                    last = _dr["IDCLIENTE"].ToString();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
                message = "Mensaje:" + ex.Message;

            }

            _connection.Close();
            return last;
        }

        public string GetStausItem(int IDINVOICE_ITEMS)
        {
            string last = "";
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT [STATUS] FROM [dbo].[INVOICE_ITEMS] WHERE [IDINVOICE_ITEMS] = '" + IDINVOICE_ITEMS + "' ", _connection);
                _dr = cmd.ExecuteReader();
                while (_dr.Read())
                {
                    last = _dr["STATUS"].ToString();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
                message = "Mensaje:" + ex.Message;

            }

            _connection.Close();
            return last;
        }

        public int GetStausRemission(string ID_REMISSION_HEADER)
        {
            int last = 0;
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT [STATUS] FROM [dbo].[REMISSION_HEADER] WHERE [ID_REMISSION_HEADER] = @ID_REMISSION_HEADER", _connection);
                cmd.Parameters.AddWithValue("@ID_REMISSION_HEADER", ID_REMISSION_HEADER);
                _dr = cmd.ExecuteReader();
                while (_dr.Read())
                {
                    last = int.Parse(_dr["STATUS"].ToString());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
                message = "Mensaje:" + ex.Message;

            }

            _connection.Close();
            return last;
        }
        #endregion

        #region Strings[]
        public Clients FillDateClients(string NAME)
        {
            Clients dateClient = new Clients();
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM CLIENTS WHERE NAME = '" + NAME + "'", _connection);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    dateClient.IDCLIENTS = int.Parse(dr["IDCLIENTS"].ToString());
                    dateClient.NAME = dr["NAME"].ToString();
                    dateClient.SHORT_NAME = dr["SHORT_NAME"].ToString();
                    dateClient.DOCUMNET_NAME = dr["DOCUMNET_NAME"].ToString();
                    dateClient.PREFIX = dr["PREFIX"].ToString();
                    dateClient.TYPE = int.Parse(dr["TYPE"].ToString());
                    dateClient.COUNTRY = int.Parse(dr["COUNTRY"].ToString());
                    dateClient.STATE = dr["STATE"].ToString();
                    dateClient.CITY = dr["CITY"].ToString();
                    dateClient.DISTRICT = dr["DISTRICT"].ToString();
                    dateClient.STREET = dr["STREET"].ToString();
                    dateClient.ZIPCODE = dr["ZIPCODE"].ToString();
                    dateClient.IMMEX = dr["IMMEX"].ToString();
                    dateClient.RFC = dr["RFC"].ToString();
                    dateClient.CONTACT_EMAIL = dr["CONTACT_EMAIL"].ToString();
                    dateClient.CONTACT_NUMBER = dr["CONTACT_NUMBER"].ToString();
                    dateClient.AUTOMATIC_EMAIL_INVOICE = int.Parse(dr["AUTOMATIC_EMAIL_INVOICE"].ToString());
                    dateClient.AUTOMATIC_EMAIL_REMISSION = int.Parse(dr["AUTOMATIC_EMAIL_REMISSION"].ToString());
                    dateClient.AUTOMATIC_EMAIL_INVENTARY = int.Parse(dr["AUTOMATIC_EMAIL_INVENTARY"].ToString());
                    //dateClient.WAREHOUSE = int.Parse(dr["WAREHOUSE"].ToString());
                    dateClient.CREATE_AT = dr["CREATE_AT"].ToString();
                    dateClient.UPDATED_AT = dr["UPDATED_AT"].ToString();
                    dateClient.SESSION_IDSESSION = dr["SESSION_IDSESSION"].ToString();
                    dateClient.VALID = bool.Parse(dr["VALID"].ToString());


                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
                message = "Mensaje:" + ex.Message;
                dateClient = null;
                _connection.Close();
            }
            _connection.Close();
            return dateClient;
        }

        public Users FillDateUser(string USERNAME)
        {
            Users DateUser = new Users();
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM USERS WHERE USERNAME = '" + USERNAME + "'", _connection);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    DateUser.IDUSER = int.Parse(dr["IDUSER"].ToString());
                    DateUser.USERNAME = dr["USERNAME"].ToString();
                    DateUser.NAME = dr["NAME"].ToString();
                    DateUser.LASTNAME = dr["LASTNAME"].ToString();
                    DateUser.PASSWORD = dr["PASSWORD"].ToString();
                    DateUser.EMAIL = dr["EMAIL"].ToString();
                    DateUser.PERMISSIONS = int.Parse(dr["PERMISSIONS"].ToString());

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
                message = "Mensaje:" + ex.Message;
                _connection.Close();
            }
            _connection.Close();
            return DateUser;
        }

        public string[] FillDateRepots(string NAME)
        {
            string[] DateUser = new string[4];
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM REPORTS WHERE NAME = '" + NAME + "'", _connection);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    DateUser[0] = dr["TEXT"].ToString();
                    DateUser[1] = dr["PATH"].ToString();
                    DateUser[2] = dr["QUERY"].ToString();
                    DateUser[3] = dr["GROUPBY"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
                message = "Mensaje:" + ex.Message;
                _connection.Close();
            }
            _connection.Close();
            return DateUser;
        }


        public string[] FillDateEmail(string ADDRESS, int IDCLIENT)
        {
            string[] DateEmails = new string[3];

            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM [CLIENT_EMAILS] WHERE ADDRESS = '" + ADDRESS + "' AND IDCLIENT = " + IDCLIENT + "", _connection);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    DateEmails[0] = dr["INVOICE"].ToString();
                    DateEmails[1] = dr["REMISSION"].ToString();
                    DateEmails[2] = dr["INVENTORY"].ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
                message = "Mensaje:" + ex.Message;
                _connection.Close();
            }
            _connection.Close();
            return DateEmails;
        }

        public Permisions FillDatePermissions(string WHERE)
        {
            Permisions dataPermisions = new Permisions();
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM DBO.PERMISSIONS WHERE " + WHERE + "", _connection);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    dataPermisions.NAME = dr["NAME"].ToString();
                    dataPermisions.DESCRIPTION = dr["DESCRIPTION"].ToString();
                    dataPermisions.USERS_ACCESS = Convert.ToBoolean(dr["USERS_ACCESS"]);
                    dataPermisions.USERS_CONSULT = Convert.ToBoolean(dr["USERS_CONSULT"]);
                    dataPermisions.USERS_CREATE = Convert.ToBoolean(dr["USERS_CREATE"]);
                    dataPermisions.USERS_EDIT = Convert.ToBoolean(dr["USERS_EDIT"]);
                    dataPermisions.USERS_DELETE = Convert.ToBoolean(dr["USERS_DELETE"]);
                    dataPermisions.CLIENTS_ACCESS = Convert.ToBoolean(dr["CLIENTS_ACCESS"]);
                    dataPermisions.CLIENTS_CONSULT = Convert.ToBoolean(dr["CLIENTS_CONSULT"]);
                    dataPermisions.CLIENTS_CREATE = Convert.ToBoolean(dr["CLIENTS_CREATE"]);
                    dataPermisions.CLIENTS_EDIT = Convert.ToBoolean(dr["CLIENTS_EDIT"]);
                    dataPermisions.CLIENTS_DELETE = Convert.ToBoolean(dr["CLIENTS_DELETE"]);
                    dataPermisions.PRODUCTS_ACCESS = Convert.ToBoolean(dr["PRODUCTS_ACCESS"]);
                    dataPermisions.PRODUCTS_CONSULT = Convert.ToBoolean(dr["PRODUCTS_CONSULT"]);
                    dataPermisions.PRODUCTS_CREATE = Convert.ToBoolean(dr["PRODUCTS_CREATE"]);
                    dataPermisions.PRODUCTS_EDIT = Convert.ToBoolean(dr["PRODUCTS_EDIT"]);
                    dataPermisions.PRODUCTS_DELETE = Convert.ToBoolean(dr["PRODUCTS_DELETE"]);
                    dataPermisions.INVOICES_ACCESS = Convert.ToBoolean(dr["INVOICES_ACCESS"]);
                    dataPermisions.INVOICES_CONSULT = Convert.ToBoolean(dr["INVOICES_CONSULT"]);
                    dataPermisions.INVOICES_CREATE = Convert.ToBoolean(dr["INVOICES_CREATE"]);
                    dataPermisions.INVOICES_EDIT = Convert.ToBoolean(dr["INVOICES_EDIT"]);
                    dataPermisions.INVOICES_DELETE = Convert.ToBoolean(dr["INVOICES_DELETE"]);
                    dataPermisions.REMISSIONS_ACCESS = Convert.ToBoolean(dr["REMISSIONS_ACCESS"]);
                    dataPermisions.REMISSIONS_CONSULT = Convert.ToBoolean(dr["REMISSIONS_CONSULT"]);
                    dataPermisions.REMISSIONS_CREATE = Convert.ToBoolean(dr["REMISSIONS_CREATE"]);
                    dataPermisions.REMISSIONS_EDIT = Convert.ToBoolean(dr["REMISSIONS_EDIT"]);
                    dataPermisions.REMISSIONS_DELETE = Convert.ToBoolean(dr["REMISSIONS_DELETE"]);
                    dataPermisions.TRANSFERS_ACCESS = Convert.ToBoolean(dr["TRANSFERS_ACCESS"]);
                    dataPermisions.TRANSFERS_CONSULT = Convert.ToBoolean(dr["TRANSFERS_CONSULT"]);
                    dataPermisions.TRANSFERS_CREATE = Convert.ToBoolean(dr["TRANSFERS_CREATE"]);
                    dataPermisions.TRANSFERS_EDIT = Convert.ToBoolean(dr["TRANSFERS_EDIT"]);
                    dataPermisions.TRANSFERS_DELETE = Convert.ToBoolean(dr["TRANSFERS_DELETE"]);
                    dataPermisions.INVENTORY_ACCESS = Convert.ToBoolean(dr["INVENTORY_ACCESS"]);
                    dataPermisions.LOG_ACCESS = Convert.ToBoolean(dr["LOG_ACCESS"]);
                    dataPermisions.LOG_CONSULT = Convert.ToBoolean(dr["LOG_CONSULT"]);
                    dataPermisions.LOG_CREATE = Convert.ToBoolean(dr["LOG_CREATE"]);
                    dataPermisions.LOG_EDIT = Convert.ToBoolean(dr["LOG_EDIT"]);
                    dataPermisions.LOG_DELETE = Convert.ToBoolean(dr["LOG_DELETE"]);
                    dataPermisions.CAN_AUTORISE = Convert.ToBoolean(dr["CAN_AUTORISE"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
                message = "Mensaje:" + ex.Message;
                _connection.Close();
            }
            _connection.Close();
            return dataPermisions;
        }


        public Destinations FillDateDestinations(string NAME, int IDCLIENT)
        {
            Destinations dateClientDestinatios = new Destinations();
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM [dbo].[CLIENTS_DESTINATIONS] WHERE NAME = '" + NAME + "' AND IDCLIENTE = " + IDCLIENT + "", _connection);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    dateClientDestinatios.IDCLIENTE_DESTINATIONS = int.Parse(dr["IDCLIENTE_DESTINATIONS"].ToString());
                    dateClientDestinatios.IDCLIENTE = int.Parse(dr["IDCLIENTE"].ToString());
                    dateClientDestinatios.NAME = dr["NAME"].ToString();
                    dateClientDestinatios.DESCRIPTION = dr["DESCRIPTION"].ToString();
                    dateClientDestinatios.COUNTRY = int.Parse(dr["COUNTRY"].ToString());
                    dateClientDestinatios.STATE = dr["STATE"].ToString();
                    dateClientDestinatios.CITY = dr["CITY"].ToString();
                    dateClientDestinatios.DISTRICT = dr["DISTRICT"].ToString();
                    dateClientDestinatios.STREET = dr["STREET"].ToString();
                    dateClientDestinatios.ZIPCODE = dr["ZIPCODE"].ToString();
                    dateClientDestinatios.IMMEX = dr["IMMEX"].ToString();
                    dateClientDestinatios.RFC = dr["RFC"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
                message = "Mensaje:" + ex.Message;
                _connection.Close();
            }
            _connection.Close();
            return dateClientDestinatios;
        }

        public Provider FillDateProviders(string NAME, int IDCLIENT)
        {
            Provider dateClientProviders = new Provider();
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM [dbo].[CLIENTS_PROVIDERS] WHERE NAME = '" + NAME + "' AND IDCLIENTE = " + IDCLIENT + "", _connection);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    dateClientProviders.IDCLIENTE_PROVIDERS = int.Parse(dr["IDCLIENTE_PROVIDERS"].ToString());
                    dateClientProviders.IDCLIENTE = int.Parse(dr["IDCLIENTE"].ToString());
                    dateClientProviders.NAME = dr["NAME"].ToString();
                    dateClientProviders.DESCRIPTION = dr["DESCRIPTION"].ToString();
                    
                    dateClientProviders.VALID = bool.Parse(dr["VALID"].ToString());

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
                message = "Mensaje:" + ex.Message;
                _connection.Close();
            }
            _connection.Close();
            return dateClientProviders;
        }

        public string[] FillDateWarehouse(string SHORT_NAME)
        {
            string[] DateWh = new string[8];
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM WAREHOUSES WHERE SHORT_NAME = '" + SHORT_NAME + "'", _connection);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    DateWh[0] = dr["short_name"].ToString();
                    DateWh[1] = dr["DESCRIPTION"].ToString();
                    DateWh[2] = dr["country"].ToString();
                    DateWh[3] = dr["state"].ToString();
                    DateWh[4] = dr["city"].ToString();
                    DateWh[5] = dr["district"].ToString();
                    DateWh[6] = dr["street"].ToString();
                    DateWh[7] = dr["zipcode"].ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
                message = "Mensaje:" + ex.Message;
                _connection.Close();
            }
            _connection.Close();
            return DateWh;
        }

        public Prod FillDateProducts(int IDPRODUCTS)
        {
            Prod DateProducts = new Prod();
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM PRODUCTS WHERE IDPRODUCTS = '" + IDPRODUCTS + "'", _connection);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    DateProducts.IDCLIENT = int.Parse(dr["IDCLIENTE"].ToString());
                    DateProducts.DESCRIPTION = dr["DESCRIPTION"].ToString();
                    DateProducts.PART_NUMBER_PROVIDER = dr["PART_NUMBER_PROVIDER"].ToString();
                    DateProducts.PART_NUMBER_CLIENT = dr["PART_NUMBER_CLIENT"].ToString();
                    DateProducts.REFERENCE = dr["REFERENCE"].ToString();
                    DateProducts.MEASSURMENT_UNIT = int.Parse(dr["MEASSURMENT_UNIT"].ToString());
                    DateProducts.WEIGHT = dr["WEIGHT"].ToString();
                    DateProducts.UNIT_VALUE = dr["UNIT_VALUE"].ToString();
                    DateProducts.CURRENCY = int.Parse(dr["CURRENCY"].ToString());
                    DateProducts.TARIFF_FRACTION = dr["TARIFF_FRACTION"].ToString();
                    DateProducts.ORIGIN_COUNTRY = int.Parse(dr["ORIGIN_COUNTRY"].ToString());
                    DateProducts.SESSION_IDSESSION = dr["SESSION_IDSESSION"].ToString();
                    DateProducts.ITEMS_PER_BOX = dr["ITEMS_PER_BOX"].ToString();
                    DateProducts.STANDARD_PACK_PALLET = dr["STANDARD_PACK_PALLET"].ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
                message = "Mensaje:" + ex.Message;
                _connection.Close();
            }
            _connection.Close();
            return DateProducts;
        }

        public Inventary FillDateInventory(int ID_INVOICE_ITEM)
        {
            Inventary DateInventary = new Inventary();
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM INVENTORY WHERE ID_INVOICE_ITEM = @ID_INVOICE_ITEM AND VALID = 'true'", _connection);
                cmd.Parameters.AddWithValue("@ID_INVOICE_ITEM", ID_INVOICE_ITEM);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    DateInventary.IDINVENTORY = int.Parse(dr["IDINVENTORY"].ToString());
                    DateInventary.ID_INVOICE_ITEM = int.Parse(dr["ID_INVOICE_ITEM"].ToString());
                    DateInventary.QUANTITY = int.Parse(dr["QUANTITY"].ToString());
                    DateInventary.IDWAREHOUSE_RACK_POSITIONS = dr["IDWAREHOUSE_RACK_POSITIONS"].ToString();
                    DateInventary.STATUS = int.Parse(dr["STATUS"].ToString());
                    DateInventary.VALID = bool.Parse(dr["VALID"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
                message = "Mensaje:" + ex.Message;
                DateInventary = new Inventary();
            }
            _connection.Close();
            return DateInventary;
        }

        public RemissionHeader FillRemissionHeader(string ID_REMISSION_HEADER, int IDCLIENT)
        {
            RemissionHeader DateRemissionHeader = new RemissionHeader();
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM REMISSION_HEADER WHERE ID_REMISSION_HEADER = @ID_REMISSION_HEADER AND CLIENT_ID = @IDCLIENT", _connection);
                cmd.Parameters.AddWithValue("@ID_REMISSION_HEADER", ID_REMISSION_HEADER);
                cmd.Parameters.AddWithValue("@IDCLIENT", IDCLIENT);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    DateRemissionHeader.ID_REMISSION_HEADER = dr["ID_REMISSION_HEADER"].ToString();
                    DateRemissionHeader.CLIENT_ID = int.Parse(dr["CLIENT_ID"].ToString());
                    DateRemissionHeader.CLIENT_DESTINATION = int.Parse(dr["CLIENT_DESTINATION"].ToString());
                    DateRemissionHeader.WORK_ORDER_ID = int.Parse(dr["WORK_ORDER_ID"].ToString());
                    DateRemissionHeader.PURCHASE_ORDER_ID_CLIENT = int.Parse(dr["PURCHASE_ORDER_ID_CLIENT"].ToString());
                    DateRemissionHeader.TOTAL_PALLETS = int.Parse(dr["TOTAL_PALLETS"].ToString());
                    DateRemissionHeader.TRANSPORT_INFO_ID = int.Parse(dr["TRANSPORT_INFO_ID"].ToString());
                    DateRemissionHeader.STATUS = int.Parse(dr["STATUS"].ToString());
                    DateRemissionHeader.CREATE_AT = dr["CREATE_AT"].ToString();
                    DateRemissionHeader.UPDATED_AT = dr["UPDATE_AT"].ToString();
                    DateRemissionHeader.REMISSION_AT = dr["REMISSION_AT"].ToString();
                    DateRemissionHeader.SESSION_ID = int.Parse(dr["SESSION_ID"].ToString());
                    DateRemissionHeader.VALID = bool.Parse(dr["VALID"].ToString());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
                message = "Mensaje:" + ex.Message;
                DateRemissionHeader = new RemissionHeader();
            }
            _connection.Close();
            return DateRemissionHeader;
        }
        #endregion

        #region ComboBox
        public void ClientsAComboBox(ComboBox COMBOBOX)
        {
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT SHORT_NAME FROM DBO.CLIENTS ", _connection);
                _dr = cmd.ExecuteReader();

                while (_dr.Read())
                {
                    COMBOBOX.Items.Add(_dr["SHORT_NAME"].ToString());
                }
                //COMBOBOX.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
            _connection.Close();
        }

        public void ClientsAComboBoxFromClient(ComboBox COMBOBOX)
        {
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT NAME FROM DBO.CLIENTS ", _connection);
                _dr = cmd.ExecuteReader();

                while (_dr.Read())
                {
                    COMBOBOX.Items.Add(_dr["NAME"].ToString());
                }
                //COMBOBOX.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
            _connection.Close();
        }

        public void ClientsTypeAComboBox(ComboBox COMBOBOX)
        {
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT NAME FROM DBO.CLIENTS_TYPE ", _connection);
                _dr = cmd.ExecuteReader();

                while (_dr.Read())
                {
                    COMBOBOX.Items.Add(_dr["NAME"].ToString());
                }
                //COMBOBOX.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
            _connection.Close();
        }

        public void ReportsAComboBox(ComboBox COMBOBOX)
        {
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT NAME FROM DBO.REPORTS WHERE VALID = 'TRUE'", _connection);
                _dr = cmd.ExecuteReader();

                while (_dr.Read())
                {
                    COMBOBOX.Items.Add(_dr["NAME"].ToString());
                }
                //COMBOBOX.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
            _connection.Close();
        }

        public void WarehouseAComboBox(ComboBox COMBOBOX)
        {
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT short_name FROM dbo.warehouses", _connection);
                _dr = cmd.ExecuteReader();

                while (_dr.Read())
                {
                    COMBOBOX.Items.Add(_dr["short_name"].ToString());
                }
                //COMBOBOX.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
            _connection.Close();
        }

        public string GetnameWarehouses(int IDWAREHOUSES)
        {
            string last = "";
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT [SHORT_NAME] FROM [dbo].[WAREHOUSES] WHERE [IDWAREHOUSES] = @IDWAREHOUSES ", _connection);
                cmd.Parameters.AddWithValue("@IDWAREHOUSES", IDWAREHOUSES);
                _dr = cmd.ExecuteReader();
                while (_dr.Read())
                {
                    last = _dr["SHORT_NAME"].ToString();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
                message = "Mensaje:" + ex.Message;

            }

            _connection.Close();
            return last;
        }

        public string GetidWarehousesFromuserwarehouse(int IDWAREHOUSES)
        {
            string last = "";
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT [SHORT_NAME] FROM [dbo].[WAREHOUSES] WHERE [IDWAREHOUSES] = @IDWAREHOUSES ", _connection);
                cmd.Parameters.AddWithValue("@IDWAREHOUSES", IDWAREHOUSES);
                _dr = cmd.ExecuteReader();
                while (_dr.Read())
                {
                    last = _dr["SHORT_NAME"].ToString();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
                message = "Mensaje:" + ex.Message;

            }

            _connection.Close();
            return last;
        }


        public void EmailAComboBox(ComboBox COMBOBOX, string CHAIN)
        {
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT ADDRESS FROM CLIENT_EMAILS WHERE IDCLIENT = " + CHAIN + "", _connection);
                _dr = cmd.ExecuteReader();

                while (_dr.Read())
                {
                    COMBOBOX.Items.Add(_dr["ADDRESS"].ToString());
                }
                //COMBOBOX.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
            _connection.Close();
        }

        public void ProductsATextBox(TextBox TEXTBOX, int IDCLINTE, string PART_NUMBER)
        {
            try
            {
                _connection.Open();

                SqlCommand cmd = new SqlCommand("SELECT DESCRIPTION FROM [dbo].[PRODUCTS] WHERE IDCLIENTE = @IDCLINTE AND PART_NUMBER_PROVIDER = @PART_NUMBER", _connection);
                cmd.Parameters.AddWithValue("@PART_NUMBER", PART_NUMBER);
                cmd.Parameters.AddWithValue("@IDCLINTE", IDCLINTE);
                _dr = cmd.ExecuteReader();

                while (_dr.Read())
                {
                    TEXTBOX.Text = _dr["DESCRIPTION"].ToString();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
            _connection.Close();
        }

        public void SerialATextBox(TextBox TEXTBOX, int IDCLINTE, string PART_NUMBER)
        {
            try
            {
                _connection.Open();

                SqlCommand cmd = new SqlCommand("SELECT PART_NUMBER_CLIENT FROM [dbo].[PRODUCTS] WHERE IDCLIENTE = @IDCLINTE AND PART_NUMBER_PROVIDER = @PART_NUMBER", _connection);
                cmd.Parameters.AddWithValue("@PART_NUMBER", PART_NUMBER);
                cmd.Parameters.AddWithValue("@IDCLINTE", IDCLINTE);
                _dr = cmd.ExecuteReader();

                while (_dr.Read())
                {
                    TEXTBOX.Text = _dr["PART_NUMBER_CLIENT"].ToString();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
            _connection.Close();
        }

        public void CostATextBox(TextBox TEXTBOX, int IDCLINTE, string PART_NUMBER_PROVIDER)
        {
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT UNIT_VALUE FROM [dbo].[PRODUCTS] WHERE IDCLIENTE = @IDCLINTE AND PART_NUMBER_PROVIDER = @PART_NUMBER_PROVIDER", _connection);
                cmd.Parameters.AddWithValue("@IDCLINTE", IDCLINTE);
                cmd.Parameters.AddWithValue("@PART_NUMBER_PROVIDER", PART_NUMBER_PROVIDER);
                _dr = cmd.ExecuteReader();

                while (_dr.Read())
                {
                    TEXTBOX.Text = _dr["UNIT_VALUE"].ToString();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
            _connection.Close();
        }

        
        public void ItemsPerBoxATextBox(TextBox TEXTBOX, int IDCLINTE, string PART_NUMBER_PROVIDER)
        {
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT ITEMS_PER_BOX FROM [dbo].[PRODUCTS] WHERE IDCLIENTE = @IDCLINTE AND PART_NUMBER_PROVIDER = @PART_NUMBER_PROVIDER ", _connection);
                cmd.Parameters.AddWithValue("@IDCLINTE", IDCLINTE);
                cmd.Parameters.AddWithValue("@PART_NUMBER_PROVIDER", PART_NUMBER_PROVIDER);
                _dr = cmd.ExecuteReader();

                while (_dr.Read())
                {
                    TEXTBOX.Text = _dr["ITEMS_PER_BOX"].ToString();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
            _connection.Close();
        }

        public void UserATextBox(TextBox TEXTBOX, int IDUSER)
        {
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT [NAME] FROM [dbo].[USERS] WHERE IDUSER = @IDUSER", _connection);
                cmd.Parameters.AddWithValue("@IDUSER", IDUSER);
                _dr = cmd.ExecuteReader();

                while (_dr.Read())
                {
                    TEXTBOX.Text = _dr["NAME"].ToString();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
            _connection.Close();
        }


        public void IdProductsAComboBox(ComboBox COMBOBOX, int IDCLINTE, List<string> lis)
        {
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT PART_NUMBER_PROVIDER FROM [dbo].[PRODUCTS] WHERE IDCLIENTE = @IDCLINTE ", _connection);
                cmd.Parameters.AddWithValue("@IDCLINTE", IDCLINTE);
                _dr = cmd.ExecuteReader();

                while (_dr.Read())
                {
                    COMBOBOX.Items.Add(_dr["PART_NUMBER_PROVIDER"].ToString());
                    lis.Add(_dr["PART_NUMBER_PROVIDER"].ToString());
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
            _connection.Close();
        }

        public void ContryAComboBox(ComboBox COMBOBOX)
        {
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT name FROM dbo.countries ", _connection);
                _dr = cmd.ExecuteReader();

                while (_dr.Read())
                {
                    COMBOBOX.Items.Add(_dr["name"].ToString());
                }
                //COMBOBOX.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
            _connection.Close();
        }

        public void PermissionsAComboBox(ComboBox COMBOBOX)
        {
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT NAME FROM dbo.PERMISSIONS ", _connection);
                _dr = cmd.ExecuteReader();

                while (_dr.Read())
                {
                    COMBOBOX.Items.Add(_dr["NAME"].ToString());
                }
                //COMBOBOX.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
            _connection.Close();
        }

        public void UserAComboBox(ComboBox COMBOBOX)
        {
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT USERNAME FROM dbo.USERS ", _connection);
                _dr = cmd.ExecuteReader();

                while (_dr.Read())
                {
                    COMBOBOX.Items.Add(_dr["USERNAME"].ToString());
                }
                //COMBOBOX.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
            _connection.Close();
        }

        public void MeasuringUnitAComboBox(ComboBox COMBOBOX)
        {
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT ABREVIATION FROM dbo.MEASURING_UNIT ", _connection);
                _dr = cmd.ExecuteReader();

                while (_dr.Read())
                {
                    COMBOBOX.Items.Add(_dr["ABREVIATION"].ToString());
                }
                //COMBOBOX.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
            _connection.Close();
        }

        public void CurrenciesAComboBox(ComboBox COMBOBOX)
        {
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT ABREVIATION FROM dbo.CURRENCIES ", _connection);
                _dr = cmd.ExecuteReader();

                while (_dr.Read())
                {
                    COMBOBOX.Items.Add(_dr["ABREVIATION"].ToString());
                }
                //COMBOBOX.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
            _connection.Close();
        }

        public void ProductsAComboBox(ComboBox COMBOBOX, int IDCLINTE)
        {
            try
            {
                _connection.Open();

                SqlCommand cmd = new SqlCommand("SELECT DESCRIPTION FROM [dbo].[PRODUCTS] WHERE IDCLIENTE = @IDCLINTE", _connection);
                cmd.Parameters.AddWithValue("@IDCLINTE", IDCLINTE);
                _dr = cmd.ExecuteReader();

                while (_dr.Read())
                {
                    COMBOBOX.Items.Add(_dr["DESCRIPTION"].ToString());
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
            _connection.Close();
        }

        public void DestinatiosAComboBox(ComboBox COMBOBOX, int IDCLINTE)
        {
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT NAME FROM [dbo].[CLIENTS_DESTINATIONS] WHERE IDCLIENTE = @IDCLINTE", _connection);
                cmd.Parameters.AddWithValue("@IDCLINTE", IDCLINTE);
                _dr = cmd.ExecuteReader();

                while (_dr.Read())
                {
                    COMBOBOX.Items.Add(_dr["NAME"].ToString());
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
            _connection.Close();
        }

        public void ProviderAComboBox(ComboBox COMBOBOX, int IDCLINTE)
        {
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT NAME FROM [dbo].[CLIENTS_PROVIDERS] WHERE IDCLIENTE = @IDCLINTE", _connection);
                cmd.Parameters.AddWithValue("@IDCLINTE", IDCLINTE);
                _dr = cmd.ExecuteReader();

                while (_dr.Read())
                {
                    COMBOBOX.Items.Add(_dr["NAME"].ToString());
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
            _connection.Close();
        }


        public void RemissionLoadAComboBox(ComboBox COMBOBOX, int IDCLINTE)
        {
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT ID_REMISSION_HEADER FROM [dbo].[REMISSION_HEADER] WHERE CLIENT_ID = @IDCLINTE  AND VALID = 'true' ORDER BY ID_REMISSION_HEADER DESC", _connection);
                cmd.Parameters.AddWithValue("@IDCLINTE", IDCLINTE);
                _dr = cmd.ExecuteReader();

                while (_dr.Read())
                {
                    COMBOBOX.Items.Add(_dr["ID_REMISSION_HEADER"].ToString());
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
            _connection.Close();
        }

        public void InvoiceLoadAComboBox(ComboBox COMBOBOX, int IDCLINTE)
        {
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT H.INVOICE AS INV FROM [dbo].[INVOICE_HEADERS] H WHERE EXISTS (SELECT 1 FROM [dbo].[INVOICE_ITEMS] I WHERE I.INVOICE = H.INVOICE) AND IDCLIENTE = @IDCLINTE ORDER BY INV DESC", _connection);
                cmd.Parameters.AddWithValue("@IDCLINTE", IDCLINTE);
                _dr = cmd.ExecuteReader();

                while (_dr.Read())
                { 
                   COMBOBOX.Items.Add(_dr["INV"].ToString());
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
            _connection.Close();
        }


        public void ProductsInNumPartAComboBox(ComboBox COMBOBOX, int IDCLINTE)
        {
            try
            {
                _connection.Open();

                SqlCommand cmd = new SqlCommand("SELECT DESCRIPTION, PART_NUMBER_PROVIDER FROM [dbo].[PRODUCTS] WHERE IDCLIENTE = @IDCLINTE ", _connection);
                cmd.Parameters.AddWithValue("@IDCLINTE", IDCLINTE);
                _dr = cmd.ExecuteReader();

                while (_dr.Read())
                {
                    var concat = _dr["DESCRIPTION"].ToString();
                    var concat2 = _dr["PART_NUMBER_PROVIDER"].ToString();
                    COMBOBOX.Items.Add(concat + "|" + concat2);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
            _connection.Close();
        }

        public void RemissionAComboBox(ComboBox COMBOBOX, int IDCLINTE)
        {
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT PART_NUMBER_PROVIDER FROM [dbo].[PRODUCTS] WHERE IDCLIENTE = @IDCLINTE ", _connection);
                cmd.Parameters.AddWithValue("@IDCLINTE", IDCLINTE);

                _dr = cmd.ExecuteReader();

                while (_dr.Read())
                {
                    COMBOBOX.Items.Add(_dr["PART_NUMBER_PROVIDER"].ToString());
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
            _connection.Close();
        }

        public void ListCompaniesAComboBox(ComboBox COMBOBOX, int IDUSER)
        {
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT COMPANY.COMPANY FROM DBO.COMPANY INNER JOIN  COMPANYANDUSER ON COMPANY.IDPERMISSIONS = COMPANYANDUSER.IDCOMPANY INNER JOIN USERINVENTARY ON COMPANYANDUSER.IDUSER = USERINVENTARY.IDUSER WHERE USERINVENTARY.IDUSER = @IDUSER ", _connection);
                cmd.Parameters.AddWithValue("@IDUSER", IDUSER);
                _dr = cmd.ExecuteReader();

                while (_dr.Read())
                {
                    COMBOBOX.Items.Add(_dr["COMPANY"].ToString());
                }
                COMBOBOX.SelectedIndex = 0;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
            _connection.Close();
        }

        public void ProvidersAComboBox(ComboBox COMBOBOX, int IDCLIENT)
        {
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT NAME FROM dbo.CLIENTS_PROVIDERS WHERE IDCLIENTE= @IDCLIENT ", _connection);
                cmd.Parameters.AddWithValue("@IDCLIENT", IDCLIENT);

                _dr = cmd.ExecuteReader();

                while (_dr.Read())
                {
                    COMBOBOX.Items.Add(_dr["NAME"].ToString());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
            _connection.Close();
        }

        public void BatchAComboBox(ComboBox COMBOBOX, int IDPRODUCTS, int ID_INTERNAL_WAREHOUSE)
        {
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT BATCH FROM dbo.INVOICE_ITEMS WHERE IDPRODUCTS= @IDPRODUCTS AND INVOICE_ITEMS.ID_INTERNAL_WAREHOUSE = @ID_INTERNAL_WAREHOUSE AND VALID = 'true'", _connection);
                cmd.Parameters.AddWithValue("@IDPRODUCTS", IDPRODUCTS);
                cmd.Parameters.AddWithValue("@ID_INTERNAL_WAREHOUSE", ID_INTERNAL_WAREHOUSE);
                _dr = cmd.ExecuteReader();

                while (_dr.Read())
                {
                    COMBOBOX.Items.Add(_dr["BATCH"].ToString());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
            _connection.Close();
        }

        public void BatchAComboBox(ComboBox COMBOBOX, string IDCLINTE, int ID_INTERNAL_WAREHOUSE)
        {
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT BATCH FROM dbo.INVOICE_ITEMS INNER JOIN INVOICE_HEADERS ON INVOICE_ITEMS.IDINVOICE_HEADERS = INVOICE_HEADERS.IDINVOICE_HEADERS WHERE INVOICE_HEADERS.IDCLIENTE = @IDCLINTE AND INVOICE_ITEMS.VALID = 'true' AND INVOICE_ITEMS.ID_INTERNAL_WAREHOUSE = @ID_INTERNAL_WAREHOUSE", _connection);
                cmd.Parameters.AddWithValue("@IDCLINTE", IDCLINTE);
                cmd.Parameters.AddWithValue("@ID_INTERNAL_WAREHOUSE", ID_INTERNAL_WAREHOUSE);
                _dr = cmd.ExecuteReader();

                while (_dr.Read())
                {
                    COMBOBOX.Items.Add(_dr["BATCH"].ToString());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
            _connection.Close();
        }

        public void SerialAComboBox(ComboBox COMBOBOX, int IDPRODUCTS, string BATCH, int ID_INTERNAL_WAREHOUSE)
        {
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT SERIAL FROM dbo.INVOICE_ITEMS WHERE IDPRODUCTS= @IDPRODUCTS AND BATCH = @BATCH AND INVOICE_ITEMS.ID_INTERNAL_WAREHOUSE = @ID_INTERNAL_WAREHOUSE AND VALID = 'true'", _connection);
                cmd.Parameters.AddWithValue("@IDPRODUCTS", IDPRODUCTS);
                cmd.Parameters.AddWithValue("@BATCH", BATCH);
                cmd.Parameters.AddWithValue("@ID_INTERNAL_WAREHOUSE", ID_INTERNAL_WAREHOUSE);
                _dr = cmd.ExecuteReader();

                while (_dr.Read())
                {
                    COMBOBOX.Items.Add(_dr["SERIAL"].ToString());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
            _connection.Close();
        }

        public void SerialNoIdProductsAComboBox(ComboBox COMBOBOX, string BATCH, int ID_INTERNAL_WAREHOUSE)
        {
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT SERIAL FROM dbo.INVOICE_ITEMS WHERE BATCH = @BATCH AND INVOICE_ITEMS.ID_INTERNAL_WAREHOUSE = @ID_INTERNAL_WAREHOUSE AND VALID = 'true'", _connection);
                cmd.Parameters.AddWithValue("@BATCH", BATCH);
                cmd.Parameters.AddWithValue("@ID_INTERNAL_WAREHOUSE", ID_INTERNAL_WAREHOUSE);
                _dr = cmd.ExecuteReader();

                while (_dr.Read())
                {
                    COMBOBOX.Items.Add(_dr["SERIAL"].ToString());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
            _connection.Close();
        }

        public void SerialNoIdProductsNoBatchAComboBox(ComboBox COMBOBOX, int IDCLIENT, int ID_INTERNAL_WAREHOUSE)
        {
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT SERIAL FROM dbo.INVOICE_ITEMS INNER JOIN INVOICE_HEADERS ON INVOICE_ITEMS.IDINVOICE_HEADERS = INVOICE_HEADERS.IDINVOICE_HEADERS WHERE INVOICE_HEADERS.IDCLIENTE = @IDCLIENT AND INVOICE_ITEMS.ID_INTERNAL_WAREHOUSE = @ID_INTERNAL_WAREHOUSE AND INVOICE_ITEMS.VALID = 'true'", _connection);
                cmd.Parameters.AddWithValue("@IDCLIENT", IDCLIENT);
                cmd.Parameters.AddWithValue("@ID_INTERNAL_WAREHOUSE", ID_INTERNAL_WAREHOUSE);
                _dr = cmd.ExecuteReader();

                while (_dr.Read())
                {
                    COMBOBOX.Items.Add(_dr["SERIAL"].ToString());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
            _connection.Close();
        }
        public void SerialNoBatchAComboBox(ComboBox COMBOBOX, int IDPRODUCTS, int ID_INTERNAL_WAREHOUSE)
        {
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT SERIAL FROM dbo.INVOICE_ITEMS WHERE IDPRODUCTS = @IDPRODUCTS AND VALID = 'true'", _connection);
                cmd.Parameters.AddWithValue("@IDPRODUCTS", IDPRODUCTS);
                cmd.Parameters.AddWithValue("@ID_INTERNAL_WAREHOUSE", ID_INTERNAL_WAREHOUSE);
                _dr = cmd.ExecuteReader();

                while (_dr.Read())
                {
                    COMBOBOX.Items.Add(_dr["SERIAL"].ToString());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
            _connection.Close();
        }

        public void SerchAComboBox(ComboBox COMBOBOX, int selectedItem, int IDCLIENT)
        {
            string query = string.Empty;
            string fieldName = string.Empty;

            switch (selectedItem)
            {
                case -1:
                    break;
                case 0:
                    query = $"SELECT DISTINCT I.SERIAL FROM [dbo].[INVOICE_ITEMS] I INNER JOIN [dbo].[INVOICE_HEADERS] H ON I.INVOICE = H.INVOICE  WHERE H.IDCLIENTE = @IDCLIENT";
                    fieldName = "SERIAL";
                    break;
                case 1:
                    query = $"SELECT DISTINCT I.INVOICE FROM [dbo].[INVOICE_ITEMS] I INNER JOIN [dbo].[INVOICE_HEADERS] H ON I.INVOICE = H.INVOICE WHERE H.IDCLIENTE = @IDCLIENT";
                    fieldName = "INVOICE";
                    break;
                case 2:
                    query = $"SELECT DISTINCT I.BATCH FROM [dbo].[INVOICE_ITEMS] I INNER JOIN [dbo].[INVOICE_HEADERS] H ON I.INVOICE = H.INVOICE WHERE H.IDCLIENTE = @IDCLIENT";
                    fieldName = "BATCH";
                    break;
                case 3:
                    query = $"SELECT DISTINCT PART_NUMBER_PROVIDER FROM [dbo].[PRODUCTS] WHERE IDCLIENTE = @IDCLIENT";
                    fieldName = "PART_NUMBER_PROVIDER";
                    break;
                case 4:
                    query = $"SELECT DISTINCT DESCRIPTION FROM [dbo].[PRODUCTS] WHERE IDCLIENTE = @IDCLIENT";
                    fieldName = "DESCRIPTION";
                    break;
                case 5:
                    query = $"SELECT DISTINCT CD1.NAME FROM [dbo].[CLIENTS_DESTINATIONS] CD1 WHERE CD1.IDCLIENTE = @IDCLIENT";
                    fieldName = "NAME";
                    break;
                case 6:
                    query = $"SELECT DISTINCT CD2.NAME FROM [dbo].[CLIENTS_DESTINATIONS] CD2 WHERE CD2.IDCLIENTE = @IDCLIENT";
                    fieldName = "NAME";
                    break;
                default:
                    break;
            }

            if (!string.IsNullOrEmpty(query))
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand(query, _connection);
                cmd.Parameters.AddWithValue("@IDCLIENT", IDCLIENT);
                _dr = cmd.ExecuteReader();

                while (_dr.Read())
                {
                    COMBOBOX.Items.Add(_dr[fieldName].ToString());
                }

                _connection.Close();
            }
            
        }

        #endregion

        #region Take
        public int TakeIdUser(string USERNAME)
        {
            int ultimo = 0;
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT IDUSER FROM [dbo].[USERS] WHERE USERNAME = '" + USERNAME + "' ", _connection);
                _dr = cmd.ExecuteReader();
                while (_dr.Read())
                {
                    ultimo = int.Parse(_dr["IDUSER"].ToString());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
                message = "Mensaje:" + ex.Message;


            }
            _connection.Close();
            return ultimo;
        }

        public int TakeIdInternalWarehouse(string USERNAME)
        {
            int ultimo = 0;
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT ID_INTERNAL_W FROM [dbo].[INTERNAL_WAREHOUSES] WHERE NAME = '" + USERNAME + "' ", _connection);
                _dr = cmd.ExecuteReader();
                while (_dr.Read())
                {
                    ultimo = int.Parse(_dr["ID_INTERNAL_W"].ToString());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
                message = "Mensaje:" + ex.Message;


            }
            _connection.Close();
            return ultimo;
        }

        public int TakeIdDestinations(string NAME)
        {
            int ultimo = 0;
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT IDCLIENTE_DESTINATIONS FROM [dbo].[CLIENTS_DESTINATIONS] WHERE NAME = @NAME", _connection);
                cmd.Parameters.AddWithValue("@NAME", NAME);
                _dr = cmd.ExecuteReader();
                while (_dr.Read())
                {
                    ultimo = int.Parse(_dr["IDCLIENTE_DESTINATIONS"].ToString());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
                message = "Mensaje:" + ex.Message;


            }
            _connection.Close();
            return ultimo;
        }

        public string TakeCurrency(int IDCURRENCY)
        {
            string ultimo = " ";
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT [ABREVIATION] FROM [dbo].[CURRENCIES] WHERE IDCURRENCIES = '" + IDCURRENCY + "' ", _connection);
                _dr = cmd.ExecuteReader();
                while (_dr.Read())
                {
                    ultimo = _dr["ABREVIATION"].ToString();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
                message = "Mensaje:" + ex.Message;


            }
            _connection.Close();
            return ultimo;
        }

        public string TakeDestinatios(int IDCLIENTE_DESTINATIONS, int IDCLIENTE)
        {
            string ultimo = " ";
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT [NAME] FROM [dbo].[CLIENTS_DESTINATIONS] WHERE IDCLIENTE_DESTINATIONS =  @IDCLIENTE_DESTINATIONS  AND IDCLIENTE = @IDCLIENTE", _connection);
                cmd.Parameters.AddWithValue("@IDCLIENTE_DESTINATIONS", IDCLIENTE_DESTINATIONS);
                cmd.Parameters.AddWithValue("@IDCLIENTE", IDCLIENTE);
                _dr = cmd.ExecuteReader();
                while (_dr.Read())
                {
                    ultimo = _dr["NAME"].ToString();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
                message = "Mensaje:" + ex.Message;


            }
            _connection.Close();
            return ultimo;
        }

        public int TakeTransport(int IDCLIENTS)
        {
            int ultimo = 0;
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT [IDTRANSPORT_INFO] FROM [dbo].[TRANSPORT_INFORMATION] WHERE IDCLIENTS = @IDCLIENTS", _connection);
                cmd.Parameters.AddWithValue("@IDCLIENTS", IDCLIENTS);
                _dr = cmd.ExecuteReader();
                while (_dr.Read())
                {
                    ultimo = int.Parse(_dr["IDTRANSPORT_INFO"].ToString());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
                message = "Mensaje:" + ex.Message;


            }
            _connection.Close();
            return ultimo;
        }

        public string TakePermissions(int IDPRODUCTS)
        {
            string ultimo = " ";
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT [NAME] FROM [dbo].[PERMISSIONS] WHERE IDPERMISSIONS = '" + IDPRODUCTS + "' ", _connection);
                _dr = cmd.ExecuteReader();
                while (_dr.Read())
                {
                    ultimo = _dr["NAME"].ToString();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
                message = "Mensaje:" + ex.Message;


            }
            _connection.Close();
            return ultimo;
        }

        public string TakeUnit(int IDMEASURING_UNIT)
        {
            string ultimo = " ";
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT [ABREVIATION] FROM [dbo].[MEASURING_UNIT] WHERE IDMEASURING_UNIT = '" + IDMEASURING_UNIT + "' ", _connection);
                _dr = cmd.ExecuteReader();
                while (_dr.Read())
                {
                    ultimo = _dr["ABREVIATION"].ToString();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
                message = "Mensaje:" + ex.Message;


            }
            _connection.Close();
            return ultimo;
        }

        public int TakeIdProducts(string PART_NUMBER)
        {

            int ultimo = 0;
            if (PART_NUMBER != "")
            {

                char[] separador = { '|' };
                string[] subcadenas = PART_NUMBER.Split(separador);
                try
                {
                    _connection.Open();
                    SqlCommand cmd = new SqlCommand("SELECT [IDPRODUCTS] FROM [dbo].[PRODUCTS] WHERE PART_NUMBER_PROVIDER = '" + subcadenas[1] + "' ", _connection);
                    _dr = cmd.ExecuteReader();
                    while (_dr.Read())
                    {
                        ultimo = int.Parse(_dr["IDPRODUCTS"].ToString());
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error : " + ex.Message);
                    message = "Mensaje:" + ex.Message;


                }
                _connection.Close();
                return ultimo;
            }

            return ultimo;
        }


        public string TakeEmais(int IDCLIENT_EMAILS, int IDCLIENT)
        {
            string ultimo = " ";
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT ADDRESS FROM [dbo].[CLIENT_EMAILS] WHERE IDCLIENT_EMAILS = " + IDCLIENT_EMAILS + " AND IDCLIENT = " + IDCLIENT + " ", _connection);
                _dr = cmd.ExecuteReader();
                while (_dr.Read())
                {
                    ultimo = _dr["ADDRESS"].ToString();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
                message = "Mensaje:" + ex.Message;


            }
            _connection.Close();
            return ultimo;
        }

        public string TakeClientType(int IDCLIENTE_TYPE)
        {
            string ultimo = " ";
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT NAME FROM [dbo].[CLIENTS_TYPE] WHERE IDCLIENTE_TYPE = " + IDCLIENTE_TYPE + " ", _connection);
                _dr = cmd.ExecuteReader();
                while (_dr.Read())
                {
                    ultimo = _dr["NAME"].ToString();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
                message = "Mensaje:" + ex.Message;


            }
            _connection.Close();
            return ultimo;
        }

        public string TakeWarehouse(int IDWAREHOUSES)
        {
            string ultimo = " ";
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT SHORT_NAME FROM [dbo].[WAREHOUSES] WHERE IDWAREHOUSES = " + IDWAREHOUSES + " ", _connection);
                _dr = cmd.ExecuteReader();
                while (_dr.Read())
                {
                    ultimo = _dr["SHORT_NAME"].ToString();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
                message = "Mensaje:" + ex.Message;


            }
            _connection.Close();
            return ultimo;
        }

        public string TakeContry(int IDCOUNTRIES)
        {
            string ultimo = " ";
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT NAME FROM [dbo].[COUNTRIES] WHERE IDCOUNTRIES = " + IDCOUNTRIES + " ", _connection);
                _dr = cmd.ExecuteReader();
                while (_dr.Read())
                {
                    ultimo = _dr["NAME"].ToString();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
                message = "Mensaje:" + ex.Message;


            }
            _connection.Close();
            return ultimo;
        }

        public Configurations TakeOutpotInvoice(int idClient)
        {
            Configurations ultimo = new Configurations();
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM [dbo].[CONFIGURATIONS] WHERE IDCLIENT = '" + idClient + "' ", _connection);
                _dr = cmd.ExecuteReader();
                while (_dr.Read())
                {
                    ultimo.IDCLIENT = int.Parse(_dr["IDCLIENT"].ToString());
                    ultimo.OUTPUT = int.Parse(_dr["OUTPUT"].ToString());
                    ultimo.ORDEROUTPUT = int.Parse(_dr["ORDEROUTPUT"].ToString());
                    ultimo.REMISSIONOUTPUT = int.Parse(_dr["REMISSIONOUTPUT"].ToString());
                    ultimo.PROFORMAOUTPUT = int.Parse(_dr["PROFORMAOUTPUT"].ToString());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
                message = "Mensaje:" + ex.Message;


            }
            _connection.Close();
            return ultimo;
        }
        #endregion

        #region DataGrid
        public DataTable ShowDataBinnacle()
        {
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT [DESCRIPTION] AS DESCRIPCION, [CREATE_AT] AS FECHA FROM [dbo].[BINNACLE] ORDER BY [CREATE_AT] DESC", _connection);
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                _ds = new DataSet();
                ad.Fill(_ds, "tabla");
                _connection.Close();
                return _ds.Tables["tabla"];
            }
            catch
            {
                MessageBox.Show("Archivo no encontrado");
                _connection.Close();
                return null;
            }

        }

        public DataTable ShowDataClientDestination(string NAME, int IDCLIENT)
        {
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM [dbo].[CLIENTS_DESTINATIONS] WHERE NAME = '" + NAME + "' AND IDCLIENTE = " + IDCLIENT + "", _connection);
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                _ds = new DataSet();
                ad.Fill(_ds, "tabla");
                _connection.Close();
                return _ds.Tables["tabla"];
            }
            catch
            {
                MessageBox.Show("Archivo no encontrado");
                _connection.Close();
                return null;
            }

        }

        public DataTable ShowDataRepots(string QUERY)
        {
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand(QUERY, _connection);
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                _ds = new DataSet();
                ad.Fill(_ds, "tabla");
                _connection.Close();
                return _ds.Tables["tabla"];
            }
            catch
            {
                MessageBox.Show("Archivo no encontrado");
                _connection.Close();
                return null;
            }

        }
        public DataTable ShowDataBinnacleRepots2()
        {
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM [dbo].[CLIENTS] ORDER BY [CREATE_AT] DESC", _connection);
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                _ds = new DataSet();
                ad.Fill(_ds, "tabla");
                _connection.Close();
                return _ds.Tables["tabla"];
            }
            catch
            {
                MessageBox.Show("Archivo no encontrado");
                _connection.Close();
                return null;
            }

        }

        public DataTable ShowDataProducts(int IDCLINTE)
        {
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT [DESCRIPTION] AS DESCRIPCION, [PART_NUMBER_PROVIDER] AS PROVEEDOR,  [CREATE_AT] AS FECHA FROM [dbo].[Products] WHERE IDCLIENTE = " + IDCLINTE + " ", _connection);
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                _ds = new DataSet();
                ad.Fill(_ds, "tabla");
                _connection.Close();
                return _ds.Tables["tabla"];
            }
            catch
            {
                MessageBox.Show("Archivo no encontrado");
                _connection.Close();
                return null;
            }

        }

        public DataTable SearchInProducts(int IDCLINTE, string search)
        {
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT [PART_NUMBER_PROVIDER] AS PROVEEDOR, [DESCRIPTION] AS DESCRIPCION, [CREATE_AT] AS FECHA FROM [dbo].[Products] WHERE IDCLIENTE = " + IDCLINTE + "  AND " + search + " ORDER BY [CREATE_AT] DESC", _connection);
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                _ds = new DataSet();
                ad.Fill(_ds, "tabla");
                _connection.Close();
                return _ds.Tables["tabla"];

            }
            catch
            {
                MessageBox.Show("Archivo no encontrado");
                _connection.Close();
                return null;
            }

        }
        public DataTable SearchInBinnacle(string search)
        {
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT [DESCRIPTION] AS DESCRIPCION, [CREATE_AT] AS FECHA FROM [dbo].[BINNACLE] WHERE " + search + " ORDER BY [CREATE_AT] DESC", _connection);
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                _ds = new DataSet();
                ad.Fill(_ds, "tabla");
                _connection.Close();
                return _ds.Tables["tabla"];
            }
            catch
            {
                MessageBox.Show("Archivo no encontrado");
                _connection.Close();
                return ShowDataBinnacle();
            }
        }

        public DataTable SearchInOrder(int IDCLINTE, string WHERE)
        {
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT INVOICE_ITEMS.IDINVOICE_ITEMS, INVOICE_ITEMS.SERIAL AS SERIAL, PRODUCTS.PART_NUMBER_PROVIDER AS NP, PRODUCTS.DESCRIPTION AS DESCRIPTION, MEASURING_UNIT.ABREVIATION AS UM, INVOICE_ITEMS.BOXES AS PIEZASXCAJA, INVENTORY.QUANTITY AS CANTIDAD, INVENTORY.IDWAREHOUSE_RACK_POSITIONS AS LOCAL, INVOICE_HEADERS.INVOICE AS FACTURA, CLIENTS_PROVIDERS.NAME AS PROVEEDOR, INVOICE_ITEMS.BATCH AS LOTE, INVOICE_ITEMS.CREATE_AT AS FECHA, INVOICE_ITEMS.PEDIMENTOADUANAL AS PEDIMENTO,INVOICE_ITEMS.REGIMEN FROM INVOICE_ITEMS INNER JOIN PRODUCTS ON PRODUCTS.IDPRODUCTS = INVOICE_ITEMS.IDPRODUCTS INNER JOIN INVENTORY ON INVENTORY.ID_INVOICE_ITEM = INVOICE_ITEMS.IDINVOICE_ITEMS INNER JOIN MEASURING_UNIT ON PRODUCTS.MEASSURMENT_UNIT = MEASURING_UNIT.IDMEASURING_UNIT INNER JOIN INVOICE_HEADERS ON INVOICE_HEADERS.IDINVOICE_HEADERS = INVOICE_ITEMS.IDINVOICE_HEADERS INNER JOIN CLIENTS_PROVIDERS ON CLIENTS_PROVIDERS.IDCLIENTE_PROVIDERS = IDCLIENT_PROVIDERS WHERE PRODUCTS.IDCLIENTE = @IDCLINTE AND INVOICE_ITEMS.VALID = 'true' " + WHERE + " ", _connection);
                cmd.Parameters.AddWithValue("@IDCLINTE", IDCLINTE);
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                _ds = new DataSet();
                ad.Fill(_ds, "tabla");
                _connection.Close();
                return _ds.Tables["tabla"];
            }
            catch
            {
                MessageBox.Show("Archivo no encontrado");
                _connection.Close();
                return null;
            }
        }

        public DataTable SearchInOrder(string chain, int IDCLINTE, bool oneDate, string WHERE)
        {
            try
            {
                _connection.Open();
                string sentency = null;
                if (oneDate)
                {
                    sentency = "SELECT CLIENTS.NAME, INVOICE_ITEMS.IDINVOICE_ITEMS, INVOICE_ITEMS.SERIAL AS SERIAL, PRODUCTS.PART_NUMBER_PROVIDER AS PROVPARTNUM, PRODUCTS.PART_NUMBER_CLIENT AS CUSTPARTNUM, PRODUCTS.DESCRIPTION AS DESCRIPTION, INVOICE_ITEMS.BOXES AS PC, INVENTORY.QUANTITY AS QTY, MEASURING_UNIT.ABREVIATION AS UM, WAREHOUSE_RACKS_POSITIONS.NAME AS LOCAL, INVOICE_HEADERS.INVOICE AS FACTURA, CLIENTS_PROVIDERS.NAME AS PROVEEDOR, INVOICE_ITEMS.BATCH AS LOTE, INVOICE_ITEMS.CREATE_AT AS FECHA, INVOICE_ITEMS.PEDIMENTOADUANAL AS PEDIMENTO,INVOICE_ITEMS.REGIMEN,INVOICE_ITEMS.COST AS PRECIO FROM INVOICE_ITEMS INNER JOIN PRODUCTS ON PRODUCTS.IDPRODUCTS = INVOICE_ITEMS.IDPRODUCTS INNER JOIN INVENTORY ON INVENTORY.ID_INVOICE_ITEM = INVOICE_ITEMS.IDINVOICE_ITEMS INNER JOIN MEASURING_UNIT ON PRODUCTS.MEASSURMENT_UNIT = MEASURING_UNIT.IDMEASURING_UNIT INNER JOIN INVOICE_HEADERS ON INVOICE_HEADERS.IDINVOICE_HEADERS = INVOICE_ITEMS.IDINVOICE_HEADERS INNER JOIN CLIENTS_PROVIDERS ON CLIENTS_PROVIDERS.IDCLIENTE_PROVIDERS = IDCLIENT_PROVIDERS INNER JOIN CLIENTS ON CLIENTS.IDCLIENTS = PRODUCTS.IDCLIENTE LEFT JOIN WAREHOUSE_RACKS_POSITIONS ON INVOICE_ITEMS.IDWAREHOUSE_RACKS_POSITIONS = WAREHOUSE_RACKS_POSITIONS.IDWAREHOUSE_RACKS_POSITIONS WHERE PRODUCTS.IDCLIENTE = @IDCLINTE AND INVOICE_ITEMS.VALID = 'true' " + WHERE + "  AND INVOICE_ITEMS.IDINVOICE_ITEMS =" + chain + "";
                }
                else
                {
                    sentency = "SELECT CLIENTS.NAME, INVOICE_ITEMS.IDINVOICE_ITEMS, INVOICE_ITEMS.SERIAL AS SERIAL, PRODUCTS.PART_NUMBER_PROVIDER AS PROVPARTNUM, PRODUCTS.PART_NUMBER_CLIENT AS CUSTPARTNUM, PRODUCTS.DESCRIPTION AS DESCRIPTION, INVOICE_ITEMS.BOXES AS PC, INVENTORY.QUANTITY AS QTY, MEASURING_UNIT.ABREVIATION AS UM, WAREHOUSE_RACKS_POSITIONS.NAME AS LOCAL, INVOICE_HEADERS.INVOICE AS FACTURA, CLIENTS_PROVIDERS.NAME AS PROVEEDOR, INVOICE_ITEMS.BATCH AS LOTE, INVOICE_ITEMS.CREATE_AT AS FECHA, INVOICE_ITEMS.PEDIMENTOADUANAL AS PEDIMENTO,INVOICE_ITEMS.REGIMEN,INVOICE_ITEMS.COST AS PRECIO FROM INVOICE_ITEMS INNER JOIN PRODUCTS ON PRODUCTS.IDPRODUCTS = INVOICE_ITEMS.IDPRODUCTS INNER JOIN INVENTORY ON INVENTORY.ID_INVOICE_ITEM = INVOICE_ITEMS.IDINVOICE_ITEMS INNER JOIN MEASURING_UNIT ON PRODUCTS.MEASSURMENT_UNIT = MEASURING_UNIT.IDMEASURING_UNIT INNER JOIN INVOICE_HEADERS ON INVOICE_HEADERS.IDINVOICE_HEADERS = INVOICE_ITEMS.IDINVOICE_HEADERS INNER JOIN CLIENTS_PROVIDERS ON CLIENTS_PROVIDERS.IDCLIENTE_PROVIDERS = IDCLIENT_PROVIDERS INNER JOIN CLIENTS ON CLIENTS.IDCLIENTS = PRODUCTS.IDCLIENTE LEFT JOIN WAREHOUSE_RACKS_POSITIONS ON INVOICE_ITEMS.IDWAREHOUSE_RACKS_POSITIONS = WAREHOUSE_RACKS_POSITIONS.IDWAREHOUSE_RACKS_POSITIONS WHERE PRODUCTS.IDCLIENTE = @IDCLINTE AND INVOICE_ITEMS.VALID = 'true' " + WHERE + " AND INVOICE_ITEMS.IDINVOICE_ITEMS IN (" + chain + ")";
                }
                SqlCommand cmd = new SqlCommand(sentency, _connection);
                cmd.Parameters.AddWithValue("@IDCLINTE", IDCLINTE);
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                _ds = new DataSet();
                ad.Fill(_ds, "tabla");
                _connection.Close();
                return _ds.Tables["tabla"];
            }
            catch
            {
                MessageBox.Show("Archivo no encontrado");
                _connection.Close();
                return null;
            }
        }

        public DataTable SearchInRemission(int IDCLINTE, string REMISION)
        {
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT CLIENTS.NAME, INVOICE_ITEMS.IDINVOICE_ITEMS, INVOICE_ITEMS.SERIAL AS SERIAL, PRODUCTS.PART_NUMBER_PROVIDER AS PROVPARTNUM, PRODUCTS.PART_NUMBER_CLIENT AS CUSTPARTNUM, PRODUCTS.DESCRIPTION AS DESCRIPTION,INVOICE_ITEMS.BOXES AS PC, INVENTORY.QUANTITY AS QTY, MEASURING_UNIT.ABREVIATION AS UM,  INVENTORY.IDWAREHOUSE_RACK_POSITIONS AS LOCAL, INVOICE_HEADERS.INVOICE AS FACTURA, CLIENTS_PROVIDERS.NAME AS PROVEEDOR, INVOICE_ITEMS.BATCH AS LOTE, INVOICE_ITEMS.CREATE_AT AS FECHA, INVOICE_ITEMS.PEDIMENTOADUANAL AS PEDIMENTO,INVOICE_ITEMS.REGIMEN,INVOICE_ITEMS.COST AS PRECIO,CURRENCIES.ABREVIATION AS CURRENCY,REMISSION_HEADER.REMISSION_AT,INVOICE_ITEMS.COST AS IMPORTE FROM INVOICE_ITEMS INNER JOIN PRODUCTS ON PRODUCTS.IDPRODUCTS = INVOICE_ITEMS.IDPRODUCTS INNER JOIN CURRENCIES ON CURRENCIES.IDCURRENCIES = PRODUCTS.CURRENCY INNER JOIN INVENTORY ON INVENTORY.ID_INVOICE_ITEM = INVOICE_ITEMS.IDINVOICE_ITEMS INNER JOIN MEASURING_UNIT ON PRODUCTS.MEASSURMENT_UNIT = MEASURING_UNIT.IDMEASURING_UNIT INNER JOIN INVOICE_HEADERS ON INVOICE_HEADERS.IDINVOICE_HEADERS = INVOICE_ITEMS.IDINVOICE_HEADERS INNER JOIN CLIENTS_PROVIDERS ON CLIENTS_PROVIDERS.IDCLIENTE_PROVIDERS = IDCLIENT_PROVIDERS INNER JOIN CLIENTS ON CLIENTS.IDCLIENTS = PRODUCTS.IDCLIENTE INNER JOIN REMISSION_HEADER ON ID_REMISSION_HEADER = INVOICE_ITEMS.REMISION  WHERE PRODUCTS.IDCLIENTE = @IDCLINTE AND INVOICE_ITEMS.REMISION = @REMISION ", _connection);
                cmd.Parameters.AddWithValue("@REMISION", REMISION);
                cmd.Parameters.AddWithValue("@IDCLINTE", IDCLINTE);
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                _ds = new DataSet();
                ad.Fill(_ds, "tabla");
                _connection.Close();
                return _ds.Tables["tabla"];
            }
            catch
            {
                MessageBox.Show("Archivo no encontrado");
                _connection.Close();
                return null;
            }
        }
        #endregion

        #region Other
        public string UserHasTheseClients(int IDUSER)
        {
            string last = null;

            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT ALLCOMPANY FROM [REPORTS].[dbo].[USERINVENTARY] WHERE USERINVENTARY.IDUSER = " + IDUSER + "", _connection);

                _dr = cmd.ExecuteReader();
                while (_dr.Read())
                {
                    last = _dr["ALLCOMPANY"].ToString();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
                message = "Mensaje:" + ex.Message;
            }
            _connection.Close();
            return last;
        }

        public bool existsRemission(string ID_REMISSION_HEADER)
        {
            try
            {
                _connection.Open();
                string query = "SELECT * FROM [dbo].[REMISSION_HEADER] WHERE ID_REMISSION_HEADER = @ID_REMISSION_HEADER";
                SqlCommand cmd = new SqlCommand(query, _connection);
                cmd.Parameters.AddWithValue("@ID_REMISSION_HEADER", ID_REMISSION_HEADER);


                _dr = cmd.ExecuteReader();

                while (_dr.Read())
                {
                    _connection.Close();
                    return true;
                }
                _connection.Close();
                return false;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Error :" + ex.Message);
                message = "Error :" + ex.Message;
                _connection.Close();
                return false;
            }
        }

        public bool existsPrefix(string PREFIX)
        {
            try
            {
                _connection.Open();
                string query = "SELECT * FROM [dbo].[CLIENTS] WHERE PREFIX = @PREFIX";
                SqlCommand cmd = new SqlCommand(query, _connection);
                cmd.Parameters.AddWithValue("@PREFIX", PREFIX);

                _dr = cmd.ExecuteReader();

                while (_dr.Read())
                {
                    _connection.Close();
                    return true;
                }
                _connection.Close();
                return false;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Error :" + ex.Message);
                message = "Error :" + ex.Message;
                _connection.Close();
                return false;
            }
        }

        #endregion

    }
}
