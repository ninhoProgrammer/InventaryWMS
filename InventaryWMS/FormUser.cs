using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventaryWMS
{
    public partial class FormUser : Form
    {
        #region Variabls and triggers
        //Sentencias SQL
        Main mainForm;
        SelectSQL selectSQL = new SelectSQL();
        InsertSQL insertSQL = new InsertSQL();
        UpdateSQL updateSQL = new UpdateSQL();
        DeleteSQL deleteSQL = new DeleteSQL();
        Users users = new Users();

        //Variables
        private string _username { get; set; }
        private bool _updateForm { get; set; }

        private bool _save { get; set; }
        private bool _new { get; set; }

        public FormUser()
        {
            InitializeComponent();
            inicialize();


        }

        public FormUser(Main main)
        {
            this.mainForm = main;
            InitializeComponent();
            inicialize();
            permission();
        }

        private void permission()
        {
            if (mainForm.permission.Rows[0]["USERS_CREATE"].ToString() == "False")
            {
                buttonNew.Visible = false;
            }

        }
        private void inicialize()
        {
            comboBoxUsername.Items.Clear();
            comboBoxPermissions.Items.Clear();
            selectSQL.PermissionsAComboBox(comboBoxPermissions);
            selectSQL.UserAComboBox(comboBoxUsername);
            VisibleForm(false);
            pictureBoxEdit.Visible = false;
        }

        public void Modify(bool update, int user)
        {
            this.Text = "Modifica Usuario";
            comboBoxUsername.Items.Clear();
            selectSQL.UserAComboBox(comboBoxUsername);
            _updateForm = update;
        }

        public void Delete(int user)
        {
            this.Text = "Elimina Cliente";
            buttonSave.Visible = false;

            selectSQL.UserAComboBox(comboBoxUsername);
            EnabledTextbox();
        }

        #endregion

        #region KeyPress and Changed
        private void textBoxUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;//elimina el sonido
                textBoxName.Focus();//cambia al siguiente elemento
            }
        }

        private void comboBoxUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;//elimina el sonido
                textBoxName.Focus();//cambia al siguiente elemento
            }
        }

        private void textBoxName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;//elimina el sonido
                textBoxLastName.Focus();//cambia al siguiente elemento
            }
        }

        private void textBoxLastName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;//elimina el sonido
                textBoxEmail.Focus();//cambia al siguiente elemento
            }
        }

        private void textBoxEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;//elimina el sonido
                textBoxPassword.Focus();//cambia al siguiente elemento
            }
        }

        private void textBoxPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;//elimina el sonido
                textBoxValidatePassword.Focus();//cambia al siguiente elemento
            }
        }

        private void textBoxValidatePassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;//elimina el sonido
                comboBoxPermissions.Focus();//cambia al siguiente elemento
            }
        }

        private void comboBoxPermissions_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;//elimina el sonido
                buttonSave.Focus();//cambia al siguiente elemento
            }
        }

        private void comboBoxUsername_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxUsername.Text != "")
            {
                if (mainForm.permission.Rows[0]["USERS_EDIT"].ToString() == "True")
                {
                    pictureBoxEdit.Visible = true;
                }
                users = selectSQL.FillDateUser(comboBoxUsername.SelectedItem.ToString());
            }
            else
            {
                pictureBoxEdit.Visible = false;
            }

            users = selectSQL.FillDateUser(comboBoxUsername.SelectedItem.ToString());
            try
            {
                fullUsers(users);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Error : " + ex.Message);
            }
        }

        #endregion

        #region Click
        private void buttonSave_Click(object sender, EventArgs e)
        {
            spinner.Visible = true;
            buttonSave.Enabled = false;
            try
            {
                fillUsers();
                if (_new)
                    InsertSentency();

                else if (_save)
                    UpdateSentency();
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

        private void buttonNew_Click(object sender, EventArgs e)
        {
            _new = true;
            VisibleForm(_new);
            fullUsers(new Users());
            textBoxUsername.Focus();
        }

        private void pictureBoxEdit_Click(object sender, EventArgs e)
        {
            VisibleForm(true);
            textBoxUsername.Focus();
            _save = true;
        }

        private void pictureBoxCancel_Click(object sender, EventArgs e)
        {
            VisibleForm(false);
            _save = false;
            _new = false;
            if (comboBoxUsername.SelectedIndex != 1)
            {
                int l = comboBoxUsername.SelectedIndex;
                comboBoxUsername.SelectedIndex = 0;
                comboBoxUsername.SelectedIndex = l;
                comboBoxUsername.Focus();
            }
        }

        private void FormUser_Click(object sender, EventArgs e)
        {
            BringToFront();
        }

        #endregion

        #region Functions
        private void EnabledTextbox()
        {
            textBoxName.Enabled = false;
            textBoxLastName.Enabled = false;
            textBoxEmail.Enabled = false;
            textBoxPassword.Enabled = false;
            textBoxValidatePassword.Enabled = false;
            comboBoxPermissions.Enabled = false;
        }

        private void fillUsers()
        {
            users.USERNAME = textBoxUsername.Text;
            users.NAME = textBoxName.Text;
            users.LASTNAME = textBoxLastName.Text;
            users.PASSWORD = textBoxPassword.Text;
            users.EMAIL = textBoxEmail.Text;
            users.PERMISSIONS = selectSQL.GetIdPermissions(comboBoxPermissions.Text);
        }

        private void fullUsers(Users us)
        {
            textBoxUsername.Text = us.USERNAME;
            textBoxName.Text = us.NAME;
            textBoxLastName.Text = us.LASTNAME;
            textBoxPassword.Text = us.PASSWORD;
            textBoxValidatePassword.Text = us.PASSWORD;
            textBoxEmail.Text = us.EMAIL;
            comboBoxPermissions.SelectedItem = selectSQL.TakePermissions(us.PERMISSIONS);
        }

        private void InsertSentency()
        {
            Task.Run(() =>
            {

                this.Invoke((Action)(() =>
                {

                    if (insertSQL.saveToUser(users))
                    {
                        insertSQL.SaveToBinnacle("Usuario dado de alta: " + comboBoxUsername.Text);
                        MessageBox.Show("Usuario dado de alta con exito");
                        fetchUsers();
                    }
                    else
                    {
                        spinner.Visible = false;
                        buttonSave.Enabled = true;
                    }
                }));
            });

        }


        private void fetchUsers()
        {
            comboBoxUsername.Items.Clear();
            selectSQL.UserAComboBox(comboBoxUsername);

            spinner.Visible = false;
            buttonSave.Enabled = true;
            VisibleForm(false);
        }

        private void UpdateSentency()
        {
            Task.Run(() =>
            {

                this.Invoke((Action)(() =>
                {

                    if (updateSQL.UpdateUser(users))
                    {
                        insertSQL.SaveToBinnacle("Usuario: " + comboBoxUsername.Text + ", modificado con exito");
                        MessageBox.Show("Usuario modificado con exito");
                        fetchUsers();
                    }
                    else
                    {
                        spinner.Visible = false;
                        buttonSave.Enabled = true;
                    }
                }));
            });


        }

        private void VisibleForm(bool panel)
        {
            if (panel == false)
                comboBoxUsername.Text = users.NAME;

            comboBoxUsername.Enabled = !panel;
            textBoxUsername.Enabled = panel;
            textBoxName.Enabled = panel;
            textBoxLastName.Enabled = panel;
            textBoxEmail.Enabled = panel;
            textBoxPassword.Enabled = panel;
            panelValid.Enabled = panel;
            textBoxValidatePassword.Enabled = panel;
            comboBoxPermissions.Enabled = panel;
            buttonSave.Visible = panel;
            buttonNew.Visible = !panel;
            pictureBoxEdit.Visible = !panel;
            pictureBoxCancel.Visible = panel;
        }

        private bool ValidateNotNull()
        {
            bool nullC = true;
            string chain = "Campo no puede ser null:";
            foreach (Control control in Controls)
            {
                string[] split = control.Name.Split(':');

                switch (control)
                {
                    case TextBox textBox when string.IsNullOrWhiteSpace(textBox.Text):
                        if (split[0] != "textBoxUsername")
                        {
                            chain += " -" + control.AccessibleName;
                            nullC = false;
                        }
                        break;

                    case ComboBox comboBox when comboBox.SelectedIndex == -1:
                        if (split[0] != "comboBoxUsername")
                        {
                            chain += " -" + control.AccessibleName;
                            nullC = false;
                        }
                        break;

                    // Puedes agregar más casos para otros tipos de controles si es necesario.
                    // ...

                    default:
                        // Si el tipo de control no coincide con ninguno de los casos anteriores,
                        // no se realiza ninguna acción específica.
                        break;
                }


                if (control is GroupBox groupBox)
                {


                    foreach (Control controlGroupBox in groupBox.Controls)
                    {

                    }
                }
            }
            if (!nullC)
                MessageBox.Show(chain);

            return nullC;
        }


        #endregion

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBoxUsername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
