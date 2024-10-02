using Microsoft.Reporting.WinForms;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventaryWMS
{
    public partial class Reports : Form
    {
        SelectSQL selectSQL = new SelectSQL();
        Security Security = new Security();
        static string reportPath { get; set; }
        static string query { get; set; }
        string[] reportDate { get; set; }
        int status { get; set; }
        private int _idClient { get; set; }
        public Reports()
        {
            InitializeComponent();
            selectSQL.ReportsAComboBox(comboBoxReportName);
            _idClient = int.Parse(Security.createFile("address.txt"));
            statusChange(true);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            spinner.Visible = true;
            query = dataQuery();
            if (query != " ")
            {
                try
                {
                    Task.Run(() =>
                    {

                        this.Invoke((Action)(() =>
                        {
                            dataReport.DataSource = selectSQL.ShowDataRepots(query);
                            buttonPrint.Visible = true;

                        }));
                    });
                }
                catch (Exception ex) { }

            }
            spinner.Visible = false;
        }

        public string dataQuery()
        {
            string sentecy = " ";
            reportDate = selectSQL.FillDateRepots(comboBoxReportName.Text);
            reportPath = reportDate[1];
            if (comboBoxReportName.Text != "")
            {

                if (textBoxInitialDate.Text == "" && textBoxEndDate.Text == "")
                {
                    if (comboBoxReportName.SelectedIndex == 4)
                    {
                        sentecy = reportDate[2] + " WHERE  PRODUCTS.IDCLIENTE = " + _idClient + " AND " + reportDate[0] + ".VALID = " + 0 + " " + reportDate[3] + " ";

                    }
                    else
                    {
                        sentecy = reportDate[2] + " WHERE  PRODUCTS.IDCLIENTE = " + _idClient + " AND " + reportDate[0] + ".VALID = " + status + " " + reportDate[3] + " ";

                    }
                }
                else
                {
                    if (!(textBoxInitialDate.Text == "" || textBoxEndDate.Text == ""))
                    {
                        if (comboBoxReportName.SelectedIndex == 4)
                        {
                            var timeInitial = DateTime.Parse(textBoxInitialDate.Text);
                            var timeLast = DateTime.Parse(textBoxEndDate.Text);
                            sentecy = reportDate[2] + " WHERE REMISSION_HEADER.REMISSION_AT BETWEEN '" + timeInitial.ToString("yyyy-MM-dd") + " 00:00:00' and '" + timeLast.ToString("yyyy-MM-dd") + " 23:59:59' AND PRODUCTS.IDCLIENTE = " + _idClient + " AND  " + reportDate[0] + ".VALID = " + 0 + " " + reportDate[3] + " ORDER BY " + reportDate[0] + ".CREATE_AT DESC";
                        }
                        else
                        {
                            var timeInitial = DateTime.Parse(textBoxInitialDate.Text);
                            var timeLast = DateTime.Parse(textBoxEndDate.Text);
                            sentecy = reportDate[2] + " WHERE " + reportDate[0] + ".CREATE_AT BETWEEN '" + timeInitial.ToString("yyyy-MM-dd") + " 00:00:00' and '" + timeLast.ToString("yyyy-MM-dd") + " 23:59:59' AND PRODUCTS.IDCLIENTE = " + _idClient + " AND  " + reportDate[0] + ".VALID = " + status + " " + reportDate[3] + " ORDER BY " + reportDate[0] + ".CREATE_AT DESC";
                        }

                    }
                    else
                    {
                        MessageBox.Show("Error: Falta de llenar un campo fecha");
                        buttonPrint.Visible = false;
                    }
                }
            }
            else
            {
                MessageBox.Show("Favor de selecionar un reporte");
                buttonPrint.Visible = false;
            }

            return sentecy;
        }

        /*public void conexCN(ReportDocument rep)
        {

            ConnectionInfo cn = new ConnectionInfo();
            cn.ServerName = "192.168.2.10";
            cn.DatabaseName = "WMS_REIS_NEW";
            cn.UserID = "sa";
            cn.Password = "ReisWMS2019";
            cn.Type = ConnectionInfoType.SQL;
            SetDBLogonForReport(cn, rep);

        }

        private void SetDBLogonForReport(CrystalDecisions.Shared.ConnectionInfo connectionInfo, ReportDocument rptDocument)
        {
            Tables myTables = rptDocument.Database.Tables;
            foreach (CrystalDecisions.CrystalReports.Engine.Table myTable in myTables)
            {
                TableLogOnInfo myTableLogonInfo = myTable.LogOnInfo;
                myTableLogonInfo.ConnectionInfo = connectionInfo;
                myTable.ApplyLogOnInfo(myTableLogonInfo);
            }
        }*/

        public string changesName(string nombreEntrante)
        {
            string[] tRep = nombreEntrante.Split(' ');
            string nombre = null;

            foreach (string lista in tRep)
            {
                if (nombre == null)
                {
                    nombre = lista;
                }
                else
                {
                    nombre = nombre + "_" + lista;
                }
            }
            return nombre;
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void comboBoxPermissions_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBoxTrue_Click(object sender, EventArgs e)
        {
            statusChange(false);
        }

        private void pictureBoxFalse_Click(object sender, EventArgs e)
        {
            statusChange(true);
        }

        public void statusChange(bool change)
        {
            if (change)
            {
                status = 1;
            }
            else
            {
                status = 0;
            }
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void Repots_Load(object sender, EventArgs e)
        {

        }

        private void dateTimePickerInitialDate_ValueChanged(object sender, EventArgs e)
        {
            textBoxInitialDate.Text = dateTimePickerInitialDate.Value.ToString("dd/MM/yyyy");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadingSpinner1.Visible = true;

            try
            {
                Task.Run(() =>
                {
                    ReportDataSource reportData = new ReportDataSource("DataSet", selectSQL.ShowDataRepots(query));
                    this.Invoke((Action)(() =>
                    {
                        FormReports formReports = new FormReports(reportPath, reportData);
                        formReports.ShowDialog();
                        loadingSpinner1.Visible = false;
                    }));
                });
            }
            catch (Exception ex) { }
        }

        private void dateTimePickerEndDate_ValueChanged(object sender, EventArgs e)
        {
            textBoxEndDate.Text = dateTimePickerEndDate.Value.ToString("dd/MM/yyyy");

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBoxInitialDate_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void comboBoxReportName_SelectedIndexChanged(object sender, EventArgs e)
        {
            dateTimePickerInitialDate.Value = DateTime.Now;
            textBoxInitialDate.Clear();
            dateTimePickerEndDate.Value = DateTime.Now;
            textBoxEndDate.Clear();
        }
    }
}
