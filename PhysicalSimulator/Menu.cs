using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace PhysicalSimulator
{
    /// <summary>
    /// Esta clase representa el menú principal para acceder al simulador.
    /// </summary>
    public partial class Menu : Form
    {
        /// <summary>
        /// Inicializa el WinForm
        /// </summary>
        public Menu()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Este método está asociado al botón de ingreso, dentro de éste, se revisa que el usuario y contraseña exista.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            bool login = false;
            string path = Directory.GetCurrentDirectory() + "/login.txt"; 
            string usuario, password;
            usuario = txbUsuario.Text;
            password = txbPassword.Text;

            //Abre el archivo en donde se encuentran los usuarios y contraseñas válidas
            using (var sr = new StreamReader(path))
            {
                string linea = sr.ReadLine();
             
                //Lee linea por linea todo el documento, hasta que llege a una linea que no tenga nada
                while (linea != "" && linea != null)
                {
                    //Parte la linea por el caracter & que separa usuario y contraseña
                    string[] lineaSplit = linea.Split('&');
                    if (lineaSplit.Count() < 2 || lineaSplit.Count() > 2)
                    {
                        MessageBox.Show("Error al leer los registros.");
                        return;
                    }
                    if (lineaSplit[0] == usuario && lineaSplit[1] == password)
                    {
                        login = true;
                        break;
                    }

                    linea = sr.ReadLine();
                }
            }

            //Si el log-in fue inválido
            if (!login)
            {
                MessageBox.Show("Error, verifique usuario y contraseña.");
                return;
            }

            //ejecuta el simulador
            Game1 game = new Game1();
            game.Run();
        }
    }
}
