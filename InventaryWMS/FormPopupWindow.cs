using System;
using System.Windows.Forms;

namespace InventaryWMS
{
    public partial class FormPopupWindow : Form
    {
        public FormPopupWindow()
        {
            InitializeComponent();
            this.ControlBox = false;    // Oculta el cuadro de control (cerrar, maximizar, minimizar)
            this.MaximizeBox = false;   // Deshabilita el botón de maximizar
            this.MinimizeBox = false;   // Deshabilita el botón de minimizar
            //.CloseButton = false;   // Oculta el botón de cerrar
        }

        private void buttoncompressed_Click(object sender, EventArgs e)
        {
            // Establecer el resultado del cuadro de diálogo como OK
            this.DialogResult = DialogResult.OK;

            // Cerrar el formulario emergente
            this.Close();
        }

        private void buttondown_Click(object sender, EventArgs e)
        {
            // Establecer el resultado del cuadro de diálogo como Cancel
            this.DialogResult = DialogResult.Cancel;

            // Cerrar el formulario emergente
            this.Close();
        }

        private void FormPopupWindow_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
