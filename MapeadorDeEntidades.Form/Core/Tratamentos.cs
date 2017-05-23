using Zeus.Properties;

namespace Zeus.Core
{
    public static class Tratamentos
    {
        public static string TratarNomeTabela(this string nome)
        {
            return nome.ToUpper().Replace(Settings.Default.PrefixoTabela.ToUpper(), "");
        }

        public static string TratarNomePackage(this string nome)
        {
            return nome.ToUpper().Replace(Settings.Default.PrefixoTabela.ToUpper(), Settings.Default.PrefixoPackage);
        }
        public static string TratarNomeBase(this string nome) { return $"\"{nome.Split(';')[1].Split('=')[1]}\""; }
    }
}
