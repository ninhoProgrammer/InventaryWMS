using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace InventaryWMS
{
    public partial class FormInventory : Form
    {
        DataTable midatatable = new DataTable();
        SelectSQL selectsql = new SelectSQL();
        Security security = new Security();
        private int _selectedopcionserch { get; set; }
        private int _iduser { get; set; }
        private int _idclient { get; set; }
        private int _idwarehouse { get; set; }
        private string _namewarehouse { get; set; }
        private bool _typeSerch { get; set; }
        public FormInventory()
        {
            InitializeComponent();
            
        }

        public void Inicialize(int iduser, int idclient)
        {
            _iduser = iduser;
            _idclient = idclient;
            _typeSerch = false;
            loadTable();
            customSerch(true);
            _selectedopcionserch = -1;
            selectsql.WarehouseAComboBox(comboBoxOpcionlocation);
            _idwarehouse = selectsql.GetIdWarehouse(this._iduser);
            _namewarehouse = selectsql.GetnameWarehouses(_idwarehouse);
            for (int i = 0; i < comboBoxOpcionlocation.Items.Count; i++)
            {
                if (comboBoxOpcionlocation.Items[i].ToString() == _namewarehouse)
                {
                    comboBoxOpcionlocation.SelectedIndex = i;
                }
            }
            
        }
       
        private void loadTable()
        {
            if (midatatable.Rows != null)
            {
                midatatable.Rows.Clear();
            }
            midatatable = selectsql.getdatatableInventary(-1, "", _idclient, _typeSerch);
            dataGridViewInventary.DataSource = midatatable;
            dataGridViewInventary.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void comboBoxOpcionserch_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxFolio.Items.Clear();
            _selectedopcionserch = comboBoxOpcionserch.SelectedIndex;
            selectsql.SerchAComboBox(comboBoxFolio, _selectedopcionserch, _idclient);
        }

        private void buttonsearch_Click(object sender, EventArgs e)
        {
            if (comboBoxOpcionserch.SelectedIndex != -1)
            {
                if (comboBoxFolio.SelectedIndex != -1)
                {
                    midatatable.Rows.Clear();
                    midatatable = selectsql.getdatatableInventary(_selectedopcionserch, comboBoxFolio.Text, _idclient, _typeSerch);
                    dataGridViewInventary.DataSource = midatatable;
                    buttonClear.Visible = true;
                }
                else
                {
                    MessageBox.Show("Seleccione una parametro de busqueda");
                    comboBoxFolio.Focus();
                }
            }
            else
            {
                loadTable();
            }

            /*if (selectedopcionserch == 0)
            {
                midatatable.Rows.Clear();
                midatatable = selectsql.getdatatableInventary(0, textBoxdata.Text, idclient);
                dataGridViewInventary.DataSource = midatatable;
                sizeWindow();
            }
            else
            {
                if (selectedopcionserch == 1)
                {
                    midatatable.Rows.Clear();
                    midatatable = selectsql.getdatatableInventary(1, textBoxdata.Text, idclient);
                    dataGridViewInventary.DataSource = midatatable;
                    sizeWindow();
                }
                else
                {
                    if (selectedopcionserch == 2)
                    {
                        midatatable.Rows.Clear();
                        midatatable = selectsql.getdatatableInventary(2, textBoxdata.Text, idclient);
                        dataGridViewInventary.DataSource = midatatable;
                        sizeWindow();
                    }
                    else
                    {
                        if (selectedopcionserch == 3)
                        {
                            midatatable.Rows.Clear();
                            midatatable = selectsql.getdatatableInventary(3, textBoxdata.Text, idclient);
                            dataGridViewInventary.DataSource = midatatable;
                            sizeWindow();
                        }
                        else
                        {
                            if (selectedopcionserch == 4)
                            {
                                midatatable.Rows.Clear();
                                midatatable = selectsql.getdatatableInventary(4, textBoxdata.Text, idclient);
                                dataGridViewInventary.DataSource = midatatable;
                                sizeWindow();
                            }
                        }
                    }
                }
            }*/
        }

        private void FormInventory_MaximumSizeChanged(object sender, EventArgs e)
        {

        }
       
        private void FormInventory_Resize(object sender, EventArgs e)
        {
            //tableLayoutPanel1.Size = new Size(ClientSize.Height/2,ClientSize.Width);
        }

        private void FormInventory_Load(object sender, EventArgs e)
        {

        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {

        }

        private void pictureBoxEneble_Click(object sender, EventArgs e)
        {
            customSerch(false);
        }

        private void pictureBoxNotEneble_Click(object sender, EventArgs e)
        {
            customSerch(true);
        }

        private void customSerch(bool type)
        {
            _typeSerch = type;
            pictureBoxEneble.Visible = type;
            pictureBoxNotEneble.Enabled = 
                !type;
            comboBoxOpcionserch.Items.Clear();
            //comboBox1.Items.Add("Select an option");
            comboBoxOpcionserch.Items.Add("Serial");
            comboBoxOpcionserch.Items.Add("Factura");
            comboBoxOpcionserch.Items.Add("Lote");
            comboBoxOpcionserch.Items.Add("Numero de parte");
            comboBoxOpcionserch.Items.Add("Descripción");
            if (type)
            {
                labelSerch.Text = "Inventario";
            }
            else
            {
                labelSerch.Text = "Asignado";
                comboBoxOpcionserch.Items.Add("Recibio");
                comboBoxOpcionserch.Items.Add("Responsable");
            }
            comboBoxOpcionserch.SelectedIndex = -1;
            
            loadTable();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridViewInventary_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridViewInventary_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // vamos a meter el nombre y numero de parte aqui no se van a modificar y comentarios para ingresar este producto tiene algun defecto 
            FormInvoiceItem formInvoiceItem = new FormInvoiceItem(dataGridViewInventary.Rows[e.RowIndex].Cells[2].Value.ToString());
            formInvoiceItem.ShowDialog();
            if(formInvoiceItem.save)
                buttonsearch_Click(sender, e);
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            midatatable.Rows.Clear();
            midatatable = selectsql.getdatatableInventary(-1, "", _idclient, _typeSerch); 
            dataGridViewInventary.DataSource = midatatable;

            comboBoxOpcionserch.SelectedIndex = -1;

            comboBoxFolio.SelectedIndex = -1;
            comboBoxFolio.Text = "";
            comboBoxFolio.Items.Clear();
            
            buttonClear.Visible = false;
        }
    }
}
