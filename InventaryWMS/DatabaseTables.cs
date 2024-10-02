using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace InventaryWMS
{
    public class Prod
    {
        public int IDPRODUCTS { get; set; }
        public int IDCLIENT { get; set; }
        public string PART_NUMBER_PROVIDER { get; set; }
        public string PART_NUMBER_CLIENT { get; set; }
        public string REFERENCE { get; set; }
        public string DESCRIPTION { get; set; }
        public int MEASSURMENT_UNIT { get; set; }
        public string WEIGHT { get; set; }
        public string UNIT_VALUE { get; set; }
        public int CURRENCY { get; set; }
        public string TARIFF_FRACTION { get; set; }
        public int ORIGIN_COUNTRY { get; set; }
        public string ITEMS_PER_BOX { get; set; }

        public string SESSION_IDSESSION { get; set; }
        public string STANDARD_PACK_PALLET { get; set; }
        public bool VALID { get; set; }

        public Prod()
        {
            WEIGHT = "0";
            UNIT_VALUE = "0";
            TARIFF_FRACTION = "0";
            MEASSURMENT_UNIT = 10;
            CURRENCY = 1;
            ITEMS_PER_BOX = "0";
            SESSION_IDSESSION = null;
            STANDARD_PACK_PALLET = "0";
            REFERENCE = "PENDIENTE";
        }
    }
    public class Warehouse
    {
        public int IDWAREHOUSES { get; set; }
        public string NAME { get; set; }
        public string SHORT_NAME { get; set; }
        public string DESCRIPTION { get; set; }
        public int COUNTRY { get; set; }
        public int STATE { get; set; }
        public string CITY { get; set; }
        public string DISTRICT { get; set; }
        public string STREET { get; set; }
        public string ZIPCODE { get; set; }
        public bool VALID { get; set; }
    }
    public class Country
    {
        public int IDCONTRY { get; set; }
        public string NAME { get; set; }
    }
    public class State
    {
        public int IDSTATE { get; set; }
        public string NAME { get; set; }
    }
    public class WarehouseRack
    {
        public int IDRACK { get; set; }
        public int idWarehouse { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int type { get; set; }
        public int totalPositions { get; set; }
        public int levels { get; set; }
        public bool valid { get; set; }
        public int? clientId { get; set; }
    }
    public class Provider
    {
        public int IDCLIENTE_PROVIDERS { get; set; }
        public int IDCLIENTE { get; set; }
        public string NAME { get; set; }
        public string DESCRIPTION { get; set; }
        public bool VALID { get; set; }
    }
    public class WarehouseRack_Position
    {
        public int idPosition { get; set; }
        public int idRack { get; set; }
        public string name { get; set; }
        public int level { get; set; }
        public int max_weight { get; set; }
        public int priority { get; set; }
        public int type { get; set; }
        public int excluded { get; set; }
        public bool valid { get; set; }
    }    
    public class TransferTableRow
    {
        public int idInventory { get; set; }
        public int localId { get; set; }
        public string serial { get; set; }
        public string externalSerial { get; set; }
        public string pedimentoAduanal { get; set; }
        public string partNumberProvider { get; set; }
        public string partNumberClient { get; set; }
        public string description { get; set; }
        public double quantity { get; set; }        
        public int clientId { get; set; }
        public string clientName { get; set; }
        public DateTime expirationDate { get; set; }
        public string invoice { get; set; }
        public string batch { get; set; }


        public int rackPositionId { get; set; }
        public string rackPositionName { get; set; }
        public string rackName { get; set; }
        public int idRack { get; set; }
        public string warehouse {  get; set; }
        public int idWarehouse { get; set; }
    }
    public class Invoice_items
    {
        public int idInvoice { get; set; }
        public string serial { get; set;}
    }
    public class Destinations
    {
        public int IDCLIENTE_DESTINATIONS { get; set; }
        public int IDCLIENTE { get; set; }
        public string NAME { get; set; }
        public string DESCRIPTION { get; set; }
        public int COUNTRY { get; set; }
        public string STATE { get; set; }
        public string CITY { get; set; }
        public string DISTRICT { get; set; }
        public string STREET { get; set; }
        public string ZIPCODE { get; set; }
        public string IMMEX { get; set; }
        public string RFC { get; set; }
        public bool VALID { get; set; }

        public Destinations()
        {
            COUNTRY = 112;
        }
    }
    public class Clients
    {
        public int IDCLIENTS { get; set; }
        public string NAME { get; set; }
        public string SHORT_NAME { get; set; }
        public string DOCUMNET_NAME { get; set; }
        public string PREFIX { get; set; }
        public int TYPE { get; set; }
        public int COUNTRY { get; set; }
        public string STATE { get; set; }
        public string CITY { get; set; }
        public string DISTRICT { get; set; }
        public string STREET { get; set; }
        public string ZIPCODE { get; set; }
        public string IMMEX { get; set; }
        public string RFC { get; set; }
        public string CONTACT_EMAIL { get; set; }
        public string CONTACT_NUMBER { get; set; }
        public int AUTOMATIC_EMAIL_INVOICE { get; set; }
        public int AUTOMATIC_EMAIL_REMISSION { get; set; }
        public int AUTOMATIC_EMAIL_INVENTARY { get; set; }
        public string CREATE_AT { get; set; }
        public string UPDATED_AT { get; set; }
        public string SESSION_IDSESSION { get; set; }
        public bool VALID { get; set; }

        public Clients()
        {
            COUNTRY = 112;
            TYPE = 0;
            AUTOMATIC_EMAIL_INVOICE = 0;
            AUTOMATIC_EMAIL_REMISSION = 0;
            AUTOMATIC_EMAIL_INVENTARY = 0;
            CONTACT_NUMBER = "0";
            DOCUMNET_NAME = "PENDIENTE";
            VALID = true;
        }
    }
    public class Configurations
    {
        public int IDCONFIGURATIONS { get; set; }
        public int IDCLIENT { get; set; }
        public int INPUT { get; set; } 
        public int OUTPUT { get; set; }
        public int ORDEROUTPUT { get; set; } 
        public int REMISSIONOUTPUT { get; set; }
        public int PROFORMAOUTPUT { get; set; }

        public Configurations()
        {
            INPUT = 1; 
            OUTPUT = 1;
            ORDEROUTPUT = 1;
            REMISSIONOUTPUT = 3;
            PROFORMAOUTPUT = 3;
        }
    }
    public class Permisions
    {
        public int IDPERMISSIONS { get; set; }
        public string NAME { get; set; }
        public string DESCRIPTION { get; set; }
        public bool USERS_ACCESS { get; set; }
        public bool USERS_CONSULT { get; set; }
        public bool USERS_CREATE { get; set; }
        public bool USERS_EDIT { get; set; }
        public bool USERS_DELETE { get; set; }
        public bool CLIENTS_ACCESS { get; set; }
        public bool CLIENTS_CONSULT { get; set; }
        public bool CLIENTS_CREATE { get; set; }
        public bool CLIENTS_EDIT { get; set; }
        public bool CLIENTS_DELETE { get; set; }
        public bool PRODUCTS_ACCESS { get; set; }
        public bool PRODUCTS_CONSULT { get; set; }
        public bool PRODUCTS_CREATE { get; set; }
        public bool PRODUCTS_EDIT { get; set; }
        public bool PRODUCTS_DELETE { get; set; }
        public bool INVOICES_ACCESS { get; set; }
        public bool INVOICES_CONSULT { get; set; }
        public bool INVOICES_CREATE { get; set; }
        public bool INVOICES_EDIT { get; set; }
        public bool INVOICES_DELETE { get; set; }
        public bool REMISSIONS_ACCESS { get; set; }
        public bool REMISSIONS_CONSULT { get; set; }
        public bool REMISSIONS_CREATE { get; set; }
        public bool REMISSIONS_EDIT { get; set; }
        public bool REMISSIONS_DELETE { get; set; }
        public bool TRANSFERS_ACCESS { get; set; }
        public bool TRANSFERS_CONSULT { get; set; }
        public bool TRANSFERS_CREATE { get; set; }
        public bool TRANSFERS_EDIT { get; set; }
        public bool TRANSFERS_DELETE { get; set; }
        public bool INVENTORY_ACCESS { get; set; }
        public bool LOG_ACCESS { get; set; }
        public bool LOG_CONSULT { get; set; }
        public bool LOG_CREATE { get; set; }
        public bool LOG_EDIT { get; set; }
        public bool LOG_DELETE { get; set; }
        public bool CAN_AUTORISE { get; set; }
    }
    public class Users
    {
        public int IDUSER { get; set; }
        public string USERNAME { get; set; }
        public string NAME { get; set; }
        public string LASTNAME { get; set; }
        public string PASSWORD { get; set; }
        public int PERMISSIONS { get; set; }
        public string EMAIL { get; set; }
        public DateTime CREATE_AT { get; set; }
        public DateTime UPDATED_AT { get; set; }
        public bool VALID { get; set; }

        public Users()
        {
            IDUSER = 0;
            VALID = true;
        }

        
    }
    public class WorkOrderInventoryItem
    {
        public string ID_WORDER_INV { get; set; }
        public string WORK_ORDER_ID { get; set; }
        public int INVENTORY_ID { get; set; }
        public int QUANTITY_REQUESTED { get; set; }
        public int STATUS { get; set; }
        public DateTime CREATE_AT { get; set; }
        public int SESSION_ID { get; set; }
        public bool VALID { get; set; }
    }
    public class WorkOrderHeader
    {
        public string ID_WORKORDER_HEADER { get; set; }
        public int CLIENT_ID { get; set; }
        public int TYPE { get; set; }
        public int PURCHASE_ORDER_CLIENT { get; set; }
        public int CLIENT_DESTINATION { get; set; }
        public int STATUS { get; set; }
        public DateTime CREATE_AT { get; set; }
        public DateTime UPDATED_AT { get; set; }
        public DateTime WORKORDER_AT { get; set; }
        public int SESSION_ID { get; set; }
        public bool VALID { get; set; }
    }
    public class Inventary 
    {
        public int IDINVENTORY { get; set; }
        public int ID_INVOICE_ITEM { get; set; }
        public int QUANTITY { get; set; }
        public string IDWAREHOUSE_RACK_POSITIONS { get; set; }
        public int STATUS { get; set; } 
        public bool VALID { get; set; }
    }
    public class RemissionHeader
    {
        public string ID_REMISSION_HEADER { get; set; }
        public int CLIENT_ID { get; set; }
        public int CLIENT_DESTINATION { get; set; }
        public int WORK_ORDER_ID { get; set; }
        public int PURCHASE_ORDER_ID_CLIENT { get; set; }
        public int TOTAL_PALLETS { get; set; }
        public int TRANSPORT_INFO_ID { get; set; }
        public int STATUS { get; set; }
        public string CREATE_AT { get; set; }
        public string UPDATED_AT { get; set; }
        public string REMISSION_AT { get; set; }
        public int SESSION_ID { get; set; }
        public bool VALID { get; set; }
    }
    public class InvoiceHeader
    {
        public int IDINVOICE_HEADERS { get; set; }
        public int IDCLIENTE { get; set; }
        public int INVOICE_INDEX { get; set; }
        public DateTime CREATE_AT { get; set; }
        public string INVOICE { get; set; }
        public string CUSTOMS_DOCUMENTS { get; set; }
        public string PROFORMA { get; set; }
        public string CLIENT_REFERENCE { get; set; }
        public int IDWAREHOUSES { get; set; }
        public int IDTRANSPORT_INFO { get; set; }
        public int STATUS { get; set; }
        public string COMMENTS { get; set; }
        public int SESSION_IDSESSION { get; set; }
        public bool VALID { get; set; }
        public float SUBTOTAL { get; set; }
        public float DISCOUNT { get; set; }
        public float TAX { get; set; }
        public float TOTAL { get; set; }
        public string RECEIVES { get; set; }
    }
    public class InvoiceItem
    {
        public int IDINVOICE_ITEMS { get; set; }
        public int IDINVOICE_HEADERS { get; set; }
        public int IDINVOICE_PALLETS { get; set; }
        public int IDPRODUCTS { get; set; }
        public float QUANTITY { get; set; }
        public string INVOICE { get; set; }
        public string BATCH { get; set; }
        public string EXTERNAL_SERIAL { get; set; }
        public string EXPIRATION_DATE { get; set; }
        public string REVISION { get; set; }
        public string IDWAREHOUSE_RACKS_POSITIONS { get; set; }
        public string CUSTOMS_DOCUMENT { get; set; }
        public string PROFORMA { get; set; }
        public string SERIAL { get; set; }
        public string PACKING_LIST { get; set; }
        public int BOXES { get; set; }
        public int IDCLIENT_PROVIDERS { get; set; }
        public string DESCRIPTION { get; set; }
        public int IDMEASURING_UNIT { get; set; }
        public float WEIGHT { get; set; }
        public string UNIT_VALUE { get; set; }
        public int IDCURRENCY { get; set; }
        public string TARIFF_FRACTION { get; set; }
        public int IDCOUNTRIES { get; set; }
        public string STATUS { get; set; }
        public string CREATE_AT { get; set; }
        public string UPDATED_AT { get; set; }
        public int SESSION_IDSESSION { get; set; }
        public bool VALID { get; set; }
        public string PEDIMENTOADUANAL { get; set; }
        public int ID_INTERNAL_WAREHOUSE { get; set; }
        public string REGIMEN { get; set; }
        public string REMISION { get; set; }
        public string PEDIMENTO_DATE { get; set; }
        public string PAY_DATE { get; set; }
        public string CONTAINER { get; set; }
        public float COST { get; set; }
        public float PRICE { get; set; }
        public InvoiceItem()
        {
            BATCH = "S/L";
            REVISION = "Revisión";
            CUSTOMS_DOCUMENT = "Documentos";
            PROFORMA = "Proforma";
            PACKING_LIST = "Lista de embalaje";

        }
    }
}