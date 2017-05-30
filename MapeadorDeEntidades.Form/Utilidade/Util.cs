using System;
using System.Windows.Forms;
using Zeus.Core;

namespace Zeus.Utilidade
{
    public class Util
    {
        public static void Status(string text)
        {
            var data = DateTime.Now;
            Session.listaStatus.Items.Insert(0, $"{data.ToShortDateString()} - {data:hh:mm:ss} - {text}");
            Application.DoEvents();
        }
        public static void Barra(int valor)
        {
            Session.progressBar1.Value = valor;
            Application.DoEvents();
        }
    }
}
