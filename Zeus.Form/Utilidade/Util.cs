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
            if (Session.listaStatus != null)
                Session.listaStatus.Items.Insert(0, $"{data.ToShortDateString()} - {data:hh:mm:ss} - {text}");
            Application.DoEvents();
        }

        public static void Barra(int valor)
        {
            if (Session.progressBar1 != null)
                Session.progressBar1.Value = valor;
            Application.DoEvents();
        }
    }
}