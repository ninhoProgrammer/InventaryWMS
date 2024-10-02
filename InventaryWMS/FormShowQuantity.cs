using System;
using System.Windows.Forms;

namespace InventaryWMS
{
    public partial class FormShowQuantity : Form
    {

        Security security = new Security();
        SelectSQL selectSQL = new SelectSQL();
        private int _idClient { get; set; }
        public string input { get; set; }
        public int quitity { get; set; }
        public string prefix { get; set; }

        public FormShowQuantity()
        {
            InitializeComponent();
            _idClient = int.Parse(security.createFile("address.txt"));
            selectSQL.RemissionLoadAComboBox(comboBoxRemission, _idClient);
            this.Text = "Salida";
            label1.Text = $" Factura: ";
        }

        public FormShowQuantity(bool input)
        {
            InitializeComponent();
            
            _idClient = int.Parse(security.createFile("address.txt"));
            selectSQL.InvoiceLoadAComboBox(comboBoxRemission, _idClient);
            this.Text = "Entrada";
            label1.Text = $" Remision: ";
        }

        private void textBoxQuantity_TextChanged(object sender, EventArgs e)
        {

        }

        static Tuple<string, string> SepararLetrasYNumeros(string cadena)
        {
            // Inicializar variables para letras y números
            string letras = "";
            string numeros = "";

            // Iterar a través de cada carácter en la cadena
            foreach (char caracter in cadena)
            {
                // Verificar si el carácter es una letra
                if (char.IsLetter(caracter))
                {
                    letras += caracter;
                }
                // Verificar si el carácter es un número
                else if (char.IsDigit(caracter))
                {
                    numeros += caracter;
                }
            }

            // Devolver el resultado como una tupla
            return Tuple.Create(letras, numeros);
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            Tuple<string, string> resultado = SepararLetrasYNumeros(comboBoxRemission.Text);
            // Verifica si ambos elementos de la tupla están vacíos
            if (!string.IsNullOrEmpty(resultado.Item1) && !string.IsNullOrEmpty(resultado.Item2))
            {
                // Si la tupla tiene contenido, continúa con el proceso
                quitity = int.Parse(resultado.Item2);
                prefix = comboBoxRemission.Text;
                
            }
            // Cierra el formulario
            Close();
        }

        private void textBoxQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;//elimina el sonido
                buttonAccept.Focus();
            }
        }

        private void textBoxQuantity_Click(object sender, EventArgs e)
        {
            if (sender is TextBox textBox && !String.IsNullOrEmpty(textBox.Text))
            {
                textBox.SelectionStart = 0;
                textBox.SelectionLength = textBox.Text.Length;
            }
        }

        private void comboBoxName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;//elimina el sonido
                buttonAccept.Focus();
            }
        }

        private void comboBoxName_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void comboBoxClient_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;//elimina el sonido
                buttonAccept.Focus();
            }
        }

        private void comboBoxName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
