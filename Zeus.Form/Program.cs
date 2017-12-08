using System;
using System.Windows.Forms;
using Zeus.Core;
using Zeus.Properties;

namespace Zeus
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            InitParamters();

            if (Settings.Default.SkipWelcome)
                Application.Run(new formWizard());
            else
            {
                Application.Run(new formWelcome());
            }
        }

        static void InitParamters()
        {
            ParamtersInput.Prefixos = new Prefixos
            {
                Package = Settings.Default.PrefixoPackage ?? "",
                Procedure = Settings.Default.PrefixoProcedure ?? "",
                Tabela = Settings.Default.PrefixoTabela ?? ""
            };

            ParamtersInput.SelectedPath = Settings.Default.Destino ?? "";
        }
    }
}
