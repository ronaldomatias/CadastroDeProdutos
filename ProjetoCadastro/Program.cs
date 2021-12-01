using ProjetoCadastro.Controller;
using ProjetoCadastro.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoCadastro
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form1 visao = new Form1();
            Modelo modelo = new Modelo();
            Controlador controlador = new Controlador(visao, modelo);
            Application.Run(visao);
        }
    }
}
