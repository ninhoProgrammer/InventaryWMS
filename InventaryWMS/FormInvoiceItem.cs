using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services.Description;
using System.Windows.Forms;

namespace InventaryWMS
{
    public partial class FormInvoiceItem : Form
    {
        SelectSQL selectSQL = new SelectSQL();
        UpdateSQL updateSQL = new UpdateSQL();
        Security security = new Security();
        InvoiceItem invoiceItem { get; set; }
        private string _Name { get; set; }
        private int _idClient { get; set; }
        private bool _valid { get; set; }
        public bool save { get; set; }
        private bool _new { get; set; }
        public FormInvoiceItem(string serial)
        {
            InitializeComponent();
            invoiceItem = selectSQL.getInvoiceIteam(serial);
            inicialize();
        }

        private void inicialize()
        {
            _idClient = int.Parse(security.createFile("address.txt"));
            _valid = true;
            save = false;
            _new = false;
            pictureBoxEdit.Visible = save;
            fullProviders();

        }

        private void fullProviders()
        {
            Prod prod = selectSQL.FillDateProducts(invoiceItem.IDPRODUCTS);
            textBoxCod.Text = prod.PART_NUMBER_CLIENT;
            textBoxSerial.Text = invoiceItem.SERIAL;
            textboxName.Text = prod.DESCRIPTION;
            textBoxDescription.Text = invoiceItem.DESCRIPTION;
            Valid(invoiceItem.VALID);
        }

        private void Valid(bool val)
        {
            _valid = val;
            pictureBoxValid.Visible = val;
            pictureBoxNotValid.Visible = !val;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (updateSQL.UpdateDescriptionInItems(textBoxDescription.Text, _valid, invoiceItem.IDINVOICE_ITEMS))
            {
                save = true;
                Close();
            }
            else
                MessageBox.Show(updateSQL.message);

        }

        private void textBoxDescription_Leave(object sender, EventArgs e)
        {
            textBoxDescription.SelectionLength = 0;
        }

        private void textBoxDescription_Click(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
            {
                //textBox.ForeColor = Color.Blue;
                textBox.SelectionStart = textBox.Text.Length;
                textBox.SelectionLength = 0;
                textBox.SelectAll();
            }
        }

        private void pictureBoxValid_Click(object sender, EventArgs e)
        {
            Valid(false);
        }

        private void pictureBoxNotValid_Click(object sender, EventArgs e)
        {
            Valid(true);
        }
    }
}
