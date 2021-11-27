using ProjetoCadastro.Controller;
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
            Form1 telaInicial = new Form1();
            Controlador controlador = new Controlador(telaInicial);
            telaInicial.setControlador(controlador);
            Application.Run(telaInicial);
        }
    }
}
