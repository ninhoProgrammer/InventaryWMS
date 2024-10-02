using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventaryWMS
{
    internal class Security
    {
        static string addressClient = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\\..\\..\\address.txt"));
        private string _sesionPath { get; set; }

        public Security()
        {
            _sesionPath = takeSession();
        }

        public string CreateEncrypt(string textToEncrypt)
        {
            string result = string.Empty;
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(textToEncrypt);
            result = Convert.ToBase64String(encryted);
            return result;
        }

        /// Esta función desencripta la cadena que le envíamos en el parámentro de entrada.
        public string Decrypt(string textToDcrypt)
        {
            string result = string.Empty;
            byte[] decryted = Convert.FromBase64String(textToDcrypt);
            //result = System.Text.Encoding.Unicode.GetString(decryted, 0, decryted.ToArray().Length);
            result = System.Text.Encoding.Unicode.GetString(decryted);
            return result;
        }

        public string takeSession()
        {
            // Obtener la ruta de la carpeta de usuario actual
            string userFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

            // Agregar una nueva carpeta dentro de la carpeta de usuario actual
            string newFolder = Path.Combine(userFolderPath, "WMS");
            Directory.CreateDirectory(newFolder);

            //Console.WriteLine("Se ha creado la carpeta: {0}", newFolder);
            return newFolder;
        }

        public string createFile(string nameFile)
        {
            string cont = null;
            string pathFile = Path.Combine(_sesionPath, nameFile);
            if (File.Exists(pathFile))
            {
                cont = File.ReadAllText(pathFile);
            }
            else
            {
                File.Create(pathFile).Dispose();
                SystemConfiguration systemConfiguration = new SystemConfiguration(true, true);
                systemConfiguration.pictureBoxTurnON.Visible = false;
                systemConfiguration.labelWind.Visible = false;
                systemConfiguration.pictureBoxTurnOFF.Visible = false;
                systemConfiguration.ShowDialog();
                cont = File.ReadAllText(pathFile);
            }
            return Decrypt(cont);
        }


        public void writeFile(string file, string text)
        {
            string userFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string newFolder = Path.Combine(userFolderPath, "WMS");
            string saveFile = Path.Combine(newFolder, file);
            File.WriteAllText(saveFile, CreateEncrypt(text));
        }
    }
}
