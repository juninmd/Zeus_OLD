using MapeadorDeEntidades.Form.Properties;

namespace MapeadorDeEntidades.Form.Core
{
    public static class Tratamentos
    {
        public static string TratarNomeTabela(this string nome)
        {
            return nome.Replace(Settings.Default.PrefixoTabela, "");
        }

        public static string TratarNomePackage(this string nome)
        {
            return nome.Replace(Settings.Default.PrefixoTabela, Settings.Default.PrefixoPackage);
        }
        public static string TratarNomeBase(this string nome) { return $"\"{nome.Split(';')[1].Split('=')[1]}\""; }

        public static string TratarNomeSequence(this string nome)
        {
            return "SQ_" + nome.TratarNomeTabela() + ".NEXTVAL";
        }
    }
}
