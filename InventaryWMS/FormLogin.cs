using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventaryWMS
{
    public partial class FormLogin : Form
    {
        #region Variables and triggers
        SelectSQL selectSQL { get; set; }
        Security security = new Security();
        private int _idUser { get; set; }
        private int _Count { get; set; }
        private bool _selectTrue { get; set; }
        private int _xClick { get; set; }
        private int _yClick { get; set; }

        public FormLogin()
        {
            InitializeComponent();
            selectSQL = new SelectSQL();
            if (!selectSQL.CheckConections())
            {
                security.createFile("address.txt");
                security.createFile("user.txt");
                pictureBoxConfigurations.Visible = true;
            }
            spinner.Visible = false;
            _Count = 0;
            _selectTrue = false;
            buttonSelect.Enabled = _selectTrue;
            panelCompany.Visible = _selectTrue;

        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            _xClick = 0;
            _yClick = 0;
        }

        #endregion

        #region Click
        private void buttonLogIn_Click(object sender, EventArgs e)
        {
            spinner.Visible = true;
            ButtonLogIn.Enabled = false;
            try
            {
                Task.Run(() =>
                {
                    _idUser = selectSQL.CheckUser(textBoxUser.Text, textBoxPassword.Text);
                    this.Invoke((Action)(() =>
                    {
                        spinner.Visible = false;
                        if (_idUser == 0)
                        {
                            MessageBox.Show("Usuario no existe");
                            ButtonLogIn.Enabled = true;
                        }
                        else
                        {
                            fillCompany(_idUser);
                        }
                    }));
                });
            }
            catch
            {

            }
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

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            //Close();

            if (comboBoxClient.Text != null)
            {
                buttonSelect.Enabled = false;
                this.Visible = false;
                int client = selectSQL.GetIdOnCheckClients(comboBoxClient.SelectedItem.ToString());
                if (client != 0)
                {
                    security.writeFile("address.txt", client.ToString());
                    security.writeFile("user.txt", _idUser.ToString());
                    Main fm = new Main(_idUser, client);
                    fm.Show();
                }
                else
                {
                    buttonSelect.Enabled = true;
                }
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        #endregion

        #region KeyPress and Changed
        private void ButtonLogIn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;//elimina el sonido
                buttonLogIn_Click(sender, e);//llama al evento click del boton
            }
        }

        private void buttonSelect_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;//elimina el sonido
                buttonSelect_Click(sender, e);//llama al evento click del boton
            }

        }

        private void textBoxPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;//elimina el sonido e.Handled = true;//elimina el sonido
                ButtonLogIn.Focus();//cambia al siguiente elemento
            }
        }


        private void textBoxUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;//elimina el sonido
                textBoxPassword.Focus();//cambia al siguiente elemento
            }
        }

        private void comboBoxClient_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;//elimina el sonido
                buttonSelect.Focus();//cambia al siguiente elemento
            }

        }

        private void FormLogin_MouseMove(object sender, MouseEventArgs e)
        {
            //PARA PODER MOVER LA VENTANA CON EL MOUSE.
            if (e.Button != MouseButtons.Left)
            { _xClick = e.X; _yClick = e.Y; }
            else
            { Left = Left + (e.X - _xClick); Top = Top + (e.Y - _yClick); }
        }
        #endregion

        #region Funtions
        public void fillCompany(int id)
        {
            //timerLoadingClient.Stop();
            _idUser = id;
            //string giveListCompany = selectSQL.UserHasTheseClients(_idUser);
            /*if (giveListCompany == "Y         " || giveListCompany == "Y")
            {
                selectSQL.ClientsAComboBox(comboBoxClient);
            }
            else
            {
                selectSQL.ListCompaniesAComboBox(comboBoxClient, _idUser);
            }*/
            selectSQL.ClientsAComboBox(comboBoxClient);
            if (comboBoxClient.Items.Count > 0)
            {
                comboBoxClient.SelectedIndex = 0;
                panelUser.Visible = false;
                _selectTrue = true;
                buttonSelect.Enabled = _selectTrue;
                panelCompany.Visible = _selectTrue;
                comboBoxClient.Focus();
            }
            else
            {
                DialogResult result = MessageBox.Show("¿Quieres dar de alta uno?", "Alerta no se encuentraron clientes", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    FormClient form = new FormClient();
                    form.ShowDialog();
                    fillCompany(_idUser);
                }
            }
        }

        #endregion

        private void comboBoxClient_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxClient_MouseDown(object sender, MouseEventArgs e)
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

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            SystemConfiguration systemConfiguration = new SystemConfiguration(true, true);
            systemConfiguration.pictureBoxTurnON.Visible = false;
            systemConfiguration.labelWind.Visible = false;
            systemConfiguration.pictureBoxTurnOFF.Visible = false;
            systemConfiguration.ShowDialog();

        }
    }
}
