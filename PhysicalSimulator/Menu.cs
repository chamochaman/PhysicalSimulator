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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

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
