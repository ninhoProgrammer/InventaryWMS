
using Microsoft.Reporting.WinForms;
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
    public partial class WorkOrder : Form
    {
        SelectSQL selectSQL = new SelectSQL();
        InsertSQL insertSQL = new InsertSQL();
        UpdateSQL updateSQL = new UpdateSQL();
        DeleteSQL deleteSQL = new DeleteSQL();
        Security security = new Security();
        WorkOrderHeader WorkOrderHeader { get; set; }
        private int _idClient { get; set; }
        private bool _new { get; set; }
        private bool _save { get; set; }
        static string reportPath { get; set; }
        static string query { get; set; }
        string[] reportDate { get; set; }
        
        public WorkOrder()
        {
            InitializeComponent();
            Inicialice();
        }

        public void Inicialice()
        {
           
            _idClient = int.Parse(security.createFile("address.txt"));
            pictureBoxEdit.Visible = false;
            this.Text = "Ordenees";
            VisibleForm(false);
            FillDataGrid();
        }

        private void comboBoxClient_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void buttonSave_Click(object sender, EventArgs e)
        {
            spinner.Visible = true;

            try
            {
                Task.Run(() =>
                {
                    reportDate = selectSQL.FillDateRepots("Orden");
                    reportPath = reportDate[1];
                    query = reportDate[2] + " WHERE " + reportDate[0] + ".VALID = 1" + reportDate[3] + " ";
                    //ReportDataSource reportData = new ReportDataSource("DataSet", selectSQL.ShowDataRepots(query));
                    this.Invoke((Action)(() =>
                    {
                        
                        //FormReports formReports = new FormReports(reportPath, reportData);
                        //formReports.ShowDialog();
                        spinner.Visible = false;
                    }));
                });
            }
            catch { }
        }

        public void VisibleForm(bool panel)
        {
            //if (panel == false)
               // comboBoxClient.Text = "";
            //----------------------Cambia lo de arriba-------------------------------------------
            
            comboBoxClient.Enabled = !panel;
            buttonSerch.Enabled = !panel;
            buttonPrint.Visible = panel;
            pictureBoxEdit.Visible = !panel;
            pictureBoxDelete.Visible = panel;
            pictureBoxCancel.Visible = panel;
            dataProducts.Enabled = panel;
        }

        public void FillDataGrid()
        {
            dataProducts.AllowUserToAddRows = false;
            dataProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataProducts.RowHeadersVisible = false;
            dataProducts.AutoResizeColumns();
            dataProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            _new = true;
            VisibleForm(true);

        }

        private void pictureBoxEdit_Click(object sender, EventArgs e)
        {
            VisibleForm(true);
            _save = true;
        }

        private void pictureBoxCancel_Click(object sender, EventArgs e)
        {
            VisibleForm(false);
            _save = false;
            _new = false;
        }

        private DataTable createtable()
        {
            DataTable tableOrderInvebtaryItem = new DataTable();
            tableOrderInvebtaryItem.Columns.Add("INVENTORY_ID", typeof(int));
            tableOrderInvebtaryItem.Columns.Add("QUANTITY_REQUESTED", typeof(int));
            tableOrderInvebtaryItem.Columns.Add("STATUS", typeof(string));
            tableOrderInvebtaryItem.Columns.Add("CREATE_AT", typeof(DateTime));
            tableOrderInvebtaryItem.Columns.Add("SESSION_ID", typeof(int));
            tableOrderInvebtaryItem.Columns.Add("VALID", typeof(bool));



            return tableOrderInvebtaryItem;
        }

        private void createOrderHeader()
        {
            //WorkOrderHeader.CLIENT_ID = _id;
        }

        private void pictureBoxDelete_Click(object sender, EventArgs e)
        {
            dataProducts.Rows.RemoveAt(dataProducts.CurrentRow.Index);
        }
    }
}
