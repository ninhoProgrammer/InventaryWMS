using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventaryWMS
{
    public partial class FormReports : Form
    {
        //public ReportDocument rCr = new ReportDocument();
        SelectSQL selectSQL = new SelectSQL();
        public string parametrer { get; set; }

        string reporteDireccion = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\\..\\..\\ReisWMS\Report.rdlc"));

        public string tituloEmpresa { get; set; }
        public string tituloReporte { get; set; }


        public FormReports(string report, ReportDataSource reportData)
        {
            InitializeComponent();
            reportViewer1.LocalReport.ReportPath = report;
           
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(reportData);
           

            this.Controls.Add(reportViewer1);

            // Refresca el informe
            reportViewer1.RefreshReport();
        }

        public FormReports()
        {
            InitializeComponent();
            
        }

        /*
        public void conexCN(ReportDocument rep)
        {
            try
            {
                ConnectionInfo cn = new ConnectionInfo();
                cn.ServerName = "192.168.2.10";
                cn.DatabaseName = "WMS_REIS_NEW";
                cn.UserID = "sa";
                cn.Password = "ReisWMS2019";
                cn.Type = ConnectionInfoType.SQL;
                SetDBLogonForReport(cn, rep);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
        }
        */


        public string cambiaNombre()
        {
            string[] tRep = tituloReporte.Split(' ');
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

        private void FormReports_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void crystalReportViewer2_Load(object sender, EventArgs e)
        {

            
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            try
            {
                Task.Run(() =>
                {
                    //rCr.Load(@"C:\WMS\Informe1.rpt");
                    //Informe11.r = rCr;
                    //conexCN(rCr);
                    //Informe11.Dispose();


                    //informe11.Dispose();
                    this.Invoke((Action)(() =>
                    {
                        //crystalReportViewer1.ReportSource = rCr;
                        //crystalReportViewer1.ReportSource = informe11;
                    }));
                });
            }
            catch { }
            {

            }
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
            try
            {
                Task.Run(() =>
                {
                    //rCr.Load(@"C:\WMS\Informe1.rpt");
                    //Informe11.r = rCr;
                    //conexCN(rCr);
                    //Informe11.Dispose();


                    //informe11.Dispose();
                    this.Invoke((Action)(() =>
                    {
                        //reportViewer1.re = rCr;
                        //crystalReportViewer1.ReportSource = informe11;
                    }));
                });
            }
            catch 
            {

            }
        }
    }
}

