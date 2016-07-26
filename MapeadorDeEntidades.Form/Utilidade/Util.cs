using System.Windows.Forms;
using MapeadorDeEntidades.Form.Core;

namespace MapeadorDeEntidades.Form.Utilidade
{
    public class Util
    {
        public static void Status(string text)
        {
            Session.lblStatus.Text = text;
            Application.DoEvents();
        }
        public static void Barra(int valor)
        {
            Session.progressBar1.Value = valor;
            Application.DoEvents();
        }
    }
}
