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
    public partial class Binnacle : Form
    {
        #region Variables and triggers
        readonly SelectSQL selectSQL = new SelectSQL();

        private bool ViewSerch { get; set; }

        public Binnacle()
        {
            InitializeComponent();
            FillDataGrid();
            ViewSerch = false;
            buttonClear.Visible = false;
            VisibleForm(ViewSerch);
        }

        public void FillDataGrid()
        {
            dataBinnacle.AllowUserToAddRows = false;
            dataBinnacle.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataBinnacle.RowHeadersVisible = false;
            dataBinnacle.AutoResizeColumns();
            dataBinnacle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataBinnacle.Columns.Clear();
            dataBinnacle.DataSource = selectSQL.ShowDataBinnacle();
        }

        private void Binnacle_Load(object sender, EventArgs e)
        {

        }
        #endregion

        #region Click and ValueChanged
        private void ButtonSerch_Click(object sender, EventArgs e)
        {
            dataBinnacle.Columns.Clear();
            if (ViewSerch)
            {
                dataBinnacle.DataSource = selectSQL.SearchInBinnacle("DESCRIPTION LIKE '%" + textSearch.Text + "%'");
            }
            else
            {
                try
                {
                    if (textBoxDateInitial.Text != " " && textBoxDateLast.Text != " ")
                    {
                        var timeInitial = DateTime.Parse(textBoxDateInitial.Text);
                        var timeLast = DateTime.Parse(textBoxDateLast.Text);
                        dataBinnacle.DataSource = selectSQL.SearchInBinnacle("CREATE_AT BETWEEN '" + timeInitial.ToString("yyyy-MM-dd") + " 00:00:00' and '" + timeLast.ToString("yyyy-MM-dd") + " 23:59:59'");
                    }
                    else
                    {
                        dataBinnacle.DataSource = selectSQL.SearchInBinnacle("DESCRIPTION LIKE '%" + textSearch.Text + "%'");
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

        private void Binnancle_Click(object sender, EventArgs e)
        {
            this.BringToFront();
        }

        private void PictureBoxNotEneble_Click(object sender, EventArgs e)
        {
            ViewSerch = false;
            VisibleForm(ViewSerch);
        }

        private void PictureBoxEneble_Click(object sender, EventArgs e)
        {
            ViewSerch = true;
            VisibleForm(ViewSerch);
        }

        private void DateTimePickerInitial_ValueChanged(object sender, EventArgs e)
        {
            textBoxDateInitial.Text = dateTimePickerInitial.Value.ToString("dd-MM-yyyy");
        }

        private void DateTimePickerLast_ValueChanged(object sender, EventArgs e)
        {
            textBoxDateLast.Text = dateTimePickerLast.Value.ToString("dd-MM-yyyy");
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region Funcions
        private void VisibleForm(bool panel)
        {
            labelDescrition.Visible = panel;
            panelDescription.Visible = panel;
            pictureBoxNotEneble.Visible = panel;
            pictureBoxEneble.Visible = !panel;
            textSearch.Visible = panel;
            dateTimePickerInitial.Visible = !panel;
            dateTimePickerLast.Visible = !panel;
            textBoxDateInitial.Visible = !panel;
            textBoxDateLast.Visible = !panel;
            labelOf.Visible = !panel;
            labelA.Visible = !panel;
            //panelDateToDate.Visible = !panel; 339, 10
        }

        #endregion

        private void buttonClear_Click(object sender, EventArgs e)
        {
            buttonSerch.Enabled = true;
            dataBinnacle.DataSource = selectSQL.ShowDataBinnacle();
            buttonClear.Visible = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
