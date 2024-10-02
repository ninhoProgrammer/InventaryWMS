using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventaryWMS
{
    public partial class Product : Form
    {
        #region Variables and triggers
        readonly Security security = new Security();
        readonly SelectSQL selectSQL = new SelectSQL();
        private bool viewSerch { get; set; }

        private int _idClient { get; set; }

        public Product()
        {
            InitializeComponent();
            Inicialize();
        }

        #endregion

        #region Click and ValueChanged
        private void buttonSerch_Click(object sender, EventArgs e)
        {
            dataProducts.Columns.Clear();
            if (viewSerch)
            {

                dataProducts.DataSource = selectSQL.SearchInProducts(_idClient, "DESCRIPTION LIKE '%" + textSearch.Text + "%'");
                if(dataProducts.Rows.Count == 0)
                {
                    dataProducts.DataSource = selectSQL.SearchInProducts(_idClient, "PART_NUMBER_PROVIDER LIKE '%" + textSearch.Text + "%'");
                }
            }
            else
            {
                try
                {
                    if (textBoxDateInitial.Text != "" && textBoxDateLast.Text != "")
                    {
                        var timeInitial = DateTime.Parse(textBoxDateInitial.Text);
                        var timeLast = DateTime.Parse(textBoxDateLast.Text);
                        dataProducts.DataSource = selectSQL.SearchInProducts(_idClient, "CREATE_AT BETWEEN '" + timeInitial.ToString("yyyy-MM-dd") + " 00:00:00' and '" + timeLast.ToString("yyyy-MM-dd") + " 23:59:59'");
                    }
                    else
                    {
                        dataProducts.DataSource = selectSQL.ShowDataProducts(_idClient);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            buttonSerch.Enabled = false;
            buttonClear.Visible = true;
        }

        private void pictureBoxNotEneble_Click(object sender, EventArgs e)
        {
            viewSerch = true;
            VisibleForm(viewSerch);
        }

        private void pictureBoxEneble_Click(object sender, EventArgs e)
        {
            viewSerch = false;
            VisibleForm(viewSerch);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dataProducts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            FormProducts formProducts = new FormProducts(dataProducts.Rows[e.RowIndex].Cells[0].Value.ToString());
            formProducts.ShowDialog();
        }
        private void dateTimePickerLast_ValueChanged(object sender, EventArgs e)
        {
            textBoxDateLast.Text = dateTimePickerLast.Value.ToString("dd-MM-yyyy");
        }

        private void dateTimePickerInitial_ValueChanged(object sender, EventArgs e)
        {
            textBoxDateInitial.Text = dateTimePickerInitial.Value.ToString("dd-MM-yyyy");
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            buttonSerch.Enabled = true;
            dataProducts.DataSource = selectSQL.ShowDataProducts(_idClient);
            buttonClear.Visible = false;
        }

        private void Product_Click(object sender, EventArgs e)
        {
            BringToFront();
        }
        #endregion

        #region Funtions

        private void VisibleForm(bool panel)
        {
            pictureBoxNotEneble.Visible = !panel;
            pictureBoxEneble.Visible = panel;
            labelDescrition.Visible = panel;
            panelDescription.Visible = panel;
            textSearch.Visible = panel;
            dateTimePickerInitial.Visible = !panel;
            dateTimePickerLast.Visible = !panel;
            textBoxDateInitial.Visible = !panel;
            textBoxDateLast.Visible = !panel;
            labelOf.Visible = !panel;
            labelA.Visible = !panel;
            //panelDateToDate.Visible = !panel; 339, 10
        }

        public void Inicialize()
        {
            //security.
            _idClient = int.Parse(security.createFile("address.txt"));
            FillDataGrid();
            viewSerch = true;
            buttonClear.Visible = false;
            VisibleForm(viewSerch);
        }

        public void FillDataGrid()
        {
            dataProducts.AllowUserToAddRows = false;
            dataProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataProducts.RowHeadersVisible = false;
            dataProducts.AutoResizeColumns();
            dataProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataProducts.Columns.Clear();
            dataProducts.DataSource = selectSQL.ShowDataProducts(_idClient);
        }

        #endregion

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
