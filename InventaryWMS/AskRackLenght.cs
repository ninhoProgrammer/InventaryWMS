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
    public partial class AskRackLenght : Form
    {
        private List<string> rackNamesList = new List<string>();
        private List<int> rackLenghtList = new List<int>();
        private List<int> startIndexList = new List<int>();

        public AskRackLenght(List<string> rackNames)
        {
            InitializeComponent();
            this.rackNamesList = rackNames;
        }

        private void loadRackNamesList()
        {
            dgridNamesList.Rows.Clear();
            dgridNamesList.AllowUserToAddRows = false;
            dgridNamesList.SelectionMode = DataGridViewSelectionMode.CellSelect;
            foreach (string rackName in rackNamesList)
            {
                dgridNamesList.Rows.Add(rackName, "", "1");
            }
            dgridNamesList.ClearSelection();
        }

        public List<int> getLenghtList()
        {
            return rackLenghtList;
        }

        public List<int> getIndexList()
        {
            return startIndexList;
        }

        public List<string> getNamesList()
        {
            return rackNamesList;
        }

        private void actionButton1_ButtonClick(object sender, EventArgs e)
        {
            helpPanel.Visible = true;
        }

        private void AskRackLenght_Load(object sender, EventArgs e)
        {
            loadRackNamesList();
        }        

        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (validateStartNumber())
                {
                    rackNamesList.Clear();
                    foreach (DataGridViewRow row in dgridNamesList.Rows)
                    {
                        rackNamesList.Add(row.Cells[0].Value.ToString());
                        rackLenghtList.Add(int.Parse(row.Cells[1].Value.ToString()));
                        startIndexList.Add(int.Parse(row.Cells[2].Value.ToString()));
                    }
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Las celdas marcadas deben iniciar en un valor menor. La suma del número de inicio más la longitud no debe ser mayor a 99 ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }               
            }
            catch 
            {
                MessageBox.Show("Revise que los datos estén completos", "Error",MessageBoxButtons.OK);
            }            
        }

        private void dgridNamesList_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {                       
            if (dgridNamesList.CurrentCell.ColumnIndex > 0 && e.FormattedValue.ToString().Length > 0)
            {
                e.Cancel = false;
                int newInteger;
                // Comprueba si el valor es un número entero y si está entre 1 y 99
                if (!int.TryParse(e.FormattedValue.ToString(), out newInteger) || newInteger < 1 || newInteger > 99)
                {
                    e.Cancel = true;
                    labelError.Text = "El valor ingresado no es válido";
                    labelError.Visible = true;
                }
                else
                {
                    labelError.Visible = false;
                }
            }
        }

        private bool validateStartNumber()
        {
            bool dataIsOk = true;
            //Evaluar indices 1, 2 -> (Longitud, Inicia en)
            foreach (DataGridViewRow row in dgridNamesList.Rows)
            {
                if (int.Parse(row.Cells[2].Value.ToString()) + int.Parse(row.Cells[1].Value.ToString()) > 99)
                {
                    dataIsOk = false;
                    var cell = row.Cells[2];
                    cell.Style.BackColor = Color.FromArgb(255, 134, 134);
                }
            }

            dgridNamesList.ClearSelection();

            return dataIsOk;
        }

        private void closeHelp_Click(object sender, EventArgs e)
        {
            helpPanel.Visible = false;
        }
    }
}
