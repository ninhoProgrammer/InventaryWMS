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
    public partial class FormEmails : Form
    {
        //Sentencias SQL
        SelectSQL selectSQL = new SelectSQL();
        InsertSQL insertSQL = new InsertSQL();
        UpdateSQL updateSQL = new UpdateSQL();
        DeleteSQL deleteSQL = new DeleteSQL();

        private bool _updateForm { get; set; }
        private int _idUser { get; set; }
        private string _typeEmail { get; set; }
        private string _AddressModify { get; set; }

        public FormEmails()
        {
            InitializeComponent();
            comboBoxAddress.Items.Clear();
            comboBoxClient.Items.Clear();
            selectSQL.ClientsAComboBox(comboBoxClient);
            this.Text = "Añade Correo";
            buttonSave.Visible = false;
            showNameCompany(false);
        }

        public void Modify(bool update, int user)
        {
            this.Text = "Modifica Correo";
            _updateForm = update;
            _idUser = user;
            showNameCompany(update);

        }

        public void Delete(int user)
        {
            this.Text = "Elimina Correo";
            buttonSave.Visible = true;
            buttonSave.Visible = false;
            showNameCompany(true);
        }

        public void showNameCompany(bool isCompany)
        {
            comboBoxAddress.Visible = isCompany;
            textBoxAddress.Visible = !isCompany;
        }


        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (ValidateNotNull())
            {
                if (!_updateForm)
                    InsertSentency();
                else
                    UpdateSentency();
            }
        }



        public void InsertSentency()
        {
            string sentency = "INSERT INTO[dbo].[CLIENT_EMAILS] ([IDCLIENT], [ADDRESS], [INVOICE], [INVENTORY], [REMISSION], [CREATE_AT], [UPDATED_AT], [IDSESSION], [VALID]) VALUES('" + selectSQL.GetIdClientName(comboBoxClient.Text) + "', '" + textBoxAddress.Text + "', " + _typeEmail + ", '" + DateTime.Now.ToString("yyyyMMdd") + "', '" + DateTime.Now.ToString("yyyyMMdd") + "', '0', 0)";

            if (insertSQL.insertSentency(sentency))
            {
                insertSQL.SaveToBinnacle("Correo dado de alta: " + textBoxAddress.Text);
                MessageBox.Show("Correo dado de alta con exito");
                Close();
            }
        }

        private void UpdateSentency()
        {
            System.Console.WriteLine(_AddressModify);
            string sentency = "UPDATE [dbo].[CLIENT_EMAILS] SET [IDCLIENT] = '" + selectSQL.GetIdClientName(comboBoxClient.Text) + "', [ADDRESS] = '" + comboBoxAddress.Text + "', " + _typeEmail + " ,  [updated_at] = '" + DateTime.Now.ToString("yyyyMMdd") + "' WHERE [IDCLIENT_EMAILS] =" + selectSQL.GetClientEmail(_AddressModify) + "";

            if (updateSQL.UpdateSentency(sentency))
            {
                insertSQL.SaveToBinnacle("Cliente: " + comboBoxClient.Text + ", modificado con exito");
                MessageBox.Show("Cliente modificado on exito");
                Close();
            }

        }

        private void FormEmails_Load(object sender, EventArgs e)
        {


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
                        if (split[0] != "textBoxAddress")
                        {
                            chain += " -" + control.AccessibleName;
                            nullC = false;
                        }
                        break;

                    case ComboBox comboBox when comboBox.SelectedIndex == -1:
                        if (split[0] != "comboBoxAddress")
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

        private void comboBoxClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxAddress.Items.Clear();
            selectSQL.EmailAComboBox(comboBoxAddress, selectSQL.GetIdClientName(comboBoxClient.Text).ToString());
        }

        private void comboBoxTypeEmail_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxTypeEmail.SelectedIndex)
            {
                case 0:
                    assignsBool(true, false, false);
                    break;
                case 1:
                    assignsBool(false, false, true);
                    break;
                case 2:
                    assignsBool(false, true, false);
                    break;
            }
        }

        private void comboBoxAddress_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] strings = selectSQL.FillDateEmail(comboBoxAddress.SelectedItem.ToString(), selectSQL.GetIdClientName(comboBoxClient.Text));
            _AddressModify = comboBoxAddress.Text;

            try
            {
                for (int i = 0; i < strings.Count(); i++)
                {
                    if (strings[i] == "True")
                    {
                        comboBoxTypeEmail.SelectedIndex = i;
                    }
                }

            }
            catch
            { }
        }
        public void assignsBool(bool INVOICE, bool INVENTORY, bool REMISSION)
        {
            if (_updateForm)

                _typeEmail = "[INVOICE] = '" + INVOICE + "' ,[INVENTORY] = '" + INVENTORY + "', [REMISSION] = '" + REMISSION + "'";

            else
                _typeEmail = "'" + INVOICE + "', '" + INVENTORY + "', '" + REMISSION + "'";
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro de eliminar el Usuario?", "Alerta se eliminara usuario", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                if (deleteSQL.DeleteEmailsClients(selectSQL.GetClientEmail(comboBoxAddress.Text), comboBoxAddress.Text))
                    Close();
            }
        }

        private void FormEmails_Click(object sender, EventArgs e)
        {
            BringToFront();
        }
    }
}
