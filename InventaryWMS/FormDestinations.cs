using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventaryWMS
{
    public partial class FormDestinations : Form
    {
        #region Variabls and triggers
        Main mainForm { get; set; }
        SelectSQL selectSQL = new SelectSQL();
        InsertSQL insertSQL = new InsertSQL();
        UpdateSQL updateSQL = new UpdateSQL();
        DeleteSQL deleteSQL = new DeleteSQL();
        Security security = new Security();
        Destinations destinations = new Destinations();
        private string _Name { get; set; }
        private int _idClient { get; set; }
        private bool _valid { get; set; }
        private bool _save { get; set; }
        private bool _new { get; set; }

        public FormDestinations()
        {
            InitializeComponent();
            inicialize();
        }

        public FormDestinations(Main main)
        {
            this.mainForm = main;
            InitializeComponent();
            inicialize();
            permission();
        }

        private void permission()
        {
            if (mainForm.permission.Rows[0]["DESTINATIONS_CREATE"].ToString() == "False")
            {
                buttonSerch.Visible = false;
            }

        }
        private void FormDestinations_Load(object sender, EventArgs e)
        {


        }

        private void inicialize()
        {
            _idClient = int.Parse(security.createFile("address.txt"));
            selectSQL.DestinatiosAComboBox(comboBoxName, _idClient);
            selectSQL.ContryAComboBox(comboBoxContry);
            validDestinations(true);
            _valid = true;
            _save = false;
            _new = false;
            VisibleForm(_save);
            pictureBoxEdit.Visible = _save;
        }
        #endregion

        #region KeyPress and Changed
        private void comboBoxName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxName.Text != "")
                {
                    if (mainForm.permission.Rows[0]["DESTINATIONS_EDIT"].ToString() == "True")
                    {
                        pictureBoxEdit.Visible = true;
                    }
                    destinations = selectSQL.FillDateDestinations(comboBoxName.Text, _idClient);
                }
                else
                {
                    pictureBoxEdit.Visible = false;

                }

                fullDestinatios(destinations);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Error : " + ex.Message);
            }
        }

        #endregion

        #region Click

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
        private void buttonNew_Click(object sender, EventArgs e)
        {
            _new = true;
            VisibleForm(_new);
            fullDestinatios(new Destinations());
            textboxDestination.Focus();

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            spinner.Visible = true;
            buttonSave.Enabled = false;
            try
            {
                if (ValidateNoNull())
                {
                    fillDestinatios();
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

        public void InsertSentency()
        {

            Task.Run(() =>
            {

                this.Invoke((Action)(() =>
                {
                    spinner.Visible = false;
                    if (insertSQL.saveToDestinary(destinations))
                    {
                        insertSQL.SaveToBinnacle("Destino dado de alta: " + textBoxDescription.Text);
                        string nameAux = textBoxDescription.Text;
                        MessageBox.Show("Destino dado de alta con exito");
                        _new = false;
                        fetchDestinations();
                        comboBoxName.Name = nameAux;
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
                    spinner.Visible = false;
                    if (updateSQL.UpdateDestinations(destinations))
                    {
                        insertSQL.SaveToBinnacle("Destino: " + textBoxDescription.Text + ", modificado con exito");
                        string nameAux = textBoxDescription.Text;
                        MessageBox.Show("Destino modificado con exito");
                        _save = false;
                        fetchDestinations();
                        comboBoxName.Name = nameAux;
                    }
                    else
                    {
                        spinner.Visible = false;
                        buttonSave.Enabled = true;
                    }
                }));
            });


        }

        private void pictureBoxCancel_Click(object sender, EventArgs e)
        {
            _save = false;
            _new = false;
            //comboBoxName_SelectedIndexChanged(sender, e);
            VisibleForm(false);
            if (comboBoxName.SelectedIndex != -1)
            {
                int l = comboBoxName.SelectedIndex;
                comboBoxName.SelectedIndex = 0;
                comboBoxName.SelectedIndex = l;
                comboBoxName.Focus();
            }

        }

        private void pictureBoxEdit_Click(object sender, EventArgs e)
        {
            _save = true;
            VisibleForm(_save);
            textboxDestination.Focus();
        }

        private void pictureBoxValid_Click(object sender, EventArgs e)
        {
            validDestinations(false);
        }

        private void pictureBoxNotValid_Click(object sender, EventArgs e)
        {
            validDestinations(true);
        }

        private void textBox_Click(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (textBox != null && !String.IsNullOrEmpty(textBox.Text))
            {
                textBox.SelectionStart = 0;
                textBox.SelectionLength = textBox.Text.Length;
            }
        }

        #endregion

        #region Functions
        private void VisibleForm(bool panel)
        {
            if (panel == false)
                comboBoxName.Text = destinations.NAME;

            textBoxDescription.Enabled = panel;
            textboxDestination.Enabled = panel;
            textBoxImmex.Enabled = panel;
            textBoxRFC.Enabled = panel;
            textBoxState.Enabled = panel;
            textBoxCity.Enabled = panel;
            textBoxDistrict.Enabled = panel;
            textBoxStreet.Enabled = panel;
            textBoxZipCode.Enabled = panel;
            comboBoxContry.Enabled = panel;
            pictureBoxCancel.Visible = panel;
            buttonSave.Visible = panel;
            pictureBoxEdit.Visible = !panel;
            buttonSerch.Visible = !panel;
            comboBoxName.Enabled = !panel;

        }

        private void fillDestinatios()
        {
            destinations.IDCLIENTE = _idClient;
            destinations.NAME = textboxDestination.Text;
            destinations.DESCRIPTION = textBoxDescription.Text;
            destinations.COUNTRY = selectSQL.GetContry(comboBoxContry.Text);
            destinations.STATE = textBoxState.Text;
            destinations.CITY = textBoxCity.Text;
            destinations.DISTRICT = textBoxDistrict.Text;
            destinations.STREET = textBoxStreet.Text;
            destinations.ZIPCODE = textBoxZipCode.Text;
            destinations.IMMEX = textBoxImmex.Text;
            destinations.RFC = textBoxRFC.Text;
            destinations.VALID = _valid;
        }

        private void fullDestinatios(Destinations Destination)
        {
            textboxDestination.Text = Destination.NAME;
            textBoxDescription.Text = Destination.DESCRIPTION;
            comboBoxContry.SelectedItem = selectSQL.TakeContry(Destination.COUNTRY);
            textBoxState.Text = Destination.STATE;
            textBoxCity.Text = Destination.CITY;
            textBoxDistrict.Text = Destination.DISTRICT;
            textBoxStreet.Text = Destination.STREET;
            textBoxZipCode.Text = Destination.ZIPCODE;
            textBoxImmex.Text = Destination.IMMEX;
            textBoxRFC.Text = Destination.RFC;

        }

        private void fetchDestinations()
        {
            comboBoxName.Items.Clear();
            selectSQL.DestinatiosAComboBox(comboBoxName, _idClient);
            spinner.Visible = false;
            buttonSave.Enabled = true;
            VisibleForm(false);

        }

        private void validDestinations(bool valid)
        {
            pictureBoxValid.Visible = valid;
            pictureBoxNotValid.Visible = !valid;
            _valid = valid;
        }

        private bool ValidateNoNull()
        {
            bool nullC = true;
            string chain = "Campo no puede ser null:";

            foreach (Control control in Controls)
            {
                if (control.Name == "panelPropiedades")
                {
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


                            }

                        }
                    }
                }

            }
            if (!nullC)

                if (!nullC)
                    MessageBox.Show(chain);

            return nullC;
        }

        private void comboBoxContry_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
    #endregion
}
