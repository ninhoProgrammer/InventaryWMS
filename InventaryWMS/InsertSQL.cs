using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace InventaryWMS
{
    internal class InsertSQL
    {
        public SqlConnection connection { get; set; }
        private SqlDataReader _dr { get; set; }
        public string message { get; set; }

        public InsertSQL()
        {
            connection = DBConections.GetConnection();
        }

        public void SaveToBinnacle(string logbooks)
        {
            try
            {
                connection.Open();
                DateTime date = DateTime.Now;
                string query = "INSERT INTO [dbo].[BINNACLE] ([DESCRIPTION],[CREATE_AT]) VALUES ('" + logbooks + "','" + date.ToString("yyyyMMdd hh:mm:ss") + "')";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Error :" + logbooks + " Mensaje:" + ex.Message);
                message = "Error :" + logbooks + " Mensaje:" + ex.Message;
            }

            connection.Close();

        }

        public async Task<bool> saveToSession(Warehouse warehouse)
        {
            try
            {
                connection.Open();
                string query = "INSERT INTO dbo.warehouses (name, short_name, description, country, state, city, district, street, zipcode, updated_at, valid) values(@value1, @value2, @value3, @value4, @value5, @value6, @value7, @value8, @value9, @value10, @value11)";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@value1", warehouse.NAME);
                cmd.Parameters.AddWithValue("@value2", warehouse.SHORT_NAME);
                cmd.Parameters.AddWithValue("@value3", warehouse.DESCRIPTION);
                cmd.Parameters.AddWithValue("@value4", warehouse.COUNTRY);
                cmd.Parameters.AddWithValue("@value5", warehouse.STATE);
                cmd.Parameters.AddWithValue("@value6", warehouse.CITY);
                cmd.Parameters.AddWithValue("@value7", warehouse.DISTRICT);
                cmd.Parameters.AddWithValue("@value8", warehouse.STREET);
                cmd.Parameters.AddWithValue("@value9", warehouse.ZIPCODE);
                cmd.Parameters.AddWithValue("@value10", DateTime.Now.ToString("yyyyMMdd"));
                cmd.Parameters.AddWithValue("@value11", warehouse.VALID);

                var res = await cmd.ExecuteNonQueryAsync();
                connection.Close();
                return true;
            }
            catch
            {
                connection.Close();
                return false;
            }
        }

        public async Task<bool> saveToWarehouses(Warehouse warehouse)
        {
            try
            {
                connection.Open();
                string query = "INSERT INTO dbo.warehouses (name, short_name, description, country, state, city, district, street, zipcode, updated_at, valid) values(@value1, @value2, @value3, @value4, @value5, @value6, @value7, @value8, @value9, @value10, @value11)";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@value1", warehouse.NAME);
                cmd.Parameters.AddWithValue("@value2", warehouse.SHORT_NAME);
                cmd.Parameters.AddWithValue("@value3", warehouse.DESCRIPTION);
                cmd.Parameters.AddWithValue("@value4", warehouse.COUNTRY);
                cmd.Parameters.AddWithValue("@value5", warehouse.STATE);
                cmd.Parameters.AddWithValue("@value6", warehouse.CITY);
                cmd.Parameters.AddWithValue("@value7", warehouse.DISTRICT);
                cmd.Parameters.AddWithValue("@value8", warehouse.STREET);
                cmd.Parameters.AddWithValue("@value9", warehouse.ZIPCODE);
                cmd.Parameters.AddWithValue("@value10", DateTime.Now.ToString("yyyyMMdd"));
                cmd.Parameters.AddWithValue("@value11", warehouse.VALID);

                var res = await cmd.ExecuteNonQueryAsync();
                connection.Close();
                return true;
            }
            catch
            {
                connection.Close();
                return false;
            }
        }

        public bool saveToWarehouseAClients(int IDCLIENT, int IDWAREHOUSE)
        {
            try
            {
                string query = "INSERT INTO [dbo].[CLIENTS_WAREHOUSE] (IDCLIENT, IDWAREHOUSE) values (@value1, @value2)";

                connection.Open();

                
                SqlCommand cmd = new SqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@value1", IDCLIENT);
                cmd.Parameters.AddWithValue("@value2", IDWAREHOUSE);
                cmd.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool saveToWarehouseRacks(WarehouseRack rack, int numRacks, char format)
        {
            try
            {
                string query = "INSERT INTO dbo.warehouse_racks (idwarehouse, name, type, levels) values (@value1, @value2, @value3, @value4)";

                connection.Open();

                for (int i = 0; i < numRacks; i++)
                {
                    rack.name = format.ToString();

                    SqlCommand cmd = new SqlCommand(query, connection);

                    cmd.Parameters.AddWithValue("@value1", rack.idWarehouse);
                    cmd.Parameters.AddWithValue("@value2", rack.name);
                    cmd.Parameters.AddWithValue("@value3", rack.type);
                    cmd.Parameters.AddWithValue("@value4", rack.levels);
                    cmd.ExecuteNonQuery();
                    format++;
                }
                connection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<int> saveWHRack(WarehouseRack rack)
        {
            try
            {
                string query = "INSERT INTO dbo.warehouse_racks (idwarehouse, name, type, total_positions,levels, valid, id_client) values (@value1, @value2, @value3, @value4, @value5, @value6, @value7); SELECT SCOPE_IDENTITY();";

                if (rack.clientId == null)
                {
                    query = "INSERT INTO dbo.warehouse_racks (idwarehouse, name, type, total_positions,levels, valid) values (@value1, @value2, @value3, @value4, @value5, @value6); SELECT SCOPE_IDENTITY();";

                }

                connection.Open();

                SqlCommand cmd = new SqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@value1", rack.idWarehouse);
                cmd.Parameters.AddWithValue("@value2", rack.name);
                cmd.Parameters.AddWithValue("@value3", rack.type);
                cmd.Parameters.AddWithValue("@value4", rack.totalPositions);
                cmd.Parameters.AddWithValue("@value5", rack.levels);
                cmd.Parameters.AddWithValue("@value6", rack.valid);
                if (rack.clientId != null)
                    cmd.Parameters.AddWithValue("@value7", rack.clientId);

                object result = await cmd.ExecuteScalarAsync();

                connection.Close();

                if (result != null)
                {
                    int clavePrimaria = Convert.ToInt32(result);                    
                    return clavePrimaria;
                }
                else
                {
                    return -1;
                }
                                                             
            }
            catch(Exception e) 
            {
                connection.Close();
                return -1;
            }
        }
        public async Task<bool> saveToWarehouseRacks(WarehouseRack rack, List<string> namesList, List<int> lenghList)
        {
            try
            {
                string query = "INSERT INTO dbo.warehouse_racks (idwarehouse, name, type, total_positions,levels) values (@value1, @value2, @value3, @value4, @value5)";

                connection.Open();

                for (int i = 0; i < namesList.Count; i++)
                {
                    rack.name = namesList[i];
                    rack.totalPositions = lenghList[i] * rack.levels;

                    SqlCommand cmd = new SqlCommand(query, connection);

                    cmd.Parameters.AddWithValue("@value1", rack.idWarehouse);
                    cmd.Parameters.AddWithValue("@value2", rack.name);
                    cmd.Parameters.AddWithValue("@value3", rack.type);
                    cmd.Parameters.AddWithValue("@value4", rack.totalPositions);
                    cmd.Parameters.AddWithValue("@value5", rack.levels);
                    await cmd.ExecuteNonQueryAsync();

                }
                connection.Close();
                return true;
            }
            catch
            {
                connection.Close();
                return false;
            }
        }

        public async Task<bool> saveToRackPositions(DataTable positions)
        {
            try
            {

                connection.Open();

                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
                {
                    bulkCopy.DestinationTableName = "dbo.warehouse_racks_positions";
                    try
                    {
                        // Write from the source to the destination.
                        await bulkCopy.WriteToServerAsync(positions);
                    }
                    catch (Exception ex)
                    {
                        connection.Close();
                        MessageBox.Show("Bulk err: " + ex.Message);
                        return false;
                    }
                }
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection err: " + ex.Message);
                connection.Close();
                return false;
            }
        }

        public bool insertSentency(string sentency)
        {
            bool enter = false;
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(sentency, connection);
                cmd.ExecuteNonQuery();
                enter = true;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Error :" + ex.Message);
                message = "Error :" + ex.Message;
                connection.Close();
            }

            connection.Close();
            return enter;
        }

        public bool saveToDestinary(Destinations destinations)
        {
            try
            {
                connection.Open();
                string query = "INSERT INTO [dbo].[CLIENTS_DESTINATIONS] (IDCLIENTE, NAME, DESCRIPTION, COUNTRY, STATE, CITY, DISTRICT, STREET, ZIPCODE, IMMEX, RFC, VALID) VALUES(@value1, @value2, @value3, @value4, @value5, @value6, @value7, @value8, @value9, @value10, @value11, @value12)";
                SqlCommand cmd = new SqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@value1", destinations.IDCLIENTE);
                cmd.Parameters.AddWithValue("@value2", destinations.NAME);
                cmd.Parameters.AddWithValue("@value3", destinations.DESCRIPTION);
                cmd.Parameters.AddWithValue("@value4", destinations.COUNTRY);
                cmd.Parameters.AddWithValue("@value5", destinations.STATE);
                cmd.Parameters.AddWithValue("@value6", destinations.CITY);
                cmd.Parameters.AddWithValue("@value7", destinations.DISTRICT);
                cmd.Parameters.AddWithValue("@value8", destinations.STREET);
                cmd.Parameters.AddWithValue("@value9", destinations.ZIPCODE);
                cmd.Parameters.AddWithValue("@value10", destinations.IMMEX);
                cmd.Parameters.AddWithValue("@value11", destinations.RFC);
                cmd.Parameters.AddWithValue("@value12", destinations.VALID);

                int rowsAffected = cmd.ExecuteNonQuery();
                connection.Close();
                if (rowsAffected > 0)
                {
                    Console.WriteLine("Actualización exitosa.");
                    return true;
                }
                else
                {
                    Console.WriteLine("No se realizaron cambios.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Error :" + ex.Message);
                message = "Error :" + ex.Message;
                connection.Close();
                return false;
            }
        }

        public bool saveToPermisions(Permisions permision)
        {
            try
            {
                connection.Open();
                string query = "INSERT INTO PERMISSIONS (NAME, DESCRIPTION, USERS_ACCESS, USERS_CONSULT, USERS_CREATE, USERS_EDIT, USERS_DELETE, CLIENTS_ACCESS, CLIENTS_CONSULT, CLIENTS_CREATE, CLIENTS_EDIT, CLIENTS_DELETE, PRODUCTS_ACCESS, PRODUCTS_CONSULT, PRODUCTS_CREATE, PRODUCTS_EDIT, PRODUCTS_DELETE, INVOICES_ACCESS, INVOICES_CONSULT, INVOICES_CREATE, INVOICES_EDIT, INVOICES_DELETE, REMISSIONS_ACCESS, REMISSIONS_CONSULT, REMISSIONS_CREATE, REMISSIONS_EDIT, REMISSIONS_DELETE, TRANSFERS_ACCESS, TRANSFERS_CONSULT, TRANSFERS_CREATE, TRANSFERS_EDIT, TRANSFERS_DELETE, INVENTORY_ACCESS, LOG_ACCESS, LOG_CONSULT, LOG_CREATE, LOG_EDIT, LOG_DELETE, CAN_AUTORISE) " +
                    "VALUES (@Name, @Description, @UsersAccess, @UsersConsult, @UsersCreate, @UsersEdit, @UsersDelete, @ClientsAccess, @ClientsConsult, @ClientsCreate, @ClientsEdit, @ClientsDelete, @ProductsAccess, @ProductsConsult, @ProductsCreate, @ProductsEdit, @ProductsDelete, @InvoicesAccess, @InvoicesConsult, @InvoicesCreate, @InvoicesEdit, @InvoicesDelete, @RemissionsAccess, @RemissionsConsult, @RemissionsCreate, @RemissionsEdit, @RemissionsDelete, @TransfersAccess, @TransfersConsult, @TransfersCreate, @TransfersEdit, @TransfersDelete, @InventoryAccess, @LogAccess, @LogConsult, @LogCreate, @LogEdit, @LogDelete, @CanAutorise)";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Name", permision.NAME);
                cmd.Parameters.AddWithValue("@Description", permision.DESCRIPTION);
                cmd.Parameters.AddWithValue("@UsersAccess", permision.USERS_ACCESS);
                cmd.Parameters.AddWithValue("@UsersConsult", permision.USERS_CONSULT);
                cmd.Parameters.AddWithValue("@UsersCreate", permision.USERS_CREATE);
                cmd.Parameters.AddWithValue("@UsersEdit", permision.USERS_EDIT);
                cmd.Parameters.AddWithValue("@UsersDelete", permision.USERS_DELETE);
                cmd.Parameters.AddWithValue("@ClientsAccess", permision.CLIENTS_ACCESS);
                cmd.Parameters.AddWithValue("@ClientsConsult", permision.CLIENTS_CONSULT);
                cmd.Parameters.AddWithValue("@ClientsCreate", permision.CLIENTS_CREATE);
                cmd.Parameters.AddWithValue("@ClientsEdit", permision.CLIENTS_EDIT);
                cmd.Parameters.AddWithValue("@ClientsDelete", permision.CLIENTS_DELETE);
                cmd.Parameters.AddWithValue("@ProductsAccess", permision.PRODUCTS_ACCESS);
                cmd.Parameters.AddWithValue("@ProductsConsult", permision.PRODUCTS_CONSULT);
                cmd.Parameters.AddWithValue("@ProductsCreate", permision.PRODUCTS_CREATE);
                cmd.Parameters.AddWithValue("@ProductsEdit", permision.PRODUCTS_EDIT);
                cmd.Parameters.AddWithValue("@ProductsDelete", permision.PRODUCTS_DELETE);
                cmd.Parameters.AddWithValue("@InvoicesAccess", permision.INVOICES_ACCESS);
                cmd.Parameters.AddWithValue("@InvoicesConsult", permision.INVOICES_CONSULT);
                cmd.Parameters.AddWithValue("@InvoicesCreate", permision.INVOICES_CREATE);
                cmd.Parameters.AddWithValue("@InvoicesEdit", permision.INVOICES_EDIT);
                cmd.Parameters.AddWithValue("@InvoicesDelete", permision.INVOICES_DELETE);
                cmd.Parameters.AddWithValue("@RemissionsAccess", permision.REMISSIONS_ACCESS);
                cmd.Parameters.AddWithValue("@RemissionsConsult", permision.REMISSIONS_CONSULT);
                cmd.Parameters.AddWithValue("@RemissionsCreate", permision.REMISSIONS_CREATE);
                cmd.Parameters.AddWithValue("@RemissionsEdit", permision.REMISSIONS_EDIT);
                cmd.Parameters.AddWithValue("@RemissionsDelete", permision.REMISSIONS_DELETE);
                cmd.Parameters.AddWithValue("@TransfersAccess", permision.TRANSFERS_ACCESS);
                cmd.Parameters.AddWithValue("@TransfersConsult", permision.TRANSFERS_CONSULT);
                cmd.Parameters.AddWithValue("@TransfersCreate", permision.TRANSFERS_CREATE);
                cmd.Parameters.AddWithValue("@TransfersEdit", permision.TRANSFERS_EDIT);
                cmd.Parameters.AddWithValue("@TransfersDelete", permision.TRANSFERS_DELETE);
                cmd.Parameters.AddWithValue("@InventoryAccess", permision.INVENTORY_ACCESS);
                cmd.Parameters.AddWithValue("@LogAccess", permision.LOG_ACCESS);
                cmd.Parameters.AddWithValue("@LogConsult", permision.LOG_CONSULT);
                cmd.Parameters.AddWithValue("@LogCreate", permision.LOG_CREATE);
                cmd.Parameters.AddWithValue("@LogEdit", permision.LOG_EDIT);
                cmd.Parameters.AddWithValue("@LogDelete", permision.LOG_DELETE);
                cmd.Parameters.AddWithValue("@CanAutorise", permision.CAN_AUTORISE);

                int rowsAffected = cmd.ExecuteNonQuery();
                connection.Close();
                if (rowsAffected > 0)
                {
                    Console.WriteLine("Actualización exitosa.");
                    return true;
                }
                else
                {
                    Console.WriteLine("No se realizaron cambios.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Error :" + ex.Message);
                message = "Error :" + ex.Message;
                connection.Close();
                return false;
            }
        }

        public bool saveToUser(Users user)
        {
            try
            {
                connection.Open();
                string query = "INSERT INTO USERS (USERNAME, NAME, LASTNAME, PASSWORD, PERMISSIONS, EMAIL, CREATE_AT, UPDATED_AT, VALID) " +
                             "VALUES (@Username, @Name, @Lastname, @Password, @Permissions, @Email, @CreateAt, @UpdatedAt, @Valid)";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Username", user.USERNAME);
                cmd.Parameters.AddWithValue("@Name", user.NAME);
                cmd.Parameters.AddWithValue("@Lastname", user.LASTNAME);
                cmd.Parameters.AddWithValue("@Password", user.PASSWORD);
                cmd.Parameters.AddWithValue("@Permissions", user.PERMISSIONS);
                cmd.Parameters.AddWithValue("@Email", user.EMAIL);
                cmd.Parameters.AddWithValue("@CreateAt", DateTime.Now.ToString("yyyyMMdd"));
                cmd.Parameters.AddWithValue("@UpdatedAt", DateTime.Now.ToString("yyyyMMdd"));
                cmd.Parameters.AddWithValue("@Valid", user.VALID);

                int rowsAffected = cmd.ExecuteNonQuery();
                connection.Close();
                if (rowsAffected > 0)
                {
                    Console.WriteLine("Actualización exitosa.");
                    return true;
                }
                else
                {
                    Console.WriteLine("No se realizaron cambios.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Error :" + ex.Message);
                message = "Error :" + ex.Message;
                connection.Close();
                return false;
            }
        }


        public bool saveToProducts(Prod prod)
        {
            try
            {
                connection.Open();
                string query = "INSERT INTO [dbo].[PRODUCTS] ([IDCLIENTE], [PART_NUMBER_PROVIDER], [PART_NUMBER_CLIENT], [REFERENCE], [DESCRIPTION], [MEASSURMENT_UNIT], [WEIGHT],[UNIT_VALUE], [CURRENCY], [TARIFF_FRACTION], [ORIGIN_COUNTRY], [ITEMS_PER_BOX], [STANDARD_PACK_PALLET], [CREATE_AT], [UPDATED_AT], [VALID]) " +
                    "VALUES(@value1, @value2, @value3, @value4,@value5, @value6, @value7, @value8,@value9, @value10, @value11, @value12, @value13, @value14, @value15, @value16)";
                SqlCommand cmd = new SqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@value1", prod.IDCLIENT);
                cmd.Parameters.AddWithValue("@value2", prod.PART_NUMBER_PROVIDER);
                cmd.Parameters.AddWithValue("@value3", prod.PART_NUMBER_CLIENT);
                cmd.Parameters.AddWithValue("@value4", prod.REFERENCE);
                cmd.Parameters.AddWithValue("@value5", prod.DESCRIPTION);
                cmd.Parameters.AddWithValue("@value6", prod.MEASSURMENT_UNIT);
                cmd.Parameters.AddWithValue("@value7", prod.WEIGHT);
                cmd.Parameters.AddWithValue("@value8", prod.UNIT_VALUE);
                cmd.Parameters.AddWithValue("@value9", prod.CURRENCY);
                cmd.Parameters.AddWithValue("@value10", prod.TARIFF_FRACTION);
                cmd.Parameters.AddWithValue("@value11", prod.ORIGIN_COUNTRY);
                cmd.Parameters.AddWithValue("@value12", prod.ITEMS_PER_BOX);
                cmd.Parameters.AddWithValue("@value13", prod.STANDARD_PACK_PALLET);
                cmd.Parameters.AddWithValue("@value14", DateTime.Now.ToString("yyyyMMdd"));
                cmd.Parameters.AddWithValue("@value15", DateTime.Now.ToString("yyyyMMdd"));
                cmd.Parameters.AddWithValue("@value16", prod.VALID);

                int rowsAffected = cmd.ExecuteNonQuery();
                connection.Close();
                if (rowsAffected > 0)
                {
                    Console.WriteLine("Actualización exitosa.");
                    return true;
                }
                else
                {
                    Console.WriteLine("No se realizaron cambios.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Error :" + ex.Message);
                message = "Error :" + ex.Message;
                connection.Close();
                return false;
            }

        }

        public bool saveToProvider(Provider prov)
        {
            try
            {
                connection.Open();
                string query = "INSERT INTO CLIENTS_PROVIDERS (IDCLIENTE, NAME, DESCRIPTION, VALID) " +
                             "VALUES (@IDCLIENTE, @NAME, @DESCRIPTION, @Valid)";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@IDCLIENTE", prov.IDCLIENTE);
                cmd.Parameters.AddWithValue("@NAME", prov.NAME);
                cmd.Parameters.AddWithValue("@DESCRIPTION", prov.DESCRIPTION);
                cmd.Parameters.AddWithValue("@Valid", prov.VALID);

                int rowsAffected = cmd.ExecuteNonQuery();
                connection.Close();
                if (rowsAffected > 0)
                {
                    Console.WriteLine("Actualización exitosa.");
                    return true;
                }
                else
                {
                    Console.WriteLine("No se realizaron cambios.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Error :" + ex.Message);
                message = "Error :" + ex.Message;
                connection.Close();
                return false;
            }
        }


        public bool saveToConfigurations(Configurations conf)
        {
            try
            {
                connection.Open();
                string query = "INSERT INTO CONFIGURATIONS (IDCLIENT, INPUT, ORDEROUTPUT, REMISSIONOUTPUT, PROFORMAOUTPUT) " +
                             "VALUES (@IDCLIENT, @INPUT, @ORDEROUTPUT, @REMISSIONOUTPUT, @PROFORMAOUTPUT)";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@IDCLIENT", conf.IDCLIENT);
                cmd.Parameters.AddWithValue("@INPUT", conf.INPUT);
                cmd.Parameters.AddWithValue("@ORDEROUTPUT", conf.ORDEROUTPUT);
                cmd.Parameters.AddWithValue("@REMISSIONOUTPUT", conf.REMISSIONOUTPUT);
                cmd.Parameters.AddWithValue("@PROFORMAOUTPUT", conf.PROFORMAOUTPUT);

                int rowsAffected = cmd.ExecuteNonQuery();
                connection.Close();
                if (rowsAffected > 0)
                {
                    Console.WriteLine("Actualización exitosa.");
                    return true;
                }
                else
                {
                    Console.WriteLine("No se realizaron cambios.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Error :" + ex.Message);
                message = "Error :" + ex.Message;
                connection.Close();
                return false;
            }
        }
        public bool saveToClients(Clients dateClient)
        {
            try
            {
                connection.Open();
                string query = "INSERT INTO CLIENTS ( NAME, SHORT_NAME, DOCUMNET_NAME, PREFIX, TYPE, COUNTRY, STATE, CITY, DISTRICT, STREET, ZIPCODE, IMMEX, RFC, CONTACT_EMAIL, CONTACT_NUMBER, AUTOMATIC_EMAIL_INVOICE, AUTOMATIC_EMAIL_REMISSION, AUTOMATIC_EMAIL_INVENTARY, CREATE_AT, UPDATED_AT, VALID) VALUES ( @value2, @value3, @value4, @value5, @value6, @value7, @value8, @value9, @value10, @value11, @value12, @value13, @value14, @value15, @value16, @value17, @value18, @value19, @value21, @value22, @value24); ";
                SqlCommand cmd = new SqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@value2", dateClient.NAME);
                cmd.Parameters.AddWithValue("@value3", dateClient.SHORT_NAME);
                cmd.Parameters.AddWithValue("@value4", dateClient.DOCUMNET_NAME);
                cmd.Parameters.AddWithValue("@value5", dateClient.PREFIX);
                cmd.Parameters.AddWithValue("@value6", dateClient.TYPE);
                cmd.Parameters.AddWithValue("@value7", dateClient.COUNTRY);
                cmd.Parameters.AddWithValue("@value8", dateClient.STATE);
                cmd.Parameters.AddWithValue("@value9", dateClient.CITY);
                cmd.Parameters.AddWithValue("@value10", dateClient.DISTRICT);
                cmd.Parameters.AddWithValue("@value11", dateClient.STREET);
                cmd.Parameters.AddWithValue("@value12", dateClient.ZIPCODE);
                cmd.Parameters.AddWithValue("@value13", dateClient.IMMEX);
                cmd.Parameters.AddWithValue("@value14", dateClient.RFC);
                cmd.Parameters.AddWithValue("@value15", dateClient.CONTACT_EMAIL);
                cmd.Parameters.AddWithValue("@value16", dateClient.CONTACT_NUMBER);
                cmd.Parameters.AddWithValue("@value17", dateClient.AUTOMATIC_EMAIL_INVOICE);
                cmd.Parameters.AddWithValue("@value18", dateClient.AUTOMATIC_EMAIL_REMISSION);
                cmd.Parameters.AddWithValue("@value19", dateClient.AUTOMATIC_EMAIL_INVENTARY);
                cmd.Parameters.AddWithValue("@value21", DateTime.Now.ToString("yyyyMMdd"));
                cmd.Parameters.AddWithValue("@value22", DateTime.Now.ToString("yyyyMMdd"));
                //cmd.Parameters.AddWithValue("@value23", 0);
                cmd.Parameters.AddWithValue("@value24", dateClient.VALID);

                int rowsAffected = cmd.ExecuteNonQuery();
                connection.Close();
                if (rowsAffected > 0)
                {
                    Console.WriteLine("Actualización exitosa.");
                    return true;
                }
                else
                {
                    Console.WriteLine("No se realizaron cambios.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Error :" + ex.Message);
                message = "Error :" + ex.Message;
                connection.Close();
                return false;
            }

        }
        //Ejecuta el procedimiento almacenado en la BD
        public bool saveToOrder(WorkOrderHeader workOrderheader, RemissionHeader remissionHeader, DataTable table, DataTable RemisionItemsTableType, int folio)
        {
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("InsertOutpot", connection);

                command.CommandType = CommandType.StoredProcedure;

                // Parámetros de Header
                command.Parameters.AddWithValue("@WORK_ORDER_ID", workOrderheader.ID_WORKORDER_HEADER);
                command.Parameters.AddWithValue("@CLIENT_ID", workOrderheader.CLIENT_ID);
                command.Parameters.AddWithValue("@TYPE", workOrderheader.TYPE);
                command.Parameters.AddWithValue("@PURCHASE_ORDER_CLIENT", workOrderheader.PURCHASE_ORDER_CLIENT);
                command.Parameters.AddWithValue("@CLIENT_DESTINATION", workOrderheader.CLIENT_DESTINATION);
                command.Parameters.AddWithValue("@STATUS", workOrderheader.STATUS);
                command.Parameters.AddWithValue("@CREATE_AT", DateTime.Now.ToString("yyyyMMdd"));
                command.Parameters.AddWithValue("@UPDATED_AT", workOrderheader.UPDATED_AT.ToString("yyyyMMdd"));
                command.Parameters.AddWithValue("@WORKORDER_AT", workOrderheader.WORKORDER_AT.ToString("yyyyMMdd"));
                command.Parameters.AddWithValue("@SESSION_ID", workOrderheader.SESSION_ID);
                command.Parameters.AddWithValue("@VALID", workOrderheader.VALID);

                //
                command.Parameters.AddWithValue("@TOTAL_PALLETS", remissionHeader.TOTAL_PALLETS);
                command.Parameters.AddWithValue("@TRANSPORT_INFO_ID ", remissionHeader.TRANSPORT_INFO_ID);


                command.Parameters.AddWithValue("@FOLIO",folio);
                // Ingresar toda la tabla 
                SqlParameter tablaBParam = command.Parameters.AddWithValue("@TablaB", table);
                tablaBParam.SqlDbType = SqlDbType.Structured;
                tablaBParam.TypeName = "dbo.WorkOrderInventoryItemTableType";

                SqlParameter remisionItemsParam = command.Parameters.AddWithValue("@RemisionItemsTableType", RemisionItemsTableType);
                remisionItemsParam.SqlDbType = SqlDbType.Structured;
                remisionItemsParam.TypeName = "dbo.RemisionItemsTableType";

                SqlParameter outputParameter = new SqlParameter();
                outputParameter.ParameterName = "@PrintMessage";
                outputParameter.SqlDbType = SqlDbType.NVarChar; // Ajusta el tipo de datos según sea necesario
                outputParameter.Direction = ParameterDirection.Output;
                outputParameter.Size = 255; // Ajusta el tamaño según sea necesario
                command.Parameters.Add(outputParameter);

                int rowsAffected = command.ExecuteNonQuery();
                
                message = outputParameter.Value.ToString();
                
                connection.Close();
                if (rowsAffected > 0)
                {
                    //MessageBox.Show("Actualización exitosa.");
                    return true;
                }
                else
                {
                    Console.WriteLine("No se realizaron cambios." + outputParameter.Value.ToString());
                    return false;
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Error :" + ex.Message);
                message = "Error :" + ex.Message;
                connection.Close();
                return false;
            }
        }

        public bool saveToRemmsion( string IDINVOICE_ITEMS, float? nuevaQuantity)
        {
            try
            {
                connection.InfoMessage += Connection_InfoMessage;
                connection.Open();
                SqlCommand command = new SqlCommand("DupRegistro", connection);

                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IDINVOICE_ITEMS", IDINVOICE_ITEMS);

                // Manejar el valor nullable para nuevaQuantity
                SqlParameter nuevaQuantityParam = new SqlParameter("@NUEVA_QUANTITY", SqlDbType.Float);
                nuevaQuantityParam.Value = (object)nuevaQuantity ?? DBNull.Value;
                command.Parameters.Add(nuevaQuantityParam);

                command.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Error :" + ex.Message);
                message = "Error :" + ex.Message;
                connection.Close();
                return false;
            }
        }

        public bool saveToRemmsionItems(string remissionId, int inventoryItemId, float quantity, float picking,
        float remainingQuantity, string location, int status, DateTime createAt,
        int sessionId, bool valid)
        {
            try
            {
                connection.InfoMessage += Connection_InfoMessage;
                connection.Open();
                SqlCommand command = new SqlCommand(
                "INSERT INTO [dbo].[REMISSION_ITEMS] " +
                "( [REMISSION_ID], [INVENTORY_ITEM_ID], [QUANTITY], [PICKING], [REMAINING_QUANTITY], " +
                "[LOCATION], [STATUS], [CREATE_AT], [SESSION_ID], [VALID]) " +
                "VALUES " +
                "(@RemissionId, @InventoryItemId, @Quantity, @Picking, @RemainingQuantity, " +
                "@Location, @Status, @CreateAt, @SessionId, @Valid)", connection);
                command.Parameters.AddWithValue("@RemissionId", remissionId);
                command.Parameters.AddWithValue("@InventoryItemId", inventoryItemId);
                command.Parameters.AddWithValue("@Quantity", quantity);
                command.Parameters.AddWithValue("@Picking", picking);
                command.Parameters.AddWithValue("@RemainingQuantity", remainingQuantity);
                command.Parameters.AddWithValue("@Location", location);
                command.Parameters.AddWithValue("@Status", status);
                command.Parameters.AddWithValue("@CreateAt", createAt);
                command.Parameters.AddWithValue("@SessionId", sessionId);
                command.Parameters.AddWithValue("@Valid", valid);

                // Ejecutar la consulta
                int affectedRows = command.ExecuteNonQuery();
                //MessageBox.Show(affectedRows.ToString());
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error :" + ex.Message);
                message = "Error :" + ex.Message;
                connection.Close();
                return false;
            }
        }

        public bool InsertarWorkOrderInventoryItem(WorkOrderInventoryItem workOrderInventoryItem)
        {
            
            try
            {
                connection.InfoMessage += Connection_InfoMessage;
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO [dbo].[WORK_ORDER_INVENTORY_ITEM] " +
                "( [WORK_ORDER_ID], [INVENTORY_ID], [QUANTITY_REQUESTED], [STATUS], [CREATE_AT], " +
                "[SESSION_ID], [VALID]) " +
                "VALUES " +
                "(@WorkOrderId, @InventoryId, @QuantityRequested, @Status, @CreateAt, " +
                "@SessionId, @Valid)", connection);
                    command.Parameters.AddWithValue("@WorkOrderId", workOrderInventoryItem.WORK_ORDER_ID);
                    command.Parameters.AddWithValue("@InventoryId", workOrderInventoryItem.INVENTORY_ID);
                    command.Parameters.AddWithValue("@QuantityRequested", workOrderInventoryItem.QUANTITY_REQUESTED);
                    command.Parameters.AddWithValue("@Status", workOrderInventoryItem.STATUS);
                    command.Parameters.AddWithValue("@CreateAt", workOrderInventoryItem.CREATE_AT);
                    command.Parameters.AddWithValue("@SessionId", workOrderInventoryItem.SESSION_ID);
                    command.Parameters.AddWithValue("@Valid", workOrderInventoryItem.VALID);

                    // Ejecutar la consulta
                    command.ExecuteNonQuery();

                    connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Error :" + ex.Message);
                message = "Error :" + ex.Message;
                connection.Close();
                return false;
            }
        }
        private static void Connection_InfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            // Manejar los mensajes INFO (PRINT) aquí
            foreach (SqlError error in e.Errors)
            {
                MessageBox.Show($"Mensaje de la base de datos: {error.Message}");
                //message = error.Message;
            }
        }

        public bool saveToClientWarehouse(int IDCLIENT, int IDWAREHOUSES)
        {
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO dbo.CLIENTS_WAREHOUSE (IDCLIENT, IDWAREHOUSES) VALUES(@IDCLIENT, @IDWAREHOUSES);", connection);
                command.Parameters.AddWithValue("@IDCLIENT", IDCLIENT);
                command.Parameters.AddWithValue("@IDWAREHOUSES", IDWAREHOUSES);

                command.ExecuteReaderAsync();

                connection.Close();
                
                return true;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Error :" + ex.Message);
                message = "Error :" + ex.Message;
                connection.Close();
                return false;
            }
        }
        public int InsertInvoiceHeader(SqlTransaction transaction, params object[] parameters)
        {
            string comando = @"
            INSERT INTO [dbo].[INVOICE_HEADERS] 
            ([IDCLIENTE], [INVOICE_INDEX], [CREATE_AT], [INVOICE], [CUSTOMS_DOCUMENTS], 
            [PROFORMA], [CLIENT_REFERENCE], [IDWAREHOUSES], [STATUS], [COMMENTS], 
            [SESSION_IDSESSION], [VALID], [SUBTOTAL], [DISCOUNT], [TAX], [TOTAL], [RECEIVES]) 
            OUTPUT INSERTED.IDINVOICE_HEADERS
            VALUES (@IdCliente, @InvoiceIndex, @CreateAt, @Invoice, @CustomsDocuments, 
            @Proforma, @ClientReference, @IdWarehouses, @Status, @Comments, 
            @SessionIdSession, @Valid, @Subtotal, @Discount, @Tax, @Total, @Receives)";

            using (SqlCommand command = new SqlCommand(comando, transaction.Connection, transaction))
            {
                // Asignar parámetros al comando SQL
                command.Parameters.AddWithValue("@IdCliente", parameters[0]);
                command.Parameters.AddWithValue("@InvoiceIndex", parameters[1]);
                command.Parameters.AddWithValue("@CreateAt", parameters[2]);
                command.Parameters.AddWithValue("@Invoice", parameters[3]);
                command.Parameters.AddWithValue("@CustomsDocuments", parameters[4]);
                command.Parameters.AddWithValue("@Proforma", parameters[5]);
                command.Parameters.AddWithValue("@ClientReference", parameters[6]);
                command.Parameters.AddWithValue("@IdWarehouses", parameters[7]);
                command.Parameters.AddWithValue("@Status", parameters[8]);
                command.Parameters.AddWithValue("@Comments", parameters[9]);
                command.Parameters.AddWithValue("@SessionIdSession", parameters[10]);
                command.Parameters.AddWithValue("@Valid", parameters[11]);
                command.Parameters.AddWithValue("@Subtotal", parameters[12]);
                command.Parameters.AddWithValue("@Discount", parameters[13]);
                command.Parameters.AddWithValue("@Tax", parameters[14]);
                command.Parameters.AddWithValue("@Total", parameters[15]);
                command.Parameters.AddWithValue("@Receives", parameters[16]);

                // Ejecutar la consulta y devolver el ID insertado
                var result = command.ExecuteScalar();
                return Convert.ToInt32(result);
            }
        }

        // Método para insertar un ítem de factura
        public int InsertInvoiceItem(SqlTransaction transaction, int invoiceHeaderId, int invoicePalletId, InvoiceItemData itemData, int IdSession)
        {
            string comando = @"
            INSERT INTO [dbo].[INVOICE_ITEMS] 
            ([IDINVOICE_HEADERS], [IDINVOICE_PALLETS], [IDPRODUCTS], [QUANTITY], [INVOICE], [BATCH], 
            [EXTERNAL_SERIAL], [EXPIRATION_DATE], [REVISION], [CUSTOMS_DOCUMENT], [PROFORMA], 
            [SERIAL], [PACKING_LIST], [BOXES], [IDCLIENT_PROVIDERS], [DESCRIPTION], [IDMEASURING_UNIT], 
            [WEIGHT], [UNIT_VALUE], [IDCURRENCY], [TARIFF_FRACTION], [IDCOUNTRIES], [STATUS], 
            [CREATE_AT], [SESSION_IDSESSION], [VALID], [PEDIMENTOADUANAL], [ID_INTERNAL_WAREHOUSE], 
            [REGIMEN], [REMISION], [PEDIMENTO_DATE], [PAY_DATE], [CONTAINER], [COST], [PRICE], [TRANSPORT]) 
            OUTPUT INSERTED.IDINVOICE_ITEMS
            VALUES (@IdInvoiceHeaders, @IdInvoicePallets, @IdProducts, @Quantity, @Invoice, @Batch, 
            @ExternalSerial, @ExpirationDate, @Revision, @CustomsDocument, @Proforma, 
            @Serial, @PackingList, @Boxes, @IdClientProviders, @Description, @IdMeasuringUnit, 
            @Weight, @UnitValue, @IdCurrency, @TariffFraction, @IdCountries, @Status, 
            @CreateAt, @SessionIdSession, @Valid, @PedimentoAduanal, @IdInternalWarehouse, 
            @Regimen, @Remision, @PedimentoDate, @PayDate, @Container, @Cost, @Price, @Transport)";

            using (SqlCommand command = new SqlCommand(comando, transaction.Connection, transaction))
            {
                // Mapear las propiedades del objeto `itemData` a los parámetros SQL
                command.Parameters.AddWithValue("@IdInvoiceHeaders", invoiceHeaderId);
                command.Parameters.AddWithValue("@IdInvoicePallets", invoicePalletId);
                command.Parameters.AddWithValue("@IdProducts", itemData.ProductId);
                command.Parameters.AddWithValue("@Quantity", itemData.Pieces);
                command.Parameters.AddWithValue("@Invoice", itemData.Invoice);
                command.Parameters.AddWithValue("@Batch", itemData.Batch);
                command.Parameters.AddWithValue("@ExternalSerial", itemData.ExternalSerial);
                command.Parameters.AddWithValue("@ExpirationDate", itemData.ExpirationDate);
                command.Parameters.AddWithValue("@Revision", "Revision");
                command.Parameters.AddWithValue("@CustomsDocument", itemData.CustomsDocument);
                command.Parameters.AddWithValue("@Proforma", "Proforma");
                command.Parameters.AddWithValue("@Serial", itemData.Serial);
                command.Parameters.AddWithValue("@PackingList", "Lista de embalaje");
                command.Parameters.AddWithValue("@Boxes", 1);
                command.Parameters.AddWithValue("@IdClientProviders", itemData.ClientProviderId);
                command.Parameters.AddWithValue("@Description", " ");
                command.Parameters.AddWithValue("@IdMeasuringUnit", itemData.ProductValues[0]);
                command.Parameters.AddWithValue("@Weight", itemData.ProductValues[1]);
                command.Parameters.AddWithValue("@UnitValue", itemData.ProductValues[2]);
                command.Parameters.AddWithValue("@IdCurrency", itemData.ProductValues[3]);
                command.Parameters.AddWithValue("@TariffFraction", itemData.ProductValues[4]);
                command.Parameters.AddWithValue("@IdCountries", itemData.ProductValues[5]);
                command.Parameters.AddWithValue("@Status", 1);
                command.Parameters.AddWithValue("@CreateAt", DateTime.Now.ToString("yyyyMMdd HH:mm:ss"));
                command.Parameters.AddWithValue("@SessionIdSession", IdSession);
                command.Parameters.AddWithValue("@Valid", 1);
                command.Parameters.AddWithValue("@PedimentoAduanal", itemData.CustomsDocument);
                command.Parameters.AddWithValue("@IdInternalWarehouse", itemData.InternalWarehouseId);
                command.Parameters.AddWithValue("@Regimen", itemData.Regime);
                command.Parameters.AddWithValue("@Remision", itemData.Remission);
                command.Parameters.AddWithValue("@PedimentoDate", itemData.CustomsDate);
                command.Parameters.AddWithValue("@PayDate", itemData.PayDate);
                command.Parameters.AddWithValue("@Container", itemData.Container);
                command.Parameters.AddWithValue("@Cost", itemData.Cost);
                command.Parameters.AddWithValue("@Price", itemData.Price);
                command.Parameters.AddWithValue("@Transport", itemData.Transport);

                // Ejecutar la consulta y devolver el ID insertado
                object result = command.ExecuteScalar();
                return Convert.ToInt32(result);
            }
        }

        // Método para insertar un pallet de factura
        public int InsertInvoicePallet(SqlTransaction transaction, int invoiceHeaderId, string serial)
        {
            string comando = @"
            INSERT INTO [dbo].[INVOICE_PALLETS] 
            ([IDINVOICE_HEADERS], [SERIAL], [VALID]) 
            OUTPUT INSERTED.IDINVOICE_PALLETS
            VALUES (@IdInvoiceHeaders, @Serial, @Valid)";

            using (SqlCommand command = new SqlCommand(comando, transaction.Connection, transaction))
            {
                // Asignar parámetros
                command.Parameters.AddWithValue("@IdInvoiceHeaders", invoiceHeaderId);
                command.Parameters.AddWithValue("@Serial", serial);
                command.Parameters.AddWithValue("@Valid", 1);

                // Ejecutar la consulta y devolver el ID
                object result = command.ExecuteScalar();
                return Convert.ToInt32(result);
            }
        }

        // Método para insertar un registro de inventario
        public void InsertInventory(SqlTransaction transaction, int invoiceItemId, string quantity)
        {
            string comando = @"
            INSERT INTO [dbo].[INVENTORY] 
            ([ID_INVOICE_ITEM], [QUANTITY], [STATUS], [VALID]) 
            VALUES (@IdInvoiceItem, @Quantity, @Status, @Valid)";

            using (SqlCommand command = new SqlCommand(comando, transaction.Connection, transaction))
            {
                // Asignar parámetros
                command.Parameters.AddWithValue("@IdInvoiceItem", invoiceItemId);
                command.Parameters.AddWithValue("@Quantity", quantity);
                command.Parameters.AddWithValue("@Status", 1);
                command.Parameters.AddWithValue("@Valid", 1);

                // Ejecutar la consulta
                command.ExecuteNonQuery();
            }
        }
    }
}
