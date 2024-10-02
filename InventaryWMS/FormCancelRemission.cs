using Microsoft.Reporting.WinForms;
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
    public partial class FormCancelRemission : Form
    {
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
        public FormCancelRemission()
        {
            InitializeComponent();
            inicialize();
        }

        private void inicialize()
        {
            _idClient = int.Parse(security.createFile("address.txt"));
            selectSQL.DestinatiosAComboBox(comboBoxName, _idClient);
            _valid = true;
            _save = false;
            _new = false;
            pictureBoxEdit.Visible = _save;
        }
    }
}
