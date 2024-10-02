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
    public partial class FormInvoice : Form
    {
        #region Variables and triggers
        SelectSQL selectSQL = new SelectSQL();
        InsertSQL insertSQL = new InsertSQL();
        UpdateSQL updateSQL = new UpdateSQL();
        DeleteSQL deleteSQL = new DeleteSQL();
        private bool _updateForm { get; set; }
        private bool _deleteForm { get; set; }
        private bool _CanAutorize { get; set; }
        private int _idClient { get; set; }
        private int _idUser { get; set; }
        public FormInvoice()
        {
            InitializeComponent();

            this.Text = "Añade Factura";
            buttonDelete.Visible = false;

        }

        public void Inicialize(int client)
        {
            _idClient = client;

        }

        public void Modify(bool update, int user, int client)
        {
            _updateForm = update;
            _idClient = client;
            _idUser = user;

            this.Text = "Modifiaca Factura";


        }

        public void Delete(int user, int client)
        {
            _idClient = client;
            _idUser = user;

            this.Text = "Elimina Factura";
            buttonDelete.Visible = true;
            buttonSave.Visible = false;
        }

        private void FormInvoice_Load(object sender, EventArgs e)
        {

        }
        #endregion

        private void FormInvoice_Click(object sender, EventArgs e)
        {
            BringToFront();
        }
    }
}
