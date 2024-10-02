using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace InventaryWMS
{
    internal class UpdateSQL
    {
        private System.Data.SqlClient.SqlConnection _connection { get; set; }
        private SqlDataReader _dr { get; set; }
        public string message { get; set; }

        public UpdateSQL()
        {
            _connection = DBConections.GetConnection();
        }

        public SqlConnection getConnection()
        {
            return _connection;
        }

        public bool UpdateSentency(string sentency)
        {
            bool enter = false;
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand(sentency, _connection);
                cmd.ExecuteNonQuery();
                enter = true;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Error :" + ex.Message);
                message = "Error :" + ex.Message;
            }

            _connection.Close();
            return enter;
        }

        public bool UpdateWarehouseValidState(int idWarehouse, int valid)
        {
            try
            {
                string query = "UPDATE [dbo].[warehouses] set valid = @value1 where idwarehouses = @value2;";
                _connection.Open();
                SqlCommand cmd = new SqlCommand(query, _connection);
                cmd.Parameters.AddWithValue("@value1", valid);
                cmd.Parameters.AddWithValue("@value2", idWarehouse);
                int rowsAffected = cmd.ExecuteNonQuery();
                _connection.Close();
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
                MessageBox.Show("Ocurrió un error" + ex.Message);
                _connection.Close();
                message = "Error :" + ex.Message;
                return false;
            }
        }


        public bool updateInventory(int idInventory, int idPosition)
        {
            try
            {
                string query = "UPDATE [dbo].[inventory] set IDWAREHOUSE_RACK_POSITIONS = @value1 where IDINVENTORY  = @value2;";
                _connection.Open();
                SqlCommand cmd = new SqlCommand(query, _connection);
                cmd.Parameters.AddWithValue("@value1", idPosition);
                cmd.Parameters.AddWithValue("@value2", idInventory);
                cmd.ExecuteNonQuery();
                _connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error" + ex.Message);
                _connection.Close();
                message = "Error :" + ex.Message;
                _connection.Close();
                return false;
            }
        }

        public bool updateStoragePosition(List<int> idInvoceitemsList, List<int> idPositionsList)
        {
            try
            {
                DataTable table = new DataTable();
                table.Columns.Add("IDINVOICE_ITEMS", typeof(int));
                table.Columns.Add("IDWAREHOUSE_RACKS_POSITIONS", typeof(int));

                for (int i = 0; i < idInvoceitemsList.Count; i++)
                {
                    table.Rows.Add(idInvoceitemsList[i], idPositionsList[i]);
                }

                string query = @"
    DECLARE @tempTable AS dbo.InvoiceItemsPositions;
    INSERT INTO @tempTable SELECT * FROM @sourceTable;

    UPDATE [dbo].[invoice_items]
    SET IDWAREHOUSE_RACKS_POSITIONS = t.IDWAREHOUSE_RACKS_POSITIONS
    FROM [dbo].[invoice_items] i
    INNER JOIN @tempTable t ON i.IDINVOICE_ITEMS = t.IDINVOICE_ITEMS;

    UPDATE [dbo].[inventory]
    SET IDWAREHOUSE_RACK_POSITIONS = t.IDWAREHOUSE_RACKS_POSITIONS
    FROM [dbo].[inventory] inv
    INNER JOIN @tempTable t ON inv.ID_INVOICE_ITEM = t.IDINVOICE_ITEMS;
";

                _connection.Open();

                SqlCommand cmd = new SqlCommand(query, _connection);
                SqlParameter param = cmd.Parameters.AddWithValue("@sourceTable", table);
                param.SqlDbType = SqlDbType.Structured;
                param.TypeName = "dbo.InvoiceItemsPositions";

                cmd.ExecuteNonQuery();

                _connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error" + ex.Message);
                _connection.Close();
                message = "Error :" + ex.Message;
                _connection.Close();
                return false;
            }
        }


        public void UpdateStoragePositionState(List<WarehouseRack_Position> positions)
        {
            try
            {
                string query = "UPDATE [dbo].[warehouse_racks_positions] set valid = @value1 where idwarehouse_racks_positions = @value2;";
                _connection.Open();
                foreach (WarehouseRack_Position position in positions)
                {
                    SqlCommand cmd = new SqlCommand(query, _connection);
                    cmd.Parameters.AddWithValue("@value1", position.valid);
                    cmd.Parameters.AddWithValue("@value2", position.idPosition);
                    cmd.ExecuteNonQuery();
                }
                _connection.Close();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Error :" + ex.Message);
                message = "Error :" + ex.Message;
            }
        }

        public bool UpdateDestinations(Destinations Destination)
        {
            try
            {
                string query = "UPDATE [dbo].[CLIENTS_DESTINATIONS] SET IDCLIENTE = @value2,NAME = @value3, DESCRIPTION = @value4, COUNTRY = @value5, STATE = @value6, CITY = @value7, DISTRICT = @value8, STREET = @value9, ZIPCODE = @value10, IMMEX = @value11, RFC = @value12, VALID = @value13 WHERE IDCLIENTE_DESTINATIONS = @value1;";
                _connection.Open();
                SqlCommand cmd = new SqlCommand(query, _connection);
                cmd.Parameters.AddWithValue("@value1", Destination.IDCLIENTE_DESTINATIONS);
                cmd.Parameters.AddWithValue("@value2", Destination.IDCLIENTE);
                cmd.Parameters.AddWithValue("@value3", Destination.NAME);
                cmd.Parameters.AddWithValue("@value4", Destination.DESCRIPTION);
                cmd.Parameters.AddWithValue("@value5", Destination.COUNTRY);
                cmd.Parameters.AddWithValue("@value6", Destination.STATE);
                cmd.Parameters.AddWithValue("@value7", Destination.CITY);
                cmd.Parameters.AddWithValue("@value8", Destination.DISTRICT);
                cmd.Parameters.AddWithValue("@value9", Destination.STREET);
                cmd.Parameters.AddWithValue("@value10", Destination.ZIPCODE);
                cmd.Parameters.AddWithValue("@value11", Destination.IMMEX);
                cmd.Parameters.AddWithValue("@value12", Destination.RFC);
                cmd.Parameters.AddWithValue("@value13", Destination.VALID);
                int rowsAffected = cmd.ExecuteNonQuery();
                _connection.Close();
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
                _connection.Close();
                message = "Error :" + ex.Message;
            }
            return false;
        }

        public bool UpdateProvider(Provider Destination)
        {
            try
            {
                string query = "UPDATE [dbo].[CLIENTS_PROVIDERS] SET IDCLIENTE = @value1,NAME = @value2, DESCRIPTION = @value3, VALID = @value4 WHERE IDCLIENTE_PROVIDERS = @value5;";
                _connection.Open();
                SqlCommand cmd = new SqlCommand(query, _connection);
                cmd.Parameters.AddWithValue("@value1", Destination.IDCLIENTE);
                cmd.Parameters.AddWithValue("@value2", Destination.NAME);
                cmd.Parameters.AddWithValue("@value3", Destination.DESCRIPTION);
                cmd.Parameters.AddWithValue("@value4", Destination.VALID);
                cmd.Parameters.AddWithValue("@value5", Destination.IDCLIENTE_PROVIDERS);
                int rowsAffected = cmd.ExecuteNonQuery();
                _connection.Close();
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
                _connection.Close();
                message = "Error :" + ex.Message;
            }
            return false;
        }


        public bool UpdateProducts(Prod prod)
        {
            try
            {
                //string query = "UPDATE [dbo].[PRODUCTS] SET [IDCLIENTE] = @value1, [PART_NUMBER_PROVIDER] = @value2, [PART_NUMBER_CLIENT] = @value3, [REFERENCE] = @value4, [DESCRIPTION] = @value5, [MEASSURMENT_UNIT] = @value6, [WEIGHT] =  @value7, [UNIT_VALUE] =  @value8, [CURRENCY] = @value9, [TARIFF_FRACTION] = @value10, [ORIGIN_COUNTRY] = @value11, [ITEMS_PER_BOX] = @value12, [STANDARD_PACK_PALLET] = @value13, [UPDATED_AT] = @value14, [SESSION_IDSESSION] = @value15, [VALID] = @value16 WHERE [IDPRODUCTS] = @value17";

                string query = "UPDATE [dbo].[PRODUCTS] SET [IDCLIENTE] = @value1, [PART_NUMBER_PROVIDER] = @value2, [PART_NUMBER_CLIENT] = @value3, [REFERENCE] = @value4, [DESCRIPTION] = @value5, [MEASSURMENT_UNIT] = @value6, [WEIGHT] =  @value7, [UNIT_VALUE] =  @value8, [CURRENCY] = @value9, [TARIFF_FRACTION] = @value10, [ORIGIN_COUNTRY] = @value11, [ITEMS_PER_BOX] = @value12, [STANDARD_PACK_PALLET] = @value13, [UPDATED_AT] = @value14, [VALID] = @value16 WHERE [IDPRODUCTS] = @value17";
                _connection.Open();
                SqlCommand cmd = new SqlCommand(query, _connection);
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
                //cmd.Parameters.AddWithValue("@value15", prod.SESSION_IDSESSION);
                cmd.Parameters.AddWithValue("@value16", prod.VALID);
                cmd.Parameters.AddWithValue("@value17", prod.IDPRODUCTS);
                int rowsAffected = cmd.ExecuteNonQuery();
                _connection.Close();
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
                Console.WriteLine("No se realizaron cambios.");
                System.Console.WriteLine("Error :" + ex.Message);
                _connection.Close();
                message = "Error :" + ex.Message;
            }
            return false;
        }

        public bool UpdateProducts(Clients dateClient)
        {
            try
            {
                string query = "UPDATE CLIENTS SET NAME = @value2, SHORT_NAME = @value3, DOCUMNET_NAME = @value4, PREFIX = @value5, TYPE = @value6, COUNTRY = @value7, STATE = @value8, CITY = @value9, DISTRICT = @value10, STREET = @value11, ZIPCODE = @value12, IMMEX = @value13, RFC = @value14, CONTACT_EMAIL = @value15, CONTACT_NUMBER = @value16, AUTOMATIC_EMAIL_INVOICE = @value17, AUTOMATIC_EMAIL_REMISSION = @value18, AUTOMATIC_EMAIL_INVENTARY = @value19, UPDATED_AT = @value21, SESSION_IDSESSION = @value22, VALID = @value23 WHERE IDCLIENTS = @value1";
                _connection.Open();
                SqlCommand cmd = new SqlCommand(query, _connection);

                cmd.Parameters.AddWithValue("@value1", dateClient.IDCLIENTS);
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
                cmd.Parameters.AddWithValue("@value22", 2);
                cmd.Parameters.AddWithValue("@value23", dateClient.VALID);
                int rowsAffected = cmd.ExecuteNonQuery();
                _connection.Close();
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
                _connection.Close();
                message = "Error :" + ex.Message;
            }
            return false;
        }

        public bool UpdatePermisions(Permisions role)
        {
            try
            {
                string query = "UPDATE PERMISSIONS SET NAME = @Name, DESCRIPTION = @Description, USERS_ACCESS = @UsersAccess, USERS_CONSULT = @UsersConsult, USERS_CREATE = @UsersCreate, USERS_EDIT = @UsersEdit, USERS_DELETE = @UsersDelete, CLIENTS_ACCESS = @ClientsAccess, CLIENTS_CONSULT = @ClientsConsult, CLIENTS_CREATE = @ClientsCreate, CLIENTS_EDIT = @ClientsEdit, CLIENTS_DELETE = @ClientsDelete, PRODUCTS_ACCESS = @ProductsAccess, PRODUCTS_CONSULT = @ProductsConsult, PRODUCTS_CREATE = @ProductsCreate, PRODUCTS_EDIT = @ProductsEdit, PRODUCTS_DELETE = @ProductsDelete, INVOICES_ACCESS = @InvoicesAccess, INVOICES_CONSULT = @InvoicesConsult, INVOICES_CREATE = @InvoicesCreate, INVOICES_EDIT = @InvoicesEdit, INVOICES_DELETE = @InvoicesDelete, REMISSIONS_ACCESS = @RemissionsAccess, REMISSIONS_CONSULT = @RemissionsConsult, REMISSIONS_CREATE = @RemissionsCreate, REMISSIONS_EDIT = @RemissionsEdit, REMISSIONS_DELETE = @RemissionsDelete, TRANSFERS_ACCESS = @TransfersAccess, TRANSFERS_CONSULT = @TransfersConsult, TRANSFERS_CREATE = @TransfersCreate, TRANSFERS_EDIT = @TransfersEdit, TRANSFERS_DELETE = @TransfersDelete, INVENTORY_ACCESS = @InventoryAccess, LOG_ACCESS = @LogAccess, LOG_CONSULT = @LogConsult, LOG_CREATE = @LogCreate, LOG_EDIT = @LogEdit, LOG_DELETE = @LogDelete, CAN_AUTORISE = @CanAutorise WHERE IDPERMISSIONS = @IDPERMISSIONS";
                _connection.Open();
                SqlCommand cmd = new SqlCommand(query, _connection);

                cmd.Parameters.AddWithValue("@Name", role.NAME);
                cmd.Parameters.AddWithValue("@Description", role.DESCRIPTION);
                cmd.Parameters.AddWithValue("@UsersAccess", role.USERS_ACCESS);
                cmd.Parameters.AddWithValue("@UsersConsult", role.USERS_CONSULT);
                cmd.Parameters.AddWithValue("@UsersCreate", role.USERS_CREATE);
                cmd.Parameters.AddWithValue("@UsersEdit", role.USERS_EDIT);
                cmd.Parameters.AddWithValue("@UsersDelete", role.USERS_DELETE);
                cmd.Parameters.AddWithValue("@ClientsAccess", role.CLIENTS_ACCESS);
                cmd.Parameters.AddWithValue("@ClientsConsult", role.CLIENTS_CONSULT);
                cmd.Parameters.AddWithValue("@ClientsCreate", role.CLIENTS_CREATE);
                cmd.Parameters.AddWithValue("@ClientsEdit", role.CLIENTS_EDIT);
                cmd.Parameters.AddWithValue("@ClientsDelete", role.CLIENTS_DELETE);
                cmd.Parameters.AddWithValue("@ProductsAccess", role.PRODUCTS_ACCESS);
                cmd.Parameters.AddWithValue("@ProductsConsult", role.PRODUCTS_CONSULT);
                cmd.Parameters.AddWithValue("@ProductsCreate", role.PRODUCTS_CREATE);
                cmd.Parameters.AddWithValue("@ProductsEdit", role.PRODUCTS_EDIT);
                cmd.Parameters.AddWithValue("@ProductsDelete", role.PRODUCTS_DELETE);
                cmd.Parameters.AddWithValue("@InvoicesAccess", role.INVOICES_ACCESS);
                cmd.Parameters.AddWithValue("@InvoicesConsult", role.INVOICES_CONSULT);
                cmd.Parameters.AddWithValue("@InvoicesCreate", role.INVOICES_CREATE);
                cmd.Parameters.AddWithValue("@InvoicesEdit", role.INVOICES_EDIT);
                cmd.Parameters.AddWithValue("@InvoicesDelete", role.INVOICES_DELETE);
                cmd.Parameters.AddWithValue("@RemissionsAccess", role.REMISSIONS_ACCESS);
                cmd.Parameters.AddWithValue("@RemissionsConsult", role.REMISSIONS_CONSULT);
                cmd.Parameters.AddWithValue("@RemissionsCreate", role.REMISSIONS_CREATE);
                cmd.Parameters.AddWithValue("@RemissionsEdit", role.REMISSIONS_EDIT);
                cmd.Parameters.AddWithValue("@RemissionsDelete", role.REMISSIONS_DELETE);
                cmd.Parameters.AddWithValue("@TransfersAccess", role.TRANSFERS_ACCESS);
                cmd.Parameters.AddWithValue("@TransfersConsult", role.TRANSFERS_CONSULT);
                cmd.Parameters.AddWithValue("@TransfersCreate", role.TRANSFERS_CREATE);
                cmd.Parameters.AddWithValue("@TransfersEdit", role.TRANSFERS_EDIT);
                cmd.Parameters.AddWithValue("@TransfersDelete", role.TRANSFERS_DELETE);
                cmd.Parameters.AddWithValue("@InventoryAccess", role.INVENTORY_ACCESS);
                cmd.Parameters.AddWithValue("@LogAccess", role.LOG_ACCESS);
                cmd.Parameters.AddWithValue("@LogConsult", role.LOG_CONSULT);
                cmd.Parameters.AddWithValue("@LogCreate", role.LOG_CREATE);
                cmd.Parameters.AddWithValue("@LogEdit", role.LOG_EDIT);
                cmd.Parameters.AddWithValue("@LogDelete", role.LOG_DELETE);
                cmd.Parameters.AddWithValue("@CanAutorise", role.CAN_AUTORISE);
                cmd.Parameters.AddWithValue("@IDPERMISSIONS", role.IDPERMISSIONS);
                int rowsAffected = cmd.ExecuteNonQuery();
                _connection.Close();
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
                _connection.Close();
                message = "Error :" + ex.Message;
            }
            return false;
        }

        public bool UpdateUser(Users user)
        {
            try
            {
                string query = "UPDATE USERS SET USERNAME = @Username, NAME = @Name, LASTNAME = @Lastname, PASSWORD = @Password, PERMISSIONS = @Permissions, EMAIL = @Email, UPDATED_AT = @UpdatedAt, VALID = @Valid WHERE IDUSER = @IdUser";
                _connection.Open();
                SqlCommand cmd = new SqlCommand(query, _connection);

                cmd.Parameters.AddWithValue("@Username", user.USERNAME);
                cmd.Parameters.AddWithValue("@Name", user.NAME);
                cmd.Parameters.AddWithValue("@Lastname", user.LASTNAME);
                cmd.Parameters.AddWithValue("@Password", user.PASSWORD);
                cmd.Parameters.AddWithValue("@Permissions", user.PERMISSIONS);
                cmd.Parameters.AddWithValue("@Email", user.EMAIL);
                cmd.Parameters.AddWithValue("@UpdatedAt", DateTime.Now.ToString("yyyyMMdd"));
                cmd.Parameters.AddWithValue("@Valid", user.VALID);
                cmd.Parameters.AddWithValue("@IdUser", user.IDUSER);

                int rowsAffected = cmd.ExecuteNonQuery();
                _connection.Close();
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
                _connection.Close();
                message = "Error :" + ex.Message;
            }
            return false;
        }

        public bool UpdateOrderPrint(Configurations confi)
        {
            try
            {
                string query = "UPDATE CONFIGURATIONS SET ORDEROUTPUT = @ORDEROUTPUT WHERE IDCLIENT = @IDCLIENT";
                _connection.Open();
                SqlCommand cmd = new SqlCommand(query, _connection);

                cmd.Parameters.AddWithValue("@IDCLIENT", confi.IDCLIENT);
                cmd.Parameters.AddWithValue("@ORDEROUTPUT", confi.ORDEROUTPUT);


                int rowsAffected = cmd.ExecuteNonQuery();
                _connection.Close();
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
                _connection.Close();
                message = "Error :" + ex.Message;
            }
            return false;
        }

        public bool UpdateRemissionsPrint(Configurations confi)
        {
            try
            {
                string query = "UPDATE CONFIGURATIONS SET REMISSIONOUTPUT = @REMISSIONOUTPUT WHERE IDCLIENT = @IDCLIENT";
                _connection.Open();
                SqlCommand cmd = new SqlCommand(query, _connection);

                cmd.Parameters.AddWithValue("@IDCLIENT", confi.IDCLIENT);
                cmd.Parameters.AddWithValue("@REMISSIONOUTPUT", confi.REMISSIONOUTPUT);


                int rowsAffected = cmd.ExecuteNonQuery();
                _connection.Close();
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
                _connection.Close();
                message = "Error :" + ex.Message;
            }
            return false;
        }

        public bool UpdateProformaPrint(Configurations confi)
        {
            try
            {
                string query = "UPDATE CONFIGURATIONS SET PROFORMAOUTPUT = @PROFORMAOUTPUT WHERE IDCLIENT = @IDCLIENT";
                _connection.Open();
                SqlCommand cmd = new SqlCommand(query, _connection);

                cmd.Parameters.AddWithValue("@IDCLIENT", confi.IDCLIENT);
                cmd.Parameters.AddWithValue("@PROFORMAOUTPUT", confi.PROFORMAOUTPUT);


                int rowsAffected = cmd.ExecuteNonQuery();
                _connection.Close();
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
                _connection.Close();
                message = "Error :" + ex.Message;
            }
            return false;
        }

        public bool UpdateProformaAndRemission(string proforma, int IDINVOICE_ITEMS, int STATUS, bool VALID)
        {
            try

            {
                string query = "UPDATE INVOICE_ITEMS SET REMISION = @REMISION, PROFORMA = @PROFORMA, STATUS = @STATUS, VALID = @VALID WHERE IDINVOICE_ITEMS = @IDINVOICE_ITEMS";
                _connection.Open();
                SqlCommand cmd = new SqlCommand(query, _connection);
                cmd.Parameters.AddWithValue("@IDINVOICE_ITEMS", IDINVOICE_ITEMS);
                cmd.Parameters.AddWithValue("@REMISION", proforma);
                cmd.Parameters.AddWithValue("@PROFORMA", proforma);
                cmd.Parameters.AddWithValue("@STATUS", STATUS);
                cmd.Parameters.AddWithValue("@VALID", VALID);


                int rowsAffected = cmd.ExecuteNonQuery();
                _connection.Close();
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
                _connection.Close();
                message = "Error :" + ex.Message;
            }
            return false;
        }

        public bool Updateconfiguration(int CLIENT_ID, int FOLIO)
        {
            try

            {
                string query = "UPDATE CONFIGURATIONS SET OUTPUT = @FOLIO + 1 WHERE IDCLIENT = @CLIENT_ID";
                _connection.Open();
                SqlCommand cmd = new SqlCommand(query, _connection);
                cmd.Parameters.AddWithValue("@FOLIO", FOLIO);
                cmd.Parameters.AddWithValue("@CLIENT_ID", CLIENT_ID);

                int rowsAffected = cmd.ExecuteNonQuery();
                _connection.Close();
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
                _connection.Close();
                message = "Error :" + ex.Message;
            }
            return false;
        }

        public bool UpdateSaveFolio(int CLIENT_ID, int FOLIO)
        {
            try
            {
                string query = "UPDATE CONFIGURATIONS SET OUTPUT = @FOLIO - 1 WHERE IDCLIENT = @CLIENT_ID";
                _connection.Open();
                SqlCommand cmd = new SqlCommand(query, _connection);
                cmd.Parameters.AddWithValue("@FOLIO", FOLIO);
                cmd.Parameters.AddWithValue("@CLIENT_ID", CLIENT_ID);

                int rowsAffected = cmd.ExecuteNonQuery();
                _connection.Close();
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
                _connection.Close();
                message = "Error :" + ex.Message;
            }
            return false;
        }

        public bool UpdateInventary(int IDINVOICE_ITEMS, int STATUS, bool VALID)
        {
            try
            {
                //ERROR SQL!!!!!!!!!!!!
                string query = "UPDATE INVENTARY SET STATUS = @STATUS, VALID = @VALID WHERE IDINVOICE_ITEMS = @IDINVOICE_ITEMS";
                _connection.Open();
                SqlCommand cmd = new SqlCommand(query, _connection);
                cmd.Parameters.AddWithValue("@IDINVOICE_ITEMS", IDINVOICE_ITEMS);
                cmd.Parameters.AddWithValue("@STATUS", STATUS);
                cmd.Parameters.AddWithValue("@VALID", VALID);


                int rowsAffected = cmd.ExecuteNonQuery();
                _connection.Close();
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
                _connection.Close();
                message = "Error :" + ex.Message;
            }
            return false;
        }

        public bool UpdateRemision(string ID_REMISSION_HEADER, int STATUS, bool VALID, DateTime REMISSION_AT)
        {
            try
            {
                string query = "UPDATE REMISSION_HEADER SET UPDATE_AT = @UPDATE_AT, REMISSION_AT = @REMISSION_AT, STATUS = @STATUS, VALID = @VALID WHERE ID_REMISSION_HEADER = @ID_REMISSION_HEADER";
                _connection.Open();
                SqlCommand cmd = new SqlCommand(query, _connection);
                cmd.Parameters.AddWithValue("@ID_REMISSION_HEADER", ID_REMISSION_HEADER);
                cmd.Parameters.AddWithValue("@STATUS", STATUS);
                cmd.Parameters.AddWithValue("@UPDATE_AT", DateTime.Now);
                cmd.Parameters.AddWithValue("@REMISSION_AT", REMISSION_AT);
                cmd.Parameters.AddWithValue("@VALID", VALID);

                int rowsAffected = cmd.ExecuteNonQuery();
                _connection.Close();
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
                _connection.Close();
                message = "Error :" + ex.Message;
            }
            return false;
        }

        public bool UpdateRemisionSeal(string ID_REMISSION_HEADER, string IDSEAL, string NOTE)
        {
            try
            {
                string query = "UPDATE REMISSION_HEADER SET IDSEAL = @IDSEAL, NOTE = @NOTE WHERE ID_REMISSION_HEADER = @ID_REMISSION_HEADER";
                _connection.Open();
                SqlCommand cmd = new SqlCommand(query, _connection);
                cmd.Parameters.AddWithValue("@ID_REMISSION_HEADER", ID_REMISSION_HEADER);
                cmd.Parameters.AddWithValue("@IDSEAL", IDSEAL);
                cmd.Parameters.AddWithValue("@NOTE", NOTE);

                int rowsAffected = cmd.ExecuteNonQuery();
                _connection.Close();
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
                _connection.Close();
                message = "Error :" + ex.Message;
            }
            return false;
        }

        public bool UpdateRemisionDestinatios(string ID_REMISSION_HEADER, int CLIENT_DESTINATION)
        {
            try
            {
                string query = "UPDATE REMISSION_HEADER SET CLIENT_DESTINATION = @CLIENT_DESTINATION WHERE ID_REMISSION_HEADER = @ID_REMISSION_HEADER";
                _connection.Open();
                SqlCommand cmd = new SqlCommand(query, _connection);
                cmd.Parameters.AddWithValue("@ID_REMISSION_HEADER", ID_REMISSION_HEADER);
                cmd.Parameters.AddWithValue("@CLIENT_DESTINATION", CLIENT_DESTINATION);

                int rowsAffected = cmd.ExecuteNonQuery();
                _connection.Close();
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
                _connection.Close();
                message = "Error :" + ex.Message;
            }
            return false;
        }

        public bool UpdateRemisionShip(string ID_REMISSION_HEADER, int PURCHASE_ORDER_ID_CLIENT)
        {
            try
            {
                string query = "UPDATE REMISSION_HEADER SET PURCHASE_ORDER_ID_CLIENT = @PURCHASE_ORDER_ID_CLIENT WHERE ID_REMISSION_HEADER = @ID_REMISSION_HEADER";
                _connection.Open();
                SqlCommand cmd = new SqlCommand(query, _connection);
                cmd.Parameters.AddWithValue("@ID_REMISSION_HEADER", ID_REMISSION_HEADER);
                cmd.Parameters.AddWithValue("@PURCHASE_ORDER_ID_CLIENT", PURCHASE_ORDER_ID_CLIENT);

                int rowsAffected = cmd.ExecuteNonQuery();
                _connection.Close();
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
                _connection.Close();
                message = "Error :" + ex.Message;
            }
            return false;
        }
        public bool UpdateRemisionRemissionAt(string ID_REMISSION_HEADER, DateTime REMISSION_AT)
        {
            try
            {
                string query = "UPDATE REMISSION_HEADER SET REMISSION_AT = @REMISSION_AT WHERE ID_REMISSION_HEADER = @ID_REMISSION_HEADER";
                _connection.Open();
                SqlCommand cmd = new SqlCommand(query, _connection);
                cmd.Parameters.AddWithValue("@ID_REMISSION_HEADER", ID_REMISSION_HEADER);
                cmd.Parameters.AddWithValue("@REMISSION_AT", REMISSION_AT);

                int rowsAffected = cmd.ExecuteNonQuery();
                _connection.Close();
                if (rowsAffected > 0)
                {
                    Console.WriteLine("Actualización exitosa.");
                    return true;
                }
                else
                {
                    Console.WriteLine("Fecha no valida.");
                    return false;
                }

            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Error :" + ex.Message);
                _connection.Close();
                message = "Error :" + ex.Message;
            }
            return false;
        }

        public bool UpdateDescriptionInItems(string DESCRIPTION,bool VALID, int IDINVOICE_ITEMS)
        {
            try
            {
                string query = "UPDATE INVOICE_ITEMS SET DESCRIPTION = @DESCRIPTION, VALID = @VALID WHERE IDINVOICE_ITEMS = @IDINVOICE_ITEMS";
                _connection.Open();
                SqlCommand cmd = new SqlCommand(query, _connection);
                cmd.Parameters.AddWithValue("@DESCRIPTION", DESCRIPTION);
                cmd.Parameters.AddWithValue("@IDINVOICE_ITEMS", IDINVOICE_ITEMS);
                cmd.Parameters.AddWithValue("@VALID", VALID);
                int rowsAffected = cmd.ExecuteNonQuery();
                _connection.Close();
                if (rowsAffected > 0)
                {
                    Console.WriteLine("Actualización exitosa.");
                    return true;
                }
                else
                {
                    Console.WriteLine("Fecha no valida.");
                    return false;
                }

            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Error :" + ex.Message);
                _connection.Close();
                message = "Error :" + ex.Message;
            }
            return false;
        }
    }
}


