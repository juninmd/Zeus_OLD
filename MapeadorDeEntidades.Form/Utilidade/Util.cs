using System;
using System.Windows.Forms;
using Zeus.Core;

namespace Zeus.Utilidade
{
    public class Util
    {
        public static void Status(string text)
        {
            Session.lblStatus.Text = text;
            Session.listaStatus.Items.Insert(0, $"{DateTime.Now.ToShortDateString()} - {DateTime.Now.ToShortTimeString()} - {text}");
            Application.DoEvents();
        }
        public static void Barra(int valor)
        {
            Session.progressBar1.Value = valor;
            Application.DoEvents();
        }
    }
}
