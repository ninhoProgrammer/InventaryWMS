using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventaryWMS
{
    public partial class FormProducts : Form
    {
        #region Variables and triggers
        Main mainForm;
        SelectSQL selectSQL = new SelectSQL();
        InsertSQL insertSQL = new InsertSQL();
        UpdateSQL updateSQL = new UpdateSQL();
        DeleteSQL deleteSQL = new DeleteSQL();
        Security security = new Security();
        Prod prods = new Prod();
        private bool _valid { get; set; }
        private bool _new { get; set; }
        private bool _save { get; set; }
        List<string> eleme = new List<string>();
        private int _idClient { get; set; }
        //private int _idUser { get; set; }
        public FormProducts()
        {
            InitializeComponent();
            Inicialice();

        }

        public FormProducts(Main main)
        {
            this.mainForm = main;
            InitializeComponent();
            Inicialice();
            permission();
        }

        private void permission()
        {
            if (mainForm.permission.Rows[0]["PRODUCTS_CREATE"].ToString() == "False")
            {
                buttonNew.Visible = false;
            }

        }

        public FormProducts(string DESCRIPTION)
        {
            InitializeComponent();
            Inicialice();


            comboBoxDescription.Text = DESCRIPTION;
            comboBoxDescription.Enabled = false;
            this.Text = "Modificando: " + DESCRIPTION + " ";
        }



        public void Modify(bool update, int user, int client)
        {
            _valid = update;
            _idClient = client;

            selectSQL.ProductsInNumPartAComboBox(comboBoxDescription, _idClient);
            textBoxDescription.Visible = false;
            comboBoxDescription.Visible = true;
            this.Text = "Modifiaca Productos";


        }

        public void Inicialice()
        {
            _idClient = int.Parse(security.createFile("address.txt"));
            selectSQL.ProductsInNumPartAComboBox(comboBoxDescription, _idClient);
            //selectSQL.IdProductsAComboBox(comboBoxDescription, _idClient, eleme);
            selectSQL.MeasuringUnitAComboBox(comboBoxMeassurmentUnit);
            selectSQL.CurrenciesAComboBox(comboBoxCurrency);
            selectSQL.ContryAComboBox(comboBoxContry);
            comboBoxContry.SelectedIndex = 1;
            this.Text = "Productos";
            _valid = true;
            VisibleForm(false);
            pictureBoxEdit.Visible = false;
        }

        public void Delete(int user, int client)
        {
            _idClient = client;

            selectSQL.ProductsInNumPartAComboBox(comboBoxDescription, _idClient);
            textBoxDescription.Visible = false;
            comboBoxDescription.Visible = true;
            this.Text = "Elimina Productos";
            buttonSave.Visible = false;
        }

        private void FormProducts_Load(object sender, EventArgs e)
        {

        }

        #endregion

        #region Funtions 
        private bool ValidateNoNull()
        {
            bool nullC = true;
            string chain = "Campo no puede ser null:";
            
            foreach (Control control in Controls)
            {
                if (control.Name == "panelPropiedades")
                    if (control is Panel tabControl)
                    {
                        foreach (Control controlTabControl in tabControl.Controls)
                        {
                            if (controlTabControl is TextBox textBox)
                            {

                                if (textBox.AccessibleName == "Nombre" && textBox.Text == "")
                                {
                                    chain += " -" + controlTabControl.Name;
                                    nullC = false;
                                }
                                if (textBox.AccessibleName == "N.P." && textBox.Text == "")
                                {
                                    chain += " -" + controlTabControl.Name;
                                    nullC = false;
                                }

                            }
                                
                        }
                    }

                

                
            }
            if (!nullC)
                MessageBox.Show(chain);

            return nullC;
        }

        public void InsertSentency()
        {

            Task.Run(() =>
            {

                this.Invoke((Action)(() =>
                {

                    if (insertSQL.saveToProducts(prods))
                    {
                        insertSQL.SaveToBinnacle("Producto dado de alta: " + textBoxDescription.Text);
                        string nameAux = textBoxDescription.Text;
                        MessageBox.Show("Producto dado de alta con exito");
                        _new = false;
                        fetchProducts();
                        comboBoxDescription.Text = nameAux;


                    }
                    else
                    {
                        spinner.Visible = false;
                        buttonSave.Enabled = true;
                    }
                }));
            });

        }

        private void UpdateSentency()
        {

            Task.Run(() =>
            {

                this.Invoke((Action)(() =>
                {

                    if (updateSQL.UpdateProducts(prods))
                    {
                        insertSQL.SaveToBinnacle("Producto: " + textBoxDescription.Text + ", modificado con exito");
                        string nameAux = textBoxDescription.Text;
                        MessageBox.Show("Producto modificado con exito");
                        _save = false;
                        fetchProducts();
                        comboBoxDescription.Text = nameAux;
                    }
                    else
                    {
                        spinner.Visible = false;
                        buttonSave.Enabled = true;
                    }
                }));
            });
        }


        private void fillProducts()
        {
            prods = new Prod
            {
                IDPRODUCTS = selectSQL.TakeIdProducts(comboBoxDescription.Text),
                IDCLIENT = _idClient,
                DESCRIPTION = textBoxDescription.Text,
                PART_NUMBER_PROVIDER = textBoxNumberPartProvider.Text,
                PART_NUMBER_CLIENT = textBoxNumberPartClient.Text,
                REFERENCE = textBoxReferrence.Text,
                MEASSURMENT_UNIT = selectSQL.GetIdMeasuringUnit(comboBoxMeassurmentUnit.Text),
                WEIGHT = numericUpDownWeight.Text,
                UNIT_VALUE = numericUpDownUnitValue.Text,
                CURRENCY = selectSQL.GetIdCurrency(comboBoxCurrency.Text),
                TARIFF_FRACTION = numericUpDownTariffFraction.Text,
                ORIGIN_COUNTRY = comboBoxContry.SelectedIndex + 1,
                ITEMS_PER_BOX = numericUpDownItemForBox.Text,
                STANDARD_PACK_PALLET = numericUpDownStandarPack.Text,
                VALID = true,
            };
        }

        private void VisibleForm(bool panel)
        {
            if (panel == false)
                comboBoxDescription.Text = prods.PART_NUMBER_CLIENT;

            comboBoxDescription.Enabled = !panel;
            textBoxDescription.Enabled = panel;
            textBoxNumberPartProvider.Enabled = panel;
            textBoxNumberPartClient.Enabled = panel;
            textBoxReferrence.Enabled = panel;
            comboBoxMeassurmentUnit.Enabled = panel;
            numericUpDownWeight.Enabled = panel;
            numericUpDownUnitValue.Enabled = panel;
            comboBoxCurrency.Enabled = panel;
            numericUpDownTariffFraction.Enabled = panel;
            comboBoxContry.Enabled = panel;
            numericUpDownItemForBox.Enabled = panel;
            numericUpDownStandarPack.Enabled = panel;
            buttonSave.Visible = panel;
            pictureBoxEdit.Visible = !panel;
            pictureBoxCancel.Visible = panel;
            buttonNew.Visible = !panel;
        }

        private void fullProducts(Prod products)
        {
            textBoxDescription.Text = products.DESCRIPTION;
            textBoxNumberPartProvider.Text = products.PART_NUMBER_PROVIDER;
            textBoxNumberPartClient.Text = products.PART_NUMBER_CLIENT;
            textBoxReferrence.Text = products.REFERENCE;
            comboBoxMeassurmentUnit.SelectedItem = selectSQL.TakeUnit(products.MEASSURMENT_UNIT);
            numericUpDownWeight.Value = decimal.Parse(products.WEIGHT);
            numericUpDownUnitValue.Value = decimal.Parse(products.UNIT_VALUE);
            comboBoxCurrency.SelectedItem = selectSQL.TakeCurrency(products.CURRENCY);
            numericUpDownTariffFraction.Value = decimal.Parse(products.TARIFF_FRACTION);
            comboBoxContry.SelectedItem = selectSQL.TakeContry(products.ORIGIN_COUNTRY);
            numericUpDownItemForBox.Value = decimal.Parse(products.ITEMS_PER_BOX);
            numericUpDownStandarPack.Text = products.STANDARD_PACK_PALLET;

        }

        private void pictureBox(bool valid)
        {
            _valid = !valid;
            pictureBoxValid.Visible = !valid;
            pictureBoxNotValid.Visible = valid;

        }

        private void fetchProducts()
        {
            comboBoxDescription.Items.Clear();
            selectSQL.ProductsInNumPartAComboBox(comboBoxDescription, _idClient);
            
            //selectSQL.ProductsAComboBox(comboBoxDescription, _idClient);

            spinner.Visible = false;
            buttonSave.Enabled = true;
            VisibleForm(false);
        }


        #endregion

        #region click and change
        private void comboBoxDescription_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxDescription.Text != "")
            {
                
                if (mainForm.permission.Rows[0]["PRODUCTS_EDIT"].ToString() == "True")
                {
                    pictureBoxEdit.Visible = true;
                }
                prods = selectSQL.FillDateProducts(selectSQL.TakeIdProducts(comboBoxDescription.Text));
            }
            else
            {
                pictureBoxEdit.Visible = false;
            }

            try
            {
                fullProducts(prods);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Error : " + ex.Message);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            spinner.Visible = true;
            buttonSave.Enabled = false;
            try
            {
                if (ValidateNoNull())
                {
                    fillProducts();
                    if (_new)
                        InsertSentency();

                    else if (_save)
                        UpdateSentency();
                }
                else
                {
                    spinner.Visible = false;
                    buttonSave.Enabled = true;
                }   
                    
            }
            catch { }
        }

        private void control_Click(object sender, EventArgs e)
        {
            if (sender is TextBox textBox && !String.IsNullOrEmpty(textBox.Text))
            {
                textBox.SelectionStart = 0;
                textBox.SelectionLength = textBox.Text.Length;
            }
            else if (sender is ComboBox comboBox && comboBox.SelectedItem != null)
            {
                comboBox.SelectionStart = 0;
                comboBox.SelectionLength = comboBox.Text.Length;
            }
        }

        private void pictureBoxEdit_Click(object sender, EventArgs e)
        {
            VisibleForm(true);
            textBoxDescription.Focus();
            _save = true;
        }

        private void pictureBoxCancel_Click(object sender, EventArgs e)
        {
            VisibleForm(false);
            _save = false;
            _new = false;
            if (comboBoxDescription.SelectedIndex != -1)
            {
                int l = comboBoxDescription.SelectedIndex;
                comboBoxDescription.SelectedIndex = 0;
                comboBoxDescription.SelectedIndex = l;
                comboBoxDescription.Focus();
            }
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            _new = true;
            fullProducts(new Prod());
            textBoxDescription.Focus();
            VisibleForm(true);
        }

        private void pictureBoxValid_Click(object sender, EventArgs e)
        {
            pictureBox(true);
        }

        private void pictureBoxNotValid_Click(object sender, EventArgs e)
        {
            pictureBox(false);
        }

        private void FormProducts_Click(object sender, EventArgs e)
        {
            BringToFront();
        }

        #endregion

        #region KeyPress

        private void comboBoxDescription_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;//elimina el sonido
                textBoxNumberPartProvider.Focus();
            }
        }

        private void textBoxDescription_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;//elimina el sonido
                textBoxNumberPartProvider.Focus();
            }
        }

        private void textBoxNumberPartProvider_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;//elimina el sonido
                textBoxNumberPartClient.Focus();
            }
        }

        private void textBoxNumberPartClient_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;//elimina el sonido
                textBoxReferrence.Focus();
            }
        }




        private void textBoxReferrence_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;//elimina el sonido
                comboBoxContry.Focus();
            }
        }

        private void comboBoxMeassurmentUnit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;//elimina el sonido
                comboBoxCurrency.Focus();
            }
        }

        private void comboBoxContry_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;//elimina el sonido
                numericUpDownTariffFraction.Focus();
            }
        }

        private void comboBoxCurrency_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;//elimina el sonido
                buttonSave.Focus();
            }
        }




        private void buttonSave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;//elimina el sonido
                buttonSave_Click(sender, e);
            }
        }

        private void textBoxUnitValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;//elimina el sonido
                textBoxReferrence.Focus();
            }
        }

        private void numericUpDownTariffFraction_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;//elimina el sonido
                numericUpDownItemForBox.Focus();
            }
        }

        private void numericUpDownItemForBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;//elimina el sonido
                numericUpDownUnitValue.Focus();
            }
        }

        private void numericUpDownUnitValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;//elimina el sonido
                numericUpDownStandarPack.Focus();
            }
        }

        private void numericUpDownStandarPack_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;//elimina el sonido
                numericUpDownWeight.Focus();
            }
        }

        private void numericUpDownWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;//elimina el sonido
                comboBoxMeassurmentUnit.Focus();
            }
        }








        #endregion

        #region Changed


        #endregion

        private void comboBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (sender is ComboBox comboBox)
            {
                if (e.Button == MouseButtons.Left)
                {
                    int buttonWidth = SystemInformation.VerticalScrollBarWidth; // Ancho del botón de despliegue
                    int textBoxWidth = comboBox.Width - buttonWidth;

                    // Verifica si se hizo clic en el botón de despliegue
                    if (e.X > textBoxWidth)
                    {
                        //MessageBox.Show("Se hizo clic en la flecha hacia abajo.");
                    }
                    else
                    {
                        //MessageBox.Show("Se hizo clic en el área de texto.");
                        comboBox.Focus();
                    }
                }
            }
        }

        private void numericUpDownUnitValue_ValueChanged(object sender, EventArgs e)
        {

        }

        private void FormProducts_Activated(object sender, EventArgs e)
        {

        }

        private void FormProducts_Enter(object sender, EventArgs e)
        {

        }

        private void FormProducts_MouseClick(object sender, MouseEventArgs e)
        {
            int i = 0;
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
           /* if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                comboBoxDescription.Items.Clear();
                comboBoxDescription.Items.AddRange(eleme.ToArray());
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            // Manejar el evento KeyDown del TextBox
            if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
            {
                // Obtener el texto del TextBox
                string textoFiltrado = textBox1.Text.ToLower();

                // Limpiar los elementos actuales del ComboBox
                comboBoxDescription.Items.Clear();

                // Filtrar los elementos que contienen el texto ingresado y agregarlos al ComboBox
                foreach (string elemento in eleme
                    .Where(elem => elem.ToLower().Contains(textoFiltrado)))
                {
                    comboBoxDescription.Items.Add(elemento);
                }
                comboBoxDescription.DroppedDown = true;

            }
            else
            {
                // Obtener el texto del TextBox
                string textoFiltrado = textBox1.Text.ToLower();

                // Limpiar los elementos actuales del ComboBox
                comboBoxDescription.Items.Clear();

                // Filtrar los elementos que contienen el texto ingresado y agregarlos al ComboBox
                foreach (string elemento in eleme
                    .Where(elem => elem.ToLower().Contains(textoFiltrado)))
                {
                    comboBoxDescription.Items.Add(elemento);
                }

                comboBoxDescription.DroppedDown = true;
                comboBoxDescription.Text = "";
            }*/
        }
    }
}
