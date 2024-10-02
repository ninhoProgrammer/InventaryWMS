using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventaryWMS
{
    public partial class FormValidate : Form
    {
        public int sts { get; set; }
        private bool valid { get; set; }
        public bool _Asentar { get; set; }
        private DataGridView _dataGrid { get; set; }
        List<string> strings { get; set; }

        private TaskCompletionSource<bool> tcs { get; set; }

        public delegate void enviar(string datos, string datos2);
        public event enviar enviado;

        public FormValidate(DataGridView dataGrid, string folio)
        {

            InitializeComponent();
            tcs = null;
            textBoxF.Text = folio;
            _dataGrid = dataGrid;
            FillDataGrid();
            button1.Enabled = false;
            valid = false;
            _Asentar = false;
            sts = 2;
            strings = new List<string>();
        }

        public void FillDataGrid()
        {

            dataProducts.AllowUserToAddRows = false;
            dataProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataProducts.RowHeadersVisible = false;
            dataProducts.AutoResizeColumns();
            dataProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataProducts.ClearSelection();
            dataGridViewVerific.AllowUserToAddRows = false;
            dataGridViewVerific.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewVerific.RowHeadersVisible = false;
            dataGridViewVerific.AutoResizeColumns();
            dataGridViewVerific.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewVerific.ClearSelection();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            sts = 1;
            valid = true;
            _Asentar = true;
            this.Close();
        }

        public Task ShowAsync()
        {
            this.Show();
            tcs = new TaskCompletionSource<bool>();
            return tcs.Task;
        }

        private void dataProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBoxCancel_Click(object sender, EventArgs e)
        {
            bool i = false;
            object value2 = textBoxNP.Text;
            foreach (DataGridViewRow row1 in _dataGrid.Rows)
            {
                // Iterar sobre las filas del segundo DataGridView.

                // Comparar las celdas de cada fila.
                if (!strings.Contains(textBoxNP.Text))
                {
                    // Obtener los valores de las celdas en las dos DataGridView.
                    object value1 = row1.Cells["SERIAL"].Value;



                    // Comparar los valores de las celdas.
                    if (object.Equals(value1, value2))
                    {
                        // Si los valores coinciden, resaltar la celda en verde en el primer DataGridView.

                        //
                        dataProducts.Rows.Add(value2);
                        enviado(value2.ToString(), "");
                        //row1.Cells[0].Style.BackColor = Color.Green;
                        strings.Add(value2.ToString());
                        textBox1.Text = dataProducts.Rows.Count.ToString();
                        if (dataProducts.Rows.Count == _dataGrid.Rows.Count)
                        {
                            MessageBox.Show("Validacion terminada");
                            button1.Enabled = true;
                            textBoxNP.Enabled = false;
                            sts = 1;
                            valid = true;
                            _Asentar = true;
                            this.Close();
                        }
                        i = true;
                    }
                }

            }
            if (!i)
            {
                dataGridViewVerific.Rows.Add(value2);
            }
            //MessageBox.Show("Validados: " + i);
        }

        private void textBoxNP_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxNP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;//elimina el sonido
                if (textBoxNP.Text != "")
                {
                    pictureBoxCancel_Click(sender, e);
                    textBoxNP.Text = "";
                }
            }
        }


        private void FormValidate_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_Asentar)
            {
                //enviado("", "");
                DialogResult resultValidate = MessageBox.Show("¿Quieres cancelar la validación?", "Alerta: Validacion en proceso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (resultValidate == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    valid = false;
                    sts = 2;
                }
            }
            else
            {
                tcs.SetResult(true);
            }
        }
    }
}
